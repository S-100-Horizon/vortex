using System;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100Framework.AttributeModel.S123.SimpleAttributes
{
	/// <summary>
	/// A statement that expresses if it accepts AMVER(Automated Mutual-Assistance Vessel Rescue system) reports
	/// </summary>
	public class acceptAMVER : S100Framework.AttributeModel.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(acceptAMVER);
		[JsonIgnore]
		public override string S100FC_name => "Accept AMVER";

		public static implicit operator acceptAMVER(Boolean? value) => new acceptAMVER { value = value };
	}

	/// <summary>
	/// The action or activity of a vessel.
	/// </summary>
	public class actionOrActivity : S100Framework.AttributeModel.CodeListAttribute
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
			];
	}

	/// <summary>
	/// A generic term for an administrative region within a country at a level below that of the sovereign state.
	/// </summary>
	public class administrativeDivision : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(administrativeDivision);
		[JsonIgnore]
		public override string S100FC_name => "Administrative Division";

		public static implicit operator administrativeDivision(String? value) => new administrativeDivision { value = value };
	}

	/// <summary>
	/// Antenna height of the base station in metres.
	/// </summary>
	public class baseStationAntennaHeight : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(baseStationAntennaHeight);
		[JsonIgnore]
		public override string S100FC_name => "Base Station Antenna Height";

		public static implicit operator baseStationAntennaHeight(double? value) => new baseStationAntennaHeight { value = value };
	}

	/// <summary>
	/// The designated call name of a station; for example, radio station, radar station, pilot.
	/// </summary>
	public class callName : S100Framework.AttributeModel.TextAttribute
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
	public class callSign : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(callSign);
		[JsonIgnore]
		public override string S100FC_name => "Call Sign";

		public static implicit operator callSign(String? value) => new callSign { value = value };
	}

	/// <summary>
	/// Instructions provided on how to contact a particular person, organisation or service.
	/// </summary>
	public class contactInstructions : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(contactInstructions);
		[JsonIgnore]
		public override string S100FC_name => "Contact Instructions";

		public static implicit operator contactInstructions(String? value) => new contactInstructions { value = value };
	}

	/// <summary>
	/// The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.
	/// </summary>
	public class categoryOfAuthority : S100Framework.AttributeModel.EnumerationAttribute
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
	/// Classification of broadcast or communications based on public availability and commercial/non-commercial nature.
	/// </summary>
	public class categoryOfBroadcastCommunication : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfBroadcastCommunication);
		[JsonIgnore]
		public override string S100FC_name => "Category of Broadcast/Communication";
		public static listedValue[] listedValues => [
				new listedValue("Commercial", "A service operated with the intention of earning money.",1),
				new listedValue("Non-Commercial", "A service without any financial interest.",2),
				new listedValue("Public", "Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.",3),
				new listedValue("Non-Public", "A service available for limited and predefined customers.",4),
			];

		public static implicit operator categoryOfBroadcastCommunication(int? value) => new categoryOfBroadcastCommunication { value = value };
	}

	/// <summary>
	/// Classification of the different types of cargo that a ship may be carrying.
	/// </summary>
	public class categoryOfCargo : S100Framework.AttributeModel.EnumerationAttribute
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
	/// Classification of dangerous goods or hazardous materials based on the International Maritime Dangerous Goods Code (IMDG Code).
	/// </summary>
	public class categoryOfDangerousOrHazardousCargo : S100Framework.AttributeModel.EnumerationAttribute
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
	/// Classification of weather forecast and weather warning areas based on source of warnings and forecasts.
	/// </summary>
	public class categoryOfForecastOrWarningArea : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfForecastOrWarningArea);
		[JsonIgnore]
		public override string S100FC_name => "Category of Forecast or Warning Area";
		public static listedValue[] listedValues => [
				new listedValue("World Meteorological Organization (WMO)", "The forecast and warning area defined by WMO.",1),
				new listedValue("National High Seas", "The forecast and warning area defined by national authorities covering High Seas.",2),
				new listedValue("National Offshore", "The forecast and warning area defined by national authorities covering offshore waters.",3),
				new listedValue("National Coastal", "The forecast and warning area defined by national authorities covering coastal waters.",4),
				new listedValue("National Inshore", "The forecast and warning area defined by national authorities covering inshore waters.",5),
				new listedValue("National Local", "The forecast and warning area defined by national authorities covering local waters.",6),
				new listedValue("Ice", "The solid form of water.",7),
			];

		public static implicit operator categoryOfForecastOrWarningArea(int? value) => new categoryOfForecastOrWarningArea { value = value };
	}

	/// <summary>
	/// Classification of GMDSS areas based on availability of GMDSS services and GMDSS equipment requirements.
	/// </summary>
	public class categoryOfGMDSSArea : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfGMDSSArea);
		[JsonIgnore]
		public override string S100FC_name => "Category of GMDSS Area";
		public static listedValue[] listedValues => [
				new listedValue("Area A1", "Within range of VHF coast stations with continuous DSC alerting available (about 20 30 miles).",1),
				new listedValue("Area A2", "Beyond area A1, but within range of MF coastal stations with continuous DSC alerting available (about l00 miles).",2),
				new listedValue("Area A3", "An area, excluding sea areas A1 and A2, within the coverage of a recognized mobile satellite service supported by the ship earth station carried on board, in which continuous alerting is available.",3),
				new listedValue("Area A4", "The sea areas beyond Area 3. The most important of these is the sea around the North Pole (the area around the South Pole is mostly land). Geostationary satellites, which are positioned above the equator, cannot reach this far.",4),
			];

		public static implicit operator categoryOfGMDSSArea(int? value) => new categoryOfGMDSSArea { value = value };
	}

	/// <summary>
	/// Classification of radio services offered by a radio station.
	/// </summary>
	public class categoryOfRadioStation : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfRadioStation);
		[JsonIgnore]
		public override string S100FC_name => "Category of Radio Station";
		public static listedValue[] listedValues => [
				new listedValue("Radio Direction-Finding Station", "A radio station intended to determine only the direction of other stations by means of transmission from the latter.",5),
				new listedValue("Loran C", "A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.",9),
				new listedValue("Differential GNSS", "Differential GNSS is implemented by placing a GNSS monitor receiver at a precisely known location. Instead of computing a navigation fix, the monitor determines the range error to every GNSS satellite it can track. These ranging errors are then transmitted to local users where they are applied as corrections before computing the navigation result.",10),
				new listedValue("Radio Telephone Station", "The equipment needed at one station to carry on two way voice communication by radio waves only.",19),
				new listedValue("AIS Base Station", "An AIS shore station for use by competent authorities to provide AIS service, manage the data link and enable effective ship to shore / shore to ship transmission of information.",20),
			];

		public static implicit operator categoryOfRadioStation(int? value) => new categoryOfRadioStation { value = value };
	}

	/// <summary>
	/// Expresses constraints or requirements on vessel actions or activities in relation to a geographic feature, facility, or service.
	/// </summary>
	public class categoryOfRelationship : S100Framework.AttributeModel.EnumerationAttribute
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
			];

		public static implicit operator categoryOfRelationship(int? value) => new categoryOfRelationship { value = value };
	}

	/// <summary>
	/// The principal subject matter of regulations, restrictions, recommendations or nautical information.
	/// </summary>
	public class categoryOfRxN : S100Framework.AttributeModel.CodeListAttribute
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
	/// The type of schedule, for instance opening, closure, etc.
	/// </summary>
	public class categoryOfSchedule : S100Framework.AttributeModel.EnumerationAttribute
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
	/// An assessment of the likelihood of change over time.
	/// </summary>
	public class categoryOfTemporalVariation : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfTemporalVariation);
		[JsonIgnore]
		public override string S100FC_name => "Category of Temporal Variation";
		public static listedValue[] listedValues => [
				new listedValue("Extreme Event", "Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.",1),
				new listedValue("Likely to Change", "Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).",4),
				new listedValue("Unlikely to Change", "Significant change to the seafloor is not expected.",5),
			];

		public static implicit operator categoryOfTemporalVariation(int? value) => new categoryOfTemporalVariation { value = value };
	}

	/// <summary>
	/// Classification of completeness of textual information in relation to the source material from which it is derived.
	/// </summary>
	public class categoryOfText : S100Framework.AttributeModel.EnumerationAttribute
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
	/// Classification of vessels by function or use.
	/// </summary>
	public class categoryOfVessel : S100Framework.AttributeModel.CodeListAttribute
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
	/// The locality of vessel registration or enrolment relative to the nationality of a port, territorial sea, administrative area, exclusive zone or other location.
	/// </summary>
	public class categoryOfVesselRegistry : S100Framework.AttributeModel.EnumerationAttribute
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
	/// Category of the communication system providing the connectivity coverage for subscription.
	/// </summary>
	public class categoryOfConnectivitySubscription : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfConnectivitySubscription);
		[JsonIgnore]
		public override string S100FC_name => "Category of Connectivity Subscription";
		public static listedValue[] listedValues => [
				new listedValue("Satellite Communication GEO", "Communication using GEO (Geosynchronous Earth Orbit) satellites",1),
				new listedValue("Satellite Communication LEO", "Communication using LEO (Low Earth Orbit) satellites",2),
				new listedValue("Cellular Communication", "Communication using cellular network. Cellular network or mobile network enables wireless communication between mobile devices. The final stage of connectivity is achieved by segmenting the comprehensive service area into several compact zones, each called a cell. A stationary transceiver, known as a cell site or base station, provides service in each cell. The cell site links to the primary network infrastructure, employing either a wireless or wired connection.",3),
				new listedValue("Terrestrial Ad-Hoc Communication", "Communication using ad-hoc networking, which uses whatever resources available to create communication paths from an end-user device to its desired destination, independent from central network infrastructure or administration.",4),
			];

		public static implicit operator categoryOfConnectivitySubscription(int? value) => new categoryOfConnectivitySubscription { value = value };
	}

	/// <summary>
	/// The set of characteristics of an emission, designated by standard symbols, e.g. type of modulation of the main carrier, modulating signal, type of information to be transmitted, and also, if appropriate, any additional signal characteristics.
	/// </summary>
	public class classOfEmission : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(classOfEmission);
		[JsonIgnore]
		public override string S100FC_name => "Class of Emission";

		public static implicit operator classOfEmission(String? value) => new classOfEmission { value = value };
	}

	/// <summary>
	/// A code, issued according to a standard and coordination procedure, to identify the transmission of a coast radio station.
	/// </summary>
	public class coastStationIdentificationCode : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(coastStationIdentificationCode);
		[JsonIgnore]
		public override string S100FC_name => "Coast Station Identification Code";

		public static implicit operator coastStationIdentificationCode(String? value) => new coastStationIdentificationCode { value = value };
	}

	/// <summary>
	/// A channel number assigned to a specific radio frequency, frequencies or frequency band.
	/// </summary>
	public class communicationChannel : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(communicationChannel);
		[JsonIgnore]
		public override string S100FC_name => "Communication Channel";

		public static implicit operator communicationChannel(String? value) => new communicationChannel { value = value };
	}

	/// <summary>
	/// The communications standard applicable to accessing the radio service.
	/// </summary>
	public class communicationStandard : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(communicationStandard);
		[JsonIgnore]
		public override string S100FC_name => "Communication Standard";

		public static implicit operator communicationStandard(String? value) => new communicationStandard { value = value };
	}

	/// <summary>
	/// Numerical comparison.
	/// </summary>
	public class comparisonOperator : S100Framework.AttributeModel.EnumerationAttribute
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
	/// The name of a nation.
	/// </summary>
	public class countryName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(countryName);
		[JsonIgnore]
		public override string S100FC_name => "Country Name";

		public static implicit operator countryName(String? value) => new countryName { value = value };
	}

	/// <summary>
	/// The name of a town or city.
	/// </summary>
	public class cityName : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cityName);
		[JsonIgnore]
		public override string S100FC_name => "City Name";

		public static implicit operator cityName(String? value) => new cityName { value = value };
	}

	/// <summary>
	/// The average number of bits communicated (transmitted) in 1 second. (ITU Terms and Definitions)
	/// </summary>
	public class dataTransmissionRate : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(dataTransmissionRate);
		[JsonIgnore]
		public override string S100FC_name => "Data Transmission Rate";

		public static implicit operator dataTransmissionRate(int? value) => new dataTransmissionRate { value = value };
	}

	/// <summary>
	/// The latest date on which an object (for example a buoy) will be present.
	/// </summary>
	public class dateEnd : S100Framework.AttributeModel.S100_TruncatedDateAttribute
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
	public class dateFixed : S100Framework.AttributeModel.S100_TruncatedDateAttribute
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
	public class dateStart : S100Framework.AttributeModel.S100_TruncatedDateAttribute
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
	public class dateVariable : S100Framework.AttributeModel.TextAttribute
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
	public class dayOfWeek : S100Framework.AttributeModel.EnumerationAttribute
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
	public class dayOfWeekIsRange : S100Framework.AttributeModel.BooleanAttribute
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
	public class deliveryPoint : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(deliveryPoint);
		[JsonIgnore]
		public override string S100FC_name => "Delivery Point";

		public static implicit operator deliveryPoint(String? value) => new deliveryPoint { value = value };
	}

	/// <summary>
	/// Downlink bandwidth in Mbps
	/// </summary>
	public class downlinkBandwidth : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(downlinkBandwidth);
		[JsonIgnore]
		public override string S100FC_name => "Downlink Bandwidth";

		public static implicit operator downlinkBandwidth(double? value) => new downlinkBandwidth { value = value };
	}

	/// <summary>
	/// The estimated range of a non-optical electromagnetic transmission.
	/// </summary>
	public class estimatedRangeOfTransmission : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(estimatedRangeOfTransmission);
		[JsonIgnore]
		public override string S100FC_name => "Estimated Range of Transmission";

		public static implicit operator estimatedRangeOfTransmission(double? value) => new estimatedRangeOfTransmission { value = value };
	}

	/// <summary>
	/// The location of a fragment of text or other information in a support file.
	/// </summary>
	public class fileLocator : S100Framework.AttributeModel.TextAttribute
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
	public class fileReference : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fileReference);
		[JsonIgnore]
		public override string S100FC_name => "File Reference";

		public static implicit operator fileReference(String? value) => new fileReference { value = value };
	}

	/// <summary>
	/// A continuous set of frequencies lying between two specified limiting frequencies. (Rec. ITU-R V.662-3)
	/// </summary>
	public class frequencyBand : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyBand);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Band";
		public static listedValue[] listedValues => [
				new listedValue("LF", "Radio frequencies between 30 kHz and 300 kHz",1),
				new listedValue("MF", "Radio frequencies between 300 kHz and 3000 kHz",2),
				new listedValue("MF/HF", "Radio frequencies between 300 kHz and 30 MHz",3),
				new listedValue("HF", "Radio frequencies between 3 MHz and 30 MHz",4),
				new listedValue("VHF", "Radio frequencies between 30 MHz and 300 MHz",5),
				new listedValue("UHF", "Radio frequencies between 300 MHz and 3 GHz",6),
			];

		public static implicit operator frequencyBand(int? value) => new frequencyBand { value = value };
	}

	/// <summary>
	/// The shore station receiver frequency.
	/// </summary>
	public class frequencyShoreStationReceives : S100Framework.AttributeModel.IntegerAttribute
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
	public class frequencyShoreStationTransmits : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyShoreStationTransmits);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Shore Station Transmits";

		public static implicit operator frequencyShoreStationTransmits(int? value) => new frequencyShoreStationTransmits { value = value };
	}

	/// <summary>
	/// Lower limit of the frequency range in Hz.
	/// </summary>
	public class frequencyLimitLower : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyLimitLower);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Limit Lower";

		public static implicit operator frequencyLimitLower(int? value) => new frequencyLimitLower { value = value };
	}

	/// <summary>
	/// Upper limit of the frequency range in Hz.
	/// </summary>
	public class frequencyLimitUpper : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyLimitUpper);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Limit Upper";

		public static implicit operator frequencyLimitUpper(int? value) => new frequencyLimitUpper { value = value };
	}

	/// <summary>
	/// Words set at the head of a passage or page to introduce or categorize.
	/// </summary>
	public class headline : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(headline);
		[JsonIgnore]
		public override string S100FC_name => "Headline";

		public static implicit operator headline(String? value) => new headline { value = value };
	}

	/// <summary>
	/// The hours during which the watch on the radio channel is maintained. Hours are given in UTC, such as 0930-1000, or by using a service symbol such as "H24" for a 24 hour service.
	/// </summary>
	public class hoursOfWatch : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(hoursOfWatch);
		[JsonIgnore]
		public override string S100FC_name => "Hours of Watch";

		public static implicit operator hoursOfWatch(String? value) => new hoursOfWatch { value = value };
	}

	/// <summary>
	/// The best estimate of the horizontal accuracy of horizontal clearances and distances.
	/// </summary>
	public class horizontalDistanceUncertainty : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(horizontalDistanceUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Horizontal Distance Uncertainty";

		public static implicit operator horizontalDistanceUncertainty(double? value) => new horizontalDistanceUncertainty { value = value };
	}

	/// <summary>
	/// The identifier for a METAREA.
	/// </summary>
	public class idMETAREA : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(idMETAREA);
		[JsonIgnore]
		public override string S100FC_name => "Id METAREA";

		public static implicit operator idMETAREA(String? value) => new idMETAREA { value = value };
	}

	/// <summary>
	/// The identifier for a NAVAREA.
	/// </summary>
	public class idNAVAREA : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(idNAVAREA);
		[JsonIgnore]
		public override string S100FC_name => "Id NAVAREA";

		public static implicit operator idNAVAREA(String? value) => new idNAVAREA { value = value };
	}

	/// <summary>
	/// Whether the vessel is in ballast.
	/// </summary>
	public class inBallast : S100Framework.AttributeModel.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(inBallast);
		[JsonIgnore]
		public override string S100FC_name => "In Ballast";

		public static implicit operator inBallast(Boolean? value) => new inBallast { value = value };
	}

	/// <summary>
	/// The likelihood that a vessel will experience the phenomenon described by a feature, or that the service described by the feature will be available.
	/// </summary>
	public class informationConfidence : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(informationConfidence);
		[JsonIgnore]
		public override string S100FC_name => "Information Confidence";
		public static listedValue[] listedValues => [
				new listedValue("Virtually Certain", "Virtually certain to be experienced by (or available to) an individual vessel; will be experienced by nearly all vessels.",1),
				new listedValue("High Likelihood", "Frequently experienced by (or available to) an individual vessel; experienced by a majority of vessels.",2),
				new listedValue("Medium Likelihood", "Occasionally experienced by (or available to) an individual vessel; experienced by (or available to) about half of all vessels.",3),
				new listedValue("Low Likelihood", "Unlikely, but sometimes (rarely) experienced by (or available to) an individual vessel; experienced by (or available to) a minority of vessels.",4),
			];

		public static implicit operator informationConfidence(int? value) => new informationConfidence { value = value };
	}

	/// <summary>
	/// A common unique identifier for entities which describe a single real-world feature, and which is used to identify instances of the feature in end-user systems where the feature may be included in multiple data product types.
	/// </summary>
	public class interoperabilityIdentifier : S100Framework.AttributeModel.UrnTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(interoperabilityIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Interoperability Identifier";

		public static implicit operator interoperabilityIdentifier(String? value) => new interoperabilityIdentifier { value = value };
	}

	/// <summary>
	/// A statement that expresses if a Coast Guard station performs the function of a Maritime Rescue and Coordination Centre.
	/// </summary>
	public class isMRCC : S100Framework.AttributeModel.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(isMRCC);
		[JsonIgnore]
		public override string S100FC_name => "Is MRCC";

		public static implicit operator isMRCC(Boolean? value) => new isMRCC { value = value };
	}

	/// <summary>
	/// The method of human communication, either spoken or written, consisting of the use of words in a structured and conventional way.
	/// </summary>
	public class language : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(language);
		[JsonIgnore]
		public override string S100FC_name => "Language";

		public static implicit operator language(String? value) => new language { value = value };
	}

	/// <summary>
	/// A description of the languages, alphabets and scripts in use.
	/// </summary>
	public class languageInformation : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(languageInformation);
		[JsonIgnore]
		public override string S100FC_name => "Language Information";

		public static implicit operator languageInformation(String? value) => new languageInformation { value = value };
	}

	/// <summary>
	/// Location (address) for online access using a URL/URI address or similar addressing scheme.
	/// </summary>
	public class linkage : S100Framework.AttributeModel.UriTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(linkage);
		[JsonIgnore]
		public override string S100FC_name => "Linkage";

		public static implicit operator linkage(String? value) => new linkage { value = value };
	}

	/// <summary>
	/// Expresses whether all the constraints described by its co-attributes must be satisfied, or only one such constraint need be satisfied.
	/// </summary>
	public class logicalConnectives : S100Framework.AttributeModel.EnumerationAttribute
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
	/// Maximum data burst volume in bytes
	/// </summary>
	public class maximumDataBurstVolume : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(maximumDataBurstVolume);
		[JsonIgnore]
		public override string S100FC_name => "Maximum Data Burst Volume";

		public static implicit operator maximumDataBurstVolume(int? value) => new maximumDataBurstVolume { value = value };
	}

	/// <summary>
	/// The value considered by the Data Producer to be the maximum (largest) scale at which the data is to be displayed before it can be considered to be "grossly overscaled".
	/// </summary>
	public class maximumDisplayScale : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(maximumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Maximum Display Scale";

		public static implicit operator maximumDisplayScale(int? value) => new maximumDisplayScale { value = value };
	}

	/// <summary>
	/// Indicates whether a vessel is included or excluded from the regulation/restriction/recommendation/nautical information.
	/// </summary>
	public class membership : S100Framework.AttributeModel.EnumerationAttribute
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
	/// The smallest intended viewing scale for the data.
	/// </summary>
	public class minimumDisplayScale : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minimumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Minimum Display Scale";

		public static implicit operator minimumDisplayScale(int? value) => new minimumDisplayScale { value = value };
	}

	/// <summary>
	/// Minimum received power in dBm.
	/// </summary>
	public class minimumReceivedPower : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minimumReceivedPower);
		[JsonIgnore]
		public override string S100FC_name => "Minimum Received Power";

		public static implicit operator minimumReceivedPower(double? value) => new minimumReceivedPower { value = value };
	}

	/// <summary>
	/// The minimum value of Signal to Interference plus Noise Ratio (SINR) in dB.
	/// </summary>
	public class minimumSignalToInterferenceNoiseRatio : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minimumSignalToInterferenceNoiseRatio);
		[JsonIgnore]
		public override string S100FC_name => "Minimum Signal to Interference Noise Ratio";

		public static implicit operator minimumSignalToInterferenceNoiseRatio(double? value) => new minimumSignalToInterferenceNoiseRatio { value = value };
	}

	/// <summary>
	/// The minute past even hours when a routine transmission starts.
	/// </summary>
	public class minutePastEvenHours : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minutePastEvenHours);
		[JsonIgnore]
		public override string S100FC_name => "Minute Past Even Hours";

		public static implicit operator minutePastEvenHours(int? value) => new minutePastEvenHours { value = value };
	}

	/// <summary>
	/// The minute past every hour when a routine transmission starts.
	/// </summary>
	public class minutePastEveryHour : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minutePastEveryHour);
		[JsonIgnore]
		public override string S100FC_name => "Minute Past Every Hour";

		public static implicit operator minutePastEveryHour(int? value) => new minutePastEveryHour { value = value };
	}

	/// <summary>
	/// The minute past odd hours when a routine transmission starts.
	/// </summary>
	public class minutePastOddHours : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minutePastOddHours);
		[JsonIgnore]
		public override string S100FC_name => "Minute Past Odd Hours";

		public static implicit operator minutePastOddHours(int? value) => new minutePastOddHours { value = value };
	}

	/// <summary>
	/// The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations, coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.
	/// </summary>
	public class mMSICode : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(mMSICode);
		[JsonIgnore]
		public override string S100FC_name => "MMSI Code";

		public static implicit operator mMSICode(String? value) => new mMSICode { value = value };
	}

	/// <summary>
	/// The coastal warning area identification letter(s) to be selected to receive the Maritime Safety Information (MSI) for the corresponding coastal warning area(s).
	/// </summary>
	public class mSICoastalWarningArea : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(mSICoastalWarningArea);
		[JsonIgnore]
		public override string S100FC_name => "MSI Coastal Warning Area";

		public static implicit operator mSICoastalWarningArea(String? value) => new mSICoastalWarningArea { value = value };
	}

	/// <summary>
	/// The individual name of a feature.
	/// </summary>
	public class name : S100Framework.AttributeModel.TextAttribute
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
	public class nameOfResource : S100Framework.AttributeModel.TextAttribute
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
	public class nameUsage : S100Framework.AttributeModel.EnumerationAttribute
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
	public class nationality : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(nationality);
		[JsonIgnore]
		public override string S100FC_name => "Nationality";

		public static implicit operator nationality(String? value) => new nationality { value = value };
	}

	/// <summary>
	/// The time on each day when observations are made.
	/// </summary>
	public class observationTime : S100Framework.AttributeModel.TimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(observationTime);
		[JsonIgnore]
		public override string S100FC_name => "Observation Time";

		public static implicit operator observationTime(S100Framework.DomainModel.S100.Time? value) => new observationTime { value = value };
	}

	/// <summary>
	/// The largest intended viewing scale for the data.
	/// </summary>
	public class optimumDisplayScale : S100Framework.AttributeModel.IntegerAttribute
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
	public class orientationUncertainty : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(orientationUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Orientation Uncertainty";

		public static implicit operator orientationUncertainty(double? value) => new orientationUncertainty { value = value };
	}

	/// <summary>
	/// Packet delay in ms
	/// </summary>
	public class packetDelay : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(packetDelay);
		[JsonIgnore]
		public override string S100FC_name => "Packet Delay";

		public static implicit operator packetDelay(double? value) => new packetDelay { value = value };
	}

	/// <summary>
	/// The file name of an externally referenced picture file.
	/// </summary>
	public class pictorialRepresentation : S100Framework.AttributeModel.TextAttribute
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
	public class pictureCaption : S100Framework.AttributeModel.TextAttribute
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
	public class pictureInformation : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pictureInformation);
		[JsonIgnore]
		public override string S100FC_name => "Picture Information";

		public static implicit operator pictureInformation(String? value) => new pictureInformation { value = value };
	}

	/// <summary>
	/// Known in various countries as a postcode, or ZIP code, the postal code is a series of letters and/or digits that identifies each postal delivery area.
	/// </summary>
	public class postalCode : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(postalCode);
		[JsonIgnore]
		public override string S100FC_name => "Postal Code";

		public static implicit operator postalCode(String? value) => new postalCode { value = value };
	}

	/// <summary>
	/// Presumed receiver antenna height for the calculation of radio coverage.
	/// </summary>
	public class presumedReceiverAntennaHeight : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(presumedReceiverAntennaHeight);
		[JsonIgnore]
		public override string S100FC_name => "Presumed Receiver Antenna Height";

		public static implicit operator presumedReceiverAntennaHeight(double? value) => new presumedReceiverAntennaHeight { value = value };
	}

	/// <summary>
	/// The degree of reliability attributed to a position.
	/// </summary>
	public class qualityOfHorizontalMeasurement : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(qualityOfHorizontalMeasurement);
		[JsonIgnore]
		public override string S100FC_name => "Quality of Horizontal Measurement";
		public static listedValue[] listedValues => [
				new listedValue("Approximate", "A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.",4),
			];

		public static implicit operator qualityOfHorizontalMeasurement(int? value) => new qualityOfHorizontalMeasurement { value = value };
	}

	/// <summary>
	/// A statement that expresses if it is remote controlled.
	/// </summary>
	public class remoteControlled : S100Framework.AttributeModel.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(remoteControlled);
		[JsonIgnore]
		public override string S100FC_name => "Remote Controlled";

		public static implicit operator remoteControlled(Boolean? value) => new remoteControlled { value = value };
	}

	/// <summary>
	/// The date that the item was observed, done, or investigated.
	/// </summary>
	public class reportedDate : S100Framework.AttributeModel.S100_TruncatedDateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(reportedDate);
		[JsonIgnore]
		public override string S100FC_name => "Reported Date";

		public static implicit operator reportedDate(String? value) => new reportedDate { value = value };
	}

	/// <summary>
	/// The identifier of the ocean region area, within which a station can obtain line-of-sight communication, with an Inmarsat satellite.
	/// </summary>
	public class satelliteOceanRegion : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(satelliteOceanRegion);
		[JsonIgnore]
		public override string S100FC_name => "Satellite Ocean Region";

		public static implicit operator satelliteOceanRegion(String? value) => new satelliteOceanRegion { value = value };
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector bearing specifies the limit of the sector.
	/// </summary>
	public class sectorBearing : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorBearing);
		[JsonIgnore]
		public override string S100FC_name => "Sector Bearing";

		public static implicit operator sectorBearing(double? value) => new sectorBearing { value = value };
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector line length specifies the displayed length of the line, in ground units, defining the limit of the sector.
	/// </summary>
	public class sectorLineLength : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorLineLength);
		[JsonIgnore]
		public override string S100FC_name => "Sector Line Length";

		public static implicit operator sectorLineLength(double? value) => new sectorLineLength { value = value };
	}

	/// <summary>
	/// When stations of the maritime mobile service (direct printing telegraphy) use selective calling devices, their Selective Call numbers (SELCAL) are formed of four digits (coast stations).
	/// </summary>
	public class selectiveCallNumber : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(selectiveCallNumber);
		[JsonIgnore]
		public override string S100FC_name => "Selective Call Number";

		public static implicit operator selectiveCallNumber(int? value) => new selectiveCallNumber { value = value };
	}

	/// <summary>
	/// The Recognized Mobile Satellite Service (RMSS) providing the service through a satellite system that is recognized by the IMO, for use in the GMDSS
	/// </summary>
	public class servingMobileSatelliteService : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(servingMobileSatelliteService);
		[JsonIgnore]
		public override string S100FC_name => "Serving Mobile Satellite Service";
		public static listedValue[] listedValues => [
				new listedValue("Inmarsat SafetyNET", "An international automatic direct-printing satellite-based service using Inmarsat C Enhanced Group Call (EGC) system for the promulgation of Maritime Safety Information (MSI), navigational and meteorological warnings, meteorological forecasts, Search and Rescue (SAR) related information and other urgent safety-related messages to ships.",1),
				new listedValue("Iridium SafetyCast", "A service based on Iridium mobile-satellite system for the promulgation of Maritime Safety Information (MSI), navigational and meteorological warnings, meteorological forecasts, SAR-related information and other urgent safety-related messages to ships.",2),
			];

		public static implicit operator servingMobileSatelliteService(int? value) => new servingMobileSatelliteService { value = value };
	}

	/// <summary>
	/// The production date of the source; for example the date of measurement.
	/// </summary>
	public class sourceDate : S100Framework.AttributeModel.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceDate);
		[JsonIgnore]
		public override string S100FC_name => "Source Date";

		public static implicit operator sourceDate(DateOnly? value) => new sourceDate { value = value };
	}

	/// <summary>
	/// The publication, document, or reference work from which information comes or is acquired.
	/// </summary>
	public class source : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(source);
		[JsonIgnore]
		public override string S100FC_name => "Source";

		public static implicit operator source(String? value) => new source { value = value };
	}

	/// <summary>
	/// The condition of an object at a given instant in time.
	/// </summary>
	public class status : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(status);
		[JsonIgnore]
		public override string S100FC_name => "Status";
		public static listedValue[] listedValues => [
				new listedValue("Permanent", "Intended to last or function indefinitely.",1),
				new listedValue("Occasional", "Acting on special occasions; happening irregularly.",2),
				new listedValue("Not in Use", "Use has ceased, but the facility still exists intact; disused.",4),
				new listedValue("Periodic/Intermittent", "Recurring at intervals.",5),
				new listedValue("Temporary", "Meant to last only for a time.",7),
				new listedValue("Private", "Administered by an individual or corporation, rather than a State or a public body.",8),
				new listedValue("Public", "Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.",14),
				new listedValue("Watched", "Looked at or observed over a period of time especially so as to be aware of any movement or change.",16),
				new listedValue("Unwatched", "Usually automatic in operation, without any permanently-stationed personnel to superintend it.",17),
				new listedValue("Strong", "Not easily broken or destroyed.",24),
				new listedValue("Good", "In a satisfactory condition to use.",25),
				new listedValue("Moderately", "Fairly but not very.",26),
				new listedValue("Poor", "Not as good as it could be or should.",27),
			];

		public static implicit operator status(int? value) => new status { value = value };
	}

	/// <summary>
	/// Descriptions of the subject of the transmitted message.
	/// </summary>
	public class subjectDescription : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(subjectDescription);
		[JsonIgnore]
		public override string S100FC_name => "Subject Description";

		public static implicit operator subjectDescription(String? value) => new subjectDescription { value = value };
	}

	/// <summary>
	/// A code specified for a communication system to indicate the subject group or message type of the transmitted content, e.g., message type of DGNSS, subject code for NAVDAT, or subject indicator character for NAVTEX. 
	/// </summary>
	public class subjectOrMessageTypeCode : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(subjectOrMessageTypeCode);
		[JsonIgnore]
		public override string S100FC_name => "Subject or Message Type Code";

		public static implicit operator subjectOrMessageTypeCode(String? value) => new subjectOrMessageTypeCode { value = value };
	}

	/// <summary>
	/// An identifier, such as words, numbers, letters, symbols, or any combination of those used to establish a contact to a particular person, organisation or service.
	/// </summary>
	public class telecommunicationIdentifier : S100Framework.AttributeModel.TextAttribute
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
	public class telecommunicationService : S100Framework.AttributeModel.EnumerationAttribute
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
	public class text : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(text);
		[JsonIgnore]
		public override string S100FC_name => "Text";

		public static implicit operator text(String? value) => new text { value = value };
	}

	/// <summary>
	/// The thickness of ice that the ship can safely transit.
	/// </summary>
	public class thicknessOfIceCapability : S100Framework.AttributeModel.IntegerAttribute
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
	public class timeOfDayEnd : S100Framework.AttributeModel.TimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timeOfDayEnd);
		[JsonIgnore]
		public override string S100FC_name => "Time of Day End";

		public static implicit operator timeOfDayEnd(S100Framework.DomainModel.S100.Time? value) => new timeOfDayEnd { value = value };
	}

	/// <summary>
	/// The time corresponding to the start of an active period.
	/// </summary>
	public class timeOfDayStart : S100Framework.AttributeModel.TimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timeOfDayStart);
		[JsonIgnore]
		public override string S100FC_name => "Time of Day Start";

		public static implicit operator timeOfDayStart(S100Framework.DomainModel.S100.Time? value) => new timeOfDayStart { value = value };
	}

	/// <summary>
	/// Content of transmission.
	/// </summary>
	public class transmissionContent : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(transmissionContent);
		[JsonIgnore]
		public override string S100FC_name => "Transmission Content";

		public static implicit operator transmissionContent(String? value) => new transmissionContent { value = value };
	}

	/// <summary>
	/// The NAVTEX transmitter identification character is a single unique letter, which is allocated to each transmitter. It is used to identify the broadcasts, which are to be accepted by the receiver, those which are to be rejected, and the time slot for the transmission.
	/// </summary>
	public class transmitterIdentificationCharacter : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(transmitterIdentificationCharacter);
		[JsonIgnore]
		public override string S100FC_name => "Transmitter Identification Character";

		public static implicit operator transmitterIdentificationCharacter(String? value) => new transmitterIdentificationCharacter { value = value };
	}

	/// <summary>
	/// Describes whether a station transmits traffic lists.
	/// </summary>
	public class transmissionOfTrafficLists : S100Framework.AttributeModel.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(transmissionOfTrafficLists);
		[JsonIgnore]
		public override string S100FC_name => "Transmission of Traffic Lists";

		public static implicit operator transmissionOfTrafficLists(Boolean? value) => new transmissionOfTrafficLists { value = value };
	}

	/// <summary>
	/// The maximum power the radio service uses (or is authorized to use) for radio transmission.
	/// </summary>
	public class transmissionPower : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(transmissionPower);
		[JsonIgnore]
		public override string S100FC_name => "Transmission Power";

		public static implicit operator transmissionPower(double? value) => new transmissionPower { value = value };
	}

	/// <summary>
	/// Classification of regularity or conditions for transmission.
	/// </summary>
	public class transmissionRegularity : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(transmissionRegularity);
		[JsonIgnore]
		public override string S100FC_name => "Transmission Regularity";
		public static listedValue[] listedValues => [
				new listedValue("Continuous", "Transmission is made continuously.",1),
				new listedValue("Regular", "Transmission is made regularly according to a schedule.",2),
				new listedValue("On Receipt", "Transmission is made when warning or information is received from another authority.",3),
				new listedValue("As Required", "Transmission is made under specified conditions or when needed.",4),
				new listedValue("On Request", "When you ask for it.",5),
			];

		public static implicit operator transmissionRegularity(int? value) => new transmissionRegularity { value = value };
	}

	/// <summary>
	/// The time in the day when scheduled transmissions start.
	/// </summary>
	public class transmissionTime : S100Framework.AttributeModel.TimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(transmissionTime);
		[JsonIgnore]
		public override string S100FC_name => "Transmission Time";

		public static implicit operator transmissionTime(S100Framework.DomainModel.S100.Time? value) => new transmissionTime { value = value };
	}

	/// <summary>
	/// Categorization of the broadcast content by subject.
	/// </summary>
	public class typeOfBroadcastContent : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(typeOfBroadcastContent);
		[JsonIgnore]
		public override string S100FC_name => "Type of Broadcast Content";
		public static listedValue[] listedValues => [
				new listedValue("Navigational Warning", "A message containing urgent information relevant to safe navigation broadcast to ships in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended.",1),
				new listedValue("Meteorological Warnings and Forecasts", "Marine meteorological warning and forecast information in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974",2),
				new listedValue("SAR Information", "Broadcast message with information about an ongoing Search and Rescue operation.",3),
				new listedValue("Marine Security or Piracy Warnings", "Security-related requirements in accordance to International Ship and Port Facility Security (ISPS) Code, or warnings related to acts of piracy and armed robbery against ships",4),
				new listedValue("Tsunamis or Natural Phenomena Warnings", "Warnings related to tsunamis and other natural phenomena, such as abnormal changes to sea level",5),
				new listedValue("Pilot and VTS Service Messages", "Messages related to pilot and VTS service, such as temporary alterations, movement or suspension to pilot or VTS services",6),
				new listedValue("Military Information", "Information concerning military events, such as military exercises, missile firings.",7),
				new listedValue("Special Service or Application Specific Messages", "Broadcast for special services or other application specific messages",8),
				new listedValue("Ice Report", "Report of the ice situation and restrictions to shipping.",9),
			];

		public static implicit operator typeOfBroadcastContent(int? value) => new typeOfBroadcastContent { value = value };
	}

	/// <summary>
	/// Categorization of the connectivity resource by Quality o Service (QoS).
	/// </summary>
	public class typeOfConnectivityResource : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(typeOfConnectivityResource);
		[JsonIgnore]
		public override string S100FC_name => "Type of Connectivity Resource";
		public static listedValue[] listedValues => [
				new listedValue("Guaranteed Bit Rate", "The type of Quality of Service (QoS) Flow or a QoS parameter that defines the minimum data rate that must be guaranteed for a specific service or traffic flow.",1),
				new listedValue("Non-Guaranteed Bit Rate", "The type of Quality of Service (QoS) Flow that does not provide the end-user a guaranteed flow bit rate,  typically used for non-time-sensitive applications, e.g., web browsing, buffered streaming, and instant messenger applications",2),
				new listedValue("Delay Critical Guaranteed Bit Rate", "The type of Quality of Service (QoS) Flow that provides latencies significantly lower than guaranteed flow bit rate. Typically used in mission critical application like automation or intelligent transportation systems",3),
				new listedValue("Best Effort", "The network or service that does not support quality of service, does its best to deliver packets, but does not guarantee delivery or control delay",4),
			];

		public static implicit operator typeOfConnectivityResource(int? value) => new typeOfConnectivityResource { value = value };
	}

	/// <summary>
	/// Type of service of the NAVTEX, an international one or a national one.
	/// </summary>
	public class typeOfNAVTEXService : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(typeOfNAVTEXService);
		[JsonIgnore]
		public override string S100FC_name => "Type of NAVTEX Service";
		public static listedValue[] listedValues => [
				new listedValue("International NAVTEX", "The coordinated broadcast and automatic reception on 518 kHz of maritime safety information by means of narrow-band direct-printing telegraphy using the English language.",1),
				new listedValue("National NAVTEX", "The broadcast and automatic reception of maritime safety information by means of narrow-band direct-printing telegraphy using frequencies other than 518 kHz and languages as decided by the Administration concerned.",2),
			];

		public static implicit operator typeOfNAVTEXService(int? value) => new typeOfNAVTEXService { value = value };
	}

	/// <summary>
	/// Categorization of the radio service by the technology or system
	/// </summary>
	public class typeOfRadioService : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(typeOfRadioService);
		[JsonIgnore]
		public override string S100FC_name => "Type of Radio Service";
		public static listedValue[] listedValues => [
				new listedValue("Digital Selective Calling", "Radio service using Digital Selective Calling (DSC) techniques.",1),
				new listedValue("Radio Telephony", "Radio service using Radio Telephony (RT).",2),
				new listedValue("Public Correspondence Service", "Radio service with the coast station providing a public correspondence service.",3),
				new listedValue("Radio Telegraphy", "Radio service using Radio Telegraphy (WT)",4),
				new listedValue("NBDP Telegraphy (Narrow Band Direct Printing Telegraphy)", "A communications system consisting of teletypewriters connected to a telephonic network to send and receive Narrow Band Direct Printing.",5),
				new listedValue("Radio Facsimile", "Radio service using radio facsimile",6),
				new listedValue("Digital", "A method of representing information by combinations of discrete and discontinuous data.",7),
				new listedValue("Data", "A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.",8),
				new listedValue("NAVTEX", "The system for the broadcast and automatic reception of maritime safety information by means of narrow-band direct-printing telegraphy.",9),
				new listedValue("Enhanced Group Call", "The broadcast of coordinated maritime safety information and search and rescue related information, to a defined geographical area using a recognized mobile satellite service.",10),
				new listedValue("Automatic Identification System", "An automatic communication and identification system intended to improve the safety of navigation by assisting the efficient operation of Vessel Traffic Services (VTS), ship reporting, and ship-to-ship and ship-to-shore operations.",11),
				new listedValue("Special Service or Application Specific Messages", "Broadcast for special services or other application specific messages.",12),
				new listedValue("Satellite Communication", "Communication using a satellite system",13),
				new listedValue("Navigational Data System", "A digital system referred to as navigational data for broadcasting maritime safety and security related information from shore-to-ship.",14),
			];

		public static implicit operator typeOfRadioService(int? value) => new typeOfRadioService { value = value };
	}

	/// <summary>
	/// The best estimate of the fixed horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.
	/// </summary>
	public class uncertaintyFixed : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(uncertaintyFixed);
		[JsonIgnore]
		public override string S100FC_name => "Uncertainty Fixed";

		public static implicit operator uncertaintyFixed(double? value) => new uncertaintyFixed { value = value };
	}

	/// <summary>
	/// The factor to be applied to the variable component of an uncertainty equation so as to provide the best estimate of the variable horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.
	/// </summary>
	public class uncertaintyVariableFactor : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(uncertaintyVariableFactor);
		[JsonIgnore]
		public override string S100FC_name => "Uncertainty Variable Factor";

		public static implicit operator uncertaintyVariableFactor(double? value) => new uncertaintyVariableFactor { value = value };
	}

	/// <summary>
	/// Uplink bandwith in Mbps
	/// </summary>
	public class uplinkBandwidth : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(uplinkBandwidth);
		[JsonIgnore]
		public override string S100FC_name => "Uplink Bandwidth";

		public static implicit operator uplinkBandwidth(double? value) => new uplinkBandwidth { value = value };
	}

	/// <summary>
	/// Characteristics of vessels.
	/// </summary>
	public class vesselsCharacteristics : S100Framework.AttributeModel.EnumerationAttribute
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
	public class vesselsCharacteristicsUnit : S100Framework.AttributeModel.EnumerationAttribute
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
	public class vesselsCharacteristicsValue : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(vesselsCharacteristicsValue);
		[JsonIgnore]
		public override string S100FC_name => "Vessels Characteristics Value";

		public static implicit operator vesselsCharacteristicsValue(double? value) => new vesselsCharacteristicsValue { value = value };
	}

	/// <summary>
	/// A description of the required handling characteristics of a vessel including hull design, main and auxiliary machinery, cargo handling equipment, navigation equipment and manoeuvring behaviour.
	/// </summary>
	public class vesselPerformance : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(vesselPerformance);
		[JsonIgnore]
		public override string S100FC_name => "Vessel Performance";

		public static implicit operator vesselPerformance(String? value) => new vesselPerformance { value = value };
	}

}

namespace S100Framework.AttributeModel.S123.ComplexAttributes
{
	using S100Framework.AttributeModel.S123.SimpleAttributes;

	/// <summary>
	/// Description of the radio service for area A3 of the Global Maritime Distress and Safety System (GMDSS).
	/// </summary>
	public class areaA3ServiceDescription : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(areaA3ServiceDescription);
		[JsonIgnore]
		public override string S100FC_name => "Area A3 Service Description";
		public servingMobileSatelliteService servingMobileSatelliteService { get; set; } = new servingMobileSatelliteService();

		[JsonIgnore]
		public override Attribute[] attributes => [
				servingMobileSatelliteService,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(servingMobileSatelliteService),
					lower = 1,
					upper = 2147483647,
					permitedValues = [1,2],
					CreateInstance = () => new servingMobileSatelliteService(),
				},
				new attributeBinding {
					attribute = nameof(satelliteOceanRegion),
					lower = 0,
					upper = 1,
					CreateInstance = () => new satelliteOceanRegion(),
				},
				new attributeBinding {
					attribute = nameof(mSICoastalWarningArea),
					lower = 0,
					upper = 1,
					CreateInstance = () => new mSICoastalWarningArea(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int?[] servingMobileSatelliteService_optional {
			set { base.SetAttribute([.. value.Select(e=> new servingMobileSatelliteService { value = e })]); }
			get { return base.GetAttributeValues<servingMobileSatelliteService>(nameof(servingMobileSatelliteService)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? satelliteOceanRegion_optional {
			set { base.SetAttribute(new satelliteOceanRegion { value = value }); }
			get { return base.GetAttributeValue<satelliteOceanRegion>(nameof(satelliteOceanRegion))?.value; }
		}
		[JsonIgnore]
		public String? mSICoastalWarningArea_optional {
			set { base.SetAttribute(new mSICoastalWarningArea { value = value }); }
			get { return base.GetAttributeValue<mSICoastalWarningArea>(nameof(mSICoastalWarningArea))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Details related to the content of the broadcast.
	/// </summary>
	public class broadcastContent : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(broadcastContent);
		[JsonIgnore]
		public override string S100FC_name => "Broadcast Content";
		public typeOfBroadcastContent typeOfBroadcastContent { get; set; } = new typeOfBroadcastContent();

		[JsonIgnore]
		public override Attribute[] attributes => [
				typeOfBroadcastContent,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(typeOfBroadcastContent),
					lower = 1,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new typeOfBroadcastContent(),
				},
				new attributeBinding {
					attribute = nameof(subjectOrMessageTypeCode),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new subjectOrMessageTypeCode(),
				},
				new attributeBinding {
					attribute = nameof(subjectDescription),
					lower = 0,
					upper = 1,
					CreateInstance = () => new subjectDescription(),
				},
				new attributeBinding {
					attribute = nameof(observationTime),
					lower = 0,
					upper = 1,
					CreateInstance = () => new observationTime(),
				},
				new attributeBinding {
					attribute = nameof(transmissionRegularity),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5],
					CreateInstance = () => new transmissionRegularity(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int?[] typeOfBroadcastContent_optional {
			set { base.SetAttribute([.. value.Select(e=> new typeOfBroadcastContent { value = e })]); }
			get { return base.GetAttributeValues<typeOfBroadcastContent>(nameof(typeOfBroadcastContent)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] subjectOrMessageTypeCode_optional {
			set { base.SetAttribute([.. value.Select(e=> new subjectOrMessageTypeCode { value = e })]); }
			get { return base.GetAttributeValues<subjectOrMessageTypeCode>(nameof(subjectOrMessageTypeCode)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? subjectDescription_optional {
			set { base.SetAttribute(new subjectDescription { value = value }); }
			get { return base.GetAttributeValue<subjectDescription>(nameof(subjectDescription))?.value; }
		}
		[JsonIgnore]
		public S100Framework.DomainModel.S100.Time? observationTime_optional {
			set { base.SetAttribute(new observationTime { value = value }); }
			get { return base.GetAttributeValue<observationTime>(nameof(observationTime))?.value; }
		}
		[JsonIgnore]
		public int? transmissionRegularity_optional {
			set { base.SetAttribute(new transmissionRegularity { value = value }); }
			get { return base.GetAttributeValue<transmissionRegularity>(nameof(transmissionRegularity))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
	/// </summary>
	public class contactAddress : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(contactAddress);
		[JsonIgnore]
		public override string S100FC_name => "Contact Address";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(deliveryPoint),
					lower = 0,
					upper = 1,
					CreateInstance = () => new deliveryPoint(),
				},
				new attributeBinding {
					attribute = nameof(cityName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new cityName(),
				},
				new attributeBinding {
					attribute = nameof(administrativeDivision),
					lower = 0,
					upper = 1,
					CreateInstance = () => new administrativeDivision(),
				},
				new attributeBinding {
					attribute = nameof(countryName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new countryName(),
				},
				new attributeBinding {
					attribute = nameof(postalCode),
					lower = 0,
					upper = 1,
					CreateInstance = () => new postalCode(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? deliveryPoint_optional {
			set { base.SetAttribute(new deliveryPoint { value = value }); }
			get { return base.GetAttributeValue<deliveryPoint>(nameof(deliveryPoint))?.value; }
		}
		[JsonIgnore]
		public String? cityName_optional {
			set { base.SetAttribute(new cityName { value = value }); }
			get { return base.GetAttributeValue<cityName>(nameof(cityName))?.value; }
		}
		[JsonIgnore]
		public String? administrativeDivision_optional {
			set { base.SetAttribute(new administrativeDivision { value = value }); }
			get { return base.GetAttributeValue<administrativeDivision>(nameof(administrativeDivision))?.value; }
		}
		[JsonIgnore]
		public String? countryName_optional {
			set { base.SetAttribute(new countryName { value = value }); }
			get { return base.GetAttributeValue<countryName>(nameof(countryName))?.value; }
		}
		[JsonIgnore]
		public String? postalCode_optional {
			set { base.SetAttribute(new postalCode { value = value }); }
			get { return base.GetAttributeValue<postalCode>(nameof(postalCode))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Details related to the indication of the radio coverage.
	/// </summary>
	public class coverageIndication : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(coverageIndication);
		[JsonIgnore]
		public override string S100FC_name => "Coverage Indication";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(minimumReceivedPower),
					lower = 0,
					upper = 1,
					CreateInstance = () => new minimumReceivedPower(),
				},
				new attributeBinding {
					attribute = nameof(presumedReceiverAntennaHeight),
					lower = 0,
					upper = 1,
					CreateInstance = () => new presumedReceiverAntennaHeight(),
				},
				new attributeBinding {
					attribute = nameof(minimumSignalToInterferenceNoiseRatio),
					lower = 0,
					upper = 1,
					CreateInstance = () => new minimumSignalToInterferenceNoiseRatio(),
				},
				new attributeBinding {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,4,5,7,8,14,16,17,24,25,26,27],
					CreateInstance = () => new status(),
				},
				new attributeBinding {
					attribute = nameof(text),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new text(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public double? minimumReceivedPower_optional {
			set { base.SetAttribute(new minimumReceivedPower { value = value }); }
			get { return base.GetAttributeValue<minimumReceivedPower>(nameof(minimumReceivedPower))?.value; }
		}
		[JsonIgnore]
		public double? presumedReceiverAntennaHeight_optional {
			set { base.SetAttribute(new presumedReceiverAntennaHeight { value = value }); }
			get { return base.GetAttributeValue<presumedReceiverAntennaHeight>(nameof(presumedReceiverAntennaHeight))?.value; }
		}
		[JsonIgnore]
		public double? minimumSignalToInterferenceNoiseRatio_optional {
			set { base.SetAttribute(new minimumSignalToInterferenceNoiseRatio { value = value }); }
			get { return base.GetAttributeValue<minimumSignalToInterferenceNoiseRatio>(nameof(minimumSignalToInterferenceNoiseRatio))?.value; }
		}
		[JsonIgnore]
		public int?[] status_optional {
			set { base.SetAttribute([.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] text_optional {
			set { base.SetAttribute([.. value.Select(e=> new text { value = e })]); }
			get { return base.GetAttributeValues<text>(nameof(text)).Select(e=>e.value).ToArray(); }
		}
		#endregion
	}

	/// <summary>
	/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
	/// </summary>
	public class featureName : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(featureName);
		[JsonIgnore]
		public override string S100FC_name => "Feature Name";
		public language language { get; set; } = new language();
		public name name { get; set; } = new name();

		[JsonIgnore]
		public override Attribute[] attributes => [
				language,
				name,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(language),
					lower = 1,
					upper = 1,
					CreateInstance = () => new language(),
				},
				new attributeBinding {
					attribute = nameof(name),
					lower = 1,
					upper = 1,
					CreateInstance = () => new name(),
				},
				new attributeBinding {
					attribute = nameof(nameUsage),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new nameUsage(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? nameUsage_optional {
			set { base.SetAttribute(new nameUsage { value = value }); }
			get { return base.GetAttributeValue<nameUsage>(nameof(nameUsage))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// An active period of a single fixed event or occurrence, as the date range between discrete start and end dates.
	/// </summary>
	public class fixedDateRange : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fixedDateRange);
		[JsonIgnore]
		public override string S100FC_name => "Fixed Date Range";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(dateStart),
					lower = 0,
					upper = 1,
					CreateInstance = () => new dateStart(),
				},
				new attributeBinding {
					attribute = nameof(dateEnd),
					lower = 0,
					upper = 1,
					CreateInstance = () => new dateEnd(),
				},
				new attributeBinding {
					attribute = nameof(timeOfDayStart),
					lower = 0,
					upper = 1,
					CreateInstance = () => new timeOfDayStart(),
				},
				new attributeBinding {
					attribute = nameof(timeOfDayEnd),
					lower = 0,
					upper = 1,
					CreateInstance = () => new timeOfDayEnd(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? dateStart_optional {
			set { base.SetAttribute(new dateStart { value = value }); }
			get { return base.GetAttributeValue<dateStart>(nameof(dateStart))?.value; }
		}
		[JsonIgnore]
		public String? dateEnd_optional {
			set { base.SetAttribute(new dateEnd { value = value }); }
			get { return base.GetAttributeValue<dateEnd>(nameof(dateEnd))?.value; }
		}
		[JsonIgnore]
		public S100Framework.DomainModel.S100.Time? timeOfDayStart_optional {
			set { base.SetAttribute(new timeOfDayStart { value = value }); }
			get { return base.GetAttributeValue<timeOfDayStart>(nameof(timeOfDayStart))?.value; }
		}
		[JsonIgnore]
		public S100Framework.DomainModel.S100.Time? timeOfDayEnd_optional {
			set { base.SetAttribute(new timeOfDayEnd { value = value }); }
			get { return base.GetAttributeValue<timeOfDayEnd>(nameof(timeOfDayEnd))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
	/// </summary>
	public class frequencyPair : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyPair);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Pair";
		public frequencyShoreStationTransmits frequencyShoreStationTransmits { get; set; } = new frequencyShoreStationTransmits();

		[JsonIgnore]
		public override Attribute[] attributes => [
				frequencyShoreStationTransmits,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(frequencyShoreStationReceives),
					lower = 0,
					upper = 1,
					CreateInstance = () => new frequencyShoreStationReceives(),
				},
				new attributeBinding {
					attribute = nameof(frequencyShoreStationTransmits),
					lower = 1,
					upper = 1,
					CreateInstance = () => new frequencyShoreStationTransmits(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? frequencyShoreStationReceives_optional {
			set { base.SetAttribute(new frequencyShoreStationReceives { value = value }); }
			get { return base.GetAttributeValue<frequencyShoreStationReceives>(nameof(frequencyShoreStationReceives))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Frequency range of the electromagnetic spectrum in which the transmission is provided.
	/// </summary>
	public class frequencyRange : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(frequencyRange);
		[JsonIgnore]
		public override string S100FC_name => "Frequency Range";
		public frequencyLimitLower frequencyLimitLower { get; set; } = new frequencyLimitLower();
		public frequencyLimitUpper frequencyLimitUpper { get; set; } = new frequencyLimitUpper();

		[JsonIgnore]
		public override Attribute[] attributes => [
				frequencyLimitLower,
				frequencyLimitUpper,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(frequencyLimitLower),
					lower = 1,
					upper = 1,
					CreateInstance = () => new frequencyLimitLower(),
				},
				new attributeBinding {
					attribute = nameof(frequencyLimitUpper),
					lower = 1,
					upper = 1,
					CreateInstance = () => new frequencyLimitUpper(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
	/// </summary>
	public class graphic : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(graphic);
		[JsonIgnore]
		public override string S100FC_name => "Graphic";
		public pictorialRepresentation pictorialRepresentation { get; set; } = new pictorialRepresentation();

		[JsonIgnore]
		public override Attribute[] attributes => [
				pictorialRepresentation,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(pictorialRepresentation),
					lower = 1,
					upper = 1,
					CreateInstance = () => new pictorialRepresentation(),
				},
				new attributeBinding {
					attribute = nameof(pictureCaption),
					lower = 0,
					upper = 1,
					CreateInstance = () => new pictureCaption(),
				},
				new attributeBinding {
					attribute = nameof(sourceDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new sourceDate(),
				},
				new attributeBinding {
					attribute = nameof(pictureInformation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new pictureInformation(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? pictureCaption_optional {
			set { base.SetAttribute(new pictureCaption { value = value }); }
			get { return base.GetAttributeValue<pictureCaption>(nameof(pictureCaption))?.value; }
		}
		[JsonIgnore]
		public DateOnly? sourceDate_optional {
			set { base.SetAttribute(new sourceDate { value = value }); }
			get { return base.GetAttributeValue<sourceDate>(nameof(sourceDate))?.value; }
		}
		[JsonIgnore]
		public String? pictureInformation_optional {
			set { base.SetAttribute(new pictureInformation { value = value }); }
			get { return base.GetAttributeValue<pictureInformation>(nameof(pictureInformation))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// The best estimate of the accuracy of a position.
	/// </summary>
	public class horizontalPositionUncertainty : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(horizontalPositionUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Horizontal Position Uncertainty";
		public uncertaintyFixed uncertaintyFixed { get; set; } = new uncertaintyFixed();

		[JsonIgnore]
		public override Attribute[] attributes => [
				uncertaintyFixed,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(uncertaintyFixed),
					lower = 1,
					upper = 1,
					CreateInstance = () => new uncertaintyFixed(),
				},
				new attributeBinding {
					attribute = nameof(uncertaintyVariableFactor),
					lower = 0,
					upper = 1,
					CreateInstance = () => new uncertaintyVariableFactor(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public double? uncertaintyVariableFactor_optional {
			set { base.SetAttribute(new uncertaintyVariableFactor { value = value }); }
			get { return base.GetAttributeValue<uncertaintyVariableFactor>(nameof(uncertaintyVariableFactor))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Textual information about the feature. The information may be provided as a string of text or as a file name of a single external text file that contains the text.
	/// </summary>
	public class information : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(information);
		[JsonIgnore]
		public override string S100FC_name => "Information";
		public language language { get; set; } = new language();

		[JsonIgnore]
		public override Attribute[] attributes => [
				language,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(fileLocator),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fileLocator(),
				},
				new attributeBinding {
					attribute = nameof(fileReference),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fileReference(),
				},
				new attributeBinding {
					attribute = nameof(headline),
					lower = 0,
					upper = 1,
					CreateInstance = () => new headline(),
				},
				new attributeBinding {
					attribute = nameof(language),
					lower = 1,
					upper = 1,
					CreateInstance = () => new language(),
				},
				new attributeBinding {
					attribute = nameof(text),
					lower = 0,
					upper = 1,
					CreateInstance = () => new text(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? fileLocator_optional {
			set { base.SetAttribute(new fileLocator { value = value }); }
			get { return base.GetAttributeValue<fileLocator>(nameof(fileLocator))?.value; }
		}
		[JsonIgnore]
		public String? fileReference_optional {
			set { base.SetAttribute(new fileReference { value = value }); }
			get { return base.GetAttributeValue<fileReference>(nameof(fileReference))?.value; }
		}
		[JsonIgnore]
		public String? headline_optional {
			set { base.SetAttribute(new headline { value = value }); }
			get { return base.GetAttributeValue<headline>(nameof(headline))?.value; }
		}
		[JsonIgnore]
		public String? text_optional {
			set { base.SetAttribute(new text { value = value }); }
			get { return base.GetAttributeValue<text>(nameof(text))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Information about online sources from which a resource or data can be obtained.
	/// </summary>
	public class onlineResource : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(onlineResource);
		[JsonIgnore]
		public override string S100FC_name => "Online Resource";
		public linkage linkage { get; set; } = new linkage();

		[JsonIgnore]
		public override Attribute[] attributes => [
				linkage,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(headline),
					lower = 0,
					upper = 1,
					CreateInstance = () => new headline(),
				},
				new attributeBinding {
					attribute = nameof(linkage),
					lower = 1,
					upper = 1,
					CreateInstance = () => new linkage(),
				},
				new attributeBinding {
					attribute = nameof(nameOfResource),
					lower = 0,
					upper = 1,
					CreateInstance = () => new nameOfResource(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? headline_optional {
			set { base.SetAttribute(new headline { value = value }); }
			get { return base.GetAttributeValue<headline>(nameof(headline))?.value; }
		}
		[JsonIgnore]
		public String? nameOfResource_optional {
			set { base.SetAttribute(new nameOfResource { value = value }); }
			get { return base.GetAttributeValue<nameOfResource>(nameof(nameOfResource))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// The active period of a recurring event or occurrence.
	/// </summary>
	public class periodicDateRange : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(periodicDateRange);
		[JsonIgnore]
		public override string S100FC_name => "Periodic Date Range";
		public dateStart dateStart { get; set; } = new dateStart();
		public dateEnd dateEnd { get; set; } = new dateEnd();

		[JsonIgnore]
		public override Attribute[] attributes => [
				dateStart,
				dateEnd,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(dateStart),
					lower = 1,
					upper = 1,
					CreateInstance = () => new dateStart(),
				},
				new attributeBinding {
					attribute = nameof(dateEnd),
					lower = 1,
					upper = 1,
					CreateInstance = () => new dateEnd(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Details related to the radio channel used in the radio service.
	/// </summary>
	public class radioChannelDetails : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(radioChannelDetails);
		[JsonIgnore]
		public override string S100FC_name => "Radio Channel Details";
		public transmissionOfTrafficLists transmissionOfTrafficLists { get; set; } = new transmissionOfTrafficLists();

		[JsonIgnore]
		public override Attribute[] attributes => [
				transmissionOfTrafficLists,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBinding {
					attribute = nameof(frequencyPair),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new frequencyPair(),
				},
				new attributeBinding {
					attribute = nameof(dataTransmissionRate),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new dataTransmissionRate(),
				},
				new attributeBinding {
					attribute = nameof(transmissionOfTrafficLists),
					lower = 1,
					upper = 1,
					CreateInstance = () => new transmissionOfTrafficLists(),
				},
				new attributeBinding {
					attribute = nameof(hoursOfWatch),
					lower = 0,
					upper = 1,
					CreateInstance = () => new hoursOfWatch(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String?[] communicationChannel_optional {
			set { base.SetAttribute([.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public frequencyPair?[] frequencyPair_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<frequencyPair>(nameof(frequencyPair)); } 
	}
		[JsonIgnore]
		public int?[] dataTransmissionRate_optional {
			set { base.SetAttribute([.. value.Select(e=> new dataTransmissionRate { value = e })]); }
			get { return base.GetAttributeValues<dataTransmissionRate>(nameof(dataTransmissionRate)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? hoursOfWatch_optional {
			set { base.SetAttribute(new hoursOfWatch { value = value }); }
			get { return base.GetAttributeValue<hoursOfWatch>(nameof(hoursOfWatch))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Identifiers of the radio station in various maritime radiocommunication services.
	/// </summary>
	public class radiocommunicationIdentifier : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(radiocommunicationIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Radiocommunication Identifier";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(callSign),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new callSign(),
				},
				new attributeBinding {
					attribute = nameof(mMSICode),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new mMSICode(),
				},
				new attributeBinding {
					attribute = nameof(selectiveCallNumber),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new selectiveCallNumber(),
				},
				new attributeBinding {
					attribute = nameof(coastStationIdentificationCode),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new coastStationIdentificationCode(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String?[] callSign_optional {
			set { base.SetAttribute([.. value.Select(e=> new callSign { value = e })]); }
			get { return base.GetAttributeValues<callSign>(nameof(callSign)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] mMSICode_optional {
			set { base.SetAttribute([.. value.Select(e=> new mMSICode { value = e })]); }
			get { return base.GetAttributeValues<mMSICode>(nameof(mMSICode)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] selectiveCallNumber_optional {
			set { base.SetAttribute([.. value.Select(e=> new selectiveCallNumber { value = e })]); }
			get { return base.GetAttributeValues<selectiveCallNumber>(nameof(selectiveCallNumber)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] coastStationIdentificationCode_optional {
			set { base.SetAttribute([.. value.Select(e=> new coastStationIdentificationCode { value = e })]); }
			get { return base.GetAttributeValues<coastStationIdentificationCode>(nameof(coastStationIdentificationCode)).Select(e=>e.value).ToArray(); }
		}
		#endregion
	}

	/// <summary>
	/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
	/// </summary>
	public class rxNCode : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(rxNCode);
		[JsonIgnore]
		public override string S100FC_name => "RxN Code";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(headline),
					lower = 0,
					upper = 1,
					CreateInstance = () => new headline(),
				},
				new attributeBinding {
					attribute = nameof(categoryOfRxN),
					lower = 0,
					upper = 1,
					CreateInstance = () => new categoryOfRxN(),
				},
				new attributeBinding {
					attribute = nameof(actionOrActivity),
					lower = 0,
					upper = 1,
					CreateInstance = () => new actionOrActivity(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? headline_optional {
			set { base.SetAttribute(new headline { value = value }); }
			get { return base.GetAttributeValue<headline>(nameof(headline))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfRxN_optional {
			set { base.SetAttribute(new categoryOfRxN { value = value }); }
			get { return base.GetAttributeValue<categoryOfRxN>(nameof(categoryOfRxN))?.value; }
		}
		[JsonIgnore]
		public int? actionOrActivity_optional {
			set { base.SetAttribute(new actionOrActivity { value = value }); }
			get { return base.GetAttributeValue<actionOrActivity>(nameof(actionOrActivity))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	public class sectorLimitOne : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorLimitOne);
		[JsonIgnore]
		public override string S100FC_name => "Sector Limit One";
		public sectorBearing sectorBearing { get; set; } = new sectorBearing();

		[JsonIgnore]
		public override Attribute[] attributes => [
				sectorBearing,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(sectorBearing),
					lower = 1,
					upper = 1,
					CreateInstance = () => new sectorBearing(),
				},
				new attributeBinding {
					attribute = nameof(sectorLineLength),
					lower = 0,
					upper = 1,
					CreateInstance = () => new sectorLineLength(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public double? sectorLineLength_optional {
			set { base.SetAttribute(new sectorLineLength { value = value }); }
			get { return base.GetAttributeValue<sectorLineLength>(nameof(sectorLineLength))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	public class sectorLimitTwo : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorLimitTwo);
		[JsonIgnore]
		public override string S100FC_name => "Sector Limit Two";
		public sectorBearing sectorBearing { get; set; } = new sectorBearing();

		[JsonIgnore]
		public override Attribute[] attributes => [
				sectorBearing,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(sectorBearing),
					lower = 1,
					upper = 1,
					CreateInstance = () => new sectorBearing(),
				},
				new attributeBinding {
					attribute = nameof(sectorLineLength),
					lower = 0,
					upper = 1,
					CreateInstance = () => new sectorLineLength(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public double? sectorLineLength_optional {
			set { base.SetAttribute(new sectorLineLength { value = value }); }
			get { return base.GetAttributeValue<sectorLineLength>(nameof(sectorLineLength))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
	/// </summary>
	public class surveyDateRange : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(surveyDateRange);
		[JsonIgnore]
		public override string S100FC_name => "Survey Date Range";
		public dateEnd dateEnd { get; set; } = new dateEnd();

		[JsonIgnore]
		public override Attribute[] attributes => [
				dateEnd,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(dateStart),
					lower = 0,
					upper = 1,
					CreateInstance = () => new dateStart(),
				},
				new attributeBinding {
					attribute = nameof(dateEnd),
					lower = 1,
					upper = 1,
					CreateInstance = () => new dateEnd(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? dateStart_optional {
			set { base.SetAttribute(new dateStart { value = value }); }
			get { return base.GetAttributeValue<dateStart>(nameof(dateStart))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
	/// </summary>
	public class telecommunications : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunications);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunications";
		public telecommunicationIdentifier telecommunicationIdentifier { get; set; } = new telecommunicationIdentifier();

		[JsonIgnore]
		public override Attribute[] attributes => [
				telecommunicationIdentifier,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(contactInstructions),
					lower = 0,
					upper = 1,
					CreateInstance = () => new contactInstructions(),
				},
				new attributeBinding {
					attribute = nameof(telecommunicationIdentifier),
					lower = 1,
					upper = 1,
					CreateInstance = () => new telecommunicationIdentifier(),
				},
				new attributeBinding {
					attribute = nameof(telecommunicationService),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new telecommunicationService(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? contactInstructions_optional {
			set { base.SetAttribute(new contactInstructions { value = value }); }
			get { return base.GetAttributeValue<contactInstructions>(nameof(contactInstructions))?.value; }
		}
		[JsonIgnore]
		public int? telecommunicationService_optional {
			set { base.SetAttribute(new telecommunicationService { value = value }); }
			get { return base.GetAttributeValue<telecommunicationService>(nameof(telecommunicationService))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.
	/// </summary>
	public class textContent : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textContent);
		[JsonIgnore]
		public override string S100FC_name => "Text Content";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(categoryOfText),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfText(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new attributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 1,
					CreateInstance = () => new onlineResource(),
				},
				new attributeBinding {
					attribute = nameof(source),
					lower = 0,
					upper = 1,
					CreateInstance = () => new source(),
				},
				new attributeBinding {
					attribute = nameof(reportedDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new reportedDate(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? categoryOfText_optional {
			set { base.SetAttribute(new categoryOfText { value = value }); }
			get { return base.GetAttributeValue<categoryOfText>(nameof(categoryOfText))?.value; }
		}
		[JsonIgnore]
		public information?[] information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		[JsonIgnore]
		public onlineResource? onlineResource_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<onlineResource>(nameof(onlineResource)); }
		}
		[JsonIgnore]
		public String? source_optional {
			set { base.SetAttribute(new source { value = value }); }
			get { return base.GetAttributeValue<source>(nameof(source))?.value; }
		}
		[JsonIgnore]
		public String? reportedDate_optional {
			set { base.SetAttribute(new reportedDate { value = value }); }
			get { return base.GetAttributeValue<reportedDate>(nameof(reportedDate))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// The regular weekly operation times of a service or schedule.
	/// </summary>
	public class timeIntervalsByDayOfWeek : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timeIntervalsByDayOfWeek);
		[JsonIgnore]
		public override string S100FC_name => "Time Intervals by Day of Week";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(dayOfWeek),
					lower = 0,
					upper = 7,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new dayOfWeek(),
				},
				new attributeBinding {
					attribute = nameof(dayOfWeekIsRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new dayOfWeekIsRange(),
				},
				new attributeBinding {
					attribute = nameof(timeOfDayStart),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new timeOfDayStart(),
				},
				new attributeBinding {
					attribute = nameof(timeOfDayEnd),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new timeOfDayEnd(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int?[] dayOfWeek_optional {
			set { base.SetAttribute([.. value.Select(e=> new dayOfWeek { value = e })]); }
			get { return base.GetAttributeValues<dayOfWeek>(nameof(dayOfWeek)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? dayOfWeekIsRange_optional {
			set { base.SetAttribute(new dayOfWeekIsRange { value = value }); }
			get { return base.GetAttributeValue<dayOfWeekIsRange>(nameof(dayOfWeekIsRange))?.value; }
		}
		[JsonIgnore]
		public S100Framework.DomainModel.S100.Time?[] timeOfDayStart_optional {
			set { base.SetAttribute([.. value.Select(e=> new timeOfDayStart { value = e })]); }
			get { return base.GetAttributeValues<timeOfDayStart>(nameof(timeOfDayStart)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public S100Framework.DomainModel.S100.Time?[] timeOfDayEnd_optional {
			set { base.SetAttribute([.. value.Select(e=> new timeOfDayEnd { value = e })]); }
			get { return base.GetAttributeValues<timeOfDayEnd>(nameof(timeOfDayEnd)).Select(e=>e.value).ToArray(); }
		}
		#endregion
	}

	/// <summary>
	/// One or more times in the day when the radio station starts a routine transmission, normally expressed in UTC or local time.
	/// </summary>
	public class timesOfTransmission : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(timesOfTransmission);
		[JsonIgnore]
		public override string S100FC_name => "Times of Transmission";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(minutePastEvenHours),
					lower = 0,
					upper = 1,
					CreateInstance = () => new minutePastEvenHours(),
				},
				new attributeBinding {
					attribute = nameof(minutePastOddHours),
					lower = 0,
					upper = 1,
					CreateInstance = () => new minutePastOddHours(),
				},
				new attributeBinding {
					attribute = nameof(minutePastEveryHour),
					lower = 0,
					upper = 1,
					CreateInstance = () => new minutePastEveryHour(),
				},
				new attributeBinding {
					attribute = nameof(transmissionTime),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new transmissionTime(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? minutePastEvenHours_optional {
			set { base.SetAttribute(new minutePastEvenHours { value = value }); }
			get { return base.GetAttributeValue<minutePastEvenHours>(nameof(minutePastEvenHours))?.value; }
		}
		[JsonIgnore]
		public int? minutePastOddHours_optional {
			set { base.SetAttribute(new minutePastOddHours { value = value }); }
			get { return base.GetAttributeValue<minutePastOddHours>(nameof(minutePastOddHours))?.value; }
		}
		[JsonIgnore]
		public int? minutePastEveryHour_optional {
			set { base.SetAttribute(new minutePastEveryHour { value = value }); }
			get { return base.GetAttributeValue<minutePastEveryHour>(nameof(minutePastEveryHour))?.value; }
		}
		[JsonIgnore]
		public S100Framework.DomainModel.S100.Time?[] transmissionTime_optional {
			set { base.SetAttribute([.. value.Select(e=> new transmissionTime { value = e })]); }
			get { return base.GetAttributeValues<transmissionTime>(nameof(transmissionTime)).Select(e=>e.value).ToArray(); }
		}
		#endregion
	}

	/// <summary>
	/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
	/// </summary>
	public class verticalUncertainty : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalUncertainty);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Uncertainty";
		public uncertaintyFixed uncertaintyFixed { get; set; } = new uncertaintyFixed();

		[JsonIgnore]
		public override Attribute[] attributes => [
				uncertaintyFixed,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(uncertaintyFixed),
					lower = 1,
					upper = 1,
					CreateInstance = () => new uncertaintyFixed(),
				},
				new attributeBinding {
					attribute = nameof(uncertaintyVariableFactor),
					lower = 0,
					upper = 1,
					CreateInstance = () => new uncertaintyVariableFactor(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public double? uncertaintyVariableFactor_optional {
			set { base.SetAttribute(new uncertaintyVariableFactor { value = value }); }
			get { return base.GetAttributeValue<uncertaintyVariableFactor>(nameof(uncertaintyVariableFactor))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
	/// </summary>
	public class vesselMeasurementsSpecification : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(vesselMeasurementsSpecification);
		[JsonIgnore]
		public override string S100FC_name => "Vessel Measurements Specification";
		public vesselsCharacteristics vesselsCharacteristics { get; set; } = new vesselsCharacteristics();
		public vesselsCharacteristicsValue vesselsCharacteristicsValue { get; set; } = new vesselsCharacteristicsValue();
		public vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; set; } = new vesselsCharacteristicsUnit();
		public comparisonOperator comparisonOperator { get; set; } = new comparisonOperator();

		[JsonIgnore]
		public override Attribute[] attributes => [
				vesselsCharacteristics,
				vesselsCharacteristicsValue,
				vesselsCharacteristicsUnit,
				comparisonOperator,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(vesselsCharacteristics),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4,6,7,8,9,10,11,12,13],
					CreateInstance = () => new vesselsCharacteristics(),
				},
				new attributeBinding {
					attribute = nameof(vesselsCharacteristicsValue),
					lower = 1,
					upper = 1,
					CreateInstance = () => new vesselsCharacteristicsValue(),
				},
				new attributeBinding {
					attribute = nameof(vesselsCharacteristicsUnit),
					lower = 1,
					upper = 1,
					permitedValues = [1,3,4,5,6,7,9],
					CreateInstance = () => new vesselsCharacteristicsUnit(),
				},
				new attributeBinding {
					attribute = nameof(comparisonOperator),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new comparisonOperator(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// The nature and timings of a daily schedule by days of the week.
	/// </summary>
	public class scheduleByDayOfWeek : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(scheduleByDayOfWeek);
		[JsonIgnore]
		public override string S100FC_name => "Schedule by Day of Week";
		public timeIntervalsByDayOfWeek timeIntervalsByDayOfWeek { get; set; } = new timeIntervalsByDayOfWeek();

		[JsonIgnore]
		public override Attribute[] attributes => [
				timeIntervalsByDayOfWeek,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(categoryOfSchedule),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfSchedule(),
				},
				new attributeBinding {
					attribute = nameof(timeIntervalsByDayOfWeek),
					lower = 1,
					upper = 10,
					CreateInstance = () => new timeIntervalsByDayOfWeek(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? categoryOfSchedule_optional {
			set { base.SetAttribute(new categoryOfSchedule { value = value }); }
			get { return base.GetAttributeValue<categoryOfSchedule>(nameof(categoryOfSchedule))?.value; }
		}
		[JsonIgnore]
		public timeIntervalsByDayOfWeek?[] timeIntervalsByDayOfWeek_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<timeIntervalsByDayOfWeek>(nameof(timeIntervalsByDayOfWeek)); } 
	}
		#endregion
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
	/// </summary>
	public class sectorLimit : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorLimit);
		[JsonIgnore]
		public override string S100FC_name => "Sector Limit";
		public sectorLimitOne sectorLimitOne { get; set; } = new sectorLimitOne();
		public sectorLimitTwo sectorLimitTwo { get; set; } = new sectorLimitTwo();

		[JsonIgnore]
		public override Attribute[] attributes => [
				sectorLimitOne,
				sectorLimitTwo,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(sectorLimitOne),
					lower = 1,
					upper = 1,
					CreateInstance = () => new sectorLimitOne(),
				},
				new attributeBinding {
					attribute = nameof(sectorLimitTwo),
					lower = 1,
					upper = 1,
					CreateInstance = () => new sectorLimitTwo(),
				},
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
	/// </summary>
	public class spatialAccuracy : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(spatialAccuracy);
		[JsonIgnore]
		public override string S100FC_name => "Spatial Accuracy";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBinding {
					attribute = nameof(horizontalPositionUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
				new attributeBinding {
					attribute = nameof(verticalUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new verticalUncertainty(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public fixedDateRange? fixedDateRange_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public horizontalPositionUncertainty? horizontalPositionUncertainty_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<horizontalPositionUncertainty>(nameof(horizontalPositionUncertainty)); }
		}
		[JsonIgnore]
		public verticalUncertainty? verticalUncertainty_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<verticalUncertainty>(nameof(verticalUncertainty)); }
		}
		#endregion
	}

}

namespace S100Framework.AttributeModel.S123.InformationAssociation
{
	using S100Framework.AttributeModel.S123.SimpleAttributes;
	using S100Framework.AttributeModel.S123.ComplexAttributes;

	public class AdditionalInformation : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theInformation";
		
		
	}
	public class AssociatedRxN : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theRxN";
		
		
	}
	public class AuthorityContact : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theContactDetails";
		
		
	}
	public class AuthorityHours : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theServiceHours";
		
		
	}
	public class AvailableQoS : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theQoS";
		
		
	}
	public class BroadcastService : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theBroadcastDetails";
		
		
	}
	public class BroadcastTransmission : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theTransmissionDetails";
		
		
	}
	public class ConnectivityService : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "connectivityServiceProvider";
		
		
	}
	public class ExceptionalWorkday : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "partialWorkingDay";
		
		
	}
	public class InclusionType : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theApplicableRxN";
		
		
	}
	public class LocationHours : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theServiceHours";
		
		
	}
	public class PermissionType : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "permission";
		
		
	}
	public class RadioServiceControl : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theControlCentre";
		
		
	}
	public class relatedOrganisation : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theInformation";
		
		
	}
	public class ServiceContact : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theContactDetails";
		
		
	}
	public class ServiceCoordination : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "coordinatingAuthority";
		
		
	}
	public class SpatialAssociation : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theQualityInformation";
		
		
	}
	public class TMAS : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theTMAS";
		
		
	}
	public class TransmissionService : S100Framework.AttributeModel.InformationAssociation
	{
		[JsonIgnore]
		public override string role => "theTransmissionDetails";
		
		
	}
}

namespace S100Framework.AttributeModel.S123.FeatureAssociation
{
	using S100Framework.AttributeModel.S123.SimpleAttributes;
	using S100Framework.AttributeModel.S123.ComplexAttributes;

	public class coreAggregation : S100Framework.AttributeModel.FeatureAssociation
	{
		[JsonIgnore]
		public override string[] roles => ["theCollection","theComponent"];

	}
	public class fuzzyZoneAggregation : S100Framework.AttributeModel.FeatureAssociation
	{
		[JsonIgnore]
		public override string[] roles => ["theCollection","theComponent"];

	}
	public class ServiceProvisionArea : S100Framework.AttributeModel.FeatureAssociation
	{
		[JsonIgnore]
		public override string[] roles => ["serviceArea","serviceProvider"];

	}
}

namespace S100Framework.AttributeModel.S123.InformationTypes
{
	using S100Framework.AttributeModel.S123.SimpleAttributes;
	using S100Framework.AttributeModel.S123.ComplexAttributes;

	/// <summary>
	/// Generalized information type which carries all the common attributes.
	/// </summary>
	public class InformationType : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(InformationType);
		[JsonIgnore]
		public override string S100FC_name => "Information Type";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBinding {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new periodicDateRange(),
				},
				new attributeBinding {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new featureName(),
				},
				new attributeBinding {
					attribute = nameof(source),
					lower = 0,
					upper = 1,
					CreateInstance = () => new source(),
				},
				new attributeBinding {
					attribute = nameof(reportedDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new reportedDate(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public fixedDateRange? fixedDateRange_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public periodicDateRange?[] periodicDateRange_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<periodicDateRange>(nameof(periodicDateRange)); } 
	}
		[JsonIgnore]
		public featureName?[] featureName_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); } 
	}
		[JsonIgnore]
		public String? source_optional {
			set { base.SetAttribute(new source { value = value }); }
			get { return base.GetAttributeValue<source>(nameof(source))?.value; }
		}
		[JsonIgnore]
		public String? reportedDate_optional {
			set { base.SetAttribute(new reportedDate { value = value }); }
			get { return base.GetAttributeValue<reportedDate>(nameof(reportedDate))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
	/// </summary>
	public class AbstractRxN : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AbstractRxN);
		[JsonIgnore]
		public override string S100FC_name => "AbstractRxN";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(categoryOfAuthority),
					lower = 0,
					upper = 1,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new attributeBinding {
					attribute = nameof(textContent),
					lower = 0,
					upper = 1,
					CreateInstance = () => new textContent(),
				},
				new attributeBinding {
					attribute = nameof(graphic),
					lower = 0,
					upper = 1,
					CreateInstance = () => new graphic(),
				},
				new attributeBinding {
					attribute = nameof(rxNCode),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new rxNCode(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? categoryOfAuthority_optional {
			set { base.SetAttribute(new categoryOfAuthority { value = value }); }
			get { return base.GetAttributeValue<categoryOfAuthority>(nameof(categoryOfAuthority))?.value; }
		}
		[JsonIgnore]
		public textContent? textContent_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<textContent>(nameof(textContent)); }
		}
		[JsonIgnore]
		public graphic? graphic_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<graphic>(nameof(graphic)); }
		}
		[JsonIgnore]
		public rxNCode?[] rxNCode_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<rxNCode>(nameof(rxNCode)); } 
	}
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

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(inBallast),
					lower = 0,
					upper = 1,
					CreateInstance = () => new inBallast(),
				},
				new attributeBinding {
					attribute = nameof(categoryOfVessel),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17],
					CreateInstance = () => new categoryOfVessel(),
				},
				new attributeBinding {
					attribute = nameof(categoryOfVesselRegistry),
					lower = 0,
					upper = 1,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfVesselRegistry(),
				},
				new attributeBinding {
					attribute = nameof(categoryOfCargo),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfCargo(),
				},
				new attributeBinding {
					attribute = nameof(categoryOfDangerousOrHazardousCargo),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21],
					CreateInstance = () => new categoryOfDangerousOrHazardousCargo(),
				},
				new attributeBinding {
					attribute = nameof(logicalConnectives),
					lower = 0,
					upper = 1,
					permitedValues = [1,2],
					CreateInstance = () => new logicalConnectives(),
				},
				new attributeBinding {
					attribute = nameof(thicknessOfIceCapability),
					lower = 0,
					upper = 1,
					CreateInstance = () => new thicknessOfIceCapability(),
				},
				new attributeBinding {
					attribute = nameof(vesselPerformance),
					lower = 0,
					upper = 1,
					CreateInstance = () => new vesselPerformance(),
				},
				new attributeBinding {
					attribute = nameof(vesselMeasurementsSpecification),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new vesselMeasurementsSpecification(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public Boolean? inBallast_optional {
			set { base.SetAttribute(new inBallast { value = value }); }
			get { return base.GetAttributeValue<inBallast>(nameof(inBallast))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfVessel_optional {
			set { base.SetAttribute([.. value.Select(e=> new categoryOfVessel { value = e })]); }
			get { return base.GetAttributeValues<categoryOfVessel>(nameof(categoryOfVessel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? categoryOfVesselRegistry_optional {
			set { base.SetAttribute(new categoryOfVesselRegistry { value = value }); }
			get { return base.GetAttributeValue<categoryOfVesselRegistry>(nameof(categoryOfVesselRegistry))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfCargo_optional {
			set { base.SetAttribute([.. value.Select(e=> new categoryOfCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfCargo>(nameof(categoryOfCargo)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfDangerousOrHazardousCargo_optional {
			set { base.SetAttribute([.. value.Select(e=> new categoryOfDangerousOrHazardousCargo { value = e })]); }
			get { return base.GetAttributeValues<categoryOfDangerousOrHazardousCargo>(nameof(categoryOfDangerousOrHazardousCargo)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? logicalConnectives_optional {
			set { base.SetAttribute(new logicalConnectives { value = value }); }
			get { return base.GetAttributeValue<logicalConnectives>(nameof(logicalConnectives))?.value; }
		}
		[JsonIgnore]
		public int? thicknessOfIceCapability_optional {
			set { base.SetAttribute(new thicknessOfIceCapability { value = value }); }
			get { return base.GetAttributeValue<thicknessOfIceCapability>(nameof(thicknessOfIceCapability))?.value; }
		}
		[JsonIgnore]
		public String? vesselPerformance_optional {
			set { base.SetAttribute(new vesselPerformance { value = value }); }
			get { return base.GetAttributeValue<vesselPerformance>(nameof(vesselPerformance))?.value; }
		}
		[JsonIgnore]
		public vesselMeasurementsSpecification?[] vesselMeasurementsSpecification_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<vesselMeasurementsSpecification>(nameof(vesselMeasurementsSpecification)); } 
	}
		[JsonIgnore]
		public information?[] information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
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

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(categoryOfAuthority),
					lower = 0,
					upper = 1,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new attributeBinding {
					attribute = nameof(textContent),
					lower = 0,
					upper = 1,
					CreateInstance = () => new textContent(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? categoryOfAuthority_optional {
			set { base.SetAttribute(new categoryOfAuthority { value = value }); }
			get { return base.GetAttributeValue<categoryOfAuthority>(nameof(categoryOfAuthority))?.value; }
		}
		[JsonIgnore]
		public textContent? textContent_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<textContent>(nameof(textContent)); }
		}
		#endregion
	}

	/// <summary>
	/// Description of the content and schedule of a service using broadcast technology of radiocommunications to deliver information (to every receiver within a direct range). Online resource to access the content may also be included.
	/// </summary>
	public class BroadcastDetails : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(BroadcastDetails);
		[JsonIgnore]
		public override string S100FC_name => "Broadcast Details";
		public broadcastContent broadcastContent { get; set; } = new broadcastContent();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				broadcastContent,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(language),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new language(),
				},
				new attributeBinding {
					attribute = nameof(categoryOfBroadcastCommunication),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfBroadcastCommunication(),
				},
				new attributeBinding {
					attribute = nameof(broadcastContent),
					lower = 1,
					upper = 2147483647,
					CreateInstance = () => new broadcastContent(),
				},
				new attributeBinding {
					attribute = nameof(timesOfTransmission),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new timesOfTransmission(),
				},
				new attributeBinding {
					attribute = nameof(timeIntervalsByDayOfWeek),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new timeIntervalsByDayOfWeek(),
				},
				new attributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 1,
					CreateInstance = () => new onlineResource(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String?[] language_optional {
			set { base.SetAttribute([.. value.Select(e=> new language { value = e })]); }
			get { return base.GetAttributeValues<language>(nameof(language)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? categoryOfBroadcastCommunication_optional {
			set { base.SetAttribute(new categoryOfBroadcastCommunication { value = value }); }
			get { return base.GetAttributeValue<categoryOfBroadcastCommunication>(nameof(categoryOfBroadcastCommunication))?.value; }
		}
		[JsonIgnore]
		public broadcastContent?[] broadcastContent_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<broadcastContent>(nameof(broadcastContent)); } 
	}
		[JsonIgnore]
		public timesOfTransmission?[] timesOfTransmission_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<timesOfTransmission>(nameof(timesOfTransmission)); } 
	}
		[JsonIgnore]
		public timeIntervalsByDayOfWeek?[] timeIntervalsByDayOfWeek_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<timeIntervalsByDayOfWeek>(nameof(timeIntervalsByDayOfWeek)); } 
	}
		[JsonIgnore]
		public onlineResource? onlineResource_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<onlineResource>(nameof(onlineResource)); }
		}
		#endregion
	}

	/// <summary>
	/// Information related to the Quality of Service (QoS) of the connectivity.
	/// </summary>
	public class ConnectivityQualityOfService : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ConnectivityQualityOfService);
		[JsonIgnore]
		public override string S100FC_name => "Connectivity Quality of Service";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(typeOfConnectivityResource),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new typeOfConnectivityResource(),
				},
				new attributeBinding {
					attribute = nameof(uplinkBandwidth),
					lower = 0,
					upper = 1,
					CreateInstance = () => new uplinkBandwidth(),
				},
				new attributeBinding {
					attribute = nameof(downlinkBandwidth),
					lower = 0,
					upper = 1,
					CreateInstance = () => new downlinkBandwidth(),
				},
				new attributeBinding {
					attribute = nameof(packetDelay),
					lower = 0,
					upper = 1,
					CreateInstance = () => new packetDelay(),
				},
				new attributeBinding {
					attribute = nameof(maximumDataBurstVolume),
					lower = 0,
					upper = 1,
					CreateInstance = () => new maximumDataBurstVolume(),
				},
				new attributeBinding {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,4,5,7,8,14,16,17,25,26,27],
					CreateInstance = () => new status(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int?[] typeOfConnectivityResource_optional {
			set { base.SetAttribute([.. value.Select(e=> new typeOfConnectivityResource { value = e })]); }
			get { return base.GetAttributeValues<typeOfConnectivityResource>(nameof(typeOfConnectivityResource)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public double? uplinkBandwidth_optional {
			set { base.SetAttribute(new uplinkBandwidth { value = value }); }
			get { return base.GetAttributeValue<uplinkBandwidth>(nameof(uplinkBandwidth))?.value; }
		}
		[JsonIgnore]
		public double? downlinkBandwidth_optional {
			set { base.SetAttribute(new downlinkBandwidth { value = value }); }
			get { return base.GetAttributeValue<downlinkBandwidth>(nameof(downlinkBandwidth))?.value; }
		}
		[JsonIgnore]
		public double? packetDelay_optional {
			set { base.SetAttribute(new packetDelay { value = value }); }
			get { return base.GetAttributeValue<packetDelay>(nameof(packetDelay))?.value; }
		}
		[JsonIgnore]
		public int? maximumDataBurstVolume_optional {
			set { base.SetAttribute(new maximumDataBurstVolume { value = value }); }
			get { return base.GetAttributeValue<maximumDataBurstVolume>(nameof(maximumDataBurstVolume))?.value; }
		}
		[JsonIgnore]
		public int?[] status_optional {
			set { base.SetAttribute([.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public information?[] information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
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

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(contactInstructions),
					lower = 0,
					upper = 1,
					CreateInstance = () => new contactInstructions(),
				},
				new attributeBinding {
					attribute = nameof(contactAddress),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new contactAddress(),
				},
				new attributeBinding {
					attribute = nameof(frequencyPair),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new frequencyPair(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 1,
					CreateInstance = () => new information(),
				},
				new attributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new onlineResource(),
				},
				new attributeBinding {
					attribute = nameof(telecommunications),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new telecommunications(),
				},
				new attributeBinding {
					attribute = nameof(callName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new callName(),
				},
				new attributeBinding {
					attribute = nameof(callSign),
					lower = 0,
					upper = 1,
					CreateInstance = () => new callSign(),
				},
				new attributeBinding {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new communicationChannel(),
				},
				new attributeBinding {
					attribute = nameof(mMSICode),
					lower = 0,
					upper = 1,
					CreateInstance = () => new mMSICode(),
				},
				new attributeBinding {
					attribute = nameof(language),
					lower = 0,
					upper = 1,
					CreateInstance = () => new language(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? contactInstructions_optional {
			set { base.SetAttribute(new contactInstructions { value = value }); }
			get { return base.GetAttributeValue<contactInstructions>(nameof(contactInstructions))?.value; }
		}
		[JsonIgnore]
		public contactAddress?[] contactAddress_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<contactAddress>(nameof(contactAddress)); } 
	}
		[JsonIgnore]
		public frequencyPair?[] frequencyPair_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<frequencyPair>(nameof(frequencyPair)); } 
	}
		[JsonIgnore]
		public information? information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<information>(nameof(information)); }
		}
		[JsonIgnore]
		public onlineResource?[] onlineResource_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<onlineResource>(nameof(onlineResource)); } 
	}
		[JsonIgnore]
		public telecommunications?[] telecommunications_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<telecommunications>(nameof(telecommunications)); } 
	}
		[JsonIgnore]
		public String? callName_optional {
			set { base.SetAttribute(new callName { value = value }); }
			get { return base.GetAttributeValue<callName>(nameof(callName))?.value; }
		}
		[JsonIgnore]
		public String? callSign_optional {
			set { base.SetAttribute(new callSign { value = value }); }
			get { return base.GetAttributeValue<callSign>(nameof(callSign))?.value; }
		}
		[JsonIgnore]
		public String?[] communicationChannel_optional {
			set { base.SetAttribute([.. value.Select(e=> new communicationChannel { value = e })]); }
			get { return base.GetAttributeValues<communicationChannel>(nameof(communicationChannel)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? mMSICode_optional {
			set { base.SetAttribute(new mMSICode { value = value }); }
			get { return base.GetAttributeValue<mMSICode>(nameof(mMSICode))?.value; }
		}
		[JsonIgnore]
		public String? language_optional {
			set { base.SetAttribute(new language { value = value }); }
			get { return base.GetAttributeValue<language>(nameof(language))?.value; }
		}
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

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
			];
		#endregion

		#region Optional Attributes
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

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new attributeBinding {
					attribute = nameof(dateFixed),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new dateFixed(),
				},
				new attributeBinding {
					attribute = nameof(dateVariable),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new dateVariable(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public information?[] information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		[JsonIgnore]
		public String?[] dateFixed_optional {
			set { base.SetAttribute([.. value.Select(e=> new dateFixed { value = e })]); }
			get { return base.GetAttributeValues<dateFixed>(nameof(dateFixed)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String?[] dateVariable_optional {
			set { base.SetAttribute([.. value.Select(e=> new dateVariable { value = e })]); }
			get { return base.GetAttributeValues<dateVariable>(nameof(dateVariable)).Select(e=>e.value).ToArray(); }
		}
		#endregion
	}

	/// <summary>
	/// The control centre of the radio service or radio stations
	/// </summary>
	public class RadioControlCentre : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadioControlCentre);
		[JsonIgnore]
		public override string S100FC_name => "Radio Control Centre";
		public isMRCC isMRCC { get; set; } = new isMRCC();
		public acceptAMVER acceptAMVER { get; set; } = new acceptAMVER();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				isMRCC,
				acceptAMVER,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(isMRCC),
					lower = 1,
					upper = 1,
					CreateInstance = () => new isMRCC(),
				},
				new attributeBinding {
					attribute = nameof(acceptAMVER),
					lower = 1,
					upper = 1,
					CreateInstance = () => new acceptAMVER(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new attributeBinding {
					attribute = nameof(hoursOfWatch),
					lower = 0,
					upper = 1,
					CreateInstance = () => new hoursOfWatch(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public information?[] information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		[JsonIgnore]
		public String? hoursOfWatch_optional {
			set { base.SetAttribute(new hoursOfWatch { value = value }); }
			get { return base.GetAttributeValue<hoursOfWatch>(nameof(hoursOfWatch))?.value; }
		}
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

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
			];
		#endregion

		#region Optional Attributes
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

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
			];
		#endregion

		#region Optional Attributes
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

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
			];
		#endregion

		#region Optional Attributes
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
		public scheduleByDayOfWeek scheduleByDayOfWeek { get; set; } = new scheduleByDayOfWeek();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				scheduleByDayOfWeek,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(scheduleByDayOfWeek),
					lower = 1,
					upper = 2147483647,
					CreateInstance = () => new scheduleByDayOfWeek(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public scheduleByDayOfWeek?[] scheduleByDayOfWeek_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<scheduleByDayOfWeek>(nameof(scheduleByDayOfWeek)); } 
	}
		[JsonIgnore]
		public information?[] information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		#endregion
	}

	/// <summary>
	/// The indication of the quality of the locational information for features in a dataset.
	/// </summary>
	public class SpatialQuality : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SpatialQuality);
		[JsonIgnore]
		public override string S100FC_name => "Spatial Quality";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(qualityOfHorizontalMeasurement),
					lower = 0,
					upper = 1,
					permitedValues = [4],
					CreateInstance = () => new qualityOfHorizontalMeasurement(),
				},
				new attributeBinding {
					attribute = nameof(spatialAccuracy),
					lower = 0,
					upper = 1,
					CreateInstance = () => new spatialAccuracy(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? qualityOfHorizontalMeasurement_optional {
			set { base.SetAttribute(new qualityOfHorizontalMeasurement { value = value }); }
			get { return base.GetAttributeValue<qualityOfHorizontalMeasurement>(nameof(qualityOfHorizontalMeasurement))?.value; }
		}
		[JsonIgnore]
		public spatialAccuracy? spatialAccuracy_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<spatialAccuracy>(nameof(spatialAccuracy)); }
		}
		#endregion
	}

	/// <summary>
	/// A service to provide decision support and advice to the seafarer on board responsible for medical care.
	/// </summary>
	public class TelemedicalAssistanceService : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TelemedicalAssistanceService);
		[JsonIgnore]
		public override string S100FC_name => "Telemedical Assistance Service";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(contactInstructions),
					lower = 0,
					upper = 1,
					CreateInstance = () => new contactInstructions(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 1,
					CreateInstance = () => new information(),
				},
				new attributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new onlineResource(),
				},
				new attributeBinding {
					attribute = nameof(telecommunications),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new telecommunications(),
				},
				new attributeBinding {
					attribute = nameof(languageInformation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new languageInformation(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? contactInstructions_optional {
			set { base.SetAttribute(new contactInstructions { value = value }); }
			get { return base.GetAttributeValue<contactInstructions>(nameof(contactInstructions))?.value; }
		}
		[JsonIgnore]
		public information? information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<information>(nameof(information)); }
		}
		[JsonIgnore]
		public onlineResource?[] onlineResource_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<onlineResource>(nameof(onlineResource)); } 
	}
		[JsonIgnore]
		public telecommunications?[] telecommunications_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<telecommunications>(nameof(telecommunications)); } 
	}
		[JsonIgnore]
		public String? languageInformation_optional {
			set { base.SetAttribute(new languageInformation { value = value }); }
			get { return base.GetAttributeValue<languageInformation>(nameof(languageInformation))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Description of the radiocommunication service with respect to the radio method and radio channels for the transfer of information by means of signals.
	/// </summary>
	public class TransmissionDetails : InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TransmissionDetails);
		[JsonIgnore]
		public override string S100FC_name => "Transmission Details";
		public radioChannelDetails radioChannelDetails { get; set; } = new radioChannelDetails();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				radioChannelDetails,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(typeOfRadioService),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new typeOfRadioService(),
				},
				new attributeBinding {
					attribute = nameof(frequencyBand),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new frequencyBand(),
				},
				new attributeBinding {
					attribute = nameof(classOfEmission),
					lower = 0,
					upper = 1,
					CreateInstance = () => new classOfEmission(),
				},
				new attributeBinding {
					attribute = nameof(communicationStandard),
					lower = 0,
					upper = 1,
					CreateInstance = () => new communicationStandard(),
				},
				new attributeBinding {
					attribute = nameof(radioChannelDetails),
					lower = 1,
					upper = 2147483647,
					CreateInstance = () => new radioChannelDetails(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? typeOfRadioService_optional {
			set { base.SetAttribute(new typeOfRadioService { value = value }); }
			get { return base.GetAttributeValue<typeOfRadioService>(nameof(typeOfRadioService))?.value; }
		}
		[JsonIgnore]
		public int? frequencyBand_optional {
			set { base.SetAttribute(new frequencyBand { value = value }); }
			get { return base.GetAttributeValue<frequencyBand>(nameof(frequencyBand))?.value; }
		}
		[JsonIgnore]
		public String? classOfEmission_optional {
			set { base.SetAttribute(new classOfEmission { value = value }); }
			get { return base.GetAttributeValue<classOfEmission>(nameof(classOfEmission))?.value; }
		}
		[JsonIgnore]
		public String? communicationStandard_optional {
			set { base.SetAttribute(new communicationStandard { value = value }); }
			get { return base.GetAttributeValue<communicationStandard>(nameof(communicationStandard))?.value; }
		}
		[JsonIgnore]
		public radioChannelDetails?[] radioChannelDetails_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<radioChannelDetails>(nameof(radioChannelDetails)); } 
	}
		#endregion
	}

}

namespace S100Framework.AttributeModel.S123.FeatureTypes
{
	using S100Framework.AttributeModel.S123.SimpleAttributes;
	using S100Framework.AttributeModel.S123.ComplexAttributes;

	/// <summary>
	/// Generalized feature type which carries all the common attributes.
	/// </summary>
	public class FeatureType : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(FeatureType);
		[JsonIgnore]
		public override string S100FC_name => "Feature Type";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new textContent(),
				},
				new attributeBinding {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new featureName(),
				},
				new attributeBinding {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBinding {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new periodicDateRange(),
				},
				new attributeBinding {
					attribute = nameof(source),
					lower = 0,
					upper = 1,
					CreateInstance = () => new source(),
				},
				new attributeBinding {
					attribute = nameof(reportedDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new reportedDate(),
				},
				new attributeBinding {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 1,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public textContent?[] textContent_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<textContent>(nameof(textContent)); } 
	}
		[JsonIgnore]
		public featureName?[] featureName_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); } 
	}
		[JsonIgnore]
		public fixedDateRange? fixedDateRange_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public periodicDateRange?[] periodicDateRange_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<periodicDateRange>(nameof(periodicDateRange)); } 
	}
		[JsonIgnore]
		public String? source_optional {
			set { base.SetAttribute(new source { value = value }); }
			get { return base.GetAttributeValue<source>(nameof(source))?.value; }
		}
		[JsonIgnore]
		public String? reportedDate_optional {
			set { base.SetAttribute(new reportedDate { value = value }); }
			get { return base.GetAttributeValue<reportedDate>(nameof(reportedDate))?.value; }
		}
		[JsonIgnore]
		public String? interoperabilityIdentifier_optional {
			set { base.SetAttribute(new interoperabilityIdentifier { value = value }); }
			get { return base.GetAttributeValue<interoperabilityIdentifier>(nameof(interoperabilityIdentifier))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// An area of connectivity coverage available for the subscription of connectivity service.
	/// </summary>
	public class ConnectivitySubscriptionArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ConnectivitySubscriptionArea);
		[JsonIgnore]
		public override string S100FC_name => "Connectivity Subscription Area";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(categoryOfConnectivitySubscription),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfConnectivitySubscription(),
				},
				new attributeBinding {
					attribute = nameof(communicationStandard),
					lower = 0,
					upper = 1,
					CreateInstance = () => new communicationStandard(),
				},
				new attributeBinding {
					attribute = nameof(estimatedRangeOfTransmission),
					lower = 0,
					upper = 1,
					CreateInstance = () => new estimatedRangeOfTransmission(),
				},
				new attributeBinding {
					attribute = nameof(baseStationAntennaHeight),
					lower = 0,
					upper = 1,
					CreateInstance = () => new baseStationAntennaHeight(),
				},
				new attributeBinding {
					attribute = nameof(frequencyRange),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new frequencyRange(),
				},
				new attributeBinding {
					attribute = nameof(sectorLimit),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new sectorLimit(),
				},
				new attributeBinding {
					attribute = nameof(coverageIndication),
					lower = 0,
					upper = 1,
					CreateInstance = () => new coverageIndication(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? categoryOfConnectivitySubscription_optional {
			set { base.SetAttribute(new categoryOfConnectivitySubscription { value = value }); }
			get { return base.GetAttributeValue<categoryOfConnectivitySubscription>(nameof(categoryOfConnectivitySubscription))?.value; }
		}
		[JsonIgnore]
		public String? communicationStandard_optional {
			set { base.SetAttribute(new communicationStandard { value = value }); }
			get { return base.GetAttributeValue<communicationStandard>(nameof(communicationStandard))?.value; }
		}
		[JsonIgnore]
		public double? estimatedRangeOfTransmission_optional {
			set { base.SetAttribute(new estimatedRangeOfTransmission { value = value }); }
			get { return base.GetAttributeValue<estimatedRangeOfTransmission>(nameof(estimatedRangeOfTransmission))?.value; }
		}
		[JsonIgnore]
		public double? baseStationAntennaHeight_optional {
			set { base.SetAttribute(new baseStationAntennaHeight { value = value }); }
			get { return base.GetAttributeValue<baseStationAntennaHeight>(nameof(baseStationAntennaHeight))?.value; }
		}
		[JsonIgnore]
		public frequencyRange?[] frequencyRange_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<frequencyRange>(nameof(frequencyRange)); } 
	}
		[JsonIgnore]
		public sectorLimit?[] sectorLimit_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<sectorLimit>(nameof(sectorLimit)); } 
	}
		[JsonIgnore]
		public coverageIndication? coverageIndication_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<coverageIndication>(nameof(coverageIndication)); }
		}
		#endregion
	}

	/// <summary>
	/// An area defined for a global communications service based upon automated systems, both satellite based and terrestrial, to provide distress alerting and promulgation of maritime safety information for mariners.
	/// </summary>
	public class GMDSSArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(GMDSSArea);
		[JsonIgnore]
		public override string S100FC_name => "GMDSS Area";
		public idNAVAREA idNAVAREA { get; set; } = new idNAVAREA();
		public categoryOfGMDSSArea categoryOfGMDSSArea { get; set; } = new categoryOfGMDSSArea();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				idNAVAREA,
				categoryOfGMDSSArea,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(idNAVAREA),
					lower = 1,
					upper = 1,
					CreateInstance = () => new idNAVAREA(),
				},
				new attributeBinding {
					attribute = nameof(nationality),
					lower = 0,
					upper = 1,
					CreateInstance = () => new nationality(),
				},
				new attributeBinding {
					attribute = nameof(categoryOfGMDSSArea),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfGMDSSArea(),
				},
				new attributeBinding {
					attribute = nameof(areaA3ServiceDescription),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new areaA3ServiceDescription(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? nationality_optional {
			set { base.SetAttribute(new nationality { value = value }); }
			get { return base.GetAttributeValue<nationality>(nameof(nationality))?.value; }
		}
		[JsonIgnore]
		public areaA3ServiceDescription?[] areaA3ServiceDescription_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<areaA3ServiceDescription>(nameof(areaA3ServiceDescription)); } 
	}
		#endregion
	}

	/// <summary>
	/// A region in which the perception of a phenomenon or the availability of a service is known only to a specified level of confidence.
	/// </summary>
	public class IndeterminateZone : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(IndeterminateZone);
		[JsonIgnore]
		public override string S100FC_name => "Indeterminate Zone";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(informationConfidence),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new informationConfidence(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? informationConfidence_optional {
			set { base.SetAttribute(new informationConfidence { value = value }); }
			get { return base.GetAttributeValue<informationConfidence>(nameof(informationConfidence))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// A geographical sea area (which may include inland seas, lakes and waterways navigable by seagoing ships) established for the purpose of coordinating the broadcast of marine meteorological information.
	/// </summary>
	public class METAREA : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(METAREA);
		[JsonIgnore]
		public override string S100FC_name => "METAREA";
		public idMETAREA idMETAREA { get; set; } = new idMETAREA();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				idMETAREA,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(idMETAREA),
					lower = 1,
					upper = 1,
					CreateInstance = () => new idMETAREA(),
				},
				new attributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new onlineResource(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public onlineResource?[] onlineResource_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<onlineResource>(nameof(onlineResource)); } 
	}
		#endregion
	}

	/// <summary>
	/// The short title for a geographical sea area (may include inland seas, lakes and waterways navigable by sea-going ships) established for the purpose of coordinating the broadcast of navigational warnings. The term NAVAREA followed by a roman numeral may be used to identify a particular sea area. The delimitation of such areas is not related to and shall not prejudice the delimitation of any boundaries between States.
	/// </summary>
	public class NAVAREA : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NAVAREA);
		[JsonIgnore]
		public override string S100FC_name => "NAVAREA";
		public idNAVAREA idNAVAREA { get; set; } = new idNAVAREA();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				idNAVAREA,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(idNAVAREA),
					lower = 1,
					upper = 1,
					CreateInstance = () => new idNAVAREA(),
				},
				new attributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new onlineResource(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public onlineResource?[] onlineResource_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<onlineResource>(nameof(onlineResource)); } 
	}
		#endregion
	}

	/// <summary>
	/// A unique and precisely defined sea area, wholly contained within the NAVTEX coverage area, for which maritime safety information is provided from a particular NAVTEX transmitter.
	/// </summary>
	public class NAVTEXServiceArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NAVTEXServiceArea);
		[JsonIgnore]
		public override string S100FC_name => "NAVTEX Service Area";
		public typeOfNAVTEXService typeOfNAVTEXService { get; set; } = new typeOfNAVTEXService();
		public idNAVAREA idNAVAREA { get; set; } = new idNAVAREA();
		public transmitterIdentificationCharacter transmitterIdentificationCharacter { get; set; } = new transmitterIdentificationCharacter();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				typeOfNAVTEXService,
				idNAVAREA,
				transmitterIdentificationCharacter,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(typeOfNAVTEXService),
					lower = 1,
					upper = 1,
					permitedValues = [1,2],
					CreateInstance = () => new typeOfNAVTEXService(),
				},
				new attributeBinding {
					attribute = nameof(idNAVAREA),
					lower = 1,
					upper = 1,
					CreateInstance = () => new idNAVAREA(),
				},
				new attributeBinding {
					attribute = nameof(transmitterIdentificationCharacter),
					lower = 1,
					upper = 1,
					CreateInstance = () => new transmitterIdentificationCharacter(),
				},
				new attributeBinding {
					attribute = nameof(nationality),
					lower = 0,
					upper = 1,
					CreateInstance = () => new nationality(),
				},
				new attributeBinding {
					attribute = nameof(status),
					lower = 0,
					upper = 1,
					permitedValues = [1,4,7],
					CreateInstance = () => new status(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? nationality_optional {
			set { base.SetAttribute(new nationality { value = value }); }
			get { return base.GetAttributeValue<nationality>(nameof(nationality))?.value; }
		}
		[JsonIgnore]
		public int? status_optional {
			set { base.SetAttribute(new status { value = value }); }
			get { return base.GetAttributeValue<status>(nameof(status))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// The area where a radio service can be obtained and the characteristics of the radio transmission.
	/// </summary>
	public class RadioServiceArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadioServiceArea);
		[JsonIgnore]
		public override string S100FC_name => "Radio Service Area";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(languageInformation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new languageInformation(),
				},
				new attributeBinding {
					attribute = nameof(transmissionPower),
					lower = 0,
					upper = 1,
					CreateInstance = () => new transmissionPower(),
				},
				new attributeBinding {
					attribute = nameof(transmissionOfTrafficLists),
					lower = 0,
					upper = 1,
					CreateInstance = () => new transmissionOfTrafficLists(),
				},
				new attributeBinding {
					attribute = nameof(status),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,4,5,7,8,14,16,17],
					CreateInstance = () => new status(),
				},
				new attributeBinding {
					attribute = nameof(hoursOfWatch),
					lower = 0,
					upper = 1,
					CreateInstance = () => new hoursOfWatch(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? languageInformation_optional {
			set { base.SetAttribute(new languageInformation { value = value }); }
			get { return base.GetAttributeValue<languageInformation>(nameof(languageInformation))?.value; }
		}
		[JsonIgnore]
		public double? transmissionPower_optional {
			set { base.SetAttribute(new transmissionPower { value = value }); }
			get { return base.GetAttributeValue<transmissionPower>(nameof(transmissionPower))?.value; }
		}
		[JsonIgnore]
		public Boolean? transmissionOfTrafficLists_optional {
			set { base.SetAttribute(new transmissionOfTrafficLists { value = value }); }
			get { return base.GetAttributeValue<transmissionOfTrafficLists>(nameof(transmissionOfTrafficLists))?.value; }
		}
		[JsonIgnore]
		public int? status_optional {
			set { base.SetAttribute(new status { value = value }); }
			get { return base.GetAttributeValue<status>(nameof(status))?.value; }
		}
		[JsonIgnore]
		public String? hoursOfWatch_optional {
			set { base.SetAttribute(new hoursOfWatch { value = value }); }
			get { return base.GetAttributeValue<hoursOfWatch>(nameof(hoursOfWatch))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
	/// </summary>
	public class RadioStation : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadioStation);
		[JsonIgnore]
		public override string S100FC_name => "Radio Station";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(categoryOfRadioStation),
					lower = 0,
					upper = 1,
					permitedValues = [5,9,10,19,20],
					CreateInstance = () => new categoryOfRadioStation(),
				},
				new attributeBinding {
					attribute = nameof(estimatedRangeOfTransmission),
					lower = 0,
					upper = 1,
					CreateInstance = () => new estimatedRangeOfTransmission(),
				},
				new attributeBinding {
					attribute = nameof(transmissionContent),
					lower = 0,
					upper = 1,
					CreateInstance = () => new transmissionContent(),
				},
				new attributeBinding {
					attribute = nameof(remoteControlled),
					lower = 0,
					upper = 1,
					CreateInstance = () => new remoteControlled(),
				},
				new attributeBinding {
					attribute = nameof(status),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,4,5,7,8,16,17],
					CreateInstance = () => new status(),
				},
				new attributeBinding {
					attribute = nameof(radiocommunicationIdentifier),
					lower = 0,
					upper = 1,
					CreateInstance = () => new radiocommunicationIdentifier(),
				},
				new attributeBinding {
					attribute = nameof(sectorLimit),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new sectorLimit(),
				},
				new attributeBinding {
					attribute = nameof(hoursOfWatch),
					lower = 0,
					upper = 1,
					CreateInstance = () => new hoursOfWatch(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? categoryOfRadioStation_optional {
			set { base.SetAttribute(new categoryOfRadioStation { value = value }); }
			get { return base.GetAttributeValue<categoryOfRadioStation>(nameof(categoryOfRadioStation))?.value; }
		}
		[JsonIgnore]
		public double? estimatedRangeOfTransmission_optional {
			set { base.SetAttribute(new estimatedRangeOfTransmission { value = value }); }
			get { return base.GetAttributeValue<estimatedRangeOfTransmission>(nameof(estimatedRangeOfTransmission))?.value; }
		}
		[JsonIgnore]
		public String? transmissionContent_optional {
			set { base.SetAttribute(new transmissionContent { value = value }); }
			get { return base.GetAttributeValue<transmissionContent>(nameof(transmissionContent))?.value; }
		}
		[JsonIgnore]
		public Boolean? remoteControlled_optional {
			set { base.SetAttribute(new remoteControlled { value = value }); }
			get { return base.GetAttributeValue<remoteControlled>(nameof(remoteControlled))?.value; }
		}
		[JsonIgnore]
		public int? status_optional {
			set { base.SetAttribute(new status { value = value }); }
			get { return base.GetAttributeValue<status>(nameof(status))?.value; }
		}
		[JsonIgnore]
		public radiocommunicationIdentifier? radiocommunicationIdentifier_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<radiocommunicationIdentifier>(nameof(radiocommunicationIdentifier)); }
		}
		[JsonIgnore]
		public sectorLimit?[] sectorLimit_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<sectorLimit>(nameof(sectorLimit)); } 
	}
		[JsonIgnore]
		public String? hoursOfWatch_optional {
			set { base.SetAttribute(new hoursOfWatch { value = value }); }
			get { return base.GetAttributeValue<hoursOfWatch>(nameof(hoursOfWatch))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// A defined geographical area where a specific country or organization is designated to coordinate and provide search and rescue services.
	/// </summary>
	public class SearchAndRescueRegion : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SearchAndRescueRegion);
		[JsonIgnore]
		public override string S100FC_name => "Search and Rescue Region";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(nationality),
					lower = 0,
					upper = 1,
					CreateInstance = () => new nationality(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? nationality_optional {
			set { base.SetAttribute(new nationality { value = value }); }
			get { return base.GetAttributeValue<nationality>(nameof(nationality))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// An area for which weather forecasts and warnings are provided for specified periods.
	/// </summary>
	public class WeatherForecastAndWarningArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(WeatherForecastAndWarningArea);
		[JsonIgnore]
		public override string S100FC_name => "Weather Forecast and Warning Area";
		public categoryOfForecastOrWarningArea categoryOfForecastOrWarningArea { get; set; } = new categoryOfForecastOrWarningArea();

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				categoryOfForecastOrWarningArea,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBinding {
					attribute = nameof(categoryOfForecastOrWarningArea),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new categoryOfForecastOrWarningArea(),
				},
				new attributeBinding {
					attribute = nameof(idMETAREA),
					lower = 0,
					upper = 1,
					CreateInstance = () => new idMETAREA(),
				},
				new attributeBinding {
					attribute = nameof(nationality),
					lower = 0,
					upper = 1,
					CreateInstance = () => new nationality(),
				},
				new attributeBinding {
					attribute = nameof(status),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,4,5,7,8,14],
					CreateInstance = () => new status(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public String? idMETAREA_optional {
			set { base.SetAttribute(new idMETAREA { value = value }); }
			get { return base.GetAttributeValue<idMETAREA>(nameof(idMETAREA))?.value; }
		}
		[JsonIgnore]
		public String? nationality_optional {
			set { base.SetAttribute(new nationality { value = value }); }
			get { return base.GetAttributeValue<nationality>(nameof(nationality))?.value; }
		}
		[JsonIgnore]
		public int? status_optional {
			set { base.SetAttribute(new status { value = value }); }
			get { return base.GetAttributeValue<status>(nameof(status))?.value; }
		}
		#endregion
	}

	/// <summary>
	/// Aggregation of a geographic feature describing a service or phenomenon with zones of different confidence about the availability of the service, occurrence of the phenomenon, or applicability of the information described by the geographic feature.
	/// </summary>
	public class FuzzyAreaAggregate : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(FuzzyAreaAggregate);
		[JsonIgnore]
		public override string S100FC_name => "Fuzzy Area Aggregate";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Aggregation of areas where radio services from a single radio service are available to different levels of reliability.
	/// </summary>
	public class RadioServiceAreaAggregate : FuzzyAreaAggregate
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadioServiceAreaAggregate);
		[JsonIgnore]
		public override string S100FC_name => "Radio Service Area Aggregate";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributes,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
			];
		#endregion

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// A geographical area that describes the coverage and extent of spatial objects.
	/// </summary>
	public class DataCoverage : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(DataCoverage);
		[JsonIgnore]
		public override string S100FC_name => "Data Coverage";
		public maximumDisplayScale maximumDisplayScale { get; set; } = new maximumDisplayScale();
		public minimumDisplayScale minimumDisplayScale { get; set; } = new minimumDisplayScale();

		[JsonIgnore]
		public override Attribute[] attributes => [
				maximumDisplayScale,
				minimumDisplayScale,
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(maximumDisplayScale),
					lower = 1,
					upper = 1,
					CreateInstance = () => new maximumDisplayScale(),
				},
				new attributeBinding {
					attribute = nameof(minimumDisplayScale),
					lower = 1,
					upper = 1,
					CreateInstance = () => new minimumDisplayScale(),
				},
				new attributeBinding {
					attribute = nameof(optimumDisplayScale),
					lower = 0,
					upper = 1,
					CreateInstance = () => new optimumDisplayScale(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? optimumDisplayScale_optional {
			set { base.SetAttribute(new optimumDisplayScale { value = value }); }
			get { return base.GetAttributeValue<optimumDisplayScale>(nameof(optimumDisplayScale))?.value; }
		}
		[JsonIgnore]
		public information?[] information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		#endregion
	}

	/// <summary>
	/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
	/// </summary>
	public class QualityOfNonBathymetricData : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(QualityOfNonBathymetricData);
		[JsonIgnore]
		public override string S100FC_name => "Quality of Non-Bathymetric Data";

		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];

		#region Catalogue
		[JsonIgnore]
		public override attributeBinding[] attributeBindingsCatalogue => [
				new attributeBinding {
					attribute = nameof(categoryOfTemporalVariation),
					lower = 0,
					upper = 1,
					permitedValues = [1,4,5],
					CreateInstance = () => new categoryOfTemporalVariation(),
				},
				new attributeBinding {
					attribute = nameof(horizontalDistanceUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new horizontalDistanceUncertainty(),
				},
				new attributeBinding {
					attribute = nameof(horizontalPositionUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
				new attributeBinding {
					attribute = nameof(orientationUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new orientationUncertainty(),
				},
				new attributeBinding {
					attribute = nameof(surveyDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new surveyDateRange(),
				},
				new attributeBinding {
					attribute = nameof(verticalUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new verticalUncertainty(),
				},
				new attributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
			];
		#endregion

		#region Optional Attributes
		[JsonIgnore]
		public int? categoryOfTemporalVariation_optional {
			set { base.SetAttribute(new categoryOfTemporalVariation { value = value }); }
			get { return base.GetAttributeValue<categoryOfTemporalVariation>(nameof(categoryOfTemporalVariation))?.value; }
		}
		[JsonIgnore]
		public double? horizontalDistanceUncertainty_optional {
			set { base.SetAttribute(new horizontalDistanceUncertainty { value = value }); }
			get { return base.GetAttributeValue<horizontalDistanceUncertainty>(nameof(horizontalDistanceUncertainty))?.value; }
		}
		[JsonIgnore]
		public horizontalPositionUncertainty? horizontalPositionUncertainty_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<horizontalPositionUncertainty>(nameof(horizontalPositionUncertainty)); }
		}
		[JsonIgnore]
		public double? orientationUncertainty_optional {
			set { base.SetAttribute(new orientationUncertainty { value = value }); }
			get { return base.GetAttributeValue<orientationUncertainty>(nameof(orientationUncertainty))?.value; }
		}
		[JsonIgnore]
		public surveyDateRange? surveyDateRange_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<surveyDateRange>(nameof(surveyDateRange)); }
		}
		[JsonIgnore]
		public verticalUncertainty? verticalUncertainty_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<verticalUncertainty>(nameof(verticalUncertainty)); }
		}
		[JsonIgnore]
		public information?[] information_optional {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValues<information>(nameof(information)); } 
	}
		#endregion
	}

}

namespace S100Framework.AttributeModel.S123
{
	using System.Text.Json;
	using S100Framework.AttributeModel.S123.SimpleAttributes;
	using S100Framework.AttributeModel.S123.ComplexAttributes;
	using S100Framework.AttributeModel.S123.FeatureAssociation;
	using S100Framework.AttributeModel.S123.FeatureTypes;

	public class Summary : ISummary
	{
		public static string Name => "Marine Radio Services";
		public static string Scope => "Global";
		public static string ProductId => "S-123";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-12-10", "yyyy-MM-dd");
	}

	public static class Extensions {
		public static JsonSerializerOptions AppendTypeInfoResolver(this JsonSerializerOptions jsonSerializerOptions) {
			var resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
			resolver.Modifiers.Add(typeInfo => {
				if (typeInfo.Type == typeof(S100Framework.AttributeModel.informationBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$association",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AdditionalInformation>), typeDiscriminator: "AdditionalInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AssociatedRxN>), typeDiscriminator: "AssociatedRxN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AuthorityContact>), typeDiscriminator: "AuthorityContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AuthorityHours>), typeDiscriminator: "AuthorityHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AvailableQoS>), typeDiscriminator: "AvailableQoS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.BroadcastService>), typeDiscriminator: "BroadcastService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.BroadcastTransmission>), typeDiscriminator: "BroadcastTransmission"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ConnectivityService>), typeDiscriminator: "ConnectivityService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ExceptionalWorkday>), typeDiscriminator: "ExceptionalWorkday"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.InclusionType>), typeDiscriminator: "InclusionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.LocationHours>), typeDiscriminator: "LocationHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.PermissionType>), typeDiscriminator: "PermissionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.RadioServiceControl>), typeDiscriminator: "RadioServiceControl"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.relatedOrganisation>), typeDiscriminator: "relatedOrganisation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ServiceContact>), typeDiscriminator: "ServiceContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ServiceCoordination>), typeDiscriminator: "ServiceCoordination"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.SpatialAssociation>), typeDiscriminator: "SpatialAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.TMAS>), typeDiscriminator: "TMAS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.TransmissionService>), typeDiscriminator: "TransmissionService"));
				}
				if (typeInfo.Type == typeof(S100Framework.AttributeModel.featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$association",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.coreAggregation>), typeDiscriminator: "coreAggregation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.fuzzyZoneAggregation>), typeDiscriminator: "fuzzyZoneAggregation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.ServiceProvisionArea>), typeDiscriminator: "ServiceProvisionArea"));
				}
				if (typeInfo.Type == typeof(S100Framework.AttributeModel.Attribute)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(acceptAMVER), typeDiscriminator: "acceptAMVER"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(actionOrActivity), typeDiscriminator: "actionOrActivity"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(administrativeDivision), typeDiscriminator: "administrativeDivision"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(baseStationAntennaHeight), typeDiscriminator: "baseStationAntennaHeight"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(callName), typeDiscriminator: "callName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(callSign), typeDiscriminator: "callSign"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactInstructions), typeDiscriminator: "contactInstructions"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfAuthority), typeDiscriminator: "categoryOfAuthority"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfBroadcastCommunication), typeDiscriminator: "categoryOfBroadcastCommunication"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfCargo), typeDiscriminator: "categoryOfCargo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfDangerousOrHazardousCargo), typeDiscriminator: "categoryOfDangerousOrHazardousCargo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfForecastOrWarningArea), typeDiscriminator: "categoryOfForecastOrWarningArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfGMDSSArea), typeDiscriminator: "categoryOfGMDSSArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRadioStation), typeDiscriminator: "categoryOfRadioStation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRelationship), typeDiscriminator: "categoryOfRelationship"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRxN), typeDiscriminator: "categoryOfRxN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSchedule), typeDiscriminator: "categoryOfSchedule"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfTemporalVariation), typeDiscriminator: "categoryOfTemporalVariation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfText), typeDiscriminator: "categoryOfText"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVessel), typeDiscriminator: "categoryOfVessel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVesselRegistry), typeDiscriminator: "categoryOfVesselRegistry"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfConnectivitySubscription), typeDiscriminator: "categoryOfConnectivitySubscription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(classOfEmission), typeDiscriminator: "classOfEmission"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(coastStationIdentificationCode), typeDiscriminator: "coastStationIdentificationCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(communicationChannel), typeDiscriminator: "communicationChannel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(communicationStandard), typeDiscriminator: "communicationStandard"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(comparisonOperator), typeDiscriminator: "comparisonOperator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(countryName), typeDiscriminator: "countryName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cityName), typeDiscriminator: "cityName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dataTransmissionRate), typeDiscriminator: "dataTransmissionRate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateEnd), typeDiscriminator: "dateEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateFixed), typeDiscriminator: "dateFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateStart), typeDiscriminator: "dateStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateVariable), typeDiscriminator: "dateVariable"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dayOfWeek), typeDiscriminator: "dayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dayOfWeekIsRange), typeDiscriminator: "dayOfWeekIsRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(deliveryPoint), typeDiscriminator: "deliveryPoint"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(downlinkBandwidth), typeDiscriminator: "downlinkBandwidth"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(estimatedRangeOfTransmission), typeDiscriminator: "estimatedRangeOfTransmission"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileLocator), typeDiscriminator: "fileLocator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileReference), typeDiscriminator: "fileReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyBand), typeDiscriminator: "frequencyBand"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyShoreStationReceives), typeDiscriminator: "frequencyShoreStationReceives"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyShoreStationTransmits), typeDiscriminator: "frequencyShoreStationTransmits"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyLimitLower), typeDiscriminator: "frequencyLimitLower"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyLimitUpper), typeDiscriminator: "frequencyLimitUpper"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(headline), typeDiscriminator: "headline"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(hoursOfWatch), typeDiscriminator: "hoursOfWatch"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalDistanceUncertainty), typeDiscriminator: "horizontalDistanceUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(idMETAREA), typeDiscriminator: "idMETAREA"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(idNAVAREA), typeDiscriminator: "idNAVAREA"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(inBallast), typeDiscriminator: "inBallast"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationConfidence), typeDiscriminator: "informationConfidence"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(interoperabilityIdentifier), typeDiscriminator: "interoperabilityIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(isMRCC), typeDiscriminator: "isMRCC"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(language), typeDiscriminator: "language"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(languageInformation), typeDiscriminator: "languageInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(linkage), typeDiscriminator: "linkage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(logicalConnectives), typeDiscriminator: "logicalConnectives"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumDataBurstVolume), typeDiscriminator: "maximumDataBurstVolume"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumDisplayScale), typeDiscriminator: "maximumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(membership), typeDiscriminator: "membership"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumDisplayScale), typeDiscriminator: "minimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumReceivedPower), typeDiscriminator: "minimumReceivedPower"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumSignalToInterferenceNoiseRatio), typeDiscriminator: "minimumSignalToInterferenceNoiseRatio"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minutePastEvenHours), typeDiscriminator: "minutePastEvenHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minutePastEveryHour), typeDiscriminator: "minutePastEveryHour"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minutePastOddHours), typeDiscriminator: "minutePastOddHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(mMSICode), typeDiscriminator: "mMSICode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(mSICoastalWarningArea), typeDiscriminator: "mSICoastalWarningArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(name), typeDiscriminator: "name"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameOfResource), typeDiscriminator: "nameOfResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameUsage), typeDiscriminator: "nameUsage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nationality), typeDiscriminator: "nationality"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(observationTime), typeDiscriminator: "observationTime"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(optimumDisplayScale), typeDiscriminator: "optimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationUncertainty), typeDiscriminator: "orientationUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(packetDelay), typeDiscriminator: "packetDelay"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictorialRepresentation), typeDiscriminator: "pictorialRepresentation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictureCaption), typeDiscriminator: "pictureCaption"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictureInformation), typeDiscriminator: "pictureInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(postalCode), typeDiscriminator: "postalCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(presumedReceiverAntennaHeight), typeDiscriminator: "presumedReceiverAntennaHeight"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(qualityOfHorizontalMeasurement), typeDiscriminator: "qualityOfHorizontalMeasurement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(remoteControlled), typeDiscriminator: "remoteControlled"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(reportedDate), typeDiscriminator: "reportedDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(satelliteOceanRegion), typeDiscriminator: "satelliteOceanRegion"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorBearing), typeDiscriminator: "sectorBearing"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorLineLength), typeDiscriminator: "sectorLineLength"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(selectiveCallNumber), typeDiscriminator: "selectiveCallNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(servingMobileSatelliteService), typeDiscriminator: "servingMobileSatelliteService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceDate), typeDiscriminator: "sourceDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(source), typeDiscriminator: "source"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(status), typeDiscriminator: "status"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(subjectDescription), typeDiscriminator: "subjectDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(subjectOrMessageTypeCode), typeDiscriminator: "subjectOrMessageTypeCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationIdentifier), typeDiscriminator: "telecommunicationIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationService), typeDiscriminator: "telecommunicationService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(text), typeDiscriminator: "text"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(thicknessOfIceCapability), typeDiscriminator: "thicknessOfIceCapability"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayEnd), typeDiscriminator: "timeOfDayEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayStart), typeDiscriminator: "timeOfDayStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(transmissionContent), typeDiscriminator: "transmissionContent"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(transmitterIdentificationCharacter), typeDiscriminator: "transmitterIdentificationCharacter"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(transmissionOfTrafficLists), typeDiscriminator: "transmissionOfTrafficLists"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(transmissionPower), typeDiscriminator: "transmissionPower"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(transmissionRegularity), typeDiscriminator: "transmissionRegularity"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(transmissionTime), typeDiscriminator: "transmissionTime"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(typeOfBroadcastContent), typeDiscriminator: "typeOfBroadcastContent"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(typeOfConnectivityResource), typeDiscriminator: "typeOfConnectivityResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(typeOfNAVTEXService), typeDiscriminator: "typeOfNAVTEXService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(typeOfRadioService), typeDiscriminator: "typeOfRadioService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyFixed), typeDiscriminator: "uncertaintyFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyVariableFactor), typeDiscriminator: "uncertaintyVariableFactor"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uplinkBandwidth), typeDiscriminator: "uplinkBandwidth"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristics), typeDiscriminator: "vesselsCharacteristics"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristicsUnit), typeDiscriminator: "vesselsCharacteristicsUnit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristicsValue), typeDiscriminator: "vesselsCharacteristicsValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselPerformance), typeDiscriminator: "vesselPerformance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(areaA3ServiceDescription), typeDiscriminator: "areaA3ServiceDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(broadcastContent), typeDiscriminator: "broadcastContent"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactAddress), typeDiscriminator: "contactAddress"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(coverageIndication), typeDiscriminator: "coverageIndication"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureName), typeDiscriminator: "featureName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fixedDateRange), typeDiscriminator: "fixedDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyPair), typeDiscriminator: "frequencyPair"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyRange), typeDiscriminator: "frequencyRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(graphic), typeDiscriminator: "graphic"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalPositionUncertainty), typeDiscriminator: "horizontalPositionUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(information), typeDiscriminator: "information"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineResource), typeDiscriminator: "onlineResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(periodicDateRange), typeDiscriminator: "periodicDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(radioChannelDetails), typeDiscriminator: "radioChannelDetails"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(radiocommunicationIdentifier), typeDiscriminator: "radiocommunicationIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(rxNCode), typeDiscriminator: "rxNCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorLimitOne), typeDiscriminator: "sectorLimitOne"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorLimitTwo), typeDiscriminator: "sectorLimitTwo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(surveyDateRange), typeDiscriminator: "surveyDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunications), typeDiscriminator: "telecommunications"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textContent), typeDiscriminator: "textContent"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeIntervalsByDayOfWeek), typeDiscriminator: "timeIntervalsByDayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timesOfTransmission), typeDiscriminator: "timesOfTransmission"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalUncertainty), typeDiscriminator: "verticalUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselMeasurementsSpecification), typeDiscriminator: "vesselMeasurementsSpecification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scheduleByDayOfWeek), typeDiscriminator: "scheduleByDayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorLimit), typeDiscriminator: "sectorLimit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(spatialAccuracy), typeDiscriminator: "spatialAccuracy"));
				}
			});
			jsonSerializerOptions.TypeInfoResolver = resolver;
			return jsonSerializerOptions;
		}
	}
}
