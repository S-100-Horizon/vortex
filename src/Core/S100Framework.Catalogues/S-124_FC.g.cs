using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S124 {
	public class Summary : ISummary
	{
		public static string Name => "Navigational Warnings";
		public static string Scope => "Global";
		public static string ProductId => "S-124";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2024-10-30", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["affectedChartPublications","chartAffected","fixedDateRange","generalArea","information","locality","locationName","messageSeriesIdentifier","navwarnTitle","warningInformation","featureReference","featureName","horizontalPositionUncertainty","spatialAccuracy"];
		public static string[] InformationAssociationTypes => ["navwarnPreambleContent","navwarnReferences"];
		public static string[] FeatureAssociationTypes => ["TextAssociation","areaAffected"];
		public static string[] InformationTypes => ["References","NavwarnPreamble","SpatialQuality"];
		public static string[] FeatureTypes => ["NavwarnPart","NavwarnAreaAffected","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.point => ["NavwarnPart","NavwarnAreaAffected","TextPlacement"],
			Primitives.curve => ["NavwarnPart","NavwarnAreaAffected"],
			Primitives.surface => ["NavwarnPart","NavwarnAreaAffected"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"NavwarnPart" => [Primitives.point,Primitives.curve,Primitives.surface],
			"NavwarnAreaAffected" => [Primitives.point,Primitives.curve,Primitives.surface],
			"TextPlacement" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
		public static Type InformationBindings(string code) => code switch {
			"navwarnPreambleContent" => typeof(informationBinding<InformationAssociations.navwarnPreambleContent>),
			"navwarnReferences" => typeof(informationBinding<InformationAssociations.navwarnReferences>),
			_ or "" => throw new InvalidOperationException(),
		};
		public static Type FeatureBindings(string code) => code switch {
			"TextAssociation" => typeof(featureBinding<FeatureAssociations.TextAssociation>),
			"areaAffected" => typeof(featureBinding<FeatureAssociations.areaAffected>),
			_ or "" => throw new InvalidOperationException(),
		};

		public static System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver InformationBindingResolver() {
			var resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
			resolver.Modifiers.Add(typeInfo => {
				if (typeInfo.Type == typeof(informationBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$type",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
				typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.navwarnPreambleContent>), typeDiscriminator: "informationBinding::navwarnPreambleContent"));
				typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.navwarnReferences>), typeDiscriminator: "informationBinding::navwarnReferences"));
				}
			});
			return resolver;
		}


		public static System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver FeatureBindingResolver() {
			var resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
			resolver.Modifiers.Add(typeInfo => {
				if (typeInfo.Type == typeof(featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$type",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
				typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.TextAssociation>), typeDiscriminator: "featureBinding::TextAssociation"));
				typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.areaAffected>), typeDiscriminator: "featureBinding::areaAffected"));
				}
			});
			return resolver;
		}
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
	}

	/// <summary>
	/// The scope of the MSI warning - NAVAREA, sub-area, etc.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum warningType : int {
		[System.ComponentModel.Description("Message containing urgent information relevant to safe navigation broadcast to ships in a local area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended.(Adopted from S-53, 2.2.23)  Local warning means a navigational warning which covers inshore waters, often within the limits of jurisdiction of a harbour or port authority. (Adopted from S-53, 2.2.10)")]
		[EnumMember(Value = "Local Navigational Warning")] 
		[XmlEnum("1")] 
		LocalNavigationalWarning = 1,

		[System.ComponentModel.Description("Message containing urgent information relevant to safe navigation broadcast to ships in a coastal  area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended.  Coastal warning means a navigational warning promulgated as part of a numbered series by a National Coordinator.")]
		[EnumMember(Value = "Coastal Navigational Warning")] 
		[XmlEnum("2")] 
		CoastalNavigationalWarning = 2,

		[System.ComponentModel.Description("Message containing urgent information relevant to safe navigation broadcast to ships in a sub-area, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended.  Sub-area warning means a navigational warning or in-force bulletin promulgated as part of a numbered series by a Sub-area Coordinator.")]
		[EnumMember(Value = "Sub-Area Navigational Warning")] 
		[XmlEnum("3")] 
		SubAreaNavigationalWarning = 3,

		[System.ComponentModel.Description("Message containing urgent information relevant to safe navigation broadcast to ships in a NAVAREA, in accordance with the provisions of the International Convention for the Safety of Life at Sea, 1974, as amended.  NAVAREA warning means a navigational warning promulgated as part of a numbered series by a NAVAREA Coordinator.")]
		[EnumMember(Value = "NAVAREA Navigational Warning")] 
		[XmlEnum("4")] 
		NavareaNavigationalWarning = 4,

		[System.ComponentModel.Description("A message that indicates that there are no navigational warnings to be disseminated in the NAVAREA.")]
		[EnumMember(Value = "NAVAREA No Warning")] 
		[XmlEnum("5")] 
		NavareaNoWarning = 5,

		[System.ComponentModel.Description("A message that indicates that there are no navigational warnings to be disseminated in the sub-area.")]
		[EnumMember(Value = "Sub-Area No Warning")] 
		[XmlEnum("6")] 
		SubAreaNoWarning = 6,

		[System.ComponentModel.Description("A message that indicates that there are no navigational warnings to be disseminated in the coastal area.")]
		[EnumMember(Value = "Coastal No Warning")] 
		[XmlEnum("7")] 
		CoastalNoWarning = 7,

		[System.ComponentModel.Description("A message that indicates that there are no navigational warnings to be disseminated in the local area.")]
		[EnumMember(Value = "Local No Warning")] 
		[XmlEnum("8")] 
		LocalNoWarning = 8,

		[System.ComponentModel.Description("A list of serial numbers of NAVAREA warnings which are in- force.")]
		[EnumMember(Value = "NAVAREA In-Force Bulletin")] 
		[XmlEnum("9")] 
		NavareaInForceBulletin = 9,

		[System.ComponentModel.Description("A list of serial numbers of sub-area warnings which are in-force.")]
		[EnumMember(Value = "Sub-Area In-Force Bulletin")] 
		[XmlEnum("10")] 
		SubAreaInForceBulletin = 10,

		[System.ComponentModel.Description("A list of serial numbers of coastal warnings which are in- force.")]
		[EnumMember(Value = "Coastal In-Force Bulletin")] 
		[XmlEnum("11")] 
		CoastalInForceBulletin = 11,

		[System.ComponentModel.Description("A list of serial numbers of local warnings which are in- force.")]
		[EnumMember(Value = "Local In-Force Bulletin")] 
		[XmlEnum("12")] 
		LocalInForceBulletin = 12,
	}

	/// <summary>
	/// Category of reference.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum referenceCategory : int {
		[System.ComponentModel.Description("Cancellation of warning which is no longer valid.")]
		[EnumMember(Value = "Warning Cancellation")] 
		[XmlEnum("1")] 
		WarningCancellation = 1,

		[System.ComponentModel.Description("Reference to relevant warning.")]
		[EnumMember(Value = "Warning Reference")] 
		[XmlEnum("2")] 
		WarningReference = 2,

		[System.ComponentModel.Description("Reference to warnings or notices that are considered in-force.")]
		[EnumMember(Value = "In-Force")] 
		[XmlEnum("3")] 
		InForce = 3,
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
		[System.ComponentModel.Description("[1] An area shown on charts within which navigation and/or anchoring is prohibited. [2] In aviation terminology, a specified area within the land areas of a state or territorial waters adjacent thereto over which the flight of aircraft is prohibi­ted.")]
		[EnumMember(Value = "Entry Prohibited")] 
		[XmlEnum("7")] 
		EntryProhibited = 7,

		[System.ComponentModel.Description("A specified area designated by appropriate authority, within which navigation is restricted in accordance with certain specified conditions.")]
		[EnumMember(Value = "Entry Restricted")] 
		[XmlEnum("8")] 
		EntryRestricted = 8,

		[System.ComponentModel.Description("An IMO declared routeing measure comprising an area within defined limits in which either navigation is particularly hazardous or it is exceptionally important to avoid casualties and which should be avoided by all ships, or certain classes of ships.")]
		[EnumMember(Value = "Area To Be Avoided")] 
		[XmlEnum("14")] 
		AreaToBeAvoided = 14,

		[System.ComponentModel.Description("An area in which a vessel is prohibited from stopping.")]
		[EnumMember(Value = "Stopping Prohibited")] 
		[XmlEnum("25")] 
		StoppingProhibited = 25,

		[System.ComponentModel.Description("An area within which speed is restricted.")]
		[EnumMember(Value = "Speed Restricted")] 
		[XmlEnum("27")] 
		SpeedRestricted = 27,
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

		[System.ComponentModel.Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to a feature whose position does not remain fixed.")]
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
	/// Detailed type of a warning or hazard.
	/// </summary>
	[System.Serializable()]
	public class navwarnTypeDetails
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	/// <summary>
	/// General type of a navigational warning or navigational hazard.
	/// </summary>
	[System.Serializable()]
	public class navwarnTypeGeneral
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	public static class CodeList
	{
		public static ImmutableArray<navwarnTypeDetails> navwarnTypeDetails => ImmutableArray.Create<navwarnTypeDetails>(new navwarnTypeDetails[]{
			new() {
				code = 1,
				definition = "The temporary or permanent installation of an acoustical instrument in the marine environment for the purpose of tracking the behavior of marine mammals or to monitor their ecosystems.",
				label = "Acoustic Recorder",
			},
			new() {
				code = 2,
				definition = "A new AIS has been or will be established for a limited period of time.",
				label = "AIS Temporary Establishment",
			},
			new() {
				code = 3,
				definition = "A new AIS site has been or will be established.",
				label = "AIS Transmitter Establishment",
			},
			new() {
				code = 4,
				definition = "The terrestrial AIS transmitter is operating as advertised.",
				label = "AIS Transmitter Operating Properly",
			},
			new() {
				code = 5,
				definition = "The terrestrial AIS transmitter is inoperative due to a technical issue.",
				label = "AIS Transmitter Out Of Service",
			},
			new() {
				code = 6,
				definition = "AIS transmitter has been or will be permanently removed from service.",
				label = "AIS Transmitter Removal",
			},
			new() {
				code = 7,
				definition = "AIS transmitter has been or will be temporarily removed from service.",
				label = "AIS Transmitter Temporary Removal",
			},
			new() {
				code = 8,
				definition = "The terrestrial AIS transmitter is unreliable due to a technical issue or maintenance.",
				label = "AIS Transmitter Unreliable",
			},
			new() {
				code = 9,
				definition = "All aids to navigation on a structure or in an area are unreliable due to environmental impact, equipment failure, etc.",
				label = "All Aids To Navigation Unreliable",
			},
			new() {
				code = 10,
				definition = "A large scale activity where multiple vessels, surveillance aircraft, and shore-based personnel practice a response to the discharge of a pollutant from a ship (or shore) into the marine environment, in order to evaluate the effectiveness of response capability.",
				label = "Anti Pollution Exercise",
			},
			new() {
				code = 11,
				definition = "A real time response by vessels, surveillance aircraft, and shore-based personnel to resolve the discharge of a pollutant from a ship (or shore) into the marine environment.",
				label = "Anti Pollution Operation",
			},
			new() {
				code = 12,
				definition = "The installation of infrastructure at a new location where the farming of fish, shellfish and aquatic plants in fresh or salt water is undertaken; and, failures at these locations where the infrastructure is reported damaged and may be adrift.",
				label = "Aquaculture Site",
			},
			new() {
				code = 13,
				definition = "The outage/failure has been corrected and the aids to navigation has resumed normal operation.",
				label = "AtoN Operating Properly",
			},
			new() {
				code = 14,
				definition = "The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be changed.",
				label = "Audible Signal Change",
			},
			new() {
				code = 15,
				definition = "A new audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be established.",
				label = "Audible Signal Establishment",
			},
			new() {
				code = 16,
				definition = "The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is operating as advertised.",
				label = "Audible Signal Operating Properly",
			},
			new() {
				code = 17,
				definition = "The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is inoperative.",
				label = "Audible Signal Out Of Service",
			},
			new() {
				code = 18,
				definition = "Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be permanently removed from service.",
				label = "Audible Signal Removal",
			},
			new() {
				code = 19,
				definition = "The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be temporarily changed.",
				label = "Audible Signal Temporary Change",
			},
			new() {
				code = 20,
				definition = "A new audible signal has been or will be established for a limited period of time.",
				label = "Audible Signal Temporary Establishment",
			},
			new() {
				code = 21,
				definition = "Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be temporarily removed from service.",
				label = "Audible Signal Temporary Removal",
			},
			new() {
				code = 22,
				definition = "Ice routeing information provided by a recognized authority.",
				label = "Authorized Ice Routeing Information",
			},
			new() {
				code = 23,
				definition = "The characteristics of the beacon have been or will be changed.",
				label = "Beacon Change",
			},
			new() {
				code = 24,
				definition = "The beacon has sustained damage due to external factors (wind, sea state, collision with a vessel).",
				label = "Beacon Damaged",
			},
			new() {
				code = 25,
				definition = "Colour of the beacon daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",
				label = "Beacon Daymark Unreliable",
			},
			new() {
				code = 26,
				definition = "A new beacon has been or will be established.",
				label = "Beacon Establishment",
			},
			new() {
				code = 27,
				definition = "No beacon at the advertised position.",
				label = "Beacon Missing",
			},
			new() {
				code = 28,
				definition = "Beacon has been or will be permanently removed from service.",
				label = "Beacon Removal",
			},
			new() {
				code = 29,
				definition = "The beacon has been restored to normal condition.",
				label = "Beacon Restored To Normal",
			},
			new() {
				code = 30,
				definition = "The characteristics of the beacon have been or will be temporarily changed.",
				label = "Beacon Temporary Change",
			},
			new() {
				code = 31,
				definition = "A new beacon has been or will be established for a limited period of time.",
				label = "Beacon Temporary Establishment",
			},
			new() {
				code = 32,
				definition = "Beacon has been or will be temporarily removed from service.",
				label = "Beacon Temporary Removal",
			},
			new() {
				code = 33,
				definition = "The topmark of the beacon is damaged due to external factors (wind, sea state, collision with a vessel).",
				label = "Beacon Topmark Damaged",
			},
			new() {
				code = 34,
				definition = "The topmark of the beacon is missing.",
				label = "Beacon Topmark Missing",
			},
			new() {
				code = 35,
				definition = "An explosive detonation was observed at sea or blasting operation is scheduled to occur.",
				label = "Blasting Operation",
			},
			new() {
				code = 36,
				definition = "The construction of a structure protecting a shore area, harbour, or anchorage from waves.",
				label = "Breakwater Construction",
			},
			new() {
				code = 37,
				definition = "The published horizontal clearance of the fixed or opening bridge has changed.",
				label = "Bridge Horizontal Clearance Change",
			},
			new() {
				code = 38,
				definition = "The functionality of an opening bridge is compromised. The bridge will remain open.",
				label = "Bridge Unable To Close",
			},
			new() {
				code = 39,
				definition = "The functionality of an opening bridge is compromised. The bridge will remain closed.",
				label = "Bridge Unable To Open",
			},
			new() {
				code = 40,
				definition = "The published vertical clearance of the fixed or opening bridge has changed.",
				label = "Bridge Vertical Clearance Change",
			},
			new() {
				code = 41,
				definition = "The buoy is no longer secured to its moorings and is adrift.",
				label = "Buoy Adrift",
			},
			new() {
				code = 42,
				definition = "The characteristics of the buoy have been or will be changed.",
				label = "Buoy Change",
			},
			new() {
				code = 43,
				definition = "A buoy which was in ice over the winter and has been verified undamaged and in advertised position for the navigational season",
				label = "Buoy Commissioned for Navigation Season",
			},
			new() {
				code = 44,
				definition = "The buoy has been damaged due to external factors (wind, sea state, collision with a vessel).",
				label = "Buoy Damaged",
			},
			new() {
				code = 45,
				definition = "Colour of the buoy daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",
				label = "Buoy Daymark Unreliable",
			},
			new() {
				code = 46,
				definition = "A buoy which remains in the water over winter but which is declared unreliable (may be impacted by ice movement).",
				label = "Buoy Decommissioned for Winter",
			},
			new() {
				code = 47,
				definition = "The buoy has suffered extensive damage and is not useable.",
				label = "Buoy Destroyed",
			},
			new() {
				code = 48,
				definition = "A new buoy has been or will be established.",
				label = "Buoy Establishment",
			},
			new() {
				code = 49,
				definition = "No buoy at its advertised/charted position or in the vicinity.",
				label = "Buoy Missing",
			},
			new() {
				code = 50,
				definition = "The buoy has been or will be moved intentionally.",
				label = "Buoy Move",
			},
			new() {
				code = 51,
				definition = "The buoy has been dragged off its advertised position due to wind or current affecting the mooring system.",
				label = "Buoy off Position",
			},
			new() {
				code = 52,
				definition = "The re-establishment of a buoy which was previously announced either destroyed or temporarily removed.",
				label = "Buoy Re-established",
			},
			new() {
				code = 53,
				definition = "Buoy has been or will be permanently removed from service.",
				label = "Buoy Removal",
			},
			new() {
				code = 54,
				definition = "A buoy which has been removed and it's location is now marked by a winter spar buoy.",
				label = "Buoy Replaced by Winter Spar",
			},
			new() {
				code = 55,
				definition = "The buoy has been restored to normal condition.",
				label = "Buoy Restored to Normal",
			},
			new() {
				code = 56,
				definition = "The characteristics of the buoy have been or will be temporarily changed.",
				label = "Buoy Temporary Change",
			},
			new() {
				code = 57,
				definition = "A new buoy has been or will be established for a limited period of time.",
				label = "Buoy Temporary Establishment",
			},
			new() {
				code = 58,
				definition = "Buoy has been or will be temporarily removed from service.",
				label = "Buoy Temporary Removal",
			},
			new() {
				code = 59,
				definition = "The topmark of the buoy is damaged due to external factors (wind, sea state, collision with a vessel).",
				label = "Buoy Topmark Damaged",
			},
			new() {
				code = 60,
				definition = "The topmark of the buoy is missing.",
				label = "Buoy Topmark Missing",
			},
			new() {
				code = 61,
				definition = "The buoy has been scheduled for removal from service for a fixed term.",
				label = "Buoy Will Be Withdrawn",
			},
			new() {
				code = 62,
				definition = "The buoy has been removed from service for a fixed term.",
				label = "Buoy Withdrawn",
			},
			new() {
				code = 63,
				definition = "A buoy has been withdrawn for the winter season.",
				label = "Buoy Withdrawn for Winter",
			},
			new() {
				code = 64,
				definition = "Operations being undertaken to lay wires, fibres, wire rope or chains underwater or to bury them beneath the sea floor.",
				label = "Cable Laying Operation",
			},
			new() {
				code = 65,
				definition = "Underwater operations undertaken to maintain or repair a submarine cable.",
				label = "Cable Operations",
			},
			new() {
				code = 66,
				definition = "The Chayka station is operating as advertised.",
				label = "Chayka Operating Properly",
			},
			new() {
				code = 67,
				definition = "The Chayka station is inoperative due to a technical issue.",
				label = "Chayka Out Of Service",
			},
			new() {
				code = 68,
				definition = "Chayka station has been or will be permanently removed from service.",
				label = "Chayka Station Removal",
			},
			new() {
				code = 69,
				definition = "Chayka station has been or will be temporarily removed from service.",
				label = "Chayka Station Temporary Removal",
			},
			new() {
				code = 70,
				definition = "The Chayka station is unreliable due to a technical issue or maintenance.",
				label = "Chayka Unreliable",
			},
			new() {
				code = 71,
				definition = "A large concentration of fishing vessels in a small area which may interfere with, hamper, or reduce the ability of another vessel to navigate safely.",
				label = "Cluster of Fishing Vessels",
			},
			new() {
				code = 72,
				definition = "A cargo container which has fallen overboard and is reported adrift.",
				label = "Container Adrift",
			},
			new() {
				code = 73,
				definition = "A wreck submerged at such a depth as to be considered dangerous to surface navigation.",
				label = "Dangerous Wreck",
			},
			new() {
				code = 74,
				definition = "A deceased marine mammal, typically a whale, reported adrift.",
				label = "Dead Whale Adrift",
			},
			new() {
				code = 75,
				definition = "A log which, becoming saturated with water, will start to sink at the heavier end, such that it floats vertically or nearly vertically in the water.",
				label = "Deadhead Adrift",
			},
			new() {
				code = 76,
				definition = "Any vessel abandoned at sea of sufficient size as to pose a hazard to safe navigation.",
				label = "Derelict Vessel Adrift",
			},
			new() {
				code = 77,
				definition = "The DGLONASS station is operating as advertised.",
				label = "DGLONASS Operating Properly",
			},
			new() {
				code = 78,
				definition = "The DGLONASS station is inoperative due to a technical issue.",
				label = "DGLONASS Out Of Service",
			},
			new() {
				code = 79,
				definition = "A new DGLONASS station has been or will be established.",
				label = "DGLONASS Station Establishment",
			},
			new() {
				code = 80,
				definition = "The DGLONASS station is unreliable due to a technical issue or maintenance.",
				label = "DGLONASS Unreliable",
			},
			new() {
				code = 81,
				definition = "The DGPS station is operating as advertised.",
				label = "DGPS Operating Properly",
			},
			new() {
				code = 82,
				definition = "The DGPS station is inoperative due to a technical issue.",
				label = "DGPS Out Of Service",
			},
			new() {
				code = 83,
				definition = "A new DGPS station has been or will be established.",
				label = "DGPS Station Establishment",
			},
			new() {
				code = 84,
				definition = "DGPS station has been or will be permanently removed from service.",
				label = "DGPS Station Removal",
			},
			new() {
				code = 85,
				definition = "DGPS station has been or will be temporarily removed from service.",
				label = "DGPS Station Temporary Removal",
			},
			new() {
				code = 86,
				definition = "The DGPS station is unreliable due to a technical issue or maintenance.",
				label = "DGPS Unreliable",
			},
			new() {
				code = 87,
				definition = "A location where divers are conducting any type of activity at or below the surface of the water.",
				label = "Diving Operation",
			},
			new() {
				code = 88,
				definition = "A structure, formerly attached along the shoreline or extending from the shore into a body of water to which vessels moor, which has broken free of its moorings and is adrift.",
				label = "Dock Adrift",
			},
			new() {
				code = 89,
				definition = "Works in order to increase depth.",
				label = "Dredging Operation",
			},
			new() {
				code = 90,
				definition = "A drill rig is under tow.",
				label = "Drill Rig Under Tow",
			},
			new() {
				code = 91,
				definition = "A drill rig/drill ship has commenced operations at the specified location offshore.",
				label = "Drilling Site Operations",
			},
			new() {
				code = 92,
				definition = "The e-Chayka station is operating as advertised.",
				label = "E-Chayka Operating Properly",
			},
			new() {
				code = 93,
				definition = "The e-Chayka station is inoperative due to a technical issue.",
				label = "E-Chayka Out Of Service",
			},
			new() {
				code = 94,
				definition = "A new e-Chayka station has been or will be established.",
				label = "E-Chayka Station Establishment",
			},
			new() {
				code = 95,
				definition = "The e-Chayka station has been or will be permanently removed from service.",
				label = "E-Chayka Station Removal",
			},
			new() {
				code = 96,
				definition = "The e-Chayka station has been or will be temporarily removed from service",
				label = "E-Chayka Station Temporary Removal",
			},
			new() {
				code = 97,
				definition = "The e-Chayka station is unreliable due to a technical issue or maintenance.",
				label = "E-Chayka Unreliable",
			},
			new() {
				code = 98,
				definition = "Any failure or return to operation of an EGC service offered by a recognized mobile satellite service provider.",
				label = "EGC MSI Service",
			},
			new() {
				code = 99,
				definition = "The EGNOS station is operating as advertised.",
				label = "EGNOS Operating Properly",
			},
			new() {
				code = 100,
				definition = "The EGNOS station is inoperative due to a technical issue.",
				label = "EGNOS Out Of Service",
			},
			new() {
				code = 101,
				definition = "A new EGNOS station has been or will be established.",
				label = "EGNOS Station Establishment",
			},
			new() {
				code = 102,
				definition = "EGNOS station has been or will be permanently removed from service.",
				label = "EGNOS Station Removal",
			},
			new() {
				code = 103,
				definition = "EGNOS station has been or will be temporarily removed from service.",
				label = "EGNOS Station Temporary Removal",
			},
			new() {
				code = 104,
				definition = "The EGNOS station is unreliable due to a technical issue or maintenance.",
				label = "EGNOS Unreliable",
			},
			new() {
				code = 105,
				definition = "The eLORAN station is operating as advertised.",
				label = "ELORAN Operating Properly",
			},
			new() {
				code = 106,
				definition = "The eLORAN station is inoperative due to a technical issue.",
				label = "ELORAN Out Of Service",
			},
			new() {
				code = 107,
				definition = "A new eLORAN station has been or will be established.",
				label = "ELORAN Station Establishment",
			},
			new() {
				code = 108,
				definition = "The eLORAN station has been or will be permanently removed from service.",
				label = "ELORAN Station Removal",
			},
			new() {
				code = 109,
				definition = "The eLORAN station has been or will be temporarily removed from service.",
				label = "ELORAN Station Temporary Removal",
			},
			new() {
				code = 110,
				definition = "The eLORAN station is unreliable due to a technical issue or maintenance.",
				label = "ELORAN Unreliable",
			},
			new() {
				code = 111,
				definition = "An established marine area, temporary or permanent in nature, where vessel traffic is prohibited." + Environment.NewLine +
"A geographical area, within which all other vessels should remain clear unless authorised.",
				label = "Exclusion Zone",
			},
			new() {
				code = 112,
				definition = "Unexploded explosive devices.",
				label = "Explosive Device",
			},
			new() {
				code = 113,
				definition = "The light on the fairway marker is no longer synchronized with another light or group of lights.",
				label = "Fairway Marker - Light Not Synchronized",
			},
			new() {
				code = 114,
				definition = "The light on the fairway marker is inoperative.",
				label = "Fairway Marker - Light Unlit",
			},
			new() {
				code = 115,
				definition = "The operation of the light on the fairway marker is unreliable due to technical problems.",
				label = "Fairway Marker - Light Unreliable",
			},
			new() {
				code = 116,
				definition = "The fairway marker has been damaged due to external factors (wind, sea state, collision with a vessel).",
				label = "Fairway Marker Damaged",
			},
			new() {
				code = 117,
				definition = "The fairway marker has suffered extensive damage and is not useable.",
				label = "Fairway Marker Destroyed",
			},
			new() {
				code = 118,
				definition = "The area of which remains hazardous to life after an explosive detonation or the fallout from a rocket launch or space debris.",
				label = "Fallout Hazard",
			},
			new() {
				code = 119,
				definition = "Scheduled public display of pyrotechnics, usually ignited from barges located just offshore, and often accompanied by music.",
				label = "Fireworks",
			},
			new() {
				code = 120,
				definition = "An exercise within a defined area which includes the firing of weapon systems during training or testing that may affect safety at sea.",
				label = "Firing Exercise",
			},
			new() {
				code = 121,
				definition = "A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks or adrift.",
				label = "Fish Aggregating Device",
			},
			new() {
				code = 122,
				definition = "A fishing net (seine, purse, gill, trawl, bag or other), reported adrift, of sufficient size to pose a hazard to safe navigation.",
				label = "Fishing Net Adrift",
			},
			new() {
				code = 123,
				definition = "A concentration of floating objects, which by the nature of their size and material, could pose a hazard to safe navigation.",
				label = "Floating Debris",
			},
			new() {
				code = 124,
				definition = "The flood light illuminating the beacon is inoperative.",
				label = "Floodlit Beacon - Unlit",
			},
			new() {
				code = 125,
				definition = "The characteristics of the fog signal have been or will be changed.",
				label = "Fog Signal Change",
			},
			new() {
				code = 126,
				definition = "A new fog signal has been or will be established.",
				label = "Fog Signal Establishment",
			},
			new() {
				code = 127,
				definition = "The fog signal is operating as advertised.",
				label = "Fog Signal Operating Properly",
			},
			new() {
				code = 128,
				definition = "The fog signal is inoperative.",
				label = "Fog Signal Out Of Service",
			},
			new() {
				code = 129,
				definition = "Fog signal has been or will be permanently removed from service.",
				label = "Fog Signal Removal",
			},
			new() {
				code = 130,
				definition = "The characteristics of the fog signal have been or will be temporarily changed.",
				label = "Fog Signal Temporary Change",
			},
			new() {
				code = 131,
				definition = "A new fog signal has been or will be established for a limited period of time.",
				label = "Fog Signal Temporary Establishment",
			},
			new() {
				code = 132,
				definition = "Fog signal has been or will be temporarily removed from service.",
				label = "Fog Signal Temporary Removal",
			},
			new() {
				code = 133,
				definition = "The synchronization of the leading lights is abnormal / The synchronization of the range lights is abnormal.",
				label = "Front and Rear Lights out of Synchronization",
			},
			new() {
				code = 134,
				definition = "The front leading beacon has been restored to normal condition. / The front range beacon has been restored to normal condition.",
				label = "Front Beacon Restored to Normal",
			},
			new() {
				code = 135,
				definition = "The front leading beacon is damaged, obscured or missing. / The front range beacon is damaged, obscured or missing.",
				label = "Front Beacon Unreliable",
			},
			new() {
				code = 136,
				definition = "The front leading light is operating as advertised. / The front range light is operating as advertised.",
				label = "Front Light is Operating Properly",
			},
			new() {
				code = 137,
				definition = "The nominal range of the front leading light is reduced. / The nominal range of the front range light is reduced.",
				label = "Front Light Range Reduced",
			},
			new() {
				code = 138,
				definition = "The front leading light is extinguished. / The front range light is extinguished.",
				label = "Front Light Unlit",
			},
			new() {
				code = 139,
				definition = "The operation of the front leading light is unreliable due to technical problems. / The operation of the front range light is unreliable due to technical problems.",
				label = "Front Light Unreliable",
			},
			new() {
				code = 140,
				definition = "Due to technical problems front leading light has no rhythm and is in fixed light mode. / Due to technical problems front range light has no rhythm and is in fixed light mode.",
				label = "Front Light Without Rhythm",
			},
			new() {
				code = 141,
				definition = "The quality of service of a global navigation satellite system is poor due to an internal or external cause (e.g. jamming, space weather).",
				label = "GNSS Degradation",
			},
			new() {
				code = 142,
				definition = "An area which may contain known or unknown navigational hazards which could impact the safe navigation.",
				label = "Hazardous Area",
			},
			new() {
				code = 143,
				definition = "An outage, or return to operation, of an HF service (radiotelephone, digital selective calling or narrow band directing printing telegraphy).",
				label = "HF Service",
			},
			new() {
				code = 144,
				definition = "High water level, potentially over a sustained period of time, such as with extreme weather or river freshet.",
				label = "High Water Level",
			},
			new() {
				code = 145,
				definition = "The reduction in the horizontal distance or navigable width of a canal, channel, lock, etc.",
				label = "Horizontal Clearance Reduced",
			},
			new() {
				code = 146,
				definition = "Activity of vessels or drones/MASS, restricted in their ability to maneuver, engaged in towing of surface or subsurface scientific instruments to gather data on the measurements of subsurface features.",
				label = "Hydrographic Survey Activity",
			},
			new() {
				code = 147,
				definition = "A notice concerning the installation (or removal) of floating barriers, anchored to the bottom, used to deflect the path of floating ice in order to prevent the obstruction of locks, intakes, etc., and to prevent damage to bridge piers and other structures.",
				label = "Ice Boom - Installation or Removal",
			},
			new() {
				code = 148,
				definition = "Information concerning when a designated ice control zone is in force or deactivated. If in-force, mariners must follow established procedures for safe navigation.",
				label = "Ice Control Zone In-Force or Deactivated",
			},
			new() {
				code = 149,
				definition = "An iceberg which is reported outside of the advertised limits of ice.",
				label = "Iceberg Outside Advertised Limits",
			},
			new() {
				code = 150,
				definition = "An exercise in which the signals of radio navigation aids, radars or radio services are disrupted by an intentional cause for training purposes.",
				label = "Jamming Exercise",
			},
			new() {
				code = 151,
				definition = "The light on the buoy is damaged due to external factors (wind, sea state, collision with a vessel).",
				label = "Light Buoy - Light Damaged",
			},
			new() {
				code = 152,
				definition = "The light on the buoy is no longer synchronized with another light or group of lights.",
				label = "Light Buoy - Light Not Synchronized",
			},
			new() {
				code = 153,
				definition = "The light on the buoy is extinguished.",
				label = "Light Buoy - Light Unlit",
			},
			new() {
				code = 154,
				definition = "The operation of the light on the buoy is unreliable due to technical problems.",
				label = "Light Buoy - Light Unreliable",
			},
			new() {
				code = 155,
				definition = "The characteristics of the light have been or will be changed.",
				label = "Light Change",
			},
			new() {
				code = 156,
				definition = "The light daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).",
				label = "Light Daymark Unreliable",
			},
			new() {
				code = 157,
				definition = "A new light has been or will be established.",
				label = "Light Establishment",
			},
			new() {
				code = 158,
				definition = "The light is operating as advertised",
				label = "Light Operating Properly",
			},
			new() {
				code = 159,
				definition = "The light is no longer synchronized with another light or group of lights.",
				label = "Light Out Of Synchronization",
			},
			new() {
				code = 160,
				definition = "The nominal range of the light is less than the advertised range.",
				label = "Light Range Reduced",
			},
			new() {
				code = 161,
				definition = "The re-establishment of a light which was previously announced as either destroyed or temporarily removed.",
				label = "Light Re-Establishment",
			},
			new() {
				code = 162,
				definition = "Light has been or will be permanently removed from service.",
				label = "Light Removal",
			},
			new() {
				code = 163,
				definition = "The light on the spar buoy is damaged due to external factors (wind, sea state, collision with a vessel).",
				label = "Light Spar Buoy - Light Damaged",
			},
			new() {
				code = 164,
				definition = "The light on the spar buoy is no longer synchronized with another light or group of lights.",
				label = "Light Spar Buoy - Light Not Synchronized",
			},
			new() {
				code = 165,
				definition = "The light on the spar buoy is extinguished.",
				label = "Light Spar Buoy - Light Unlit",
			},
			new() {
				code = 166,
				definition = "The operation of the light on the spar buoy is unreliable due to technical problems.",
				label = "Light Spar Buoy - Light Unreliable",
			},
			new() {
				code = 167,
				definition = "The characteristics of the light have been or will be temporarily changed.",
				label = "Light Temporary Change",
			},
			new() {
				code = 168,
				definition = "A new light has been or will be established for a limited period of time.",
				label = "Light Temporary Establishment",
			},
			new() {
				code = 169,
				definition = "Light has been or will be temporarily removed from service.",
				label = "Light Temporary Removal",
			},
			new() {
				code = 170,
				definition = "The light is extinguished.",
				label = "Light Unlit",
			},
			new() {
				code = 171,
				definition = "The light is unreliable due to technical problems.",
				label = "Light Unreliable",
			},
			new() {
				code = 172,
				definition = "Due to technical problems the light has no more rhythm and is in fixed light mode.",
				label = "Light Without Rhythm",
			},
			new() {
				code = 173,
				definition = "The light on the beacon is damaged due to external factors (wind, sea state, collision with a vessel).",
				label = "Lighted Beacon - Light Damaged",
			},
			new() {
				code = 174,
				definition = "The light on the beacon is no longer synchronized with another light or group of lights.",
				label = "Lighted Beacon - Light Not Synchronized",
			},
			new() {
				code = 175,
				definition = "The light of the beacon is extinguished.",
				label = "Lighted Beacon - Light Unlit",
			},
			new() {
				code = 176,
				definition = "The operation of the light on the beacon is unreliable due to technical problems.",
				label = "Lighted Beacon - Light Unreliable",
			},
			new() {
				code = 177,
				definition = "Notice issued by local health authorities to persons ashore or at sea.",
				label = "Local Health Authority Notice",
			},
			new() {
				code = 178,
				definition = "Lock operation is compromised. The lock is closed.",
				label = "Lock Closed",
			},
			new() {
				code = 179,
				definition = "A log is a tree, stripped of its branches and roots, which is floating horizontally and barely awash.",
				label = "Log Adrift",
			},
			new() {
				code = 180,
				definition = "One or more sections of a chained log boom has broken free of its tow and is adrift.",
				label = "Log Boom Adrift",
			},
			new() {
				code = 181,
				definition = "The LORAN C station is operating as advertised.",
				label = "LORAN C - Operating Properly",
			},
			new() {
				code = 182,
				definition = "The LORAN C station is inoperative due to a technical issue.",
				label = "LORAN C - Out Of Service",
			},
			new() {
				code = 183,
				definition = "The LORAN C station is unreliable due to a technical issue or maintenance.",
				label = "LORAN C - Unreliable",
			},
			new() {
				code = 184,
				definition = "LORAN C station has been or will be permanently removed from service.",
				label = "LORAN C Station Removal",
			},
			new() {
				code = 185,
				definition = "LORAN C station has been or will be temporarily removed from service.",
				label = "LORAN C Station Temporary Removal",
			},
			new() {
				code = 186,
				definition = "Low water level, potentially over a sustained period of time, such as with extreme weather.",
				label = "Low Water Level",
			},
			new() {
				code = 187,
				definition = "The position or status of Marine Aids to Navigation, over an extensive area, is unreliable due to a natural event (freshet, storm surge, flooding).",
				label = "Marine Aids to Navigation Unreliable",
			},
			new() {
				code = 188,
				definition = "The raising or lowering of the national, regional or port-specific maritime security level within a country.",
				label = "Maritime Security Level Changes",
			},
			new() {
				code = 189,
				definition = "Any outage or return to operation of a MF service (radiotelephone, digital selective calling or narrow band directing printing).",
				label = "MF Service",
			},
			new() {
				code = 190,
				definition = "An exercise comprised of multiple vessels and/or aircraft used to train and asses operational capacity and strategy without actual live combat.",
				label = "Military Exercise",
			},
			new() {
				code = 191,
				definition = "A military response to a specific event or situation.",
				label = "Military Operation",
			},
			new() {
				code = 192,
				definition = "An outage of a maritime safety information broadcast service (satellite or terrestrial system).",
				label = "MSI Service",
			},
			new() {
				code = 193,
				definition = "Notice issued by a national health authority to persons ashore or at sea.",
				label = "National Health Authority Notice",
			},
			new() {
				code = 194,
				definition = "Any failure or return to service of the International or National NAVTEX broadcast services.",
				label = "NAVTEX Service Change",
			},
			new() {
				code = 195,
				definition = "New or updated maritime regulation which may impact navigation such as changes to navigation lanes or newly established areas to be avoided.",
				label = "New or Amended Regulation",
			},
			new() {
				code = 196,
				definition = "There are many fishing vessels operating in the area.",
				label = "Numerous Fishing Vessels",
			},
			new() {
				code = 197,
				definition = "Object reported adrift and posing a hazard to safe navigation.",
				label = "Object Adrift",
			},
			new() {
				code = 198,
				definition = "Changes to offshore rig/platforms, either fixed or floating, used for oil/gas production, exploration, research, observation, etc.",
				label = "Offshore Rigs or Platform Changes",
			},
			new() {
				code = 199,
				definition = "The temporary or permanent closing or re-opening of a harbour.",
				label = "Opening or Closing of Harbour",
			},
			new() {
				code = 200,
				definition = "The failure, or return to operation, of the opening or closing of swing bridges.",
				label = "Opening or Closing of Swing Bridge",
			},
			new() {
				code = 201,
				definition = "The temporary closing or re-opening of waters, e.g. waterway, bay, straits.",
				label = "Opening or Closing of Waters",
			},
			new() {
				code = 202,
				definition = "Activity comprised of one or more vessels engaged in the laying of pipe on or beneath the sea floor.",
				label = "Pipe Laying Operation",
			},
			new() {
				code = 203,
				definition = "Underwater operations undertaken to maintain or repair a submarine pipe.",
				label = "Pipe Operations",
			},
			new() {
				code = 204,
				definition = "There are fishing vessels using long fishing gear, such as fishing net and long fishing lines.",
				label = "Presence of Long Fishing Gear",
			},
			new() {
				code = 205,
				definition = "Presence of marine mammals is expected.",
				label = "Presence of Marine Mammals",
			},
			new() {
				code = 206,
				definition = "Self-contained explosive device, either floating or submerged, which could be triggered by the approach or contact with a vessel or submarine.",
				label = "Presence of Naval Mines",
			},
			new() {
				code = 207,
				definition = "A fishing net (seine, purse, gill, trawl, bag or other), reported submerged, or partially submerged, of sufficient size to pose a hazard to safe navigation.",
				label = "Presence of Submerged Fishing Net",
			},
			new() {
				code = 208,
				definition = "Presence of a buoy or object deployed to gather scientific information.",
				label = "Presence of Scientific Equipment",
			},
			new() {
				code = 209,
				definition = "The characteristics of the RACON have been or will be changed.",
				label = "RACON Change",
			},
			new() {
				code = 210,
				definition = "A new RACON has been or will be established.",
				label = "RACON Establishment",
			},
			new() {
				code = 211,
				definition = "The RACON is operating as advertised.",
				label = "RACON Operating Properly",
			},
			new() {
				code = 212,
				definition = "The RACON is inoperative.",
				label = "RACON Out Of Service",
			},
			new() {
				code = 213,
				definition = "RACON has been or will be permanently removed from service.",
				label = "RACON Removal",
			},
			new() {
				code = 214,
				definition = "The characteristics of the RACON have been or will be temporarily changed.",
				label = "RACON Temporary Change",
			},
			new() {
				code = 215,
				definition = "A new RACON has been or will be established for a limited period of time.",
				label = "RACON Temporary Establishment",
			},
			new() {
				code = 216,
				definition = "RACON has been or will be temporarily removed from service.",
				label = "RACON Temporary Removal",
			},
			new() {
				code = 217,
				definition = "The RACON is unreliable due to a technical issue or maintenance.",
				label = "RACON Unreliable",
			},
			new() {
				code = 218,
				definition = "Any failure or return to service of radar in an advertised radar-monitored area which may impact the ability of maritime authorities to track and monitor the movement of vessels.",
				label = "Radar Surveillance System Service Change",
			},
			new() {
				code = 219,
				definition = "The characteristics of the RAMARK have been or will be changed.",
				label = "RAMARK Change",
			},
			new() {
				code = 220,
				definition = "A new RAMARK has been or will be established.",
				label = "RAMARK Establishment",
			},
			new() {
				code = 221,
				definition = "The RAMARK is operating as advertised.",
				label = "RAMARK Operating Properly",
			},
			new() {
				code = 222,
				definition = "The RAMARK is inoperative.",
				label = "RAMARK Out Of Service",
			},
			new() {
				code = 223,
				definition = "RAMARK has been or will be permanently removed from service.",
				label = "RAMARK removal",
			},
			new() {
				code = 224,
				definition = "The characteristics of the RAMARK have been or will be temporarily changed.",
				label = "RAMARK Temporary Change",
			},
			new() {
				code = 225,
				definition = "A new RAMARK has been or will be established for a limited period of time.",
				label = "RAMARK Temporary Establishment",
			},
			new() {
				code = 226,
				definition = "RAMARK has been or will be temporarily removed from service.",
				label = "RAMARK Temporary Removal",
			},
			new() {
				code = 227,
				definition = "The RAMARK is unreliable due to a technical issue or maintenance.",
				label = "RAMARK Unreliable",
			},
			new() {
				code = 228,
				definition = "The rear leading beacon has been restored to normal condition. / The rear range beacon has been restored to normal condition.",
				label = "Rear Beacon Restored to Normal",
			},
			new() {
				code = 229,
				definition = "The rear leading beacon is damaged, obscured or missing. / The rear range beacon is damaged, obscured or missing",
				label = "Rear Beacon Unreliable",
			},
			new() {
				code = 230,
				definition = "The rear leading light is operating as advertised. / The rear range light is operating as advertised.",
				label = "Rear Light is Operating Properly",
			},
			new() {
				code = 231,
				definition = "The nominal range of the rear leading light is reduced. / The nominal range of the rear range light is reduced.",
				label = "Rear Light Range Reduced",
			},
			new() {
				code = 232,
				definition = "The rear leading light is extinguished. / The rear range light is extinguished.",
				label = "Rear Light Unlit",
			},
			new() {
				code = 233,
				definition = "The operation of the rear leading light is unreliable due to technical problems. / The operation of the rear range light is unreliable due to technical problems.",
				label = "Rear Light Unreliable",
			},
			new() {
				code = 234,
				definition = "Due to technical problems, the rear leading light has no rhythm and is in fixed light mode. / Due to technical problems rear range light has no rhythm and is in fixed light mode.",
				label = "Rear Light Without Rhythm",
			},
			new() {
				code = 235,
				definition = "A short or long race of sail, oar or power craft along a predetermined course which may approach or cross navigation lanes.",
				label = "Regatta or Race",
			},
			new() {
				code = 236,
				definition = "The installation, removal, failure or damage of renewable energy devices (Wind turbines/farms, ocean current or wave power plants) which pose a hazard to safe navigation.",
				label = "Renewable Energy Device or Farm Change",
			},
			new() {
				code = 237,
				definition = "A new or revised specified area, temporary or permanent in nature, designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.",
				label = "Restricted Area Changes",
			},
			new() {
				code = 238,
				definition = "Significant changes to the limits or depth of a known sandbar/sandspit, or the discovery of a new sandbar/sandspit, which poses a hazard to safe navigation.",
				label = "Sandspit or Sandbar Change",
			},
			new() {
				code = 239,
				definition = "A large scale activity where multiple vessels, surveillance aircraft, and shore-based personnel practice search and rescue techniques, in order to evaluate the effectiveness of response capability.",
				label = "SAR Exercise",
			},
			new() {
				code = 240,
				definition = "A real time response by vessels, surveillance aircraft, and shore-based personnel participating in an active search and rescue operation.",
				label = "SAR Operation",
			},
			new() {
				code = 241,
				definition = "A buoy fit for scientific purposes which has broken free of its moorings or has been left free and is adrift.",
				label = "Scientific Buoy Adrift",
			},
			new() {
				code = 242,
				definition = "A submerged platform where a scientific instrument is secured and which may or may not be secured to the sea floor by means of an anchor chain.",
				label = "Scientific Moorings",
			},
			new() {
				code = 243,
				definition = "An activity where one or more vessels, restricted in their ability to manoeuvre, navigate along a pre-determine grid pattern in order to collect scientific data.",
				label = "Scientific Survey",
			},
			new() {
				code = 244,
				definition = "Sea testing phase of a vessel.",
				label = "Sea Trials",
			},
			new() {
				code = 245,
				definition = "Activity within a defined area on the water where seaplanes are actively engaged in take-off, landing or taxiing.",
				label = "Seaplane Operations",
			},
			new() {
				code = 246,
				definition = "The completion of the process to place summer buoys (and the removal of any winter spar buoys).",
				label = "Seasonal Commissioning Complete",
			},
			new() {
				code = 247,
				definition = "The commencement of the process to place summer buoys (and the removal of any winter spar buoys).",
				label = "Seasonal Commissioning in Progress",
			},
			new() {
				code = 248,
				definition = "The completion of the process to remove summer buoys (and possibly replace some with winter spar buoys).",
				label = "Seasonal Decommissioning Complete",
			},
			new() {
				code = 249,
				definition = "The commencement of the process to remove summer buoys (and possibly replace some with winter spar buoys).",
				label = "Seasonal Decommissioning in Progress",
			},
			new() {
				code = 250,
				definition = "The light sector has been fully or partly obscured.",
				label = "Sector Light - Sector Obscured",
			},
			new() {
				code = 251,
				definition = "The characteristics of the sector light have been or will be changed.",
				label = "Sector Light Change",
			},
			new() {
				code = 252,
				definition = "The characteristics of the sector light have been or will be temporarily changed.",
				label = "Sector Light Temporary Change",
			},
			new() {
				code = 253,
				definition = "Changes to the national, regional or port-specific maritime security regulations.",
				label = "Security Regulation Change",
			},
			new() {
				code = 254,
				definition = "The commencement or cessation of the complex operations of a seismic survey.",
				label = "Seismic Survey Operation",
			},
			new() {
				code = 255,
				definition = "Confirmed significant change to the depth or position of a charted sounding/shoal, or the discovery of a new shoal, which poses a hazard to safe navigation.",
				label = "Shallow Depth Confirmed",
			},
			new() {
				code = 256,
				definition = "Reported significant change to the depth or position of a charted sounding/shoal, or the discovery of a new shoal, which poses a hazard to safe navigation.",
				label = "Shallow Depth Reported",
			},
			new() {
				code = 257,
				definition = "The spar buoy is no longer secured to its moorings and has gone adrift from its advertised position.",
				label = "Spar Buoy Adrift",
			},
			new() {
				code = 258,
				definition = "The spar buoy has been damaged due to external factors (wind, sea state, collision with a vessel).",
				label = "Spar Buoy Damaged",
			},
			new() {
				code = 259,
				definition = "The spar buoy has suffered extensive damage and is not useable.",
				label = "Spar Buoy Destroyed",
			},
			new() {
				code = 260,
				definition = "No spar buoy at its advertised position or in the vicinity.",
				label = "Spar Buoy Missing",
			},
			new() {
				code = 261,
				definition = "The spar buoy has been or will be moved intentionally.",
				label = "Spar Buoy Move",
			},
			new() {
				code = 262,
				definition = "The spar buoy has been dragged off its advertised position due to wind or current affecting the mooring system.",
				label = "Spar Buoy off Position",
			},
			new() {
				code = 263,
				definition = "The re-establishment of a spar buoy which was previously announced either destroyed or temporarily removed.",
				label = "Spar Buoy Re-established",
			},
			new() {
				code = 264,
				definition = "The spar buoy has been restored to normal condition.",
				label = "Spar Buoy Restored to Normal",
			},
			new() {
				code = 265,
				definition = "The topmark of the spar buoy is missing.",
				label = "Spar Buoy Topmark Missing",
			},
			new() {
				code = 266,
				definition = "The spar buoy has been removed from service for a fixed term.",
				label = "Spar Buoy Withdrawn",
			},
			new() {
				code = 267,
				definition = "A rise above normal water level on the open coast due only to the action of wind stress on the water surface. Storm surge resulting from a hurricane or other intense storm also includes the rise in level due to atmospheric pressure reduction as well as that due to wind stress. A storm surge is more severe when it occurs in conjunction with a high tide. Also called storm tide, storm wave, tidal wave.",
				label = "Storm Surge",
			},
			new() {
				code = 268,
				definition = "Change in status, location or depth of a submerged or seabed cable which poses a hazard to safe navigation, anchoring or fishing.",
				label = "Submarine Cable Changes",
			},
			new() {
				code = 269,
				definition = "Change in status, location or depth of a submerged or seabed pipeline which poses a hazard to safe navigation, anchoring or fishing.",
				label = "Submarine Pipeline Changes",
			},
			new() {
				code = 270,
				definition = "Any object under water; not showing above water.",
				label = "Submerged Object",
			},
			new() {
				code = 271,
				definition = "A mooring which is under water and which may or may not be secured to the sea floor by means of an anchor chain.",
				label = "Subsurface Mooring",
			},
			new() {
				code = 272,
				definition = "A single person or groups of persons will be / are swimming in or near navigation lanes.",
				label = "Swimmers",
			},
			new() {
				code = 273,
				definition = "The establishment of a buoy or group of buoys for a limited period of time (i.e. during summer season or during marine construction projects).",
				label = "Temporary Buoyage",
			},
			new() {
				code = 274,
				definition = "The installation or removal of a tide gauge.",
				label = "Tide Gauge Change",
			},
			new() {
				code = 275,
				definition = "An area is experiencing a significantly high volume of vessel traffic which could potentially impede the progress of a vessel.",
				label = "Traffic Congestion",
			},
			new() {
				code = 276,
				definition = "An alert message concerning strong waves, the widespread inundation of water, due to an earthquake, landslide or volcanic eruption, which is issued when the threat is imminent, expected or occurring.",
				label = "Tsunami Warning",
			},
			new() {
				code = 277,
				definition = "A newly located rock, submerged or partially submerged rock, which had not been previously charted.",
				label = "Uncharted Rock",
			},
			new() {
				code = 278,
				definition = "Underwater work to maintain or repair subsurface structures (e.g. drill head).",
				label = "Underwater Operations",
			},
			new() {
				code = 279,
				definition = "An unidentified radar target, within the advertised limits of ice, but not yet visually confirmed as being an iceberg.",
				label = "Unidentified Radar Target - Possible Iceberg",
			},
			new() {
				code = 280,
				definition = "A tow, which by the nature of the size, shape or dimensions of the object being towed, is cumbersome to effectively tow regardless of the conditions of the waterway.",
				label = "Unwieldy Tow",
			},
			new() {
				code = 281,
				definition = "The characteristics of the V-AIS have been or will be changed.",
				label = "V-AIS Change",
			},
			new() {
				code = 282,
				definition = "A new V-AIS has been or will be established.",
				label = "V-AIS Establishment",
			},
			new() {
				code = 283,
				definition = "Virtual AIS aid to navigation is operating as advertised.",
				label = "V-AIS Operating Properly",
			},
			new() {
				code = 284,
				definition = "Virtual AIS aid to navigation is extinguished.",
				label = "V-AIS Out Of Service",
			},
			new() {
				code = 285,
				definition = "V-AIS has been or will be permanently removed from service.",
				label = "V-AIS Removal",
			},
			new() {
				code = 286,
				definition = "The characteristics of the V-AIS have been or will be temporarily changed.",
				label = "V-AIS Temporary Change",
			},
			new() {
				code = 287,
				definition = "A new V-AIS has been or will be established for a limited period of time.",
				label = "V-AIS Temporary Establishment",
			},
			new() {
				code = 288,
				definition = "V-AIS has been or will be temporarily removed from service.",
				label = "V-AIS Temporary Removal",
			},
			new() {
				code = 289,
				definition = "Virtual AIS aid is unreliable due to a technical issue or maintenance.",
				label = "V-AIS Unreliable",
			},
			new() {
				code = 290,
				definition = "The reduction in the vertical distance between the air draft of a vessel and the lowest point on a bridge structure, cable or pipeline of which the vessel is intending to pass underneath.",
				label = "Vertical Clearance Reduced",
			},
			new() {
				code = 291,
				definition = "A vessel at sea or which has lost mechanical capability and cannot be moored or anchored.",
				label = "Vessel Adrift",
			},
			new() {
				code = 292,
				definition = "A vessel adrift at sea or safely anchored/moored, which has been damaged or has experienced some sort of mechanical or electrical failure so it can no longer sail.",
				label = "Vessel Disabled",
			},
			new() {
				code = 293,
				definition = "Any outage or return to operation of any VHF service (radiotelephone or digital selective calling).",
				label = "VHF Service Change",
			},
			new() {
				code = 294,
				definition = "Volcano activity impacting safe navigation.",
				label = "Volcano Activity",
			},
			new() {
				code = 295,
				definition = "Change to an existing vessel traffic service zone limit, procedure and or provision of broadcast service relating to vessels operating within that zone.",
				label = "VTS Change",
			},
			new() {
				code = 296,
				definition = "Temporary or permanent changes to a waterway/fairway which may render it unsafe/safe for marine traffic.",
				label = "Waterway Recommended or Not Recommended For Shipping",
			},
			new() {
				code = 297,
				definition = "The commencement or cessation of wharf construction.",
				label = "Wharf Construction",
			},
			new() {
				code = 298,
				definition = "An active marine project, either on the surface or under water, which may affect the navigation of vessels.",
				label = "Works in Progress",
			},
			new() {
				code = 299,
				definition = "Notice issued by World Health Organization to persons ashore or at sea.",
				label = "World Health Organization Notice",
			},
		});

		public static ImmutableArray<navwarnTypeGeneral> navwarnTypeGenerals => ImmutableArray.Create<navwarnTypeGeneral>(new navwarnTypeGeneral[]{
			new() {
				code = 1,
				definition = "Any casualties to lights, fog signals, buoys and other aids to navigation affecting shipping; establishment of major new aids to navigation or significant changes to existing ones, when such establishment or change might be misleading to shipping.",
				label = "Aids to Navigation Changes",
			},
			new() {
				code = 2,
				definition = "New or established aquaculture and fishing installations.",
				label = "Aquaculture and Fishing Installations",
			},
			new() {
				code = 3,
				definition = "Drifting hazards, including derelict ships, containers, other large items, etc.",
				label = "Drifting Hazards",
			},
			new() {
				code = 4,
				definition = "Operating anomalies identified within ECDIS, including issues with official data.",
				label = "ECDIS Operating Anomalies including Official Data Issues",
			},
			new() {
				code = 5,
				definition = "Hazards likely to constitute a danger to navigation.",
				label = "Other Hazards",
			},
			new() {
				code = 6,
				definition = "Health advisories or information.",
				label = "Health Advisories",
			},
			new() {
				code = 7,
				definition = "Newly discovered icebergs, changes to ice conditions and ice related information likely to impact navigation.",
				label = "Ice Information",
			},
			new() {
				code = 8,
				definition = "A list of serial numbers of warnings which are in-force.",
				label = "In-Force Bulletin",
			},
			new() {
				code = 9,
				definition = "Natural phenomena adversely affecting the marine environment.",
				label = "Dangerous Natural Phenomena",
			},
			new() {
				code = 10,
				definition = "Newly discovered rocks, shoals, reefs and wrecks likely to constitute a danger to navigation and, if relevant, their markings.",
				label = "Newly Discovered Dangers",
			},
			new() {
				code = 11,
				definition = "New or established complex structures situated at sea, including rigs, drilling platforms, offshore wind turbines, cables and pipelines.",
				label = "Offshore Infrastructure",
			},
			new() {
				code = 12,
				definition = "Acts of piracy and armed robbery against ships.",
				label = "Piracy or Robbery",
			},
			new() {
				code = 13,
				definition = "Any failure or return to service of terrestrial or satellite radio services used to determine the position of an object.",
				label = "Communication or Broadcast Service Change",
			},
			new() {
				code = 14,
				definition = "Changes to the established navigational routes or specific procedures related to them.",
				label = "Routeing Change",
			},
			new() {
				code = 15,
				definition = "Deployment or removal of scientific instruments on the surface, subsurface or on the sea floor.",
				label = "Scientific Instruments Change",
			},
			new() {
				code = 16,
				definition = "Changes to the maritime security levels in a country, a specific region or port. Or, changes to maritime security regulations.",
				label = "Security Requirement Change",
			},
			new() {
				code = 17,
				definition = "Events which might affect the safety of shipping, sometimes over wide areas, e.g. naval exercises, missile firings, space missions, nuclear tests, ordnance dumping zones, etc.",
				label = "Special Operations",
			},
			new() {
				code = 18,
				definition = "Objects being towed which are impacting navigation of vessels in its vicinity.",
				label = "Towing Operations",
			},
			new() {
				code = 19,
				definition = "Works at sea or onshore which might affect navigation.",
				label = "Works",
			},
			new() {
				code = 20,
				definition = "An update on the position, movement or status of rigs or drill ships within a defined area.",
				label = "Rig List",
			},
		});
	}

	namespace ComplexAttributes {
		/// <summary>
		/// Name or number of affected national paper chart or ENC.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class chartAffected : ComplexType {
			[XmlElement("chartNumber")]
			[Mandatory]
			public String chartNumber {get;set;} = string.Empty;

			[XmlElement("chartPlanNumber")]
			[Optional]
			public String? chartPlanNumber {get;set;} = default;

			[XmlIgnore]
			[Mandatory]
			public DateOnly editionDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			[XmlIgnore]
			[Optional]
			public DateOnly? lastNoticeDate {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializechartPlanNumber() { return !string.IsNullOrEmpty(chartPlanNumber); }

			public bool ShouldSerializelastNoticeDate() { return lastNoticeDate.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<chartAffected, bool>> _conditionalUnknown = new Dictionary<string,Func<chartAffected, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
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
			[XmlElement("dateEnd")]
			[Optional]
			public String? dateEnd {get;set;} = default;

			[XmlElement("dateStart")]
			[Optional]
			public String? dateStart {get;set;} = default;

			[XmlElement("timeOfDayEnd")]
			[Optional]
			public S100Framework.DomainModel.S100.Time? timeOfDayEnd {get;set;} = default;

			[XmlElement("timeOfDayStart")]
			[Optional]
			public S100Framework.DomainModel.S100.Time? timeOfDayStart {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			public bool ShouldSerializetimeOfDayEnd() { return timeOfDayEnd.HasValue; }

			public bool ShouldSerializetimeOfDayStart() { return timeOfDayStart.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<fixedDateRange, bool>> _conditionalUnknown = new Dictionary<string,Func<fixedDateRange, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
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
			[XmlElement("language")]
			[Mandatory]
			public String language {get;set;} = string.Empty;

			[XmlElement("text")]
			[Mandatory]
			public String text {get;set;} = string.Empty;

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<information, bool>> _conditionalUnknown = new Dictionary<string,Func<information, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Name of an area locality as defined by a competent authority.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class locationName : ComplexType {
			[XmlElement("language")]
			[Mandatory]
			public String language {get;set;} = string.Empty;

			[XmlElement("text")]
			[Mandatory]
			public String text {get;set;} = string.Empty;

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<locationName, bool>> _conditionalUnknown = new Dictionary<string,Func<locationName, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Message series identification of the warning or notice.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class messageSeriesIdentifier : ComplexType {
			[XmlElement("agencyResponsibleForProduction")]
			[Mandatory]
			public String agencyResponsibleForProduction {get;set;} = string.Empty;

			[XmlElement("interoperabilityIdentifier")]
			[Optional]
			public String? interoperabilityIdentifier {get;set;} = default;

			[XmlElement("nameOfSeries")]
			[Mandatory]
			public String nameOfSeries {get;set;} = string.Empty;

			[XmlElement("nationality")]
			[Optional]
			public String? nationality {get;set;} = default;

			[XmlElement("warningNumber")]
			[Mandatory]
			public int warningNumber {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Mandatory]
			public warningType warningType {get;set;}

			[XmlElement("year")]
			[Mandatory]
			public int year {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("warningType")]
			public SerializableEnumeration<warningType> warningTypeElement { get { return warningType; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<messageSeriesIdentifier, bool>> _conditionalUnknown = new Dictionary<string,Func<messageSeriesIdentifier, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Title of the navigational warning.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class navwarnTitle : ComplexType {
			[XmlElement("language")]
			[Mandatory]
			public String language {get;set;} = string.Empty;

			[XmlElement("text")]
			[Mandatory]
			public String text {get;set;} = string.Empty;

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<navwarnTitle, bool>> _conditionalUnknown = new Dictionary<string,Func<navwarnTitle, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Detailed information about a warning.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class warningInformation : ComplexType {
			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];

			[XmlElement("navwarnTypeDetails")]
			[Optional]
			public List<navwarnTypeDetails> navwarnTypeDetails {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializeinformation() { return information.Any(); }

			public bool ShouldSerializenavwarnTypeDetails() { return navwarnTypeDetails.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<warningInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<warningInformation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Reference to an object or feature that is external to the dataset.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureReference : ComplexType {
			[XmlElement("atoNNumber")]
			[Optional]
			public List<String> atoNNumber {get;set;} = [];

			[XmlElement("interoperabilityIdentifier")]
			[Optional]
			public List<String> interoperabilityIdentifier {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializeatoNNumber() { return atoNNumber.Any(); }

			public bool ShouldSerializeinteroperabilityIdentifier() { return interoperabilityIdentifier.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<featureReference, bool>> _conditionalUnknown = new Dictionary<string,Func<featureReference, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Provides the name of an entity, defines the national language of the name, and provides the option to display the name at various system display settings.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName : ComplexType {
			[XmlElement("language")]
			[Mandatory]
			public String language {get;set;} = string.Empty;

			[XmlElement("name")]
			[Mandatory]
			public String name {get;set;} = string.Empty;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public nameUsage? nameUsage {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("nameUsage")]
			public SerializableEnumeration<nameUsage>? nameUsageElement { get { return nameUsage; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<featureName, bool>> _conditionalUnknown = new Dictionary<string,Func<featureName, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The best estimate of the accuracy of a position.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty : ComplexType {
			[XmlElement("uncertaintyFixed")]
			[Mandatory]
			public double uncertaintyFixed {get;set;} = default;

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<horizontalPositionUncertainty, bool>> _conditionalUnknown = new Dictionary<string,Func<horizontalPositionUncertainty, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class spatialAccuracy : ComplexType {
			[XmlElement("horizontalPositionUncertainty")]
			[Mandatory]
			public horizontalPositionUncertainty horizontalPositionUncertainty {get;set;} = new horizontalPositionUncertainty {
				uncertaintyFixed = default,
			};

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<spatialAccuracy, bool>> _conditionalUnknown = new Dictionary<string,Func<spatialAccuracy, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Identifies paper charts, ENCs or publications that are affected by the information.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class affectedChartPublications : ComplexType {
			[XmlElement("chartAffected")]
			[Optional]
			public chartAffected? chartAffected {get;set;} = default;

			[XmlElement("chartPublicationIdentifier")]
			[Optional]
			public String? chartPublicationIdentifier {get;set;} = default;

			[XmlElement("internationalChartAffected")]
			[Optional]
			public String? internationalChartAffected {get;set;} = default;

			[XmlElement("language")]
			[Mandatory]
			public String language {get;set;} = string.Empty;

			[XmlElement("publicationAffected")]
			[Optional]
			public String? publicationAffected {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializechartAffected() { return chartAffected!=default; }

			public bool ShouldSerializechartPublicationIdentifier() { return !string.IsNullOrEmpty(chartPublicationIdentifier); }

			public bool ShouldSerializeinternationalChartAffected() { return !string.IsNullOrEmpty(internationalChartAffected); }

			public bool ShouldSerializepublicationAffected() { return !string.IsNullOrEmpty(publicationAffected); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<affectedChartPublications, bool>> _conditionalUnknown = new Dictionary<string,Func<affectedChartPublications, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The general area used to identify which broad geographic region the message affects. The geographical name which is selected for the general area should be one that can be found on charts and in nautical publications. (S-53, 6).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class generalArea : ComplexType {
			[XmlElement("localityIdentifier")]
			[Optional]
			public String? localityIdentifier {get;set;} = default;

			[XmlElement("locationName")]
			[Multiplicity(1)]
			public List<locationName> locationName {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializelocalityIdentifier() { return !string.IsNullOrEmpty(localityIdentifier); }

			public bool ShouldSerializelocationName() { return locationName.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<generalArea, bool>> _conditionalUnknown = new Dictionary<string,Func<generalArea, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Name and/or identifier of an area locality.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class locality : ComplexType {
			[XmlElement("localityIdentifier")]
			[Optional]
			public String? localityIdentifier {get;set;} = default;

			[XmlElement("locationName")]
			[Multiplicity(1)]
			public List<locationName> locationName {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializelocalityIdentifier() { return !string.IsNullOrEmpty(localityIdentifier); }

			public bool ShouldSerializelocationName() { return locationName.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<locality, bool>> _conditionalUnknown = new Dictionary<string,Func<locality, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

	}
	public enum Role {
		[System.ComponentModel.Description("The header of a navigational warning.")]
		header,
		[System.ComponentModel.Description("The body of a navigational warning.")]
		theWarningPart,
		[System.ComponentModel.Description("The references relevant to the navigational warning")]
		theReferences,
		[System.ComponentModel.Description("The navigational warning that has references")]
		theWarning,
		[System.ComponentModel.Description("A pointer to a specific feature(s).")]
		thePositionProvider,
		[System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
		theCartographicText,
		[System.ComponentModel.Description("marked by an area to show impacts")]
		impacts,
		[System.ComponentModel.Description("marking an affected area")]
		affects,
	}

	namespace InformationAssociations {
		/// <summary>
		/// The binding between a navigational warning preamble and the body.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class navwarnPreambleContent : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(navwarnPreambleContent);
		}

		/// <summary>
		/// The relationship between a navigational warning and previous information relevant to its purpose.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class navwarnReferences : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(navwarnReferences);
		}
	}

	namespace FeatureAssociations {
		/// <summary>
		/// a feature association for the binding between a geo feature and the cartographically positioned location for text.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextAssociation : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TextAssociation);
		}

		/// <summary>
		/// Association between a warning and the area impacted.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class areaAffected : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(areaAffected);
		}
	}

}

namespace S100Framework.DomainModel.S124 {
	using ComplexAttributes;
	using InformationAssociations;
		using System.Xml.Linq;

	namespace InformationTypes {
		/// <summary>
		/// References to for example a navigational warning, nautical publication or chart.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class References : InformationNode, IInformationBindingDefinition {
			[XmlElement("messageSeriesIdentifier")]
			[Optional]
			public List<messageSeriesIdentifier> messageSeriesIdentifier {get;set;} = [];

			[XmlElement("noMessageOnHand")]
			[Mandatory]
			public Boolean noMessageOnHand {get;set;} = false;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Mandatory]
			public referenceCategory referenceCategory {get;set;}


			#region ShouldSerialize
			public bool ShouldSerializemessageSeriesIdentifier() { return messageSeriesIdentifier.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("referenceCategory")]
			public SerializableEnumeration<referenceCategory> referenceCategoryElement { get { return referenceCategory; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(References);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => References._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(navwarnReferences),
					role = Enum.GetName<Role>(Role.theWarning)!,
					informationTypes = [nameof(NavwarnPreamble)],
					primitives = [],
				},
			];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<References, bool>> _conditionalUnknown = new Dictionary<string,Func<References, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Preamble information for warnings, notices and other types of messages in a navigational warning scheme.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavwarnPreamble : InformationNode, IInformationBindingDefinition {
			[XmlElement("affectedChartPublications")]
			[Optional]
			public List<affectedChartPublications> affectedChartPublications {get;set;} = [];

			[XmlElement("generalArea")]
			[Multiplicity(1)]
			public List<generalArea> generalArea {get;set;} = [];

			[XmlElement("locality")]
			[Optional]
			public List<locality> locality {get;set;} = [];

			[XmlElement("messageSeriesIdentifier")]
			[Mandatory]
			public messageSeriesIdentifier messageSeriesIdentifier {get;set;} = new messageSeriesIdentifier {
				agencyResponsibleForProduction = string.Empty,
				nameOfSeries = string.Empty,
				warningNumber = default,
				warningType = Enum.GetValues<warningType>()[0],
				year = default,
			};

			[XmlElement("navwarnTitle")]
			[Optional]
			public List<navwarnTitle> navwarnTitle {get;set;} = [];

			[XmlElement("cancellationDate")]
			[Optional]
			public DateTime? cancellationDate {get;set;} = default;

			[XmlElement("intService")]
			[Mandatory]
			public Boolean intService {get;set;} = false;

			[XmlElement("navwarnTypeGeneral")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20])]
			[Mandatory]
			public navwarnTypeGeneral navwarnTypeGeneral {get;set;} = default;

			[XmlElement("publicationTime")]
			[Mandatory]
			public DateTime publicationTime {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeaffectedChartPublications() { return affectedChartPublications.Any(); }

			public bool ShouldSerializegeneralArea() { return generalArea.Any(); }

			public bool ShouldSerializelocality() { return locality.Any(); }

			public bool ShouldSerializenavwarnTitle() { return navwarnTitle.Any(); }

			public bool ShouldSerializecancellationDate() { return cancellationDate.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavwarnPreamble);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => NavwarnPreamble._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(navwarnReferences),
					role = Enum.GetName<Role>(Role.theReferences)!,
					informationTypes = [nameof(References)],
					primitives = [],
				},
			];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<NavwarnPreamble, bool>> _conditionalUnknown = new Dictionary<string,Func<NavwarnPreamble, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The indication of the quality of the locational information for features in a dataset.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQuality : InformationNode, IInformationBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			[Optional]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			[XmlElement("spatialAccuracy")]
			[Optional]
			public spatialAccuracy? spatialAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			public bool ShouldSerializespatialAccuracy() { return spatialAccuracy!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("qualityOfHorizontalMeasurement")]
			public SerializableEnumeration<qualityOfHorizontalMeasurement>? qualityOfHorizontalMeasurementElement { get { return qualityOfHorizontalMeasurement; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpatialQuality);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<SpatialQuality, bool>> _conditionalUnknown = new Dictionary<string,Func<SpatialQuality, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}
	}
	namespace FeatureTypes {
		using FeatureAssociations;
		using InformationTypes;
		using System.Xml;
		using System.Xml.Linq;

		/// <summary>
		/// Navigational warning information that may be geo-located.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavwarnPart : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([7,8,14,25,27])]
			[Optional]
			public restriction? restriction {get;set;} = default;

			[XmlElement("fixedDateRange")]
			[Optional]
			public List<fixedDateRange> fixedDateRange {get;set;} = [];

			[XmlElement("warningInformation")]
			[Mandatory]
			public warningInformation warningInformation {get;set;} = new warningInformation {
			};

			[XmlElement("featureName")]
			[Optional]
			public List<featureName> featureName {get;set;} = [];

			[XmlElement("featureReference")]
			[Optional]
			public List<featureReference> featureReference {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializerestriction() { return restriction.HasValue; }

			public bool ShouldSerializefixedDateRange() { return fixedDateRange.Any(); }

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public bool ShouldSerializefeatureReference() { return featureReference.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>? restrictionElement { get { return restriction; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavwarnPart);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => NavwarnPart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(navwarnPreambleContent),
					role = Enum.GetName<Role>(Role.header)!,
					informationTypes = [nameof(NavwarnPreamble)],
					primitives = [],
				},
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => NavwarnPart._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => NavwarnPart._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(areaAffected),
					role = Enum.GetName<Role>(Role.affects)!,
					featureTypes = [nameof(NavwarnAreaAffected)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.thePositionProvider)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<NavwarnPart, bool>> _conditionalUnknown = new Dictionary<string,Func<NavwarnPart, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An area affected by some event marked by a navigational warning.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavwarnAreaAffected : FeatureNode, IFeatureBindingDefinition {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavwarnAreaAffected);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => NavwarnAreaAffected._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => NavwarnAreaAffected._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => NavwarnAreaAffected._primitives;
			public static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(areaAffected),
					role = Enum.GetName<Role>(Role.impacts)!,
					featureTypes = [nameof(NavwarnPart)],
				},
			];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<NavwarnAreaAffected, bool>> _conditionalUnknown = new Dictionary<string,Func<NavwarnAreaAffected, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("scaleMinimum")]
			[Optional]
			public int? scaleMinimum {get;set;} = default;

			[XmlElement("text")]
			[Mandatory]
			public String text {get;set;} = string.Empty;

			[XmlElement("textOffsetBearing")]
			[Mandatory]
			public int textOffsetBearing {get;set;} = default;

			[XmlElement("textOffsetDistance")]
			[Mandatory]
			public int textOffsetDistance {get;set;} = default;

			[XmlElement("textRotation")]
			[Mandatory]
			public Boolean textRotation {get;set;} = false;


			#region ShouldSerialize
			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TextPlacement);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
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
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(NavwarnPart)],
				},
			];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XElement[]? Geometry { get; set; } = default;

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<TextPlacement, bool>> _conditionalUnknown = new Dictionary<string,Func<TextPlacement, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S124/2.0")]
	[XmlRoot(Namespace = "http://www.iho.int/S124/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S124/2.0 124_2.0.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S124/2.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.References", typeof(InformationTypes.References), Order = 1, ElementName = "References")]
		[XmlElement("InformationTypes.NavwarnPreamble", typeof(InformationTypes.NavwarnPreamble), Order = 1, ElementName = "NavwarnPreamble")]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1, ElementName = "SpatialQuality")]
		[XmlElement("FeatureTypes.NavwarnPart", typeof(FeatureTypes.NavwarnPart), Order = 1, ElementName = "NavwarnPart")]
		[XmlElement("FeatureTypes.NavwarnAreaAffected", typeof(FeatureTypes.NavwarnAreaAffected), Order = 1, ElementName = "NavwarnAreaAffected")]
		[XmlElement("FeatureTypes.TextPlacement", typeof(FeatureTypes.TextPlacement), Order = 1, ElementName = "TextPlacement")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
