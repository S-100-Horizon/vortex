using System;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100FC.S122.SimpleAttributes
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
				new listedValue("Historic Wreck Area", "An area around certain wrecks of historical importance to protect the wrecks from unauthorized interference by diving, salvage or deposition (including anchoring).",10),
				new listedValue("Research Area", "An area where marine research takes place.",20),
				new listedValue("Fish Sanctuary", "A place where fish (including shellfish and crustaceans) are protected.",22),
				new listedValue("Ecological Reserve", "A tract of land managed so as to preserve the relation of plants and living creatures to each other and to their surroundings.",23),
				new listedValue("Environmentally Sensitive Sea Area", "A generic term which may be used to describe a wide range of areas, considered sensitive for a variety of environmental reasons.",27),
				new listedValue("Particularly Sensitive Sea Area", "An area that needs special protection through action by IMO because of its significance for regional ecological, socio-economic or scientific reasons and because it may be vulnerable to damage by international shipping activities.",28),
				new listedValue("Coral Sanctuary", "A place where coral is protected.",31),
				new listedValue("Recreation Area", "An area within which recreational activities regularly take place and therefore vessel movement may be restricted.",32),
				new listedValue("Ship Pollution Emission Control", "An area within which the ship pollution emission is controlled.",33),
			];

		public static implicit operator categoryOfRestrictedArea(int? value) => new categoryOfRestrictedArea { value = value };
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
	/// An identifier which is an instance of a particular, named scheme
	/// </summary>
	public class designationIdentifier : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(designationIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Designation Identifier";

		public static implicit operator designationIdentifier(String? value) => new designationIdentifier { value = value };
	}

	/// <summary>
	/// An official name, title or description. This can be an identifier itself, or an identifier which is an instance of a named designation scheme.
	/// </summary>
	public class designationScheme : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(designationScheme);
		[JsonIgnore]
		public override string S100FC_name => "Designation Scheme";

		public static implicit operator designationScheme(String? value) => new designationScheme { value = value };
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
	/// The jurisdiction applicable to an administrative area.
	/// </summary>
	public class jurisdiction : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(jurisdiction);
		[JsonIgnore]
		public override string S100FC_name => "Jurisdiction";
		public static listedValue[] listedValues => [
				new listedValue("International", "Involving more than one country; covering more than one national area.",1),
				new listedValue("National", "An area administered or controlled by a single nation.",2),
				new listedValue("National Sub-Division", "An area smaller than the nation in which it lies.",3),
			];

		public static implicit operator jurisdiction(int? value) => new jurisdiction { value = value };
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
	/// Code for function performed by the online resource (ISO 19115)
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
	/// Detailed text description of what the online resource is/does (ISO 19115)
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
				new listedValue("Use of Spuds Prohibited", "The use of anchoring spuds (telescopic piles) is prohibited.",38),
				new listedValue("Swimming Prohibited", "An area in which swimming is prohibited.",39),
				new listedValue("SOx Emission Restricted", "An area within which the emission of SOx is restricted.",40),
				new listedValue("NOx Emission Restricted", "An area within which the emission of NOx is restricted.",41),
				new listedValue("Power-Driven Vessels Prohibited", "An area within which any vessel propelled by machinery is prohibited.",42),
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
				new listedValue("Mandatory", "Compulsory; enforced.",9),
				new listedValue("Historic", "Famous in history; of historical interest.",13),
				new listedValue("Public", "Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.",14),
				new listedValue("Existence Doubtful", "A feature that has been reported but has not been definitely determined to exist.",18),
				new listedValue("Buoyed", "Marked by buoys.",28),
			];

		public static implicit operator status(int? value) => new status { value = value };
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
	/// Classification of marine protected areas based on IUCN (International Union for Conservation of Nature and Natural Resources) categories.
	/// </summary>
	public class categoryOfMarineProtectedArea : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfMarineProtectedArea);
		[JsonIgnore]
		public override string S100FC_name => "Category of Marine Protected Area";
		public static listedValue[] listedValues => [
				new listedValue("IUCN Category Ia", "Strict Nature Reserve: Protected area managed mainly for science.",1),
				new listedValue("IUCN Category Ib", "Wilderness Area: Protected area managed mainly for wilderness protection.",2),
				new listedValue("IUCN Category II", "National Park: Protected area managed mainly for ecosystem protection and recreation.",3),
				new listedValue("IUCN Category III", "Natural Monument: Protected area managed mainly for conservation of specific natural features.",4),
				new listedValue("IUCN Category IV", "Habitat/Species Management Area: Protected area managed mainly for conservation through management intervention.",5),
				new listedValue("IUCN Category V", "Protected Landscape/Seascape: Protected area managed mainly for landscape/seascape conservation and recreation.",6),
				new listedValue("IUCN Category VI", "Managed Resource Protected Area: Protected area managed mainly for the sustainable use of natural ecosystems.",7),
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

namespace S100FC.S122.ComplexAttributes
{
	using S100FC.S122.SimpleAttributes;

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
	/// An official name, title or description. This can be an identifier or an identifier which is an instance of a named designation scheme.
	/// </summary>
	public class designation : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(designation);
		[JsonIgnore]
		public override string S100FC_name => "Designation";

		#region Attributes
		[JsonIgnore]
		public String? designationScheme {
			set { base.SetAttribute(new designationScheme { value = value }); }
			get { return base.GetAttributeValue<designationScheme>(nameof(designationScheme))?.value; }
		}
		[JsonIgnore]
		public String? designationIdentifier {
			set { base.SetAttribute(new designationIdentifier { value = value }); }
			get { return base.GetAttributeValue<designationIdentifier>(nameof(designationIdentifier))?.value; }
		}
		[JsonIgnore]
		public int? jurisdiction {
			set { base.SetAttribute(new jurisdiction { value = value }); }
			get { return base.GetAttributeValue<jurisdiction>(nameof(jurisdiction))?.value; }
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
					attribute = nameof(designationScheme),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new designationScheme(),
				},
				new attributeBindingDefinition {
					attribute = nameof(designationIdentifier),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new designationIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(jurisdiction),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3],
					CreateInstance = () => new jurisdiction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(text),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new text(),
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
		public String? protocolRequest {
			set { base.SetAttribute(new protocolRequest { value = value }); }
			get { return base.GetAttributeValue<protocolRequest>(nameof(protocolRequest))?.value; }
		}
		[JsonIgnore]
		public int? onlineFunction {
			set { base.SetAttribute(new onlineFunction { value = value }); }
			get { return base.GetAttributeValue<onlineFunction>(nameof(onlineFunction))?.value; }
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
					attribute = nameof(protocolRequest),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new protocolRequest(),
				},
				new attributeBindingDefinition {
					attribute = nameof(onlineFunction),
					lower = 0,
					upper = 1,
					order = 6,
					permitedValues = [1,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new onlineFunction(),
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
		public String? headline {
			set { base.SetAttribute(new headline { value = value }); }
			get { return base.GetAttributeValue<headline>(nameof(headline))?.value; }
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
					upper = 1,
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

}

namespace S100FC.S122.InformationAssociation
{
	using S100FC.S122.SimpleAttributes;
	using S100FC.S122.ComplexAttributes;

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
	/// There may be more than one such authority depending on how responsibilities are divided
	/// </summary>
	public class ProtectedAreaAuthority : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ProtectedAreaAuthority);
		[JsonIgnore]
		public override string S100FC_name => "Protected area authority";
		public static string role => "responsibleAuthority";

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

}

namespace S100FC.S122.FeatureAssociation
{
	using S100FC.S122.SimpleAttributes;
	using S100FC.S122.ComplexAttributes;

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

}

namespace S100FC.S122.InformationTypes
{
	using S100FC.S122.SimpleAttributes;
	using S100FC.S122.ComplexAttributes;

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

namespace S100FC.S122.FeatureTypes
{
	using S100FC.S122.SimpleAttributes;
	using S100FC.S122.ComplexAttributes;
	using S100FC.S122.InformationTypes;

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
	/// An area for which general information regarding navigation, but not directly related to safety of navigation, is available.
	/// </summary>
	public class InformationArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(InformationArea);
		[JsonIgnore]
		public override string S100FC_name => "Information Area";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfRelationship {
			set { base.SetAttribute(new categoryOfRelationship { value = value }); }
			get { return base.GetAttributeValue<categoryOfRelationship>(nameof(categoryOfRelationship))?.value; }
		}
		[JsonIgnore]
		public int? actionOrActivity {
			set { base.SetAttribute(new actionOrActivity { value = value }); }
			get { return base.GetAttributeValue<actionOrActivity>(nameof(actionOrActivity))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfRelationship),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,3],
					CreateInstance = () => new categoryOfRelationship(),
				},
				new attributeBindingDefinition {
					attribute = nameof(actionOrActivity),
					lower = 1,
					upper = 1,
					order = 1,
					permitedValues = [17],
					CreateInstance = () => new actionOrActivity(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => InformationArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => InformationArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.surface];
	}

	/// <summary>
	/// Any area of the intertidal or sub-tidal terrain, together with its overlying water and associated flora, fauna, historical and cultural features, which has been reserved by law or other effective means to protect part or all of the enclosed environment.
	/// </summary>
	public class MarineProtectedArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(MarineProtectedArea);
		[JsonIgnore]
		public override string S100FC_name => "Marine Protected Area";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfMarineProtectedArea {
			set { base.SetAttribute("categoryOfMarineProtectedArea", [.. value.Select(e=> new categoryOfMarineProtectedArea { value = e })]); }
			get { return base.GetAttributeValues<categoryOfMarineProtectedArea>(nameof(categoryOfMarineProtectedArea)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] categoryOfRestrictedArea {
			set { base.SetAttribute("categoryOfRestrictedArea", [.. value.Select(e=> new categoryOfRestrictedArea { value = e })]); }
			get { return base.GetAttributeValues<categoryOfRestrictedArea>(nameof(categoryOfRestrictedArea)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? jurisdiction {
			set { base.SetAttribute(new jurisdiction { value = value }); }
			get { return base.GetAttributeValue<jurisdiction>(nameof(jurisdiction))?.value; }
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
		[JsonIgnore]
		public designation?[] designation {
			set { base.SetAttribute("designation", value); }
			get { return base.GetAttributeValues<designation>(nameof(designation)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfMarineProtectedArea),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new categoryOfMarineProtectedArea(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfRestrictedArea),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,4,5,6,7,10,20,22,23,27,28,31,32,33],
					CreateInstance = () => new categoryOfRestrictedArea(),
				},
				new attributeBindingDefinition {
					attribute = nameof(jurisdiction),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3],
					CreateInstance = () => new jurisdiction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(restriction),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,38,39,40,41,42],
					CreateInstance = () => new restriction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [1,2,3,4,5,6,7,9,18,28,13,14],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(designation),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new designation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => MarineProtectedArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. FeatureType.informationBindingsDefinitions,
				new informationBindingDefinition {
					roleType = "association",
					role = "responsibleAuthority",
					association = "ProtectedAreaAuthority",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(Authority)],
					CreateInstance = () => new informationBinding<InformationAssociation.ProtectedAreaAuthority>() {
						roleType = "association",
						role = "responsibleAuthority",
					},
				},
			];

		public static informationBinding<InformationAssociation.ProtectedAreaAuthority> ProtectedAreaAuthority => new informationBinding<InformationAssociation.ProtectedAreaAuthority> {
			roleType = "association",
			role = "responsibleAuthority",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => MarineProtectedArea.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.curve,Primitives.surface];
	}

	/// <summary>
	/// A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.
	/// </summary>
	public class RestrictedArea : FeatureType
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
					permitedValues = [1,4,5,6,7,10,20,22,23,27,28,31,32,33],
					CreateInstance = () => new categoryOfRestrictedArea(),
				},
				new attributeBindingDefinition {
					attribute = nameof(restriction),
					lower = 1,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,38,39,40,41,42],
					CreateInstance = () => new restriction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,9,18,28,13,14],
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
	/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
	/// </summary>
	public class VesselTrafficServiceArea : FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(VesselTrafficServiceArea);
		[JsonIgnore]
		public override string S100FC_name => "Vessel Traffic Service Area";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => VesselTrafficServiceArea.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				.. FeatureType.informationBindingsDefinitions,
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

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => VesselTrafficServiceArea.featureBindingsDefinitions;

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

namespace S100FC.S122
{
	using System.Text.Json;
	using S100FC.S122.SimpleAttributes;
	using S100FC.S122.ComplexAttributes;
	using S100FC.S122.InformationAssociation;
	using S100FC.S122.FeatureAssociation;
	using S100FC.S122.InformationTypes;
	using S100FC.S122.FeatureTypes;

	public class Summary : ISummary
	{
		public static string Name => "Marine Protected Area";
		public static string Scope => "";
		public static string ProductId => "S-122";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2026-01-16", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["contactAddress","designation","featureName","fixedDateRange","frequencyPair","horizontalPositionUncertainty","information","onlineResource","orientation","periodicDateRange","rxNCode","sourceIndication","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","verticalUncertainty","vesselMeasurementsSpecification","bearingInformation","graphic","scheduleByDayOfWeek","spatialAccuracy"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AuthorityContact","AuthorityHours","AssociatedRxN","ExceptionalWorkday","ProtectedAreaAuthority","RelatedOrganisation","InclusionType","PermissionType","ServiceControl","SpatialAssociation"];
		public static string[] FeatureAssociationTypes => ["TextAssociation"];
		public static string[] InformationTypes => ["InformationType","AbstractRxN","Applicability","Authority","ContactDetails","NauticalInformation","NonStandardWorkingDay","Recommendations","Regulations","Restrictions","ServiceHours","SpatialQuality"];
		public static string[] FeatureTypes => ["FeatureType","InformationArea","MarineProtectedArea","RestrictedArea","VesselTrafficServiceArea","DataCoverage","QualityOfNonBathymetricData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType"],
			Primitives.point => ["TextPlacement"],
			Primitives.pointSet => [],
			Primitives.curve => ["MarineProtectedArea"],
			Primitives.surface => ["InformationArea","MarineProtectedArea","RestrictedArea","VesselTrafficServiceArea","DataCoverage","QualityOfNonBathymetricData"],
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
			"MarineProtectedArea::ProtectedAreaAuthority" => MarineProtectedArea.ProtectedAreaAuthority,
			"VesselTrafficServiceArea::ServiceControl" => VesselTrafficServiceArea.ServiceControl,
			"" => throw new KeyNotFoundException(),
			_ => throw new KeyNotFoundException(),
		};

		public static featureBinding CreateFeatureBinding(string featureType, string association, string role) => $"{featureType}::{association}" switch {
			"FeatureType::TextAssociation" => FeatureType.TextAssociation(role),
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ProtectedAreaAuthority>), typeDiscriminator: "ProtectedAreaAuthority"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.RelatedOrganisation>), typeDiscriminator: "RelatedOrganisation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.InclusionType>), typeDiscriminator: "InclusionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.PermissionType>), typeDiscriminator: "PermissionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.ServiceControl>), typeDiscriminator: "ServiceControl"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.SpatialAssociation>), typeDiscriminator: "SpatialAssociation"));
				}
				if (typeInfo.Type == typeof(S100FC.featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.TextAssociation>), typeDiscriminator: "TextAssociation"));
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfCargo), typeDiscriminator: "categoryOfCargo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfCommunicationPreference), typeDiscriminator: "categoryOfCommunicationPreference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfDangerousOrHazardousCargo), typeDiscriminator: "categoryOfDangerousOrHazardousCargo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRelationship), typeDiscriminator: "categoryOfRelationship"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRestrictedArea), typeDiscriminator: "categoryOfRestrictedArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSchedule), typeDiscriminator: "categoryOfSchedule"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfTemporalVariation), typeDiscriminator: "categoryOfTemporalVariation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfText), typeDiscriminator: "categoryOfText"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVesselRegistry), typeDiscriminator: "categoryOfVesselRegistry"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cityName), typeDiscriminator: "cityName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(communicationChannel), typeDiscriminator: "communicationChannel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(comparisonOperator), typeDiscriminator: "comparisonOperator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactInstructions), typeDiscriminator: "contactInstructions"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(countryName), typeDiscriminator: "countryName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateEnd), typeDiscriminator: "dateEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateFixed), typeDiscriminator: "dateFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateStart), typeDiscriminator: "dateStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateVariable), typeDiscriminator: "dateVariable"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dayOfWeek), typeDiscriminator: "dayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dayOfWeekIsRange), typeDiscriminator: "dayOfWeekIsRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(deliveryPoint), typeDiscriminator: "deliveryPoint"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(designationIdentifier), typeDiscriminator: "designationIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(designationScheme), typeDiscriminator: "designationScheme"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(destination), typeDiscriminator: "destination"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(distance), typeDiscriminator: "distance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileLocator), typeDiscriminator: "fileLocator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileReference), typeDiscriminator: "fileReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyShoreStationReceives), typeDiscriminator: "frequencyShoreStationReceives"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(frequencyShoreStationTransmits), typeDiscriminator: "frequencyShoreStationTransmits"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(headline), typeDiscriminator: "headline"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalDistanceUncertainty), typeDiscriminator: "horizontalDistanceUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(inBallast), typeDiscriminator: "inBallast"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(interoperabilityIdentifier), typeDiscriminator: "interoperabilityIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(jurisdiction), typeDiscriminator: "jurisdiction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(language), typeDiscriminator: "language"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(linkage), typeDiscriminator: "linkage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(logicalConnectives), typeDiscriminator: "logicalConnectives"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumDisplayScale), typeDiscriminator: "maximumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(membership), typeDiscriminator: "membership"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumDisplayScale), typeDiscriminator: "minimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(mMSICode), typeDiscriminator: "mMSICode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(name), typeDiscriminator: "name"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameOfResource), typeDiscriminator: "nameOfResource"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameUsage), typeDiscriminator: "nameUsage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineFunction), typeDiscriminator: "onlineFunction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(onlineResourceDescription), typeDiscriminator: "onlineResourceDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(optimumDisplayScale), typeDiscriminator: "optimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationUncertainty), typeDiscriminator: "orientationUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationValue), typeDiscriminator: "orientationValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictorialRepresentation), typeDiscriminator: "pictorialRepresentation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictureCaption), typeDiscriminator: "pictureCaption"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictureInformation), typeDiscriminator: "pictureInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(postalCode), typeDiscriminator: "postalCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(protocol), typeDiscriminator: "protocol"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(protocolRequest), typeDiscriminator: "protocolRequest"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(qualityOfHorizontalMeasurement), typeDiscriminator: "qualityOfHorizontalMeasurement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(reportedDate), typeDiscriminator: "reportedDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(restriction), typeDiscriminator: "restriction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scaleMinimum), typeDiscriminator: "scaleMinimum"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(source), typeDiscriminator: "source"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceDate), typeDiscriminator: "sourceDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceType), typeDiscriminator: "sourceType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(status), typeDiscriminator: "status"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationCarrier), typeDiscriminator: "telecommunicationCarrier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationIdentifier), typeDiscriminator: "telecommunicationIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(telecommunicationService), typeDiscriminator: "telecommunicationService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(text), typeDiscriminator: "text"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textOffsetBearing), typeDiscriminator: "textOffsetBearing"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textOffsetDistance), typeDiscriminator: "textOffsetDistance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textRotation), typeDiscriminator: "textRotation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textType), typeDiscriminator: "textType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(thicknessOfIceCapability), typeDiscriminator: "thicknessOfIceCapability"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayEnd), typeDiscriminator: "timeOfDayEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayStart), typeDiscriminator: "timeOfDayStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyFixed), typeDiscriminator: "uncertaintyFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyVariableFactor), typeDiscriminator: "uncertaintyVariableFactor"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselPerformance), typeDiscriminator: "vesselPerformance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristics), typeDiscriminator: "vesselsCharacteristics"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristicsUnit), typeDiscriminator: "vesselsCharacteristicsUnit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselsCharacteristicsValue), typeDiscriminator: "vesselsCharacteristicsValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(actionOrActivity), typeDiscriminator: "actionOrActivity"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfMarineProtectedArea), typeDiscriminator: "categoryOfMarineProtectedArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRxN), typeDiscriminator: "categoryOfRxN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfVessel), typeDiscriminator: "categoryOfVessel"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactAddress), typeDiscriminator: "contactAddress"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(designation), typeDiscriminator: "designation"));
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalUncertainty), typeDiscriminator: "verticalUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(vesselMeasurementsSpecification), typeDiscriminator: "vesselMeasurementsSpecification"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(bearingInformation), typeDiscriminator: "bearingInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(graphic), typeDiscriminator: "graphic"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scheduleByDayOfWeek), typeDiscriminator: "scheduleByDayOfWeek"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(spatialAccuracy), typeDiscriminator: "spatialAccuracy"));
				}
			});
			jsonSerializerOptions.TypeInfoResolver = resolver;
			return jsonSerializerOptions;
		}
	}
}
