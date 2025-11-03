using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S125 {
	public class Summary : ISummary
	{
		public static string Name => "S-125";
		public static string Scope => "";
		public static string ProductId => "S-125";
		public static Version Version => new Version("0.0.4 with FIHO_FIXES 2025-10-03");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-09-11", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["horizontalPositionUncertainty","verticalUncertainty","directionalCharacter","featureName","fixedDateRange","information","lightSector","multiplicityOfFeatures","orientation","periodicDateRange","radarWaveLength","rhythmOfLight","sectorCharacteristics","ObscuredSector","sectorInformation","sectorLimit","sectorLimitOne","sectorLimitTwo","signalSequence","ChangeDetails"];
		public static string[] InformationAssociationTypes => ["Atonstatus"];
		public static string[] FeatureAssociationTypes => ["BuoyTopmark","StructureEquipment","PhysicalAIS","SyntheticAIS","VirtualAIS","AtonAggregations","AtonAssociations","RangeSystem","DangerousFeatureAssociation"];
		public static string[] InformationTypes => ["AtonStatusInformation"];
		public static string[] FeatureTypes => ["Equipment","GenericBuoy","Pile","SiloTank","CardinalBuoy","EmergencyWreckMarkingBuoy","InstallationBuoy","IsolatedDangerBuoy","LateralBuoy","LightFloat","LightVessel","MooringBuoy","OffshorePlatform","SafeWaterBuoy","SpecialPurposeGeneralBuoy","NavigationLine","RecommendedTrack","VirtualAISAidToNavigation","Daymark","StructureObject","FogSignal","RadarReflector","GenericBeacon","RadarTransponderBeacon","RadioStation","LightAirObstruction","Retroreflector","LightAllAround","LightFogDetector","LightSectored","CardinalBeacon","IsolatedDangerBeacon","Landmark","LateralBeacon","Lighthouse","SafeWaterBeacon","SpecialPurposeGeneralBeacon","DangerousFeature","AtonAssociation","AtonAggregation","Topmark","PhysicalAISAidToNavigation","SyntheticAISAidToNavigation"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["AidsToNavigation","StructureObject","GenericBeacon","AtonAssociation","AtonAggregation","ElectronicAton","GenericLight"],
			Primitives.point => ["Equipment","GenericBuoy","Pile","SiloTank","CardinalBuoy","EmergencyWreckMarkingBuoy","InstallationBuoy","IsolatedDangerBuoy","LateralBuoy","LightFloat","LightVessel","MooringBuoy","OffshorePlatform","SafeWaterBuoy","SpecialPurposeGeneralBuoy","VirtualAISAidToNavigation","Daymark","FogSignal","RadarReflector","RadarTransponderBeacon","RadioStation","LightAirObstruction","Retroreflector","LightAllAround","LightFogDetector","LightSectored","CardinalBeacon","IsolatedDangerBeacon","Landmark","LateralBeacon","Lighthouse","SafeWaterBeacon","SpecialPurposeGeneralBeacon","DangerousFeature","Topmark","PhysicalAISAidToNavigation","SyntheticAISAidToNavigation"],
			Primitives.surface => ["SiloTank","OffshorePlatform","Landmark","Lighthouse"],
			Primitives.curve => ["NavigationLine","RecommendedTrack","Landmark"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"AidsToNavigation" => [Primitives.noGeometry],
			"Equipment" => [Primitives.point],
			"GenericBuoy" => [Primitives.point],
			"Pile" => [Primitives.point],
			"SiloTank" => [Primitives.point,Primitives.surface],
			"CardinalBuoy" => [Primitives.point],
			"EmergencyWreckMarkingBuoy" => [Primitives.point],
			"InstallationBuoy" => [Primitives.point],
			"IsolatedDangerBuoy" => [Primitives.point],
			"LateralBuoy" => [Primitives.point],
			"LightFloat" => [Primitives.point],
			"LightVessel" => [Primitives.point],
			"MooringBuoy" => [Primitives.point],
			"OffshorePlatform" => [Primitives.point,Primitives.surface],
			"SafeWaterBuoy" => [Primitives.point],
			"SpecialPurposeGeneralBuoy" => [Primitives.point],
			"NavigationLine" => [Primitives.curve],
			"RecommendedTrack" => [Primitives.curve],
			"VirtualAISAidToNavigation" => [Primitives.point],
			"Daymark" => [Primitives.point],
			"StructureObject" => [Primitives.noGeometry],
			"FogSignal" => [Primitives.point],
			"RadarReflector" => [Primitives.point],
			"GenericBeacon" => [Primitives.noGeometry],
			"RadarTransponderBeacon" => [Primitives.point],
			"RadioStation" => [Primitives.point],
			"LightAirObstruction" => [Primitives.point],
			"Retroreflector" => [Primitives.point],
			"LightAllAround" => [Primitives.point],
			"LightFogDetector" => [Primitives.point],
			"LightSectored" => [Primitives.point],
			"CardinalBeacon" => [Primitives.point],
			"IsolatedDangerBeacon" => [Primitives.point],
			"Landmark" => [Primitives.point,Primitives.curve,Primitives.surface],
			"LateralBeacon" => [Primitives.point],
			"Lighthouse" => [Primitives.point,Primitives.surface],
			"SafeWaterBeacon" => [Primitives.point],
			"SpecialPurposeGeneralBeacon" => [Primitives.point],
			"DangerousFeature" => [Primitives.point],
			"AtonAssociation" => [Primitives.noGeometry],
			"AtonAggregation" => [Primitives.noGeometry],
			"ElectronicAton" => [Primitives.noGeometry],
			"GenericLight" => [Primitives.noGeometry],
			"Topmark" => [Primitives.point],
			"PhysicalAISAidToNavigation" => [Primitives.point],
			"SyntheticAISAidToNavigation" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
		public static Type InformationBindings(string code) => code switch {
			"Atonstatus" => typeof(informationBinding<InformationAssociations.Atonstatus>),
			_ or "" => throw new InvalidOperationException(),
		};
		public static Type FeatureBindings(string code) => code switch {
			"BuoyTopmark" => typeof(featureBinding<FeatureAssociations.BuoyTopmark>),
			"StructureEquipment" => typeof(featureBinding<FeatureAssociations.StructureEquipment>),
			"PhysicalAIS" => typeof(featureBinding<FeatureAssociations.PhysicalAIS>),
			"SyntheticAIS" => typeof(featureBinding<FeatureAssociations.SyntheticAIS>),
			"VirtualAIS" => typeof(featureBinding<FeatureAssociations.VirtualAIS>),
			"AtonAggregations" => typeof(featureBinding<FeatureAssociations.AtonAggregations>),
			"AtonAssociations" => typeof(featureBinding<FeatureAssociations.AtonAssociations>),
			"RangeSystem" => typeof(featureBinding<FeatureAssociations.RangeSystem>),
			"DangerousFeatureAssociation" => typeof(featureBinding<FeatureAssociations.DangerousFeatureAssociation>),
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.Atonstatus>), typeDiscriminator: "informationBinding::S125::Atonstatus"));
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BuoyTopmark>), typeDiscriminator: "featureBinding::S125::BuoyTopmark"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.StructureEquipment>), typeDiscriminator: "featureBinding::S125::StructureEquipment"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.PhysicalAIS>), typeDiscriminator: "featureBinding::S125::PhysicalAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.SyntheticAIS>), typeDiscriminator: "featureBinding::S125::SyntheticAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.VirtualAIS>), typeDiscriminator: "featureBinding::S125::VirtualAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.AtonAggregations>), typeDiscriminator: "featureBinding::S125::AtonAggregations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.AtonAssociations>), typeDiscriminator: "featureBinding::S125::AtonAssociations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.RangeSystem>), typeDiscriminator: "featureBinding::S125::RangeSystem"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.DangerousFeatureAssociation>), typeDiscriminator: "featureBinding::S125::DangerousFeatureAssociation"));
				}
			});
			return resolver;
		}


		public static System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver SharedBindingResolver() {
			var resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
			resolver.Modifiers.Add(typeInfo => {
				if (typeInfo.Type == typeof(informationBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$type",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.Atonstatus>), typeDiscriminator: "informationBinding::S125::Atonstatus"));
				}
				if (typeInfo.Type == typeof(featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$type",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BuoyTopmark>), typeDiscriminator: "featureBinding::S125::BuoyTopmark"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.StructureEquipment>), typeDiscriminator: "featureBinding::S125::StructureEquipment"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.PhysicalAIS>), typeDiscriminator: "featureBinding::S125::PhysicalAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.SyntheticAIS>), typeDiscriminator: "featureBinding::S125::SyntheticAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.VirtualAIS>), typeDiscriminator: "featureBinding::S125::VirtualAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.AtonAggregations>), typeDiscriminator: "featureBinding::S125::AtonAggregations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.AtonAssociations>), typeDiscriminator: "featureBinding::S125::AtonAssociations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.RangeSystem>), typeDiscriminator: "featureBinding::S125::RangeSystem"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.DangerousFeatureAssociation>), typeDiscriminator: "featureBinding::S125::DangerousFeatureAssociation"));
				}
			});
			return resolver;
		}
	}

	/// <summary>
	/// Modifications to electronic or digital AtoNs, such as AIS (Automatic Identification System) AtoNs, virtual AtoNs, or remote-controlled systems.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum electronicAtonChange : int {
		[System.ComponentModel.Description("The terrestrial AIS transmitter is inoperative due to a technical issue.")]
		[EnumMember(Value = "AIS Transmitter Out Of Service")] 
		[XmlEnum("1")] 
		AisTransmitterOutOfService = 1,

		[System.ComponentModel.Description("The terrestrial AIS transmitter is unreliable due to a technical issue or maintenance.")]
		[EnumMember(Value = "AIS Transmitter Unreliable")] 
		[XmlEnum("2")] 
		AisTransmitterUnreliable = 2,

		[System.ComponentModel.Description("The terrestrial AIS transmitter is operating as advertised.")]
		[EnumMember(Value = "AIS Transmitter Operating Properly")] 
		[XmlEnum("3")] 
		AisTransmitterOperatingProperly = 3,

		[System.ComponentModel.Description("Virtual AIS aid to navigation is extinguished.")]
		[EnumMember(Value = "V-AIS Out Of Service")] 
		[XmlEnum("4")] 
		VAisOutOfService = 4,

		[System.ComponentModel.Description("Virtual AIS aid is unreliable due to a technical issue or maintenance.")]
		[EnumMember(Value = "V-AIS Unreliable")] 
		[XmlEnum("5")] 
		VAisUnreliable = 5,

		[System.ComponentModel.Description("Virtual AIS aid to navigation is operating as advertised.")]
		[EnumMember(Value = "V-AIS Operating Properly")] 
		[XmlEnum("6")] 
		VAisOperatingProperly = 6,

		[System.ComponentModel.Description("The RACON is inoperative.")]
		[EnumMember(Value = "RACON Out Of Service")] 
		[XmlEnum("7")] 
		RaconOutOfService = 7,

		[System.ComponentModel.Description("The RACON is unreliable due to a technical issue or maintenance.")]
		[EnumMember(Value = "RACON Unreliable")] 
		[XmlEnum("8")] 
		RaconUnreliable = 8,

		[System.ComponentModel.Description("The RACON is operating as advertised.")]
		[EnumMember(Value = "RACON Operating Properly")] 
		[XmlEnum("9")] 
		RaconOperatingProperly = 9,

		[System.ComponentModel.Description("The DGPS station is inoperative due to a technical issue.")]
		[EnumMember(Value = "DGPS Out Of Service")] 
		[XmlEnum("10")] 
		DgpsOutOfService = 10,

		[System.ComponentModel.Description("The DGPS station is operating as advertised.")]
		[EnumMember(Value = "DGPS Operating Properly")] 
		[XmlEnum("11")] 
		DgpsOperatingProperly = 11,

		[System.ComponentModel.Description("The DGPS station is unreliable due to a technical issue or maintenance.")]
		[EnumMember(Value = "DGPS Unreliable")] 
		[XmlEnum("12")] 
		DgpsUnreliable = 12,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "LORAN C operating properly")] 
		[XmlEnum("13")] 
		LoranCOperatingProperly = 13,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "LORAN C unreliable")] 
		[XmlEnum("14")] 
		LoranCUnreliable = 14,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "LORAN C out of service")] 
		[XmlEnum("15")] 
		LoranCOutOfService = 15,

		[System.ComponentModel.Description("The eLORAN station is operating as advertised.")]
		[EnumMember(Value = "ELORAN Operating Properly")] 
		[XmlEnum("16")] 
		EloranOperatingProperly = 16,

		[System.ComponentModel.Description("The eLORAN station is unreliable due to a technical issue or maintenance.")]
		[EnumMember(Value = "ELORAN Unreliable")] 
		[XmlEnum("17")] 
		EloranUnreliable = 17,

		[System.ComponentModel.Description("The eLORAN station is inoperative due to a technical issue.")]
		[EnumMember(Value = "ELORAN Out Of Service")] 
		[XmlEnum("18")] 
		EloranOutOfService = 18,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "DGLOANSS operating properly")] 
		[XmlEnum("19")] 
		DgloanssOperatingProperly = 19,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "DGLOANSS unreliable")] 
		[XmlEnum("20")] 
		DgloanssUnreliable = 20,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "DGLOANSS out of service")] 
		[XmlEnum("21")] 
		DgloanssOutOfService = 21,

		[System.ComponentModel.Description("The Chayka station is operating as advertised.")]
		[EnumMember(Value = "Chayka Operating Properly")] 
		[XmlEnum("22")] 
		ChaykaOperatingProperly = 22,

		[System.ComponentModel.Description("The Chayka station is unreliable due to a technical issue or maintenance.")]
		[EnumMember(Value = "Chayka Unreliable")] 
		[XmlEnum("23")] 
		ChaykaUnreliable = 23,

		[System.ComponentModel.Description("The Chayka station is inoperative due to a technical issue.")]
		[EnumMember(Value = "Chayka Out Of Service")] 
		[XmlEnum("24")] 
		ChaykaOutOfService = 24,

		[System.ComponentModel.Description("The e-Chayka station is operating as advertised.")]
		[EnumMember(Value = "E-Chayka Operating Properly")] 
		[XmlEnum("25")] 
		EChaykaOperatingProperly = 25,

		[System.ComponentModel.Description("The e-Chayka station is unreliable due to a technical issue or maintenance.")]
		[EnumMember(Value = "E-Chayka Unreliable")] 
		[XmlEnum("26")] 
		EChaykaUnreliable = 26,

		[System.ComponentModel.Description("The e-Chayka station is inoperative due to a technical issue.")]
		[EnumMember(Value = "E-Chayka Out Of Service")] 
		[XmlEnum("27")] 
		EChaykaOutOfService = 27,

		[System.ComponentModel.Description("The EGNOS station is operating as advertised.")]
		[EnumMember(Value = "EGNOS Operating Properly")] 
		[XmlEnum("28")] 
		EgnosOperatingProperly = 28,

		[System.ComponentModel.Description("The EGNOS station is unreliable due to a technical issue or maintenance.")]
		[EnumMember(Value = "EGNOS Unreliable")] 
		[XmlEnum("29")] 
		EgnosUnreliable = 29,

		[System.ComponentModel.Description("The EGNOS station is inoperative due to a technical issue.")]
		[EnumMember(Value = "EGNOS Out Of Service")] 
		[XmlEnum("30")] 
		EgnosOutOfService = 30,
	}

	/// <summary>
	/// Updates or modifications to light-emitting AtoNs, including changing light characteristics, intensity, or operational status.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightedAtonChange : int {
		[System.ComponentModel.Description("The light is extinguished.")]
		[EnumMember(Value = "Light Unlit")] 
		[XmlEnum("1")] 
		LightUnlit = 1,

		[System.ComponentModel.Description("The light is unreliable due to technical problems.")]
		[EnumMember(Value = "Light Unreliable")] 
		[XmlEnum("2")] 
		LightUnreliable = 2,

		[System.ComponentModel.Description("The re-establishment of a light which was previously announced as either destroyed or temporarily removed.")]
		[EnumMember(Value = "Light Re-Establishment")] 
		[XmlEnum("3")] 
		LightReEstablishment = 3,

		[System.ComponentModel.Description("The nominal range of the light is less than the advertised range.")]
		[EnumMember(Value = "Light Range Reduced")] 
		[XmlEnum("4")] 
		LightRangeReduced = 4,

		[System.ComponentModel.Description("Due to technical problems the light has no more rhythm and is in fixed light mode.")]
		[EnumMember(Value = "Light Without Rhythm")] 
		[XmlEnum("5")] 
		LightWithoutRhythm = 5,

		[System.ComponentModel.Description("The light is no longer synchronized with another light or group of lights.")]
		[EnumMember(Value = "Light Out Of Synchronization")] 
		[XmlEnum("6")] 
		LightOutOfSynchronization = 6,

		[System.ComponentModel.Description("The light daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).")]
		[EnumMember(Value = "Light Daymark Unreliable")] 
		[XmlEnum("7")] 
		LightDaymarkUnreliable = 7,

		[System.ComponentModel.Description("The light is operating as advertised")]
		[EnumMember(Value = "Light Operating Properly")] 
		[XmlEnum("8")] 
		LightOperatingProperly = 8,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Sector light Sector obscured")] 
		[XmlEnum("9")] 
		SectorLightSectorObscured = 9,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Front leading/range light Unlit")] 
		[XmlEnum("10")] 
		FrontLeadingRangeLightUnlit = 10,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Rear leading/range light Unlit")] 
		[XmlEnum("11")] 
		RearLeadingRangeLightUnlit = 11,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Front leading/range light Unreliable")] 
		[XmlEnum("12")] 
		FrontLeadingRangeLightUnreliable = 12,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Rear leading/range light Unreliable")] 
		[XmlEnum("13")] 
		RearLeadingRangeLightUnreliable = 13,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Front leading/range light Light range reduced")] 
		[XmlEnum("14")] 
		FrontLeadingRangeLightLightRangeReduced = 14,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Rear leading/range light Light range reduced")] 
		[XmlEnum("15")] 
		RearLeadingRangeLightLightRangeReduced = 15,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Front leading/range light without rhythm")] 
		[XmlEnum("16")] 
		FrontLeadingRangeLightWithoutRhythm = 16,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Rear leading/range light without rhythm")] 
		[XmlEnum("17")] 
		RearLeadingRangeLightWithoutRhythm = 17,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Leading/range lights out of synchronization")] 
		[XmlEnum("18")] 
		LeadingRangeLightsOutOfSynchronization = 18,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Front leading/range beacon Unreliable")] 
		[XmlEnum("19")] 
		FrontLeadingRangeBeaconUnreliable = 19,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Rear leading/range beacon Unreliable")] 
		[XmlEnum("20")] 
		RearLeadingRangeBeaconUnreliable = 20,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Front leading/range light is operating properly")] 
		[XmlEnum("21")] 
		FrontLeadingRangeLightIsOperatingProperly = 21,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Rear leading/range light is operating properly")] 
		[XmlEnum("22")] 
		RearLeadingRangeLightIsOperatingProperly = 22,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Front leading/range beacon restored to normal")] 
		[XmlEnum("23")] 
		FrontLeadingRangeBeaconRestoredToNormal = 23,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Rear leading/range beacon restored to normal")] 
		[XmlEnum("24")] 
		RearLeadingRangeBeaconRestoredToNormal = 24,
	}

	/// <summary>
	/// Any modification to an AtoN that uses sound signals, such as foghorns or bells, to assist in navigation under low visibility conditions.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum audibleSignalAtonChange : int {
		[System.ComponentModel.Description("The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is inoperative.")]
		[EnumMember(Value = "Audible Signal Out Of Service")] 
		[XmlEnum("1")] 
		AudibleSignalOutOfService = 1,

		[System.ComponentModel.Description("The fog signal is inoperative.")]
		[EnumMember(Value = "Fog Signal Out Of Service")] 
		[XmlEnum("2")] 
		FogSignalOutOfService = 2,

		[System.ComponentModel.Description("The audible signal (device activated by e.g. sea state or wind, irrespective of visibility) is operating as advertised.")]
		[EnumMember(Value = "Audible Signal Operating Properly")] 
		[XmlEnum("3")] 
		AudibleSignalOperatingProperly = 3,

		[System.ComponentModel.Description("The fog signal is operating as advertised.")]
		[EnumMember(Value = "Fog Signal Operating Properly")] 
		[XmlEnum("4")] 
		FogSignalOperatingProperly = 4,
	}

	/// <summary>
	/// Adjustments or replacements related to floating AtoNs, such as buoys, which are anchored but can move with water currents.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum floatingAtonChange : int {
		[System.ComponentModel.Description("The buoy is no longer secured to its moorings and is adrift.")]
		[EnumMember(Value = "Buoy Adrift")] 
		[XmlEnum("1")] 
		BuoyAdrift = 1,

		[System.ComponentModel.Description("The buoy has been damaged due to external factors (wind, sea state, collision with a vessel).")]
		[EnumMember(Value = "Buoy Damaged")] 
		[XmlEnum("2")] 
		BuoyDamaged = 2,

		[System.ComponentModel.Description("Colour of the buoy daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).")]
		[EnumMember(Value = "Buoy Daymark Unreliable")] 
		[XmlEnum("3")] 
		BuoyDaymarkUnreliable = 3,

		[System.ComponentModel.Description("The buoy has suffered extensive damage and is not useable.")]
		[EnumMember(Value = "Buoy Destroyed")] 
		[XmlEnum("4")] 
		BuoyDestroyed = 4,

		[System.ComponentModel.Description("No buoy at its advertised/charted position or in the vicinity.")]
		[EnumMember(Value = "Buoy Missing")] 
		[XmlEnum("5")] 
		BuoyMissing = 5,

		[System.ComponentModel.Description("The buoy has been or will be moved intentionally.")]
		[EnumMember(Value = "Buoy Move")] 
		[XmlEnum("6")] 
		BuoyMove = 6,

		[System.ComponentModel.Description("The buoy has been dragged off its advertised position due to wind or current affecting the mooring system.")]
		[EnumMember(Value = "Buoy off Position")] 
		[XmlEnum("7")] 
		BuoyOffPosition = 7,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Buoy re-establishment")] 
		[XmlEnum("8")] 
		BuoyReEstablishment = 8,

		[System.ComponentModel.Description("The buoy has been restored to normal condition.")]
		[EnumMember(Value = "Buoy Restored to Normal")] 
		[XmlEnum("9")] 
		BuoyRestoredToNormal = 9,

		[System.ComponentModel.Description("The topmark of the buoy is damaged due to external factors (wind, sea state, collision with a vessel).")]
		[EnumMember(Value = "Buoy Topmark Damaged")] 
		[XmlEnum("10")] 
		BuoyTopmarkDamaged = 10,

		[System.ComponentModel.Description("The topmark of the buoy is missing.")]
		[EnumMember(Value = "Buoy Topmark Missing")] 
		[XmlEnum("11")] 
		BuoyTopmarkMissing = 11,

		[System.ComponentModel.Description("The buoy has been scheduled for removal from service for a fixed term.")]
		[EnumMember(Value = "Buoy Will Be Withdrawn")] 
		[XmlEnum("12")] 
		BuoyWillBeWithdrawn = 12,

		[System.ComponentModel.Description("The buoy has been removed from service for a fixed term.")]
		[EnumMember(Value = "Buoy Withdrawn")] 
		[XmlEnum("13")] 
		BuoyWithdrawn = 13,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Decommissioned for winter")] 
		[XmlEnum("14")] 
		DecommissionedForWinter = 14,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Lifted for Winter")] 
		[XmlEnum("15")] 
		LiftedForWinter = 15,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Light buoy Light damaged")] 
		[XmlEnum("16")] 
		LightBuoyLightDamaged = 16,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Light buoy Light not synchronized")] 
		[XmlEnum("17")] 
		LightBuoyLightNotSynchronized = 17,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Light buoy Light unlit")] 
		[XmlEnum("18")] 
		LightBuoyLightUnlit = 18,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Light buoy Light unreliable")] 
		[XmlEnum("19")] 
		LightBuoyLightUnreliable = 19,

		[System.ComponentModel.Description("The position or status of Marine Aids to Navigation, over an extensive area, is unreliable due to a natural event (freshet, storm surge, flooding).")]
		[EnumMember(Value = "Marine Aids to Navigation Unreliable")] 
		[XmlEnum("20")] 
		MarineAidsToNavigationUnreliable = 20,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Recommissioned for navigation season")] 
		[XmlEnum("21")] 
		RecommissionedForNavigationSeason = 21,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Replaced by Winter Spar")] 
		[XmlEnum("22")] 
		ReplacedByWinterSpar = 22,

		[System.ComponentModel.Description("The completion of the process to remove summer buoys (and possibly replace some with winter spar buoys).")]
		[EnumMember(Value = "Seasonal Decommissioning Complete")] 
		[XmlEnum("23")] 
		SeasonalDecommissioningComplete = 23,

		[System.ComponentModel.Description("The commencement of the process to remove summer buoys (and possibly replace some with winter spar buoys).")]
		[EnumMember(Value = "Seasonal Decommissioning in Progress")] 
		[XmlEnum("24")] 
		SeasonalDecommissioningInProgress = 24,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Seasonal recommissioning complete")] 
		[XmlEnum("25")] 
		SeasonalRecommissioningComplete = 25,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Seasonal recommissioning in progress")] 
		[XmlEnum("26")] 
		SeasonalRecommissioningInProgress = 26,
	}

	/// <summary>
	/// Modifications or updates to fixed AtoNs, such as lighthouses or beacons, which are permanently positioned.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum fixedAtonChange : int {
		[System.ComponentModel.Description("No beacon at the advertised position.")]
		[EnumMember(Value = "Beacon Missing")] 
		[XmlEnum("1")] 
		BeaconMissing = 1,

		[System.ComponentModel.Description("The beacon has sustained damage due to external factors (wind, sea state, collision with a vessel).")]
		[EnumMember(Value = "Beacon Damaged")] 
		[XmlEnum("2")] 
		BeaconDamaged = 2,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Light beacon Unlit")] 
		[XmlEnum("3")] 
		LightBeaconUnlit = 3,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Light beacon Unreliable")] 
		[XmlEnum("4")] 
		LightBeaconUnreliable = 4,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Light beacon Not synchronized")] 
		[XmlEnum("5")] 
		LightBeaconNotSynchronized = 5,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Light beacon damaged")] 
		[XmlEnum("6")] 
		LightBeaconDamaged = 6,

		[System.ComponentModel.Description("The topmark of the beacon is missing.")]
		[EnumMember(Value = "Beacon Topmark Missing")] 
		[XmlEnum("7")] 
		BeaconTopmarkMissing = 7,

		[System.ComponentModel.Description("The topmark of the beacon is damaged due to external factors (wind, sea state, collision with a vessel).")]
		[EnumMember(Value = "Beacon Topmark Damaged")] 
		[XmlEnum("8")] 
		BeaconTopmarkDamaged = 8,

		[System.ComponentModel.Description("Colour of the beacon daymark is not visible due to damage or fading of colours (out of tolerance with colour recommendations).")]
		[EnumMember(Value = "Beacon Daymark Unreliable")] 
		[XmlEnum("9")] 
		BeaconDaymarkUnreliable = 9,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "Floodlit beacon Unlit")] 
		[XmlEnum("10")] 
		FloodlitBeaconUnlit = 10,

		[System.ComponentModel.Description("The beacon has been restored to normal condition.")]
		[EnumMember(Value = "Beacon Restored To Normal")] 
		[XmlEnum("11")] 
		BeaconRestoredToNormal = 11,
	}

	/// <summary>
	/// The act of swapping an existing AtoN with a new or upgraded unit, either due to maintenance needs or technological improvements.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonReplacement : int {
		[System.ComponentModel.Description("The characteristics of the buoy have been or will be changed.")]
		[EnumMember(Value = "Buoy Change")] 
		[XmlEnum("1")] 
		BuoyChange = 1,

		[System.ComponentModel.Description("The characteristics of the buoy have been or will be temporarily changed.")]
		[EnumMember(Value = "Buoy Temporary Change")] 
		[XmlEnum("2")] 
		BuoyTemporaryChange = 2,

		[System.ComponentModel.Description("The characteristics of the light have been or will be changed.")]
		[EnumMember(Value = "Light Change")] 
		[XmlEnum("3")] 
		LightChange = 3,

		[System.ComponentModel.Description("The characteristics of the light have been or will be temporarily changed.")]
		[EnumMember(Value = "Light Temporary Change")] 
		[XmlEnum("4")] 
		LightTemporaryChange = 4,

		[System.ComponentModel.Description("The characteristics of the sector light have been or will be changed.")]
		[EnumMember(Value = "Sector Light Change")] 
		[XmlEnum("5")] 
		SectorLightChange = 5,

		[System.ComponentModel.Description("The characteristics of the sector light have been or will be temporarily changed.")]
		[EnumMember(Value = "Sector Light Temporary Change")] 
		[XmlEnum("6")] 
		SectorLightTemporaryChange = 6,

		[System.ComponentModel.Description("The characteristics of the beacon have been or will be changed.")]
		[EnumMember(Value = "Beacon Change")] 
		[XmlEnum("7")] 
		BeaconChange = 7,

		[System.ComponentModel.Description("The characteristics of the beacon have been or will be temporarily changed.")]
		[EnumMember(Value = "Beacon Temporary Change")] 
		[XmlEnum("8")] 
		BeaconTemporaryChange = 8,

		[System.ComponentModel.Description("The characteristics of the fog signal have been or will be changed.")]
		[EnumMember(Value = "Fog Signal Change")] 
		[XmlEnum("9")] 
		FogSignalChange = 9,

		[System.ComponentModel.Description("The characteristics of the fog signal have been or will be temporarily changed.")]
		[EnumMember(Value = "Fog Signal Temporary Change")] 
		[XmlEnum("10")] 
		FogSignalTemporaryChange = 10,

		[System.ComponentModel.Description("The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be changed.")]
		[EnumMember(Value = "Audible Signal Change")] 
		[XmlEnum("11")] 
		AudibleSignalChange = 11,

		[System.ComponentModel.Description("The characteristics of the audible signal (device activated by e.g. sea state or wind, irrespective of visibility) have been or will be temporarily changed.")]
		[EnumMember(Value = "Audible Signal Temporary Change")] 
		[XmlEnum("12")] 
		AudibleSignalTemporaryChange = 12,

		[System.ComponentModel.Description("The characteristics of the V-AIS have been or will be changed.")]
		[EnumMember(Value = "V-AIS Change")] 
		[XmlEnum("13")] 
		VAisChange = 13,

		[System.ComponentModel.Description("The characteristics of the V-AIS have been or will be temporarily changed.")]
		[EnumMember(Value = "V-AIS Temporary Change")] 
		[XmlEnum("14")] 
		VAisTemporaryChange = 14,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "RACON signal change")] 
		[XmlEnum("15")] 
		RaconSignalChange = 15,

		[System.ComponentModel.Description("The characteristics of the RACON have been or will be temporarily changed.")]
		[EnumMember(Value = "RACON Temporary Change")] 
		[XmlEnum("16")] 
		RaconTemporaryChange = 16,
	}

	/// <summary>
	/// The process of decommissioning and physically removing an AtoN from its designated location, either temporarily or permanently.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonRemoval : int {
		[System.ComponentModel.Description("Buoy has been or will be permanently removed from service.")]
		[EnumMember(Value = "Buoy Removal")] 
		[XmlEnum("1")] 
		BuoyRemoval = 1,

		[System.ComponentModel.Description("Buoy has been or will be temporarily removed from service.")]
		[EnumMember(Value = "Buoy Temporary Removal")] 
		[XmlEnum("2")] 
		BuoyTemporaryRemoval = 2,

		[System.ComponentModel.Description("Light has been or will be permanently removed from service.")]
		[EnumMember(Value = "Light Removal")] 
		[XmlEnum("3")] 
		LightRemoval = 3,

		[System.ComponentModel.Description("Light has been or will be temporarily removed from service.")]
		[EnumMember(Value = "Light Temporary Removal")] 
		[XmlEnum("4")] 
		LightTemporaryRemoval = 4,

		[System.ComponentModel.Description("Beacon has been or will be permanently removed from service.")]
		[EnumMember(Value = "Beacon Removal")] 
		[XmlEnum("5")] 
		BeaconRemoval = 5,

		[System.ComponentModel.Description("Beacon has been or will be temporarily removed from service.")]
		[EnumMember(Value = "Beacon Temporary Removal")] 
		[XmlEnum("6")] 
		BeaconTemporaryRemoval = 6,

		[System.ComponentModel.Description("Fog signal has been or will be permanently removed from service.")]
		[EnumMember(Value = "Fog Signal Removal")] 
		[XmlEnum("7")] 
		FogSignalRemoval = 7,

		[System.ComponentModel.Description("Fog signal has been or will be temporarily removed from service.")]
		[EnumMember(Value = "Fog Signal Temporary Removal")] 
		[XmlEnum("8")] 
		FogSignalTemporaryRemoval = 8,

		[System.ComponentModel.Description("Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be permanently removed from service.")]
		[EnumMember(Value = "Audible Signal Removal")] 
		[XmlEnum("9")] 
		AudibleSignalRemoval = 9,

		[System.ComponentModel.Description("Audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be temporarily removed from service.")]
		[EnumMember(Value = "Audible Signal Temporary Removal")] 
		[XmlEnum("10")] 
		AudibleSignalTemporaryRemoval = 10,

		[System.ComponentModel.Description("V-AIS has been or will be permanently removed from service.")]
		[EnumMember(Value = "V-AIS Removal")] 
		[XmlEnum("11")] 
		VAisRemoval = 11,

		[System.ComponentModel.Description("V-AIS has been or will be temporarily removed from service.")]
		[EnumMember(Value = "V-AIS Temporary Removal")] 
		[XmlEnum("12")] 
		VAisTemporaryRemoval = 12,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "RACON signal removal")] 
		[XmlEnum("13")] 
		RaconSignalRemoval = 13,

		[System.ComponentModel.Description("RACON has been or will be temporarily removed from service.")]
		[EnumMember(Value = "RACON Temporary Removal")] 
		[XmlEnum("14")] 
		RaconTemporaryRemoval = 14,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "DGPS removal")] 
		[XmlEnum("15")] 
		DgpsRemoval = 15,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "DGPS temporary removal")] 
		[XmlEnum("16")] 
		DgpsTemporaryRemoval = 16,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "EGNOS removal")] 
		[XmlEnum("17")] 
		EgnosRemoval = 17,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "EGNOS temporary removal")] 
		[XmlEnum("18")] 
		EgnosTemporaryRemoval = 18,

		[System.ComponentModel.Description("LORAN C station has been or will be permanently removed from service.")]
		[EnumMember(Value = "LORAN C Station Removal")] 
		[XmlEnum("19")] 
		LoranCStationRemoval = 19,

		[System.ComponentModel.Description("LORAN C station has been or will be temporarily removed from service.")]
		[EnumMember(Value = "LORAN C Station Temporary Removal")] 
		[XmlEnum("20")] 
		LoranCStationTemporaryRemoval = 20,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "eLORAN removal")] 
		[XmlEnum("21")] 
		EloranRemoval = 21,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "eLORAN temporary removal")] 
		[XmlEnum("22")] 
		EloranTemporaryRemoval = 22,

		[System.ComponentModel.Description("Chayka station has been or will be permanently removed from service.")]
		[EnumMember(Value = "Chayka Station Removal")] 
		[XmlEnum("23")] 
		ChaykaStationRemoval = 23,

		[System.ComponentModel.Description("Chayka station has been or will be temporarily removed from service.")]
		[EnumMember(Value = "Chayka Station Temporary Removal")] 
		[XmlEnum("24")] 
		ChaykaStationTemporaryRemoval = 24,

		[System.ComponentModel.Description("The e-Chayka station has been or will be permanently removed from service.")]
		[EnumMember(Value = "E-Chayka Station Removal")] 
		[XmlEnum("25")] 
		EChaykaStationRemoval = 25,

		[System.ComponentModel.Description("The e-Chayka station has been or will be temporarily removed from service")]
		[EnumMember(Value = "E-Chayka Station Temporary Removal")] 
		[XmlEnum("26")] 
		EChaykaStationTemporaryRemoval = 26,
	}

	/// <summary>
	/// The process of deploying and activating a new Aid to Navigation (AtoN), ensuring that it is properly installed and operational.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonCommissioning : int {
		[System.ComponentModel.Description("A new buoy has been or will be established.")]
		[EnumMember(Value = "Buoy Establishment")] 
		[XmlEnum("1")] 
		BuoyEstablishment = 1,

		[System.ComponentModel.Description("A new light has been or will be established.")]
		[EnumMember(Value = "Light Establishment")] 
		[XmlEnum("2")] 
		LightEstablishment = 2,

		[System.ComponentModel.Description("A new beacon has been or will be established.")]
		[EnumMember(Value = "Beacon Establishment")] 
		[XmlEnum("3")] 
		BeaconEstablishment = 3,

		[System.ComponentModel.Description("A new audible signal (device activated by e.g. sea state or wind, irrespective of visibility) has been or will be established.")]
		[EnumMember(Value = "Audible Signal Establishment")] 
		[XmlEnum("4")] 
		AudibleSignalEstablishment = 4,

		[System.ComponentModel.Description("A new fog signal has been or will be established.")]
		[EnumMember(Value = "Fog Signal Establishment")] 
		[XmlEnum("5")] 
		FogSignalEstablishment = 5,

		[System.ComponentModel.Description("A new AIS site has been or will be established.")]
		[EnumMember(Value = "AIS Transmitter Establishment")] 
		[XmlEnum("6")] 
		AisTransmitterEstablishment = 6,

		[System.ComponentModel.Description("A new V-AIS has been or will be established.")]
		[EnumMember(Value = "V-AIS Establishment")] 
		[XmlEnum("7")] 
		VAisEstablishment = 7,

		[System.ComponentModel.Description("A new RACON has been or will be established.")]
		[EnumMember(Value = "RACON Establishment")] 
		[XmlEnum("8")] 
		RaconEstablishment = 8,

		[System.ComponentModel.Description("A new DGPS station has been or will be established.")]
		[EnumMember(Value = "DGPS Station Establishment")] 
		[XmlEnum("9")] 
		DgpsStationEstablishment = 9,

		[System.ComponentModel.Description("A new eLORAN station has been or will be established.")]
		[EnumMember(Value = "ELORAN Station Establishment")] 
		[XmlEnum("10")] 
		EloranStationEstablishment = 10,

		[System.ComponentModel.Description("A new DGLONASS station has been or will be established.")]
		[EnumMember(Value = "DGLONASS Station Establishment")] 
		[XmlEnum("11")] 
		DglonassStationEstablishment = 11,

		[System.ComponentModel.Description("A new e-Chayka station has been or will be established.")]
		[EnumMember(Value = "E-Chayka Station Establishment")] 
		[XmlEnum("12")] 
		EChaykaStationEstablishment = 12,

		[System.ComponentModel.Description(".")]
		[EnumMember(Value = "EGNOS establishment")] 
		[XmlEnum("13")] 
		EgnosEstablishment = 13,
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
	/// Different categories or kinds of modifications that can be made to data, positions, or objects. For example, changes may involve updates to position, orientation, or attributes of an object.
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum ChangeTypes : int {
		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "Advanced notice of changes ")] 
		[XmlEnum("1")] 
		AdvancedNoticeOfChanges = 1,

		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "Discrepancy ")] 
		[XmlEnum("2")] 
		Discrepancy = 2,

		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "Proposed changes ")] 
		[XmlEnum("3")] 
		ProposedChanges = 3,

		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "Temporary changes ")] 
		[XmlEnum("4")] 
		TemporaryChanges = 4,
	}

	/// <summary>
	/// The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colour : int {
		[System.ComponentModel.Description("The achromatic object colour of greatest lightness characteristically perceived to belong to objects that reflect diffusely nearly all incident energy throughout the visible spectrum.")]
		[EnumMember(Value = "White")] 
		[XmlEnum("1")] 
		White = 1,

		[System.ComponentModel.Description("The achromatic color of least lightness characteristically perceived to belong to objects that neither reflect nor transmit light.")]
		[EnumMember(Value = "Black")] 
		[XmlEnum("2")] 
		Black = 2,

		[System.ComponentModel.Description("A color whose hue resembles that of blood or of the ruby or is that of the long-wave extreme of the visible spectrum.")]
		[EnumMember(Value = "Red")] 
		[XmlEnum("3")] 
		Red = 3,

		[System.ComponentModel.Description("Of the color green.")]
		[EnumMember(Value = "Green")] 
		[XmlEnum("4")] 
		Green = 4,

		[System.ComponentModel.Description("A color whose hue is that of the clear sky or that of the portion of the color spectrum lying between green and violet.")]
		[EnumMember(Value = "Blue")] 
		[XmlEnum("5")] 
		Blue = 5,

		[System.ComponentModel.Description("A color whose hue resembles that of ripe lemons or sunflowers or is that of the portion of the spectrum lying between green and orange.")]
		[EnumMember(Value = "Yellow")] 
		[XmlEnum("6")] 
		Yellow = 6,

		[System.ComponentModel.Description("Of the color grey.")]
		[EnumMember(Value = "Grey")] 
		[XmlEnum("7")] 
		Grey = 7,

		[System.ComponentModel.Description("Any of a group of colors between red and yellow in hue, of medium to low lightness, and of moderate to low saturation.")]
		[EnumMember(Value = "Brown")] 
		[XmlEnum("8")] 
		Brown = 8,

		[System.ComponentModel.Description("A variable color averaging a dark orange yellow.")]
		[EnumMember(Value = "Amber")] 
		[XmlEnum("9")] 
		Amber = 9,

		[System.ComponentModel.Description("Any of a group of colors of reddish-blue hue, low lightness, and medium saturation.")]
		[EnumMember(Value = "Violet")] 
		[XmlEnum("10")] 
		Violet = 10,

		[System.ComponentModel.Description("Any of a group of colors that are between red and yellow in hue.")]
		[EnumMember(Value = "Orange")] 
		[XmlEnum("11")] 
		Orange = 11,

		[System.ComponentModel.Description("A deep purplish red.")]
		[EnumMember(Value = "Magenta")] 
		[XmlEnum("12")] 
		Magenta = 12,

		[System.ComponentModel.Description("Any of a group of colors bluish red to red in hue, of medium to high lightness, and of low to moderate saturation.")]
		[EnumMember(Value = "Pink")] 
		[XmlEnum("13")] 
		Pink = 13,
	}

	/// <summary>
	/// A regular repeated design containing more than one colour.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colourPattern : int {
		[System.ComponentModel.Description("Straight bands or stripes of differing colours oriented horizontally.")]
		[EnumMember(Value = "Horizontal Stripes")] 
		[XmlEnum("1")] 
		HorizontalStripes = 1,

		[System.ComponentModel.Description("Straight bands or stripes of differing colours oriented vertically.")]
		[EnumMember(Value = "Vertical Stripes")] 
		[XmlEnum("2")] 
		VerticalStripes = 2,

		[System.ComponentModel.Description("Straight bands or stripes of differing colours oriented diagonally (that is, not horizontally or vertically).")]
		[EnumMember(Value = "Diagonal Stripes")] 
		[XmlEnum("3")] 
		DiagonalStripes = 3,

		[System.ComponentModel.Description("Often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.")]
		[EnumMember(Value = "Squared")] 
		[XmlEnum("4")] 
		Squared = 4,

		[System.ComponentModel.Description("Straight bands or stripes of differing colours oriented in an unknown direction.")]
		[EnumMember(Value = "Stripes (Direction Unknown)")] 
		[XmlEnum("5")] 
		StripesDirectionUnknown = 5,

		[System.ComponentModel.Description("A band or stripe of colour which is displayed around the outer edge of the object, which may also form a border to an inner pattern or plain colour.")]
		[EnumMember(Value = "Border Stripe")] 
		[XmlEnum("6")] 
		BorderStripe = 6,

		[System.ComponentModel.Description("One solid colour of uniform coverage.")]
		[EnumMember(Value = "Single Colour")] 
		[XmlEnum("7")] 
		SingleColour = 7,

		[System.ComponentModel.Description("A four-sided shape that is made up of two pairs of parallel lines and that has four right angles, on a different coloured background.")]
		[EnumMember(Value = "Rectangle")] 
		[XmlEnum("8")] 
		Rectangle = 8,

		[System.ComponentModel.Description("A shape that is made up of three lines and three angles, on a different coloured background.")]
		[EnumMember(Value = "Triangle")] 
		[XmlEnum("9")] 
		Triangle = 9,
	}

	/// <summary>
	/// The system of navigational buoyage a region complies with.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum marksNavigationalSystemOf : int {
		[System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA A system.")]
		[EnumMember(Value = "IALA A")] 
		[XmlEnum("1")] 
		IalaA = 1,

		[System.ComponentModel.Description("Navigational aids conform to the International Association of Lighthouse Authorities - IALA B system.")]
		[EnumMember(Value = "IALA B")] 
		[XmlEnum("2")] 
		IalaB = 2,

		[System.ComponentModel.Description("Navigational aids do not conform to any defined system.")]
		[EnumMember(Value = "No System")] 
		[XmlEnum("9")] 
		NoSystem = 9,

		[System.ComponentModel.Description("Navigational aids conform to a defined system other than International Association of Lighthouse Authorities - IALA.")]
		[EnumMember(Value = "Other System")] 
		[XmlEnum("10")] 
		OtherSystem = 10,

		[System.ComponentModel.Description("Navigational aids as required in international, national or regional regulations that contain the same navigational aids as the European Code for Inland Waterways of UNECE, or if there is no regulation for a waterway, navigational aids as recommended in the European Code for Inland Waterways of UNECE")]
		[EnumMember(Value = "Main European Inland Waterway Marking System")] 
		[XmlEnum("11")] 
		MainEuropeanInlandWaterwayMarkingSystem = 11,

		[System.ComponentModel.Description("Navigational aids conform to the Russian inland waterway regulations.")]
		[EnumMember(Value = "Russian Inland Waterway Regulations")] 
		[XmlEnum("12")] 
		RussianInlandWaterwayRegulations = 12,

		[System.ComponentModel.Description("Navigational aids conform to the Brazilian national inland waterway regulation")]
		[EnumMember(Value = "Brazilian National Inland Waterway Regulation")] 
		[XmlEnum("13")] 
		BrazilianNationalInlandWaterwayRegulation = 13,

		[System.ComponentModel.Description("Navigational aids conform to the Brazilian complementary aids on the Paraguay-Parana waterway.")]
		[EnumMember(Value = "Paraguay-Parana Waterway - Brazilian Complementary Aids")] 
		[XmlEnum("15")] 
		ParaguayParanaWaterwayBrazilianComplementaryAids = 15,
	}

	/// <summary>
	/// The building's primary construction material.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfConstruction : int {
		[System.ComponentModel.Description("Constructed of stones or bricks, usually quarried, shaped, and mortared.")]
		[EnumMember(Value = "Masonry")] 
		[XmlEnum("1")] 
		Masonry = 1,

		[System.ComponentModel.Description("Constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.")]
		[EnumMember(Value = "Concreted")] 
		[XmlEnum("2")] 
		Concreted = 2,

		[System.ComponentModel.Description("Constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.")]
		[EnumMember(Value = "Loose Boulders")] 
		[XmlEnum("3")] 
		LooseBoulders = 3,

		[System.ComponentModel.Description("Constructed with a surface of hard material, usually a term applied to roads surfaced with asphalt or concrete.")]
		[EnumMember(Value = "Hard Surfaced")] 
		[XmlEnum("4")] 
		HardSurfaced = 4,

		[System.ComponentModel.Description("Constructed with no extra protection, usually a term applied to roads not surfaced with a hard material.")]
		[EnumMember(Value = "Unsurfaced")] 
		[XmlEnum("5")] 
		Unsurfaced = 5,

		[System.ComponentModel.Description("Constructed from wood.")]
		[EnumMember(Value = "Wooden")] 
		[XmlEnum("6")] 
		Wooden = 6,

		[System.ComponentModel.Description("Constructed from metal.")]
		[EnumMember(Value = "Metal")] 
		[XmlEnum("7")] 
		Metal = 7,

		[System.ComponentModel.Description("Constructed from a plastic material strengthened with fibres of glass.")]
		[EnumMember(Value = "Glass Reinforced Plastic")] 
		[XmlEnum("8")] 
		GlassReinforcedPlastic = 8,

		[System.ComponentModel.Description("The application of paint to some other construction or natural feature.")]
		[EnumMember(Value = "Painted")] 
		[XmlEnum("9")] 
		Painted = 9,

		[System.ComponentModel.Description("Constructed from a lattice framework of, often diagonal, intersecting struts.")]
		[EnumMember(Value = "Framework")] 
		[XmlEnum("10")] 
		Framework = 10,

		[System.ComponentModel.Description("A structure of crossed wooden or metal strips usually arranged to form a diagonal pattern of open spaces between the strips.")]
		[EnumMember(Value = "Latticed")] 
		[XmlEnum("11")] 
		Latticed = 11,

		[System.ComponentModel.Description("[1] Any artificial or natural substance having similar properties and composition, as fused borax, obsidian, or the like.   [2] Something made of such a substance, as a windowpane.")]
		[EnumMember(Value = "Glass")] 
		[XmlEnum("12")] 
		Glass = 12,

		[System.ComponentModel.Description("Constructed from fiberglass.")]
		[EnumMember(Value = "Fiberglass")] 
		[XmlEnum("13")] 
		Fiberglass = 13,

		[System.ComponentModel.Description("Constructed from plastic.")]
		[EnumMember(Value = "Plastic")] 
		[XmlEnum("14")] 
		Plastic = 14,
	}

	/// <summary>
	/// The principal shape and/or design of a buoy.
	/// </summary>
	/// <remarks>
	/// The principal shapes are those recommended in the International Association of Lighthouse Authorities - IALA System.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buoyShape : int {
		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has approximately the shape or the appearance of a pointed cone with the point upwards.")]
		[EnumMember(Value = "Conical")] 
		[XmlEnum("1")] 
		Conical = 1,

		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a cylinder, or a truncated cone that approximates to a cylinder, with a flat end uppermost.")]
		[EnumMember(Value = "Can")] 
		[XmlEnum("2")] 
		Can = 2,

		[System.ComponentModel.Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
		[EnumMember(Value = "Spherical")] 
		[XmlEnum("3")] 
		Spherical = 3,

		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure is a narrow vertical structure, pillar or lattice tower.")]
		[EnumMember(Value = "Pillar")] 
		[XmlEnum("4")] 
		Pillar = 4,

		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a pole, or of a very long cylinder, floating upright.")]
		[EnumMember(Value = "Spar")] 
		[XmlEnum("5")] 
		Spar = 5,

		[System.ComponentModel.Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a barrel or cylinder floating horizontally.")]
		[EnumMember(Value = "Barrel")] 
		[XmlEnum("6")] 
		Barrel = 6,

		[System.ComponentModel.Description("A very large buoy designed to carry a signal light of high luminous intensity at a high elevation.")]
		[EnumMember(Value = "Superbuoy")] 
		[XmlEnum("7")] 
		Superbuoy = 7,

		[System.ComponentModel.Description("A specially constructed shuttle shaped buoy which is used in ice conditions.")]
		[EnumMember(Value = "Ice Buoy")] 
		[XmlEnum("8")] 
		IceBuoy = 8,
	}

	/// <summary>
	/// Classification of pile, driven into the earth as a foundation or support for a structure.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPile : int {
		[System.ComponentModel.Description("An elongated wood or metal pole embedded in the seabed to serve as a marker or support.")]
		[EnumMember(Value = "Stake")] 
		[XmlEnum("1")] 
		Stake = 1,

		[System.ComponentModel.Description("A vertical piece of timber, metal or concrete forced into the earth or sea bed.")]
		[EnumMember(Value = "Post")] 
		[XmlEnum("3")] 
		Post = 3,

		[System.ComponentModel.Description("A single structure comprising 3 or more piles held together (sections of heavy timber, steel or concrete), and forced into the earth or sea bed.")]
		[EnumMember(Value = "Tripodal")] 
		[XmlEnum("4")] 
		Tripodal = 4,

		[System.ComponentModel.Description("A number of piles, usually in a straight line, and usually connected or bolted together.")]
		[EnumMember(Value = "Piling")] 
		[XmlEnum("5")] 
		Piling = 5,

		[System.ComponentModel.Description("A number of piles, usually in a straight line, but not connected by structural members.")]
		[EnumMember(Value = "Area of Piles")] 
		[XmlEnum("6")] 
		AreaOfPiles = 6,

		[System.ComponentModel.Description("A vertical hollow cylinder of metal, wood, or other material forced into the earth or seabed.")]
		[EnumMember(Value = "Pipe")] 
		[XmlEnum("7")] 
		Pipe = 7,

		[System.ComponentModel.Description("A post where to which something (such as a craft) can be moored.")]
		[EnumMember(Value = "Mooring Post")] 
		[XmlEnum("8")] 
		MooringPost = 8,
	}

	/// <summary>
	/// The extent to which a feature, either natural or artificial, is visible from seaward.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum visualProminence : int {
		[System.ComponentModel.Description("Term applied to a feature either natural or artificial which is distinctly and notably visible from seaward.")]
		[EnumMember(Value = "Visually Conspicuous")] 
		[XmlEnum("1")] 
		VisuallyConspicuous = 1,

		[System.ComponentModel.Description("An object that may be visible from seaward, but cannot be used as a fixing mark and is not conspicuous.")]
		[EnumMember(Value = "Not Visually Conspicuous")] 
		[XmlEnum("2")] 
		NotVisuallyConspicuous = 2,

		[System.ComponentModel.Description("Objects which are easily identifiable, but do not justify being classed as conspicuous.")]
		[EnumMember(Value = "Prominent")] 
		[XmlEnum("3")] 
		Prominent = 3,
	}

	/// <summary>
	/// The specific shape of the building.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buildingShape : int {
		[System.ComponentModel.Description("A building having many storeys.")]
		[EnumMember(Value = "High-Rise Building")] 
		[XmlEnum("5")] 
		HighRiseBuilding = 5,

		[System.ComponentModel.Description("A polyhedron of which one face is a polygon of any number of sides, and the other faces are triangles with a common vertex.")]
		[EnumMember(Value = "Pyramid")] 
		[XmlEnum("6")] 
		Pyramid = 6,

		[System.ComponentModel.Description("Shaped like a cylinder, which is a solid geometrical figure generated by straight lines fixed in direction and describing with one of its points a closed curve, especially a circle.")]
		[EnumMember(Value = "Cylindrical")] 
		[XmlEnum("7")] 
		Cylindrical = 7,

		[System.ComponentModel.Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
		[EnumMember(Value = "Spherical")] 
		[XmlEnum("8")] 
		Spherical = 8,

		[System.ComponentModel.Description("A shape the sides of which are six equal squares; a regular hexahedron.")]
		[EnumMember(Value = "Cubic")] 
		[XmlEnum("9")] 
		Cubic = 9,
	}

	/// <summary>
	/// Classification based on the product for which a silo or tank is used.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSiloTank : int {
		[System.ComponentModel.Description("A large storage structure used for storing loose materials.")]
		[EnumMember(Value = "Silo in General")] 
		[XmlEnum("1")] 
		SiloInGeneral = 1,

		[System.ComponentModel.Description("A fixed structure for storing liquids.")]
		[EnumMember(Value = "Tank in General")] 
		[XmlEnum("2")] 
		TankInGeneral = 2,

		[System.ComponentModel.Description("A storage building for grain. Usually a tall frame, metal or concrete structure with an especially compartmented interior.")]
		[EnumMember(Value = "Grain Elevator")] 
		[XmlEnum("3")] 
		GrainElevator = 3,

		[System.ComponentModel.Description("A tower supporting an elevated storage tank of water.")]
		[EnumMember(Value = "Water Tower")] 
		[XmlEnum("4")] 
		WaterTower = 4,
	}

	/// <summary>
	/// The four quadrants (north, east, south and west) are bounded by the true bearings NW-NE, NE-SE, SE-SW and SW-NW taken from the point of interest. A cardinal mark is named after the quadrant in which it is placed. The name of the cardinal mark indicates that it should be passed to the named side of the mark.
	/// </summary>
	/// <remarks>
	/// Cardinal marks are used in conjunction with the compass to indicate where a mariner will find safe navigable water.Cardinal marks do not have a distinctive shape but are normally pillar or spar. They are always painted in yellow and black horizontal bands and their distinctive double cone top-marks are always black. (Note that such top-marks are encoded as separate TOPMAR objects). Cardinal marks may also have a special system of flashing white lights and if such lights are fitted they are encoded as separate LIGHTS objects.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCardinalMark : int {
		[System.ComponentModel.Description("Quadrant bounded by the true bearing NW-NE taken from the point of interest; it should be passed to the north side of the mark.")]
		[EnumMember(Value = "North Cardinal Mark")] 
		[XmlEnum("1")] 
		NorthCardinalMark = 1,

		[System.ComponentModel.Description("Quadrant bounded by the true bearing NE-SE taken from the point of interest. It should be passed to the east side of the mark.")]
		[EnumMember(Value = "East Cardinal Mark")] 
		[XmlEnum("2")] 
		EastCardinalMark = 2,

		[System.ComponentModel.Description("Quadrant bounded by the true bearing SE-SW taken from the point of interest; it should be passed to the south side of the mark.")]
		[EnumMember(Value = "South Cardinal Mark")] 
		[XmlEnum("3")] 
		SouthCardinalMark = 3,

		[System.ComponentModel.Description("Quadrant bounded by the true bearing SW-NW taken from the point of interest; it should be passed to the west side of the mark.")]
		[EnumMember(Value = "West Cardinal Mark")] 
		[XmlEnum("4")] 
		WestCardinalMark = 4,
	}

	/// <summary>
	/// Classification of fixed installation buoy.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfInstallationBuoy : int {
		[System.ComponentModel.Description("Incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.")]
		[EnumMember(Value = "Catenary Anchor Leg Mooring")] 
		[XmlEnum("1")] 
		CatenaryAnchorLegMooring = 1,

		[System.ComponentModel.Description("A large mooring buoy used by tankers to load and unload in port approaches or in offshore oil and gas fields.")]
		[EnumMember(Value = "Single Buoy Mooring")] 
		[XmlEnum("2")] 
		SingleBuoyMooring = 2,
	}

	/// <summary>
	/// Classification of lateral marks in the IALA Buoyage System.
	/// </summary>
	/// <remarks>
	/// There are two international buoyage regions, A and B, between which lateral marks differ. When top-marks, retro reflectors and/or lights are fitted to these marks, they are encoded as separate features.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLateralMark : int {
		[System.ComponentModel.Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".")]
		[EnumMember(Value = "Port-Hand Lateral Mark")] 
		[XmlEnum("1")] 
		PortHandLateralMark = 1,

		[System.ComponentModel.Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".")]
		[EnumMember(Value = "Starboard-Hand Lateral Mark")] 
		[XmlEnum("2")] 
		StarboardHandLateralMark = 2,

		[System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Starboard Lateral Mark")] 
		[XmlEnum("3")] 
		PreferredChannelToStarboardLateralMark = 3,

		[System.ComponentModel.Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Port Lateral Mark")] 
		[XmlEnum("4")] 
		PreferredChannelToPortLateralMark = 4,

		[System.ComponentModel.Description("Indicates the right-hand side of the inland waterway.")]
		[EnumMember(Value = "Right-Hand Side of the Waterway")] 
		[XmlEnum("5")] 
		RightHandSideOfTheWaterway = 5,

		[System.ComponentModel.Description("Indicates the left-hand side of the inland waterway.")]
		[EnumMember(Value = "Left-Hand Side of the Waterway")] 
		[XmlEnum("6")] 
		LeftHandSideOfTheWaterway = 6,

		[System.ComponentModel.Description("Indicates the right-hand side of a channel of an inland waterway.")]
		[EnumMember(Value = "Right-Hand Side of the Channel")] 
		[XmlEnum("7")] 
		RightHandSideOfTheChannel = 7,

		[System.ComponentModel.Description("Indicates the left-hand side of a channel of an inland waterway.")]
		[EnumMember(Value = "Left-Hand Side of the Channel")] 
		[XmlEnum("8")] 
		LeftHandSideOfTheChannel = 8,

		[System.ComponentModel.Description("Indicates a bifurcation of the inland waterway.")]
		[EnumMember(Value = "Bifurcation of the Waterway")] 
		[XmlEnum("9")] 
		BifurcationOfTheWaterway = 9,

		[System.ComponentModel.Description("Indicates a bifurcation of a channel of an inland waterway.")]
		[EnumMember(Value = "Bifurcation of the Channel")] 
		[XmlEnum("10")] 
		BifurcationOfTheChannel = 10,

		[System.ComponentModel.Description("Indicates that the channel is near the right bank.")]
		[EnumMember(Value = "Channel Near the Right Bank")] 
		[XmlEnum("11")] 
		ChannelNearTheRightBank = 11,

		[System.ComponentModel.Description("Indicates that the channel is near the left bank.")]
		[EnumMember(Value = "Channel Near the Left Bank")] 
		[XmlEnum("12")] 
		ChannelNearTheLeftBank = 12,

		[System.ComponentModel.Description("Indicates that the channel crosses from the left to the right bank.")]
		[EnumMember(Value = "Channel Cross-Over to the Right Bank")] 
		[XmlEnum("13")] 
		ChannelCrossOverToTheRightBank = 13,

		[System.ComponentModel.Description("Indicates that the channel crosses from the right to the left bank.")]
		[EnumMember(Value = "Channel Cross-Over to the Left Bank")] 
		[XmlEnum("14")] 
		ChannelCrossOverToTheLeftBank = 14,

		[System.ComponentModel.Description("Indicates a danger point or obstacles at the right-hand side.")]
		[EnumMember(Value = "Danger Point or Obstacles at the Right-Hand Side")] 
		[XmlEnum("15")] 
		DangerPointOrObstaclesAtTheRightHandSide = 15,

		[System.ComponentModel.Description("Indicates a danger point or obstacles at the left-hand side.")]
		[EnumMember(Value = "Danger Point or Obstacles at the Left-Hand Side")] 
		[XmlEnum("16")] 
		DangerPointOrObstaclesAtTheLeftHandSide = 16,

		[System.ComponentModel.Description("Indicates a turn off at the right-hand side.")]
		[EnumMember(Value = "Turn Off at the Right-Hand Side")] 
		[XmlEnum("17")] 
		TurnOffAtTheRightHandSide = 17,

		[System.ComponentModel.Description("Indicates a turn off at the left-hand side.")]
		[EnumMember(Value = "Turn Off at the Left-Hand Side")] 
		[XmlEnum("18")] 
		TurnOffAtTheLeftHandSide = 18,

		[System.ComponentModel.Description("Indicates a junction at the right-hand side.")]
		[EnumMember(Value = "Junction at the Right-Hand Side")] 
		[XmlEnum("19")] 
		JunctionAtTheRightHandSide = 19,

		[System.ComponentModel.Description("Indicates a junction at the left-hand side.")]
		[EnumMember(Value = "Junction at the Left-Hand Side")] 
		[XmlEnum("20")] 
		JunctionAtTheLeftHandSide = 20,

		[System.ComponentModel.Description("Indicates a harbour entry at the right-hand side.")]
		[EnumMember(Value = "Harbour Entry at the Right-Hand Side")] 
		[XmlEnum("21")] 
		HarbourEntryAtTheRightHandSide = 21,

		[System.ComponentModel.Description("Indicates a harbour entry at the left-hand side.")]
		[EnumMember(Value = "Harbour Entry at the Left-Hand Side")] 
		[XmlEnum("22")] 
		HarbourEntryAtTheLeftHandSide = 22,

		[System.ComponentModel.Description("Indicates a bridge pier in an inland waterway.")]
		[EnumMember(Value = "Bridge Pier Mark")] 
		[XmlEnum("23")] 
		BridgePierMark = 23,

		[System.ComponentModel.Description("Indicates the right bank of the entry from a lake or a lake-like expansion to a section of the waterway which is narrower.")]
		[EnumMember(Value = "Entry From a Lake to a Narrower Waterway, Right Bank")] 
		[XmlEnum("24")] 
		EntryFromALakeToANarrowerWaterwayRightBank = 24,

		[System.ComponentModel.Description("Indicates the left bank of the entry from a lake or a lake-like expansion to a section of the waterway which is narrower.")]
		[EnumMember(Value = "Entry From a Lake to a Narrower Waterway, Left Bank")] 
		[XmlEnum("25")] 
		EntryFromALakeToANarrowerWaterwayLeftBank = 25,

		[System.ComponentModel.Description("Change bank.")]
		[EnumMember(Value = "Change Bank")] 
		[XmlEnum("26")] 
		ChangeBank = 26,

		[System.ComponentModel.Description("Continue along bank.")]
		[EnumMember(Value = "Continue Along Bank")] 
		[XmlEnum("27")] 
		ContinueAlongBank = 27,
	}

	/// <summary>
	/// Classification of an offshore raised structure.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfOffshorePlatform : int {
		[System.ComponentModel.Description("A temporary mobile structure, either fixed or floating, used in the exploration stages of oil and gas fields.")]
		[EnumMember(Value = "Oil Rig")] 
		[XmlEnum("1")] 
		OilRig = 1,

		[System.ComponentModel.Description("A term used to indicate a permanent offshore structure equipped to control the flow of oil or gas. It does not include entirely submarine structures.")]
		[EnumMember(Value = "Production Platform")] 
		[XmlEnum("2")] 
		ProductionPlatform = 2,

		[System.ComponentModel.Description("A platform from which one's surroundings or events can be observed, noted or recorded such as for scientific study.")]
		[EnumMember(Value = "Observation/Research Platform")] 
		[XmlEnum("3")] 
		ObservationResearchPlatform = 3,

		[System.ComponentModel.Description("A metal lattice tower, buoyant at one end and attached at the other by a universal joint to a concrete filled base on the sea bed. The platform may be fitted with a helicopter platform, emergency accommodation and hawser/hose retrieval.")]
		[EnumMember(Value = "Articulated Loading Platform")] 
		[XmlEnum("4")] 
		ArticulatedLoadingPlatform = 4,

		[System.ComponentModel.Description("A rigid frame or tube with a buoyancy device at its upper end , secured at its lower end to a universal joint on a large steel or concrete base resting on the sea bed, and at its upper end to a mooring buoy by a chain or wire.")]
		[EnumMember(Value = "Single Anchor Leg Mooring")] 
		[XmlEnum("5")] 
		SingleAnchorLegMooring = 5,

		[System.ComponentModel.Description("A platform secured to the sea bed and surmounted by a turntable to which ships moor.")]
		[EnumMember(Value = "Mooring Tower")] 
		[XmlEnum("6")] 
		MooringTower = 6,

		[System.ComponentModel.Description("A man-made structure usually built for the exploration or exploitation of marine resources, marine scientific research, tidal observations, etc.")]
		[EnumMember(Value = "Artificial Island")] 
		[XmlEnum("7")] 
		ArtificialIsland = 7,

		[System.ComponentModel.Description("An offshore oil/gas facility consisting of a moored tanker/barge by which the product is extracted, stored and exported.")]
		[EnumMember(Value = "Floating Production, Storage and Off-Loading Vessel")] 
		[XmlEnum("8")] 
		FloatingProductionStorageAndOffLoadingVessel = 8,

		[System.ComponentModel.Description("A platform used primarily for eating, sleeping and recreation purposes.")]
		[EnumMember(Value = "Accommodation Platform")] 
		[XmlEnum("9")] 
		AccommodationPlatform = 9,

		[System.ComponentModel.Description("A floating structure with control room, power and storage facilities, attached to the sea bed by a flexible pipeline and cables.")]
		[EnumMember(Value = "Navigation, Communication and Control Buoy")] 
		[XmlEnum("10")] 
		NavigationCommunicationAndControlBuoy = 10,

		[System.ComponentModel.Description("A floating structure, anchored to the seabed, for storing oil.")]
		[EnumMember(Value = "Floating Oil Tank")] 
		[XmlEnum("11")] 
		FloatingOilTank = 11,
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

		[System.ComponentModel.Description("A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.")]
		[EnumMember(Value = "Ruined")] 
		[XmlEnum("2")] 
		Ruined = 2,

		[System.ComponentModel.Description("An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.")]
		[EnumMember(Value = "Under Reclamation")] 
		[XmlEnum("3")] 
		UnderReclamation = 3,

		[System.ComponentModel.Description("A windmill or wind turbine from which the vanes or turbine blades are missing.")]
		[EnumMember(Value = "Wingless")] 
		[XmlEnum("4")] 
		Wingless = 4,

		[System.ComponentModel.Description("Detailed planning has been completed but construction has not been initiated.")]
		[EnumMember(Value = "Planned Construction")] 
		[XmlEnum("5")] 
		PlannedConstruction = 5,
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
	/// The reliability of the value of a sounding.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfVerticalMeasurement : int {
		[System.ComponentModel.Description("The depth from the chart datum to the seabed (or to the top of a drying feature) is known.")]
		[EnumMember(Value = "Depth Known")] 
		[XmlEnum("1")] 
		DepthKnown = 1,

		[System.ComponentModel.Description("The depth from chart datum to the seabed, or the shoalest depth of the feature is unknown.")]
		[EnumMember(Value = "Depth or Least Depth Unknown")] 
		[XmlEnum("2")] 
		DepthOrLeastDepthUnknown = 2,

		[System.ComponentModel.Description("A depth that may be less than indicated.")]
		[EnumMember(Value = "Doubtful Sounding")] 
		[XmlEnum("3")] 
		DoubtfulSounding = 3,

		[System.ComponentModel.Description("A depth that is considered to be an unreliable value.")]
		[EnumMember(Value = "Unreliable Sounding")] 
		[XmlEnum("4")] 
		UnreliableSounding = 4,

		[System.ComponentModel.Description("Upon investigation the bottom was not found at this depth.")]
		[EnumMember(Value = "No Bottom Found at Value Shown")] 
		[XmlEnum("5")] 
		NoBottomFoundAtValueShown = 5,

		[System.ComponentModel.Description("The shoalest depth over a feature is of known value.")]
		[EnumMember(Value = "Least Depth Known")] 
		[XmlEnum("6")] 
		LeastDepthKnown = 6,

		[System.ComponentModel.Description("The least depth over a feature is unknown, but there is considered to be safe clearance at this depth.")]
		[EnumMember(Value = "Least Depth Unknown, Safe Clearance at Value Shown")] 
		[XmlEnum("7")] 
		LeastDepthUnknownSafeClearanceAtValueShown = 7,

		[System.ComponentModel.Description("Depth value obtained from a report, but not fully surveyed.")]
		[EnumMember(Value = "Value Reported (Not Surveyed)")] 
		[XmlEnum("8")] 
		ValueReportedNotSurveyed = 8,

		[System.ComponentModel.Description("Depth value obtained from a report, which it has not been possible to confirm.")]
		[EnumMember(Value = "Value Reported (Not Confirmed)")] 
		[XmlEnum("9")] 
		ValueReportedNotConfirmed = 9,

		[System.ComponentModel.Description("The depth at which a channel is kept by human influence, usually by dredging.")]
		[EnumMember(Value = "Maintained Depth")] 
		[XmlEnum("10")] 
		MaintainedDepth = 10,

		[System.ComponentModel.Description("Depths may be altered by human influence, but will not be routinely maintained.")]
		[EnumMember(Value = "Not Regularly Maintained")] 
		[XmlEnum("11")] 
		NotRegularlyMaintained = 11,
	}

	/// <summary>
	/// Survey method used to obtain depth information.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum techniqueOfVerticalMeasurement : int {
		[System.ComponentModel.Description("The depth was determined by using an instrument that determines depth of water by measuring the time interval between emission of a sonic or ultrasonic signal and return of its echo from the bottom.")]
		[EnumMember(Value = "Found by Echo Sounder")] 
		[XmlEnum("1")] 
		FoundByEchoSounder = 1,

		[System.ComponentModel.Description("The depth was computed from a record produced by active sonar in which fixed acoustic beams are directed into the water perpendicularly to the direction of travel to scan the seabed and generate a record of the seabed configuration.")]
		[EnumMember(Value = "Found by Side Scan Sonar")] 
		[XmlEnum("2")] 
		FoundBySideScanSonar = 2,

		[System.ComponentModel.Description("The depth was determined by using a wide swath echo sounder that uses multiple beams to measure depths directly below and transverse to the ship's track.")]
		[EnumMember(Value = "Found by Multi Beam")] 
		[XmlEnum("3")] 
		FoundByMultiBeam = 3,

		[System.ComponentModel.Description("The depth was determined by a person skilled in the practice of diving.")]
		[EnumMember(Value = "Found by Diver")] 
		[XmlEnum("4")] 
		FoundByDiver = 4,

		[System.ComponentModel.Description("The depth was determined by using a line, graduated with attached marks and fastened to a sounding lead.")]
		[EnumMember(Value = "Found by Lead Line")] 
		[XmlEnum("5")] 
		FoundByLeadLine = 5,

		[System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a buoyed wire at the desired depth by two launches, or a least depth was identified using the same technique.")]
		[EnumMember(Value = "Swept by Wire-Drag")] 
		[XmlEnum("6")] 
		SweptByWireDrag = 6,

		[System.ComponentModel.Description("The depth was determined by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
		[EnumMember(Value = "Found by Laser")] 
		[XmlEnum("7")] 
		FoundByLaser = 7,

		[System.ComponentModel.Description("The given area has been swept using a system comprised of multiple echo sounder transducers attached to booms deployed from the survey vessel.")]
		[EnumMember(Value = "Swept by Vertical Acoustic System")] 
		[XmlEnum("8")] 
		SweptByVerticalAcousticSystem = 8,

		[System.ComponentModel.Description("The depth was determined by using an instrument that compares electromagnetic signals.")]
		[EnumMember(Value = "Found by Electromagnetic Sensor")] 
		[XmlEnum("9")] 
		FoundByElectromagneticSensor = 9,

		[System.ComponentModel.Description("The science or art of obtaining reliable measurements from photographs.")]
		[EnumMember(Value = "Photogrammetry")] 
		[XmlEnum("10")] 
		Photogrammetry = 10,

		[System.ComponentModel.Description("The depth was determined by using instruments placed aboard an artificial satellite.")]
		[EnumMember(Value = "Satellite Imagery")] 
		[XmlEnum("11")] 
		SatelliteImagery = 11,

		[System.ComponentModel.Description("The depth was determined by using levelling techniques to find the elevation of the point relative to a datum.")]
		[EnumMember(Value = "Found by Levelling")] 
		[XmlEnum("12")] 
		FoundByLevelling = 12,

		[System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a side scan sonar.")]
		[EnumMember(Value = "Swept by Side Scan Sonar")] 
		[XmlEnum("13")] 
		SweptBySideScanSonar = 13,

		[System.ComponentModel.Description("The sounding was determined from a bottom model constructed using a computer.")]
		[EnumMember(Value = "Computer Generated")] 
		[XmlEnum("14")] 
		ComputerGenerated = 14,

		[System.ComponentModel.Description("The depth was measured by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
		[EnumMember(Value = "Found by LIDAR")] 
		[XmlEnum("15")] 
		FoundByLidar = 15,

		[System.ComponentModel.Description("A radar with a synthetic aperture antenna which is composed of a large number of elementary transducing elements. The signals are electronically combined into a resulting signal equivalent to that of a single antenna of a given aperture in a given direction.")]
		[EnumMember(Value = "Synthetic Aperture Radar")] 
		[XmlEnum("16")] 
		SyntheticApertureRadar = 16,

		[System.ComponentModel.Description("Term used to describe the imagery derived from subdividing the electromagnetic spectrum into very narrow bandwidths. These narrow bandwidths may be combined with or subtracted from each other in various ways to form images useful in precise terrain or target analysis.")]
		[EnumMember(Value = "Hyperspectral Imagery")] 
		[XmlEnum("17")] 
		HyperspectralImagery = 17,

		[System.ComponentModel.Description("The given area was determined to be free from navigational dangers to a certain depth by towing a line or object below the surface at the desired depth; or least depth(s) and position(s) within an area was identified using the same technique.")]
		[EnumMember(Value = "Mechanically Swept")] 
		[XmlEnum("18")] 
		MechanicallySwept = 18,
	}

	/// <summary>
	/// The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas. Also called spring low water.")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		[XmlEnum("1")] 
		MeanLowWaterSprings = 1,

		[System.ComponentModel.Description("The average height of lower low water springs at a place.")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		[XmlEnum("2")] 
		MeanLowerLowWaterSprings = 2,

		[System.ComponentModel.Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
		[EnumMember(Value = "Mean Sea Level")] 
		[XmlEnum("3")] 
		MeanSeaLevel = 3,

		[System.ComponentModel.Description("An arbitrary level conforming to the lowest tide observed at a place, or some what lower.")]
		[EnumMember(Value = "Lowest Low Water")] 
		[XmlEnum("4")] 
		LowestLowWater = 4,

		[System.ComponentModel.Description("The average height of all low waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Low Water")] 
		[XmlEnum("5")] 
		MeanLowWater = 5,

		[System.ComponentModel.Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
		[EnumMember(Value = "Lowest Low Water Springs")] 
		[XmlEnum("6")] 
		LowestLowWaterSprings = 6,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
		[EnumMember(Value = "Approximate Mean Low Water Springs")] 
		[XmlEnum("7")] 
		ApproximateMeanLowWaterSprings = 7,

		[System.ComponentModel.Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
		[EnumMember(Value = "Indian Spring Low Water")] 
		[XmlEnum("8")] 
		IndianSpringLowWater = 8,

		[System.ComponentModel.Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
		[EnumMember(Value = "Low Water Springs")] 
		[XmlEnum("9")] 
		LowWaterSprings = 9,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
		[EnumMember(Value = "Approximate Lowest Astronomical Tide")] 
		[XmlEnum("10")] 
		ApproximateLowestAstronomicalTide = 10,

		[System.ComponentModel.Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
		[EnumMember(Value = "Nearly Lowest Low Water")] 
		[XmlEnum("11")] 
		NearlyLowestLowWater = 11,

		[System.ComponentModel.Description("The average height of the lower low waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Lower Low Water")] 
		[XmlEnum("12")] 
		MeanLowerLowWater = 12,

		[System.ComponentModel.Description("The lowest level reached at a place by the water surface in one oscillation. Also called low tide.")]
		[EnumMember(Value = "Low Water")] 
		[XmlEnum("13")] 
		LowWater = 13,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
		[EnumMember(Value = "Approximate Mean Low Water")] 
		[XmlEnum("14")] 
		ApproximateMeanLowWater = 14,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
		[EnumMember(Value = "Approximate Mean Lower Low Water")] 
		[XmlEnum("15")] 
		ApproximateMeanLowerLowWater = 15,

		[System.ComponentModel.Description("The average height of all high waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean High Water")] 
		[XmlEnum("16")] 
		MeanHighWater = 16,

		[System.ComponentModel.Description("The average height of the high waters of spring tides. Also called spring high water.")]
		[EnumMember(Value = "Mean High Water Springs")] 
		[XmlEnum("17")] 
		MeanHighWaterSprings = 17,

		[System.ComponentModel.Description("The highest level reached at a place by the water surface in one oscillation.")]
		[EnumMember(Value = "High Water")] 
		[XmlEnum("18")] 
		HighWater = 18,

		[System.ComponentModel.Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		[XmlEnum("19")] 
		ApproximateMeanSeaLevel = 19,

		[System.ComponentModel.Description("An arbitrary level, approximating that of mean high water springs (MHWS).")]
		[EnumMember(Value = "High Water Springs")] 
		[XmlEnum("20")] 
		HighWaterSprings = 20,

		[System.ComponentModel.Description("The average height of higher high waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Higher High Water")] 
		[XmlEnum("21")] 
		MeanHigherHighWater = 21,

		[System.ComponentModel.Description("The level of low water springs near the time of an equinox.")]
		[EnumMember(Value = "Equinoctial Spring Low Water")] 
		[XmlEnum("22")] 
		EquinoctialSpringLowWater = 22,

		[System.ComponentModel.Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
		[EnumMember(Value = "Lowest Astronomical Tide")] 
		[XmlEnum("23")] 
		LowestAstronomicalTide = 23,

		[System.ComponentModel.Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("24")] 
		LocalDatum = 24,

		[System.ComponentModel.Description("A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Pere, Quebec, over the period 1970 to 1988.")]
		[EnumMember(Value = "International Great Lakes Datum 1985")] 
		[XmlEnum("25")] 
		InternationalGreatLakesDatum1985 = 25,

		[System.ComponentModel.Description("The average of all hourly water levels over the available period of record.")]
		[EnumMember(Value = "Mean Water Level")] 
		[XmlEnum("26")] 
		MeanWaterLevel = 26,

		[System.ComponentModel.Description("The average of the lowest low waters, one from each of 19 years of observations.")]
		[EnumMember(Value = "Lower Low Water Large Tide")] 
		[XmlEnum("27")] 
		LowerLowWaterLargeTide = 27,

		[System.ComponentModel.Description("The average of the highest high waters, one from each of 19 years of observations.")]
		[EnumMember(Value = "Higher High Water Large Tide")] 
		[XmlEnum("28")] 
		HigherHighWaterLargeTide = 28,

		[System.ComponentModel.Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
		[EnumMember(Value = "Nearly Highest High Water")] 
		[XmlEnum("29")] 
		NearlyHighestHighWater = 29,

		[System.ComponentModel.Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
		[EnumMember(Value = "Highest Astronomical Tide")] 
		[XmlEnum("30")] 
		HighestAstronomicalTide = 30,

		[System.ComponentModel.Description("Low water reference level of the local area.")]
		[EnumMember(Value = "Local Low Water Reference Level")] 
		[XmlEnum("31")] 
		LocalLowWaterReferenceLevel = 31,

		[System.ComponentModel.Description("High water reference level of the local area.")]
		[EnumMember(Value = "Local High Water Reference Level")] 
		[XmlEnum("32")] 
		LocalHighWaterReferenceLevel = 32,

		[System.ComponentModel.Description("Mean water reference level of the local area.")]
		[EnumMember(Value = "Local Mean Water Reference Level")] 
		[XmlEnum("33")] 
		LocalMeanWaterReferenceLevel = 33,

		[System.ComponentModel.Description("A low water level which is the result of a defined low water discharge - called \"equivalent discharge\".")]
		[EnumMember(Value = "Equivalent Height of Water (German GlW)")] 
		[XmlEnum("34")] 
		EquivalentHeightOfWaterGermanGlw = 34,

		[System.ComponentModel.Description("Upper limit of water levels where navigation is allowed.")]
		[EnumMember(Value = "Highest Shipping Height of Water (German HSW)")] 
		[XmlEnum("35")] 
		HighestShippingHeightOfWaterGermanHsw = 35,

		[System.ComponentModel.Description("The water level at a discharge, which is exceeded 94 % of the year within a period of 30 years.")]
		[EnumMember(Value = "Reference Low Water Level According to Danube Commission")] 
		[XmlEnum("36")] 
		ReferenceLowWaterLevelAccordingToDanubeCommission = 36,

		[System.ComponentModel.Description("The water level at a discharge, which is exceeded 1% of the year within a period of 30 years.")]
		[EnumMember(Value = "Highest Shipping Height of Water According to Danube Commission")] 
		[XmlEnum("37")] 
		HighestShippingHeightOfWaterAccordingToDanubeCommission = 37,

		[System.ComponentModel.Description("The water level at a discharge, which is exceeded 95% of the year within a period of 20 years.")]
		[EnumMember(Value = "Dutch River Low Water Reference Level (OLR)")] 
		[XmlEnum("38")] 
		DutchRiverLowWaterReferenceLevelOlr = 38,

		[System.ComponentModel.Description("Conditional low water level with established probability.")]
		[EnumMember(Value = "Russian Project Water Level")] 
		[XmlEnum("39")] 
		RussianProjectWaterLevel = 39,

		[System.ComponentModel.Description("Highest water level derived from the upper backwater stream in watercourse or reservoir under the normal operational conditions.")]
		[EnumMember(Value = "Russian Normal Backwater Level")] 
		[XmlEnum("40")] 
		RussianNormalBackwaterLevel = 40,

		[System.ComponentModel.Description("The Ohio River datum.")]
		[EnumMember(Value = "Ohio River Datum")] 
		[XmlEnum("41")] 
		OhioRiverDatum = 41,

		[System.ComponentModel.Description("Dutch High Water Reference Level.")]
		[EnumMember(Value = "Dutch High Water Reference Level")] 
		[XmlEnum("43")] 
		DutchHighWaterReferenceLevel = 43,

		[System.ComponentModel.Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		[XmlEnum("44")] 
		BalticSeaChartDatum2000 = 44,

		[System.ComponentModel.Description("Dutch Estuary Low Water Reference Level (OLW)")]
		[EnumMember(Value = "Dutch Estuary Low Water Reference Level (OLW)")] 
		[XmlEnum("45")] 
		DutchEstuaryLowWaterReferenceLevelOlw = 45,

		[System.ComponentModel.Description("The 2020 update to the International Great Lakes Datum, the official reference system used to measure water level heights in the Great Lakes, connecting channels, and the St. Lawrence River system.")]
		[EnumMember(Value = "International Great Lakes Datum 2020")] 
		[XmlEnum("46")] 
		InternationalGreatLakesDatum2020 = 46,

		[System.ComponentModel.Description("The bottom of the ocean and seas where there is a generally smooth gentle gradient. Also referred to as sea bed (sometimes seabed or sea-bed), and sea bottom.")]
		[EnumMember(Value = "Sea Floor")] 
		[XmlEnum("47")] 
		SeaFloor = 47,

		[System.ComponentModel.Description("A two-dimensional (in the horizontal plane) field representing the air-sea interface, with high-frequency fluctuations such as wind waves and swell, but not astronomical tides, filtered out.")]
		[EnumMember(Value = "Sea Surface")] 
		[XmlEnum("48")] 
		SeaSurface = 48,

		[System.ComponentModel.Description("A vertical reference near the lowest astronomical tide (LAT), below which the sea level falls only very exceptionally.")]
		[EnumMember(Value = "Hydrographic Zero")] 
		[XmlEnum("49")] 
		HydrographicZero = 49,
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

		[System.ComponentModel.Description("No longer lit.")]
		[EnumMember(Value = "Extinguished")] 
		[XmlEnum("11")] 
		Extinguished = 11,

		[System.ComponentModel.Description("Lit by floodlights, strip lights, etc.")]
		[EnumMember(Value = "Illuminated")] 
		[XmlEnum("12")] 
		Illuminated = 12,

		[System.ComponentModel.Description("Famous in history; of historical interest.")]
		[EnumMember(Value = "Historic")] 
		[XmlEnum("13")] 
		Historic = 13,

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

		[System.ComponentModel.Description("When you ask for it.")]
		[EnumMember(Value = "On Request")] 
		[XmlEnum("19")] 
		OnRequest = 19,

		[System.ComponentModel.Description("To become lower in level.")]
		[EnumMember(Value = "Drop Away")] 
		[XmlEnum("20")] 
		DropAway = 20,

		[System.ComponentModel.Description("To become higher in level.")]
		[EnumMember(Value = "Rising")] 
		[XmlEnum("21")] 
		Rising = 21,

		[System.ComponentModel.Description("Becoming larger in magnitude.")]
		[EnumMember(Value = "Increasing")] 
		[XmlEnum("22")] 
		Increasing = 22,

		[System.ComponentModel.Description("Becoming smaller in magnitude.")]
		[EnumMember(Value = "Decreasing")] 
		[XmlEnum("23")] 
		Decreasing = 23,

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

		[System.ComponentModel.Description("Marked by buoys.")]
		[EnumMember(Value = "Buoyed")] 
		[XmlEnum("28")] 
		Buoyed = 28,

		[System.ComponentModel.Description("Entire observation platform is operating in accordance with, or exceeding, manufacturer specifications.")]
		[EnumMember(Value = "Fully Operational")] 
		[XmlEnum("29")] 
		FullyOperational = 29,

		[System.ComponentModel.Description("At least one instrument that is part of an observation platform is not operating to manufacturer specification.")]
		[EnumMember(Value = "Partially Operational")] 
		[XmlEnum("30")] 
		PartiallyOperational = 30,

		[System.ComponentModel.Description("Floating platform at the mercy of environmental elements, whether intentional or not.")]
		[EnumMember(Value = "Drifting")] 
		[XmlEnum("31")] 
		Drifting = 31,

		[System.ComponentModel.Description("Fractured or in pieces.")]
		[EnumMember(Value = "Broken")] 
		[XmlEnum("32")] 
		Broken = 32,

		[System.ComponentModel.Description("Observation platform is intentionally not reporting an environmental observation.")]
		[EnumMember(Value = "Offline")] 
		[XmlEnum("33")] 
		Offline = 33,

		[System.ComponentModel.Description("Observation station, suite of instruments, or an individual instrument, for a particular location, has been removed and is no longer at the particular location.")]
		[EnumMember(Value = "Discontinued")] 
		[XmlEnum("34")] 
		Discontinued = 34,

		[System.ComponentModel.Description("Observations made by a human observer.")]
		[EnumMember(Value = "Manual Observation")] 
		[XmlEnum("35")] 
		ManualObservation = 35,

		[System.ComponentModel.Description("Status of an observation platform, suite of instruments, or individual instrument is not known or unspecified.")]
		[EnumMember(Value = "Unknown Status")] 
		[XmlEnum("36")] 
		UnknownStatus = 36,

		[System.ComponentModel.Description("Made certain as to truth, accuracy, validity, availability, etc.")]
		[EnumMember(Value = "Confirmed")] 
		[XmlEnum("37")] 
		Confirmed = 37,

		[System.ComponentModel.Description("Item selected for an action.")]
		[EnumMember(Value = "Candidate")] 
		[XmlEnum("38")] 
		Candidate = 38,

		[System.ComponentModel.Description("Item that is in the process of being modified.")]
		[EnumMember(Value = "Under Modification")] 
		[XmlEnum("39")] 
		UnderModification = 39,

		[System.ComponentModel.Description("Item in the process of being removed or deleted.")]
		[EnumMember(Value = "Under Removal / Deletion")] 
		[XmlEnum("41")] 
		UnderRemovalDeletion = 41,

		[System.ComponentModel.Description("Item that has been removed or deleted.")]
		[EnumMember(Value = "Removed / Deleted")] 
		[XmlEnum("42")] 
		RemovedDeleted = 42,

		[System.ComponentModel.Description("Item selected for modification.")]
		[EnumMember(Value = "Candidate for Modification")] 
		[XmlEnum("43")] 
		CandidateForModification = 43,
	}

	/// <summary>
	/// Classification of an aid to navigation which signifies some special purpose.
	/// </summary>
	/// <remarks>
	/// A mark may be a beacon, a buoy, a signpost or may take another form.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSpecialPurposeMark : int {
		[System.ComponentModel.Description("A mark used to indicate a firing danger area, usually at sea.")]
		[EnumMember(Value = "Firing Danger Area Mark")] 
		[XmlEnum("1")] 
		FiringDangerAreaMark = 1,

		[System.ComponentModel.Description("Any object toward which something is directed. The distinctive marking or instrumentation of a ground point to aid its identification on a photograph.")]
		[EnumMember(Value = "Target Mark")] 
		[XmlEnum("2")] 
		TargetMark = 2,

		[System.ComponentModel.Description("A mark marking the position of a ship which is used as a target during some military exercise.")]
		[EnumMember(Value = "Marker Ship Mark")] 
		[XmlEnum("3")] 
		MarkerShipMark = 3,

		[System.ComponentModel.Description("A mark used to indicate a degaussing range.")]
		[EnumMember(Value = "Degaussing Range Mark")] 
		[XmlEnum("4")] 
		DegaussingRangeMark = 4,

		[System.ComponentModel.Description("A mark of relevance to barges.")]
		[EnumMember(Value = "Barge Mark")] 
		[XmlEnum("5")] 
		BargeMark = 5,

		[System.ComponentModel.Description("A mark used to indicate the position of submarine cables or the point at which they run on to the land.")]
		[EnumMember(Value = "Cable Mark")] 
		[XmlEnum("6")] 
		CableMark = 6,

		[System.ComponentModel.Description("A mark used to indicate the limit of a spoil ground.")]
		[EnumMember(Value = "Spoil Ground Mark")] 
		[XmlEnum("7")] 
		SpoilGroundMark = 7,

		[System.ComponentModel.Description("A mark used to indicate the position of an outfall or the point at which it leaves the land.")]
		[EnumMember(Value = "Outfall Mark")] 
		[XmlEnum("8")] 
		OutfallMark = 8,

		[System.ComponentModel.Description("Ocean Data Acquisition System.")]
		[EnumMember(Value = "ODAS")] 
		[XmlEnum("9")] 
		Odas = 9,

		[System.ComponentModel.Description("A mark used to record data for scientific purposes.")]
		[EnumMember(Value = "Recording Mark")] 
		[XmlEnum("10")] 
		RecordingMark = 10,

		[System.ComponentModel.Description("A mark used to indicate a seaplane anchorage.")]
		[EnumMember(Value = "Seaplane Anchorage Mark")] 
		[XmlEnum("11")] 
		SeaplaneAnchorageMark = 11,

		[System.ComponentModel.Description("A mark used to indicate a recreation zone.")]
		[EnumMember(Value = "Recreation Zone Mark")] 
		[XmlEnum("12")] 
		RecreationZoneMark = 12,

		[System.ComponentModel.Description("A privately maintained mark.")]
		[EnumMember(Value = "Private Mark")] 
		[XmlEnum("13")] 
		PrivateMark = 13,

		[System.ComponentModel.Description("A mark indicating a mooring or moorings.")]
		[EnumMember(Value = "Mooring Mark")] 
		[XmlEnum("14")] 
		MooringMark = 14,

		[System.ComponentModel.Description("A large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.")]
		[EnumMember(Value = "LANBY")] 
		[XmlEnum("15")] 
		Lanby = 15,

		[System.ComponentModel.Description("Aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.")]
		[EnumMember(Value = "Leading Mark")] 
		[XmlEnum("16")] 
		LeadingMark = 16,

		[System.ComponentModel.Description("A mark forming part of a transit indicating one end of a measured distance.")]
		[EnumMember(Value = "Measured Distance Mark")] 
		[XmlEnum("17")] 
		MeasuredDistanceMark = 17,

		[System.ComponentModel.Description("A notice board or sign indicating information to the mariner.")]
		[EnumMember(Value = "Notice Mark")] 
		[XmlEnum("18")] 
		NoticeMark = 18,

		[System.ComponentModel.Description("A mark indicating a Traffic Separation Scheme.")]
		[EnumMember(Value = "TSS Mark")] 
		[XmlEnum("19")] 
		TssMark = 19,

		[System.ComponentModel.Description("A mark indicating an anchoring prohibited area.")]
		[EnumMember(Value = "Anchoring Prohibited Mark")] 
		[XmlEnum("20")] 
		AnchoringProhibitedMark = 20,

		[System.ComponentModel.Description("A mark indicating that berthing is prohibited.")]
		[EnumMember(Value = "Berthing Prohibited Mark")] 
		[XmlEnum("21")] 
		BerthingProhibitedMark = 21,

		[System.ComponentModel.Description("A mark indicating that overtaking is prohibited.")]
		[EnumMember(Value = "Overtaking Prohibited Mark")] 
		[XmlEnum("22")] 
		OvertakingProhibitedMark = 22,

		[System.ComponentModel.Description("A mark indicating a one-way route.")]
		[EnumMember(Value = "Two-Way Traffic Prohibited Mark")] 
		[XmlEnum("23")] 
		TwoWayTrafficProhibitedMark = 23,

		[System.ComponentModel.Description("A mark indicating that vessels must not generate excessive wake.")]
		[EnumMember(Value = "Reduced Wake Mark")] 
		[XmlEnum("24")] 
		ReducedWakeMark = 24,

		[System.ComponentModel.Description("A mark indicating that a speed limit applies.")]
		[EnumMember(Value = "Speed Limit Mark")] 
		[XmlEnum("25")] 
		SpeedLimitMark = 25,

		[System.ComponentModel.Description("A mark indicating the place where the bow of a ship must stop when traffic lights show red.")]
		[EnumMember(Value = "Stop Mark")] 
		[XmlEnum("26")] 
		StopMark = 26,

		[System.ComponentModel.Description("A mark indicating that special caution must be exercised in the vicinity of the mark.")]
		[EnumMember(Value = "General Warning Mark")] 
		[XmlEnum("27")] 
		GeneralWarningMark = 27,

		[System.ComponentModel.Description("A mark indicating that a ship should sound its siren or horn.")]
		[EnumMember(Value = "Sound Ship's Siren Mark")] 
		[XmlEnum("28")] 
		SoundShipSSirenMark = 28,

		[System.ComponentModel.Description("A mark indicating the minimum vertical space available for passage.")]
		[EnumMember(Value = "Restricted Vertical Clearance Mark")] 
		[XmlEnum("29")] 
		RestrictedVerticalClearanceMark = 29,

		[System.ComponentModel.Description("A mark indicating the maximum draught of vessel permitted.")]
		[EnumMember(Value = "Maximum Vessel's Draught Mark")] 
		[XmlEnum("30")] 
		MaximumVesselSDraughtMark = 30,

		[System.ComponentModel.Description("A mark indicating the minimum horizontal space available for passage.")]
		[EnumMember(Value = "Restricted Horizontal Clearance Mark")] 
		[XmlEnum("31")] 
		RestrictedHorizontalClearanceMark = 31,

		[System.ComponentModel.Description("A mark warning of strong currents.")]
		[EnumMember(Value = "Strong Current Warning Mark")] 
		[XmlEnum("32")] 
		StrongCurrentWarningMark = 32,

		[System.ComponentModel.Description("A mark indicating that berthing is allowed.")]
		[EnumMember(Value = "Berthing Permitted Mark")] 
		[XmlEnum("33")] 
		BerthingPermittedMark = 33,

		[System.ComponentModel.Description("A mark indicating an overhead power cable.")]
		[EnumMember(Value = "Overhead Power Cable Mark")] 
		[XmlEnum("34")] 
		OverheadPowerCableMark = 34,

		[System.ComponentModel.Description("A mark indicating the gradient of the slope of a dredge channel edge.")]
		[EnumMember(Value = "Channel Edge Gradient Mark")] 
		[XmlEnum("35")] 
		ChannelEdgeGradientMark = 35,

		[System.ComponentModel.Description("A mark indicating the presence of a telephone.")]
		[EnumMember(Value = "Telephone Mark")] 
		[XmlEnum("36")] 
		TelephoneMark = 36,

		[System.ComponentModel.Description("A mark indicating that a ferry route crosses the ship route; often used with a 'sound ship's siren' mark.")]
		[EnumMember(Value = "Ferry Crossing Mark")] 
		[XmlEnum("37")] 
		FerryCrossingMark = 37,

		[System.ComponentModel.Description("A mark used to indicate the position of submarine pipelines or the point at which they run on to the land.")]
		[EnumMember(Value = "Pipeline Mark")] 
		[XmlEnum("39")] 
		PipelineMark = 39,

		[System.ComponentModel.Description("A mark indicating an anchorage area.")]
		[EnumMember(Value = "Anchorage Mark")] 
		[XmlEnum("40")] 
		AnchorageMark = 40,

		[System.ComponentModel.Description("A mark used to indicate a clearing line.")]
		[EnumMember(Value = "Clearing Mark")] 
		[XmlEnum("41")] 
		ClearingMark = 41,

		[System.ComponentModel.Description("A mark indicating the location at which a restriction or requirement exists.")]
		[EnumMember(Value = "Control Mark")] 
		[XmlEnum("42")] 
		ControlMark = 42,

		[System.ComponentModel.Description("A mark indicating that diving may take place in the vicinity.")]
		[EnumMember(Value = "Diving Mark")] 
		[XmlEnum("43")] 
		DivingMark = 43,

		[System.ComponentModel.Description("A mark providing or indicating a place of safety.")]
		[EnumMember(Value = "Refuge Beacon")] 
		[XmlEnum("44")] 
		RefugeBeacon = 44,

		[System.ComponentModel.Description("A mark indicating a foul ground.")]
		[EnumMember(Value = "Foul Ground Mark")] 
		[XmlEnum("45")] 
		FoulGroundMark = 45,

		[System.ComponentModel.Description("A mark installed for use by yachtsmen.")]
		[EnumMember(Value = "Yachting Mark")] 
		[XmlEnum("46")] 
		YachtingMark = 46,

		[System.ComponentModel.Description("A mark indicating an area where helicopters may land.")]
		[EnumMember(Value = "Heliport Mark")] 
		[XmlEnum("47")] 
		HeliportMark = 47,

		[System.ComponentModel.Description("A mark indicating a location at which a GNSS position has been accurately determined.")]
		[EnumMember(Value = "GNSS Mark")] 
		[XmlEnum("48")] 
		GnssMark = 48,

		[System.ComponentModel.Description("A mark indicating an area where sea-planes land.")]
		[EnumMember(Value = "Seaplane Landing Mark")] 
		[XmlEnum("49")] 
		SeaplaneLandingMark = 49,

		[System.ComponentModel.Description("A mark indicating that entry is prohibited.")]
		[EnumMember(Value = "Entry Prohibited Mark")] 
		[XmlEnum("50")] 
		EntryProhibitedMark = 50,

		[System.ComponentModel.Description("A mark indicating that work (generally construction) is in progress.")]
		[EnumMember(Value = "Work in Progress Mark")] 
		[XmlEnum("51")] 
		WorkInProgressMark = 51,

		[System.ComponentModel.Description("A mark whose detailed characteristics are unknown.")]
		[EnumMember(Value = "Mark With Unknown Purpose")] 
		[XmlEnum("52")] 
		MarkWithUnknownPurpose = 52,

		[System.ComponentModel.Description("A mark indicating a borehole that produces or is capable of producing oil or natural gas.")]
		[EnumMember(Value = "Wellhead Mark")] 
		[XmlEnum("53")] 
		WellheadMark = 53,

		[System.ComponentModel.Description("A mark indicating the point at which a channel divides separately into two channels.")]
		[EnumMember(Value = "Channel Separation Mark")] 
		[XmlEnum("54")] 
		ChannelSeparationMark = 54,

		[System.ComponentModel.Description("A mark indicating the existence of a fish, mussel, oyster or pearl farm/culture.")]
		[EnumMember(Value = "Marine Farm Mark")] 
		[XmlEnum("55")] 
		MarineFarmMark = 55,

		[System.ComponentModel.Description("A mark indicating the existence or the extent of an artificial reef.")]
		[EnumMember(Value = "Artificial Reef Mark")] 
		[XmlEnum("56")] 
		ArtificialReefMark = 56,

		[System.ComponentModel.Description("A mark, used year round, that may be submerged when ice passes through the area.")]
		[EnumMember(Value = "Ice Mark")] 
		[XmlEnum("57")] 
		IceMark = 57,

		[System.ComponentModel.Description("A mark used to define the boundary of a nature reserve.")]
		[EnumMember(Value = "Nature Reserve Mark")] 
		[XmlEnum("58")] 
		NatureReserveMark = 58,

		[System.ComponentModel.Description("A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks.")]
		[EnumMember(Value = "Fish Aggregating Device")] 
		[XmlEnum("59")] 
		FishAggregatingDevice = 59,

		[System.ComponentModel.Description("A mark used to indicate the existence of a wreck.")]
		[EnumMember(Value = "Wreck Mark")] 
		[XmlEnum("60")] 
		WreckMark = 60,

		[System.ComponentModel.Description("A mark used to indicate the existence of a customs checkpoint.")]
		[EnumMember(Value = "Customs Mark")] 
		[XmlEnum("61")] 
		CustomsMark = 61,

		[System.ComponentModel.Description("A mark used to indicate the existence of a causeway.")]
		[EnumMember(Value = "Causeway Mark")] 
		[XmlEnum("62")] 
		CausewayMark = 62,

		[System.ComponentModel.Description("A surface following buoy used to measure wave activity.")]
		[EnumMember(Value = "Wave Recorder")] 
		[XmlEnum("63")] 
		WaveRecorder = 63,

		[System.ComponentModel.Description("A mark indicating a jetski prohibited area.")]
		[EnumMember(Value = "Jetski Prohibited")] 
		[XmlEnum("64")] 
		JetskiProhibited = 64,
	}

	/// <summary>
	/// A classification of AIS AtoNs that are transmitted electronically and linked to a real-world object but do not physically exist at the broadcast location.
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfSyntheticAISAidtoNavigation : int {
		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "predicted")] 
		[XmlEnum("1")] 
		Predicted = 1,

		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "monitored")] 
		[XmlEnum("2")] 
		Monitored = 2,
	}

	/// <summary>
	/// A purpose of a virtual AIS Aid to Navigation.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum virtualAISAidToNavigationType : int {
		[System.ComponentModel.Description("Indicates that it should be passed to the north side of the aid.")]
		[EnumMember(Value = "North Cardinal")] 
		[XmlEnum("1")] 
		NorthCardinal = 1,

		[System.ComponentModel.Description("Indicates that it should be passed to the east side of the aid.")]
		[EnumMember(Value = "East Cardinal")] 
		[XmlEnum("2")] 
		EastCardinal = 2,

		[System.ComponentModel.Description("Indicates that it should be passed to the south side of the aid.")]
		[EnumMember(Value = "South Cardinal")] 
		[XmlEnum("3")] 
		SouthCardinal = 3,

		[System.ComponentModel.Description("Indicates that it should be passed to the west side of the aid.")]
		[EnumMember(Value = "West Cardinal")] 
		[XmlEnum("4")] 
		WestCardinal = 4,

		[System.ComponentModel.Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the conventional direction of buoyage.")]
		[EnumMember(Value = "Port Lateral")] 
		[XmlEnum("5")] 
		PortLateral = 5,

		[System.ComponentModel.Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the conventional direction of buoyage.")]
		[EnumMember(Value = "Starboard Lateral")] 
		[XmlEnum("6")] 
		StarboardLateral = 6,

		[System.ComponentModel.Description("At a point where a channel divides, when proceeding in the conventional direction of buoyage, the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Port")] 
		[XmlEnum("7")] 
		PreferredChannelToPort = 7,

		[System.ComponentModel.Description("At a point where a channel divides, when proceeding in the conventional direction of buoyage, the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Starboard")] 
		[XmlEnum("8")] 
		PreferredChannelToStarboard = 8,

		[System.ComponentModel.Description("A mark used alone to indicate a dangerous reef or shoal. The mark may be passed on either hand.")]
		[EnumMember(Value = "Isolated Danger")] 
		[XmlEnum("9")] 
		IsolatedDanger = 9,

		[System.ComponentModel.Description("Indicates that there is navigable water around the mark.")]
		[EnumMember(Value = "Safe Water")] 
		[XmlEnum("10")] 
		SafeWater = 10,

		[System.ComponentModel.Description("A special purpose aid is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notice to Mariners")]
		[EnumMember(Value = "Special Purpose")] 
		[XmlEnum("11")] 
		SpecialPurpose = 11,

		[System.ComponentModel.Description("A mark used to indicate the existence of a recently identified new danger, such as a wreck.")]
		[EnumMember(Value = "New Danger Marking")] 
		[XmlEnum("12")] 
		NewDangerMarking = 12,
	}

	/// <summary>
	/// A classification of AIS AtoNs that correspond to an actual, physical Aid to Navigation at a real-world location.
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfPhysicalAISAidToNavigation : int {
		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "Physical AIS Type 1")] 
		[XmlEnum("1")] 
		PhysicalAisType1 = 1,

		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "Physical AIS Type 2")] 
		[XmlEnum("2")] 
		PhysicalAisType2 = 2,

		[System.ComponentModel.Description("-")]
		[EnumMember(Value = "Physical AIS Type 3")] 
		[XmlEnum("3")] 
		PhysicalAisType3 = 3,
	}

	/// <summary>
	/// The shape a topmark or daymark exhibits.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum topmarkDaymarkShape : int {
		[System.ComponentModel.Description("Is where the vertex points up. A cone is a solid figure generated by straight lines drawn from a fixed point (the vertex) to a circle in a plane not containing the vertex. Cones are commonly used as International Association of Lighthouse Authorities - IALA topmarks, lateral.")]
		[EnumMember(Value = "Cone (Point Up)")] 
		[XmlEnum("1")] 
		ConePointUp = 1,

		[System.ComponentModel.Description("Is where the vertex points down. A cone is a solid figure generated by straight lines drawn from a fixed point (the vertex) to a circle in a plane not containing the vertex. Cones are commonly used as International Association of Lighthouse Authorities - IALA topmarks, lateral.")]
		[EnumMember(Value = "Cone (Point Down)")] 
		[XmlEnum("2")] 
		ConePointDown = 2,

		[System.ComponentModel.Description("A curved surface all points of which are equidistant from a fixed point within, called the centre.")]
		[EnumMember(Value = "Sphere")] 
		[XmlEnum("3")] 
		Sphere = 3,

		[System.ComponentModel.Description("Two spheres, one above the other. Two black spheres are commonly used as an International Association of Lighthouse Authorities - IALA topmark (isolated danger).")]
		[EnumMember(Value = "2 Spheres")] 
		[XmlEnum("4")] 
		twoSpheres = 4,

		[System.ComponentModel.Description("A solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, it's ends being parallel circles). Cylinders are commonly used as International Association of Lighthouse Authorities - IALA topmarks lateral.")]
		[EnumMember(Value = "Cylinder")] 
		[XmlEnum("5")] 
		Cylinder = 5,

		[System.ComponentModel.Description("Usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.")]
		[EnumMember(Value = "Board")] 
		[XmlEnum("6")] 
		Board = 6,

		[System.ComponentModel.Description("Having a shape or a cross-section like the capital letter X. An x-shape as an International Association of Lighthouse Authorities - IALA topmark should be 3 dimensional in shape. It is made of at least three crossed bars.")]
		[EnumMember(Value = "X-Shaped")] 
		[XmlEnum("7")] 
		XShaped = 7,

		[System.ComponentModel.Description("A cross with one vertical member and one horizontal member; that is, similar in shape to the character '+'.")]
		[EnumMember(Value = "Upright Cross")] 
		[XmlEnum("8")] 
		UprightCross = 8,

		[System.ComponentModel.Description("A cube standing on one of its vertexes. A cube is a solid contained by six equal squares, a regular hexahedron.")]
		[EnumMember(Value = "Cube (Point Up)")] 
		[XmlEnum("9")] 
		CubePointUp = 9,

		[System.ComponentModel.Description("2 cones, one above the other, with their vertices together in the centre.")]
		[EnumMember(Value = "2 Cones (Point to Point)")] 
		[XmlEnum("10")] 
		twoConesPointToPoint = 10,

		[System.ComponentModel.Description("2 cones, one above the other, with their bases together in the centre and their vertices pointing up and down.")]
		[EnumMember(Value = "2 Cones (Base to Base)")] 
		[XmlEnum("11")] 
		twoConesBaseToBase = 11,

		[System.ComponentModel.Description("A plane figure having four equal sides and equal opposite angles (two acute and two obtuse); an oblique equilateral parallelogram.")]
		[EnumMember(Value = "Rhombus")] 
		[XmlEnum("12")] 
		Rhombus = 12,

		[System.ComponentModel.Description("2 cones, one above the other, with their vertices pointing up.")]
		[EnumMember(Value = "2 Cones (Points Upward)")] 
		[XmlEnum("13")] 
		twoConesPointsUpward = 13,

		[System.ComponentModel.Description("2 cones, one above the other, with their vertices pointing down.")]
		[EnumMember(Value = "2 Cones (Points Downward)")] 
		[XmlEnum("14")] 
		twoConesPointsDownward = 14,

		[System.ComponentModel.Description("Besom: A bundle of rods or twigs. Perch: A staff placed on top of a buoy, rock or shoal as a mark for navigation. A besom, point up is where the thicker (untied) end of the besom is at the bottom.")]
		[EnumMember(Value = "Besom (Point Up)")] 
		[XmlEnum("15")] 
		BesomPointUp = 15,

		[System.ComponentModel.Description("Besom: A bundle of rods or twigs. Perch: A staff placed on top of a buoy, rock or shoal as a mark for navigation. A besom, point down is where the thinner (tied) end of the besom is at the bottom.")]
		[EnumMember(Value = "Besom (Point Down)")] 
		[XmlEnum("16")] 
		BesomPointDown = 16,

		[System.ComponentModel.Description("A flag mounted on a short pole.")]
		[EnumMember(Value = "Flag")] 
		[XmlEnum("17")] 
		Flag = 17,

		[System.ComponentModel.Description("A sphere located above a rhombus.")]
		[EnumMember(Value = "Sphere Over a Rhombus")] 
		[XmlEnum("18")] 
		SphereOverARhombus = 18,

		[System.ComponentModel.Description("A plane figure with four right angles and four equal straight sides.")]
		[EnumMember(Value = "Square")] 
		[XmlEnum("19")] 
		Square = 19,

		[System.ComponentModel.Description("Where the two longer opposite sides are standing horizontally. A rectangle is a plane figure with four right angles and four straight sides, opposite sides being parallel and equal in length.")]
		[EnumMember(Value = "Rectangle (Horizontal)")] 
		[XmlEnum("20")] 
		RectangleHorizontal = 20,

		[System.ComponentModel.Description("Where the two longer opposite sides are standing vertically. A rectangle is a plane figure with four right angles and four straight sides, opposite sides being parallel and equal in length.")]
		[EnumMember(Value = "Rectangle (Vertical)")] 
		[XmlEnum("21")] 
		RectangleVertical = 21,

		[System.ComponentModel.Description("A quadrilateral having one pair of opposite sides parallel, and which stands on its longer parallel side.")]
		[EnumMember(Value = "Trapezium (Up)")] 
		[XmlEnum("22")] 
		TrapeziumUp = 22,

		[System.ComponentModel.Description("A quadrilateral having one pair of opposite sides parallel, and which stands on its shorter parallel side.")]
		[EnumMember(Value = "Trapezium (Down)")] 
		[XmlEnum("23")] 
		TrapeziumDown = 23,

		[System.ComponentModel.Description("A figure having three angles and three sides, and which has a vertex at the top.")]
		[EnumMember(Value = "Triangle (Point Up)")] 
		[XmlEnum("24")] 
		TrianglePointUp = 24,

		[System.ComponentModel.Description("A figure having three angles and three sides, and which has a side at the top.")]
		[EnumMember(Value = "Triangle (Point Down)")] 
		[XmlEnum("25")] 
		TrianglePointDown = 25,

		[System.ComponentModel.Description("A perfectly round plane figure whose circumference is everywhere equidistant from its centre.")]
		[EnumMember(Value = "Circle")] 
		[XmlEnum("26")] 
		Circle = 26,

		[System.ComponentModel.Description("Two upright crosses, generally vertically disposed one above the other.")]
		[EnumMember(Value = "Two Upright Crosses (One Over the Other)")] 
		[XmlEnum("27")] 
		TwoUprightCrossesOneOverTheOther = 27,

		[System.ComponentModel.Description("Having a shape like the capital letter T.")]
		[EnumMember(Value = "T-Shape")] 
		[XmlEnum("28")] 
		TShape = 28,

		[System.ComponentModel.Description("A triangle, vertex uppermost, located above a circle.")]
		[EnumMember(Value = "Triangle Pointing Up Over a Circle")] 
		[XmlEnum("29")] 
		TrianglePointingUpOverACircle = 29,

		[System.ComponentModel.Description("An upright cross located above a circle.")]
		[EnumMember(Value = "Upright Cross Over a Circle")] 
		[XmlEnum("30")] 
		UprightCrossOverACircle = 30,

		[System.ComponentModel.Description("A rhombus located above a circle.")]
		[EnumMember(Value = "Rhombus Over a Circle")] 
		[XmlEnum("31")] 
		RhombusOverACircle = 31,

		[System.ComponentModel.Description("A circle located over a triangle, vertex uppermost.")]
		[EnumMember(Value = "Circle Over a Triangle Pointing Up")] 
		[XmlEnum("32")] 
		CircleOverATrianglePointingUp = 32,

		[System.ComponentModel.Description("An uncommon and/or non-standardized shape as textually described using an associated attribute.")]
		[EnumMember(Value = "Other Shape (See Shape Information)")] 
		[XmlEnum("33")] 
		OtherShapeSeeShapeInformation = 33,

		[System.ComponentModel.Description("Having the form of or consisting of a tube.")]
		[EnumMember(Value = "Tubular")] 
		[XmlEnum("34")] 
		Tubular = 34,
	}

	/// <summary>
	/// Classification of the various means of generating the fog signal.
	/// </summary>
	/// <remarks>
	/// The classification 'horn' is the generic term for fog signals 'nautophone', 'reed' and 'tyfon'.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFogSignal : int {
		[System.ComponentModel.Description("A signal produced by the firing of explosive charges.")]
		[EnumMember(Value = "Explosive")] 
		[XmlEnum("1")] 
		Explosive = 1,

		[System.ComponentModel.Description("A diaphone uses compressed air and generally emits a powerful low-pitched sound, which often concludes with a brief sound of suddenly lowered pitch, termed the 'grunt'.")]
		[EnumMember(Value = "Diaphone")] 
		[XmlEnum("2")] 
		Diaphone = 2,

		[System.ComponentModel.Description("A type of fog signal apparatus which produces sound by virtue of the passage of air through slots or holes in a revolving disk.")]
		[EnumMember(Value = "Siren")] 
		[XmlEnum("3")] 
		Siren = 3,

		[System.ComponentModel.Description("A horn having a diaphragm oscillated by electricity.")]
		[EnumMember(Value = "Nautophone")] 
		[XmlEnum("4")] 
		Nautophone = 4,

		[System.ComponentModel.Description("[1]  A reed uses compressed air and emits a weak, high pitched sound.  [2]  Any of various water or marsh plants with a firm stem. (Concise Oxford English Dictionary)")]
		[EnumMember(Value = "Reed")] 
		[XmlEnum("5")] 
		Reed = 5,

		[System.ComponentModel.Description("A diaphragm horn which operates under the influence of compressed air or steam.")]
		[EnumMember(Value = "Tyfon")] 
		[XmlEnum("6")] 
		Tyfon = 6,

		[System.ComponentModel.Description("A ringing sound with a short range.")]
		[EnumMember(Value = "Bell")] 
		[XmlEnum("7")] 
		Bell = 7,

		[System.ComponentModel.Description("A distinctive sound made by a jet of air passing through an orifice. The apparatus may be operated automatically, by hand or by air being forced up a tube by waves acting on a buoy.")]
		[EnumMember(Value = "Whistle")] 
		[XmlEnum("8")] 
		Whistle = 8,

		[System.ComponentModel.Description("A sound produced by vibration of a disc when struck.")]
		[EnumMember(Value = "Gong")] 
		[XmlEnum("9")] 
		Gong = 9,

		[System.ComponentModel.Description("A horn uses compressed air or electricity to vibrate a diaphragm and exists in a variety of types which differ greatly in their sound and power.")]
		[EnumMember(Value = "Horn")] 
		[XmlEnum("10")] 
		Horn = 10,
	}

	/// <summary>
	/// Describes the characteristic geometric form of the beacon.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum beaconShape : int {
		[System.ComponentModel.Description("An elongated wood or metal pole, driven into the ground or seabed, which serves as a navigational aid or a support for a navigational aid.")]
		[EnumMember(Value = "Stake, Pole, Perch, Post")] 
		[XmlEnum("1")] 
		StakePolePerchPost = 1,

		[System.ComponentModel.Description("A tree without roots stuck or spoiled into the bottom of the sea to serve as a navigational aid.")]
		[EnumMember(Value = "Withy")] 
		[XmlEnum("2")] 
		Withy = 2,

		[System.ComponentModel.Description("A solid structure of the order of 10 metres in height used as a navigational aid.")]
		[EnumMember(Value = "Beacon Tower")] 
		[XmlEnum("3")] 
		BeaconTower = 3,

		[System.ComponentModel.Description("A structure consisting of strips of metal or wood crossed or interlaced to form a structure to serve as an aid to navigation or as a support for an aid to navigation.")]
		[EnumMember(Value = "Lattice Beacon")] 
		[XmlEnum("4")] 
		LatticeBeacon = 4,

		[System.ComponentModel.Description("A long heavy timber(s) or section(s) of steel, wood, concrete, etc., forced into the seabed to serve as an aid to navigation or as a support for an aid to navigation.")]
		[EnumMember(Value = "Pile Beacon")] 
		[XmlEnum("5")] 
		PileBeacon = 5,

		[System.ComponentModel.Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
		[EnumMember(Value = "Cairn")] 
		[XmlEnum("6")] 
		Cairn = 6,

		[System.ComponentModel.Description("A tall spar-like beacon fitted with a permanently submerged buoyancy chamber, the lower end of the body is secured to seabed sinker either by a flexible joint or by a cable under tension.")]
		[EnumMember(Value = "Buoyant Beacon")] 
		[XmlEnum("7")] 
		BuoyantBeacon = 7,
	}

	/// <summary>
	/// Classification of radar transponder beacon based on functionality.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadarTransponderBeacon : int {
		[System.ComponentModel.Description("A radar marker beacon which continuously transmits a signal appearing as a radial line on a radar screen, the line indicating the direction of the beacon. Ramarks are intended primarily for marine use. The name 'ramark' is derived from the words radar marker.")]
		[EnumMember(Value = "Ramark, Radar Beacon Transmitting Continuously")] 
		[XmlEnum("1")] 
		RamarkRadarBeaconTransmittingContinuously = 1,

		[System.ComponentModel.Description("A radar beacon which returns a coded signal which provides identification of the beacon, as well as range and bearing. The range and bearing are indicated by the location of the first character received on the radar screen. The name 'racon' is derived from the words radar beacon.")]
		[EnumMember(Value = "Racon, Radar Transponder Beacon")] 
		[XmlEnum("2")] 
		RaconRadarTransponderBeacon = 2,

		[System.ComponentModel.Description("A radar beacon that may be used (in conjunction with at least one other radar beacon) to indicate a leading line.")]
		[EnumMember(Value = "Leading Racon/Radar Transponder Beacon")] 
		[XmlEnum("3")] 
		LeadingRaconRadarTransponderBeacon = 3,
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
		[System.ComponentModel.Description("A radio station which need not necessarily be manned, the emissions of which, radiated around the horizon, enable its bearing to be determined by means of the radio direction finder of a ship.")]
		[EnumMember(Value = "Circular (Non-Directional) Marine or Aero-Marine Radiobeacon")] 
		[XmlEnum("1")] 
		CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,

		[System.ComponentModel.Description("A special type of radiobeacon station the emissions of which are intended to provide a definite track for guidance.")]
		[EnumMember(Value = "Directional Radiobeacon")] 
		[XmlEnum("2")] 
		DirectionalRadiobeacon = 2,

		[System.ComponentModel.Description("A special type of radiobeacon station emitting a beam of waves to which a uniform turning movement is given, the bearing of the station being determined by means of an ordinary listening receiver and a stop watch. Also referred to as a rotating loop radiobeacon.")]
		[EnumMember(Value = "Rotating Pattern Radiobeacon")] 
		[XmlEnum("3")] 
		RotatingPatternRadiobeacon = 3,

		[System.ComponentModel.Description("A type of long range position fixing beacon.")]
		[EnumMember(Value = "Consol Beacon")] 
		[XmlEnum("4")] 
		ConsolBeacon = 4,

		[System.ComponentModel.Description("A radio station intended to determine only the direction of other stations by means of transmission from the latter.")]
		[EnumMember(Value = "Radio Direction-Finding Station")] 
		[XmlEnum("5")] 
		RadioDirectionFindingStation = 5,

		[System.ComponentModel.Description("A radio station which is prepared to provide QTG service; that is to say, to transmit upon request from a ship a radio signal, the bearing of which can be taken by that ship.")]
		[EnumMember(Value = "Coast Radio Station Providing QTG Service")] 
		[XmlEnum("6")] 
		CoastRadioStationProvidingQtgService = 6,

		[System.ComponentModel.Description("A radio beacon designed for aeronautical use.")]
		[EnumMember(Value = "Aeronautical Radiobeacon")] 
		[XmlEnum("7")] 
		AeronauticalRadiobeacon = 7,

		[System.ComponentModel.Description("The Decca Navigator System is a high accuracy, short to medium range radio navigational aid intended for coastal and landfall navigation.")]
		[EnumMember(Value = "Decca")] 
		[XmlEnum("8")] 
		Decca = 8,

		[System.ComponentModel.Description("A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
		[EnumMember(Value = "Loran C")] 
		[XmlEnum("9")] 
		LoranC = 9,

		[System.ComponentModel.Description("A radiobeacon transmitting DGPS correction signals.")]
		[EnumMember(Value = "Differential GNSS")] 
		[XmlEnum("10")] 
		DifferentialGnss = 10,

		[System.ComponentModel.Description("An electronic position fixing system used mainly by aircraft.")]
		[EnumMember(Value = "Toran")] 
		[XmlEnum("11")] 
		Toran = 11,

		[System.ComponentModel.Description("A long-range radio navigational aid which operates within the VLF frequency band. The system comprises eight land based stations.")]
		[EnumMember(Value = "Omega")] 
		[XmlEnum("12")] 
		Omega = 12,

		[System.ComponentModel.Description("A ranging position fixing system operating at 420-450 MHz over a range of up to 400 Km.")]
		[EnumMember(Value = "Syledis")] 
		[XmlEnum("13")] 
		Syledis = 13,

		[System.ComponentModel.Description("Chaika is a low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
		[EnumMember(Value = "Chaika")] 
		[XmlEnum("14")] 
		Chaika = 14,

		[System.ComponentModel.Description("The equipment needed at one station to carry on two way voice communication by radio waves only.")]
		[EnumMember(Value = "Radio Telephone Station")] 
		[XmlEnum("19")] 
		RadioTelephoneStation = 19,

		[System.ComponentModel.Description("An onshore AIS unit that monitors traffic in the waterways.")]
		[EnumMember(Value = "AIS Base Station")] 
		[XmlEnum("20")] 
		AisBaseStation = 20,
	}

	/// <summary>
	/// The specific visibility of a light, with respect to the light's intensity and ease of recognition.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightVisibility : int {
		[System.ComponentModel.Description("Non-marine lights with a higher power than marine lights and visible from well off shore (often 'Aero' lights).")]
		[EnumMember(Value = "High Intensity")] 
		[XmlEnum("1")] 
		HighIntensity = 1,

		[System.ComponentModel.Description("Non-marine lights with lower power than marine lights.")]
		[EnumMember(Value = "Low Intensity")] 
		[XmlEnum("2")] 
		LowIntensity = 2,

		[System.ComponentModel.Description("A decrease in the apparent intensity of a light which may occur in the case of partial obstructions.")]
		[EnumMember(Value = "Faint")] 
		[XmlEnum("3")] 
		Faint = 3,

		[System.ComponentModel.Description("A light in a sector is intensified (that is, has longer range than other sectors).")]
		[EnumMember(Value = "Intensified")] 
		[XmlEnum("4")] 
		Intensified = 4,

		[System.ComponentModel.Description("A light in a sector is unintensified (that is, has shorter range than other sectors).")]
		[EnumMember(Value = "Unintensified")] 
		[XmlEnum("5")] 
		Unintensified = 5,

		[System.ComponentModel.Description("A light sector is deliberately reduced in intensity, for example to reduce its effect on a built-up area.")]
		[EnumMember(Value = "Visibility Deliberately Restricted")] 
		[XmlEnum("6")] 
		VisibilityDeliberatelyRestricted = 6,

		[System.ComponentModel.Description("Said of the arc of a light sector designated by its limiting bearings in which the light is not visible from seaward.")]
		[EnumMember(Value = "Obscured")] 
		[XmlEnum("7")] 
		Obscured = 7,

		[System.ComponentModel.Description("This value specifies that parts of the sector are obscured.")]
		[EnumMember(Value = "Partially Obscured")] 
		[XmlEnum("8")] 
		PartiallyObscured = 8,

		[System.ComponentModel.Description("Lights that must in line to be visible.")]
		[EnumMember(Value = "Visible in Line of Range")] 
		[XmlEnum("9")] 
		VisibleInLineOfRange = 9,
	}

	/// <summary>
	/// The outward display of the light.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum exhibitionConditionOfLight : int {
		[System.ComponentModel.Description("A light shown throughout the 24 hours without change of character.")]
		[EnumMember(Value = "Light Shown Without Change of Character")] 
		[XmlEnum("1")] 
		LightShownWithoutChangeOfCharacter = 1,

		[System.ComponentModel.Description("A light which is only exhibited by day.")]
		[EnumMember(Value = "Daytime Light")] 
		[XmlEnum("2")] 
		DaytimeLight = 2,

		[System.ComponentModel.Description("A light which is exhibited in fog or conditions of reduced visibility.")]
		[EnumMember(Value = "Fog Light")] 
		[XmlEnum("3")] 
		FogLight = 3,

		[System.ComponentModel.Description("A light which is only exhibited at night.")]
		[EnumMember(Value = "Night Light")] 
		[XmlEnum("4")] 
		NightLight = 4,
	}

	/// <summary>
	/// The mechanism used to generate a fog or light signal.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalGeneration : int {
		[System.ComponentModel.Description("Signal generation is initiated by a self regulating mechanism such as a timer or light sensor.")]
		[EnumMember(Value = "Automatically")] 
		[XmlEnum("1")] 
		Automatically = 1,

		[System.ComponentModel.Description("The signal is generated by the motion of the sea surface such as a bell in a buoy.")]
		[EnumMember(Value = "By Wave Action")] 
		[XmlEnum("2")] 
		ByWaveAction = 2,

		[System.ComponentModel.Description("The signal is generated by a manually operated mechanism such as a hand cranked siren.")]
		[EnumMember(Value = "By Hand")] 
		[XmlEnum("3")] 
		ByHand = 3,

		[System.ComponentModel.Description("The signal is generated by the motion of air such as a wind driven whistle.")]
		[EnumMember(Value = "By Wind")] 
		[XmlEnum("4")] 
		ByWind = 4,

		[System.ComponentModel.Description("Activated by radio signal.")]
		[EnumMember(Value = "Radio Activated")] 
		[XmlEnum("5")] 
		RadioActivated = 5,

		[System.ComponentModel.Description("Activated by making a call to a manned station.")]
		[EnumMember(Value = "Call Activated")] 
		[XmlEnum("6")] 
		CallActivated = 6,
	}

	/// <summary>
	/// Classification of different light types.
	/// </summary>
	/// <remarks>
	/// All lights are considered to be marine lights unless the category of light indicates otherwise.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLight : int {
		[System.ComponentModel.Description("A light illuminating a sector of very narrow angle and intended to mark a direction to follow.")]
		[EnumMember(Value = "Directional Function")] 
		[XmlEnum("1")] 
		DirectionalFunction = 1,

		[System.ComponentModel.Description("A light associated with other lights so as to form a leading line to be followed.")]
		[EnumMember(Value = "Leading Light")] 
		[XmlEnum("4")] 
		LeadingLight = 4,

		[System.ComponentModel.Description("An aero light is established for aeronautical navigation and may be of higher power than marine lights and visible from well offshore.")]
		[EnumMember(Value = "Aero Light")] 
		[XmlEnum("5")] 
		AeroLight = 5,

		[System.ComponentModel.Description("A light marking an obstacle which constitutes a danger to air navigation.")]
		[EnumMember(Value = "Air Obstruction Light")] 
		[XmlEnum("6")] 
		AirObstructionLight = 6,

		[System.ComponentModel.Description("A broad beam light used to illuminate a structure or area.")]
		[EnumMember(Value = "Flood Light")] 
		[XmlEnum("8")] 
		FloodLight = 8,

		[System.ComponentModel.Description("A light whose source has a linear form generally horizontal, which can reach a length of several metres.")]
		[EnumMember(Value = "Strip Light")] 
		[XmlEnum("9")] 
		StripLight = 9,

		[System.ComponentModel.Description("A light placed on or near the support of a main light and having a special use in navigation.")]
		[EnumMember(Value = "Subsidiary Light")] 
		[XmlEnum("10")] 
		SubsidiaryLight = 10,

		[System.ComponentModel.Description("A powerful light focused so as to illuminate a small area.")]
		[EnumMember(Value = "Spotlight")] 
		[XmlEnum("11")] 
		Spotlight = 11,

		[System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Front")] 
		[XmlEnum("12")] 
		Front = 12,

		[System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Rear")] 
		[XmlEnum("13")] 
		Rear = 13,

		[System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Lower")] 
		[XmlEnum("14")] 
		Lower = 14,

		[System.ComponentModel.Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Upper")] 
		[XmlEnum("15")] 
		Upper = 15,

		[System.ComponentModel.Description("A light available as a backup to a main light which will be illuminated should the main light fail.")]
		[EnumMember(Value = "Emergency")] 
		[XmlEnum("17")] 
		Emergency = 17,

		[System.ComponentModel.Description("A light which enables its approximate bearing to be obtained without the use of a compass.")]
		[EnumMember(Value = "Bearing Light")] 
		[XmlEnum("18")] 
		BearingLight = 18,

		[System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed horizontally.")]
		[EnumMember(Value = "Horizontally Disposed")] 
		[XmlEnum("19")] 
		HorizontallyDisposed = 19,

		[System.ComponentModel.Description("A group of lights of identical character and almost identical position, that are disposed vertically.")]
		[EnumMember(Value = "Vertically Disposed")] 
		[XmlEnum("20")] 
		VerticallyDisposed = 20,
	}

	/// <summary>
	/// Classification of prominent cultural and natural features in the landscape.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLandmark : int {
		[System.ComponentModel.Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
		[EnumMember(Value = "Cairn")] 
		[XmlEnum("1")] 
		Cairn = 1,

		[System.ComponentModel.Description("A site and associated structures devoted to the burial of the dead.")]
		[EnumMember(Value = "Cemetery")] 
		[XmlEnum("2")] 
		Cemetery = 2,

		[System.ComponentModel.Description("A vertical structure containing a passage or flue for discharging smoke and gases of combustion.")]
		[EnumMember(Value = "Chimney")] 
		[XmlEnum("3")] 
		Chimney = 3,

		[System.ComponentModel.Description("A parabolic aerial for the receipt and transmission of high frequency radio signals.")]
		[EnumMember(Value = "Dish Aerial")] 
		[XmlEnum("4")] 
		DishAerial = 4,

		[System.ComponentModel.Description("A staff or pole on which flags are raised.")]
		[EnumMember(Value = "Flagstaff")] 
		[XmlEnum("5")] 
		Flagstaff = 5,

		[System.ComponentModel.Description("A tall structure used for burning-off waste oil or gas.")]
		[EnumMember(Value = "Flare Stack")] 
		[XmlEnum("6")] 
		FlareStack = 6,

		[System.ComponentModel.Description("A relatively tall structure usually held vertical by guy lines.")]
		[EnumMember(Value = "Mast")] 
		[XmlEnum("7")] 
		Mast = 7,

		[System.ComponentModel.Description("A tapered fabric sleeve mounted so as to catch and swing with the wind, thus indicating the wind direction.")]
		[EnumMember(Value = "Windsock")] 
		[XmlEnum("8")] 
		Windsock = 8,

		[System.ComponentModel.Description("A structure erected and/or maintained as a memorial to a person and/or event.")]
		[EnumMember(Value = "Monument")] 
		[XmlEnum("9")] 
		Monument = 9,

		[System.ComponentModel.Description("A cylindrical or slightly tapering body of considerably greater length than diameter erected vertically.")]
		[EnumMember(Value = "Column/Pillar")] 
		[XmlEnum("10")] 
		ColumnPillar = 10,

		[System.ComponentModel.Description("A slab of metal, usually ornamented, erected as a memorial to a person or event.")]
		[EnumMember(Value = "Memorial Plaque")] 
		[XmlEnum("11")] 
		MemorialPlaque = 11,

		[System.ComponentModel.Description("A tapering shaft usually of stone or concrete, square or rectangular in section, with a pyramidal apex.")]
		[EnumMember(Value = "Obelisk")] 
		[XmlEnum("12")] 
		Obelisk = 12,

		[System.ComponentModel.Description("A representation of a living being, sculptured, moulded, or cast in a variety of materials (for example: marble, metal, or plaster).")]
		[EnumMember(Value = "Statue")] 
		[XmlEnum("13")] 
		Statue = 13,

		[System.ComponentModel.Description("A monument, or other structure in form of a cross.")]
		[EnumMember(Value = "Cross")] 
		[XmlEnum("14")] 
		Cross = 14,

		[System.ComponentModel.Description("A landmark comprising a hemispherical or spheroidal shaped structure.")]
		[EnumMember(Value = "Dome")] 
		[XmlEnum("15")] 
		Dome = 15,

		[System.ComponentModel.Description("A device used for directing a radar beam through a search pattern.")]
		[EnumMember(Value = "Radar Scanner")] 
		[XmlEnum("16")] 
		RadarScanner = 16,

		[System.ComponentModel.Description("A relatively tall, narrow structure that may either stand alone or may form part of another structure.")]
		[EnumMember(Value = "Tower")] 
		[XmlEnum("17")] 
		Tower = 17,

		[System.ComponentModel.Description("A system of vanes attached to a tower and driven by wind (excluding wind turbines).")]
		[EnumMember(Value = "Windmill")] 
		[XmlEnum("18")] 
		Windmill = 18,

		[System.ComponentModel.Description("A modern structure for the use of wind power.")]
		[EnumMember(Value = "Windmotor")] 
		[XmlEnum("19")] 
		Windmotor = 19,

		[System.ComponentModel.Description("A tall conical or pyramid-shaped structure often built on the roof or tower of a building, especially a church or mosque.")]
		[EnumMember(Value = "Spire/Minaret")] 
		[XmlEnum("20")] 
		SpireMinaret = 20,

		[System.ComponentModel.Description("An isolated rocky formation or a single large stone.")]
		[EnumMember(Value = "Large Rock or Boulder on Land")] 
		[XmlEnum("21")] 
		LargeRockOrBoulderOnLand = 21,

		[System.ComponentModel.Description("A recoverable point on the earth, whose geographic position has been determined by angular methods with geodetic instruments. A triangulation point is a selected point, which has been marked with a station mark, or it is a conspicuous natural or artificial feature.")]
		[EnumMember(Value = "Triangulation Mark")] 
		[XmlEnum("22")] 
		TriangulationMark = 22,

		[System.ComponentModel.Description("A marker identifying the location of a surveyed boundary line.")]
		[EnumMember(Value = "Boundary Mark")] 
		[XmlEnum("23")] 
		BoundaryMark = 23,

		[System.ComponentModel.Description("Wheels with passenger cars mounted external to the rim and independently rotated by electric motors.")]
		[EnumMember(Value = "Observation Wheel")] 
		[XmlEnum("24")] 
		ObservationWheel = 24,

		[System.ComponentModel.Description("A form of decorative gateway or portal, consisting of two upright wooden posts connected at the top by two horizontal crosspieces, commonly found at the entrance to Shinto temples.")]
		[EnumMember(Value = "Torii")] 
		[XmlEnum("25")] 
		Torii = 25,

		[System.ComponentModel.Description("A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians.")]
		[EnumMember(Value = "Bridge")] 
		[XmlEnum("26")] 
		Bridge = 26,

		[System.ComponentModel.Description("A barrier to check or confine anything in motion; particularly one constructed to hold back water and raise its level to form a reservoir, or to prevent flooding.")]
		[EnumMember(Value = "Dam")] 
		[XmlEnum("27")] 
		Dam = 27,
	}

	/// <summary>
	/// A specific role that describes a feature.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum function : int {
		[System.ComponentModel.Description("A local official who has charge of mooring and berthing of vessels, collecting harbour fees, etc.")]
		[EnumMember(Value = "Harbour-Masters Office")] 
		[XmlEnum("2")] 
		HarbourMastersOffice = 2,

		[System.ComponentModel.Description("Serves as a government office where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
		[EnumMember(Value = "Customs Office")] 
		[XmlEnum("3")] 
		CustomsOffice = 3,

		[System.ComponentModel.Description("The office which is charged with the administration of health laws and sanitary inspections.")]
		[EnumMember(Value = "Health Office")] 
		[XmlEnum("4")] 
		HealthOffice = 4,

		[System.ComponentModel.Description("An institution or establishment providing medical or surgical treatment for the ill or wounded.")]
		[EnumMember(Value = "Hospital")] 
		[XmlEnum("5")] 
		Hospital = 5,

		[System.ComponentModel.Description("The public department, agency or organisation responsible primarily for the collection, transmission and distribution of mail.")]
		[EnumMember(Value = "Post Office")] 
		[XmlEnum("6")] 
		PostOffice = 6,

		[System.ComponentModel.Description("An establishment, especially of a comfortable or luxurious kind, where paying visitors are provided with accommodation, meals and other services.")]
		[EnumMember(Value = "Hotel")] 
		[XmlEnum("7")] 
		Hotel = 7,

		[System.ComponentModel.Description("A building with platforms where trains arrive, load, discharge and depart.")]
		[EnumMember(Value = "Railway Station")] 
		[XmlEnum("8")] 
		RailwayStation = 8,

		[System.ComponentModel.Description("The headquarters of a local police force and that is where those under arrest are first charged.")]
		[EnumMember(Value = "Police Station")] 
		[XmlEnum("9")] 
		PoliceStation = 9,

		[System.ComponentModel.Description("The headquarters of a local water-police force.")]
		[EnumMember(Value = "Water-Police Station")] 
		[XmlEnum("10")] 
		WaterPoliceStation = 10,

		[System.ComponentModel.Description("The office or headquarters of pilots; the place where the services of a pilot may be obtained.")]
		[EnumMember(Value = "Pilot Office")] 
		[XmlEnum("11")] 
		PilotOffice = 11,

		[System.ComponentModel.Description("A distinctive structure or place on shore from which personnel keep watch upon events at sea or along the coast.")]
		[EnumMember(Value = "Pilot Lookout")] 
		[XmlEnum("12")] 
		PilotLookout = 12,

		[System.ComponentModel.Description("An office for custody, deposit, loan, exchange or issue of money.")]
		[EnumMember(Value = "Bank Office")] 
		[XmlEnum("13")] 
		BankOffice = 13,

		[System.ComponentModel.Description("The quarters of an executive officer (director, manager, etc.) with responsibility for an administrative area.")]
		[EnumMember(Value = "Headquarters for District Control")] 
		[XmlEnum("14")] 
		HeadquartersForDistrictControl = 14,

		[System.ComponentModel.Description("A building or part of a building for storage of wares or goods.")]
		[EnumMember(Value = "Transit Shed/Warehouse")] 
		[XmlEnum("15")] 
		TransitShedWarehouse = 15,

		[System.ComponentModel.Description("A building or buildings with equipment for manufacturing; a workshop.")]
		[EnumMember(Value = "Factory")] 
		[XmlEnum("16")] 
		Factory = 16,

		[System.ComponentModel.Description("A stationary plant containing apparatus for large scale conversion of some form of energy (such as hydraulic, steam, chemical or nuclear energy) into electrical energy.")]
		[EnumMember(Value = "Power Station")] 
		[XmlEnum("17")] 
		PowerStation = 17,

		[System.ComponentModel.Description("A building for the management of affairs.")]
		[EnumMember(Value = "Administrative")] 
		[XmlEnum("18")] 
		Administrative = 18,

		[System.ComponentModel.Description("A building concerned with education (for example school, college, university, etc).")]
		[EnumMember(Value = "Educational Facility")] 
		[XmlEnum("19")] 
		EducationalFacility = 19,

		[System.ComponentModel.Description("A building for public Christian worship.")]
		[EnumMember(Value = "Church")] 
		[XmlEnum("20")] 
		Church = 20,

		[System.ComponentModel.Description("A place for Christian worship other than a parish, cathedral or church, especially one attached to a private house or institution.")]
		[EnumMember(Value = "Chapel")] 
		[XmlEnum("21")] 
		Chapel = 21,

		[System.ComponentModel.Description("A building for public Jewish worship.")]
		[EnumMember(Value = "Temple")] 
		[XmlEnum("22")] 
		Temple = 22,

		[System.ComponentModel.Description("A Hindu or Buddhist temple or sacred building.")]
		[EnumMember(Value = "Pagoda")] 
		[XmlEnum("23")] 
		Pagoda = 23,

		[System.ComponentModel.Description("A building for public Shinto worship.")]
		[EnumMember(Value = "Shinto Shrine")] 
		[XmlEnum("24")] 
		ShintoShrine = 24,

		[System.ComponentModel.Description("A building for public Buddhist worship.")]
		[EnumMember(Value = "Buddhist Temple")] 
		[XmlEnum("25")] 
		BuddhistTemple = 25,

		[System.ComponentModel.Description("A Muslim place of worship.")]
		[EnumMember(Value = "Mosque")] 
		[XmlEnum("26")] 
		Mosque = 26,

		[System.ComponentModel.Description("A shrine marking the burial place of a Muslim holy man.")]
		[EnumMember(Value = "Marabout")] 
		[XmlEnum("27")] 
		Marabout = 27,

		[System.ComponentModel.Description("Keeping a watch upon events at sea or along the coast.")]
		[EnumMember(Value = "Lookout")] 
		[XmlEnum("28")] 
		Lookout = 28,

		[System.ComponentModel.Description("Transmitting and/or receiving electronic communication signals.")]
		[EnumMember(Value = "Communication")] 
		[XmlEnum("29")] 
		Communication = 29,

		[System.ComponentModel.Description("A system for reproducing on a screen visual images transmitted (usually with sound) by radio signals.")]
		[EnumMember(Value = "Television")] 
		[XmlEnum("30")] 
		Television = 30,

		[System.ComponentModel.Description("Transmitting and/or receiving radio-frequency electromagnetic waves as a means of communication.")]
		[EnumMember(Value = "Radio")] 
		[XmlEnum("31")] 
		Radio = 31,

		[System.ComponentModel.Description("A method, system or technique of using beamed, reflected, and timed radio waves for detecting, locating, or tracking objects, and for measuring altitudes.")]
		[EnumMember(Value = "Radar")] 
		[XmlEnum("32")] 
		Radar = 32,

		[System.ComponentModel.Description("A structure serving as a support for one or more lights.")]
		[EnumMember(Value = "Light Support")] 
		[XmlEnum("33")] 
		LightSupport = 33,

		[System.ComponentModel.Description("Broadcasting and receiving signals using microwaves.")]
		[EnumMember(Value = "Microwave")] 
		[XmlEnum("34")] 
		Microwave = 34,

		[System.ComponentModel.Description("Generation of chilled liquid and/or gas for cooling purposes.")]
		[EnumMember(Value = "Cooling")] 
		[XmlEnum("35")] 
		Cooling = 35,

		[System.ComponentModel.Description("A place from which the surroundings can be observed but at which a watch is not habitually maintained.")]
		[EnumMember(Value = "Observation")] 
		[XmlEnum("36")] 
		Observation = 36,

		[System.ComponentModel.Description("A visual time signal in the form of a ball.")]
		[EnumMember(Value = "Timeball")] 
		[XmlEnum("37")] 
		Timeball = 37,

		[System.ComponentModel.Description("Instrument for measuring time and recording hours.")]
		[EnumMember(Value = "Clock")] 
		[XmlEnum("38")] 
		Clock = 38,

		[System.ComponentModel.Description("Used to control the flow of traffic within a specified range of an installation.")]
		[EnumMember(Value = "Control")] 
		[XmlEnum("39")] 
		Control = 39,

		[System.ComponentModel.Description("Equipment or structure to secure an airship.")]
		[EnumMember(Value = "Airship Mooring")] 
		[XmlEnum("40")] 
		AirshipMooring = 40,

		[System.ComponentModel.Description("An arena for holding and viewing events.")]
		[EnumMember(Value = "Stadium")] 
		[XmlEnum("41")] 
		Stadium = 41,

		[System.ComponentModel.Description("A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.")]
		[EnumMember(Value = "Bus Station")] 
		[XmlEnum("42")] 
		BusStation = 42,

		[System.ComponentModel.Description("A building within a terminal for the loading and unloading of passengers.")]
		[EnumMember(Value = "Passenger Terminal Building")] 
		[XmlEnum("43")] 
		PassengerTerminalBuilding = 43,

		[System.ComponentModel.Description("A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.")]
		[EnumMember(Value = "Sea Rescue Control")] 
		[XmlEnum("44")] 
		SeaRescueControl = 44,

		[System.ComponentModel.Description("A building designed and equipped for making observations of astronomical, meteorological, or other natural phenomena.")]
		[EnumMember(Value = "Observatory")] 
		[XmlEnum("45")] 
		Observatory = 45,

		[System.ComponentModel.Description("A building or structure used to crush ore.")]
		[EnumMember(Value = "Ore Crusher")] 
		[XmlEnum("46")] 
		OreCrusher = 46,

		[System.ComponentModel.Description("A building or shed, usually built partly over water, for sheltering a boat or boats.")]
		[EnumMember(Value = "Boathouse")] 
		[XmlEnum("47")] 
		Boathouse = 47,

		[System.ComponentModel.Description("A facility to move solids, liquids or gases by means of pressure or suction.")]
		[EnumMember(Value = "Pumping Station")] 
		[XmlEnum("48")] 
		PumpingStation = 48,

		[System.ComponentModel.Description("A roof that is extending above navigable water, e.g. to protect open cargo holds from rain during loading and unloading. Depending on the vertical clearance vessels can pass under the roof above navigable water.")]
		[EnumMember(Value = "Roof Above Navigable Water")] 
		[XmlEnum("49")] 
		RoofAboveNavigableWater = 49,

		[System.ComponentModel.Description("The part of a building on land that is extending above navigable water. Depending on the vertical clearance vessels can pass under the building above navigable water.")]
		[EnumMember(Value = "Building Above Navigable Water")] 
		[XmlEnum("50")] 
		BuildingAboveNavigableWater = 50,
	}

	/// <summary>
	/// The distinct character, such as fixed, flashing, or occulting, which is given to each light to avoid confusion with neighbouring ones.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightCharacteristic : int {
		[System.ComponentModel.Description("A signal light that shows continuously, in any given direction, with constant luminous intensity and colour.")]
		[EnumMember(Value = "Fixed")] 
		[XmlEnum("1")] 
		Fixed = 1,

		[System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
		[EnumMember(Value = "Flashing")] 
		[XmlEnum("2")] 
		Flashing = 2,

		[System.ComponentModel.Description("A single-flashing light in which a single flash of not less than two seconds duration is regularly repeated.")]
		[EnumMember(Value = "Long-Flashing")] 
		[XmlEnum("3")] 
		LongFlashing = 3,

		[System.ComponentModel.Description("A rhythmic light in which flashes are repeated at a rate of not less than 50 flashes per minutes but less than 80 flashes per minutes. It may be: - Continuous quick-flashing: A quick-flashing light in which a flash is regularly repeated. - Group quick-flashing: A quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
		[EnumMember(Value = "Quick-Flashing")] 
		[XmlEnum("4")] 
		QuickFlashing = 4,

		[System.ComponentModel.Description("A rhythmic light in which flashes are repeated at a rate of not less than 80 flashes per minute but less than 160 flashes per minute. It may be:- Continuous very quick-flashing: A very quick-flashing light in which a flash is regularly repeated.- Group very quick-flashing: A very quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
		[EnumMember(Value = "Very Quick-Flashing")] 
		[XmlEnum("5")] 
		VeryQuickFlashing = 5,

		[System.ComponentModel.Description("A rhythmic light in which flashes are regularly repeated at a rate of not less than 160 flashes per minute.")]
		[EnumMember(Value = "Continuous Ultra Quick-Flashing")] 
		[XmlEnum("6")] 
		ContinuousUltraQuickFlashing = 6,

		[System.ComponentModel.Description("A light with all durations of light and darkness equal.")]
		[EnumMember(Value = "Isophased")] 
		[XmlEnum("7")] 
		Isophased = 7,

		[System.ComponentModel.Description("A rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration. It may be:  - Single-occulting: An occulting light in which an eclipse is regularly repeated.  - Group-occulting: An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated.  - Composite group-occulting: An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.")]
		[EnumMember(Value = "Occulting")] 
		[XmlEnum("8")] 
		Occulting = 8,

		[System.ComponentModel.Description("A quick light in which the sequence of flashes is interrupted by regularly repeated eclipses of constant and long duration.")]
		[EnumMember(Value = "Interrupted Quick Flashing")] 
		[XmlEnum("9")] 
		InterruptedQuickFlashing = 9,

		[System.ComponentModel.Description("A light in which the very rapid alterations of light and darkness are interrupted at regular intervals by eclipses of long duration.")]
		[EnumMember(Value = "Interrupted Very Quick Flashing")] 
		[XmlEnum("10")] 
		InterruptedVeryQuickFlashing = 10,

		[System.ComponentModel.Description("A light in which the ultra quick flashes (160 or more per minute) are interrupted at regular intervals by eclipses of long duration.")]
		[EnumMember(Value = "Interrupted Ultra Quick-Flashing")] 
		[XmlEnum("11")] 
		InterruptedUltraQuickFlashing = 11,

		[System.ComponentModel.Description("A rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.")]
		[EnumMember(Value = "Morse")] 
		[XmlEnum("12")] 
		Morse = 12,

		[System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Fixed and Flash")] 
		[XmlEnum("13")] 
		FixedAndFlash = 13,

		[System.ComponentModel.Description("A rhythmic light in which a flashing light is combined with a long-flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Flash and Long-Flash")] 
		[XmlEnum("14")] 
		FlashAndLongFlash = 14,

		[System.ComponentModel.Description("A rhythmic light in which an occulting light is combined with a flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Occulting and Flash")] 
		[XmlEnum("15")] 
		OccultingAndFlash = 15,

		[System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a long-flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Fixed and Long-Flash")] 
		[XmlEnum("16")] 
		FixedAndLongFlash = 16,

		[System.ComponentModel.Description("An alternating light in which the total duration of light in each period is clearly longer than the total duration of darkness and in which the intervals of darkness (occultations) are all of equal duration.")]
		[EnumMember(Value = "Occulting Alternating")] 
		[XmlEnum("17")] 
		OccultingAlternating = 17,

		[System.ComponentModel.Description("An alternating single-flashing light in which an appearance of light of not less than two seconds duration is regularly repeated.")]
		[EnumMember(Value = "Long-Flash Alternating")] 
		[XmlEnum("18")] 
		LongFlashAlternating = 18,

		[System.ComponentModel.Description("An alternating rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
		[EnumMember(Value = "Flash Alternating")] 
		[XmlEnum("19")] 
		FlashAlternating = 19,

		[System.ComponentModel.Description("Occulting light in which the occultations are combined in groups, each group including the same number of occultations, and in which the groups are repeated at regular intervals.")]
		[EnumMember(Value = "Group Alternating")] 
		[XmlEnum("20")] 
		GroupAlternating = 20,

		[System.ComponentModel.Description("A rhythmic light in which a group of quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Quick-Flash Plus Long-Flash")] 
		[XmlEnum("25")] 
		QuickFlashPlusLongFlash = 25,

		[System.ComponentModel.Description("A rhythmic light in which a group of very quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Very Quick-Flash Plus Long-Flash")] 
		[XmlEnum("26")] 
		VeryQuickFlashPlusLongFlash = 26,

		[System.ComponentModel.Description("A rhythmic light in which a group of ultra quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Ultra Quick-Flash Plus Long-Flash")] 
		[XmlEnum("27")] 
		UltraQuickFlashPlusLongFlash = 27,

		[System.ComponentModel.Description("A signal light that shows, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Alternating")] 
		[XmlEnum("28")] 
		Alternating = 28,

		[System.ComponentModel.Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity and different colour.")]
		[EnumMember(Value = "Fixed and Alternating Flashing")] 
		[XmlEnum("29")] 
		FixedAndAlternatingFlashing = 29,
	}

	/// <summary>
	/// The indication of an element of a signal sequence being a period of light/sound or eclipse/silence.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalStatus : int {
		[System.ComponentModel.Description("The indication of an element of a signal sequence being a period of light or sound.")]
		[EnumMember(Value = "Lit/Sound")] 
		[XmlEnum("1")] 
		LitSound = 1,

		[System.ComponentModel.Description("The indication of an element of a signal sequence being a period of eclipse or silence.")]
		[EnumMember(Value = "Eclipsed/Silent")] 
		[XmlEnum("2")] 
		EclipsedSilent = 2,
	}

	/// <summary>
	/// Named aggregations between two or more aids to navigation and/or navigationally relevant features.
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Serializable()]
	public class CategoryOfAggregation
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	/// <summary>
	/// Named associations between two or more aids to navigation and/or navigationally relevant features.
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Serializable()]
	public class CategoryOfAssociation
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	public static class CodeList
	{
		public static ImmutableArray<CategoryOfAggregation> CategoryOfAggregations => ImmutableArray.Create<CategoryOfAggregation>(new CategoryOfAggregation[]{
			new() {
				code = 1,
				definition = "-",
				label = "leading line ",
			},
			new() {
				code = 3,
				definition = "-",
				label = "measured distance ",
			},
			new() {
				code = 2,
				definition = "-",
				label = "range system ",
			},
		});

		public static ImmutableArray<CategoryOfAssociation> CategoryOfAssociations => ImmutableArray.Create<CategoryOfAssociation>(new CategoryOfAssociation[]{
			new() {
				code = 1,
				definition = "A group of channel marks which indicate channel limits.",
				label = "Channel Markings",
			},
			new() {
				code = 2,
				definition = "One of more aids to navigation and the danger(s) that are marked.",
				label = "Danger Markings",
			},
		});
	}

	namespace ComplexAttributes {
		/// <summary>
		/// The best estimate of the accuracy of a position.
		/// </summary>
		/// <remarks>
		/// The expected input is the maximum of the two-dimensional error. The error is assumed to be positive and negative.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty : ComplexType {
			[XmlElement("uncertaintyFixed")]
			[Mandatory]
			public double uncertaintyFixed {get;set;} = default;

			[XmlElement("uncertaintyVariableFactor")]
			[Optional]
			public double? uncertaintyVariableFactor {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
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
		/// The best estimate of the vertical accuracy of depths, heights, vertical distances and vertical clearances.
		/// </summary>
		/// <remarks>
		/// Encodes the vertical uncertainty associated with any vertical measurement.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalUncertainty : ComplexType {
			[XmlElement("uncertaintyFixed")]
			[Mandatory]
			public double uncertaintyFixed {get;set;} = default;

			[XmlElement("uncertaintyVariableFactor")]
			[Optional]
			public double? uncertaintyVariableFactor {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<verticalUncertainty, bool>> _conditionalUnknown = new Dictionary<string,Func<verticalUncertainty, bool>> {
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
			[XmlElement("fileLocator")]
			[Optional]
			public String? fileLocator {get;set;} = default;

			[XmlElement("fileReference")]
			[Optional]
			public String? fileReference {get;set;} = default;

			[XmlElement("headline")]
			[Optional]
			public String? headline {get;set;} = default;

			[XmlElement("language")]
			[Mandatory]
			public String language {get;set;} = string.Empty;

			[XmlElement("text")]
			[Optional]
			public String? text {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializefileLocator() { return !string.IsNullOrEmpty(fileLocator); }

			public bool ShouldSerializefileReference() { return !string.IsNullOrEmpty(fileReference); }

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }
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
		/// The number of features of identical character that exist as a colocated group.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class multiplicityOfFeatures : ComplexType {
			[XmlElement("multiplicityKnown")]
			[Mandatory]
			public Boolean multiplicityKnown {get;set;} = false;

			[XmlElement("numberOfFeatures")]
			[Optional]
			public int? numberOfFeatures {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializenumberOfFeatures() { return numberOfFeatures.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<multiplicityOfFeatures, bool>> _conditionalUnknown = new Dictionary<string,Func<multiplicityOfFeatures, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The angular distance measured from true north to the major axis of the feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation : ComplexType {
			[XmlElement("orientationUncertainty")]
			[Optional]
			public double? orientationUncertainty {get;set;} = default;

			[XmlElement("orientationValue")]
			[Mandatory]
			public double orientationValue {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<orientation, bool>> _conditionalUnknown = new Dictionary<string,Func<orientation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The active period of a recurring event or occurrence.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange : ComplexType {
			[XmlElement("dateEnd")]
			[Mandatory]
			public String dateEnd {get;set;} = string.Empty;

			[XmlElement("dateStart")]
			[Mandatory]
			public String dateStart {get;set;} = string.Empty;

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<periodicDateRange, bool>> _conditionalUnknown = new Dictionary<string,Func<periodicDateRange, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The distance between two successive peaks (or other points of identical phase) on an electromagnetic wave in the radar band of the electromagnetic spectrum.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class radarWaveLength : ComplexType {
			[XmlElement("radarBand")]
			[Mandatory]
			public String radarBand {get;set;} = string.Empty;

			[XmlElement("waveLengthValue")]
			[Mandatory]
			public double waveLengthValue {get;set;} = default;

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<radarWaveLength, bool>> _conditionalUnknown = new Dictionary<string,Func<radarWaveLength, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Additional textual information about a light sector.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorInformation : ComplexType {
			[XmlElement("language")]
			[Optional]
			public String? language {get;set;} = default;

			[XmlElement("text")]
			[Mandatory]
			public String text {get;set;} = string.Empty;

			#region ShouldSerialize
			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<sectorInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<sectorInformation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit one specifies the first limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne : ComplexType {
			[XmlElement("sectorBearing")]
			[Mandatory]
			public double sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			[Optional]
			public double? sectorLineLength {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<sectorLimitOne, bool>> _conditionalUnknown = new Dictionary<string,Func<sectorLimitOne, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. Sector limit two specifies the second limit of the sector. The order of sector limit one and sector limit two is clockwise around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo : ComplexType {
			[XmlElement("sectorBearing")]
			[Mandatory]
			public double sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			[Optional]
			public double? sectorLineLength {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<sectorLimitTwo, bool>> _conditionalUnknown = new Dictionary<string,Func<sectorLimitTwo, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The sequence of times occupied by intervals of light and eclipse for all light characteristics.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class signalSequence : ComplexType {
			[XmlElement("signalDuration")]
			[Mandatory]
			public double signalDuration {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2])]
			[Mandatory]
			public signalStatus signalStatus {get;set;}

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("signalStatus")]
			public SerializableEnumeration<signalStatus> signalStatusElement { get { return signalStatus; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<signalSequence, bool>> _conditionalUnknown = new Dictionary<string,Func<signalSequence, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// -
		/// </summary>
		/// <remarks>
		/// -
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class ChangeDetails : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public atonCommissioning? atonCommissioning {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			[Optional]
			public atonRemoval? atonRemoval {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			[Optional]
			public atonReplacement? atonReplacement {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			[Optional]
			public fixedAtonChange? fixedAtonChange {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26])]
			[Optional]
			public floatingAtonChange? floatingAtonChange {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public audibleSignalAtonChange? audibleSignalAtonChange {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
			[Optional]
			public lightedAtonChange? lightedAtonChange {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30])]
			[Optional]
			public electronicAtonChange? electronicAtonChange {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializeatonCommissioning() { return atonCommissioning.HasValue; }

			public bool ShouldSerializeatonRemoval() { return atonRemoval.HasValue; }

			public bool ShouldSerializeatonReplacement() { return atonReplacement.HasValue; }

			public bool ShouldSerializefixedAtonChange() { return fixedAtonChange.HasValue; }

			public bool ShouldSerializefloatingAtonChange() { return floatingAtonChange.HasValue; }

			public bool ShouldSerializeaudibleSignalAtonChange() { return audibleSignalAtonChange.HasValue; }

			public bool ShouldSerializelightedAtonChange() { return lightedAtonChange.HasValue; }

			public bool ShouldSerializeelectronicAtonChange() { return electronicAtonChange.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("atonCommissioning")]
			public SerializableEnumeration<atonCommissioning>? atonCommissioningElement { get { return atonCommissioning; } set { } }

			[JsonIgnore]
			[XmlElement("atonRemoval")]
			public SerializableEnumeration<atonRemoval>? atonRemovalElement { get { return atonRemoval; } set { } }

			[JsonIgnore]
			[XmlElement("atonReplacement")]
			public SerializableEnumeration<atonReplacement>? atonReplacementElement { get { return atonReplacement; } set { } }

			[JsonIgnore]
			[XmlElement("fixedAtonChange")]
			public SerializableEnumeration<fixedAtonChange>? fixedAtonChangeElement { get { return fixedAtonChange; } set { } }

			[JsonIgnore]
			[XmlElement("floatingAtonChange")]
			public SerializableEnumeration<floatingAtonChange>? floatingAtonChangeElement { get { return floatingAtonChange; } set { } }

			[JsonIgnore]
			[XmlElement("audibleSignalAtonChange")]
			public SerializableEnumeration<audibleSignalAtonChange>? audibleSignalAtonChangeElement { get { return audibleSignalAtonChange; } set { } }

			[JsonIgnore]
			[XmlElement("lightedAtonChange")]
			public SerializableEnumeration<lightedAtonChange>? lightedAtonChangeElement { get { return lightedAtonChange; } set { } }

			[JsonIgnore]
			[XmlElement("electronicAtonChange")]
			public SerializableEnumeration<electronicAtonChange>? electronicAtonChangeElement { get { return electronicAtonChange; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<ChangeDetails, bool>> _conditionalUnknown = new Dictionary<string,Func<ChangeDetails, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A directional light is a light illuminating a sector of very narrow angle and intended to mark a direction to follow.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class directionalCharacter : ComplexType {
			[XmlElement("moireEffect")]
			[Optional]
			public Boolean? moireEffect {get;set;} = default;

			[XmlElement("orientation")]
			[Mandatory]
			public orientation orientation {get;set;} = new orientation {
				orientationValue = default,
			};

			#region ShouldSerialize
			public bool ShouldSerializemoireEffect() { return moireEffect.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<directionalCharacter, bool>> _conditionalUnknown = new Dictionary<string,Func<directionalCharacter, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The sequence of times occupied by intervals of light/sound and eclipse/silence for all light characteristics or sound signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rhythmOfLight : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,25,26,27,28,29])]
			[Mandatory]
			public lightCharacteristic lightCharacteristic {get;set;}

			[XmlElement("signalGroup")]
			[Multiplicity(0, 10)]
			public List<String> signalGroup {get;set;} = [];

			[XmlElement("signalPeriod")]
			[Optional]
			public double? signalPeriod {get;set;} = default;

			[XmlElement("signalSequence")]
			[Multiplicity(0, 10)]
			public List<signalSequence> signalSequence {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializesignalGroup() { return signalGroup.Any(); }

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			public bool ShouldSerializesignalSequence() { return signalSequence.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("lightCharacteristic")]
			public SerializableEnumeration<lightCharacteristic> lightCharacteristicElement { get { return lightCharacteristic; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<rhythmOfLight, bool>> _conditionalUnknown = new Dictionary<string,Func<rhythmOfLight, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference. The sector limit specifies the limits of the sector In a clockwise direction around the central feature (for example a light).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimit : ComplexType {
			[XmlElement("sectorLimitOne")]
			[Mandatory]
			public sectorLimitOne sectorLimitOne {get;set;} = new sectorLimitOne {
				sectorBearing = default,
			};

			[XmlElement("sectorLimitTwo")]
			[Mandatory]
			public sectorLimitTwo sectorLimitTwo {get;set;} = new sectorLimitTwo {
				sectorBearing = default,
			};

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<sectorLimit, bool>> _conditionalUnknown = new Dictionary<string,Func<sectorLimit, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lightSector : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1, 99)]
			public List<colour> colour {get;set;} = [];

			[XmlElement("directionalCharacter")]
			[Optional]
			public directionalCharacter? directionalCharacter {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Multiplicity(0, 99)]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			[XmlElement("sectorLimit")]
			[Optional]
			public sectorLimit? sectorLimit {get;set;} = default;

			[XmlElement("valueOfNominalRange")]
			[Optional]
			public double? valueOfNominalRange {get;set;} = default;

			[XmlElement("sectorInformation")]
			[Multiplicity(0, 99)]
			public List<sectorInformation> sectorInformation {get;set;} = [];

			[XmlElement("sectorArcExtension")]
			[Optional]
			public Boolean? sectorArcExtension {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializedirectionalCharacter() { return directionalCharacter!=default; }

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			public bool ShouldSerializesectorLimit() { return sectorLimit!=default; }

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public bool ShouldSerializesectorInformation() { return sectorInformation.Any(); }

			public bool ShouldSerializesectorArcExtension() { return sectorArcExtension.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("lightVisibility")]
			public SerializableEnumeration<lightVisibility>[] lightVisibilityElement { get { return [.. lightVisibility]; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<lightSector, bool>> _conditionalUnknown = new Dictionary<string,Func<lightSector, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Describes the characteristics of a light sector.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorCharacteristics : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,25,26,27,28,29])]
			[Mandatory]
			public lightCharacteristic lightCharacteristic {get;set;}

			[XmlElement("lightSector")]
			[Multiplicity(1, 10)]
			public List<lightSector> lightSector {get;set;} = [];

			[XmlElement("signalGroup")]
			[Multiplicity(0, 10)]
			public List<String> signalGroup {get;set;} = [];

			[XmlElement("signalPeriod")]
			[Optional]
			public double? signalPeriod {get;set;} = default;

			[XmlElement("signalSequence")]
			[Multiplicity(0, 10)]
			public List<signalSequence> signalSequence {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializelightSector() { return lightSector.Any(); }

			public bool ShouldSerializesignalGroup() { return signalGroup.Any(); }

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			public bool ShouldSerializesignalSequence() { return signalSequence.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("lightCharacteristic")]
			public SerializableEnumeration<lightCharacteristic> lightCharacteristicElement { get { return lightCharacteristic; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<sectorCharacteristics, bool>> _conditionalUnknown = new Dictionary<string,Func<sectorCharacteristics, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// -
		/// </summary>
		/// <remarks>
		/// -
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class ObscuredSector : ComplexType {
			[XmlElement("sectorLimit")]
			[Mandatory]
			public sectorLimit sectorLimit {get;set;} = new sectorLimit {
				sectorLimitOne = new sectorLimitOne {
							sectorBearing = default,
						},
				sectorLimitTwo = new sectorLimitTwo {
							sectorBearing = default,
						},
			};

			[XmlElement("sectorInformation")]
			[Optional]
			public sectorInformation? sectorInformation {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializesectorInformation() { return sectorInformation!=default; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<ObscuredSector, bool>> _conditionalUnknown = new Dictionary<string,Func<ObscuredSector, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

	}
	public enum Role {
		[System.ComponentModel.Description("-")]
		parent,
		[System.ComponentModel.Description("-")]
		child,
		[System.ComponentModel.Description("-")]
		virtualAISbroadcastBy,
		[System.ComponentModel.Description("-")]
		syntheticAISbroadcastBy,
		[System.ComponentModel.Description("-")]
		physicalAISbroadcastBy,
		[System.ComponentModel.Description("-")]
		peerAtonAggregation,
		[System.ComponentModel.Description("-")]
		peerAtonAssociation,
		[System.ComponentModel.Description("The role given to the navigable part of the navigation line.")]
		navigableTrack,
		[System.ComponentModel.Description("A signal or message warning of the presence of a danger to navigation.")]
		danger,
		[System.ComponentModel.Description("-")]
		topmarkPart,
		[System.ComponentModel.Description("-")]
		Statuspart,
		[System.ComponentModel.Description("-")]
		virtualAISbroadcasts,
		[System.ComponentModel.Description("-")]
		syntheticAISbroadcasts,
		[System.ComponentModel.Description("-")]
		physicalAISbroadcasts,
		[System.ComponentModel.Description("-")]
		atonAggregationBy,
		[System.ComponentModel.Description("-")]
		atonAssociationBy,
		[System.ComponentModel.Description("The role given to the navigation line(s) that is generally formed between two or more objects, or by one object and a bearing.")]
		navigationLine,
		[System.ComponentModel.Description("-")]
		markingAton,
		[System.ComponentModel.Description("-")]
		buoyPart,
	}

	namespace InformationAssociations {
		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Atonstatus : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Atonstatus);
		}
	}

	namespace FeatureAssociations {
		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BuoyTopmark : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BuoyTopmark);
		}

		/// <summary>
		/// A feature association for the binding between a navigation aid equipment feature and the structure that supports it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StructureEquipment : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(StructureEquipment);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalAIS : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PhysicalAIS);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SyntheticAIS : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SyntheticAIS);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VirtualAIS : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(VirtualAIS);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAggregations : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AtonAggregations);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAssociations : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AtonAssociations);
		}

		/// <summary>
		/// Navigation system limited in their positioning capability to coastal regions, or those systems limited to making landfall
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RangeSystem : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RangeSystem);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DangerousFeatureAssociation : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DangerousFeatureAssociation);
		}
	}

}

namespace S100Framework.DomainModel.S125 {
	using ComplexAttributes;
	using InformationAssociations;
		using System.Xml.Linq;

	namespace InformationTypes {
		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonStatusInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("ChangeDetails")]
			[Mandatory]
			public ChangeDetails ChangeDetails {get;set;} = new ChangeDetails {
			};

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public ChangeTypes? ChangeTypes {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeChangeTypes() { return ChangeTypes.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("ChangeTypes")]
			public SerializableEnumeration<ChangeTypes>? ChangeTypesElement { get { return ChangeTypes; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AtonStatusInformation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtonStatusInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<AtonStatusInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<AtonStatusInformation, bool>> {
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
		/// A visual, acoustical, or radio device, external to a ship, designed to assist in determining a safe course or a vessel's position, or to warn of dangers and/or obstructions. Aids to navigation usually include buoys, beacons, fog signals, lights, radio beacons, leading marks, radio position fixing systems and GNSS which are chart-related and assist safe navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class AidsToNavigation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("iDCode")]
			[Optional]
			public String? iDCode {get;set;} = default;

			[XmlElement("interoperabilityIdentifier")]
			[Mandatory]
			public String interoperabilityIdentifier {get;set;} = string.Empty;

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];

			[XmlElement("featureName")]
			[Optional]
			public List<featureName> featureName {get;set;} = [];

			[XmlElement("scaleMinimum")]
			[Optional]
			public int? scaleMinimum {get;set;} = default;

			[XmlIgnore]
			[Optional]
			public DateOnly? sourceDate {get;set;} = default;

			[XmlElement("source")]
			[Optional]
			public String? source {get;set;} = default;

			[XmlElement("pictorialRepresentation")]
			[Optional]
			public String? pictorialRepresentation {get;set;} = default;

			[XmlIgnore]
			[Optional]
			public DateOnly? installationDate {get;set;} = default;

			[XmlElement("fixedDateRange")]
			[Optional]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			[XmlElement("periodicDateRange")]
			[Optional]
			public periodicDateRange? periodicDateRange {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeiDCode() { return !string.IsNullOrEmpty(iDCode); }

			public bool ShouldSerializeinformation() { return information.Any(); }

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public bool ShouldSerializesourceDate() { return sourceDate.HasValue; }

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public bool ShouldSerializeinstallationDate() { return installationDate.HasValue; }

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange!=default; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AidsToNavigation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AidsToNavigation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(Atonstatus),
					role = Enum.GetName<Role>(Role.Statuspart)!,
					informationTypes = [nameof(AtonStatusInformation)],
					primitives = [],
				},
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AidsToNavigation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AidsToNavigation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonAggregations),
					role = Enum.GetName<Role>(Role.peerAtonAggregation)!,
					featureTypes = [nameof(AtonAggregation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonAssociations),
					role = Enum.GetName<Role>(Role.peerAtonAssociation)!,
					featureTypes = [nameof(AtonAssociation)],
				},
			];
			#endregion
		}

		/// <summary>
		/// The implements used in an operation or activity.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Equipment : AidsToNavigation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Equipment);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..Equipment._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..Equipment._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Equipment._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.parent)!,
					featureTypes = [nameof(StructureObject)],
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

			private IReadOnlyDictionary<string, Func<Equipment, bool>> _conditionalUnknown = new Dictionary<string,Func<Equipment, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationLine : AidsToNavigation {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Mandatory]
			public categoryOfNavigationLine categoryOfNavigationLine {get;set;}

			[XmlElement("orientation")]
			[Mandatory]
			public orientation orientation {get;set;} = new orientation {
				orientationValue = default,
			};

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfNavigationLine")]
			public SerializableEnumeration<categoryOfNavigationLine> categoryOfNavigationLineElement { get { return categoryOfNavigationLine; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavigationLine);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..NavigationLine._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..NavigationLine._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..NavigationLine._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RangeSystem),
					role = Enum.GetName<Role>(Role.navigableTrack)!,
					featureTypes = [nameof(RecommendedTrack)],
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

			private IReadOnlyDictionary<string, Func<NavigationLine, bool>> _conditionalUnknown = new Dictionary<string,Func<NavigationLine, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A route which has been specially examined to ensure so far as possible that it is free of dangers and along which ships are advised to navigate.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RecommendedTrack : AidsToNavigation {
			[XmlElement("basedOnFixedMarks")]
			[Mandatory]
			public Boolean basedOnFixedMarks {get;set;} = false;

			[XmlElement("depthRangeMinimumValue")]
			[Optional]
			public double? depthRangeMinimumValue {get;set;} = default;

			[XmlElement("maximalPermittedDraught")]
			[Optional]
			public double? maximalPermittedDraught {get;set;} = default;

			[XmlElement("orientation")]
			[Mandatory]
			public orientation orientation {get;set;} = new orientation {
				orientationValue = default,
			};

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			[Optional]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[XmlElement("verticalUncertainty")]
			[Optional]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18])]
			[Optional]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Mandatory]
			public trafficFlow trafficFlow {get;set;}

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializedepthRangeMinimumValue() { return depthRangeMinimumValue.HasValue; }

			public bool ShouldSerializemaximalPermittedDraught() { return maximalPermittedDraught.HasValue; }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>[] qualityOfVerticalMeasurementElement { get { return [.. qualityOfVerticalMeasurement]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			[JsonIgnore]
			[XmlElement("trafficFlow")]
			public SerializableEnumeration<trafficFlow> trafficFlowElement { get { return trafficFlow; } set { } }

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RecommendedTrack);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..RecommendedTrack._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..RecommendedTrack._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..RecommendedTrack._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(RangeSystem),
					role = Enum.GetName<Role>(Role.navigationLine)!,
					featureTypes = [nameof(NavigationLine)],
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

			private IReadOnlyDictionary<string, Func<RecommendedTrack, bool>> _conditionalUnknown = new Dictionary<string,Func<RecommendedTrack, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Daymark : Equipment {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			[Optional]
			public categoryOfSpecialPurposeMark? categoryOfSpecialPurposeMark {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
			[Mandatory]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}

			[XmlElement("orientation")]
			[Optional]
			public orientation? orientation {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.HasValue; }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeorientation() { return orientation!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfSpecialPurposeMark")]
			public SerializableEnumeration<categoryOfSpecialPurposeMark>? categoryOfSpecialPurposeMarkElement { get { return categoryOfSpecialPurposeMark; } set { } }

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("topmarkDaymarkShape")]
			public SerializableEnumeration<topmarkDaymarkShape> topmarkDaymarkShapeElement { get { return topmarkDaymarkShape; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Daymark);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..Daymark._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..Daymark._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..Daymark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Daymark, bool>> _conditionalUnknown = new Dictionary<string,Func<Daymark, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// Something (such as a house, tower, bridge, etc.) that is built by putting parts together and that usually stands on its own.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StructureObject : AidsToNavigation {
			[XmlElement("AtoNNumber")]
			[Mandatory]
			public String AtoNNumber {get;set;} = string.Empty;


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(StructureObject);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..StructureObject._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..StructureObject._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..StructureObject._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.child)!,
					featureTypes = [nameof(Equipment)],
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

			private IReadOnlyDictionary<string, Func<StructureObject, bool>> _conditionalUnknown = new Dictionary<string,Func<StructureObject, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A warning signal transmitted by a vessel, or aid to navigation, during periods of low visibility. Also, the device producing such a signal.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FogSignal : Equipment {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			[Mandatory]
			public categoryOfFogSignal categoryOfFogSignal {get;set;}

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("signalSequence")]
			[Optional]
			public signalSequence? signalSequence {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializesignalSequence() { return signalSequence!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfFogSignal")]
			public SerializableEnumeration<categoryOfFogSignal> categoryOfFogSignalElement { get { return categoryOfFogSignal; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FogSignal);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..FogSignal._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..FogSignal._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..FogSignal._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<FogSignal, bool>> _conditionalUnknown = new Dictionary<string,Func<FogSignal, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A device capable of, or intended for, reflecting radar signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarReflector : Equipment {
			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadarReflector);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..RadarReflector._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..RadarReflector._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadarReflector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<RadarReflector, bool>> _conditionalUnknown = new Dictionary<string,Func<RadarReflector, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A fixed artificial navigation mark that can be recognized by its shape, colour, pattern, topmark or light character, or a combination of these. It may carry various additional aids to navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class GenericBeacon : StructureObject {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			[Mandatory]
			public beaconShape beaconShape {get;set;}

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,9,10,11,12,13,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("beaconShape")]
			public SerializableEnumeration<beaconShape> beaconShapeElement { get { return beaconShape; } set { } }

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(GenericBeacon);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..GenericBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..GenericBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..GenericBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<GenericBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<GenericBeacon, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A transponder beacon transmitting a coded signal on radar frequency, permitting an interrogating craft to determine the bearing and range of the transponder.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarTransponderBeacon : Equipment {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Mandatory]
			public categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon {get;set;}

			[XmlElement("radarWaveLength")]
			[Optional]
			public radarWaveLength? radarWaveLength {get;set;} = default;

			[XmlElement("sectorLimitOne")]
			[Optional]
			public sectorLimitOne? sectorLimitOne {get;set;} = default;

			[XmlElement("sectorLimitTwo")]
			[Optional]
			public sectorLimitTwo? sectorLimitTwo {get;set;} = default;

			[XmlElement("signalGroup")]
			[Optional]
			public String? signalGroup {get;set;} = default;

			[XmlElement("signalSequence")]
			[Optional]
			public signalSequence? signalSequence {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("valueOfNominalRange")]
			[Optional]
			public double? valueOfNominalRange {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeradarWaveLength() { return radarWaveLength!=default; }

			public bool ShouldSerializesectorLimitOne() { return sectorLimitOne!=default; }

			public bool ShouldSerializesectorLimitTwo() { return sectorLimitTwo!=default; }

			public bool ShouldSerializesignalGroup() { return !string.IsNullOrEmpty(signalGroup); }

			public bool ShouldSerializesignalSequence() { return signalSequence!=default; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfRadarTransponderBeacon")]
			public SerializableEnumeration<categoryOfRadarTransponderBeacon> categoryOfRadarTransponderBeaconElement { get { return categoryOfRadarTransponderBeacon; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadarTransponderBeacon);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..RadarTransponderBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..RadarTransponderBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadarTransponderBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<RadarTransponderBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<RadarTransponderBeacon, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioStation : Equipment {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,19,20])]
			[Mandatory]
			public categoryOfRadioStation categoryOfRadioStation {get;set;}

			[XmlElement("estimatedRangeOfTransmission")]
			[Optional]
			public double? estimatedRangeOfTransmission {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeestimatedRangeOfTransmission() { return estimatedRangeOfTransmission.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfRadioStation")]
			public SerializableEnumeration<categoryOfRadioStation> categoryOfRadioStationElement { get { return categoryOfRadioStation; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioStation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..RadioStation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..RadioStation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadioStation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(PhysicalAIS),
					role = Enum.GetName<Role>(Role.physicalAISbroadcastBy)!,
					featureTypes = [nameof(PhysicalAISAidToNavigation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(SyntheticAIS),
					role = Enum.GetName<Role>(Role.syntheticAISbroadcastBy)!,
					featureTypes = [nameof(SyntheticAISAidToNavigation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(VirtualAIS),
					role = Enum.GetName<Role>(Role.virtualAISbroadcastBy)!,
					featureTypes = [nameof(VirtualAISAidToNavigation)],
				},
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<RadioStation, bool>> _conditionalUnknown = new Dictionary<string,Func<RadioStation, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A means of distinguishing unlighted marks at night. Retro-reflective material is secured to the mark in a particular pattern to reflect back light.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Retroreflector : Equipment {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,9,10,11,12,13,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Retroreflector);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..Retroreflector._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..Retroreflector._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..Retroreflector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Retroreflector, bool>> _conditionalUnknown = new Dictionary<string,Func<Retroreflector, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBeacon : GenericBeacon {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Mandatory]
			public categoryOfCardinalMark categoryOfCardinalMark {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfCardinalMark")]
			public SerializableEnumeration<categoryOfCardinalMark> categoryOfCardinalMarkElement { get { return categoryOfCardinalMark; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CardinalBeacon);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..CardinalBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..CardinalBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..CardinalBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<CardinalBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<CardinalBeacon, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBeacon : GenericBeacon {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(IsolatedDangerBeacon);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..IsolatedDangerBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..IsolatedDangerBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..IsolatedDangerBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<IsolatedDangerBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<IsolatedDangerBeacon, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A prominent object at a fixed location on land which can be used in determining a location or a direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Landmark : StructureObject {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			[Multiplicity(1)]
			public List<categoryOfLandmark> categoryOfLandmark {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Mandatory]
			public visualProminence visualProminence {get;set;}

			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50])]
			[Optional]
			public List<function> function {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfLandmark() { return categoryOfLandmark.Any(); }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializefunction() { return function.Any(); }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeheight() { return height.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfLandmark")]
			public SerializableEnumeration<categoryOfLandmark>[] categoryOfLandmarkElement { get { return [.. categoryOfLandmark]; } set { } }

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence> visualProminenceElement { get { return visualProminence; } set { } }

			[JsonIgnore]
			[XmlElement("function")]
			public SerializableEnumeration<function>[] functionElement { get { return [.. function]; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Landmark);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..Landmark._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..Landmark._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Landmark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Landmark, bool>> _conditionalUnknown = new Dictionary<string,Func<Landmark, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBeacon : GenericBeacon {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			[Mandatory]
			public categoryOfLateralMark categoryOfLateralMark {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfLateralMark")]
			public SerializableEnumeration<categoryOfLateralMark> categoryOfLateralMarkElement { get { return categoryOfLateralMark; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LateralBeacon);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..LateralBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..LateralBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..LateralBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<LateralBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<LateralBeacon, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A distinctive structure on or off a coast exhibiting a major light designed to serve as an aid to navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Lighthouse : Landmark {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Lighthouse);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Landmark._informationBindingDefinitions, ..Lighthouse._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Landmark._featureBindingDefinitions, ..Lighthouse._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Landmark._primitives, ..Lighthouse._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Lighthouse, bool>> _conditionalUnknown = new Dictionary<string,Func<Lighthouse, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A safe water beacon is used to indicate that there is navigable water around the mark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBeacon : GenericBeacon {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SafeWaterBeacon);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..SafeWaterBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..SafeWaterBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..SafeWaterBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<SafeWaterBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<SafeWaterBeacon, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBeacon : GenericBeacon {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			[Multiplicity(1)]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfSpecialPurposeMark")]
			public SerializableEnumeration<categoryOfSpecialPurposeMark>[] categoryOfSpecialPurposeMarkElement { get { return [.. categoryOfSpecialPurposeMark]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBeacon);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..SpecialPurposeGeneralBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..SpecialPurposeGeneralBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..SpecialPurposeGeneralBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<SpecialPurposeGeneralBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<SpecialPurposeGeneralBeacon, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DangerousFeature : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];

			[XmlElement("interoperabilityIdentifier")]
			[Optional]
			public String? interoperabilityIdentifier {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeinformation() { return information.Any(); }

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DangerousFeature);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DangerousFeature._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DangerousFeature._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DangerousFeature._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(DangerousFeatureAssociation),
					role = Enum.GetName<Role>(Role.markingAton)!,
					featureTypes = [nameof(AtonAssociation)],
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

			private IReadOnlyDictionary<string, Func<DangerousFeature, bool>> _conditionalUnknown = new Dictionary<string,Func<DangerousFeature, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Used to identify an association between two or more objects. The association may be named content of categoryOfAssociation should be put in information attribute when converting to S-57
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAssociation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("CategoryOfAssociation")]
			[EnumerationValue([1,2])]
			[Mandatory]
			public CategoryOfAssociation CategoryOfAssociation {get;set;} = default;


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AtonAssociation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtonAssociation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AtonAssociation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AtonAssociation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DangerousFeatureAssociation),
					role = Enum.GetName<Role>(Role.danger)!,
					featureTypes = [nameof(DangerousFeature)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonAssociations),
					role = Enum.GetName<Role>(Role.atonAssociationBy)!,
					featureTypes = [nameof(AidsToNavigation)],
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

			private IReadOnlyDictionary<string, Func<AtonAssociation, bool>> _conditionalUnknown = new Dictionary<string,Func<AtonAssociation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAggregation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("CategoryOfAggregation")]
			[EnumerationValue([1,3,2])]
			[Mandatory]
			public CategoryOfAggregation CategoryOfAggregation {get;set;} = default;


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AtonAggregation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtonAggregation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AtonAggregation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AtonAggregation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonAggregations),
					role = Enum.GetName<Role>(Role.atonAggregationBy)!,
					featureTypes = [nameof(AidsToNavigation)],
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

			private IReadOnlyDictionary<string, Func<AtonAggregation, bool>> _conditionalUnknown = new Dictionary<string,Func<AtonAggregation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// TBD
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class ElectronicAton : AidsToNavigation {
			[XmlElement("AtoNNumber")]
			[Optional]
			public String? AtoNNumber {get;set;} = default;

			[XmlElement("mMSICode")]
			[Mandatory]
			public String mMSICode {get;set;} = string.Empty;

			[XmlIgnore]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeAtoNNumber() { return !string.IsNullOrEmpty(AtoNNumber); }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ElectronicAton);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..ElectronicAton._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..ElectronicAton._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..ElectronicAton._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericLight : Equipment {
			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("effectiveIntensity")]
			[Optional]
			public double? effectiveIntensity {get;set;} = default;

			[XmlElement("peakIntensity")]
			[Optional]
			public double? peakIntensity {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeeffectiveIntensity() { return effectiveIntensity.HasValue; }

			public bool ShouldSerializepeakIntensity() { return peakIntensity.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(GenericLight);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..GenericLight._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..GenericLight._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..GenericLight._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion
		}

		/// <summary>
		/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Topmark : AidsToNavigation {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
			[Mandatory]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("topmarkDaymarkShape")]
			public SerializableEnumeration<topmarkDaymarkShape> topmarkDaymarkShapeElement { get { return topmarkDaymarkShape; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Topmark);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..Topmark._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..Topmark._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Topmark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(BuoyTopmark),
					role = Enum.GetName<Role>(Role.buoyPart)!,
					featureTypes = [nameof(GenericBuoy)],
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

			private IReadOnlyDictionary<string, Func<Topmark, bool>> _conditionalUnknown = new Dictionary<string,Func<Topmark, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalAISAidToNavigation : ElectronicAton {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Mandatory]
			public CategoryOfPhysicalAISAidToNavigation CategoryOfPhysicalAISAidToNavigation {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("CategoryOfPhysicalAISAidToNavigation")]
			public SerializableEnumeration<CategoryOfPhysicalAISAidToNavigation> CategoryOfPhysicalAISAidToNavigationElement { get { return CategoryOfPhysicalAISAidToNavigation; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PhysicalAISAidToNavigation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ElectronicAton._informationBindingDefinitions, ..PhysicalAISAidToNavigation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ElectronicAton._featureBindingDefinitions, ..PhysicalAISAidToNavigation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..PhysicalAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PhysicalAIS),
					role = Enum.GetName<Role>(Role.physicalAISbroadcasts)!,
					featureTypes = [nameof(RadioStation)],
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

			private IReadOnlyDictionary<string, Func<PhysicalAISAidToNavigation, bool>> _conditionalUnknown = new Dictionary<string,Func<PhysicalAISAidToNavigation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station located remotely from the intended physical Aid to Navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SyntheticAISAidToNavigation : ElectronicAton {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			[Mandatory]
			public CategoryOfSyntheticAISAidtoNavigation CategoryOfSyntheticAISAidtoNavigation {get;set;}

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Mandatory]
			public virtualAISAidToNavigationType virtualAISAidToNavigationType {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("CategoryOfSyntheticAISAidtoNavigation")]
			public SerializableEnumeration<CategoryOfSyntheticAISAidtoNavigation> CategoryOfSyntheticAISAidtoNavigationElement { get { return CategoryOfSyntheticAISAidtoNavigation; } set { } }

			[JsonIgnore]
			[XmlElement("virtualAISAidToNavigationType")]
			public SerializableEnumeration<virtualAISAidToNavigationType> virtualAISAidToNavigationTypeElement { get { return virtualAISAidToNavigationType; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SyntheticAISAidToNavigation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ElectronicAton._informationBindingDefinitions, ..SyntheticAISAidToNavigation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ElectronicAton._featureBindingDefinitions, ..SyntheticAISAidToNavigation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..SyntheticAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(SyntheticAIS),
					role = Enum.GetName<Role>(Role.syntheticAISbroadcasts)!,
					featureTypes = [nameof(RadioStation)],
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

			private IReadOnlyDictionary<string, Func<SyntheticAISAidToNavigation, bool>> _conditionalUnknown = new Dictionary<string,Func<SyntheticAISAidToNavigation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}
		/// <summary>
		/// A floating object moored to the bottom in a particular (charted) place, as an aid to navigation or for other specific purposes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class GenericBuoy : StructureObject {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Mandatory]
			public buoyShape buoyShape {get;set;}

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,9,10,11,12,13,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("typeOfBuoy")]
			[Optional]
			public String? typeOfBuoy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializetypeOfBuoy() { return !string.IsNullOrEmpty(typeOfBuoy); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("buoyShape")]
			public SerializableEnumeration<buoyShape> buoyShapeElement { get { return buoyShape; } set { } }

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(GenericBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..GenericBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..GenericBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..GenericBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BuoyTopmark),
					role = Enum.GetName<Role>(Role.topmarkPart)!,
					featureTypes = [nameof(Topmark)],
				},
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<GenericBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<GenericBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A long heavy timber or section of steel, wood, concrete, etc., forced into the earth or sea floor to serve as a support, as for a pier, or to resist lateral pressure; or as a free standing pole within a marine environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Pile : StructureObject {
			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,8])]
			[Optional]
			public categoryOfPile? categoryOfPile {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfPile() { return categoryOfPile.HasValue; }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializeheight() { return height.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfPile")]
			public SerializableEnumeration<categoryOfPile>? categoryOfPileElement { get { return categoryOfPile; } set { } }

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Pile);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..Pile._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..Pile._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Pile._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Pile, bool>> _conditionalUnknown = new Dictionary<string,Func<Pile, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A large storage structure used for storing loose materials, liquids and/or gases.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SiloTank : StructureObject {
			[XmlIgnore]
			[EnumerationValue([5,6,7,8,9])]
			[Optional]
			public buildingShape? buildingShape {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public categoryOfSiloTank? categoryOfSiloTank {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializebuildingShape() { return buildingShape.HasValue; }

			public bool ShouldSerializecategoryOfSiloTank() { return categoryOfSiloTank.HasValue; }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeheight() { return height.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("buildingShape")]
			public SerializableEnumeration<buildingShape>? buildingShapeElement { get { return buildingShape; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfSiloTank")]
			public SerializableEnumeration<categoryOfSiloTank>? categoryOfSiloTankElement { get { return categoryOfSiloTank; } set { } }

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SiloTank);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..SiloTank._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..SiloTank._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..SiloTank._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<SiloTank, bool>> _conditionalUnknown = new Dictionary<string,Func<SiloTank, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A cardinal buoy is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBuoy : GenericBuoy {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Mandatory]
			public categoryOfCardinalMark categoryOfCardinalMark {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfCardinalMark")]
			public SerializableEnumeration<categoryOfCardinalMark> categoryOfCardinalMarkElement { get { return categoryOfCardinalMark; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CardinalBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..CardinalBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..CardinalBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..CardinalBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<CardinalBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<CardinalBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// An emergency wreck marking buoy is a buoy moored on or above a new wreck, designed to provide a prominent (both visual and radio) and easily identifiable temporary first response.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class EmergencyWreckMarkingBuoy : GenericBuoy {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(EmergencyWreckMarkingBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..EmergencyWreckMarkingBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..EmergencyWreckMarkingBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..EmergencyWreckMarkingBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<EmergencyWreckMarkingBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<EmergencyWreckMarkingBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// An installation buoy is a buoy used for loading tankers with gas or oil.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InstallationBuoy : GenericBuoy {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			[Mandatory]
			public categoryOfInstallationBuoy categoryOfInstallationBuoy {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfInstallationBuoy")]
			public SerializableEnumeration<categoryOfInstallationBuoy> categoryOfInstallationBuoyElement { get { return categoryOfInstallationBuoy; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InstallationBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..InstallationBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..InstallationBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..InstallationBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<InstallationBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<InstallationBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// An isolated danger buoy is a buoy moored on or above an isolated danger of limited extent, which has navigable water all around it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBuoy : GenericBuoy {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(IsolatedDangerBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..IsolatedDangerBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..IsolatedDangerBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..IsolatedDangerBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<IsolatedDangerBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<IsolatedDangerBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well-defined channels and are used in conjunction with a conventional direction of buoyage.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBuoy : GenericBuoy {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			[Mandatory]
			public categoryOfLateralMark categoryOfLateralMark {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfLateralMark")]
			public SerializableEnumeration<categoryOfLateralMark> categoryOfLateralMarkElement { get { return categoryOfLateralMark; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LateralBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..LateralBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..LateralBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..LateralBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<LateralBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<LateralBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFloat : StructureObject {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightFloat);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..LightFloat._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..LightFloat._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..LightFloat._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<LightFloat, bool>> _conditionalUnknown = new Dictionary<string,Func<LightFloat, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A distinctively marked vessel anchored or moored at a charted point, to serve as an aid to navigation. By night, it displays a characteristic light(s) and is usually equipped with other devices, such as fog signal, submarine sound signal, and radio-beacon, to assist navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightVessel : StructureObject {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightVessel);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..LightVessel._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..LightVessel._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..LightVessel._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<LightVessel, bool>> _conditionalUnknown = new Dictionary<string,Func<LightVessel, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringBuoy : GenericBuoy {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MooringBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..MooringBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..MooringBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..MooringBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<MooringBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<MooringBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A permanent offshore structure, either fixed or floating.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OffshorePlatform : StructureObject {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			[Optional]
			public List<categoryOfOffshorePlatform> categoryOfOffshorePlatform {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5])]
			[Optional]
			public condition? condition {get;set;} = default;

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfOffshorePlatform() { return categoryOfOffshorePlatform.Any(); }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfOffshorePlatform")]
			public SerializableEnumeration<categoryOfOffshorePlatform>[] categoryOfOffshorePlatformElement { get { return [.. categoryOfOffshorePlatform]; } set { } }

			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("colourPattern")]
			public SerializableEnumeration<colourPattern>[] colourPatternElement { get { return [.. colourPattern]; } set { } }

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(OffshorePlatform);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..OffshorePlatform._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..OffshorePlatform._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..OffshorePlatform._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<OffshorePlatform, bool>> _conditionalUnknown = new Dictionary<string,Func<OffshorePlatform, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A safe water buoy is used to indicate that there is navigable water around the mark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBuoy : GenericBuoy {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SafeWaterBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..SafeWaterBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..SafeWaterBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..SafeWaterBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<SafeWaterBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<SafeWaterBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBuoy : GenericBuoy {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			[Multiplicity(1)]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfSpecialPurposeMark")]
			public SerializableEnumeration<categoryOfSpecialPurposeMark>[] categoryOfSpecialPurposeMarkElement { get { return [.. categoryOfSpecialPurposeMark]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..SpecialPurposeGeneralBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..SpecialPurposeGeneralBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..SpecialPurposeGeneralBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<SpecialPurposeGeneralBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<SpecialPurposeGeneralBuoy, bool>> {
			};

			public override void RunValidationChecks() {
				base.RunValidationChecks();
			}
			#endregion
		}

		/// <summary>
		/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VirtualAISAidToNavigation : ElectronicAton {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Mandatory]
			public virtualAISAidToNavigationType virtualAISAidToNavigationType {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("virtualAISAidToNavigationType")]
			public SerializableEnumeration<virtualAISAidToNavigationType> virtualAISAidToNavigationTypeElement { get { return virtualAISAidToNavigationType; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(VirtualAISAidToNavigation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ElectronicAton._informationBindingDefinitions, ..VirtualAISAidToNavigation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ElectronicAton._featureBindingDefinitions, ..VirtualAISAidToNavigation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..VirtualAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(VirtualAIS),
					role = Enum.GetName<Role>(Role.virtualAISbroadcasts)!,
					featureTypes = [nameof(RadioStation)],
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

			private IReadOnlyDictionary<string, Func<VirtualAISAidToNavigation, bool>> _conditionalUnknown = new Dictionary<string,Func<VirtualAISAidToNavigation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAirObstruction : GenericLight {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			[XmlElement("valueOfNominalRange")]
			[Optional]
			public double? valueOfNominalRange {get;set;} = default;

			[XmlElement("flareBearing")]
			[Optional]
			public int? flareBearing {get;set;} = default;

			[XmlElement("multiplicityOfFeatures")]
			[Optional]
			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[XmlElement("rhythmOfLight")]
			[Mandatory]
			public rhythmOfLight rhythmOfLight {get;set;} = new rhythmOfLight {
				lightCharacteristic = Enum.GetValues<lightCharacteristic>()[0],
			};


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("lightVisibility")]
			public SerializableEnumeration<lightVisibility>[] lightVisibilityElement { get { return [.. lightVisibility]; } set { } }

			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>? exhibitionConditionOfLightElement { get { return exhibitionConditionOfLight; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightAirObstruction);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericLight._informationBindingDefinitions, ..LightAirObstruction._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericLight._featureBindingDefinitions, ..LightAirObstruction._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightAirObstruction._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
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

			private IReadOnlyDictionary<string, Func<LightAirObstruction, bool>> _conditionalUnknown = new Dictionary<string,Func<LightAirObstruction, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAllAround : GenericLight {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			[Optional]
			public signalGeneration? signalGeneration {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,9,10,11,12,13,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlElement("majorLight")]
			[Optional]
			public Boolean? majorLight {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public lightVisibility? lightVisibility {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
			[Optional]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[XmlElement("valueOfNominalRange")]
			[Optional]
			public double? valueOfNominalRange {get;set;} = default;

			[XmlElement("multiplicityOfFeatures")]
			[Optional]
			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[XmlElement("rhythmOfLight")]
			[Mandatory]
			public rhythmOfLight rhythmOfLight {get;set;} = new rhythmOfLight {
				lightCharacteristic = Enum.GetValues<lightCharacteristic>()[0],
			};


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializemajorLight() { return majorLight.HasValue; }

			public bool ShouldSerializelightVisibility() { return lightVisibility.HasValue; }

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("signalGeneration")]
			public SerializableEnumeration<signalGeneration>? signalGenerationElement { get { return signalGeneration; } set { } }

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			[JsonIgnore]
			[XmlElement("lightVisibility")]
			public SerializableEnumeration<lightVisibility>? lightVisibilityElement { get { return lightVisibility; } set { } }

			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>? exhibitionConditionOfLightElement { get { return exhibitionConditionOfLight; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfLight")]
			public SerializableEnumeration<categoryOfLight>[] categoryOfLightElement { get { return [.. categoryOfLight]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightAllAround);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericLight._informationBindingDefinitions, ..LightAllAround._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericLight._featureBindingDefinitions, ..LightAllAround._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightAllAround._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
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

			private IReadOnlyDictionary<string, Func<LightAllAround, bool>> _conditionalUnknown = new Dictionary<string,Func<LightAllAround, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFogDetector : GenericLight {
			[XmlElement("rhythmOfLight")]
			[Mandatory]
			public rhythmOfLight rhythmOfLight {get;set;} = new rhythmOfLight {
				lightCharacteristic = Enum.GetValues<lightCharacteristic>()[0],
			};

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			[Optional]
			public signalGeneration? signalGeneration {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("signalGeneration")]
			public SerializableEnumeration<signalGeneration>? signalGenerationElement { get { return signalGeneration; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightFogDetector);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericLight._informationBindingDefinitions, ..LightFogDetector._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericLight._featureBindingDefinitions, ..LightFogDetector._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightFogDetector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
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

			private IReadOnlyDictionary<string, Func<LightFogDetector, bool>> _conditionalUnknown = new Dictionary<string,Func<LightFogDetector, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightSectored : GenericLight {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			[Optional]
			public signalGeneration? signalGeneration {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,9,10,11,12,13,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
			[Optional]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[XmlElement("sectorCharacteristics")]
			[Multiplicity(1)]
			public List<sectorCharacteristics> sectorCharacteristics {get;set;} = [];

			[XmlElement("multiplicityOfFeatures")]
			[Optional]
			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			public bool ShouldSerializesectorCharacteristics() { return sectorCharacteristics.Any(); }

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("signalGeneration")]
			public SerializableEnumeration<signalGeneration>? signalGenerationElement { get { return signalGeneration; } set { } }

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>? exhibitionConditionOfLightElement { get { return exhibitionConditionOfLight; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfLight")]
			public SerializableEnumeration<categoryOfLight>[] categoryOfLightElement { get { return [.. categoryOfLight]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightSectored);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericLight._informationBindingDefinitions, ..LightSectored._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericLight._featureBindingDefinitions, ..LightSectored._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightSectored._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
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

			private IReadOnlyDictionary<string, Func<LightSectored, bool>> _conditionalUnknown = new Dictionary<string,Func<LightSectored, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S125/0.0")]
	[XmlRoot(Namespace = "http://www.iho.int/S125/0.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S125/0.0 125_0.0.4 with FIHO_FIXES 2025-10-03.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S125/0.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.AtonStatusInformation", typeof(InformationTypes.AtonStatusInformation), Order = 1, ElementName = "AtonStatusInformation")]
		[XmlElement("FeatureTypes.Equipment", typeof(FeatureTypes.Equipment), Order = 1, ElementName = "Equipment")]
		[XmlElement("FeatureTypes.GenericBuoy", typeof(FeatureTypes.GenericBuoy), Order = 1, ElementName = "GenericBuoy")]
		[XmlElement("FeatureTypes.Pile", typeof(FeatureTypes.Pile), Order = 1, ElementName = "Pile")]
		[XmlElement("FeatureTypes.SiloTank", typeof(FeatureTypes.SiloTank), Order = 1, ElementName = "SiloTank")]
		[XmlElement("FeatureTypes.CardinalBuoy", typeof(FeatureTypes.CardinalBuoy), Order = 1, ElementName = "CardinalBuoy")]
		[XmlElement("FeatureTypes.EmergencyWreckMarkingBuoy", typeof(FeatureTypes.EmergencyWreckMarkingBuoy), Order = 1, ElementName = "EmergencyWreckMarkingBuoy")]
		[XmlElement("FeatureTypes.InstallationBuoy", typeof(FeatureTypes.InstallationBuoy), Order = 1, ElementName = "InstallationBuoy")]
		[XmlElement("FeatureTypes.IsolatedDangerBuoy", typeof(FeatureTypes.IsolatedDangerBuoy), Order = 1, ElementName = "IsolatedDangerBuoy")]
		[XmlElement("FeatureTypes.LateralBuoy", typeof(FeatureTypes.LateralBuoy), Order = 1, ElementName = "LateralBuoy")]
		[XmlElement("FeatureTypes.LightFloat", typeof(FeatureTypes.LightFloat), Order = 1, ElementName = "LightFloat")]
		[XmlElement("FeatureTypes.LightVessel", typeof(FeatureTypes.LightVessel), Order = 1, ElementName = "LightVessel")]
		[XmlElement("FeatureTypes.MooringBuoy", typeof(FeatureTypes.MooringBuoy), Order = 1, ElementName = "MooringBuoy")]
		[XmlElement("FeatureTypes.OffshorePlatform", typeof(FeatureTypes.OffshorePlatform), Order = 1, ElementName = "OffshorePlatform")]
		[XmlElement("FeatureTypes.SafeWaterBuoy", typeof(FeatureTypes.SafeWaterBuoy), Order = 1, ElementName = "SafeWaterBuoy")]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBuoy", typeof(FeatureTypes.SpecialPurposeGeneralBuoy), Order = 1, ElementName = "SpecialPurposeGeneralBuoy")]
		[XmlElement("FeatureTypes.NavigationLine", typeof(FeatureTypes.NavigationLine), Order = 1, ElementName = "NavigationLine")]
		[XmlElement("FeatureTypes.RecommendedTrack", typeof(FeatureTypes.RecommendedTrack), Order = 1, ElementName = "RecommendedTrack")]
		[XmlElement("FeatureTypes.VirtualAISAidToNavigation", typeof(FeatureTypes.VirtualAISAidToNavigation), Order = 1, ElementName = "VirtualAISAidToNavigation")]
		[XmlElement("FeatureTypes.Daymark", typeof(FeatureTypes.Daymark), Order = 1, ElementName = "Daymark")]
		[XmlElement("FeatureTypes.StructureObject", typeof(FeatureTypes.StructureObject), Order = 1, ElementName = "StructureObject")]
		[XmlElement("FeatureTypes.FogSignal", typeof(FeatureTypes.FogSignal), Order = 1, ElementName = "FogSignal")]
		[XmlElement("FeatureTypes.RadarReflector", typeof(FeatureTypes.RadarReflector), Order = 1, ElementName = "RadarReflector")]
		[XmlElement("FeatureTypes.GenericBeacon", typeof(FeatureTypes.GenericBeacon), Order = 1, ElementName = "GenericBeacon")]
		[XmlElement("FeatureTypes.RadarTransponderBeacon", typeof(FeatureTypes.RadarTransponderBeacon), Order = 1, ElementName = "RadarTransponderBeacon")]
		[XmlElement("FeatureTypes.RadioStation", typeof(FeatureTypes.RadioStation), Order = 1, ElementName = "RadioStation")]
		[XmlElement("FeatureTypes.LightAirObstruction", typeof(FeatureTypes.LightAirObstruction), Order = 1, ElementName = "LightAirObstruction")]
		[XmlElement("FeatureTypes.Retroreflector", typeof(FeatureTypes.Retroreflector), Order = 1, ElementName = "Retroreflector")]
		[XmlElement("FeatureTypes.LightAllAround", typeof(FeatureTypes.LightAllAround), Order = 1, ElementName = "LightAllAround")]
		[XmlElement("FeatureTypes.LightFogDetector", typeof(FeatureTypes.LightFogDetector), Order = 1, ElementName = "LightFogDetector")]
		[XmlElement("FeatureTypes.LightSectored", typeof(FeatureTypes.LightSectored), Order = 1, ElementName = "LightSectored")]
		[XmlElement("FeatureTypes.CardinalBeacon", typeof(FeatureTypes.CardinalBeacon), Order = 1, ElementName = "CardinalBeacon")]
		[XmlElement("FeatureTypes.IsolatedDangerBeacon", typeof(FeatureTypes.IsolatedDangerBeacon), Order = 1, ElementName = "IsolatedDangerBeacon")]
		[XmlElement("FeatureTypes.Landmark", typeof(FeatureTypes.Landmark), Order = 1, ElementName = "Landmark")]
		[XmlElement("FeatureTypes.LateralBeacon", typeof(FeatureTypes.LateralBeacon), Order = 1, ElementName = "LateralBeacon")]
		[XmlElement("FeatureTypes.Lighthouse", typeof(FeatureTypes.Lighthouse), Order = 1, ElementName = "Lighthouse")]
		[XmlElement("FeatureTypes.SafeWaterBeacon", typeof(FeatureTypes.SafeWaterBeacon), Order = 1, ElementName = "SafeWaterBeacon")]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBeacon", typeof(FeatureTypes.SpecialPurposeGeneralBeacon), Order = 1, ElementName = "SpecialPurposeGeneralBeacon")]
		[XmlElement("FeatureTypes.DangerousFeature", typeof(FeatureTypes.DangerousFeature), Order = 1, ElementName = "DangerousFeature")]
		[XmlElement("FeatureTypes.AtonAssociation", typeof(FeatureTypes.AtonAssociation), Order = 1, ElementName = "AtonAssociation")]
		[XmlElement("FeatureTypes.AtonAggregation", typeof(FeatureTypes.AtonAggregation), Order = 1, ElementName = "AtonAggregation")]
		[XmlElement("FeatureTypes.Topmark", typeof(FeatureTypes.Topmark), Order = 1, ElementName = "Topmark")]
		[XmlElement("FeatureTypes.PhysicalAISAidToNavigation", typeof(FeatureTypes.PhysicalAISAidToNavigation), Order = 1, ElementName = "PhysicalAISAidToNavigation")]
		[XmlElement("FeatureTypes.SyntheticAISAidToNavigation", typeof(FeatureTypes.SyntheticAISAidToNavigation), Order = 1, ElementName = "SyntheticAISAidToNavigation")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
