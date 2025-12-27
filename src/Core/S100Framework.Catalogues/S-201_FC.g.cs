using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S201 {
	public class Summary : ISummary
	{
		public static string Name => "Aids to Navigation(AtoN) Information";
		public static string Scope => "Aton";
		public static string ProductId => "S-201";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-05-19", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["contactAddress","directionalCharacter","featureName","fixedDateRange","lightSector","multiplicityOfFeatures","orientation","periodicDateRange","radarWaveLength","rhythmOfLight","sectorCharacteristics","sectorInformation","sectorLimit","sectorLimitOne","sectorLimitTwo","shapeInformation","signalSequence","spatialAccuracy","CableDimensions","ChangeDetails","ObscuredSector","sinkerDimensions","positioningMethod","horizontalPositionUncertainty","information","textualDescription","verticalUncertainty"];
		public static string[] InformationAssociationTypes => ["Atonstatus","AtonFixingMethodAssociation","AtonPositioningInformationAssociation"];
		public static string[] FeatureAssociationTypes => ["BuoyTopmark","StructureEquipment","PhysicalAIS","SyntheticAIS","VirtualAIS","BuoyCounterWeight","BridleConnection","ShackleConnection","ShackleConnectionFromCable","SwivelCableConnection","BridleCableConnection","ShackleToBridleConnection","ShackleToSwivelConnection","ShackleToAnchorConnection","SwivelConnection","AtonAggregations","AtonAssociations","RangeSystem","DangerousFeatureAssociation"];
		public static string[] InformationTypes => ["AtoNFixingMethod","AtonStatusInformation","PositioningInformation","SpatialQuality"];
		public static string[] FeatureTypes => ["Landmark","LateralBeacon","LateralBuoy","NavigationLine","RecommendedTrack","LightSectored","LightAllAround","LightAirObstruction","LightFogDetector","RadarReflector","FogSignal","EnvironmentObservationEquipment","RadioStation","Daymark","Retroreflector","RadarTransponderBeacon","VirtualAISAidToNavigation","PhysicalAISAidToNavigation","SyntheticAISAidToNavigation","PowerSource","IsolatedDangerBeacon","CardinalBeacon","IsolatedDangerBuoy","CardinalBuoy","InstallationBuoy","MooringBuoy","EmergencyWreckMarkingBuoy","Lighthouse","LightFloat","LightVessel","OffshorePlatform","SiloTank","Pile","Building","Bridge","SinkerAnchor","MooringShackle","CableSubmarine","Swivel","Bridle","CounterWeight","Topmark","SafeWaterBeacon","SpecialPurposeGeneralBeacon","SafeWaterBuoy","SpecialPurposeGeneralBuoy","DangerousFeature","AtonAggregation","AtonAssociation","QualityOfNonBathymetricData","DataCoverage","LocalDirectionOfBuoyage","NavigationalSystemOfMarks","SoundingDatum","VerticalDatumOfData"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["AidsToNavigation","StructureObject","Equipment","ElectronicAton","GenericBeacon","GenericBuoy","GenericLight","Bridge","AtonAggregation","AtonAssociation"],
			Primitives.point => ["Landmark","LateralBeacon","LateralBuoy","LightSectored","LightAllAround","LightAirObstruction","LightFogDetector","RadarReflector","FogSignal","EnvironmentObservationEquipment","RadioStation","Daymark","Retroreflector","RadarTransponderBeacon","VirtualAISAidToNavigation","PhysicalAISAidToNavigation","SyntheticAISAidToNavigation","PowerSource","IsolatedDangerBeacon","CardinalBeacon","IsolatedDangerBuoy","CardinalBuoy","InstallationBuoy","MooringBuoy","EmergencyWreckMarkingBuoy","Lighthouse","LightFloat","LightVessel","OffshorePlatform","SiloTank","Pile","Building","SinkerAnchor","MooringShackle","CableSubmarine","Swivel","Bridle","CounterWeight","Topmark","SafeWaterBeacon","SpecialPurposeGeneralBeacon","SafeWaterBuoy","SpecialPurposeGeneralBuoy","DangerousFeature"],
			Primitives.curve => ["Landmark","NavigationLine","RecommendedTrack"],
			Primitives.surface => ["Landmark","Lighthouse","OffshorePlatform","SiloTank","QualityOfNonBathymetricData","DataCoverage","LocalDirectionOfBuoyage","NavigationalSystemOfMarks","SoundingDatum","VerticalDatumOfData"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"AidsToNavigation" => [Primitives.noGeometry],
			"StructureObject" => [Primitives.noGeometry],
			"Equipment" => [Primitives.noGeometry],
			"ElectronicAton" => [Primitives.noGeometry],
			"GenericBeacon" => [Primitives.noGeometry],
			"GenericBuoy" => [Primitives.noGeometry],
			"GenericLight" => [Primitives.noGeometry],
			"Landmark" => [Primitives.point,Primitives.curve,Primitives.surface],
			"LateralBeacon" => [Primitives.point],
			"LateralBuoy" => [Primitives.point],
			"NavigationLine" => [Primitives.curve],
			"RecommendedTrack" => [Primitives.curve],
			"LightSectored" => [Primitives.point],
			"LightAllAround" => [Primitives.point],
			"LightAirObstruction" => [Primitives.point],
			"LightFogDetector" => [Primitives.point],
			"RadarReflector" => [Primitives.point],
			"FogSignal" => [Primitives.point],
			"EnvironmentObservationEquipment" => [Primitives.point],
			"RadioStation" => [Primitives.point],
			"Daymark" => [Primitives.point],
			"Retroreflector" => [Primitives.point],
			"RadarTransponderBeacon" => [Primitives.point],
			"VirtualAISAidToNavigation" => [Primitives.point],
			"PhysicalAISAidToNavigation" => [Primitives.point],
			"SyntheticAISAidToNavigation" => [Primitives.point],
			"PowerSource" => [Primitives.point],
			"IsolatedDangerBeacon" => [Primitives.point],
			"CardinalBeacon" => [Primitives.point],
			"IsolatedDangerBuoy" => [Primitives.point],
			"CardinalBuoy" => [Primitives.point],
			"InstallationBuoy" => [Primitives.point],
			"MooringBuoy" => [Primitives.point],
			"EmergencyWreckMarkingBuoy" => [Primitives.point],
			"Lighthouse" => [Primitives.point,Primitives.surface],
			"LightFloat" => [Primitives.point],
			"LightVessel" => [Primitives.point],
			"OffshorePlatform" => [Primitives.point,Primitives.surface],
			"SiloTank" => [Primitives.point,Primitives.surface],
			"Pile" => [Primitives.point],
			"Building" => [Primitives.point],
			"Bridge" => [Primitives.noGeometry],
			"SinkerAnchor" => [Primitives.point],
			"MooringShackle" => [Primitives.point],
			"CableSubmarine" => [Primitives.point],
			"Swivel" => [Primitives.point],
			"Bridle" => [Primitives.point],
			"CounterWeight" => [Primitives.point],
			"Topmark" => [Primitives.point],
			"SafeWaterBeacon" => [Primitives.point],
			"SpecialPurposeGeneralBeacon" => [Primitives.point],
			"SafeWaterBuoy" => [Primitives.point],
			"SpecialPurposeGeneralBuoy" => [Primitives.point],
			"DangerousFeature" => [Primitives.point],
			"AtonAggregation" => [Primitives.noGeometry],
			"AtonAssociation" => [Primitives.noGeometry],
			"QualityOfNonBathymetricData" => [Primitives.surface],
			"DataCoverage" => [Primitives.surface],
			"LocalDirectionOfBuoyage" => [Primitives.surface],
			"NavigationalSystemOfMarks" => [Primitives.surface],
			"SoundingDatum" => [Primitives.surface],
			"VerticalDatumOfData" => [Primitives.surface],
			_ or "" => throw new InvalidOperationException(),
		};
		public static Type InformationBindings(string code) => code switch {
			"Atonstatus" => typeof(informationBinding<InformationAssociations.Atonstatus>),
			"AtonFixingMethodAssociation" => typeof(informationBinding<InformationAssociations.AtonFixingMethodAssociation>),
			"AtonPositioningInformationAssociation" => typeof(informationBinding<InformationAssociations.AtonPositioningInformationAssociation>),
			_ or "" => throw new InvalidOperationException(),
		};
		public static Type FeatureBindings(string code) => code switch {
			"BuoyTopmark" => typeof(featureBinding<FeatureAssociations.BuoyTopmark>),
			"StructureEquipment" => typeof(featureBinding<FeatureAssociations.StructureEquipment>),
			"PhysicalAIS" => typeof(featureBinding<FeatureAssociations.PhysicalAIS>),
			"SyntheticAIS" => typeof(featureBinding<FeatureAssociations.SyntheticAIS>),
			"VirtualAIS" => typeof(featureBinding<FeatureAssociations.VirtualAIS>),
			"BuoyCounterWeight" => typeof(featureBinding<FeatureAssociations.BuoyCounterWeight>),
			"BridleConnection" => typeof(featureBinding<FeatureAssociations.BridleConnection>),
			"ShackleConnection" => typeof(featureBinding<FeatureAssociations.ShackleConnection>),
			"ShackleConnectionFromCable" => typeof(featureBinding<FeatureAssociations.ShackleConnectionFromCable>),
			"SwivelCableConnection" => typeof(featureBinding<FeatureAssociations.SwivelCableConnection>),
			"BridleCableConnection" => typeof(featureBinding<FeatureAssociations.BridleCableConnection>),
			"ShackleToBridleConnection" => typeof(featureBinding<FeatureAssociations.ShackleToBridleConnection>),
			"ShackleToSwivelConnection" => typeof(featureBinding<FeatureAssociations.ShackleToSwivelConnection>),
			"ShackleToAnchorConnection" => typeof(featureBinding<FeatureAssociations.ShackleToAnchorConnection>),
			"SwivelConnection" => typeof(featureBinding<FeatureAssociations.SwivelConnection>),
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.Atonstatus>), typeDiscriminator: "informationBinding::S201::Atonstatus"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AtonFixingMethodAssociation>), typeDiscriminator: "informationBinding::S201::AtonFixingMethodAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AtonPositioningInformationAssociation>), typeDiscriminator: "informationBinding::S201::AtonPositioningInformationAssociation"));
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BuoyTopmark>), typeDiscriminator: "featureBinding::S201::BuoyTopmark"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.StructureEquipment>), typeDiscriminator: "featureBinding::S201::StructureEquipment"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.PhysicalAIS>), typeDiscriminator: "featureBinding::S201::PhysicalAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.SyntheticAIS>), typeDiscriminator: "featureBinding::S201::SyntheticAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.VirtualAIS>), typeDiscriminator: "featureBinding::S201::VirtualAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BuoyCounterWeight>), typeDiscriminator: "featureBinding::S201::BuoyCounterWeight"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BridleConnection>), typeDiscriminator: "featureBinding::S201::BridleConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleConnection>), typeDiscriminator: "featureBinding::S201::ShackleConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleConnectionFromCable>), typeDiscriminator: "featureBinding::S201::ShackleConnectionFromCable"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.SwivelCableConnection>), typeDiscriminator: "featureBinding::S201::SwivelCableConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BridleCableConnection>), typeDiscriminator: "featureBinding::S201::BridleCableConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleToBridleConnection>), typeDiscriminator: "featureBinding::S201::ShackleToBridleConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleToSwivelConnection>), typeDiscriminator: "featureBinding::S201::ShackleToSwivelConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleToAnchorConnection>), typeDiscriminator: "featureBinding::S201::ShackleToAnchorConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.SwivelConnection>), typeDiscriminator: "featureBinding::S201::SwivelConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.AtonAggregations>), typeDiscriminator: "featureBinding::S201::AtonAggregations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.AtonAssociations>), typeDiscriminator: "featureBinding::S201::AtonAssociations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.RangeSystem>), typeDiscriminator: "featureBinding::S201::RangeSystem"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.DangerousFeatureAssociation>), typeDiscriminator: "featureBinding::S201::DangerousFeatureAssociation"));
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.Atonstatus>), typeDiscriminator: "informationBinding::S201::Atonstatus"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AtonFixingMethodAssociation>), typeDiscriminator: "informationBinding::S201::AtonFixingMethodAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AtonPositioningInformationAssociation>), typeDiscriminator: "informationBinding::S201::AtonPositioningInformationAssociation"));
				}
				if (typeInfo.Type == typeof(featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$type",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BuoyTopmark>), typeDiscriminator: "featureBinding::S201::BuoyTopmark"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.StructureEquipment>), typeDiscriminator: "featureBinding::S201::StructureEquipment"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.PhysicalAIS>), typeDiscriminator: "featureBinding::S201::PhysicalAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.SyntheticAIS>), typeDiscriminator: "featureBinding::S201::SyntheticAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.VirtualAIS>), typeDiscriminator: "featureBinding::S201::VirtualAIS"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BuoyCounterWeight>), typeDiscriminator: "featureBinding::S201::BuoyCounterWeight"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BridleConnection>), typeDiscriminator: "featureBinding::S201::BridleConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleConnection>), typeDiscriminator: "featureBinding::S201::ShackleConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleConnectionFromCable>), typeDiscriminator: "featureBinding::S201::ShackleConnectionFromCable"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.SwivelCableConnection>), typeDiscriminator: "featureBinding::S201::SwivelCableConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.BridleCableConnection>), typeDiscriminator: "featureBinding::S201::BridleCableConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleToBridleConnection>), typeDiscriminator: "featureBinding::S201::ShackleToBridleConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleToSwivelConnection>), typeDiscriminator: "featureBinding::S201::ShackleToSwivelConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.ShackleToAnchorConnection>), typeDiscriminator: "featureBinding::S201::ShackleToAnchorConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.SwivelConnection>), typeDiscriminator: "featureBinding::S201::SwivelConnection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.AtonAggregations>), typeDiscriminator: "featureBinding::S201::AtonAggregations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.AtonAssociations>), typeDiscriminator: "featureBinding::S201::AtonAssociations"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.RangeSystem>), typeDiscriminator: "featureBinding::S201::RangeSystem"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.DangerousFeatureAssociation>), typeDiscriminator: "featureBinding::S201::DangerousFeatureAssociation"));
				}
			});
			return resolver;
		}
	}

	/// <summary>
	/// The degree of reliability attributed to a position.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfHorizontalMeasurement : int {
		[Description("The position(s) was(were) determined by the operation of making measurements for determining the relative position of points on, above or beneath the earth's surface. Survey implies a regular, controlled survey of any date.")]
		[EnumMember(Value = "Surveyed")] 
		[XmlEnum("1")] 
		Surveyed = 1,

		[Description("Survey data is does not exist or is very poor.")]
		[EnumMember(Value = "Unsurveyed")] 
		[XmlEnum("2")] 
		Unsurveyed = 2,

		[Description("Not surveyed to modern standards; or due to its age, scale, or positional or vertical uncertainties is not suitable to the type of navigation expected in the area.")]
		[EnumMember(Value = "Inadequately Surveyed")] 
		[XmlEnum("3")] 
		InadequatelySurveyed = 3,

		[Description("A position that is considered to be less than third-order accuracy, but is generally considered to be within 30.5 metres of its correct geographic location. Also may apply to an object whose position does not remain fixed.")]
		[EnumMember(Value = "Approximate")] 
		[XmlEnum("4")] 
		Approximate = 4,

		[Description("Of uncertain position. The expression is used principally on charts to indicate that a wreck, shoal, etc., has been reported in various positions and not definitely determined in any.")]
		[EnumMember(Value = "Position Doubtful")] 
		[XmlEnum("5")] 
		PositionDoubtful = 5,

		[Description("A feature's position has been obtained from questionable or unreliable data.")]
		[EnumMember(Value = "Unreliable")] 
		[XmlEnum("6")] 
		Unreliable = 6,

		[Description("An object whose position has been reported and its position confirmed by some means other than a formal survey such as an independent report of the same object.")]
		[EnumMember(Value = "Reported (Not Surveyed)")] 
		[XmlEnum("7")] 
		ReportedNotSurveyed = 7,

		[Description("An object whose position has been reported and its position has not been confirmed.")]
		[EnumMember(Value = "Reported (Not Confirmed)")] 
		[XmlEnum("8")] 
		ReportedNotConfirmed = 8,

		[Description("The most probable position of an object determined from incomplete data or data of questionable accuracy.")]
		[EnumMember(Value = "Estimated")] 
		[XmlEnum("9")] 
		Estimated = 9,

		[Description("A position that is of a known value, such as the position of an anchor berth or other defined object.")]
		[EnumMember(Value = "Precisely Known")] 
		[XmlEnum("10")] 
		PreciselyKnown = 10,

		[Description("A position that is computed from data.")]
		[EnumMember(Value = "Calculated")] 
		[XmlEnum("11")] 
		Calculated = 11,
	}

	/// <summary>
	/// -
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum ChangeTypes : int {
		[Description("-")]
		[EnumMember(Value = "Advanced notice of changes")] 
		[XmlEnum("1")] 
		AdvancedNoticeOfChanges = 1,

		[Description("-")]
		[EnumMember(Value = "Discrepancy")] 
		[XmlEnum("2")] 
		Discrepancy = 2,

		[Description("-")]
		[EnumMember(Value = "Proposed changes")] 
		[XmlEnum("3")] 
		ProposedChanges = 3,

		[Description("-")]
		[EnumMember(Value = "Temporary changes")] 
		[XmlEnum("4")] 
		TemporaryChanges = 4,
	}

	/// <summary>
	/// Units of measure of waterway distances. (IHO Registry)
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum heightLengthUnits : int {
		[Description("-")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[Description("-")]
		[EnumMember(Value = "Feet")] 
		[XmlEnum("2")] 
		Feet = 2,

		[Description("-")]
		[EnumMember(Value = "Kilometres")] 
		[XmlEnum("3")] 
		Kilometres = 3,

		[Description("-")]
		[EnumMember(Value = "Hectometres")] 
		[XmlEnum("4")] 
		Hectometres = 4,

		[Description("-")]
		[EnumMember(Value = "Statute Miles")] 
		[XmlEnum("5")] 
		StatuteMiles = 5,

		[Description("-")]
		[EnumMember(Value = "Nautical Miles")] 
		[XmlEnum("6")] 
		NauticalMiles = 6,
	}

	/// <summary>
	/// Horizontal reference surface or the reference coordinate system used for geodetic control in the calculation of coordinates of points on the earth.
	/// </summary>
	/// <remarks>
	/// All necessary information for conversion of geographic coordinates from most of the Geodetic Datums in the above list to WGS-84 is contained in the 'User's Handbook on Datum Transformations involving WGS-84', prepared by the US Defense Mapping Agency and which is available from the IHB as IHO Publication S-60 (English and French Versions), along with an associated standard datum transformation software on floppy disk called 'MADTRAN'.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum horizontalDatum : int {
		[Description("A standard for use in cartography, geodesy, and satellite navigation including GPS. This standard includes the definition of the coordinate system's fundamental and derived constants, the ellipsoidal (normal) Earth Gravitational Model (EGM), a description of the associated World Magnetic Model (WMM), and a current list of local datum transformations. The WGS 72 is based on selected satellite, surface gravity and astrogeodetic data available through 1972.")]
		[EnumMember(Value = "WGS 72")] 
		[XmlEnum("1")] 
		Wgs72 = 1,

		[Description("A standard for use in cartography, geodesy, and satellite navigation including GPS. This standard includes the definition of the coordinate system's fundamental and derived constants, the ellipsoidal (normal) Earth Gravitational Model (EGM), a description of the associated World Magnetic Model (WMM), and a current list of local datum transformations. WGS 84 is the reference coordinate system used by the Global Positioning System.")]
		[EnumMember(Value = "WGS 84")] 
		[XmlEnum("2")] 
		Wgs84 = 2,

		[Description("A geodetic datum first defined in 1950 suitable for use in Europe - west: Andorra; Cyprus; Denmark - onshore and offshore; Faroe Islands - onshore; France - offshore; Germany - offshore North Sea; Gibraltar; Greece - offshore; Israel - offshore; Italy including San Marino and Vatican City State; Ireland offshore; Malta; Netherlands - offshore; North Sea; Norway including Svalbard - onshore and offshore; Portugal - mainland - offshore; Spain - onshore; Turkey - onshore and offshore; United Kingdom UKCS offshore east of 6W including Channel Islands (Guernsey and Jersey). Egypt - Western Desert; Iraq - onshore; Jordan. European Datum 1950 references the International 1924 ellipsoid and the Greenwich prime meridian. European Datum 1950 origin is Fundamental point: Potsdam (Helmert Tower). Latitude: 5222'51.4456\"N, longitude: 1303'58.9283\"E (of Greenwich). European Datum 1950 is a geodetic datum for Topographic mapping, geodetic survey.")]
		[EnumMember(Value = "European 1950")] 
		[XmlEnum("3")] 
		European1950 = 3,

		[Description("A geodetic datum first defined in 1990 suitable for use in Germany - Thuringen. Potsdam Datum/83 references the Bessel 1841 ellipsoid and the Greenwich prime meridian. Potsdam Datum/83 origin is Fundamental point: Rauenberg. Latitude: 5227'12.021\"N, longitude: 1322'04.928\"E (of Greenwich). This station was destroyed in 1910 and the station at Potsdam substituted as the fundamental point. Potsdam Datum/83 is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from BKG via EuroGeographics. http://crs.bkg.bund.de PD/83 is the realisation of DHDN in Thuringen. It is the resultant of applying a transformation derived at 13 points on the border between East and West Germany to Pulkovo 1942/83 points in Thuringen.")]
		[EnumMember(Value = "Potsdam Datum")] 
		[XmlEnum("4")] 
		PotsdamDatum = 4,

		[Description("A geodetic datum first defined in 1958 suitable for use in Eritrea; Ethiopia; South Sudan; Sudan. Adindan references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Adindan origin is Fundamental point: Station 15; Adindan. Latitude: 2210'07.110\"N, longitude: 3129'21.608\"E (of Greenwich). Adindan is a geodetic datum for Topographic mapping. It was defined by information from US Coast and Geodetic Survey via Geophysical Reasearch vol 67 #11, October 1962. The 12th parallel traverse of 1966-70 (Point 58 datum, code 6620) is connected to the Blue Nile 1958 network in western Sudan. This has given rise to misconceptions that the Blue Nile network is used in west Africa.")]
		[EnumMember(Value = "Adindan")] 
		[XmlEnum("5")] 
		Adindan = 5,

		[Description("A geodetic datum first defined in and suitable for use in Somalia - onshore. Afgooye references the Krassowsky 1940 ellipsoid and the Greenwich prime meridian. Afgooye is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Afgooye")] 
		[XmlEnum("6")] 
		Afgooye = 6,

		[Description("A geodetic datum first defined in 1970 and suitable for use in Bahrain, Kuwait and Saudi Arabia - onshore. Ain el Abd 1970 references the International 1924 ellipsoid and the Greenwich prime meridian. Ain el Abd 1970 origin is Fundamental point: Ain El Abd. Latitude: 2814'06.171\"N, longitude: 4816'20.906\"E (of Greenwich). Ain el Abd 1970 is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Ain el Abd 1970")] 
		[XmlEnum("7")] 
		AinElAbd1970 = 7,

		[Description("A geodetic datum first defined in 1965 suitable for use in Cocos (Keeling) Islands - onshore. Cocos Islands 1965 references the Australian National Spheroid ellipsoid and the Greenwich prime meridian. Cocos Islands 1965 origin is Fundamental point: Anna 1. Cocos Islands 1965 is a geodetic datum for Military and topographic mapping It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Anna 1 Astro 1965")] 
		[XmlEnum("8")] 
		Anna1Astro1965 = 8,

		[Description("A geodetic datum first defined in 1943 suitable for use in Antigua island - onshore. Antigua 1943 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Antigua 1943 origin is Fundamental point: station A14. Antigua 1943 is a geodetic datum for Topographic mapping. It was defined by information from Ordnance Survey of Great Britain.")]
		[EnumMember(Value = "Antigua Island Astro 1943")] 
		[XmlEnum("9")] 
		AntiguaIslandAstro1943 = 9,

		[Description("A geodetic datum first defined in 1950 suitable for use in Botswana; Malawi; Zambia; Zimbabwe. Arc 1950 references the Clarke 1880 (Arc) ellipsoid and the Greenwich prime meridian. Arc 1950 origin is Fundamental point: Buffelsfontein. Latitude: 3359'32.000\"S, longitude: 2530'44.622\"E (of Greenwich). Arc 1950 is a geodetic datum for Topographic mapping, geodetic survey.")]
		[EnumMember(Value = "Arc 1950")] 
		[XmlEnum("10")] 
		Arc1950 = 10,

		[Description("A geodetic datum first defined in 1960 suitable for use in Kenya; Tanzania; Uganda. Arc 1960 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Arc 1960 origin is Fundamental point: Buffelsfontein. Latitude: 3359'32.000\"S, longitude: 2530'44.622\"E (of Greenwich). Arc 1960 is a geodetic datum for Topographic mapping, geodetic survey.")]
		[EnumMember(Value = "Arc 1960")] 
		[XmlEnum("11")] 
		Arc1960 = 11,

		[Description("A geodetic datum first defined in 1958 suitable for use in St Helena, Ascension and Tristan da Cunha - Ascension Island - onshore. Ascension Island 1958 references the International 1924 ellipsoid and the Greenwich prime meridian. Ascension Island 1958 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Ascension Island 1958")] 
		[XmlEnum("12")] 
		AscensionIsland1958 = 12,

		[Description("Astro beacon 'E' 1945")]
		[EnumMember(Value = "Astro Beacon 'E' 1945")] 
		[XmlEnum("13")] 
		AstroBeaconE1945 = 13,

		[Description("A geodetic datum first defined in 1971 suitable for use in St Helena, Ascension and Tristan da Cunha - St Helena Island - onshore. Astro DOS 71 references the International 1924 ellipsoid and the Greenwich prime meridian. Astro DOS 71 origin is Fundamental point: DOS 71/4, Ladder Hill Fort, latitude: 1555'30\"S, longitude: 543'25\"W (of Greenwich). Astro DOS 71 is a geodetic datum for Geodetic control, military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000) and St. Helena Government, Environment and Natural Resources Directorate (ENRD).")]
		[EnumMember(Value = "Astro DOS 71/4")] 
		[XmlEnum("14")] 
		AstroDos714 = 14,

		[Description("A geodetic datum first defined in 1961 suitable for use in United States (USA) - Hawaii - Tern Island and Sorel Atoll. Tern Island 1961 references the International 1924 ellipsoid and the Greenwich prime meridian. Tern Island 1961 origin is Fundamental point: station FRIG on tern island, station B4 on Sorol Atoll. Tern Island 1961 is a geodetic datum for Military and topographic mapping It was defined by information from DMA / NIMA / NGA TR8350.2 (original 1987 first edition and 3rd edition, Amendment 1, 3 January 2000). Two independent astronomic determinations considered to be consistent through adoption of common transformation to WGS 84 (see tfm code 15795).")]
		[EnumMember(Value = "Astro Tern Island (FRIG) 1961")] 
		[XmlEnum("15")] 
		AstroTernIslandFrig1961 = 15,

		[Description("Astronomical station 1952.")]
		[EnumMember(Value = "Astronomical Station 1952")] 
		[XmlEnum("16")] 
		AstronomicalStation1952 = 16,

		[Description("A geodetic datum first defined in 1966 suitable for use in Australia - onshore and offshore. Papua New Guinea - onshore. Australian Geodetic Datum 1966 references the Australian National Spheroid ellipsoid and the Greenwich prime meridian. Australian Geodetic Datum 1966 origin is Fundamental point: Johnson Memorial Cairn. Latitude: 2556'54.5515\"S, longitude: 13312'30.0771\"E (of Greenwich). Australian Geodetic Datum 1966 is a geodetic datum for Topographic mapping. It was defined by information from Australian Map Grid Technical Manual. National Mapping Council of Australia Technical Publication 7; 1972.")]
		[EnumMember(Value = "Australian Geodetic 1966")] 
		[XmlEnum("17")] 
		AustralianGeodetic1966 = 17,

		[Description("A geodetic datum first defined in 1984 suitable for use in Australia - Queensland, South Australia, Western Australia, federal areas offshore west of 129E. Australian Geodetic Datum 1984 references the Australian National Spheroid ellipsoid and the Greenwich prime meridian. Australian Geodetic Datum 1984 origin is Fundamental point: Johnson Memorial Cairn. Latitude: 2556'54.5515\"S, longitude: 13312'30.0771\"E (of Greenwich). Australian Geodetic Datum 1984 is a geodetic datum for Topographic mapping. It was defined by information from \"GDA technical manual v2_2\", Intergovernmental Committee on Surveying and Mapping. www.anzlic.org.au/icsm/gdtm/ Uses all data from 1966 adjustment with additional observations, improved software and a geoid model.")]
		[EnumMember(Value = "Australian Geodetic 1984")] 
		[XmlEnum("18")] 
		AustralianGeodetic1984 = 18,

		[Description("A geodetic datum suitable for use in Djibouti - onshore and offshore. Ayabelle Lighthouse references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Ayabelle Lighthouse origin is Fundamental point: Ayabelle Lighthouse. Ayabelle Lighthouse is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Ayabelle Lighthouse")] 
		[XmlEnum("19")] 
		AyabelleLighthouse = 19,

		[Description("A geodetic datum first defined in 1960 suitable for use in Vanuatu - southern islands - Aneityum, Efate, Erromango and Tanna. Bellevue references the International 1924 ellipsoid and the Greenwich prime meridian. Bellevue is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000). Datum covers all the major islands of Vanuatu in two different adjustment blocks, but practical usage is as given in the area of use.")]
		[EnumMember(Value = "Bellevue (IGN)")] 
		[XmlEnum("20")] 
		BellevueIgn = 20,

		[Description("A geodetic datum first defined in 1957 suitable for use in Bermuda - onshore. Bermuda 1957 references the Clarke 1866 ellipsoid and the Greenwich prime meridian. Bermuda 1957 origin is Fundamental point: Fort George base. Latitude 3222'44.36\"N, longitude 6440'58.11\"W (of Greenwich). Bermuda 1957 is a geodetic datum for Topographic mapping. It was defined by information from Various oil industry sources.")]
		[EnumMember(Value = "Bermuda 1957")] 
		[XmlEnum("21")] 
		Bermuda1957 = 21,

		[Description("A geodetic datum first defined in and is suitable for use in Guinea-Bissau - onshore. Bissau references the International 1924 ellipsoid and the Greenwich prime meridian. Bissau origin is Bissau is a geodetic datum for Topographic mapping. It was defined by information from NIMA TR8350.2 ftp://164.214.2.65/pub/gig/tr8350.2/changes.pdf.")]
		[EnumMember(Value = "Bissau")] 
		[XmlEnum("22")] 
		Bissau = 22,

		[Description("A geodetic datum first defined in 1975 suitable for use in Colombia - mainland and offshore Caribbean. Bogota 1975 references the International 1924 ellipsoid and the Greenwich prime meridian. Bogota 1975 origin is Fundamental point: Bogota observatory. Latitude: 435'56.570\"N, longitude: 7404'51.300\"W (of Greenwich). Bogota 1975 is a geodetic datum for Topographic mapping. It was defined by information from Instituto Geografico Agustin Codazzi (IGAC) special publication no. 1, 4th edition (1975) \"Geodesia: Resultados Definitvos de Parte de las Redes Geodesicas Establecidas en el Pais\". Replaces 1951 adjustment. Replaced by MAGNA-SIRGAS (datum code 6685).")]
		[EnumMember(Value = "Bogota Observatory")] 
		[XmlEnum("23")] 
		BogotaObservatory = 23,

		[Description("A geodetic datum suitable for use in Indonesia - Banga and Belitung Islands. Bukit Rimpah references the Bessel 1841 ellipsoid and the Greenwich prime meridian. Bukit Rimpah origin is 200'40.16\"S, 10551'39.76\"E (of Greenwich). Bukit Rimpah is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Bukit Rimpah")] 
		[XmlEnum("24")] 
		BukitRimpah = 24,

		[Description("A geodetic datum suitable for use in Antarctica - McMurdo Sound, Camp McMurdo area. Camp Area Astro references the International 1924 ellipsoid and the Greenwich prime meridian. Camp Area Astro is a geodetic datum for Geodetic and topographic survey. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Camp Area Astro")] 
		[XmlEnum("25")] 
		CampAreaAstro = 25,

		[Description("A geodetic datum suitable for use in Argentina - mainland onshore and Atlantic offshore Tierra del Fuego. Campo Inchauspe references the International 1924 ellipsoid and the Greenwich prime meridian. Campo Inchauspe origin is Fundamental point: Campo Inchauspe. Latitude: 3558'16.56\"S, longitude: 6210'12.03\"W (of Greenwich). Campo Inchauspe is a geodetic datum for Topographic mapping. It was defined by information from NIMA http://earth-info.nima.mil/")]
		[EnumMember(Value = "Campo Inchauspe 1969")] 
		[XmlEnum("26")] 
		CampoInchauspe1969 = 26,

		[Description("A geodetic datum first defined in 1966 suitable for use in Kiribati - Phoenix Islands: Kanton, Orona, McKean Atoll, Birnie Atoll, Phoenix Seamounts. Phoenix Islands 1966 references the International 1924 ellipsoid and the Greenwich prime meridian. Phoenix Islands 1966 is a geodetic datum for Military and topographic mapping It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Canton Astro 1966")] 
		[XmlEnum("27")] 
		CantonAstro1966 = 27,

		[Description("A geodetic datum suitable for use in Botswana; Lesotho; South Africa - mainland; Swaziland. Cape references the Clarke 1880 (Arc) ellipsoid and the Greenwich prime meridian. Cape origin is Fundamental point: Buffelsfontein. Latitude: 3359'32.000\"S, longitude: 2530'44.622\"E (of Greenwich). Cape is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from Private Communication, Directorate of Surveys and Land Information, Cape Town.")]
		[EnumMember(Value = "Cape Datum")] 
		[XmlEnum("28")] 
		CapeDatum = 28,

		[Description("A geodetic datum first defined in 1963 suitable for use in North America - onshore - Bahamas and USA - Florida (east). Cape Canaveral references the Clarke 1866 ellipsoid and the Greenwich prime meridian. Cape Canaveral origin is Fundamental point: Central 1950. Latitude: 28 29'32.36555\"N, longitude 80 34'38.77362\"W (of Greenwich). Cape Canaveral is a geodetic datum for US space and military operations. It was defined by information from US NGS and DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Cape Canaveral")] 
		[XmlEnum("29")] 
		CapeCanaveral = 29,

		[Description("A geodetic datum first defined in 1925 suitable for use in Tunisia - onshore and offshore. Carthage references the Clarke 1880 (IGN) ellipsoid and the Greenwich prime meridian. Carthage origin is Fundamental point: Carthage. Latitude: 40.9464506g = 3651'06.50\"N, longitude: 8.8724368g E of Paris = 1019'20.72\"E (of Greenwich). Carthage is a geodetic datum for Topographic mapping. Fundamental point astronomic coordinates determined in 1878.")]
		[EnumMember(Value = "Carthage")] 
		[XmlEnum("30")] 
		Carthage = 30,

		[Description("A geodetic datum first defined in 1971 suitable for use in New Zealand - Chatham Islands group - onshore. Chatham Islands Datum 1971 references the International 1924 ellipsoid and the Greenwich prime meridian. Chatham Islands Datum 1971 is a geodetic datum for Geodetic survey, topographic mapping, engineering survey. It was defined by information from Office of Surveyor General (OSG) Technical Report 14, June 2001. Replaced by Chatham Islands Datum 1979 (code 6673).")]
		[EnumMember(Value = "Chatam Island Astro 1971")] 
		[XmlEnum("31")] 
		ChatamIslandAstro1971 = 31,

		[Description("A geodetic datum suitable for use in Brazil - south of 18S and west of 54W, plus Distrito Federal. Paraguay - north. Chua references the International 1924 ellipsoid and the Greenwich prime meridian. Chua origin is Fundamental point: Chua. Latitude: 1945'41.160\"S, longitude: 4806'07.560\"W (of Greenwich). Chua is a geodetic datum for Geodetic survey. It was defined by information from NIMA http://earth-info.nima.mil/. The Chua origin and associated network is in Brazil with a connecting traverse through northern Paraguay. It was used in Brazil only as input into the Corrego Allegre adjustment and for government work in Distrito Federal.")]
		[EnumMember(Value = "Chua Astro")] 
		[XmlEnum("32")] 
		ChuaAstro = 32,

		[Description("A geodetic datum first defined in 1972 suitable for use in Brazil - onshore - west of 54W and south of 18S; also south of 15S between 54W and 42W; also east of 42W. Corrego Alegre 1970-72 references the International 1924 ellipsoid and the Greenwich prime meridian. Corrego Alegre 1970-72 origin is Fundamental point: Corrego Alegre. Latitude: 1950'14.91\"S, longitude: 4857'41.98\"W (of Greenwich). Corrego Alegre 1970-72 is a geodetic datum for Topographic mapping, geodetic survey. Superseded by SAD69. It was defined by information from IBGE. Replaces 1961 adjustment (datum code 1074). NIMA gives coordinates of origin as latitude: 1950'15.14\"S, longitude: 4857'42.75\"W; these may refer to 1961 adjustment.")]
		[EnumMember(Value = "Corrego Alegre")] 
		[XmlEnum("33")] 
		CorregoAlegre = 33,

		[Description("A geodetic datum first defined in 1981 suitable for use in Guinea - onshore. Dabola 1981 references the Clarke 1880 (IGN) ellipsoid and the Greenwich prime meridian. Dabola 1981 is a geodetic datum for Topographic mapping. It was defined by information from IGN Paris.")]
		[EnumMember(Value = "Dabola")] 
		[XmlEnum("34")] 
		Dabola = 34,

		[Description("A geodetic datum suitable for use in Indonesia - onshore Java and Bali. Batavia (Jakarta) references the Bessel 1841 ellipsoid and the Jakarta prime meridian. Batavia (Jakarta) origin is Fundamental point: Longitude at Batavia astronomical station. Latitude: 607'39.522\"S, longitude: 000'00.0\"E (of Jakarta). Latitude and azimuth at Genuk. Batavia (Jakarta) is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Djakarta (Batavia)")] 
		[XmlEnum("35")] 
		DjakartaBatavia = 35,

		[Description("DOS 1968.")]
		[EnumMember(Value = "DOS 1968")] 
		[XmlEnum("36")] 
		Dos1968 = 36,

		[Description("A geodetic datum first defined in 1967 suitable for use in Chile - Easter Island onshore. Easter Island 1967 references the International 1924 ellipsoid and the Greenwich prime meridian. Easter Island 1967 is a geodetic datum for Military and topographic mapping, +/- 25 meters in each component. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Easter Island 1967")] 
		[XmlEnum("37")] 
		EasterIsland1967 = 37,

		[Description("A geodetic datum first defined in 1979 suitable for use in Europe - west. European Datum 1979 references the International 1924 ellipsoid and the Greenwich prime meridian. European Datum 1979 origin is Fundamental point: Potsdam (Helmert Tower). Latitude: 5222'51.4456\"N, longitude: 1303'58.9283\"E (of Greenwich). European Datum 1979 is a geodetic datum for Scientific network. Replaced by 1987 adjustment.")]
		[EnumMember(Value = "European 1979")] 
		[XmlEnum("38")] 
		European1979 = 38,

		[Description("Fort Thomas 1955 datum.")]
		[EnumMember(Value = "Fort Thomas 1955")] 
		[XmlEnum("39")] 
		FortThomas1955 = 39,

		[Description("A geodetic datum first defined in 1970 suitable for use in Maldives - onshore. Gan 1970 references the International 1924 ellipsoid and the Greenwich prime meridian. Gan 1970 is a geodetic datum for Topographic mapping. It was defined by information from Various industry sources. In some references incorrectly named \"Gandajika 1970\".")]
		[EnumMember(Value = "Gan 1970")] 
		[XmlEnum("40")] 
		Gan1970 = 40,

		[Description("A geodetic datum first defined in 1949 suitable for use in New Zealand - North Island, South Island, Stewart Island - onshore and nearshore. New Zealand Geodetic Datum 1949 references the International 1924 ellipsoid and the Greenwich prime meridian. New Zealand Geodetic Datum 1949 origin is Fundamental point: Papatahi. Latitude: 4119' 8.900\"S, longitude: 17502'51.000\"E (of Greenwich). New Zealand Geodetic Datum 1949 is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from Land Information New Zealand. http://www.linz.govt.nz/rcs/linz/pub/web/root/core/SurveySystem/GeodeticInfo/GeodeticDatums/nzgd2000factsheet/index.jsp. Replaced by New Zealand Geodetic Datum 2000 (code 6167) from March 2000.")]
		[EnumMember(Value = "Geodetic Datum 1949")] 
		[XmlEnum("41")] 
		GeodeticDatum1949 = 41,

		[Description("Graciosa Base SW 1948 datum.")]
		[EnumMember(Value = "Graciosa Base SW 1948")] 
		[XmlEnum("42")] 
		GraciosaBaseSw1948 = 42,

		[Description("A geodetic datum first defined in 1963 suitable for use in Guam - onshore. Guam 1963 references the Clarke 1866 ellipsoid and the Greenwich prime meridian. Guam 1963 origin is Fundamental point: Tagcha. Latitude: 1322'38.49\"N, longitude: 14445'51.56\"E (of Greenwich). Guam 1963 is a geodetic datum for Topographic mapping. It was defined by information from US National Geospatial Intelligence Agency (NGA). http://earth-info.nga.mil/ Replaced by NAD83(HARN)")]
		[EnumMember(Value = "Guam 1963")] 
		[XmlEnum("43")] 
		Guam1963 = 43,

		[Description("A geodetic datum suitable for use in Indonesia - Kalimantan - onshore east coastal area including Mahakam delta coastal and offshore shelf areas. Gunung Segara references the Bessel 1841 ellipsoid and the Greenwich prime meridian. Gunung Segara origin is Station P5 (Gunung Segara). Latitude 032'12.83\"S, longitude 11708'48.47\"E (of Greenwich). Gunung Segara is a geodetic datum for Topographic mapping. It was defined by information from TotalFinaElf.")]
		[EnumMember(Value = "Gunung Segara")] 
		[XmlEnum("44")] 
		GunungSegara = 44,

		[Description("GUX 1 Astro datum.")]
		[EnumMember(Value = "GUX 1 Astro")] 
		[XmlEnum("45")] 
		Gux1Astro = 45,

		[Description("A geodetic datum suitable for use in Afghanistan. Herat North references the International 1924 ellipsoid and the Greenwich prime meridian. Herat North origin is Fundamental point: Herat North. Latitude: 3423'09.08\"N, longitude: 6410'58.94\"E (of Greenwich). Herat North is a geodetic datum for Topographic mapping. It was defined by information from NIMA http://earth-info.nima.mil/.")]
		[EnumMember(Value = "Herat North")] 
		[XmlEnum("46")] 
		HeratNorth = 46,

		[Description("A geodetic datum first defined in 1955 suitable for use in Iceland - onshore. Hjorsey 1955 references the International 1924 ellipsoid and the Greenwich prime meridian. Hjorsey 1955 origin is Fundamental point: Latitude: 6431'29.26\"N, longitude: 2222'05.84\"W (of Greenwich). Hjorsey 1955 is a geodetic datum for 1/50,000 scale topographic mapping. It was defined by information from Landmaelingar Islands (National Survey of Iceland).")]
		[EnumMember(Value = "Hjorsey 1955")] 
		[XmlEnum("47")] 
		Hjorsey1955 = 47,

		[Description("A geodetic datum first defined in 1963 suitable for use in China - Hong Kong - onshore and offshore. Hong Kong 1963 references the Clarke 1858 ellipsoid and the Greenwich prime meridian. Hong Kong 1963 origin is Fundamental point: Trig \"Zero\", 38.4 feet south along the transit circle of the Kowloon Observatory. Latitude 2218'12.82\"N, longitude 11410'18.75\"E (of Greenwich). Hong Kong 1963 is a geodetic datum for Topographic mapping and hydrographic charting. It was defined by information from Survey and Mapping Office, Lands Department. http://www.info.gov.hk/landsd/. Replaced by Hong Kong 1963(67) for military purposes only in 1967. Replaced by Hong Kong 1980.")]
		[EnumMember(Value = "Hong Kong 1963")] 
		[XmlEnum("48")] 
		HongKong1963 = 48,

		[Description("A geodetic datum first defined in 1950 suitable for use in Taiwan, Republic of China - onshore - Taiwan Island, Penghu (Pescadores) Islands. Hu Tzu Shan 1950 references the International 1924 ellipsoid and the Greenwich prime meridian. Hu Tzu Shan 1950 origin is Fundamental point: Hu Tzu Shan. Latitude: 2358'32.34\"N, longitude: 12058'25.975\"E (of Greenwich). Hu Tzu Shan 1950 is a geodetic datum for Topographic mapping. It was defined by information from NIMA US NGA, http://earth-info.nga.mil/GandG/index.html")]
		[EnumMember(Value = "Hu-Tzu-Shan")] 
		[XmlEnum("49")] 
		HuTzuShan = 49,

		[Description("Indian datum.")]
		[EnumMember(Value = "Indian")] 
		[XmlEnum("50")] 
		Indian = 50,

		[Description("A geodetic datum first defined in 1954 suitable for use in Myanmar (Burma) - onshore; Thailand - onshore. Indian 1954 references the Everest 1830 (1937 Adjustment) ellipsoid and the Greenwich prime meridian. Indian 1954 origin is Extension of Kalianpur 1937 over Myanmar and Thailand. Indian 1954 is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Indian 1954")] 
		[XmlEnum("51")] 
		Indian1954 = 51,

		[Description("A geodetic datum first defined in 1975 suitable for use in Thailand - onshore plus offshore Gulf of Thailand. Indian 1975 references the Everest 1830 (1937 Adjustment) ellipsoid and the Greenwich prime meridian. Indian 1975 origin is Fundamental point: Khau Sakaerang. Indian 1975 is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Indian 1975")] 
		[XmlEnum("52")] 
		Indian1975 = 52,

		[Description("A geodetic datum first defined in 1975 suitable for use in Ireland - onshore. United Kingdom (UK) - Northern Ireland (Ulster) - onshore. Ireland 1965 references the Airy Modified 1849 ellipsoid and the Greenwich prime meridian. Ireland 1965 origin is Adjusted to best mean fit 9 stations of the OSNI 1952 primary adjustment in Northern Ireland plus the 1965 values of 3 stations in the Republic of Ireland. Ireland 1965 is a geodetic datum for Geodetic survey, topographic mapping and engineering survey. It was defined by information from \"The Irish Grid - A Description of the Co-ordinate Reference System\" published by Ordnance Survey of Ireland, Dublin and Ordnance Survey of Northern Ireland, Belfast. Differences from the 1965 adjustment (datum code 6299) are: average difference in Eastings 0.092m; average difference in Northings 0.108m; maximum vector difference 0.548m.")]
		[EnumMember(Value = "Ireland 1965")] 
		[XmlEnum("53")] 
		Ireland1965 = 53,

		[Description("A geodetic datum first defined in 1968 suitable for use in South Georgia and the South Sandwich Islands - South Georgia onshore. ISTS 061 Astro 1968 references the International 1924 ellipsoid and the Greenwich prime meridian. ISTS 061 Astro 1968 origin is Fundamental point: ISTS 061. ISTS 061 Astro 1968 is a geodetic datum for Military and topographic mapping It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "ISTS 061 Astro 1968")] 
		[XmlEnum("54")] 
		Ists061Astro1968 = 54,

		[Description("A geodetic datum first defined in 1969 suitable for use in British Indian Ocean Territory - Chagos Archipelago - Diego Garcia. ISTS 073 Astro 1969 references the International 1924 ellipsoid and the Greenwich prime meridian. ISTS 073 Astro 1969 origin is Fundamental point: ISTS 073. ISTS 073 Astro 1969 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "ISTS 073 Astro 1969")] 
		[XmlEnum("55")] 
		Ists073Astro1969 = 55,

		[Description("A geodetic datum first defined in 1961 suitable for use in United States Minor Outlying Islands - Johnston Island. Johnston Island 1961 references the International 1924 ellipsoid and the Greenwich prime meridian. Johnston Island 1961 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Johnston Island 1961")] 
		[XmlEnum("56")] 
		JohnstonIsland1961 = 56,

		[Description("A geodetic datum first defined in 1930 suitable for use in Sri Lanka - onshore. Kandawala references the Everest 1830 (1937 Adjustment) ellipsoid and the Greenwich prime meridian. Kandawala origin is Fundamental point: Kandawala. Latitude: 714'06.838\"N, longitude: 7952'36.670\"E. Kandawala is a geodetic datum for Topographic mapping. It was defined by information from Abeyratne, Featherstone and Tantrigoda in Survey Review vol. 42 no. 317 (July 2010).")]
		[EnumMember(Value = "Kandawala")] 
		[XmlEnum("57")] 
		Kandawala = 57,

		[Description("A geodetic datum first defined in 1949 suitable for use in French Southern Territories - Kerguelen onshore. References the International 1924 ellipsoid and the Greenwich prime meridian. Origin is K0 1949. Is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from IGN Paris.")]
		[EnumMember(Value = "Kerguelen Island 1949")] 
		[XmlEnum("58")] 
		KerguelenIsland1949 = 58,

		[Description("A geodetic datum first defined in 1968 suitable for use in Malaysia - West Malaysia onshore and offshore east coast; Singapore - onshore and offshore. Kertau 1968 references the Everest 1830 Modified ellipsoid and the Greenwich prime meridian. Kertau 1968 origin is Fundamental point: Kertau. Latitude: 327'50.710\"N, longitude: 10237'24.550\"E (of Greenwich). Kertau 1968 is a geodetic datum for Geodetic survey, cadastre. It was defined by information from Defence Geographic Centre. Replaces MRT48 and earlier adjustments. Adopts metric conversion of 39.370113 inches per metre. Not used for 1969 metrication of RSO grid - see Kertau (RSO) (code 6751).")]
		[EnumMember(Value = "Kertau 1968")] 
		[XmlEnum("59")] 
		Kertau1968 = 59,

		[Description("A geodetic datum first defined in 1951 suitable for use in Federated States of Micronesia - Kosrae (Kusaie). Kusaie 1951 references the International 1924 ellipsoid and the Greenwich prime meridian. Kusaie 1951 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Kusaie Astro 1951")] 
		[XmlEnum("60")] 
		KusaieAstro1951 = 60,

		[Description("L. C. 5 Astro 1961 datum.")]
		[EnumMember(Value = "L. C. 5 Astro 1961")] 
		[XmlEnum("61")] 
		LC5Astro1961 = 61,

		[Description("A geodetic datum suitable for use in Ghana - onshore and offshore. Leigon references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Leigon origin is Fundamental point: GCS Station 121, Leigon. Latitude: 538'52.27\"N, longitude: 011'46.08\"W (of Greenwich). Leigon is a geodetic datum for Topographic mapping. It was defined by information from Ordnance Survey International. Replaced Accra datum (code 6168) from 1978. Coordinates at Leigon fundamental point defined as Accra datum values for that point.")]
		[EnumMember(Value = "Leigon")] 
		[XmlEnum("62")] 
		Leigon = 62,

		[Description("A geodetic datum first defined in 1964 suitable for use in Liberia - onshore. Liberia 1964 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Liberia 1964 origin is Fundamental point: Robertsfield. Latitude: 613'53.02\"N, longitude: 1021'35.44\"W (of Greenwich). Liberia 1964 is a geodetic datum for Topographic mapping. It was defined by information from NIMA http://earth-info.nima.mil/.")]
		[EnumMember(Value = "Liberia 1964")] 
		[XmlEnum("63")] 
		Liberia1964 = 63,

		[Description("A geodetic datum first defined in 1911 suitable for use in Philippines - onshore. Luzon references the Clarke 1866 ellipsoid and the Greenwich prime meridian. Luzon origin is Fundamental point: Balacan. Latitude: 1333'41.000\"N, longitude: 12152'03.000\"E (of Greenwich). Luzon is a geodetic datum for Topographic mapping. It was defined by information from Coast and Geodetic Survey Replaced by Philippine Reference system of 1992 (datum code 6683).")]
		[EnumMember(Value = "Luzon")] 
		[XmlEnum("64")] 
		Luzon = 64,

		[Description("A geodetic datum first defined in 1971 suitable for use in Seychelles - Mahe Island. Mahe 1971 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Mahe 1971 origin is Fundamental point: Station SITE. Latitude: 440'14.644\"S, longitude: 5528'44.488\"E (of Greenwich). Mahe 1971 is a geodetic datum for US military survey. It was defined by information from Clifford Mugnier's September 2007 PE&RS \"Grids and Datums\" article on Seychelles (www.asprs.org/resources/grids/). South East Island 1943 (datum code 1138) used for topographic mapping, cadastral and hydrographic survey.")]
		[EnumMember(Value = "Mahe 1971")] 
		[XmlEnum("65")] 
		Mahe1971 = 65,

		[Description("A geodetic datum suitable for use in Eritrea - onshore and offshore. Massawa references the Bessel 1841 ellipsoid and the Greenwich prime meridian. Massawa is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Massawa")] 
		[XmlEnum("66")] 
		Massawa = 66,

		[Description("A geodetic datum first defined in 1922 suitable for use in Morocco - onshore. Merchich references the Clarke 1880 (IGN) ellipsoid and the Greenwich prime meridian. Merchich origin is Fundamental point: Merchich. Latitude: 3326'59.672\"N, longitude: 733'27.295\"W (of Greenwich). Merchich is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Merchich")] 
		[XmlEnum("67")] 
		Merchich = 67,

		[Description("A geodetic datum first defined in 1961 suitable for use in United States Minor Outlying Islands - Midway Islands - Sand Island and Eastern Island. Midway 1961 references the International 1924 ellipsoid and the Greenwich prime meridian. Midway 1961 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Midway Astro 1961")] 
		[XmlEnum("68")] 
		MidwayAstro1961 = 68,

		[Description("A geodetic datum suitable for use in Nigeria - onshore and offshore. Minna references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Minna origin is Fundamental point: Minna base station L40. Latitude: 938'08.87\"N, longitude: 630'58.76\"E (of Greenwich). Minna is a geodetic datum for Topographic mapping. It was defined by information from NIMA http://earth-info.nima.mil/.")]
		[EnumMember(Value = "Minna")] 
		[XmlEnum("69")] 
		Minna = 69,

		[Description("A geodetic datum first defined in 1958 suitable for use in Montserrat - onshore. Montserrat 1958 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Montserrat 1958 origin is Fundamental point: station M36. Montserrat 1958 is a geodetic datum for Topographic mapping. It was defined by information from Ordnance Survey of Great Britain.")]
		[EnumMember(Value = "Montserrat Island Astro 1958")] 
		[XmlEnum("70")] 
		MontserratIslandAstro1958 = 70,

		[Description("A geodetic datum suitable for use in Gabon - onshore and offshore. M'poraloko references the Clarke 1880 (IGN) ellipsoid and the Greenwich prime meridian. M'poraloko is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "M'poraloko")] 
		[XmlEnum("71")] 
		MPoraloko = 71,

		[Description("A geodetic datum first defined in 1934 suitable for use in Iraq - onshore; Iran - onshore northern Gulf coast and west bordering southeast Iraq. Nahrwan 1934 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Nahrwan 1934 origin is Fundamental point: Nahrwan south base. Latitude: 3319'10.87\"N, longitude: 4443'25.54\"E (of Greenwich). Nahrwan 1934 is a geodetic datum for Oil exploration and production. It was defined by information from Various industry sources. This adjustment later discovered to have a significant orientation error. In Iran replaced by FD58. In Iraq, replaced by Karbala 1979.")]
		[EnumMember(Value = "Nahrwan")] 
		[XmlEnum("72")] 
		Nahrwan = 72,

		[Description("A geodetic datum first defined in 1972 suitable for use in Trinidad and Tobago - Tobago - onshore. Naparima 1972 references the International 1924 ellipsoid and the Greenwich prime meridian. Naparima 1972 origin is Fundamental point: Naparima. Latitude: 1016'44.860\"N, longitude: 6127'34.620\"W (of Greenwich). Naparima 1972 is a geodetic datum for Topographic mapping. It was defined by information from Ordnance Survey International. Naparima 1972 is an extension of the Naparima 1955 network of Trinidad to include Tobago.")]
		[EnumMember(Value = "Naparima, BWI")] 
		[XmlEnum("73")] 
		NaparimaBwi = 73,

		[Description("A geodetic datum first defined in 1927 suitable for use in North and central America; Antigua and Barbuda; Bahamas; Belize; British Virgin Islandss. Usage shall be onshore only except that onshore and offshore shall apply to Canada east coast (New Brunswick; Newfoundland and Labrador; Prince Edward Island; Quebec). Cuba. Mexico (Gulf of Mexico and Caribbean coasts only). USA Alaska. USA Gulf of Mexico (Alabama; Florida; Louisiana; Mississippi; Texas). USA East Coast. Bahamas onshore plus offshore over internal continental shelf only. North American Datum 1927 references the Clarke 1866 ellipsoid and the Greenwich prime meridian. North American Datum 1927 origin is Fundamental point: Meade's Ranch. Latitude: 3913'26.686\"N, longitude: 9832'30.506\"W (of Greenwich). North American Datum 1927 is a geodetic datum for Topographic mapping. In United States (USA) and Canada, replaced by North American Datum 1983 (NAD83) (code 6269) ; in Mexico, replaced by Mexican Datum of 1993 (code 1042).")]
		[EnumMember(Value = "North American 1927")] 
		[XmlEnum("74")] 
		NorthAmerican1927 = 74,

		[Description("A geodetic datum first defined in 1986 suitable for use in North America - onshore and offshore: Canada; Puerto Rico; United States (USA); US Virgin Islands; British Virgin Islands. North American Datum 1983 references the GRS 1980 ellipsoid and the Greenwich prime meridian. North American Datum 1983 origin is Origin at geocentre. North American Datum 1983 is a geodetic datum for Topographic mapping. Although the 1986 adjustment included connections to Greenland and Mexico, it has not been adopted there. In Canada and US, replaced NAD27.")]
		[EnumMember(Value = "North American 1983")] 
		[XmlEnum("75")] 
		NorthAmerican1983 = 75,

		[Description("A geodetic datum first defined in 1939 suitable for use in Portugal - western Azores onshore - Flores, Corvo. Azores Occidental Islands 1939 references the International 1924 ellipsoid and the Greenwich prime meridian. Azores Occidental Islands 1939 origin is Fundamental point: Observatario Meteorologico Flores. Azores Occidental Islands 1939 is a geodetic datum for Topographic mapping. It was defined by information from Instituto Geografico e Cadastral Lisbon via EuroGeographics; http://crs.bkg.bund.de/crs-eu/.")]
		[EnumMember(Value = "Observatorio Meteorologico 1939")] 
		[XmlEnum("76")] 
		ObservatorioMeteorologico1939 = 76,

		[Description("A geodetic datum first defined in 1907 suitable for use in Egypt - onshore and offshore. Egypt 1907 references the Helmert 1906 ellipsoid and the Greenwich prime meridian. Egypt 1907 origin is Fundamental point: Station F1 (Venus). Latitude: 3001'42.86\"N, longitude: 3116'33.60\"E (of Greenwich). Egypt 1907 is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey.")]
		[EnumMember(Value = "Old Egyptian 1907")] 
		[XmlEnum("77")] 
		OldEgyptian1907 = 77,

		[Description("A geodetic datum suitable for use in United States (USA) - Hawaii - main islands onshore. Old Hawaiian references the Clarke 1866 ellipsoid and the Greenwich prime meridian. Old Hawaiian origin is Fundamental point: Oahu West Base Astro. Latitude: 2118'13.89\"N, longitude 15750'55.79\"W (of Greenwich). Old Hawaiian is a geodetic datum for Topographic mapping. It was defined by information from http://www.ngs.noaa.gov/ (NADCON readme file). Hawaiian Islands were never on NAD27 but rather on Old Hawaiian Datum. NADCON conversion program provides transformation from Old Hawaiian Datum to NAD83 (original 1986 realization) but making the transformation appear to user as if from NAD27.")]
		[EnumMember(Value = "Old Hawaiian")] 
		[XmlEnum("78")] 
		OldHawaiian = 78,

		[Description("A geodetic datum first defined in 2013 suitable for use in Oman - onshore and offshore. Oman National Geodetic Datum 2014 references the GRS 1980 ellipsoid and the Greenwich prime meridian. Oman National Geodetic Datum 2014 origin is 20 stations of the Oman primary network tied to ITRF2008 at epoch 2013.15. Oman National Geodetic Datum 2014 is a geodetic datum for Geodetic Survey. It was defined by information from National Survey Authority, Sultanate of Oman. Replaces WGS 84 (G874).")]
		[EnumMember(Value = "Oman")] 
		[XmlEnum("79")] 
		Oman = 79,

		[Description("A geodetic datum first defined in 1936 suitable for use in United Kingdom (UK) - offshore to boundary of UKCS within 4946'N to 6101'N and 733'W to 333'E; onshore Great Britain (England, Wales and Scotland). Isle of Man onshore. OSGB 1936 references the Airy 1830 ellipsoid and the Greenwich prime meridian. OSGB 1936 origin is Prior to 2002, fundamental point: Herstmonceux, Latitude: 5051'55.271\"N, longitude: 020'45.882\"E (of Greenwich). From April 2002 the datum is defined through the application of the OSTN transformation from ETRS89. OSGB 1936 is a geodetic datum for Topographic mapping. It was defined by information from Ordnance Survey of Great Britain. The average accuracy of OSTN compared to the old triangulation network (down to 3rd order) is 0.1m. With the introduction of OSTN15, the area for OSGB 1936 has effectively been extended from Britain to cover the adjacent UK Continental Shelf.")]
		[EnumMember(Value = "Ordnance Survey of Great Britain 1936")] 
		[XmlEnum("80")] 
		OrdnanceSurveyOfGreatBritain1936 = 80,

		[Description("A geodetic datum suitable for use in Spain - Canary Islands onshore. Pico de las Nieves 1984 references the International 1924 ellipsoid and the Greenwich prime meridian. Pico de las Nieves 1984 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000). Replaces Pico de las Nieves 1968 (PN68). Replaced by REGCAN95.")]
		[EnumMember(Value = "Pico de las Nieves")] 
		[XmlEnum("81")] 
		PicoDeLasNieves = 81,

		[Description("A geodetic datum first defined in 1967 suitable for use in Pitcairn - Pitcairn Island. Pitcairn 1967 references the International 1924 ellipsoid and the Greenwich prime meridian. Pitcairn 1967 origin is Fundamental point: Pitcairn Astro. Latitude: 2504'06.87\"S, longitude: 13006'47.83\"W (of Greenwich). Pitcairn 1967 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000). Replaced by Pitcairn 2006.")]
		[EnumMember(Value = "Pitcairn Astro 1967")] 
		[XmlEnum("82")] 
		PitcairnAstro1967 = 82,

		[Description("A geodetic datum first defined in 1969 suitable for use in Senegal - central, Mali - southwest, Burkina Faso - central, Niger - southwest, Nigeria - north, Chad - central. All in proximity to the parallel of latitude of 12N. Point 58 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Point 58 origin is Fundamental point: Point 58. Latitude: 1252'44.045\"N, longitude: 358'37.040\"E (of Greenwich). Point 58 is a geodetic datum for Geodetic survey. It was defined by information from IGN Paris. Used as the basis for computation of the 12th Parallel traverse conducted 1966-70 from Senegal to Chad and connecting to the Blue Nile 1958 (Adindan) triangulation in Sudan.")]
		[EnumMember(Value = "Point 58")] 
		[XmlEnum("83")] 
		Point58 = 83,

		[Description("Pointe Noire 1948 datum.")]
		[EnumMember(Value = "Pointe Noire 1948")] 
		[XmlEnum("84")] 
		PointeNoire1948 = 84,

		[Description("A geodetic datum first defined in 1936 suitable for use in Portugal - Madeira, Porto Santo and Desertas islands - onshore. Porto Santo 1936 references the International 1924 ellipsoid and the Greenwich prime meridian. Porto Santo 1936 origin is SE Base on Porto Santo island. Porto Santo 1936 is a geodetic datum for Topographic mapping. It was defined by information from Instituto Geografico e Cadastral Lisbon http://www.igeo.pt Replaced by 1995 adjustment (datum code 6663). For Selvagens see Selvagem Grande (code 6616).")]
		[EnumMember(Value = "Porto Santo 1936")] 
		[XmlEnum("85")] 
		PortoSanto1936 = 85,

		[Description("A geodetic datum first defined in 1956 suitable for use in Aruba - onshore; Bolivia; Bonaire - onshore; Brazil - offshore - Amazon Cone shelf; Chile - onshore north of 4330'S; Curacao - onshore; Ecuador - mainland onshore; Guyana - onshore; Peru - onshore; Venezuela - onshore. Provisional South American Datum 1956 references the International 1924 ellipsoid and the Greenwich prime meridian. Provisional South American Datum 1956 origin is Fundamental point: La Canoa. Latitude: 834'17.170\"N, longitude: 6351'34.880\"W (of Greenwich). Provisional South American Datum 1956 is a geodetic datum for Topographic mapping. Same origin as La Canoa datum.")]
		[EnumMember(Value = "Provisional South American 1956")] 
		[XmlEnum("86")] 
		ProvisionalSouthAmerican1956 = 86,

		[Description("A geodetic datum first defined in 1963 suitable for use in Argentina and Chile - Tierra del Fuego, onshore. Hito XVIII 1963 references the International 1924 ellipsoid and the Greenwich prime meridian. Hito XVIII 1963 origin is Chile-Argentina boundary survey. Hito XVIII 1963 is a geodetic datum for Geodetic survey. It was defined by information from Various oil company records. Used in Tierra del Fuego.")]
		[EnumMember(Value = "Provisional South Chilean 1963")] 
		[XmlEnum("87")] 
		ProvisionalSouthChilean1963 = 87,

		[Description("A geodetic datum first defined in 1901 suitable for use in Puerto Rico, US Virgin Islands and British Virgin Islands - onshore. Puerto Rico references the Clarke 1866 ellipsoid and the Greenwich prime meridian. Puerto Rico origin is Fundamental point: Cardona Island Lighthouse. Latitude:1757'31.40\"N, longitude: 6638'07.53\"W (of Greenwich). Puerto Rico is a geodetic datum for Topographic mapping. It was defined by information from Ordnance Survey of Great Britain and http://www.ngs.noaa.gov/ (NADCON readme file). NADCON conversion program provides transformation from Puerto Rico Datum to NAD83 (original 1986 realization) but making the transformation appear to user as if from NAD27.")]
		[EnumMember(Value = "Puerto Rico")] 
		[XmlEnum("88")] 
		PuertoRico = 88,

		[Description("A geodetic datum first defined in 1995 suitable for use in Qatar - onshore. Qatar National Datum 1995 references the International 1924 ellipsoid and the Greenwich prime meridian. Qatar National Datum 1995 origin is defined by transformation from WGS 84 - see coordinate operation code 1840. Qatar National Datum 1995 is a geodetic datum for Topographic mapping. It was defined by information from Qatar Centre for Geographic Information.")]
		[EnumMember(Value = "Qatar National")] 
		[XmlEnum("89")] 
		QatarNational = 89,

		[Description("A geodetic datum first defined in 1927 suitable for use in Greenland - west coast onshore. Qornoq 1927 references the International 1924 ellipsoid and the Greenwich prime meridian. Qornoq 1927 origin is Fundamental point: Station 7008. Latitude: 6431'06.27\"N, longitude: 5112'24.86\"W (of Greenwich). Qornoq 1927 is a geodetic datum for Topographic mapping. It was defined by information from Kort & Matrikelstyrelsen, Copenhagen. Origin coordinates from NIMA http://earth-info.nima.mil/.")]
		[EnumMember(Value = "Qornoq")] 
		[XmlEnum("90")] 
		Qornoq = 90,

		[Description("A geodetic datum first defined in 1947 suitable for use in Reunion - onshore. Reunion 1947 references the International 1924 ellipsoid and the Greenwich prime meridian. Reunion 1947 origin is Fundamental point: Piton des Neiges (Borne). Latitude: 2105'13.119\"S, longitude: 5529'09.193\"E (of Greenwich). Reunion 1947 is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from IGN Paris. Replaced by RGR92 (datum code 6627).")]
		[EnumMember(Value = "Reunion")] 
		[XmlEnum("91")] 
		Reunion = 91,

		[Description("A geodetic datum first defined in and is suitable for use in Italy - onshore and offshore; San Marino, Vatican City State. Monte Mario (Rome) references the International 1924 ellipsoid and the Rome prime meridian. Monte Mario (Rome) origin is Fundamental point: Monte Mario. Latitude: 4155'25.51\"N, longitude: 000' 00.00\"E (of Rome). Monte Mario (Rome) is a geodetic datum for Topographic mapping. Replaced Genova datum, Bessel 1841 ellipsoid, from 1940.")]
		[EnumMember(Value = "Rome 1940")] 
		[XmlEnum("92")] 
		Rome1940 = 92,

		[Description("A geodetic datum first defined in 1965 suitable for use in Vanuatu - northern islands - Aese, Ambrym, Aoba, Epi, Espiritu Santo, Maewo, Malo, Malkula, Paama, Pentecost, Shepherd and Tutuba. Santo 1965 references the International 1924 ellipsoid and the Greenwich prime meridian. Santo 1965 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000). Datum covers all the major islands of Vanuatu in two different adjustment blocks, but practical usage is as given in the area of use.")]
		[EnumMember(Value = "Santo (DOS) 1965")] 
		[XmlEnum("93")] 
		SantoDos1965 = 93,

		[Description("A geodetic datum first defined in 1995 suitable for use in Portugal - eastern Azores onshore - Sao Miguel, Santa Maria, Formigas. Azores Oriental Islands 1995 references the International 1924 ellipsoid and the Greenwich prime meridian. Azores Oriental Islands 1995 origin is Fundamental point: Forte de So Bras. Origin and orientation constrained to those of the 1940 adjustment. Azores Oriental Islands 1995 is a geodetic datum for Topographic mapping. It was defined by information from Instituto Geografico e Cadastral Lisbon; http://www.igeo.pt/ Classical and GPS observations. Replaces 1940 adjustment (datum code 6184).")]
		[EnumMember(Value = "Sao Braz")] 
		[XmlEnum("94")] 
		SaoBraz = 94,

		[Description("A geodetic datum first defined in 1943 suitable for use in Falkland Islands (Malvinas) - onshore. Sapper Hill 1943 references the International 1924 ellipsoid and the Greenwich prime meridian. Sapper Hill 1943 is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Sapper Hill 1943")] 
		[XmlEnum("95")] 
		SapperHill1943 = 95,

		[Description("A geodetic datum suitable for use in Namibia - onshore and offshore. Schwarzeck references the Bessel Namibia (GLM) ellipsoid and the Greenwich prime meridian. Schwarzeck origin is Fundamental point: Schwarzeck. Latitude: 2245'35.820\"S, longitude: 1840'34.549\"E (of Greenwich). Fixed during German South West Africa-British Bechuanaland boundary survey of 1898-1903. Schwarzeck is a geodetic datum for Topographic mapping. It was defined by information from Private Communication, Directorate of Surveys and Land Information, Cape Town.")]
		[EnumMember(Value = "Schwarzeck")] 
		[XmlEnum("96")] 
		Schwarzeck = 96,

		[Description("A geodetic datum suitable for use in Portugal - Selvagens islands (Madeira province) - onshore. Selvagem Grande references the International 1924 ellipsoid and the Greenwich prime meridian. Selvagem Grande is a geodetic datum for Topographic mapping. It was defined by information from Instituto Geografico e Cadastral Lisbon http://www.igeo.pt.")]
		[EnumMember(Value = "Selvagem Grande 1938")] 
		[XmlEnum("97")] 
		SelvagemGrande1938 = 97,

		[Description("A geodetic datum first defined in 1969 suitable for use in Brazil - onshore and offshore. In rest of South America - onshore north of approximately 45S and Tierra del Fuego. South American Datum 1969 references the GRS 1967 Modified ellipsoid and the Greenwich prime meridian. South American Datum 1969 origin is Fundamental point: Chua. Geodetic latitude: 1945'41.6527\"S; geodetic longitude: 4806'04.0639\"W (of Greenwich). (Astronomic coordinates: Latitude 1945'41.34\"S +/- 0.05\", longitude 4806'07.80\"W +/- 0.08\"). South American Datum 1969 is a geodetic datum for Topographic mapping. It was defined by information from DMA 1974. SAD69 uses GRS 1967 ellipsoid but with 1/f to exactly 2 decimal places. In Brazil only, replaced by SAD69(96) (datum code 1075).")]
		[EnumMember(Value = "South American 1969")] 
		[XmlEnum("98")] 
		SouthAmerican1969 = 98,

		[Description("South Asia datum.")]
		[EnumMember(Value = "South Asia")] 
		[XmlEnum("99")] 
		SouthAsia = 99,

		[Description("A geodetic datum first defined in 1925 suitable for use in Madagascar - onshore and nearshore. Tananarive 1925 references the International 1924 ellipsoid and the Greenwich prime meridian. Tananarive 1925 origin is Fundamental point: Tananarive observatory. Latitude: 1855'02.10\"S, longitude: 4733'06.75\"E (of Greenwich). Tananarive 1925 is a geodetic datum for Topographic mapping. It was defined by information from IGN Paris.")]
		[EnumMember(Value = "Tananarive Observatory 1925")] 
		[XmlEnum("100")] 
		TananariveObservatory1925 = 100,

		[Description("A geodetic datum first defined in 1948 suitable for use in Brunei - onshore and offshore; Malaysia - East Malaysia (Sabah; Sarawak) - onshore and offshore. Timbalai 1948 references the Everest 1830 (1967 Definition) ellipsoid and the Greenwich prime meridian. Timbalai 1948 origin is Fundamental point: Station P85 at Timbalai. Latitude: 517' 3.548\"N, longitude: 11510'56.409\"E (of Greenwich). Timbalai 1948 is a geodetic datum for Topographic mapping. It was defined by information from Defence Geographic Centre. In 1968, the original adjustment was densified in Sarawak and extended to Sabah.")]
		[EnumMember(Value = "Timbalai 1948")] 
		[XmlEnum("101")] 
		Timbalai1948 = 101,

		[Description("A geodetic datum first defined in 1918 suitable for use in Japan - onshore; North Korea - onshore; South Korea - onshore. Tokyo references the Bessel 1841 ellipsoid and the Greenwich prime meridian. Tokyo origin is Fundamental point: Nikon-Keido-Genten. Latitude: 3539'17.5148\"N, longitude: 13944'40.5020\"E (of Greenwich). Longitude derived in 1918. Tokyo is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from Geographic Survey Institute; Japan; Bulletin 40 (March 1994). Also http://vldb.gsi.go.jp/sokuchi/datum/tokyodatum.html. In Japan, replaces Tokyo 1892 (code 1048) and replaced by Japanese Geodetic Datum 2000 (code 6611). In Korea used only for geodetic applications before being replaced by Korean 1985 (code 6162).")]
		[EnumMember(Value = "Tokyo")] 
		[XmlEnum("102")] 
		Tokyo = 102,

		[Description("A geodetic datum first defined in 1968 suitable for use in St Helena, Ascension and Tristan da Cunha - Tristan da Cunha island group including Tristan, Inaccessible, Nightingale, Middle and Stoltenhoff Islands. Tristan 1968 references the International 1924 ellipsoid and the Greenwich prime meridian. Tristan 1968 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Tristan Astro 1968")] 
		[XmlEnum("103")] 
		TristanAstro1968 = 103,

		[Description("A geodetic datum first defined in 1912 suitable for use in Fiji - Viti Levu island. Viti Levu 1912 references the Clarke 1880 (international foot) ellipsoid and the Greenwich prime meridian. Viti Levu 1912 Latitude origin was obtained astronomically at station Monavatu = 1753'28.285\"S, longitude origin was obtained astronomically at station Suva = 17825'35.835\"E. Viti Levu 1912 is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from Clifford J. Mugnier in Photogrammetric Engineering and Remote Sensing, October 2000, www.asprs.org. For topographic mapping, replaced by Fiji 1956. For other purposes, replaced by Fiji 1986.")]
		[EnumMember(Value = "Viti Levu 1916")] 
		[XmlEnum("104")] 
		VitiLevu1916 = 104,

		[Description("A geodetic datum first defined in 1960 suitable for use in Marshall Islands - onshore. Wake atoll onshore. Marshall Islands 1960 references the Hough 1960 ellipsoid and the Greenwich prime meridian. Marshall Islands 1960 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Wake-Eniwetok 1960")] 
		[XmlEnum("105")] 
		WakeEniwetok1960 = 105,

		[Description("A geodetic datum first defined in 1952 suitable for use in Wake atoll - onshore. Wake Island 1952 references the International 1924 ellipsoid and the Greenwich prime meridian. Wake Island 1952 is a geodetic datum for Military and topographic mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Wake Island Astro 1952")] 
		[XmlEnum("106")] 
		WakeIslandAstro1952 = 106,

		[Description("A geodetic datum suitable for use in Uruguay - onshore. Yacare references the International 1924 ellipsoid and the Greenwich prime meridian. Yacare origin is Fundamental point: Yacare. Latitude: 3035'53.68\"S, longitude: 5725'01.30\"W (of Greenwich). Yacare is a geodetic datum for Topographic mapping. It was defined by information from NIMA http://earth-info.nima.mil/")]
		[EnumMember(Value = "Yacare")] 
		[XmlEnum("107")] 
		Yacare = 107,

		[Description("A geodetic datum suitable for use in Suriname - onshore and offshore. Zanderij references the International 1924 ellipsoid and the Greenwich prime meridian. Zanderij is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Zanderij")] 
		[XmlEnum("108")] 
		Zanderij = 108,

		[Description("A geodetic datum first defined in 1962 suitable for use in American Samoa - Tutuila, Aunu'u, Ofu, Olesega and Ta'u islands. American Samoa 1962 references the Clarke 1866 ellipsoid and the Greenwich prime meridian. American Samoa 1962 origin is Fundamental point: Betty 13 eccentric. Latitude: 1420'08.34\"S, longitude: 17042'52.25\"W (of Greenwich). American Samoa 1962 is a geodetic datum for Topographic mapping. It was defined by information from NIMA TR8350.2 revision of January 2000. Oil industry sources for origin description details.")]
		[EnumMember(Value = "American Samoa 1962")] 
		[XmlEnum("109")] 
		AmericanSamoa1962 = 109,

		[Description("A geodetic datum suitable for use in Antarctica - South Shetland Islands - Deception Island. Deception Island references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Deception Island is a geodetic datum for Military and scientific mapping. It was defined by information from DMA / NIMA / NGA TR8350.2 (3rd edition, Amendment 1, 3 January 2000).")]
		[EnumMember(Value = "Deception Island")] 
		[XmlEnum("110")] 
		DeceptionIsland = 110,

		[Description("A geodetic datum suitable for use in Cambodia - onshore; Vietnam - onshore and offshore Cuu Long basin. Indian 1960 references the Everest 1830 (1937 Adjustment) ellipsoid and the Greenwich prime meridian. Indian 1960 origin is DMA extension over IndoChina of the Indian 1954 network adjusted to better fit local geoid. Indian 1960 is a geodetic datum for Topographic mapping. Also known as Indian (DMA Reduced).")]
		[EnumMember(Value = "Indian 1960")] 
		[XmlEnum("111")] 
		Indian1960 = 111,

		[Description("A geodetic datum first defined in 1974 suitable for use in Indonesia - onshore. Indonesian Datum 1974 references the Indonesian National Spheroid ellipsoid and the Greenwich prime meridian. Indonesian Datum 1974 origin is Fundamental point: Padang. Latitude: 056'38.414\"S, longitude: 10022' 8.804\"E (of Greenwich). Ellipsoidal height 3.190m, gravity-related height 14.0m above mean sea level. Indonesian Datum 1974 is a geodetic datum for Topographic mapping. It was defined by information from Bakosurtanal 1979 paper by Jacob Rais. Replaced by DGN95.")]
		[EnumMember(Value = "Indonesian 1974")] 
		[XmlEnum("112")] 
		Indonesian1974 = 112,

		[Description("A geodetic datum first defined in 1959 suitable for use in Algeria - onshore and offshore. Nord Sahara 1959 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Nord Sahara 1959 origin is Coordinates of primary network readjusted on ED50 datum and then transformed conformally to Clarke 1880 (RGS) ellipsoid. Nord Sahara 1959 is a geodetic datum for Topographic mapping. It was defined by information from \"Le System Geodesique Nord-Sahara\"; IGN Paris Adjustment includes Morocco and Tunisia but use only in Algeria. Within Algeria the adjustment is north of 32N but use has been extended southwards in many disconnected projects, some based on independent astro stations rather than the geodetic network.")]
		[EnumMember(Value = "North Sahara 1959")] 
		[XmlEnum("113")] 
		NorthSahara1959 = 113,

		[Description("A geodetic datum first defined in 1942 suitable for use in Armenia; Azerbaijan; Belarus; Estonia - onshore; Georgia - onshore; Kazakhstan; Kyrgyzstan; Latvia - onshore; Lithuania - onshore; Moldova; Russian Federation - onshore; Tajikistan; Turkmenistan; Ukraine - onshore; Uzbekistan. Pulkovo 1942 references the Krassowsky 1940 ellipsoid and the Greenwich prime meridian. Pulkovo 1942 origin is Fundamental point: Pulkovo observatory. Latitude: 5946'18.550\"N, longitude: 3019'42.090\"E (of Greenwich). Pulkovo 1942 is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Pulkovo 1942")] 
		[XmlEnum("114")] 
		Pulkovo1942 = 114,

		[Description("A geodetic datum suitable for use in Czech Republic; Slovakia. System Jednotne Trigonometricke Site Katastralni references the Bessel 1841 ellipsoid and the Greenwich prime meridian. System Jednotne Trigonometricke Site Katastralni origin is Modification of Austrian MGI datum, code 6312. System Jednotne Trigonometricke Site Katastralni is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from Research Institute for Geodesy Topography and Cartography (VUGTK); Prague. S-JTSK = System of the Unified Trigonometrical Cadastral Network.")]
		[EnumMember(Value = "S-JTSK")] 
		[XmlEnum("116")] 
		SJtsk = 116,

		[Description("Voirol 1950 datum.")]
		[EnumMember(Value = "Voirol 1950")] 
		[XmlEnum("117")] 
		Voirol1950 = 117,

		[Description("A geodetic datum first defined in 1977 suitable for use in Canada - New Brunswick; Nova Scotia; Prince Edward Island. Average Terrestrial System 1977 references the Average Terrestrial System 1977 ellipsoid and the Greenwich prime meridian. Average Terrestrial System 1977 is a geodetic datum for Topographic mapping. It was defined by information from New Brunswick Geographic Information Corporation land and water information standards manual. In use from 1979.")]
		[EnumMember(Value = "Average Terrestrial System 1977")] 
		[XmlEnum("118")] 
		AverageTerrestrialSystem1977 = 118,

		[Description("Compensation Geodesique du Quebec 1977.")]
		[EnumMember(Value = "Compensation Geodesique du Quebec 1977")] 
		[XmlEnum("119")] 
		CompensationGeodesiqueDuQuebec1977 = 119,

		[Description("A geodetic datum first defined in 1966 suitable for use in Finland - onshore. Kartastokoordinaattijarjestelma (1966) references the International 1924 ellipsoid and the Greenwich prime meridian. Kartastokoordinaattijarjestelma (1966) origin is Adjustment with fundamental point SF31 based on ED50 transformed to best fit the older VVJ adjustment. Kartastokoordinaattijarjestelma (1966) is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from National Land Survey of Finland; http://www.maanmittauslaitos.fi. Adopted in 1970.")]
		[EnumMember(Value = "Finnish (KKJ)")] 
		[XmlEnum("120")] 
		FinnishKkj = 120,

		[Description("A geodetic datum first defined in 1952 suitable for use in United Kingdom (UK) - Northern Ireland (Ulster) - onshore. OSNI 1952 references the Airy 1830 ellipsoid and the Greenwich prime meridian. OSNI 1952 origin is Position fixed to the coordinates from the 19th century Principle Triangulation of station Divis. Scale and orientation controlled by position of Principle Triangulation stations Knocklayd and Trostan. OSNI 1952 is a geodetic datum for Geodetic survey and topographic mapping. It was defined by information from Ordnance Survey of Northern Ireland. Replaced by Geodetic Datum of 1965 alias 1975 Mapping Adjustment or TM75 (datum code 6300).")]
		[EnumMember(Value = "Ordnance Survey of Ireland")] 
		[XmlEnum("121")] 
		OrdnanceSurveyOfIreland = 121,

		[Description("A geodetic datum first defined in 1969 suitable for use in Malaysia - West Malaysia; Singapore. Kertau (RSO) references the Everest 1830 (RSO 1969) ellipsoid and the Greenwich prime meridian. Kertau (RSO) is a geodetic datum for Metrication of RSO grid. It was defined by information from Defence Geographic Centre. Adopts metric conversion of 0.914398 metres per yard exactly. This is a truncation of the Sears 1922 ratio.")]
		[EnumMember(Value = "Revised Kertau")] 
		[XmlEnum("122")] 
		RevisedKertau = 122,

		[Description("A geodetic datum first defined in 1967 suitable for use in Arabian Gulf; Qatar - offshore; United Arab Emirates (UAE) - Abu Dhabi; Dubai; Sharjah; Ajman; Fujairah; Ras Al Kaimah; Umm Al Qaiwain - onshore and offshore. Nahrwan 1967 references the Clarke 1880 (RGS) ellipsoid and the Greenwich prime meridian. Nahrwan 1967 origin is Fundamental point: Nahrwan south base. Latitude: 3319'10.87\"N, longitude: 4443'25.54\"E (of Greenwich). Nahrwan 1967 is a geodetic datum for Topographic mapping. In Iraq, replaces Nahrwan 1934.")]
		[EnumMember(Value = "Revised Nahrwan")] 
		[XmlEnum("123")] 
		RevisedNahrwan = 123,

		[Description("A geodetic datum first defined in 1987 suitable for use in Greece - onshore. Greek Geodetic Reference System 1987 references the GRS 1980 ellipsoid and the Greenwich prime meridian. Greek Geodetic Reference System 1987 origin is Fundamental point: Dionysos. Latitude 3804'33.8\"N, longitude 2355'51.0\"E of Greenwich; geoid height 7.0 m. Greek Geodetic Reference System 1987 is a geodetic datum for Topographic mapping. It was defined by information from L. Portokalakis; Public Petroleum Corporation of Greece. Replaced (old) Greek datum. Oil industry work based on ED50.")]
		[EnumMember(Value = "GGRS 76 (Greece)")] 
		[XmlEnum("124")] 
		Ggrs76Greece = 124,

		[Description("A geodetic datum first defined in 1895 suitable for use in France - onshore - mainland and Corsica. Nouvelle Triangulation Francaise references the Clarke 1880 (IGN) ellipsoid and the Greenwich prime meridian. Nouvelle Triangulation Francaise origin is Fundamental point: Pantheon. Latitude: 4850'46.522\"N, longitude: 220'48.667\"E (of Greenwich). Nouvelle Triangulation Francaise is a geodetic datum for Topographic mapping.")]
		[EnumMember(Value = "Nouvelle Triangulation de France")] 
		[XmlEnum("125")] 
		NouvelleTriangulationDeFrance = 125,

		[Description("A geodetic datum first defined in 1982 suitable for use in Sweden - onshore and offshore. Rikets koordinatsystem 1990 references the Bessel 1841 ellipsoid and the Greenwich prime meridian. Rikets koordinatsystem 1990 is a geodetic datum for Geodetic survey, cadastre, topographic mapping, engineering survey. It was defined by information from National Land Survey of Sweden Replaces RT38 adjustment (datum code 6308).")]
		[EnumMember(Value = "RT 90 (Sweden)")] 
		[XmlEnum("126")] 
		Rt90Sweden = 126,

		[Description("A geodetic datum first defined in 1994 suitable for use in Australia including Lord Howe Island, Macquarie Islands, Ashmore and Cartier Islands, Christmas Island, Cocos (Keeling) Islands, Norfolk Island. All onshore and offshore. Geocentric Datum of Australia 1994 references the GRS 1980 ellipsoid and the Greenwich prime meridian. Geocentric Datum of Australia 1994 origin is ITRF92 at epoch 1994.0. Geocentric Datum of Australia 1994 is a geodetic datum for Topographic mapping, geodetic survey. It was defined by information from Australian Surveying and Land Information Group Internet WWW page. http://www.auslig.gov.au/geodesy/datums/gda.htm#specs Coincident with WGS84 to within 1 metre.")]
		[EnumMember(Value = "Geocentric Datum of Australia")] 
		[XmlEnum("127")] 
		GeocentricDatumOfAustralia = 127,

		[Description("A geodetic datum first defined in 1954 suitable for use in China - onshore. Beijing 1954 references the Krassowsky 1940 ellipsoid and the Greenwich prime meridian. Beijing 1954 origin is Pulkovo, transferred through Russian triangulation. Beijing 1954 is a geodetic datum for Topographic mapping. It was defined by information from Chinese Science Bulletin, 2009, 54:2714-2721 Scale determined through three baselines in northeast China. Discontinuities at boundaries of adjustment blocks. From 1982 replaced by Xian 1980 and New Beijing.")]
		[EnumMember(Value = "BJZ54 (A954 Beijing Coordinates)")] 
		[XmlEnum("128")] 
		Bjz54A954BeijingCoordinates = 128,

		[Description("Modified BJZ54 datum.")]
		[EnumMember(Value = "Modified BJZ54")] 
		[XmlEnum("129")] 
		ModifiedBjz54 = 129,

		[Description("GDZ80 datum.")]
		[EnumMember(Value = "GDZ80")] 
		[XmlEnum("130")] 
		Gdz80 = 130,

		[Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("131")] 
		LocalDatum = 131,
	}

	/// <summary>
	/// The indication of an element of a signal sequence being a period of light/sound or eclipse/silence.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalStatus : int {
		[Description("The indication of an element of a signal sequence being a period of light or sound.")]
		[EnumMember(Value = "Lit/Sound")] 
		[XmlEnum("1")] 
		LitSound = 1,

		[Description("The indication of an element of a signal sequence being a period of eclipse or silence.")]
		[EnumMember(Value = "Eclipsed/Silent")] 
		[XmlEnum("2")] 
		EclipsedSilent = 2,
	}

	/// <summary>
	/// Classification of the cable based on the services provided.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCable : int {
		[Description("A cable that transmits or distributes electrical power.")]
		[EnumMember(Value = "Power Line")] 
		[XmlEnum("1")] 
		PowerLine = 1,

		[Description("Multiple un-insulated cables usually supported by steel lattice towers. Such features are generally more prominent than normal power lines.")]
		[EnumMember(Value = "Transmission Line")] 
		[XmlEnum("3")] 
		TransmissionLine = 3,

		[Description("A cable that transmits telephone signals.")]
		[EnumMember(Value = "Telephone")] 
		[XmlEnum("4")] 
		Telephone = 4,

		[Description("An apparatus, system or process for communication at a distance by electric transmission over wire.")]
		[EnumMember(Value = "Telegraph")] 
		[XmlEnum("5")] 
		Telegraph = 5,

		[Description("A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.")]
		[EnumMember(Value = "Mooring Cable")] 
		[XmlEnum("6")] 
		MooringCable = 6,

		[Description("A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.")]
		[EnumMember(Value = "Ferry")] 
		[XmlEnum("7")] 
		Ferry = 7,

		[Description("A cable made of glass or plastic fiber designed to guide light along its length, fibre optic cables are widely used in fiber-optic communication, which permits transmission over longer distances and at higher data rates than other forms of communication.")]
		[EnumMember(Value = "Fibre Optic Cable")] 
		[XmlEnum("8")] 
		FibreOpticCable = 8,
	}

	/// <summary>
	/// 	Classification of fixed installation buoy.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfInstallationBuoy : int {
		[Description("incorporates a large buoy which remains on the surface at all times and is moored by 4 or more anchors. Mooring hawsers and cargo hoses lead from a turntable on top of the buoy, so that the buoy does not turn as the ship swings to wind and stream.")]
		[EnumMember(Value = "Catenary Anchor Leg Mooring")] 
		[XmlEnum("1")] 
		CatenaryAnchorLegMooring = 1,

		[Description("a mooring structure used by tankers to load and unload in port approaches or in offshore oil and gas fields. The size of the structure can vary between a large mooring buoy and a manned floating structure. Also known as single point mooring (SPM)")]
		[EnumMember(Value = "Single Buoy Mooring")] 
		[XmlEnum("2")] 
		SingleBuoyMooring = 2,
	}

	/// <summary>
	/// Types of shackle.
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum ShackleType : int {
		[Description("-")]
		[EnumMember(Value = "forelock shackles")] 
		[XmlEnum("1")] 
		ForelockShackles = 1,

		[Description("-")]
		[EnumMember(Value = "clenching shackles")] 
		[XmlEnum("2")] 
		ClenchingShackles = 2,

		[Description("-")]
		[EnumMember(Value = "bolt shackles")] 
		[XmlEnum("3")] 
		BoltShackles = 3,

		[Description("-")]
		[EnumMember(Value = "screw pin shackles")] 
		[XmlEnum("4")] 
		ScrewPinShackles = 4,

		[Description("-")]
		[EnumMember(Value = "kenter shackle")] 
		[XmlEnum("5")] 
		KenterShackle = 5,

		[Description("-")]
		[EnumMember(Value = "quick release link")] 
		[XmlEnum("6")] 
		QuickReleaseLink = 6,
	}

	/// <summary>
	/// Classification of pile, driven into the earth as a foundation or support for a structure.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPile : int {
		[Description("An elongated wood or metal pole embedded in the seabed to serve as a marker or support.")]
		[EnumMember(Value = "Stake")] 
		[XmlEnum("1")] 
		Stake = 1,

		[Description("A vertical piece of timber, metal or concrete forced into the earth or sea bed.")]
		[EnumMember(Value = "Post")] 
		[XmlEnum("3")] 
		Post = 3,

		[Description("A single structure comprising 3 or more piles held together (sections of heavy timber, steel or concrete), and forced into the earth or sea bed.")]
		[EnumMember(Value = "Tripodal")] 
		[XmlEnum("4")] 
		Tripodal = 4,

		[Description("A number of piles, usually in a straight line, and usually connected or bolted together.")]
		[EnumMember(Value = "Piling")] 
		[XmlEnum("5")] 
		Piling = 5,

		[Description("A number of piles, usually in a straight line, but not connected by structural members.")]
		[EnumMember(Value = "Area of Piles")] 
		[XmlEnum("6")] 
		AreaOfPiles = 6,

		[Description("A vertical hollow cylinder of metal, wood, or other material forced into the earth or seabed.")]
		[EnumMember(Value = "Pipe")] 
		[XmlEnum("7")] 
		Pipe = 7,
	}

	/// <summary>
	/// Classification based on the product for which a silo or tank is used.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSiloTank : int {
		[Description("A large storage structure used for storing loose materials.")]
		[EnumMember(Value = "Silo in General")] 
		[XmlEnum("1")] 
		SiloInGeneral = 1,

		[Description("A fixed structure for storing liquids.")]
		[EnumMember(Value = "Tank in General")] 
		[XmlEnum("2")] 
		TankInGeneral = 2,

		[Description("A storage building for grain. Usually a tall frame, metal or concrete structure with an especially compartmented interior.")]
		[EnumMember(Value = "Grain Elevator")] 
		[XmlEnum("3")] 
		GrainElevator = 3,

		[Description("A tower supporting an elevated storage tank of water.")]
		[EnumMember(Value = "Water Tower")] 
		[XmlEnum("4")] 
		WaterTower = 4,
	}

	/// <summary>
	/// The specific shape of the building.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buildingShape : int {
		[Description("A building having many storeys.")]
		[EnumMember(Value = "High-Rise Building")] 
		[XmlEnum("5")] 
		HighRiseBuilding = 5,

		[Description("A polyhedron of which one face is a polygon of any number of sides, and the other faces are triangles with a common vertex.")]
		[EnumMember(Value = "Pyramid")] 
		[XmlEnum("6")] 
		Pyramid = 6,

		[Description("Shaped like a cylinder, which is a solid geometrical figure generated by straight lines fixed in direction and describing with one of its points a closed curve, especially a circle.")]
		[EnumMember(Value = "Cylindrical")] 
		[XmlEnum("7")] 
		Cylindrical = 7,

		[Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
		[EnumMember(Value = "Spherical")] 
		[XmlEnum("8")] 
		Spherical = 8,

		[Description("A shape the sides of which are six equal squares; a regular hexahedron.")]
		[EnumMember(Value = "Cubic")] 
		[XmlEnum("9")] 
		Cubic = 9,
	}

	/// <summary>
	/// The various substances which are transported, stored or exploited.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum product : int {
		[Description("A thick, slippery liquid that will not dissolve in water, usually petroleum based in the context of storage tanks.")]
		[EnumMember(Value = "Oil")] 
		[XmlEnum("1")] 
		Oil = 1,

		[Description("A substance with particles that can move freely, usually a fuel substance in the context of storage tanks.")]
		[EnumMember(Value = "Gas")] 
		[XmlEnum("2")] 
		Gas = 2,

		[Description("A colourless, odourless, tasteless liquid that is a compound of hydrogen and oxygen.")]
		[EnumMember(Value = "Water")] 
		[XmlEnum("3")] 
		Water = 3,

		[Description("A general term for rock and rock fragments ranging in size from pebbles and gravel to boulders or large rock masses.")]
		[EnumMember(Value = "Stone")] 
		[XmlEnum("4")] 
		Stone = 4,

		[Description("A hard black mineral that is burned as fuel.")]
		[EnumMember(Value = "Coal")] 
		[XmlEnum("5")] 
		Coal = 5,

		[Description("A solid rock or mineral from which metal is obtained.")]
		[EnumMember(Value = "Ore")] 
		[XmlEnum("6")] 
		Ore = 6,

		[Description("Any substance obtained by or used in a chemical process.")]
		[EnumMember(Value = "Chemicals")] 
		[XmlEnum("7")] 
		Chemicals = 7,

		[Description("Water that is suitable for human consumption.")]
		[EnumMember(Value = "Drinking Water")] 
		[XmlEnum("8")] 
		DrinkingWater = 8,

		[Description("A white fluid secreted by female mammals as food for their young.")]
		[EnumMember(Value = "Milk")] 
		[XmlEnum("9")] 
		Milk = 9,

		[Description("A mineral from which aluminum is obtained.")]
		[EnumMember(Value = "Bauxite")] 
		[XmlEnum("10")] 
		Bauxite = 10,

		[Description("A solid substance obtained after gas and tar have been extracted from coal, used as a fuel.")]
		[EnumMember(Value = "Coke")] 
		[XmlEnum("11")] 
		Coke = 11,

		[Description("An oblong lump of cast iron metal.")]
		[EnumMember(Value = "Iron Ingots")] 
		[XmlEnum("12")] 
		IronIngots = 12,

		[Description("Sodium chloride obtained from mines or by the evaporation of sea water.")]
		[EnumMember(Value = "Salt")] 
		[XmlEnum("13")] 
		Salt = 13,

		[Description("Loose material consisting of small but easily distinguishable, separate grains, between 0.0625 and 2.000 millimetres in diameter.")]
		[EnumMember(Value = "Sand")] 
		[XmlEnum("14")] 
		Sand = 14,

		[Description("Wood prepared for use in building or carpentry.")]
		[EnumMember(Value = "Timber")] 
		[XmlEnum("15")] 
		Timber = 15,

		[Description("Powdery fragments of wood made in sawing timber or coarse chips produced for use in manufacturing pressed board.")]
		[EnumMember(Value = "Sawdust/Wood Chips")] 
		[XmlEnum("16")] 
		SawdustWoodChips = 16,

		[Description("Discarded metal suitable for being reprocessed.")]
		[EnumMember(Value = "Scrap Metal")] 
		[XmlEnum("17")] 
		ScrapMetal = 17,

		[Description("Natural gas that has been liquefied for ease of transport by cooling the gas to -162 Celsius.")]
		[EnumMember(Value = "Liquefied Natural Gas")] 
		[XmlEnum("18")] 
		LiquefiedNaturalGas = 18,

		[Description("A compressed gas consisting of flammable light hydrocarbons and derived from petroleum.")]
		[EnumMember(Value = "Liquefied Petroleum Gas")] 
		[XmlEnum("19")] 
		LiquefiedPetroleumGas = 19,

		[Description("The fermented juice of grapes.")]
		[EnumMember(Value = "Wine")] 
		[XmlEnum("20")] 
		Wine = 20,

		[Description("A substance made of powdered lime and clay, mixed with water.")]
		[EnumMember(Value = "Cement")] 
		[XmlEnum("21")] 
		Cement = 21,

		[Description("A small hard seed, especially that of any cereal plant such as wheat, rice, corn, rye etc.")]
		[EnumMember(Value = "Grain")] 
		[XmlEnum("22")] 
		Grain = 22,

		[Description("Electric charge or current.")]
		[EnumMember(Value = "Electricity")] 
		[XmlEnum("23")] 
		Electricity = 23,

		[Description("The solid form of water.")]
		[EnumMember(Value = "Ice")] 
		[XmlEnum("24")] 
		Ice = 24,

		[Description("(Particles of less than 0.002mm); stiff, sticky earth that becomes hard when baked.")]
		[EnumMember(Value = "Clay")] 
		[XmlEnum("25")] 
		Clay = 25,
	}

	/// <summary>
	/// Classification of an offshore raised structure.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfOffshorePlatform : int {
		[Description("A temporary mobile structure, either fixed or floating, used in the exploration stages of oil and gas fields.")]
		[EnumMember(Value = "Oil Rig")] 
		[XmlEnum("1")] 
		OilRig = 1,

		[Description("A term used to indicate a permanent offshore structure equipped to control the flow of oil or gas. It does not include entirely submarine structures.")]
		[EnumMember(Value = "Production Platform")] 
		[XmlEnum("2")] 
		ProductionPlatform = 2,

		[Description("A platform from which one's surroundings or events can be observed, noted or recorded such as for scientific study.")]
		[EnumMember(Value = "Observation/Research Platform")] 
		[XmlEnum("3")] 
		ObservationResearchPlatform = 3,

		[Description("A metal lattice tower, buoyant at one end and attached at the other by a universal joint to a concrete filled base on the sea bed. The platform may be fitted with a helicopter platform, emergency accommodation and hawser/hose retrieval.")]
		[EnumMember(Value = "Articulated Loading Platform")] 
		[XmlEnum("4")] 
		ArticulatedLoadingPlatform = 4,

		[Description("A rigid frame or tube with a buoyancy device at its upper end , secured at its lower end to a universal joint on a large steel or concrete base resting on the sea bed, and at its upper end to a mooring buoy by a chain or wire.")]
		[EnumMember(Value = "Single Anchor Leg Mooring")] 
		[XmlEnum("5")] 
		SingleAnchorLegMooring = 5,

		[Description("A platform secured to the sea bed and surmounted by a turntable to which ships moor.")]
		[EnumMember(Value = "Mooring Tower")] 
		[XmlEnum("6")] 
		MooringTower = 6,

		[Description("A man-made structure usually built for the exploration or exploitation of marine resources, marine scientific research, tidal observations, etc.")]
		[EnumMember(Value = "Artificial Island")] 
		[XmlEnum("7")] 
		ArtificialIsland = 7,

		[Description("An offshore oil/gas facility consisting of a moored tanker/barge by which the product is extracted, stored and exported.")]
		[EnumMember(Value = "Floating Production, Storage and Off-Loading Vessel")] 
		[XmlEnum("8")] 
		FloatingProductionStorageAndOffLoadingVessel = 8,

		[Description("A platform used primarily for eating, sleeping and recreation purposes.")]
		[EnumMember(Value = "Accommodation Platform")] 
		[XmlEnum("9")] 
		AccommodationPlatform = 9,

		[Description("A floating structure with control room, power and storage facilities, attached to the sea bed by a flexible pipeline and cables.")]
		[EnumMember(Value = "Navigation, Communication and Control Buoy")] 
		[XmlEnum("10")] 
		NavigationCommunicationAndControlBuoy = 10,

		[Description("A floating structure, anchored to the seabed, for storing oil.")]
		[EnumMember(Value = "Floating Oil Tank")] 
		[XmlEnum("11")] 
		FloatingOilTank = 11,
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
		[Description("Quadrant bounded by the true bearing NW-NE taken from the point of interest; it should be passed to the north side of the mark.")]
		[EnumMember(Value = "North Cardinal Mark")] 
		[XmlEnum("1")] 
		NorthCardinalMark = 1,

		[Description("Quadrant bounded by the true bearing NE-SE taken from the point of interest. It should be passed to the east side of the mark.")]
		[EnumMember(Value = "East Cardinal Mark")] 
		[XmlEnum("2")] 
		EastCardinalMark = 2,

		[Description("Quadrant bounded by the true bearing SE-SW taken from the point of interest; it should be passed to the south side of the mark.")]
		[EnumMember(Value = "South Cardinal Mark")] 
		[XmlEnum("3")] 
		SouthCardinalMark = 3,

		[Description("Quadrant bounded by the true bearing SW-NW taken from the point of interest; it should be passed to the west side of the mark.")]
		[EnumMember(Value = "West Cardinal Mark")] 
		[XmlEnum("4")] 
		WestCardinalMark = 4,
	}

	/// <summary>
	/// The distinct character, such as fixed, flashing, or occulting, which is given to each light to avoid confusion with neighbouring ones.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightCharacteristic : int {
		[Description("A signal light that shows continuously, in any given direction, with constant luminous intensity and colour.")]
		[EnumMember(Value = "Fixed")] 
		[XmlEnum("1")] 
		Fixed = 1,

		[Description("A rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
		[EnumMember(Value = "Flashing")] 
		[XmlEnum("2")] 
		Flashing = 2,

		[Description("A single-flashing light in which a single flash of not less than two seconds duration is regularly repeated.")]
		[EnumMember(Value = "Long-Flashing")] 
		[XmlEnum("3")] 
		LongFlashing = 3,

		[Description("A rhythmic light in which flashes are repeated at a rate of not less than 50 flashes per minutes but less than 80 flashes per minutes. It may be: - Continuous quick-flashing: A quick-flashing light in which a flash is regularly repeated. - Group quick-flashing: A quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
		[EnumMember(Value = "Quick-Flashing")] 
		[XmlEnum("4")] 
		QuickFlashing = 4,

		[Description("A rhythmic light in which flashes are repeated at a rate of not less than 80 flashes per minute but less than 160 flashes per minute. It may be:- Continuous very quick-flashing: A very quick-flashing light in which a flash is regularly repeated.- Group very quick-flashing: A very quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
		[EnumMember(Value = "Very Quick-Flashing")] 
		[XmlEnum("5")] 
		VeryQuickFlashing = 5,

		[Description("A rhythmic light in which flashes are regularly repeated at a rate of not less than 160 flashes per minute.")]
		[EnumMember(Value = "Continuous Ultra Quick-Flashing")] 
		[XmlEnum("6")] 
		ContinuousUltraQuickFlashing = 6,

		[Description("A light with all durations of light and darkness equal.")]
		[EnumMember(Value = "Isophased")] 
		[XmlEnum("7")] 
		Isophased = 7,

		[Description("A rhythmic light in which the total duration of light in a period is clearly longer than the total duration of darkness and all the eclipses are of equal duration. It may be:  - Single-occulting: An occulting light in which an eclipse is regularly repeated.  - Group-occulting: An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated.  - Composite group-occulting: An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.")]
		[EnumMember(Value = "Occulting")] 
		[XmlEnum("8")] 
		Occulting = 8,

		[Description("A rhythmic light in which appearances of light of two clearly different durations are grouped to represent a character or characters in the Morse code.")]
		[EnumMember(Value = "Morse")] 
		[XmlEnum("12")] 
		Morse = 12,

		[Description("A rhythmic light in which a fixed light is combined with a flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Fixed and Flash")] 
		[XmlEnum("13")] 
		FixedAndFlash = 13,

		[Description("A rhythmic light in which a flashing light is combined with a long-flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Flash and Long-Flash")] 
		[XmlEnum("14")] 
		FlashAndLongFlash = 14,

		[Description("A rhythmic light in which an occulting light is combined with a flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Occulting and Flash")] 
		[XmlEnum("15")] 
		OccultingAndFlash = 15,

		[Description("A rhythmic light in which a fixed light is combined with a long-flashing light of higher luminous intensity.")]
		[EnumMember(Value = "Fixed and Long-Flash")] 
		[XmlEnum("16")] 
		FixedAndLongFlash = 16,

		[Description("An alternating light in which the total duration of light in each period is clearly longer than the total duration of darkness and in which the intervals of darkness (occultations) are all of equal duration.")]
		[EnumMember(Value = "Occulting Alternating")] 
		[XmlEnum("17")] 
		OccultingAlternating = 17,

		[Description("An alternating single-flashing light in which an appearance of light of not less than two seconds duration is regularly repeated.")]
		[EnumMember(Value = "Long-Flash Alternating")] 
		[XmlEnum("18")] 
		LongFlashAlternating = 18,

		[Description("An alternating rhythmic light in which the total duration of light in a period is clearly shorter than the total duration of darkness and all the appearances of light are of equal duration.")]
		[EnumMember(Value = "Flash Alternating")] 
		[XmlEnum("19")] 
		FlashAlternating = 19,

		[Description("Occulting light in which the occultations are combined in groups, each group including the same number of occultations, and in which the groups are repeated at regular intervals.")]
		[EnumMember(Value = "Group Alternating")] 
		[XmlEnum("20")] 
		GroupAlternating = 20,

		[Description("A rhythmic light in which a group of quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Quick-Flash Plus Long-Flash")] 
		[XmlEnum("25")] 
		QuickFlashPlusLongFlash = 25,

		[Description("A rhythmic light in which a group of very quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Very Quick-Flash Plus Long-Flash")] 
		[XmlEnum("26")] 
		VeryQuickFlashPlusLongFlash = 26,

		[Description("A rhythmic light in which a group of ultra quick flashes is followed by one or more long flashes in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Ultra Quick-Flash Plus Long-Flash")] 
		[XmlEnum("27")] 
		UltraQuickFlashPlusLongFlash = 27,

		[Description("A signal light that shows, in any given direction, two or more colours in a regularly repeated sequence with a regular periodicity.")]
		[EnumMember(Value = "Alternating")] 
		[XmlEnum("28")] 
		Alternating = 28,

		[Description("")]
		[EnumMember(Value = "Fixed and Alternating Flashing")] 
		[XmlEnum("29")] 
		FixedAndAlternatingFlashing = 29,

		[Description("An occulting light in which a group of two or more eclipses, which are specified in number, is regularly repeated.")]
		[EnumMember(Value = "Group-occulting light")] 
		[XmlEnum("30")] 
		GroupOccultingLight = 30,

		[Description("An occulting light in which a sequence of groups of one or more eclipses, which are specified in number, is regularly repeated, and the groups comprise different numbers of eclipses.")]
		[EnumMember(Value = "Composite group-occulting light")] 
		[XmlEnum("31")] 
		CompositeGroupOccultingLight = 31,

		[Description("A flashing light in which a group of flashes, specified in number, is regularly repeated.")]
		[EnumMember(Value = "Group flashing light")] 
		[XmlEnum("32")] 
		GroupFlashingLight = 32,

		[Description("A light similar to a group-flashing light except that successive groups in a period have different numbers of flashes.")]
		[EnumMember(Value = "Composite group-flashing light")] 
		[XmlEnum("33")] 
		CompositeGroupFlashingLight = 33,

		[Description(" A quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
		[EnumMember(Value = "Group quick light")] 
		[XmlEnum("34")] 
		GroupQuickLight = 34,

		[Description("A very quick-flashing light in which a group of two or more flashes, which are specified in number, is regularly repeated.")]
		[EnumMember(Value = "Group very quick light")] 
		[XmlEnum("35")] 
		GroupVeryQuickLight = 35,
	}

	/// <summary>
	/// -
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfPowerSource : int {
		[Description("-")]
		[EnumMember(Value = "battery")] 
		[XmlEnum("1")] 
		Battery = 1,

		[Description("-")]
		[EnumMember(Value = "generator")] 
		[XmlEnum("2")] 
		Generator = 2,

		[Description("-")]
		[EnumMember(Value = "solar panel")] 
		[XmlEnum("3")] 
		SolarPanel = 3,

		[Description("-")]
		[EnumMember(Value = "electrical service")] 
		[XmlEnum("4")] 
		ElectricalService = 4,
	}

	/// <summary>
	/// -
	/// </summary>
	/// <remarks>
	/// -
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfSyntheticAISAidtoNavigation : int {
		[Description("-")]
		[EnumMember(Value = "predicted")] 
		[XmlEnum("1")] 
		Predicted = 1,

		[Description("-")]
		[EnumMember(Value = "monitored")] 
		[XmlEnum("2")] 
		Monitored = 2,
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
		[Description("Simple transmission of static, pre-programmed information.")]
		[EnumMember(Value = "Physical AIS Type 1")] 
		[XmlEnum("1")] 
		PhysicalAisType1 = 1,

		[Description("Transmission of dynamic, real-time updated information via connected sensors.")]
		[EnumMember(Value = "Physical AIS Type 2")] 
		[XmlEnum("2")] 
		PhysicalAisType2 = 2,

		[Description("Full two-way communication: transmission + remote control / configuration.")]
		[EnumMember(Value = "Physical AIS Type 3")] 
		[XmlEnum("3")] 
		PhysicalAisType3 = 3,
	}

	/// <summary>
	/// A purpose of a virtual AIS Aid to Navigation.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum virtualAISAidToNavigationType : int {
		[Description("Indicates that it should be passed to the north side of the aid.")]
		[EnumMember(Value = "North Cardinal")] 
		[XmlEnum("1")] 
		NorthCardinal = 1,

		[Description("Indicates that it should be passed to the east side of the aid.")]
		[EnumMember(Value = "East Cardinal")] 
		[XmlEnum("2")] 
		EastCardinal = 2,

		[Description("Indicates that it should be passed to the south side of the aid.")]
		[EnumMember(Value = "South Cardinal")] 
		[XmlEnum("3")] 
		SouthCardinal = 3,

		[Description("Indicates that it should be passed to the west side of the aid.")]
		[EnumMember(Value = "West Cardinal")] 
		[XmlEnum("4")] 
		WestCardinal = 4,

		[Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the conventional direction of buoyage.")]
		[EnumMember(Value = "Port Lateral")] 
		[XmlEnum("5")] 
		PortLateral = 5,

		[Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the conventional direction of buoyage.")]
		[EnumMember(Value = "Starboard Lateral")] 
		[XmlEnum("6")] 
		StarboardLateral = 6,

		[Description("At a point where a channel divides, when proceeding in the conventional direction of buoyage, the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Port")] 
		[XmlEnum("7")] 
		PreferredChannelToPort = 7,

		[Description("At a point where a channel divides, when proceeding in the conventional direction of buoyage, the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Starboard")] 
		[XmlEnum("8")] 
		PreferredChannelToStarboard = 8,

		[Description("A mark used alone to indicate a dangerous reef or shoal. The mark may be passed on either hand.")]
		[EnumMember(Value = "Isolated Danger")] 
		[XmlEnum("9")] 
		IsolatedDanger = 9,

		[Description("Indicates that there is navigable water around the mark.")]
		[EnumMember(Value = "Safe Water")] 
		[XmlEnum("10")] 
		SafeWater = 10,

		[Description("A special purpose aid is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notice to Mariners")]
		[EnumMember(Value = "Special Purpose")] 
		[XmlEnum("11")] 
		SpecialPurpose = 11,

		[Description("A mark used to indicate the existence of a recently identified new danger, such as a wreck.")]
		[EnumMember(Value = "New Danger Marking")] 
		[XmlEnum("12")] 
		NewDangerMarking = 12,
	}

	/// <summary>
	/// Classification of radar transponder beacon based on functionality.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadarTransponderBeacon : int {
		[Description("A radar marker beacon which continuously transmits a signal appearing as a radial line on a radar screen, the line indicating the direction of the beacon. Ramarks are intended primarily for marine use. The name 'ramark' is derived from the words radar marker.")]
		[EnumMember(Value = "Ramark, Radar Beacon Transmitting Continuously")] 
		[XmlEnum("1")] 
		RamarkRadarBeaconTransmittingContinuously = 1,

		[Description("A radar beacon which returns a coded signal which provides identification of the beacon, as well as range and bearing. The range and bearing are indicated by the location of the first character received on the radar screen. The name 'racon' is derived from the words radar beacon.")]
		[EnumMember(Value = "Racon, Radar Transponder Beacon")] 
		[XmlEnum("2")] 
		RaconRadarTransponderBeacon = 2,

		[Description("A radar beacon that may be used (in conjunction with at least one other radar beacon) to indicate a leading line.")]
		[EnumMember(Value = "Leading Racon/Radar Transponder Beacon")] 
		[XmlEnum("3")] 
		LeadingRaconRadarTransponderBeacon = 3,
	}

	/// <summary>
	/// The shape a topmark or daymark exhibits.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum topmarkDaymarkShape : int {
		[Description("Is where the vertex points up. A cone is a solid figure generated by straight lines drawn from a fixed point (the vertex) to a circle in a plane not containing the vertex. Cones are commonly used as International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA topmarks, lateral.")]
		[EnumMember(Value = "Cone (Point Up)")] 
		[XmlEnum("1")] 
		ConePointUp = 1,

		[Description("Is where the vertex points down. A cone is a solid figure generated by straight lines drawn from a fixed point (the vertex) to a circle in a plane not containing the vertex. Cones are commonly used as International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA topmarks, lateral.")]
		[EnumMember(Value = "Cone (Point Down)")] 
		[XmlEnum("2")] 
		ConePointDown = 2,

		[Description("A curved surface all points of which are equidistant from a fixed point within, called the centre.")]
		[EnumMember(Value = "Sphere")] 
		[XmlEnum("3")] 
		Sphere = 3,

		[Description("Two spheres, one above the other. Two black spheres are commonly used as an International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA topmark (isolated danger).")]
		[EnumMember(Value = "2 Spheres")] 
		[XmlEnum("4")] 
		twoSpheres = 4,

		[Description("A solid geometrical figure generated by straight lines fixed in direction and describing with one of point a closed curve, especially a circle (in which case the figure is circular cylinder, it's ends being parallel circles). Cylinders are commonly used as International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA topmarks lateral.")]
		[EnumMember(Value = "Cylinder")] 
		[XmlEnum("5")] 
		Cylinder = 5,

		[Description("Usually of rectangular shape, made from timber or metal and used to provide a contrast with the natural background of a daymark. The actual daymark is often painted on to this board.")]
		[EnumMember(Value = "Board")] 
		[XmlEnum("6")] 
		Board = 6,

		[Description("Having a shape or a cross-section like the capital letter X. An x-shape as an International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA topmark should be 3 dimensional in shape. It is made of at least three crossed bars.")]
		[EnumMember(Value = "X-Shaped")] 
		[XmlEnum("7")] 
		XShaped = 7,

		[Description("A cross with one vertical member and one horizontal member; that is, similar in shape to the character '+'.")]
		[EnumMember(Value = "Upright Cross")] 
		[XmlEnum("8")] 
		UprightCross = 8,

		[Description("A cube standing on one of its vertexes. A cube is a solid contained by six equal squares, a regular hexahedron.")]
		[EnumMember(Value = "Cube (Point Up)")] 
		[XmlEnum("9")] 
		CubePointUp = 9,

		[Description("2 cones, one above the other, with their vertices together in the centre.")]
		[EnumMember(Value = "2 Cones (Point to Point)")] 
		[XmlEnum("10")] 
		twoConesPointToPoint = 10,

		[Description("2 cones, one above the other, with their bases together in the centre and their vertices pointing up and down.")]
		[EnumMember(Value = "2 Cones (Base to Base)")] 
		[XmlEnum("11")] 
		twoConesBaseToBase = 11,

		[Description("A plane figure having four equal sides and equal opposite angles (two acute and two obtuse); an oblique equilateral parallelogram.")]
		[EnumMember(Value = "Rhombus")] 
		[XmlEnum("12")] 
		Rhombus = 12,

		[Description("2 cones, one above the other, with their vertices pointing up.")]
		[EnumMember(Value = "2 Cones (Points Upward)")] 
		[XmlEnum("13")] 
		twoConesPointsUpward = 13,

		[Description("2 cones, one above the other, with their vertices pointing down.")]
		[EnumMember(Value = "2 Cones (Points Downward)")] 
		[XmlEnum("14")] 
		twoConesPointsDownward = 14,

		[Description("Besom: A bundle of rods or twigs. Perch: A staff placed on top of a buoy, rock or shoal as a mark for navigation. A besom, point up is where the thicker (untied) end of the besom is at the bottom.")]
		[EnumMember(Value = "Besom (Point Up)")] 
		[XmlEnum("15")] 
		BesomPointUp = 15,

		[Description("Besom: A bundle of rods or twigs. Perch: A staff placed on top of a buoy, rock or shoal as a mark for navigation. A besom, point down is where the thinner (tied) end of the besom is at the bottom.")]
		[EnumMember(Value = "Besom (Point Down)")] 
		[XmlEnum("16")] 
		BesomPointDown = 16,

		[Description("A flag mounted on a short pole.")]
		[EnumMember(Value = "Flag")] 
		[XmlEnum("17")] 
		Flag = 17,

		[Description("A sphere located above a rhombus.")]
		[EnumMember(Value = "Sphere Over a Rhombus")] 
		[XmlEnum("18")] 
		SphereOverARhombus = 18,

		[Description("A plane figure with four right angles and four equal straight sides.")]
		[EnumMember(Value = "Square")] 
		[XmlEnum("19")] 
		Square = 19,

		[Description("Where the two longer opposite sides are standing horizontally. A rectangle is a plane figure with four right angles and four straight sides, opposite sides being parallel and equal in length.")]
		[EnumMember(Value = "Rectangle (Horizontal)")] 
		[XmlEnum("20")] 
		RectangleHorizontal = 20,

		[Description("Where the two longer opposite sides are standing vertically. A rectangle is a plane figure with four right angles and four straight sides, opposite sides being parallel and equal in length.")]
		[EnumMember(Value = "Rectangle (Vertical)")] 
		[XmlEnum("21")] 
		RectangleVertical = 21,

		[Description("A quadrilateral having one pair of opposite sides parallel, and which stands on its longer parallel side.")]
		[EnumMember(Value = "Trapezium (Up)")] 
		[XmlEnum("22")] 
		TrapeziumUp = 22,

		[Description("A quadrilateral having one pair of opposite sides parallel, and which stands on its shorter parallel side.")]
		[EnumMember(Value = "Trapezium (Down)")] 
		[XmlEnum("23")] 
		TrapeziumDown = 23,

		[Description("A figure having three angles and three sides, and which has a vertex at the top.")]
		[EnumMember(Value = "Triangle (Point Up)")] 
		[XmlEnum("24")] 
		TrianglePointUp = 24,

		[Description("A figure having three angles and three sides, and which has a side at the top.")]
		[EnumMember(Value = "Triangle (Point Down)")] 
		[XmlEnum("25")] 
		TrianglePointDown = 25,

		[Description("A perfectly round plane figure whose circumference is everywhere equidistant from its centre.")]
		[EnumMember(Value = "Circle")] 
		[XmlEnum("26")] 
		Circle = 26,

		[Description("Two upright crosses, generally vertically disposed one above the other.")]
		[EnumMember(Value = "Two Upright Crosses (One Over the Other)")] 
		[XmlEnum("27")] 
		TwoUprightCrossesOneOverTheOther = 27,

		[Description("Having a shape like the capital letter T.")]
		[EnumMember(Value = "T-Shape")] 
		[XmlEnum("28")] 
		TShape = 28,

		[Description("A triangle, vertex uppermost, located above a circle.")]
		[EnumMember(Value = "Triangle Pointing Up Over a Circle")] 
		[XmlEnum("29")] 
		TrianglePointingUpOverACircle = 29,

		[Description("An upright cross located above a circle.")]
		[EnumMember(Value = "Upright Cross Over a Circle")] 
		[XmlEnum("30")] 
		UprightCrossOverACircle = 30,

		[Description("A rhombus located above a circle.")]
		[EnumMember(Value = "Rhombus Over a Circle")] 
		[XmlEnum("31")] 
		RhombusOverACircle = 31,

		[Description("A circle located over a triangle, vertex uppermost.")]
		[EnumMember(Value = "Circle Over a Triangle Pointing Up")] 
		[XmlEnum("32")] 
		CircleOverATrianglePointingUp = 32,

		[Description("An uncommon and/or non-standardized shape as textually described using an associated attribute.")]
		[EnumMember(Value = "Other Shape (See Shape Information)")] 
		[XmlEnum("33")] 
		OtherShapeSeeShapeInformation = 33,

		[Description("Having the form of or consisting of a tube.")]
		[EnumMember(Value = "Tubular")] 
		[XmlEnum("34")] 
		Tubular = 34,
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
		[Description("A mark used to indicate a firing danger area, usually at sea.")]
		[EnumMember(Value = "Firing Danger Mark")] 
		[XmlEnum("1")] 
		FiringDangerMark = 1,

		[Description("Any object toward which something is directed. The distinctive marking or instrumentation of a ground point to aid its identification on a photograph.")]
		[EnumMember(Value = "Target Mark")] 
		[XmlEnum("2")] 
		TargetMark = 2,

		[Description("A mark marking the position of a ship which is used as a target during some military exercise.")]
		[EnumMember(Value = "Marker Ship Mark")] 
		[XmlEnum("3")] 
		MarkerShipMark = 3,

		[Description("A mark used to indicate a degaussing range.")]
		[EnumMember(Value = "Degaussing Range Mark")] 
		[XmlEnum("4")] 
		DegaussingRangeMark = 4,

		[Description("A mark of relevance to barges.")]
		[EnumMember(Value = "Barge Mark")] 
		[XmlEnum("5")] 
		BargeMark = 5,

		[Description("A mark used to indicate the position of submarine cables or the point at which they run on to the land.")]
		[EnumMember(Value = "Cable Mark")] 
		[XmlEnum("6")] 
		CableMark = 6,

		[Description("A mark used to indicate the limit of a spoil ground.")]
		[EnumMember(Value = "Spoil Ground Mark")] 
		[XmlEnum("7")] 
		SpoilGroundMark = 7,

		[Description("A mark used to indicate the position of an outfall or the point at which it leaves the land.")]
		[EnumMember(Value = "Outfall Mark")] 
		[XmlEnum("8")] 
		OutfallMark = 8,

		[Description("Ocean Data Acquisition System.")]
		[EnumMember(Value = "ODAS")] 
		[XmlEnum("9")] 
		Odas = 9,

		[Description("A mark used to record data for scientific purposes.")]
		[EnumMember(Value = "Recording Mark")] 
		[XmlEnum("10")] 
		RecordingMark = 10,

		[Description("A mark used to indicate a seaplane anchorage.")]
		[EnumMember(Value = "Seaplane Anchorage Mark")] 
		[XmlEnum("11")] 
		SeaplaneAnchorageMark = 11,

		[Description("A mark used to indicate a recreation zone.")]
		[EnumMember(Value = "Recreation Zone Mark")] 
		[XmlEnum("12")] 
		RecreationZoneMark = 12,

		[Description("A privately maintained mark.")]
		[EnumMember(Value = "Private Mark")] 
		[XmlEnum("13")] 
		PrivateMark = 13,

		[Description("A mark indicating a mooring or moorings.")]
		[EnumMember(Value = "Mooring Mark")] 
		[XmlEnum("14")] 
		MooringMark = 14,

		[Description("A large buoy designed to take the place of a lightship where construction of an offshore light station is not feasible.")]
		[EnumMember(Value = "LANBY")] 
		[XmlEnum("15")] 
		Lanby = 15,

		[Description("Aids to navigation or other indicators so located as to indicate the path to be followed. Leading marks identify a leading line when they are in transit.")]
		[EnumMember(Value = "Leading Mark")] 
		[XmlEnum("16")] 
		LeadingMark = 16,

		[Description("A mark forming part of a transit indicating one end of a measured distance.")]
		[EnumMember(Value = "Measured Distance Mark")] 
		[XmlEnum("17")] 
		MeasuredDistanceMark = 17,

		[Description("A notice board or sign indicating information to the mariner.")]
		[EnumMember(Value = "Notice Mark")] 
		[XmlEnum("18")] 
		NoticeMark = 18,

		[Description("A mark indicating a Traffic Separation Scheme.")]
		[EnumMember(Value = "TSS Mark")] 
		[XmlEnum("19")] 
		TssMark = 19,

		[Description("A mark indicating an anchoring prohibited area.")]
		[EnumMember(Value = "Anchoring Prohibited Mark")] 
		[XmlEnum("20")] 
		AnchoringProhibitedMark = 20,

		[Description("A mark indicating that berthing is prohibited.")]
		[EnumMember(Value = "Berthing Prohibited Mark")] 
		[XmlEnum("21")] 
		BerthingProhibitedMark = 21,

		[Description("A mark indicating that overtaking is prohibited.")]
		[EnumMember(Value = "Overtaking Prohibited Mark")] 
		[XmlEnum("22")] 
		OvertakingProhibitedMark = 22,

		[Description("A mark indicating a one-way route.")]
		[EnumMember(Value = "Two-Way Traffic Prohibited Mark")] 
		[XmlEnum("23")] 
		TwoWayTrafficProhibitedMark = 23,

		[Description("A mark indicating that vessels must not generate excessive wake.")]
		[EnumMember(Value = "Reduced Wake Mark")] 
		[XmlEnum("24")] 
		ReducedWakeMark = 24,

		[Description("A mark indicating that a speed limit applies.")]
		[EnumMember(Value = "Speed Limit Mark")] 
		[XmlEnum("25")] 
		SpeedLimitMark = 25,

		[Description("A mark indicating the place where the bow of a ship must stop when traffic lights show red.")]
		[EnumMember(Value = "Stop Mark")] 
		[XmlEnum("26")] 
		StopMark = 26,

		[Description("A mark indicating that special caution must be exercised in the vicinity of the mark.")]
		[EnumMember(Value = "General Warning Mark")] 
		[XmlEnum("27")] 
		GeneralWarningMark = 27,

		[Description("A mark indicating that a ship should sound its siren or horn.")]
		[EnumMember(Value = "Sound Ship's Siren Mark")] 
		[XmlEnum("28")] 
		SoundShipSSirenMark = 28,

		[Description("A mark indicating the minimum vertical space available for passage.")]
		[EnumMember(Value = "Restricted Vertical Clearance Mark")] 
		[XmlEnum("29")] 
		RestrictedVerticalClearanceMark = 29,

		[Description("A mark indicating the maximum draught of vessel permitted.")]
		[EnumMember(Value = "Maximum Vessel's Draught Mark")] 
		[XmlEnum("30")] 
		MaximumVesselSDraughtMark = 30,

		[Description("A mark indicating the minimum horizontal space available for passage.")]
		[EnumMember(Value = "Restricted Horizontal Clearance Mark")] 
		[XmlEnum("31")] 
		RestrictedHorizontalClearanceMark = 31,

		[Description("A mark warning of strong currents.")]
		[EnumMember(Value = "Strong Current Warning Mark")] 
		[XmlEnum("32")] 
		StrongCurrentWarningMark = 32,

		[Description("A mark indicating that berthing is allowed.")]
		[EnumMember(Value = "Berthing Permitted Mark")] 
		[XmlEnum("33")] 
		BerthingPermittedMark = 33,

		[Description("A mark indicating an overhead power cable.")]
		[EnumMember(Value = "Overhead Power Cable Mark")] 
		[XmlEnum("34")] 
		OverheadPowerCableMark = 34,

		[Description("A mark indicating the gradient of the slope of a dredge channel edge.")]
		[EnumMember(Value = "Channel Edge Gradient Mark")] 
		[XmlEnum("35")] 
		ChannelEdgeGradientMark = 35,

		[Description("A mark indicating the presence of a telephone.")]
		[EnumMember(Value = "Telephone Mark")] 
		[XmlEnum("36")] 
		TelephoneMark = 36,

		[Description("A mark indicating that a ferry route crosses the ship route; often used with a 'sound ship's siren' mark.")]
		[EnumMember(Value = "Ferry Crossing Mark")] 
		[XmlEnum("37")] 
		FerryCrossingMark = 37,

		[Description("A mark used to indicate the position of submarine pipelines or the point at which they run on to the land.")]
		[EnumMember(Value = "Pipeline Mark")] 
		[XmlEnum("39")] 
		PipelineMark = 39,

		[Description("A mark indicating an anchorage area.")]
		[EnumMember(Value = "Anchorage Mark")] 
		[XmlEnum("40")] 
		AnchorageMark = 40,

		[Description("A mark used to indicate a clearing line.")]
		[EnumMember(Value = "Clearing Mark")] 
		[XmlEnum("41")] 
		ClearingMark = 41,

		[Description("A mark indicating the location at which a restriction or requirement exists.")]
		[EnumMember(Value = "Control Mark")] 
		[XmlEnum("42")] 
		ControlMark = 42,

		[Description("A mark indicating that diving may take place in the vicinity.")]
		[EnumMember(Value = "Diving Mark")] 
		[XmlEnum("43")] 
		DivingMark = 43,

		[Description("A mark providing or indicating a place of safety.")]
		[EnumMember(Value = "Refuge Beacon")] 
		[XmlEnum("44")] 
		RefugeBeacon = 44,

		[Description("A mark indicating a foul ground.")]
		[EnumMember(Value = "Foul Ground Mark")] 
		[XmlEnum("45")] 
		FoulGroundMark = 45,

		[Description("A mark installed for use by yachtsmen.")]
		[EnumMember(Value = "Yachting Mark")] 
		[XmlEnum("46")] 
		YachtingMark = 46,

		[Description("A mark indicating an area where helicopters may land.")]
		[EnumMember(Value = "Heliport Mark")] 
		[XmlEnum("47")] 
		HeliportMark = 47,

		[Description("A mark indicating a location at which a GNSS position has been accurately determined.")]
		[EnumMember(Value = "GNSS Mark")] 
		[XmlEnum("48")] 
		GnssMark = 48,

		[Description("A mark indicating an area where sea-planes land.")]
		[EnumMember(Value = "Seaplane Landing Mark")] 
		[XmlEnum("49")] 
		SeaplaneLandingMark = 49,

		[Description("A mark indicating that entry is prohibited.")]
		[EnumMember(Value = "Entry Prohibited Mark")] 
		[XmlEnum("50")] 
		EntryProhibitedMark = 50,

		[Description("A mark indicating that work (generally construction) is in progress.")]
		[EnumMember(Value = "Work in Progress Mark")] 
		[XmlEnum("51")] 
		WorkInProgressMark = 51,

		[Description("A mark whose detailed characteristics are unknown.")]
		[EnumMember(Value = "Mark With Unknown Purpose")] 
		[XmlEnum("52")] 
		MarkWithUnknownPurpose = 52,

		[Description("A mark indicating a borehole that produces or is capable of producing oil or natural gas.")]
		[EnumMember(Value = "Wellhead Mark")] 
		[XmlEnum("53")] 
		WellheadMark = 53,

		[Description("A mark indicating the point at which a channel divides separately into two channels.")]
		[EnumMember(Value = "Channel Separation Mark")] 
		[XmlEnum("54")] 
		ChannelSeparationMark = 54,

		[Description("A mark indicating the existence of a fish, mussel, oyster or pearl farm/culture.")]
		[EnumMember(Value = "Marine Farm Mark")] 
		[XmlEnum("55")] 
		MarineFarmMark = 55,

		[Description("A mark indicating the existence or the extent of an artificial reef.")]
		[EnumMember(Value = "Artificial Reef Mark")] 
		[XmlEnum("56")] 
		ArtificialReefMark = 56,

		[Description("A mark, used year round, that may be submerged when ice passes through the area.")]
		[EnumMember(Value = "Ice Mark")] 
		[XmlEnum("57")] 
		IceMark = 57,

		[Description("A mark used to define the boundary of a nature reserve.")]
		[EnumMember(Value = "Nature Reserve Mark")] 
		[XmlEnum("58")] 
		NatureReserveMark = 58,

		[Description("A fish aggregating (or aggregation) device (FAD) is a man-made object used to attract ocean going pelagic fish such as marlin, tuna and mahi-mahi (dolphin fish). They usually consist of buoys or floats tethered to the ocean floor with concrete blocks.")]
		[EnumMember(Value = "Fish Aggregating Device")] 
		[XmlEnum("59")] 
		FishAggregatingDevice = 59,

		[Description("A mark used to indicate the existence of a wreck.")]
		[EnumMember(Value = "Wreck Mark")] 
		[XmlEnum("60")] 
		WreckMark = 60,

		[Description("A mark used to indicate the existence of a customs checkpoint.")]
		[EnumMember(Value = "Customs Mark")] 
		[XmlEnum("61")] 
		CustomsMark = 61,

		[Description("A mark used to indicate the existence of a causeway.")]
		[EnumMember(Value = "Causeway Mark")] 
		[XmlEnum("62")] 
		CausewayMark = 62,

		[Description("A surface following buoy used to measure wave activity.")]
		[EnumMember(Value = "Wave Recorder")] 
		[XmlEnum("63")] 
		WaveRecorder = 63,

		[Description("A mark indicating a jetski prohibited area.")]
		[EnumMember(Value = "Jetski Prohibited")] 
		[XmlEnum("64")] 
		JetskiProhibited = 64,

		[Description("-")]
		[EnumMember(Value = "Facility Protection Mark")] 
		[XmlEnum("65")] 
		FacilityProtectionMark = 65,

		[Description("-")]
		[EnumMember(Value = "Oil Pipeline Protection Mark")] 
		[XmlEnum("66")] 
		OilPipelineProtectionMark = 66,

		[Description("-")]
		[EnumMember(Value = "Marine Cable Protection Mark")] 
		[XmlEnum("67")] 
		MarineCableProtectionMark = 67,
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
		[Description("A radio station which need not necessarily be manned, the emissions of which, radiated around the horizon, enable its bearing to be determined by means of the radio direction finder of a ship.")]
		[EnumMember(Value = "Circular (Non-Directional) Marine or Aero-Marine Radiobeacon")] 
		[XmlEnum("1")] 
		CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,

		[Description("A special type of radiobeacon station the emissions of which are intended to provide a definite track for guidance.")]
		[EnumMember(Value = "Directional Radiobeacon")] 
		[XmlEnum("2")] 
		DirectionalRadiobeacon = 2,

		[Description("A special type of radiobeacon station emitting a beam of waves to which a uniform turning movement is given, the bearing of the station being determined by means of an ordinary listening receiver and a stop watch. Also referred to as a rotating loop radiobeacon.")]
		[EnumMember(Value = "Rotating Pattern Radiobeacon")] 
		[XmlEnum("3")] 
		RotatingPatternRadiobeacon = 3,

		[Description("A type of long range position fixing beacon.")]
		[EnumMember(Value = "Consol Beacon")] 
		[XmlEnum("4")] 
		ConsolBeacon = 4,

		[Description("A radio station intended to determine only the direction of other stations by means of transmission from the latter.")]
		[EnumMember(Value = "Radio Direction-Finding Station")] 
		[XmlEnum("5")] 
		RadioDirectionFindingStation = 5,

		[Description("A radio station which is prepared to provide QTG service; that is to say, to transmit upon request from a ship a radio signal, the bearing of which can be taken by that ship.")]
		[EnumMember(Value = "Coast Radio Station Providing QTG Service")] 
		[XmlEnum("6")] 
		CoastRadioStationProvidingQtgService = 6,

		[Description("A radio beacon designed for aeronautical use.")]
		[EnumMember(Value = "Aeronautical Radiobeacon")] 
		[XmlEnum("7")] 
		AeronauticalRadiobeacon = 7,

		[Description("The Decca Navigator System is a high accuracy, short to medium range radio navigational aid intended for coastal and landfall navigation.")]
		[EnumMember(Value = "Decca")] 
		[XmlEnum("8")] 
		Decca = 8,

		[Description("A low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
		[EnumMember(Value = "Loran C")] 
		[XmlEnum("9")] 
		LoranC = 9,

		[Description("A radiobeacon transmitting DGPS correction signals.")]
		[EnumMember(Value = "Differential GNSS")] 
		[XmlEnum("10")] 
		DifferentialGnss = 10,

		[Description("An electronic position fixing system used mainly by aircraft.")]
		[EnumMember(Value = "Toran")] 
		[XmlEnum("11")] 
		Toran = 11,

		[Description("A long-range radio navigational aid which operates within the VLF frequency band. The system comprises eight land based stations.")]
		[EnumMember(Value = "Omega")] 
		[XmlEnum("12")] 
		Omega = 12,

		[Description("A ranging position fixing system operating at 420-450 MHz over a range of up to 400 Km.")]
		[EnumMember(Value = "Syledis")] 
		[XmlEnum("13")] 
		Syledis = 13,

		[Description("Chaika is a low frequency electronic position fixing system using pulsed transmissions at 100 Khz.")]
		[EnumMember(Value = "Chaika")] 
		[XmlEnum("14")] 
		Chaika = 14,

		[Description("The equipment needed at one station to carry on two way voice communication by radio waves only.")]
		[EnumMember(Value = "Radio Telephone Station")] 
		[XmlEnum("19")] 
		RadioTelephoneStation = 19,

		[Description("An onshore AIS unit that monitors traffic in the waterways.")]
		[EnumMember(Value = "AIS Base Station")] 
		[XmlEnum("20")] 
		AisBaseStation = 20,
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
		[Description("A signal produced by the firing of explosive charges.")]
		[EnumMember(Value = "Explosive")] 
		[XmlEnum("1")] 
		Explosive = 1,

		[Description("A diaphone uses compressed air and generally emits a powerful low-pitched sound, which often concludes with a brief sound of suddenly lowered pitch, termed the 'grunt'.")]
		[EnumMember(Value = "Diaphone")] 
		[XmlEnum("2")] 
		Diaphone = 2,

		[Description("A type of fog signal apparatus which produces sound by virtue of the passage of air through slots or holes in a revolving disk.")]
		[EnumMember(Value = "Siren")] 
		[XmlEnum("3")] 
		Siren = 3,

		[Description("A horn having a diaphragm oscillated by electricity.")]
		[EnumMember(Value = "Nautophone")] 
		[XmlEnum("4")] 
		Nautophone = 4,

		[Description("[1]  A reed uses compressed air and emits a weak, high pitched sound.  [2]  Any of various water or marsh plants with a firm stem. (Concise Oxford English Dictionary)")]
		[EnumMember(Value = "Reed")] 
		[XmlEnum("5")] 
		Reed = 5,

		[Description("A diaphragm horn which operates under the influence of compressed air or steam.")]
		[EnumMember(Value = "Tyfon")] 
		[XmlEnum("6")] 
		Tyfon = 6,

		[Description("A ringing sound with a short range.")]
		[EnumMember(Value = "Bell")] 
		[XmlEnum("7")] 
		Bell = 7,

		[Description("A distinctive sound made by a jet of air passing through an orifice. The apparatus may be operated automatically, by hand or by air being forced up a tube by waves acting on a buoy.")]
		[EnumMember(Value = "Whistle")] 
		[XmlEnum("8")] 
		Whistle = 8,

		[Description("A sound produced by vibration of a disc when struck.")]
		[EnumMember(Value = "Gong")] 
		[XmlEnum("9")] 
		Gong = 9,

		[Description("A horn uses compressed air or electricity to vibrate a diaphragm and exists in a variety of types which differ greatly in their sound and power.")]
		[EnumMember(Value = "Horn")] 
		[XmlEnum("10")] 
		Horn = 10,
	}

	/// <summary>
	/// The specific visibility of a light, with respect to the light's intensity and ease of recognition.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightVisibility : int {
		[Description("Non-marine lights with a higher power than marine lights and visible from well off shore (often 'Aero' lights).")]
		[EnumMember(Value = "High Intensity")] 
		[XmlEnum("1")] 
		HighIntensity = 1,

		[Description("Non-marine lights with lower power than marine lights.")]
		[EnumMember(Value = "Low Intensity")] 
		[XmlEnum("2")] 
		LowIntensity = 2,

		[Description("A decrease in the apparent intensity of a light which may occur in the case of partial obstructions.")]
		[EnumMember(Value = "Faint")] 
		[XmlEnum("3")] 
		Faint = 3,

		[Description("A light in a sector is intensified (that is, has longer range than other sectors).")]
		[EnumMember(Value = "Intensified")] 
		[XmlEnum("4")] 
		Intensified = 4,

		[Description("A light in a sector is unintensified (that is, has shorter range than other sectors).")]
		[EnumMember(Value = "Unintensified")] 
		[XmlEnum("5")] 
		Unintensified = 5,

		[Description("A light sector is deliberately reduced in intensity, for example to reduce its effect on a built-up area.")]
		[EnumMember(Value = "Visibility Deliberately Restricted")] 
		[XmlEnum("6")] 
		VisibilityDeliberatelyRestricted = 6,

		[Description("Said of the arc of a light sector designated by its limiting bearings in which the light is not visible from seaward.")]
		[EnumMember(Value = "Obscured")] 
		[XmlEnum("7")] 
		Obscured = 7,

		[Description("This value specifies that parts of the sector are obscured.")]
		[EnumMember(Value = "Partially Obscured")] 
		[XmlEnum("8")] 
		PartiallyObscured = 8,

		[Description("Lights that must in line to be visible.")]
		[EnumMember(Value = "Visible in Line of Range")] 
		[XmlEnum("9")] 
		VisibleInLineOfRange = 9,
	}

	/// <summary>
	/// The mechanism used to generate a fog or light signal.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalGeneration : int {
		[Description("Signal generation is initiated by a self regulating mechanism such as a timer or light sensor.")]
		[EnumMember(Value = "Automatically")] 
		[XmlEnum("1")] 
		Automatically = 1,

		[Description("The signal is generated by the motion of the sea surface such as a bell in a buoy.")]
		[EnumMember(Value = "By Wave Action")] 
		[XmlEnum("2")] 
		ByWaveAction = 2,

		[Description("The signal is generated by a manually operated mechanism such as a hand cranked siren.")]
		[EnumMember(Value = "By Hand")] 
		[XmlEnum("3")] 
		ByHand = 3,

		[Description("The signal is generated by the motion of air such as a wind driven whistle.")]
		[EnumMember(Value = "By Wind")] 
		[XmlEnum("4")] 
		ByWind = 4,

		[Description("Activated by radio signal.")]
		[EnumMember(Value = "Radio Activated")] 
		[XmlEnum("5")] 
		RadioActivated = 5,

		[Description("Activated by making a call to a manned station.")]
		[EnumMember(Value = "Call Activated")] 
		[XmlEnum("6")] 
		CallActivated = 6,
	}

	/// <summary>
	/// The outward display of the light.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum exhibitionConditionOfLight : int {
		[Description("A light shown throughout the 24 hours without change of character.")]
		[EnumMember(Value = "Light Shown Without Change of Character")] 
		[XmlEnum("1")] 
		LightShownWithoutChangeOfCharacter = 1,

		[Description("A light which is only exhibited by day.")]
		[EnumMember(Value = "Daytime Light")] 
		[XmlEnum("2")] 
		DaytimeLight = 2,

		[Description("A light which is exhibited in fog or conditions of reduced visibility.")]
		[EnumMember(Value = "Fog Light")] 
		[XmlEnum("3")] 
		FogLight = 3,

		[Description("A light which is only exhibited at night.")]
		[EnumMember(Value = "Night Light")] 
		[XmlEnum("4")] 
		NightLight = 4,
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
		[Description("A light illuminating a sector of very narrow angle and intended to mark a direction to follow.")]
		[EnumMember(Value = "Directional Function")] 
		[XmlEnum("1")] 
		DirectionalFunction = 1,

		[Description("A light associated with other lights so as to form a leading line to be followed.")]
		[EnumMember(Value = "Leading Light")] 
		[XmlEnum("4")] 
		LeadingLight = 4,

		[Description("An aero light is established for aeronautical navigation and may be of higher power than marine lights and visible from well offshore.")]
		[EnumMember(Value = "Aero Light")] 
		[XmlEnum("5")] 
		AeroLight = 5,

		[Description("A light marking an obstacle which constitutes a danger to air navigation.")]
		[EnumMember(Value = "Air Obstruction Light")] 
		[XmlEnum("6")] 
		AirObstructionLight = 6,

		[Description("A broad beam light used to illuminate a structure or area.")]
		[EnumMember(Value = "Flood Light")] 
		[XmlEnum("8")] 
		FloodLight = 8,

		[Description("A light whose source has a linear form generally horizontal, which can reach a length of several metres.")]
		[EnumMember(Value = "Strip Light")] 
		[XmlEnum("9")] 
		StripLight = 9,

		[Description("A light placed on or near the support of a main light and having a special use in navigation.")]
		[EnumMember(Value = "Subsidiary Light")] 
		[XmlEnum("10")] 
		SubsidiaryLight = 10,

		[Description("A powerful light focused so as to illuminate a small area.")]
		[EnumMember(Value = "Spotlight")] 
		[XmlEnum("11")] 
		Spotlight = 11,

		[Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Front")] 
		[XmlEnum("12")] 
		Front = 12,

		[Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Rear")] 
		[XmlEnum("13")] 
		Rear = 13,

		[Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Lower")] 
		[XmlEnum("14")] 
		Lower = 14,

		[Description("Term used with leading lights to describe the position of the light on the lead as viewed from seaward.")]
		[EnumMember(Value = "Upper")] 
		[XmlEnum("15")] 
		Upper = 15,

		[Description("A light available as a backup to a main light which will be illuminated should the main light fail.")]
		[EnumMember(Value = "Emergency")] 
		[XmlEnum("17")] 
		Emergency = 17,

		[Description("A light which enables its approximate bearing to be obtained without the use of a compass.")]
		[EnumMember(Value = "Bearing Light")] 
		[XmlEnum("18")] 
		BearingLight = 18,

		[Description("A group of lights of identical character and almost identical position, that are disposed horizontally.")]
		[EnumMember(Value = "Horizontally Disposed")] 
		[XmlEnum("19")] 
		HorizontallyDisposed = 19,

		[Description("A group of lights of identical character and almost identical position, that are disposed vertically.")]
		[EnumMember(Value = "Vertically Disposed")] 
		[XmlEnum("20")] 
		VerticallyDisposed = 20,
	}

	/// <summary>
	/// Direction of vessels passing a reference point.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum trafficFlow : int {
		[Description("Traffic flow in a general direction toward a port or similar destination.")]
		[EnumMember(Value = "Inbound")] 
		[XmlEnum("1")] 
		Inbound = 1,

		[Description("Traffic flow in a general direction away from a port or similar point of origin.")]
		[EnumMember(Value = "Outbound")] 
		[XmlEnum("2")] 
		Outbound = 2,

		[Description("Traffic flow in one general direction only.")]
		[EnumMember(Value = "One-Way")] 
		[XmlEnum("3")] 
		OneWay = 3,

		[Description("Traffic flow in two generally opposite directions.")]
		[EnumMember(Value = "Two-Way")] 
		[XmlEnum("4")] 
		TwoWay = 4,
	}

	/// <summary>
	/// Survey method used to obtain depth information.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum techniqueOfVerticalMeasurement : int {
		[Description("The depth was determined by using an instrument that determines depth of water by measuring the time interval between emission of a sonic or ultrasonic signal and return of its echo from the bottom.")]
		[EnumMember(Value = "Found by Echo Sounder")] 
		[XmlEnum("1")] 
		FoundByEchoSounder = 1,

		[Description("The depth was computed from a record produced by active sonar in which fixed acoustic beams are directed into the water perpendicularly to the direction of travel to scan the seabed and generate a record of the seabed configuration.")]
		[EnumMember(Value = "Found by Side Scan Sonar")] 
		[XmlEnum("2")] 
		FoundBySideScanSonar = 2,

		[Description("The depth was determined by using a wide swath echo sounder that uses multiple beams to measure depths directly below and transverse to the ship's track.")]
		[EnumMember(Value = "Found by Multi Beam")] 
		[XmlEnum("3")] 
		FoundByMultiBeam = 3,

		[Description("The depth was determined by a person skilled in the practice of diving.")]
		[EnumMember(Value = "Found by Diver")] 
		[XmlEnum("4")] 
		FoundByDiver = 4,

		[Description("The depth was determined by using a line, graduated with attached marks and fastened to a sounding lead.")]
		[EnumMember(Value = "Found by Lead Line")] 
		[XmlEnum("5")] 
		FoundByLeadLine = 5,

		[Description("The given area was determined to be free from navigational dangers to a certain depth by towing a buoyed wire at the desired depth by two launches, or a least depth was identified using the same technique.")]
		[EnumMember(Value = "Swept by Wire-Drag")] 
		[XmlEnum("6")] 
		SweptByWireDrag = 6,

		[Description("The depth was determined by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
		[EnumMember(Value = "Found by Laser")] 
		[XmlEnum("7")] 
		FoundByLaser = 7,

		[Description("The given area has been swept using a system comprised of multiple echo sounder transducers attached to booms deployed from the survey vessel.")]
		[EnumMember(Value = "Swept by Vertical Acoustic System")] 
		[XmlEnum("8")] 
		SweptByVerticalAcousticSystem = 8,

		[Description("The depth was determined by using an instrument that compares electromagnetic signals.")]
		[EnumMember(Value = "Found by Electromagnetic Sensor")] 
		[XmlEnum("9")] 
		FoundByElectromagneticSensor = 9,

		[Description("The science or art of obtaining reliable measurements from photographs.")]
		[EnumMember(Value = "Photogrammetry")] 
		[XmlEnum("10")] 
		Photogrammetry = 10,

		[Description("The depth was determined by using instruments placed aboard an artificial satellite.")]
		[EnumMember(Value = "Satellite Imagery")] 
		[XmlEnum("11")] 
		SatelliteImagery = 11,

		[Description("The depth was determined by using levelling techniques to find the elevation of the point relative to a datum.")]
		[EnumMember(Value = "Found by Levelling")] 
		[XmlEnum("12")] 
		FoundByLevelling = 12,

		[Description("The given area was determined to be free from navigational dangers to a certain depth by towing a side scan sonar.")]
		[EnumMember(Value = "Swept by Side Scan Sonar")] 
		[XmlEnum("13")] 
		SweptBySideScanSonar = 13,

		[Description("The sounding was determined from a bottom model constructed using a computer.")]
		[EnumMember(Value = "Computer Generated")] 
		[XmlEnum("14")] 
		ComputerGenerated = 14,

		[Description("The depth was measured by using an instrument that measures distance by emitting timed pulses of laser light and measuring the time between emission and reception of the reflected pulses.")]
		[EnumMember(Value = "Found by LIDAR")] 
		[XmlEnum("15")] 
		FoundByLidar = 15,

		[Description("A radar with a synthetic aperture antenna which is composed of a large number of elementary transducing elements. The signals are electronically combined into a resulting signal equivalent to that of a single antenna of a given aperture in a given direction.")]
		[EnumMember(Value = "Synthetic Aperture Radar")] 
		[XmlEnum("16")] 
		SyntheticApertureRadar = 16,

		[Description("Term used to describe the imagery derived from subdividing the electromagnetic spectrum into very narrow bandwidths. These narrow bandwidths may be combined with or subtracted from each other in various ways to form images useful in precise terrain or target analysis.")]
		[EnumMember(Value = "Hyperspectral Imagery")] 
		[XmlEnum("17")] 
		HyperspectralImagery = 17,
	}

	/// <summary>
	/// The reliability of the value of a sounding.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfVerticalMeasurement : int {
		[Description("The depth from the chart datum to the seabed (or to the top of a drying feature) is known.")]
		[EnumMember(Value = "Depth Known")] 
		[XmlEnum("1")] 
		DepthKnown = 1,

		[Description("The depth from chart datum to the seabed, or the shoalest depth of the feature is unknown.")]
		[EnumMember(Value = "Depth or Least Depth Unknown")] 
		[XmlEnum("2")] 
		DepthOrLeastDepthUnknown = 2,

		[Description("A depth that may be less than indicated.")]
		[EnumMember(Value = "Doubtful Sounding")] 
		[XmlEnum("3")] 
		DoubtfulSounding = 3,

		[Description("A depth that is considered to be an unreliable value.")]
		[EnumMember(Value = "Unreliable Sounding")] 
		[XmlEnum("4")] 
		UnreliableSounding = 4,

		[Description("Upon investigation the bottom was not found at this depth.")]
		[EnumMember(Value = "No Bottom Found at Value Shown")] 
		[XmlEnum("5")] 
		NoBottomFoundAtValueShown = 5,

		[Description("The shoalest depth over a feature is of known value.")]
		[EnumMember(Value = "Least Depth Known")] 
		[XmlEnum("6")] 
		LeastDepthKnown = 6,

		[Description("The least depth over a feature is unknown, but there is considered to be safe clearance at this depth.")]
		[EnumMember(Value = "Least Depth Unknown, Safe Clearance at Value Shown")] 
		[XmlEnum("7")] 
		LeastDepthUnknownSafeClearanceAtValueShown = 7,

		[Description("Depth value obtained from a report, but not fully surveyed.")]
		[EnumMember(Value = "Value Reported (Not Surveyed)")] 
		[XmlEnum("8")] 
		ValueReportedNotSurveyed = 8,

		[Description("Depth value obtained from a report, which it has not been possible to confirm.")]
		[EnumMember(Value = "Value Reported (Not Confirmed)")] 
		[XmlEnum("9")] 
		ValueReportedNotConfirmed = 9,

		[Description("The depth at which a channel is kept by human influence, usually by dredging.")]
		[EnumMember(Value = "Maintained Depth")] 
		[XmlEnum("10")] 
		MaintainedDepth = 10,

		[Description("Depths may be altered by human influence, but will not be routinely maintained.")]
		[EnumMember(Value = "Not Regularly Maintained")] 
		[XmlEnum("11")] 
		NotRegularlyMaintained = 11,
	}

	/// <summary>
	/// Classification of route guidance given to vessels.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfNavigationLine : int {
		[Description("A straight line that marks the boundary between a safe and a dangerous area or that passes clear of a navigational danger.")]
		[EnumMember(Value = "Clearing Line")] 
		[XmlEnum("1")] 
		ClearingLine = 1,

		[Description("A line passing through one or more fixed marks.")]
		[EnumMember(Value = "Transit Line")] 
		[XmlEnum("2")] 
		TransitLine = 2,

		[Description("A line passing through one or more clearly defined objects, along the path of which a vessel can approach safely up to a certain distance off.")]
		[EnumMember(Value = "Leading Line Bearing a Recommended Track")] 
		[XmlEnum("3")] 
		LeadingLineBearingARecommendedTrack = 3,
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
		[Description("Indicates the port boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".")]
		[EnumMember(Value = "Port-Hand Lateral Mark")] 
		[XmlEnum("1")] 
		PortHandLateralMark = 1,

		[Description("Indicates the starboard boundary of a navigational channel or suggested route when proceeding in the \"conventional direction of buoyage\".")]
		[EnumMember(Value = "Starboard-Hand Lateral Mark")] 
		[XmlEnum("2")] 
		StarboardHandLateralMark = 2,

		[Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified port-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Starboard Lateral Mark")] 
		[XmlEnum("3")] 
		PreferredChannelToStarboardLateralMark = 3,

		[Description("At a point where a channel divides, when proceeding in the \"conventional direction of buoyage\", the preferred channel (or primary route) is indicated by a modified starboard-hand lateral mark.")]
		[EnumMember(Value = "Preferred Channel to Port Lateral Mark")] 
		[XmlEnum("4")] 
		PreferredChannelToPortLateralMark = 4,
	}

	/// <summary>
	/// The reference level used for expressing the vertical measurements of points on the earth's surface. Also called datum level, reference plane, levelling datum, datum for sounding reduction, datum for heights.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[Description("The average height of the low waters of spring tides. This level is used as a tidal datum in some areas. Also called spring low water.")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		[XmlEnum("1")] 
		MeanLowWaterSprings = 1,

		[Description("The average height of lower low water springs at a place.")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		[XmlEnum("2")] 
		MeanLowerLowWaterSprings = 2,

		[Description("The average height of the surface of the sea at a tide station for all stages of the tide over a 19-year period, usually determined from hourly height readings measured from a fixed predetermined reference level.")]
		[EnumMember(Value = "Mean Sea Level")] 
		[XmlEnum("3")] 
		MeanSeaLevel = 3,

		[Description("An arbitrary level conforming to the lowest tide observed at a place, or some what lower.")]
		[EnumMember(Value = "Lowest Low Water")] 
		[XmlEnum("4")] 
		LowestLowWater = 4,

		[Description("The average height of all low waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Low Water")] 
		[XmlEnum("5")] 
		MeanLowWater = 5,

		[Description("An arbitrary level conforming to the lowest water level observed at a place at spring tides during a period of time shorter than 19 years.")]
		[EnumMember(Value = "Lowest Low Water Springs")] 
		[XmlEnum("6")] 
		LowestLowWaterSprings = 6,

		[Description("An arbitrary level, usually within 0.3m from that of Mean Low Water Springs (MLWS).")]
		[EnumMember(Value = "Approximate Mean Low Water Springs")] 
		[XmlEnum("7")] 
		ApproximateMeanLowWaterSprings = 7,

		[Description("An arbitrary tidal datum approximating the level of the mean of the lower low water at spring tides. It was first used in waters surrounding India.")]
		[EnumMember(Value = "Indian Spring Low Water")] 
		[XmlEnum("8")] 
		IndianSpringLowWater = 8,

		[Description("An arbitrary level, approximating that of mean low water springs (MLWS).")]
		[EnumMember(Value = "Low Water Springs")] 
		[XmlEnum("9")] 
		LowWaterSprings = 9,

		[Description("An arbitrary level, usually within 0.3m from that of Lowest Astronomical Tide (LAT).")]
		[EnumMember(Value = "Approximate Lowest Astronomical Tide")] 
		[XmlEnum("10")] 
		ApproximateLowestAstronomicalTide = 10,

		[Description("An arbitrary level approximating the lowest water level observed at a place, usually equivalent to the Indian Spring Low Water (ISLW).")]
		[EnumMember(Value = "Nearly Lowest Low Water")] 
		[XmlEnum("11")] 
		NearlyLowestLowWater = 11,

		[Description("The average height of the lower low waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Lower Low Water")] 
		[XmlEnum("12")] 
		MeanLowerLowWater = 12,

		[Description("The lowest level reached at a place by the water surface in one oscillation. Also called low tide.")]
		[EnumMember(Value = "Low Water")] 
		[XmlEnum("13")] 
		LowWater = 13,

		[Description("An arbitrary level, usually within 0.3m from that of Mean Low Water (MLW).")]
		[EnumMember(Value = "Approximate Mean Low Water")] 
		[XmlEnum("14")] 
		ApproximateMeanLowWater = 14,

		[Description("An arbitrary level, usually within 0.3m from that of Mean Lower Low Water (MLLW).")]
		[EnumMember(Value = "Approximate Mean Lower Low Water")] 
		[XmlEnum("15")] 
		ApproximateMeanLowerLowWater = 15,

		[Description("The average height of all high waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean High Water")] 
		[XmlEnum("16")] 
		MeanHighWater = 16,

		[Description("The average height of the high waters of spring tides. Also called spring high water.")]
		[EnumMember(Value = "Mean High Water Springs")] 
		[XmlEnum("17")] 
		MeanHighWaterSprings = 17,

		[Description("The highest level reached at a place by the water surface in one oscillation.")]
		[EnumMember(Value = "High Water")] 
		[XmlEnum("18")] 
		HighWater = 18,

		[Description("An arbitrary level, usually within 0.3m from that of Mean Sea Level (MSL).")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		[XmlEnum("19")] 
		ApproximateMeanSeaLevel = 19,

		[Description("An arbitrary level, approximating that of mean high water springs (MHWS).")]
		[EnumMember(Value = "High Water Springs")] 
		[XmlEnum("20")] 
		HighWaterSprings = 20,

		[Description("The average height of higher high waters at a place over a 19-year period.")]
		[EnumMember(Value = "Mean Higher High Water")] 
		[XmlEnum("21")] 
		MeanHigherHighWater = 21,

		[Description("The level of low water springs near the time of an equinox.")]
		[EnumMember(Value = "Equinoctial Spring Low Water")] 
		[XmlEnum("22")] 
		EquinoctialSpringLowWater = 22,

		[Description("The lowest tide level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
		[EnumMember(Value = "Lowest Astronomical Tide")] 
		[XmlEnum("23")] 
		LowestAstronomicalTide = 23,

		[Description("An arbitrary datum defined by a local harbour authority, from which levels and tidal heights are measured by this authority.")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("24")] 
		LocalDatum = 24,

		[Description("A vertical reference system with its zero based on the mean water level at Rimouski/Pointe-au-Pere, Quebec, over the period 1970 to 1988.")]
		[EnumMember(Value = "International Great Lakes Datum 1985")] 
		[XmlEnum("25")] 
		InternationalGreatLakesDatum1985 = 25,

		[Description("The average of all hourly water levels over the available period of record.")]
		[EnumMember(Value = "Mean Water Level")] 
		[XmlEnum("26")] 
		MeanWaterLevel = 26,

		[Description("The average of the lowest low waters, one from each of 19 years of observations.")]
		[EnumMember(Value = "Lower Low Water Large Tide")] 
		[XmlEnum("27")] 
		LowerLowWaterLargeTide = 27,

		[Description("The average of the highest high waters, one from each of 19 years of observations.")]
		[EnumMember(Value = "Higher High Water Large Tide")] 
		[XmlEnum("28")] 
		HigherHighWaterLargeTide = 28,

		[Description("An arbitrary level approximating the highest water level observed at a place, usually equivalent to the high water springs.")]
		[EnumMember(Value = "Nearly Highest High Water")] 
		[XmlEnum("29")] 
		NearlyHighestHighWater = 29,

		[Description("The highest tidal level which can be predicted to occur under average meteorological conditions and under any combination of astronomical conditions.")]
		[EnumMember(Value = "Highest Astronomical Tide")] 
		[XmlEnum("30")] 
		HighestAstronomicalTide = 30,

		[Description("Low water reference level of the local area.")]
		[EnumMember(Value = "Local Low Water Reference Level")] 
		[XmlEnum("31")] 
		LocalLowWaterReferenceLevel = 31,

		[Description("High water reference level of the local area.")]
		[EnumMember(Value = "Local High Water Reference Level")] 
		[XmlEnum("32")] 
		LocalHighWaterReferenceLevel = 32,

		[Description("Mean water reference level of the local area.")]
		[EnumMember(Value = "Local Mean Water Reference Level")] 
		[XmlEnum("33")] 
		LocalMeanWaterReferenceLevel = 33,

		[Description("A low water level which is the result of a defined low water discharge - called \"equivalent discharge\".")]
		[EnumMember(Value = "Equivalent Height of Water (German GlW)")] 
		[XmlEnum("34")] 
		EquivalentHeightOfWaterGermanGlw = 34,

		[Description("Upper limit of water levels where navigation is allowed.")]
		[EnumMember(Value = "Highest Shipping Height of Water (German HSW)")] 
		[XmlEnum("35")] 
		HighestShippingHeightOfWaterGermanHsw = 35,

		[Description("The water level at a discharge, which is exceeded 94 % of the year within a period of 30 years.")]
		[EnumMember(Value = "Reference Low Water Level According to Danube Commission")] 
		[XmlEnum("36")] 
		ReferenceLowWaterLevelAccordingToDanubeCommission = 36,

		[Description("The water level at a discharge, which is exceeded 1% of the year within a period of 30 years.")]
		[EnumMember(Value = "Highest Shipping Height of Water According to Danube Commission")] 
		[XmlEnum("37")] 
		HighestShippingHeightOfWaterAccordingToDanubeCommission = 37,

		[Description("The water level at a discharge, which is exceeded 95% of the year within a period of 20 years.")]
		[EnumMember(Value = "Dutch River Low Water Reference Level (OLR)")] 
		[XmlEnum("38")] 
		DutchRiverLowWaterReferenceLevelOlr = 38,

		[Description("Conditional low water level with established probability.")]
		[EnumMember(Value = "Russian Project Water Level")] 
		[XmlEnum("39")] 
		RussianProjectWaterLevel = 39,

		[Description("Highest water level derived from the upper backwater stream in watercourse or reservoir under the normal operational conditions.")]
		[EnumMember(Value = "Russian Normal Backwater Level")] 
		[XmlEnum("40")] 
		RussianNormalBackwaterLevel = 40,

		[Description("The Ohio River datum.")]
		[EnumMember(Value = "Ohio River Datum")] 
		[XmlEnum("41")] 
		OhioRiverDatum = 41,

		[Description("Dutch High Water Reference Level.")]
		[EnumMember(Value = "Dutch High Water Reference Level")] 
		[XmlEnum("43")] 
		DutchHighWaterReferenceLevel = 43,

		[Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		[XmlEnum("44")] 
		BalticSeaChartDatum2000 = 44,

		[Description("Dutch Estuary Low Water Reference Level (OLW)")]
		[EnumMember(Value = "Dutch Estuary Low Water Reference Level (OLW)")] 
		[XmlEnum("45")] 
		DutchEstuaryLowWaterReferenceLevelOlw = 45,

		[Description("-")]
		[EnumMember(Value = "International Great Lakes Datum 2020")] 
		[XmlEnum("46")] 
		InternationalGreatLakesDatum2020 = 46,

		[Description("-")]
		[EnumMember(Value = "Sea Floor")] 
		[XmlEnum("47")] 
		SeaFloor = 47,

		[Description("-")]
		[EnumMember(Value = "Sea Surface")] 
		[XmlEnum("48")] 
		SeaSurface = 48,

		[Description("-")]
		[EnumMember(Value = "Hydrographic Zero")] 
		[XmlEnum("49")] 
		HydrographicZero = 49,
	}

	/// <summary>
	/// A specific role that describes a feature.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum function : int {
		[Description("A local official who has charge of mooring and berthing of vessels, collecting harbour fees, etc.")]
		[EnumMember(Value = "Harbour-Masters Office")] 
		[XmlEnum("2")] 
		HarbourMastersOffice = 2,

		[Description("Serves as a government office where customs duties are collected, the flow of goods are regulated and restrictions enforced, and shipments or vehicles are cleared for entering or leaving a country.")]
		[EnumMember(Value = "Customs Office")] 
		[XmlEnum("3")] 
		CustomsOffice = 3,

		[Description("The office which is charged with the administration of health laws and sanitary inspections.")]
		[EnumMember(Value = "Health Office")] 
		[XmlEnum("4")] 
		HealthOffice = 4,

		[Description("An institution or establishment providing medical or surgical treatment for the ill or wounded.")]
		[EnumMember(Value = "Hospital")] 
		[XmlEnum("5")] 
		Hospital = 5,

		[Description("The public department, agency or organisation responsible primarily for the collection, transmission and distribution of mail.")]
		[EnumMember(Value = "Post Office")] 
		[XmlEnum("6")] 
		PostOffice = 6,

		[Description("An establishment, especially of a comfortable or luxurious kind, where paying visitors are provided with accommodation, meals and other services.")]
		[EnumMember(Value = "Hotel")] 
		[XmlEnum("7")] 
		Hotel = 7,

		[Description("A building with platforms where trains arrive, load, discharge and depart.")]
		[EnumMember(Value = "Railway Station")] 
		[XmlEnum("8")] 
		RailwayStation = 8,

		[Description("The headquarters of a local police force and that is where those under arrest are first charged.")]
		[EnumMember(Value = "Police Station")] 
		[XmlEnum("9")] 
		PoliceStation = 9,

		[Description("The headquarters of a local water-police force.")]
		[EnumMember(Value = "Water-Police Station")] 
		[XmlEnum("10")] 
		WaterPoliceStation = 10,

		[Description("The office or headquarters of pilots; the place where the services of a pilot may be obtained.")]
		[EnumMember(Value = "Pilot Office")] 
		[XmlEnum("11")] 
		PilotOffice = 11,

		[Description("A distinctive structure or place on shore from which personnel keep watch upon events at sea or along the coast.")]
		[EnumMember(Value = "Pilot Lookout")] 
		[XmlEnum("12")] 
		PilotLookout = 12,

		[Description("An office for custody, deposit, loan, exchange or issue of money.")]
		[EnumMember(Value = "Bank Office")] 
		[XmlEnum("13")] 
		BankOffice = 13,

		[Description("The quarters of an executive officer (director, manager, etc.) with responsibility for an administrative area.")]
		[EnumMember(Value = "Headquarters for District Control")] 
		[XmlEnum("14")] 
		HeadquartersForDistrictControl = 14,

		[Description("A building or part of a building for storage of wares or goods.")]
		[EnumMember(Value = "Transit Shed/Warehouse")] 
		[XmlEnum("15")] 
		TransitShedWarehouse = 15,

		[Description("A building or buildings with equipment for manufacturing; a workshop.")]
		[EnumMember(Value = "Factory")] 
		[XmlEnum("16")] 
		Factory = 16,

		[Description("A stationary plant containing apparatus for large scale conversion of some form of energy (such as hydraulic, steam, chemical or nuclear energy) into electrical energy.")]
		[EnumMember(Value = "Power Station")] 
		[XmlEnum("17")] 
		PowerStation = 17,

		[Description("A building for the management of affairs.")]
		[EnumMember(Value = "Administrative")] 
		[XmlEnum("18")] 
		Administrative = 18,

		[Description("A building concerned with education (for example school, college, university, etc).")]
		[EnumMember(Value = "Educational Facility")] 
		[XmlEnum("19")] 
		EducationalFacility = 19,

		[Description("A building for public Christian worship.")]
		[EnumMember(Value = "Church")] 
		[XmlEnum("20")] 
		Church = 20,

		[Description("A place for Christian worship other than a parish, cathedral or church, especially one attached to a private house or institution.")]
		[EnumMember(Value = "Chapel")] 
		[XmlEnum("21")] 
		Chapel = 21,

		[Description("A building for public Jewish worship.")]
		[EnumMember(Value = "Temple")] 
		[XmlEnum("22")] 
		Temple = 22,

		[Description("A Hindu or Buddhist temple or sacred building.")]
		[EnumMember(Value = "Pagoda")] 
		[XmlEnum("23")] 
		Pagoda = 23,

		[Description("A building for public Shinto worship.")]
		[EnumMember(Value = "Shinto Shrine")] 
		[XmlEnum("24")] 
		ShintoShrine = 24,

		[Description("A building for public Buddhist worship.")]
		[EnumMember(Value = "Buddhist Temple")] 
		[XmlEnum("25")] 
		BuddhistTemple = 25,

		[Description("A Muslim place of worship.")]
		[EnumMember(Value = "Mosque")] 
		[XmlEnum("26")] 
		Mosque = 26,

		[Description("A shrine marking the burial place of a Muslim holy man.")]
		[EnumMember(Value = "Marabout")] 
		[XmlEnum("27")] 
		Marabout = 27,

		[Description("Keeping a watch upon events at sea or along the coast.")]
		[EnumMember(Value = "Lookout")] 
		[XmlEnum("28")] 
		Lookout = 28,

		[Description("Transmitting and/or receiving electronic communication signals.")]
		[EnumMember(Value = "Communication")] 
		[XmlEnum("29")] 
		Communication = 29,

		[Description("A system for reproducing on a screen visual images transmitted (usually with sound) by radio signals.")]
		[EnumMember(Value = "Television")] 
		[XmlEnum("30")] 
		Television = 30,

		[Description("Transmitting and/or receiving radio-frequency electromagnetic waves as a means of communication.")]
		[EnumMember(Value = "Radio")] 
		[XmlEnum("31")] 
		Radio = 31,

		[Description("A method, system or technique of using beamed, reflected, and timed radio waves for detecting, locating, or tracking objects, and for measuring altitudes.")]
		[EnumMember(Value = "Radar")] 
		[XmlEnum("32")] 
		Radar = 32,

		[Description("A structure serving as a support for one or more lights.")]
		[EnumMember(Value = "Light Support")] 
		[XmlEnum("33")] 
		LightSupport = 33,

		[Description("Broadcasting and receiving signals using microwaves.")]
		[EnumMember(Value = "Microwave")] 
		[XmlEnum("34")] 
		Microwave = 34,

		[Description("Generation of chilled liquid and/or gas for cooling purposes.")]
		[EnumMember(Value = "Cooling")] 
		[XmlEnum("35")] 
		Cooling = 35,

		[Description("A place from which the surroundings can be observed but at which a watch is not habitually maintained.")]
		[EnumMember(Value = "Observation")] 
		[XmlEnum("36")] 
		Observation = 36,

		[Description("A visual time signal in the form of a ball.")]
		[EnumMember(Value = "Timeball")] 
		[XmlEnum("37")] 
		Timeball = 37,

		[Description("Instrument for measuring time and recording hours.")]
		[EnumMember(Value = "Clock")] 
		[XmlEnum("38")] 
		Clock = 38,

		[Description("Used to control the flow of traffic within a specified range of an installation.")]
		[EnumMember(Value = "Control")] 
		[XmlEnum("39")] 
		Control = 39,

		[Description("Equipment or structure to secure an airship.")]
		[EnumMember(Value = "Airship Mooring")] 
		[XmlEnum("40")] 
		AirshipMooring = 40,

		[Description("An arena for holding and viewing events.")]
		[EnumMember(Value = "Stadium")] 
		[XmlEnum("41")] 
		Stadium = 41,

		[Description("A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.")]
		[EnumMember(Value = "Bus Station")] 
		[XmlEnum("42")] 
		BusStation = 42,

		[Description("A building within a terminal for the loading and unloading of passengers.")]
		[EnumMember(Value = "Passenger Terminal Building")] 
		[XmlEnum("43")] 
		PassengerTerminalBuilding = 43,

		[Description("A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.")]
		[EnumMember(Value = "Sea Rescue Control")] 
		[XmlEnum("44")] 
		SeaRescueControl = 44,

		[Description("A building designed and equipped for making observations of astronomical, meteorological, or other natural phenomena.")]
		[EnumMember(Value = "Observatory")] 
		[XmlEnum("45")] 
		Observatory = 45,

		[Description("A building or structure used to crush ore.")]
		[EnumMember(Value = "Ore Crusher")] 
		[XmlEnum("46")] 
		OreCrusher = 46,

		[Description("A building or shed, usually built partly over water, for sheltering a boat or boats.")]
		[EnumMember(Value = "Boathouse")] 
		[XmlEnum("47")] 
		Boathouse = 47,

		[Description("A facility to move solids, liquids or gases by means of pressure or suction.")]
		[EnumMember(Value = "Pumping Station")] 
		[XmlEnum("48")] 
		PumpingStation = 48,
	}

	/// <summary>
	/// Classification of prominent cultural and natural features in the landscape.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLandmark : int {
		[Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
		[EnumMember(Value = "Cairn")] 
		[XmlEnum("1")] 
		Cairn = 1,

		[Description("A site and associated structures devoted to the burial of the dead.")]
		[EnumMember(Value = "Cemetery")] 
		[XmlEnum("2")] 
		Cemetery = 2,

		[Description("A vertical structure containing a passage or flue for discharging smoke and gases of combustion.")]
		[EnumMember(Value = "Chimney")] 
		[XmlEnum("3")] 
		Chimney = 3,

		[Description("A parabolic aerial for the receipt and transmission of high frequency radio signals.")]
		[EnumMember(Value = "Dish Aerial")] 
		[XmlEnum("4")] 
		DishAerial = 4,

		[Description("A staff or pole on which flags are raised.")]
		[EnumMember(Value = "Flagstaff")] 
		[XmlEnum("5")] 
		Flagstaff = 5,

		[Description("A tall structure used for burning-off waste oil or gas.")]
		[EnumMember(Value = "Flare Stack")] 
		[XmlEnum("6")] 
		FlareStack = 6,

		[Description("A relatively tall structure usually held vertical by guy lines.")]
		[EnumMember(Value = "Mast")] 
		[XmlEnum("7")] 
		Mast = 7,

		[Description("A tapered fabric sleeve mounted so as to catch and swing with the wind, thus indicating the wind direction.")]
		[EnumMember(Value = "Windsock")] 
		[XmlEnum("8")] 
		Windsock = 8,

		[Description("A structure erected and/or maintained as a memorial to a person and/or event.")]
		[EnumMember(Value = "Monument")] 
		[XmlEnum("9")] 
		Monument = 9,

		[Description("A cylindrical or slightly tapering body of considerably greater length than diameter erected vertically.")]
		[EnumMember(Value = "Column/Pillar")] 
		[XmlEnum("10")] 
		ColumnPillar = 10,

		[Description("A slab of metal, usually ornamented, erected as a memorial to a person or event.")]
		[EnumMember(Value = "Memorial Plaque")] 
		[XmlEnum("11")] 
		MemorialPlaque = 11,

		[Description("A tapering shaft usually of stone or concrete, square or rectangular in section, with a pyramidal apex.")]
		[EnumMember(Value = "Obelisk")] 
		[XmlEnum("12")] 
		Obelisk = 12,

		[Description("A representation of a living being, sculptured, moulded, or cast in a variety of materials (for example: marble, metal, or plaster).")]
		[EnumMember(Value = "Statue")] 
		[XmlEnum("13")] 
		Statue = 13,

		[Description("A monument, or other structure in form of a cross.")]
		[EnumMember(Value = "Cross")] 
		[XmlEnum("14")] 
		Cross = 14,

		[Description("A landmark comprising a hemispherical or spheroidal shaped structure.")]
		[EnumMember(Value = "Dome")] 
		[XmlEnum("15")] 
		Dome = 15,

		[Description("A device used for directing a radar beam through a search pattern.")]
		[EnumMember(Value = "Radar Scanner")] 
		[XmlEnum("16")] 
		RadarScanner = 16,

		[Description("A relatively tall, narrow structure that may either stand alone or may form part of another structure.")]
		[EnumMember(Value = "Tower")] 
		[XmlEnum("17")] 
		Tower = 17,

		[Description("A system of vanes attached to a tower and driven by wind (excluding wind turbines).")]
		[EnumMember(Value = "Windmill")] 
		[XmlEnum("18")] 
		Windmill = 18,

		[Description("A modern structure for the use of wind power.")]
		[EnumMember(Value = "Windmotor")] 
		[XmlEnum("19")] 
		Windmotor = 19,

		[Description("A tall conical or pyramid-shaped structure often built on the roof or tower of a building, especially a church or mosque.")]
		[EnumMember(Value = "Spire/Minaret")] 
		[XmlEnum("20")] 
		SpireMinaret = 20,

		[Description("An isolated rocky formation or a single large stone.")]
		[EnumMember(Value = "Large Rock or Boulder on Land")] 
		[XmlEnum("21")] 
		LargeRockOrBoulderOnLand = 21,

		[Description("A recoverable point on the earth, whose geographic position has been determined by angular methods with geodetic instruments. A triangulation point is a selected point, which has been marked with a station mark, or it is a conspicuous natural or artificial feature.")]
		[EnumMember(Value = "Triangulation Mark")] 
		[XmlEnum("22")] 
		TriangulationMark = 22,

		[Description("A marker identifying the location of a surveyed boundary line.")]
		[EnumMember(Value = "Boundary Mark")] 
		[XmlEnum("23")] 
		BoundaryMark = 23,

		[Description("Wheels with passenger cars mounted external to the rim and independently rotated by electric motors.")]
		[EnumMember(Value = "Observation Wheel")] 
		[XmlEnum("24")] 
		ObservationWheel = 24,

		[Description("A form of decorative gateway or portal, consisting of two upright wooden posts connected at the top by two horizontal crosspieces, commonly found at the entrance to Shinto temples.")]
		[EnumMember(Value = "Torii")] 
		[XmlEnum("25")] 
		Torii = 25,

		[Description("(1) An elevated structure extending across or over the weather deck of a vessel, or part of such a structure. The term is sometimes modified to indicate the intended use, such as navigating bridge or signal bridge.  (2) A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians.")]
		[EnumMember(Value = "Bridge")] 
		[XmlEnum("26")] 
		Bridge = 26,

		[Description("A barrier to check or confine anything in motion; particularly one constructed to hold back water and raise its level to form a reservoir, or to prevent flooding.")]
		[EnumMember(Value = "Dam")] 
		[XmlEnum("27")] 
		Dam = 27,
	}

	/// <summary>
	/// The principal shape and/or design of a buoy.
	/// </summary>
	/// <remarks>
	/// The principal shapes are those recommended in the International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA System.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buoyShape : int {
		[Description("The upper part of the body above the water-line, or the greater part of the superstructure, has approximately the shape or the appearance of a pointed cone with the point upwards.")]
		[EnumMember(Value = "Conical")] 
		[XmlEnum("1")] 
		Conical = 1,

		[Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the shape of a cylinder, or a truncated cone that approximates to a cylinder, with a flat end uppermost.")]
		[EnumMember(Value = "Can")] 
		[XmlEnum("2")] 
		Can = 2,

		[Description("Shaped like a sphere, which is a body the surface of which is at all points equidistant from the centre.")]
		[EnumMember(Value = "Spherical")] 
		[XmlEnum("3")] 
		Spherical = 3,

		[Description("The upper part of the body above the water-line, or the greater part of the superstructure is a narrow vertical structure, pillar or lattice tower.")]
		[EnumMember(Value = "Pillar")] 
		[XmlEnum("4")] 
		Pillar = 4,

		[Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a pole, or of a very long cylinder, floating upright.")]
		[EnumMember(Value = "Spar")] 
		[XmlEnum("5")] 
		Spar = 5,

		[Description("The upper part of the body above the water-line, or the greater part of the superstructure, has the form of a barrel or cylinder floating horizontally.")]
		[EnumMember(Value = "Barrel")] 
		[XmlEnum("6")] 
		Barrel = 6,

		[Description("A very large buoy designed to carry a signal light of high luminous intensity at a high elevation.")]
		[EnumMember(Value = "Superbuoy")] 
		[XmlEnum("7")] 
		Superbuoy = 7,

		[Description("A specially constructed shuttle shaped buoy which is used in ice conditions.")]
		[EnumMember(Value = "Ice Buoy")] 
		[XmlEnum("8")] 
		IceBuoy = 8,
	}

	/// <summary>
	/// The extent to which a feature, either natural or artificial, is visible from seaward.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum visualProminence : int {
		[Description("Term applied to a feature either natural or artificial which is distinctly and notably visible from seaward.")]
		[EnumMember(Value = "Visually Conspicuous")] 
		[XmlEnum("1")] 
		VisuallyConspicuous = 1,

		[Description("An object that may be visible from seaward, but cannot be used as a fixing mark and is not conspicuous.")]
		[EnumMember(Value = "Not Visually Conspicuous")] 
		[XmlEnum("2")] 
		NotVisuallyConspicuous = 2,

		[Description("Objects which are easily identifiable, but do not justify being classed as conspicuous.")]
		[EnumMember(Value = "Prominent")] 
		[XmlEnum("3")] 
		Prominent = 3,
	}

	/// <summary>
	/// The condition of an object at a given instant in time.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum status : int {
		[Description("Intended to last or function indefinitely.")]
		[EnumMember(Value = "Permanent")] 
		[XmlEnum("1")] 
		Permanent = 1,

		[Description("Acting on special occasions; happening irregularly.")]
		[EnumMember(Value = "Occasional")] 
		[XmlEnum("2")] 
		Occasional = 2,

		[Description("Presented as worthy of confidence, acceptance, use, etc.")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("3")] 
		Recommended = 3,

		[Description("Use has ceased, but the facility still exists intact; disused.")]
		[EnumMember(Value = "Not in Use")] 
		[XmlEnum("4")] 
		NotInUse = 4,

		[Description("Recurring at intervals.")]
		[EnumMember(Value = "Periodic/Intermittent")] 
		[XmlEnum("5")] 
		PeriodicIntermittent = 5,

		[Description("Set apart for some specific use.")]
		[EnumMember(Value = "Reserved")] 
		[XmlEnum("6")] 
		Reserved = 6,

		[Description("Meant to last only for a time.")]
		[EnumMember(Value = "Temporary")] 
		[XmlEnum("7")] 
		Temporary = 7,

		[Description("Administered by an individual or corporation, rather than a State or a public body.")]
		[EnumMember(Value = "Private")] 
		[XmlEnum("8")] 
		Private = 8,

		[Description("Compulsory; enforced.")]
		[EnumMember(Value = "Mandatory")] 
		[XmlEnum("9")] 
		Mandatory = 9,

		[Description("No longer lit.")]
		[EnumMember(Value = "Extinguished")] 
		[XmlEnum("11")] 
		Extinguished = 11,

		[Description("Lit by floodlights, strip lights, etc.")]
		[EnumMember(Value = "Illuminated")] 
		[XmlEnum("12")] 
		Illuminated = 12,

		[Description("Famous in history; of historical interest.")]
		[EnumMember(Value = "Historic")] 
		[XmlEnum("13")] 
		Historic = 13,

		[Description("Belonging to, available to, used or shared by, the community as a whole and not restricted to private use.")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("14")] 
		Public = 14,

		[Description("Occur at a time, coincide in point of time, be contemporary or simultaneous.")]
		[EnumMember(Value = "Synchronized")] 
		[XmlEnum("15")] 
		Synchronized = 15,

		[Description("Looked at or observed over a period of time especially so as to be aware of any movement or change.")]
		[EnumMember(Value = "Watched")] 
		[XmlEnum("16")] 
		Watched = 16,

		[Description("Usually automatic in operation, without any permanently-stationed personnel to superintend it.")]
		[EnumMember(Value = "Unwatched")] 
		[XmlEnum("17")] 
		Unwatched = 17,

		[Description("A feature that has been reported but has not been definitely determined to exist.")]
		[EnumMember(Value = "Existence Doubtful")] 
		[XmlEnum("18")] 
		ExistenceDoubtful = 18,

		[Description("When you ask for it.")]
		[EnumMember(Value = "On Request")] 
		[XmlEnum("19")] 
		OnRequest = 19,

		[Description("To become lower in level.")]
		[EnumMember(Value = "Drop Away")] 
		[XmlEnum("20")] 
		DropAway = 20,

		[Description("To become higher in level.")]
		[EnumMember(Value = "Rising")] 
		[XmlEnum("21")] 
		Rising = 21,

		[Description("Becoming larger in magnitude.")]
		[EnumMember(Value = "Increasing")] 
		[XmlEnum("22")] 
		Increasing = 22,

		[Description("Becoming smaller in magnitude.")]
		[EnumMember(Value = "Decreasing")] 
		[XmlEnum("23")] 
		Decreasing = 23,

		[Description("Not easily broken or destroyed.")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("24")] 
		Strong = 24,

		[Description("In a satisfactory condition to use.")]
		[EnumMember(Value = "Good")] 
		[XmlEnum("25")] 
		Good = 25,

		[Description("Fairly but not very.")]
		[EnumMember(Value = "Moderately")] 
		[XmlEnum("26")] 
		Moderately = 26,

		[Description("Not as good as it could be or should.")]
		[EnumMember(Value = "Poor")] 
		[XmlEnum("27")] 
		Poor = 27,

		[Description("Marked by buoys.")]
		[EnumMember(Value = "Buoyed")] 
		[XmlEnum("28")] 
		Buoyed = 28,

		[Description("Entire observation platform is operating in accordance with, or exceeding, manufacturer specifications.")]
		[EnumMember(Value = "Fully Operational")] 
		[XmlEnum("29")] 
		FullyOperational = 29,

		[Description("At least one instrument that is part of an observation platform is not operating to manufacturer specification.")]
		[EnumMember(Value = "Partially Operational")] 
		[XmlEnum("30")] 
		PartiallyOperational = 30,

		[Description("Floating platform at the mercy of environmental elements, whether intentional or not.")]
		[EnumMember(Value = "Drifting")] 
		[XmlEnum("31")] 
		Drifting = 31,

		[Description("Fractured or in pieces.")]
		[EnumMember(Value = "Broken")] 
		[XmlEnum("32")] 
		Broken = 32,

		[Description("Observation platform is intentionally not reporting an environmental observation.")]
		[EnumMember(Value = "Offline")] 
		[XmlEnum("33")] 
		Offline = 33,

		[Description("Observation station, suite of instruments, or an individual instrument, for a particular location, has been removed and is no longer at the particular location.")]
		[EnumMember(Value = "Discontinued")] 
		[XmlEnum("34")] 
		Discontinued = 34,

		[Description("Observations made by a human observer.")]
		[EnumMember(Value = "Manual Observation")] 
		[XmlEnum("35")] 
		ManualObservation = 35,

		[Description("Status of an observation platform, suite of instruments, or individual instrument is not known or unspecified.")]
		[EnumMember(Value = "Unknown Status")] 
		[XmlEnum("36")] 
		UnknownStatus = 36,

		[Description("Made certain as to truth, accuracy, validity, availability, etc.")]
		[EnumMember(Value = "Confirmed")] 
		[XmlEnum("37")] 
		Confirmed = 37,

		[Description("Item selected for an action.")]
		[EnumMember(Value = "Candidate")] 
		[XmlEnum("38")] 
		Candidate = 38,

		[Description("Item that is in the process of being modified.")]
		[EnumMember(Value = "Under Modification")] 
		[XmlEnum("39")] 
		UnderModification = 39,

		[Description("")]
		[EnumMember(Value = "Experimental")] 
		[XmlEnum("40")] 
		Experimental = 40,

		[Description("Item in the process of being removed or deleted.")]
		[EnumMember(Value = "Under Removal / Deletion")] 
		[XmlEnum("41")] 
		UnderRemovalDeletion = 41,

		[Description("Item that has been removed or deleted.")]
		[EnumMember(Value = "Removed / Deleted")] 
		[XmlEnum("42")] 
		RemovedDeleted = 42,

		[Description("Item selected for modification.")]
		[EnumMember(Value = "Candidate for Modification")] 
		[XmlEnum("43")] 
		CandidateForModification = 43,
	}

	/// <summary>
	/// The building's primary construction material.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfConstruction : int {
		[Description("Constructed of stones or bricks, usually quarried, shaped, and mortared.")]
		[EnumMember(Value = "Masonry")] 
		[XmlEnum("1")] 
		Masonry = 1,

		[Description("Constructed of concrete, a material made of sand and gravel that is united by cement into a hardened mass used for roads, foundations, etc.")]
		[EnumMember(Value = "Concreted")] 
		[XmlEnum("2")] 
		Concreted = 2,

		[Description("Constructed from large stones or blocks of concrete, often placed loosely for protection against waves or water turbulence.")]
		[EnumMember(Value = "Loose Boulders")] 
		[XmlEnum("3")] 
		LooseBoulders = 3,

		[Description("Constructed with a surface of hard material, usually a term applied to roads surfaced with asphalt or concrete.")]
		[EnumMember(Value = "Hard Surfaced")] 
		[XmlEnum("4")] 
		HardSurfaced = 4,

		[Description("Constructed with no extra protection, usually a term applied to roads not surfaced with a hard material.")]
		[EnumMember(Value = "Unsurfaced")] 
		[XmlEnum("5")] 
		Unsurfaced = 5,

		[Description("Constructed from wood.")]
		[EnumMember(Value = "Wooden")] 
		[XmlEnum("6")] 
		Wooden = 6,

		[Description("Constructed from metal.")]
		[EnumMember(Value = "Metal")] 
		[XmlEnum("7")] 
		Metal = 7,

		[Description("Constructed from a plastic material strengthened with fibres of glass.")]
		[EnumMember(Value = "Glass Reinforced Plastic")] 
		[XmlEnum("8")] 
		GlassReinforcedPlastic = 8,

		[Description("The application of paint to some other construction or natural feature.")]
		[EnumMember(Value = "Painted")] 
		[XmlEnum("9")] 
		Painted = 9,

		[Description("Constructed from a lattice framework of, often diagonal, intersecting struts.")]
		[EnumMember(Value = "Framework")] 
		[XmlEnum("10")] 
		Framework = 10,

		[Description("A structure of crossed wooden or metal strips usually arranged to form a diagonal pattern of open spaces between the strips.")]
		[EnumMember(Value = "Latticed")] 
		[XmlEnum("11")] 
		Latticed = 11,

		[Description("[1] Any artificial or natural substance having similar properties and composition, as fused borax, obsidian, or the like.   [2] Something made of such a substance, as a windowpane.")]
		[EnumMember(Value = "Glass")] 
		[XmlEnum("12")] 
		Glass = 12,

		[Description("Constructed from fiberglass.")]
		[EnumMember(Value = "Fiberglass")] 
		[XmlEnum("13")] 
		Fiberglass = 13,

		[Description("Constructed from plastic.")]
		[EnumMember(Value = "Plastic")] 
		[XmlEnum("14")] 
		Plastic = 14,
	}

	/// <summary>
	/// The system of navigational buoyage a region complies with.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum marksNavigationalSystemOf : int {
		[Description("Navigational aids conform to the International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA A system.")]
		[EnumMember(Value = "IALA A")] 
		[XmlEnum("1")] 
		IalaA = 1,

		[Description("Navigational aids conform to the International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA B system.")]
		[EnumMember(Value = "IALA B")] 
		[XmlEnum("2")] 
		IalaB = 2,

		[Description("Navigational aids do not conform to any defined system.")]
		[EnumMember(Value = "No System")] 
		[XmlEnum("9")] 
		NoSystem = 9,

		[Description("Navigational aids conform to a defined system other than International Association of Marine Aids to Navigation and Lighthouse Authorities - IALA.")]
		[EnumMember(Value = "Other System")] 
		[XmlEnum("10")] 
		OtherSystem = 10,

		[Description("CEVNI (European Code for Navigation on Inland Waterways) is the European code for rivers, canals land lakes in most of Europe.")]
		[EnumMember(Value = "CEVNI")] 
		[XmlEnum("11")] 
		Cevni = 11,

		[Description("Navigational aids conform to the Russian inland waterway regulations.")]
		[EnumMember(Value = "Russian Inland Waterway Regulations")] 
		[XmlEnum("12")] 
		RussianInlandWaterwayRegulations = 12,

		[Description("Navigational aids conform to the Brazilian national inland waterway regulations for two sides.")]
		[EnumMember(Value = "Brazilian National Inland Waterway Regulations - Two Sides")] 
		[XmlEnum("13")] 
		BrazilianNationalInlandWaterwayRegulationsTwoSides = 13,

		[Description("Navigational aids conform to the Brazilian national inland waterway regulations - side independent.")]
		[EnumMember(Value = "Brazilian National Inland Waterway Regulations - Side Independent")] 
		[XmlEnum("14")] 
		BrazilianNationalInlandWaterwayRegulationsSideIndependent = 14,

		[Description("Navigational aids conform to the Brazilian complementary aids on the Paraguay-Parana waterway.")]
		[EnumMember(Value = "Paraguay-Parana Waterway - Brazilian Complementary Aids")] 
		[XmlEnum("15")] 
		ParaguayParanaWaterwayBrazilianComplementaryAids = 15,
	}

	/// <summary>
	/// A regular repeated design containing more than one colour.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colourPattern : int {
		[Description("Straight bands or stripes of differing colours oriented horizontally.")]
		[EnumMember(Value = "Horizontal Stripes")] 
		[XmlEnum("1")] 
		HorizontalStripes = 1,

		[Description("Straight bands or stripes of differing colours oriented vertically.")]
		[EnumMember(Value = "Vertical Stripes")] 
		[XmlEnum("2")] 
		VerticalStripes = 2,

		[Description("Straight bands or stripes of differing colours oriented diagonally (that is, not horizontally or vertically).")]
		[EnumMember(Value = "Diagonal Stripes")] 
		[XmlEnum("3")] 
		DiagonalStripes = 3,

		[Description("Often referred to as checker plate, where alternate colours are used to create squares similar to a chess or draught board. The pattern may be straight or diagonal.")]
		[EnumMember(Value = "Squared")] 
		[XmlEnum("4")] 
		Squared = 4,

		[Description("Straight bands or stripes of differing colours oriented in an unknown direction.")]
		[EnumMember(Value = "Stripes (Direction Unknown)")] 
		[XmlEnum("5")] 
		StripesDirectionUnknown = 5,

		[Description("A band or stripe of colour which is displayed around the outer edge of the object, which may also form a border to an inner pattern or plain colour.")]
		[EnumMember(Value = "Border Stripe")] 
		[XmlEnum("6")] 
		BorderStripe = 6,

		[Description("One solid colour of uniform coverage.")]
		[EnumMember(Value = "Single Colour")] 
		[XmlEnum("7")] 
		SingleColour = 7,

		[Description("A four-sided shape that is made up of two pairs of parallel lines and that has four right angles, on a different coloured background.")]
		[EnumMember(Value = "Rectangle")] 
		[XmlEnum("8")] 
		Rectangle = 8,

		[Description("A shape that is made up of three lines and three angles, on a different coloured background.")]
		[EnumMember(Value = "Triangle")] 
		[XmlEnum("9")] 
		Triangle = 9,
	}

	/// <summary>
	/// The property possessed by an object of producing different sensations on the eye as a result of the way it reflects or emits light.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colour : int {
		[Description("The achromatic object colour of greatest lightness characteristically perceived to belong to objects that reflect diffusely nearly all incident energy throughout the visible spectrum.")]
		[EnumMember(Value = "White")] 
		[XmlEnum("1")] 
		White = 1,

		[Description("The achromatic color of least lightness characteristically perceived to belong to objects that neither reflect nor transmit light.")]
		[EnumMember(Value = "Black")] 
		[XmlEnum("2")] 
		Black = 2,

		[Description("A color whose hue resembles that of blood or of the ruby or is that of the long-wave extreme of the visible spectrum.")]
		[EnumMember(Value = "Red")] 
		[XmlEnum("3")] 
		Red = 3,

		[Description("Of the color green.")]
		[EnumMember(Value = "Green")] 
		[XmlEnum("4")] 
		Green = 4,

		[Description("A color whose hue is that of the clear sky or that of the portion of the color spectrum lying between green and violet.")]
		[EnumMember(Value = "Blue")] 
		[XmlEnum("5")] 
		Blue = 5,

		[Description("A color whose hue resembles that of ripe lemons or sunflowers or is that of the portion of the spectrum lying between green and orange.")]
		[EnumMember(Value = "Yellow")] 
		[XmlEnum("6")] 
		Yellow = 6,

		[Description("Of the color grey.")]
		[EnumMember(Value = "Grey")] 
		[XmlEnum("7")] 
		Grey = 7,

		[Description("Any of a group of colors between red and yellow in hue, of medium to low lightness, and of moderate to low saturation.")]
		[EnumMember(Value = "Brown")] 
		[XmlEnum("8")] 
		Brown = 8,

		[Description("A variable color averaging a dark orange yellow.")]
		[EnumMember(Value = "Amber")] 
		[XmlEnum("9")] 
		Amber = 9,

		[Description("Any of a group of colors of reddish-blue hue, low lightness, and medium saturation.")]
		[EnumMember(Value = "Violet")] 
		[XmlEnum("10")] 
		Violet = 10,

		[Description("Any of a group of colors that are between red and yellow in hue.")]
		[EnumMember(Value = "Orange")] 
		[XmlEnum("11")] 
		Orange = 11,

		[Description("A deep purplish red.")]
		[EnumMember(Value = "Magenta")] 
		[XmlEnum("12")] 
		Magenta = 12,

		[Description("Any of a group of colors bluish red to red in hue, of medium to high lightness, and of low to moderate saturation.")]
		[EnumMember(Value = "Pink")] 
		[XmlEnum("13")] 
		Pink = 13,

		[Description("-")]
		[EnumMember(Value = "Green A")] 
		[XmlEnum("14")] 
		GreenA = 14,

		[Description("-")]
		[EnumMember(Value = "Green B")] 
		[XmlEnum("15")] 
		GreenB = 15,

		[Description("-")]
		[EnumMember(Value = "White Temporary")] 
		[XmlEnum("16")] 
		WhiteTemporary = 16,

		[Description("-")]
		[EnumMember(Value = "Red Temporary")] 
		[XmlEnum("17")] 
		RedTemporary = 17,

		[Description("-")]
		[EnumMember(Value = "Yellow Temporary")] 
		[XmlEnum("18")] 
		YellowTemporary = 18,

		[Description("-")]
		[EnumMember(Value = "Green Preferred")] 
		[XmlEnum("19")] 
		GreenPreferred = 19,

		[Description("-")]
		[EnumMember(Value = "Green Temporary")] 
		[XmlEnum("20")] 
		GreenTemporary = 20,
	}

	/// <summary>
	/// Describes the characteristic geometric form of the beacon.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum beaconShape : int {
		[Description("An elongated wood or metal pole, driven into the ground or seabed, which serves as a navigational aid or a support for a navigational aid.")]
		[EnumMember(Value = "Stake, Pole, Perch, Post")] 
		[XmlEnum("1")] 
		StakePolePerchPost = 1,

		[Description("A tree without roots stuck or spoiled into the bottom of the sea to serve as a navigational aid.")]
		[EnumMember(Value = "Withy")] 
		[XmlEnum("2")] 
		Withy = 2,

		[Description("A solid structure of the order of 10 metres in height used as a navigational aid.")]
		[EnumMember(Value = "Beacon Tower")] 
		[XmlEnum("3")] 
		BeaconTower = 3,

		[Description("A structure consisting of strips of metal or wood crossed or interlaced to form a structure to serve as an aid to navigation or as a support for an aid to navigation.")]
		[EnumMember(Value = "Lattice Beacon")] 
		[XmlEnum("4")] 
		LatticeBeacon = 4,

		[Description("A long heavy timber(s) or section(s) of steel, wood, concrete, etc., forced into the seabed to serve as an aid to navigation or as a support for an aid to navigation.")]
		[EnumMember(Value = "Pile Beacon")] 
		[XmlEnum("5")] 
		PileBeacon = 5,

		[Description("A mound of stones, usually conical or pyramidal, raised as a landmark or to designate a point of importance in surveying.")]
		[EnumMember(Value = "Cairn")] 
		[XmlEnum("6")] 
		Cairn = 6,

		[Description("A tall spar-like beacon fitted with a permanently submerged buoyancy chamber, the lower end of the body is secured to seabed sinker either by a flexible joint or by a cable under tension.")]
		[EnumMember(Value = "Buoyant Beacon")] 
		[XmlEnum("7")] 
		BuoyantBeacon = 7,
	}

	/// <summary>
	/// A Category denoting the significance of an Aid to Navigation, expressed in terms of the probability that an AtoN or system of AtoN, as defined by the Competent Authority, is performing its specified function at any randomly chosen time. This is expressed as a percentage of total time that an AtoN or system of AtoN should be performing their specified function.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum aidAvailabilityCategory : int {
		[Description("An AtoN or system of AtoN that is considered by the Competent Authority to be of vital navigational significance.")]
		[EnumMember(Value = "Category 1")] 
		[XmlEnum("1")] 
		Category1 = 1,

		[Description("An AtoN or system of AtoN that is considered by the Competent Authority to be of important navigational significance.")]
		[EnumMember(Value = "Category 2")] 
		[XmlEnum("2")] 
		Category2 = 2,

		[Description("An AtoN or system of AtoN that is considered by the Competent Authority to be of necessary navigational significance.")]
		[EnumMember(Value = "Category 3")] 
		[XmlEnum("3")] 
		Category3 = 3,
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
		[Description("Being built but not yet capable of function.")]
		[EnumMember(Value = "Under Construction")] 
		[XmlEnum("1")] 
		UnderConstruction = 1,

		[Description("A structure in a decayed or deteriorated condition resulting from neglect or disuse, or a damaged structure in need of repair.")]
		[EnumMember(Value = "Ruined")] 
		[XmlEnum("2")] 
		Ruined = 2,

		[Description("An area of the sea, a lake or the navigable part of a river that is being reclaimed as land, usually by the dumping of earth and other material.")]
		[EnumMember(Value = "Under Reclamation")] 
		[XmlEnum("3")] 
		UnderReclamation = 3,

		[Description("A windmill or wind turbine from which the vanes or turbine blades are missing.")]
		[EnumMember(Value = "Wingless")] 
		[XmlEnum("4")] 
		Wingless = 4,

		[Description("Detailed planning has been completed but construction has not been initiated.")]
		[EnumMember(Value = "Planned Construction")] 
		[XmlEnum("5")] 
		PlannedConstruction = 5,
	}

	/// <summary>
	/// An assessment of the likelihood of change over time.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTemporalVariation : int {
		[Description("Indication of the possible impact of a significant event (for example hurricane, earthquake, volcanic eruption, landslide, etc), which is considered likely to have changed the seafloor or landscape significantly.")]
		[EnumMember(Value = "Extreme Event")] 
		[XmlEnum("1")] 
		ExtremeEvent = 1,

		[Description("Continuous or frequent change (for example river siltation, sand waves, seasonal storms, icebergs, etc) that is likely to result in new significant shoaling.")]
		[EnumMember(Value = "Likely to Change and Significant Shoaling Expected")] 
		[XmlEnum("2")] 
		LikelyToChangeAndSignificantShoalingExpected = 2,

		[Description("Continuous or frequent change (for example sand wave shift, seasonal storms, icebergs, etc) that is not likely to result in new significant shoaling.")]
		[EnumMember(Value = "Likely to Change But Significant Shoaling Not Expected")] 
		[XmlEnum("3")] 
		LikelyToChangeButSignificantShoalingNotExpected = 3,

		[Description("Continuous or frequent change to non-bathymetric features (for example river siltation, glacier creep/recession, sand dunes, buoys, marine farms, etc).")]
		[EnumMember(Value = "Likely to Change")] 
		[XmlEnum("4")] 
		LikelyToChange = 4,

		[Description("Significant change to the seafloor is not expected.")]
		[EnumMember(Value = "Unlikely to Change")] 
		[XmlEnum("5")] 
		UnlikelyToChange = 5,

		[Description("Not having been assessed.")]
		[EnumMember(Value = "Unassessed")] 
		[XmlEnum("6")] 
		Unassessed = 6,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonCommissioning : int {
		[Description(".")]
		[EnumMember(Value = "Buoy establishment")] 
		[XmlEnum("1")] 
		BuoyEstablishment = 1,

		[Description(".")]
		[EnumMember(Value = "Light establishment")] 
		[XmlEnum("2")] 
		LightEstablishment = 2,

		[Description(".")]
		[EnumMember(Value = "Beacon establishment")] 
		[XmlEnum("3")] 
		BeaconEstablishment = 3,

		[Description(".")]
		[EnumMember(Value = "Audible signal establishment")] 
		[XmlEnum("4")] 
		AudibleSignalEstablishment = 4,

		[Description(".")]
		[EnumMember(Value = "Fog signal establishment")] 
		[XmlEnum("5")] 
		FogSignalEstablishment = 5,

		[Description(".")]
		[EnumMember(Value = "AIS transmitter establishment")] 
		[XmlEnum("6")] 
		AisTransmitterEstablishment = 6,

		[Description(".")]
		[EnumMember(Value = "V-AIS establishment")] 
		[XmlEnum("7")] 
		VAisEstablishment = 7,

		[Description(".")]
		[EnumMember(Value = "RACON establishment")] 
		[XmlEnum("8")] 
		RaconEstablishment = 8,

		[Description(".")]
		[EnumMember(Value = "DGPS station establishment")] 
		[XmlEnum("9")] 
		DgpsStationEstablishment = 9,

		[Description(".")]
		[EnumMember(Value = "eLORAN station establishment")] 
		[XmlEnum("10")] 
		EloranStationEstablishment = 10,

		[Description(".")]
		[EnumMember(Value = "DGLONASS station establishment")] 
		[XmlEnum("11")] 
		DglonassStationEstablishment = 11,

		[Description(".")]
		[EnumMember(Value = "e-Chayka station establishment")] 
		[XmlEnum("12")] 
		EChaykaStationEstablishment = 12,

		[Description(".")]
		[EnumMember(Value = "EGNOS establishment")] 
		[XmlEnum("13")] 
		EgnosEstablishment = 13,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonRemoval : int {
		[Description(".")]
		[EnumMember(Value = "Buoy removal")] 
		[XmlEnum("1")] 
		BuoyRemoval = 1,

		[Description(".")]
		[EnumMember(Value = "Buoy temporary removal")] 
		[XmlEnum("2")] 
		BuoyTemporaryRemoval = 2,

		[Description(".")]
		[EnumMember(Value = "Light removal")] 
		[XmlEnum("3")] 
		LightRemoval = 3,

		[Description(".")]
		[EnumMember(Value = "Light temporary removal")] 
		[XmlEnum("4")] 
		LightTemporaryRemoval = 4,

		[Description(".")]
		[EnumMember(Value = "Beacon removal")] 
		[XmlEnum("5")] 
		BeaconRemoval = 5,

		[Description(".")]
		[EnumMember(Value = "Beacon temporary removal")] 
		[XmlEnum("6")] 
		BeaconTemporaryRemoval = 6,

		[Description(".")]
		[EnumMember(Value = "Fog signal removal")] 
		[XmlEnum("7")] 
		FogSignalRemoval = 7,

		[Description(".")]
		[EnumMember(Value = "Fog signal temporary removal")] 
		[XmlEnum("8")] 
		FogSignalTemporaryRemoval = 8,

		[Description(".")]
		[EnumMember(Value = "Audible signal removal")] 
		[XmlEnum("9")] 
		AudibleSignalRemoval = 9,

		[Description(".")]
		[EnumMember(Value = "Audible signal temporary removal")] 
		[XmlEnum("10")] 
		AudibleSignalTemporaryRemoval = 10,

		[Description(".")]
		[EnumMember(Value = "V-AIS removal")] 
		[XmlEnum("11")] 
		VAisRemoval = 11,

		[Description(".")]
		[EnumMember(Value = "V-AIS temporary removal")] 
		[XmlEnum("12")] 
		VAisTemporaryRemoval = 12,

		[Description(".")]
		[EnumMember(Value = "RACON signal removal")] 
		[XmlEnum("13")] 
		RaconSignalRemoval = 13,

		[Description(".")]
		[EnumMember(Value = "RACON temporary removal")] 
		[XmlEnum("14")] 
		RaconTemporaryRemoval = 14,

		[Description(".")]
		[EnumMember(Value = "DGPS removal")] 
		[XmlEnum("15")] 
		DgpsRemoval = 15,

		[Description(".")]
		[EnumMember(Value = "DGPS temporary removal")] 
		[XmlEnum("16")] 
		DgpsTemporaryRemoval = 16,

		[Description(".")]
		[EnumMember(Value = "EGNOS removal")] 
		[XmlEnum("17")] 
		EgnosRemoval = 17,

		[Description(".")]
		[EnumMember(Value = "EGNOS temporary removal")] 
		[XmlEnum("18")] 
		EgnosTemporaryRemoval = 18,

		[Description(".")]
		[EnumMember(Value = "LORAN C station removal")] 
		[XmlEnum("19")] 
		LoranCStationRemoval = 19,

		[Description(".")]
		[EnumMember(Value = "LORAN C station temporary removal")] 
		[XmlEnum("20")] 
		LoranCStationTemporaryRemoval = 20,

		[Description(".")]
		[EnumMember(Value = "eLORAN removal")] 
		[XmlEnum("21")] 
		EloranRemoval = 21,

		[Description(".")]
		[EnumMember(Value = "eLORAN temporary removal")] 
		[XmlEnum("22")] 
		EloranTemporaryRemoval = 22,

		[Description(".")]
		[EnumMember(Value = "Chayka station removal")] 
		[XmlEnum("23")] 
		ChaykaStationRemoval = 23,

		[Description(".")]
		[EnumMember(Value = "Chayka station temporary removal")] 
		[XmlEnum("24")] 
		ChaykaStationTemporaryRemoval = 24,

		[Description(".")]
		[EnumMember(Value = "e-Chayka station removal")] 
		[XmlEnum("25")] 
		EChaykaStationRemoval = 25,

		[Description(".")]
		[EnumMember(Value = "e-Chayka station temporary removal")] 
		[XmlEnum("26")] 
		EChaykaStationTemporaryRemoval = 26,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonReplacement : int {
		[Description(".")]
		[EnumMember(Value = "Buoy change")] 
		[XmlEnum("1")] 
		BuoyChange = 1,

		[Description(".")]
		[EnumMember(Value = "Buoy temporary change")] 
		[XmlEnum("2")] 
		BuoyTemporaryChange = 2,

		[Description(".")]
		[EnumMember(Value = "Light change")] 
		[XmlEnum("3")] 
		LightChange = 3,

		[Description(".")]
		[EnumMember(Value = "Light temporary change")] 
		[XmlEnum("4")] 
		LightTemporaryChange = 4,

		[Description(".")]
		[EnumMember(Value = "Sector light change")] 
		[XmlEnum("5")] 
		SectorLightChange = 5,

		[Description(".")]
		[EnumMember(Value = "Sector light temporary change")] 
		[XmlEnum("6")] 
		SectorLightTemporaryChange = 6,

		[Description(".")]
		[EnumMember(Value = "Beacon change")] 
		[XmlEnum("7")] 
		BeaconChange = 7,

		[Description(".")]
		[EnumMember(Value = "Beacon temporary change")] 
		[XmlEnum("8")] 
		BeaconTemporaryChange = 8,

		[Description(".")]
		[EnumMember(Value = "Fog signal change")] 
		[XmlEnum("9")] 
		FogSignalChange = 9,

		[Description(".")]
		[EnumMember(Value = "Fog signal temporary change")] 
		[XmlEnum("10")] 
		FogSignalTemporaryChange = 10,

		[Description(".")]
		[EnumMember(Value = "Audible signal change")] 
		[XmlEnum("11")] 
		AudibleSignalChange = 11,

		[Description(".")]
		[EnumMember(Value = "Audible signal temporary change")] 
		[XmlEnum("12")] 
		AudibleSignalTemporaryChange = 12,

		[Description(".")]
		[EnumMember(Value = "V-AIS change")] 
		[XmlEnum("13")] 
		VAisChange = 13,

		[Description(".")]
		[EnumMember(Value = "V-AIS temporary change")] 
		[XmlEnum("14")] 
		VAisTemporaryChange = 14,

		[Description(".")]
		[EnumMember(Value = "RACON signal change")] 
		[XmlEnum("15")] 
		RaconSignalChange = 15,

		[Description(".")]
		[EnumMember(Value = "RACON temporary change")] 
		[XmlEnum("16")] 
		RaconTemporaryChange = 16,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum fixedAtonChange : int {
		[Description(".")]
		[EnumMember(Value = "Beacon missing")] 
		[XmlEnum("1")] 
		BeaconMissing = 1,

		[Description(".")]
		[EnumMember(Value = "Beacon damaged")] 
		[XmlEnum("2")] 
		BeaconDamaged = 2,

		[Description(".")]
		[EnumMember(Value = "Light beacon Unlit")] 
		[XmlEnum("3")] 
		LightBeaconUnlit = 3,

		[Description(".")]
		[EnumMember(Value = "Light beacon Unreliable")] 
		[XmlEnum("4")] 
		LightBeaconUnreliable = 4,

		[Description(".")]
		[EnumMember(Value = "Light beacon Not synchronized")] 
		[XmlEnum("5")] 
		LightBeaconNotSynchronized = 5,

		[Description(".")]
		[EnumMember(Value = "Light beacon damaged")] 
		[XmlEnum("6")] 
		LightBeaconDamaged = 6,

		[Description(".")]
		[EnumMember(Value = "Beacon topmark missing")] 
		[XmlEnum("7")] 
		BeaconTopmarkMissing = 7,

		[Description(".")]
		[EnumMember(Value = "Beacon topmark damaged")] 
		[XmlEnum("8")] 
		BeaconTopmarkDamaged = 8,

		[Description(".")]
		[EnumMember(Value = "Beacon daymark unreliable")] 
		[XmlEnum("9")] 
		BeaconDaymarkUnreliable = 9,

		[Description(".")]
		[EnumMember(Value = "Floodlit beacon Unlit")] 
		[XmlEnum("10")] 
		FloodlitBeaconUnlit = 10,

		[Description(".")]
		[EnumMember(Value = "Beacon restored to normal")] 
		[XmlEnum("11")] 
		BeaconRestoredToNormal = 11,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum floatingAtonChange : int {
		[Description(".")]
		[EnumMember(Value = "Buoy adrift")] 
		[XmlEnum("1")] 
		BuoyAdrift = 1,

		[Description(".")]
		[EnumMember(Value = "Buoy damaged")] 
		[XmlEnum("2")] 
		BuoyDamaged = 2,

		[Description(".")]
		[EnumMember(Value = "Buoy daymark unreliable")] 
		[XmlEnum("3")] 
		BuoyDaymarkUnreliable = 3,

		[Description(".")]
		[EnumMember(Value = "Buoy destroyed")] 
		[XmlEnum("4")] 
		BuoyDestroyed = 4,

		[Description(".")]
		[EnumMember(Value = "Buoy missing")] 
		[XmlEnum("5")] 
		BuoyMissing = 5,

		[Description(".")]
		[EnumMember(Value = "Buoy move")] 
		[XmlEnum("6")] 
		BuoyMove = 6,

		[Description(".")]
		[EnumMember(Value = "Buoy off position")] 
		[XmlEnum("7")] 
		BuoyOffPosition = 7,

		[Description(".")]
		[EnumMember(Value = "Buoy re-establishment")] 
		[XmlEnum("8")] 
		BuoyReEstablishment = 8,

		[Description(".")]
		[EnumMember(Value = "Buoy restored to normal")] 
		[XmlEnum("9")] 
		BuoyRestoredToNormal = 9,

		[Description(".")]
		[EnumMember(Value = "Buoy topmark damaged")] 
		[XmlEnum("10")] 
		BuoyTopmarkDamaged = 10,

		[Description(".")]
		[EnumMember(Value = "Buoy topmark missing")] 
		[XmlEnum("11")] 
		BuoyTopmarkMissing = 11,

		[Description(".")]
		[EnumMember(Value = "Buoy will be withdrawn")] 
		[XmlEnum("12")] 
		BuoyWillBeWithdrawn = 12,

		[Description(".")]
		[EnumMember(Value = "Buoy withdrawn")] 
		[XmlEnum("13")] 
		BuoyWithdrawn = 13,

		[Description(".")]
		[EnumMember(Value = "Decommissioned for winter")] 
		[XmlEnum("14")] 
		DecommissionedForWinter = 14,

		[Description(".")]
		[EnumMember(Value = "Lifted for Winter")] 
		[XmlEnum("15")] 
		LiftedForWinter = 15,

		[Description(".")]
		[EnumMember(Value = "Light buoy Light damaged")] 
		[XmlEnum("16")] 
		LightBuoyLightDamaged = 16,

		[Description(".")]
		[EnumMember(Value = "Light buoy Light not synchronized")] 
		[XmlEnum("17")] 
		LightBuoyLightNotSynchronized = 17,

		[Description(".")]
		[EnumMember(Value = "Light buoy Light unlit")] 
		[XmlEnum("18")] 
		LightBuoyLightUnlit = 18,

		[Description(".")]
		[EnumMember(Value = "Light buoy Light unreliable")] 
		[XmlEnum("19")] 
		LightBuoyLightUnreliable = 19,

		[Description(".")]
		[EnumMember(Value = "Marine Aids to Navigation unreliable")] 
		[XmlEnum("20")] 
		MarineAidsToNavigationUnreliable = 20,

		[Description(".")]
		[EnumMember(Value = "Recommissioned for navigation season")] 
		[XmlEnum("21")] 
		RecommissionedForNavigationSeason = 21,

		[Description(".")]
		[EnumMember(Value = "Replaced by Winter Spar")] 
		[XmlEnum("22")] 
		ReplacedByWinterSpar = 22,

		[Description(".")]
		[EnumMember(Value = "Seasonal decommissioning complete")] 
		[XmlEnum("23")] 
		SeasonalDecommissioningComplete = 23,

		[Description(".")]
		[EnumMember(Value = "Seasonal decommissioning in progress")] 
		[XmlEnum("24")] 
		SeasonalDecommissioningInProgress = 24,

		[Description(".")]
		[EnumMember(Value = "Seasonal recommissioning complete")] 
		[XmlEnum("25")] 
		SeasonalRecommissioningComplete = 25,

		[Description(".")]
		[EnumMember(Value = "Seasonal recommissioning in progress")] 
		[XmlEnum("26")] 
		SeasonalRecommissioningInProgress = 26,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum audibleSignalAtonChange : int {
		[Description(".")]
		[EnumMember(Value = "Audible signal out of service")] 
		[XmlEnum("1")] 
		AudibleSignalOutOfService = 1,

		[Description(".")]
		[EnumMember(Value = "Fog signal out of service")] 
		[XmlEnum("2")] 
		FogSignalOutOfService = 2,

		[Description(".")]
		[EnumMember(Value = "Audible signal operating properly")] 
		[XmlEnum("3")] 
		AudibleSignalOperatingProperly = 3,

		[Description(".")]
		[EnumMember(Value = "Fog signal operating properly")] 
		[XmlEnum("4")] 
		FogSignalOperatingProperly = 4,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightedAtonChange : int {
		[Description(".")]
		[EnumMember(Value = "Light unlit")] 
		[XmlEnum("1")] 
		LightUnlit = 1,

		[Description(".")]
		[EnumMember(Value = "Light unreliable")] 
		[XmlEnum("2")] 
		LightUnreliable = 2,

		[Description(".")]
		[EnumMember(Value = "Light re-establishment")] 
		[XmlEnum("3")] 
		LightReEstablishment = 3,

		[Description(".")]
		[EnumMember(Value = "Light range reduced")] 
		[XmlEnum("4")] 
		LightRangeReduced = 4,

		[Description(".")]
		[EnumMember(Value = "Light without rhythm")] 
		[XmlEnum("5")] 
		LightWithoutRhythm = 5,

		[Description(".")]
		[EnumMember(Value = "Light out of synchronization")] 
		[XmlEnum("6")] 
		LightOutOfSynchronization = 6,

		[Description(".")]
		[EnumMember(Value = "Light daymark unreliable")] 
		[XmlEnum("7")] 
		LightDaymarkUnreliable = 7,

		[Description(".")]
		[EnumMember(Value = "Light operating properly")] 
		[XmlEnum("8")] 
		LightOperatingProperly = 8,

		[Description(".")]
		[EnumMember(Value = "Sector light Sector obscured")] 
		[XmlEnum("9")] 
		SectorLightSectorObscured = 9,

		[Description(".")]
		[EnumMember(Value = "Front leading/range light Unlit")] 
		[XmlEnum("10")] 
		FrontLeadingRangeLightUnlit = 10,

		[Description(".")]
		[EnumMember(Value = "Rear leading/range light Unlit")] 
		[XmlEnum("11")] 
		RearLeadingRangeLightUnlit = 11,

		[Description(".")]
		[EnumMember(Value = "Front leading/range light Unreliable")] 
		[XmlEnum("12")] 
		FrontLeadingRangeLightUnreliable = 12,

		[Description(".")]
		[EnumMember(Value = "Rear leading/range light Unreliable")] 
		[XmlEnum("13")] 
		RearLeadingRangeLightUnreliable = 13,

		[Description(".")]
		[EnumMember(Value = "Front leading/range light Light range reduced")] 
		[XmlEnum("14")] 
		FrontLeadingRangeLightLightRangeReduced = 14,

		[Description(".")]
		[EnumMember(Value = "Rear leading/range light Light range reduced")] 
		[XmlEnum("15")] 
		RearLeadingRangeLightLightRangeReduced = 15,

		[Description(".")]
		[EnumMember(Value = "Front leading/range light without rhythm")] 
		[XmlEnum("16")] 
		FrontLeadingRangeLightWithoutRhythm = 16,

		[Description(".")]
		[EnumMember(Value = "Rear leading/range light without rhythm")] 
		[XmlEnum("17")] 
		RearLeadingRangeLightWithoutRhythm = 17,

		[Description(".")]
		[EnumMember(Value = "Leading/range lights out of synchronization")] 
		[XmlEnum("18")] 
		LeadingRangeLightsOutOfSynchronization = 18,

		[Description(".")]
		[EnumMember(Value = "Front leading/range beacon Unreliable")] 
		[XmlEnum("19")] 
		FrontLeadingRangeBeaconUnreliable = 19,

		[Description(".")]
		[EnumMember(Value = "Rear leading/range beacon Unreliable")] 
		[XmlEnum("20")] 
		RearLeadingRangeBeaconUnreliable = 20,

		[Description(".")]
		[EnumMember(Value = "Front leading/range light is operating properly")] 
		[XmlEnum("21")] 
		FrontLeadingRangeLightIsOperatingProperly = 21,

		[Description(".")]
		[EnumMember(Value = "Rear leading/range light is operating properly")] 
		[XmlEnum("22")] 
		RearLeadingRangeLightIsOperatingProperly = 22,

		[Description(".")]
		[EnumMember(Value = "Front leading/range beacon restored to normal")] 
		[XmlEnum("23")] 
		FrontLeadingRangeBeaconRestoredToNormal = 23,

		[Description(".")]
		[EnumMember(Value = "Rear leading/range beacon restored to normal")] 
		[XmlEnum("24")] 
		RearLeadingRangeBeaconRestoredToNormal = 24,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum electronicAtonChange : int {
		[Description(".")]
		[EnumMember(Value = "AIS transmitter out of service")] 
		[XmlEnum("1")] 
		AisTransmitterOutOfService = 1,

		[Description(".")]
		[EnumMember(Value = "AIS transmitter unreliable")] 
		[XmlEnum("2")] 
		AisTransmitterUnreliable = 2,

		[Description(".")]
		[EnumMember(Value = "AIS transmitter operating properly")] 
		[XmlEnum("3")] 
		AisTransmitterOperatingProperly = 3,

		[Description(".")]
		[EnumMember(Value = "V-AIS out of service")] 
		[XmlEnum("4")] 
		VAisOutOfService = 4,

		[Description(".")]
		[EnumMember(Value = "V-AIS unreliable")] 
		[XmlEnum("5")] 
		VAisUnreliable = 5,

		[Description(".")]
		[EnumMember(Value = "V-AIS operating properly")] 
		[XmlEnum("6")] 
		VAisOperatingProperly = 6,

		[Description(".")]
		[EnumMember(Value = "RACON out of service")] 
		[XmlEnum("7")] 
		RaconOutOfService = 7,

		[Description(".")]
		[EnumMember(Value = "RACON unreliable")] 
		[XmlEnum("8")] 
		RaconUnreliable = 8,

		[Description(".")]
		[EnumMember(Value = "RACON operating properly")] 
		[XmlEnum("9")] 
		RaconOperatingProperly = 9,

		[Description(".")]
		[EnumMember(Value = "DGPS out of service")] 
		[XmlEnum("10")] 
		DgpsOutOfService = 10,

		[Description(".")]
		[EnumMember(Value = "DGPS operating properly")] 
		[XmlEnum("11")] 
		DgpsOperatingProperly = 11,

		[Description(".")]
		[EnumMember(Value = "DGPS unreliable")] 
		[XmlEnum("12")] 
		DgpsUnreliable = 12,

		[Description(".")]
		[EnumMember(Value = "LORAN C operating properly")] 
		[XmlEnum("13")] 
		LoranCOperatingProperly = 13,

		[Description(".")]
		[EnumMember(Value = "LORAN C unreliable")] 
		[XmlEnum("14")] 
		LoranCUnreliable = 14,

		[Description(".")]
		[EnumMember(Value = "LORAN C out of service")] 
		[XmlEnum("15")] 
		LoranCOutOfService = 15,

		[Description(".")]
		[EnumMember(Value = "eLORAN operating properly")] 
		[XmlEnum("16")] 
		EloranOperatingProperly = 16,

		[Description(".")]
		[EnumMember(Value = "eLORAN unreliable")] 
		[XmlEnum("17")] 
		EloranUnreliable = 17,

		[Description(".")]
		[EnumMember(Value = "eLORAN out of service")] 
		[XmlEnum("18")] 
		EloranOutOfService = 18,

		[Description(".")]
		[EnumMember(Value = "DGLOANSS operating properly")] 
		[XmlEnum("19")] 
		DgloanssOperatingProperly = 19,

		[Description(".")]
		[EnumMember(Value = "DGLOANSS unreliable")] 
		[XmlEnum("20")] 
		DgloanssUnreliable = 20,

		[Description(".")]
		[EnumMember(Value = "DGLOANSS out of service")] 
		[XmlEnum("21")] 
		DgloanssOutOfService = 21,

		[Description(".")]
		[EnumMember(Value = "Chayka operating properly")] 
		[XmlEnum("22")] 
		ChaykaOperatingProperly = 22,

		[Description(".")]
		[EnumMember(Value = "Chayka unreliable")] 
		[XmlEnum("23")] 
		ChaykaUnreliable = 23,

		[Description(".")]
		[EnumMember(Value = "Chayka out of service")] 
		[XmlEnum("24")] 
		ChaykaOutOfService = 24,

		[Description(".")]
		[EnumMember(Value = "e-Chayka operating properly")] 
		[XmlEnum("25")] 
		EChaykaOperatingProperly = 25,

		[Description(".")]
		[EnumMember(Value = "e-Chayka unreliable")] 
		[XmlEnum("26")] 
		EChaykaUnreliable = 26,

		[Description(".")]
		[EnumMember(Value = "e-Chayka out of service")] 
		[XmlEnum("27")] 
		EChaykaOutOfService = 27,

		[Description(".")]
		[EnumMember(Value = "EGNOS operating properly")] 
		[XmlEnum("28")] 
		EgnosOperatingProperly = 28,

		[Description(".")]
		[EnumMember(Value = "EGNOS unreliable")] 
		[XmlEnum("29")] 
		EgnosUnreliable = 29,

		[Description(".")]
		[EnumMember(Value = "EGNOS out of service")] 
		[XmlEnum("30")] 
		EgnosOutOfService = 30,
	}

	/// <summary>
	/// .
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum positioningEquipment : int {
		[Description(".")]
		[EnumMember(Value = "DGPS Receiver")] 
		[XmlEnum("1")] 
		DgpsReceiver = 1,

		[Description(".")]
		[EnumMember(Value = "GLONASS Receiver")] 
		[XmlEnum("2")] 
		GlonassReceiver = 2,

		[Description(".")]
		[EnumMember(Value = "GPS Receiver")] 
		[XmlEnum("3")] 
		GpsReceiver = 3,

		[Description(".")]
		[EnumMember(Value = "GPS/WAAS Receiver")] 
		[XmlEnum("4")] 
		GpsWaasReceiver = 4,
	}

	/// <summary>
	/// named associations between two or more aids to navigation and/or navigationally relevant features
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

	/// <summary>
	/// named aggregations between two or more aids to navigation and/or navigationally relevant features
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

	public static class CodeList
	{
		public static ImmutableArray<CategoryOfAssociation> CategoryOfAssociations => ImmutableArray.Create<CategoryOfAssociation>(new CategoryOfAssociation[]{
			new() {
				code = 1,
				definition = "-",
				label = "channel markings",
			},
			new() {
				code = 2,
				definition = "-",
				label = "danger markings",
			},
		});

		public static ImmutableArray<CategoryOfAggregation> CategoryOfAggregations => ImmutableArray.Create<CategoryOfAggregation>(new CategoryOfAggregation[]{
			new() {
				code = 1,
				definition = "-",
				label = "leading line",
			},
			new() {
				code = 3,
				definition = "-",
				label = "measured distance",
			},
			new() {
				code = 2,
				definition = "-",
				label = "range system",
			},
		});
	}

	namespace ComplexAttributes {
		/// <summary>
		/// Direction or superscription of a letter, package, etc., specifying the name of the place to which it is directed, and optionally a contact person or organisation who should receive it.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress : ComplexType {
			[XmlElement("deliveryPoint")]
			[Optional]
			public String? deliveryPoint {get;set;} = default;

			[XmlElement("cityName")]
			[Optional]
			public String? cityName {get;set;} = default;

			[XmlElement("administrativeDivision")]
			[Optional]
			public String? administrativeDivision {get;set;} = default;

			[XmlElement("countryName")]
			[Optional]
			public String? countryName {get;set;} = default;

			[XmlElement("postalCode")]
			[Optional]
			public String? postalCode {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializedeliveryPoint() { return !string.IsNullOrEmpty(deliveryPoint); }

			public bool ShouldSerializecityName() { return !string.IsNullOrEmpty(cityName); }

			public bool ShouldSerializeadministrativeDivision() { return !string.IsNullOrEmpty(administrativeDivision); }

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			public bool ShouldSerializepostalCode() { return !string.IsNullOrEmpty(postalCode); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<contactAddress, bool>> _conditionalUnknown = new Dictionary<string,Func<contactAddress, bool>> {
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
			[XmlElement("displayName")]
			[Optional]
			public Boolean? displayName {get;set;} = default;

			[XmlElement("language")]
			[Optional]
			public String? language {get;set;} = default;

			[XmlElement("name")]
			[Mandatory]
			public String name {get;set;} = string.Empty;

			#region ShouldSerialize
			public bool ShouldSerializedisplayName() { return displayName.HasValue; }

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
			#endregion

			#region SerializableEnumeration

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

			#region ShouldSerialize
			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }
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
		/// (1) The angular distance measured from true north to the major axis of the feature. (2) In ECDIS, the mode in which information on the ECDIS is being presented. Typical modes include: north-up - as shown on a nautical chart, north is at the top of the display; Ships head-up - based on the actual heading of the ship, (e.g. Ships gyrocompass); course-up display - based on the course or route being taken.
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
			public int? sectorLineLength {get;set;} = default;

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
			public int? sectorLineLength {get;set;} = default;

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
		/// Textual information about the shape of a non-standard topmark.
		/// </summary>
		/// <remarks>
		/// No formatting of text is possible within shape information. If formatted text is required, then an associated text file referenced by the complex attribute textual description must be used.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class shapeInformation : ComplexType {
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

			private IReadOnlyDictionary<string, Func<shapeInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<shapeInformation, bool>> {
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
			[PermittedValues([1,2])]
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
		/// The dimensions of a cable to give its length and diameter.
		/// </summary>
		/// <remarks>
		/// -
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class CableDimensions : ComplexType {
			[XmlElement("cableLength")]
			[Mandatory]
			public double cableLength {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6])]
			[Mandatory]
			public heightLengthUnits heightLengthUnits {get;set;}

			[XmlElement("diameter")]
			[Mandatory]
			public double diameter {get;set;} = default;

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("heightLengthUnits")]
			public SerializableEnumeration<heightLengthUnits> heightLengthUnitsElement { get { return heightLengthUnits; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<CableDimensions, bool>> _conditionalUnknown = new Dictionary<string,Func<CableDimensions, bool>> {
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
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public atonCommissioning? atonCommissioning {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			[Optional]
			public atonRemoval? atonRemoval {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			[Optional]
			public atonReplacement? atonReplacement {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
			[Optional]
			public fixedAtonChange? fixedAtonChange {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26])]
			[Optional]
			public floatingAtonChange? floatingAtonChange {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
			[Optional]
			public audibleSignalAtonChange? audibleSignalAtonChange {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
			[Optional]
			public lightedAtonChange? lightedAtonChange {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30])]
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
		/// The dimensions of a sinker/anchor to give its three dimensional shape measurements.
		/// </summary>
		/// <remarks>
		/// -
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sinkerDimensions : ComplexType {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6])]
			[Mandatory]
			public heightLengthUnits heightLengthUnits {get;set;}

			[XmlElement("horizontalLength")]
			[Optional]
			public double? horizontalLength {get;set;} = default;

			[XmlElement("horizontalWidth")]
			[Optional]
			public double? horizontalWidth {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("heightLengthUnits")]
			public SerializableEnumeration<heightLengthUnits> heightLengthUnitsElement { get { return heightLengthUnits; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<sinkerDimensions, bool>> _conditionalUnknown = new Dictionary<string,Func<sinkerDimensions, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A description of the method used to obtain a position.(proposed by CCG)
		/// </summary>
		/// <remarks>
		/// -
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class positioningMethod : ComplexType {
			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
			[Mandatory]
			public positioningEquipment positioningEquipment {get;set;}

			[XmlElement("NMEAString")]
			[Mandatory]
			public String NMEAString {get;set;} = string.Empty;

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("positioningEquipment")]
			public SerializableEnumeration<positioningEquipment> positioningEquipmentElement { get { return positioningEquipment; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<positioningMethod, bool>> _conditionalUnknown = new Dictionary<string,Func<positioningMethod, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

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
		/// Encodes the file name of a single external text file that contains the text in a defined language, which provides additional textual information that cannot be provided using other allowable attributes for the feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textualDescription : ComplexType {
			[XmlElement("fileReference")]
			[Mandatory]
			public String fileReference {get;set;} = string.Empty;

			[XmlElement("language")]
			[Optional]
			public String? language {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<textualDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<textualDescription, bool>> {
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
			[PermittedValues([1,2,3,4,5,6,7,8,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,31,32,33,34,35])]
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
		/// Provides an indication of the vertical and horizontal positional uncertainty of bathymetric data, optionally within a specified date range.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class spatialAccuracy : ComplexType {
			[XmlElement("fixedDateRange")]
			[Optional]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			[XmlElement("horizontalPositionUncertainty")]
			[Optional]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			[XmlElement("verticalUncertainty")]
			[Optional]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }
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

		/// <summary>
		/// A sector is the part of a circle between two straight lines drawn from the centre to the circumference.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lightSector : ComplexType {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlElement("directionalCharacter")]
			[Optional]
			public directionalCharacter? directionalCharacter {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			[XmlElement("sectorLimit")]
			[Optional]
			public sectorLimit? sectorLimit {get;set;} = default;

			[XmlElement("valueOfNominalRange")]
			[Optional]
			public double? valueOfNominalRange {get;set;} = default;

			[XmlElement("sectorInformation")]
			[Optional]
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
			[PermittedValues([1,2,3,4,5,6,7,8,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,31,32,33,34,35])]
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

	}
	public enum Role {
		[Description("-")]
		Statuspart,
		[Description("TBD")]
		buoyPart,
		[Description("TBD")]
		topmarkPart,
		[Description("-")]
		parent,
		[Description("-")]
		child,
		[Description("-")]
		physicalAISbroadcastBy,
		[Description("-")]
		physicalAISbroadcasts,
		[Description("-")]
		syntheticAISbroadcastBy,
		[Description("-")]
		syntheticAISbroadcasts,
		[Description("-")]
		virtualAISbroadcastBy,
		[Description("-")]
		virtualAISbroadcasts,
		[Description("-")]
		buoyattached,
		[Description("-")]
		counterWeightholds,
		[Description("-")]
		buoyhangs,
		[Description("-")]
		bridleholds,
		[Description("-")]
		shackleToCableconnectedTo,
		[Description("-")]
		shackleToCableconnected,
		[Description("-")]
		swivelattached,
		[Description("-")]
		bridleattached,
		[Description("-")]
		cableholds,
		[Description("-")]
		shackleToBridleconnected,
		[Description("-")]
		shackleToBridleconnectedTo,
		[Description("-")]
		shackleToBuoyconnected,
		[Description("-")]
		shackleToBuoyconnectedTo,
		[Description("-")]
		shackleToSwivelconnected,
		[Description("-")]
		shackleToSwivelconnectedTo,
		[Description("-")]
		shackleToAnchorconnectedTo,
		[Description("-")]
		shackleToAnchorconnected,
		[Description("-")]
		bridlehangs,
		[Description("-")]
		swivelholds,
		[Description("TBD")]
		peerAtonAggregation,
		[Description("TBD")]
		atonAggregationBy,
		[Description("TBD")]
		peerAtonAssociation,
		[Description("TBD")]
		atonAssociationBy,
		[Description("The role given to the navigable part of the navigation line.")]
		navigableTrack,
		[Description("The role given to the navigation line(s) that is generally formed between two or more objects, or by one object and a bearing.")]
		navigationLine,
		[Description("-")]
		fixingMethod,
		[Description("-")]
		positioningMethod,
		[Description("-")]
		danger,
		[Description("-")]
		markingAton,
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

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonFixingMethodAssociation : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AtonFixingMethodAssociation);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonPositioningInformationAssociation : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AtonPositioningInformationAssociation);
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
		/// 
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
		public partial class BuoyCounterWeight : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BuoyCounterWeight);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BridleConnection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BridleConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleConnection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShackleConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleConnectionFromCable : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShackleConnectionFromCable);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SwivelCableConnection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SwivelCableConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BridleCableConnection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BridleCableConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleToBridleConnection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShackleToBridleConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleToSwivelConnection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShackleToSwivelConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleToAnchorConnection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShackleToAnchorConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SwivelConnection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SwivelConnection);
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
		/// 
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

namespace S100Framework.DomainModel.S201 {
	using ComplexAttributes;
	using InformationAssociations;
		using System.Xml.Linq;

	namespace InformationTypes {
		/// <summary>
		/// Method used for fixing the position of an aid to navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtoNFixingMethod : InformationNode {
			[XmlElement("referencePoint")]
			[Optional]
			public String? referencePoint {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131])]
			[Optional]
			public horizontalDatum? horizontalDatum {get;set;} = default;

			[XmlIgnore]
			[Mandatory]
			public DateOnly sourceDate {get;set;} = default;

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "sourceDate")]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public DateTime sourceDateField {
				get { return sourceDate.ToDateTime(TimeOnly.MinValue); }
				set { sourceDate = DateOnly.FromDateTime(value); }
			}

			[XmlElement("positioningProcedure")]
			[Mandatory]
			public String positioningProcedure {get;set;} = string.Empty;


			#region ShouldSerialize
			public bool ShouldSerializereferencePoint() { return !string.IsNullOrEmpty(referencePoint); }

			public bool ShouldSerializehorizontalDatum() { return horizontalDatum.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("horizontalDatum")]
			public SerializableEnumeration<horizontalDatum>? horizontalDatumElement { get { return horizontalDatum; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AtoNFixingMethod);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtoNFixingMethod.informationBindingDefinitions;
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<AtoNFixingMethod, bool>> _conditionalUnknown = new Dictionary<string,Func<AtoNFixingMethod, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonStatusInformation : InformationNode {
			[XmlElement("ChangeDetails")]
			[Mandatory]
			public ChangeDetails ChangeDetails {get;set;} = new ChangeDetails {
			};

			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtonStatusInformation.informationBindingDefinitions;
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

		/// <summary>
		/// Information about how a position was obtained. (proposed by CCG)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PositioningInformation : InformationNode {
			[XmlElement("positioningDevice")]
			[Mandatory]
			public String positioningDevice {get;set;} = string.Empty;

			[XmlElement("positioningMethod")]
			[Optional]
			public positioningMethod? positioningMethod {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializepositioningMethod() { return positioningMethod!=default; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PositioningInformation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PositioningInformation.informationBindingDefinitions;
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<PositioningInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<PositioningInformation, bool>> {
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
		public partial class SpatialQuality : InformationNode {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpatialQuality.informationBindingDefinitions;
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
		/// A visual, acoustical, or radio device, external to a ship, designed to assist in determining a safe course or a vessel's position, or to warn of dangers and/or obstructions. Aids to navigation usually include buoys, beacons, fog signals, lights, radio beacons, leading marks, radio position fixing systems and GNSS which are chart-related and assist safe navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class AidsToNavigation : FeatureNode {
			[XmlElement("iDCode")]
			[Optional]
			public String? iDCode {get;set;} = default;

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

			[XmlElement("inspectionFrequency")]
			[Optional]
			public String? inspectionFrequency {get;set;} = default;

			[XmlElement("inspectionRequirements")]
			[Optional]
			public String? inspectionRequirements {get;set;} = default;

			[XmlElement("aToNMaintenanceRecord")]
			[Optional]
			public String? aToNMaintenanceRecord {get;set;} = default;

			[XmlIgnore]
			[Optional]
			public DateOnly? installationDate {get;set;} = default;

			[XmlElement("fixedDateRange")]
			[Optional]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			[XmlElement("periodicDateRange")]
			[Optional]
			public periodicDateRange? periodicDateRange {get;set;} = default;

			[XmlElement("SeasonalActionRequired")]
			[Optional]
			public List<String> SeasonalActionRequired {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeiDCode() { return !string.IsNullOrEmpty(iDCode); }

			public bool ShouldSerializeinformation() { return information.Any(); }

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			public bool ShouldSerializesourceDate() { return sourceDate.HasValue; }

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			public bool ShouldSerializeinspectionFrequency() { return !string.IsNullOrEmpty(inspectionFrequency); }

			public bool ShouldSerializeinspectionRequirements() { return !string.IsNullOrEmpty(inspectionRequirements); }

			public bool ShouldSerializeaToNMaintenanceRecord() { return !string.IsNullOrEmpty(aToNMaintenanceRecord); }

			public bool ShouldSerializeinstallationDate() { return installationDate.HasValue; }

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange!=default; }

			public bool ShouldSerializeSeasonalActionRequired() { return SeasonalActionRequired.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AidsToNavigation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AidsToNavigation.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.AidsToNavigation.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AidsToNavigation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			#endregion
		}

		/// <summary>
		/// Something (such as a house, tower, bridge, etc.) that is built by putting parts together and that usually stands on its own.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class StructureObject : AidsToNavigation {
			[XmlElement("AtoNNumber")]
			[Mandatory]
			public String AtoNNumber {get;set;} = string.Empty;

			[XmlIgnore]
			[PermittedValues([1,2,3])]
			[Optional]
			public aidAvailabilityCategory? aidAvailabilityCategory {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5])]
			[Optional]
			public condition? condition {get;set;} = default;

			[XmlElement("contactAddress")]
			[Optional]
			public contactAddress? contactAddress {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeaidAvailabilityCategory() { return aidAvailabilityCategory.HasValue; }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public bool ShouldSerializecontactAddress() { return contactAddress!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("aidAvailabilityCategory")]
			public SerializableEnumeration<aidAvailabilityCategory>? aidAvailabilityCategoryElement { get { return aidAvailabilityCategory; } set { } }

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(StructureObject);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.StructureObject.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.StructureObject.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..StructureObject._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			#endregion
		}

		/// <summary>
		/// The implements used in an operation or activity.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class Equipment : AidsToNavigation {
			[XmlElement("remoteMonitoringSystem")]
			[Optional]
			public List<String> remoteMonitoringSystem {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeremoteMonitoringSystem() { return remoteMonitoringSystem.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Equipment);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Equipment.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Equipment.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Equipment._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.ElectronicAton.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.ElectronicAton.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..ElectronicAton._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			#endregion
		}

		/// <summary>
		/// A fixed artificial navigation mark that can be recognized by its shape, colour, pattern, topmark or light character, or a combination of these. It may carry various additional aids to navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericBeacon : StructureObject {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7])]
			[Mandatory]
			public beaconShape beaconShape {get;set;}

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("elevation")]
			[Optional]
			public double? elevation {get;set;} = default;

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,9,10,11,12,13,14,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }
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
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(GenericBeacon);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.GenericBeacon.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.GenericBeacon.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..GenericBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			#endregion
		}

		/// <summary>
		/// A floating object moored to the bottom in a particular (charted) place, as an aid to navigation or for other specific purposes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericBuoy : StructureObject {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8])]
			[Mandatory]
			public buoyShape buoyShape {get;set;}

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,9,10,11,12,13,14,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("typeOfBuoy")]
			[Optional]
			public String? typeOfBuoy {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializetypeOfBuoy() { return !string.IsNullOrEmpty(typeOfBuoy); }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.GenericBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.GenericBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..GenericBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
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

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlElement("effectiveIntensity")]
			[Optional]
			public double? effectiveIntensity {get;set;} = default;

			[XmlElement("peakIntensity")]
			[Optional]
			public double? peakIntensity {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializeeffectiveIntensity() { return effectiveIntensity.HasValue; }

			public bool ShouldSerializepeakIntensity() { return peakIntensity.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(GenericLight);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.GenericLight.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.GenericLight.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..GenericLight._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			#endregion
		}

		/// <summary>
		/// A prominent object at a fixed location on land which can be used in determining a location or a direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Landmark : StructureObject {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			[Multiplicity(1)]
			public List<categoryOfLandmark> categoryOfLandmark {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48])]
			[Optional]
			public List<function> function {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3])]
			[Mandatory]
			public visualProminence visualProminence {get;set;}

			[XmlElement("elevation")]
			[Optional]
			public double? elevation {get;set;} = default;

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlElement("mannedStructure")]
			[Optional]
			public Boolean? mannedStructure {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfLandmark() { return categoryOfLandmark.Any(); }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializefunction() { return function.Any(); }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializemannedStructure() { return mannedStructure.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }
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
			[XmlElement("function")]
			public SerializableEnumeration<function>[] functionElement { get { return [.. function]; } set { } }

			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence> visualProminenceElement { get { return visualProminence; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Landmark);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Landmark.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Landmark.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Landmark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
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

			private IReadOnlyDictionary<string, Func<Landmark, bool>> _conditionalUnknown = new Dictionary<string,Func<Landmark, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LateralBeacon.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LateralBeacon.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..LateralBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<LateralBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<LateralBeacon, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LateralBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LateralBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..LateralBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<LateralBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<LateralBuoy, bool>> {
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
			[PermittedValues([1,2,3])]
			[Mandatory]
			public categoryOfNavigationLine categoryOfNavigationLine {get;set;}

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("orientation")]
			[Mandatory]
			public orientation orientation {get;set;} = new orientation {
				orientationValue = default,
			};


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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NavigationLine.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.NavigationLine.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..NavigationLine._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve
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

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlElement("orientation")]
			[Mandatory]
			public orientation orientation {get;set;} = new orientation {
				orientationValue = default,
			};

			[XmlElement("verticalUncertainty")]
			[Optional]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
			[Optional]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			[Optional]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
			[Mandatory]
			public trafficFlow trafficFlow {get;set;}


			#region ShouldSerialize
			public bool ShouldSerializedepthRangeMinimumValue() { return depthRangeMinimumValue.HasValue; }

			public bool ShouldSerializemaximalPermittedDraught() { return maximalPermittedDraught.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			[JsonIgnore]
			[XmlElement("qualityOfVerticalMeasurement")]
			public SerializableEnumeration<qualityOfVerticalMeasurement>[] qualityOfVerticalMeasurementElement { get { return [.. qualityOfVerticalMeasurement]; } set { } }

			[JsonIgnore]
			[XmlElement("techniqueOfVerticalMeasurement")]
			public SerializableEnumeration<techniqueOfVerticalMeasurement>[] techniqueOfVerticalMeasurementElement { get { return [.. techniqueOfVerticalMeasurement]; } set { } }

			[JsonIgnore]
			[XmlElement("trafficFlow")]
			public SerializableEnumeration<trafficFlow> trafficFlowElement { get { return trafficFlow; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RecommendedTrack);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RecommendedTrack.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RecommendedTrack.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..RecommendedTrack._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve
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
		/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightSectored : GenericLight {
			[XmlIgnore]
			[PermittedValues([1,3,4,5,6,9,10,11,14,15,16,17,18,19,20])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
			[Optional]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
			[Optional]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,9,10,11,12,13,14,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6])]
			[Optional]
			public signalGeneration? signalGeneration {get;set;} = default;

			[XmlElement("ObscuredSector")]
			[Optional]
			public List<ObscuredSector> ObscuredSector {get;set;} = [];

			[XmlElement("sectorCharacteristics")]
			[Multiplicity(1)]
			public List<sectorCharacteristics> sectorCharacteristics {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			public bool ShouldSerializeObscuredSector() { return ObscuredSector.Any(); }

			public bool ShouldSerializesectorCharacteristics() { return sectorCharacteristics.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfLight")]
			public SerializableEnumeration<categoryOfLight>[] categoryOfLightElement { get { return [.. categoryOfLight]; } set { } }

			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>? exhibitionConditionOfLightElement { get { return exhibitionConditionOfLight; } set { } }

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			[JsonIgnore]
			[XmlElement("signalGeneration")]
			public SerializableEnumeration<signalGeneration>? signalGenerationElement { get { return signalGeneration; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightSectored);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightSectored.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightSectored.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightSectored._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

		/// <summary>
		/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAllAround : GenericLight {
			[XmlIgnore]
			[PermittedValues([1,3,4,5,6,9,10,11,14,15,16,17,18,19,20])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
			[Optional]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
			[Optional]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public lightVisibility? lightVisibility {get;set;} = default;

			[XmlElement("majorLight")]
			[Optional]
			public Boolean? majorLight {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,9,10,11,12,13,14,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6])]
			[Optional]
			public signalGeneration? signalGeneration {get;set;} = default;

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

			[XmlElement("flareBearing")]
			[Optional]
			public int? flareBearing {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			public bool ShouldSerializelightVisibility() { return lightVisibility.HasValue; }

			public bool ShouldSerializemajorLight() { return majorLight.HasValue; }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("colour")]
			public SerializableEnumeration<colour>[] colourElement { get { return [.. colour]; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfLight")]
			public SerializableEnumeration<categoryOfLight>[] categoryOfLightElement { get { return [.. categoryOfLight]; } set { } }

			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>? exhibitionConditionOfLightElement { get { return exhibitionConditionOfLight; } set { } }

			[JsonIgnore]
			[XmlElement("lightVisibility")]
			public SerializableEnumeration<lightVisibility>? lightVisibilityElement { get { return lightVisibility; } set { } }

			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf>? marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }

			[JsonIgnore]
			[XmlElement("signalGeneration")]
			public SerializableEnumeration<signalGeneration>? signalGenerationElement { get { return signalGeneration; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightAllAround);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightAllAround.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightAllAround.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightAllAround._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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
		/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAirObstruction : GenericLight {
			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
			[Optional]
			public List<exhibitionConditionOfLight> exhibitionConditionOfLight {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<lightVisibility> lightVisibility {get;set;} = [];

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

			[XmlElement("flareBearing")]
			[Optional]
			public int? flareBearing {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.Any(); }

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("exhibitionConditionOfLight")]
			public SerializableEnumeration<exhibitionConditionOfLight>[] exhibitionConditionOfLightElement { get { return [.. exhibitionConditionOfLight]; } set { } }

			[JsonIgnore]
			[XmlElement("lightVisibility")]
			public SerializableEnumeration<lightVisibility>[] lightVisibilityElement { get { return [.. lightVisibility]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightAirObstruction);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightAirObstruction.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightAirObstruction.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightAirObstruction._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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
		/// A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFogDetector : GenericLight {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6])]
			[Optional]
			public signalGeneration? signalGeneration {get;set;} = default;

			[XmlElement("rhythmOfLight")]
			[Mandatory]
			public rhythmOfLight rhythmOfLight {get;set;} = new rhythmOfLight {
				lightCharacteristic = Enum.GetValues<lightCharacteristic>()[0],
			};


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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightFogDetector.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightFogDetector.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightFogDetector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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
		/// A device capable of, or intended for, reflecting radar signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarReflector : Equipment {
			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadarReflector);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadarReflector.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadarReflector.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadarReflector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<RadarReflector, bool>> _conditionalUnknown = new Dictionary<string,Func<RadarReflector, bool>> {
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
			[PermittedValues([1,2,3,4,5,6,7,8,9,10])]
			[Mandatory]
			public categoryOfFogSignal categoryOfFogSignal {get;set;}

			[XmlElement("signalFrequency")]
			[Optional]
			public int? signalFrequency {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6])]
			[Optional]
			public signalGeneration? signalGeneration {get;set;} = default;

			[XmlElement("signalGroup")]
			[Optional]
			public String? signalGroup {get;set;} = default;

			[XmlElement("signalOutput")]
			[Optional]
			public double? signalOutput {get;set;} = default;

			[XmlElement("signalPeriod")]
			[Optional]
			public double? signalPeriod {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("valueOfMaximumRange")]
			[Optional]
			public double? valueOfMaximumRange {get;set;} = default;

			[XmlElement("signalSequence")]
			[Optional]
			public signalSequence? signalSequence {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializesignalFrequency() { return signalFrequency.HasValue; }

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			public bool ShouldSerializesignalGroup() { return !string.IsNullOrEmpty(signalGroup); }

			public bool ShouldSerializesignalOutput() { return signalOutput.HasValue; }

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializevalueOfMaximumRange() { return valueOfMaximumRange.HasValue; }

			public bool ShouldSerializesignalSequence() { return signalSequence!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfFogSignal")]
			public SerializableEnumeration<categoryOfFogSignal> categoryOfFogSignalElement { get { return categoryOfFogSignal; } set { } }

			[JsonIgnore]
			[XmlElement("signalGeneration")]
			public SerializableEnumeration<signalGeneration>? signalGenerationElement { get { return signalGeneration; } set { } }

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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.FogSignal.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.FogSignal.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..FogSignal._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<FogSignal, bool>> _conditionalUnknown = new Dictionary<string,Func<FogSignal, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A sensor used to observe the environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class EnvironmentObservationEquipment : Equipment {
			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("typeOfEnvironmentalObservationEquipment")]
			[Multiplicity(1)]
			public List<String> typeOfEnvironmentalObservationEquipment {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializetypeOfEnvironmentalObservationEquipment() { return typeOfEnvironmentalObservationEquipment.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(EnvironmentObservationEquipment);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.EnvironmentObservationEquipment.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.EnvironmentObservationEquipment.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..EnvironmentObservationEquipment._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<EnvironmentObservationEquipment, bool>> _conditionalUnknown = new Dictionary<string,Func<EnvironmentObservationEquipment, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,19,20])]
			[Mandatory]
			public categoryOfRadioStation categoryOfRadioStation {get;set;}

			[XmlElement("estimatedRangeOfTransmission")]
			[Optional]
			public double? estimatedRangeOfTransmission {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public status? status {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeestimatedRangeOfTransmission() { return estimatedRangeOfTransmission.HasValue; }

			public bool ShouldSerializestatus() { return status.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfRadioStation")]
			public SerializableEnumeration<categoryOfRadioStation> categoryOfRadioStationElement { get { return categoryOfRadioStation; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RadioStation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadioStation.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadioStation.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadioStation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<RadioStation, bool>> _conditionalUnknown = new Dictionary<string,Func<RadioStation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// (1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Daymark : Equipment {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67])]
			[Optional]
			public categoryOfSpecialPurposeMark? categoryOfSpecialPurposeMark {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("elevation")]
			[Optional]
			public double? elevation {get;set;} = default;

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlElement("orientationValue")]
			[Optional]
			public double? orientationValue {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
			[Mandatory]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlElement("shapeInformation")]
			[Optional]
			public shapeInformation? shapeInformation {get;set;} = default;

			[XmlElement("isSlatted")]
			[Mandatory]
			public Boolean isSlatted {get;set;} = false;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.HasValue; }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeorientationValue() { return orientationValue.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializeshapeInformation() { return shapeInformation!=default; }
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

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Daymark);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Daymark.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Daymark.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..Daymark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<Daymark, bool>> _conditionalUnknown = new Dictionary<string,Func<Daymark, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,9,10,11,12,13,14,15])]
			[Optional]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }
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

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Retroreflector);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Retroreflector.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Retroreflector.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..Retroreflector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<Retroreflector, bool>> _conditionalUnknown = new Dictionary<string,Func<Retroreflector, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3])]
			[Mandatory]
			public categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon {get;set;}

			[XmlElement("radarWaveLength")]
			[Optional]
			public radarWaveLength? radarWaveLength {get;set;} = default;

			[XmlElement("signalGroup")]
			[Optional]
			public String? signalGroup {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("valueOfNominalRange")]
			[Optional]
			public double? valueOfNominalRange {get;set;} = default;

			[XmlElement("manufactorer")]
			[Optional]
			public String? manufactorer {get;set;} = default;

			[XmlElement("sectorLimitOne")]
			[Optional]
			public sectorLimitOne? sectorLimitOne {get;set;} = default;

			[XmlElement("sectorLimitTwo")]
			[Optional]
			public sectorLimitTwo? sectorLimitTwo {get;set;} = default;

			[XmlElement("signalSequence")]
			[Optional]
			public signalSequence? signalSequence {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeradarWaveLength() { return radarWaveLength!=default; }

			public bool ShouldSerializesignalGroup() { return !string.IsNullOrEmpty(signalGroup); }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			public bool ShouldSerializemanufactorer() { return !string.IsNullOrEmpty(manufactorer); }

			public bool ShouldSerializesectorLimitOne() { return sectorLimitOne!=default; }

			public bool ShouldSerializesectorLimitTwo() { return sectorLimitTwo!=default; }

			public bool ShouldSerializesignalSequence() { return signalSequence!=default; }
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.RadarTransponderBeacon.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.RadarTransponderBeacon.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadarTransponderBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<RadarTransponderBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<RadarTransponderBeacon, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.VirtualAISAidToNavigation.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.VirtualAISAidToNavigation.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..VirtualAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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
		/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalAISAidToNavigation : ElectronicAton {
			[XmlIgnore]
			[PermittedValues([1,2,3])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PhysicalAISAidToNavigation.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PhysicalAISAidToNavigation.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..PhysicalAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SyntheticAISAidToNavigation : ElectronicAton {
			[XmlIgnore]
			[PermittedValues([1,2])]
			[Mandatory]
			public CategoryOfSyntheticAISAidtoNavigation CategoryOfSyntheticAISAidtoNavigation {get;set;}

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SyntheticAISAidToNavigation.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SyntheticAISAidToNavigation.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..SyntheticAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PowerSource : Equipment {
			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
			[Mandatory]
			public CategoryOfPowerSource CategoryOfPowerSource {get;set;}

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("CategoryOfPowerSource")]
			public SerializableEnumeration<CategoryOfPowerSource> CategoryOfPowerSourceElement { get { return CategoryOfPowerSource; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PowerSource);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.PowerSource.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.PowerSource.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..PowerSource._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<PowerSource, bool>> _conditionalUnknown = new Dictionary<string,Func<PowerSource, bool>> {
			};

			public override void RunValidationChecks() {
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.IsolatedDangerBeacon.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.IsolatedDangerBeacon.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..IsolatedDangerBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<IsolatedDangerBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<IsolatedDangerBeacon, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CardinalBeacon.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CardinalBeacon.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..CardinalBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<CardinalBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<CardinalBeacon, bool>> {
			};

			public override void RunValidationChecks() {
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.IsolatedDangerBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.IsolatedDangerBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..IsolatedDangerBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<IsolatedDangerBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<IsolatedDangerBuoy, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CardinalBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CardinalBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..CardinalBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<CardinalBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<CardinalBuoy, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). An installation buoy is a buoy used for loading tankers with gas or oil. (IHO Chart Specifications, M-4)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InstallationBuoy : GenericBuoy {
			[XmlIgnore]
			[PermittedValues([1,2])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.InstallationBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.InstallationBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..InstallationBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<InstallationBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<InstallationBuoy, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The equipment or structure used to secure a vessel. (IHO Registry)
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.MooringBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.MooringBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..MooringBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<MooringBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<MooringBuoy, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An emergency wreck marking buoy is a buoy moored on or above a new wreck, designed to provide a prominent (both visual and radio) and easily identifiable temporary (24-72 hours) first response. (IHO Registry)
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.EmergencyWreckMarkingBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.EmergencyWreckMarkingBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..EmergencyWreckMarkingBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<EmergencyWreckMarkingBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<EmergencyWreckMarkingBuoy, bool>> {
			};

			public override void RunValidationChecks() {
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Lighthouse.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Lighthouse.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..Landmark._primitives, ..Lighthouse._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
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
		/// A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFloat : StructureObject {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("horizontalLength")]
			[Optional]
			public double? horizontalLength {get;set;} = default;

			[XmlElement("horizontalWidth")]
			[Optional]
			public double? horizontalWidth {get;set;} = default;

			[XmlElement("mannedStructure")]
			[Optional]
			public Boolean? mannedStructure {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;

			[XmlElement("horizontalAccuracy")]
			[Optional]
			public double? horizontalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			public bool ShouldSerializemannedStructure() { return mannedStructure.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

			public bool ShouldSerializehorizontalAccuracy() { return horizontalAccuracy.HasValue; }
			#endregion

			#region SerializableEnumeration
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
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightFloat);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightFloat.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightFloat.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..LightFloat._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<LightFloat, bool>> _conditionalUnknown = new Dictionary<string,Func<LightFloat, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Multiplicity(1)]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("horizontalLength")]
			[Optional]
			public double? horizontalLength {get;set;} = default;

			[XmlElement("horizontalWidth")]
			[Optional]
			public double? horizontalWidth {get;set;} = default;

			[XmlElement("mannedStructure")]
			[Optional]
			public Boolean? mannedStructure {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;

			[XmlElement("horizontalAccuracy")]
			[Optional]
			public double? horizontalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			public bool ShouldSerializemannedStructure() { return mannedStructure.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

			public bool ShouldSerializehorizontalAccuracy() { return horizontalAccuracy.HasValue; }
			#endregion

			#region SerializableEnumeration
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
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LightVessel);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LightVessel.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LightVessel.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..LightVessel._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<LightVessel, bool>> _conditionalUnknown = new Dictionary<string,Func<LightVessel, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11])]
			[Optional]
			public List<categoryOfOffshorePlatform> categoryOfOffshorePlatform {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlElement("mannedStructure")]
			[Optional]
			public Boolean? mannedStructure {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25])]
			[Optional]
			public List<product> product {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfOffshorePlatform() { return categoryOfOffshorePlatform.Any(); }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializemannedStructure() { return mannedStructure.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeproduct() { return product.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }
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
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("product")]
			public SerializableEnumeration<product>[] productElement { get { return [.. product]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(OffshorePlatform);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.OffshorePlatform.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.OffshorePlatform.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..OffshorePlatform._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
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

			private IReadOnlyDictionary<string, Func<OffshorePlatform, bool>> _conditionalUnknown = new Dictionary<string,Func<OffshorePlatform, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([5,6,7,8,9])]
			[Optional]
			public buildingShape? buildingShape {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4])]
			[Optional]
			public categoryOfSiloTank? categoryOfSiloTank {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("elevation")]
			[Optional]
			public double? elevation {get;set;} = default;

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[XmlElement("radarConspicuous")]
			[Optional]
			public Boolean? radarConspicuous {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializebuildingShape() { return buildingShape.HasValue; }

			public bool ShouldSerializecategoryOfSiloTank() { return categoryOfSiloTank.HasValue; }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }
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
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>[] natureOfConstructionElement { get { return [.. natureOfConstruction]; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

			[JsonIgnore]
			[XmlElement("visualProminence")]
			public SerializableEnumeration<visualProminence>? visualProminenceElement { get { return visualProminence; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SiloTank);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SiloTank.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SiloTank.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..SiloTank._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
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

			private IReadOnlyDictionary<string, Func<SiloTank, bool>> _conditionalUnknown = new Dictionary<string,Func<SiloTank, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,3,4,5,6,7])]
			[Optional]
			public categoryOfPile? categoryOfPile {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlElement("height")]
			[Optional]
			public double? height {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Optional]
			public verticalDatum? verticalDatum {get;set;} = default;

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3])]
			[Optional]
			public visualProminence? visualProminence {get;set;} = default;

			[XmlElement("verticalAccuracy")]
			[Optional]
			public double? verticalAccuracy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfPile() { return categoryOfPile.HasValue; }

			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }
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
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum>? verticalDatumElement { get { return verticalDatum; } set { } }

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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Pile.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Pile.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Pile._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<Pile, bool>> _conditionalUnknown = new Dictionary<string,Func<Pile, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A free-standing self-supporting construction that is roofed, usually walled, and is intended for human occupancy (for example: a place of work or recreation) and/or habitation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Building : StructureObject {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Building);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Building.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Building.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Building._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<Building, bool>> _conditionalUnknown = new Dictionary<string,Func<Building, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// (1) An elevated structure extending across or over the weather deck of a vessel, or part of such a structure. The term is sometimes modified to indicate the intended use, such as navigating bridge or signal bridge.  (2) A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bridge : StructureObject {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Bridge);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Bridge.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Bridge.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Bridge._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
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

			private IReadOnlyDictionary<string, Func<Bridge, bool>> _conditionalUnknown = new Dictionary<string,Func<Bridge, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A heavy weight (of concrete, cast-iron, etc..) that rests on the sea bed and to which a mooring line can be attached. (IALA Dictionary, 8-5-025)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SinkerAnchor : AidsToNavigation {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;

			[XmlElement("sinkerDimensions")]
			[Optional]
			public sinkerDimensions? sinkerDimensions {get;set;} = default;

			[XmlElement("weight")]
			[Mandatory]
			public double weight {get;set;} = default;

			[XmlElement("sinkerType")]
			[Optional]
			public String? sinkerType {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.HasValue; }

			public bool ShouldSerializesinkerDimensions() { return sinkerDimensions!=default; }

			public bool ShouldSerializesinkerType() { return !string.IsNullOrEmpty(sinkerType); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>? natureOfConstructionElement { get { return natureOfConstruction; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SinkerAnchor);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SinkerAnchor.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SinkerAnchor.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..SinkerAnchor._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<SinkerAnchor, bool>> _conditionalUnknown = new Dictionary<string,Func<SinkerAnchor, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A shackle at the lower end of a mooring chain, for attachment to an anchor or sinker. (IALA Dictionary, 8-5-150)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringShackle : AidsToNavigation {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6])]
			[Optional]
			public ShackleType? ShackleType {get;set;} = default;

			[XmlElement("weight")]
			[Optional]
			public double? weight {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.HasValue; }

			public bool ShouldSerializeShackleType() { return ShackleType.HasValue; }

			public bool ShouldSerializeweight() { return weight.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>? natureOfConstructionElement { get { return natureOfConstruction; } set { } }

			[JsonIgnore]
			[XmlElement("ShackleType")]
			public SerializableEnumeration<ShackleType>? ShackleTypeElement { get { return ShackleType; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MooringShackle);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.MooringShackle.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.MooringShackle.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..MooringShackle._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<MooringShackle, bool>> _conditionalUnknown = new Dictionary<string,Func<MooringShackle, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the sea floor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableSubmarine : AidsToNavigation {
			[XmlElement("CableDimensions")]
			[Optional]
			public CableDimensions? CableDimensions {get;set;} = default;

			[XmlIgnore]
			[PermittedValues([1,3,4,5,6,7,8])]
			[Mandatory]
			public categoryOfCable categoryOfCable {get;set;}

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeCableDimensions() { return CableDimensions!=default; }

			public bool ShouldSerializestatus() { return status.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfCable")]
			public SerializableEnumeration<categoryOfCable> categoryOfCableElement { get { return categoryOfCable; } set { } }

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CableSubmarine);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CableSubmarine.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CableSubmarine.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..CableSubmarine._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<CableSubmarine, bool>> _conditionalUnknown = new Dictionary<string,Func<CableSubmarine, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A chain link that provides for rotary motion between the lengths of chain that it connects. (IALA Dictionary, 8-5-165)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Swivel : AidsToNavigation {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;

			[XmlElement("weight")]
			[Optional]
			public double? weight {get;set;} = default;

			[XmlElement("swivelType")]
			[Optional]
			public String? swivelType {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.HasValue; }

			public bool ShouldSerializeweight() { return weight.HasValue; }

			public bool ShouldSerializeswivelType() { return !string.IsNullOrEmpty(swivelType); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>? natureOfConstructionElement { get { return natureOfConstruction; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Swivel);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Swivel.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Swivel.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Swivel._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<Swivel, bool>> _conditionalUnknown = new Dictionary<string,Func<Swivel, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Two lengths of chain connected by a central ring and used for lifting wide loads. (IALA Dictionary,8-3-195)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bridle : AidsToNavigation {
			[XmlElement("bridleLinkType")]
			[Optional]
			public String? bridleLinkType {get;set;} = default;

			[XmlElement("legsDetails")]
			[Optional]
			public String? legsDetails {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializebridleLinkType() { return !string.IsNullOrEmpty(bridleLinkType); }

			public bool ShouldSerializelegsDetails() { return !string.IsNullOrEmpty(legsDetails); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Bridle);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Bridle.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Bridle.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Bridle._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<Bridle, bool>> _conditionalUnknown = new Dictionary<string,Func<Bridle, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CounterWeight : AidsToNavigation {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;

			[XmlElement("weight")]
			[Mandatory]
			public double weight {get;set;} = default;

			[XmlElement("counterWeightType")]
			[Optional]
			public String? counterWeightType {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.HasValue; }

			public bool ShouldSerializecounterWeightType() { return !string.IsNullOrEmpty(counterWeightType); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("natureOfConstruction")]
			public SerializableEnumeration<natureOfConstruction>? natureOfConstructionElement { get { return natureOfConstruction; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(CounterWeight);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.CounterWeight.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.CounterWeight.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..CounterWeight._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<CounterWeight, bool>> _conditionalUnknown = new Dictionary<string,Func<CounterWeight, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification. (IHO Dictionary, S-32, 5th Edition, 5548)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Topmark : AidsToNavigation {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public List<colour> colour {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9])]
			[Optional]
			public List<colourPattern> colourPattern {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			[Optional]
			public List<status> status {get;set;} = [];

			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
			[Mandatory]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}

			[XmlElement("verticalLength")]
			[Optional]
			public double? verticalLength {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecolour() { return colour.Any(); }

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			public bool ShouldSerializestatus() { return status.Any(); }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.Topmark.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.Topmark.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Topmark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SafeWaterBeacon.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SafeWaterBeacon.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..SafeWaterBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<SafeWaterBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<SafeWaterBeacon, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpecialPurposeGeneralBeacon.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SpecialPurposeGeneralBeacon.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..SpecialPurposeGeneralBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<SpecialPurposeGeneralBeacon, bool>> _conditionalUnknown = new Dictionary<string,Func<SpecialPurposeGeneralBeacon, bool>> {
			};

			public override void RunValidationChecks() {
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SafeWaterBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SafeWaterBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..SafeWaterBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<SafeWaterBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<SafeWaterBuoy, bool>> {
			};

			public override void RunValidationChecks() {
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
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpecialPurposeGeneralBuoy.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SpecialPurposeGeneralBuoy.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..SpecialPurposeGeneralBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
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

			private IReadOnlyDictionary<string, Func<SpecialPurposeGeneralBuoy, bool>> _conditionalUnknown = new Dictionary<string,Func<SpecialPurposeGeneralBuoy, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DangerousFeature : FeatureNode {
			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeinformation() { return information.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DangerousFeature);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DangerousFeature.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DangerousFeature.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DangerousFeature._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
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
		/// Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAggregation : FeatureNode {
			[XmlElement("CategoryOfAggregation")]
			[PermittedValues([1,3,2])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtonAggregation.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.AtonAggregation.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AtonAggregation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
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
		/// Used to identify an association between two or more objects. The association may be named content of categoryOfAssociation should be put in information attribute when converting to S-57
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAssociation : FeatureNode {
			[XmlElement("CategoryOfAssociation")]
			[PermittedValues([1,2])]
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.AtonAssociation.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.AtonAssociation.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AtonAssociation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
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
		/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfNonBathymetricData : FeatureNode {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6])]
			[Mandatory]
			public categoryOfTemporalVariation categoryOfTemporalVariation {get;set;}

			[XmlElement("orientationUncertainty")]
			[Optional]
			public double? orientationUncertainty {get;set;} = default;

			[XmlElement("horizontalDistanceUncertainty")]
			[Optional]
			public double? horizontalDistanceUncertainty {get;set;} = default;

			[XmlElement("horizontalPositionUncertainty")]
			[Mandatory]
			public horizontalPositionUncertainty horizontalPositionUncertainty {get;set;} = new horizontalPositionUncertainty {
				uncertaintyFixed = default,
			};

			[XmlElement("information")]
			[Optional]
			public information? information {get;set;} = default;

			[XmlElement("informationInNationalLanguage")]
			[Optional]
			public String? informationInNationalLanguage {get;set;} = default;

			[XmlElement("textualDescription")]
			[Optional]
			public textualDescription? textualDescription {get;set;} = default;

			[XmlElement("verticalUncertainty")]
			[Optional]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			public bool ShouldSerializeinformation() { return information!=default; }

			public bool ShouldSerializeinformationInNationalLanguage() { return !string.IsNullOrEmpty(informationInNationalLanguage); }

			public bool ShouldSerializetextualDescription() { return textualDescription!=default; }

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfTemporalVariation")]
			public SerializableEnumeration<categoryOfTemporalVariation> categoryOfTemporalVariationElement { get { return categoryOfTemporalVariation; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(QualityOfNonBathymetricData);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.QualityOfNonBathymetricData.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.QualityOfNonBathymetricData.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => QualityOfNonBathymetricData._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
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

			private IReadOnlyDictionary<string, Func<QualityOfNonBathymetricData, bool>> _conditionalUnknown = new Dictionary<string,Func<QualityOfNonBathymetricData, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A geographical area that describes the coverage and extent of spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DataCoverage : FeatureNode {
			[XmlElement("maximumDisplayScale")]
			[Mandatory]
			public int maximumDisplayScale {get;set;} = default;

			[XmlElement("minimumDisplayScale")]
			[Mandatory]
			public int minimumDisplayScale {get;set;} = default;


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DataCoverage);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DataCoverage.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DataCoverage.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DataCoverage._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
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

			private IReadOnlyDictionary<string, Func<DataCoverage, bool>> _conditionalUnknown = new Dictionary<string,Func<DataCoverage, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An area within which the navigational system of marks has been established in relation to a specific direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocalDirectionOfBuoyage : FeatureNode {
			[XmlElement("orientation")]
			[Mandatory]
			public orientation orientation {get;set;} = new orientation {
				orientationValue = default,
			};


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LocalDirectionOfBuoyage);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.LocalDirectionOfBuoyage.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.LocalDirectionOfBuoyage.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LocalDirectionOfBuoyage._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
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

			private IReadOnlyDictionary<string, Func<LocalDirectionOfBuoyage, bool>> _conditionalUnknown = new Dictionary<string,Func<LocalDirectionOfBuoyage, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An area within which the navigational system of marks has been established in relation to a specific direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationalSystemOfMarks : FeatureNode {
			[XmlIgnore]
			[PermittedValues([1,2,9,10,11,12,13,15])]
			[Mandatory]
			public marksNavigationalSystemOf marksNavigationalSystemOf {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("marksNavigationalSystemOf")]
			public SerializableEnumeration<marksNavigationalSystemOf> marksNavigationalSystemOfElement { get { return marksNavigationalSystemOf; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NavigationalSystemOfMarks);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.NavigationalSystemOfMarks.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.NavigationalSystemOfMarks.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => NavigationalSystemOfMarks._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
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

			private IReadOnlyDictionary<string, Func<NavigationalSystemOfMarks, bool>> _conditionalUnknown = new Dictionary<string,Func<NavigationalSystemOfMarks, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SoundingDatum : FeatureNode {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Mandatory]
			public verticalDatum verticalDatum {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum> verticalDatumElement { get { return verticalDatum; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SoundingDatum);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SoundingDatum.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SoundingDatum.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SoundingDatum._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
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

			private IReadOnlyDictionary<string, Func<SoundingDatum, bool>> _conditionalUnknown = new Dictionary<string,Func<SoundingDatum, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Any level surface (for example Mean Sea Level) taken as a surface of reference to which the elevations within a data set are reduced. Also called datum level, reference level, reference plane, levelling datum, datum for heights.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VerticalDatumOfData : FeatureNode {
			[XmlIgnore]
			[PermittedValues([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Mandatory]
			public verticalDatum verticalDatum {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("verticalDatum")]
			public SerializableEnumeration<verticalDatum> verticalDatumElement { get { return verticalDatum; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(VerticalDatumOfData);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.VerticalDatumOfData.informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.VerticalDatumOfData.featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => VerticalDatumOfData._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
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

			private IReadOnlyDictionary<string, Func<VerticalDatumOfData, bool>> _conditionalUnknown = new Dictionary<string,Func<VerticalDatumOfData, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}
	}

	#region InformationBindings
	public static class InformationBindings
	{
		public static class AtoNFixingMethod {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class AtonStatusInformation {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class PositioningInformation {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class SpatialQuality {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class AidsToNavigation {
			public static informationBindingDefinition[] informationBindingDefinitions => [
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
		}
		public static class StructureObject {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions,
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonPositioningInformationAssociation),
					role = Enum.GetName<Role>(Role.positioningMethod)!,
					informationTypes = [nameof(PositioningInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonFixingMethodAssociation),
					role = Enum.GetName<Role>(Role.fixingMethod)!,
					informationTypes = [nameof(AtoNFixingMethod)],
					primitives = [],
				},
			];
		}
		public static class Equipment {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class ElectronicAton {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class GenericBeacon {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class GenericBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class GenericLight {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class Landmark {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class LateralBeacon {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBeacon.informationBindingDefinitions
			];
		}
		public static class LateralBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBuoy.informationBindingDefinitions
			];
		}
		public static class NavigationLine {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class RecommendedTrack {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class LightSectored {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericLight.informationBindingDefinitions
			];
		}
		public static class LightAllAround {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericLight.informationBindingDefinitions
			];
		}
		public static class LightAirObstruction {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericLight.informationBindingDefinitions
			];
		}
		public static class LightFogDetector {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericLight.informationBindingDefinitions
			];
		}
		public static class RadarReflector {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class FogSignal {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class EnvironmentObservationEquipment {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class RadioStation {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class Daymark {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class Retroreflector {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class RadarTransponderBeacon {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class VirtualAISAidToNavigation {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. ElectronicAton.informationBindingDefinitions
			];
		}
		public static class PhysicalAISAidToNavigation {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. ElectronicAton.informationBindingDefinitions
			];
		}
		public static class SyntheticAISAidToNavigation {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. ElectronicAton.informationBindingDefinitions
			];
		}
		public static class PowerSource {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Equipment.informationBindingDefinitions
			];
		}
		public static class IsolatedDangerBeacon {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBeacon.informationBindingDefinitions
			];
		}
		public static class CardinalBeacon {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBeacon.informationBindingDefinitions
			];
		}
		public static class IsolatedDangerBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBuoy.informationBindingDefinitions
			];
		}
		public static class CardinalBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBuoy.informationBindingDefinitions
			];
		}
		public static class InstallationBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBuoy.informationBindingDefinitions
			];
		}
		public static class MooringBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBuoy.informationBindingDefinitions
			];
		}
		public static class EmergencyWreckMarkingBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBuoy.informationBindingDefinitions
			];
		}
		public static class Lighthouse {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. Landmark.informationBindingDefinitions
			];
		}
		public static class LightFloat {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class LightVessel {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class OffshorePlatform {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class SiloTank {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class Pile {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class Building {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class Bridge {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. StructureObject.informationBindingDefinitions
			];
		}
		public static class SinkerAnchor {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class MooringShackle {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class CableSubmarine {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class Swivel {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class Bridle {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class CounterWeight {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class Topmark {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. AidsToNavigation.informationBindingDefinitions
			];
		}
		public static class SafeWaterBeacon {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBeacon.informationBindingDefinitions
			];
		}
		public static class SpecialPurposeGeneralBeacon {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBeacon.informationBindingDefinitions
			];
		}
		public static class SafeWaterBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBuoy.informationBindingDefinitions
			];
		}
		public static class SpecialPurposeGeneralBuoy {
			public static informationBindingDefinition[] informationBindingDefinitions => [.. GenericBuoy.informationBindingDefinitions
			];
		}
		public static class DangerousFeature {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class AtonAggregation {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class AtonAssociation {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class QualityOfNonBathymetricData {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class DataCoverage {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class LocalDirectionOfBuoyage {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class NavigationalSystemOfMarks {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class SoundingDatum {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static class VerticalDatumOfData {
			public static informationBindingDefinition[] informationBindingDefinitions => [
			];
		}
		public static informationBindingDefinition[] informationBindingDefinitions(string informationType) => informationType switch {
			"AtoNFixingMethod" => AtoNFixingMethod.informationBindingDefinitions,
			"AtonStatusInformation" => AtonStatusInformation.informationBindingDefinitions,
			"PositioningInformation" => PositioningInformation.informationBindingDefinitions,
			"SpatialQuality" => SpatialQuality.informationBindingDefinitions,
			"AidsToNavigation" => AidsToNavigation.informationBindingDefinitions,
			"StructureObject" => StructureObject.informationBindingDefinitions,
			"Equipment" => Equipment.informationBindingDefinitions,
			"ElectronicAton" => ElectronicAton.informationBindingDefinitions,
			"GenericBeacon" => GenericBeacon.informationBindingDefinitions,
			"GenericBuoy" => GenericBuoy.informationBindingDefinitions,
			"GenericLight" => GenericLight.informationBindingDefinitions,
			"Landmark" => Landmark.informationBindingDefinitions,
			"LateralBeacon" => LateralBeacon.informationBindingDefinitions,
			"LateralBuoy" => LateralBuoy.informationBindingDefinitions,
			"NavigationLine" => NavigationLine.informationBindingDefinitions,
			"RecommendedTrack" => RecommendedTrack.informationBindingDefinitions,
			"LightSectored" => LightSectored.informationBindingDefinitions,
			"LightAllAround" => LightAllAround.informationBindingDefinitions,
			"LightAirObstruction" => LightAirObstruction.informationBindingDefinitions,
			"LightFogDetector" => LightFogDetector.informationBindingDefinitions,
			"RadarReflector" => RadarReflector.informationBindingDefinitions,
			"FogSignal" => FogSignal.informationBindingDefinitions,
			"EnvironmentObservationEquipment" => EnvironmentObservationEquipment.informationBindingDefinitions,
			"RadioStation" => RadioStation.informationBindingDefinitions,
			"Daymark" => Daymark.informationBindingDefinitions,
			"Retroreflector" => Retroreflector.informationBindingDefinitions,
			"RadarTransponderBeacon" => RadarTransponderBeacon.informationBindingDefinitions,
			"VirtualAISAidToNavigation" => VirtualAISAidToNavigation.informationBindingDefinitions,
			"PhysicalAISAidToNavigation" => PhysicalAISAidToNavigation.informationBindingDefinitions,
			"SyntheticAISAidToNavigation" => SyntheticAISAidToNavigation.informationBindingDefinitions,
			"PowerSource" => PowerSource.informationBindingDefinitions,
			"IsolatedDangerBeacon" => IsolatedDangerBeacon.informationBindingDefinitions,
			"CardinalBeacon" => CardinalBeacon.informationBindingDefinitions,
			"IsolatedDangerBuoy" => IsolatedDangerBuoy.informationBindingDefinitions,
			"CardinalBuoy" => CardinalBuoy.informationBindingDefinitions,
			"InstallationBuoy" => InstallationBuoy.informationBindingDefinitions,
			"MooringBuoy" => MooringBuoy.informationBindingDefinitions,
			"EmergencyWreckMarkingBuoy" => EmergencyWreckMarkingBuoy.informationBindingDefinitions,
			"Lighthouse" => Lighthouse.informationBindingDefinitions,
			"LightFloat" => LightFloat.informationBindingDefinitions,
			"LightVessel" => LightVessel.informationBindingDefinitions,
			"OffshorePlatform" => OffshorePlatform.informationBindingDefinitions,
			"SiloTank" => SiloTank.informationBindingDefinitions,
			"Pile" => Pile.informationBindingDefinitions,
			"Building" => Building.informationBindingDefinitions,
			"Bridge" => Bridge.informationBindingDefinitions,
			"SinkerAnchor" => SinkerAnchor.informationBindingDefinitions,
			"MooringShackle" => MooringShackle.informationBindingDefinitions,
			"CableSubmarine" => CableSubmarine.informationBindingDefinitions,
			"Swivel" => Swivel.informationBindingDefinitions,
			"Bridle" => Bridle.informationBindingDefinitions,
			"CounterWeight" => CounterWeight.informationBindingDefinitions,
			"Topmark" => Topmark.informationBindingDefinitions,
			"SafeWaterBeacon" => SafeWaterBeacon.informationBindingDefinitions,
			"SpecialPurposeGeneralBeacon" => SpecialPurposeGeneralBeacon.informationBindingDefinitions,
			"SafeWaterBuoy" => SafeWaterBuoy.informationBindingDefinitions,
			"SpecialPurposeGeneralBuoy" => SpecialPurposeGeneralBuoy.informationBindingDefinitions,
			"DangerousFeature" => DangerousFeature.informationBindingDefinitions,
			"AtonAggregation" => AtonAggregation.informationBindingDefinitions,
			"AtonAssociation" => AtonAssociation.informationBindingDefinitions,
			"QualityOfNonBathymetricData" => QualityOfNonBathymetricData.informationBindingDefinitions,
			"DataCoverage" => DataCoverage.informationBindingDefinitions,
			"LocalDirectionOfBuoyage" => LocalDirectionOfBuoyage.informationBindingDefinitions,
			"NavigationalSystemOfMarks" => NavigationalSystemOfMarks.informationBindingDefinitions,
			"SoundingDatum" => SoundingDatum.informationBindingDefinitions,
			"VerticalDatumOfData" => VerticalDatumOfData.informationBindingDefinitions,
			_ => throw new KeyNotFoundException(),
		};
	}

	#endregion

	#region FeatureBindings
	public static class FeatureBindings
	{
		public static class AidsToNavigation {
			public static featureBindingDefinition[] featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.AtonAggregations),
					role = Enum.GetName<Role>(Role.peerAtonAggregation)!,
					featureTypes = [nameof(FeatureTypes.AtonAggregation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.AtonAssociations),
					role = Enum.GetName<Role>(Role.peerAtonAssociation)!,
					featureTypes = [nameof(FeatureTypes.AtonAssociation)],
				},
			];
		}
		public static class StructureObject {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.StructureEquipment),
					role = Enum.GetName<Role>(Role.child)!,
					featureTypes = [nameof(FeatureTypes.Equipment)],
				},
			];
		}
		public static class Equipment {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.StructureEquipment),
					role = Enum.GetName<Role>(Role.parent)!,
					featureTypes = [nameof(FeatureTypes.StructureObject)],
				},
			];
		}
		public static class ElectronicAton {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions
			];
		}
		public static class GenericBeacon {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class GenericBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.BuoyTopmark),
					role = Enum.GetName<Role>(Role.topmarkPart)!,
					featureTypes = [nameof(FeatureTypes.Topmark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.ShackleConnection),
					role = Enum.GetName<Role>(Role.shackleToBuoyconnected)!,
					featureTypes = [nameof(FeatureTypes.MooringShackle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.BridleConnection),
					role = Enum.GetName<Role>(Role.buoyhangs)!,
					featureTypes = [nameof(FeatureTypes.Bridle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.BuoyCounterWeight),
					role = Enum.GetName<Role>(Role.buoyattached)!,
					featureTypes = [nameof(FeatureTypes.CounterWeight)],
				},
			];
		}
		public static class GenericLight {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions
			];
		}
		public static class Landmark {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class LateralBeacon {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBeacon.featureBindingDefinitions
			];
		}
		public static class LateralBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBuoy.featureBindingDefinitions
			];
		}
		public static class NavigationLine {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.RangeSystem),
					role = Enum.GetName<Role>(Role.navigableTrack)!,
					featureTypes = [nameof(FeatureTypes.RecommendedTrack)],
				},
			];
		}
		public static class RecommendedTrack {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(FeatureAssociations.RangeSystem),
					role = Enum.GetName<Role>(Role.navigationLine)!,
					featureTypes = [nameof(FeatureTypes.NavigationLine)],
				},
			];
		}
		public static class LightSectored {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericLight.featureBindingDefinitions
			];
		}
		public static class LightAllAround {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericLight.featureBindingDefinitions
			];
		}
		public static class LightAirObstruction {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericLight.featureBindingDefinitions
			];
		}
		public static class LightFogDetector {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericLight.featureBindingDefinitions
			];
		}
		public static class RadarReflector {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions
			];
		}
		public static class FogSignal {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions
			];
		}
		public static class EnvironmentObservationEquipment {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions
			];
		}
		public static class RadioStation {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.PhysicalAIS),
					role = Enum.GetName<Role>(Role.physicalAISbroadcastBy)!,
					featureTypes = [nameof(FeatureTypes.PhysicalAISAidToNavigation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.SyntheticAIS),
					role = Enum.GetName<Role>(Role.syntheticAISbroadcastBy)!,
					featureTypes = [nameof(FeatureTypes.SyntheticAISAidToNavigation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.VirtualAIS),
					role = Enum.GetName<Role>(Role.virtualAISbroadcastBy)!,
					featureTypes = [nameof(FeatureTypes.VirtualAISAidToNavigation)],
				},
			];
		}
		public static class Daymark {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions
			];
		}
		public static class Retroreflector {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions
			];
		}
		public static class RadarTransponderBeacon {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions
			];
		}
		public static class VirtualAISAidToNavigation {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. ElectronicAton.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.VirtualAIS),
					role = Enum.GetName<Role>(Role.virtualAISbroadcasts)!,
					featureTypes = [nameof(FeatureTypes.RadioStation)],
				},
			];
		}
		public static class PhysicalAISAidToNavigation {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. ElectronicAton.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.PhysicalAIS),
					role = Enum.GetName<Role>(Role.physicalAISbroadcasts)!,
					featureTypes = [nameof(FeatureTypes.RadioStation)],
				},
			];
		}
		public static class SyntheticAISAidToNavigation {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. ElectronicAton.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.SyntheticAIS),
					role = Enum.GetName<Role>(Role.syntheticAISbroadcasts)!,
					featureTypes = [nameof(FeatureTypes.RadioStation)],
				},
			];
		}
		public static class PowerSource {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Equipment.featureBindingDefinitions
			];
		}
		public static class IsolatedDangerBeacon {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBeacon.featureBindingDefinitions
			];
		}
		public static class CardinalBeacon {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBeacon.featureBindingDefinitions
			];
		}
		public static class IsolatedDangerBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBuoy.featureBindingDefinitions
			];
		}
		public static class CardinalBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBuoy.featureBindingDefinitions
			];
		}
		public static class InstallationBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBuoy.featureBindingDefinitions
			];
		}
		public static class MooringBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBuoy.featureBindingDefinitions
			];
		}
		public static class EmergencyWreckMarkingBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBuoy.featureBindingDefinitions
			];
		}
		public static class Lighthouse {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. Landmark.featureBindingDefinitions
			];
		}
		public static class LightFloat {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class LightVessel {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class OffshorePlatform {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class SiloTank {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class Pile {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class Building {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class Bridge {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. StructureObject.featureBindingDefinitions
			];
		}
		public static class SinkerAnchor {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.ShackleToAnchorConnection),
					role = Enum.GetName<Role>(Role.shackleToAnchorconnected)!,
					featureTypes = [nameof(FeatureTypes.MooringShackle)],
				},
			];
		}
		public static class MooringShackle {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.ShackleConnection),
					role = Enum.GetName<Role>(Role.shackleToBuoyconnectedTo)!,
					featureTypes = [nameof(FeatureTypes.GenericBuoy)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.ShackleToBridleConnection),
					role = Enum.GetName<Role>(Role.shackleToBridleconnectedTo)!,
					featureTypes = [nameof(FeatureTypes.Bridle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.BridleCableConnection),
					role = Enum.GetName<Role>(Role.bridleattached)!,
					featureTypes = [nameof(FeatureTypes.CableSubmarine)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.ShackleToSwivelConnection),
					role = Enum.GetName<Role>(Role.shackleToSwivelconnectedTo)!,
					featureTypes = [nameof(FeatureTypes.Swivel)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.ShackleToAnchorConnection),
					role = Enum.GetName<Role>(Role.shackleToAnchorconnectedTo)!,
					featureTypes = [nameof(FeatureTypes.SinkerAnchor)],
				},
			];
		}
		public static class CableSubmarine {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.BridleCableConnection),
					role = Enum.GetName<Role>(Role.cableholds)!,
					featureTypes = [nameof(FeatureTypes.Bridle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.SwivelCableConnection),
					role = Enum.GetName<Role>(Role.cableholds)!,
					featureTypes = [nameof(FeatureTypes.Swivel)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.ShackleConnectionFromCable),
					role = Enum.GetName<Role>(Role.shackleToCableconnected)!,
					featureTypes = [nameof(FeatureTypes.MooringShackle)],
				},
			];
		}
		public static class Swivel {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.SwivelConnection),
					role = Enum.GetName<Role>(Role.swivelholds)!,
					featureTypes = [nameof(FeatureTypes.Bridle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.SwivelCableConnection),
					role = Enum.GetName<Role>(Role.swivelattached)!,
					featureTypes = [nameof(FeatureTypes.CableSubmarine)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.ShackleToSwivelConnection),
					role = Enum.GetName<Role>(Role.shackleToSwivelconnected)!,
					featureTypes = [nameof(FeatureTypes.MooringShackle)],
				},
			];
		}
		public static class Bridle {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.BridleConnection),
					role = Enum.GetName<Role>(Role.bridleholds)!,
					featureTypes = [nameof(FeatureTypes.GenericBuoy)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.SwivelConnection),
					role = Enum.GetName<Role>(Role.bridlehangs)!,
					featureTypes = [nameof(FeatureTypes.Swivel)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.ShackleToBridleConnection),
					role = Enum.GetName<Role>(Role.shackleToBridleconnected)!,
					featureTypes = [nameof(FeatureTypes.MooringShackle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.BridleCableConnection),
					role = Enum.GetName<Role>(Role.bridleattached)!,
					featureTypes = [nameof(FeatureTypes.CableSubmarine)],
				},
			];
		}
		public static class CounterWeight {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.BuoyCounterWeight),
					role = Enum.GetName<Role>(Role.counterWeightholds)!,
					featureTypes = [nameof(FeatureTypes.GenericBuoy)],
				},
			];
		}
		public static class Topmark {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. AidsToNavigation.featureBindingDefinitions,
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.BuoyTopmark),
					role = Enum.GetName<Role>(Role.buoyPart)!,
					featureTypes = [nameof(FeatureTypes.GenericBuoy)],
				},
			];
		}
		public static class SafeWaterBeacon {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBeacon.featureBindingDefinitions
			];
		}
		public static class SpecialPurposeGeneralBeacon {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBeacon.featureBindingDefinitions
			];
		}
		public static class SafeWaterBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBuoy.featureBindingDefinitions
			];
		}
		public static class SpecialPurposeGeneralBuoy {
			public static featureBindingDefinition[] featureBindingDefinitions => [.. GenericBuoy.featureBindingDefinitions
			];
		}
		public static class DangerousFeature {
			public static featureBindingDefinition[] featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(FeatureAssociations.DangerousFeatureAssociation),
					role = Enum.GetName<Role>(Role.markingAton)!,
					featureTypes = [nameof(FeatureTypes.AtonAssociation)],
				},
			];
		}
		public static class AtonAggregation {
			public static featureBindingDefinition[] featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.AtonAggregations),
					role = Enum.GetName<Role>(Role.atonAggregationBy)!,
					featureTypes = [nameof(FeatureTypes.AidsToNavigation)],
				},
			];
		}
		public static class AtonAssociation {
			public static featureBindingDefinition[] featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.DangerousFeatureAssociation),
					role = Enum.GetName<Role>(Role.danger)!,
					featureTypes = [nameof(FeatureTypes.DangerousFeature)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.AtonAssociations),
					role = Enum.GetName<Role>(Role.atonAssociationBy)!,
					featureTypes = [nameof(FeatureTypes.AidsToNavigation)],
				},
			];
		}
		public static class QualityOfNonBathymetricData {
			public static featureBindingDefinition[] featureBindingDefinitions => [
			];
		}
		public static class DataCoverage {
			public static featureBindingDefinition[] featureBindingDefinitions => [
			];
		}
		public static class LocalDirectionOfBuoyage {
			public static featureBindingDefinition[] featureBindingDefinitions => [
			];
		}
		public static class NavigationalSystemOfMarks {
			public static featureBindingDefinition[] featureBindingDefinitions => [
			];
		}
		public static class SoundingDatum {
			public static featureBindingDefinition[] featureBindingDefinitions => [
			];
		}
		public static class VerticalDatumOfData {
			public static featureBindingDefinition[] featureBindingDefinitions => [
			];
		}
		public static featureBindingDefinition[] featureBindingDefinitions(string featureType) => featureType switch {
			"AidsToNavigation" => AidsToNavigation.featureBindingDefinitions,
			"StructureObject" => StructureObject.featureBindingDefinitions,
			"Equipment" => Equipment.featureBindingDefinitions,
			"ElectronicAton" => ElectronicAton.featureBindingDefinitions,
			"GenericBeacon" => GenericBeacon.featureBindingDefinitions,
			"GenericBuoy" => GenericBuoy.featureBindingDefinitions,
			"GenericLight" => GenericLight.featureBindingDefinitions,
			"Landmark" => Landmark.featureBindingDefinitions,
			"LateralBeacon" => LateralBeacon.featureBindingDefinitions,
			"LateralBuoy" => LateralBuoy.featureBindingDefinitions,
			"NavigationLine" => NavigationLine.featureBindingDefinitions,
			"RecommendedTrack" => RecommendedTrack.featureBindingDefinitions,
			"LightSectored" => LightSectored.featureBindingDefinitions,
			"LightAllAround" => LightAllAround.featureBindingDefinitions,
			"LightAirObstruction" => LightAirObstruction.featureBindingDefinitions,
			"LightFogDetector" => LightFogDetector.featureBindingDefinitions,
			"RadarReflector" => RadarReflector.featureBindingDefinitions,
			"FogSignal" => FogSignal.featureBindingDefinitions,
			"EnvironmentObservationEquipment" => EnvironmentObservationEquipment.featureBindingDefinitions,
			"RadioStation" => RadioStation.featureBindingDefinitions,
			"Daymark" => Daymark.featureBindingDefinitions,
			"Retroreflector" => Retroreflector.featureBindingDefinitions,
			"RadarTransponderBeacon" => RadarTransponderBeacon.featureBindingDefinitions,
			"VirtualAISAidToNavigation" => VirtualAISAidToNavigation.featureBindingDefinitions,
			"PhysicalAISAidToNavigation" => PhysicalAISAidToNavigation.featureBindingDefinitions,
			"SyntheticAISAidToNavigation" => SyntheticAISAidToNavigation.featureBindingDefinitions,
			"PowerSource" => PowerSource.featureBindingDefinitions,
			"IsolatedDangerBeacon" => IsolatedDangerBeacon.featureBindingDefinitions,
			"CardinalBeacon" => CardinalBeacon.featureBindingDefinitions,
			"IsolatedDangerBuoy" => IsolatedDangerBuoy.featureBindingDefinitions,
			"CardinalBuoy" => CardinalBuoy.featureBindingDefinitions,
			"InstallationBuoy" => InstallationBuoy.featureBindingDefinitions,
			"MooringBuoy" => MooringBuoy.featureBindingDefinitions,
			"EmergencyWreckMarkingBuoy" => EmergencyWreckMarkingBuoy.featureBindingDefinitions,
			"Lighthouse" => Lighthouse.featureBindingDefinitions,
			"LightFloat" => LightFloat.featureBindingDefinitions,
			"LightVessel" => LightVessel.featureBindingDefinitions,
			"OffshorePlatform" => OffshorePlatform.featureBindingDefinitions,
			"SiloTank" => SiloTank.featureBindingDefinitions,
			"Pile" => Pile.featureBindingDefinitions,
			"Building" => Building.featureBindingDefinitions,
			"Bridge" => Bridge.featureBindingDefinitions,
			"SinkerAnchor" => SinkerAnchor.featureBindingDefinitions,
			"MooringShackle" => MooringShackle.featureBindingDefinitions,
			"CableSubmarine" => CableSubmarine.featureBindingDefinitions,
			"Swivel" => Swivel.featureBindingDefinitions,
			"Bridle" => Bridle.featureBindingDefinitions,
			"CounterWeight" => CounterWeight.featureBindingDefinitions,
			"Topmark" => Topmark.featureBindingDefinitions,
			"SafeWaterBeacon" => SafeWaterBeacon.featureBindingDefinitions,
			"SpecialPurposeGeneralBeacon" => SpecialPurposeGeneralBeacon.featureBindingDefinitions,
			"SafeWaterBuoy" => SafeWaterBuoy.featureBindingDefinitions,
			"SpecialPurposeGeneralBuoy" => SpecialPurposeGeneralBuoy.featureBindingDefinitions,
			"DangerousFeature" => DangerousFeature.featureBindingDefinitions,
			"AtonAggregation" => AtonAggregation.featureBindingDefinitions,
			"AtonAssociation" => AtonAssociation.featureBindingDefinitions,
			"QualityOfNonBathymetricData" => QualityOfNonBathymetricData.featureBindingDefinitions,
			"DataCoverage" => DataCoverage.featureBindingDefinitions,
			"LocalDirectionOfBuoyage" => LocalDirectionOfBuoyage.featureBindingDefinitions,
			"NavigationalSystemOfMarks" => NavigationalSystemOfMarks.featureBindingDefinitions,
			"SoundingDatum" => SoundingDatum.featureBindingDefinitions,
			"VerticalDatumOfData" => VerticalDatumOfData.featureBindingDefinitions,
			_ => throw new KeyNotFoundException(),
		};
	}

	#endregion

	[XmlType(Namespace = "http://www.iho.int/S201/2.0")]
	[XmlRoot(Namespace = "http://www.iho.int/S201/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S201/2.0 201_2.0.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S201/2.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.AtoNFixingMethod", typeof(InformationTypes.AtoNFixingMethod), Order = 1, ElementName = "AtoNFixingMethod")]
		[XmlElement("InformationTypes.AtonStatusInformation", typeof(InformationTypes.AtonStatusInformation), Order = 1, ElementName = "AtonStatusInformation")]
		[XmlElement("InformationTypes.PositioningInformation", typeof(InformationTypes.PositioningInformation), Order = 1, ElementName = "PositioningInformation")]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1, ElementName = "SpatialQuality")]
		[XmlElement("FeatureTypes.Landmark", typeof(FeatureTypes.Landmark), Order = 1, ElementName = "Landmark")]
		[XmlElement("FeatureTypes.LateralBeacon", typeof(FeatureTypes.LateralBeacon), Order = 1, ElementName = "LateralBeacon")]
		[XmlElement("FeatureTypes.LateralBuoy", typeof(FeatureTypes.LateralBuoy), Order = 1, ElementName = "LateralBuoy")]
		[XmlElement("FeatureTypes.NavigationLine", typeof(FeatureTypes.NavigationLine), Order = 1, ElementName = "NavigationLine")]
		[XmlElement("FeatureTypes.RecommendedTrack", typeof(FeatureTypes.RecommendedTrack), Order = 1, ElementName = "RecommendedTrack")]
		[XmlElement("FeatureTypes.LightSectored", typeof(FeatureTypes.LightSectored), Order = 1, ElementName = "LightSectored")]
		[XmlElement("FeatureTypes.LightAllAround", typeof(FeatureTypes.LightAllAround), Order = 1, ElementName = "LightAllAround")]
		[XmlElement("FeatureTypes.LightAirObstruction", typeof(FeatureTypes.LightAirObstruction), Order = 1, ElementName = "LightAirObstruction")]
		[XmlElement("FeatureTypes.LightFogDetector", typeof(FeatureTypes.LightFogDetector), Order = 1, ElementName = "LightFogDetector")]
		[XmlElement("FeatureTypes.RadarReflector", typeof(FeatureTypes.RadarReflector), Order = 1, ElementName = "RadarReflector")]
		[XmlElement("FeatureTypes.FogSignal", typeof(FeatureTypes.FogSignal), Order = 1, ElementName = "FogSignal")]
		[XmlElement("FeatureTypes.EnvironmentObservationEquipment", typeof(FeatureTypes.EnvironmentObservationEquipment), Order = 1, ElementName = "EnvironmentObservationEquipment")]
		[XmlElement("FeatureTypes.RadioStation", typeof(FeatureTypes.RadioStation), Order = 1, ElementName = "RadioStation")]
		[XmlElement("FeatureTypes.Daymark", typeof(FeatureTypes.Daymark), Order = 1, ElementName = "Daymark")]
		[XmlElement("FeatureTypes.Retroreflector", typeof(FeatureTypes.Retroreflector), Order = 1, ElementName = "Retroreflector")]
		[XmlElement("FeatureTypes.RadarTransponderBeacon", typeof(FeatureTypes.RadarTransponderBeacon), Order = 1, ElementName = "RadarTransponderBeacon")]
		[XmlElement("FeatureTypes.VirtualAISAidToNavigation", typeof(FeatureTypes.VirtualAISAidToNavigation), Order = 1, ElementName = "VirtualAISAidToNavigation")]
		[XmlElement("FeatureTypes.PhysicalAISAidToNavigation", typeof(FeatureTypes.PhysicalAISAidToNavigation), Order = 1, ElementName = "PhysicalAISAidToNavigation")]
		[XmlElement("FeatureTypes.SyntheticAISAidToNavigation", typeof(FeatureTypes.SyntheticAISAidToNavigation), Order = 1, ElementName = "SyntheticAISAidToNavigation")]
		[XmlElement("FeatureTypes.PowerSource", typeof(FeatureTypes.PowerSource), Order = 1, ElementName = "PowerSource")]
		[XmlElement("FeatureTypes.IsolatedDangerBeacon", typeof(FeatureTypes.IsolatedDangerBeacon), Order = 1, ElementName = "IsolatedDangerBeacon")]
		[XmlElement("FeatureTypes.CardinalBeacon", typeof(FeatureTypes.CardinalBeacon), Order = 1, ElementName = "CardinalBeacon")]
		[XmlElement("FeatureTypes.IsolatedDangerBuoy", typeof(FeatureTypes.IsolatedDangerBuoy), Order = 1, ElementName = "IsolatedDangerBuoy")]
		[XmlElement("FeatureTypes.CardinalBuoy", typeof(FeatureTypes.CardinalBuoy), Order = 1, ElementName = "CardinalBuoy")]
		[XmlElement("FeatureTypes.InstallationBuoy", typeof(FeatureTypes.InstallationBuoy), Order = 1, ElementName = "InstallationBuoy")]
		[XmlElement("FeatureTypes.MooringBuoy", typeof(FeatureTypes.MooringBuoy), Order = 1, ElementName = "MooringBuoy")]
		[XmlElement("FeatureTypes.EmergencyWreckMarkingBuoy", typeof(FeatureTypes.EmergencyWreckMarkingBuoy), Order = 1, ElementName = "EmergencyWreckMarkingBuoy")]
		[XmlElement("FeatureTypes.Lighthouse", typeof(FeatureTypes.Lighthouse), Order = 1, ElementName = "Lighthouse")]
		[XmlElement("FeatureTypes.LightFloat", typeof(FeatureTypes.LightFloat), Order = 1, ElementName = "LightFloat")]
		[XmlElement("FeatureTypes.LightVessel", typeof(FeatureTypes.LightVessel), Order = 1, ElementName = "LightVessel")]
		[XmlElement("FeatureTypes.OffshorePlatform", typeof(FeatureTypes.OffshorePlatform), Order = 1, ElementName = "OffshorePlatform")]
		[XmlElement("FeatureTypes.SiloTank", typeof(FeatureTypes.SiloTank), Order = 1, ElementName = "SiloTank")]
		[XmlElement("FeatureTypes.Pile", typeof(FeatureTypes.Pile), Order = 1, ElementName = "Pile")]
		[XmlElement("FeatureTypes.Building", typeof(FeatureTypes.Building), Order = 1, ElementName = "Building")]
		[XmlElement("FeatureTypes.Bridge", typeof(FeatureTypes.Bridge), Order = 1, ElementName = "Bridge")]
		[XmlElement("FeatureTypes.SinkerAnchor", typeof(FeatureTypes.SinkerAnchor), Order = 1, ElementName = "SinkerAnchor")]
		[XmlElement("FeatureTypes.MooringShackle", typeof(FeatureTypes.MooringShackle), Order = 1, ElementName = "MooringShackle")]
		[XmlElement("FeatureTypes.CableSubmarine", typeof(FeatureTypes.CableSubmarine), Order = 1, ElementName = "CableSubmarine")]
		[XmlElement("FeatureTypes.Swivel", typeof(FeatureTypes.Swivel), Order = 1, ElementName = "Swivel")]
		[XmlElement("FeatureTypes.Bridle", typeof(FeatureTypes.Bridle), Order = 1, ElementName = "Bridle")]
		[XmlElement("FeatureTypes.CounterWeight", typeof(FeatureTypes.CounterWeight), Order = 1, ElementName = "CounterWeight")]
		[XmlElement("FeatureTypes.Topmark", typeof(FeatureTypes.Topmark), Order = 1, ElementName = "Topmark")]
		[XmlElement("FeatureTypes.SafeWaterBeacon", typeof(FeatureTypes.SafeWaterBeacon), Order = 1, ElementName = "SafeWaterBeacon")]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBeacon", typeof(FeatureTypes.SpecialPurposeGeneralBeacon), Order = 1, ElementName = "SpecialPurposeGeneralBeacon")]
		[XmlElement("FeatureTypes.SafeWaterBuoy", typeof(FeatureTypes.SafeWaterBuoy), Order = 1, ElementName = "SafeWaterBuoy")]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBuoy", typeof(FeatureTypes.SpecialPurposeGeneralBuoy), Order = 1, ElementName = "SpecialPurposeGeneralBuoy")]
		[XmlElement("FeatureTypes.DangerousFeature", typeof(FeatureTypes.DangerousFeature), Order = 1, ElementName = "DangerousFeature")]
		[XmlElement("FeatureTypes.AtonAggregation", typeof(FeatureTypes.AtonAggregation), Order = 1, ElementName = "AtonAggregation")]
		[XmlElement("FeatureTypes.AtonAssociation", typeof(FeatureTypes.AtonAssociation), Order = 1, ElementName = "AtonAssociation")]
		[XmlElement("FeatureTypes.QualityOfNonBathymetricData", typeof(FeatureTypes.QualityOfNonBathymetricData), Order = 1, ElementName = "QualityOfNonBathymetricData")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.LocalDirectionOfBuoyage", typeof(FeatureTypes.LocalDirectionOfBuoyage), Order = 1, ElementName = "LocalDirectionOfBuoyage")]
		[XmlElement("FeatureTypes.NavigationalSystemOfMarks", typeof(FeatureTypes.NavigationalSystemOfMarks), Order = 1, ElementName = "NavigationalSystemOfMarks")]
		[XmlElement("FeatureTypes.SoundingDatum", typeof(FeatureTypes.SoundingDatum), Order = 1, ElementName = "SoundingDatum")]
		[XmlElement("FeatureTypes.VerticalDatumOfData", typeof(FeatureTypes.VerticalDatumOfData), Order = 1, ElementName = "VerticalDatumOfData")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
