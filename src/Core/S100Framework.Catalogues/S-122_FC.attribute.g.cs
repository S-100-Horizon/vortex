using System;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100Framework.AttributeModel.S122.SimpleAttributes
{
	/// <summary>
	/// A generic term for an administrative region within a country at a level below that of the sovereign state.
	/// </summary>
	public class administrativeDivision : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(administrativeDivision);
		[JsonIgnore]
		public override string S100FC_name => "Administrative Division";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator administrativeDivision(String value) => new administrativeDivision { value = value };
	}

	/// <summary>
	/// Name of an application profile that can be used with the online resource.
	/// </summary>
	public class applicationProfile : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(applicationProfile);
		[JsonIgnore]
		public override string S100FC_name => "Application Profile";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator applicationProfile(String value) => new applicationProfile { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator callName(String value) => new callName { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator callSign(String value) => new callSign { value = value };
	}

	/// <summary>
	/// Principal and intermediate compass points.
	/// </summary>
	public class cardinalDirection : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cardinalDirection);
		[JsonIgnore]
		public override string S100FC_name => "Cardinal Direction";
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator cardinalDirection(int? value) => new cardinalDirection { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator categoryOfAuthority(int? value) => new categoryOfAuthority { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator categoryOfCargo(int? value) => new categoryOfCargo { value = value };
	}

	/// <summary>
	/// Classification of frequencies, VHF channels, telephone numbers, or other means of communication based on preference.
	/// </summary>
	public class categoryOfCommunicationPreference : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfCommunicationPreference);
		[JsonIgnore]
		public override string S100FC_name => "Category of Communication Preference";
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Preferred Calling", "The first choice channel or frequency to be used when calling a radio station.",1),
				new listedValue("Alternate Calling", "A channel or frequency to be used for calling a radio station when the preferred channel or frequency is busy or is suffering from interference.",2),
				new listedValue("Preferred Working", "The first choice channel or frequency to be used when working with a radio station.",3),
				new listedValue("Alternate Working", "A channel or frequency to be used for working with a radio station when the preferred working channel or frequency is busy or is suffering from interference.",4),
			];
		public int? value { get; set; } = default;

		public static implicit operator categoryOfCommunicationPreference(int? value) => new categoryOfCommunicationPreference { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator categoryOfDangerousOrHazardousCargo(int? value) => new categoryOfDangerousOrHazardousCargo { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Prohibited", "Use of facility, waterway or service is forbidden.",1),
				new listedValue("Not Recommended", "Use of facility, waterway or service is not recommended.",2),
				new listedValue("Permitted", "Use of facility, waterway, or service is permitted but not required.",3),
				new listedValue("Recommended", "Use of facility, waterway, or service is recommended.",4),
				new listedValue("Required", "Use of facility, waterway, or service is required.",5),
				new listedValue("Not Required", "Use of facility, waterway, or service is not required.",6),
				new listedValue("Exclusively Permitted", "Only vessels of the specified characteristics may use the facility, waterway, or service.",7),
			];
		public int? value { get; set; } = default;

		public static implicit operator categoryOfRelationship(int? value) => new categoryOfRelationship { value = value };
	}

	/// <summary>
	/// The official legal status of each kind of restricted area defines the kind of restriction(s), for example the restriction for a 'game reserve' may be 'entering prohibited'.
	/// </summary>
	public class categoryOfRestrictedArea : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfRestrictedArea);
		[JsonIgnore]
		public override string S100FC_name => "Category of Restricted Area";
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator categoryOfRestrictedArea(int? value) => new categoryOfRestrictedArea { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Normal Operation", "The service, office, is open, fully manned, and operating normally, or the area is accessible as usual.",1),
				new listedValue("Closure", "The service, office, or area is closed.",2),
				new listedValue("Unmanned Operation", "The service is available but not manned.",3),
			];
		public int? value { get; set; } = default;

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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Extreme Event", "Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.",1),
				new listedValue("Likely to Change", "Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).",4),
				new listedValue("Unlikely to Change", "Significant change to the seafloor is not expected.",5),
				new listedValue("Unassessed", "Not having been assessed.",6),
			];
		public int? value { get; set; } = default;

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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Abstract or Summary", "A statement summarizing the important points of a text.",1),
				new listedValue("Extract", "An excerpt or excerpts from a text.",2),
				new listedValue("Full Text", "The whole text.",3),
			];
		public int? value { get; set; } = default;

		public static implicit operator categoryOfText(int? value) => new categoryOfText { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Domestic", "The vessel is registered or enrolled under the same national flag as the port, harbour, territorial sea, exclusive economic zone, or administrative area in which the object that possesses this attribute applies or is located.",1),
				new listedValue("Foreign", "The vessel is registered or enrolled under a national flag different from the port, harbour, territorial sea, exclusive economic zone, or other administrative area in which the object that possesses this attribute applies or is located.",2),
			];
		public int? value { get; set; } = default;

		public static implicit operator categoryOfVesselRegistry(int? value) => new categoryOfVesselRegistry { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator cityName(String value) => new cityName { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator communicationChannel(String value) => new communicationChannel { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Greater Than", "The value of the left value is greater than that of the right.",1),
				new listedValue("Greater Than or Equal To", "The value of the left expression is greater than or equal to that of the right.",2),
				new listedValue("Less Than", "The value of the left expression is less than that of the right.",3),
				new listedValue("Less Than or Equal To", "The value of the left expression is less than or equal to that of the right.",4),
				new listedValue("Equal To", "The two values are equivalent.",5),
				new listedValue("Not Equal To", "The two values are not equivalent.",6),
			];
		public int? value { get; set; } = default;

		public static implicit operator comparisonOperator(int? value) => new comparisonOperator { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator contactInstructions(String value) => new contactInstructions { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator countryName(String value) => new countryName { value = value };
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
		[JsonIgnore]
		public override string valueType => "S100_TruncatedDate";

		public static implicit operator dateEnd(String value) => new dateEnd { value = value };
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
		[JsonIgnore]
		public override string valueType => "S100_TruncatedDate";

		public static implicit operator dateFixed(String value) => new dateFixed { value = value };
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
		[JsonIgnore]
		public override string valueType => "S100_TruncatedDate";

		public static implicit operator dateStart(String value) => new dateStart { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator dateVariable(String value) => new dateVariable { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Sunday", "The day of the week following Saturday and preceding Monday.",1),
				new listedValue("Monday", "The day of the week following Sunday and preceding Tuesday.",2),
				new listedValue("Tuesday", "The day of the week following Monday and preceding Wednesday.",3),
				new listedValue("Wednesday", "The day of the week following Tuesday and preceding Thursday.",4),
				new listedValue("Thursday", "The day of the week following Wednesday and preceding Friday.",5),
				new listedValue("Friday", "The day of the week following Thursday and preceding Saturday.",6),
				new listedValue("Saturday", "The day of the week following Friday and preceding Sunday.",7),
			];
		public int? value { get; set; } = default;

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
		[JsonIgnore]
		public override string valueType => "boolean";

		public static implicit operator dayOfWeekIsRange(Boolean value) => new dayOfWeekIsRange { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator deliveryPoint(String value) => new deliveryPoint { value = value };
	}

	/// <summary>
	/// An identifier which is an instance of a particular, named scheme
	/// </summary>
	public class designationIdentifier : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(designationIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Designation Identifier";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator designationIdentifier(String value) => new designationIdentifier { value = value };
	}

	/// <summary>
	/// An official name, title or description. This can be an identifier itself, or an identifier which is an instance of a named designation scheme.
	/// </summary>
	public class designationScheme : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(designationScheme);
		[JsonIgnore]
		public override string S100FC_name => "Designation Scheme";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator designationScheme(String value) => new designationScheme { value = value };
	}

	/// <summary>
	/// The place or general direction to which a vessel is going or directed.
	/// </summary>
	public class destination : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(destination);
		[JsonIgnore]
		public override string S100FC_name => "Destination";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator destination(String value) => new destination { value = value };
	}

	/// <summary>
	/// A numeric measure of the spatial separation between two locations.
	/// </summary>
	public class distance : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(distance);
		[JsonIgnore]
		public override string S100FC_name => "Distance";
		[JsonIgnore]
		public override string valueType => "real";

		public static implicit operator distance(double value) => new distance { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator fileLocator(String value) => new fileLocator { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator fileReference(String value) => new fileReference { value = value };
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
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator frequencyShoreStationReceives(int value) => new frequencyShoreStationReceives { value = value };
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
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator frequencyShoreStationTransmits(int value) => new frequencyShoreStationTransmits { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator headline(String value) => new headline { value = value };
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
		[JsonIgnore]
		public override string valueType => "real";

		public static implicit operator horizontalDistanceUncertainty(double value) => new horizontalDistanceUncertainty { value = value };
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
		[JsonIgnore]
		public override string valueType => "boolean";

		public static implicit operator inBallast(Boolean value) => new inBallast { value = value };
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
		[JsonIgnore]
		public override string valueType => "URN";

		public static implicit operator interoperabilityIdentifier(String value) => new interoperabilityIdentifier { value = value };
	}

	/// <summary>
	/// The jurisdiction applicable to an administrative area.
	/// </summary>
	public class jurisdiction : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(jurisdiction);
		[JsonIgnore]
		public override string S100FC_name => "Jurisdiction";
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("International", "Involving more than one country; covering more than one national area.",1),
				new listedValue("National", "An area administered or controlled by a single nation.",2),
				new listedValue("National Sub-Division", "An area smaller than the nation in which it lies.",3),
			];
		public int? value { get; set; } = default;

		public static implicit operator jurisdiction(int? value) => new jurisdiction { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator language(String value) => new language { value = value };
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
		[JsonIgnore]
		public override string valueType => "URI";

		public static implicit operator linkage(String value) => new linkage { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Logical Conjunction", "All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.",1),
				new listedValue("Logical Disjunction", "At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.",2),
			];
		public int? value { get; set; } = default;

		public static implicit operator logicalConnectives(int? value) => new logicalConnectives { value = value };
	}

	/// <summary>
	/// The largest intended viewing scale for the data.
	/// </summary>
	public class maximumDisplayScale : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(maximumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Maximum Display Scale";
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator maximumDisplayScale(int value) => new maximumDisplayScale { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Included", "Vessels with these characteristics are included in the regulation/restriction/recommendation/nautical information.",1),
				new listedValue("Excluded", "Vessels with these characteristics are excluded from the regulation/restriction/recommendation/nautical information.",2),
			];
		public int? value { get; set; } = default;

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
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator minimumDisplayScale(int value) => new minimumDisplayScale { value = value };
	}

	/// <summary>
	/// The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations,coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.
	/// </summary>
	public class mMSICode : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(mMSICode);
		[JsonIgnore]
		public override string S100FC_name => "MMSI Code";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator mMSICode(String value) => new mMSICode { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator name(String value) => new name { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator nameOfResource(String value) => new nameOfResource { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Default Name Display", "The name is intended to be displayed when the end-user system is set to the default name/text display setting.",1),
				new listedValue("Alternate Name Display", "The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.",2),
				new listedValue("No Chart Display", "The name or text is not intended to be displayed.",3),
			];
		public int? value { get; set; } = default;

		public static implicit operator nameUsage(int? value) => new nameUsage { value = value };
	}

	/// <summary>
	/// Code for function performed by the online resource (ISO 19115)
	/// </summary>
	public class onlineFunction : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(onlineFunction);
		[JsonIgnore]
		public override string S100FC_name => "Online Function";
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator onlineFunction(int? value) => new onlineFunction { value = value };
	}

	/// <summary>
	/// Detailed text description of what the online resource is/does (ISO 19115)
	/// </summary>
	public class onlineResourceDescription : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(onlineResourceDescription);
		[JsonIgnore]
		public override string S100FC_name => "Online Resource Description";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator onlineResourceDescription(String value) => new onlineResourceDescription { value = value };
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
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator optimumDisplayScale(int value) => new optimumDisplayScale { value = value };
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
		[JsonIgnore]
		public override string valueType => "real";

		public static implicit operator orientationUncertainty(double value) => new orientationUncertainty { value = value };
	}

	/// <summary>
	/// The angular distance measured from true north to the major axis of the feature.
	/// </summary>
	public class orientationValue : S100Framework.AttributeModel.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(orientationValue);
		[JsonIgnore]
		public override string S100FC_name => "Orientation Value";
		[JsonIgnore]
		public override string valueType => "real";

		public static implicit operator orientationValue(double value) => new orientationValue { value = value };
	}

	/// <summary>
	/// Indicates whether a pictorial representation of the feature is available.
	/// </summary>
	public class pictorialRepresentation : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(pictorialRepresentation);
		[JsonIgnore]
		public override string S100FC_name => "Pictorial Representation";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator pictorialRepresentation(String value) => new pictorialRepresentation { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator pictureCaption(String value) => new pictureCaption { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator pictureInformation(String value) => new pictureInformation { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator postalCode(String value) => new postalCode { value = value };
	}

	/// <summary>
	/// Connection protocol to be used. Example: ftp, http get KVP, http POST, etc.
	/// </summary>
	public class protocol : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(protocol);
		[JsonIgnore]
		public override string S100FC_name => "Protocol";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator protocol(String value) => new protocol { value = value };
	}

	/// <summary>
	/// Request used to access the resource. Structure and content depend on the protocol and standard used by the online resource, such as Web Feature Service standard.
	/// </summary>
	public class protocolRequest : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(protocolRequest);
		[JsonIgnore]
		public override string S100FC_name => "Protocol Request";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator protocolRequest(String value) => new protocolRequest { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator qualityOfHorizontalMeasurement(int? value) => new qualityOfHorizontalMeasurement { value = value };
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
		[JsonIgnore]
		public override string valueType => "S100_TruncatedDate";

		public static implicit operator reportedDate(String value) => new reportedDate { value = value };
	}

	/// <summary>
	/// The official legal statute of each kind of restricted area.
	/// </summary>
	public class restriction : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(restriction);
		[JsonIgnore]
		public override string S100FC_name => "Restriction";
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator restriction(int? value) => new restriction { value = value };
	}

	/// <summary>
	/// The minimum scale at which the feature may be used for example for ECDIS presentation.
	/// </summary>
	public class scaleMinimum : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(scaleMinimum);
		[JsonIgnore]
		public override string S100FC_name => "Scale Minimum";
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator scaleMinimum(int value) => new scaleMinimum { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator source(String value) => new source { value = value };
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
		[JsonIgnore]
		public override string valueType => "date";

		public static implicit operator sourceDate(DateOnly value) => new sourceDate { value = value };
	}

	/// <summary>
	/// Type of the source.
	/// </summary>
	public class sourceType : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceType);
		[JsonIgnore]
		public override string S100FC_name => "Source Type";
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator sourceType(int? value) => new sourceType { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

		public static implicit operator status(int? value) => new status { value = value };
	}

	/// <summary>
	/// The name of a provider or type of carrier for a telecommunication service. This service may include land line based, shore based or satellite based radio connections.
	/// </summary>
	public class telecommunicationCarrier : S100Framework.AttributeModel.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(telecommunicationCarrier);
		[JsonIgnore]
		public override string S100FC_name => "Telecommunication Carrier";
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator telecommunicationCarrier(String value) => new telecommunicationCarrier { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator telecommunicationIdentifier(String value) => new telecommunicationIdentifier { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Voice", "The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.",1),
				new listedValue("Facsimile", "A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.",2),
				new listedValue("SMS", "Short Message Service is a form of text messaging communication on phones and mobile phones.",3),
				new listedValue("Data", "A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.",4),
				new listedValue("Streamed Data", "Data that is constantly received by and presented to an end-user while being delivered by a provider.",5),
				new listedValue("Telex", "A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).",6),
				new listedValue("Telegraph", "An apparatus, system or process for communication at a distance by electric transmission over wire.",7),
				new listedValue("Email", "Messages and other data exchanged between individuals using computers in a network.",8),
			];
		public int? value { get; set; } = default;

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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator text(String value) => new text { value = value };
	}

	/// <summary>
	/// The angular distance measured from true north that text associated with a feature is positioned from the feature in an end-user system.
	/// </summary>
	public class textOffsetBearing : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textOffsetBearing);
		[JsonIgnore]
		public override string S100FC_name => "Text Offset Bearing";
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator textOffsetBearing(int value) => new textOffsetBearing { value = value };
	}

	/// <summary>
	/// The distance that text associated with a feature is positioned from the feature in an end-user system.
	/// </summary>
	public class textOffsetDistance : S100Framework.AttributeModel.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textOffsetDistance);
		[JsonIgnore]
		public override string S100FC_name => "Text Offset Distance";
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator textOffsetDistance(int value) => new textOffsetDistance { value = value };
	}

	/// <summary>
	/// A statement that expresses if text associated with a feature is to be rotated in the ECDIS display or not.
	/// </summary>
	public class textRotation : S100Framework.AttributeModel.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textRotation);
		[JsonIgnore]
		public override string S100FC_name => "Text Rotation";
		[JsonIgnore]
		public override string valueType => "boolean";

		public static implicit operator textRotation(Boolean value) => new textRotation { value = value };
	}

	/// <summary>
	/// The attribute from which a text string is derived.
	/// </summary>
	public class textType : S100Framework.AttributeModel.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textType);
		[JsonIgnore]
		public override string S100FC_name => "Text Type";
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Name", "The individual name of a feature.",1),
			];
		public int? value { get; set; } = default;

		public static implicit operator textType(int? value) => new textType { value = value };
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
		[JsonIgnore]
		public override string valueType => "integer";

		public static implicit operator thicknessOfIceCapability(int value) => new thicknessOfIceCapability { value = value };
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
		[JsonIgnore]
		public override string valueType => "time";

		public static implicit operator timeOfDayEnd(S100Framework.DomainModel.S100.Time value) => new timeOfDayEnd { value = value };
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
		[JsonIgnore]
		public override string valueType => "time";

		public static implicit operator timeOfDayStart(S100Framework.DomainModel.S100.Time value) => new timeOfDayStart { value = value };
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
		[JsonIgnore]
		public override string valueType => "real";

		public static implicit operator uncertaintyFixed(double value) => new uncertaintyFixed { value = value };
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
		[JsonIgnore]
		public override string valueType => "real";

		public static implicit operator uncertaintyVariableFactor(double value) => new uncertaintyVariableFactor { value = value };
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
		[JsonIgnore]
		public override string valueType => "text";

		public static implicit operator vesselPerformance(String value) => new vesselPerformance { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;

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
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("Metres", "The basic unit of length in the International System of Units (SI) system.",1),
				new listedValue("Metric Ton", "The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6.",3),
				new listedValue("Ton", "Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m) of salt water with a density of 64 lb/ft (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).",4),
				new listedValue("Short Ton", "A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).",5),
				new listedValue("Gross Ton", "Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.",6),
				new listedValue("Net Ton", "Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessels earning space and is a function of the moulded volume of all cargo spaces of the ship.",7),
				new listedValue("Suez Canal Net Tonnage", "The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.",9),
			];
		public int? value { get; set; } = default;

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
		[JsonIgnore]
		public override string valueType => "real";

		public static implicit operator vesselsCharacteristicsValue(double value) => new vesselsCharacteristicsValue { value = value };
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;
	}

	/// <summary>
	/// Classification of marine protected areas based on IUCN (International Union for Conservation of Nature and Natural Resources) categories.
	/// </summary>
	public class categoryOfMarineProtectedArea : S100Framework.AttributeModel.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfMarineProtectedArea);
		[JsonIgnore]
		public override string S100FC_name => "Category of Marine Protected Area";
		[JsonIgnore]
		public override listedValue[] listedValues => [
				new listedValue("IUCN Category Ia", "Strict Nature Reserve: Protected area managed mainly for science.",1),
				new listedValue("IUCN Category Ib", "Wilderness Area: Protected area managed mainly for wilderness protection.",2),
				new listedValue("IUCN Category II", "National Park: Protected area managed mainly for ecosystem protection and recreation.",3),
				new listedValue("IUCN Category III", "Natural Monument: Protected area managed mainly for conservation of specific natural features.",4),
				new listedValue("IUCN Category IV", "Habitat/Species Management Area: Protected area managed mainly for conservation through management intervention.",5),
				new listedValue("IUCN Category V", "Protected Landscape/Seascape: Protected area managed mainly for landscape/seascape conservation and recreation.",6),
				new listedValue("IUCN Category VI", "Managed Resource Protected Area: Protected area managed mainly for the sustainable use of natural ecosystems.",7),
			];
		public int? value { get; set; } = default;
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;
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
		[JsonIgnore]
		public override listedValue[] listedValues => [
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
		public int? value { get; set; } = default;
	}

}

namespace S100Framework.AttributeModel.S122.ComplexAttributes
{
	using S100Framework.AttributeModel.S122.SimpleAttributes;

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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(deliveryPoint),
					lower = 0,
					upper = 1,
					CreateInstance = () => new deliveryPoint(),
				},
				new AttributeBinding {
					attribute = nameof(cityName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new cityName(),
				},
				new AttributeBinding {
					attribute = nameof(administrativeDivision),
					lower = 0,
					upper = 1,
					CreateInstance = () => new administrativeDivision(),
				},
				new AttributeBinding {
					attribute = nameof(countryName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new countryName(),
				},
				new AttributeBinding {
					attribute = nameof(postalCode),
					lower = 0,
					upper = 1,
					CreateInstance = () => new postalCode(),
				},
			];

		#region Optional Attributes
		public String? deliveryPoint { set { base.AddAttributeValue(new deliveryPoint { value = value }); } }
		public String? cityName { set { base.AddAttributeValue(new cityName { value = value }); } }
		public String? administrativeDivision { set { base.AddAttributeValue(new administrativeDivision { value = value }); } }
		public String? countryName { set { base.AddAttributeValue(new countryName { value = value }); } }
		public String? postalCode { set { base.AddAttributeValue(new postalCode { value = value }); } }
		#endregion
	}

	/// <summary>
	/// An official name, title or description. This can be an identifier or an identifier which is an instance of a named designation scheme.
	/// </summary>
	public class designation : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(designation);
		[JsonIgnore]
		public override string S100FC_name => "Designation";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(designationScheme),
					lower = 0,
					upper = 1,
					CreateInstance = () => new designationScheme(),
				},
				new AttributeBinding {
					attribute = nameof(designationIdentifier),
					lower = 0,
					upper = 1,
					CreateInstance = () => new designationIdentifier(),
				},
				new AttributeBinding {
					attribute = nameof(jurisdiction),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new jurisdiction(),
				},
				new AttributeBinding {
					attribute = nameof(text),
					lower = 0,
					upper = 1,
					CreateInstance = () => new text(),
				},
			];

		#region Optional Attributes
		public String? designationScheme { set { base.AddAttributeValue(new designationScheme { value = value }); } }
		public String? designationIdentifier { set { base.AddAttributeValue(new designationIdentifier { value = value }); } }
		public int? jurisdiction { set { base.AddAttributeValue(new jurisdiction { value = value }); } }
		public String? text { set { base.AddAttributeValue(new text { value = value }); } }
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
		public language language { get; init; } = new language();
		public name name { get; init; } = new name();
		[JsonIgnore]
		public override Attribute[] attributes => [
				language,
				name,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(language),
					lower = 1,
					upper = 1,
					CreateInstance = () => new language(),
				},
				new AttributeBinding {
					attribute = nameof(name),
					lower = 1,
					upper = 1,
					CreateInstance = () => new name(),
				},
				new AttributeBinding {
					attribute = nameof(nameUsage),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new nameUsage(),
				},
			];

		#region Optional Attributes
		public int? nameUsage { set { base.AddAttributeValue(new nameUsage { value = value }); } }
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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(dateStart),
					lower = 0,
					upper = 1,
					CreateInstance = () => new dateStart(),
				},
				new AttributeBinding {
					attribute = nameof(dateEnd),
					lower = 0,
					upper = 1,
					CreateInstance = () => new dateEnd(),
				},
			];

		#region Optional Attributes
		public String? dateStart { set { base.AddAttributeValue(new dateStart { value = value }); } }
		public String? dateEnd { set { base.AddAttributeValue(new dateEnd { value = value }); } }
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
		public frequencyShoreStationTransmits frequencyShoreStationTransmits { get; init; } = new frequencyShoreStationTransmits();
		[JsonIgnore]
		public override Attribute[] attributes => [
				frequencyShoreStationTransmits,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(frequencyShoreStationReceives),
					lower = 0,
					upper = 1,
					CreateInstance = () => new frequencyShoreStationReceives(),
				},
				new AttributeBinding {
					attribute = nameof(frequencyShoreStationTransmits),
					lower = 1,
					upper = 1,
					CreateInstance = () => new frequencyShoreStationTransmits(),
				},
			];

		#region Optional Attributes
		public int? frequencyShoreStationReceives { set { base.AddAttributeValue(new frequencyShoreStationReceives { value = value }); } }
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
		public uncertaintyFixed uncertaintyFixed { get; init; } = new uncertaintyFixed();
		[JsonIgnore]
		public override Attribute[] attributes => [
				uncertaintyFixed,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(uncertaintyFixed),
					lower = 1,
					upper = 1,
					CreateInstance = () => new uncertaintyFixed(),
				},
				new AttributeBinding {
					attribute = nameof(uncertaintyVariableFactor),
					lower = 0,
					upper = 1,
					CreateInstance = () => new uncertaintyVariableFactor(),
				},
			];

		#region Optional Attributes
		public double? uncertaintyVariableFactor { set { base.AddAttributeValue(new uncertaintyVariableFactor { value = value }); } }
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
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(fileLocator),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fileLocator(),
				},
				new AttributeBinding {
					attribute = nameof(fileReference),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fileReference(),
				},
				new AttributeBinding {
					attribute = nameof(headline),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new headline(),
				},
				new AttributeBinding {
					attribute = nameof(language),
					lower = 0,
					upper = 1,
					CreateInstance = () => new language(),
				},
				new AttributeBinding {
					attribute = nameof(text),
					lower = 0,
					upper = 1,
					CreateInstance = () => new text(),
				},
			];

		#region Optional Attributes
		public String? fileLocator { set { base.AddAttributeValue(new fileLocator { value = value }); } }
		public String? fileReference { set { base.AddAttributeValue(new fileReference { value = value }); } }
		public String? language { set { base.AddAttributeValue(new language { value = value }); } }
		public String? text { set { base.AddAttributeValue(new text { value = value }); } }
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
		public linkage linkage { get; init; } = new linkage();
		[JsonIgnore]
		public override Attribute[] attributes => [
				linkage,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(linkage),
					lower = 1,
					upper = 1,
					CreateInstance = () => new linkage(),
				},
				new AttributeBinding {
					attribute = nameof(protocol),
					lower = 0,
					upper = 1,
					CreateInstance = () => new protocol(),
				},
				new AttributeBinding {
					attribute = nameof(applicationProfile),
					lower = 0,
					upper = 1,
					CreateInstance = () => new applicationProfile(),
				},
				new AttributeBinding {
					attribute = nameof(nameOfResource),
					lower = 0,
					upper = 1,
					CreateInstance = () => new nameOfResource(),
				},
				new AttributeBinding {
					attribute = nameof(onlineResourceDescription),
					lower = 0,
					upper = 1,
					CreateInstance = () => new onlineResourceDescription(),
				},
				new AttributeBinding {
					attribute = nameof(protocolRequest),
					lower = 0,
					upper = 1,
					CreateInstance = () => new protocolRequest(),
				},
				new AttributeBinding {
					attribute = nameof(onlineFunction),
					lower = 0,
					upper = 1,
					permitedValues = [1,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new onlineFunction(),
				},
			];

		#region Optional Attributes
		public String? protocol { set { base.AddAttributeValue(new protocol { value = value }); } }
		public String? applicationProfile { set { base.AddAttributeValue(new applicationProfile { value = value }); } }
		public String? nameOfResource { set { base.AddAttributeValue(new nameOfResource { value = value }); } }
		public String? onlineResourceDescription { set { base.AddAttributeValue(new onlineResourceDescription { value = value }); } }
		public String? protocolRequest { set { base.AddAttributeValue(new protocolRequest { value = value }); } }
		public int? onlineFunction { set { base.AddAttributeValue(new onlineFunction { value = value }); } }
		#endregion
	}

	/// <summary>
	/// (1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.
	/// </summary>
	public class orientation : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(orientation);
		[JsonIgnore]
		public override string S100FC_name => "Orientation";
		public orientationValue orientationValue { get; init; } = new orientationValue();
		[JsonIgnore]
		public override Attribute[] attributes => [
				orientationValue,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(orientationUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new orientationUncertainty(),
				},
				new AttributeBinding {
					attribute = nameof(orientationValue),
					lower = 1,
					upper = 1,
					CreateInstance = () => new orientationValue(),
				},
			];

		#region Optional Attributes
		public double? orientationUncertainty { set { base.AddAttributeValue(new orientationUncertainty { value = value }); } }
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
		public dateStart dateStart { get; init; } = new dateStart();
		public dateEnd dateEnd { get; init; } = new dateEnd();
		[JsonIgnore]
		public override Attribute[] attributes => [
				dateStart,
				dateEnd,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(dateStart),
					lower = 1,
					upper = 1,
					CreateInstance = () => new dateStart(),
				},
				new AttributeBinding {
					attribute = nameof(dateEnd),
					lower = 1,
					upper = 1,
					CreateInstance = () => new dateEnd(),
				},
			];

		#region Optional Attributes
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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfRxN),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new categoryOfRxN(),
				},
				new AttributeBinding {
					attribute = nameof(actionOrActivity),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22],
					CreateInstance = () => new actionOrActivity(),
				},
				new AttributeBinding {
					attribute = nameof(headline),
					lower = 0,
					upper = 1,
					CreateInstance = () => new headline(),
				},
			];

		#region Optional Attributes
		public int? categoryOfRxN { set { base.AddAttributeValue(new categoryOfRxN { value = value }); } }
		public int? actionOrActivity { set { base.AddAttributeValue(new actionOrActivity { value = value }); } }
		public String? headline { set { base.AddAttributeValue(new headline { value = value }); } }
		#endregion
	}

	/// <summary>
	/// Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.
	/// </summary>
	public class sourceIndication : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sourceIndication);
		[JsonIgnore]
		public override string S100FC_name => "Source Indication";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfAuthority),
					lower = 0,
					upper = 1,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new AttributeBinding {
					attribute = nameof(countryName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new countryName(),
				},
				new AttributeBinding {
					attribute = nameof(source),
					lower = 0,
					upper = 1,
					CreateInstance = () => new source(),
				},
				new AttributeBinding {
					attribute = nameof(sourceType),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,7,8,9,10,11,12,13,14],
					CreateInstance = () => new sourceType(),
				},
				new AttributeBinding {
					attribute = nameof(reportedDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new reportedDate(),
				},
				new AttributeBinding {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new featureName(),
				},
			];

		#region Optional Attributes
		public int? categoryOfAuthority { set { base.AddAttributeValue(new categoryOfAuthority { value = value }); } }
		public String? countryName { set { base.AddAttributeValue(new countryName { value = value }); } }
		public String? source { set { base.AddAttributeValue(new source { value = value }); } }
		public int? sourceType { set { base.AddAttributeValue(new sourceType { value = value }); } }
		public String? reportedDate { set { base.AddAttributeValue(new reportedDate { value = value }); } }
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
		public dateEnd dateEnd { get; init; } = new dateEnd();
		[JsonIgnore]
		public override Attribute[] attributes => [
				dateEnd,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(dateStart),
					lower = 0,
					upper = 1,
					CreateInstance = () => new dateStart(),
				},
				new AttributeBinding {
					attribute = nameof(dateEnd),
					lower = 1,
					upper = 1,
					CreateInstance = () => new dateEnd(),
				},
			];

		#region Optional Attributes
		public String? dateStart { set { base.AddAttributeValue(new dateStart { value = value }); } }
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
		public telecommunicationIdentifier telecommunicationIdentifier { get; init; } = new telecommunicationIdentifier();
		[JsonIgnore]
		public override Attribute[] attributes => [
				telecommunicationIdentifier,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfCommunicationPreference),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfCommunicationPreference(),
				},
				new AttributeBinding {
					attribute = nameof(telecommunicationIdentifier),
					lower = 1,
					upper = 1,
					CreateInstance = () => new telecommunicationIdentifier(),
				},
				new AttributeBinding {
					attribute = nameof(telecommunicationCarrier),
					lower = 0,
					upper = 1,
					CreateInstance = () => new telecommunicationCarrier(),
				},
				new AttributeBinding {
					attribute = nameof(contactInstructions),
					lower = 0,
					upper = 1,
					CreateInstance = () => new contactInstructions(),
				},
				new AttributeBinding {
					attribute = nameof(telecommunicationService),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new telecommunicationService(),
				},
			];

		#region Optional Attributes
		public int? categoryOfCommunicationPreference { set { base.AddAttributeValue(new categoryOfCommunicationPreference { value = value }); } }
		public String? telecommunicationCarrier { set { base.AddAttributeValue(new telecommunicationCarrier { value = value }); } }
		public String? contactInstructions { set { base.AddAttributeValue(new contactInstructions { value = value }); } }
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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfText),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfText(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new AttributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 1,
					CreateInstance = () => new onlineResource(),
				},
				new AttributeBinding {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new sourceIndication(),
				},
			];

		#region Optional Attributes
		public int? categoryOfText { set { base.AddAttributeValue(new categoryOfText { value = value }); } }
		public onlineResource? onlineResource { set { base.AddAttributeValue(value); } }
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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(dayOfWeek),
					lower = 0,
					upper = 7,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new dayOfWeek(),
				},
				new AttributeBinding {
					attribute = nameof(dayOfWeekIsRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new dayOfWeekIsRange(),
				},
				new AttributeBinding {
					attribute = nameof(timeOfDayStart),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new timeOfDayStart(),
				},
				new AttributeBinding {
					attribute = nameof(timeOfDayEnd),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new timeOfDayEnd(),
				},
			];

		#region Optional Attributes
		public Boolean? dayOfWeekIsRange { set { base.AddAttributeValue(new dayOfWeekIsRange { value = value }); } }
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
		public uncertaintyFixed uncertaintyFixed { get; init; } = new uncertaintyFixed();
		[JsonIgnore]
		public override Attribute[] attributes => [
				uncertaintyFixed,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(uncertaintyFixed),
					lower = 1,
					upper = 1,
					CreateInstance = () => new uncertaintyFixed(),
				},
				new AttributeBinding {
					attribute = nameof(uncertaintyVariableFactor),
					lower = 0,
					upper = 1,
					CreateInstance = () => new uncertaintyVariableFactor(),
				},
			];

		#region Optional Attributes
		public double? uncertaintyVariableFactor { set { base.AddAttributeValue(new uncertaintyVariableFactor { value = value }); } }
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
		public comparisonOperator comparisonOperator { get; init; } = new comparisonOperator();
		public vesselsCharacteristics vesselsCharacteristics { get; init; } = new vesselsCharacteristics();
		public vesselsCharacteristicsValue vesselsCharacteristicsValue { get; init; } = new vesselsCharacteristicsValue();
		public vesselsCharacteristicsUnit vesselsCharacteristicsUnit { get; init; } = new vesselsCharacteristicsUnit();
		[JsonIgnore]
		public override Attribute[] attributes => [
				comparisonOperator,
				vesselsCharacteristics,
				vesselsCharacteristicsValue,
				vesselsCharacteristicsUnit,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(comparisonOperator),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new comparisonOperator(),
				},
				new AttributeBinding {
					attribute = nameof(vesselsCharacteristics),
					lower = 1,
					upper = 1,
					permitedValues = [1,2,3,4,6,7,8,9,10,11,12,13],
					CreateInstance = () => new vesselsCharacteristics(),
				},
				new AttributeBinding {
					attribute = nameof(vesselsCharacteristicsValue),
					lower = 1,
					upper = 1,
					CreateInstance = () => new vesselsCharacteristicsValue(),
				},
				new AttributeBinding {
					attribute = nameof(vesselsCharacteristicsUnit),
					lower = 1,
					upper = 1,
					permitedValues = [1,3,4,5,6,7,9],
					CreateInstance = () => new vesselsCharacteristicsUnit(),
				},
			];

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// A bearing is the direction one object is from another object.
	/// </summary>
	public class bearingInformation : S100Framework.AttributeModel.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(bearingInformation);
		[JsonIgnore]
		public override string S100FC_name => "Bearing Information";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(cardinalDirection),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new cardinalDirection(),
				},
				new AttributeBinding {
					attribute = nameof(distance),
					lower = 0,
					upper = 1,
					CreateInstance = () => new distance(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new AttributeBinding {
					attribute = nameof(orientation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new orientation(),
				},
			];

		#region Optional Attributes
		public int? cardinalDirection { set { base.AddAttributeValue(new cardinalDirection { value = value }); } }
		public double? distance { set { base.AddAttributeValue(new distance { value = value }); } }
		public orientation? orientation { set { base.AddAttributeValue(value); } }
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
		public pictorialRepresentation pictorialRepresentation { get; init; } = new pictorialRepresentation();
		[JsonIgnore]
		public override Attribute[] attributes => [
				pictorialRepresentation,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(pictorialRepresentation),
					lower = 1,
					upper = 2147483647,
					CreateInstance = () => new pictorialRepresentation(),
				},
				new AttributeBinding {
					attribute = nameof(pictureCaption),
					lower = 0,
					upper = 1,
					CreateInstance = () => new pictureCaption(),
				},
				new AttributeBinding {
					attribute = nameof(sourceDate),
					lower = 0,
					upper = 1,
					CreateInstance = () => new sourceDate(),
				},
				new AttributeBinding {
					attribute = nameof(pictureInformation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new pictureInformation(),
				},
				new AttributeBinding {
					attribute = nameof(bearingInformation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new bearingInformation(),
				},
			];

		#region Optional Attributes
		public String? pictureCaption { set { base.AddAttributeValue(new pictureCaption { value = value }); } }
		public DateOnly? sourceDate { set { base.AddAttributeValue(new sourceDate { value = value }); } }
		public String? pictureInformation { set { base.AddAttributeValue(new pictureInformation { value = value }); } }
		public bearingInformation? bearingInformation { set { base.AddAttributeValue(value); } }
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
		public timeIntervalsByDayOfWeek timeIntervalsByDayOfWeek { get; init; } = new timeIntervalsByDayOfWeek();
		[JsonIgnore]
		public override Attribute[] attributes => [
				timeIntervalsByDayOfWeek,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfSchedule),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfSchedule(),
				},
				new AttributeBinding {
					attribute = nameof(text),
					lower = 0,
					upper = 1,
					CreateInstance = () => new text(),
				},
				new AttributeBinding {
					attribute = nameof(timeIntervalsByDayOfWeek),
					lower = 1,
					upper = 2147483647,
					CreateInstance = () => new timeIntervalsByDayOfWeek(),
				},
			];

		#region Optional Attributes
		public int? categoryOfSchedule { set { base.AddAttributeValue(new categoryOfSchedule { value = value }); } }
		public String? text { set { base.AddAttributeValue(new text { value = value }); } }
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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fixedDateRange(),
				},
				new AttributeBinding {
					attribute = nameof(horizontalPositionUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
				new AttributeBinding {
					attribute = nameof(verticalUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new verticalUncertainty(),
				},
			];

		#region Optional Attributes
		public fixedDateRange? fixedDateRange { set { base.AddAttributeValue(value); } }
		public horizontalPositionUncertainty? horizontalPositionUncertainty { set { base.AddAttributeValue(value); } }
		public verticalUncertainty? verticalUncertainty { set { base.AddAttributeValue(value); } }
		#endregion
	}

}

namespace S100Framework.AttributeModel.S122.InformationTypes
{
	using S100Framework.AttributeModel.S122.SimpleAttributes;
	using S100Framework.AttributeModel.S122.ComplexAttributes;

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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new featureName(),
				},
				new AttributeBinding {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fixedDateRange(),
				},
				new AttributeBinding {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new periodicDateRange(),
				},
				new AttributeBinding {
					attribute = nameof(graphic),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new graphic(),
				},
				new AttributeBinding {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new sourceIndication(),
				},
			];

		#region Optional Attributes
		public fixedDateRange? fixedDateRange { set { base.AddAttributeValue(value); } }
		#endregion
	}

	/// <summary>
	/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
	/// </summary>
	public class AbstractRxN : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AbstractRxN);
		[JsonIgnore]
		public override string S100FC_name => "AbstractRxN";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfAuthority),
					lower = 0,
					upper = 1,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new AttributeBinding {
					attribute = nameof(rxNCode),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new rxNCode(),
				},
				new AttributeBinding {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new textContent(),
				},
			];

		#region Optional Attributes
		public int? categoryOfAuthority { set { base.AddAttributeValue(new categoryOfAuthority { value = value }); } }
		#endregion
	}

	/// <summary>
	/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
	/// </summary>
	public class Applicability : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Applicability);
		[JsonIgnore]
		public override string S100FC_name => "Applicability";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(inBallast),
					lower = 0,
					upper = 1,
					CreateInstance = () => new inBallast(),
				},
				new AttributeBinding {
					attribute = nameof(categoryOfCargo),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8,10,11,12,13,14,15],
					CreateInstance = () => new categoryOfCargo(),
				},
				new AttributeBinding {
					attribute = nameof(categoryOfDangerousOrHazardousCargo),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21],
					CreateInstance = () => new categoryOfDangerousOrHazardousCargo(),
				},
				new AttributeBinding {
					attribute = nameof(categoryOfVessel),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17],
					CreateInstance = () => new categoryOfVessel(),
				},
				new AttributeBinding {
					attribute = nameof(categoryOfVesselRegistry),
					lower = 0,
					upper = 1,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfVesselRegistry(),
				},
				new AttributeBinding {
					attribute = nameof(logicalConnectives),
					lower = 0,
					upper = 1,
					permitedValues = [1,2],
					CreateInstance = () => new logicalConnectives(),
				},
				new AttributeBinding {
					attribute = nameof(thicknessOfIceCapability),
					lower = 0,
					upper = 1,
					CreateInstance = () => new thicknessOfIceCapability(),
				},
				new AttributeBinding {
					attribute = nameof(vesselPerformance),
					lower = 0,
					upper = 1,
					CreateInstance = () => new vesselPerformance(),
				},
				new AttributeBinding {
					attribute = nameof(destination),
					lower = 0,
					upper = 1,
					CreateInstance = () => new destination(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new AttributeBinding {
					attribute = nameof(vesselMeasurementsSpecification),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new vesselMeasurementsSpecification(),
				},
			];

		#region Optional Attributes
		public Boolean? inBallast { set { base.AddAttributeValue(new inBallast { value = value }); } }
		public int? categoryOfVessel { set { base.AddAttributeValue(new categoryOfVessel { value = value }); } }
		public int? categoryOfVesselRegistry { set { base.AddAttributeValue(new categoryOfVesselRegistry { value = value }); } }
		public int? logicalConnectives { set { base.AddAttributeValue(new logicalConnectives { value = value }); } }
		public int? thicknessOfIceCapability { set { base.AddAttributeValue(new thicknessOfIceCapability { value = value }); } }
		public String? vesselPerformance { set { base.AddAttributeValue(new vesselPerformance { value = value }); } }
		public String? destination { set { base.AddAttributeValue(new destination { value = value }); } }
		#endregion
	}

	/// <summary>
	/// A person or organisation having political or administrative power and control.
	/// </summary>
	public class Authority : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Authority);
		[JsonIgnore]
		public override string S100FC_name => "Authority";
		public categoryOfAuthority categoryOfAuthority { get; init; } = new categoryOfAuthority();
		[JsonIgnore]
		public override Attribute[] attributes => [
				categoryOfAuthority,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfAuthority),
					lower = 1,
					upper = 1,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new categoryOfAuthority(),
				},
				new AttributeBinding {
					attribute = nameof(textContent),
					lower = 0,
					upper = 1,
					CreateInstance = () => new textContent(),
				},
			];

		#region Optional Attributes
		public textContent? textContent { set { base.AddAttributeValue(value); } }
		#endregion
	}

	/// <summary>
	/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
	/// </summary>
	public class ContactDetails : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ContactDetails);
		[JsonIgnore]
		public override string S100FC_name => "Contact Details";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(callName),
					lower = 0,
					upper = 1,
					CreateInstance = () => new callName(),
				},
				new AttributeBinding {
					attribute = nameof(callSign),
					lower = 0,
					upper = 1,
					CreateInstance = () => new callSign(),
				},
				new AttributeBinding {
					attribute = nameof(categoryOfCommunicationPreference),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfCommunicationPreference(),
				},
				new AttributeBinding {
					attribute = nameof(communicationChannel),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new communicationChannel(),
				},
				new AttributeBinding {
					attribute = nameof(contactInstructions),
					lower = 0,
					upper = 1,
					CreateInstance = () => new contactInstructions(),
				},
				new AttributeBinding {
					attribute = nameof(language),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new language(),
				},
				new AttributeBinding {
					attribute = nameof(mMSICode),
					lower = 0,
					upper = 1,
					CreateInstance = () => new mMSICode(),
				},
				new AttributeBinding {
					attribute = nameof(contactAddress),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new contactAddress(),
				},
				new AttributeBinding {
					attribute = nameof(frequencyPair),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new frequencyPair(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
				new AttributeBinding {
					attribute = nameof(onlineResource),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new onlineResource(),
				},
				new AttributeBinding {
					attribute = nameof(telecommunications),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new telecommunications(),
				},
			];

		#region Optional Attributes
		public String? callName { set { base.AddAttributeValue(new callName { value = value }); } }
		public String? callSign { set { base.AddAttributeValue(new callSign { value = value }); } }
		public int? categoryOfCommunicationPreference { set { base.AddAttributeValue(new categoryOfCommunicationPreference { value = value }); } }
		public String? contactInstructions { set { base.AddAttributeValue(new contactInstructions { value = value }); } }
		public String? mMSICode { set { base.AddAttributeValue(new mMSICode { value = value }); } }
		#endregion
	}

	/// <summary>
	/// Nautical information about a related area or facility.
	/// </summary>
	public class NauticalInformation : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NauticalInformation);
		[JsonIgnore]
		public override string S100FC_name => "Nautical Information";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
			];

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
	/// </summary>
	public class NonStandardWorkingDay : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NonStandardWorkingDay);
		[JsonIgnore]
		public override string S100FC_name => "Non-Standard Working Day";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(dateFixed),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new dateFixed(),
				},
				new AttributeBinding {
					attribute = nameof(dateVariable),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new dateVariable(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
			];

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Recommendations for a related area or facility.
	/// </summary>
	public class Recommendations : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Recommendations);
		[JsonIgnore]
		public override string S100FC_name => "Recommendations";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
			];

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Regulations for a related area or facility.
	/// </summary>
	public class Regulations : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Regulations);
		[JsonIgnore]
		public override string S100FC_name => "Regulations";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
			];

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Restrictions for a related area or facility.
	/// </summary>
	public class Restrictions : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Restrictions);
		[JsonIgnore]
		public override string S100FC_name => "Restrictions";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
			];

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// The time when a service is available and known exceptions.
	/// </summary>
	public class ServiceHours : S100Framework.AttributeModel.InformationType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ServiceHours);
		[JsonIgnore]
		public override string S100FC_name => "Service Hours";
		public scheduleByDayOfWeek scheduleByDayOfWeek { get; init; } = new scheduleByDayOfWeek();
		[JsonIgnore]
		public override Attribute[] attributes => [
				scheduleByDayOfWeek,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(scheduleByDayOfWeek),
					lower = 1,
					upper = 2147483647,
					CreateInstance = () => new scheduleByDayOfWeek(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
			];

		#region Optional Attributes
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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(qualityOfHorizontalMeasurement),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new qualityOfHorizontalMeasurement(),
				},
				new AttributeBinding {
					attribute = nameof(spatialAccuracy),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new spatialAccuracy(),
				},
			];

		#region Optional Attributes
		public int? qualityOfHorizontalMeasurement { set { base.AddAttributeValue(new qualityOfHorizontalMeasurement { value = value }); } }
		#endregion
	}

}

namespace S100Framework.AttributeModel.S122.FeatureTypes
{
	using S100Framework.AttributeModel.S122.SimpleAttributes;
	using S100Framework.AttributeModel.S122.ComplexAttributes;

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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new AttributeBinding {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new featureName(),
				},
				new AttributeBinding {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new fixedDateRange(),
				},
				new AttributeBinding {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new periodicDateRange(),
				},
				new AttributeBinding {
					attribute = nameof(graphic),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new graphic(),
				},
				new AttributeBinding {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new sourceIndication(),
				},
				new AttributeBinding {
					attribute = nameof(textContent),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new textContent(),
				},
			];

		#region Optional Attributes
		public fixedDateRange? fixedDateRange { set { base.AddAttributeValue(value); } }
		#endregion
	}

	/// <summary>
	/// An area for which general information regarding navigation, but not directly related to safety of navigation, is available.
	/// </summary>
	public class InformationArea : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(InformationArea);
		[JsonIgnore]
		public override string S100FC_name => "Information Area";
		public categoryOfRelationship categoryOfRelationship { get; init; } = new categoryOfRelationship();
		public actionOrActivity actionOrActivity { get; init; } = new actionOrActivity();
		[JsonIgnore]
		public override Attribute[] attributes => [
				categoryOfRelationship,
				actionOrActivity,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfRelationship),
					lower = 1,
					upper = 1,
					permitedValues = [1,3],
					CreateInstance = () => new categoryOfRelationship(),
				},
				new AttributeBinding {
					attribute = nameof(actionOrActivity),
					lower = 1,
					upper = 1,
					permitedValues = [17],
					CreateInstance = () => new actionOrActivity(),
				},
			];

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// Any area of the intertidal or sub-tidal terrain, together with its overlying water and associated flora, fauna, historical and cultural features, which has been reserved by law or other effective means to protect part or all of the enclosed environment.
	/// </summary>
	public class MarineProtectedArea : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(MarineProtectedArea);
		[JsonIgnore]
		public override string S100FC_name => "Marine Protected Area";
		public categoryOfMarineProtectedArea categoryOfMarineProtectedArea { get; init; } = new categoryOfMarineProtectedArea();
		[JsonIgnore]
		public override Attribute[] attributes => [
				categoryOfMarineProtectedArea,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfMarineProtectedArea),
					lower = 1,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new categoryOfMarineProtectedArea(),
				},
				new AttributeBinding {
					attribute = nameof(categoryOfRestrictedArea),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,4,5,6,7,10,20,22,23,27,28,31,32,33],
					CreateInstance = () => new categoryOfRestrictedArea(),
				},
				new AttributeBinding {
					attribute = nameof(jurisdiction),
					lower = 0,
					upper = 1,
					permitedValues = [1,2,3],
					CreateInstance = () => new jurisdiction(),
				},
				new AttributeBinding {
					attribute = nameof(restriction),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,38,39,40,41,42],
					CreateInstance = () => new restriction(),
				},
				new AttributeBinding {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,9,18,28,13,14],
					CreateInstance = () => new status(),
				},
				new AttributeBinding {
					attribute = nameof(designation),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new designation(),
				},
			];

		#region Optional Attributes
		public int? jurisdiction { set { base.AddAttributeValue(new jurisdiction { value = value }); } }
		#endregion
	}

	/// <summary>
	/// A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.
	/// </summary>
	public class RestrictedArea : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RestrictedArea);
		[JsonIgnore]
		public override string S100FC_name => "Restricted Area";
		public restriction restriction { get; init; } = new restriction();
		[JsonIgnore]
		public override Attribute[] attributes => [
				restriction,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfRestrictedArea),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,4,5,6,7,10,20,22,23,27,28,31,32,33],
					CreateInstance = () => new categoryOfRestrictedArea(),
				},
				new AttributeBinding {
					attribute = nameof(restriction),
					lower = 1,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,38,39,40,41,42],
					CreateInstance = () => new restriction(),
				},
				new AttributeBinding {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					permitedValues = [1,2,3,4,5,6,7,9,18,28,13,14],
					CreateInstance = () => new status(),
				},
			];

		#region Optional Attributes
		#endregion
	}

	/// <summary>
	/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
	/// </summary>
	public class VesselTrafficServiceArea : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(VesselTrafficServiceArea);
		[JsonIgnore]
		public override string S100FC_name => "Vessel Traffic Service Area";
		[JsonIgnore]
		public override Attribute[] attributes => [
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
			];

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
		public maximumDisplayScale maximumDisplayScale { get; init; } = new maximumDisplayScale();
		public minimumDisplayScale minimumDisplayScale { get; init; } = new minimumDisplayScale();
		[JsonIgnore]
		public override Attribute[] attributes => [
				maximumDisplayScale,
				minimumDisplayScale,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(maximumDisplayScale),
					lower = 1,
					upper = 1,
					CreateInstance = () => new maximumDisplayScale(),
				},
				new AttributeBinding {
					attribute = nameof(minimumDisplayScale),
					lower = 1,
					upper = 1,
					CreateInstance = () => new minimumDisplayScale(),
				},
				new AttributeBinding {
					attribute = nameof(optimumDisplayScale),
					lower = 0,
					upper = 1,
					CreateInstance = () => new optimumDisplayScale(),
				},
				new AttributeBinding {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
			];

		#region Optional Attributes
		public int? optimumDisplayScale { set { base.AddAttributeValue(new optimumDisplayScale { value = value }); } }
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
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(categoryOfTemporalVariation),
					lower = 0,
					upper = 1,
					permitedValues = [1,4,5,6],
					CreateInstance = () => new categoryOfTemporalVariation(),
				},
				new AttributeBinding {
					attribute = nameof(horizontalDistanceUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new horizontalDistanceUncertainty(),
				},
				new AttributeBinding {
					attribute = nameof(horizontalPositionUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
				new AttributeBinding {
					attribute = nameof(orientationUncertainty),
					lower = 0,
					upper = 1,
					CreateInstance = () => new orientationUncertainty(),
				},
				new AttributeBinding {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new AttributeBinding {
					attribute = nameof(sourceIndication),
					lower = 0,
					upper = 1,
					CreateInstance = () => new sourceIndication(),
				},
				new AttributeBinding {
					attribute = nameof(surveyDateRange),
					lower = 0,
					upper = 1,
					CreateInstance = () => new surveyDateRange(),
				},
				new AttributeBinding {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					CreateInstance = () => new information(),
				},
			];

		#region Optional Attributes
		public int? categoryOfTemporalVariation { set { base.AddAttributeValue(new categoryOfTemporalVariation { value = value }); } }
		public double? horizontalDistanceUncertainty { set { base.AddAttributeValue(new horizontalDistanceUncertainty { value = value }); } }
		public horizontalPositionUncertainty? horizontalPositionUncertainty { set { base.AddAttributeValue(value); } }
		public double? orientationUncertainty { set { base.AddAttributeValue(new orientationUncertainty { value = value }); } }
		public sourceIndication? sourceIndication { set { base.AddAttributeValue(value); } }
		public surveyDateRange? surveyDateRange { set { base.AddAttributeValue(value); } }
		#endregion
	}

	/// <summary>
	/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
	/// </summary>
	public class TextPlacement : S100Framework.AttributeModel.FeatureType
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TextPlacement);
		[JsonIgnore]
		public override string S100FC_name => "Text Placement";
		public textOffsetBearing textOffsetBearing { get; init; } = new textOffsetBearing();
		public textOffsetDistance textOffsetDistance { get; init; } = new textOffsetDistance();
		public textType textType { get; init; } = new textType();
		[JsonIgnore]
		public override Attribute[] attributes => [
				textOffsetBearing,
				textOffsetDistance,
				textType,
				.. base.attributesOptional,
			];
		public override AttributeBinding[] attributeBindings() => [
				new AttributeBinding {
					attribute = nameof(textOffsetBearing),
					lower = 1,
					upper = 1,
					CreateInstance = () => new textOffsetBearing(),
				},
				new AttributeBinding {
					attribute = nameof(textOffsetDistance),
					lower = 1,
					upper = 1,
					CreateInstance = () => new textOffsetDistance(),
				},
				new AttributeBinding {
					attribute = nameof(textRotation),
					lower = 0,
					upper = 1,
					CreateInstance = () => new textRotation(),
				},
				new AttributeBinding {
					attribute = nameof(textType),
					lower = 1,
					upper = 2,
					permitedValues = [1],
					CreateInstance = () => new textType(),
				},
				new AttributeBinding {
					attribute = nameof(scaleMinimum),
					lower = 0,
					upper = 1,
					CreateInstance = () => new scaleMinimum(),
				},
			];

		#region Optional Attributes
		public Boolean? textRotation { set { base.AddAttributeValue(new textRotation { value = value }); } }
		public int? scaleMinimum { set { base.AddAttributeValue(new scaleMinimum { value = value }); } }
		#endregion
	}

}

namespace S100Framework.AttributeModel.S122
{
	using System.Text.Json;
	using S100Framework.AttributeModel.S122.SimpleAttributes;
	using S100Framework.AttributeModel.S122.ComplexAttributes;
	using S100Framework.AttributeModel.S122.FeatureTypes;

	public class Summary : ISummary
	{
		public static string Name => "Marine Protected Area";
		public static string Scope => "";
		public static string ProductId => "S-122";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-12-07", "yyyy-MM-dd");
	}

	public static class Extensions {
		public static JsonSerializerOptions AppendTypeInfoResolver(this JsonSerializerOptions jsonSerializerOptions) {
			var resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
			resolver.Modifiers.Add(typeInfo => {
				if (typeInfo.Type == typeof(S100Framework.AttributeModel.Attribute)) {
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
