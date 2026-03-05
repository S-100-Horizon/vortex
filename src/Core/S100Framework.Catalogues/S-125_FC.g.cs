using System;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace S100FC.S125.SimpleAttributes
{
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
	/// A purpose of a virtual AIS Aid to Navigation.
	/// </summary>
	public class virtualAISAidToNavigationType : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(virtualAISAidToNavigationType);
		[JsonIgnore]
		public override string S100FC_name => "Virtual AIS Aid to Navigation Type";
		public static listedValue[] listedValues => [
				new listedValue("North Cardinal", "Indicates that it should be passed to the north side of the aid.",1),
				new listedValue("East Cardinal", "Indicates that it should be passed to the east side of the aid.",2),
				new listedValue("South Cardinal", "Indicates that it should be passed to the south side of the aid.",3),
				new listedValue("West Cardinal", "Indicates that it should be passed to the west side of the aid.",4),
				new listedValue("Port Lateral", "Indicates the port boundary of a navigational channel or suggested route when proceeding in the conventional direction of buoyage.",5),
				new listedValue("Starboard Lateral", "Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the conventional direction of buoyage.",6),
				new listedValue("Preferred Channel to Port", "At a point where a channel divides, when proceeding in the conventional direction of buoyage, the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.",7),
				new listedValue("Preferred Channel to Starboard", "At a point where a channel divides, when proceeding in the conventional direction of buoyage, the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.",8),
				new listedValue("Isolated Danger", "A mark used alone to indicate a dangerous reef or shoal. The mark may be passed on either hand.",9),
				new listedValue("Safe Water", "Indicates that there is navigable water around the mark.",10),
				new listedValue("Special Purpose", "A special purpose aid is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notice to Mariners.",11),
				new listedValue("New Danger Marking", "A mark used to indicate the existence of a recently identified new danger, such as a wreck.",12),
			];

		public static implicit operator virtualAISAidToNavigationType(int? value) => new virtualAISAidToNavigationType { value = value };
	}

	/// <summary>
	/// The process of deploying and activating a new Aid to Navigation (AtoN), ensuring that it is properly installed and operational.
	/// </summary>
	public class atonCommissioning : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(atonCommissioning);
		[JsonIgnore]
		public override string S100FC_name => "Aton Commissioning";
		public static listedValue[] listedValues => [
				new listedValue("Buoy Establishment", "A new buoy has been or will be established.",1),
				new listedValue("Light Establishment", "A new light has been or will be established.",2),
				new listedValue("Beacon Establishment", "A new beacon has been or will be established.",3),
				new listedValue("Audible Signal Establishment", "A new audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be established.",4),
				new listedValue("Fog Signal Establishment", "A new fog signal has been or will be established.",5),
				new listedValue("AIS Transmitter Establishment", "A new AIS site has been or will be established.",6),
				new listedValue("V-AIS Establishment", "A new V-AIS has been or will be established.",7),
				new listedValue("RACON Establishment", "A new RACON has been or will be established.",8),
				new listedValue("DGPS Station Establishment", "A new DGPS station has been or will be established.",9),
				new listedValue("ELORAN Station Establishment", "A new eLORAN station has been or will be established.",10),
				new listedValue("DGLONASS Station Establishment", "A new DGLONASS station has been or will be established.",11),
				new listedValue("E-Chayka Station Establishment", "A new e-Chayka station has been or will be established.",12),
				new listedValue("EGNOS Station Establishment", "A new EGNOS station has been or will be established.",13),
			];

		public static implicit operator atonCommissioning(int? value) => new atonCommissioning { value = value };
	}

	/// <summary>
	/// The process of decommissioning and physically removing an AtoN from its designated location, either temporarily or permanently.
	/// </summary>
	public class atonRemoval : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(atonRemoval);
		[JsonIgnore]
		public override string S100FC_name => "Aton Removal";
		public static listedValue[] listedValues => [
				new listedValue("Buoy Removal", "Buoy has been or will be permanently removed from service.",1),
				new listedValue("Buoy Temporary Removal", "Buoy has been or will be temporarily removed from service.",2),
				new listedValue("Light Removal", "Light has been or will be permanently removed from service.",3),
				new listedValue("Light Temporary Removal", "Light has been or will be temporarily removed from service.",4),
				new listedValue("Beacon Removal", "Beacon has been or will be permanently removed from service.",5),
				new listedValue("Beacon Temporary Removal", "Beacon has been or will be temporarily removed from service.",6),
				new listedValue("Fog Signal Removal", "Fog signal has been or will be permanently removed from service.",7),
				new listedValue("Fog Signal Temporary Removal", "Fog signal has been or will be temporarily removed from service.",8),
				new listedValue("Audible Signal Removal", "Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be permanently removed from service.",9),
				new listedValue("Audible Signal Temporary Removal", "Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be temporarily removed from service.",10),
				new listedValue("AIS Transmitter Removal", "AIS transmitter has been or will be permanently removed from service.",11),
				new listedValue("AIS Transmitter Temporary Removal", "AIS transmitter has been or will be temporarily removed from service.",12),
				new listedValue("V-AIS Removal", "V-AIS has been or will be permanently removed from service.",13),
				new listedValue("V-AIS Temporary Removal", "V-AIS has been or will be temporarily removed from service.",14),
				new listedValue("RACON Removal", "RACON has been or will be permanently removed from service.",15),
				new listedValue("RACON Temporary Removal", "RACON has been or will be temporarily removed from service.",16),
				new listedValue("DGPS Station Removal", "DGPS station has been or will be permanently removed from service.",17),
				new listedValue("DGPS Station Temporary Removal", "DGPS station has been or will be temporarily removed from service.",18),
				new listedValue("EGNOS Station Removal", "EGNOS station has been or will be permanently removed from service.",19),
				new listedValue("EGNOS Station Temporary Removal", "EGNOS station has been or will be temporarily removed from service.",20),
				new listedValue("LORAN C Station Removal", "LORAN C station has been or will be permanently removed from service.",21),
				new listedValue("LORAN C Station Temporary Removal", "LORAN C station has been or will be temporarily removed from service.",22),
				new listedValue("ELORAN Station Temporary Removal", "The eLORAN station has been or will be temporarily removed from service.",24),
				new listedValue("Chayka Station Removal", "Chayka station has been or will be permanently removed from service.",25),
				new listedValue("Chayka Station Temporary Removal", "Chayka station has been or will be temporarily removed from service.",26),
				new listedValue("E-Chayka Station Removal", "The e-Chayka station has been or will be permanently removed from service.",27),
			];

		public static implicit operator atonRemoval(int? value) => new atonRemoval { value = value };
	}

	/// <summary>
	/// The act of swapping an existing AtoN with a new or upgraded unit, either due to maintenance needs or technological improvements.
	/// </summary>
	public class atonReplacement : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(atonReplacement);
		[JsonIgnore]
		public override string S100FC_name => "Aton Replacement";
		public static listedValue[] listedValues => [
				new listedValue("Buoy Change", "The characteristics of the buoy have been or will be changed.",1),
				new listedValue("Buoy Temporary Change", "The characteristics of the buoy have been or will be temporarily changed.",2),
				new listedValue("Light Change", "The characteristics of the light have been or will be changed.",3),
				new listedValue("Light Temporary Change", "The characteristics of the light have been or will be temporarily changed.",4),
				new listedValue("Sector Light Change", "The characteristics of the sector light have been or will be changed.",5),
				new listedValue("Sector Light Temporary Change", "The characteristics of the sector light have been or will be temporarily changed.",6),
				new listedValue("Beacon Change", "The characteristics of the beacon have been or will be changed.",7),
				new listedValue("Beacon Temporary Change", "The characteristics of the beacon have been or will be temporarily changed.",8),
				new listedValue("Fog Signal Change", "The characteristics of the fog signal have been or will be changed.",9),
				new listedValue("Fog Signal Temporary Change", "The characteristics of the fog signal have been or will be temporarily changed.",10),
				new listedValue("Audible Signal Change", "The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be changed.",11),
				new listedValue("Audible Signal Temporary Change", "The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be temporarily changed.",12),
				new listedValue("V-AIS Change", "The characteristics of the V-AIS have been or will be changed.",13),
				new listedValue("V-AIS Temporary Change", "The characteristics of the V-AIS have been or will be temporarily changed.",14),
				new listedValue("RACON Change", "The characteristics of the RACON have been or will be changed.",15),
				new listedValue("RACON Temporary Change", "The characteristics of the RACON have been or will be temporarily changed.",16),
			];

		public static implicit operator atonReplacement(int? value) => new atonReplacement { value = value };
	}

	/// <summary>
	/// Modifications or updates to fixed AtoNs, such as lighthouses or beacons, which are permanently positioned.
	/// </summary>
	public class fixedAtonChange : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(fixedAtonChange);
		[JsonIgnore]
		public override string S100FC_name => "Fixed Aton Change";
		public static listedValue[] listedValues => [
				new listedValue("Beacon Missing", "No beacon at the advertised position.",1),
				new listedValue("Beacon Damaged", "The beacon has sustained damage due to external factors (wind, sea state, collision with a vessel).",2),
				new listedValue("Lighted Beacon - Light Unlit", "The light of the beacon is extinguished.",3),
				new listedValue("Lighted Beacon - Light Unreliable", "The operation of the light on the beacon is unreliable due to technical problems.",4),
				new listedValue("Lighted Beacon - Light Not Synchronized", "The light on the beacon is no longer synchronized with another light or group of lights.",5),
				new listedValue("Lighted Beacon - Light Damaged", "The light on the beacon is damaged due to external factors (wind, sea state, collision with a vessel).",6),
				new listedValue("Beacon Topmark Missing", "The topmark of the beacon is missing.",7),
				new listedValue("Beacon Topmark Damaged", "The topmark of the beacon is damaged due to external factors (wind, sea state, collision with a vessel).",8),
				new listedValue("Beacon Daymark Unreliable", "Colour of the beacon daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",9),
				new listedValue("Floodlit Beacon - Unlit", "The flood light illuminating the beacon is inoperative.",10),
				new listedValue("Beacon Restored To Normal", "The beacon has been restored to normal condition.",11),
			];

		public static implicit operator fixedAtonChange(int? value) => new fixedAtonChange { value = value };
	}

	/// <summary>
	/// A short range (up to 2km) type of directional light. Sodium lighting gives a yellow background to a screen on which a vertical black line will be seen by an observer on the centre line.
	/// </summary>
	public class moireEffect : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(moireEffect);
		[JsonIgnore]
		public override string S100FC_name => "Moire Effect";

		public static implicit operator moireEffect(Boolean? value) => new moireEffect { value = value };
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
	/// Adjustments or replacements related to floating AtoNs, such as buoys, which are anchored but can move with water currents.
	/// </summary>
	public class floatingAtonChange : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(floatingAtonChange);
		[JsonIgnore]
		public override string S100FC_name => "Floating Aton Change";
		public static listedValue[] listedValues => [
				new listedValue("Buoy Adrift", "The buoy is no longer secured to its moorings and is adrift.",1),
				new listedValue("Buoy Damaged", "The buoy has been damaged due to external factors (wind, sea state, collision with a vessel).",2),
				new listedValue("Buoy Daymark Unreliable", "Colour of the buoy daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",3),
				new listedValue("Buoy Destroyed", "The buoy has suffered extensive damage and is not useable.",4),
				new listedValue("Buoy Missing", "No buoy at its advertised/charted position or in the vicinity.",5),
				new listedValue("Buoy Move", "The buoy has been or will be moved intentionally.",6),
				new listedValue("Buoy off Position", "The buoy has been dragged off its advertised position due to wind or current affecting the mooring system.",7),
				new listedValue("Buoy Re-established", "The re-establishment of a buoy which was previously announced either destroyed or temporarily removed.",8),
				new listedValue("Buoy Restored to Normal", "The buoy has been restored to normal condition.",9),
				new listedValue("Buoy Topmark Damaged", "The topmark of the buoy is damaged due to external factors (wind, sea state, collision with a vessel).",10),
				new listedValue("Buoy Topmark Missing", "The topmark of the buoy is missing.",11),
				new listedValue("Buoy Will Be Withdrawn", "The buoy has been scheduled for removal from service for a fixed term.",12),
				new listedValue("Buoy Withdrawn", "The buoy has been removed from service for a fixed term.",13),
				new listedValue("Buoy Decommissioned for Winter", "A buoy which remains in the water over winter but which is declared unreliable (may be impacted by ice movement).",14),
				new listedValue("Lifted for Winter", "An object that has been removed for the Winter season.",15),
				new listedValue("Light Buoy - Light Damaged", "The light on the buoy is damaged due to external factors (wind, sea state, collision with a vessel).",16),
				new listedValue("Light Buoy - Light Not Synchronized", "The light on the buoy is no longer synchronized with another light or group of lights.",17),
				new listedValue("Light Buoy - Light Unlit", "The light on the buoy is extinguished.",18),
				new listedValue("Light Buoy - Light Unreliable", "The operation of the light on the buoy is unreliable due to technical problems.",19),
				new listedValue("Marine Aids to Navigation Unreliable", "The position or status of Marine Aids to Navigation, over an extensive area, is unreliable due to a natural event (freshet, storm surge, flooding).",20),
				new listedValue("Buoy Commissioned for Navigation Season", "A buoy which was in ice over the winter and has been verified undamaged and in advertised position for the navigational season",21),
				new listedValue("Buoy Replaced by Winter Spar", "A buoy which has been removed and it's location is now marked by a winter spar buoy.",22),
				new listedValue("Seasonal Decommissioning Complete", "The completion of the process to remove summer buoys (and possibly replace some with winter spar buoys).",23),
				new listedValue("Seasonal Decommissioning in Progress", "The commencement of the process to remove summer buoys (and possibly replace some with winter spar buoys).",24),
				new listedValue("Seasonal Commissioning Complete", "The completion of the process to place summer buoys (and the removal of any winter spar buoys).",25),
				new listedValue("Seasonal Commissioning in Progress", "The commencement of the process to place summer buoys (and the removal of any winter spar buoys).",26),
			];

		public static implicit operator floatingAtonChange(int? value) => new floatingAtonChange { value = value };
	}

	/// <summary>
	/// Indicates whether specific actions or maintenance must be performed based on the season (for example, repositioning, removal, or other adjustments).
	/// </summary>
	public class seasonalActionRequired : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(seasonalActionRequired);
		[JsonIgnore]
		public override string S100FC_name => "Seasonal Action Required";

		public static implicit operator seasonalActionRequired(String? value) => new seasonalActionRequired { value = value };
	}

	/// <summary>
	/// Any modification to an AtoN that uses sound signals, such as foghorns or bells, to assist in navigation under low visibility conditions.
	/// </summary>
	public class audibleSignalAtonChange : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(audibleSignalAtonChange);
		[JsonIgnore]
		public override string S100FC_name => "Audible Signal Aton Change";
		public static listedValue[] listedValues => [
				new listedValue("Audible Signal Out Of Service", "The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is inoperative.",1),
				new listedValue("Fog Signal Out Of Service", "The fog signal is inoperative.",2),
				new listedValue("Audible Signal Operating Properly", "The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is operating as advertised.",3),
				new listedValue("Fog Signal Operating Properly", "The fog signal is operating as advertised.",4),
			];

		public static implicit operator audibleSignalAtonChange(int? value) => new audibleSignalAtonChange { value = value };
	}

	/// <summary>
	/// The indication of an element of a signal sequence being a period of light/sound or eclipse/silence.
	/// </summary>
	public class signalStatus : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(signalStatus);
		[JsonIgnore]
		public override string S100FC_name => "Signal Status";
		public static listedValue[] listedValues => [
				new listedValue("Lit/Sound", "The indication of an element of a signal sequence being a period of light or sound.",1),
				new listedValue("Eclipsed/Silent", "The indication of an element of a signal sequence being a period of eclipse or silence.",2),
			];

		public static implicit operator signalStatus(int? value) => new signalStatus { value = value };
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
	/// Updates or modifications to light-emitting AtoNs, including changing light characteristics, intensity, or operational status.
	/// </summary>
	public class lightedAtonChange : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(lightedAtonChange);
		[JsonIgnore]
		public override string S100FC_name => "Lighted Aton Change";
		public static listedValue[] listedValues => [
				new listedValue("Light Unlit", "The light is extinguished.",1),
				new listedValue("Light Unreliable", "The light is unreliable due to technical problems.",2),
				new listedValue("Light Re-Establishment", "The re-establishment of a light which was previously announced as either destroyed or temporarily removed.",3),
				new listedValue("Light Range Reduced", "The nominal range of the light is less than the advertised range.",4),
				new listedValue("Light Without Rhythm", "Due to technical problems the light has no more rhythm and is in fixed light mode.",5),
				new listedValue("Light Out Of Synchronization", "The light is no longer synchronized with another light or group of lights.",6),
				new listedValue("Light Daymark Unreliable", "The light daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",7),
				new listedValue("Light Operating Properly", "The light is operating as advertised",8),
				new listedValue("Sector Light - Sector Obscured", "The light sector has been fully or partly obscured.",9),
				new listedValue("Front Light Unlit", "The front leading light is extinguished. / The front range light is extinguished.",10),
				new listedValue("Rear Light Unlit", "The rear leading light is extinguished. / The rear range light is extinguished.",11),
				new listedValue("Front Light Unreliable", "The operation of the front leading light is unreliable due to technical problems. / The operation of the front range light is unreliable due to technical problems.",12),
				new listedValue("Rear Light Unreliable", "The operation of the rear leading light is unreliable due to technical problems. / The operation of the rear range light is unreliable due to technical problems.",13),
				new listedValue("Front Light Range Reduced", "The nominal range of the front leading light is reduced. / The nominal range of the front range light is reduced.",14),
				new listedValue("Rear Light Range Reduced", "The nominal range of the rear leading light is reduced. / The nominal range of the rear range light is reduced.",15),
				new listedValue("Front Light Without Rhythm", "Due to technical problems front leading light has no rhythm and is in fixed light mode. / Due to technical problems front range light has no rhythm and is in fixed light mode.",16),
				new listedValue("Rear Light Without Rhythm", "Due to technical problems, the rear leading light has no rhythm and is in fixed light mode. / Due to technical problems rear range light has no rhythm and is in fixed light mode.",17),
				new listedValue("Front and Rear Lights out of Synchronization", "The synchronization of the leading lights is abnormal / The synchronization of the range lights is abnormal.",18),
				new listedValue("Front Beacon Unreliable", "The front leading beacon is damaged, obscured or missing. / The front range beacon is damaged, obscured or missing.",19),
				new listedValue("Rear Beacon Unreliable", "The rear leading beacon is damaged, obscured or missing. / The rear range beacon is damaged, obscured or missing",20),
				new listedValue("Front Light is Operating Properly", "The front leading light is operating as advertised. / The front range light is operating as advertised.",21),
				new listedValue("Rear Light is Operating Properly", "The rear leading light is operating as advertised. / The rear range light is operating as advertised.",22),
				new listedValue("Front Beacon Restored to Normal", "The front leading beacon has been restored to normal condition. / The front range beacon has been restored to normal condition.",23),
				new listedValue("Rear Beacon Restored to Normal", "The rear leading beacon has been restored to normal condition. / The rear range beacon has been restored to normal condition.",24),
			];

		public static implicit operator lightedAtonChange(int? value) => new lightedAtonChange { value = value };
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
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector line length specifies the displayed length of the line, in ground units, defining the limit of the sector.
	/// </summary>
	public class sectorLineLength : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorLineLength);
		[JsonIgnore]
		public override string S100FC_name => "Sector Line Length";

		public static implicit operator sectorLineLength(int? value) => new sectorLineLength { value = value };
	}

	/// <summary>
	/// The time occupied by a single instance of light/sound or eclipse/silence in a signal sequence.
	/// </summary>
	public class signalDuration : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(signalDuration);
		[JsonIgnore]
		public override string S100FC_name => "Signal Duration";

		public static implicit operator signalDuration(decimal? value) => new signalDuration { value = value };
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector bearing specifies the limit of the sector.
	/// </summary>
	public class sectorBearing : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorBearing);
		[JsonIgnore]
		public override string S100FC_name => "Sector Bearing";

		public static implicit operator sectorBearing(decimal? value) => new sectorBearing { value = value };
	}

	/// <summary>
	/// The distance between two successive peaks (or other points of identical phase) on an electromagnetic wave.
	/// </summary>
	public class waveLengthValue : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(waveLengthValue);
		[JsonIgnore]
		public override string S100FC_name => "Wave Length Value";

		public static implicit operator waveLengthValue(decimal? value) => new waveLengthValue { value = value };
	}

	/// <summary>
	/// The band code character of the electromagnetic spectrum within which radar wave lengths lie.
	/// </summary>
	public class radarBand : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(radarBand);
		[JsonIgnore]
		public override string S100FC_name => "Radar Band";

		public static implicit operator radarBand(String? value) => new radarBand { value = value };
	}

	/// <summary>
	/// The number of features of identical character that exist as a co-located group.
	/// </summary>
	public class numberOfFeatures : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(numberOfFeatures);
		[JsonIgnore]
		public override string S100FC_name => "Number of Features";

		public static implicit operator numberOfFeatures(int? value) => new numberOfFeatures { value = value };
	}

	/// <summary>
	/// The number of features of identical character that exist as a co-located group is or is not known.
	/// </summary>
	public class multiplicityKnown : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(multiplicityKnown);
		[JsonIgnore]
		public override string S100FC_name => "Multiplicity Known";

		public static implicit operator multiplicityKnown(Boolean? value) => new multiplicityKnown { value = value };
	}

	/// <summary>
	/// An indication that the default radius of a sector arc is to be extended by 5mm.
	/// </summary>
	public class sectorArcExtension : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorArcExtension);
		[JsonIgnore]
		public override string S100FC_name => "Sector Arc Extension";

		public static implicit operator sectorArcExtension(Boolean? value) => new sectorArcExtension { value = value };
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
	/// Modifications to electronic or digital AtoNs, such as AIS (Automatic Identification System) AtoNs, virtual AtoNs, or remote-controlled systems.
	/// </summary>
	public class electronicAtonChange : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(electronicAtonChange);
		[JsonIgnore]
		public override string S100FC_name => "Electronic Aton Change";
		public static listedValue[] listedValues => [
				new listedValue("AIS Transmitter Out Of Service", "The terrestrial AIS transmitter is inoperative due to a technical issue.",1),
				new listedValue("AIS Transmitter Unreliable", "The terrestrial AIS transmitter is unreliable due to a technical issue or maintenance.",2),
				new listedValue("AIS Transmitter Operating Properly", "The terrestrial AIS transmitter is operating as advertised.",3),
				new listedValue("V-AIS Out Of Service", "Virtual AIS aid to navigation is extinguished.",4),
				new listedValue("V-AIS Unreliable", "Virtual AIS aid is unreliable due to a technical issue or maintenance.",5),
				new listedValue("V-AIS Operating Properly", "Virtual AIS aid to navigation is operating as advertised.",6),
				new listedValue("RACON Out Of Service", "The RACON is inoperative.",7),
				new listedValue("RACON Unreliable", "The RACON is unreliable due to a technical issue or maintenance.",8),
				new listedValue("RACON Operating Properly", "The RACON is operating as advertised.",9),
				new listedValue("DGPS Out Of Service", "The DGPS station is inoperative due to a technical issue.",10),
				new listedValue("DGPS Operating Properly", "The DGPS station is operating as advertised.",11),
				new listedValue("DGPS Unreliable", "The DGPS station is unreliable due to a technical issue or maintenance.",12),
				new listedValue("LORAN C - Operating Properly", "The LORAN C station is operating as advertised.",13),
				new listedValue("LORAN C - Unreliable", "The LORAN C station is unreliable due to a technical issue or maintenance.",14),
				new listedValue("LORAN C - Out Of Service", "The LORAN C station is inoperative due to a technical issue.",15),
				new listedValue("ELORAN Operating Properly", "The eLORAN station is operating as advertised.",16),
				new listedValue("ELORAN Unreliable", "The eLORAN station is unreliable due to a technical issue or maintenance.",17),
				new listedValue("ELORAN Out Of Service", "The eLORAN station is inoperative due to a technical issue.",18),
				new listedValue("DGLONASS Operating Properly", "The DGLONASS station is operating as advertised.",19),
				new listedValue("DGLONASS Unreliable", "The DGLONASS station is unreliable due to a technical issue or maintenance.",20),
				new listedValue("DGLONASS Out Of Service", "The DGLONASS station is inoperative due to a technical issue.",21),
				new listedValue("Chayka Operating Properly", "The Chayka station is operating as advertised.",22),
				new listedValue("Chayka Unreliable", "The Chayka station is unreliable due to a technical issue or maintenance.",23),
				new listedValue("Chayka Out Of Service", "The Chayka station is inoperative due to a technical issue.",24),
				new listedValue("E-Chayka Operating Properly", "The e-Chayka station is operating as advertised.",25),
				new listedValue("E-Chayka Unreliable", "The e-Chayka station is unreliable due to a technical issue or maintenance.",26),
				new listedValue("E-Chayka Out Of Service", "The e-Chayka station is inoperative due to a technical issue.",27),
				new listedValue("EGNOS Operating Properly", "The EGNOS station is operating as advertised.",28),
				new listedValue("EGNOS Unreliable", "The EGNOS station is unreliable due to a technical issue or maintenance.",29),
				new listedValue("EGNOS Out Of Service", "The EGNOS station is inoperative due to a technical issue.",30),
			];

		public static implicit operator electronicAtonChange(int? value) => new electronicAtonChange { value = value };
	}

	/// <summary>
	/// Named associations between two or more aids to navigation and/or navigationally relevant features.
	/// </summary>
	public class categoryOfAssociation : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfAssociation);
		[JsonIgnore]
		public override string S100FC_name => "Category of Association";
		public static listedValue[] listedValues => [
				new listedValue("Channel Markings", "A group of channel marks which indicate channel limits.",1),
				new listedValue("Danger Markings", "One of more aids to navigation and the danger(s) that are marked.",2),
			];
	}

	/// <summary>
	/// Named aggregations between two or more aids to navigation and/or navigationally relevant features.
	/// </summary>
	public class categoryOfAggregation : S100FC.CodeListAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfAggregation);
		[JsonIgnore]
		public override string S100FC_name => "Category of Aggregation";
		public static listedValue[] listedValues => [
				new listedValue("Leading Line", "A line passing through two or more clearly defined charted objects, and along which a vessel can approach safely.",1),
				new listedValue("Measured Distance", "A course at sea, whose ends are indicated by ranges ashore, and whose length has been accurately measured for determining the speed of vessels.",3),
				new listedValue("Range System", "Two or more features in the same horizontal direction, particularly those features so placed as navigational aids to mark any line of importance to vessels, as a channel. The one nearest the observer is the front mark and the one farthest from the observer is the rear mark.",2),
			];
	}

	/// <summary>
	/// The Maritime Mobile Service Identity (MMSI) Code is formed of a series of nine digits which are transmitted over the radio path in order to uniquely identify ship stations, ship earth stations, coast stations, coast earth stations, and group calls. These identities are formed in such a way that the identity or part thereof can be used by telephone and telex subscribers connected to the general telecommunications network principally to call ships automatically.
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
	/// Classification of fixed installation buoy.
	/// </summary>
	public class categoryOfInstallationBuoy : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfInstallationBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Category of Installation Buoy";
		public static listedValue[] listedValues => [
				new listedValue("Catenary Anchor Leg Mooring", "Incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.",1),
				new listedValue("Catenary Anchor Leg Mooring", "Incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.",2),
			];

		public static implicit operator categoryOfInstallationBuoy(int? value) => new categoryOfInstallationBuoy { value = value };
	}

	/// <summary>
	/// The distinct character, such as fixed, flashing, or occulting, which is given to each light to avoid confusion with neighbouring ones.
	/// </summary>
	public class lightCharacteristic : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(lightCharacteristic);
		[JsonIgnore]
		public override string S100FC_name => "Light Characteristic";
		public static listedValue[] listedValues => [
				new listedValue("Fixed", "A signal light that shows continuously, in any given direction, with constant luminous intensity and colour.",1),
				new listedValue("Flashing", "A rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.",2),
				new listedValue("Long-Flashing", "A single-flashing light in which an appearance of light of not less than two seconds duration is regularly repeated.",3),
				new listedValue("Quick-Flashing", "A rhythmic light in which flashes are repeated at a rate of not less than 50 flashes per minutes but less than 80 flashes per minutes. It may be: - Continuous quick-flashing: A quick-flashing light in which a flash is regularly repeated. - Group quick-flashing: A quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.",4),
				new listedValue("Very Quick-Flashing", "A rhythmic light in which flashes are repeated at a rate of not less than 80 flashes per minute but less than 160 flashes per minute. It may be:- Continuous very quick-flashing: A very quick-flashing light in which a flash is regularly repeated.- Group very quick-flashing: A very quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.",5),
				new listedValue("Continuous Ultra Quick-Flashing", "A rhythmic light in which flashes are regularly repeated at a rate of not less than 160 flashes per minute.",6),
				new listedValue("Isophased", "A light with all durations of light and darkness equal.",7),
				new listedValue("Occulting", "A rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration. It may be:  - Single-occulting: An occulting light in which an eclipse is regularly repeated.  - Group-occulting: An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated.  - Composite group-occulting: An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.",8),
				new listedValue("Interrupted Quick Flashing", "A quick light in which the sequence of flashes is interrupted by regularly repeated eclipses of constant and long duration.",9),
				new listedValue("Interrupted Very Quick Flashing", "A light in which the very rapid alterations of light and darkness are interrupted at regular intervals by eclipses of long duration.",10),
				new listedValue("Interrupted Ultra Quick-Flashing", "A light in which the ultra quick flashes (160 or more per minute) are interrupted at regular intervals by eclipses of long duration.",11),
				new listedValue("Morse", "A rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.",12),
				new listedValue("Fixed and Flash", "A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.",13),
				new listedValue("Flash and Long-Flash", "A rhythmic light in which a flashing light is combined with a long-flashing light of higher luminous intensity.",14),
				new listedValue("Occulting and Flash", "A rhythmic light in which an occulting light is combined with a flashing light of higher luminous intensity.",15),
				new listedValue("Fixed and Long-Flash", "A rhythmic light in which a fixed light is combined with a long-flashing light of higher luminous intensity.",16),
				new listedValue("Occulting Alternating", "An alternating light in which the total duration of light in each period is clearly longer than the total duration of darkness and in which the intervals of darkness (occultations) are all of equal duration.",17),
				new listedValue("Long-Flash Alternating", "An alternating single-flashing light in which an appearance of light of not less than two seconds duration is regularly repeated.",18),
				new listedValue("Flash Alternating", "An alternating rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.",19),
				new listedValue("Group Alternating", "Occulting light in which the occultations are combined in groups, each group including the same number of occultations, and in which the groups are repeated at regular intervals.",20),
				new listedValue("Quick-Flash Plus Long-Flash", "A rhythmic light in which a group of quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.",25),
				new listedValue("Very Quick-Flash Plus Long-Flash", "A rhythmic light in which a group of very quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.",26),
				new listedValue("Ultra Quick-Flash Plus Long-Flash", "A rhythmic light in which a group of ultra quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.",27),
				new listedValue("Alternating", "A signal light that shows continuously, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.",28),
				new listedValue("Fixed and Alternating Flashing", "A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity and different colour.",29),
				new listedValue("Group-Occulting Light", "An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated",1),
				new listedValue("Composite Group-Occulting Light", "An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.",2),
				new listedValue("Group Flashing Light", "A flashing light in which a group of flashes, specified in number, is regularly repeated.",3),
				new listedValue("Composite Group-Flashing Light", "A light similar to a group-flashing light except that successive groups in a period have different numbers of flashes.",4),
				new listedValue("Group Quick Light", "A light in which flashes are combined in groups including the same number of quick flashes (repetition rate : 50-79 per minute) and in which groups are repeated at regular intervals.",5),
				new listedValue("Group Very Quick Light", "A light in which very quick flashes are combined in groups including the same number of flashes (repetition rate : 80-159 per minute) and in which groups are repeated at regular intervals.",6),
			];

		public static implicit operator lightCharacteristic(int? value) => new lightCharacteristic { value = value };
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
	/// The file name of an externally referenced picture file.
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
	/// The date when an item was installed.
	/// </summary>
	public class installationDate : S100FC.DateAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(installationDate);
		[JsonIgnore]
		public override string S100FC_name => "Installation Date";

		public static implicit operator installationDate(DateOnly? value) => new installationDate { value = value };
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
	/// A straight route (known as a recommended track, range or leading line), which comprises: a. at least two structures (usually beacons or daymarks) and/or natural features, which may carry lights and/or top-marks. The structures/features are positioned so that when observed to be in line, a vessel can follow a known bearing with safety. (Adapted from International Association of Lighthouse Authorities - IALA Aids to Navigation Guide, 1990); or b. a single structure or natural feature, which may carry lights and/or a topmark, and a specified bearing which can be followed with safety. (S-57 Edition 3.1, Appendix A Chapter 2, Page 2.72, November 2000, as amended).
	/// </summary>
	public class basedOnFixedMarks : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(basedOnFixedMarks);
		[JsonIgnore]
		public override string S100FC_name => "Based On Fixed Marks";

		public static implicit operator basedOnFixedMarks(Boolean? value) => new basedOnFixedMarks { value = value };
	}

	/// <summary>
	/// The minimum (shoalest) value of a depth range.
	/// </summary>
	public class depthRangeMinimumValue : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(depthRangeMinimumValue);
		[JsonIgnore]
		public override string S100FC_name => "Depth Range Minimum Value";

		public static implicit operator depthRangeMinimumValue(decimal? value) => new depthRangeMinimumValue { value = value };
	}

	/// <summary>
	/// The maximal permitted draught of a vessel or convoy according to the particular article/clause of the applicable law/regulation.
	/// </summary>
	public class maximalPermittedDraught : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(maximalPermittedDraught);
		[JsonIgnore]
		public override string S100FC_name => "Maximal Permitted Draught";

		public static implicit operator maximalPermittedDraught(decimal? value) => new maximalPermittedDraught { value = value };
	}

	/// <summary>
	/// The reliability of the value of a sounding.
	/// </summary>
	public class qualityOfVerticalMeasurement : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(qualityOfVerticalMeasurement);
		[JsonIgnore]
		public override string S100FC_name => "Quality of Vertical Measurement";
		public static listedValue[] listedValues => [
				new listedValue("Depth Known", "The depth from the chart datum to the seabed (or to the top of a drying feature) is known.",1),
				new listedValue("Depth or Least Depth Unknown", "The depth from chart datum to the seabed, or the shoalest depth of the feature is unknown.",2),
				new listedValue("Doubtful Sounding", "A depth that may be less than indicated.",3),
				new listedValue("Unreliable Sounding", "A depth that is considered to be an unreliable value.",4),
				new listedValue("No Bottom Found at Value Shown", "Upon investigation the bottom was not found at this depth.",5),
				new listedValue("Least Depth Known", "The shoalest depth over a feature is of known value.",6),
				new listedValue("Least Depth Unknown, Safe Clearance at Value Shown", "The least depth over a feature is unknown, but there is considered to be safe clearance at this depth.",7),
				new listedValue("Value Reported (Not Surveyed)", "Depth value obtained from a report, but not fully surveyed.",8),
				new listedValue("Value Reported (Not Confirmed)", "Depth value obtained from a report, which it has not been possible to confirm.",9),
				new listedValue("Maintained Depth", "The depth at which a channel is kept by human influence, usually by dredging.",10),
				new listedValue("Not Regularly Maintained", "Depths may be altered by human influence, but will not be routinely maintained.",11),
			];

		public static implicit operator qualityOfVerticalMeasurement(int? value) => new qualityOfVerticalMeasurement { value = value };
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
				new listedValue("Extinguished", "No longer lit.",11),
				new listedValue("Illuminated", "Lit by flood lights, strip lights, etc.",12),
				new listedValue("Historic", "Famous in history; of historical interest.",13),
				new listedValue("Public", "Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.",14),
				new listedValue("Synchronized", "Occur at a time, coincide in point of time, be contemporary or simultaneous.",15),
				new listedValue("Watched", "Looked at or observed over a period of time especially so as to be aware of any movement or change.",16),
				new listedValue("Unwatched", "Usually automatic in operation, without any permanently-stationed personnel to superintend it.",17),
				new listedValue("Existence Doubtful", "A feature that has been reported but has not been definitely determined to exist.",18),
				new listedValue("On Request", "When you ask for it.",19),
				new listedValue("Drop Away", "To become lower in level.",20),
				new listedValue("Rising", "To become higher in level.",21),
				new listedValue("Increasing", "Becoming larger in magnitude.",22),
				new listedValue("Decreasing", "Becoming smaller in magnitude.",23),
				new listedValue("Strong", "Not easily broken or destroyed.",24),
				new listedValue("Good", "In a satisfactory condition to use.",25),
				new listedValue("Moderately", "Fairly but not very.",26),
				new listedValue("Poor", "Not as good as it could be or should.",27),
				new listedValue("Buoyed", "Marked by buoys.",28),
				new listedValue("Fully Operational", "Entire observation platform is operating in accordance with, or exceeding, manufacturer specifications.",29),
				new listedValue("Partially Operational", "At least one instrument that is part of an observation platform is not operating to manufacturer specification.",30),
				new listedValue("Drifting", "Floating platform at the mercy of environmental elements, whether intentional or not.",31),
				new listedValue("Broken", "Fractured or in pieces.",32),
				new listedValue("Offline", "Observation platform is intentionally not reporting an environmental observation.",33),
				new listedValue("Discontinued", "Observation station, suite of instruments, or an individual instrument, for a particular location, has been removed and is no longer at the particular location.",34),
				new listedValue("Manual Observation", "Observations made by a human observer.",35),
				new listedValue("Unknown Status", "Status of an observation platform, suite of instruments, or individual instrument is not known or unspecified.",36),
				new listedValue("Confirmed", "Made certain as to truth, accuracy, validity, availability, etc.",37),
				new listedValue("Candidate", "Item selected for an action.",38),
				new listedValue("Under Modification", "Item that is in the process of being modified.",39),
				new listedValue("Under Removal / Deletion", "Item in the process of being removed or deleted.",41),
				new listedValue("Removed / Deleted", "Item that has been removed or deleted.",42),
				new listedValue("Candidate for Modification", "Item selected for modification.",43),
			];

		public static implicit operator status(int? value) => new status { value = value };
	}

	/// <summary>
	/// A flag or attribute indicating whether an object has slats, which are flat, narrow strips of material, often used for ventilation or design
	/// </summary>
	public class isSlatted : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(isSlatted);
		[JsonIgnore]
		public override string S100FC_name => "IsSlatted";

		public static implicit operator isSlatted(Boolean? value) => new isSlatted { value = value };
	}

	/// <summary>
	/// The degree to which a vertical measurement is accurate, typically referring to the accuracy of an object's position in the vertical plane (height or depth)
	/// </summary>
	public class verticalAccuracy : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalAccuracy);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Accuracy";

		public static implicit operator verticalAccuracy(decimal? value) => new verticalAccuracy { value = value };
	}

	/// <summary>
	/// The maximum luminous intensity of a light during its flash cycle.
	/// </summary>
	public class peakIntensity : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(peakIntensity);
		[JsonIgnore]
		public override string S100FC_name => "Peak Intensity";

		public static implicit operator peakIntensity(decimal? value) => new peakIntensity { value = value };
	}

	/// <summary>
	/// Survey method used to obtain depth information.
	/// </summary>
	public class techniqueOfVerticalMeasurement : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(techniqueOfVerticalMeasurement);
		[JsonIgnore]
		public override string S100FC_name => "Technique of Vertical Measurement";
		public static listedValue[] listedValues => [
				new listedValue("Found by Echo Sounder", "The depth was measured by using an instrument that determines depth of water by measuring the time interval between emission of a sonic or ultrasonic signal and return of its echo from the bottom.",1),
				new listedValue("Found by Side Scan Sonar", "The depth was computed from a record produced by active sonar in which fixed acoustic beams are directed into the water perpendicularly to the direction of travel to scan the seabed and generate a record of the seabed configuration.",2),
				new listedValue("Found by Multi Beam", "The depth was measured by using a wide swath echo sounder that uses multiple beams to measure depths directly below and transverse to the ship's track.",3),
				new listedValue("Found by Diver", "The depth was determined by a person skilled in the practice of diving.",4),
				new listedValue("Found by Lead Line", "The depth was measured by using a line, graduated with attached marks and fastened to a sounding lead.",5),
				new listedValue("Swept by Wire-Drag", "The given area was determined to be free from navigational dangers to a certain depth by towing a buoyed wire at the desired depth by two launches, or a least depth was identified using the same technique.",6),
				new listedValue("Found by Laser", "The depth was determined by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.",7),
				new listedValue("Swept by Vertical Acoustic System", "The given area has been swept using a system comprised of multiple echo sounder transducers attached to booms deployed from the survey vessel.",8),
				new listedValue("Found by Electromagnetic Sensor", "The depth was determined by using an instrument that compares electromagnetic signals.",9),
				new listedValue("Photogrammetry", "The science or art of obtaining reliable measurements from photographs.",10),
				new listedValue("Satellite Imagery", "The depth was determined by using instruments placed aboard an artificial satellite.",11),
				new listedValue("Found by Levelling", "The depth was determined by using levelling techniques to find the elevation of the point relative to a datum.",12),
				new listedValue("Swept by Side Scan Sonar", "The given area was determined to be free from navigational dangers to a certain depth by towing a side scan sonar.",13),
				new listedValue("Computer Generated", "The sounding was determined from a bottom model constructed using a computer.",14),
				new listedValue("Found by LIDAR", "The depth was measured by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.",15),
				new listedValue("Synthetic Aperture Radar", "A radar with a synthetic aperture antenna which is composed of a large number of elementary transducing elements. The signals are electronically combined into a resulting signal equivalent to that of a single antenna of a given aperture in a given direction.",16),
				new listedValue("Hyperspectral Imagery", "Term used to describe the imagery derived from subdividing the electromagnetic spectrum into very narrow bandwidths. These narrow bandwidths may be combined with or subtracted from each other in various ways to form images useful in precise terrain or target analysis.",17),
				new listedValue("Mechanically Swept", "The given area was determined to be free from navigational dangers to a certain depth by towing a line or object below the surface at the desired depth; or least depth(s) and position(s) within an area was identified using the same technique.",18),
			];

		public static implicit operator techniqueOfVerticalMeasurement(int? value) => new techniqueOfVerticalMeasurement { value = value };
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
	/// The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.
	/// </summary>
	public class verticalDatum : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalDatum);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Datum";
		public static listedValue[] listedValues => [
				new listedValue("Mean Low Water Springs", "The average height of the low waters of spring tides. This level is used as a tidal datum in some areas.",1),
				new listedValue("Mean Lower Low Water Springs", "The average height of lower low water springs at a place.",2),
				new listedValue("Mean Sea Level", "The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.",3),
				new listedValue("Lowest Low Water", "An arbitrary level conforming to the lowest tide observed at a place, or somewhat lower.",4),
				new listedValue("Mean Low Water", "The average height of all low waters at a place over a 19-year period.",5),
				new listedValue("Lowest Low Water Springs", "An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.",6),
				new listedValue("Approximate Mean Low Water Springs", "An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).",7),
				new listedValue("Indian Spring Low Water", "An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.",8),
				new listedValue("Low Water Springs", "An arbitrary level, approximating that of mean low water springs (MLWS).",9),
				new listedValue("Approximate Lowest Astronomical Tide", "An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).",10),
				new listedValue("Nearly Lowest Low Water", "An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).",11),
				new listedValue("Mean Lower Low Water", "The average height of the lower low waters at a place over a 19-year period.",12),
				new listedValue("Low Water", "The lowest level reached at a place by the water surface in one oscillation.",13),
				new listedValue("Approximate Mean Low Water", "An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).",14),
				new listedValue("Approximate Mean Lower Low Water", "An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).",15),
				new listedValue("Mean High Water", "The average height of all high waters at a place over a 19-year period.",16),
				new listedValue("Mean High Water Springs", "The average height of the high waters of spring tides.",17),
				new listedValue("High Water", "The highest level reached at a place by the water surface in one oscillation.",18),
				new listedValue("Approximate Mean Sea Level", "An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).",19),
				new listedValue("High Water Springs", "An arbitrary level, approximating that of mean high water springs (MHWS).",20),
				new listedValue("Mean Higher High Water", "The average height of higher high waters at a place over a 19-year period.",21),
				new listedValue("Equinoctial Spring Low Water", "The level of low water springs near the time of an equinox.",22),
				new listedValue("Lowest Astronomical Tide", "The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.",23),
				new listedValue("Local Datum", "An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.",24),
				new listedValue("International Great Lakes Datum 1985", "A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Père, Quebec, over the period 1970 to 1988.",25),
				new listedValue("Mean Water Level", "The average of all hourly water levels over the available period of record.",26),
				new listedValue("Lower Low Water Large Tide", "The average of the lowest low waters, one from each of 19 years of observations.",27),
				new listedValue("Higher High Water Large Tide", "The average of the highest high waters, one from each of 19 years of observations.",28),
				new listedValue("Nearly Highest High Water", "An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.",29),
				new listedValue("Highest Astronomical Tide", "The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.",30),
				new listedValue("Local Low Water Reference Level", "Low water reference level of the local area.",31),
				new listedValue("Local High Water Reference Level", "High water reference level of the local area.",32),
				new listedValue("Local Mean Water Reference Level", "Mean water reference level of the local area.",33),
				new listedValue("Equivalent Height of Water (German GlW)", "A low water level which is the result of a defined low water discharge - called \"equivalent discharge\".",34),
				new listedValue("Highest Shipping Height of Water (German HSW)", "Upper limit of water levels where navigation is allowed.",35),
				new listedValue("Reference Low Water Level According to Danube Commission", "The water level at a discharge, which is exceeded 94 % of the year within a period of 30 years.",36),
				new listedValue("Highest Shipping Height of Water According to Danube Commission", "The water level at a discharge, which is exceeded 1% of the year within a period of 30 years.",37),
				new listedValue("Dutch River Low Water Reference Level (OLR)", "The water level at a discharge, which is exceeded 95% of the year within a period of 20 years.",38),
				new listedValue("Russian Project Water Level", "Conditional low water level with established probability.",39),
				new listedValue("Russian Normal Backwater Level", "Highest water level derived from the upper backwater stream in watercourse or reservoir under the normal operational conditions.",40),
				new listedValue("Ohio River Datum", "The Ohio River datum.",41),
				new listedValue("Dutch High Water Reference Level", "Dutch High Water Reference Level.",43),
				new listedValue("Baltic Sea Chart Datum 2000", "The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).",44),
				new listedValue("Dutch Estuary Low Water Reference Level (OLW)", "Dutch Estuary Low Water Reference Level (OLW)",45),
				new listedValue("International Great Lakes Datum 2020", "The 2020 update to the International Great Lakes Datum, the official reference system used to measure water level heights in the Great Lakes, connecting channels, and the St. Lawrence River system.",46),
				new listedValue("Sea Floor", "The bottom of the ocean and seas where there is a generally smooth gentle gradient. Also referred to as sea bed (sometimes seabed or sea-bed), and sea bottom.",47),
				new listedValue("Sea Surface", "A two-dimensional (in the horizontal plane) field representing the air-sea interface, with high-frequency fluctuations such as wind waves and swell, but not astronomical tides, filtered out.",48),
				new listedValue("Hydrographic Zero", "A vertical reference near the lowest astronomical tide (LAT), below which the sea level falls only very exceptionally.",49),
			];

		public static implicit operator verticalDatum(int? value) => new verticalDatum { value = value };
	}

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
	/// The principal shape and/or design of a buoy.
	/// </summary>
	public class buoyShape : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(buoyShape);
		[JsonIgnore]
		public override string S100FC_name => "Buoy Shape";
		public static listedValue[] listedValues => [
				new listedValue("Conical", "The upper part of the body above the water-line, or the greater part of the superstructure, has approximately the shape or the appearance of a pointed cone with the point upwards.",1),
				new listedValue("Can", "The upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a cylinder, or a truncated cone that approximates to a cylinder, with a flat end uppermost.",2),
				new listedValue("Spherical", "Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.",3),
				new listedValue("Pillar", "The upper part of the body above the water-line, or the greater part of the superstructure is a narrow vertical structure, pillar or lattice tower.",4),
				new listedValue("Spar", "The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a pole, or of a very long cylinder, floating upright.",5),
				new listedValue("Barrel", "The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a barrel or cylinder floating horizontally.",6),
				new listedValue("Superbuoy", "A very large buoy designed to carry a signal light of high luminous intensity at a high elevation.",7),
				new listedValue("Ice Buoy", "A specially constructed shuttle shaped buoy which is used in ice conditions.",8),
			];

		public static implicit operator buoyShape(int? value) => new buoyShape { value = value };
	}

	/// <summary>
	/// The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.
	/// </summary>
	public class colour : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(colour);
		[JsonIgnore]
		public override string S100FC_name => "Colour";
		public static listedValue[] listedValues => [
				new listedValue("White", "The achromatic object colour of greatest lightness characteristically perceived to belong to objects that reflect diffusely nearly all incident energy throughout the visible spectrum.",1),
				new listedValue("Black", "The achromatic color of least lightness characteristically perceived to belong to objects that neither reflect nor transmit light.",2),
				new listedValue("Red", "A color whose hue resembles that of blood or of the ruby or is that of the long-wave extreme of the visible spectrum.",3),
				new listedValue("Green", "Of the color green.",4),
				new listedValue("Blue", "A color whose hue is that of the clear sky or that of the portion of the color spectrum lying between green and violet.",5),
				new listedValue("Yellow", "A color whose hue resembles that of ripe lemons or sunflowers or is that of the portion of the spectrum lying between green and orange.",6),
				new listedValue("Grey", "Of the color grey.",7),
				new listedValue("Brown", "Any of a group of colors between red and yellow in hue, of medium to low lightness, and of moderate to low saturation.",8),
				new listedValue("Amber", "A variable color averaging a dark orange yellow.",9),
				new listedValue("Violet", "Any of a group of colors of reddish-blue hue, low lightness, and medium saturation.",10),
				new listedValue("Orange", "Any of a group of colors that are between red and yellow in hue.",11),
				new listedValue("Magenta", "A deep purplish red.",12),
				new listedValue("Pink", "Any of a group of colors bluish red to red in hue, of medium to high lightness, and of low to moderate saturation.",13),
			];

		public static implicit operator colour(int? value) => new colour { value = value };
	}

	/// <summary>
	/// A classification of AIS AtoNs that are transmitted electronically and linked to a real-world object but do not physically exist at the broadcast location.
	/// </summary>
	public class categoryOfSyntheticAISAidToNavigation : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfSyntheticAISAidToNavigation);
		[JsonIgnore]
		public override string S100FC_name => "Category Of Synthetic AIS Aid To Navigation";
		public static listedValue[] listedValues => [
				new listedValue("Predicted Synthetic AIS Aid to Navigation", "A Synthetic AIS AtoN that is not equipped with a monitoring device to confirm its position and status.",1),
				new listedValue("Monitored Synthetic AIS Aid to Navigation", "A Synthetic AIS AtoN equipped with a communication link that confirms the position and status of the AtoN.",2),
			];

		public static implicit operator categoryOfSyntheticAISAidToNavigation(int? value) => new categoryOfSyntheticAISAidToNavigation { value = value };
	}

	/// <summary>
	/// A classification of AIS AtoNs that correspond to an actual, physical Aid to Navigation at a real-world location.
	/// </summary>
	public class categoryOfPhysicalAISAidToNavigation : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfPhysicalAISAidToNavigation);
		[JsonIgnore]
		public override string S100FC_name => "Category Of Physical AIS Aid To Navigation";
		public static listedValue[] listedValues => [
				new listedValue("Physical AIS Type 1", "Simple transmission of static, pre-programmed information",1),
				new listedValue("Physical AIS Type 2", "Transmission of dynamic, real-time updated information via connected sensors.",2),
				new listedValue("Physical AIS Type 3", "Full two-way communication including transmission, remote control and configuration",3),
			];

		public static implicit operator categoryOfPhysicalAISAidToNavigation(int? value) => new categoryOfPhysicalAISAidToNavigation { value = value };
	}

	/// <summary>
	/// A regular repeated design containing more than one colour.
	/// </summary>
	public class colourPattern : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(colourPattern);
		[JsonIgnore]
		public override string S100FC_name => "Colour Pattern";
		public static listedValue[] listedValues => [
				new listedValue("Horizontal Stripes", "Straight bands or stripes of differing colours oriented horizontally.",1),
				new listedValue("Vertical Stripes", "Straight bands or stripes of differing colours oriented vertically.",2),
				new listedValue("Diagonal Stripes", "Straight bands or stripes of differing colours oriented diagonally (that is, not horizontally or vertically).",3),
				new listedValue("Squared", "Often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.",4),
				new listedValue("Stripes (Direction Unknown)", "Straight bands or stripes of differing colours oriented in an unknown direction.",5),
				new listedValue("Border Stripe", "A band or stripe of colour which is displayed around the outer edge of the feature, which may also form a border to an inner pattern or plain colour.",6),
				new listedValue("Single Colour", "One solid colour of uniform coverage.",7),
				new listedValue("Rectangle", "A four-sided shape that is made up of two pairs of parallel lines and that has four right angles, on a different coloured background.",8),
				new listedValue("Triangle", "A shape that is made up of three lines and three angles, on a different coloured background.",9),
			];

		public static implicit operator colourPattern(int? value) => new colourPattern { value = value };
	}

	/// <summary>
	/// A feature which returns a strong radar echo.
	/// </summary>
	public class radarConspicuous : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(radarConspicuous);
		[JsonIgnore]
		public override string S100FC_name => "Radar Conspicuous";

		public static implicit operator radarConspicuous(Boolean? value) => new radarConspicuous { value = value };
	}

	/// <summary>
	/// The system of navigational buoyage a region complies with.
	/// </summary>
	public class marksNavigationalSystemOf : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(marksNavigationalSystemOf);
		[JsonIgnore]
		public override string S100FC_name => "Marks Navigational - System Of";
		public static listedValue[] listedValues => [
				new listedValue("IALA A", "Navigational aids conform to the International Association of Lighthouse Authorities - IALA A system.",1),
				new listedValue("IALA B", "Navigational aids conform to the International Association of Lighthouse Authorities - IALA B system.",2),
				new listedValue("No System", "Navigational aids do not conform to any defined system.",9),
				new listedValue("Other System", "Navigational aids conform to a defined system other than International Association of Lighthouse Authorities - IALA.",10),
				new listedValue("Main European Inland Waterway Marking System", "Navigational aids as required in international, national or regional regulations that contain the same navigational aids as the European Code for Inland Waterways of UNECE, or if there is no regulation for a waterway, navigational aids as recommended in the European Code for Inland Waterways of UNECE",11),
				new listedValue("Russian Inland Waterway Regulations", "Navigational aids conform to the Russian inland waterway regulations.",12),
				new listedValue("Brazilian National Inland Waterway Regulation", "Navigational aids conform to the Brazilian national inland waterway regulation",13),
				new listedValue("Paraguay-Parana Waterway - Brazilian Complementary Aids", "Navigational aids conform to the Brazilian complementary aids on the Paraguay-Parana waterway.",15),
			];

		public static implicit operator marksNavigationalSystemOf(int? value) => new marksNavigationalSystemOf { value = value };
	}

	/// <summary>
	/// The building's primary construction material.
	/// </summary>
	public class natureOfConstruction : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(natureOfConstruction);
		[JsonIgnore]
		public override string S100FC_name => "Nature of Construction";
		public static listedValue[] listedValues => [
				new listedValue("Masonry", "Constructed of stones or bricks, usually quarried, shaped, and mortared.",1),
				new listedValue("Concreted", "Constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.",2),
				new listedValue("Loose Boulders", "Constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.",3),
				new listedValue("Hard Surfaced", "Constructed with a surface of hard material, usually a term applied to roads surfaced with asphalt or concrete.",4),
				new listedValue("Unsurfaced", "Constructed with no extra protection, usually a term applied to roads not surfaced with a hard material.",5),
				new listedValue("Wooden", "Constructed from wood.",6),
				new listedValue("Metal", "Constructed from metal.",7),
				new listedValue("Glass Reinforced Plastic", "Constructed from a plastic material strengthened with fibres of glass.",8),
				new listedValue("Painted", "The application of paint to some other construction or natural feature.",9),
				new listedValue("Framework", "Constructed from a lattice framework of, often diagonal, intersecting struts.",10),
				new listedValue("Latticed", "A structure of crossed wooden or metal strips usually arranged to form a diagonal pattern of open spaces between the strips.",11),
				new listedValue("Glass", "[1] Any artificial or natural substance having similar properties and composition, as fused borax, obsidian, or the like.   [2] Something made of such a substance, as a windowpane.",12),
				new listedValue("Fiberglass", "Constructed from fiberglass.",13),
				new listedValue("Plastic", "Constructed from plastic.",14),
			];

		public static implicit operator natureOfConstruction(int? value) => new natureOfConstruction { value = value };
	}

	/// <summary>
	/// Type equipment used as a buoy in a particular installation.
	/// </summary>
	public class typeOfBuoy : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(typeOfBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Type of Buoy";

		public static implicit operator typeOfBuoy(String? value) => new typeOfBuoy { value = value };
	}

	/// <summary>
	/// Describes the characteristic geometric form of the beacon.
	/// </summary>
	public class beaconShape : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(beaconShape);
		[JsonIgnore]
		public override string S100FC_name => "Beacon Shape";
		public static listedValue[] listedValues => [
				new listedValue("Stake, Pole, Perch, Post", "An elongated wood or metal pole, driven into the ground or seabed, which serves as a navigational aid or a support for a navigational aid.",1),
				new listedValue("Withy", "A tree without roots stuck or spoiled into the bottom of the sea to serve as a navigational aid.",2),
				new listedValue("Beacon Tower", "A solid structure of the order of 10 metres in height used as a navigational aid.",3),
				new listedValue("Lattice Beacon", "A structure consisting of strips of metal or wood crossed or interlaced to form a structure to serve as an aid to navigation or as a support for an aid to navigation.",4),
				new listedValue("Pile Beacon", "A long heavy timber(s) or section(s) of steel, wood, concrete, etc., forced into the seabed to serve as an aid to navigation or as a support for an aid to navigation.",5),
				new listedValue("Cairn", "A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.",6),
				new listedValue("Buoyant Beacon", "A tall spar-like beacon fitted with a permanently submerged buoyancy chamber, the lower end of the body is secured to seabed sinker either by a flexible joint or by a cable under tension.",7),
			];

		public static implicit operator beaconShape(int? value) => new beaconShape { value = value };
	}

	/// <summary>
	/// The extent to which a feature, either natural or artificial, is visible from seaward.
	/// </summary>
	public class visualProminence : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(visualProminence);
		[JsonIgnore]
		public override string S100FC_name => "Visual Prominence";
		public static listedValue[] listedValues => [
				new listedValue("Visually Conspicuous", "Term applied to an object either natural or artificial which is distinctly and notably visible from seaward.",1),
				new listedValue("Not Visually Conspicuous", "An object that may be visible from seaward, but cannot be used as a fixing mark and is not conspicuous.",2),
				new listedValue("Prominent", "Objects which are easily identifiable, but do not justify being classed as conspicuous.",3),
			];

		public static implicit operator visualProminence(int? value) => new visualProminence { value = value };
	}

	/// <summary>
	/// The value of the vertical distance to the highest point of the feature, measured from a specified vertical datum.
	/// </summary>
	public class height : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(height);
		[JsonIgnore]
		public override string S100FC_name => "Height";

		public static implicit operator height(decimal? value) => new height { value = value };
	}

	/// <summary>
	/// The total vertical length of a feature.
	/// </summary>
	public class verticalLength : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(verticalLength);
		[JsonIgnore]
		public override string S100FC_name => "Vertical Length";

		public static implicit operator verticalLength(decimal? value) => new verticalLength { value = value };
	}

	/// <summary>
	/// Classification of prominent cultural and natural features in the landscape.
	/// </summary>
	public class categoryOfLandmark : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfLandmark);
		[JsonIgnore]
		public override string S100FC_name => "Category of Landmark";
		public static listedValue[] listedValues => [
				new listedValue("Cairn", "A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.",1),
				new listedValue("Cemetery", "A site and associated structures devoted to the burial of the dead.",2),
				new listedValue("Chimney", "A vertical structure containing a passage or flue for discharging smoke and gases of combustion.",3),
				new listedValue("Dish Aerial", "A parabolic aerial for the receipt and transmission of high frequency radio signals.",4),
				new listedValue("Flagstaff", "A staff or pole on which flags are raised.",5),
				new listedValue("Flare Stack", "A tall structure used for burning-off waste oil or gas.",6),
				new listedValue("Mast", "A relatively tall structure usually held vertical by guy lines.",7),
				new listedValue("Windsock", "A tapered fabric sleeve mounted so as to catch and swing with the wind, thus indicating the wind direction.",8),
				new listedValue("Monument", "A structure erected and/or maintained as a memorial to a person and/or event.",9),
				new listedValue("Column/Pillar", "A cylindrical or slightly tapering body of considerably greater length than diameter erected vertically.",10),
				new listedValue("Memorial Plaque", "A slab of metal, usually ornamented, erected as a memorial to a person or event.",11),
				new listedValue("Obelisk", "A tapering shaft usually of stone or concrete, square or rectangular in section, with a pyramidal apex.",12),
				new listedValue("Statue", "A representation of a living being, sculptured, moulded, or cast in a variety of materials (for example: marble, metal, or plaster).",13),
				new listedValue("Cross", "A monument, or other structure in form of a cross.",14),
				new listedValue("Dome", "A landmark comprising a hemispherical or spheroidal shaped structure.",15),
				new listedValue("Radar Scanner", "A device used for directing a radar beam through a search pattern.",16),
				new listedValue("Tower", "A relatively tall, narrow structure that may either stand alone or may form part of another structure.",17),
				new listedValue("Windmill", "A system of vanes attached to a tower and driven by wind (excluding wind turbines).",18),
				new listedValue("Windmotor", "A modern structure for the use of wind power.",19),
				new listedValue("Spire/Minaret", "A tall conical or pyramid-shaped structure often built on the roof or tower of a building, especially a church or mosque.",20),
				new listedValue("Large Rock or Boulder on Land", "An isolated rocky formation or a single large stone.",21),
				new listedValue("Triangulation Mark", "A recoverable point on the earth, whose geographic position has been determined by angular methods with geodetic instruments. A triangulation point is a selected point, which has been marked with a station mark, or it is a conspicuous natural or artificial feature.",22),
				new listedValue("Boundary Mark", "A marker identifying the location of a surveyed boundary line.",23),
				new listedValue("Observation Wheel", "Wheels with passenger cars mounted external to the rim and independently rotated by electric motors.",24),
				new listedValue("Torii", "A form of decorative gateway or portal, consisting of two upright wooden posts connected at the top by two horizontal crosspieces, commonly found at the entrance to Shinto temples.",25),
				new listedValue("Bridge", "(1) An elevated structure extending across or over the weather deck of a vessel, or part of such a structure. The term is sometimes modified to indicate the intended use, such as navigating bridge or signal bridge.  (2) A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians.",26),
				new listedValue("Dam", "A barrier to check or confine anything in motion; particularly one constructed to hold back water and raise its level to form a reservoir, or to prevent flooding.",27),
			];

		public static implicit operator categoryOfLandmark(int? value) => new categoryOfLandmark { value = value };
	}

	/// <summary>
	/// A specific role that describes a feature.
	/// </summary>
	public class function : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(function);
		[JsonIgnore]
		public override string S100FC_name => "Function";
		public static listedValue[] listedValues => [
				new listedValue("Harbour-Masters Office", "A local official who has charge of mooring and berthing of vessels, collecting harbour fees, etc.",2),
				new listedValue("Customs Office", "Serves as a government office where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.",3),
				new listedValue("Health Office", "The office which is charged with the administration of health laws and sanitary inspections.",4),
				new listedValue("Hospital", "An institution or establishment providing medical or surgical treatment for the ill or wounded.",5),
				new listedValue("Post Office", "The public department, agency or organisation responsible primarily for the collection, transmission and distribution of mail.",6),
				new listedValue("Hotel", "An establishment, especially of a comfortable or luxurious kind, where paying visitors are provided with accommodation, meals and other services.",7),
				new listedValue("Railway Station", "A building with platforms where trains arrive, load, discharge and depart.",8),
				new listedValue("Police Station", "The headquarters of a local police force and that is where those under arrest are first charged.",9),
				new listedValue("Water-Police Station", "The headquarters of a local water-police force.",10),
				new listedValue("Pilot Office", "The office or headquarters of pilots; the place where the services of a pilot may be obtained.",11),
				new listedValue("Pilot Lookout", "A distinctive structure or place on shore from which personnel keep watch upon events at sea or along the coast.",12),
				new listedValue("Bank Office", "An office for custody, deposit, loan, exchange or issue of money.",13),
				new listedValue("Headquarters for District Control", "The quarters of an executive officer (director, manager, etc.) with responsibility for an administrative area.",14),
				new listedValue("Transit Shed/Warehouse", "A building or part of a building for storage of wares or goods.",15),
				new listedValue("Factory", "A building or buildings with equipment for manufacturing; a workshop.",16),
				new listedValue("Power Station", "A stationary plant containing apparatus for large scale conversion of some form of energy (such as hydraulic, steam, chemical or nuclear energy) into electrical energy.",17),
				new listedValue("Administrative", "A building for the management of affairs.",18),
				new listedValue("Educational Facility", "An establishment for teaching and learning (for example school, college, university, etc).",19),
				new listedValue("Church", "A building for public Christian worship.",20),
				new listedValue("Chapel", "A place for Christian worship other than a parish, cathedral or church, especially one attached to a private house or institution.",21),
				new listedValue("Temple", "A building for public Jewish worship.",22),
				new listedValue("Pagoda", "A Hindu or Buddhist temple or sacred building.",23),
				new listedValue("Shinto Shrine", "A building for public Shinto worship.",24),
				new listedValue("Buddhist Temple", "A building for public Buddhist worship.",25),
				new listedValue("Mosque", "A Muslim place of worship.",26),
				new listedValue("Marabout", "A shrine marking the burial place of a Muslim holy man.",27),
				new listedValue("Lookout", "Keeping a watch upon events at sea or along the coast.",28),
				new listedValue("Communication", "Transmitting and/or receiving electronic communication signals.",29),
				new listedValue("Television", "A system for reproducing on a screen visual images transmitted (usually with sound) by radio signals.",30),
				new listedValue("Radio", "Transmitting and/or receiving radio-frequency electromagnetic waves as a means of communication.",31),
				new listedValue("Radar", "A method, system or technique of using beamed, reflected, and timed radio waves for detecting, locating, or tracking objects, and for measuring altitudes.",32),
				new listedValue("Light Support", "A structure serving as a support for one or more lights.",33),
				new listedValue("Microwave", "Broadcasting and receiving signals using microwaves.",34),
				new listedValue("Cooling", "Generation of chilled liquid and/or gas for cooling purposes.",35),
				new listedValue("Observation", "A place from which the surroundings can be observed but at which a watch is not habitually maintained.",36),
				new listedValue("Timeball", "A visual time signal in the form of a ball.",37),
				new listedValue("Clock", "Instrument for measuring time and recording hours.",38),
				new listedValue("Control", "Used to control the flow of traffic within a specified range of an installation.",39),
				new listedValue("Airship Mooring", "Equipment or structure to secure an airship.",40),
				new listedValue("Stadium", "An arena for holding and viewing events.",41),
				new listedValue("Bus Station", "A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.",42),
				new listedValue("Passenger Terminal Building", "A building within a terminal for the loading and unloading of passengers.",43),
				new listedValue("Sea Rescue Control", "A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.",44),
				new listedValue("Observatory", "A building designed and equipped for making observations of astronomical, meteorological, or other natural phenomena.",45),
				new listedValue("Ore Crusher", "A building or structure used to crush ore.",46),
				new listedValue("Boathouse", "A building or shed, usually built partly over water, for sheltering a boat or boats.",47),
				new listedValue("Pumping Station", "A facility to move solids, liquids or gases by means of pressure or suction.",48),
				new listedValue("Roof Above Navigable Water", "A roof that is extending above navigable water, e.g. to protect open cargo holds from rain during loading and unloading. Depending on the vertical clearance vessels can pass under the roof above navigable water.",49),
				new listedValue("Building Above Navigable Water", "The part of a building on land that is extending above navigable water. Depending on the vertical clearance vessels can pass under the building above navigable water.",50),
			];

		public static implicit operator function(int? value) => new function { value = value };
	}

	/// <summary>
	/// Classification of an aid to navigation which signifies some special purpose.
	/// </summary>
	public class categoryOfSpecialPurposeMark : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfSpecialPurposeMark);
		[JsonIgnore]
		public override string S100FC_name => "Category of Special Purpose Mark";
		public static listedValue[] listedValues => [
				new listedValue("Firing Danger Area Mark", "A mark used to indicate a firing danger area, usually at sea.",1),
				new listedValue("Target Mark", "Any object toward which something is directed. The distinctive marking or instrumentation of a ground point to aid its identification on a photograph.",2),
				new listedValue("Marker Ship Mark", "A mark marking the position of a ship which is used as a target during some military exercise.",3),
				new listedValue("Degaussing Range Mark", "A mark used to indicate a degaussing range.",4),
				new listedValue("Barge Mark", "A mark of relevance to barges.",5),
				new listedValue("Cable Mark", "A mark used to indicate the position of submarine cables or the point at which they run on to the land.",6),
				new listedValue("Spoil Ground Mark", "A mark used to indicate the limit of a spoil ground.",7),
				new listedValue("Outfall Mark", "A mark used to indicate the position of an outfall or the point at which it leaves the land.",8),
				new listedValue("ODAS", "Ocean Data Acquisition System.",9),
				new listedValue("Recording Mark", "A mark used to record data for scientific purposes.",10),
				new listedValue("Seaplane Anchorage Mark", "A mark used to indicate a seaplane anchorage.",11),
				new listedValue("Recreation Zone Mark", "A mark used to indicate a recreation zone.",12),
				new listedValue("Private Mark", "A privately maintained mark.",13),
				new listedValue("Mooring Mark", "A mark indicating a mooring or moorings.",14),
				new listedValue("LANBY", "A large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.",15),
				new listedValue("Leading Mark", "Aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.",16),
				new listedValue("Measured Distance Mark", "A mark forming part of a transit indicating one end of a measured distance.",17),
				new listedValue("Notice Mark", "A notice board or sign indicating information to the mariner.",18),
				new listedValue("TSS Mark", "A mark indicating a Traffic Separation Scheme.",19),
				new listedValue("Anchoring Prohibited Mark", "A mark indicating an anchoring prohibited area.",20),
				new listedValue("Berthing Prohibited Mark", "A mark indicating that berthing is prohibited.",21),
				new listedValue("Overtaking Prohibited Mark", "A mark indicating that overtaking is prohibited.",22),
				new listedValue("Two-Way Traffic Prohibited Mark", "A mark indicating a one-way route.",23),
				new listedValue("Reduced Wake Mark", "A mark indicating that vessels must not generate excessive wake.",24),
				new listedValue("Speed Limit Mark", "A mark indicating that a speed limit applies.",25),
				new listedValue("Stop Mark", "A mark indicating the place where the bow of a ship must stop when traffic lights show red.",26),
				new listedValue("General Warning Mark", "A mark indicating that special caution must be exercised in the vicinity of the mark.",27),
				new listedValue("Sound Ship's Siren Mark", "A mark indicating that a ship should sound its siren or horn.",28),
				new listedValue("Restricted Vertical Clearance Mark", "A mark indicating the minimum vertical space available for passage.",29),
				new listedValue("Maximum Vessel's Draught Mark", "A mark indicating the maximum draught of vessel permitted.",30),
				new listedValue("Restricted Horizontal Clearance Mark", "A mark indicating the minimum horizontal space available for passage.",31),
				new listedValue("Strong Current Warning Mark", "A mark warning of strong currents.",32),
				new listedValue("Berthing Permitted Mark", "A mark indicating that berthing is allowed.",33),
				new listedValue("Overhead Power Cable Mark", "A mark indicating an overhead power cable.",34),
				new listedValue("Channel Edge Gradient Mark", "A mark indicating the gradient of the slope of a dredge channel edge.",35),
				new listedValue("Telephone Mark", "A mark indicating the presence of a telephone.",36),
				new listedValue("Ferry Crossing Mark", "A mark indicating that a ferry route crosses the ship route; often used with a 'sound ship's siren' mark.",37),
				new listedValue("Pipeline Mark", "A mark used to indicate the position of submarine pipelines or the point at which they run on to the land.",39),
				new listedValue("Anchorage Mark", "A mark indicating an anchorage area.",40),
				new listedValue("Clearing Mark", "A mark used to indicate a clearing line.",41),
				new listedValue("Control Mark", "A mark indicating the location at which a restriction or requirement exists.",42),
				new listedValue("Diving Mark", "A mark indicating that diving may take place in the vicinity.",43),
				new listedValue("Refuge Beacon", "A mark providing or indicating a place of safety.",44),
				new listedValue("Foul Ground Mark", "A mark indicating a foul ground.",45),
				new listedValue("Yachting Mark", "A mark installed for use by yachtsmen.",46),
				new listedValue("Heliport Mark", "A mark indicating an area where helicopters may land.",47),
				new listedValue("GNSS Mark", "A mark indicating a location at which a GNSS position has been accurately determined.",48),
				new listedValue("Seaplane Landing Mark", "A mark indicating an area where seaplanes land.",49),
				new listedValue("Entry Prohibited Mark", "A mark indicating that entry is prohibited.",50),
				new listedValue("Work in Progress Mark", "A mark indicating that work (generally construction) is in progress.",51),
				new listedValue("Mark With Unknown Purpose", "A mark whose detailed characteristics are unknown.",52),
				new listedValue("Wellhead Mark", "A mark indicating a borehole that produces or is capable of producing oil or natural gas.",53),
				new listedValue("Channel Separation Mark", "A mark indicating the point at which a channel divides separately into two channels.",54),
				new listedValue("Marine Farm Mark", "A mark indicating the existence of a fish, mussel, oyster or pearl farm/culture.",55),
				new listedValue("Artificial Reef Mark", "A mark indicating the existence or the extent of an artificial reef.",56),
				new listedValue("Ice Mark", "A mark, used year round, that may be submerged when ice passes through the area.",57),
				new listedValue("Nature Reserve Mark", "A mark used to define the boundary of a nature reserve.",58),
				new listedValue("Fish Aggregating Device", "A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks or adrift.",59),
				new listedValue("Wreck Mark", "A mark used to indicate the existence of a wreck.",60),
				new listedValue("Customs Mark", "A mark used to indicate the existence of a customs checkpoint.",61),
				new listedValue("Causeway Mark", "A mark used to indicate the existence of a causeway.",62),
				new listedValue("Wave Recorder", "A surface following buoy or fixed device used to measure wave activity.",63),
				new listedValue("Jetski Prohibited", "A mark indicating a jetski prohibited area.",64),
			];

		public static implicit operator categoryOfSpecialPurposeMark(int? value) => new categoryOfSpecialPurposeMark { value = value };
	}

	/// <summary>
	/// The shape a topmark or daymark exhibits.
	/// </summary>
	public class topmarkDaymarkShape : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(topmarkDaymarkShape);
		[JsonIgnore]
		public override string S100FC_name => "Topmark/Daymark Shape";
		public static listedValue[] listedValues => [
				new listedValue("Cone (Point Up)", "Is where the vertex points up.",1),
				new listedValue("Cone (Point Down)", "Is where the vertex points down.",2),
				new listedValue("Sphere", "A curved surface all points of which are equidistant from a fixed point within, called the centre.",3),
				new listedValue("2 Spheres", "Two spheres, one above the other. Two black spheres are commonly used as an International Association of Lighthouse Authorities - IALA topmark (isolated danger).",4),
				new listedValue("Cylinder", "A solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, its ends being parallel circles).",5),
				new listedValue("Board", "Usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.",6),
				new listedValue("X-Shaped", "Having a shape or a cross-section like the capital letter X.",7),
				new listedValue("Upright Cross", "A cross with one vertical member and one horizontal member; that is, similar in shape to the character '+'.",8),
				new listedValue("Cube (Point Up)", "A cube standing on one of its vertexes. A cube is a solid contained by six equal squares, a regular hexahedron.",9),
				new listedValue("2 Cones (Point to Point)", "2 cones, one above the other, with their vertices together in the centre.",10),
				new listedValue("2 Cones (Base to Base)", "2 cones, one above the other, with their bases together in the centre and their vertices pointing up and down.",11),
				new listedValue("Rhombus", "A plane figure having four equal sides and equal opposite angles (two acute and two obtuse); an oblique equilateral parallelogram.",12),
				new listedValue("2 Cones (Points Upward)", "2 cones, one above the other, with their vertices pointing up.",13),
				new listedValue("2 Cones (Points Downward)", "2 cones, one above the other, with their vertices pointing down.",14),
				new listedValue("Besom (Point Up)", "A bundle of rods or twigs. A besom, point up is where the thicker (untied) end of the besom is at the bottom.",15),
				new listedValue("Besom (Point Down)", "A bundle of rods or twigs. A besom, point down is where the thinner (tied) end of the besom is at the bottom.",16),
				new listedValue("Flag", "A flag mounted on a short pole.",17),
				new listedValue("Sphere Over a Rhombus", "A sphere located above a rhombus.",18),
				new listedValue("Square", "A plane figure with four right angles and four equal straight sides.",19),
				new listedValue("Rectangle (Horizontal)", "A horizontal rectangle is where the two longer opposite sides are standing horizontally.",20),
				new listedValue("Rectangle (Vertical)", "A rectangle is a plane figure with four right angles and four straight sides, opposite sides being parallel and equal in length. A vertical rectangle is where the two longer opposite sides are standing vertically.",21),
				new listedValue("Trapezium (Up)", "A quadrilateral having one pair of opposite sides parallel, and which stands on its longer parallel side.",22),
				new listedValue("Trapezium (Down)", "A quadrilateral having one pair of opposite sides parallel, and which stands on its shorter parallel side.",23),
				new listedValue("Triangle (Point Up)", "A figure having three angles and three sides, and which has a vertex at the top.",24),
				new listedValue("Triangle (Point Down)", "A figure having three angles and three sides, and which has a side at the top.",25),
				new listedValue("Circle", "A perfectly round plane figure whose circumference is everywhere equidistant from its centre.",26),
				new listedValue("Two Upright Crosses (One Over the Other)", "Two upright crosses, generally vertically disposed one above the other.",27),
				new listedValue("T-Shape", "Having a shape like the capital letter T.",28),
				new listedValue("Triangle Pointing Up Over a Circle", "A triangle, vertex uppermost, located above a circle.",29),
				new listedValue("Upright Cross Over a Circle", "An upright cross located above a circle.",30),
				new listedValue("Rhombus Over a Circle", "A rhombus located above a circle.",31),
				new listedValue("Circle Over a Triangle Pointing Up", "A circle located over a triangle, vertex uppermost.",32),
				new listedValue("Other Shape (See Shape Information)", "An uncommon and/or non-standardized shape as textually described using an associated attribute.",33),
				new listedValue("Tubular", "Having the form of or consisting of a tube.",34),
			];

		public static implicit operator topmarkDaymarkShape(int? value) => new topmarkDaymarkShape { value = value };
	}

	/// <summary>
	/// Classification of the various means of generating the fog signal.
	/// </summary>
	public class categoryOfFogSignal : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfFogSignal);
		[JsonIgnore]
		public override string S100FC_name => "Category of Fog Signal";
		public static listedValue[] listedValues => [
				new listedValue("Explosive", "A signal produced by the firing of explosive charges.",1),
				new listedValue("Diaphone", "A diaphone uses compressed air and generally emits a powerful low-pitched sound, which often concludes with a brief sound of suddenly lowered pitch, termed the 'grunt'.",2),
				new listedValue("Siren", "A type of fog signal apparatus which produces sound by virtue of the passage of air through slots or holes in a revolving disk.",3),
				new listedValue("Nautophone", "A horn having a diaphragm oscillated by electricity.",4),
				new listedValue("Reed", "[1]  A reed uses compressed air and emits a weak, high pitched sound.  [2]  Any of various water or marsh plants with a firm stem. (Concise Oxford English Dictionary)",5),
				new listedValue("Tyfon", "A diaphragm horn which operates under the influence of compressed air or steam.",6),
				new listedValue("Bell", "A ringing sound with a short range.",7),
				new listedValue("Whistle", "A distinctive sound made by a jet of air passing through an orifice. The apparatus may be operated automatically, by hand or by air being forced up a tube by waves acting on a buoy.",8),
				new listedValue("Gong", "A sound produced by vibration of a disc when struck.",9),
				new listedValue("Horn", "A horn uses compressed air or electricity to vibrate a diaphragm and exists in a variety of types which differ greatly in their sound and power.",10),
			];

		public static implicit operator categoryOfFogSignal(int? value) => new categoryOfFogSignal { value = value };
	}

	/// <summary>
	/// Classification of radar transponder beacon based on functionality.
	/// </summary>
	public class categoryOfRadarTransponderBeacon : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfRadarTransponderBeacon);
		[JsonIgnore]
		public override string S100FC_name => "Category of Radar Transponder Beacon";
		public static listedValue[] listedValues => [
				new listedValue("Ramark, Radar Beacon Transmitting Continuously", "A radar marker beacon which continuously transmits a signal appearing as a radial line on a radar screen, the line indicating the direction of the beacon. Ramarks are intended primarily for marine use. The name 'ramark' is derived from the words radar marker.",1),
				new listedValue("Racon, Radar Transponder Beacon", "A radar beacon which returns a coded signal which provides identification of the beacon, as well as range and bearing. The range and bearing are indicated by the location of the first character received on the radar screen. The name 'racon' is derived from the words radar beacon.",2),
				new listedValue("Leading Racon/Radar Transponder Beacon", "A radar beacon that may be used (in conjunction with at least one other radar beacon) to indicate a leading line.",3),
			];

		public static implicit operator categoryOfRadarTransponderBeacon(int? value) => new categoryOfRadarTransponderBeacon { value = value };
	}

	/// <summary>
	/// The number of signals, the combination of signals or the morse character(s) within one period of full sequence.
	/// </summary>
	public class signalGroup : S100FC.TextAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(signalGroup);
		[JsonIgnore]
		public override string S100FC_name => "Signal Group";

		public static implicit operator signalGroup(String? value) => new signalGroup { value = value };
	}

	/// <summary>
	/// The time occupied by an entire cycle of intervals of light and eclipse.
	/// </summary>
	public class signalPeriod : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(signalPeriod);
		[JsonIgnore]
		public override string S100FC_name => "Signal Period";

		public static implicit operator signalPeriod(decimal? value) => new signalPeriod { value = value };
	}

	/// <summary>
	/// The luminous range of a light in a homogenous atmosphere in which the meteorological visibility is 10 sea miles.
	/// </summary>
	public class valueOfNominalRange : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(valueOfNominalRange);
		[JsonIgnore]
		public override string S100FC_name => "Value of Nominal Range";

		public static implicit operator valueOfNominalRange(decimal? value) => new valueOfNominalRange { value = value };
	}

	/// <summary>
	/// Classification of radio services offered by a radio station.
	/// </summary>
	public class categoryOfRadioStation : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfRadioStation);
		[JsonIgnore]
		public override string S100FC_name => "Category of Radio Station";
		public static listedValue[] listedValues => [
				new listedValue("Circular (Non-Directional) Marine or Aero-Marine Radiobeacon", "A radio station which need not necessarily be manned, the emissions of which, radiated around the horizon, enable its bearing to be determined by means of the radio direction finder of a ship.",1),
				new listedValue("Directional Radiobeacon", "A special type of radiobeacon station the emissions of which are intended to provide a definite track for guidance.",2),
				new listedValue("Rotating Pattern Radiobeacon", "A special type of radiobeacon station emitting a beam of waves to which a uniform turning movement is given, the bearing of the station being determined by means of an ordinary listening receiver and a stop watch. Also referred to as a rotating loop radiobeacon.",3),
				new listedValue("Consol Beacon", "A type of long range position fixing beacon.",4),
				new listedValue("Radio Direction-Finding Station", "A radio station intended to determine only the direction of other stations by means of transmission from the latter.",5),
				new listedValue("Coast Radio Station Providing QTG Service", "A radio station which is prepared to provide QTG service; that is to say, to transmit upon request from a ship a radio signal, the bearing of which can be taken by that ship.",6),
				new listedValue("Aeronautical Radiobeacon", "A radio beacon designed for aeronautical use.",7),
				new listedValue("Decca", "The Decca Navigator System is a high accuracy, short to medium range radio navigational aid intended for coastal and landfall navigation.",8),
				new listedValue("Loran C", "A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.",9),
				new listedValue("Differential GNSS", "Differential GNSS is implemented by placing a GNSS monitor receiver at a precisely known location. Instead of computing a navigation fix, the monitor determines the range error to every GNSS satellite it can track. These ranging errors are then transmitted to local users where they are applied as corrections before computing the navigation result.",10),
				new listedValue("Toran", "An electronic position fixing system used mainly by aircraft.",11),
				new listedValue("Omega", "A long-range radio navigational aid which operates within the VLF frequency band. The system comprises eight land based stations.",12),
				new listedValue("Syledis", "A ranging position fixing system operating at 420-450 MHz over a range of up to 400 Km.",13),
				new listedValue("Chaika", "A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.",14),
				new listedValue("Radio Telephone Station", "The equipment needed at one station to carry on two way voice communication by radio waves only.",19),
				new listedValue("AIS Base Station", "An AIS shore station for use by competent authorities to provide AIS service, manage the data link and enable effective ship to shore / shore to ship transmission of information.",20),
			];

		public static implicit operator categoryOfRadioStation(int? value) => new categoryOfRadioStation { value = value };
	}

	/// <summary>
	/// The luminous intensity of a fictitious juxtaposed steady-burning point light source that would appear to exhibit a luminosity equal to that of the rhythmic point light source it describes. The apparent reduction in intensity of the rhythmic light is subjective and is due to the nature of the response of the eye of the observer.
	/// </summary>
	public class effectiveIntensity : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(effectiveIntensity);
		[JsonIgnore]
		public override string S100FC_name => "Effective Intensity";

		public static implicit operator effectiveIntensity(decimal? value) => new effectiveIntensity { value = value };
	}

	/// <summary>
	/// The estimated range of a non-optical electromagnetic transmission.
	/// </summary>
	public class estimatedRangeOfTransmission : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(estimatedRangeOfTransmission);
		[JsonIgnore]
		public override string S100FC_name => "Estimated Range of Transmission";

		public static implicit operator estimatedRangeOfTransmission(decimal? value) => new estimatedRangeOfTransmission { value = value };
	}

	/// <summary>
	/// The specific visibility of a light, with respect to the light's intensity and ease of recognition.
	/// </summary>
	public class lightVisibility : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(lightVisibility);
		[JsonIgnore]
		public override string S100FC_name => "Light Visibility";
		public static listedValue[] listedValues => [
				new listedValue("High Intensity", "Non-marine lights with a higher power than marine lights and visible from well off shore (often 'Aero' lights).",1),
				new listedValue("Low Intensity", "Non-marine lights with lower power than marine lights.",2),
				new listedValue("Faint", "A decrease in the apparent intensity of a light which may occur in the case of partial obstructions.",3),
				new listedValue("Intensified", "A light in a sector is intensified (that is, has longer range than other sectors).",4),
				new listedValue("Unintensified", "A light in a sector is unintensified (that is, has shorter range than other sectors).",5),
				new listedValue("Visibility Deliberately Restricted", "A light sector is deliberately reduced in intensity, for example to reduce its effect on a built-up area.",6),
				new listedValue("Obscured", "Said of the arc of a light sector designated by its limiting bearings in which the light is not visible from seaward.",7),
				new listedValue("Partially Obscured", "This value specifies that parts of the sector are obscured.",8),
				new listedValue("Visible in Line of Range", "Lights that must be in line to be visible.",9),
			];

		public static implicit operator lightVisibility(int? value) => new lightVisibility { value = value };
	}

	/// <summary>
	/// The outward display of the light.
	/// </summary>
	public class exhibitionConditionOfLight : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(exhibitionConditionOfLight);
		[JsonIgnore]
		public override string S100FC_name => "Exhibition Condition of Light";
		public static listedValue[] listedValues => [
				new listedValue("Light Shown Without Change of Character", "A light shown throughout the 24 hours without change of character.",1),
				new listedValue("Daytime Light", "A light which is only exhibited by day.",2),
				new listedValue("Fog Light", "A light which is exhibited in fog or conditions of reduced visibility.",3),
				new listedValue("Night Light", "A light which is only exhibited at night.",4),
			];

		public static implicit operator exhibitionConditionOfLight(int? value) => new exhibitionConditionOfLight { value = value };
	}

	/// <summary>
	/// The bearing about which the light flare symbol is rotated to be displayed in ECDIS.
	/// </summary>
	public class flareBearing : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(flareBearing);
		[JsonIgnore]
		public override string S100FC_name => "Flare Bearing";

		public static implicit operator flareBearing(int? value) => new flareBearing { value = value };
	}

	/// <summary>
	/// The mechanism used to generate a fog or light signal.
	/// </summary>
	public class signalGeneration : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(signalGeneration);
		[JsonIgnore]
		public override string S100FC_name => "Signal Generation";
		public static listedValue[] listedValues => [
				new listedValue("Automatically", "Signal generation is initiated by a self regulating mechanism such as a timer or light sensor.",1),
				new listedValue("By Wave Action", "The signal is generated by the motion of the sea surface such as a bell in a buoy.",2),
				new listedValue("By Hand", "The signal is generated by a manually operated mechanism such as a hand cranked siren.",3),
				new listedValue("By Wind", "The signal is generated by the motion of air such as a wind driven whistle.",4),
				new listedValue("Radio Activated", "Activated by radio signal.",5),
				new listedValue("Call Activated", "Activated by making a call to a manned station.",6),
			];

		public static implicit operator signalGeneration(int? value) => new signalGeneration { value = value };
	}

	/// <summary>
	/// A statement expressing if a light is considered to be a major light in terms of ECDIS display in a particular area.
	/// </summary>
	public class majorLight : S100FC.BooleanAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(majorLight);
		[JsonIgnore]
		public override string S100FC_name => "Major Light";

		public static implicit operator majorLight(Boolean? value) => new majorLight { value = value };
	}

	/// <summary>
	/// Classification of different light types.
	/// </summary>
	public class categoryOfLight : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfLight);
		[JsonIgnore]
		public override string S100FC_name => "Category of Light";
		public static listedValue[] listedValues => [
				new listedValue("Directional Function", "A light illuminating a sector of very narrow angle and intended to mark a direction to follow.",1),
				new listedValue("Leading Light", "A light associated with other lights so as to form a leading line to be followed.",4),
				new listedValue("Aero Light", "An aero light is established for aeronautical navigation and may be of higher power than marine lights and visible from well offshore.",5),
				new listedValue("Air Obstruction Light", "A light marking an obstacle which constitutes a danger to air navigation.",6),
				new listedValue("Flood Light", "A broad beam light used to illuminate a structure or area.",8),
				new listedValue("Strip Light", "A light whose source has a linear form generally horizontal, which can reach a length of several metres.",9),
				new listedValue("Subsidiary Light", "A light placed on or near the support of a main light and having a special use in navigation.",10),
				new listedValue("Spotlight", "A powerful light focused so as to illuminate a small area.",11),
				new listedValue("Front", "Term used with leading lights to describe the position of the light on the lead as viewed from seaward.",12),
				new listedValue("Rear", "Term used with leading lights to describe the position of the light on the lead as viewed from seaward.",13),
				new listedValue("Lower", "Term used with leading lights to describe the position of the light on the lead as viewed from seaward.",14),
				new listedValue("Upper", "Term used with leading lights to describe the position of the light on the lead as viewed from seaward.",15),
				new listedValue("Emergency", "A light available as a backup to a main light which will be illuminated should the main light fail.",17),
				new listedValue("Bearing Light", "A light which enables its approximate bearing to be obtained without the use of a compass.",18),
				new listedValue("Horizontally Disposed", "A group of lights of identical character and almost identical position, that are disposed horizontally.",19),
				new listedValue("Vertically Disposed", "A group of lights of identical character and almost identical position, that are disposed vertically.",20),
			];

		public static implicit operator categoryOfLight(int? value) => new categoryOfLight { value = value };
	}

	/// <summary>
	/// Classification of an offshore raised structure.
	/// </summary>
	public class categoryOfOffshorePlatform : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfOffshorePlatform);
		[JsonIgnore]
		public override string S100FC_name => "Category of Offshore Platform";
		public static listedValue[] listedValues => [
				new listedValue("Oil Rig", "A temporary mobile structure, either fixed or floating, used in the exploration stages of oil and gas fields.",1),
				new listedValue("Production Platform", "A term used to indicate a permanent offshore structure equipped to control the flow of oil or gas. It does not include entirely submarine structures.",2),
				new listedValue("Observation/Research Platform", "A platform from which one's surroundings or events can be observed, noted or recorded such as for scientific study.",3),
				new listedValue("Articulated Loading Platform", "A metal lattice tower, buoyant at one end and attached at the other by a universal joint to a concrete filled base on the seabed. The platform may be fitted with a helicopter platform, emergency accommodation and hawser/hose retrieval.",4),
				new listedValue("Single Anchor Leg Mooring", "A rigid frame or tube with a buoyancy device at its upper end, secured at its lower end to a universal joint on a large steel or concrete base resting on the seabed, and at its upper end to a mooring buoy by a chain or wire.",5),
				new listedValue("Mooring Tower", "A platform secured to the seabed and surmounted by a turntable to which ships moor.",6),
				new listedValue("Artificial Island", "A man-made structure usually built for the exploration or exploitation of marine resources, marine scientific research, tidal observations, etc.",7),
				new listedValue("Floating Production, Storage and Off-Loading Vessel", "An offshore facility consisting of a moored tanker/barge by which the product is extracted, stored and exported.",8),
				new listedValue("Accommodation Platform", "A platform used primarily for eating, sleeping and recreation purposes.",9),
				new listedValue("Navigation, Communication and Control Buoy", "A floating structure with control room, power and storage facilities, attached to the seabed by a flexible pipeline and cables.",10),
				new listedValue("Floating Oil Tank", "A floating structure, anchored to the seabed, for storing oil.",11),
			];

		public static implicit operator categoryOfOffshorePlatform(int? value) => new categoryOfOffshorePlatform { value = value };
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
				new listedValue("Wingless", "A windmill or wind turbine from which the vanes or turbine blades are missing.",4),
				new listedValue("Planned Construction", "Detailed planning has been completed but construction has not been initiated.",5),
			];

		public static implicit operator condition(int? value) => new condition { value = value };
	}

	/// <summary>
	/// Classification of pile, driven into the earth as a foundation or support for a structure.
	/// </summary>
	public class categoryOfPile : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfPile);
		[JsonIgnore]
		public override string S100FC_name => "Category of Pile";
		public static listedValue[] listedValues => [
				new listedValue("Stake", "An elongated wood or metal pole embedded in the seabed to serve as a marker or support.",1),
				new listedValue("Post", "A vertical piece of timber, metal or concrete forced into the earth or seabed.",3),
				new listedValue("Tripodal", "A single structure comprising 3 or more piles held together (sections of heavy timber, steel or concrete), and forced into the earth or seabed.",4),
				new listedValue("Piling", "A number of piles, usually in a straight line, and usually connected or bolted together.",5),
				new listedValue("Area of Piles", "A number of piles, usually in a straight line, but not connected by structural members.",6),
				new listedValue("Pipe", "A vertical hollow cylinder of metal, wood, or other material forced into the earth or seabed.",7),
				new listedValue("Mooring Post", "A post where to which something (such as a craft) can be moored.",8),
			];

		public static implicit operator categoryOfPile(int? value) => new categoryOfPile { value = value };
	}

	/// <summary>
	/// The specific shape of the building.
	/// </summary>
	public class buildingShape : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(buildingShape);
		[JsonIgnore]
		public override string S100FC_name => "Building Shape";
		public static listedValue[] listedValues => [
				new listedValue("High-Rise Building", "A building having many storeys.",5),
				new listedValue("Pyramid", "A polyhedron of which one face is a polygon of any number of sides, and the other faces are triangles with a common vertex.",6),
				new listedValue("Cylindrical", "Shaped like a cylinder, which is a solid geometrical figure generated by straight lines fixed in direction and describing with one of its points a closed curve, especially a circle.",7),
				new listedValue("Spherical", "Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.",8),
				new listedValue("Cubic", "A shape the sides of which are six equal squares; a regular hexahedron.",9),
			];

		public static implicit operator buildingShape(int? value) => new buildingShape { value = value };
	}

	/// <summary>
	/// Classification based on the product for which a silo or tank is used.
	/// </summary>
	public class categoryOfSiloTank : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfSiloTank);
		[JsonIgnore]
		public override string S100FC_name => "Category of Silo/Tank";
		public static listedValue[] listedValues => [
				new listedValue("Silo in General", "A large storage structure used for storing loose materials.",1),
				new listedValue("Tank in General", "A fixed structure for storing liquids.",2),
				new listedValue("Grain Elevator", "A storage building for grain. Usually a tall frame, metal or concrete structure with an especially compartmented interior.",3),
				new listedValue("Water Tower", "A tower supporting an elevated storage tank of water.",4),
			];

		public static implicit operator categoryOfSiloTank(int? value) => new categoryOfSiloTank { value = value };
	}

	/// <summary>
	/// Classification of lateral marks in the IALA Buoyage System.
	/// </summary>
	public class categoryOfLateralMark : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfLateralMark);
		[JsonIgnore]
		public override string S100FC_name => "Category of Lateral Mark";
		public static listedValue[] listedValues => [
				new listedValue("Port-Hand Lateral Mark", "Indicates the port boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".",1),
				new listedValue("Starboard-Hand Lateral Mark", "Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".",2),
				new listedValue("Preferred Channel to Starboard Lateral Mark", "At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.",3),
				new listedValue("Preferred Channel to Port Lateral Mark", "At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.",4),
				new listedValue("Right-Hand Side of the Waterway", "Indicates the right-hand side of the inland waterway.",5),
				new listedValue("Left-Hand Side of the Waterway", "Indicates the left-hand side of the inland waterway.",6),
				new listedValue("Right-Hand Side of the Channel", "Indicates the right-hand side of a channel of an inland waterway.",7),
				new listedValue("Left-Hand Side of the Channel", "Indicates the left-hand side of a channel of an inland waterway.",8),
				new listedValue("Bifurcation of the Waterway", "Indicates a bifurcation of the inland waterway.",9),
				new listedValue("Bifurcation of the Channel", "Indicates a bifurcation of a channel of an inland waterway.",10),
				new listedValue("Channel Near the Right Bank", "Indicates that the channel is near the right bank.",11),
				new listedValue("Channel Near the Left Bank", "Indicates that the channel is near the left bank.",12),
				new listedValue("Channel Cross-Over to the Right Bank", "Indicates that the channel crosses from the left to the right bank.",13),
				new listedValue("Channel Cross-Over to the Left Bank", "Indicates that the channel crosses from the right to the left bank.",14),
				new listedValue("Danger Point or Obstacles at the Right-Hand Side", "Indicates a danger point or obstacles at the right-hand side.",15),
				new listedValue("Danger Point or Obstacles at the Left-Hand Side", "Indicates a danger point or obstacles at the left-hand side.",16),
				new listedValue("Turn Off at the Right-Hand Side", "Indicates a turn off at the right-hand side.",17),
				new listedValue("Turn Off at the Left-Hand Side", "Indicates a turn off at the left-hand side.",18),
				new listedValue("Junction at the Right-Hand Side", "Indicates a junction at the right-hand side.",19),
				new listedValue("Junction at the Left-Hand Side", "Indicates a junction at the left-hand side.",20),
				new listedValue("Harbour Entry at the Right-Hand Side", "Indicates a harbour entry at the right-hand side.",21),
				new listedValue("Harbour Entry at the Left-Hand Side", "Indicates a harbour entry at the left-hand side.",22),
				new listedValue("Bridge Pier Mark", "Indicates a bridge pier in an inland waterway.",23),
				new listedValue("Entry From a Lake to a Narrower Waterway, Right Bank", "Indicates the right bank of the entry from a lake or a lake-like expansion to a section of the waterway which is narrower.",24),
				new listedValue("Entry From a Lake to a Narrower Waterway, Left Bank", "Indicates the left bank of the entry from a lake or a lake-like expansion to a section of the waterway which is narrower.",25),
				new listedValue("Change Bank", "Change bank.",26),
				new listedValue("Continue Along Bank", "Continue along bank.",27),
			];

		public static implicit operator categoryOfLateralMark(int? value) => new categoryOfLateralMark { value = value };
	}

	/// <summary>
	/// The four quadrants (north, east, south and west) are bounded by the true bearings NW-NE, NE-SE, SE-SW and SW-NW taken from the point of interest. A cardinal mark is named after the quadrant in which it is placed. The name of the cardinal mark indicates that it should be passed to the named side of the mark.
	/// </summary>
	public class categoryOfCardinalMark : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(categoryOfCardinalMark);
		[JsonIgnore]
		public override string S100FC_name => "Category of Cardinal Mark";
		public static listedValue[] listedValues => [
				new listedValue("North Cardinal Mark", "Quadrant bounded by the true bearing NW-NE taken from the point of interest; it should be passed to the north side of the mark.",1),
				new listedValue("East Cardinal Mark", "Quadrant bounded by the true bearing NE-SE taken from the point of interest. It should be passed to the east side of the mark.",2),
				new listedValue("South Cardinal Mark", "Quadrant bounded by the true bearing SE-SW taken from the point of interest; it should be passed to the south side of the mark.",3),
				new listedValue("West Cardinal Mark", "Quadrant bounded by the true bearing SW-NW taken from the point of interest; it should be passed to the west side of the mark.",4),
			];

		public static implicit operator categoryOfCardinalMark(int? value) => new categoryOfCardinalMark { value = value };
	}

	/// <summary>
	/// The altitude of the ground level of a feature, measured from a specified vertical datum.
	/// </summary>
	public class elevation : S100FC.RealAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(elevation);
		[JsonIgnore]
		public override string S100FC_name => "Elevation";

		public static implicit operator elevation(decimal? value) => new elevation { value = value };
	}

	/// <summary>
	/// The value considered by the Data Producer to be the maximum (largest) scale at which the data is to be displayed before it can be considered to be “grossly overscaled”.
	/// </summary>
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
	public class minimumDisplayScale : S100FC.IntegerAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(minimumDisplayScale);
		[JsonIgnore]
		public override string S100FC_name => "Minimum Display Scale";

		public static implicit operator minimumDisplayScale(int? value) => new minimumDisplayScale { value = value };
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
				new listedValue("Likely to Change and Significant Shoaling Expected", "Continuous or frequent change (for example river siltation, sand waves, seasonal storms, icebergs, etc) that is likely to result in new significant shoaling.",2),
				new listedValue("Likely to Change But Significant Shoaling Not Expected", "Continuous or frequent change (for example sand wave shift, seasonal storms, icebergs, etc) that is not likely to result in new significant shoaling.",3),
				new listedValue("Likely to Change", "Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).",4),
				new listedValue("Unlikely to Change", "Significant change to the seafloor is not expected.",5),
				new listedValue("Unassessed", "Not having been assessed.",6),
			];

		public static implicit operator categoryOfTemporalVariation(int? value) => new categoryOfTemporalVariation { value = value };
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
	/// Different categories or kinds of modifications that can be made to data, positions, or objects. For example, changes may involve updates to position, orientation, or attributes of an object.
	/// </summary>
	public class changeTypes : S100FC.EnumerationAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(changeTypes);
		[JsonIgnore]
		public override string S100FC_name => "Change Types";
		public static listedValue[] listedValues => [
				new listedValue("Advance Notice of Change", "Advance notice of a change to an established Aid to Navigation or establishment of a new Aid to Navigation.",1),
				new listedValue("Discrepancy", "(1) A difference between results of duplicate or comparable measures of a quantity.  (2) The difference in computed values of a quantity obtained by different processes using data from the same survey.",2),
				new listedValue("Proposed Change", "Proposed change to an established Aid to Navigation or the establishment of a new Aid to Navigation.",3),
				new listedValue("Temporary Change", "Temporary change to established or newly established Aid to Navigation to mark a hazard, etc.",4),
				new listedValue("Permanent Change", "A permanent change to an established Aid to Navigation or establishment of a new Aid to Navigation.",5),
			];

		public static implicit operator changeTypes(int? value) => new changeTypes { value = value };
	}

}

namespace S100FC.S125.ComplexAttributes
{
	using S100FC.S125.SimpleAttributes;

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
	/// Specific information or description regarding modifications or updates made to an object, system, or dataset. This term typically includes the nature, scope, and reason for the change, as well as any impact it may have on operations or functionality
	/// </summary>
	public class changeDetails : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(changeDetails);
		[JsonIgnore]
		public override string S100FC_name => "Change Details";

		#region Attributes
		[JsonIgnore]
		public int? atonCommissioning {
			set { base.SetAttribute(new atonCommissioning { value = value }); }
			get { return base.GetAttributeValue<atonCommissioning>(nameof(atonCommissioning))?.value; }
		}
		[JsonIgnore]
		public int? atonRemoval {
			set { base.SetAttribute(new atonRemoval { value = value }); }
			get { return base.GetAttributeValue<atonRemoval>(nameof(atonRemoval))?.value; }
		}
		[JsonIgnore]
		public int? atonReplacement {
			set { base.SetAttribute(new atonReplacement { value = value }); }
			get { return base.GetAttributeValue<atonReplacement>(nameof(atonReplacement))?.value; }
		}
		[JsonIgnore]
		public int? fixedAtonChange {
			set { base.SetAttribute(new fixedAtonChange { value = value }); }
			get { return base.GetAttributeValue<fixedAtonChange>(nameof(fixedAtonChange))?.value; }
		}
		[JsonIgnore]
		public int? floatingAtonChange {
			set { base.SetAttribute(new floatingAtonChange { value = value }); }
			get { return base.GetAttributeValue<floatingAtonChange>(nameof(floatingAtonChange))?.value; }
		}
		[JsonIgnore]
		public int? audibleSignalAtonChange {
			set { base.SetAttribute(new audibleSignalAtonChange { value = value }); }
			get { return base.GetAttributeValue<audibleSignalAtonChange>(nameof(audibleSignalAtonChange))?.value; }
		}
		[JsonIgnore]
		public int? lightedAtonChange {
			set { base.SetAttribute(new lightedAtonChange { value = value }); }
			get { return base.GetAttributeValue<lightedAtonChange>(nameof(lightedAtonChange))?.value; }
		}
		[JsonIgnore]
		public int? electronicAtonChange {
			set { base.SetAttribute(new electronicAtonChange { value = value }); }
			get { return base.GetAttributeValue<electronicAtonChange>(nameof(electronicAtonChange))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(atonCommissioning),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new atonCommissioning(),
				},
				new attributeBindingDefinition {
					attribute = nameof(atonRemoval),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27],
					CreateInstance = () => new atonRemoval(),
				},
				new attributeBindingDefinition {
					attribute = nameof(atonReplacement),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16],
					CreateInstance = () => new atonReplacement(),
				},
				new attributeBindingDefinition {
					attribute = nameof(fixedAtonChange),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new fixedAtonChange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(floatingAtonChange),
					lower = 0,
					upper = 1,
					order = 4,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26],
					CreateInstance = () => new floatingAtonChange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(audibleSignalAtonChange),
					lower = 0,
					upper = 1,
					order = 5,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new audibleSignalAtonChange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(lightedAtonChange),
					lower = 0,
					upper = 1,
					order = 6,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24],
					CreateInstance = () => new lightedAtonChange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(electronicAtonChange),
					lower = 0,
					upper = 1,
					order = 7,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30],
					CreateInstance = () => new electronicAtonChange(),
				},
			];

		#endregion
	}

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
			];

		#endregion
	}

	/// <summary>
	/// A period in time during which a service, system or device is expected to not be operational.
	/// </summary>
	public class expectedOutage : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(expectedOutage);
		[JsonIgnore]
		public override string S100FC_name => "Expected Outage";

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
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new dateStart(),
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
		public String? headline {
			set { base.SetAttribute(new headline { value = value }); }
			get { return base.GetAttributeValue<headline>(nameof(headline))?.value; }
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
					upper = 1,
					order = 2,
					CreateInstance = () => new headline(),
				},
				new attributeBindingDefinition {
					attribute = nameof(language),
					lower = 1,
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
	/// The number of features of identical character that exist as a co-located group.
	/// </summary>
	public class multiplicityOfFeatures : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(multiplicityOfFeatures);
		[JsonIgnore]
		public override string S100FC_name => "Multiplicity of Features";

		#region Attributes
		[JsonIgnore]
		public Boolean? multiplicityKnown {
			set { base.SetAttribute(new multiplicityKnown { value = value }); }
			get { return base.GetAttributeValue<multiplicityKnown>(nameof(multiplicityKnown))?.value; }
		}
		[JsonIgnore]
		public int? numberOfFeatures {
			set { base.SetAttribute(new numberOfFeatures { value = value }); }
			get { return base.GetAttributeValue<numberOfFeatures>(nameof(numberOfFeatures))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(multiplicityKnown),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new multiplicityKnown(),
				},
				new attributeBindingDefinition {
					attribute = nameof(numberOfFeatures),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new numberOfFeatures(),
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
		public String? dateEnd {
			set { base.SetAttribute(new dateEnd { value = value }); }
			get { return base.GetAttributeValue<dateEnd>(nameof(dateEnd))?.value; }
		}
		[JsonIgnore]
		public String? dateStart {
			set { base.SetAttribute(new dateStart { value = value }); }
			get { return base.GetAttributeValue<dateStart>(nameof(dateStart))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(dateEnd),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new dateEnd(),
				},
				new attributeBindingDefinition {
					attribute = nameof(dateStart),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new dateStart(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The distance between two successive peaks (or other points of identical phase) on an electromagnetic wave in the radar band of the electromagnetic spectrum.
	/// </summary>
	public class radarWaveLength : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(radarWaveLength);
		[JsonIgnore]
		public override string S100FC_name => "Radar Wave Length";

		#region Attributes
		[JsonIgnore]
		public String? radarBand {
			set { base.SetAttribute(new radarBand { value = value }); }
			get { return base.GetAttributeValue<radarBand>(nameof(radarBand))?.value; }
		}
		[JsonIgnore]
		public decimal? waveLengthValue {
			set { base.SetAttribute(new waveLengthValue { value = value }); }
			get { return base.GetAttributeValue<waveLengthValue>(nameof(waveLengthValue))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(radarBand),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new radarBand(),
				},
				new attributeBindingDefinition {
					attribute = nameof(waveLengthValue),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new waveLengthValue(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Additional textual information about a light sector.
	/// </summary>
	public class sectorInformation : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorInformation);
		[JsonIgnore]
		public override string S100FC_name => "Sector Information";

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
					lower = 0,
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
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	public class sectorLimitOne : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorLimitOne);
		[JsonIgnore]
		public override string S100FC_name => "Sector Limit One";

		#region Attributes
		[JsonIgnore]
		public decimal? sectorBearing {
			set { base.SetAttribute(new sectorBearing { value = value }); }
			get { return base.GetAttributeValue<sectorBearing>(nameof(sectorBearing))?.value; }
		}
		[JsonIgnore]
		public int? sectorLineLength {
			set { base.SetAttribute(new sectorLineLength { value = value }); }
			get { return base.GetAttributeValue<sectorLineLength>(nameof(sectorLineLength))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(sectorBearing),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new sectorBearing(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorLineLength),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new sectorLineLength(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
	/// </summary>
	public class sectorLimitTwo : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorLimitTwo);
		[JsonIgnore]
		public override string S100FC_name => "Sector Limit Two";

		#region Attributes
		[JsonIgnore]
		public decimal? sectorBearing {
			set { base.SetAttribute(new sectorBearing { value = value }); }
			get { return base.GetAttributeValue<sectorBearing>(nameof(sectorBearing))?.value; }
		}
		[JsonIgnore]
		public int? sectorLineLength {
			set { base.SetAttribute(new sectorLineLength { value = value }); }
			get { return base.GetAttributeValue<sectorLineLength>(nameof(sectorLineLength))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(sectorBearing),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new sectorBearing(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorLineLength),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new sectorLineLength(),
				},
			];

		#endregion
	}

	/// <summary>
	/// The sequence of times occupied by intervals of light/sound and eclipse/silence for all “light characteristics” or sound signals.
	/// </summary>
	public class signalSequence : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(signalSequence);
		[JsonIgnore]
		public override string S100FC_name => "Signal Sequence";

		#region Attributes
		[JsonIgnore]
		public decimal? signalDuration {
			set { base.SetAttribute(new signalDuration { value = value }); }
			get { return base.GetAttributeValue<signalDuration>(nameof(signalDuration))?.value; }
		}
		[JsonIgnore]
		public int? signalStatus {
			set { base.SetAttribute(new signalStatus { value = value }); }
			get { return base.GetAttributeValue<signalStatus>(nameof(signalStatus))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(signalDuration),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new signalDuration(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalStatus),
					lower = 1,
					upper = 1,
					order = 1,
					permitedValues = [1,2],
					CreateInstance = () => new signalStatus(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Encodes the file name of a single external text file that contains the text in a defined language, which provides additional textual information that cannot be provided using other allowable attributes for the feature.
	/// </summary>
	public class textualDescription : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(textualDescription);
		[JsonIgnore]
		public override string S100FC_name => "Textual Description";

		#region Attributes
		[JsonIgnore]
		public String? fileReference {
			set { base.SetAttribute(new fileReference { value = value }); }
			get { return base.GetAttributeValue<fileReference>(nameof(fileReference))?.value; }
		}
		[JsonIgnore]
		public String? language {
			set { base.SetAttribute(new language { value = value }); }
			get { return base.GetAttributeValue<language>(nameof(language))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(fileReference),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new fileReference(),
				},
				new attributeBindingDefinition {
					attribute = nameof(language),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new language(),
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
	/// The sequence of times occupied by intervals of light/sound and eclipse/silence for all light characteristics or sound signals.
	/// </summary>
	public class rhythmOfLight : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(rhythmOfLight);
		[JsonIgnore]
		public override string S100FC_name => "Rhythm of Light";

		#region Attributes
		[JsonIgnore]
		public int? lightCharacteristic {
			set { base.SetAttribute(new lightCharacteristic { value = value }); }
			get { return base.GetAttributeValue<lightCharacteristic>(nameof(lightCharacteristic))?.value; }
		}
		[JsonIgnore]
		public String?[] signalGroup {
			set { base.SetAttribute("signalGroup", [.. value.Select(e=> new signalGroup { value = e })]); }
			get { return base.GetAttributeValues<signalGroup>(nameof(signalGroup)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? signalPeriod {
			set { base.SetAttribute(new signalPeriod { value = value }); }
			get { return base.GetAttributeValue<signalPeriod>(nameof(signalPeriod))?.value; }
		}
		[JsonIgnore]
		public signalSequence?[] signalSequence {
			set { base.SetAttribute("signalSequence", value); }
			get { return base.GetAttributeValues<signalSequence>(nameof(signalSequence)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(lightCharacteristic),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,25,26,27,28,29],
					CreateInstance = () => new lightCharacteristic(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalGroup),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new signalGroup(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalPeriod),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new signalPeriod(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalSequence),
					lower = 0,
					upper = 2147483647,
					order = 3,
					CreateInstance = () => new signalSequence(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A directional light is a light illuminating a sector of very narrow angle and intended to mark a direction to follow.
	/// </summary>
	public class directionalCharacter : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(directionalCharacter);
		[JsonIgnore]
		public override string S100FC_name => "Directional Character";

		#region Attributes
		[JsonIgnore]
		public Boolean? moireEffect {
			set { base.SetAttribute(new moireEffect { value = value }); }
			get { return base.GetAttributeValue<moireEffect>(nameof(moireEffect))?.value; }
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
					attribute = nameof(moireEffect),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new moireEffect(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientation),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new orientation(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
	/// </summary>
	public class sectorLimit : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorLimit);
		[JsonIgnore]
		public override string S100FC_name => "Sector Limit";

		#region Attributes
		[JsonIgnore]
		public sectorLimitOne? sectorLimitOne {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<sectorLimitOne>(nameof(sectorLimitOne)); }
		}
		[JsonIgnore]
		public sectorLimitTwo? sectorLimitTwo {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<sectorLimitTwo>(nameof(sectorLimitTwo)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(sectorLimitOne),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new sectorLimitOne(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorLimitTwo),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new sectorLimitTwo(),
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
	/// A portion or sector of a navigational aid, such as a light or beacon, that is blocked or obscured from view due to obstacles (e.g., landforms, buildings, or other structures). In marine or aviation navigation, it usually refers to an area where the light signal or visibility is intentionally or unintentionally reduced or not visible to vessels or aircraft
	/// </summary>
	public class obscuredSector : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(obscuredSector);
		[JsonIgnore]
		public override string S100FC_name => "Obscured Sector";

		#region Attributes
		[JsonIgnore]
		public sectorLimit? sectorLimit {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<sectorLimit>(nameof(sectorLimit)); }
		}
		[JsonIgnore]
		public sectorInformation? sectorInformation {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<sectorInformation>(nameof(sectorInformation)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(sectorLimit),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new sectorLimit(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorInformation),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new sectorInformation(),
				},
			];

		#endregion
	}

	/// <summary>
	/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference.
	/// </summary>
	public class lightSector : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(lightSector);
		[JsonIgnore]
		public override string S100FC_name => "Light Sector";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public directionalCharacter? directionalCharacter {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<directionalCharacter>(nameof(directionalCharacter)); }
		}
		[JsonIgnore]
		public int?[] lightVisibility {
			set { base.SetAttribute("lightVisibility", [.. value.Select(e=> new lightVisibility { value = e })]); }
			get { return base.GetAttributeValues<lightVisibility>(nameof(lightVisibility)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public sectorLimit? sectorLimit {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<sectorLimit>(nameof(sectorLimit)); }
		}
		[JsonIgnore]
		public decimal? valueOfNominalRange {
			set { base.SetAttribute(new valueOfNominalRange { value = value }); }
			get { return base.GetAttributeValue<valueOfNominalRange>(nameof(valueOfNominalRange))?.value; }
		}
		[JsonIgnore]
		public sectorInformation?[] sectorInformation {
			set { base.SetAttribute("sectorInformation", value); }
			get { return base.GetAttributeValues<sectorInformation>(nameof(sectorInformation)); }
		}
		[JsonIgnore]
		public Boolean? sectorArcExtension {
			set { base.SetAttribute(new sectorArcExtension { value = value }); }
			get { return base.GetAttributeValue<sectorArcExtension>(nameof(sectorArcExtension))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(directionalCharacter),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new directionalCharacter(),
				},
				new attributeBindingDefinition {
					attribute = nameof(lightVisibility),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new lightVisibility(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorLimit),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new sectorLimit(),
				},
				new attributeBindingDefinition {
					attribute = nameof(valueOfNominalRange),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new valueOfNominalRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorInformation),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new sectorInformation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorArcExtension),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new sectorArcExtension(),
				},
			];

		#endregion
	}

	/// <summary>
	/// Describes the characteristics of a light sector.
	/// </summary>
	public class sectorCharacteristics : S100FC.ComplexAttribute
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(sectorCharacteristics);
		[JsonIgnore]
		public override string S100FC_name => "Sector Characteristics";

		#region Attributes
		[JsonIgnore]
		public int? lightCharacteristic {
			set { base.SetAttribute(new lightCharacteristic { value = value }); }
			get { return base.GetAttributeValue<lightCharacteristic>(nameof(lightCharacteristic))?.value; }
		}
		[JsonIgnore]
		public lightSector?[] lightSector {
			set { base.SetAttribute("lightSector", value); }
			get { return base.GetAttributeValues<lightSector>(nameof(lightSector)); }
		}
		[JsonIgnore]
		public String?[] signalGroup {
			set { base.SetAttribute("signalGroup", [.. value.Select(e=> new signalGroup { value = e })]); }
			get { return base.GetAttributeValues<signalGroup>(nameof(signalGroup)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? signalPeriod {
			set { base.SetAttribute(new signalPeriod { value = value }); }
			get { return base.GetAttributeValue<signalPeriod>(nameof(signalPeriod))?.value; }
		}
		[JsonIgnore]
		public signalSequence?[] signalSequence {
			set { base.SetAttribute("signalSequence", value); }
			get { return base.GetAttributeValues<signalSequence>(nameof(signalSequence)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(lightCharacteristic),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,25,26,27,28,29],
					CreateInstance = () => new lightCharacteristic(),
				},
				new attributeBindingDefinition {
					attribute = nameof(lightSector),
					lower = 1,
					upper = 10,
					order = 1,
					CreateInstance = () => new lightSector(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalGroup),
					lower = 0,
					upper = 10,
					order = 2,
					CreateInstance = () => new signalGroup(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalPeriod),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new signalPeriod(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalSequence),
					lower = 0,
					upper = 10,
					order = 4,
					CreateInstance = () => new signalSequence(),
				},
			];

		#endregion
	}

}

namespace S100FC.S125.InformationAssociation
{
	using S100FC.S125.SimpleAttributes;
	using S100FC.S125.ComplexAttributes;

	/// <summary>
	/// 
	/// </summary>
	public class AtonStatus : S100FC.InformationAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AtonStatus);
		[JsonIgnore]
		public override string S100FC_name => "Aton status";
		public static string role => "atonPart";

		#region Catalogue
		#endregion
	}

}

namespace S100FC.S125.FeatureAssociation
{
	using S100FC.S125.SimpleAttributes;
	using S100FC.S125.ComplexAttributes;

	/// <summary>
	/// 
	/// </summary>
	public class AtonStatusIndicationAssociation : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AtonStatusIndicationAssociation);
		[JsonIgnore]
		public override string S100FC_name => "Aton status indication association";
		public static string[] roles => ["theAidsToNavigation","theStatusIndication"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// Two or more features in the same horizontal direction, particularly those features so placed as navigational aids to mark any line of importance to vessels, as a channel. The one nearest the observer is the front mark and the one farthest from the observer is the rear mark.
	/// </summary>
	public class RangeSystem : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RangeSystem);
		[JsonIgnore]
		public override string S100FC_name => "Range System";
		public static string[] roles => ["navigableTrack","navigationLine"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// 
	/// </summary>
	public class AtonAggregations : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AtonAggregations);
		[JsonIgnore]
		public override string S100FC_name => "Aton aggregations";
		public static string[] roles => ["peerAtonAggregation","atonAggregationBy"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// 
	/// </summary>
	public class AtonAssociations : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AtonAssociations);
		[JsonIgnore]
		public override string S100FC_name => "Aton associations";
		public static string[] roles => ["peerAtonAssociation","atonAssociationBy"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// 
	/// </summary>
	public class DangerousFeatureAssociation : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(DangerousFeatureAssociation);
		[JsonIgnore]
		public override string S100FC_name => "Dangerous feature association";
		public static string[] roles => ["danger","markingAton"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// A feature association for the binding between a navigation aid or other associated equipment feature and the structure that supports it. The structure itself may or may not be intended as an aid to navigation.
	/// </summary>
	public class StructureEquipment : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(StructureEquipment);
		[JsonIgnore]
		public override string S100FC_name => "Structure/Equipment";
		public static string[] roles => ["parent","child"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// 
	/// </summary>
	public class PhysicalAIS : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PhysicalAIS);
		[JsonIgnore]
		public override string S100FC_name => "Physical AIS";
		public static string[] roles => ["physicalAISBroadcastBy","physicalAISBroadcasts"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// 
	/// </summary>
	public class SyntheticAIS : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SyntheticAIS);
		[JsonIgnore]
		public override string S100FC_name => "Synthetic AIS";
		public static string[] roles => ["syntheticAISBroadcastBy","syntheticAISBroadcasts"];

		#region Catalogue
		#endregion
	}

	/// <summary>
	/// 
	/// </summary>
	public class VirtualAIS : S100FC.FeatureAssociation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(VirtualAIS);
		[JsonIgnore]
		public override string S100FC_name => "Virtual AIS";
		public static string[] roles => ["virtualAISBroadcastBy","virtualAISBroadcasts"];

		#region Catalogue
		#endregion
	}

}

namespace S100FC.S125.InformationTypes
{
	using S100FC.S125.SimpleAttributes;
	using S100FC.S125.ComplexAttributes;

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
		public int? qualityOfVerticalMeasurement {
			set { base.SetAttribute(new qualityOfVerticalMeasurement { value = value }); }
			get { return base.GetAttributeValue<qualityOfVerticalMeasurement>(nameof(qualityOfVerticalMeasurement))?.value; }
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
					attribute = nameof(qualityOfVerticalMeasurement),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new qualityOfVerticalMeasurement(),
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

	/// <summary>
	/// This refers to the current operational status or condition of an Aid to Navigation (AtoN). It provides details about whether the navigational aid (such as a buoy, light, or beacon) is functioning properly, temporarily out of service, under maintenance, or has any other status that affects its operation or visibility to mariners
	/// </summary>
	public class AtonStatusInformation : S100FC.InformationType, IInformationBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AtonStatusInformation);
		[JsonIgnore]
		public override string S100FC_name => "Aton Status Information";

		#region Attributes
		[JsonIgnore]
		public changeDetails? changeDetails {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<changeDetails>(nameof(changeDetails)); }
		}
		[JsonIgnore]
		public int? changeTypes {
			set { base.SetAttribute(new changeTypes { value = value }); }
			get { return base.GetAttributeValue<changeTypes>(nameof(changeTypes))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(changeDetails),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new changeDetails(),
				},
				new attributeBindingDefinition {
					attribute = nameof(changeTypes),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,5],
					CreateInstance = () => new changeTypes(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AtonStatusInformation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		#endregion
	}

}

namespace S100FC.S125.FeatureTypes
{
	using S100FC.S125.SimpleAttributes;
	using S100FC.S125.ComplexAttributes;
	using S100FC.S125.InformationTypes;

	/// <summary>
	/// A visual, acoustical, or radio device, external to a ship, designed to assist in determining a safe course or a vessel's position, or to warn of dangers and/or obstructions. Aids to navigation usually include buoys, beacons, fog signals, lights, radio beacons, leading marks, radio position fixing systems and GNSS which are chart-related and assist safe navigation.
	/// </summary>
	public abstract class AidsToNavigation : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AidsToNavigation);
		[JsonIgnore]
		public override string S100FC_name => "Aids to Navigation";

		#region Attributes
		[JsonIgnore]
		public String? interoperabilityIdentifier {
			set { base.SetAttribute(new interoperabilityIdentifier { value = value }); }
			get { return base.GetAttributeValue<interoperabilityIdentifier>(nameof(interoperabilityIdentifier))?.value; }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		[JsonIgnore]
		public featureName?[] featureName {
			set { base.SetAttribute("featureName", value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); }
		}
		[JsonIgnore]
		public int? scaleMinimum {
			set { base.SetAttribute(new scaleMinimum { value = value }); }
			get { return base.GetAttributeValue<scaleMinimum>(nameof(scaleMinimum))?.value; }
		}
		[JsonIgnore]
		public DateOnly? sourceDate {
			set { base.SetAttribute(new sourceDate { value = value }); }
			get { return base.GetAttributeValue<sourceDate>(nameof(sourceDate))?.value; }
		}
		[JsonIgnore]
		public String? source {
			set { base.SetAttribute(new source { value = value }); }
			get { return base.GetAttributeValue<source>(nameof(source))?.value; }
		}
		[JsonIgnore]
		public String? pictorialRepresentation {
			set { base.SetAttribute(new pictorialRepresentation { value = value }); }
			get { return base.GetAttributeValue<pictorialRepresentation>(nameof(pictorialRepresentation))?.value; }
		}
		[JsonIgnore]
		public DateOnly? installationDate {
			set { base.SetAttribute(new installationDate { value = value }); }
			get { return base.GetAttributeValue<installationDate>(nameof(installationDate))?.value; }
		}
		[JsonIgnore]
		public fixedDateRange? fixedDateRange {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<fixedDateRange>(nameof(fixedDateRange)); }
		}
		[JsonIgnore]
		public periodicDateRange? periodicDateRange {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<periodicDateRange>(nameof(periodicDateRange)); }
		}
		[JsonIgnore]
		public String?[] seasonalActionRequired {
			set { base.SetAttribute("seasonalActionRequired", [.. value.Select(e=> new seasonalActionRequired { value = e })]); }
			get { return base.GetAttributeValues<seasonalActionRequired>(nameof(seasonalActionRequired)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(interoperabilityIdentifier),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new information(),
				},
				new attributeBindingDefinition {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new featureName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(scaleMinimum),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new scaleMinimum(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sourceDate),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new sourceDate(),
				},
				new attributeBindingDefinition {
					attribute = nameof(source),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new source(),
				},
				new attributeBindingDefinition {
					attribute = nameof(pictorialRepresentation),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new pictorialRepresentation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(installationDate),
					lower = 0,
					upper = 1,
					order = 7,
					CreateInstance = () => new installationDate(),
				},
				new attributeBindingDefinition {
					attribute = nameof(fixedDateRange),
					lower = 0,
					upper = 1,
					order = 8,
					CreateInstance = () => new fixedDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(periodicDateRange),
					lower = 0,
					upper = 1,
					order = 9,
					CreateInstance = () => new periodicDateRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(seasonalActionRequired),
					lower = 0,
					upper = 2147483647,
					order = 10,
					CreateInstance = () => new seasonalActionRequired(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AidsToNavigation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				new informationBindingDefinition {
					roleType = "association",
					role = "statusPart",
					association = "AtonStatus",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AtonStatusInformation)],
					CreateInstance = () => new informationBinding<InformationAssociation.AtonStatus>() {
						roleType = "association",
						role = "statusPart",
					},
				},
			];

		public static informationBinding<InformationAssociation.AtonStatus> AtonStatus => new informationBinding<InformationAssociation.AtonStatus> {
			roleType = "association",
			role = "statusPart",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => AidsToNavigation.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "peerAtonAggregation",
					association = "AtonAggregations",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(AtonAggregation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.AtonAggregations>() {
						roleType = "association",
						role = "peerAtonAggregation",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "peerAtonAssociation",
					association = "AtonAssociations",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(AtonAssociation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.AtonAssociations>() {
						roleType = "association",
						role = "peerAtonAssociation",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "theStatusIndication",
					association = "AtonStatusIndicationAssociation",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(AtonStatusIndication)],
					CreateInstance = () => new featureBinding<FeatureAssociation.AtonStatusIndicationAssociation>() {
						roleType = "association",
						role = "theStatusIndication",
					},
				},
			];

		public static featureBinding<FeatureAssociation.AtonAggregations> AtonAggregations(string role) => new featureBinding<FeatureAssociation.AtonAggregations> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("AtonAggregations") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.AtonAssociations> AtonAssociations(string role) => new featureBinding<FeatureAssociation.AtonAssociations> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("AtonAssociations") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.AtonStatusIndicationAssociation> AtonStatusIndicationAssociation(string role) => new featureBinding<FeatureAssociation.AtonStatusIndicationAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("AtonStatusIndicationAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// The implements used in an operation or activity.
	/// </summary>
	public abstract class Equipment : AidsToNavigation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Equipment);
		[JsonIgnore]
		public override string S100FC_name => "Equipment";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Equipment.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Equipment.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. AidsToNavigation.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "parent",
					association = "StructureEquipment",
					lower = 1,
					upper = 1,
					featureTypes = [nameof(StructureObject)],
					CreateInstance = () => new featureBinding<FeatureAssociation.StructureEquipment>() {
						roleType = "association",
						role = "parent",
					},
				},
			];

		public static featureBinding<FeatureAssociation.StructureEquipment> StructureEquipment(string role) => new featureBinding<FeatureAssociation.StructureEquipment> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("StructureEquipment") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// Something (such as a house, tower, bridge, etc.) that is built by putting parts together and that usually stands on its own.
	/// </summary>
	public abstract class StructureObject : AidsToNavigation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(StructureObject);
		[JsonIgnore]
		public override string S100FC_name => "Structure Object";

		#region Attributes
		[JsonIgnore]
		public String? atoNNumber {
			set { base.SetAttribute(new atoNNumber { value = value }); }
			get { return base.GetAttributeValue<atoNNumber>(nameof(atoNNumber))?.value; }
		}
		[JsonIgnore]
		public contactAddress? contactAddress {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<contactAddress>(nameof(contactAddress)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(atoNNumber),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new atoNNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(contactAddress),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new contactAddress(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => StructureObject.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => StructureObject.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. AidsToNavigation.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "child",
					association = "StructureEquipment",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(Equipment)],
					CreateInstance = () => new featureBinding<FeatureAssociation.StructureEquipment>() {
						roleType = "association",
						role = "child",
					},
				},
			];

		public static featureBinding<FeatureAssociation.StructureEquipment> StructureEquipment(string role) => new featureBinding<FeatureAssociation.StructureEquipment> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("StructureEquipment") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A floating object moored to the bottom in a particular (charted) place, as an aid to navigation or for other specific purposes.
	/// </summary>
	public abstract class GenericBuoy : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(GenericBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Generic Buoy";

		#region Attributes
		[JsonIgnore]
		public int? buoyShape {
			set { base.SetAttribute(new buoyShape { value = value }); }
			get { return base.GetAttributeValue<buoyShape>(nameof(buoyShape))?.value; }
		}
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? radarConspicuous {
			set { base.SetAttribute(new radarConspicuous { value = value }); }
			get { return base.GetAttributeValue<radarConspicuous>(nameof(radarConspicuous))?.value; }
		}
		[JsonIgnore]
		public int? marksNavigationalSystemOf {
			set { base.SetAttribute(new marksNavigationalSystemOf { value = value }); }
			get { return base.GetAttributeValue<marksNavigationalSystemOf>(nameof(marksNavigationalSystemOf))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public String? typeOfBuoy {
			set { base.SetAttribute(new typeOfBuoy { value = value }); }
			get { return base.GetAttributeValue<typeOfBuoy>(nameof(typeOfBuoy))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(buoyShape),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8],
					CreateInstance = () => new buoyShape(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 1,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarConspicuous),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new radarConspicuous(),
				},
				new attributeBindingDefinition {
					attribute = nameof(marksNavigationalSystemOf),
					lower = 0,
					upper = 1,
					order = 4,
					permitedValues = [1,2,9,10,11,12,13,15],
					CreateInstance = () => new marksNavigationalSystemOf(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 6,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(typeOfBuoy),
					lower = 0,
					upper = 1,
					order = 7,
					CreateInstance = () => new typeOfBuoy(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => GenericBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => GenericBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A fixed artificial navigation mark that can be recognized by its shape, colour, pattern, topmark or light character, or a combination of these. It may carry various additional aids to navigation.
	/// </summary>
	public abstract class GenericBeacon : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(GenericBeacon);
		[JsonIgnore]
		public override string S100FC_name => "Generic Beacon";

		#region Attributes
		[JsonIgnore]
		public int? beaconShape {
			set { base.SetAttribute(new beaconShape { value = value }); }
			get { return base.GetAttributeValue<beaconShape>(nameof(beaconShape))?.value; }
		}
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? radarConspicuous {
			set { base.SetAttribute(new radarConspicuous { value = value }); }
			get { return base.GetAttributeValue<radarConspicuous>(nameof(radarConspicuous))?.value; }
		}
		[JsonIgnore]
		public int? visualProminence {
			set { base.SetAttribute(new visualProminence { value = value }); }
			get { return base.GetAttributeValue<visualProminence>(nameof(visualProminence))?.value; }
		}
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
		}
		[JsonIgnore]
		public int? marksNavigationalSystemOf {
			set { base.SetAttribute(new marksNavigationalSystemOf { value = value }); }
			get { return base.GetAttributeValue<marksNavigationalSystemOf>(nameof(marksNavigationalSystemOf))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? verticalLength {
			set { base.SetAttribute(new verticalLength { value = value }); }
			get { return base.GetAttributeValue<verticalLength>(nameof(verticalLength))?.value; }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? verticalAccuracy {
			set { base.SetAttribute(new verticalAccuracy { value = value }); }
			get { return base.GetAttributeValue<verticalAccuracy>(nameof(verticalAccuracy))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(beaconShape),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7],
					CreateInstance = () => new beaconShape(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 1,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarConspicuous),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new radarConspicuous(),
				},
				new attributeBindingDefinition {
					attribute = nameof(visualProminence),
					lower = 0,
					upper = 1,
					order = 4,
					permitedValues = [1,2,3],
					CreateInstance = () => new visualProminence(),
				},
				new attributeBindingDefinition {
					attribute = nameof(height),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new height(),
				},
				new attributeBindingDefinition {
					attribute = nameof(marksNavigationalSystemOf),
					lower = 0,
					upper = 1,
					order = 6,
					permitedValues = [1,2,9,10,11,12,13,15],
					CreateInstance = () => new marksNavigationalSystemOf(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 7,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalLength),
					lower = 0,
					upper = 1,
					order = 8,
					CreateInstance = () => new verticalLength(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 9,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalAccuracy),
					lower = 0,
					upper = 1,
					order = 10,
					CreateInstance = () => new verticalAccuracy(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => GenericBeacon.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => GenericBeacon.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A source of light, usually artificial, that serves as an aid to navigation, providing visibility and guidance, especially in low-light conditions. It could be mounted on various structures like buoys, beacons, or lighthouses to indicate a specific location or navigational point
	/// </summary>
	public abstract class GenericLight : Equipment
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(GenericLight);
		[JsonIgnore]
		public override string S100FC_name => "Generic Light";

		#region Attributes
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
		}
		[JsonIgnore]
		public int? verticalDatum {
			set { base.SetAttribute(new verticalDatum { value = value }); }
			get { return base.GetAttributeValue<verticalDatum>(nameof(verticalDatum))?.value; }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? effectiveIntensity {
			set { base.SetAttribute(new effectiveIntensity { value = value }); }
			get { return base.GetAttributeValue<effectiveIntensity>(nameof(effectiveIntensity))?.value; }
		}
		[JsonIgnore]
		public decimal? peakIntensity {
			set { base.SetAttribute(new peakIntensity { value = value }); }
			get { return base.GetAttributeValue<peakIntensity>(nameof(peakIntensity))?.value; }
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
					attribute = nameof(verticalDatum),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49],
					CreateInstance = () => new verticalDatum(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(effectiveIntensity),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new effectiveIntensity(),
				},
				new attributeBindingDefinition {
					attribute = nameof(peakIntensity),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new peakIntensity(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => GenericLight.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => GenericLight.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.
	/// </summary>
	public class NavigationLine : AidsToNavigation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NavigationLine);
		[JsonIgnore]
		public override string S100FC_name => "Navigation Line";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfNavigationLine {
			set { base.SetAttribute(new categoryOfNavigationLine { value = value }); }
			get { return base.GetAttributeValue<categoryOfNavigationLine>(nameof(categoryOfNavigationLine))?.value; }
		}
		[JsonIgnore]
		public orientation? orientation {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<orientation>(nameof(orientation)); }
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
					attribute = nameof(categoryOfNavigationLine),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfNavigationLine(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientation),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new orientation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => NavigationLine.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => NavigationLine.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. AidsToNavigation.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "navigableTrack",
					association = "RangeSystem",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(RecommendedTrack)],
					CreateInstance = () => new featureBinding<FeatureAssociation.RangeSystem>() {
						roleType = "association",
						role = "navigableTrack",
					},
				},
			];

		public static featureBinding<FeatureAssociation.RangeSystem> RangeSystem(string role) => new featureBinding<FeatureAssociation.RangeSystem> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("RangeSystem") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.curve];
	}

	/// <summary>
	/// A route which has been specially examined to ensure so far as possible that it is free of dangers and along which ships are advised to navigate.
	/// </summary>
	public class RecommendedTrack : AidsToNavigation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RecommendedTrack);
		[JsonIgnore]
		public override string S100FC_name => "Recommended Track";

		#region Attributes
		[JsonIgnore]
		public Boolean? basedOnFixedMarks {
			set { base.SetAttribute(new basedOnFixedMarks { value = value }); }
			get { return base.GetAttributeValue<basedOnFixedMarks>(nameof(basedOnFixedMarks))?.value; }
		}
		[JsonIgnore]
		public decimal? depthRangeMinimumValue {
			set { base.SetAttribute(new depthRangeMinimumValue { value = value }); }
			get { return base.GetAttributeValue<depthRangeMinimumValue>(nameof(depthRangeMinimumValue))?.value; }
		}
		[JsonIgnore]
		public decimal? maximalPermittedDraught {
			set { base.SetAttribute(new maximalPermittedDraught { value = value }); }
			get { return base.GetAttributeValue<maximalPermittedDraught>(nameof(maximalPermittedDraught))?.value; }
		}
		[JsonIgnore]
		public orientation? orientation {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<orientation>(nameof(orientation)); }
		}
		[JsonIgnore]
		public int?[] qualityOfVerticalMeasurement {
			set { base.SetAttribute("qualityOfVerticalMeasurement", [.. value.Select(e=> new qualityOfVerticalMeasurement { value = e })]); }
			get { return base.GetAttributeValues<qualityOfVerticalMeasurement>(nameof(qualityOfVerticalMeasurement)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public verticalUncertainty? verticalUncertainty {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<verticalUncertainty>(nameof(verticalUncertainty)); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] techniqueOfVerticalMeasurement {
			set { base.SetAttribute("techniqueOfVerticalMeasurement", [.. value.Select(e=> new techniqueOfVerticalMeasurement { value = e })]); }
			get { return base.GetAttributeValues<techniqueOfVerticalMeasurement>(nameof(techniqueOfVerticalMeasurement)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? trafficFlow {
			set { base.SetAttribute(new trafficFlow { value = value }); }
			get { return base.GetAttributeValue<trafficFlow>(nameof(trafficFlow))?.value; }
		}
		[JsonIgnore]
		public int? verticalDatum {
			set { base.SetAttribute(new verticalDatum { value = value }); }
			get { return base.GetAttributeValue<verticalDatum>(nameof(verticalDatum))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(basedOnFixedMarks),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new basedOnFixedMarks(),
				},
				new attributeBindingDefinition {
					attribute = nameof(depthRangeMinimumValue),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new depthRangeMinimumValue(),
				},
				new attributeBindingDefinition {
					attribute = nameof(maximalPermittedDraught),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new maximalPermittedDraught(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientation),
					lower = 1,
					upper = 1,
					order = 3,
					CreateInstance = () => new orientation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(qualityOfVerticalMeasurement),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new qualityOfVerticalMeasurement(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalUncertainty),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new verticalUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 6,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(techniqueOfVerticalMeasurement),
					lower = 0,
					upper = 2147483647,
					order = 7,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18],
					CreateInstance = () => new techniqueOfVerticalMeasurement(),
				},
				new attributeBindingDefinition {
					attribute = nameof(trafficFlow),
					lower = 1,
					upper = 1,
					order = 8,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new trafficFlow(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalDatum),
					lower = 0,
					upper = 1,
					order = 9,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49],
					CreateInstance = () => new verticalDatum(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => RecommendedTrack.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => RecommendedTrack.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. AidsToNavigation.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "navigationLine",
					association = "RangeSystem",
					lower = 1,
					upper = 2147483647,
					featureTypes = [nameof(NavigationLine)],
					CreateInstance = () => new featureBinding<FeatureAssociation.RangeSystem>() {
						roleType = "association",
						role = "navigationLine",
					},
				},
			];

		public static featureBinding<FeatureAssociation.RangeSystem> RangeSystem(string role) => new featureBinding<FeatureAssociation.RangeSystem> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("RangeSystem") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.curve];
	}

	/// <summary>
	/// Any prominent object at a fixed location on land which can be used in determining a location or a direction.
	/// </summary>
	public class Landmark : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Landmark);
		[JsonIgnore]
		public override string S100FC_name => "Landmark";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfLandmark {
			set { base.SetAttribute("categoryOfLandmark", [.. value.Select(e=> new categoryOfLandmark { value = e })]); }
			get { return base.GetAttributeValues<categoryOfLandmark>(nameof(categoryOfLandmark)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? radarConspicuous {
			set { base.SetAttribute(new radarConspicuous { value = value }); }
			get { return base.GetAttributeValue<radarConspicuous>(nameof(radarConspicuous))?.value; }
		}
		[JsonIgnore]
		public int? visualProminence {
			set { base.SetAttribute(new visualProminence { value = value }); }
			get { return base.GetAttributeValue<visualProminence>(nameof(visualProminence))?.value; }
		}
		[JsonIgnore]
		public int?[] function {
			set { base.SetAttribute("function", [.. value.Select(e=> new function { value = e })]); }
			get { return base.GetAttributeValues<function>(nameof(function)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
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
					attribute = nameof(categoryOfLandmark),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27],
					CreateInstance = () => new categoryOfLandmark(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarConspicuous),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new radarConspicuous(),
				},
				new attributeBindingDefinition {
					attribute = nameof(visualProminence),
					lower = 1,
					upper = 1,
					order = 4,
					permitedValues = [1,2,3],
					CreateInstance = () => new visualProminence(),
				},
				new attributeBindingDefinition {
					attribute = nameof(function),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50],
					CreateInstance = () => new function(),
				},
				new attributeBindingDefinition {
					attribute = nameof(height),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new height(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 7,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 8,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Landmark.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Landmark.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// (1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.
	/// </summary>
	public class Daymark : Equipment
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Daymark);
		[JsonIgnore]
		public override string S100FC_name => "Daymark";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfSpecialPurposeMark {
			set { base.SetAttribute(new categoryOfSpecialPurposeMark { value = value }); }
			get { return base.GetAttributeValue<categoryOfSpecialPurposeMark>(nameof(categoryOfSpecialPurposeMark))?.value; }
		}
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? topmarkDaymarkShape {
			set { base.SetAttribute(new topmarkDaymarkShape { value = value }); }
			get { return base.GetAttributeValue<topmarkDaymarkShape>(nameof(topmarkDaymarkShape))?.value; }
		}
		[JsonIgnore]
		public Boolean? isSlatted {
			set { base.SetAttribute(new isSlatted { value = value }); }
			get { return base.GetAttributeValue<isSlatted>(nameof(isSlatted))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfSpecialPurposeMark),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64],
					CreateInstance = () => new categoryOfSpecialPurposeMark(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 1,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(height),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new height(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(topmarkDaymarkShape),
					lower = 1,
					upper = 1,
					order = 6,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34],
					CreateInstance = () => new topmarkDaymarkShape(),
				},
				new attributeBindingDefinition {
					attribute = nameof(isSlatted),
					lower = 1,
					upper = 1,
					order = 7,
					CreateInstance = () => new isSlatted(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Daymark.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Daymark.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A warning signal transmitted by a vessel, or aid to navigation, during periods of low visibility. Also, the device producing such a signal.
	/// </summary>
	public class FogSignal : Equipment
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(FogSignal);
		[JsonIgnore]
		public override string S100FC_name => "Fog Signal";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfFogSignal {
			set { base.SetAttribute(new categoryOfFogSignal { value = value }); }
			get { return base.GetAttributeValue<categoryOfFogSignal>(nameof(categoryOfFogSignal))?.value; }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public signalSequence? signalSequence {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<signalSequence>(nameof(signalSequence)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfFogSignal),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10],
					CreateInstance = () => new categoryOfFogSignal(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalSequence),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new signalSequence(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => FogSignal.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => FogSignal.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A device capable of, or intended for, reflecting radar signals.
	/// </summary>
	public class RadarReflector : Equipment
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadarReflector);
		[JsonIgnore]
		public override string S100FC_name => "Radar Reflector";

		#region Attributes
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
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
					attribute = nameof(height),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new height(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => RadarReflector.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => RadarReflector.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A transponder beacon transmitting a coded signal on radar frequency, permitting an interrogating craft to determine the bearing and range of the transponder.
	/// </summary>
	public class RadarTransponderBeacon : Equipment
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadarTransponderBeacon);
		[JsonIgnore]
		public override string S100FC_name => "Radar Transponder Beacon";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfRadarTransponderBeacon {
			set { base.SetAttribute(new categoryOfRadarTransponderBeacon { value = value }); }
			get { return base.GetAttributeValue<categoryOfRadarTransponderBeacon>(nameof(categoryOfRadarTransponderBeacon))?.value; }
		}
		[JsonIgnore]
		public sectorLimitOne? sectorLimitOne {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<sectorLimitOne>(nameof(sectorLimitOne)); }
		}
		[JsonIgnore]
		public sectorLimitTwo? sectorLimitTwo {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<sectorLimitTwo>(nameof(sectorLimitTwo)); }
		}
		[JsonIgnore]
		public String? signalGroup {
			set { base.SetAttribute(new signalGroup { value = value }); }
			get { return base.GetAttributeValue<signalGroup>(nameof(signalGroup))?.value; }
		}
		[JsonIgnore]
		public signalSequence? signalSequence {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<signalSequence>(nameof(signalSequence)); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? valueOfNominalRange {
			set { base.SetAttribute(new valueOfNominalRange { value = value }); }
			get { return base.GetAttributeValue<valueOfNominalRange>(nameof(valueOfNominalRange))?.value; }
		}
		[JsonIgnore]
		public radarWaveLength? radarWaveLength {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<radarWaveLength>(nameof(radarWaveLength)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfRadarTransponderBeacon),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfRadarTransponderBeacon(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorLimitOne),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new sectorLimitOne(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorLimitTwo),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new sectorLimitTwo(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalGroup),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new signalGroup(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalSequence),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new signalSequence(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(valueOfNominalRange),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new valueOfNominalRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarWaveLength),
					lower = 0,
					upper = 1,
					order = 7,
					CreateInstance = () => new radarWaveLength(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => RadarTransponderBeacon.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => RadarTransponderBeacon.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
	/// </summary>
	public class RadioStation : Equipment
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(RadioStation);
		[JsonIgnore]
		public override string S100FC_name => "Radio Station";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfRadioStation {
			set { base.SetAttribute(new categoryOfRadioStation { value = value }); }
			get { return base.GetAttributeValue<categoryOfRadioStation>(nameof(categoryOfRadioStation))?.value; }
		}
		[JsonIgnore]
		public decimal? estimatedRangeOfTransmission {
			set { base.SetAttribute(new estimatedRangeOfTransmission { value = value }); }
			get { return base.GetAttributeValue<estimatedRangeOfTransmission>(nameof(estimatedRangeOfTransmission))?.value; }
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
					attribute = nameof(categoryOfRadioStation),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [20],
					CreateInstance = () => new categoryOfRadioStation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(estimatedRangeOfTransmission),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new estimatedRangeOfTransmission(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => RadioStation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => RadioStation.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. Equipment.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "physicalAISBroadcastBy",
					association = "PhysicalAIS",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(PhysicalAISAidToNavigation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.PhysicalAIS>() {
						roleType = "association",
						role = "physicalAISBroadcastBy",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "syntheticAISBroadcastBy",
					association = "SyntheticAIS",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(SyntheticAISAidToNavigation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.SyntheticAIS>() {
						roleType = "association",
						role = "syntheticAISBroadcastBy",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "virtualAISBroadcastBy",
					association = "VirtualAIS",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(VirtualAISAidToNavigation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.VirtualAIS>() {
						roleType = "association",
						role = "virtualAISBroadcastBy",
					},
				},
			];

		public static featureBinding<FeatureAssociation.PhysicalAIS> PhysicalAIS(string role) => new featureBinding<FeatureAssociation.PhysicalAIS> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("PhysicalAIS") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.SyntheticAIS> SyntheticAIS(string role) => new featureBinding<FeatureAssociation.SyntheticAIS> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("SyntheticAIS") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.VirtualAIS> VirtualAIS(string role) => new featureBinding<FeatureAssociation.VirtualAIS> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("VirtualAIS") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A means of distinguishing unlighted marks at night. Retroreflective material is secured to the mark in a particular pattern to reflect back light.
	/// </summary>
	public class Retroreflector : Equipment
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Retroreflector);
		[JsonIgnore]
		public override string S100FC_name => "Retroreflector";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? marksNavigationalSystemOf {
			set { base.SetAttribute(new marksNavigationalSystemOf { value = value }); }
			get { return base.GetAttributeValue<marksNavigationalSystemOf>(nameof(marksNavigationalSystemOf))?.value; }
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
					attribute = nameof(colour),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(marksNavigationalSystemOf),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,9,10,11,12,13,15],
					CreateInstance = () => new marksNavigationalSystemOf(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Retroreflector.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Retroreflector.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
	/// </summary>
	public class LightAirObstruction : GenericLight
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LightAirObstruction);
		[JsonIgnore]
		public override string S100FC_name => "Light Air Obstruction";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] lightVisibility {
			set { base.SetAttribute("lightVisibility", [.. value.Select(e=> new lightVisibility { value = e })]); }
			get { return base.GetAttributeValues<lightVisibility>(nameof(lightVisibility)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? exhibitionConditionOfLight {
			set { base.SetAttribute(new exhibitionConditionOfLight { value = value }); }
			get { return base.GetAttributeValue<exhibitionConditionOfLight>(nameof(exhibitionConditionOfLight))?.value; }
		}
		[JsonIgnore]
		public decimal? valueOfNominalRange {
			set { base.SetAttribute(new valueOfNominalRange { value = value }); }
			get { return base.GetAttributeValue<valueOfNominalRange>(nameof(valueOfNominalRange))?.value; }
		}
		[JsonIgnore]
		public int? flareBearing {
			set { base.SetAttribute(new flareBearing { value = value }); }
			get { return base.GetAttributeValue<flareBearing>(nameof(flareBearing))?.value; }
		}
		[JsonIgnore]
		public multiplicityOfFeatures? multiplicityOfFeatures {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<multiplicityOfFeatures>(nameof(multiplicityOfFeatures)); }
		}
		[JsonIgnore]
		public rhythmOfLight? rhythmOfLight {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<rhythmOfLight>(nameof(rhythmOfLight)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(lightVisibility),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new lightVisibility(),
				},
				new attributeBindingDefinition {
					attribute = nameof(exhibitionConditionOfLight),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new exhibitionConditionOfLight(),
				},
				new attributeBindingDefinition {
					attribute = nameof(valueOfNominalRange),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new valueOfNominalRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(flareBearing),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new flareBearing(),
				},
				new attributeBindingDefinition {
					attribute = nameof(multiplicityOfFeatures),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new multiplicityOfFeatures(),
				},
				new attributeBindingDefinition {
					attribute = nameof(rhythmOfLight),
					lower = 1,
					upper = 1,
					order = 6,
					CreateInstance = () => new rhythmOfLight(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LightAirObstruction.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LightAirObstruction.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
	/// </summary>
	public class LightAllAround : GenericLight
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LightAllAround);
		[JsonIgnore]
		public override string S100FC_name => "Light All Around";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? signalGeneration {
			set { base.SetAttribute(new signalGeneration { value = value }); }
			get { return base.GetAttributeValue<signalGeneration>(nameof(signalGeneration))?.value; }
		}
		[JsonIgnore]
		public int? marksNavigationalSystemOf {
			set { base.SetAttribute(new marksNavigationalSystemOf { value = value }); }
			get { return base.GetAttributeValue<marksNavigationalSystemOf>(nameof(marksNavigationalSystemOf))?.value; }
		}
		[JsonIgnore]
		public Boolean? majorLight {
			set { base.SetAttribute(new majorLight { value = value }); }
			get { return base.GetAttributeValue<majorLight>(nameof(majorLight))?.value; }
		}
		[JsonIgnore]
		public int? lightVisibility {
			set { base.SetAttribute(new lightVisibility { value = value }); }
			get { return base.GetAttributeValue<lightVisibility>(nameof(lightVisibility))?.value; }
		}
		[JsonIgnore]
		public int? exhibitionConditionOfLight {
			set { base.SetAttribute(new exhibitionConditionOfLight { value = value }); }
			get { return base.GetAttributeValue<exhibitionConditionOfLight>(nameof(exhibitionConditionOfLight))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfLight {
			set { base.SetAttribute("categoryOfLight", [.. value.Select(e=> new categoryOfLight { value = e })]); }
			get { return base.GetAttributeValues<categoryOfLight>(nameof(categoryOfLight)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public decimal? valueOfNominalRange {
			set { base.SetAttribute(new valueOfNominalRange { value = value }); }
			get { return base.GetAttributeValue<valueOfNominalRange>(nameof(valueOfNominalRange))?.value; }
		}
		[JsonIgnore]
		public int? flareBearing {
			set { base.SetAttribute(new flareBearing { value = value }); }
			get { return base.GetAttributeValue<flareBearing>(nameof(flareBearing))?.value; }
		}
		[JsonIgnore]
		public multiplicityOfFeatures? multiplicityOfFeatures {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<multiplicityOfFeatures>(nameof(multiplicityOfFeatures)); }
		}
		[JsonIgnore]
		public rhythmOfLight? rhythmOfLight {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<rhythmOfLight>(nameof(rhythmOfLight)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,3,4,5,6,9,10,11],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalGeneration),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new signalGeneration(),
				},
				new attributeBindingDefinition {
					attribute = nameof(marksNavigationalSystemOf),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,9,10,11,12,13,15],
					CreateInstance = () => new marksNavigationalSystemOf(),
				},
				new attributeBindingDefinition {
					attribute = nameof(majorLight),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new majorLight(),
				},
				new attributeBindingDefinition {
					attribute = nameof(lightVisibility),
					lower = 0,
					upper = 1,
					order = 4,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new lightVisibility(),
				},
				new attributeBindingDefinition {
					attribute = nameof(exhibitionConditionOfLight),
					lower = 0,
					upper = 1,
					order = 5,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new exhibitionConditionOfLight(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfLight),
					lower = 0,
					upper = 2147483647,
					order = 6,
					permitedValues = [4,5,8,9,10,11,12,13,14,15,17,18,19,20],
					CreateInstance = () => new categoryOfLight(),
				},
				new attributeBindingDefinition {
					attribute = nameof(valueOfNominalRange),
					lower = 0,
					upper = 1,
					order = 7,
					CreateInstance = () => new valueOfNominalRange(),
				},
				new attributeBindingDefinition {
					attribute = nameof(flareBearing),
					lower = 0,
					upper = 1,
					order = 8,
					CreateInstance = () => new flareBearing(),
				},
				new attributeBindingDefinition {
					attribute = nameof(multiplicityOfFeatures),
					lower = 0,
					upper = 1,
					order = 9,
					CreateInstance = () => new multiplicityOfFeatures(),
				},
				new attributeBindingDefinition {
					attribute = nameof(rhythmOfLight),
					lower = 1,
					upper = 1,
					order = 10,
					CreateInstance = () => new rhythmOfLight(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LightAllAround.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LightAllAround.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.
	/// </summary>
	public class LightFogDetector : GenericLight
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LightFogDetector);
		[JsonIgnore]
		public override string S100FC_name => "Light Fog Detector";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? signalGeneration {
			set { base.SetAttribute(new signalGeneration { value = value }); }
			get { return base.GetAttributeValue<signalGeneration>(nameof(signalGeneration))?.value; }
		}
		[JsonIgnore]
		public rhythmOfLight? rhythmOfLight {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<rhythmOfLight>(nameof(rhythmOfLight)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,3,4,5,6,9,10,11],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(signalGeneration),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new signalGeneration(),
				},
				new attributeBindingDefinition {
					attribute = nameof(rhythmOfLight),
					lower = 1,
					upper = 1,
					order = 2,
					CreateInstance = () => new rhythmOfLight(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LightFogDetector.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LightFogDetector.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
	/// </summary>
	public class LightSectored : GenericLight
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LightSectored);
		[JsonIgnore]
		public override string S100FC_name => "Light Sectored";

		#region Attributes
		[JsonIgnore]
		public int? signalGeneration {
			set { base.SetAttribute(new signalGeneration { value = value }); }
			get { return base.GetAttributeValue<signalGeneration>(nameof(signalGeneration))?.value; }
		}
		[JsonIgnore]
		public int? marksNavigationalSystemOf {
			set { base.SetAttribute(new marksNavigationalSystemOf { value = value }); }
			get { return base.GetAttributeValue<marksNavigationalSystemOf>(nameof(marksNavigationalSystemOf))?.value; }
		}
		[JsonIgnore]
		public int? exhibitionConditionOfLight {
			set { base.SetAttribute(new exhibitionConditionOfLight { value = value }); }
			get { return base.GetAttributeValue<exhibitionConditionOfLight>(nameof(exhibitionConditionOfLight))?.value; }
		}
		[JsonIgnore]
		public int?[] categoryOfLight {
			set { base.SetAttribute("categoryOfLight", [.. value.Select(e=> new categoryOfLight { value = e })]); }
			get { return base.GetAttributeValues<categoryOfLight>(nameof(categoryOfLight)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public sectorCharacteristics?[] sectorCharacteristics {
			set { base.SetAttribute("sectorCharacteristics", value); }
			get { return base.GetAttributeValues<sectorCharacteristics>(nameof(sectorCharacteristics)); }
		}
		[JsonIgnore]
		public obscuredSector?[] obscuredSector {
			set { base.SetAttribute("obscuredSector", value); }
			get { return base.GetAttributeValues<obscuredSector>(nameof(obscuredSector)); }
		}
		[JsonIgnore]
		public multiplicityOfFeatures? multiplicityOfFeatures {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<multiplicityOfFeatures>(nameof(multiplicityOfFeatures)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(signalGeneration),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new signalGeneration(),
				},
				new attributeBindingDefinition {
					attribute = nameof(marksNavigationalSystemOf),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,9,10,11,12,13,15],
					CreateInstance = () => new marksNavigationalSystemOf(),
				},
				new attributeBindingDefinition {
					attribute = nameof(exhibitionConditionOfLight),
					lower = 0,
					upper = 1,
					order = 2,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new exhibitionConditionOfLight(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfLight),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [4,5,8,9,10,11,12,13,14,15,17,18,19,20],
					CreateInstance = () => new categoryOfLight(),
				},
				new attributeBindingDefinition {
					attribute = nameof(sectorCharacteristics),
					lower = 1,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new sectorCharacteristics(),
				},
				new attributeBindingDefinition {
					attribute = nameof(obscuredSector),
					lower = 0,
					upper = 2147483647,
					order = 5,
					CreateInstance = () => new obscuredSector(),
				},
				new attributeBindingDefinition {
					attribute = nameof(multiplicityOfFeatures),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new multiplicityOfFeatures(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LightSectored.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LightSectored.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.
	/// </summary>
	public class LightFloat : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LightFloat);
		[JsonIgnore]
		public override string S100FC_name => "Light Float";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? radarConspicuous {
			set { base.SetAttribute(new radarConspicuous { value = value }); }
			get { return base.GetAttributeValue<radarConspicuous>(nameof(radarConspicuous))?.value; }
		}
		[JsonIgnore]
		public int? visualProminence {
			set { base.SetAttribute(new visualProminence { value = value }); }
			get { return base.GetAttributeValue<visualProminence>(nameof(visualProminence))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
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
					attribute = nameof(colour),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarConspicuous),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new radarConspicuous(),
				},
				new attributeBindingDefinition {
					attribute = nameof(visualProminence),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new visualProminence(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LightFloat.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LightFloat.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A distinctively marked vessel anchored or moored at a charted point, to serve as an aid to navigation. By night, it displays a characteristic light(s) and is usually equipped with other devices, such as fog signal, submarine sound signal, and radio-beacon, to assist navigation.
	/// </summary>
	public class LightVessel : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LightVessel);
		[JsonIgnore]
		public override string S100FC_name => "Light Vessel";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? radarConspicuous {
			set { base.SetAttribute(new radarConspicuous { value = value }); }
			get { return base.GetAttributeValue<radarConspicuous>(nameof(radarConspicuous))?.value; }
		}
		[JsonIgnore]
		public int? visualProminence {
			set { base.SetAttribute(new visualProminence { value = value }); }
			get { return base.GetAttributeValue<visualProminence>(nameof(visualProminence))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
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
					attribute = nameof(colour),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarConspicuous),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new radarConspicuous(),
				},
				new attributeBindingDefinition {
					attribute = nameof(visualProminence),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new visualProminence(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 4,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LightVessel.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LightVessel.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A permanent offshore structure, either fixed or floating.
	/// </summary>
	public class OffshorePlatform : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(OffshorePlatform);
		[JsonIgnore]
		public override string S100FC_name => "Offshore Platform";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfOffshorePlatform {
			set { base.SetAttribute("categoryOfOffshorePlatform", [.. value.Select(e=> new categoryOfOffshorePlatform { value = e })]); }
			get { return base.GetAttributeValues<categoryOfOffshorePlatform>(nameof(categoryOfOffshorePlatform)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? condition {
			set { base.SetAttribute(new condition { value = value }); }
			get { return base.GetAttributeValue<condition>(nameof(condition))?.value; }
		}
		[JsonIgnore]
		public Boolean? radarConspicuous {
			set { base.SetAttribute(new radarConspicuous { value = value }); }
			get { return base.GetAttributeValue<radarConspicuous>(nameof(radarConspicuous))?.value; }
		}
		[JsonIgnore]
		public int? visualProminence {
			set { base.SetAttribute(new visualProminence { value = value }); }
			get { return base.GetAttributeValue<visualProminence>(nameof(visualProminence))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
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
					attribute = nameof(categoryOfOffshorePlatform),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11],
					CreateInstance = () => new categoryOfOffshorePlatform(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(condition),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3,4,5],
					CreateInstance = () => new condition(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarConspicuous),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new radarConspicuous(),
				},
				new attributeBindingDefinition {
					attribute = nameof(visualProminence),
					lower = 0,
					upper = 1,
					order = 5,
					permitedValues = [1,2,3],
					CreateInstance = () => new visualProminence(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 6,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 7,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => OffshorePlatform.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => OffshorePlatform.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A long heavy timber or section of steel, wood, concrete, etc., forced into the earth or seafloor to serve as a support, as for a pier, or to resist lateral pressure; or as a free standing pole within a marine environment.
	/// </summary>
	public class Pile : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Pile);
		[JsonIgnore]
		public override string S100FC_name => "Pile";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfPile {
			set { base.SetAttribute(new categoryOfPile { value = value }); }
			get { return base.GetAttributeValue<categoryOfPile>(nameof(categoryOfPile))?.value; }
		}
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? visualProminence {
			set { base.SetAttribute(new visualProminence { value = value }); }
			get { return base.GetAttributeValue<visualProminence>(nameof(visualProminence))?.value; }
		}
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPile),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [1,3,4,5,6,7,8],
					CreateInstance = () => new categoryOfPile(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(visualProminence),
					lower = 0,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3],
					CreateInstance = () => new visualProminence(),
				},
				new attributeBindingDefinition {
					attribute = nameof(height),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new height(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Pile.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Pile.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A large storage structure used for storing loose materials, liquids and/or gases.
	/// </summary>
	public class SiloTank : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SiloTank);
		[JsonIgnore]
		public override string S100FC_name => "Silo/Tank";

		#region Attributes
		[JsonIgnore]
		public int? buildingShape {
			set { base.SetAttribute(new buildingShape { value = value }); }
			get { return base.GetAttributeValue<buildingShape>(nameof(buildingShape))?.value; }
		}
		[JsonIgnore]
		public int? categoryOfSiloTank {
			set { base.SetAttribute(new categoryOfSiloTank { value = value }); }
			get { return base.GetAttributeValue<categoryOfSiloTank>(nameof(categoryOfSiloTank))?.value; }
		}
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean? radarConspicuous {
			set { base.SetAttribute(new radarConspicuous { value = value }); }
			get { return base.GetAttributeValue<radarConspicuous>(nameof(radarConspicuous))?.value; }
		}
		[JsonIgnore]
		public int? visualProminence {
			set { base.SetAttribute(new visualProminence { value = value }); }
			get { return base.GetAttributeValue<visualProminence>(nameof(visualProminence))?.value; }
		}
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
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
					attribute = nameof(buildingShape),
					lower = 0,
					upper = 1,
					order = 0,
					permitedValues = [5,6,7,8,9],
					CreateInstance = () => new buildingShape(),
				},
				new attributeBindingDefinition {
					attribute = nameof(categoryOfSiloTank),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfSiloTank(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarConspicuous),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new radarConspicuous(),
				},
				new attributeBindingDefinition {
					attribute = nameof(visualProminence),
					lower = 0,
					upper = 1,
					order = 5,
					permitedValues = [1,2,3],
					CreateInstance = () => new visualProminence(),
				},
				new attributeBindingDefinition {
					attribute = nameof(height),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new height(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 7,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 8,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SiloTank.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SiloTank.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A cardinal buoy is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
	/// </summary>
	public class CardinalBuoy : GenericBuoy
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(CardinalBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Cardinal Buoy";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfCardinalMark {
			set { base.SetAttribute(new categoryOfCardinalMark { value = value }); }
			get { return base.GetAttributeValue<categoryOfCardinalMark>(nameof(categoryOfCardinalMark))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCardinalMark),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfCardinalMark(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => CardinalBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => CardinalBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An emergency wreck marking buoy is a buoy moored on or above a new wreck, designed to provide a prominent (both visual and radio) and easily identifiable temporary first response.
	/// </summary>
	public class EmergencyWreckMarkingBuoy : GenericBuoy
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(EmergencyWreckMarkingBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Emergency Wreck Marking Buoy";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => EmergencyWreckMarkingBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => EmergencyWreckMarkingBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An installation buoy is a buoy used for loading tankers with gas or oil.
	/// </summary>
	public class InstallationBuoy : GenericBuoy
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(InstallationBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Installation Buoy";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfInstallationBuoy {
			set { base.SetAttribute(new categoryOfInstallationBuoy { value = value }); }
			get { return base.GetAttributeValue<categoryOfInstallationBuoy>(nameof(categoryOfInstallationBuoy))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfInstallationBuoy),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfInstallationBuoy(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => InstallationBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => InstallationBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An isolated danger buoy is a buoy moored on or above an isolated danger of limited extent, which has navigable water all around it.
	/// </summary>
	public class IsolatedDangerBuoy : GenericBuoy
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(IsolatedDangerBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Isolated Danger Buoy";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => IsolatedDangerBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => IsolatedDangerBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well-defined channels and are used in conjunction with a conventional direction of buoyage.
	/// </summary>
	public class LateralBuoy : GenericBuoy
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LateralBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Lateral Buoy";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfLateralMark {
			set { base.SetAttribute(new categoryOfLateralMark { value = value }); }
			get { return base.GetAttributeValue<categoryOfLateralMark>(nameof(categoryOfLateralMark))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfLateralMark),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27],
					CreateInstance = () => new categoryOfLateralMark(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LateralBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LateralBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.
	/// </summary>
	public class MooringBuoy : GenericBuoy
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(MooringBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Mooring Buoy";

		#region Catalogue
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
	/// A safe water buoy is used to indicate that there is navigable water around the mark.
	/// </summary>
	public class SafeWaterBuoy : GenericBuoy
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SafeWaterBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Safe Water Buoy";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SafeWaterBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SafeWaterBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
	/// </summary>
	public class SpecialPurposeGeneralBuoy : GenericBuoy
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SpecialPurposeGeneralBuoy);
		[JsonIgnore]
		public override string S100FC_name => "Special Purpose/General Buoy";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfSpecialPurposeMark {
			set { base.SetAttribute("categoryOfSpecialPurposeMark", [.. value.Select(e=> new categoryOfSpecialPurposeMark { value = e })]); }
			get { return base.GetAttributeValues<categoryOfSpecialPurposeMark>(nameof(categoryOfSpecialPurposeMark)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfSpecialPurposeMark),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64],
					CreateInstance = () => new categoryOfSpecialPurposeMark(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SpecialPurposeGeneralBuoy.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SpecialPurposeGeneralBuoy.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
	/// </summary>
	public class CardinalBeacon : GenericBeacon
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(CardinalBeacon);
		[JsonIgnore]
		public override string S100FC_name => "Cardinal Beacon";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfCardinalMark {
			set { base.SetAttribute(new categoryOfCardinalMark { value = value }); }
			get { return base.GetAttributeValue<categoryOfCardinalMark>(nameof(categoryOfCardinalMark))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfCardinalMark),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4],
					CreateInstance = () => new categoryOfCardinalMark(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => CardinalBeacon.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => CardinalBeacon.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.
	/// </summary>
	public class IsolatedDangerBeacon : GenericBeacon
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(IsolatedDangerBeacon);
		[JsonIgnore]
		public override string S100FC_name => "Isolated Danger Beacon";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => IsolatedDangerBeacon.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => IsolatedDangerBeacon.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A safe water beacon is used to indicate that there is navigable water around the mark.
	/// </summary>
	public class SafeWaterBeacon : GenericBeacon
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SafeWaterBeacon);
		[JsonIgnore]
		public override string S100FC_name => "Safe Water Beacon";

		#region Catalogue
		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SafeWaterBeacon.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SafeWaterBeacon.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
	/// </summary>
	public class SpecialPurposeGeneralBeacon : GenericBeacon
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SpecialPurposeGeneralBeacon);
		[JsonIgnore]
		public override string S100FC_name => "Special Purpose/General Beacon";

		#region Attributes
		[JsonIgnore]
		public int?[] categoryOfSpecialPurposeMark {
			set { base.SetAttribute("categoryOfSpecialPurposeMark", [.. value.Select(e=> new categoryOfSpecialPurposeMark { value = e })]); }
			get { return base.GetAttributeValues<categoryOfSpecialPurposeMark>(nameof(categoryOfSpecialPurposeMark)).Select(e=>e.value).ToArray(); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfSpecialPurposeMark),
					lower = 1,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64],
					CreateInstance = () => new categoryOfSpecialPurposeMark(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SpecialPurposeGeneralBeacon.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SpecialPurposeGeneralBeacon.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage.
	/// </summary>
	public class LateralBeacon : GenericBeacon
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LateralBeacon);
		[JsonIgnore]
		public override string S100FC_name => "Lateral Beacon";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfLandmark {
			set { base.SetAttribute(new categoryOfLandmark { value = value }); }
			get { return base.GetAttributeValue<categoryOfLandmark>(nameof(categoryOfLandmark))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfLandmark),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27],
					CreateInstance = () => new categoryOfLandmark(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LateralBeacon.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LateralBeacon.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A tower and associated equipment that generates electrical power from wind. They can be sited offshore and may be either fixed or floating.
	/// </summary>
	public class WindTurbine : StructureObject
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(WindTurbine);
		[JsonIgnore]
		public override string S100FC_name => "Wind Turbine";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? colourPattern {
			set { base.SetAttribute(new colourPattern { value = value }); }
			get { return base.GetAttributeValue<colourPattern>(nameof(colourPattern))?.value; }
		}
		[JsonIgnore]
		public int? condition {
			set { base.SetAttribute(new condition { value = value }); }
			get { return base.GetAttributeValue<condition>(nameof(condition))?.value; }
		}
		[JsonIgnore]
		public decimal? elevation {
			set { base.SetAttribute(new elevation { value = value }); }
			get { return base.GetAttributeValue<elevation>(nameof(elevation))?.value; }
		}
		[JsonIgnore]
		public decimal? height {
			set { base.SetAttribute(new height { value = value }); }
			get { return base.GetAttributeValue<height>(nameof(height))?.value; }
		}
		[JsonIgnore]
		public int?[] natureOfConstruction {
			set { base.SetAttribute("natureOfConstruction", [.. value.Select(e=> new natureOfConstruction { value = e })]); }
			get { return base.GetAttributeValues<natureOfConstruction>(nameof(natureOfConstruction)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public Boolean?[] radarConspicuous {
			set { base.SetAttribute("radarConspicuous", [.. value.Select(e=> new radarConspicuous { value = e })]); }
			get { return base.GetAttributeValues<radarConspicuous>(nameof(radarConspicuous)).Select(e=>e.value).ToArray(); }
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
					attribute = nameof(colour),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 1,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(condition),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new condition(),
				},
				new attributeBindingDefinition {
					attribute = nameof(elevation),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new elevation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(height),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new height(),
				},
				new attributeBindingDefinition {
					attribute = nameof(natureOfConstruction),
					lower = 0,
					upper = 2147483647,
					order = 5,
					permitedValues = [6,7,8,9,10,11,12,13,14],
					CreateInstance = () => new natureOfConstruction(),
				},
				new attributeBindingDefinition {
					attribute = nameof(radarConspicuous),
					lower = 0,
					upper = 2147483647,
					order = 6,
					CreateInstance = () => new radarConspicuous(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 7,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => WindTurbine.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => WindTurbine.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
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
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(verticalDatum),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49],
					CreateInstance = () => new verticalDatum(),
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
		public override Primitives[] permittedPrimitives => [Primitives.point];
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
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => DataCoverage.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => DataCoverage.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An area within which the navigational system of marks has been established in relation to a specific direction.
	/// </summary>
	public class LocalDirectionOfBuoyage : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(LocalDirectionOfBuoyage);
		[JsonIgnore]
		public override string S100FC_name => "Local Direction of Buoyage";

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
				new attributeBindingDefinition {
					attribute = nameof(orientation),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new orientation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => LocalDirectionOfBuoyage.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => LocalDirectionOfBuoyage.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An area within which the navigational system of marks has been established in relation to a specific direction.
	/// </summary>
	public class NavigationalSystemOfMarks : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(NavigationalSystemOfMarks);
		[JsonIgnore]
		public override string S100FC_name => "Navigational System of Marks";

		#region Attributes
		[JsonIgnore]
		public int? marksNavigationalSystemOf {
			set { base.SetAttribute(new marksNavigationalSystemOf { value = value }); }
			get { return base.GetAttributeValue<marksNavigationalSystemOf>(nameof(marksNavigationalSystemOf))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(marksNavigationalSystemOf),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,9,10,11,12,13,15],
					CreateInstance = () => new marksNavigationalSystemOf(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => NavigationalSystemOfMarks.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => NavigationalSystemOfMarks.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
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
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(verticalDatum),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49],
					CreateInstance = () => new verticalDatum(),
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
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An area within which a uniform assessment of the quality of the bathymetric data exists.
	/// </summary>
	public class QualityOfBathymetricData : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(QualityOfBathymetricData);
		[JsonIgnore]
		public override string S100FC_name => "Quality of Bathymetric Data";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfTemporalVariation {
			set { base.SetAttribute(new categoryOfTemporalVariation { value = value }); }
			get { return base.GetAttributeValue<categoryOfTemporalVariation>(nameof(categoryOfTemporalVariation))?.value; }
		}
		[JsonIgnore]
		public decimal? orientationUncertainty {
			set { base.SetAttribute(new orientationUncertainty { value = value }); }
			get { return base.GetAttributeValue<orientationUncertainty>(nameof(orientationUncertainty))?.value; }
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
		public verticalUncertainty? verticalUncertainty {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<verticalUncertainty>(nameof(verticalUncertainty)); }
		}
		[JsonIgnore]
		public information? information {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<information>(nameof(information)); }
		}
		[JsonIgnore]
		public textualDescription? textualDescription {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<textualDescription>(nameof(textualDescription)); }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfTemporalVariation),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6],
					CreateInstance = () => new categoryOfTemporalVariation(),
				},
				new attributeBindingDefinition {
					attribute = nameof(orientationUncertainty),
					lower = 0,
					upper = 1,
					order = 1,
					CreateInstance = () => new orientationUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(horizontalDistanceUncertainty),
					lower = 0,
					upper = 1,
					order = 2,
					CreateInstance = () => new horizontalDistanceUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(horizontalPositionUncertainty),
					lower = 1,
					upper = 1,
					order = 3,
					CreateInstance = () => new horizontalPositionUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(verticalUncertainty),
					lower = 0,
					upper = 1,
					order = 4,
					CreateInstance = () => new verticalUncertainty(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new information(),
				},
				new attributeBindingDefinition {
					attribute = nameof(textualDescription),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new textualDescription(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => QualityOfBathymetricData.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => QualityOfBathymetricData.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A characteristic or element in the environment that poses a potential risk to navigation or safety. This could include hazards such as rocks, submerged objects, shallow waters, or man-made structures that could endanger vessels or other forms of transportation
	/// </summary>
	public class DangerousFeature : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(DangerousFeature);
		[JsonIgnore]
		public override string S100FC_name => "Dangerous Feature";

		#region Attributes
		[JsonIgnore]
		public String? interoperabilityIdentifier {
			set { base.SetAttribute(new interoperabilityIdentifier { value = value }); }
			get { return base.GetAttributeValue<interoperabilityIdentifier>(nameof(interoperabilityIdentifier))?.value; }
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
					attribute = nameof(interoperabilityIdentifier),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new interoperabilityIdentifier(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new information(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => DangerousFeature.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => DangerousFeature.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "markingAton",
					association = "DangerousFeatureAssociation",
					lower = 1,
					upper = 2147483647,
					featureTypes = [nameof(AtonAssociation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.DangerousFeatureAssociation>() {
						roleType = "association",
						role = "markingAton",
					},
				},
			];

		public static featureBinding<FeatureAssociation.DangerousFeatureAssociation> DangerousFeatureAssociation(string role) => new featureBinding<FeatureAssociation.DangerousFeatureAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("DangerousFeatureAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An Aid to Navigation that uses electronic systems to transmit, receive, or process navigational information for the purpose of enhancing maritime safety, situational awareness, or traffic management. An electronic AtoN may represent, augment, or exist independently of a physical aid to navigation.
	/// </summary>
	public abstract class ElectronicAtoN : AidsToNavigation
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(ElectronicAtoN);
		[JsonIgnore]
		public override string S100FC_name => "Electronic Aton";

		#region Attributes
		[JsonIgnore]
		public String? atoNNumber {
			set { base.SetAttribute(new atoNNumber { value = value }); }
			get { return base.GetAttributeValue<atoNNumber>(nameof(atoNNumber))?.value; }
		}
		[JsonIgnore]
		public String? mMSICode {
			set { base.SetAttribute(new mMSICode { value = value }); }
			get { return base.GetAttributeValue<mMSICode>(nameof(mMSICode))?.value; }
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
					attribute = nameof(atoNNumber),
					lower = 1,
					upper = 1,
					order = 0,
					CreateInstance = () => new atoNNumber(),
				},
				new attributeBindingDefinition {
					attribute = nameof(mMSICode),
					lower = 1,
					upper = 1,
					order = 1,
					CreateInstance = () => new mMSICode(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					permitedValues = [1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43],
					CreateInstance = () => new status(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => ElectronicAtoN.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => ElectronicAtoN.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station located remotely from the intended physical Aid to Navigation.
	/// </summary>
	public class SyntheticAISAidToNavigation : ElectronicAtoN
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(SyntheticAISAidToNavigation);
		[JsonIgnore]
		public override string S100FC_name => "Synthetic AIS Aid to Navigation";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfSyntheticAISAidToNavigation {
			set { base.SetAttribute(new categoryOfSyntheticAISAidToNavigation { value = value }); }
			get { return base.GetAttributeValue<categoryOfSyntheticAISAidToNavigation>(nameof(categoryOfSyntheticAISAidToNavigation))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfSyntheticAISAidToNavigation),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfSyntheticAISAidToNavigation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => SyntheticAISAidToNavigation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => SyntheticAISAidToNavigation.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. ElectronicAtoN.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "syntheticAISBroadcasts",
					association = "SyntheticAIS",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(RadioStation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.SyntheticAIS>() {
						roleType = "association",
						role = "syntheticAISBroadcasts",
					},
				},
			];

		public static featureBinding<FeatureAssociation.SyntheticAIS> SyntheticAIS(string role) => new featureBinding<FeatureAssociation.SyntheticAIS> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("SyntheticAIS") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
	/// </summary>
	public class PhysicalAISAidToNavigation : ElectronicAtoN
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(PhysicalAISAidToNavigation);
		[JsonIgnore]
		public override string S100FC_name => "Physical AIS Aid to Navigation";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfPhysicalAISAidToNavigation {
			set { base.SetAttribute(new categoryOfPhysicalAISAidToNavigation { value = value }); }
			get { return base.GetAttributeValue<categoryOfPhysicalAISAidToNavigation>(nameof(categoryOfPhysicalAISAidToNavigation))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(categoryOfPhysicalAISAidToNavigation),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3],
					CreateInstance = () => new categoryOfPhysicalAISAidToNavigation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => PhysicalAISAidToNavigation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => PhysicalAISAidToNavigation.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. ElectronicAtoN.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "physicalAISBroadcasts",
					association = "PhysicalAIS",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(RadioStation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.PhysicalAIS>() {
						roleType = "association",
						role = "physicalAISBroadcasts",
					},
				},
			];

		public static featureBinding<FeatureAssociation.PhysicalAIS> PhysicalAIS(string role) => new featureBinding<FeatureAssociation.PhysicalAIS> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("PhysicalAIS") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.
	/// </summary>
	public class VirtualAISAidToNavigation : ElectronicAtoN
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(VirtualAISAidToNavigation);
		[JsonIgnore]
		public override string S100FC_name => "Virtual AIS Aid to Navigation";

		#region Attributes
		[JsonIgnore]
		public int? virtualAISAidToNavigationType {
			set { base.SetAttribute(new virtualAISAidToNavigationType { value = value }); }
			get { return base.GetAttributeValue<virtualAISAidToNavigationType>(nameof(virtualAISAidToNavigationType))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(virtualAISAidToNavigationType),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12],
					CreateInstance = () => new virtualAISAidToNavigationType(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => VirtualAISAidToNavigation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => VirtualAISAidToNavigation.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				.. ElectronicAtoN.featureBindingsDefinitions,
				new featureBindingDefinition {
					roleType = "association",
					role = "virtualAISBroadcasts",
					association = "VirtualAIS",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(RadioStation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.VirtualAIS>() {
						roleType = "association",
						role = "virtualAISBroadcasts",
					},
				},
			];

		public static featureBinding<FeatureAssociation.VirtualAIS> VirtualAIS(string role) => new featureBinding<FeatureAssociation.VirtualAIS> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("VirtualAIS") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification.
	/// </summary>
	public class Topmark : Equipment
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(Topmark);
		[JsonIgnore]
		public override string S100FC_name => "Topmark";

		#region Attributes
		[JsonIgnore]
		public int?[] colour {
			set { base.SetAttribute("colour", [.. value.Select(e=> new colour { value = e })]); }
			get { return base.GetAttributeValues<colour>(nameof(colour)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] colourPattern {
			set { base.SetAttribute("colourPattern", [.. value.Select(e=> new colourPattern { value = e })]); }
			get { return base.GetAttributeValues<colourPattern>(nameof(colourPattern)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int?[] status {
			set { base.SetAttribute("status", [.. value.Select(e=> new status { value = e })]); }
			get { return base.GetAttributeValues<status>(nameof(status)).Select(e=>e.value).ToArray(); }
		}
		[JsonIgnore]
		public int? topmarkDaymarkShape {
			set { base.SetAttribute(new topmarkDaymarkShape { value = value }); }
			get { return base.GetAttributeValue<topmarkDaymarkShape>(nameof(topmarkDaymarkShape))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				.. base.attributeBindingsCatalogue,
				new attributeBindingDefinition {
					attribute = nameof(colour),
					lower = 0,
					upper = 2147483647,
					order = 0,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13],
					CreateInstance = () => new colour(),
				},
				new attributeBindingDefinition {
					attribute = nameof(colourPattern),
					lower = 0,
					upper = 2147483647,
					order = 1,
					permitedValues = [1,2,3,4,5,6,7,8,9],
					CreateInstance = () => new colourPattern(),
				},
				new attributeBindingDefinition {
					attribute = nameof(status),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new status(),
				},
				new attributeBindingDefinition {
					attribute = nameof(topmarkDaymarkShape),
					lower = 1,
					upper = 1,
					order = 3,
					permitedValues = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34],
					CreateInstance = () => new topmarkDaymarkShape(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => Topmark.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => Topmark.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
			];

		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

	/// <summary>
	/// Used to identify an aggregation of two or more  objects.
	/// </summary>
	public class AtonAggregation : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AtonAggregation);
		[JsonIgnore]
		public override string S100FC_name => "Aton Aggregation";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfAggregation {
			set { base.SetAttribute(new categoryOfAggregation { value = value }); }
			get { return base.GetAttributeValue<categoryOfAggregation>(nameof(categoryOfAggregation))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfAggregation),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,3,2],
					CreateInstance = () => new categoryOfAggregation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AtonAggregation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => AtonAggregation.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "atonAggregationBy",
					association = "AtonAggregations",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(AidsToNavigation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.AtonAggregations>() {
						roleType = "association",
						role = "atonAggregationBy",
					},
				},
			];

		public static featureBinding<FeatureAssociation.AtonAggregations> AtonAggregations(string role) => new featureBinding<FeatureAssociation.AtonAggregations> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("AtonAggregations") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
	}

	/// <summary>
	/// Used to identify an association of two or more objects.
	/// </summary>
	public class AtonAssociation : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AtonAssociation);
		[JsonIgnore]
		public override string S100FC_name => "Aton Association";

		#region Attributes
		[JsonIgnore]
		public int? categoryOfAssociation {
			set { base.SetAttribute(new categoryOfAssociation { value = value }); }
			get { return base.GetAttributeValue<categoryOfAssociation>(nameof(categoryOfAssociation))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(categoryOfAssociation),
					lower = 1,
					upper = 1,
					order = 0,
					permitedValues = [1,2],
					CreateInstance = () => new categoryOfAssociation(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AtonAssociation.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
			];

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => AtonAssociation.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "danger",
					association = "DangerousFeatureAssociation",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(DangerousFeature)],
					CreateInstance = () => new featureBinding<FeatureAssociation.DangerousFeatureAssociation>() {
						roleType = "association",
						role = "danger",
					},
				},
				new featureBindingDefinition {
					roleType = "association",
					role = "atonAssociationBy",
					association = "AtonAssociations",
					lower = 0,
					upper = 2147483647,
					featureTypes = [nameof(AidsToNavigation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.AtonAssociations>() {
						roleType = "association",
						role = "atonAssociationBy",
					},
				},
			];

		public static featureBinding<FeatureAssociation.DangerousFeatureAssociation> DangerousFeatureAssociation(string role) => new featureBinding<FeatureAssociation.DangerousFeatureAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("DangerousFeatureAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		public static featureBinding<FeatureAssociation.AtonAssociations> AtonAssociations(string role) => new featureBinding<FeatureAssociation.AtonAssociations> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("AtonAssociations") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
	}

	/// <summary>
	/// A  generic feature used to position and portray Aton Status Information.
	/// </summary>
	public class AtonStatusIndication : S100FC.FeatureType, IInformationBindings, IFeatureBindings
	{
		[JsonIgnore]
		public override string S100FC_code => nameof(AtonStatusIndication);
		[JsonIgnore]
		public override string S100FC_name => "Aton Status Indication";

		#region Attributes
		[JsonIgnore]
		public expectedOutage? expectedOutage {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<expectedOutage>(nameof(expectedOutage)); }
		}
		[JsonIgnore]
		public featureReference?[] featureReference {
			set { base.SetAttribute("featureReference", value); }
			get { return base.GetAttributeValues<featureReference>(nameof(featureReference)); }
		}
		[JsonIgnore]
		public information?[] information {
			set { base.SetAttribute("information", value); }
			get { return base.GetAttributeValues<information>(nameof(information)); }
		}
		[JsonIgnore]
		public int? scaleMinimum {
			set { base.SetAttribute(new scaleMinimum { value = value }); }
			get { return base.GetAttributeValue<scaleMinimum>(nameof(scaleMinimum))?.value; }
		}
		[JsonIgnore]
		public featureName?[] featureName {
			set { base.SetAttribute("featureName", value); }
			get { return base.GetAttributeValues<featureName>(nameof(featureName)); }
		}
		[JsonIgnore]
		public changeDetails? changeDetails {
			set { base.SetAttribute(value); }
			get { return base.GetAttributeValue<changeDetails>(nameof(changeDetails)); }
		}
		[JsonIgnore]
		public int? changeTypes {
			set { base.SetAttribute(new changeTypes { value = value }); }
			get { return base.GetAttributeValue<changeTypes>(nameof(changeTypes))?.value; }
		}
		#endregion

		#region Catalogue
		[JsonIgnore]
		public override attributeBindingDefinition[] attributeBindingsCatalogue => [
				new attributeBindingDefinition {
					attribute = nameof(expectedOutage),
					lower = 0,
					upper = 1,
					order = 0,
					CreateInstance = () => new expectedOutage(),
				},
				new attributeBindingDefinition {
					attribute = nameof(featureReference),
					lower = 0,
					upper = 2147483647,
					order = 1,
					CreateInstance = () => new featureReference(),
				},
				new attributeBindingDefinition {
					attribute = nameof(information),
					lower = 0,
					upper = 2147483647,
					order = 2,
					CreateInstance = () => new information(),
				},
				new attributeBindingDefinition {
					attribute = nameof(scaleMinimum),
					lower = 0,
					upper = 1,
					order = 3,
					CreateInstance = () => new scaleMinimum(),
				},
				new attributeBindingDefinition {
					attribute = nameof(featureName),
					lower = 0,
					upper = 2147483647,
					order = 4,
					CreateInstance = () => new featureName(),
				},
				new attributeBindingDefinition {
					attribute = nameof(changeDetails),
					lower = 0,
					upper = 1,
					order = 5,
					CreateInstance = () => new changeDetails(),
				},
				new attributeBindingDefinition {
					attribute = nameof(changeTypes),
					lower = 0,
					upper = 1,
					order = 6,
					CreateInstance = () => new changeTypes(),
				},
			];

		public override informationBindingDefinition[] GetInformationBindingsDefinitions() => AtonStatusIndication.informationBindingsDefinitions;

		public static informationBindingDefinition[] informationBindingsDefinitions => [
				new informationBindingDefinition {
					roleType = "association",
					role = "statusPart",
					association = "AtonStatus",
					lower = 0,
					upper = 1,
					informationTypes = [nameof(AtonStatusInformation)],
					CreateInstance = () => new informationBinding<InformationAssociation.AtonStatus>() {
						roleType = "association",
						role = "statusPart",
					},
				},
			];

		public static informationBinding<InformationAssociation.AtonStatus> AtonStatus => new informationBinding<InformationAssociation.AtonStatus> {
			roleType = "association",
			role = "statusPart",
		};

		public override featureBindingDefinition[] GetFeatureBindingsDefinitions() => AtonStatusIndication.featureBindingsDefinitions;

		public static featureBindingDefinition[] featureBindingsDefinitions => [
				new featureBindingDefinition {
					roleType = "association",
					role = "theAidsToNavigation",
					association = "AtonStatusIndicationAssociation",
					lower = 0,
					upper = 1,
					featureTypes = [nameof(AidsToNavigation)],
					CreateInstance = () => new featureBinding<FeatureAssociation.AtonStatusIndicationAssociation>() {
						roleType = "association",
						role = "theAidsToNavigation",
					},
				},
			];

		public static featureBinding<FeatureAssociation.AtonStatusIndicationAssociation> AtonStatusIndicationAssociation(string role) => new featureBinding<FeatureAssociation.AtonStatusIndicationAssociation> {
			roleType = featureBindingsDefinitions.Single(binding => binding.association.Equals("AtonStatusIndicationAssociation") && binding.role.Equals(role)).roleType,
			role = role,
		};
		#endregion

		[JsonIgnore]
		public override Primitives[] permittedPrimitives => [Primitives.point];
	}

}

namespace S100FC.S125
{
	using System.Text.Json;
	using S100FC.S125.SimpleAttributes;
	using S100FC.S125.ComplexAttributes;
	using S100FC.S125.InformationAssociation;
	using S100FC.S125.FeatureAssociation;
	using S100FC.S125.InformationTypes;
	using S100FC.S125.FeatureTypes;

	public class Summary : ISummary
	{
		public static string Name => "Marine Aids to Navigation (AtoN)";
		public static string Scope => "Ocean, Coastal, Ports and Harbors. Excludes Inland waters.";
		public static string ProductId => "S-125";
		public static Version Version => new Version("1.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2026-03-03", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["featureReference","changeDetails","contactAddress","featureName","fixedDateRange","expectedOutage","horizontalPositionUncertainty","information","multiplicityOfFeatures","orientation","periodicDateRange","radarWaveLength","sectorInformation","sectorLimitOne","sectorLimitTwo","signalSequence","textualDescription","verticalUncertainty","rhythmOfLight","directionalCharacter","sectorLimit","spatialAccuracy","obscuredSector","lightSector","sectorCharacteristics"];
		public static string[] InformationAssociationTypes => ["AtonStatus"];
		public static string[] FeatureAssociationTypes => ["AtonStatusIndicationAssociation","RangeSystem","AtonAggregations","AtonAssociations","DangerousFeatureAssociation","StructureEquipment","PhysicalAIS","SyntheticAIS","VirtualAIS"];
		public static string[] InformationTypes => ["SpatialQuality","AtonStatusInformation"];
		public static string[] FeatureTypes => ["AidsToNavigation","Equipment","StructureObject","GenericBuoy","GenericBeacon","GenericLight","NavigationLine","RecommendedTrack","Landmark","Daymark","FogSignal","RadarReflector","RadarTransponderBeacon","RadioStation","Retroreflector","LightAirObstruction","LightAllAround","LightFogDetector","LightSectored","LightFloat","LightVessel","OffshorePlatform","Pile","SiloTank","CardinalBuoy","EmergencyWreckMarkingBuoy","InstallationBuoy","IsolatedDangerBuoy","LateralBuoy","MooringBuoy","SafeWaterBuoy","SpecialPurposeGeneralBuoy","CardinalBeacon","IsolatedDangerBeacon","SafeWaterBeacon","SpecialPurposeGeneralBeacon","LateralBeacon","WindTurbine","VerticalDatumOfData","DataCoverage","LocalDirectionOfBuoyage","NavigationalSystemOfMarks","SoundingDatum","QualityOfBathymetricData","DangerousFeature","ElectronicAtoN","SyntheticAISAidToNavigation","PhysicalAISAidToNavigation","VirtualAISAidToNavigation","Topmark","AtonAggregation","AtonAssociation","AtonStatusIndication"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["AtonAggregation","AtonAssociation"],
			Primitives.point => ["AidsToNavigation","Equipment","StructureObject","GenericBuoy","GenericBeacon","GenericLight","Landmark","Daymark","FogSignal","RadarReflector","RadarTransponderBeacon","RadioStation","Retroreflector","LightAirObstruction","LightAllAround","LightFogDetector","LightSectored","LightFloat","LightVessel","OffshorePlatform","Pile","SiloTank","CardinalBuoy","EmergencyWreckMarkingBuoy","InstallationBuoy","IsolatedDangerBuoy","LateralBuoy","MooringBuoy","SafeWaterBuoy","SpecialPurposeGeneralBuoy","CardinalBeacon","IsolatedDangerBeacon","SafeWaterBeacon","SpecialPurposeGeneralBeacon","LateralBeacon","WindTurbine","VerticalDatumOfData","DataCoverage","LocalDirectionOfBuoyage","NavigationalSystemOfMarks","SoundingDatum","QualityOfBathymetricData","DangerousFeature","ElectronicAtoN","SyntheticAISAidToNavigation","PhysicalAISAidToNavigation","VirtualAISAidToNavigation","Topmark","AtonStatusIndication"],
			Primitives.pointSet => [],
			Primitives.curve => ["NavigationLine","RecommendedTrack"],
			Primitives.surface => [],
			_ => throw new InvalidOperationException(),
		};
	}

	public static class Extensions {
		public static informationBinding CreateInformationBinding(string informationType, string association) => $"{informationType}::{association}" switch {
			"AidsToNavigation::AtonStatus" => AidsToNavigation.AtonStatus,
			"AtonStatusIndication::AtonStatus" => AtonStatusIndication.AtonStatus,
			"" => throw new KeyNotFoundException(),
			_ => throw new KeyNotFoundException(),
		};

		public static featureBinding CreateFeatureBinding(string featureType, string association, string role) => $"{featureType}::{association}" switch {
			"AidsToNavigation::AtonAggregations" => AidsToNavigation.AtonAggregations(role),
			"AidsToNavigation::AtonAssociations" => AidsToNavigation.AtonAssociations(role),
			"AidsToNavigation::AtonStatusIndicationAssociation" => AidsToNavigation.AtonStatusIndicationAssociation(role),
			"Equipment::StructureEquipment" => Equipment.StructureEquipment(role),
			"StructureObject::StructureEquipment" => StructureObject.StructureEquipment(role),
			"NavigationLine::RangeSystem" => NavigationLine.RangeSystem(role),
			"RecommendedTrack::RangeSystem" => RecommendedTrack.RangeSystem(role),
			"RadioStation::PhysicalAIS" => RadioStation.PhysicalAIS(role),
			"RadioStation::SyntheticAIS" => RadioStation.SyntheticAIS(role),
			"RadioStation::VirtualAIS" => RadioStation.VirtualAIS(role),
			"DangerousFeature::DangerousFeatureAssociation" => DangerousFeature.DangerousFeatureAssociation(role),
			"SyntheticAISAidToNavigation::SyntheticAIS" => SyntheticAISAidToNavigation.SyntheticAIS(role),
			"PhysicalAISAidToNavigation::PhysicalAIS" => PhysicalAISAidToNavigation.PhysicalAIS(role),
			"VirtualAISAidToNavigation::VirtualAIS" => VirtualAISAidToNavigation.VirtualAIS(role),
			"AtonAggregation::AtonAggregations" => AtonAggregation.AtonAggregations(role),
			"AtonAssociation::DangerousFeatureAssociation" => AtonAssociation.DangerousFeatureAssociation(role),
			"AtonAssociation::AtonAssociations" => AtonAssociation.AtonAssociations(role),
			"AtonStatusIndication::AtonStatusIndicationAssociation" => AtonStatusIndication.AtonStatusIndicationAssociation(role),
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociation.AtonStatus>), typeDiscriminator: "AtonStatus"));
				}
				if (typeInfo.Type == typeof(S100FC.featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.AtonStatusIndicationAssociation>), typeDiscriminator: "AtonStatusIndicationAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.RangeSystem>), typeDiscriminator: "RangeSystem"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.AtonAggregations>), typeDiscriminator: "AtonAggregations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.AtonAssociations>), typeDiscriminator: "AtonAssociations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.DangerousFeatureAssociation>), typeDiscriminator: "DangerousFeatureAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.StructureEquipment>), typeDiscriminator: "StructureEquipment"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.PhysicalAIS>), typeDiscriminator: "PhysicalAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.SyntheticAIS>), typeDiscriminator: "SyntheticAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociation.VirtualAIS>), typeDiscriminator: "VirtualAIS"));
				}
				if (typeInfo.Type == typeof(S100FC.attributeBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "code",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileLocator), typeDiscriminator: "fileLocator"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyFixed), typeDiscriminator: "uncertaintyFixed"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(uncertaintyVariableFactor), typeDiscriminator: "uncertaintyVariableFactor"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(virtualAISAidToNavigationType), typeDiscriminator: "virtualAISAidToNavigationType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(atonCommissioning), typeDiscriminator: "atonCommissioning"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(atonRemoval), typeDiscriminator: "atonRemoval"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(atonReplacement), typeDiscriminator: "atonReplacement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fixedAtonChange), typeDiscriminator: "fixedAtonChange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(moireEffect), typeDiscriminator: "moireEffect"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationValue), typeDiscriminator: "orientationValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(floatingAtonChange), typeDiscriminator: "floatingAtonChange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(seasonalActionRequired), typeDiscriminator: "seasonalActionRequired"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(audibleSignalAtonChange), typeDiscriminator: "audibleSignalAtonChange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(signalStatus), typeDiscriminator: "signalStatus"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateStart), typeDiscriminator: "dateStart"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(dateEnd), typeDiscriminator: "dateEnd"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(lightedAtonChange), typeDiscriminator: "lightedAtonChange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(text), typeDiscriminator: "text"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(headline), typeDiscriminator: "headline"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorLineLength), typeDiscriminator: "sectorLineLength"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(signalDuration), typeDiscriminator: "signalDuration"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorBearing), typeDiscriminator: "sectorBearing"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(waveLengthValue), typeDiscriminator: "waveLengthValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(radarBand), typeDiscriminator: "radarBand"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(numberOfFeatures), typeDiscriminator: "numberOfFeatures"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(multiplicityKnown), typeDiscriminator: "multiplicityKnown"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorArcExtension), typeDiscriminator: "sectorArcExtension"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fileReference), typeDiscriminator: "fileReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(electronicAtonChange), typeDiscriminator: "electronicAtonChange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfAssociation), typeDiscriminator: "categoryOfAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfAggregation), typeDiscriminator: "categoryOfAggregation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(mMSICode), typeDiscriminator: "mMSICode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfInstallationBuoy), typeDiscriminator: "categoryOfInstallationBuoy"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(lightCharacteristic), typeDiscriminator: "lightCharacteristic"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(interoperabilityIdentifier), typeDiscriminator: "interoperabilityIdentifier"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(deliveryPoint), typeDiscriminator: "deliveryPoint"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(postalCode), typeDiscriminator: "postalCode"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(language), typeDiscriminator: "language"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(name), typeDiscriminator: "name"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(cityName), typeDiscriminator: "cityName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(administrativeDivision), typeDiscriminator: "administrativeDivision"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(countryName), typeDiscriminator: "countryName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(scaleMinimum), typeDiscriminator: "scaleMinimum"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sourceDate), typeDiscriminator: "sourceDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(source), typeDiscriminator: "source"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(pictorialRepresentation), typeDiscriminator: "pictorialRepresentation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(installationDate), typeDiscriminator: "installationDate"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfNavigationLine), typeDiscriminator: "categoryOfNavigationLine"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(basedOnFixedMarks), typeDiscriminator: "basedOnFixedMarks"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(depthRangeMinimumValue), typeDiscriminator: "depthRangeMinimumValue"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximalPermittedDraught), typeDiscriminator: "maximalPermittedDraught"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(qualityOfVerticalMeasurement), typeDiscriminator: "qualityOfVerticalMeasurement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(status), typeDiscriminator: "status"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(isSlatted), typeDiscriminator: "isSlatted"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalAccuracy), typeDiscriminator: "verticalAccuracy"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(peakIntensity), typeDiscriminator: "peakIntensity"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(techniqueOfVerticalMeasurement), typeDiscriminator: "techniqueOfVerticalMeasurement"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(trafficFlow), typeDiscriminator: "trafficFlow"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalDatum), typeDiscriminator: "verticalDatum"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(atoNNumber), typeDiscriminator: "atoNNumber"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(buoyShape), typeDiscriminator: "buoyShape"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(colour), typeDiscriminator: "colour"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSyntheticAISAidToNavigation), typeDiscriminator: "categoryOfSyntheticAISAidToNavigation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfPhysicalAISAidToNavigation), typeDiscriminator: "categoryOfPhysicalAISAidToNavigation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(colourPattern), typeDiscriminator: "colourPattern"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(radarConspicuous), typeDiscriminator: "radarConspicuous"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(marksNavigationalSystemOf), typeDiscriminator: "marksNavigationalSystemOf"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(natureOfConstruction), typeDiscriminator: "natureOfConstruction"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(typeOfBuoy), typeDiscriminator: "typeOfBuoy"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(beaconShape), typeDiscriminator: "beaconShape"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(visualProminence), typeDiscriminator: "visualProminence"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(height), typeDiscriminator: "height"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalLength), typeDiscriminator: "verticalLength"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfLandmark), typeDiscriminator: "categoryOfLandmark"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(function), typeDiscriminator: "function"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSpecialPurposeMark), typeDiscriminator: "categoryOfSpecialPurposeMark"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(topmarkDaymarkShape), typeDiscriminator: "topmarkDaymarkShape"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfFogSignal), typeDiscriminator: "categoryOfFogSignal"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRadarTransponderBeacon), typeDiscriminator: "categoryOfRadarTransponderBeacon"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(signalGroup), typeDiscriminator: "signalGroup"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(signalPeriod), typeDiscriminator: "signalPeriod"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(valueOfNominalRange), typeDiscriminator: "valueOfNominalRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfRadioStation), typeDiscriminator: "categoryOfRadioStation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(effectiveIntensity), typeDiscriminator: "effectiveIntensity"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(estimatedRangeOfTransmission), typeDiscriminator: "estimatedRangeOfTransmission"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(lightVisibility), typeDiscriminator: "lightVisibility"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(exhibitionConditionOfLight), typeDiscriminator: "exhibitionConditionOfLight"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(flareBearing), typeDiscriminator: "flareBearing"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(signalGeneration), typeDiscriminator: "signalGeneration"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(majorLight), typeDiscriminator: "majorLight"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfLight), typeDiscriminator: "categoryOfLight"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfOffshorePlatform), typeDiscriminator: "categoryOfOffshorePlatform"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(condition), typeDiscriminator: "condition"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfPile), typeDiscriminator: "categoryOfPile"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(buildingShape), typeDiscriminator: "buildingShape"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfSiloTank), typeDiscriminator: "categoryOfSiloTank"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfLateralMark), typeDiscriminator: "categoryOfLateralMark"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfCardinalMark), typeDiscriminator: "categoryOfCardinalMark"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(elevation), typeDiscriminator: "elevation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(maximumDisplayScale), typeDiscriminator: "maximumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(minimumDisplayScale), typeDiscriminator: "minimumDisplayScale"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(categoryOfTemporalVariation), typeDiscriminator: "categoryOfTemporalVariation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientationUncertainty), typeDiscriminator: "orientationUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalDistanceUncertainty), typeDiscriminator: "horizontalDistanceUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(changeTypes), typeDiscriminator: "changeTypes"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureReference), typeDiscriminator: "featureReference"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(changeDetails), typeDiscriminator: "changeDetails"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(contactAddress), typeDiscriminator: "contactAddress"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureName), typeDiscriminator: "featureName"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(fixedDateRange), typeDiscriminator: "fixedDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(expectedOutage), typeDiscriminator: "expectedOutage"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(horizontalPositionUncertainty), typeDiscriminator: "horizontalPositionUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(information), typeDiscriminator: "information"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(multiplicityOfFeatures), typeDiscriminator: "multiplicityOfFeatures"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(orientation), typeDiscriminator: "orientation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(periodicDateRange), typeDiscriminator: "periodicDateRange"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(radarWaveLength), typeDiscriminator: "radarWaveLength"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorInformation), typeDiscriminator: "sectorInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorLimitOne), typeDiscriminator: "sectorLimitOne"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorLimitTwo), typeDiscriminator: "sectorLimitTwo"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(signalSequence), typeDiscriminator: "signalSequence"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(textualDescription), typeDiscriminator: "textualDescription"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(verticalUncertainty), typeDiscriminator: "verticalUncertainty"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(rhythmOfLight), typeDiscriminator: "rhythmOfLight"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(directionalCharacter), typeDiscriminator: "directionalCharacter"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorLimit), typeDiscriminator: "sectorLimit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(spatialAccuracy), typeDiscriminator: "spatialAccuracy"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(obscuredSector), typeDiscriminator: "obscuredSector"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(lightSector), typeDiscriminator: "lightSector"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorCharacteristics), typeDiscriminator: "sectorCharacteristics"));
				}
			});
			jsonSerializerOptions.TypeInfoResolver = resolver;
			return jsonSerializerOptions;
		}
	}
}
