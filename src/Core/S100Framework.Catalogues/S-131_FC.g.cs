using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S131 {
	public class Summary : ISummary
	{
		public static string Name => "Feature Catalogue for S-131";
		public static string Scope => "Global coverage of maritime areas";
		public static string ProductId => "S-131";
		public static Version Version => new Version("2.0.0");
		public static DateOnly VersionDate => DateOnly.ParseExact("2025-11-12", "yyyy-MM-dd");
		public static string[] ComplexTypes => ["bearingInformation","cargoServicesDescription","constructionInformation","contactAddress","depthsDescription","facilitiesLayoutDescription","featureName","fixedDateRange","frequencyPair","generalHarbourInformation","generalPortDescription","graphic","horizontalPositionUncertainty","information","landmarkDescription","limitsDescription","majorLightDescription","markedBy","offshoreMarkDescription","onlineResource","orientation","periodicDateRange","rxNCode","scheduleByDayOfWeek","sourceIndication","spatialAccuracy","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","usefulMarkDescription","verticalUncertainty","vesselMeasurementsSpecification","weatherResource"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AuthorityContact","AuthorityHours","AssociatedRxN","ExceptionalWorkday","ServiceControl","ServiceContact","LocationHours","RelatedOrganisation","InclusionType","PermissionType","SpatialAssociation","LimitEntrance","ServiceAvailability"];
		public static string[] FeatureAssociationTypes => ["TextAssociation","Subsection","Infrastructure","PrimaryAuxiliaryFacility","Demarcation","JurisdictionalLimit","LayoutDivision"];
		public static string[] InformationTypes => ["Applicability","Authority","AvailablePortServices","ContactDetails","Entrance","NauticalInformation","NonStandardWorkingDay","Recommendations","Regulations","Restrictions","ServiceHours","SpatialQuality"];
		public static string[] FeatureTypes => ["AnchorBerth","AnchorageArea","AutomatedGuidedVehicle","Berth","BerthPosition","Bollard","DockArea","DryDock","Dolphin","DumpingGround","FenderLine","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourBasin","HarbourFacility","LockBasin","LockBasinPart","MooringBuoy","MooringWarpingFacility","OnshorePowerFacility","OuterLimit","PilotBoardingPlace","SeaplaneLandingArea","ShipLift","StraddleCarrier","Terminal","TurningBasin","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","SoundingDatum","VerticalDatumOfData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.point => ["AnchorBerth","AnchorageArea","AutomatedGuidedVehicle","Berth","BerthPosition","Bollard","DryDock","Dolphin","DumpingGround","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourFacility","LockBasin","LockBasinPart","MooringBuoy","MooringWarpingFacility","OnshorePowerFacility","PilotBoardingPlace","SeaplaneLandingArea","ShipLift","StraddleCarrier","Terminal","TextPlacement"],
			Primitives.surface => ["AnchorBerth","AnchorageArea","AutomatedGuidedVehicle","Berth","DockArea","DryDock","Dolphin","DumpingGround","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourBasin","HarbourFacility","LockBasin","LockBasinPart","OuterLimit","PilotBoardingPlace","SeaplaneLandingArea","ShipLift","StraddleCarrier","Terminal","TurningBasin","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","SoundingDatum","VerticalDatumOfData"],
			Primitives.curve => ["AutomatedGuidedVehicle","Berth","FenderLine","HarbourFacility","OuterLimit"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"FeatureType" => [],
			"OrganizationContactArea" => [],
			"SupervisedArea" => [],
			"HarbourPhysicalInfrastructure" => [],
			"Layout" => [],
			"AnchorBerth" => [Primitives.point,Primitives.surface],
			"AnchorageArea" => [Primitives.point,Primitives.surface],
			"AutomatedGuidedVehicle" => [Primitives.point,Primitives.curve,Primitives.surface],
			"Berth" => [Primitives.point,Primitives.curve,Primitives.surface],
			"BerthPosition" => [Primitives.point],
			"Bollard" => [Primitives.point],
			"DockArea" => [Primitives.surface],
			"DryDock" => [Primitives.point,Primitives.surface],
			"Dolphin" => [Primitives.point,Primitives.surface],
			"DumpingGround" => [Primitives.surface,Primitives.point],
			"FenderLine" => [Primitives.curve],
			"FloatingDock" => [Primitives.point,Primitives.surface],
			"Gridiron" => [Primitives.point,Primitives.surface],
			"HarbourAreaAdministrative" => [Primitives.point,Primitives.surface],
			"HarbourAreaSection" => [Primitives.point,Primitives.surface],
			"HarbourBasin" => [Primitives.surface],
			"HarbourFacility" => [Primitives.point,Primitives.curve,Primitives.surface],
			"LockBasin" => [Primitives.point,Primitives.surface],
			"LockBasinPart" => [Primitives.point,Primitives.surface],
			"MooringBuoy" => [Primitives.point],
			"MooringWarpingFacility" => [Primitives.point],
			"OnshorePowerFacility" => [Primitives.point],
			"OuterLimit" => [Primitives.curve,Primitives.surface],
			"PilotBoardingPlace" => [Primitives.surface,Primitives.point],
			"SeaplaneLandingArea" => [Primitives.surface,Primitives.point],
			"ShipLift" => [Primitives.point,Primitives.surface],
			"StraddleCarrier" => [Primitives.point,Primitives.surface],
			"Terminal" => [Primitives.point,Primitives.surface],
			"TurningBasin" => [Primitives.surface],
			"WaterwayArea" => [Primitives.surface],
			"DataCoverage" => [Primitives.surface],
			"QualityOfNonBathymetricData" => [Primitives.surface],
			"SoundingDatum" => [Primitives.surface],
			"VerticalDatumOfData" => [Primitives.surface],
			"TextPlacement" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
		public static Type InformationBindings(string code) => code switch {
			"AdditionalInformation" => typeof(informationBinding<InformationAssociations.AdditionalInformation>),
			"AuthorityContact" => typeof(informationBinding<InformationAssociations.AuthorityContact>),
			"AuthorityHours" => typeof(informationBinding<InformationAssociations.AuthorityHours>),
			"AssociatedRxN" => typeof(informationBinding<InformationAssociations.AssociatedRxN>),
			"ExceptionalWorkday" => typeof(informationBinding<InformationAssociations.ExceptionalWorkday>),
			"ServiceControl" => typeof(informationBinding<InformationAssociations.ServiceControl>),
			"ServiceContact" => typeof(informationBinding<InformationAssociations.ServiceContact>),
			"LocationHours" => typeof(informationBinding<InformationAssociations.LocationHours>),
			"RelatedOrganisation" => typeof(informationBinding<InformationAssociations.RelatedOrganisation>),
			"InclusionType" => typeof(informationBinding<InformationAssociations.InclusionType>),
			"PermissionType" => typeof(informationBinding<InformationAssociations.PermissionType>),
			"SpatialAssociation" => typeof(informationBinding<InformationAssociations.SpatialAssociation>),
			"LimitEntrance" => typeof(informationBinding<InformationAssociations.LimitEntrance>),
			"ServiceAvailability" => typeof(informationBinding<InformationAssociations.ServiceAvailability>),
			_ or "" => throw new InvalidOperationException(),
		};
		public static Type FeatureBindings(string code) => code switch {
			"TextAssociation" => typeof(featureBinding<FeatureAssociations.TextAssociation>),
			"Subsection" => typeof(featureBinding<FeatureAssociations.Subsection>),
			"Infrastructure" => typeof(featureBinding<FeatureAssociations.Infrastructure>),
			"PrimaryAuxiliaryFacility" => typeof(featureBinding<FeatureAssociations.PrimaryAuxiliaryFacility>),
			"Demarcation" => typeof(featureBinding<FeatureAssociations.Demarcation>),
			"JurisdictionalLimit" => typeof(featureBinding<FeatureAssociations.JurisdictionalLimit>),
			"LayoutDivision" => typeof(featureBinding<FeatureAssociations.LayoutDivision>),
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AdditionalInformation>), typeDiscriminator: "informationBinding::S131::AdditionalInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AuthorityContact>), typeDiscriminator: "informationBinding::S131::AuthorityContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AuthorityHours>), typeDiscriminator: "informationBinding::S131::AuthorityHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AssociatedRxN>), typeDiscriminator: "informationBinding::S131::AssociatedRxN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.ExceptionalWorkday>), typeDiscriminator: "informationBinding::S131::ExceptionalWorkday"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.ServiceControl>), typeDiscriminator: "informationBinding::S131::ServiceControl"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.ServiceContact>), typeDiscriminator: "informationBinding::S131::ServiceContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.LocationHours>), typeDiscriminator: "informationBinding::S131::LocationHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.RelatedOrganisation>), typeDiscriminator: "informationBinding::S131::RelatedOrganisation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.InclusionType>), typeDiscriminator: "informationBinding::S131::InclusionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.PermissionType>), typeDiscriminator: "informationBinding::S131::PermissionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.SpatialAssociation>), typeDiscriminator: "informationBinding::S131::SpatialAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.LimitEntrance>), typeDiscriminator: "informationBinding::S131::LimitEntrance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.ServiceAvailability>), typeDiscriminator: "informationBinding::S131::ServiceAvailability"));
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.TextAssociation>), typeDiscriminator: "featureBinding::S131::TextAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.Subsection>), typeDiscriminator: "featureBinding::S131::Subsection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.Infrastructure>), typeDiscriminator: "featureBinding::S131::Infrastructure"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.PrimaryAuxiliaryFacility>), typeDiscriminator: "featureBinding::S131::PrimaryAuxiliaryFacility"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.Demarcation>), typeDiscriminator: "featureBinding::S131::Demarcation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.JurisdictionalLimit>), typeDiscriminator: "featureBinding::S131::JurisdictionalLimit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.LayoutDivision>), typeDiscriminator: "featureBinding::S131::LayoutDivision"));
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
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AdditionalInformation>), typeDiscriminator: "informationBinding::S131::AdditionalInformation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AuthorityContact>), typeDiscriminator: "informationBinding::S131::AuthorityContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AuthorityHours>), typeDiscriminator: "informationBinding::S131::AuthorityHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.AssociatedRxN>), typeDiscriminator: "informationBinding::S131::AssociatedRxN"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.ExceptionalWorkday>), typeDiscriminator: "informationBinding::S131::ExceptionalWorkday"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.ServiceControl>), typeDiscriminator: "informationBinding::S131::ServiceControl"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.ServiceContact>), typeDiscriminator: "informationBinding::S131::ServiceContact"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.LocationHours>), typeDiscriminator: "informationBinding::S131::LocationHours"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.RelatedOrganisation>), typeDiscriminator: "informationBinding::S131::RelatedOrganisation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.InclusionType>), typeDiscriminator: "informationBinding::S131::InclusionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.PermissionType>), typeDiscriminator: "informationBinding::S131::PermissionType"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.SpatialAssociation>), typeDiscriminator: "informationBinding::S131::SpatialAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.LimitEntrance>), typeDiscriminator: "informationBinding::S131::LimitEntrance"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(informationBinding<InformationAssociations.ServiceAvailability>), typeDiscriminator: "informationBinding::S131::ServiceAvailability"));
				}
				if (typeInfo.Type == typeof(featureBinding)) {
					typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
						TypeDiscriminatorPropertyName = "$type",
						IgnoreUnrecognizedTypeDiscriminators = true,
					};
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.TextAssociation>), typeDiscriminator: "featureBinding::S131::TextAssociation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.Subsection>), typeDiscriminator: "featureBinding::S131::Subsection"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.Infrastructure>), typeDiscriminator: "featureBinding::S131::Infrastructure"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.PrimaryAuxiliaryFacility>), typeDiscriminator: "featureBinding::S131::PrimaryAuxiliaryFacility"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.Demarcation>), typeDiscriminator: "featureBinding::S131::Demarcation"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.JurisdictionalLimit>), typeDiscriminator: "featureBinding::S131::JurisdictionalLimit"));
					typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(featureBinding<FeatureAssociations.LayoutDivision>), typeDiscriminator: "featureBinding::S131::LayoutDivision"));
				}
			});
			return resolver;
		}
	}

	/// <summary>
	/// Classification of assistance for mooring or anchoring operations.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum berthingAssistance : int {
		[Description("Information about assistance or arrangements for a service related to berthing operations.")]
		[EnumMember(Value = "Berthing Information")] 
		[XmlEnum("1")] 
		BerthingInformation = 1,

		[Description("Personnel specializing in the mooring and unmooring of vessels.")]
		[EnumMember(Value = "Line Personnel")] 
		[XmlEnum("2")] 
		LinePersonnel = 2,

		[Description("A boat which assists the securement of a vessel to a berth or mooring with ropes or anchor.")]
		[EnumMember(Value = "Mooring Boat")] 
		[XmlEnum("3")] 
		MooringBoat = 3,

		[Description("A locomotive for moving vessels.")]
		[EnumMember(Value = "Mule")] 
		[XmlEnum("4")] 
		Mule = 4,

		[Description("A powerful small boat designed to pull or push larger ships or powerless barges.")]
		[EnumMember(Value = "Tugboat")] 
		[XmlEnum("5")] 
		Tugboat = 5,

		[Description("A ship equipped to make and maintain a channel through ice.")]
		[EnumMember(Value = "Icebreaking Ship")] 
		[XmlEnum("6")] 
		IcebreakingShip = 6,
	}

	/// <summary>
	/// Principal and intermediate compass points.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalDirection : int {
		[Description("348.75-011.25 degrees (true north).")]
		[EnumMember(Value = "North")] 
		[XmlEnum("1")] 
		North = 1,

		[Description("011.25 - 033.75 degrees.")]
		[EnumMember(Value = "North Northeast")] 
		[XmlEnum("2")] 
		NorthNortheast = 2,

		[Description("033.75 - 056.25 degrees.")]
		[EnumMember(Value = "Northeast")] 
		[XmlEnum("3")] 
		Northeast = 3,

		[Description("056.25-078.75 degrees.")]
		[EnumMember(Value = "East Northeast")] 
		[XmlEnum("4")] 
		EastNortheast = 4,

		[Description("078.75-101.25 degrees.")]
		[EnumMember(Value = "East")] 
		[XmlEnum("5")] 
		East = 5,

		[Description("101.25-123.75 degrees.")]
		[EnumMember(Value = "East Southeast")] 
		[XmlEnum("6")] 
		EastSoutheast = 6,

		[Description("123.75-146.25 degrees.")]
		[EnumMember(Value = "Southeast")] 
		[XmlEnum("7")] 
		Southeast = 7,

		[Description("146.25-168.75 degrees.")]
		[EnumMember(Value = "South Southeast")] 
		[XmlEnum("8")] 
		SouthSoutheast = 8,

		[Description("168.75-191.25 degrees.")]
		[EnumMember(Value = "South")] 
		[XmlEnum("9")] 
		South = 9,

		[Description("191.25-213.75 degrees.")]
		[EnumMember(Value = "South Southwest")] 
		[XmlEnum("10")] 
		SouthSouthwest = 10,

		[Description("213.75-236.25 degrees.")]
		[EnumMember(Value = "Southwest")] 
		[XmlEnum("11")] 
		Southwest = 11,

		[Description("236.25-258.75 degrees.")]
		[EnumMember(Value = "West Southwest")] 
		[XmlEnum("12")] 
		WestSouthwest = 12,

		[Description("258.75-281.25 degrees.")]
		[EnumMember(Value = "West")] 
		[XmlEnum("13")] 
		West = 13,

		[Description("281.25-303.75 degrees.")]
		[EnumMember(Value = "West Northwest")] 
		[XmlEnum("14")] 
		WestNorthwest = 14,

		[Description("303.75 - 326.25 degrees.")]
		[EnumMember(Value = "Northwest")] 
		[XmlEnum("15")] 
		Northwest = 15,

		[Description("326.25 - 348.75 degrees.")]
		[EnumMember(Value = "North Northwest")] 
		[XmlEnum("16")] 
		NorthNorthwest = 16,
	}

	/// <summary>
	/// Classification of services related to the goods or items carried by vessels.
	/// </summary>
	/// <remarks>
	/// Defines an enumeration or codelist listing specific services.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cargoService : int {
		[Description("The loading, unloading, moving or handling of cargo, ship's stores, gear, or other materials, into, in, on, or out of any vessel.")]
		[EnumMember(Value = "Stevedoring")] 
		[XmlEnum("1")] 
		Stevedoring = 1,

		[Description("Inspection, evaluation or monitoring of the quantity, stowage, loading and unloading, and condition of cargo, and the effects of cargoes on vessel stability and safety.")]
		[EnumMember(Value = "Cargo Surveying")] 
		[XmlEnum("2")] 
		CargoSurveying = 2,

		[Description("The securement of cargo to the ship's structure and/or other cargo.")]
		[EnumMember(Value = "Cargo Lashing")] 
		[XmlEnum("3")] 
		CargoLashing = 3,

		[Description("Determination of the quantity of certain types of bulk cargo by assessment of its effect on displacement when loaded in a vessel.")]
		[EnumMember(Value = "Draught Survey")] 
		[XmlEnum("4")] 
		DraughtSurvey = 4,
	}

	/// <summary>
	/// Classification of an area where different use types of vessel can remain static.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAnchorage : int {
		[Description("An area in which vessels anchor or may anchor.")]
		[EnumMember(Value = "Unrestricted Anchorage")] 
		[XmlEnum("1")] 
		UnrestrictedAnchorage = 1,

		[Description("An area in which vessels of deep draught anchor or may anchor.")]
		[EnumMember(Value = "Deep Water Anchorage")] 
		[XmlEnum("2")] 
		DeepWaterAnchorage = 2,

		[Description("An area in which tankers anchor or may anchor.")]
		[EnumMember(Value = "Tanker Anchorage")] 
		[XmlEnum("3")] 
		TankerAnchorage = 3,

		[Description("An area where a vessel anchors when satisfying quarantine regulations.")]
		[EnumMember(Value = "Quarantine Anchorage")] 
		[XmlEnum("5")] 
		QuarantineAnchorage = 5,

		[Description("An area in which seaplanes anchor or may anchor.")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		[XmlEnum("6")] 
		SeaplaneAnchorage = 6,

		[Description("An area in which yachts and small boats anchor or may anchor.")]
		[EnumMember(Value = "Small Craft Anchorage")] 
		[XmlEnum("7")] 
		SmallCraftAnchorage = 7,

		[Description("An area in which vessels anchor or may anchor for periods of up to 24 hours.")]
		[EnumMember(Value = "Anchorage for Periods Up To 24 Hours")] 
		[XmlEnum("9")] 
		AnchorageForPeriodsUpTo24Hours = 9,

		[Description("An area in which vessels may anchor for a period of time not to exceed a specific limit.")]
		[EnumMember(Value = "Anchorage for a Limited Period of Time")] 
		[XmlEnum("10")] 
		AnchorageForALimitedPeriodOfTime = 10,

		[Description("An area in which vessels anchor or may anchor while waiting, for example, for access to a port or berth.")]
		[EnumMember(Value = "Waiting Anchorage")] 
		[XmlEnum("14")] 
		WaitingAnchorage = 14,

		[Description("A location not defined by a regulatory authority that has been reported to be suitable and safe for anchoring.")]
		[EnumMember(Value = "Reported Anchorage")] 
		[XmlEnum("15")] 
		ReportedAnchorage = 15,
	}

	/// <summary>
	/// The type of person, government agency or organisation granted powers of managing or controlling access to and/or activity in an area.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAuthority : int {
		[Description("The administration to prevent or detect and prosecute violations of rules and regulations at international boundaries.")]
		[EnumMember(Value = "Border Control")] 
		[XmlEnum("2")] 
		BorderControl = 2,

		[Description("The department of government, or civil force, charged with maintaining public order.")]
		[EnumMember(Value = "Police")] 
		[XmlEnum("3")] 
		Police = 3,

		[Description("Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.")]
		[EnumMember(Value = "Port")] 
		[XmlEnum("4")] 
		Port = 4,

		[Description("The authority controlling people entering a country.")]
		[EnumMember(Value = "Immigration")] 
		[XmlEnum("5")] 
		Immigration = 5,

		[Description("The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.")]
		[EnumMember(Value = "Health")] 
		[XmlEnum("6")] 
		Health = 6,

		[Description("Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.")]
		[EnumMember(Value = "Coast Guard")] 
		[XmlEnum("7")] 
		CoastGuard = 7,

		[Description("The authority with responsibility for preventing infection of the agriculture of a country and for the protection of the agricultural interests of a country.")]
		[EnumMember(Value = "Agricultural")] 
		[XmlEnum("8")] 
		Agricultural = 8,

		[Description("A military authority which provides control of access to or approval for transit through designated areas or airspace.")]
		[EnumMember(Value = "Military")] 
		[XmlEnum("9")] 
		Military = 9,

		[Description("A private or publicly owned company or commercial enterprise which exercises control of facilities, for example a calibration area.")]
		[EnumMember(Value = "Private Company")] 
		[XmlEnum("10")] 
		PrivateCompany = 10,

		[Description("A governmental or military force with jurisdiction in territorial waters. Examples could include Gendarmerie Maritime, Carabinierie, and Guardia Civil.")]
		[EnumMember(Value = "Maritime Police")] 
		[XmlEnum("11")] 
		MaritimePolice = 11,

		[Description("An authority with responsibility for the protection of the environment.")]
		[EnumMember(Value = "Environmental")] 
		[XmlEnum("12")] 
		Environmental = 12,

		[Description("An authority with responsibility for the control of fisheries.")]
		[EnumMember(Value = "Fishery")] 
		[XmlEnum("13")] 
		Fishery = 13,

		[Description("An authority with responsibility for the control and movement of money.")]
		[EnumMember(Value = "Finance")] 
		[XmlEnum("14")] 
		Finance = 14,

		[Description("A national or regional authority charged with administration of maritime affairs.")]
		[EnumMember(Value = "Maritime")] 
		[XmlEnum("15")] 
		Maritime = 15,

		[Description("The agency or establishment for collecting duties, tolls.")]
		[EnumMember(Value = "Customs")] 
		[XmlEnum("16")] 
		Customs = 16,
	}

	/// <summary>
	/// Classification of a berth according to the method of describing its location or extent.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfBerthLocation : int {
		[Description("A wharf or quay with reference position(s) given by one or more metre marks.")]
		[EnumMember(Value = "Wharf Reference Metre Mark")] 
		[XmlEnum("1")] 
		WharfReferenceMetreMark = 1,

		[Description("A wharf or quay with reference position(s) given by one or more point or points in geographic coordinates.")]
		[EnumMember(Value = "Wharf Reference Position")] 
		[XmlEnum("2")] 
		WharfReferencePosition = 2,

		[Description("A long, narrow structure extending into the water to afford a berthing place for vessels, to serve as a promenade, etc.")]
		[EnumMember(Value = "Pier (Jetty)")] 
		[XmlEnum("3")] 
		PierJetty = 3,

		[Description("A designated facility where a vessel may moor, usually by a combination of the mooring buoys and the ship’s anchors.")]
		[EnumMember(Value = "Multi-Buoy Mooring Berth")] 
		[XmlEnum("4")] 
		MultiBuoyMooringBerth = 4,
	}

	/// <summary>
	/// Classification of the different types of cargo that a ship may be carrying.
	/// </summary>
	/// <remarks>
	/// If item 7 is used, the nature of dangerous or hazardous cargoes can be amplified with category of dangerous or hazardous cargo.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[Description("Unpacked homogenous cargo poured loose in a certain space of a vessel, for example oil or grain.")]
		[EnumMember(Value = "Bulk")] 
		[XmlEnum("1")] 
		Bulk = 1,

		[Description("One of a number of standard sized cargo carrying units, secured using standard corner attachments and bar.")]
		[EnumMember(Value = "Container")] 
		[XmlEnum("2")] 
		Container = 2,

		[Description("Break bulk cargo normally loaded by crane.")]
		[EnumMember(Value = "General")] 
		[XmlEnum("3")] 
		General = 3,

		[Description("Any cargo loaded by pipeline.")]
		[EnumMember(Value = "Liquid")] 
		[XmlEnum("4")] 
		Liquid = 4,

		[Description("A fee paying traveller.")]
		[EnumMember(Value = "Passenger")] 
		[XmlEnum("5")] 
		Passenger = 5,

		[Description("Live animals carried in bulk.")]
		[EnumMember(Value = "Livestock")] 
		[XmlEnum("6")] 
		Livestock = 6,

		[Description("Dangerous or hazardous cargo as described by the IMO International Maritime Dangerous Goods code.")]
		[EnumMember(Value = "Dangerous or Hazardous")] 
		[XmlEnum("7")] 
		DangerousOrHazardous = 7,

		[Description("Indivisible heavy items of weight generally over 100 tons, and width or height greater than 100 metres.")]
		[EnumMember(Value = "Heavy Lift")] 
		[XmlEnum("8")] 
		HeavyLift = 8,

		[Description("Material carried by a ship to ensure its stability.")]
		[EnumMember(Value = "Ballast")] 
		[XmlEnum("9")] 
		Ballast = 9,

		[Description("Commodity cargo that is transported unpackaged in large quantities. These types of goods usually need to be kept dry during the whole transportation period.")]
		[EnumMember(Value = "Dry Bulk Cargo")] 
		[XmlEnum("10")] 
		DryBulkCargo = 10,

		[Description("Liquids or gases that are transported in bulk and carried unpackaged.")]
		[EnumMember(Value = "Liquid Bulk Cargo")] 
		[XmlEnum("11")] 
		LiquidBulkCargo = 11,

		[Description("Cargo transported in refrigerated containers, generally perishable commodities which require temperature-controlled transportation, such as fruit, meat, fish, vegetables, dairy products and other foods.")]
		[EnumMember(Value = "Reefer Container Cargo")] 
		[XmlEnum("12")] 
		ReeferContainerCargo = 12,

		[Description("Wheeled cargo, such as cars, busses, trucks, agricultural vehicles and cranes, that are driven on and off the ship on their own wheels or using a platform vehicle, such as a self-propelled modular transporter.")]
		[EnumMember(Value = "Ro-Ro Cargo")] 
		[XmlEnum("13")] 
		RoRoCargo = 13,

		[Description("Project cargo is a term used to broadly describe the national or international transportation of large, heavy, high value, or critical (to the project they are intended for) pieces of equipment. Also commonly referred to as heavy lift, this includes shipments made of various components which need disassembly for shipment and reassembly after delivery.")]
		[EnumMember(Value = "Project Cargo")] 
		[XmlEnum("14")] 
		ProjectCargo = 14,

		[Description("Goods that are stowed on board ship in individually counted units, and not in intermodal containers nor in bulk as with oil or grain.")]
		[EnumMember(Value = "Break Bulk Cargo")] 
		[XmlEnum("15")] 
		BreakBulkCargo = 15,
	}

	/// <summary>
	/// Classification of frequencies, VHF channels, telephone numbers, or other means of communication based on preference.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCommunicationPreference : int {
		[Description("The first choice channel or frequency to be used when calling a radio station.")]
		[EnumMember(Value = "Preferred Calling")] 
		[XmlEnum("1")] 
		PreferredCalling = 1,

		[Description("A channel or frequency to be used for calling a radio station when the preferred channel or frequency is busy or is suffering from interference.")]
		[EnumMember(Value = "Alternate Calling")] 
		[XmlEnum("2")] 
		AlternateCalling = 2,

		[Description("The first choice channel or frequency to be used when working with a radio station.")]
		[EnumMember(Value = "Preferred Working")] 
		[XmlEnum("3")] 
		PreferredWorking = 3,

		[Description("A channel or frequency to be used for working with a radio station when the preferred working channel or frequency is busy or is suffering from interference.")]
		[EnumMember(Value = "Alternate Working")] 
		[XmlEnum("4")] 
		AlternateWorking = 4,
	}

	/// <summary>
	/// Classification of dangerous goods or hazardous materials based on the International Maritime Dangerous Goods Code (IMDG Code).
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDangerousOrHazardousCargo : int {
		[Description("Explosives, Division 1: Substances and articles which have a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.1")] 
		[XmlEnum("1")] 
		ImdgCodeClass1Div11 = 1,

		[Description("Explosives, Division 2: Substances and articles which have a projection hazard but not a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.2")] 
		[XmlEnum("2")] 
		ImdgCodeClass1Div12 = 2,

		[Description("Explosives, Division 3: Substances and articles which have a fire hazard and either a minor blast hazard or a minor projection hazard or both, but not a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.3")] 
		[XmlEnum("3")] 
		ImdgCodeClass1Div13 = 3,

		[Description("Explosives, Division 4: Substances and articles which present no significant hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.4")] 
		[XmlEnum("4")] 
		ImdgCodeClass1Div14 = 4,

		[Description("Explosives, Division 5: Very insensitive substances which have a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.5")] 
		[XmlEnum("5")] 
		ImdgCodeClass1Div15 = 5,

		[Description("Explosives, Division 6: Extremely insensitive articles which do not have a mass explosion hazard.")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.6")] 
		[XmlEnum("6")] 
		ImdgCodeClass1Div16 = 6,

		[Description("Gases, flammable gases.")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.1")] 
		[XmlEnum("7")] 
		ImdgCodeClass2Div21 = 7,

		[Description("Gases, non-flammable, non-toxic gases.")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.2")] 
		[XmlEnum("8")] 
		ImdgCodeClass2Div22 = 8,

		[Description("Gases, toxic gases.")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.3")] 
		[XmlEnum("9")] 
		ImdgCodeClass2Div23 = 9,

		[Description("Flammable liquids.")]
		[EnumMember(Value = "IMDG Code Class 3")] 
		[XmlEnum("10")] 
		ImdgCodeClass3 = 10,

		[Description("Flammable solids, self-reactive substances and desensitized explosives.")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.1")] 
		[XmlEnum("11")] 
		ImdgCodeClass4Div41 = 11,

		[Description("Substances liable to spontaneous combustion.")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.2")] 
		[XmlEnum("12")] 
		ImdgCodeClass4Div42 = 12,

		[Description("Substances which, in contact with water, emit flammable gases.")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.3")] 
		[XmlEnum("13")] 
		ImdgCodeClass4Div43 = 13,

		[Description("Oxidizing substances.")]
		[EnumMember(Value = "IMDG Code Class 5 Div. 5.1")] 
		[XmlEnum("14")] 
		ImdgCodeClass5Div51 = 14,

		[Description("Organic peroxides.")]
		[EnumMember(Value = "IMDG Code Class 5 Div. 5.2")] 
		[XmlEnum("15")] 
		ImdgCodeClass5Div52 = 15,

		[Description("Toxic substances.")]
		[EnumMember(Value = "IMDG Code Class 6 Div. 6.1")] 
		[XmlEnum("16")] 
		ImdgCodeClass6Div61 = 16,

		[Description("Infectious substances.")]
		[EnumMember(Value = "IMDG Code Class 6 Div. 6.2")] 
		[XmlEnum("17")] 
		ImdgCodeClass6Div62 = 17,

		[Description("Radioactive material.")]
		[EnumMember(Value = "IMDG Code Class 7")] 
		[XmlEnum("18")] 
		ImdgCodeClass7 = 18,

		[Description("Corrosive substances.")]
		[EnumMember(Value = "IMDG Code Class 8")] 
		[XmlEnum("19")] 
		ImdgCodeClass8 = 19,

		[Description("Miscellaneous dangerous substances and articles.")]
		[EnumMember(Value = "IMDG Code Class 9")] 
		[XmlEnum("20")] 
		ImdgCodeClass9 = 20,

		[Description("Harmful substances are those substances which are identified as marine pollutants in the International Maritime Dangerous Goods Code (IMDG Code). Packaged form is defined as the forms of containment specified for harmful substances in the IMDG Code.")]
		[EnumMember(Value = "Harmful Substances in Packaged Form")] 
		[XmlEnum("21")] 
		HarmfulSubstancesInPackagedForm = 21,
	}

	/// <summary>
	/// Classification of significant aspects of depths about which information is provided.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDepthsDescription : int {
		[Description("A shallow elevation composed of unconsolidated material that may constitute a hazard to surface navigation.")]
		[EnumMember(Value = "Shoal")] 
		[XmlEnum("1")] 
		Shoal = 1,

		[Description("General information about the vertical distance from the water surface to the bottom.")]
		[EnumMember(Value = "General Depth")] 
		[XmlEnum("2")] 
		GeneralDepth = 2,

		[Description("The least depth in the approach or channel to an area, such as a port or anchorage, governing the maximum draft of vessels that can enter.")]
		[EnumMember(Value = "Controlling Depth")] 
		[XmlEnum("3")] 
		ControllingDepth = 3,
	}

	/// <summary>
	/// Classification of a post or group of posts, used for mooring or warping a vessel.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDolphin : int {
		[Description("A post or group of posts driven into the seabed or riverbed, used as a mooring point for vessels.")]
		[EnumMember(Value = "Mooring Dolphin")] 
		[XmlEnum("1")] 
		MooringDolphin = 1,

		[Description("A post or group of posts, which a vessel may swing around for compass adjustment.")]
		[EnumMember(Value = "Deviation Dolphin")] 
		[XmlEnum("2")] 
		DeviationDolphin = 2,

		[Description("A post or group of posts driven into the seabed or riverbed, used to extend the berth of a vessel by providing extra mooring points.")]
		[EnumMember(Value = "Berthing Dolphin")] 
		[XmlEnum("3")] 
		BerthingDolphin = 3,

		[Description("A post or group of posts driven into the seabed or riverbed, used to assist in berthing of vessels by taking up some berthing loads; keep vessels from pressing against the pier structure; or to protect structures from possible impact by ships.")]
		[EnumMember(Value = "Fender or Breasting Dolphin")] 
		[XmlEnum("4")] 
		FenderOrBreastingDolphin = 4,
	}

	/// <summary>
	/// The electrical frequency provided by the power supply station.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFrequency : int {
		[Description("50 Hertz")]
		[EnumMember(Value = "50Hz")] 
		[XmlEnum("1")] 
		five0hz = 1,

		[Description("60 Hertz")]
		[EnumMember(Value = "60Hz")] 
		[XmlEnum("2")] 
		six0hz = 2,
	}

	/// <summary>
	/// Classification of harbour use.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfHarbourFacility : int {
		[Description("A terminal for roll-on roll-off ferries.")]
		[EnumMember(Value = "RoRo Terminal")] 
		[XmlEnum("1")] 
		RoroTerminal = 1,

		[Description("A terminal for passenger and vehicle ferries.")]
		[EnumMember(Value = "Ferry Terminal")] 
		[XmlEnum("3")] 
		FerryTerminal = 3,

		[Description("A harbour with facilities for fishing boats.")]
		[EnumMember(Value = "Fishing Harbour")] 
		[XmlEnum("4")] 
		FishingHarbour = 4,

		[Description("A harbour facility for small boats, yachts, etc., where supplies, repairs, and various services are available.")]
		[EnumMember(Value = "Yacht Harbour/Marina")] 
		[XmlEnum("5")] 
		YachtHarbourMarina = 5,

		[Description("A centre of operations for naval vessels.")]
		[EnumMember(Value = "Naval Base")] 
		[XmlEnum("6")] 
		NavalBase = 6,

		[Description("A terminal for the bulk handling of liquid cargoes.")]
		[EnumMember(Value = "Tanker Terminal")] 
		[XmlEnum("7")] 
		TankerTerminal = 7,

		[Description("A terminal for the loading and unloading of passengers.")]
		[EnumMember(Value = "Passenger Terminal")] 
		[XmlEnum("8")] 
		PassengerTerminal = 8,

		[Description("A place where ships are built or repaired.")]
		[EnumMember(Value = "Shipyard")] 
		[XmlEnum("9")] 
		Shipyard = 9,

		[Description("A terminal with facilities to load/unload or store shipping containers.")]
		[EnumMember(Value = "Container Terminal")] 
		[XmlEnum("10")] 
		ContainerTerminal = 10,

		[Description("A terminal for the handling of bulk materials such as iron ore, coal, etc.")]
		[EnumMember(Value = "Bulk Terminal")] 
		[XmlEnum("11")] 
		BulkTerminal = 11,

		[Description("A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.")]
		[EnumMember(Value = "Ship Lift")] 
		[XmlEnum("12")] 
		ShipLift = 12,

		[Description("A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.")]
		[EnumMember(Value = "Straddle Carrier")] 
		[XmlEnum("13")] 
		StraddleCarrier = 13,

		[Description("A harbour within which the floating equipment (dredges, tugs ...) of harbour services are stationed.")]
		[EnumMember(Value = "Service Harbour")] 
		[XmlEnum("14")] 
		ServiceHarbour = 14,

		[Description("The services of a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area, are available.")]
		[EnumMember(Value = "Pilotage Service")] 
		[XmlEnum("15")] 
		PilotageService = 15,

		[Description("A place where mechanical services or repairs can be undertaken to engines or other vessel equipment.")]
		[EnumMember(Value = "Service and Repair")] 
		[XmlEnum("16")] 
		ServiceAndRepair = 16,

		[Description("A medical control center located in an isolated spot ashore where patients with contagious diseases from vessel in quarantine are taken.")]
		[EnumMember(Value = "Quarantine Station")] 
		[XmlEnum("17")] 
		QuarantineStation = 17,
	}

	/// <summary>
	/// A place or structure to which a vessel can be secured.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfMooringWarpingFacility : int {
		[Description("A section of wall designated for tying-up vessels awaiting transit. Bollards and mooring devices are available for both large and small ships.")]
		[EnumMember(Value = "Tie-Up Wall")] 
		[XmlEnum("4")] 
		TieUpWall = 4,

		[Description("A long heavy timber or section of steel, wood, concrete, etc., forced into the seabed to serve as a mooring facility.")]
		[EnumMember(Value = "Post or Pile")] 
		[XmlEnum("5")] 
		PostOrPile = 5,

		[Description("A chain or very strong fibre or wire rope used to anchor or moor vessels or buoys.")]
		[EnumMember(Value = "Mooring Cable")] 
		[XmlEnum("6")] 
		MooringCable = 6,
	}

	/// <summary>
	/// Classification of subdivisions of a port or harbour area by usage.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPortSection : int {
		[Description("The main navigable channel in a harbour or its approaches, for vessels of larger size.")]
		[EnumMember(Value = "Port Fairway")] 
		[XmlEnum("1")] 
		PortFairway = 1,

		[Description("A body of water at a berth or anchor berth, of adequate dimensions to allow a vessel to make fast to the shore, mooring buoys, berthing dolphins or to anchor.")]
		[EnumMember(Value = "Berth Pocket")] 
		[XmlEnum("3")] 
		BerthPocket = 3,

		[Description("An area in which sea-planes anchor or may anchor.")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		[XmlEnum("8")] 
		SeaplaneAnchorage = 8,

		[Description("An area of water or channel enlargement of increased depth compared to adjacent areas, where the depth is maintained by dredging operations.")]
		[EnumMember(Value = "Dredged Basin")] 
		[XmlEnum("9")] 
		DredgedBasin = 9,

		[Description("The area around a port facility or harbour installation within which vessels are prohibited from entering without permission.")]
		[EnumMember(Value = "Port Safety Zone")] 
		[XmlEnum("11")] 
		PortSafetyZone = 11,

		[Description("A general berth for use by vessels for short term waiting until a loading or discharging berth is available.")]
		[EnumMember(Value = "Lay-by Berth")] 
		[XmlEnum("12")] 
		LayByBerth = 12,
	}

	/// <summary>
	/// Expresses constraints or requirements on vessel actions or activities in relation to a geographic feature, facility, or service.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRelationship : int {
		[Description("Use of facility, waterway or service is forbidden.")]
		[EnumMember(Value = "Prohibited")] 
		[XmlEnum("1")] 
		Prohibited = 1,

		[Description("Use of facility, waterway or service is not recommended.")]
		[EnumMember(Value = "Not Recommended")] 
		[XmlEnum("2")] 
		NotRecommended = 2,

		[Description("Use of facility, waterway, or service is permitted but not required.")]
		[EnumMember(Value = "Permitted")] 
		[XmlEnum("3")] 
		Permitted = 3,

		[Description("Use of facility, waterway, or service is recommended.")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("4")] 
		Recommended = 4,

		[Description("Use of facility, waterway, or service is required.")]
		[EnumMember(Value = "Required")] 
		[XmlEnum("5")] 
		Required = 5,

		[Description("Use of facility, waterway, or service is not required.")]
		[EnumMember(Value = "Not Required")] 
		[XmlEnum("6")] 
		NotRequired = 6,

		[Description("Only vessels of the specified characteristics may use the facility, waterway, or service.")]
		[EnumMember(Value = "Exclusively Permitted")] 
		[XmlEnum("7")] 
		ExclusivelyPermitted = 7,
	}

	/// <summary>
	/// The type of schedule, for instance opening, closure, etc.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSchedule : int {
		[Description("The service, office, is open, fully manned, and operating normally, or the area is accessible as usual.")]
		[EnumMember(Value = "Normal Operation")] 
		[XmlEnum("1")] 
		NormalOperation = 1,

		[Description("The service, office, or area is closed.")]
		[EnumMember(Value = "Closure")] 
		[XmlEnum("2")] 
		Closure = 2,

		[Description("The service is available but not manned.")]
		[EnumMember(Value = "Unmanned Operation")] 
		[XmlEnum("3")] 
		UnmannedOperation = 3,
	}

	/// <summary>
	/// Classification of equipment or installations that are used for providing shoreside electrical power to a vessel at berth.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfShorePowerFacility : int {
		[Description("Delivers power to vessels using higher voltage (for example, 10 kV or above), suitable for large ports and large vessels. such as tankers, cargo ships, etc.")]
		[EnumMember(Value = "High-Voltage Shore Power System")] 
		[XmlEnum("1")] 
		HighVoltageShorePowerSystem = 1,

		[Description("Delivers power to vessels using lower voltage, designed for small to medium-sized coastal or riverine terminals and smaller vessels.")]
		[EnumMember(Value = "Low-Voltage Shore Power System")] 
		[XmlEnum("2")] 
		LowVoltageShorePowerSystem = 2,

		[Description("Delivers power to vessels using high-voltage (for example, 10kV and above) and low-voltage outputs or simultaneous provision of dual-voltage power.")]
		[EnumMember(Value = "Hybrid Shore Power System")] 
		[XmlEnum("3")] 
		HybridShorePowerSystem = 3,
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

		[Description("Continuous or frequent change (for example river siltation, sand waves, seasonal storms, ice bergs, etc) that is likely to result in new significant shoaling.")]
		[EnumMember(Value = "Likely to Change and Significant Shoaling Expected")] 
		[XmlEnum("2")] 
		LikelyToChangeAndSignificantShoalingExpected = 2,

		[Description("Continuous or frequent change (for example sand wave shift, seasonal storms, ice bergs, etc) that is not likely to result in new significant shoaling.")]
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
	/// Classification of terminals according to type of use, purpose, or type of cargo loaded or unloaded.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTerminal : int {
		[Description("A terminal for roll-on roll-off ferries.")]
		[EnumMember(Value = "RoRo Terminal")] 
		[XmlEnum("1")] 
		RoroTerminal = 1,

		[Description("A terminal for passenger and vehicle ferries.")]
		[EnumMember(Value = "Ferry Terminal")] 
		[XmlEnum("3")] 
		FerryTerminal = 3,

		[Description("A terminal for the bulk handling of liquid cargoes.")]
		[EnumMember(Value = "Tanker Terminal")] 
		[XmlEnum("7")] 
		TankerTerminal = 7,

		[Description("A terminal for the loading and unloading of passengers.")]
		[EnumMember(Value = "Passenger Terminal")] 
		[XmlEnum("8")] 
		PassengerTerminal = 8,

		[Description("A terminal with facilities to load/unload or store shipping containers.")]
		[EnumMember(Value = "Container Terminal")] 
		[XmlEnum("10")] 
		ContainerTerminal = 10,

		[Description("A terminal for the handling of bulk materials such as iron ore, coal, etc.")]
		[EnumMember(Value = "Bulk Terminal")] 
		[XmlEnum("11")] 
		BulkTerminal = 11,
	}

	/// <summary>
	/// Classification of completeness of textual information in relation to the source material from which it is derived.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfText : int {
		[Description("A statement summarizing the important points of a text.")]
		[EnumMember(Value = "Abstract or Summary")] 
		[XmlEnum("1")] 
		AbstractOrSummary = 1,

		[Description("An excerpt or excerpts from a text.")]
		[EnumMember(Value = "Extract")] 
		[XmlEnum("2")] 
		Extract = 2,

		[Description("The whole text.")]
		[EnumMember(Value = "Full Text")] 
		[XmlEnum("3")] 
		FullText = 3,
	}

	/// <summary>
	/// The locality of vessel registration or enrolment relative to the nationality of a port, territorial sea, administrative area, exclusive zone or other location.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfVesselRegistry : int {
		[Description("The vessel is registered or enrolled under the same national flag as the port, harbour, territorial sea, exclusive economic zone, or administrative area in which the object that possesses this attribute applies or is located.")]
		[EnumMember(Value = "Domestic")] 
		[XmlEnum("1")] 
		Domestic = 1,

		[Description("The vessel is registered or enrolled under a national flag different from the port, harbour, territorial sea, exclusive economic zone, or other administrative area in which the object that possesses this attribute applies or is located.")]
		[EnumMember(Value = "Foreign")] 
		[XmlEnum("2")] 
		Foreign = 2,
	}

	/// <summary>
	/// The electrical voltage provided by the power supply station.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfVoltage : int {
		[Description("230 Volts")]
		[EnumMember(Value = "230V")] 
		[XmlEnum("1")] 
		two30v = 1,

		[Description("400 Volts.")]
		[EnumMember(Value = "400V")] 
		[XmlEnum("2")] 
		four00v = 2,

		[Description("120 Volts")]
		[EnumMember(Value = "120V")] 
		[XmlEnum("3")] 
		one20v = 3,

		[Description("120/240 Volts")]
		[EnumMember(Value = "120V or 240V")] 
		[XmlEnum("4")] 
		one20vOr240v = 4,

		[Description("208 Volts")]
		[EnumMember(Value = "208V")] 
		[XmlEnum("5")] 
		two08v = 5,

		[Description("440 Volts")]
		[EnumMember(Value = "440V")] 
		[XmlEnum("6")] 
		fourfour0v = 6,

		[Description("440/690 Volts")]
		[EnumMember(Value = "440V or 690V")] 
		[XmlEnum("7")] 
		fourfour0vOr690v = 7,

		[Description("480 Volts")]
		[EnumMember(Value = "480V")] 
		[XmlEnum("8")] 
		four80v = 8,

		[Description("690 Volts")]
		[EnumMember(Value = "690V")] 
		[XmlEnum("9")] 
		six90v = 9,

		[Description("6.6 kiloVolts")]
		[EnumMember(Value = "6600V")] 
		[XmlEnum("10")] 
		sixsix00v = 10,

		[Description("6.6/11 kiloVolts")]
		[EnumMember(Value = "6600V or 11000V")] 
		[XmlEnum("11")] 
		sixsix00vOr11000v = 11,

		[Description("11 kiloVolts")]
		[EnumMember(Value = "11000V")] 
		[XmlEnum("12")] 
		oneone000v = 12,

		[Description("22 kiloVolts")]
		[EnumMember(Value = "22000V")] 
		[XmlEnum("13")] 
		twotwo000v = 13,

		[Description("380 Volts")]
		[EnumMember(Value = "380V")] 
		[XmlEnum("14")] 
		three80v = 14,
	}

	/// <summary>
	/// Numerical comparison.
	/// </summary>
	/// <remarks>
	/// Provides the relation between the value given in the model and the real ship's value.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[Description("The value of the left value is greater than that of the right.")]
		[EnumMember(Value = "Greater Than")] 
		[XmlEnum("1")] 
		GreaterThan = 1,

		[Description("The value of the left expression is greater than or equal to that of the right.")]
		[EnumMember(Value = "Greater Than or Equal To")] 
		[XmlEnum("2")] 
		GreaterThanOrEqualTo = 2,

		[Description("The value of the left expression is less than that of the right.")]
		[EnumMember(Value = "Less Than")] 
		[XmlEnum("3")] 
		LessThan = 3,

		[Description("The value of the left expression is less than or equal to that of the right.")]
		[EnumMember(Value = "Less Than or Equal To")] 
		[XmlEnum("4")] 
		LessThanOrEqualTo = 4,

		[Description("The two values are equivalent.")]
		[EnumMember(Value = "Equal To")] 
		[XmlEnum("5")] 
		EqualTo = 5,

		[Description("The two values are not equivalent.")]
		[EnumMember(Value = "Not Equal To")] 
		[XmlEnum("6")] 
		NotEqualTo = 6,
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

		[Description("Detailed planning has been completed but construction has not been initiated.")]
		[EnumMember(Value = "Planned Construction")] 
		[XmlEnum("5")] 
		PlannedConstruction = 5,
	}

	/// <summary>
	/// Any one of seven days in a week.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dayOfWeek : int {
		[Description("The day of the week following Saturday and preceding Monday.")]
		[EnumMember(Value = "Sunday")] 
		[XmlEnum("1")] 
		Sunday = 1,

		[Description("The day of the week following Sunday and preceding Tuesday.")]
		[EnumMember(Value = "Monday")] 
		[XmlEnum("2")] 
		Monday = 2,

		[Description("The day of the week following Monday and preceding Wednesday.")]
		[EnumMember(Value = "Tuesday")] 
		[XmlEnum("3")] 
		Tuesday = 3,

		[Description("The day of the week following Tuesday and preceding Thursday.")]
		[EnumMember(Value = "Wednesday")] 
		[XmlEnum("4")] 
		Wednesday = 4,

		[Description("The day of the week following Wednesday and preceding Friday.")]
		[EnumMember(Value = "Thursday")] 
		[XmlEnum("5")] 
		Thursday = 5,

		[Description("The day of the week following Thursday and preceding Saturday.")]
		[EnumMember(Value = "Friday")] 
		[XmlEnum("6")] 
		Friday = 6,

		[Description("The day of the week following Friday and preceding Sunday.")]
		[EnumMember(Value = "Saturday")] 
		[XmlEnum("7")] 
		Saturday = 7,
	}

	/// <summary>
	/// Whether a vessel must use a shore-based or other resource to obtain up-to-date information.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dynamicResource : int {
		[Description("The information is static, or a source of up-to-date information is unavailable or unknown.")]
		[EnumMember(Value = "Static")] 
		[XmlEnum("1")] 
		Static = 1,

		[Description("An external source of up-to-date information is available and interaction with it to obtain up-to-date information is required.")]
		[EnumMember(Value = "Mandatory External Dynamic")] 
		[XmlEnum("2")] 
		MandatoryExternalDynamic = 2,

		[Description("An external source of up-to-date information is available but interaction with it to obtain up-to-date information is not required.")]
		[EnumMember(Value = "Optional External Dynamic")] 
		[XmlEnum("3")] 
		OptionalExternalDynamic = 3,

		[Description("Up-to-date information may be computed using only onboard resources.")]
		[EnumMember(Value = "Onboard Dynamic")] 
		[XmlEnum("4")] 
		OnboardDynamic = 4,
	}

	/// <summary>
	/// Services for combating fires, provided by different methods.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum firefightingService : int {
		[Description("Personnel and equipment that are capable of combating a fire from ashore.")]
		[EnumMember(Value = "Shore-Based Firefighting")] 
		[XmlEnum("1")] 
		ShoreBasedFirefighting = 1,

		[Description("Trained firefighting personnel with the capability of boarding and combating a fire on a vessel.")]
		[EnumMember(Value = "Onboard Firefighting")] 
		[XmlEnum("2")] 
		OnboardFirefighting = 2,

		[Description("Specialised watercraft with firefighting apparatus designed for fighting shoreline and shipboard fires")]
		[EnumMember(Value = "Firefighting Boat")] 
		[XmlEnum("3")] 
		FirefightingBoat = 3,
	}

	/// <summary>
	/// Classification of ISPS security levels according to the ISPS Code.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iSPSLevel : int {
		[Description("The level for which minimum appropriate protective security measures shall be maintained at all times.")]
		[EnumMember(Value = "ISPS Level 1")] 
		[XmlEnum("1")] 
		IspsLevel1 = 1,

		[Description("The level for which appropriate additional protective security measures shall be maintained for a period of time as a result of heightened risk of a security incident.")]
		[EnumMember(Value = "ISPS Level 2")] 
		[XmlEnum("2")] 
		IspsLevel2 = 2,

		[Description("The level for which further specific protective security measures shall be maintained for a limited period of time when a security incident is probable or imminent, although it may not be possible to identify the specific target.")]
		[EnumMember(Value = "ISPS Level 3")] 
		[XmlEnum("3")] 
		IspsLevel3 = 3,
	}

	/// <summary>
	/// Expresses whether all the constraints described by its co-attributes must be satisfied, or only one such constraint need be satisfied.
	/// </summary>
	/// <remarks>
	/// Is intended to be used with co-attributes that encode limits on vessel dimensions, type of cargo, and other characteristics. The combination of constraints described by logicalConnectives and its co-attributes defines a subset of vessels to which information described by a feature or information type instance applies (or does not apply, is required, recommended, etc.). The relationship between the vessel subset and the information is indicated by an association - see PermissionType and InclusionType). The two listed values of logicalConnective are two of the basic operations of Boolean logic. The third basic operation (not) is not used.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum logicalConnectives : int {
		[Description("All the conditions described by the other attributes of the object, or sub-attributes of the same complex attribute, are true.")]
		[EnumMember(Value = "Logical Conjunction")] 
		[XmlEnum("1")] 
		LogicalConjunction = 1,

		[Description("At least one of the conditions described by the other attributes of the object, or sub-attributes of the same complex attributes, is true.")]
		[EnumMember(Value = "Logical Disjunction")] 
		[XmlEnum("2")] 
		LogicalDisjunction = 2,
	}

	/// <summary>
	/// Services for the prevention or treatment of, or response to injury or illness.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum medicalService : int {
		[Description("A vehicle for conveying the sick or injured to or from a hospital.")]
		[EnumMember(Value = "Ambulance")] 
		[XmlEnum("1")] 
		Ambulance = 1,

		[Description("Disinfection or purification with fumes.")]
		[EnumMember(Value = "Fumigation")] 
		[XmlEnum("2")] 
		Fumigation = 2,

		[Description("A place where a doctor is available to provide medical attention.")]
		[EnumMember(Value = "Doctor")] 
		[XmlEnum("3")] 
		Doctor = 3,

		[Description("The isolation of patients with contagious diseases.")]
		[EnumMember(Value = "Quarantine")] 
		[XmlEnum("4")] 
		Quarantine = 4,

		[Description("A place where substances intended to procure immunity against one or several diseases are administered.")]
		[EnumMember(Value = "Vaccination Centre")] 
		[XmlEnum("5")] 
		VaccinationCentre = 5,
	}

	/// <summary>
	/// Indicates whether a vessel is included or excluded from the regulation/restriction/recommendation/nautical information.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum membership : int {
		[Description("Vessels with these characteristics are included in the regulation/restriction/recommendation/nautical information.")]
		[EnumMember(Value = "Included")] 
		[XmlEnum("1")] 
		Included = 1,

		[Description("Vessels with these characteristics are excluded from the regulation/restriction/recommendation/nautical information.")]
		[EnumMember(Value = "Excluded")] 
		[XmlEnum("2")] 
		Excluded = 2,
	}

	/// <summary>
	/// The process, arrangement or scheme of attachment used to secure a vessel to a berth.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum methodOfSecuring : int {
		[Description("Vessel is secured perpendicular to the wharf with bow to seaward.")]
		[EnumMember(Value = "Bow to Seaward")] 
		[XmlEnum("1")] 
		BowToSeaward = 1,

		[Description("Vessel is secured perpendicular to the wharf with stern to the seaward.")]
		[EnumMember(Value = "Stern to Seaward")] 
		[XmlEnum("2")] 
		SternToSeaward = 2,

		[Description("The vessel is secured perpendicular to the wharf.")]
		[EnumMember(Value = "Mediterranean Mooring")] 
		[XmlEnum("3")] 
		MediterraneanMooring = 3,

		[Description("Mooring method/procedure used during onshore wind conditions without a tug.")]
		[EnumMember(Value = "Baltic Mooring")] 
		[XmlEnum("4")] 
		BalticMooring = 4,

		[Description("Mooring by maneuvering ahead and astern while dropping anchors to secure the vessel with reduced swinging room.")]
		[EnumMember(Value = "Running Mooring")] 
		[XmlEnum("5")] 
		RunningMooring = 5,

		[Description("Mooring by using mainly wind and tide to position the vessel while dropping anchors to secure the vessel with reduced swinging room. Makes limited use of the engine to position the vessel.")]
		[EnumMember(Value = "Standing Mooring")] 
		[XmlEnum("6")] 
		StandingMooring = 6,

		[Description("A mooring structure used by tankers to load and unload in port approaches or in offshore oil and gas fields. The size of the structure can vary between a large mooring buoy and a manned floating structure.")]
		[EnumMember(Value = "Single Point Mooring")] 
		[XmlEnum("7")] 
		SinglePointMooring = 7,

		[Description("A facility where a vessel is usually moored by a combination of the ship’s anchors forward and mooring buoys aft and held on a fixed heading. Also called Conventional Buoy Mooring (CBM).")]
		[EnumMember(Value = "Multi-Buoy Mooring")] 
		[XmlEnum("8")] 
		MultiBuoyMooring = 8,

		[Description("Mooring alongside another vessel.")]
		[EnumMember(Value = "Ship-to-Ship Mooring")] 
		[XmlEnum("9")] 
		ShipToShipMooring = 9,

		[Description("Mooring system supported by a spider buoy.")]
		[EnumMember(Value = "Spider Buoy Mooring")] 
		[XmlEnum("10")] 
		SpiderBuoyMooring = 10,
	}

	/// <summary>
	/// Classification of the type and display level of the name of a feature in an end-user system.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum nameUsage : int {
		[Description("The name is intended to be displayed when the end-user system is set to the default name/text display setting.")]
		[EnumMember(Value = "Default Name Display")] 
		[XmlEnum("1")] 
		DefaultNameDisplay = 1,

		[Description("The name is intended to be displayed when the end-user system is set to an alternate name/text display setting, for example an alternate language.")]
		[EnumMember(Value = "Alternate Name Display")] 
		[XmlEnum("2")] 
		AlternateNameDisplay = 2,

		[Description("The name or text is not intended to be displayed.")]
		[EnumMember(Value = "No Chart Display")] 
		[XmlEnum("3")] 
		NoChartDisplay = 3,
	}

	/// <summary>
	/// Code for function performed by the online resource.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum onlineFunction : int {
		[Description("Online instructions for transferring data from one storage device or system to another.")]
		[EnumMember(Value = "Download")] 
		[XmlEnum("1")] 
		Download = 1,

		[Description("Online instructions for requesting the resource from the provider.")]
		[EnumMember(Value = "Offline Access")] 
		[XmlEnum("3")] 
		OfflineAccess = 3,

		[Description("Online order process for obtaining the resource.")]
		[EnumMember(Value = "Order")] 
		[XmlEnum("4")] 
		Order = 4,

		[Description("To make painstaking investigation or examination.")]
		[EnumMember(Value = "Search")] 
		[XmlEnum("5")] 
		Search = 5,

		[Description("Complete metadata provided.")]
		[EnumMember(Value = "Complete Metadata")] 
		[XmlEnum("6")] 
		CompleteMetadata = 6,

		[Description("Browse graphic provided.")]
		[EnumMember(Value = "Browse Graphic")] 
		[XmlEnum("7")] 
		BrowseGraphic = 7,

		[Description("Online resource upload capability provided.")]
		[EnumMember(Value = "Upload")] 
		[XmlEnum("8")] 
		Upload = 8,

		[Description("Online email service provided.")]
		[EnumMember(Value = "Email Service")] 
		[XmlEnum("9")] 
		EmailService = 9,

		[Description("Online browsing provided.")]
		[EnumMember(Value = "Browsing")] 
		[XmlEnum("10")] 
		Browsing = 10,

		[Description("Online file access provided.")]
		[EnumMember(Value = "File Access")] 
		[XmlEnum("11")] 
		FileAccess = 11,
	}

	/// <summary>
	/// Classification of pilot activity by arrival, departure, or change of pilot. It may also describe the place where the pilot's advice begins, ends, or is transferred to a different pilot.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum pilotMovement : int {
		[Description("The place where vessels not being navigated according to a pilot's instructions pick up a pilot while in transit from sea to a port or constricted waters for future navigation under pilot instructions.")]
		[EnumMember(Value = "Embarkation")] 
		[XmlEnum("1")] 
		Embarkation = 1,

		[Description("The place where vessels being navigated under a pilot's instructions in transit from sea to a port or constricted waters drop the pilot and proceed without being subject to pilot instructions.")]
		[EnumMember(Value = "Disembarkation")] 
		[XmlEnum("2")] 
		Disembarkation = 2,

		[Description("The place where vessels being navigated under a pilot's instructions drop off the pilot and pick up a different pilot for future navigation under pilot's instructions.")]
		[EnumMember(Value = "Pilot Change")] 
		[XmlEnum("3")] 
		PilotChange = 3,
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
	/// Work or maintenance activities whereby vessels or equipment are restored to working order, renovated, or improved in condition.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum repairService : int {
		[Description("The process of neutralizing or reducing to a minimum the magnetic effects the vessel itself exerts on a magnetic compass. It is based on the principle that the magnetic effect of the iron and steel of the vessel can be counterbalanced by means of magnets and soft iron placed near the compass. Also called compass adjustment, compass compensation, or magnetic compensation.")]
		[EnumMember(Value = "Compensation of Magnetic Compass")] 
		[XmlEnum("1")] 
		CompensationOfMagneticCompass = 1,

		[Description("Underwater inspection and repair performed by divers.")]
		[EnumMember(Value = "Diver Service")] 
		[XmlEnum("2")] 
		DiverService = 2,

		[Description("Repairs to eqipment installed on the ship's bridge.")]
		[EnumMember(Value = "Bridge Equipment Repair")] 
		[XmlEnum("3")] 
		BridgeEquipmentRepair = 3,

		[Description("Repair of an engine or machine parts.")]
		[EnumMember(Value = "Engine Repair")] 
		[XmlEnum("4")] 
		EngineRepair = 4,

		[Description("Repair of marine electronic instruments.")]
		[EnumMember(Value = "Electronic Equipment Repair")] 
		[XmlEnum("5")] 
		ElectronicEquipmentRepair = 5,

		[Description("Repairs to the ship's body, frame, or superstructure.")]
		[EnumMember(Value = "Hull Repair")] 
		[XmlEnum("6")] 
		HullRepair = 6,

		[Description("Repairs to equipment used in the act of navigating a ship.")]
		[EnumMember(Value = "Navigational Equipment Repair")] 
		[XmlEnum("7")] 
		NavigationalEquipmentRepair = 7,

		[Description("Repairs to propeller hub and blades.")]
		[EnumMember(Value = "Propeller Repair")] 
		[XmlEnum("8")] 
		PropellerRepair = 8,

		[Description("Repairs to equipment used in salvage operations.")]
		[EnumMember(Value = "Salvage Gear Repair")] 
		[XmlEnum("9")] 
		SalvageGearRepair = 9,

		[Description("Repairs to drive shafts used for transmitting mechanical power and torque to a propeller.")]
		[EnumMember(Value = "Shaft Repair")] 
		[XmlEnum("10")] 
		ShaftRepair = 10,
	}

	/// <summary>
	/// Application of measures to ensure that a vessel is free of disease and disease risks, or issue of completion or exemption certificates for such measures.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum shipSanitationControl : int {
		[Description("Capable of applying measures to ensure that a vessel is free of disease and disease risks, but cannot issue a certificate.")]
		[EnumMember(Value = "Sanitation Measures Only")] 
		[XmlEnum("1")] 
		SanitationMeasuresOnly = 1,

		[Description("The competent authority can issue a Ship Sanitation Control Certificate after satisfactorily completing or supervising the completion of ship sanitation control measures.")]
		[EnumMember(Value = "Issue SSCC")] 
		[XmlEnum("2")] 
		IssueSscc = 2,

		[Description("The competent authority may issue a Ship Sanitation Control Exemption Certificate if it is satisfied that the ship is free of infection and contamination, including vectors and reservoirs.")]
		[EnumMember(Value = "Issue SSCEC")] 
		[XmlEnum("3")] 
		IssueSscec = 3,
	}

	/// <summary>
	/// Type of the source.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum sourceType : int {
		[Description("Treaty, convention, or international agreement; law or regulation issued by a national or other authority.")]
		[EnumMember(Value = "Law or Regulation")] 
		[XmlEnum("1")] 
		LawOrRegulation = 1,

		[Description("Publication not having the force of law, issued by an international organisation or a national or local administration.")]
		[EnumMember(Value = "Official Publication")] 
		[XmlEnum("2")] 
		OfficialPublication = 2,

		[Description("Reported by mariner(s) and confirmed by another source.")]
		[EnumMember(Value = "Mariner Report, Confirmed")] 
		[XmlEnum("7")] 
		MarinerReportConfirmed = 7,

		[Description("Reported by mariner(s) but not confirmed.")]
		[EnumMember(Value = "Mariner Report, Not Confirmed")] 
		[XmlEnum("8")] 
		MarinerReportNotConfirmed = 8,

		[Description("Shipping and other industry publications, including graphics, charts and web sites.")]
		[EnumMember(Value = "Industry Publications and Reports")] 
		[XmlEnum("9")] 
		IndustryPublicationsAndReports = 9,

		[Description("Information obtained from satellite images.")]
		[EnumMember(Value = "Remotely Sensed Images")] 
		[XmlEnum("10")] 
		RemotelySensedImages = 10,

		[Description("Information obtained from photographs.")]
		[EnumMember(Value = "Photographs")] 
		[XmlEnum("11")] 
		Photographs = 11,

		[Description("Information obtained from products issued by Hydrographic Offices.")]
		[EnumMember(Value = "Products Issued by HO Services")] 
		[XmlEnum("12")] 
		ProductsIssuedByHoServices = 12,

		[Description("Information obtained from news media.")]
		[EnumMember(Value = "News Media")] 
		[XmlEnum("13")] 
		NewsMedia = 13,

		[Description("Information obtained from the analysis of traffic data.")]
		[EnumMember(Value = "Traffic Data")] 
		[XmlEnum("14")] 
		TrafficData = 14,
	}

	/// <summary>
	/// Classification of services for the provision of materials, goods, utilities, or personal services to vessels, passengers, or crew.
	/// </summary>
	/// <remarks>
	/// Describes an enumeration or codelist listing specific services.
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supplyService : int {
		[Description("The provision of shoreside electrical power to a ship at berth while its main and auxiliary engines are shut down.")]
		[EnumMember(Value = "Shore Power")] 
		[XmlEnum("1")] 
		ShorePower = 1,

		[Description("Transfer of fuel oil to the fuel compartments of a ship.")]
		[EnumMember(Value = "Fuel Oil Bunkering")] 
		[XmlEnum("2")] 
		FuelOilBunkering = 2,

		[Description("Transfer of liquefied natural gas to the fuel compartments of a ship.")]
		[EnumMember(Value = "LNG Bunkering")] 
		[XmlEnum("3")] 
		LngBunkering = 3,

		[Description("Substances capable of reducing friction, heat, and wear when introduced as a film between solid surfaces.")]
		[EnumMember(Value = "Lubricants")] 
		[XmlEnum("4")] 
		Lubricants = 4,

		[Description("The gas into which water is changed by boiling.")]
		[EnumMember(Value = "Steam")] 
		[XmlEnum("5")] 
		Steam = 5,

		[Description("Water which can be used for drinking and food preparation.")]
		[EnumMember(Value = "Potable Water")] 
		[XmlEnum("6")] 
		PotableWater = 6,

		[Description("A universal hose connection for the supply of water for fighting fires.")]
		[EnumMember(Value = "International Shore Connection")] 
		[XmlEnum("7")] 
		InternationalShoreConnection = 7,

		[Description("A place where food and other such supplies are available.")]
		[EnumMember(Value = "Provisions")] 
		[XmlEnum("8")] 
		Provisions = 8,

		[Description("A dealer in ships' supplies.")]
		[EnumMember(Value = "Chandler")] 
		[XmlEnum("9")] 
		Chandler = 9,

		[Description("A place where mechanical repairs can be undertaken to engines or other vessel equipment.")]
		[EnumMember(Value = "Mechanics Workshop")] 
		[XmlEnum("10")] 
		MechanicsWorkshop = 10,
	}

	/// <summary>
	/// Services for the adjustment of vessel equipment or for assessments pertaining to cargo, compliance with regulations, safety, or security.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum technicalPortService : int {
		[Description("The process of neutralizing or reducing to a minimum the magnetic effects the vessel itself exerts on a magnetic compass. It is based on the principle that the magnetic effect of the iron and steel of the vessel can be counterbalanced by means of magnets and soft iron placed near the compass. Also called compass adjustment, compass compensation, or magnetic compensation.")]
		[EnumMember(Value = "Compensation of Magnetic Compass")] 
		[XmlEnum("1")] 
		CompensationOfMagneticCompass = 1,

		[Description("Neutralization of the strength of the magnetic field of a vessel, by means of suitably arranged electric coils permanently installed in the vessel. See also Degaussing Cable.")]
		[EnumMember(Value = "Degaussing")] 
		[XmlEnum("2")] 
		Degaussing = 2,

		[Description("Inspection, evaluation or monitoring of the quantity, stowage, loading and unloading, and condition of cargo, and the effects of cargoes on vessel stability and safety.")]
		[EnumMember(Value = "Cargo Surveying")] 
		[XmlEnum("3")] 
		CargoSurveying = 3,

		[Description("Assessment of quality and compliance with applicable law, regulations, and safety standards.")]
		[EnumMember(Value = "Vetting")] 
		[XmlEnum("4")] 
		Vetting = 4,
	}

	/// <summary>
	/// Classification of methods of communication over a distance by electrical, electronic, or electromagnetic means.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum telecommunicationService : int {
		[Description("The transfer or exchange of information by using sounds that are being made by mouth and throat when speaking.")]
		[EnumMember(Value = "Voice")] 
		[XmlEnum("1")] 
		Voice = 1,

		[Description("A system of transmitting and reproducing graphic matter (as printing or still pictures) by means of signals sent over telephone lines.")]
		[EnumMember(Value = "Facsimile")] 
		[XmlEnum("2")] 
		Facsimile = 2,

		[Description("Short Message Service is a form of text messaging communication on phones and mobile phones.")]
		[EnumMember(Value = "SMS")] 
		[XmlEnum("3")] 
		Sms = 3,

		[Description("A representation of facts, concepts or instructions in a formalised manner suitable for communication, interpretation or processing.")]
		[EnumMember(Value = "Data")] 
		[XmlEnum("4")] 
		Data = 4,

		[Description("Data that is constantly received by and presented to an end-user while being delivered by a provider.")]
		[EnumMember(Value = "Streamed Data")] 
		[XmlEnum("5")] 
		StreamedData = 5,

		[Description("A system of communication in which messages are sent over long distances by using a telephone system and are printed by using a special machine (called a teletypewriter).")]
		[EnumMember(Value = "Telex")] 
		[XmlEnum("6")] 
		Telex = 6,

		[Description("An apparatus, system or process for communication at a distance by electric transmission over wire.")]
		[EnumMember(Value = "Telegraph")] 
		[XmlEnum("7")] 
		Telegraph = 7,

		[Description("Messages and other data exchanged between individuals using computers in a network.")]
		[EnumMember(Value = "Email")] 
		[XmlEnum("8")] 
		Email = 8,
	}

	/// <summary>
	/// The attribute from which a text string is derived.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum textType : int {
		[Description("The individual name of a feature.")]
		[EnumMember(Value = "Name")] 
		[XmlEnum("1")] 
		Name = 1,
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

		[Description("The datum refers to each Baltic country's realization of the European Vertical Reference System (EVRS) with land-uplift epoch 2000, which is connected to the Normaal Amsterdams Peil (NAP).")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		[XmlEnum("44")] 
		BalticSeaChartDatum2000 = 44,
	}

	/// <summary>
	/// Characteristics of vessels.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[Description("The maximum length of the ship.")]
		[EnumMember(Value = "Length Overall")] 
		[XmlEnum("1")] 
		LengthOverall = 1,

		[Description("The ship's length measured at the waterline.")]
		[EnumMember(Value = "Length at Waterline")] 
		[XmlEnum("2")] 
		LengthAtWaterline = 2,

		[Description("The width or beam of the vessel.")]
		[EnumMember(Value = "Breadth")] 
		[XmlEnum("3")] 
		Breadth = 3,

		[Description("The depth of water necessary to float a vessel fully loaded.")]
		[EnumMember(Value = "Draught")] 
		[XmlEnum("4")] 
		Draught = 4,

		[Description("A measurement of the weight of the vessel, usually used for warships. (Merchant ships are usually measured based on the volume of cargo space; see tonnage). Displacement is expressed either in long tons of 2,240 pounds or metric tonnes of 1,000 kg. Since the two units are very close in size (2,240 pounds = 1,016 kg and 1,000 kg = 2,205 pounds), it is common not to distinguish between them. To preserve secrecy, nations sometimes misstate a warship's displacement.")]
		[EnumMember(Value = "Displacement Tonnage")] 
		[XmlEnum("6")] 
		DisplacementTonnage = 6,

		[Description("The weight of the ship excluding cargo, fuel, ballast, stores, passengers, and crew, but with water in the boilers to steaming level.")]
		[EnumMember(Value = "Displacement Tonnage, Light")] 
		[XmlEnum("7")] 
		DisplacementTonnageLight = 7,

		[Description("The weight of the ship including cargo, passengers, fuel, water, stores, dunnage and such other items necessary for use on a voyage, which brings the vessel down to her load draft.")]
		[EnumMember(Value = "Displacement Tonnage, Loaded")] 
		[XmlEnum("8")] 
		DisplacementTonnageLoaded = 8,

		[Description("The difference between displacement, light and displacement, loaded. A measure of the ship's total carrying capacity.")]
		[EnumMember(Value = "Deadweight Tonnage")] 
		[XmlEnum("9")] 
		DeadweightTonnage = 9,

		[Description("The entire internal cubic capacity of the ship expressed in tons of 100 cubic feet to the ton, except certain spaces with are exempted such as: peak and other tanks for water ballast, open forecastle bridge and poop, access of hatchways, certain light and air spaces, domes of skylights, condenser, anchor gear, steering gear, wheel house, galley and cabin for passengers.")]
		[EnumMember(Value = "Gross Tonnage")] 
		[XmlEnum("10")] 
		GrossTonnage = 10,

		[Description("Obtained from the gross tonnage by deducting crew and navigating spaces and allowances for propulsion machinery.")]
		[EnumMember(Value = "Net Tonnage")] 
		[XmlEnum("11")] 
		NetTonnage = 11,

		[Description("The Panama Canal/Universal Measurement System (PC/UMS) is based on net tonnage, modified for Panama Canal purposes. PC/UMS is based on a mathematical formula to calculate a vessel's total volume; a PC/UMS net ton is equivalent to 100 cubic feet of capacity.")]
		[EnumMember(Value = "Panama Canal/Universal Measurement System Net Tonnage")] 
		[XmlEnum("12")] 
		PanamaCanalUniversalMeasurementSystemNetTonnage = 12,

		[Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("13")] 
		SuezCanalNetTonnage = 13,
	}

	/// <summary>
	/// The unit used for vessel characteristics attribute.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[Description("The basic unit of length in the International System of Units (SI) system.")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[Description("The tonne or metric ton (U.S.), often redundantly referred to as a metric tonne, is a unit of mass equal to 1,000 kg (2,205 lb) or approximately the mass of one cubic metre of water at four degrees Celsius. It is sometimes abbreviated as mt in the United States, but this conflicts with other SI symbols. The tonne is not a unit in the International System of Units (SI), but is accepted for use with the SI. In SI units and prefixes, the tonne is a megagram (Mg). The Imperial and US customary units comparable to the tonne are both spelled ton in English, though they differ in mass. Pronunciation of tonne (the word used in the UK) and ton is usually identical, but is not too confusing unless accuracy is important as the tonne and UK long ton differ by only 1.6.")]
		[EnumMember(Value = "Metric Ton")] 
		[XmlEnum("3")] 
		MetricTon = 3,

		[Description("Long ton (weight ton or imperial ton) is the name for the unit called the \"ton\" in the avoirdupois or Imperial system of measurements, as used in the United Kingdom and several other Commonwealth countries. It has been mostly replaced by the tonne, and in the United States by the short ton. One long ton is equal to 2,240 pounds (1,016 kg) or 35 cubic feet (0.9911 m) of salt water with a density of 64 lb/ft (1.025 g/ml). It has some limited use in the United States, most commonly in measuring the displacement of ships, and was the unit prescribed for warships by the Washington Naval Treaty for example battleships were limited to a mass of 35,000 long tons (36,000 t; 39,000 ST).")]
		[EnumMember(Value = "Ton")] 
		[XmlEnum("4")] 
		Ton = 4,

		[Description("A unit of weight equal to 2,000 pounds (907.18474 kg). In the United States it is often called simply ton without distinguishing it from the metric ton (tonne, 1,000 kilograms) or the long ton (2,240 pounds / 1,016.0469088 kilograms); rather, the other two are specifically noted. There are, however, some US applications for which unspecified tons normally means long tons (for example, Navy ships) or metric tons (world grain production figures). Both the long and short ton are defined as 20 hundredweights, but a hundredweight is 100 pounds (45.359237 kg) in the US system (short or net hundredweight) and 112 pounds (50.80234544 kg) in the Imperial system (long or gross hundredweight).")]
		[EnumMember(Value = "Short Ton")] 
		[XmlEnum("5")] 
		ShortTon = 5,

		[Description("Gross tonnage (GT) is a function of the volume of all ship's enclosed spaces (from keel to funnel) measured to the outside of the hull framing. There is a sliding scale factor. So GT is a kind of capacity-derived index that is used to rank a ship for purposes of determining manning, safety and other statutory requirements and is expressed simply as GT, which is a unitless entity, even though its derivation is tied to the cubic meter unit of volumetric capacity.Tonnage measurements are now governed by an IMO Convention (International Convention on Tonnage Measurement of Ships, 1969 (London-Rules)), which applies to all ships built after July 1982. In accordance with the Convention, the correct term to use now is GT, which is a function of the moulded volume of all enclosed spaces of the ship.")]
		[EnumMember(Value = "Gross Ton")] 
		[XmlEnum("6")] 
		GrossTon = 6,

		[Description("Net tonnage (NT) is based on a calculation of the volume of all cargo spaces of the ship. It indicates a vessels earning space and is a function of the moulded volume of all cargo spaces of the ship.")]
		[EnumMember(Value = "Net Ton")] 
		[XmlEnum("7")] 
		NetTon = 7,

		[Description("The Suez Canal Net Tonnage (SCNT) is derived with a number of modifications from the former net register tonnage of the Moorsom System and was established by the International Commission of Constantinople in its Protocol of 18 December 1873. It is still in use, as amended by the Rules of Navigation of the Suez Canal Authority, and is registered in the Suez Canal Tonnage Certificate.")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("9")] 
		SuezCanalNetTonnage = 9,
	}

	/// <summary>
	/// Service for the reception of residues, polluting substances, refuse, oily wastes, and by-products from ships.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum wasteDisposalService : int {
		[Description("The service with facility to receive oil related waste/residue of the type \"Oily bilge water\" as specified in MARPOL Annex I.")]
		[EnumMember(Value = "MARPOL Annex I Oily Bilge Water")] 
		[XmlEnum("1")] 
		MarpolAnnexIOilyBilgeWater = 1,

		[Description("The service with facility to receive oil related waste/residue of the type \"Oily Residues (sludge)\" as specified in MARPOL Annex I.")]
		[EnumMember(Value = "MARPOL Annex I Oily Residues")] 
		[XmlEnum("2")] 
		MarpolAnnexIOilyResidues = 2,

		[Description("The service with facility to receive oil related waste/residue of the type \"Oily tank washings (slops)\" as specified in MARPOL Annex I.")]
		[EnumMember(Value = "MARPOL Annex I Oily Tank Washings")] 
		[XmlEnum("3")] 
		MarpolAnnexIOilyTankWashings = 3,

		[Description("The service with facility to receive oil related waste/residue of the type \"Dirty ballast water\" as specified in MARPOL Annex I.")]
		[EnumMember(Value = "MARPOL Annex I Dirty Ballast Water")] 
		[XmlEnum("4")] 
		MarpolAnnexIDirtyBallastWater = 4,

		[Description("The service with facility to receive oil related waste/residue of the type \"Scale and sludge from tank cleaning\" as specified in MARPOL Annex I.")]
		[EnumMember(Value = "MARPOL Annex I Scale and Sludge from Tank Cleaning")] 
		[XmlEnum("5")] 
		MarpolAnnexIScaleAndSludgeFromTankCleaning = 5,

		[Description("The service with facility to receive oil related waste/residue of the type \"Other\" as specified in MARPOL Annex I.")]
		[EnumMember(Value = "MARPOL Annex I Other Oily Waste")] 
		[XmlEnum("6")] 
		MarpolAnnexIOtherOilyWaste = 6,

		[Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category X\" as specified in MARPOL Annex II.")]
		[EnumMember(Value = "MARPOL Annex II Category X")] 
		[XmlEnum("7")] 
		MarpolAnnexIiCategoryX = 7,

		[Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category Y\" as specified in MARPOL Annex II.")]
		[EnumMember(Value = "MARPOL Annex II Category Y")] 
		[XmlEnum("8")] 
		MarpolAnnexIiCategoryY = 8,

		[Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Category Z\" as specified in MARPOL Annex II.")]
		[EnumMember(Value = "MARPOL Annex II Category Z")] 
		[XmlEnum("9")] 
		MarpolAnnexIiCategoryZ = 9,

		[Description("The service with facility to receive chemical/Noxious liquid substances related waste/residue of the type \"Other substance\" as specified in MARPOL Annex II.")]
		[EnumMember(Value = "MARPOL Annex II Category OS")] 
		[XmlEnum("10")] 
		MarpolAnnexIiCategoryOs = 10,

		[Description("The service with facility to receive waste/residue of the type \"Sewage\" as specified in MARPOL Annex IV.")]
		[EnumMember(Value = "MARPOL Annex IV Sewage")] 
		[XmlEnum("11")] 
		MarpolAnnexIvSewage = 11,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Plastics\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Plastics")] 
		[XmlEnum("12")] 
		MarpolAnnexVPlastics = 12,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Food wastes\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Food Wastes")] 
		[XmlEnum("13")] 
		MarpolAnnexVFoodWastes = 13,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Domestic wastes\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Domestic Wastes")] 
		[XmlEnum("14")] 
		MarpolAnnexVDomesticWastes = 14,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Cooking oil\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Cooking Oil")] 
		[XmlEnum("15")] 
		MarpolAnnexVCookingOil = 15,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Incinerator ashes\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Incinerator Ashes")] 
		[XmlEnum("16")] 
		MarpolAnnexVIncineratorAshes = 16,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Operational wastes\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Operational Wastes")] 
		[XmlEnum("17")] 
		MarpolAnnexVOperationalWastes = 17,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Animal carcasses\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Animal Carcasses")] 
		[XmlEnum("18")] 
		MarpolAnnexVAnimalCarcasses = 18,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Fishing gear\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Fishing Gear")] 
		[XmlEnum("19")] 
		MarpolAnnexVFishingGear = 19,

		[Description("The service with facility to receive garbage related waste/residue of the type \"E-waste\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V E-Waste")] 
		[XmlEnum("20")] 
		MarpolAnnexVEWaste = 20,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Cargo residues not determined to be harmful to the marine environment\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Cargo Residues - non-HME")] 
		[XmlEnum("21")] 
		MarpolAnnexVCargoResiduesNonHme = 21,

		[Description("The service with facility to receive garbage related waste/residue of the type \"Cargo residues harmful to the marine environment\", as specified in MARPOL Annex V")]
		[EnumMember(Value = "MARPOL Annex V Cargo Residues - HME")] 
		[XmlEnum("22")] 
		MarpolAnnexVCargoResiduesHme = 22,

		[Description("The service with facility to receive air pollution related waste/residue of the type \"Ozone-depleting substances\" as specified in MARPOL Annex VI.")]
		[EnumMember(Value = "MARPOL Annex VI Ozone-Depleting Substances")] 
		[XmlEnum("23")] 
		MarpolAnnexViOzoneDepletingSubstances = 23,

		[Description("The service with facility to receive air pollution related waste/residue of the type \"Exhaust gas-cleaning residues\" as specified in MARPOL Annex VI.")]
		[EnumMember(Value = "MARPOL Annex VI Exhaust Gas-Cleaning Residues")] 
		[XmlEnum("24")] 
		MarpolAnnexViExhaustGasCleaningResidues = 24,
	}

	/// <summary>
	/// The action or activity of a vessel.
	/// </summary>
	/// <remarks>
	/// codeListType=open enumeration; encoding=other: [something]
	/// </remarks>
	[System.Serializable()]
	public class actionOrActivity
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	/// <summary>
	/// The principal subject matter of regulations, restrictions, recommendations or nautical information.
	/// </summary>
	/// <remarks>
	/// codeListType=open enumeration; encoding=other: [something]
	/// </remarks>
	[System.Serializable()]
	public class categoryOfRxN
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	/// <summary>
	/// Classification of vessels by function or use.
	/// </summary>
	/// <remarks>
	/// codeListType=open enumeration; encoding=other: [something]
	/// </remarks>
	[System.Serializable()]
	public class categoryOfVessel
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	/// <summary>
	/// Protective services, law enforcement, or services for responding to sudden danger.
	/// </summary>
	/// <remarks>
	/// codelistType=openEnumeration
	/// </remarks>
	[System.Serializable()]
	public class securitySafetyEmergencyService
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	/// <summary>
	/// Classification of services for the conveyance of persons and/or goods, according to means of transport, nature of path, or representative installation.
	/// </summary>
	/// <remarks>
	/// codelistType=openEnumeration
	/// </remarks>
	[System.Serializable()]
	public class transportConnection
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	public static class CodeList
	{
		public static ImmutableArray<actionOrActivity> actionOrActivities => ImmutableArray.Create<actionOrActivity>(new actionOrActivity[]{
			new() {
				code = 1,
				definition = "Carrying a qualified pilot as part of the vessel navigation team.",
				label = "Navigating With a Pilot",
			},
			new() {
				code = 2,
				definition = "Navigating a vessel into a port.",
				label = "Entering Port",
			},
			new() {
				code = 3,
				definition = "Navigating a vessel out of a port.",
				label = "Leaving Port",
			},
			new() {
				code = 4,
				definition = "Attaching a vessel to a wharf or jetty.",
				label = "Berthing",
			},
			new() {
				code = 5,
				definition = "Detaching a vessel from a wharf or jetty.",
				label = "Slipping",
			},
			new() {
				code = 6,
				definition = "Attaching a vessel to the seabed by means of an anchor and cable.",
				label = "Anchoring",
			},
			new() {
				code = 7,
				definition = "Detaching a vessel from the seabed by recovering an anchor and cable.",
				label = "Weighing Anchor",
			},
			new() {
				code = 8,
				definition = "Navigating a vessel along a route or through a narrow gap, such as under a bridge or through a lock.",
				label = "Transiting",
			},
			new() {
				code = 9,
				definition = "Navigating a vessel past another traveling broadly in the same direction.",
				label = "Overtaking",
			},
			new() {
				code = 10,
				definition = "Providing details such as the name, location or intentions of a vessel.",
				label = "Reporting",
			},
			new() {
				code = 11,
				definition = "Loading or unloading cargo.",
				label = "Working Cargo",
			},
			new() {
				code = 12,
				definition = "Placing crew or passengers on shore.",
				label = "Landing",
			},
			new() {
				code = 13,
				definition = "A signal or message warning of diving activity.",
				label = "Diving",
			},
			new() {
				code = 14,
				definition = "Hunting or catching fish.",
				label = "Fishing",
			},
			new() {
				code = 15,
				definition = "Releasing anything into the sea; often ballast water; or spoil from dredging elsewhere.",
				label = "Discharging Overboard",
			},
			new() {
				code = 16,
				definition = "Navigating a vessel past another travelling broadly in the opposite direction.",
				label = "Passing",
			},
			new() {
				code = 17,
				definition = "Discharge and uptake of ballast water.",
				label = "Ballast Water Exchange",
			},
			new() {
				code = 18,
				definition = "The removal or treatment of biofouling (accumulation of aquatic organisms including microfouling and macrofouling) from a ship's submerged surfaces, including hull and niche areas, conducted either in-water or during dry-docking. The process includes both proactive cleaning (periodic removal of microfouling) and reactive cleaning (removal of micro- and macrofouling as corrective action).",
				label = "Hull Cleaning",
			},
			new() {
				code = 19,
				definition = "The conduct of observational, sampling, or experimental activities by authorised personnel to collect scientific or environmental data, which may involve the deployment of scientific instruments, collection of biological or geological samples, or in-water survey operations.",
				label = "Scientific Research",
			},
			new() {
				code = 20,
				definition = "Organised recreational visitation and leisure activities in marine areas, including sight-seeing, wildlife observation, glass-bottom vessel tours, and guided nature excursions conducted by commercial or permitted operators.",
				label = "Tourism",
			},
			new() {
				code = 21,
				definition = "Structured activities conducted for training, awareness, or interpretive purposes involving groups or individuals learning about the marine environment, including guided educational programs, school activities, and field instruction conducted within designated marine areas.",
				label = "Education",
			},
			new() {
				code = 22,
				definition = "Inspection, repair, or upkeep of existing marine or coastal infrastructure such as wharves, piers, pipelines, moorings, subsea cables, navigational aids, or coastal protection structures, including minor works that do not expand the original footprint.",
				label = "Infrastructure Maintenance",
			},
		});

		public static ImmutableArray<categoryOfRxN> categoryOfRxNS => ImmutableArray.Create<categoryOfRxN>(new categoryOfRxN[]{
			new() {
				code = 1,
				definition = "The process of directing the movement of a craft from one point to another.",
				label = "Navigation",
			},
			new() {
				code = 2,
				definition = "Transmitting and/or receiving electronic communication signals.",
				label = "Communication",
			},
			new() {
				code = 3,
				definition = "Pertaining to environmental protection.",
				label = "Environmental Protection",
			},
			new() {
				code = 4,
				definition = "Pertaining to wildlife protection.",
				label = "Wildlife Protection",
			},
			new() {
				code = 5,
				definition = "Pertaining to security.",
				label = "Security",
			},
			new() {
				code = 6,
				definition = "The agency or establishment for collecting duties, tolls.",
				label = "Customs",
			},
			new() {
				code = 7,
				definition = "Pertaining to cargo operations.",
				label = "Cargo Operation",
			},
			new() {
				code = 8,
				definition = "Pertaining to a place of safety or refuge.",
				label = "Refuge",
			},
			new() {
				code = 9,
				definition = "The authority with responsibility for checking the validity of the health declaration of a vessel and for declaring free pratique.",
				label = "Health",
			},
			new() {
				code = 10,
				definition = "Pertaining to natural resources or exploitation.",
				label = "Natural Resources or Exploitation",
			},
			new() {
				code = 11,
				definition = "Person or corporation, owners of, or entrusted with or invested with the power of managing a port. May be called a Harbour Board, Port Trust, Port Commission, Harbour Commission, Marine Department.",
				label = "Port",
			},
			new() {
				code = 12,
				definition = "An authority with responsibility for the control and movement of money.",
				label = "Finance",
			},
			new() {
				code = 13,
				definition = "The science, art, or practice of cultivating the soil, producing crops, and raising livestock and in varying degrees the preparation and marketing of the resulting products.",
				label = "Agriculture",
			},
		});

		public static ImmutableArray<categoryOfVessel> categoryOfVessels => ImmutableArray.Create<categoryOfVessel>(new categoryOfVessel[]{
			new() {
				code = 1,
				definition = "A vessel which is designed for carrying general cargo, e.g. boxes, sacks.",
				label = "General Cargo Vessel",
			},
			new() {
				code = 2,
				definition = "A vessel designed to carry ISO containers.",
				label = "Container Carrier",
			},
			new() {
				code = 3,
				definition = "A vessel which is designed for carrying liquid goods, for example oil or water.",
				label = "Tanker",
			},
			new() {
				code = 4,
				definition = "A vessel which is designed for carrying bulk goods, e.g. coal, ore or grain.",
				label = "Bulk Carrier",
			},
			new() {
				code = 5,
				definition = "A day trip or cabin vessel constructed and equipped to carry more than 12 passengers.",
				label = "Passenger Vessel",
			},
			new() {
				code = 6,
				definition = "A vessel designed to allow road vehicles to be driven on and off; often a ferry.",
				label = "Roll-On Roll-Off",
			},
			new() {
				code = 7,
				definition = "A vessel designed to carry refrigerated cargo.",
				label = "Refrigerated Cargo Vessel",
			},
			new() {
				code = 8,
				definition = "A vessel that is used and equipped for the fishing of living aquatic resources.",
				label = "Fishing Vessel",
			},
			new() {
				code = 9,
				definition = "A vessel which provides a service such as a tug, anchor handler, survey or supply vessel.",
				label = "Service",
			},
			new() {
				code = 10,
				definition = "A vessel designed for the conduct of military operations.",
				label = "Warship",
			},
			new() {
				code = 11,
				definition = "Either a tug and tow, or any combination of a tug providing propulsion to barges or vessels secured ahead or alongside.",
				label = "Towed or Pushed Composite Unit",
			},
			new() {
				code = 12,
				definition = "A combination of tug(s) and non-powered tow(s).",
				label = "Tug and Tow",
			},
			new() {
				code = 13,
				definition = "A pleasure boat or watercraft, or an excursion vessel used for short cruises such as whale watching.",
				label = "Light Recreational",
			},
			new() {
				code = 14,
				definition = "An installation which is designed to float at all times and which is normally anchored in position when deployed in the offshore gas and oil industry.",
				label = "Semi-Submersible Offshore Installation",
			},
			new() {
				code = 15,
				definition = "An exploration or project installation with legs which can be raised and lowered. The legs are raised when the installation is re-positioned. When stationary the legs are lowered to the sea floor and the working platform is raised clear of the sea surface.",
				label = "Jack-Up Exploration or Project Installation",
			},
			new() {
				code = 16,
				definition = "A vessel designed to carry large quantities of live animals.",
				label = "Livestock Carrier",
			},
			new() {
				code = 17,
				definition = "A vessel used in fishing for pleasure or competition.",
				label = "Sport Fishing",
			},
		});

		public static ImmutableArray<securitySafetyEmergencyService> securitySafetyEmergencyServices => ImmutableArray.Create<securitySafetyEmergencyService>(new securitySafetyEmergencyService[]{
			new() {
				code = 1,
				definition = "Organization keeping watch on shipping and coastal waters according to governmental law; normally the authority with responsibility for search and rescue.",
				label = "Coast Guard",
			},
			new() {
				code = 2,
				definition = "The agency or establishment for collecting duties, tolls.",
				label = "Customs",
			},
			new() {
				code = 3,
				definition = "Office for reporting or obtaining information about sudden dangers to the environment such as spillage of polluting or hazardous substances.",
				label = "Environmental Emergency Information Centre",
			},
			new() {
				code = 4,
				definition = "An office or organisation for reporting or coordinating response to emergencies.",
				label = "Emergency Coordination Centre",
			},
			new() {
				code = 5,
				definition = "A place where a vessel is patrolled by a security service or stored in a secure lockup.",
				label = "Guard and/or Security Service",
			},
			new() {
				code = 6,
				definition = "The authority controlling people entering a country.",
				label = "Immigration",
			},
			new() {
				code = 7,
				definition = "The department of government, or civil force, charged with maintaining public order.",
				label = "Police",
			},
			new() {
				code = 8,
				definition = "A unit responsible for promoting efficient organization of search and rescue services and for coordinating the conduct of search and rescue operations within a search and rescue region.",
				label = "Sea Rescue Control",
			},
		});

		public static ImmutableArray<transportConnection> transportConnections => ImmutableArray.Create<transportConnection>(new transportConnection[]{
			new() {
				code = 2,
				definition = "A small airport for the use of helicopters and some other vertical lift aircraft. Heliports typically contain one or more touchdown and liftoff areas and also have facilities such as fuel or hangars. In some larger towns and cities, customs facilities may also be available.",
				label = "Heliport",
			},
			new() {
				code = 3,
				definition = "A small landing surface for helicopters, with minimal or no supporting installations or facilities.",
				label = "Helipad",
			},
			new() {
				code = 4,
				definition = "Small boat with crew that may be hired for single journeys.",
				label = "Hired Boat",
			},
			new() {
				code = 5,
				definition = "A building where buses and coaches regularly stop to take on and/or let off passengers, especially for long-distance travel.",
				label = "Bus Station",
			},
			new() {
				code = 6,
				definition = "A vessel for transporting passengers, vehicles, and/or goods across a stretch of water, especially as a regular service.",
				label = "Ferry",
			},
			new() {
				code = 8,
				definition = "A limited access dual carriageway road specially designed for fast long-distance traffic and subject to special regulations concerning its use. It may have more than two lanes.",
				label = "Motorway",
			},
			new() {
				code = 9,
				definition = "Large open or half decked boat.",
				label = "Launch",
			},
			new() {
				code = 11,
				definition = "The carriage of goods or passengers using navigable waterways such as canals, rivers, lakes, or other stretch of water that is not part of the sea.",
				label = "Inland Waterway Transport",
			},
			new() {
				code = 12,
				definition = "The carriage of specified types of cargo between qualifying ports. The types of cargo and/or qualifying ports are generally specified by law or government regulation.",
				label = "Short Sea Transportation",
			},
			new() {
				code = 13,
				definition = "Specially designated commercially navigable routes in coastal, inland, and intracoastal waters, frequently as waterborne relievers to congested landside routes.",
				label = "Marine Highway",
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
			public List<String> deliveryPoint {get;set;} = [];

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
			public bool ShouldSerializedeliveryPoint() { return deliveryPoint.Any(); }

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
			[XmlElement("dateStart")]
			[Optional]
			public String? dateStart {get;set;} = default;

			[XmlElement("dateEnd")]
			[Optional]
			public String? dateEnd {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }
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
		/// A pair of frequencies for transmitting and receiving radio signals. The shore station transmits and receives on the frequencies indicated.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair : ComplexType {
			[XmlElement("frequencyShoreStationReceives")]
			[RangeConstraint<int>(0, default, Closure.gtSemiInterval)]
			[Optional]
			public int? frequencyShoreStationReceives {get;set;} = default;

			[XmlElement("frequencyShoreStationTransmits")]
			[RangeConstraint<int>(0, default, Closure.gtSemiInterval)]
			[Mandatory]
			public int frequencyShoreStationTransmits {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<frequencyPair, bool>> _conditionalUnknown = new Dictionary<string,Func<frequencyPair, bool>> {
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
			[PrecisionConstraint(1)]
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
			public List<String> headline {get;set;} = [];

			[XmlElement("language")]
			[Optional]
			public String? language {get;set;} = default;

			[XmlElement("text")]
			[Optional]
			public String? text {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializefileLocator() { return !string.IsNullOrEmpty(fileLocator); }

			public bool ShouldSerializefileReference() { return !string.IsNullOrEmpty(fileReference); }

			public bool ShouldSerializeheadline() { return headline.Any(); }

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

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
		/// Information about online sources from which a resource or data can be obtained.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource : ComplexType {
			[XmlElement("linkage")]
			[Mandatory]
			public String linkage {get;set;} = string.Empty;

			[XmlElement("protocol")]
			[Optional]
			public String? protocol {get;set;} = default;

			[XmlElement("applicationProfile")]
			[Optional]
			public String? applicationProfile {get;set;} = default;

			[XmlElement("nameOfResource")]
			[Optional]
			public String? nameOfResource {get;set;} = default;

			[XmlElement("onlineResourceDescription")]
			[Optional]
			public String? onlineResourceDescription {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,8,9,10,11])]
			[Optional]
			public onlineFunction? onlineFunction {get;set;} = default;

			[XmlElement("protocolRequest")]
			[Optional]
			public String? protocolRequest {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializeprotocol() { return !string.IsNullOrEmpty(protocol); }

			public bool ShouldSerializeapplicationProfile() { return !string.IsNullOrEmpty(applicationProfile); }

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }

			public bool ShouldSerializeonlineResourceDescription() { return !string.IsNullOrEmpty(onlineResourceDescription); }

			public bool ShouldSerializeonlineFunction() { return onlineFunction.HasValue; }

			public bool ShouldSerializeprotocolRequest() { return !string.IsNullOrEmpty(protocolRequest); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("onlineFunction")]
			public SerializableEnumeration<onlineFunction>? onlineFunctionElement { get { return onlineFunction; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<onlineResource, bool>> _conditionalUnknown = new Dictionary<string,Func<onlineResource, bool>> {
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
			[RangeConstraint<double>(0.000, 360.000, Closure.geLtInterval)]
			[PrecisionConstraint(3)]
			[Optional]
			public double? orientationUncertainty {get;set;} = default;

			[XmlElement("orientationValue")]
			[RangeConstraint<double>(0.0, 360.0, Closure.closedInterval)]
			[PrecisionConstraint(1)]
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
			[XmlElement("dateStart")]
			[Mandatory]
			public String dateStart {get;set;} = string.Empty;

			[XmlElement("dateEnd")]
			[Mandatory]
			public String dateEnd {get;set;} = string.Empty;

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
		/// A summary of the impact of the most common types of regulation, restriction, recommendation and nautical information on a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rxNCode : ComplexType {
			[XmlElement("categoryOfRxN")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			[Optional]
			public categoryOfRxN? categoryOfRxN {get;set;} = default;

			[XmlElement("actionOrActivity")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22])]
			[Optional]
			public actionOrActivity? actionOrActivity {get;set;} = default;

			[XmlElement("headline")]
			[Optional]
			public List<String> headline {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializecategoryOfRxN() { return categoryOfRxN != default; }

			public bool ShouldSerializeactionOrActivity() { return actionOrActivity != default; }

			public bool ShouldSerializeheadline() { return headline.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<rxNCode, bool>> _conditionalUnknown = new Dictionary<string,Func<rxNCode, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Information about the source document, publication, or reference from which object data or textual material included or referenced in a dataset are derived.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIndication : ComplexType {
			[XmlIgnore]
			[Optional]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[XmlElement("countryName")]
			[Optional]
			public String? countryName {get;set;} = default;

			[XmlElement("source")]
			[StringLengthConstraint(150)]
			[Optional]
			public String? source {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			[Optional]
			public sourceType? sourceType {get;set;} = default;

			[XmlElement("reportedDate")]
			[Optional]
			public String? reportedDate {get;set;} = default;

			[XmlElement("featureName")]
			[Optional]
			public List<featureName> featureName {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			public bool ShouldSerializefeatureName() { return featureName.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			[JsonIgnore]
			[XmlElement("sourceType")]
			public SerializableEnumeration<sourceType>? sourceTypeElement { get { return sourceType; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<sourceIndication, bool>> _conditionalUnknown = new Dictionary<string,Func<sourceIndication, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The complex attribute describes the period of the hydrographic survey, as the time between its sub-attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surveyDateRange : ComplexType {
			[XmlElement("dateStart")]
			[Optional]
			public String? dateStart {get;set;} = default;

			[XmlElement("dateEnd")]
			[Mandatory]
			public String dateEnd {get;set;} = string.Empty;

			#region ShouldSerialize
			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<surveyDateRange, bool>> _conditionalUnknown = new Dictionary<string,Func<surveyDateRange, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A means or channel of communicating at a distance by electrical or electromagnetic means such as telegraphy, telephony, or broadcasting.
		/// </summary>
		/// <remarks>
		/// If no value is populated for the sub-attribute telecommunication service, this means the service is by voice communication. If no value is populated for the sub-attribute telecommunication carrier, this means the service is by land line communication.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			[XmlElement("telecommunicationIdentifier")]
			[Mandatory]
			public String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlElement("telecommunicationCarrier")]
			[Optional]
			public String? telecommunicationCarrier {get;set;} = default;

			[XmlElement("contactInstructions")]
			[Optional]
			public String? contactInstructions {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Optional]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			public bool ShouldSerializetelecommunicationCarrier() { return !string.IsNullOrEmpty(telecommunicationCarrier); }

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfCommunicationPreference")]
			public SerializableEnumeration<categoryOfCommunicationPreference>? categoryOfCommunicationPreferenceElement { get { return categoryOfCommunicationPreference; } set { } }

			[JsonIgnore]
			[XmlElement("telecommunicationService")]
			public SerializableEnumeration<telecommunicationService>[] telecommunicationServiceElement { get { return [.. telecommunicationService]; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<telecommunications, bool>> _conditionalUnknown = new Dictionary<string,Func<telecommunications, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Textual material, or a pointer to a resource providing textual material. May be accompanied by basic information about its source and relationship to the source.
		/// </summary>
		/// <remarks>
		/// Exactly one of sub-attributes onlineResource or information must be completed in one instance of textContent. Product specifications may restrict the use or content of onlineResource for security. For example, a product specification may forbid populating onlineResource. Product specification authors must consider whether applications using the data product may be prevented from accessing off-system resources by security policies.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textContent : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public categoryOfText? categoryOfText {get;set;} = default;

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];

			[XmlElement("onlineResource")]
			[Optional]
			public onlineResource? onlineResource {get;set;} = default;

			[XmlElement("sourceIndication")]
			[Optional]
			public List<sourceIndication> sourceIndication {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializecategoryOfText() { return categoryOfText.HasValue; }

			public bool ShouldSerializeinformation() { return information.Any(); }

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfText")]
			public SerializableEnumeration<categoryOfText>? categoryOfTextElement { get { return categoryOfText; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<textContent, bool>> _conditionalUnknown = new Dictionary<string,Func<textContent, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The regular weekly operation times of a service or schedule.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalsByDayOfWeek : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			[Multiplicity(0, 7)]
			public List<dayOfWeek> dayOfWeek {get;set;} = [];

			[XmlElement("dayOfWeekIsRange")]
			[Optional]
			public Boolean? dayOfWeekIsRange {get;set;} = default;

			[XmlElement("timeOfDayStart")]
			[Optional]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayStart {get;set;} = [];

			[XmlElement("timeOfDayEnd")]
			[Optional]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayEnd {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializedayOfWeek() { return dayOfWeek.Any(); }

			public bool ShouldSerializedayOfWeekIsRange() { return dayOfWeekIsRange.HasValue; }

			public bool ShouldSerializetimeOfDayStart() { return timeOfDayStart.Any(); }

			public bool ShouldSerializetimeOfDayEnd() { return timeOfDayEnd.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("dayOfWeek")]
			public SerializableEnumeration<dayOfWeek>[] dayOfWeekElement { get { return [.. dayOfWeek]; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<timeIntervalsByDayOfWeek, bool>> _conditionalUnknown = new Dictionary<string,Func<timeIntervalsByDayOfWeek, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Description of Aids to Navigation or prominent marks which are usually clearly visible and identifiable enough to be used in determining location or direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class usefulMarkDescription : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<usefulMarkDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<usefulMarkDescription, bool>> {
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
			[PrecisionConstraint(1)]
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
		/// Combinations of values of measurable characteristics or dimensions of vessels, used to specify size and tonnage ranges.
		/// </summary>
		/// <remarks>
		/// Combines (i) specifications of vessels' measurable characteristics (length, beam, tonnages, etc.), (ii) limit values for the specified characteristics (with units), (iii) arithmetical comparison operators (greater than, etc.), and (iv) logical operators (AND/OR) to define a subset of vessels characterized by the specified ranges. For example, the combination (draught, 10.5, metres, greaterThan) describes "vessels with draught greater than 10.5 metres".
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselMeasurementsSpecification : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			[Mandatory]
			public comparisonOperator comparisonOperator {get;set;}

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,9,10,11,12,13])]
			[Mandatory]
			public vesselsCharacteristics vesselsCharacteristics {get;set;}

			[XmlElement("vesselsCharacteristicsValue")]
			[Mandatory]
			public double vesselsCharacteristicsValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,9])]
			[Mandatory]
			public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;}

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("comparisonOperator")]
			public SerializableEnumeration<comparisonOperator> comparisonOperatorElement { get { return comparisonOperator; } set { } }

			[JsonIgnore]
			[XmlElement("vesselsCharacteristics")]
			public SerializableEnumeration<vesselsCharacteristics> vesselsCharacteristicsElement { get { return vesselsCharacteristics; } set { } }

			[JsonIgnore]
			[XmlElement("vesselsCharacteristicsUnit")]
			public SerializableEnumeration<vesselsCharacteristicsUnit> vesselsCharacteristicsUnitElement { get { return vesselsCharacteristicsUnit; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<vesselMeasurementsSpecification, bool>> _conditionalUnknown = new Dictionary<string,Func<vesselMeasurementsSpecification, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Links for relevant weather related information.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class weatherResource : ComplexType {
			[XmlElement("onlineResource")]
			[Optional]
			public onlineResource? onlineResource {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public dynamicResource? dynamicResource {get;set;} = default;

			[XmlElement("textContent")]
			[Optional]
			public textContent? textContent {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			public bool ShouldSerializedynamicResource() { return dynamicResource.HasValue; }

			public bool ShouldSerializetextContent() { return textContent!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("dynamicResource")]
			public SerializableEnumeration<dynamicResource>? dynamicResourceElement { get { return dynamicResource; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<weatherResource, bool>> _conditionalUnknown = new Dictionary<string,Func<weatherResource, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A bearing is the direction one object is from another object.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class bearingInformation : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			[Optional]
			public cardinalDirection? cardinalDirection {get;set;} = default;

			[XmlElement("distance")]
			[PrecisionConstraint(1)]
			[Optional]
			public double? distance {get;set;} = default;

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];

			[XmlElement("orientation")]
			[Optional]
			public orientation? orientation {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializecardinalDirection() { return cardinalDirection.HasValue; }

			public bool ShouldSerializedistance() { return distance.HasValue; }

			public bool ShouldSerializeinformation() { return information.Any(); }

			public bool ShouldSerializeorientation() { return orientation!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("cardinalDirection")]
			public SerializableEnumeration<cardinalDirection>? cardinalDirectionElement { get { return cardinalDirection; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<bearingInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<bearingInformation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Description of services related to the goods or items carried by vessels.
		/// </summary>
		/// <remarks>
		/// Textual or narrative description of cargo services.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class cargoServicesDescription : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<cargoServicesDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<cargoServicesDescription, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A description of construction or other development in a location where the work will affect vessel operations such as navigation, maneuvering or docking/berthing.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class constructionInformation : ComplexType {
			[XmlElement("fixedDateRange")]
			[Optional]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,5])]
			[Optional]
			public condition? condition {get;set;} = default;

			[XmlElement("development")]
			[Mandatory]
			public String development {get;set;} = string.Empty;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlElement("textContent")]
			[Optional]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<constructionInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<constructionInformation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Textual description of the characteristics and notable matters pertaining to depths in an area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class depthsDescription : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Mandatory]
			public categoryOfDepthsDescription categoryOfDepthsDescription {get;set;}

			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfDepthsDescription")]
			public SerializableEnumeration<categoryOfDepthsDescription> categoryOfDepthsDescriptionElement { get { return categoryOfDepthsDescription; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<depthsDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<depthsDescription, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Textual description of the layout of port facilities.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class facilitiesLayoutDescription : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<facilitiesLayoutDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<facilitiesLayoutDescription, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// General, introductory information about the port.
		/// </summary>
		/// <remarks>
		/// General statement about the port, including social/political aspects, which could have an impact on the mariner’s/company’s safety or professional reputation. The information covered by this should be confined to information not contained in any other place in the data.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class generalPortDescription : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<generalPortDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<generalPortDescription, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Pictorial information such as a photograph, sketch or other graphic, optionally accompanied by descriptive information about the graphic and the location relative to its subject from which it was made.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class graphic : ComplexType {
			[XmlElement("pictorialRepresentation")]
			[Multiplicity(1)]
			public List<String> pictorialRepresentation {get;set;} = [];

			[XmlElement("pictureCaption")]
			[Optional]
			public String? pictureCaption {get;set;} = default;

			[XmlIgnore]
			[Optional]
			public DateOnly? sourceDate {get;set;} = default;

			[XmlElement("pictureInformation")]
			[Optional]
			public String? pictureInformation {get;set;} = default;

			[XmlElement("bearingInformation")]
			[Optional]
			public bearingInformation? bearingInformation {get;set;} = default;

			#region ShouldSerialize
			public bool ShouldSerializepictorialRepresentation() { return pictorialRepresentation.Any(); }

			public bool ShouldSerializepictureCaption() { return !string.IsNullOrEmpty(pictureCaption); }

			public bool ShouldSerializesourceDate() { return sourceDate.HasValue; }

			public bool ShouldSerializepictureInformation() { return !string.IsNullOrEmpty(pictureInformation); }

			public bool ShouldSerializebearingInformation() { return bearingInformation!=default; }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<graphic, bool>> _conditionalUnknown = new Dictionary<string,Func<graphic, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Textual description of selected landmarks that have significance in an area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class landmarkDescription : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<landmarkDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<landmarkDescription, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Description of the area covered by the information specified.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class limitsDescription : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<limitsDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<limitsDescription, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A description of navigationally significant lights essential for marking landfalls, offshore dangers, shipping routes, port access channels or protection of the marine environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class majorLightDescription : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<majorLightDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<majorLightDescription, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Description of the aids to navigation used to mark an area or object.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class markedBy : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<markedBy, bool>> _conditionalUnknown = new Dictionary<string,Func<markedBy, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Description of aids to navigation or prominent marks located away from the shore.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class offshoreMarkDescription : ComplexType {
			[XmlElement("textContent")]
			[Multiplicity(1)]
			public List<textContent> textContent {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<offshoreMarkDescription, bool>> _conditionalUnknown = new Dictionary<string,Func<offshoreMarkDescription, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The nature and timings of a daily schedule by days of the week.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class scheduleByDayOfWeek : ComplexType {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public categoryOfSchedule? categoryOfSchedule {get;set;} = default;

			[XmlElement("text")]
			[Optional]
			public String? text {get;set;} = default;

			[XmlElement("timeIntervalsByDayOfWeek")]
			[Multiplicity(1)]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializecategoryOfSchedule() { return categoryOfSchedule.HasValue; }

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfSchedule")]
			public SerializableEnumeration<categoryOfSchedule>? categoryOfScheduleElement { get { return categoryOfSchedule; } set { } }
			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<scheduleByDayOfWeek, bool>> _conditionalUnknown = new Dictionary<string,Func<scheduleByDayOfWeek, bool>> {
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
		/// General information about the port or harbour area.
		/// </summary>
		/// <remarks>
		/// Describes a collection of information designed to give a general overview of harbour related Information.
		/// </remarks>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class generalHarbourInformation : ComplexType {
			[XmlElement("generalPortDescription")]
			[Optional]
			public generalPortDescription? generalPortDescription {get;set;} = default;

			[XmlElement("facilitiesLayoutDescription")]
			[Optional]
			public facilitiesLayoutDescription? facilitiesLayoutDescription {get;set;} = default;

			[XmlElement("limitsDescription")]
			[Optional]
			public limitsDescription? limitsDescription {get;set;} = default;

			[XmlElement("constructionInformation")]
			[Optional]
			public constructionInformation? constructionInformation {get;set;} = default;

			[XmlElement("cargoServicesDescription")]
			[Optional]
			public cargoServicesDescription? cargoServicesDescription {get;set;} = default;

			[XmlElement("weatherResource")]
			[Optional]
			public List<weatherResource> weatherResource {get;set;} = [];

			#region ShouldSerialize
			public bool ShouldSerializegeneralPortDescription() { return generalPortDescription!=default; }

			public bool ShouldSerializefacilitiesLayoutDescription() { return facilitiesLayoutDescription!=default; }

			public bool ShouldSerializelimitsDescription() { return limitsDescription!=default; }

			public bool ShouldSerializeconstructionInformation() { return constructionInformation!=default; }

			public bool ShouldSerializecargoServicesDescription() { return cargoServicesDescription!=default; }

			public bool ShouldSerializeweatherResource() { return weatherResource.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<generalHarbourInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<generalHarbourInformation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

	}
	public enum Role {
		[Description("A pointer to an Authority object")]
		theAuthority,
		[Description("The authority for which service hours are given")]
		theAuthority_srvHrs,
		[Description("A reference to a feature that supplements or supports the use of the primary feature in an AuxiliaryFacility relationship.")]
		auxiliaryFacility,
		[Description("A pointer to the aggregate in a whole-part relationship.")]
		componentOf,
		[Description("Reference to a whole of the same type as the part feature in the relationship.")]
		constitute,
		[Description("A pointer to an Contact Details object")]
		theContactDetails,
		[Description("The controlling organization or authority for a geographically located service")]
		controlAuthority,
		[Description("Reference to the feature within which locations are demarcated.")]
		demarcatedFeature,
		[Description("Reference to a feature demarcating a location within another feature.")]
		demarcationIndicator,
		[Description("Reference to an information type describing the entrance to a limit area.")]
		entranceReference,
		[Description("Reference to information about the days and times during which a facility operates or may be used.")]
		facilityOperatingHours,
		[Description("Reference to the feature describing a particular instance of physical infrastructure.")]
		hasInfrastructure,
		[Description("Reference to the feature within which the infrastructure is located.")]
		infrastructureLocation,
		[Description("The object or class of objects to which the regulation, restriction, recommendation, or nautical information applies")]
		isApplicableTo,
		[Description("A reference to the diverse units comprising a feature of a different type.")]
		layoutUnit,
		[Description("Reference to a feature demarcating the extent to which a coastal State claims or may claim a specific jurisdiction.")]
		limitExtent,
		[Description("Reference to the feature for which a coastal State claims a specific jurisdiction different from the feature's geographic boundary.")]
		limitReference,
		[Description("Reference to regulation, recommendation, restriction or general information related to an organisation")]
		organisationRelatedRxN,
		[Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.")]
		permission,
		[Description("A reference to the primary feature in an Auxiliaryfacility relationship.")]
		primaryFacility,
		[Description("The work hours for a non-standard workday")]
		partialWorkingDay,
		[Description("Reference to an information object describing services.")]
		serviceDescriptionReference,
		[Description("Service hours for an authority or service provider")]
		theServiceHours,
		[Description("Reference to a part of the same type as the whole feature in the relationship.")]
		subUnit,
		[Description("A pointer to an object that provides more information about the referencing feature or information type.")]
		theInformation,
		[Description("The organisation to which information relates")]
		theOrganisation,
		[Description("A pointer to an information type providing spatial quality information.")]
		theQualityInformation,
		[Description("The regulation, restriction, recommendation, or nautical information")]
		theRxN,
		[Description("The applicable regulation, restriction, recommendation or nautical information")]
		theApplicableRxN,
		[Description("A pointer to a specific cartographically positioned location for text.")]
		theCartographicText,
		[Description("A pointer to a specific feature(s).")]
		thePositionProvider,
		[Description("The usual service hours to which an exception applies")]
		theServiceHours_nsdy,
	}

	namespace InformationAssociations {
		/// <summary>
		/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AdditionalInformation : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AdditionalInformation);
		}

		/// <summary>
		/// Contact information for an authority
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityContact : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AuthorityContact);
		}

		/// <summary>
		/// Service hours for an authority
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityHours : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AuthorityHours);
		}

		/// <summary>
		/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AssociatedRxN : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AssociatedRxN);
		}

		/// <summary>
		/// Exception to the usual working day
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ExceptionalWorkday : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ExceptionalWorkday);
		}

		/// <summary>
		/// The controlling authority for a service area
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceControl : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceControl);
		}

		/// <summary>
		/// Contact details for a service or facility
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceContact : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceContact);
		}

		/// <summary>
		/// Working hours for a service or facility described by a geographic location
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocationHours : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LocationHours);
		}

		/// <summary>
		/// Related organisation
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RelatedOrganisation : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(RelatedOrganisation);
		}

		/// <summary>
		/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InclusionType : InformationAssociation {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			[Mandatory]
			public membership membership {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("membership")]
			public SerializableEnumeration<membership> membershipElement { get { return membership; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InclusionType);
		}

		/// <summary>
		/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PermissionType : InformationAssociation {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			[Mandatory]
			public categoryOfRelationship categoryOfRelationship {get;set;}


			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfRelationship")]
			public SerializableEnumeration<categoryOfRelationship> categoryOfRelationshipElement { get { return categoryOfRelationship; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PermissionType);
		}

		/// <summary>
		/// An association for the binding between a spatial type and its spatial quality information.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialAssociation : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SpatialAssociation);
		}

		/// <summary>
		/// Association between a limit feature and the entrance for the limit.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LimitEntrance : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LimitEntrance);
		}

		/// <summary>
		/// The services available within a location.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceAvailability : InformationAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceAvailability);
		}
	}

	namespace FeatureAssociations {
		/// <summary>
		/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
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
		/// A division of a feature into parts of the same type as the whole.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Subsection : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Subsection);
		}

		/// <summary>
		/// The infrastructure facilities in an area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Infrastructure : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Infrastructure);
		}

		/// <summary>
		/// Describes the relationship between a primary feature and a feature that plays a supporting role in the use of the primary facility by a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PrimaryAuxiliaryFacility : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PrimaryAuxiliaryFacility);
		}

		/// <summary>
		/// Demarcation of location(s) within a feature by relation to another feature or features
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Demarcation : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Demarcation);
		}

		/// <summary>
		/// The limit(s) of a jurisdiction claimed by a coastal State.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class JurisdictionalLimit : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(JurisdictionalLimit);
		}

		/// <summary>
		/// A division of a feature into parts of type(s) different from the type of the whole.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LayoutDivision : FeatureAssociation {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LayoutDivision);
		}
	}

}

namespace S100Framework.DomainModel.S131 {
	using ComplexAttributes;
	using InformationAssociations;
		using System.Xml.Linq;

	namespace InformationTypes {
		/// <summary>
		/// Generalized information type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class InformationType : InformationNode, IInformationBindingDefinition {
			[XmlElement("featureName")]
			[Optional]
			public List<featureName> featureName {get;set;} = [];

			[XmlElement("fixedDateRange")]
			[Optional]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			[XmlElement("periodicDateRange")]
			[Optional]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[XmlElement("graphic")]
			[Optional]
			public List<graphic> graphic {get;set;} = [];

			[XmlElement("sourceIndication")]
			[Optional]
			public List<sourceIndication> sourceIndication {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public bool ShouldSerializegraphic() { return graphic.Any(); }

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(InformationType);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.InformationType._informationBindingDefinitions;
			#endregion

		}

		/// <summary>
		/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class AbstractRxN : InformationType {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			[Optional]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[XmlElement("rxNCode")]
			[Optional]
			public List<rxNCode> rxNCode {get;set;} = [];

			[XmlElement("textContent")]
			[Optional]
			public List<textContent> textContent {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			public bool ShouldSerializerxNCode() { return rxNCode.Any(); }

			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AbstractRxN);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.InformationType._informationBindingDefinitions, ..InformationBindings.AbstractRxN._informationBindingDefinitions];
			#endregion

		}

		/// <summary>
		/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Applicability : InformationType {
			[XmlElement("inBallast")]
			[Optional]
			public Boolean? inBallast {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([2,5,6,7,8,10,11,12,13,14,15])]
			[Optional]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21])]
			[Optional]
			public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo {get;set;} = [];

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			[Optional]
			public categoryOfVessel? categoryOfVessel {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2])]
			[Optional]
			public categoryOfVesselRegistry? categoryOfVesselRegistry {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2])]
			[Optional]
			public logicalConnectives? logicalConnectives {get;set;} = default;

			[XmlElement("thicknessOfIceCapability")]
			[RangeConstraint<int>(0, default, Closure.gtSemiInterval)]
			[Optional]
			public int? thicknessOfIceCapability {get;set;} = default;

			[XmlElement("vesselPerformance")]
			[Optional]
			public String? vesselPerformance {get;set;} = default;

			[XmlElement("destination")]
			[StringLengthConstraint(100)]
			[Optional]
			public String? destination {get;set;} = default;

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];

			[XmlElement("vesselMeasurementsSpecification")]
			[Optional]
			public List<vesselMeasurementsSpecification> vesselMeasurementsSpecification {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeinBallast() { return inBallast.HasValue; }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			public bool ShouldSerializecategoryOfDangerousOrHazardousCargo() { return categoryOfDangerousOrHazardousCargo.Any(); }

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel != default; }

			public bool ShouldSerializecategoryOfVesselRegistry() { return categoryOfVesselRegistry.HasValue; }

			public bool ShouldSerializelogicalConnectives() { return logicalConnectives.HasValue; }

			public bool ShouldSerializethicknessOfIceCapability() { return thicknessOfIceCapability.HasValue; }

			public bool ShouldSerializevesselPerformance() { return !string.IsNullOrEmpty(vesselPerformance); }

			public bool ShouldSerializedestination() { return !string.IsNullOrEmpty(destination); }

			public bool ShouldSerializeinformation() { return information.Any(); }

			public bool ShouldSerializevesselMeasurementsSpecification() { return vesselMeasurementsSpecification.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfDangerousOrHazardousCargo")]
			public SerializableEnumeration<categoryOfDangerousOrHazardousCargo>[] categoryOfDangerousOrHazardousCargoElement { get { return [.. categoryOfDangerousOrHazardousCargo]; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfVesselRegistry")]
			public SerializableEnumeration<categoryOfVesselRegistry>? categoryOfVesselRegistryElement { get { return categoryOfVesselRegistry; } set { } }

			[JsonIgnore]
			[XmlElement("logicalConnectives")]
			public SerializableEnumeration<logicalConnectives>? logicalConnectivesElement { get { return logicalConnectives; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Applicability);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.InformationType._informationBindingDefinitions, ..InformationBindings.Applicability._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Applicability, bool>> _conditionalUnknown = new Dictionary<string,Func<Applicability, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A person or organisation having political or administrative power and control.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Authority : InformationType {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			[Mandatory]
			public categoryOfAuthority categoryOfAuthority {get;set;}

			[XmlElement("textContent")]
			[Optional]
			public textContent? textContent {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializetextContent() { return textContent!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority> categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Authority);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.InformationType._informationBindingDefinitions, ..InformationBindings.Authority._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Authority, bool>> _conditionalUnknown = new Dictionary<string,Func<Authority, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Services that are available for a given port.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AvailablePortServices : InformationType {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public List<firefightingService> firefightingService {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5])]
			[Optional]
			public List<medicalService> medicalService {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			[Optional]
			public List<repairService> repairService {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public List<technicalPortService> technicalPortService {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public List<shipSanitationControl> shipSanitationControl {get;set;} = [];

			[XmlElement("transportConnection")]
			[EnumerationValue([2,3,4,5,6,8,9,11,12,13])]
			[Optional]
			public List<transportConnection> transportConnection {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			[Optional]
			public List<berthingAssistance> berthingAssistance {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public List<cargoService> cargoService {get;set;} = [];

			[XmlElement("securitySafetyEmergencyService")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Optional]
			public List<securitySafetyEmergencyService> securitySafetyEmergencyService {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
			[Optional]
			public List<wasteDisposalService> wasteDisposalService {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			[Optional]
			public List<supplyService> supplyService {get;set;} = [];

			[XmlElement("tugInformation")]
			[Optional]
			public String? tugInformation {get;set;} = default;

			[XmlElement("textContent")]
			[Optional]
			public List<textContent> textContent {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializefirefightingService() { return firefightingService.Any(); }

			public bool ShouldSerializemedicalService() { return medicalService.Any(); }

			public bool ShouldSerializerepairService() { return repairService.Any(); }

			public bool ShouldSerializetechnicalPortService() { return technicalPortService.Any(); }

			public bool ShouldSerializeshipSanitationControl() { return shipSanitationControl.Any(); }

			public bool ShouldSerializetransportConnection() { return transportConnection.Any(); }

			public bool ShouldSerializeberthingAssistance() { return berthingAssistance.Any(); }

			public bool ShouldSerializecargoService() { return cargoService.Any(); }

			public bool ShouldSerializesecuritySafetyEmergencyService() { return securitySafetyEmergencyService.Any(); }

			public bool ShouldSerializewasteDisposalService() { return wasteDisposalService.Any(); }

			public bool ShouldSerializesupplyService() { return supplyService.Any(); }

			public bool ShouldSerializetugInformation() { return !string.IsNullOrEmpty(tugInformation); }

			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("firefightingService")]
			public SerializableEnumeration<firefightingService>[] firefightingServiceElement { get { return [.. firefightingService]; } set { } }

			[JsonIgnore]
			[XmlElement("medicalService")]
			public SerializableEnumeration<medicalService>[] medicalServiceElement { get { return [.. medicalService]; } set { } }

			[JsonIgnore]
			[XmlElement("repairService")]
			public SerializableEnumeration<repairService>[] repairServiceElement { get { return [.. repairService]; } set { } }

			[JsonIgnore]
			[XmlElement("technicalPortService")]
			public SerializableEnumeration<technicalPortService>[] technicalPortServiceElement { get { return [.. technicalPortService]; } set { } }

			[JsonIgnore]
			[XmlElement("shipSanitationControl")]
			public SerializableEnumeration<shipSanitationControl>[] shipSanitationControlElement { get { return [.. shipSanitationControl]; } set { } }

			[JsonIgnore]
			[XmlElement("berthingAssistance")]
			public SerializableEnumeration<berthingAssistance>[] berthingAssistanceElement { get { return [.. berthingAssistance]; } set { } }

			[JsonIgnore]
			[XmlElement("cargoService")]
			public SerializableEnumeration<cargoService>[] cargoServiceElement { get { return [.. cargoService]; } set { } }

			[JsonIgnore]
			[XmlElement("wasteDisposalService")]
			public SerializableEnumeration<wasteDisposalService>[] wasteDisposalServiceElement { get { return [.. wasteDisposalService]; } set { } }

			[JsonIgnore]
			[XmlElement("supplyService")]
			public SerializableEnumeration<supplyService>[] supplyServiceElement { get { return [.. supplyService]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AvailablePortServices);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.InformationType._informationBindingDefinitions, ..InformationBindings.AvailablePortServices._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<AvailablePortServices, bool>> _conditionalUnknown = new Dictionary<string,Func<AvailablePortServices, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContactDetails : InformationType {
			[XmlElement("callName")]
			[Optional]
			public String? callName {get;set;} = default;

			[XmlElement("callSign")]
			[Optional]
			public String? callSign {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			[XmlElement("communicationChannel")]
			[Optional]
			public List<String> communicationChannel {get;set;} = [];

			[XmlElement("contactInstructions")]
			[Optional]
			public String? contactInstructions {get;set;} = default;

			[XmlElement("language")]
			[Optional]
			public List<String> language {get;set;} = [];

			[XmlElement("mMSICode")]
			[Optional]
			public String? mMSICode {get;set;} = default;

			[XmlElement("contactAddress")]
			[Optional]
			public List<contactAddress> contactAddress {get;set;} = [];

			[XmlElement("frequencyPair")]
			[Optional]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];

			[XmlElement("onlineResource")]
			[Optional]
			public List<onlineResource> onlineResource {get;set;} = [];

			[XmlElement("telecommunications")]
			[Optional]
			public List<telecommunications> telecommunications {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecallName() { return !string.IsNullOrEmpty(callName); }

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			public bool ShouldSerializelanguage() { return language.Any(); }

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			public bool ShouldSerializeinformation() { return information.Any(); }

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfCommunicationPreference")]
			public SerializableEnumeration<categoryOfCommunicationPreference>? categoryOfCommunicationPreferenceElement { get { return categoryOfCommunicationPreference; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ContactDetails);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.InformationType._informationBindingDefinitions, ..InformationBindings.ContactDetails._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<ContactDetails, bool>> _conditionalUnknown = new Dictionary<string,Func<ContactDetails, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The seaward end of a channel, harbour, dock, etc.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Entrance : InformationType {
			[XmlElement("entranceDescription")]
			[Optional]
			public String? entranceDescription {get;set;} = default;

			[XmlElement("associatedFeatureName")]
			[Optional]
			public List<String> associatedFeatureName {get;set;} = [];

			[XmlElement("localKnowledgeDescription")]
			[Optional]
			public String? localKnowledgeDescription {get;set;} = default;

			[XmlElement("approachDescription")]
			[Optional]
			public String? approachDescription {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public List<markedBy> markedBy {get;set;} = [];

			[XmlElement("landmarkDescription")]
			[Optional]
			public List<landmarkDescription> landmarkDescription {get;set;} = [];

			[XmlElement("offshoreMarkDescription")]
			[Optional]
			public List<offshoreMarkDescription> offshoreMarkDescription {get;set;} = [];

			[XmlElement("majorLightDescription")]
			[Optional]
			public List<majorLightDescription> majorLightDescription {get;set;} = [];

			[XmlElement("usefulMarkDescription")]
			[Optional]
			public List<usefulMarkDescription> usefulMarkDescription {get;set;} = [];

			[XmlElement("textContent")]
			[Optional]
			public List<textContent> textContent {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeentranceDescription() { return !string.IsNullOrEmpty(entranceDescription); }

			public bool ShouldSerializeassociatedFeatureName() { return associatedFeatureName.Any(); }

			public bool ShouldSerializelocalKnowledgeDescription() { return !string.IsNullOrEmpty(localKnowledgeDescription); }

			public bool ShouldSerializeapproachDescription() { return !string.IsNullOrEmpty(approachDescription); }

			public bool ShouldSerializemarkedBy() { return markedBy.Any(); }

			public bool ShouldSerializelandmarkDescription() { return landmarkDescription.Any(); }

			public bool ShouldSerializeoffshoreMarkDescription() { return offshoreMarkDescription.Any(); }

			public bool ShouldSerializemajorLightDescription() { return majorLightDescription.Any(); }

			public bool ShouldSerializeusefulMarkDescription() { return usefulMarkDescription.Any(); }

			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Entrance);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.InformationType._informationBindingDefinitions, ..InformationBindings.Entrance._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Entrance, bool>> _conditionalUnknown = new Dictionary<string,Func<Entrance, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Nautical information about a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NauticalInformation : AbstractRxN {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NauticalInformation);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.AbstractRxN._informationBindingDefinitions, ..InformationBindings.NauticalInformation._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<NauticalInformation, bool>> _conditionalUnknown = new Dictionary<string,Func<NauticalInformation, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NonStandardWorkingDay : InformationType {
			[XmlElement("dateFixed")]
			[Optional]
			public List<String> dateFixed {get;set;} = [];

			[XmlElement("dateVariable")]
			[Optional]
			public List<String> dateVariable {get;set;} = [];

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializedateFixed() { return dateFixed.Any(); }

			public bool ShouldSerializedateVariable() { return dateVariable.Any(); }

			public bool ShouldSerializeinformation() { return information.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(NonStandardWorkingDay);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.InformationType._informationBindingDefinitions, ..InformationBindings.NonStandardWorkingDay._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<NonStandardWorkingDay, bool>> _conditionalUnknown = new Dictionary<string,Func<NonStandardWorkingDay, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Recommendations for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Recommendations : AbstractRxN {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Recommendations);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.AbstractRxN._informationBindingDefinitions, ..InformationBindings.Recommendations._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Recommendations, bool>> _conditionalUnknown = new Dictionary<string,Func<Recommendations, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Regulations for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Regulations : AbstractRxN {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Regulations);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.AbstractRxN._informationBindingDefinitions, ..InformationBindings.Regulations._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Regulations, bool>> _conditionalUnknown = new Dictionary<string,Func<Regulations, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Restrictions for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Restrictions : AbstractRxN {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Restrictions);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.AbstractRxN._informationBindingDefinitions, ..InformationBindings.Restrictions._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<Restrictions, bool>> _conditionalUnknown = new Dictionary<string,Func<Restrictions, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The time when a service is available and known exceptions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceHours : InformationType {
			[XmlElement("scheduleByDayOfWeek")]
			[Multiplicity(1)]
			public List<scheduleByDayOfWeek> scheduleByDayOfWeek {get;set;} = [];

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek.Any(); }

			public bool ShouldSerializeinformation() { return information.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ServiceHours);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.InformationType._informationBindingDefinitions, ..InformationBindings.ServiceHours._informationBindingDefinitions];
			#endregion

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			#region Validation
			public override bool ConditionalUnknown(string name) => _conditionalUnknown[name](this);

			private IReadOnlyDictionary<string, Func<ServiceHours, bool>> _conditionalUnknown = new Dictionary<string,Func<ServiceHours, bool>> {
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
			public List<spatialAccuracy> spatialAccuracy {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			public bool ShouldSerializespatialAccuracy() { return spatialAccuracy.Any(); }
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SpatialQuality._informationBindingDefinitions;
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
		/// Generalized feature type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FeatureType : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("locationMRN")]
			[Optional]
			public String? locationMRN {get;set;} = default;

			[XmlElement("globalLocationNumber")]
			[StringLengthConstraint(13)]
			[Optional]
			public String? globalLocationNumber {get;set;} = default;

			[XmlElement("interoperabilityIdentifier")]
			[TextPatternConstraint("urn:mrn:.+")]
			[Optional]
			public List<String> interoperabilityIdentifier {get;set;} = [];

			[XmlElement("featureName")]
			[Optional]
			public List<featureName> featureName {get;set;} = [];

			[XmlElement("fixedDateRange")]
			[Optional]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			[XmlElement("periodicDateRange")]
			[Optional]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[XmlElement("rxNCode")]
			[Optional]
			public List<rxNCode> rxNCode {get;set;} = [];

			[XmlElement("graphic")]
			[Optional]
			public List<graphic> graphic {get;set;} = [];

			[XmlElement("sourceIndication")]
			[Optional]
			public List<sourceIndication> sourceIndication {get;set;} = [];

			[XmlElement("textContent")]
			[Optional]
			public List<textContent> textContent {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializelocationMRN() { return !string.IsNullOrEmpty(locationMRN); }

			public bool ShouldSerializeglobalLocationNumber() { return !string.IsNullOrEmpty(globalLocationNumber); }

			public bool ShouldSerializeinteroperabilityIdentifier() { return interoperabilityIdentifier.Any(); }

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			public bool ShouldSerializerxNCode() { return rxNCode.Any(); }

			public bool ShouldSerializegraphic() { return graphic.Any(); }

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }

			public bool ShouldSerializetextContent() { return textContent.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FeatureType);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.FeatureType._informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.FeatureType._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FeatureType._primitives;
			public static Primitives[] _primitives => [
				
			];

			#endregion
		}

		/// <summary>
		/// A feature often associated with contact information for an organization that exercises a management role or offers a service in the location.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class OrganizationContactArea : FeatureType {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(OrganizationContactArea);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.FeatureType._informationBindingDefinitions, ..InformationBindings.OrganizationContactArea._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.FeatureType._featureBindingDefinitions, ..FeatureBindings.OrganizationContactArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..OrganizationContactArea._primitives];
			public new static Primitives[] _primitives => [
				
			];

			#endregion
		}

		/// <summary>
		/// A location which may be supervised by a responsible or controlling authority.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class SupervisedArea : OrganizationContactArea {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SupervisedArea);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.OrganizationContactArea._informationBindingDefinitions, ..InformationBindings.SupervisedArea._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.OrganizationContactArea._featureBindingDefinitions, ..FeatureBindings.SupervisedArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..SupervisedArea._primitives];
			public new static Primitives[] _primitives => [
				
			];

			#endregion
		}

		/// <summary>
		/// The physical installations and facilities that support operations in a port or harbour.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class HarbourPhysicalInfrastructure : SupervisedArea {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(HarbourPhysicalInfrastructure);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.SupervisedArea._informationBindingDefinitions, ..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.SupervisedArea._featureBindingDefinitions, ..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..HarbourPhysicalInfrastructure._primitives];
			public new static Primitives[] _primitives => [
				
			];

			#endregion
		}

		/// <summary>
		/// The spatial arrangement of areas and other types of locations that are designated for specified purposes or otherwise distinguished from other areas and locations.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class Layout : SupervisedArea {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Layout);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.SupervisedArea._informationBindingDefinitions, ..InformationBindings.Layout._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.SupervisedArea._featureBindingDefinitions, ..FeatureBindings.Layout._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..Layout._primitives];
			public new static Primitives[] _primitives => [
				
			];

			#endregion
		}

		/// <summary>
		/// A designated area of water where a vessel, sea plane, etc., may anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorBerth : Layout {
			[XmlIgnore]
			[EnumerationValue([1,2,3,5,6,7,9,10,14])]
			[Optional]
			public List<categoryOfAnchorage> categoryOfAnchorage {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			[Optional]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[XmlElement("radius")]
			[RangeConstraint<double>(0.0, default, Closure.gtSemiInterval)]
			[PrecisionConstraint(1)]
			[Optional]
			public double? radius {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfAnchorage() { return categoryOfAnchorage.Any(); }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			public bool ShouldSerializeradius() { return radius.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfAnchorage")]
			public SerializableEnumeration<categoryOfAnchorage>[] categoryOfAnchorageElement { get { return [.. categoryOfAnchorage]; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AnchorBerth);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.AnchorBerth._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.AnchorBerth._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..AnchorBerth._primitives];
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

			private IReadOnlyDictionary<string, Func<AnchorBerth, bool>> _conditionalUnknown = new Dictionary<string,Func<AnchorBerth, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An area in which vessels or seaplanes anchor or may anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorageArea : Layout {
			[XmlIgnore]
			[EnumerationValue([1,2,3,5,6,7,9,10,14,15])]
			[Optional]
			public List<categoryOfAnchorage> categoryOfAnchorage {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			[Optional]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlElement("depthsDescription")]
			[Optional]
			public depthsDescription? depthsDescription {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public markedBy? markedBy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfAnchorage() { return categoryOfAnchorage.Any(); }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfAnchorage")]
			public SerializableEnumeration<categoryOfAnchorage>[] categoryOfAnchorageElement { get { return [.. categoryOfAnchorage]; } set { } }

			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AnchorageArea);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.AnchorageArea._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.AnchorageArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..AnchorageArea._primitives];
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

			private IReadOnlyDictionary<string, Func<AnchorageArea, bool>> _conditionalUnknown = new Dictionary<string,Func<AnchorageArea, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Equipment with material handling or operational capabilities, characterised by wheeled (including tracked) mobility, and which autonomously moves along a preset route based on environmental markers or external guidance signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AutomatedGuidedVehicle : HarbourPhysicalInfrastructure {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(AutomatedGuidedVehicle);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.AutomatedGuidedVehicle._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.AutomatedGuidedVehicle._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..AutomatedGuidedVehicle._primitives];
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

			private IReadOnlyDictionary<string, Func<AutomatedGuidedVehicle, bool>> _conditionalUnknown = new Dictionary<string,Func<AutomatedGuidedVehicle, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A place, generally named or numbered, where a vessel may moor or anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Berth : Layout {
			[XmlElement("availableBerthingLength")]
			[RangeConstraint<double>(0.0, 10000.0, Closure.closedInterval)]
			[Optional]
			public double? availableBerthingLength {get;set;} = default;

			[XmlElement("bollardDescription")]
			[Optional]
			public String? bollardDescription {get;set;} = default;

			[XmlElement("safeWorkingLoad")]
			[RangeConstraint<double>(0.0, default, Closure.gtSemiInterval)]
			[Optional]
			public double? safeWorkingLoad {get;set;} = default;

			[XmlElement("minimumBerthDepth")]
			[RangeConstraint<double>(0.00, default, Closure.gtSemiInterval)]
			[Optional]
			public double? minimumBerthDepth {get;set;} = default;

			[XmlElement("elevation")]
			[RangeConstraint<double>(0.0, 8850.0, Closure.closedInterval)]
			[Optional]
			public double? elevation {get;set;} = default;

			[XmlElement("cathodicProtectionSystem")]
			[Optional]
			public Boolean? cathodicProtectionSystem {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Optional]
			public categoryOfBerthLocation? categoryOfBerthLocation {get;set;} = default;

			[XmlElement("portFacilityNumber")]
			[Optional]
			public String? portFacilityNumber {get;set;} = default;

			[XmlElement("bollardNumber")]
			[Multiplicity(0, 2)]
			public List<String> bollardNumber {get;set;} = [];

			[XmlElement("gLNExtension")]
			[Optional]
			public String? gLNExtension {get;set;} = default;

			[XmlElement("metreMarkNumber")]
			[Multiplicity(0, 2)]
			public List<String> metreMarkNumber {get;set;} = [];

			[XmlElement("manifoldNumber")]
			[Multiplicity(0, 2)]
			public List<String> manifoldNumber {get;set;} = [];

			[XmlElement("rampNumber")]
			[Optional]
			public String? rampNumber {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			[Optional]
			public methodOfSecuring? methodOfSecuring {get;set;} = default;

			[XmlElement("uNLocationCode")]
			[StringLengthConstraint(20)]
			[Mandatory]
			public String uNLocationCode {get;set;} = string.Empty;

			[XmlElement("terminalIdentifier")]
			[Optional]
			public String? terminalIdentifier {get;set;} = default;

			[XmlElement("shorePowerDescription")]
			[Optional]
			public String? shorePowerDescription {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2])]
			[Optional]
			public List<categoryOfFrequency> categoryOfFrequency {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<categoryOfVoltage> categoryOfVoltage {get;set;} = [];

			[XmlElement("categoryOfPlug")]
			[Optional]
			public List<String> categoryOfPlug {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			[Optional]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeavailableBerthingLength() { return availableBerthingLength.HasValue; }

			public bool ShouldSerializebollardDescription() { return !string.IsNullOrEmpty(bollardDescription); }

			public bool ShouldSerializesafeWorkingLoad() { return safeWorkingLoad.HasValue; }

			public bool ShouldSerializeminimumBerthDepth() { return minimumBerthDepth.HasValue; }

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			public bool ShouldSerializecathodicProtectionSystem() { return cathodicProtectionSystem.HasValue; }

			public bool ShouldSerializecategoryOfBerthLocation() { return categoryOfBerthLocation.HasValue; }

			public bool ShouldSerializeportFacilityNumber() { return !string.IsNullOrEmpty(portFacilityNumber); }

			public bool ShouldSerializebollardNumber() { return bollardNumber.Any(); }

			public bool ShouldSerializegLNExtension() { return !string.IsNullOrEmpty(gLNExtension); }

			public bool ShouldSerializemetreMarkNumber() { return metreMarkNumber.Any(); }

			public bool ShouldSerializemanifoldNumber() { return manifoldNumber.Any(); }

			public bool ShouldSerializerampNumber() { return !string.IsNullOrEmpty(rampNumber); }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializemethodOfSecuring() { return methodOfSecuring.HasValue; }

			public bool ShouldSerializeterminalIdentifier() { return !string.IsNullOrEmpty(terminalIdentifier); }

			public bool ShouldSerializeshorePowerDescription() { return !string.IsNullOrEmpty(shorePowerDescription); }

			public bool ShouldSerializecategoryOfFrequency() { return categoryOfFrequency.Any(); }

			public bool ShouldSerializecategoryOfVoltage() { return categoryOfVoltage.Any(); }

			public bool ShouldSerializecategoryOfPlug() { return categoryOfPlug.Any(); }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfBerthLocation")]
			public SerializableEnumeration<categoryOfBerthLocation>? categoryOfBerthLocationElement { get { return categoryOfBerthLocation; } set { } }

			[JsonIgnore]
			[XmlElement("methodOfSecuring")]
			public SerializableEnumeration<methodOfSecuring>? methodOfSecuringElement { get { return methodOfSecuring; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfFrequency")]
			public SerializableEnumeration<categoryOfFrequency>[] categoryOfFrequencyElement { get { return [.. categoryOfFrequency]; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfVoltage")]
			public SerializableEnumeration<categoryOfVoltage>[] categoryOfVoltageElement { get { return [.. categoryOfVoltage]; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Berth);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.Berth._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.Berth._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..Berth._primitives];
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

			private IReadOnlyDictionary<string, Func<Berth, bool>> _conditionalUnknown = new Dictionary<string,Func<Berth, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A specific position within a berth where a vessel may be moored or anchored.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BerthPosition : Layout {
			[XmlElement("bollardNumber")]
			[Optional]
			public String? bollardNumber {get;set;} = default;

			[XmlElement("gLNExtension")]
			[Optional]
			public String? gLNExtension {get;set;} = default;

			[XmlElement("metreMarkNumber")]
			[Optional]
			public String? metreMarkNumber {get;set;} = default;

			[XmlElement("manifoldNumber")]
			[Optional]
			public String? manifoldNumber {get;set;} = default;

			[XmlElement("rampNumber")]
			[Optional]
			public String? rampNumber {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializebollardNumber() { return !string.IsNullOrEmpty(bollardNumber); }

			public bool ShouldSerializegLNExtension() { return !string.IsNullOrEmpty(gLNExtension); }

			public bool ShouldSerializemetreMarkNumber() { return !string.IsNullOrEmpty(metreMarkNumber); }

			public bool ShouldSerializemanifoldNumber() { return !string.IsNullOrEmpty(manifoldNumber); }

			public bool ShouldSerializerampNumber() { return !string.IsNullOrEmpty(rampNumber); }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(BerthPosition);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.BerthPosition._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.BerthPosition._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..BerthPosition._primitives];
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

			private IReadOnlyDictionary<string, Func<BerthPosition, bool>> _conditionalUnknown = new Dictionary<string,Func<BerthPosition, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Small shaped post, mounted on a wharf or dolphin used to secure ship's lines.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bollard : HarbourPhysicalInfrastructure {
			[XmlElement("height")]
			[RangeConstraint<double>(0.0, default, Closure.gtSemiInterval)]
			[Optional]
			public double? height {get;set;} = default;

			[XmlElement("verticalLength")]
			[RangeConstraint<double>(0.0, default, Closure.gtSemiInterval)]
			[Optional]
			public double? verticalLength {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeheight() { return height.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Bollard);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.Bollard._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.Bollard._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..Bollard._primitives];
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

			private IReadOnlyDictionary<string, Func<Bollard, bool>> _conditionalUnknown = new Dictionary<string,Func<Bollard, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An artificially enclosed area within which ships may moor and which may have gates to regulate water level.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DockArea : Layout {
			[XmlElement("depthsDescription")]
			[Optional]
			public depthsDescription? depthsDescription {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public markedBy? markedBy {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DockArea);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.DockArea._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.DockArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..DockArea._primitives];
			public new static Primitives[] _primitives => [
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

			private IReadOnlyDictionary<string, Func<DockArea, bool>> _conditionalUnknown = new Dictionary<string,Func<DockArea, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An artificial basin fitted with a gate or caisson, into which vessels can be floated and the water pumped out to expose the vessel's bottom. Also called graving dock.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DryDock : HarbourPhysicalInfrastructure {
			[XmlElement("sillDepth")]
			[RangeConstraint<double>(0.0, 100.0, Closure.closedInterval)]
			[Optional]
			public double? sillDepth {get;set;} = default;

			[XmlElement("verticalClearanceValue")]
			[RangeConstraint<double>(0.1, 100.0, Closure.closedInterval)]
			[Optional]
			public double? verticalClearanceValue {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializesillDepth() { return sillDepth.HasValue; }

			public bool ShouldSerializeverticalClearanceValue() { return verticalClearanceValue.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DryDock);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.DryDock._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.DryDock._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..DryDock._primitives];
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

			private IReadOnlyDictionary<string, Func<DryDock, bool>> _conditionalUnknown = new Dictionary<string,Func<DryDock, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A post or group of posts, used for mooring or warping a vessel, or as an aid to navigation. The dolphin may be in the water, on a wharf or on the beach.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Dolphin : HarbourPhysicalInfrastructure {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			[Multiplicity(1)]
			public List<categoryOfDolphin> categoryOfDolphin {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfDolphin() { return categoryOfDolphin.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfDolphin")]
			public SerializableEnumeration<categoryOfDolphin>[] categoryOfDolphinElement { get { return [.. categoryOfDolphin]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Dolphin);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.Dolphin._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.Dolphin._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..Dolphin._primitives];
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

			private IReadOnlyDictionary<string, Func<Dolphin, bool>> _conditionalUnknown = new Dictionary<string,Func<Dolphin, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A sea area where dredged material or other potentially more harmful material, for example explosives, chemical waste, is deliberately deposited.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DumpingGround : Layout {
			[XmlElement("depthsDescription")]
			[Optional]
			public depthsDescription? depthsDescription {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public markedBy? markedBy {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DumpingGround);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.DumpingGround._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.DumpingGround._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..DumpingGround._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.point
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

			private IReadOnlyDictionary<string, Func<DumpingGround, bool>> _conditionalUnknown = new Dictionary<string,Func<DumpingGround, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An imaginary line parallel to a face of a berth or quay which touches the seaward face of the fenders.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FenderLine : Layout {
			[XmlElement("orientation")]
			[Optional]
			public orientation? orientation {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeorientation() { return orientation!=default; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FenderLine);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.FenderLine._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.FenderLine._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..FenderLine._primitives];
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

			private IReadOnlyDictionary<string, Func<FenderLine, bool>> _conditionalUnknown = new Dictionary<string,Func<FenderLine, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A form of dry dock consisting of a floating structure of one or more sections which can be partly submerged by controlled flooding to receive a vessel, then raised by pumping out the water so that the vessel's bottom can be exposed.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FloatingDock : HarbourPhysicalInfrastructure {
			[XmlElement("sillDepth")]
			[RangeConstraint<double>(0.0, 100.0, Closure.closedInterval)]
			[Optional]
			public double? sillDepth {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializesillDepth() { return sillDepth.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(FloatingDock);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.FloatingDock._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.FloatingDock._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..FloatingDock._primitives];
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

			private IReadOnlyDictionary<string, Func<FloatingDock, bool>> _conditionalUnknown = new Dictionary<string,Func<FloatingDock, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A structure in the intertidal zone serving as a support for vessels at low stages of the tide to permit work on the exposed portion of the vessel's hull.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Gridiron : HarbourPhysicalInfrastructure {
			[XmlElement("sillDepth")]
			[RangeConstraint<double>(0.0, 100.0, Closure.closedInterval)]
			[Optional]
			public double? sillDepth {get;set;} = default;

			[XmlElement("verticalClearanceValue")]
			[RangeConstraint<double>(0.1, 100.0, Closure.closedInterval)]
			[Optional]
			public double? verticalClearanceValue {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializesillDepth() { return sillDepth.HasValue; }

			public bool ShouldSerializeverticalClearanceValue() { return verticalClearanceValue.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Gridiron);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.Gridiron._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.Gridiron._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..Gridiron._primitives];
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

			private IReadOnlyDictionary<string, Func<Gridiron, bool>> _conditionalUnknown = new Dictionary<string,Func<Gridiron, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The area over which a harbour authority has jurisdiction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourAreaAdministrative : Layout {
			[XmlElement("uNLocationCode")]
			[StringLengthConstraint(20)]
			[Optional]
			public String? uNLocationCode {get;set;} = default;

			[XmlElement("nationality")]
			[Optional]
			public String? nationality {get;set;} = default;

			[XmlElement("applicableLoadLineZone")]
			[Optional]
			public String? applicableLoadLineZone {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			[Optional]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

			[XmlElement("generalHarbourInformation")]
			[Optional]
			public generalHarbourInformation? generalHarbourInformation {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeuNLocationCode() { return !string.IsNullOrEmpty(uNLocationCode); }

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			public bool ShouldSerializeapplicableLoadLineZone() { return !string.IsNullOrEmpty(applicableLoadLineZone); }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			public bool ShouldSerializecategoryOfHarbourFacility() { return categoryOfHarbourFacility.Any(); }

			public bool ShouldSerializegeneralHarbourInformation() { return generalHarbourInformation!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfHarbourFacility")]
			public SerializableEnumeration<categoryOfHarbourFacility>[] categoryOfHarbourFacilityElement { get { return [.. categoryOfHarbourFacility]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(HarbourAreaAdministrative);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.HarbourAreaAdministrative._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.HarbourAreaAdministrative._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..HarbourAreaAdministrative._primitives];
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

			private IReadOnlyDictionary<string, Func<HarbourAreaAdministrative, bool>> _conditionalUnknown = new Dictionary<string,Func<HarbourAreaAdministrative, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A distinguishable portion of the area over which a harbour authority has jurisdiction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourAreaSection : Layout {
			[XmlIgnore]
			[EnumerationValue([1,3,8,9,11,12])]
			[Optional]
			public categoryOfPortSection? categoryOfPortSection {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([4,5,6,9,14,15,16,17])]
			[Optional]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			[XmlElement("facilitiesLayoutDescription")]
			[Optional]
			public facilitiesLayoutDescription? facilitiesLayoutDescription {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfPortSection() { return categoryOfPortSection.HasValue; }

			public bool ShouldSerializecategoryOfHarbourFacility() { return categoryOfHarbourFacility.Any(); }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			public bool ShouldSerializefacilitiesLayoutDescription() { return facilitiesLayoutDescription!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfPortSection")]
			public SerializableEnumeration<categoryOfPortSection>? categoryOfPortSectionElement { get { return categoryOfPortSection; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfHarbourFacility")]
			public SerializableEnumeration<categoryOfHarbourFacility>[] categoryOfHarbourFacilityElement { get { return [.. categoryOfHarbourFacility]; } set { } }

			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(HarbourAreaSection);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.HarbourAreaSection._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.HarbourAreaSection._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..HarbourAreaSection._primitives];
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

			private IReadOnlyDictionary<string, Func<HarbourAreaSection, bool>> _conditionalUnknown = new Dictionary<string,Func<HarbourAreaSection, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An enclosed area of water surrounded by quay walls constructed to provide means for the transfer of cargos from and to ships.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourBasin : Layout {
			[XmlElement("depthsDescription")]
			[Optional]
			public depthsDescription? depthsDescription {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public markedBy? markedBy {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(HarbourBasin);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.HarbourBasin._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.HarbourBasin._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..HarbourBasin._primitives];
			public new static Primitives[] _primitives => [
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

			private IReadOnlyDictionary<string, Func<HarbourBasin, bool>> _conditionalUnknown = new Dictionary<string,Func<HarbourBasin, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A harbour installation with a service or commercial operation of public interest.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourFacility : HarbourPhysicalInfrastructure {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(HarbourFacility);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.HarbourFacility._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.HarbourFacility._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..HarbourFacility._primitives];
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

			private IReadOnlyDictionary<string, Func<HarbourFacility, bool>> _conditionalUnknown = new Dictionary<string,Func<HarbourFacility, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A wet dock in a waterway, permitting a ship to pass from one level to another.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LockBasin : HarbourPhysicalInfrastructure {
			[XmlElement("sillDepth")]
			[RangeConstraint<double>(0.0, 100.0, Closure.closedInterval)]
			[Optional]
			public double? sillDepth {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializesillDepth() { return sillDepth.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LockBasin);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.LockBasin._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.LockBasin._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..LockBasin._primitives];
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

			private IReadOnlyDictionary<string, Func<LockBasin, bool>> _conditionalUnknown = new Dictionary<string,Func<LockBasin, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A lock basin is divided into several lock basin parts, if this lock basin has one ground level but several gates.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LockBasinPart : HarbourPhysicalInfrastructure {
			[XmlElement("sillDepth")]
			[RangeConstraint<double>(0.0, 100.0, Closure.closedInterval)]
			[Optional]
			public double? sillDepth {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializesillDepth() { return sillDepth.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(LockBasinPart);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.LockBasinPart._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.LockBasinPart._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..LockBasinPart._primitives];
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

			private IReadOnlyDictionary<string, Func<LockBasinPart, bool>> _conditionalUnknown = new Dictionary<string,Func<LockBasinPart, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A buoy secured to the bottom by permanent moorings with means for mooring a vessel by use of its anchor chain or mooring lines.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringBuoy : HarbourPhysicalInfrastructure {
			[XmlElement("maximumPermittedDraught")]
			[RangeConstraint<double>(0.0, 30.0, Closure.gtLeInterval)]
			[PrecisionConstraint(1)]
			[Optional]
			public double? maximumPermittedDraught {get;set;} = default;

			[XmlElement("maximumPermittedVesselLength")]
			[RangeConstraint<double>(0.0, default, Closure.gtSemiInterval)]
			[PrecisionConstraint(1)]
			[Optional]
			public double? maximumPermittedVesselLength {get;set;} = default;

			[XmlElement("verticalLength")]
			[RangeConstraint<double>(0.0, default, Closure.gtSemiInterval)]
			[Optional]
			public double? verticalLength {get;set;} = default;

			[XmlElement("visitorsMooring")]
			[Optional]
			public Boolean? visitorsMooring {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializemaximumPermittedDraught() { return maximumPermittedDraught.HasValue; }

			public bool ShouldSerializemaximumPermittedVesselLength() { return maximumPermittedVesselLength.HasValue; }

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			public bool ShouldSerializevisitorsMooring() { return visitorsMooring.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MooringBuoy);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.MooringBuoy._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.MooringBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..MooringBuoy._primitives];
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
		/// The equipment or structure used to secure a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringWarpingFacility : Layout {
			[XmlIgnore]
			[EnumerationValue([4,5,6])]
			[Mandatory]
			public categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility {get;set;}

			[XmlElement("iDCode")]
			[Mandatory]
			public String iDCode {get;set;} = string.Empty;

			[XmlElement("bollardDescription")]
			[Optional]
			public String? bollardDescription {get;set;} = default;

			[XmlElement("safeWorkingLoad")]
			[RangeConstraint<double>(0.0, default, Closure.gtSemiInterval)]
			[Optional]
			public double? safeWorkingLoad {get;set;} = default;

			[XmlElement("heavingLinesFromShore")]
			[Optional]
			public Boolean? heavingLinesFromShore {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializebollardDescription() { return !string.IsNullOrEmpty(bollardDescription); }

			public bool ShouldSerializesafeWorkingLoad() { return safeWorkingLoad.HasValue; }

			public bool ShouldSerializeheavingLinesFromShore() { return heavingLinesFromShore.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfMooringWarpingFacility")]
			public SerializableEnumeration<categoryOfMooringWarpingFacility> categoryOfMooringWarpingFacilityElement { get { return categoryOfMooringWarpingFacility; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(MooringWarpingFacility);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.MooringWarpingFacility._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.MooringWarpingFacility._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..MooringWarpingFacility._primitives];
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

			private IReadOnlyDictionary<string, Func<MooringWarpingFacility, bool>> _conditionalUnknown = new Dictionary<string,Func<MooringWarpingFacility, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// Facilities or infrastructure providing shore power to berthed vessels.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OnshorePowerFacility : HarbourPhysicalInfrastructure {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public categoryOfShorePowerFacility? categoryOfShorePowerFacility {get;set;} = default;

			[XmlElement("iDCode")]
			[Mandatory]
			public String iDCode {get;set;} = string.Empty;

			[XmlElement("shorePowerDescription")]
			[Optional]
			public String? shorePowerDescription {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			[Optional]
			public List<categoryOfVoltage> categoryOfVoltage {get;set;} = [];

			[XmlIgnore]
			[Optional]
			public List<categoryOfFrequency> categoryOfFrequency {get;set;} = [];

			[XmlElement("categoryOfPlug")]
			[Optional]
			public List<String> categoryOfPlug {get;set;} = [];

			[XmlElement("shorePowerServiceProvider")]
			[Optional]
			public String? shorePowerServiceProvider {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfShorePowerFacility() { return categoryOfShorePowerFacility.HasValue; }

			public bool ShouldSerializeshorePowerDescription() { return !string.IsNullOrEmpty(shorePowerDescription); }

			public bool ShouldSerializecategoryOfVoltage() { return categoryOfVoltage.Any(); }

			public bool ShouldSerializecategoryOfFrequency() { return categoryOfFrequency.Any(); }

			public bool ShouldSerializecategoryOfPlug() { return categoryOfPlug.Any(); }

			public bool ShouldSerializeshorePowerServiceProvider() { return !string.IsNullOrEmpty(shorePowerServiceProvider); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfShorePowerFacility")]
			public SerializableEnumeration<categoryOfShorePowerFacility>? categoryOfShorePowerFacilityElement { get { return categoryOfShorePowerFacility; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfVoltage")]
			public SerializableEnumeration<categoryOfVoltage>[] categoryOfVoltageElement { get { return [.. categoryOfVoltage]; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfFrequency")]
			public SerializableEnumeration<categoryOfFrequency>[] categoryOfFrequencyElement { get { return [.. categoryOfFrequency]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(OnshorePowerFacility);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.OnshorePowerFacility._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.OnshorePowerFacility._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..OnshorePowerFacility._primitives];
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

			private IReadOnlyDictionary<string, Func<OnshorePowerFacility, bool>> _conditionalUnknown = new Dictionary<string,Func<OnshorePowerFacility, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// The extent to which a coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OuterLimit : Layout {
			[XmlElement("limitsDescription")]
			[Optional]
			public limitsDescription? limitsDescription {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public List<markedBy> markedBy {get;set;} = [];

			[XmlElement("landmarkDescription")]
			[Optional]
			public List<landmarkDescription> landmarkDescription {get;set;} = [];

			[XmlElement("offshoreMarkDescription")]
			[Optional]
			public List<offshoreMarkDescription> offshoreMarkDescription {get;set;} = [];

			[XmlElement("majorLightDescription")]
			[Optional]
			public List<majorLightDescription> majorLightDescription {get;set;} = [];

			[XmlElement("usefulMarkDescription")]
			[Optional]
			public List<usefulMarkDescription> usefulMarkDescription {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializelimitsDescription() { return limitsDescription!=default; }

			public bool ShouldSerializemarkedBy() { return markedBy.Any(); }

			public bool ShouldSerializelandmarkDescription() { return landmarkDescription.Any(); }

			public bool ShouldSerializeoffshoreMarkDescription() { return offshoreMarkDescription.Any(); }

			public bool ShouldSerializemajorLightDescription() { return majorLightDescription.Any(); }

			public bool ShouldSerializeusefulMarkDescription() { return usefulMarkDescription.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(OuterLimit);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.OuterLimit._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.OuterLimit._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..OuterLimit._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
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

			private IReadOnlyDictionary<string, Func<OuterLimit, bool>> _conditionalUnknown = new Dictionary<string,Func<OuterLimit, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotBoardingPlace : Layout {
			[XmlElement("depthsDescription")]
			[Optional]
			public depthsDescription? depthsDescription {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Multiplicity(0, 3)]
			public List<pilotMovement> pilotMovement {get;set;} = [];

			[XmlElement("markedBy")]
			[Optional]
			public markedBy? markedBy {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializepilotMovement() { return pilotMovement.Any(); }

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("pilotMovement")]
			public SerializableEnumeration<pilotMovement>[] pilotMovementElement { get { return [.. pilotMovement]; } set { } }

			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(PilotBoardingPlace);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.PilotBoardingPlace._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.PilotBoardingPlace._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..PilotBoardingPlace._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.point
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

			private IReadOnlyDictionary<string, Func<PilotBoardingPlace, bool>> _conditionalUnknown = new Dictionary<string,Func<PilotBoardingPlace, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A designated portion of water for the landing and take-off of seaplanes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeaplaneLandingArea : Layout {
			[XmlElement("depthsDescription")]
			[Optional]
			public depthsDescription? depthsDescription {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public markedBy? markedBy {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(SeaplaneLandingArea);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.SeaplaneLandingArea._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.SeaplaneLandingArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..SeaplaneLandingArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.point
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

			private IReadOnlyDictionary<string, Func<SeaplaneLandingArea, bool>> _conditionalUnknown = new Dictionary<string,Func<SeaplaneLandingArea, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A platform powered by synchronous electric motors (for example syncrolift) used to lift vessels (larger than boats) in and out of the water.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShipLift : HarbourPhysicalInfrastructure {
			[XmlElement("verticalClearanceValue")]
			[RangeConstraint<double>(0.1, 100.0, Closure.closedInterval)]
			[Optional]
			public double? verticalClearanceValue {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeverticalClearanceValue() { return verticalClearanceValue.HasValue; }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(ShipLift);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.ShipLift._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.ShipLift._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..ShipLift._primitives];
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

			private IReadOnlyDictionary<string, Func<ShipLift, bool>> _conditionalUnknown = new Dictionary<string,Func<ShipLift, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A wheeled vehicle designed to lift and carry containers or vessels within its own framework. It is used for moving, and sometimes stacking, shipping containers and vessels.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StraddleCarrier : HarbourPhysicalInfrastructure {

			#region ShouldSerialize

			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(StraddleCarrier);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.HarbourPhysicalInfrastructure._informationBindingDefinitions, ..InformationBindings.StraddleCarrier._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FeatureBindings.StraddleCarrier._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..StraddleCarrier._primitives];
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

			private IReadOnlyDictionary<string, Func<StraddleCarrier, bool>> _conditionalUnknown = new Dictionary<string,Func<StraddleCarrier, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// A terminal covers that area on shore which provides buildings and constructions for the transfer of cargo or passengers from and to ships.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Terminal : Layout {
			[XmlElement("portFacilityNumber")]
			[Optional]
			public String? portFacilityNumber {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,3,7,8,10,11])]
			[Optional]
			public categoryOfTerminal? categoryOfTerminal {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([2,5,6,7,8,10,11,12,13,14,15])]
			[Optional]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,22])]
			[Optional]
			public List<product> product {get;set;} = [];

			[XmlElement("terminalIdentifier")]
			[Optional]
			public String? terminalIdentifier {get;set;} = default;

			[XmlElement("sMDGTerminalCode")]
			[Optional]
			public String? sMDGTerminalCode {get;set;} = default;

			[XmlElement("uNLocationCode")]
			[StringLengthConstraint(20)]
			[Optional]
			public String? uNLocationCode {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializeportFacilityNumber() { return !string.IsNullOrEmpty(portFacilityNumber); }

			public bool ShouldSerializecategoryOfTerminal() { return categoryOfTerminal.HasValue; }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			public bool ShouldSerializeproduct() { return product.Any(); }

			public bool ShouldSerializeterminalIdentifier() { return !string.IsNullOrEmpty(terminalIdentifier); }

			public bool ShouldSerializesMDGTerminalCode() { return !string.IsNullOrEmpty(sMDGTerminalCode); }

			public bool ShouldSerializeuNLocationCode() { return !string.IsNullOrEmpty(uNLocationCode); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfTerminal")]
			public SerializableEnumeration<categoryOfTerminal>? categoryOfTerminalElement { get { return categoryOfTerminal; } set { } }

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }

			[JsonIgnore]
			[XmlElement("product")]
			public SerializableEnumeration<product>[] productElement { get { return [.. product]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(Terminal);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.Terminal._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.Terminal._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..Terminal._primitives];
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

			private IReadOnlyDictionary<string, Func<Terminal, bool>> _conditionalUnknown = new Dictionary<string,Func<Terminal, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An area of water or enlargement of a channel used for turning vessels.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TurningBasin : Layout {
			[XmlElement("depthsDescription")]
			[Optional]
			public depthsDescription? depthsDescription {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public markedBy? markedBy {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			[Optional]
			public iSPSLevel? iSPSLevel {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel>? iSPSLevelElement { get { return iSPSLevel; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TurningBasin);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.TurningBasin._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.TurningBasin._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..TurningBasin._primitives];
			public new static Primitives[] _primitives => [
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

			private IReadOnlyDictionary<string, Func<TurningBasin, bool>> _conditionalUnknown = new Dictionary<string,Func<TurningBasin, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}

		/// <summary>
		/// An area in which uniform general information of the waterway exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WaterwayArea : Layout {
			[XmlIgnore]
			[EnumerationValue([1,3,8,9,11,12])]
			[Mandatory]
			public categoryOfPortSection categoryOfPortSection {get;set;}

			[XmlElement("depthsDescription")]
			[Optional]
			public depthsDescription? depthsDescription {get;set;} = default;

			[XmlElement("locationByText")]
			[Optional]
			public String? locationByText {get;set;} = default;

			[XmlElement("markedBy")]
			[Optional]
			public markedBy? markedBy {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfPortSection")]
			public SerializableEnumeration<categoryOfPortSection> categoryOfPortSectionElement { get { return categoryOfPortSection; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(WaterwayArea);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationBindings.Layout._informationBindingDefinitions, ..InformationBindings.WaterwayArea._informationBindingDefinitions];
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureBindings.Layout._featureBindingDefinitions, ..FeatureBindings.WaterwayArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..WaterwayArea._primitives];
			public new static Primitives[] _primitives => [
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

			private IReadOnlyDictionary<string, Func<WaterwayArea, bool>> _conditionalUnknown = new Dictionary<string,Func<WaterwayArea, bool>> {
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
		public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("maximumDisplayScale")]
			[RangeConstraint<int>(1, default, Closure.geSemiInterval)]
			[Mandatory]
			public int maximumDisplayScale {get;set;} = default;

			[XmlElement("minimumDisplayScale")]
			[RangeConstraint<int>(1, default, Closure.geSemiInterval)]
			[Mandatory]
			public int minimumDisplayScale {get;set;} = default;

			[XmlElement("optimumDisplayScale")]
			[RangeConstraint<int>(1, default, Closure.geSemiInterval)]
			[Optional]
			public int? optimumDisplayScale {get;set;} = default;

			[XmlElement("interoperabilityIdentifier")]
			[TextPatternConstraint("urn:mrn:.+")]
			[Optional]
			public List<String> interoperabilityIdentifier {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeoptimumDisplayScale() { return optimumDisplayScale.HasValue; }

			public bool ShouldSerializeinteroperabilityIdentifier() { return interoperabilityIdentifier.Any(); }
			#endregion

			#region SerializableEnumeration

			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(DataCoverage);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.DataCoverage._informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.DataCoverage._featureBindingDefinitions;

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
		/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfNonBathymetricData : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			[Optional]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			[XmlElement("horizontalDistanceUncertainty")]
			[RangeConstraint<double>(0, default, Closure.geSemiInterval)]
			[PrecisionConstraint(1)]
			[Optional]
			public double? horizontalDistanceUncertainty {get;set;} = default;

			[XmlElement("horizontalPositionUncertainty")]
			[Optional]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			[XmlElement("orientationUncertainty")]
			[RangeConstraint<double>(0.000, 360.000, Closure.geLtInterval)]
			[PrecisionConstraint(3)]
			[Optional]
			public double? orientationUncertainty {get;set;} = default;

			[XmlElement("interoperabilityIdentifier")]
			[TextPatternConstraint("urn:mrn:.+")]
			[Optional]
			public List<String> interoperabilityIdentifier {get;set;} = [];

			[XmlElement("sourceIndication")]
			[Optional]
			public sourceIndication? sourceIndication {get;set;} = default;

			[XmlElement("surveyDateRange")]
			[Optional]
			public surveyDateRange? surveyDateRange {get;set;} = default;

			[XmlElement("verticalUncertainty")]
			[Optional]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializecategoryOfTemporalVariation() { return categoryOfTemporalVariation.HasValue; }

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			public bool ShouldSerializeinteroperabilityIdentifier() { return interoperabilityIdentifier.Any(); }

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }

			public bool ShouldSerializesurveyDateRange() { return surveyDateRange!=default; }

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			public bool ShouldSerializeinformation() { return information.Any(); }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("categoryOfTemporalVariation")]
			public SerializableEnumeration<categoryOfTemporalVariation>? categoryOfTemporalVariationElement { get { return categoryOfTemporalVariation; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(QualityOfNonBathymetricData);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.QualityOfNonBathymetricData._informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.QualityOfNonBathymetricData._featureBindingDefinitions;

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
		/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SoundingDatum : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,19,22,23,24,25,26,27,44])]
			[Mandatory]
			public verticalDatum verticalDatum {get;set;}

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeinformation() { return information.Any(); }
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.SoundingDatum._informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.SoundingDatum._featureBindingDefinitions;

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
		public partial class VerticalDatumOfData : FeatureNode, IFeatureBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([3,13,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			[Mandatory]
			public verticalDatum verticalDatum {get;set;}

			[XmlElement("information")]
			[Optional]
			public List<information> information {get;set;} = [];


			#region ShouldSerialize
			public bool ShouldSerializeinformation() { return information.Any(); }
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
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.VerticalDatumOfData._informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.VerticalDatumOfData._featureBindingDefinitions;

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

		/// <summary>
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("textOffsetBearing")]
			[RangeConstraint<int>(0, 360, Closure.geLtInterval)]
			[Mandatory]
			public int textOffsetBearing {get;set;} = default;

			[XmlElement("textOffsetDistance")]
			[RangeConstraint<int>(0, 50, Closure.gtLeInterval)]
			[Mandatory]
			public int textOffsetDistance {get;set;} = default;

			[XmlElement("textRotation")]
			[Optional]
			public Boolean? textRotation {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1])]
			[Multiplicity(1, 2)]
			public List<textType> textType {get;set;} = [];

			[XmlElement("scaleMinimum")]
			[Optional]
			public int? scaleMinimum {get;set;} = default;


			#region ShouldSerialize
			public bool ShouldSerializetextRotation() { return textRotation.HasValue; }

			public bool ShouldSerializetextType() { return textType.Any(); }

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }
			#endregion

			#region SerializableEnumeration
			[JsonIgnore]
			[XmlElement("textType")]
			public SerializableEnumeration<textType>[] textTypeElement { get { return [.. textType]; } set { } }
			#endregion

			[JsonIgnore]
			[XmlIgnore]
			public override string Code => nameof(TextPlacement);

			#region InformationBindings
			[JsonIgnore]
			[XmlIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationBindings.TextPlacement._informationBindingDefinitions;
			#endregion

			#region IFeatureBindings
			[JsonIgnore]
			[XmlIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureBindings.TextPlacement._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => TextPlacement._primitives;
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

			private IReadOnlyDictionary<string, Func<TextPlacement, bool>> _conditionalUnknown = new Dictionary<string,Func<TextPlacement, bool>> {
			};

			public override void RunValidationChecks() {
			}
			#endregion
		}
	}

	#region InformationBindings
	public static class InformationBindings
	{
		public static class InformationType {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class AbstractRxN {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(InclusionType),
					role = Enum.GetName<Role>(Role.isApplicableTo)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.theOrganisation)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];
		}
		public static class Applicability {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(InclusionType),
					role = Enum.GetName<Role>(Role.theApplicableRxN)!,
					informationTypes = [nameof(AbstractRxN)],
					primitives = [],
				},
			];
		}
		public static class Authority {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.organisationRelatedRxN)!,
					informationTypes = [nameof(AbstractRxN)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class AvailablePortServices {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class ContactDetails {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityContact),
					role = Enum.GetName<Role>(Role.theAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];
		}
		public static class Entrance {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class NauticalInformation {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class NonStandardWorkingDay {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class Recommendations {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class Regulations {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class Restrictions {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class ServiceHours {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ExceptionalWorkday),
					role = Enum.GetName<Role>(Role.partialWorkingDay)!,
					informationTypes = [nameof(NonStandardWorkingDay)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theAuthority_srvHrs)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];
		}
		public static class SpatialQuality {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class FeatureType {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PermissionType),
					role = Enum.GetName<Role>(Role.permission)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AssociatedRxN),
					role = Enum.GetName<Role>(Role.theRxN)!,
					informationTypes = [nameof(AbstractRxN)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
					primitives = [],
				},
			];
		}
		public static class OrganizationContactArea {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
			];
		}
		public static class SupervisedArea {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceControl),
					role = Enum.GetName<Role>(Role.controlAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];
		}
		public static class HarbourPhysicalInfrastructure {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class Layout {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class AnchorBerth {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceAvailability),
					role = Enum.GetName<Role>(Role.serviceDescriptionReference)!,
					informationTypes = [nameof(AvailablePortServices)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class AnchorageArea {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class AutomatedGuidedVehicle {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class Berth {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceAvailability),
					role = Enum.GetName<Role>(Role.serviceDescriptionReference)!,
					informationTypes = [nameof(AvailablePortServices)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class BerthPosition {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class Bollard {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class DockArea {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceAvailability),
					role = Enum.GetName<Role>(Role.serviceDescriptionReference)!,
					informationTypes = [nameof(AvailablePortServices)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class DryDock {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class Dolphin {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class DumpingGround {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class FenderLine {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class FloatingDock {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class Gridiron {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class HarbourAreaAdministrative {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceAvailability),
					role = Enum.GetName<Role>(Role.serviceDescriptionReference)!,
					informationTypes = [nameof(AvailablePortServices)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class HarbourAreaSection {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceAvailability),
					role = Enum.GetName<Role>(Role.serviceDescriptionReference)!,
					informationTypes = [nameof(AvailablePortServices)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class HarbourBasin {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class HarbourFacility {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class LockBasin {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class LockBasinPart {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class MooringBuoy {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class MooringWarpingFacility {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceAvailability),
					role = Enum.GetName<Role>(Role.serviceDescriptionReference)!,
					informationTypes = [nameof(AvailablePortServices)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class OnshorePowerFacility {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class OuterLimit {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LimitEntrance),
					role = Enum.GetName<Role>(Role.entranceReference)!,
					informationTypes = [nameof(Entrance)],
					primitives = [],
				},
			];
		}
		public static class PilotBoardingPlace {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class SeaplaneLandingArea {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class ShipLift {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class StraddleCarrier {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class Terminal {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceAvailability),
					role = Enum.GetName<Role>(Role.serviceDescriptionReference)!,
					informationTypes = [nameof(AvailablePortServices)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class TurningBasin {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class WaterwayArea {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.facilityOperatingHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];
		}
		public static class DataCoverage {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class QualityOfNonBathymetricData {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class SoundingDatum {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class VerticalDatumOfData {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
		public static class TextPlacement {
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
	}

	#endregion

	#region FeatureBindings
	public static class FeatureBindings
	{
		public static class FeatureType {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(FeatureTypes.TextPlacement)],
				},
			];
		}
		public static class OrganizationContactArea {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class SupervisedArea {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class HarbourPhysicalInfrastructure {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.Infrastructure),
					role = Enum.GetName<Role>(Role.infrastructureLocation)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection),nameof(FeatureTypes.Terminal)],
				},
			];
		}
		public static class Layout {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class AnchorBerth {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.PrimaryAuxiliaryFacility),
					role = Enum.GetName<Role>(Role.auxiliaryFacility)!,
					featureTypes = [nameof(FeatureTypes.MooringWarpingFacility)],
				},
			];
		}
		public static class AnchorageArea {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class AutomatedGuidedVehicle {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class Berth {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.Demarcation),
					role = Enum.GetName<Role>(Role.demarcationIndicator)!,
					featureTypes = [nameof(FeatureTypes.BerthPosition)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection),nameof(FeatureTypes.Terminal)],
				},
			];
		}
		public static class BerthPosition {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.Demarcation),
					role = Enum.GetName<Role>(Role.demarcatedFeature)!,
					featureTypes = [nameof(FeatureTypes.Berth)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.PrimaryAuxiliaryFacility),
					role = Enum.GetName<Role>(Role.auxiliaryFacility)!,
					featureTypes = [nameof(FeatureTypes.MooringWarpingFacility)],
				},
			];
		}
		public static class Bollard {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class DockArea {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class DryDock {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class Dolphin {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class DumpingGround {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class FenderLine {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class FloatingDock {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class Gridiron {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class HarbourAreaAdministrative {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.JurisdictionalLimit),
					role = Enum.GetName<Role>(Role.limitExtent)!,
					featureTypes = [nameof(FeatureTypes.OuterLimit)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.layoutUnit)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class HarbourAreaSection {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaAdministrative)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.Subsection),
					role = Enum.GetName<Role>(Role.constitute)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.Subsection),
					role = Enum.GetName<Role>(Role.subUnit)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.Infrastructure),
					role = Enum.GetName<Role>(Role.hasInfrastructure)!,
					featureTypes = [nameof(FeatureTypes.HarbourPhysicalInfrastructure)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.layoutUnit)!,
					featureTypes = [nameof(FeatureTypes.AnchorageArea),nameof(FeatureTypes.Berth),nameof(FeatureTypes.DockArea),nameof(FeatureTypes.DumpingGround),nameof(FeatureTypes.FenderLine),nameof(FeatureTypes.HarbourBasin),nameof(FeatureTypes.PilotBoardingPlace),nameof(FeatureTypes.SeaplaneLandingArea),nameof(FeatureTypes.Terminal),nameof(FeatureTypes.TurningBasin),nameof(FeatureTypes.WaterwayArea)],
				},
			];
		}
		public static class HarbourBasin {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class HarbourFacility {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class LockBasin {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class LockBasinPart {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class MooringBuoy {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class MooringWarpingFacility {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(FeatureAssociations.PrimaryAuxiliaryFacility),
					role = Enum.GetName<Role>(Role.primaryFacility)!,
					featureTypes = [nameof(FeatureTypes.AnchorBerth),nameof(FeatureTypes.BerthPosition)],
				},
			];
		}
		public static class OnshorePowerFacility {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class OuterLimit {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.JurisdictionalLimit),
					role = Enum.GetName<Role>(Role.limitReference)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaAdministrative)],
				},
			];
		}
		public static class PilotBoardingPlace {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class SeaplaneLandingArea {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class ShipLift {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class StraddleCarrier {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class Terminal {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.layoutUnit)!,
					featureTypes = [nameof(FeatureTypes.Berth)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FeatureAssociations.Infrastructure),
					role = Enum.GetName<Role>(Role.hasInfrastructure)!,
					featureTypes = [nameof(FeatureTypes.HarbourPhysicalInfrastructure)],
				},
			];
		}
		public static class TurningBasin {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class WaterwayArea {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(FeatureTypes.HarbourAreaSection)],
				},
			];
		}
		public static class DataCoverage {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class QualityOfNonBathymetricData {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class SoundingDatum {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class VerticalDatumOfData {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
		public static class TextPlacement {
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 1,
					upper =  1,
					association = nameof(FeatureAssociations.TextAssociation),
					role = Enum.GetName<Role>(Role.thePositionProvider)!,
					featureTypes = [nameof(FeatureTypes.FeatureType)],
				},
			];
		}
	}

	#endregion

	[XmlType(Namespace = "http://www.iho.int/S131/2.0")]
	[XmlRoot(Namespace = "http://www.iho.int/S131/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S131/2.0 131_2.0.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S131/2.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.Applicability", typeof(InformationTypes.Applicability), Order = 1, ElementName = "Applicability")]
		[XmlElement("InformationTypes.Authority", typeof(InformationTypes.Authority), Order = 1, ElementName = "Authority")]
		[XmlElement("InformationTypes.AvailablePortServices", typeof(InformationTypes.AvailablePortServices), Order = 1, ElementName = "AvailablePortServices")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.Entrance", typeof(InformationTypes.Entrance), Order = 1, ElementName = "Entrance")]
		[XmlElement("InformationTypes.NauticalInformation", typeof(InformationTypes.NauticalInformation), Order = 1, ElementName = "NauticalInformation")]
		[XmlElement("InformationTypes.NonStandardWorkingDay", typeof(InformationTypes.NonStandardWorkingDay), Order = 1, ElementName = "NonStandardWorkingDay")]
		[XmlElement("InformationTypes.Recommendations", typeof(InformationTypes.Recommendations), Order = 1, ElementName = "Recommendations")]
		[XmlElement("InformationTypes.Regulations", typeof(InformationTypes.Regulations), Order = 1, ElementName = "Regulations")]
		[XmlElement("InformationTypes.Restrictions", typeof(InformationTypes.Restrictions), Order = 1, ElementName = "Restrictions")]
		[XmlElement("InformationTypes.ServiceHours", typeof(InformationTypes.ServiceHours), Order = 1, ElementName = "ServiceHours")]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1, ElementName = "SpatialQuality")]
		[XmlElement("FeatureTypes.AnchorBerth", typeof(FeatureTypes.AnchorBerth), Order = 1, ElementName = "AnchorBerth")]
		[XmlElement("FeatureTypes.AnchorageArea", typeof(FeatureTypes.AnchorageArea), Order = 1, ElementName = "AnchorageArea")]
		[XmlElement("FeatureTypes.AutomatedGuidedVehicle", typeof(FeatureTypes.AutomatedGuidedVehicle), Order = 1, ElementName = "AutomatedGuidedVehicle")]
		[XmlElement("FeatureTypes.Berth", typeof(FeatureTypes.Berth), Order = 1, ElementName = "Berth")]
		[XmlElement("FeatureTypes.BerthPosition", typeof(FeatureTypes.BerthPosition), Order = 1, ElementName = "BerthPosition")]
		[XmlElement("FeatureTypes.Bollard", typeof(FeatureTypes.Bollard), Order = 1, ElementName = "Bollard")]
		[XmlElement("FeatureTypes.DockArea", typeof(FeatureTypes.DockArea), Order = 1, ElementName = "DockArea")]
		[XmlElement("FeatureTypes.DryDock", typeof(FeatureTypes.DryDock), Order = 1, ElementName = "DryDock")]
		[XmlElement("FeatureTypes.Dolphin", typeof(FeatureTypes.Dolphin), Order = 1, ElementName = "Dolphin")]
		[XmlElement("FeatureTypes.DumpingGround", typeof(FeatureTypes.DumpingGround), Order = 1, ElementName = "DumpingGround")]
		[XmlElement("FeatureTypes.FenderLine", typeof(FeatureTypes.FenderLine), Order = 1, ElementName = "FenderLine")]
		[XmlElement("FeatureTypes.FloatingDock", typeof(FeatureTypes.FloatingDock), Order = 1, ElementName = "FloatingDock")]
		[XmlElement("FeatureTypes.Gridiron", typeof(FeatureTypes.Gridiron), Order = 1, ElementName = "Gridiron")]
		[XmlElement("FeatureTypes.HarbourAreaAdministrative", typeof(FeatureTypes.HarbourAreaAdministrative), Order = 1, ElementName = "HarbourAreaAdministrative")]
		[XmlElement("FeatureTypes.HarbourAreaSection", typeof(FeatureTypes.HarbourAreaSection), Order = 1, ElementName = "HarbourAreaSection")]
		[XmlElement("FeatureTypes.HarbourBasin", typeof(FeatureTypes.HarbourBasin), Order = 1, ElementName = "HarbourBasin")]
		[XmlElement("FeatureTypes.HarbourFacility", typeof(FeatureTypes.HarbourFacility), Order = 1, ElementName = "HarbourFacility")]
		[XmlElement("FeatureTypes.LockBasin", typeof(FeatureTypes.LockBasin), Order = 1, ElementName = "LockBasin")]
		[XmlElement("FeatureTypes.LockBasinPart", typeof(FeatureTypes.LockBasinPart), Order = 1, ElementName = "LockBasinPart")]
		[XmlElement("FeatureTypes.MooringBuoy", typeof(FeatureTypes.MooringBuoy), Order = 1, ElementName = "MooringBuoy")]
		[XmlElement("FeatureTypes.MooringWarpingFacility", typeof(FeatureTypes.MooringWarpingFacility), Order = 1, ElementName = "MooringWarpingFacility")]
		[XmlElement("FeatureTypes.OnshorePowerFacility", typeof(FeatureTypes.OnshorePowerFacility), Order = 1, ElementName = "OnshorePowerFacility")]
		[XmlElement("FeatureTypes.OuterLimit", typeof(FeatureTypes.OuterLimit), Order = 1, ElementName = "OuterLimit")]
		[XmlElement("FeatureTypes.PilotBoardingPlace", typeof(FeatureTypes.PilotBoardingPlace), Order = 1, ElementName = "PilotBoardingPlace")]
		[XmlElement("FeatureTypes.SeaplaneLandingArea", typeof(FeatureTypes.SeaplaneLandingArea), Order = 1, ElementName = "SeaplaneLandingArea")]
		[XmlElement("FeatureTypes.ShipLift", typeof(FeatureTypes.ShipLift), Order = 1, ElementName = "ShipLift")]
		[XmlElement("FeatureTypes.StraddleCarrier", typeof(FeatureTypes.StraddleCarrier), Order = 1, ElementName = "StraddleCarrier")]
		[XmlElement("FeatureTypes.Terminal", typeof(FeatureTypes.Terminal), Order = 1, ElementName = "Terminal")]
		[XmlElement("FeatureTypes.TurningBasin", typeof(FeatureTypes.TurningBasin), Order = 1, ElementName = "TurningBasin")]
		[XmlElement("FeatureTypes.WaterwayArea", typeof(FeatureTypes.WaterwayArea), Order = 1, ElementName = "WaterwayArea")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.QualityOfNonBathymetricData", typeof(FeatureTypes.QualityOfNonBathymetricData), Order = 1, ElementName = "QualityOfNonBathymetricData")]
		[XmlElement("FeatureTypes.SoundingDatum", typeof(FeatureTypes.SoundingDatum), Order = 1, ElementName = "SoundingDatum")]
		[XmlElement("FeatureTypes.VerticalDatumOfData", typeof(FeatureTypes.VerticalDatumOfData), Order = 1, ElementName = "VerticalDatumOfData")]
		[XmlElement("FeatureTypes.TextPlacement", typeof(FeatureTypes.TextPlacement), Order = 1, ElementName = "TextPlacement")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
