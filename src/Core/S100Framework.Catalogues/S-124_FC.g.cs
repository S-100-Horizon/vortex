using System;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100FC.S124.SimpleAttributes
{
	/// <summary>
	/// Identifier from a list of Aids to Navigation publication, such as List of Lights.
	/// </summary>
	public class atoNNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(atoNNumber);
		[JsonIgnore]
		public override string S100FC_name => "AtoN Number";

		public static implicit operator atoNNumber(String? value) => new atoNNumber { value = value };
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
			];

		public static implicit operator nameUsage(int? value) => new nameUsage { value = value };
	}

	/// <summary>
	/// A period of one revolution of the earth around the sun.
	/// </summary>
	public class year : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(year);
		[JsonIgnore]
		public override string S100FC_name => "Year";

		public static implicit operator year(int? value) => new year { value = value };
	}

	/// <summary>
	/// The scope of the MSI warning - NAVAREA, sub-area, etc.
	/// </summary>
	public class warningType : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(warningType);
		[JsonIgnore]
		public override string S100FC_name => "Warning Type";
		public static listedValue[] listedValues => [
				new listedValue("Local Navigational Warning", "Message containing urgent information relevant to safe navigation broadcast to ships in a local area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended.(Adopted from S-53, 2.2.23)" +
										"Local warning means a navigational warning which covers inshore waters, often within the limits of jurisdiction of a harbour or port authority. (Adopted from S-53, 2.2.10)",1),
				new listedValue("Coastal Navigational Warning", "Message containing urgent information relevant to safe navigation broadcast to ships in a coastal  area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended." +
										"Coastal warning means a navigational warning promulgated as part of a numbered series by a National Coordinator.",2),
				new listedValue("Sub-Area Navigational Warning", "Message containing urgent information relevant to safe navigation broadcast to ships in a sub-area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended." +
										"Sub-area warning means a navigational warning or in-force bulletin promulgated as part of a numbered series by a Sub-area Coordinator.",3),
				new listedValue("NAVAREA Navigational Warning", "Message containing urgent information relevant to safe navigation broadcast to ships in a NAVAREA, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended." +
										"NAVAREA warning means a navigational warning promulgated as part of a numbered series by a NAVAREA Coordinator.",4),
				new listedValue("NAVAREA No Warning", "A message that indicates that there are no navigational warnings to be disseminated in the NAVAREA.",5),
				new listedValue("Sub-Area No Warning", "A message that indicates that there are no navigational warnings to be disseminated in the sub-area.",6),
				new listedValue("Coastal No Warning", "A message that indicates that there are no navigational warnings to be disseminated in the coastal area.",7),
				new listedValue("Local No Warning", "A message that indicates that there are no navigational warnings to be disseminated in the local area.",8),
				new listedValue("NAVAREA In-Force Bulletin", "A list of serial numbers of NAVAREA warnings which are in- force.",9),
				new listedValue("Sub-Area In-Force Bulletin", "A list of serial numbers of sub-area warnings which are in-force.",10),
				new listedValue("Coastal In-Force Bulletin", "A list of serial numbers of coastal warnings which are in- force.",11),
				new listedValue("Local In-Force Bulletin", "A list of serial numbers of local warnings which are in- force.",12),
			];

		public static implicit operator warningType(int? value) => new warningType { value = value };
	}

	/// <summary>
	/// The consecutive number re-starts each calendar year at 1 (Leading zeros are not mandatory).
	/// </summary>
	public class warningNumber : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(warningNumber);
		[JsonIgnore]
		public override string S100FC_name => "Warning Number";

		public static implicit operator warningNumber(int? value) => new warningNumber { value = value };
	}

	/// <summary>
	/// The NAVAREA or METAREA. Example: NAVAREA IV. Distinction: generalArea, locality
	/// </summary>
	public class nameOfSeries : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(nameOfSeries);
		[JsonIgnore]
		public override string S100FC_name => "Name of Series";

		public static implicit operator nameOfSeries(String? value) => new nameOfSeries { value = value };
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
	/// Identifies the agency which produced the data.
	/// </summary>
	public class agencyResponsibleForProduction : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(agencyResponsibleForProduction);
		[JsonIgnore]
		public override string S100FC_name => "Agency Responsible for Production";

		public static implicit operator agencyResponsibleForProduction(String? value) => new agencyResponsibleForProduction { value = value };
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
	/// Globally unique identifier for the area or locality in the MRN format.
	/// </summary>
	public class localityIdentifier : S100FC.UrnTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(localityIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Locality Identifier";

		public static implicit operator localityIdentifier(String? value) => new localityIdentifier { value = value };
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
	/// Date of the last notice to mariner, such as was applied to a chart or publication.
	/// </summary>
	public class lastNoticeDate : S100FC.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(lastNoticeDate);
		[JsonIgnore]
		public override string S100FC_name => "Last Notice Date";

		public static implicit operator lastNoticeDate(DateOnly? value) => new lastNoticeDate { value = value };
	}

	/// <summary>
	/// Date of publishing for example of a publication, chart, or product.
	/// </summary>
	public class editionDate : S100FC.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(editionDate);
		[JsonIgnore]
		public override string S100FC_name => "Edition Date";

		public static implicit operator editionDate(DateOnly? value) => new editionDate { value = value };
	}

	/// <summary>
	/// Plan number when a chart has more than one panel.
	/// </summary>
	public class chartPlanNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(chartPlanNumber);
		[JsonIgnore]
		public override string S100FC_name => "Chart Plan Number";

		public static implicit operator chartPlanNumber(String? value) => new chartPlanNumber { value = value };
	}

	/// <summary>
	/// Chart number. Note, can be either paper chart number or ENC file name.
	/// </summary>
	public class chartNumber : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(chartNumber);
		[JsonIgnore]
		public override string S100FC_name => "Chart Number";

		public static implicit operator chartNumber(String? value) => new chartNumber { value = value };
	}

	/// <summary>
	/// Name of affected publication.
	/// </summary>
	public class publicationAffected : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(publicationAffected);
		[JsonIgnore]
		public override string S100FC_name => "Publication Affected";

		public static implicit operator publicationAffected(String? value) => new publicationAffected { value = value };
	}

	/// <summary>
	/// International paper chart number. (Not used if chartAffected carry an ENC name).
	/// </summary>
	public class internationalChartAffected : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(internationalChartAffected);
		[JsonIgnore]
		public override string S100FC_name => "International Chart Affected";

		public static implicit operator internationalChartAffected(String? value) => new internationalChartAffected { value = value };
	}

	/// <summary>
	/// Identifier for the chart or publication (using the MRN format).
	/// </summary>
	public class chartPublicationIdentifier : S100FC.UrnTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(chartPublicationIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Chart Publication Identifier";

		public static implicit operator chartPublicationIdentifier(String? value) => new chartPublicationIdentifier { value = value };
	}

	/// <summary>
	/// An indication of an international service, true = yes, false = no.
	/// </summary>
	public class intService : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(intService);
		[JsonIgnore]
		public override string S100FC_name => "Int Service";

		public static implicit operator intService(Boolean? value) => new intService { value = value };
	}

	/// <summary>
	/// Date and time of cancelling a notice or warning.
	/// </summary>
	public class cancellationDate : S100FC.DateTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(cancellationDate);
		[JsonIgnore]
		public override string S100FC_name => "Cancellation Date";

		public static implicit operator cancellationDate(DateTime? value) => new cancellationDate { value = value };
	}

	/// <summary>
	/// Category of reference.
	/// </summary>
	public class referenceCategory : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(referenceCategory);
		[JsonIgnore]
		public override string S100FC_name => "Reference Category";
		public static listedValue[] listedValues => [
				new listedValue("Warning Cancellation", "Cancellation of warning which is no longer valid.",1),
				new listedValue("Warning Reference", "Reference to relevant warning.",2),
				new listedValue("In-Force", "Reference to warnings or notices that are considered in-force.",3),
			];

		public static implicit operator referenceCategory(int? value) => new referenceCategory { value = value };
	}

	/// <summary>
	/// An indication of no active message.
	/// </summary>
	public class noMessageOnHand : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(noMessageOnHand);
		[JsonIgnore]
		public override string S100FC_name => "No Message On Hand";

		public static implicit operator noMessageOnHand(Boolean? value) => new noMessageOnHand { value = value };
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
	/// The official legal statute of each kind of restricted area.
	/// </summary>
	public class restriction : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(restriction);
		[JsonIgnore]
		public override string S100FC_name => "Restriction";
		public static listedValue[] listedValues => [
				new listedValue("Entry Prohibited", "[1] An area shown on charts within which navigation and/or anchoring is prohibited. [2] In aviation terminology, a specified area within the land areas of a state or territorial waters adjacent thereto over which the flight of aircraft is prohibi­ted.",7),
				new listedValue("Entry Restricted", "A specified area designated by appropriate authority, within which navigation is restricted in accordance with certain specified conditions.",8),
				new listedValue("Area To Be Avoided", "An IMO declared routeing measure comprising an area within defined limits in which either navigation is particularly hazardous or it is exceptionally important to avoid casualties and which should be avoided by all ships, or certain classes of ships.",14),
				new listedValue("Stopping Prohibited", "An area in which a vessel is prohibited from stopping.",25),
				new listedValue("Speed Restricted", "An area within which speed is restricted.",27),
			];

		public static implicit operator restriction(int? value) => new restriction { value = value };
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
	/// Date and time of publication of the notice or warning.
	/// </summary>
	public class publicationTime : S100FC.DateTimeAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(publicationTime);
		[JsonIgnore]
		public override string S100FC_name => "Publication Time";

		public static implicit operator publicationTime(DateTime? value) => new publicationTime { value = value };
	}

	/// <summary>
	/// Detailed type of a warning or hazard.
	/// </summary>
	public class navwarnTypeDetails : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(navwarnTypeDetails);
		[JsonIgnore]
		public override string S100FC_name => "Navwarn Type Details";
		public static listedValue[] listedValues => [
				new listedValue("Acoustic Recorder", "The temporary or permanent installation of an acoustical instrument in the marine environment for the purpose of tracking the behavior of marine mammals or to monitor their ecosystems.",1),
				new listedValue("AIS Temporary Establishment", "A new AIS has been or will be established for a limited period of time.",2),
				new listedValue("AIS Transmitter Establishment", "A new AIS site has been or will be established.",3),
				new listedValue("AIS Transmitter Operating Properly", "The terrestrial AIS transmitter is operating as advertised.",4),
				new listedValue("AIS Transmitter Out Of Service", "The terrestrial AIS transmitter is inoperative due to a technical issue.",5),
				new listedValue("AIS Transmitter Removal", "AIS transmitter has been or will be permanently removed from service.",6),
				new listedValue("AIS Transmitter Temporary Removal", "AIS transmitter has been or will be temporarily removed from service.",7),
				new listedValue("AIS Transmitter Unreliable", "The terrestrial AIS transmitter is unreliable due to a technical issue or maintenance.",8),
				new listedValue("All Aids To Navigation Unreliable", "All aids to navigation on a structure or in an area are unreliable due to environmental impact, equipment failure, etc.",9),
				new listedValue("Anti Pollution Exercise", "A large scale activity where multiple vessels, surveillance aircraft, and shore-based personnel practice a response to the discharge of a pollutant from a ship (or shore) into the marine environment, in order to evaluate the effectiveness of response capability.",10),
				new listedValue("Anti Pollution Operation", "A real time response by vessels, surveillance aircraft, and shore-based personnel to resolve the discharge of a pollutant from a ship (or shore) into the marine environment.",11),
				new listedValue("Aquaculture Site", "The installation of infrastructure at a new location where the farming of fish, shellfish and aquatic plants in fresh or salt water is undertaken; and, failures at these locations where the infrastructure is reported damaged and may be adrift.",12),
				new listedValue("AtoN Operating Properly", "The outage/failure has been corrected and the aids to navigation has resumed normal operation.",13),
				new listedValue("Audible Signal Change", "The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be changed.",14),
				new listedValue("Audible Signal Establishment", "A new audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be established.",15),
				new listedValue("Audible Signal Operating Properly", "The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is operating as advertised.",16),
				new listedValue("Audible Signal Out Of Service", "The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is inoperative.",17),
				new listedValue("Audible Signal Removal", "Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be permanently removed from service.",18),
				new listedValue("Audible Signal Temporary Change", "The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be temporarily changed.",19),
				new listedValue("Audible Signal Temporary Establishment", "A new audible signal has been or will be established for a limited period of time.",20),
				new listedValue("Audible Signal Temporary Removal", "Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be temporarily removed from service.",21),
				new listedValue("Authorized Ice Routeing Information", "Ice routeing information provided by a recognized authority.",22),
				new listedValue("Beacon Change", "The characteristics of the beacon have been or will be changed.",23),
				new listedValue("Beacon Damaged", "The beacon has sustained damage due to external factors (wind, sea state, collision with a vessel).",24),
				new listedValue("Beacon Daymark Unreliable", "Colour of the beacon daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",25),
				new listedValue("Beacon Establishment", "A new beacon has been or will be established.",26),
				new listedValue("Beacon Missing", "No beacon at the advertised position.",27),
				new listedValue("Beacon Removal", "Beacon has been or will be permanently removed from service.",28),
				new listedValue("Beacon Restored To Normal", "The beacon has been restored to normal condition.",29),
				new listedValue("Beacon Temporary Change", "The characteristics of the beacon have been or will be temporarily changed.",30),
				new listedValue("Beacon Temporary Establishment", "A new beacon has been or will be established for a limited period of time.",31),
				new listedValue("Beacon Temporary Removal", "Beacon has been or will be temporarily removed from service.",32),
				new listedValue("Beacon Topmark Damaged", "The topmark of the beacon is damaged due to external factors (wind, sea state, collision with a vessel).",33),
				new listedValue("Beacon Topmark Missing", "The topmark of the beacon is missing.",34),
				new listedValue("Blasting Operation", "An explosive detonation was observed at sea or blasting operation is scheduled to occur.",35),
				new listedValue("Breakwater Construction", "The construction of a structure protecting a shore area, harbour, or anchorage from waves.",36),
				new listedValue("Bridge Horizontal Clearance Change", "The published horizontal clearance of the fixed or opening bridge has changed.",37),
				new listedValue("Bridge Unable To Close", "The functionality of an opening bridge is compromised. The bridge will remain open.",38),
				new listedValue("Bridge Unable To Open", "The functionality of an opening bridge is compromised. The bridge will remain closed.",39),
				new listedValue("Bridge Vertical Clearance Change", "The published vertical clearance of the fixed or opening bridge has changed.",40),
				new listedValue("Buoy Adrift", "The buoy is no longer secured to its moorings and is adrift.",41),
				new listedValue("Buoy Change", "The characteristics of the buoy have been or will be changed.",42),
				new listedValue("Buoy Commissioned for Navigation Season", "A buoy which was in ice over the winter and has been verified undamaged and in advertised position for the navigational season",43),
				new listedValue("Buoy Damaged", "The buoy has been damaged due to external factors (wind, sea state, collision with a vessel).",44),
				new listedValue("Buoy Daymark Unreliable", "Colour of the buoy daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",45),
				new listedValue("Buoy Decommissioned for Winter", "A buoy which remains in the water over winter but which is declared unreliable (may be impacted by ice movement).",46),
				new listedValue("Buoy Destroyed", "The buoy has suffered extensive damage and is not useable.",47),
				new listedValue("Buoy Establishment", "A new buoy has been or will be established.",48),
				new listedValue("Buoy Missing", "No buoy at its advertised/charted position or in the vicinity.",49),
				new listedValue("Buoy Move", "The buoy has been or will be moved intentionally.",50),
				new listedValue("Buoy off Position", "The buoy has been dragged off its advertised position due to wind or current affecting the mooring system.",51),
				new listedValue("Buoy Re-established", "The re-establishment of a buoy which was previously announced either destroyed or temporarily removed.",52),
				new listedValue("Buoy Removal", "Buoy has been or will be permanently removed from service.",53),
				new listedValue("Buoy Replaced by Winter Spar", "A buoy which has been removed and it's location is now marked by a winter spar buoy.",54),
				new listedValue("Buoy Restored to Normal", "The buoy has been restored to normal condition.",55),
				new listedValue("Buoy Temporary Change", "The characteristics of the buoy have been or will be temporarily changed.",56),
				new listedValue("Buoy Temporary Establishment", "A new buoy has been or will be established for a limited period of time.",57),
				new listedValue("Buoy Temporary Removal", "Buoy has been or will be temporarily removed from service.",58),
				new listedValue("Buoy Topmark Damaged", "The topmark of the buoy is damaged due to external factors (wind, sea state, collision with a vessel).",59),
				new listedValue("Buoy Topmark Missing", "The topmark of the buoy is missing.",60),
				new listedValue("Buoy Will Be Withdrawn", "The buoy has been scheduled for removal from service for a fixed term.",61),
				new listedValue("Buoy Withdrawn", "The buoy has been removed from service for a fixed term.",62),
				new listedValue("Buoy Withdrawn for Winter", "A buoy has been withdrawn for the winter season.",63),
				new listedValue("Cable Laying Operation", "Operations being undertaken to lay wires, fibres, wire rope or chains underwater or to bury them beneath the sea floor.",64),
				new listedValue("Cable Operations", "Underwater operations undertaken to maintain or repair a submarine cable.",65),
				new listedValue("Chayka Operating Properly", "The Chayka station is operating as advertised.",66),
				new listedValue("Chayka Out Of Service", "The Chayka station is inoperative due to a technical issue.",67),
				new listedValue("Chayka Station Removal", "Chayka station has been or will be permanently removed from service.",68),
				new listedValue("Chayka Station Temporary Removal", "Chayka station has been or will be temporarily removed from service.",69),
				new listedValue("Chayka Unreliable", "The Chayka station is unreliable due to a technical issue or maintenance.",70),
				new listedValue("Cluster of Fishing Vessels", "A large concentration of fishing vessels in a small area which may interfere with, hamper, or reduce the ability of another vessel to navigate safely.",71),
				new listedValue("Container Adrift", "A cargo container which has fallen overboard and is reported adrift.",72),
				new listedValue("Dangerous Wreck", "A wreck submerged at such a depth as to be considered dangerous to surface navigation.",73),
				new listedValue("Dead Whale Adrift", "A deceased marine mammal, typically a whale, reported adrift.",74),
				new listedValue("Deadhead Adrift", "A log which, becoming saturated with water, will start to sink at the heavier end, such that it floats vertically or nearly vertically in the water.",75),
				new listedValue("Derelict Vessel Adrift", "Any vessel abandoned at sea of sufficient size as to pose a hazard to safe navigation.",76),
				new listedValue("DGLONASS Operating Properly", "The DGLONASS station is operating as advertised.",77),
				new listedValue("DGLONASS Out Of Service", "The DGLONASS station is inoperative due to a technical issue.",78),
				new listedValue("DGLONASS Station Establishment", "A new DGLONASS station has been or will be established.",79),
				new listedValue("DGLONASS Unreliable", "The DGLONASS station is unreliable due to a technical issue or maintenance.",80),
				new listedValue("DGPS Operating Properly", "The DGPS station is operating as advertised.",81),
				new listedValue("DGPS Out Of Service", "The DGPS station is inoperative due to a technical issue.",82),
				new listedValue("DGPS Station Establishment", "A new DGPS station has been or will be established.",83),
				new listedValue("DGPS Station Removal", "DGPS station has been or will be permanently removed from service.",84),
				new listedValue("DGPS Station Temporary Removal", "DGPS station has been or will be temporarily removed from service.",85),
				new listedValue("DGPS Unreliable", "The DGPS station is unreliable due to a technical issue or maintenance.",86),
				new listedValue("Diving Operation", "A location where divers are conducting any type of activity at or below the surface of the water.",87),
				new listedValue("Dock Adrift", "A structure, formerly attached along the shoreline or extending from the shore into a body of water to which vessels moor, which has broken free of its moorings and is adrift.",88),
				new listedValue("Dredging Operation", "Works in order to increase depth.",89),
				new listedValue("Drill Rig Under Tow", "A drill rig is under tow.",90),
				new listedValue("Drilling Site Operations", "A drill rig/drill ship has commenced operations at the specified location offshore.",91),
				new listedValue("E-Chayka Operating Properly", "The e-Chayka station is operating as advertised.",92),
				new listedValue("E-Chayka Out Of Service", "The e-Chayka station is inoperative due to a technical issue.",93),
				new listedValue("E-Chayka Station Establishment", "A new e-Chayka station has been or will be established.",94),
				new listedValue("E-Chayka Station Removal", "The e-Chayka station has been or will be permanently removed from service.",95),
				new listedValue("E-Chayka Station Temporary Removal", "The e-Chayka station has been or will be temporarily removed from service",96),
				new listedValue("E-Chayka Unreliable", "The e-Chayka station is unreliable due to a technical issue or maintenance.",97),
				new listedValue("EGC MSI Service", "Any failure or return to operation of an EGC service offered by a recognized mobile satellite service provider.",98),
				new listedValue("EGNOS Operating Properly", "The EGNOS station is operating as advertised.",99),
				new listedValue("EGNOS Out Of Service", "The EGNOS station is inoperative due to a technical issue.",100),
				new listedValue("EGNOS Station Establishment", "A new EGNOS station has been or will be established.",101),
				new listedValue("EGNOS Station Removal", "EGNOS station has been or will be permanently removed from service.",102),
				new listedValue("EGNOS Station Temporary Removal", "EGNOS station has been or will be temporarily removed from service.",103),
				new listedValue("EGNOS Unreliable", "The EGNOS station is unreliable due to a technical issue or maintenance.",104),
				new listedValue("ELORAN Operating Properly", "The eLORAN station is operating as advertised.",105),
				new listedValue("ELORAN Out Of Service", "The eLORAN station is inoperative due to a technical issue.",106),
				new listedValue("ELORAN Station Establishment", "A new eLORAN station has been or will be established.",107),
				new listedValue("ELORAN Station Removal", "The eLORAN station has been or will be permanently removed from service.",108),
				new listedValue("ELORAN Station Temporary Removal", "The eLORAN station has been or will be temporarily removed from service.",109),
				new listedValue("ELORAN Unreliable", "The eLORAN station is unreliable due to a technical issue or maintenance.",110),
				new listedValue("Exclusion Zone", "An established marine area, temporary or permanent in nature, where vessel traffic is prohibited." +
										"A geographical area, within which all other vessels should remain clear unless authorised.",111),
				new listedValue("Explosive Device", "Unexploded explosive devices.",112),
				new listedValue("Fairway Marker - Light Not Synchronized", "The light on the fairway marker is no longer synchronized with another light or group of lights.",113),
				new listedValue("Fairway Marker - Light Unlit", "The light on the fairway marker is inoperative.",114),
				new listedValue("Fairway Marker - Light Unreliable", "The operation of the light on the fairway marker is unreliable due to technical problems.",115),
				new listedValue("Fairway Marker Damaged", "The fairway marker has been damaged due to external factors (wind, sea state, collision with a vessel).",116),
				new listedValue("Fairway Marker Destroyed", "The fairway marker has suffered extensive damage and is not useable.",117),
				new listedValue("Fallout Hazard", "The area of which remains hazardous to life after an explosive detonation or the fallout from a rocket launch or space debris.",118),
				new listedValue("Fireworks", "Scheduled public display of pyrotechnics, usually ignited from barges located just offshore, and often accompanied by music.",119),
				new listedValue("Firing Exercise", "An exercise within a defined area which includes the firing of weapon systems during training or testing that may affect safety at sea.",120),
				new listedValue("Fish Aggregating Device", "A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks or adrift.",121),
				new listedValue("Fishing Net Adrift", "A fishing net (seine, purse, gill, trawl, bag or other), reported adrift, of sufficient size to pose a hazard to safe navigation.",122),
				new listedValue("Floating Debris", "A concentration of floating objects, which by the nature of their size and material, could pose a hazard to safe navigation.",123),
				new listedValue("Floodlit Beacon - Unlit", "The flood light illuminating the beacon is inoperative.",124),
				new listedValue("Fog Signal Change", "The characteristics of the fog signal have been or will be changed.",125),
				new listedValue("Fog Signal Establishment", "A new fog signal has been or will be established.",126),
				new listedValue("Fog Signal Operating Properly", "The fog signal is operating as advertised.",127),
				new listedValue("Fog Signal Out Of Service", "The fog signal is inoperative.",128),
				new listedValue("Fog Signal Removal", "Fog signal has been or will be permanently removed from service.",129),
				new listedValue("Fog Signal Temporary Change", "The characteristics of the fog signal have been or will be temporarily changed.",130),
				new listedValue("Fog Signal Temporary Establishment", "A new fog signal has been or will be established for a limited period of time.",131),
				new listedValue("Fog Signal Temporary Removal", "Fog signal has been or will be temporarily removed from service.",132),
				new listedValue("Front and Rear Lights out of Synchronization", "The synchronization of the leading lights is abnormal / The synchronization of the range lights is abnormal.",133),
				new listedValue("Front Beacon Restored to Normal", "The front leading beacon has been restored to normal condition. / The front range beacon has been restored to normal condition.",134),
				new listedValue("Front Beacon Unreliable", "The front leading beacon is damaged, obscured or missing. / The front range beacon is damaged, obscured or missing.",135),
				new listedValue("Front Light is Operating Properly", "The front leading light is operating as advertised. / The front range light is operating as advertised.",136),
				new listedValue("Front Light Range Reduced", "The nominal range of the front leading light is reduced. / The nominal range of the front range light is reduced.",137),
				new listedValue("Front Light Unlit", "The front leading light is extinguished. / The front range light is extinguished.",138),
				new listedValue("Front Light Unreliable", "The operation of the front leading light is unreliable due to technical problems. / The operation of the front range light is unreliable due to technical problems.",139),
				new listedValue("Front Light Without Rhythm", "Due to technical problems front leading light has no rhythm and is in fixed light mode. / Due to technical problems front range light has no rhythm and is in fixed light mode.",140),
				new listedValue("GNSS Degradation", "The quality of service of a global navigation satellite system is poor due to an internal or external cause (e.g. jamming, space weather).",141),
				new listedValue("Hazardous Area", "An area which may contain known or unknown navigational hazards which could impact the safe navigation.",142),
				new listedValue("HF Service", "An outage, or return to operation, of an HF service (radiotelephone, digital selective calling or narrow band directing printing telegraphy).",143),
				new listedValue("High Water Level", "High water level, potentially over a sustained period of time, such as with extreme weather or river freshet.",144),
				new listedValue("Horizontal Clearance Reduced", "The reduction in the horizontal distance or navigable width of a canal, channel, lock, etc.",145),
				new listedValue("Hydrographic Survey Activity", "Activity of vessels or drones/MASS, restricted in their ability to maneuver, engaged in towing of surface or subsurface scientific instruments to gather data on the measurements of subsurface features.",146),
				new listedValue("Ice Boom - Installation or Removal", "A notice concerning the installation (or removal) of floating barriers, anchored to the bottom, used to deflect the path of floating ice in order to prevent the obstruction of locks, intakes, etc., and to prevent damage to bridge piers and other structures.",147),
				new listedValue("Ice Control Zone In-Force or Deactivated", "Information concerning when a designated ice control zone is in force or deactivated. If in-force, mariners must follow established procedures for safe navigation.",148),
				new listedValue("Iceberg Outside Advertised Limits", "An iceberg which is reported outside of the advertised limits of ice.",149),
				new listedValue("Jamming Exercise", "An exercise in which the signals of radio navigation aids, radars or radio services are disrupted by an intentional cause for training purposes.",150),
				new listedValue("Light Buoy - Light Damaged", "The light on the buoy is damaged due to external factors (wind, sea state, collision with a vessel).",151),
				new listedValue("Light Buoy - Light Not Synchronized", "The light on the buoy is no longer synchronized with another light or group of lights.",152),
				new listedValue("Light Buoy - Light Unlit", "The light on the buoy is extinguished.",153),
				new listedValue("Light Buoy - Light Unreliable", "The operation of the light on the buoy is unreliable due to technical problems.",154),
				new listedValue("Light Change", "The characteristics of the light have been or will be changed.",155),
				new listedValue("Light Daymark Unreliable", "The light daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",156),
				new listedValue("Light Establishment", "A new light has been or will be established.",157),
				new listedValue("Light Operating Properly", "The light is operating as advertised",158),
				new listedValue("Light Out Of Synchronization", "The light is no longer synchronized with another light or group of lights.",159),
				new listedValue("Light Range Reduced", "The nominal range of the light is less than the advertised range.",160),
				new listedValue("Light Re-Establishment", "The re-establishment of a light which was previously announced as either destroyed or temporarily removed.",161),
				new listedValue("Light Removal", "Light has been or will be permanently removed from service.",162),
				new listedValue("Light Spar Buoy - Light Damaged", "The light on the spar buoy is damaged due to external factors (wind, sea state, collision with a vessel).",163),
				new listedValue("Light Spar Buoy - Light Not Synchronized", "The light on the spar buoy is no longer synchronized with another light or group of lights.",164),
				new listedValue("Light Spar Buoy - Light Unlit", "The light on the spar buoy is extinguished.",165),
				new listedValue("Light Spar Buoy - Light Unreliable", "The operation of the light on the spar buoy is unreliable due to technical problems.",166),
				new listedValue("Light Temporary Change", "The characteristics of the light have been or will be temporarily changed.",167),
				new listedValue("Light Temporary Establishment", "A new light has been or will be established for a limited period of time.",168),
				new listedValue("Light Temporary Removal", "Light has been or will be temporarily removed from service.",169),
				new listedValue("Light Unlit", "The light is extinguished.",170),
				new listedValue("Light Unreliable", "The light is unreliable due to technical problems.",171),
				new listedValue("Light Without Rhythm", "Due to technical problems the light has no more rhythm and is in fixed light mode.",172),
				new listedValue("Lighted Beacon - Light Damaged", "The light on the beacon is damaged due to external factors (wind, sea state, collision with a vessel).",173),
				new listedValue("Lighted Beacon - Light Not Synchronized", "The light on the beacon is no longer synchronized with another light or group of lights.",174),
				new listedValue("Lighted Beacon - Light Unlit", "The light of the beacon is extinguished.",175),
				new listedValue("Lighted Beacon - Light Unreliable", "The operation of the light on the beacon is unreliable due to technical problems.",176),
				new listedValue("Local Health Authority Notice", "Notice issued by local health authorities to persons ashore or at sea.",177),
				new listedValue("Lock Closed", "Lock operation is compromised. The lock is closed.",178),
				new listedValue("Log Adrift", "A log is a tree, stripped of its branches and roots, which is floating horizontally and barely awash.",179),
				new listedValue("Log Boom Adrift", "One or more sections of a chained log boom has broken free of its tow and is adrift.",180),
				new listedValue("LORAN C - Operating Properly", "The LORAN C station is operating as advertised.",181),
				new listedValue("LORAN C - Out Of Service", "The LORAN C station is inoperative due to a technical issue.",182),
				new listedValue("LORAN C - Unreliable", "The LORAN C station is unreliable due to a technical issue or maintenance.",183),
				new listedValue("LORAN C Station Removal", "LORAN C station has been or will be permanently removed from service.",184),
				new listedValue("LORAN C Station Temporary Removal", "LORAN C station has been or will be temporarily removed from service.",185),
				new listedValue("Low Water Level", "Low water level, potentially over a sustained period of time, such as with extreme weather.",186),
				new listedValue("Marine Aids to Navigation Unreliable", "The position or status of Marine Aids to Navigation, over an extensive area, is unreliable due to a natural event (freshet, storm surge, flooding).",187),
				new listedValue("Maritime Security Level Changes", "The raising or lowering of the national, regional or port-specific maritime security level within a country.",188),
				new listedValue("MF Service", "Any outage or return to operation of a MF service (radiotelephone, digital selective calling or narrow band directing printing).",189),
				new listedValue("Military Exercise", "An exercise comprised of multiple vessels and/or aircraft used to train and asses operational capacity and strategy without actual live combat.",190),
				new listedValue("Military Operation", "A military response to a specific event or situation.",191),
				new listedValue("MSI Service", "An outage of a maritime safety information broadcast service (satellite or terrestrial system).",192),
				new listedValue("National Health Authority Notice", "Notice issued by a national health authority to persons ashore or at sea.",193),
				new listedValue("NAVTEX Service Change", "Any failure or return to service of the International or National NAVTEX broadcast services.",194),
				new listedValue("New or Amended Regulation", "New or updated maritime regulation which may impact navigation such as changes to navigation lanes or newly established areas to be avoided.",195),
				new listedValue("Numerous Fishing Vessels", "There are many fishing vessels operating in the area.",196),
				new listedValue("Object Adrift", "Object reported adrift and posing a hazard to safe navigation.",197),
				new listedValue("Offshore Rigs or Platform Changes", "Changes to offshore rig/platforms, either fixed or floating, used for oil/gas production, exploration, research, observation, etc.",198),
				new listedValue("Opening or Closing of Harbour", "The temporary or permanent closing or re-opening of a harbour.",199),
				new listedValue("Opening or Closing of Swing Bridge", "The failure, or return to operation, of the opening or closing of swing bridges.",200),
				new listedValue("Opening or Closing of Waters", "The temporary closing or re-opening of waters, e.g. waterway, bay, straits.",201),
				new listedValue("Pipe Laying Operation", "Activity comprised of one or more vessels engaged in the laying of pipe on or beneath the sea floor.",202),
				new listedValue("Pipe Operations", "Underwater operations undertaken to maintain or repair a submarine pipe.",203),
				new listedValue("Presence of Long Fishing Gear", "There are fishing vessels using long fishing gear, such as fishing net and long fishing lines.",204),
				new listedValue("Presence of Marine Mammals", "Presence of marine mammals is expected.",205),
				new listedValue("Presence of Naval Mines", "Self-contained explosive device, either floating or submerged, which could be triggered by the approach or contact with a vessel or submarine.",206),
				new listedValue("Presence of Submerged Fishing Net", "A fishing net (seine, purse, gill, trawl, bag or other), reported submerged, or partially submerged, of sufficient size to pose a hazard to safe navigation.",207),
				new listedValue("Presence of Scientific Equipment", "Presence of a buoy or object deployed to gather scientific information.",208),
				new listedValue("RACON Change", "The characteristics of the RACON have been or will be changed.",209),
				new listedValue("RACON Establishment", "A new RACON has been or will be established.",210),
				new listedValue("RACON Operating Properly", "The RACON is operating as advertised.",211),
				new listedValue("RACON Out Of Service", "The RACON is inoperative.",212),
				new listedValue("RACON Removal", "RACON has been or will be permanently removed from service.",213),
				new listedValue("RACON Temporary Change", "The characteristics of the RACON have been or will be temporarily changed.",214),
				new listedValue("RACON Temporary Establishment", "A new RACON has been or will be established for a limited period of time.",215),
				new listedValue("RACON Temporary Removal", "RACON has been or will be temporarily removed from service.",216),
				new listedValue("RACON Unreliable", "The RACON is unreliable due to a technical issue or maintenance.",217),
				new listedValue("Radar Surveillance System Service Change", "Any failure or return to service of radar in an advertised radar-monitored area which may impact the ability of maritime authorities to track and monitor the movement of vessels.",218),
				new listedValue("RAMARK Change", "The characteristics of the RAMARK have been or will be changed.",219),
				new listedValue("RAMARK Establishment", "A new RAMARK has been or will be established.",220),
				new listedValue("RAMARK Operating Properly", "The RAMARK is operating as advertised.",221),
				new listedValue("RAMARK Out Of Service", "The RAMARK is inoperative.",222),
				new listedValue("RAMARK removal", "RAMARK has been or will be permanently removed from service.",223),
				new listedValue("RAMARK Temporary Change", "The characteristics of the RAMARK have been or will be temporarily changed.",224),
				new listedValue("RAMARK Temporary Establishment", "A new RAMARK has been or will be established for a limited period of time.",225),
				new listedValue("RAMARK Temporary Removal", "RAMARK has been or will be temporarily removed from service.",226),
				new listedValue("RAMARK Unreliable", "The RAMARK is unreliable due to a technical issue or maintenance.",227),
				new listedValue("Rear Beacon Restored to Normal", "The rear leading beacon has been restored to normal condition. / The rear range beacon has been restored to normal condition.",228),
				new listedValue("Rear Beacon Unreliable", "The rear leading beacon is damaged, obscured or missing. / The rear range beacon is damaged, obscured or missing",229),
				new listedValue("Rear Light is Operating Properly", "The rear leading light is operating as advertised. / The rear range light is operating as advertised.",230),
				new listedValue("Rear Light Range Reduced", "The nominal range of the rear leading light is reduced. / The nominal range of the rear range light is reduced.",231),
				new listedValue("Rear Light Unlit", "The rear leading light is extinguished. / The rear range light is extinguished.",232),
				new listedValue("Rear Light Unreliable", "The operation of the rear leading light is unreliable due to technical problems. / The operation of the rear range light is unreliable due to technical problems.",233),
				new listedValue("Rear Light Without Rhythm", "Due to technical problems, the rear leading light has no rhythm and is in fixed light mode. / Due to technical problems rear range light has no rhythm and is in fixed light mode.",234),
				new listedValue("Regatta or Race", "A short or long race of sail, oar or power craft along a predetermined course which may approach or cross navigation lanes.",235),
				new listedValue("Renewable Energy Device or Farm Change", "The installation, removal, failure or damage of renewable energy devices (Wind turbines/farms, ocean current or wave power plants) which pose a hazard to safe navigation.",236),
				new listedValue("Restricted Area Changes", "A new or revised specified area, temporary or permanent in nature, designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.",237),
				new listedValue("Sandspit or Sandbar Change", "Significant changes to the limits or depth of a known sandbar/sandspit, or the discovery of a new sandbar/sandspit, which poses a hazard to safe navigation.",238),
				new listedValue("SAR Exercise", "A large scale activity where multiple vessels, surveillance aircraft, and shore-based personnel practice search and rescue techniques, in order to evaluate the effectiveness of response capability.",239),
				new listedValue("SAR Operation", "A real time response by vessels, surveillance aircraft, and shore-based personnel participating in an active search and rescue operation.",240),
				new listedValue("Scientific Buoy Adrift", "A buoy fit for scientific purposes which has broken free of its moorings or has been left free and is adrift.",241),
				new listedValue("Scientific Moorings", "A submerged platform where a scientific instrument is secured and which may or may not be secured to the sea floor by means of an anchor chain.",242),
				new listedValue("Scientific Survey", "An activity where one or more vessels, restricted in their ability to manoeuvre, navigate along a pre-determine grid pattern in order to collect scientific data.",243),
				new listedValue("Sea Trials", "Sea testing phase of a vessel.",244),
				new listedValue("Seaplane Operations", "Activity within a defined area on the water where seaplanes are actively engaged in take-off, landing or taxiing.",245),
				new listedValue("Seasonal Commissioning Complete", "The completion of the process to place summer buoys (and the removal of any winter spar buoys).",246),
				new listedValue("Seasonal Commissioning in Progress", "The commencement of the process to place summer buoys (and the removal of any winter spar buoys).",247),
				new listedValue("Seasonal Decommissioning Complete", "The completion of the process to remove summer buoys (and possibly replace some with winter spar buoys).",248),
				new listedValue("Seasonal Decommissioning in Progress", "The commencement of the process to remove summer buoys (and possibly replace some with winter spar buoys).",249),
				new listedValue("Sector Light - Sector Obscured", "The light sector has been fully or partly obscured.",250),
				new listedValue("Sector Light Change", "The characteristics of the sector light have been or will be changed.",251),
				new listedValue("Sector Light Temporary Change", "The characteristics of the sector light have been or will be temporarily changed.",252),
				new listedValue("Security Regulation Change", "Changes to the national, regional or port-specific maritime security regulations.",253),
				new listedValue("Seismic Survey Operation", "The commencement or cessation of the complex operations of a seismic survey.",254),
				new listedValue("Shallow Depth Confirmed", "Confirmed significant change to the depth or position of a charted sounding/shoal, or the discovery of a new shoal, which poses a hazard to safe navigation.",255),
				new listedValue("Shallow Depth Reported", "Reported significant change to the depth or position of a charted sounding/shoal, or the discovery of a new shoal, which poses a hazard to safe navigation.",256),
				new listedValue("Spar Buoy Adrift", "The spar buoy is no longer secured to its moorings and has gone adrift from its advertised position.",257),
				new listedValue("Spar Buoy Damaged", "The spar buoy has been damaged due to external factors (wind, sea state, collision with a vessel).",258),
				new listedValue("Spar Buoy Destroyed", "The spar buoy has suffered extensive damage and is not useable.",259),
				new listedValue("Spar Buoy Missing", "No spar buoy at its advertised position or in the vicinity.",260),
				new listedValue("Spar Buoy Move", "The spar buoy has been or will be moved intentionally.",261),
				new listedValue("Spar Buoy off Position", "The spar buoy has been dragged off its advertised position due to wind or current affecting the mooring system.",262),
				new listedValue("Spar Buoy Re-established", "The re-establishment of a spar buoy which was previously announced either destroyed or temporarily removed.",263),
				new listedValue("Spar Buoy Restored to Normal", "The spar buoy has been restored to normal condition.",264),
				new listedValue("Spar Buoy Topmark Missing", "The topmark of the spar buoy is missing.",265),
				new listedValue("Spar Buoy Withdrawn", "The spar buoy has been removed from service for a fixed term.",266),
				new listedValue("Storm Surge", "A rise above normal water level on the open coast due only to the action of wind stress on the water surface. Storm surge resulting from a hurricane or other intense storm also includes the rise in level due to atmospheric pressure reduction as well as that due to wind stress. A storm surge is more severe when it occurs in conjunction with a high tide. Also called storm tide, storm wave, tidal wave.",267),
				new listedValue("Submarine Cable Changes", "Change in status, location or depth of a submerged or seabed cable which poses a hazard to safe navigation, anchoring or fishing.",268),
				new listedValue("Submarine Pipeline Changes", "Change in status, location or depth of a submerged or seabed pipeline which poses a hazard to safe navigation, anchoring or fishing.",269),
				new listedValue("Submerged Object", "Any object under water; not showing above water.",270),
				new listedValue("Subsurface Mooring", "A mooring which is under water and which may or may not be secured to the sea floor by means of an anchor chain.",271),
				new listedValue("Swimmers", "A single person or groups of persons will be / are swimming in or near navigation lanes.",272),
				new listedValue("Temporary Buoyage", "The establishment of a buoy or group of buoys for a limited period of time (i.e. during summer season or during marine construction projects).",273),
				new listedValue("Tide Gauge Change", "The installation or removal of a tide gauge.",274),
				new listedValue("Traffic Congestion", "An area is experiencing a significantly high volume of vessel traffic which could potentially impede the progress of a vessel.",275),
				new listedValue("Tsunami Warning", "An alert message concerning strong waves, the widespread inundation of water, due to an earthquake, landslide or volcanic eruption, which is issued when the threat is imminent, expected or occurring.",276),
				new listedValue("Uncharted Rock", "A newly located rock, submerged or partially submerged rock, which had not been previously charted.",277),
				new listedValue("Underwater Operations", "Underwater work to maintain or repair subsurface structures (e.g. drill head).",278),
				new listedValue("Unidentified Radar Target - Possible Iceberg", "An unidentified radar target, within the advertised limits of ice, but not yet visually confirmed as being an iceberg.",279),
				new listedValue("Unwieldy Tow", "A tow, which by the nature of the size, shape or dimensions of the object being towed, is cumbersome to effectively tow regardless of the conditions of the waterway.",280),
				new listedValue("V-AIS Change", "The characteristics of the V-AIS have been or will be changed.",281),
				new listedValue("V-AIS Establishment", "A new V-AIS has been or will be established.",282),
				new listedValue("V-AIS Operating Properly", "Virtual AIS aid to navigation is operating as advertised.",283),
				new listedValue("V-AIS Out Of Service", "Virtual AIS aid to navigation is extinguished.",284),
				new listedValue("V-AIS Removal", "V-AIS has been or will be permanently removed from service.",285),
				new listedValue("V-AIS Temporary Change", "The characteristics of the V-AIS have been or will be temporarily changed.",286),
				new listedValue("V-AIS Temporary Establishment", "A new V-AIS has been or will be established for a limited period of time.",287),
				new listedValue("V-AIS Temporary Removal", "V-AIS has been or will be temporarily removed from service.",288),
				new listedValue("V-AIS Unreliable", "Virtual AIS aid is unreliable due to a technical issue or maintenance.",289),
				new listedValue("Vertical Clearance Reduced", "The reduction in the vertical distance between the air draft of a vessel and the lowest point on a bridge structure, cable or pipeline of which the vessel is intending to pass underneath.",290),
				new listedValue("Vessel Adrift", "A vessel at sea or which has lost mechanical capability and cannot be moored or anchored.",291),
				new listedValue("Vessel Disabled", "A vessel adrift at sea or safely anchored/moored, which has been damaged or has experienced some sort of mechanical or electrical failure so it can no longer sail.",292),
				new listedValue("VHF Service Change", "Any outage or return to operation of any VHF service (radiotelephone or digital selective calling).",293),
				new listedValue("Volcano Activity", "Volcano activity impacting safe navigation.",294),
				new listedValue("VTS Change", "Change to an existing vessel traffic service zone limit, procedure and or provision of broadcast service relating to vessels operating within that zone.",295),
				new listedValue("Waterway Recommended or Not Recommended For Shipping", "Temporary or permanent changes to a waterway/fairway which may render it unsafe/safe for marine traffic.",296),
				new listedValue("Wharf Construction", "The commencement or cessation of wharf construction.",297),
				new listedValue("Works in Progress", "An active marine project, either on the surface or under water, which may affect the navigation of vessels.",298),
				new listedValue("World Health Organization Notice", "Notice issued by World Health Organization to persons ashore or at sea.",299),
			];
	}

	/// <summary>
	/// General type of a navigational warning or navigational hazard.
	/// </summary>
	public class navwarnTypeGeneral : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(navwarnTypeGeneral);
		[JsonIgnore]
		public override string S100FC_name => "Navwarn Type General";
		public static listedValue[] listedValues => [
				new listedValue("Aids to Navigation Changes", "Any casualties to lights, fog signals, buoys and other aids to navigation affecting shipping; establishment of major new aids to navigation or significant changes to existing ones, when such establishment or change might be misleading to shipping.",1),
				new listedValue("Aquaculture and Fishing Installations", "New or established aquaculture and fishing installations.",2),
				new listedValue("Drifting Hazards", "Drifting hazards, including derelict ships, containers, other large items, etc.",3),
				new listedValue("ECDIS Operating Anomalies including Official Data Issues", "Operating anomalies identified within ECDIS, including issues with official data.",4),
				new listedValue("Other Hazards", "Hazards likely to constitute a danger to navigation.",5),
				new listedValue("Health Advisories", "Health advisories or information.",6),
				new listedValue("Ice Information", "Newly discovered icebergs, changes to ice conditions and ice related information likely to impact navigation.",7),
				new listedValue("In-Force Bulletin", "A list of serial numbers of warnings which are in-force.",8),
				new listedValue("Dangerous Natural Phenomena", "Natural phenomena adversely affecting the marine environment.",9),
				new listedValue("Newly Discovered Dangers", "Newly discovered rocks, shoals, reefs and wrecks likely to constitute a danger to navigation and, if relevant, their markings.",10),
				new listedValue("Offshore Infrastructure", "New or established complex structures situated at sea, including rigs, drilling platforms, offshore wind turbines, cables and pipelines.",11),
				new listedValue("Piracy or Robbery", "Acts of piracy and armed robbery against ships.",12),
				new listedValue("Communication or Broadcast Service Change", "Any failure or return to service of terrestrial or satellite radio services used to determine the position of an object.",13),
				new listedValue("Routeing Change", "Changes to the established navigational routes or specific procedures related to them.",14),
				new listedValue("Scientific Instruments Change", "Deployment or removal of scientific instruments on the surface, subsurface or on the sea floor.",15),
				new listedValue("Security Requirement Change", "Changes to the maritime security levels in a country, a specific region or port. Or, changes to maritime security regulations.",16),
				new listedValue("Special Operations", "Events which might affect the safety of shipping, sometimes over wide areas, e.g. naval exercises, missile firings, space missions, nuclear tests, ordnance dumping zones, etc.",17),
				new listedValue("Towing Operations", "Objects being towed which are impacting navigation of vessels in its vicinity.",18),
				new listedValue("Works", "Works at sea or onshore which might affect navigation.",19),
				new listedValue("Rig List", "An update on the position, movement or status of rigs or drill ships within a defined area.",20),
			];
	}

	/// <summary>
	/// The best estimate of the fixed horizontal or vertical accuracy component for positions, depths, heights, vertical distances and vertical clearances.
	/// </summary>
	public class uncertaintyFixed : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(uncertaintyFixed);
		[JsonIgnore]
		public override string S100FC_name => "Uncertainty Fixed";

		public static implicit operator uncertaintyFixed(decimal? value) => new uncertaintyFixed { value = value };
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
				new listedValue("Approximate", "A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.",4),
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

}

namespace S100FC.S124.ComplexAttributes
{
	using S100FC.S124.SimpleAttributes;

	/// <summary>
	/// Name or number of affected national paper chart or ENC.
	/// </summary>
	public class chartAffected : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(chartAffected);
		[JsonIgnore]
		public override string S100FC_name => "Chart Affected";

		#region Attributes
		[JsonIgnore]
		public String? chartNumber {
			set { base.SetAttribute(new chartNumber { value = value }); }
			get { return base.GetAttributeValue<chartNumber>(nameof(chartNumber))?.value; }
		}
		[JsonIgnore]
		public String? chartPlanNumber {
			set { base.SetAttribute(new chartPlanNumber { value = value }); }
			get { return base.GetAttributeValue<chartPlanNumber>(nameof(chartPlanNumber))?.value; }
		}
		[JsonIgnore]
		public DateOnly? editionDate {
			set { base.SetAttribute(new editionDate { value = value }); }
			get { return base.GetAttributeValue<editionDate>(nameof(editionDate))?.value; }
		}
		[JsonIgnore]
		public DateOnly? lastNoticeDate {
			set { base.SetAttribute(new lastNoticeDate { value = value }); }
			get { return base.GetAttributeValue<lastNoticeDate>(nameof(lastNoticeDate))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(chartNumber),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new chartNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(chartPlanNumber),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new chartPlanNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(editionDate),
					lower = 1,
					upper = 1,
					order = 2,
					CreateInstance = () => new editionDate(),
				},
				new attributeBindingDefinition {
					attribute = nameof(lastNoticeDate),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new lastNoticeDate(),
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
		public String? dateEnd {
			set { base.SetAttribute(new dateEnd { value = value }); }
			get { return base.GetAttributeValue<dateEnd>(nameof(dateEnd))?.value; }
		}
		[JsonIgnore]
		public String? dateStart {
			set { base.SetAttribute(new dateStart { value = value }); }
			get { return base.GetAttributeValue<dateStart>(nameof(dateStart))?.value; }
		}
		[JsonIgnore]
		public S100FC.S100.Time? timeOfDayEnd {
			set { base.SetAttribute(new timeOfDayEnd { value = value }); }
			get { return base.GetAttributeValue<timeOfDayEnd>(nameof(timeOfDayEnd))?.value; }
		}
		[JsonIgnore]
		public S100FC.S100.Time? timeOfDayStart {
			set { base.SetAttribute(new timeOfDayStart { value = value }); }
			get { return base.GetAttributeValue<timeOfDayStart>(nameof(timeOfDayStart))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(dateEnd),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new dateEnd(),
				},
				new attributeBindingDefinition {
					attribute = nameof(dateStart),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new dateStart(),
				},
				new attributeBindingDefinition {
					attribute = nameof(timeOfDayEnd),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new timeOfDayEnd(),
				},
				new attributeBindingDefinition {
					attribute = nameof(timeOfDayStart),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new timeOfDayStart(),
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
					attribute = nameof(language),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new language(),
				},
				new attributeBindingDefinition {
					attribute = nameof(text),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new text(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Name of an area locality as defined by a competent authority.
	/// </summary>
	public class locationName : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(locationName);
		[JsonIgnore]
		public override string S100FC_name => "Location Name";

		#region Attributes
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
					attribute = nameof(language),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new language(),
				},
				new attributeBindingDefinition {
					attribute = nameof(text),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new text(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Message series identification of the warning or notice.
	/// </summary>
	public class messageSeriesIdentifier : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(messageSeriesIdentifier);
		[JsonIgnore]
		public override string S100FC_name => "Message Series Identifier";

		#region Attributes
		[JsonIgnore]
		public String? agencyResponsibleForProduction {
			set { base.SetAttribute(new agencyResponsibleForProduction { value = value }); }
			get { return base.GetAttributeValue<agencyResponsibleForProduction>(nameof(agencyResponsibleForProduction))?.value; }
		}
		[JsonIgnore]
		public String? interoperabilityIdentifier {
			set { base.SetAttribute(new interoperabilityIdentifier { value = value }); }
			get { return base.GetAttributeValue<interoperabilityIdentifier>(nameof(interoperabilityIdentifier))?.value; }
		}
		[JsonIgnore]
		public String? nameOfSeries {
			set { base.SetAttribute(new nameOfSeries { value = value }); }
			get { return base.GetAttributeValue<nameOfSeries>(nameof(nameOfSeries))?.value; }
		}
		[JsonIgnore]
		public String? nationality {
			set { base.SetAttribute(new nationality { value = value }); }
			get { return base.GetAttributeValue<nationality>(nameof(nationality))?.value; }
		}
		[JsonIgnore]
		public int? warningNumber {
			set { base.SetAttribute(new warningNumber { value = value }); }
			get { return base.GetAttributeValue<warningNumber>(nameof(warningNumber))?.value; }
		}
		[JsonIgnore]
		public int? warningType {
			set { base.SetAttribute(new warningType { value = value }); }
			get { return base.GetAttributeValue<warningType>(nameof(warningType))?.value; }
		}
		[JsonIgnore]
		public int? year {
			set { base.SetAttribute(new year { value = value }); }
			get { return base.GetAttributeValue<year>(nameof(year))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(agencyResponsibleForProduction),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new agencyResponsibleForProduction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(nameOfSeries),
					lower = 1,
					upper = 1,
					order = 2,
					CreateInstance = () => new nameOfSeries(),
				},
				new attributeBindingDefinition {
					attribute = nameof(nationality),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new nationality(),
				},
				new attributeBindingDefinition {
					attribute = nameof(warningNumber),
					lower = 1,
					upper = 1,
					order = 4,
					CreateInstance = () => new warningNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(warningType),
					lower = 1,
					upper = 1,
					order = 5,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12],
					CreateInstance = () => new warningType(),
				},
				new attributeBindingDefinition {
					attribute = nameof(year),
					lower = 1,
					upper = 1,
					order = 6,
					CreateInstance = () => new year(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Title of the navigational warning.
	/// </summary>
	public class navwarnTitle : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(navwarnTitle);
		[JsonIgnore]
		public override string S100FC_name => "NAVWARN Title";

		#region Attributes
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
					attribute = nameof(language),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new language(),
				},
				new attributeBindingDefinition {
					attribute = nameof(text),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new text(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Detailed information about a warning.
	/// </summary>
	public class warningInformation : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(warningInformation);
		[JsonIgnore]
		public override string S100FC_name => "Warning Information";

		#region Attributes
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		[JsonIgnore]
		public int?[] navwarnTypeDetails {
			set { base.SetAttribute("navwarnTypeDetails", [.. value.Select(e=> new navwarnTypeDetails { value = e })]); }
			get { return base.GetAttributeValues<navwarnTypeDetails>(nameof(navwarnTypeDetails)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new information(),
				},
				new attributeBindingDefinition {
					attribute = nameof(navwarnTypeDetails),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new navwarnTypeDetails(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Reference to an object or feature that is external to the dataset.
	/// </summary>
	public class featureReference : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(featureReference);
		[JsonIgnore]
		public override string S100FC_name => "Feature Reference";

		#region Attributes
		[JsonIgnore]
		public String?[] atoNNumber {
			set { base.SetAttribute("atoNNumber", [.. value.Select(e=> new atoNNumber { value = e })]); }
			get { return base.GetAttributeValues<atoNNumber>(nameof(atoNNumber)).Select(e=>e.value).ToArray(); }
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
					attribute = nameof(atoNNumber),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new atoNNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new interoperabilityIdentifier(),
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
		public horizontalPositionUncertainty? horizontalPositionUncertainty {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<horizontalPositionUncertainty>(nameof(horizontalPositionUncertainty)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(horizontalPositionUncertainty),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Identifies paper charts, ENCs or publications that are affected by the information.
	/// </summary>
	public class affectedChartPublications : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(affectedChartPublications);
		[JsonIgnore]
		public override string S100FC_name => "Affected Chart Publications";

		#region Attributes
		[JsonIgnore]
		public chartAffected? chartAffected {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<chartAffected>(nameof(chartAffected)); }
		}
		[JsonIgnore]
		public String? chartPublicationIdentifier {
			set { base.SetAttribute(new chartPublicationIdentifier { value = value }); }
			get { return base.GetAttributeValue<chartPublicationIdentifier>(nameof(chartPublicationIdentifier))?.value; }
		}
		[JsonIgnore]
		public String? internationalChartAffected {
			set { base.SetAttribute(new internationalChartAffected { value = value }); }
			get { return base.GetAttributeValue<internationalChartAffected>(nameof(internationalChartAffected))?.value; }
		}
		[JsonIgnore]
		public String? language {
			set { base.SetAttribute(new language { value = value }); }
			get { return base.GetAttributeValue<language>(nameof(language))?.value; }
		}
		[JsonIgnore]
		public String? publicationAffected {
			set { base.SetAttribute(new publicationAffected { value = value }); }
			get { return base.GetAttributeValue<publicationAffected>(nameof(publicationAffected))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(chartAffected),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new chartAffected(),
				},
				new attributeBindingDefinition {
					attribute = nameof(chartPublicationIdentifier),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new chartPublicationIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(internationalChartAffected),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new internationalChartAffected(),
				},
				new attributeBindingDefinition {
					attribute = nameof(language),
					lower = 1,
					upper = 1,
					order = 3,
					CreateInstance = () => new language(),
				},
				new attributeBindingDefinition {
					attribute = nameof(publicationAffected),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new publicationAffected(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The general area used to identify which broad geographic region the message affects. The geographical name which is selected for the general area should be one that can be found on charts and in nautical publications. (S-53, 6).
	/// </summary>
	public class generalArea : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(generalArea);
		[JsonIgnore]
		public override string S100FC_name => "General Area";

		#region Attributes
		[JsonIgnore]
		public String? localityIdentifier {
			set { base.SetAttribute(new localityIdentifier { value = value }); }
			get { return base.GetAttributeValue<localityIdentifier>(nameof(localityIdentifier))?.value; }
		}
		[JsonIgnore]
		public locationName?[] locationName {
			set { base.SetAttribute("locationName", value); }
			get { return base.GetAttributeValues<locationName>(nameof(locationName)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(localityIdentifier),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new localityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationName),
					lower = 1,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new locationName(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Name and/or identifier of an area locality.
	/// </summary>
	public class locality : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(locality);
		[JsonIgnore]
		public override string S100FC_name => "Locality";

		#region Attributes
		[JsonIgnore]
		public String? localityIdentifier {
			set { base.SetAttribute(new localityIdentifier { value = value }); }
			get { return base.GetAttributeValue<localityIdentifier>(nameof(localityIdentifier))?.value; }
		}
		[JsonIgnore]
		public locationName?[] locationName {
			set { base.SetAttribute("locationName", value); }
			get { return base.GetAttributeValues<locationName>(nameof(locationName)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(localityIdentifier),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new localityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locationName),
					lower = 1,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new locationName(),
				},
			];

		#endregion
	}

}

namespace S100FC.S124.InformationAssociation
{
	using S100FC.S124.SimpleAttributes;
	using S100FC.S124.ComplexAttributes;

	/// <summary>
	/// The binding between a navigational warning preamble and the body.
	/// </summary>
	public class navwarnPreambleContent : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(navwarnPreambleContent);
		[JsonIgnore]
		public override string S100FC_name => "navwarnPreambleContent";
		public static string role => "header";

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// The relationship between a navigational warning and previous information relevant to its purpose.
	/// </summary>
	public class navwarnReferences : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(navwarnReferences);
		[JsonIgnore]
		public override string S100FC_name => "navwarnReferences";
		public static string role => "theReferences";

		#region Catalogue
		#endregion
	}

}

namespace S100FC.S124.FeatureAssociation
{
	using S100FC.S124.SimpleAttributes;
	using S100FC.S124.ComplexAttributes;

	/// <summary>
	/// a feature association for the binding between a geo feature and the cartographically positioned location for text.
	/// </summary>
	public class TextAssociation : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(TextAssociation);
		[JsonIgnore]
		public override string S100FC_name => "Text association";
		public static string[] roles => ["theCartographicText","thePositionProvider"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Association between a warning and the area impacted.
	/// </summary>
	public class areaAffected : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(areaAffected);
		[JsonIgnore]
		public override string S100FC_name => "Area Affected";
		public static string[] roles => ["impacts","affects"];

		#region Catalogue
		#endregion
	}

}

namespace S100FC.S124.InformationTypes
{
	using S100FC.S124.SimpleAttributes;
	using S100FC.S124.ComplexAttributes;

	/// <summary>
	/// References to for example a navigational warning, nautical publication or chart.
	/// </summary>
	public class References : S100FC.InformationType, IInformationBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(References);
		[JsonIgnore]
		public override string S100FC_name => "References";

		#region Attributes
		[JsonIgnore]
		public messageSeriesIdentifier?[] messageSeriesIdentifier {
			set { base.SetAttribute("messageSeriesIdentifier", value); }
			get { return base.GetAttributeValues<messageSeriesIdentifier>(nameof(messageSeriesIdentifier)); }
		}
		[JsonIgnore]
		public Boolean? noMessageOnHand {
			set { base.SetAttribute(new noMessageOnHand { value = value }); }
			get { return base.GetAttributeValue<noMessageOnHand>(nameof(noMessageOnHand))?.value; }
		}
		[JsonIgnore]
		public int? referenceCategory {
			set { base.SetAttribute(new referenceCategory { value = value }); }
			get { return base.GetAttributeValue<referenceCategory>(nameof(referenceCategory))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(messageSeriesIdentifier),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new messageSeriesIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(noMessageOnHand),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new noMessageOnHand(),
				},
				new attributeBindingDefinition {
					attribute = nameof(referenceCategory),
					lower = 1,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3],
					CreateInstance = () => new referenceCategory(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => References.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				new informationBindingDefinition {
					roleType = "association",
					role = "theWarning",
					association = "navwarnReferences",
					lower = 1,
					upper = 1,
					informationTypes = [nameof(NavwarnPreamble)],
					CreateInstance = () => new informationBinding<InformationAssociation.navwarnReferences>() {
						roleType = "association",
						role = "theWarning",
					},
				},
			];

		public static informationBinding<InformationAssociation.navwarnReferences> navwarnReferences => new informationBinding<InformationAssociation.navwarnReferences> {
			roleType = "association",
			role = "theWarning",
		};

		#endregion
	}

	/// <summary>
	/// Preamble information for warnings, notices and other types of messages in a navigational warning scheme.
	/// </summary>
	public class NavwarnPreamble : S100FC.InformationType, IInformationBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NavwarnPreamble);
		[JsonIgnore]
		public override string S100FC_name => "NAVWARN Preamble";

		#region Attributes
		[JsonIgnore]
		public affectedChartPublications?[] affectedChartPublications {
			set { base.SetAttribute("affectedChartPublications", value); }
			get { return base.GetAttributeValues<affectedChartPublications>(nameof(affectedChartPublications)); }
		}
		[JsonIgnore]
		public generalArea?[] generalArea {
			set { base.SetAttribute("generalArea", value); }
			get { return base.GetAttributeValues<generalArea>(nameof(generalArea)); }
		}
		[JsonIgnore]
		public locality?[] locality {
			set { base.SetAttribute("locality", value); }
			get { return base.GetAttributeValues<locality>(nameof(locality)); }
		}
		[JsonIgnore]
		public messageSeriesIdentifier? messageSeriesIdentifier {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<messageSeriesIdentifier>(nameof(messageSeriesIdentifier)); }
		}
		[JsonIgnore]
		public navwarnTitle?[] navwarnTitle {
			set { base.SetAttribute("navwarnTitle", value); }
			get { return base.GetAttributeValues<navwarnTitle>(nameof(navwarnTitle)); }
		}
		[JsonIgnore]
		public DateTime? cancellationDate {
			set { base.SetAttribute(new cancellationDate { value = value }); }
			get { return base.GetAttributeValue<cancellationDate>(nameof(cancellationDate))?.value; }
		}
		[JsonIgnore]
		public Boolean? intService {
			set { base.SetAttribute(new intService { value = value }); }
			get { return base.GetAttributeValue<intService>(nameof(intService))?.value; }
		}
		[JsonIgnore]
		public int? navwarnTypeGeneral {
			set { base.SetAttribute(new navwarnTypeGeneral { value = value }); }
			get { return base.GetAttributeValue<navwarnTypeGeneral>(nameof(navwarnTypeGeneral))?.value; }
		}
		[JsonIgnore]
		public DateTime? publicationTime {
			set { base.SetAttribute(new publicationTime { value = value }); }
			get { return base.GetAttributeValue<publicationTime>(nameof(publicationTime))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(affectedChartPublications),
					lower = 0,
					upper = 2147483647,
					order = 0,
					CreateInstance = () => new affectedChartPublications(),
				},
				new attributeBindingDefinition {
					attribute = nameof(generalArea),
					lower = 1,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new generalArea(),
				},
				new attributeBindingDefinition {
					attribute = nameof(locality),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new locality(),
				},
				new attributeBindingDefinition {
					attribute = nameof(messageSeriesIdentifier),
					lower = 1,
					upper = 1,
					order = 3,
					CreateInstance = () => new messageSeriesIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(navwarnTitle),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new navwarnTitle(),
				},
				new attributeBindingDefinition {
					attribute = nameof(cancellationDate),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new cancellationDate(),
				},
				new attributeBindingDefinition {
					attribute = nameof(intService),
					lower = 1,
					upper = 1,
					order = 6,
					CreateInstance = () => new intService(),
				},
				new attributeBindingDefinition {
					attribute = nameof(navwarnTypeGeneral),
					lower = 1,
					upper = 1,
					order = 7,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20],
					CreateInstance = () => new navwarnTypeGeneral(),
				},
				new attributeBindingDefinition {
					attribute = nameof(publicationTime),
					lower = 1,
					upper = 1,
					order = 8,
					CreateInstance = () => new publicationTime(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => NavwarnPreamble.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				new informationBindingDefinition {
					roleType = "association",
					role = "theReferences",
					association = "navwarnReferences",
					lower = 0,
					upper = 2147483647,
					informationTypes = [nameof(References)],
					CreateInstance = () => new informationBinding<InformationAssociation.navwarnReferences>() {
						roleType = "association",
						role = "theReferences",
					},
				},
			];

		public static informationBinding<InformationAssociation.navwarnReferences> navwarnReferences => new informationBinding<InformationAssociation.navwarnReferences> {
			roleType = "association",
			role = "theReferences",
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
		public spatialAccuracy? spatialAccuracy {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<spatialAccuracy>(nameof(spatialAccuracy)); }
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
					upper = 1,
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

namespace S100FC.S124.FeatureTypes
{
	using S100FC.S124.SimpleAttributes;
	using S100FC.S124.ComplexAttributes;
	using S100FC.S124.InformationTypes;

	/// <summary>
	/// Navigational warning information that may be geo-located.
	/// </summary>
	public class NavwarnPart : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NavwarnPart);
		[JsonIgnore]
		public override string S100FC_name => "NAVWARN Part";

		#region Attributes
		[JsonIgnore]
		public int? restriction {
			set { base.SetAttribute(new restriction { value = value }); }
			get { return base.GetAttributeValue<restriction>(nameof(restriction))?.value; }
		}
		[JsonIgnore]
		public fixedDateRange?[] fixedDateRange {
			set { base.SetAttribute("fixedDateRange", value); }
			get { return base.GetAttributeValues<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public warningInformation? warningInformation {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<warningInformation>(nameof(warningInformation)); }
		}
		[JsonIgnore]
		public featureName?[] featureName {
			set { base.SetAttribute("featureName", value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); }
		}
		[JsonIgnore]
		public featureReference?[] featureReference {
			set { base.SetAttribute("featureReference", value); }
			get { return base.GetAttributeValues<featureReference>(nameof(featureReference)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(restriction),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [7,8,14,25,27],
					CreateInstance = () => new restriction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(warningInformation),
					lower = 1,
					upper = 1,
					order = 2,
					CreateInstance = () => new warningInformation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new featureName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(featureReference),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new featureReference(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => NavwarnPart.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				new informationBindingDefinition {
					roleType = "association",
					role = "header",
					association = "navwarnPreambleContent",
					lower = 1,
					upper = 1,
					informationTypes = [nameof(NavwarnPreamble)],
					CreateInstance = () => new informationBinding<InformationAssociation.navwarnPreambleContent>() {
						roleType = "association",
						role = "header",
					},
				},
			];

		public static informationBinding<InformationAssociation.navwarnPreambleContent> navwarnPreambleContent => new informationBinding<InformationAssociation.navwarnPreambleContent> {
			roleType = "association",
			role = "header",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => NavwarnPart.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "affects",
					association = "areaAffected",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(NavwarnAreaAffected)],
					CreateInstance = () => new featureBinding<FeatureAssociation.areaAffected>() {
						roleType = "association",
						role = "affects",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "thePositionProvider",
					association = "TextAssociation",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(TextPlacement)],
					CreateInstance = () => new featureBinding<FeatureAssociation.TextAssociation>() {
						roleType = "association",
						role = "thePositionProvider",
					},
				},
			];

		public static featureBinding<FeatureAssociation.areaAffected> areaAffected(string role) => new featureBinding<FeatureAssociation.areaAffected> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("areaAffected") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.TextAssociation> TextAssociation(string role) => new featureBinding<FeatureAssociation.TextAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("TextAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.curve,Primitives.surface];
	}

	/// <summary>
	/// An area affected by some event marked by a navigational warning.
	/// </summary>
	public class NavwarnAreaAffected : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NavwarnAreaAffected);
		[JsonIgnore]
		public override string S100FC_name => "NAVWARN Area Affected";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => NavwarnAreaAffected.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => NavwarnAreaAffected.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "impacts",
					association = "areaAffected",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(NavwarnPart)],
					CreateInstance = () => new featureBinding<FeatureAssociation.areaAffected>() {
						roleType = "association",
						role = "impacts",
					},
				},
			];

		public static featureBinding<FeatureAssociation.areaAffected> areaAffected(string role) => new featureBinding<FeatureAssociation.areaAffected> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("areaAffected") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point,Primitives.curve,Primitives.surface];
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
		public int? scaleMinimum {
			set { base.SetAttribute(new scaleMinimum { value = value }); }
			get { return base.GetAttributeValue<scaleMinimum>(nameof(scaleMinimum))?.value; }
		}
		[JsonIgnore]
		public String? text {
			set { base.SetAttribute(new text { value = value }); }
			get { return base.GetAttributeValue<text>(nameof(text))?.value; }
		}
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
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(scaleMinimum),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new scaleMinimum(),
				},
				new attributeBindingDefinition {
					attribute = nameof(text),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new text(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textOffsetBearing),
					lower = 1,
					upper = 1,
					order = 2,
					CreateInstance = () => new textOffsetBearing(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textOffsetDistance),
					lower = 1,
					upper = 1,
					order = 3,
					CreateInstance = () => new textOffsetDistance(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textRotation),
					lower = 1,
					upper = 1,
					order = 4,
					CreateInstance = () => new textRotation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => TextPlacement.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => TextPlacement.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "theCartographicText",
					association = "TextAssociation",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(NavwarnPart)],
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
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

}

namespace S100FC.S124
{
	using System.Text.Json;
	using S100FC.S124.SimpleAttributes;
	using S100FC.S124.ComplexAttributes;
	using S100FC.S124.InformationAssociation;
	using S100FC.S124.FeatureAssociation;
	using S100FC.S124.InformationTypes;
	using S100FC.S124.FeatureTypes;

	public class Summary : ISummary
	{
		public static string Name => "Navigational Warnings";
		public static string Scope => "Global";
		public static string ProductId => "S-124";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-07-10", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["chartAffected","fixedDateRange","information","locationName","messageSeriesIdentifier","navwarnTitle","warningInformation","featureReference","featureName","horizontalPositionUncertainty","spatialAccuracy","affectedChartPublications","generalArea","locality"];
		public static string[] InformationAssociationTypes => ["navwarnPreambleContent","navwarnReferences"];
		public static string[] FeatureAssociationTypes => ["TextAssociation","areaAffected"];
		public static string[] InformationTypes => ["References","NavwarnPreamble","SpatialQuality"];
		public static string[] FeatureTypes => ["NavwarnPart","NavwarnAreaAffected","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => [],
			Primitives.point => ["NavwarnPart","NavwarnAreaAffected","TextPlacement"],
			Primitives.pointSet => [],
			Primitives.curve => ["NavwarnPart","NavwarnAreaAffected"],
			Primitives.surface => ["NavwarnPart","NavwarnAreaAffected"],
			_ => throw new InvalidOperationException(),
		};
	}

	public static class Extensions {
		public static informationBinding CreateInformationBinding(string informationType, string association) => $"{informationType}::{association}" switch {
			"References::navwarnReferences" => References.navwarnReferences,
			"NavwarnPreamble::navwarnReferences" => NavwarnPreamble.navwarnReferences,
			"NavwarnPart::navwarnPreambleContent" => NavwarnPart.navwarnPreambleContent,
			"" => throw new KeyNotFoundException(),
			_ => throw new KeyNotFoundException(),
		};

		public static featureBinding CreateFeatureBinding(string featureType, string association, string role) => $"{featureType}::{association}" switch {
			"NavwarnPart::areaAffected" => NavwarnPart.areaAffected(role),
			"NavwarnPart::TextAssociation" => NavwarnPart.TextAssociation(role),
			"NavwarnAreaAffected::areaAffected" => NavwarnAreaAffected.areaAffected(role),
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.navwarnPreambleContent>), typeDiscriminator: "navwarnPreambleContent"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.navwarnReferences>), typeDiscriminator: "navwarnReferences"));
				}
				if (typeInfo.Type == typeof(S100FC.featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.TextAssociation>), typeDiscriminator: "TextAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.areaAffected>), typeDiscriminator: "areaAffected"));
				}
				if (typeInfo.Type == typeof(S100FC.attributeBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(atoNNumber), typeDiscriminator: "atoNNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(interoperabilityIdentifier), typeDiscriminator: "interoperabilityIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(name), typeDiscriminator: "name"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameUsage), typeDiscriminator: "nameUsage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(year), typeDiscriminator: "year"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(warningType), typeDiscriminator: "warningType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(warningNumber), typeDiscriminator: "warningNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nameOfSeries), typeDiscriminator: "nameOfSeries"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(nationality), typeDiscriminator: "nationality"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(agencyResponsibleForProduction), typeDiscriminator: "agencyResponsibleForProduction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(headline), typeDiscriminator: "headline"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileReference), typeDiscriminator: "fileReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileLocator), typeDiscriminator: "fileLocator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(localityIdentifier), typeDiscriminator: "localityIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayStart), typeDiscriminator: "timeOfDayStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(timeOfDayEnd), typeDiscriminator: "timeOfDayEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateStart), typeDiscriminator: "dateStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateEnd), typeDiscriminator: "dateEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(lastNoticeDate), typeDiscriminator: "lastNoticeDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(editionDate), typeDiscriminator: "editionDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(chartPlanNumber), typeDiscriminator: "chartPlanNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(chartNumber), typeDiscriminator: "chartNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(publicationAffected), typeDiscriminator: "publicationAffected"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(internationalChartAffected), typeDiscriminator: "internationalChartAffected"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(chartPublicationIdentifier), typeDiscriminator: "chartPublicationIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(intService), typeDiscriminator: "intService"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cancellationDate), typeDiscriminator: "cancellationDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(referenceCategory), typeDiscriminator: "referenceCategory"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(noMessageOnHand), typeDiscriminator: "noMessageOnHand"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scaleMinimum), typeDiscriminator: "scaleMinimum"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(text), typeDiscriminator: "text"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textOffsetBearing), typeDiscriminator: "textOffsetBearing"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textOffsetDistance), typeDiscriminator: "textOffsetDistance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textRotation), typeDiscriminator: "textRotation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(restriction), typeDiscriminator: "restriction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(language), typeDiscriminator: "language"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(publicationTime), typeDiscriminator: "publicationTime"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(navwarnTypeDetails), typeDiscriminator: "navwarnTypeDetails"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(navwarnTypeGeneral), typeDiscriminator: "navwarnTypeGeneral"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyFixed), typeDiscriminator: "uncertaintyFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(qualityOfHorizontalMeasurement), typeDiscriminator: "qualityOfHorizontalMeasurement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(chartAffected), typeDiscriminator: "chartAffected"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fixedDateRange), typeDiscriminator: "fixedDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(information), typeDiscriminator: "information"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(locationName), typeDiscriminator: "locationName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(messageSeriesIdentifier), typeDiscriminator: "messageSeriesIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(navwarnTitle), typeDiscriminator: "navwarnTitle"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(warningInformation), typeDiscriminator: "warningInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureReference), typeDiscriminator: "featureReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureName), typeDiscriminator: "featureName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalPositionUncertainty), typeDiscriminator: "horizontalPositionUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(spatialAccuracy), typeDiscriminator: "spatialAccuracy"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(affectedChartPublications), typeDiscriminator: "affectedChartPublications"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(generalArea), typeDiscriminator: "generalArea"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(locality), typeDiscriminator: "locality"));
				}
			});
			jsonSerializerOptions.TypeInfoResolver = resolver;
			return jsonSerializerOptions;
		}
	}
}
