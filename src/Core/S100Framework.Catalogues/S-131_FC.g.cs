using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S131 {
	public static class Summary
	{
		public static Version Version => new Version("1.0.0");
		public static string[] ComplexTypes => ["bearingInformation","cargoServicesDescription","constructionInformation","contactAddress","depthsDescription","facilitiesLayoutDescription","featureName","fixedDateRange","frequencyPair","generalHarbourInformation","generalPortDescription","graphic","horizontalPositionUncertainty","information","landmarkDescription","limitsDescription","majorLightDescription","markedBy","offshoreMarkDescription","onlineResource","orientation","periodicDateRange","rxNCode","scheduleByDayOfWeek","spatialAccuracy","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","usefulMarkDescription","verticalUncertainty","vesselsMeasurements","weatherResource"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AuthorityContact","AuthorityHours","AssociatedRxN","ExceptionalWorkday","ServiceControl","ServiceContact","LocationHours","RelatedOrganisation","InclusionType","PermissionType","SpatialAssociation","LimitEntrance","ServiceAvailability"];
		public static string[] FeatureAssociationTypes => ["TextAssociation","Subsection","Infrastructure","PrimaryAuxiliaryFacility","Demarcation","JurisdictionalLimit","LayoutDivision"];
		public static string[] InformationTypes => ["Applicability","Authority","AvailablePortServices","ContactDetails","Entrance","NauticalInformation","NonStandardWorkingDay","Recommendations","Regulations","Restrictions","ServiceHours","SpatialQuality"];
		public static string[] FeatureTypes => ["AnchorBerth","AnchorageArea","Berth","BerthPosition","DockArea","DryDock","DumpingGround","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourBasin","HarbourFacility","MooringWarpingFacility","OuterLimit","PilotBoardingPlace","SeaplaneLandingArea","Terminal","TurningBasin","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","SoundingDatum","VerticalDatumOfData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType","OrganizationContactArea","SupervisedArea","Layout"],
			Primitives.point => ["HarbourPhysicalInfrastructure","AnchorBerth","AnchorageArea","Berth","BerthPosition","DryDock","DumpingGround","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourFacility","MooringWarpingFacility","PilotBoardingPlace","SeaplaneLandingArea","Terminal","TextPlacement"],
			Primitives.surface => ["HarbourPhysicalInfrastructure","AnchorBerth","AnchorageArea","Berth","DockArea","DryDock","DumpingGround","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourBasin","HarbourFacility","OuterLimit","PilotBoardingPlace","SeaplaneLandingArea","Terminal","TurningBasin","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","SoundingDatum","VerticalDatumOfData"],
			Primitives.curve => ["Berth","OuterLimit"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"FeatureType" => [Primitives.noGeometry],
			"OrganizationContactArea" => [Primitives.noGeometry],
			"SupervisedArea" => [Primitives.noGeometry],
			"HarbourPhysicalInfrastructure" => [Primitives.point,Primitives.surface],
			"Layout" => [Primitives.noGeometry],
			"AnchorBerth" => [Primitives.point,Primitives.surface],
			"AnchorageArea" => [Primitives.point,Primitives.surface],
			"Berth" => [Primitives.point,Primitives.curve,Primitives.surface],
			"BerthPosition" => [Primitives.point],
			"DockArea" => [Primitives.surface],
			"DryDock" => [Primitives.point,Primitives.surface],
			"DumpingGround" => [Primitives.surface,Primitives.point],
			"FloatingDock" => [Primitives.point,Primitives.surface],
			"Gridiron" => [Primitives.point,Primitives.surface],
			"HarbourAreaAdministrative" => [Primitives.point,Primitives.surface],
			"HarbourAreaSection" => [Primitives.point,Primitives.surface],
			"HarbourBasin" => [Primitives.surface],
			"HarbourFacility" => [Primitives.point,Primitives.surface],
			"MooringWarpingFacility" => [Primitives.point],
			"OuterLimit" => [Primitives.curve,Primitives.surface],
			"PilotBoardingPlace" => [Primitives.surface,Primitives.point],
			"SeaplaneLandingArea" => [Primitives.surface,Primitives.point],
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
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum berthingAssistance : int {
		[System.ComponentModel.Description("InformationAboutAssistanceOrArrangementsForAServiceRelatedToBerthingOperations")]
		[EnumMember(Value = "Berthing Information")] 
		[XmlEnum("1")] 
		BerthingInformation = 1,

		[System.ComponentModel.Description("PersonnelSpecializingInTheMooringAndUnmooringOfVessels")]
		[EnumMember(Value = "Line Personnel")] 
		[XmlEnum("2")] 
		LinePersonnel = 2,

		[System.ComponentModel.Description("ABoatWhichAssistsTheSecurementOfAVesselToABerthOrMooringWithRopesOrAnchor")]
		[EnumMember(Value = "Mooring Boat")] 
		[XmlEnum("3")] 
		MooringBoat = 3,

		[System.ComponentModel.Description("ALocomotiveForMovingVessels")]
		[EnumMember(Value = "Mule")] 
		[XmlEnum("4")] 
		Mule = 4,

		[System.ComponentModel.Description("APowerfulSmallBoatDesignedToPullOrPushLargerShipsOrPowerlessBarges")]
		[EnumMember(Value = "Tugboat")] 
		[XmlEnum("5")] 
		Tugboat = 5,

		[System.ComponentModel.Description("AShipEquippedToMakeAndMaintainAChannelThroughIce")]
		[EnumMember(Value = "Icebreaking Ship")] 
		[XmlEnum("6")] 
		IcebreakingShip = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalDirection : int {
		[System.ComponentModel.Description("three487501125DegreesTrueNorth")]
		[EnumMember(Value = "North")] 
		[XmlEnum("1")] 
		North = 1,

		[System.ComponentModel.Description("zero1125zero3375Degrees")]
		[EnumMember(Value = "North Northeast")] 
		[XmlEnum("2")] 
		NorthNortheast = 2,

		[System.ComponentModel.Description("zero3375zero5625Degrees")]
		[EnumMember(Value = "Northeast")] 
		[XmlEnum("3")] 
		Northeast = 3,

		[System.ComponentModel.Description("zero5625zero7875Degrees")]
		[EnumMember(Value = "East Northeast")] 
		[XmlEnum("4")] 
		EastNortheast = 4,

		[System.ComponentModel.Description("zero78751zero125Degrees")]
		[EnumMember(Value = "East")] 
		[XmlEnum("5")] 
		East = 5,

		[System.ComponentModel.Description("one0one25one2375Degrees")]
		[EnumMember(Value = "East Southeast")] 
		[XmlEnum("6")] 
		EastSoutheast = 6,

		[System.ComponentModel.Description("one2375one4625Degrees")]
		[EnumMember(Value = "Southeast")] 
		[XmlEnum("7")] 
		Southeast = 7,

		[System.ComponentModel.Description("one4625one6875Degrees")]
		[EnumMember(Value = "South Southeast")] 
		[XmlEnum("8")] 
		SouthSoutheast = 8,

		[System.ComponentModel.Description("one6875one9one25Degrees")]
		[EnumMember(Value = "South")] 
		[XmlEnum("9")] 
		South = 9,

		[System.ComponentModel.Description("one9one252one375Degrees")]
		[EnumMember(Value = "South Southwest")] 
		[XmlEnum("10")] 
		SouthSouthwest = 10,

		[System.ComponentModel.Description("two1375two36two5Degrees")]
		[EnumMember(Value = "Southwest")] 
		[XmlEnum("11")] 
		Southwest = 11,

		[System.ComponentModel.Description("two36two5two5875Degrees")]
		[EnumMember(Value = "West Southwest")] 
		[XmlEnum("12")] 
		WestSouthwest = 12,

		[System.ComponentModel.Description("two5875two81two5Degrees")]
		[EnumMember(Value = "West")] 
		[XmlEnum("13")] 
		West = 13,

		[System.ComponentModel.Description("two81two530375Degrees")]
		[EnumMember(Value = "West Northwest")] 
		[XmlEnum("14")] 
		WestNorthwest = 14,

		[System.ComponentModel.Description("three0three75three2625Degrees")]
		[EnumMember(Value = "Northwest")] 
		[XmlEnum("15")] 
		Northwest = 15,

		[System.ComponentModel.Description("three2625three4875Degrees")]
		[EnumMember(Value = "North Northwest")] 
		[XmlEnum("16")] 
		NorthNorthwest = 16,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cargoService : int {
		[System.ComponentModel.Description("TheLoadingUnloadingMovingOrHandlingOfCargoShipSStoresGearOrOtherMaterialsIntoInOnOrOutOfAnyVessel")]
		[EnumMember(Value = "Stevedoring")] 
		[XmlEnum("1")] 
		Stevedoring = 1,

		[System.ComponentModel.Description("InspectionEvaluationOrMonitoringOfTheQuantityStowageLoadingAndUnloadingAndConditionOfCargoAndTheEffectsOfCargoesOnVesselStabilityAndSafety")]
		[EnumMember(Value = "Cargo Surveying")] 
		[XmlEnum("2")] 
		CargoSurveying = 2,

		[System.ComponentModel.Description("TheSecurementOfCargoToTheShipSStructureAndOrOtherCargo")]
		[EnumMember(Value = "Cargo Lashing")] 
		[XmlEnum("3")] 
		CargoLashing = 3,

		[System.ComponentModel.Description("DeterminationOfTheQuantityOfCertainTypesOfBulkCargoByAssessmentOfItsEffectOnDisplacementWhenLoadedInAVessel")]
		[EnumMember(Value = "Draught Survey")] 
		[XmlEnum("4")] 
		DraughtSurvey = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAuthority : int {
		[System.ComponentModel.Description("TheAdministrationToPreventOrDetectAndProsecuteViolationsOfRulesAndRegulationsAtInternationalBoundaries")]
		[EnumMember(Value = "Border Control")] 
		[XmlEnum("2")] 
		BorderControl = 2,

		[System.ComponentModel.Description("TheDepartmentOfGovernmentOrCivilForceChargedWithMaintainingPublicOrder")]
		[EnumMember(Value = "Police")] 
		[XmlEnum("3")] 
		Police = 3,

		[System.ComponentModel.Description("PersonOrCorporationOwnersOfOrEntrustedWithOrInvestedWithThePowerOfManagingAPortMayBeCalledAHarbourBoardPortTrustPortCommissionHarbourCommissionMarineDepartment")]
		[EnumMember(Value = "Port")] 
		[XmlEnum("4")] 
		Port = 4,

		[System.ComponentModel.Description("TheAuthorityControllingPeopleEnteringACountry")]
		[EnumMember(Value = "Immigration")] 
		[XmlEnum("5")] 
		Immigration = 5,

		[System.ComponentModel.Description("TheAuthorityWithResponsibilityForCheckingTheValidityOfTheHealthDeclarationOfAVesselAndForDeclaringFreePratique")]
		[EnumMember(Value = "Health")] 
		[XmlEnum("6")] 
		Health = 6,

		[System.ComponentModel.Description("OrganizationKeepingWatchOnShippingAndCoastalWatersAccordingToGovernmentalLawNormallyTheAuthorityWithResponsibilityForSearchAndRescue")]
		[EnumMember(Value = "Coast Guard")] 
		[XmlEnum("7")] 
		CoastGuard = 7,

		[System.ComponentModel.Description("TheAuthorityWithResponsibilityForPreventingInfectionOfTheAgricultureOfACountryAndForTheProtectionOfTheAgriculturalInterestsOfACountry")]
		[EnumMember(Value = "Agricultural")] 
		[XmlEnum("8")] 
		Agricultural = 8,

		[System.ComponentModel.Description("AMilitaryAuthorityWhichProvidesControlOfAccessToOrApprovalForTransitThroughDesignatedAreasOrAirspace")]
		[EnumMember(Value = "Military")] 
		[XmlEnum("9")] 
		Military = 9,

		[System.ComponentModel.Description("APrivateOrPubliclyOwnedCompanyOrCommercialEnterpriseWhichExercisesControlOfFacilitiesForExampleACalibrationArea")]
		[EnumMember(Value = "Private Company")] 
		[XmlEnum("10")] 
		PrivateCompany = 10,

		[System.ComponentModel.Description("AGovernmentalOrMilitaryForceWithJurisdictionInTerritorialWatersExamplesCouldIncludeGendarmerieMaritimeCarabinierieAndGuardiaCivil")]
		[EnumMember(Value = "Maritime Police")] 
		[XmlEnum("11")] 
		MaritimePolice = 11,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheProtectionOfTheEnvironment")]
		[EnumMember(Value = "Environmental")] 
		[XmlEnum("12")] 
		Environmental = 12,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheControlOfFisheries")]
		[EnumMember(Value = "Fishery")] 
		[XmlEnum("13")] 
		Fishery = 13,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheControlAndMovementOfMoney")]
		[EnumMember(Value = "Finance")] 
		[XmlEnum("14")] 
		Finance = 14,

		[System.ComponentModel.Description("ANationalOrRegionalAuthorityChargedWithAdministrationOfMaritimeAffairs")]
		[EnumMember(Value = "Maritime")] 
		[XmlEnum("15")] 
		Maritime = 15,

		[System.ComponentModel.Description("TheAgencyOrEstablishmentForCollectingDutiesTolls")]
		[EnumMember(Value = "Customs")] 
		[XmlEnum("16")] 
		Customs = 16,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfBerthLocation : int {
		[System.ComponentModel.Description("AWharfOrQuayWithReferencePositionSGivenByOneOrMoreMetreMarks")]
		[EnumMember(Value = "Wharf Reference Metre Mark")] 
		[XmlEnum("1")] 
		WharfReferenceMetreMark = 1,

		[System.ComponentModel.Description("AWharfOrQuayWithReferencePositionSGivenByOneOrMorePointOrPointsInGeographicCoordinates")]
		[EnumMember(Value = "Wharf Reference Position")] 
		[XmlEnum("2")] 
		WharfReferencePosition = 2,

		[System.ComponentModel.Description("ALongNarrowStructureExtendingIntoTheWaterToAffordABerthingPlaceForVesselsToServeAsAPromenadeEtc")]
		[EnumMember(Value = "Pier (Jetty)")] 
		[XmlEnum("3")] 
		PierJetty = 3,

		[System.ComponentModel.Description("MooringUsingTheVesselSAnchorsAndBuoysToSecureTheVesselAtMultiplePoints")]
		[EnumMember(Value = "Conventional Mooring")] 
		[XmlEnum("4")] 
		ConventionalMooring = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("OneOfANumberOfStandardSizedCargoCarryingUnitsSecuredUsingStandardCornerAttachmentsAndBar")]
		[EnumMember(Value = "Container")] 
		[XmlEnum("2")] 
		Container = 2,

		[System.ComponentModel.Description("AFeePayingTraveller")]
		[EnumMember(Value = "Passenger")] 
		[XmlEnum("5")] 
		Passenger = 5,

		[System.ComponentModel.Description("LiveAnimalsCarriedInBulk")]
		[EnumMember(Value = "Livestock")] 
		[XmlEnum("6")] 
		Livestock = 6,

		[System.ComponentModel.Description("DangerousOrHazardousCargoAsDescribedByTheImoInternationalMaritimeDangerousGoodsCode")]
		[EnumMember(Value = "Dangerous or Hazardous")] 
		[XmlEnum("7")] 
		DangerousOrHazardous = 7,

		[System.ComponentModel.Description("IndivisibleHeavyItemsOfWeightGenerallyOver100TonsAndWidthOrHeightGreaterThan100Metres")]
		[EnumMember(Value = "Heavy Lift")] 
		[XmlEnum("8")] 
		HeavyLift = 8,

		[System.ComponentModel.Description("CommodityCargoThatIsTransportedUnpackagedInLargeQuantitiesTheseTypesOfGoodsUsuallyNeedToBeKeptDryDuringTheWholeTransportationPeriod")]
		[EnumMember(Value = "Dry Bulk Cargo")] 
		[XmlEnum("10")] 
		DryBulkCargo = 10,

		[System.ComponentModel.Description("LiquidsOrGasesThatAreTransportedInBulkAndCarriedUnpackaged")]
		[EnumMember(Value = "Liquid Bulk Cargo")] 
		[XmlEnum("11")] 
		LiquidBulkCargo = 11,

		[System.ComponentModel.Description("CargoTransportedInRefrigeratedContainersGenerallyPerishableCommoditiesWhichRequireTemperatureControlledTransportationSuchAsFruitMeatFishVegetablesDairyProductsAndOtherFoods")]
		[EnumMember(Value = "Reefer Container Cargo")] 
		[XmlEnum("12")] 
		ReeferContainerCargo = 12,

		[System.ComponentModel.Description("WheeledCargoSuchAsCarsBussesTrucksAgriculturalVehiclesAndCranesThatAreDrivenOnAndOffTheShipOnTheirOwnWheelsOrUsingAPlatformVehicleSuchAsASelfPropelledModularTransporter")]
		[EnumMember(Value = "Ro-Ro Cargo")] 
		[XmlEnum("13")] 
		RoRoCargo = 13,

		[System.ComponentModel.Description("ProjectCargoIsATermUsedToBroadlyDescribeTheNationalOrInternationalTransportationOfLargeHeavyHighValueOrCriticalToTheProjectTheyAreIntendedForPiecesOfEquipmentAlsoCommonlyReferredToAsHeavyLiftThisIncludesShipmentsMadeOfVariousComponentsWhichNeedDisassemblyForShipmentAndReassemblyAfterDelivery")]
		[EnumMember(Value = "Project Cargo")] 
		[XmlEnum("14")] 
		ProjectCargo = 14,

		[System.ComponentModel.Description("GoodsThatAreStowedOnBoardShipInIndividuallyCountedUnitsAndNotInIntermodalContainersNorInBulkAsWithOilOrGrain")]
		[EnumMember(Value = "Break Bulk Cargo")] 
		[XmlEnum("15")] 
		BreakBulkCargo = 15,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCommunicationPreference : int {
		[System.ComponentModel.Description("TheFirstChoiceChannelOrFrequencyToBeUsedWhenCallingARadioStation")]
		[EnumMember(Value = "Preferred Calling")] 
		[XmlEnum("1")] 
		PreferredCalling = 1,

		[System.ComponentModel.Description("AChannelOrFrequencyToBeUsedForCallingARadioStationWhenThePreferredChannelOrFrequencyIsBusyOrIsSufferingFromInterference")]
		[EnumMember(Value = "Alternate Calling")] 
		[XmlEnum("2")] 
		AlternateCalling = 2,

		[System.ComponentModel.Description("TheFirstChoiceChannelOrFrequencyToBeUsedWhenWorkingWithARadioStation")]
		[EnumMember(Value = "Preferred Working")] 
		[XmlEnum("3")] 
		PreferredWorking = 3,

		[System.ComponentModel.Description("AChannelOrFrequencyToBeUsedForWorkingWithARadioStationWhenThePreferredWorkingChannelOrFrequencyIsBusyOrIsSufferingFromInterference")]
		[EnumMember(Value = "Alternate Working")] 
		[XmlEnum("4")] 
		AlternateWorking = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDangerousOrHazardousCargo : int {
		[System.ComponentModel.Description("ExplosivesDivision1SubstancesAndArticlesWhichHaveAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.1")] 
		[XmlEnum("1")] 
		ImdgCodeClass1Div11 = 1,

		[System.ComponentModel.Description("ExplosivesDivision2SubstancesAndArticlesWhichHaveAProjectionHazardButNotAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.2")] 
		[XmlEnum("2")] 
		ImdgCodeClass1Div12 = 2,

		[System.ComponentModel.Description("ExplosivesDivision3SubstancesAndArticlesWhichHaveAFireHazardAndEitherAMinorBlastHazardOrAMinorProjectionHazardOrBothButNotAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.3")] 
		[XmlEnum("3")] 
		ImdgCodeClass1Div13 = 3,

		[System.ComponentModel.Description("ExplosivesDivision4SubstancesAndArticlesWhichPresentNoSignificantHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.4")] 
		[XmlEnum("4")] 
		ImdgCodeClass1Div14 = 4,

		[System.ComponentModel.Description("ExplosivesDivision5VeryInsensitiveSubstancesWhichHaveAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.5")] 
		[XmlEnum("5")] 
		ImdgCodeClass1Div15 = 5,

		[System.ComponentModel.Description("ExplosivesDivision6ExtremelyInsensitiveArticlesWhichDoNotHaveAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.6")] 
		[XmlEnum("6")] 
		ImdgCodeClass1Div16 = 6,

		[System.ComponentModel.Description("GasesFlammableGases")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.1")] 
		[XmlEnum("7")] 
		ImdgCodeClass2Div21 = 7,

		[System.ComponentModel.Description("GasesNonFlammableNonToxicGases")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.2")] 
		[XmlEnum("8")] 
		ImdgCodeClass2Div22 = 8,

		[System.ComponentModel.Description("GasesToxicGases")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.3")] 
		[XmlEnum("9")] 
		ImdgCodeClass2Div23 = 9,

		[System.ComponentModel.Description("FlammableLiquids")]
		[EnumMember(Value = "IMDG Code Class 3")] 
		[XmlEnum("10")] 
		ImdgCodeClass3 = 10,

		[System.ComponentModel.Description("FlammableSolidsSelfReactiveSubstancesAndDesensitizedExplosives")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.1")] 
		[XmlEnum("11")] 
		ImdgCodeClass4Div41 = 11,

		[System.ComponentModel.Description("SubstancesLiableToSpontaneousCombustion")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.2")] 
		[XmlEnum("12")] 
		ImdgCodeClass4Div42 = 12,

		[System.ComponentModel.Description("SubstancesWhichInContactWithWaterEmitFlammableGases")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.3")] 
		[XmlEnum("13")] 
		ImdgCodeClass4Div43 = 13,

		[System.ComponentModel.Description("OxidizingSubstances")]
		[EnumMember(Value = "IMDG Code Class 5 Div. 5.1")] 
		[XmlEnum("14")] 
		ImdgCodeClass5Div51 = 14,

		[System.ComponentModel.Description("OrganicPeroxides")]
		[EnumMember(Value = "IMDG Code Class 5 Div. 5.2")] 
		[XmlEnum("15")] 
		ImdgCodeClass5Div52 = 15,

		[System.ComponentModel.Description("ToxicSubstances")]
		[EnumMember(Value = "IMDG Code Class 6 Div. 6.1")] 
		[XmlEnum("16")] 
		ImdgCodeClass6Div61 = 16,

		[System.ComponentModel.Description("InfectiousSubstances")]
		[EnumMember(Value = "IMDG Code Class 6 Div. 6.2")] 
		[XmlEnum("17")] 
		ImdgCodeClass6Div62 = 17,

		[System.ComponentModel.Description("RadioactiveMaterial")]
		[EnumMember(Value = "IMDG Code Class 7")] 
		[XmlEnum("18")] 
		ImdgCodeClass7 = 18,

		[System.ComponentModel.Description("CorrosiveSubstances")]
		[EnumMember(Value = "IMDG Code Class 8")] 
		[XmlEnum("19")] 
		ImdgCodeClass8 = 19,

		[System.ComponentModel.Description("MiscellaneousDangerousSubstancesAndArticles")]
		[EnumMember(Value = "IMDG Code Class 9")] 
		[XmlEnum("20")] 
		ImdgCodeClass9 = 20,

		[System.ComponentModel.Description("HarmfulSubstancesAreThoseSubstancesWhichAreIdentifiedAsMarinePollutantsInTheInternationalMaritimeDangerousGoodsCodeImdgCodePackagedFormIsDefinedAsTheFormsOfContainmentSpecifiedForHarmfulSubstancesInTheImdgCode")]
		[EnumMember(Value = "Harmful Substances in Packaged Form")] 
		[XmlEnum("21")] 
		HarmfulSubstancesInPackagedForm = 21,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDepthsDescription : int {
		[System.ComponentModel.Description("AShallowElevationComposedOfUnconsolidatedMaterialThatMayConstituteAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Shoal")] 
		[XmlEnum("1")] 
		Shoal = 1,

		[System.ComponentModel.Description("GeneralInformationAboutTheVerticalDistanceFromTheWaterSurfaceToTheBottom")]
		[EnumMember(Value = "General Depth")] 
		[XmlEnum("2")] 
		GeneralDepth = 2,

		[System.ComponentModel.Description("TheLeastDepthInTheApproachOrChannelToAnAreaSuchAsAPortOrAnchorageGoverningTheMaximumDraftOfVesselsThatCanEnter")]
		[EnumMember(Value = "Controlling Depth")] 
		[XmlEnum("3")] 
		ControllingDepth = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfHarbourFacility : int {
		[System.ComponentModel.Description("ATerminalForRollOnRollOffFerries")]
		[EnumMember(Value = "RoRo Terminal")] 
		[XmlEnum("1")] 
		RoroTerminal = 1,

		[System.ComponentModel.Description("ATerminalForPassengerAndVehicleFerries")]
		[EnumMember(Value = "Ferry Terminal")] 
		[XmlEnum("3")] 
		FerryTerminal = 3,

		[System.ComponentModel.Description("AHarbourWithFacilitiesForFishingBoats")]
		[EnumMember(Value = "Fishing Harbour")] 
		[XmlEnum("4")] 
		FishingHarbour = 4,

		[System.ComponentModel.Description("AHarbourFacilityForSmallBoatsYachtsEtcWhereSuppliesRepairsAndVariousServicesAreAvailable")]
		[EnumMember(Value = "Yacht Harbour/Marina")] 
		[XmlEnum("5")] 
		YachtHarbourMarina = 5,

		[System.ComponentModel.Description("ACentreOfOperationsForNavalVessels")]
		[EnumMember(Value = "Naval Base")] 
		[XmlEnum("6")] 
		NavalBase = 6,

		[System.ComponentModel.Description("ATerminalForTheBulkHandlingOfLiquidCargoes")]
		[EnumMember(Value = "Tanker Terminal")] 
		[XmlEnum("7")] 
		TankerTerminal = 7,

		[System.ComponentModel.Description("ATerminalForTheLoadingAndUnloadingOfPassengers")]
		[EnumMember(Value = "Passenger Terminal")] 
		[XmlEnum("8")] 
		PassengerTerminal = 8,

		[System.ComponentModel.Description("APlaceWhereShipsAreBuiltOrRepaired")]
		[EnumMember(Value = "Shipyard")] 
		[XmlEnum("9")] 
		Shipyard = 9,

		[System.ComponentModel.Description("ATerminalWithFacilitiesToLoadUnloadOrStoreShippingContainers")]
		[EnumMember(Value = "Container Terminal")] 
		[XmlEnum("10")] 
		ContainerTerminal = 10,

		[System.ComponentModel.Description("ATerminalForTheHandlingOfBulkMaterialsSuchAsIronOreCoalEtc")]
		[EnumMember(Value = "Bulk Terminal")] 
		[XmlEnum("11")] 
		BulkTerminal = 11,

		[System.ComponentModel.Description("APlatformPoweredBySynchronousElectricMotorsForExampleSyncroliftUsedToLiftVesselsLargerThanBoatsInAndOutOfTheWater")]
		[EnumMember(Value = "Ship Lift")] 
		[XmlEnum("12")] 
		ShipLift = 12,

		[System.ComponentModel.Description("AWheeledVehicleDesignedToLiftAndCarryContainersOrVesselsWithinItsOwnFrameworkItIsUsedForMovingAndSometimesStackingShippingContainersAndVessels")]
		[EnumMember(Value = "Straddle Carrier")] 
		[XmlEnum("13")] 
		StraddleCarrier = 13,

		[System.ComponentModel.Description("AHarbourWithinWhichTheFloatingEquipmentDredgesTugsOfHarbourServicesAreStationed")]
		[EnumMember(Value = "Service Harbour")] 
		[XmlEnum("14")] 
		ServiceHarbour = 14,

		[System.ComponentModel.Description("TheServicesOfAPersonWhoDirectsTheMovementsOfAVesselThroughPilotWatersUsuallyAPersonWhoHasDemonstratedExtensiveKnowledgeOfChannelsAidsToNavigationDangersToNavigationEtcInAParticularAreaAndIsLicensedForThatAreaAreAvailable")]
		[EnumMember(Value = "Pilotage Service")] 
		[XmlEnum("15")] 
		PilotageService = 15,

		[System.ComponentModel.Description("APlaceWhereMechanicalServicesOrRepairsCanBeUndertakenToEnginesOrOtherVesselEquipment")]
		[EnumMember(Value = "Service and Repair")] 
		[XmlEnum("16")] 
		ServiceAndRepair = 16,

		[System.ComponentModel.Description("AMedicalControlCenterLocatedInAnIsolatedSpotAshoreWherePatientsWithContagiousDiseasesFromVesselInQuarantineAreTaken")]
		[EnumMember(Value = "Quarantine Station")] 
		[XmlEnum("17")] 
		QuarantineStation = 17,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfMooringWarpingFacility : int {
		[System.ComponentModel.Description("APostOrGroupOfPostsUsedForMooringOrWarpingAVesselOrAsAnAidToNavigationTheDolphinMayBeInTheWaterOnAWharfOrOnTheBeach")]
		[EnumMember(Value = "Dolphin")] 
		[XmlEnum("1")] 
		Dolphin = 1,

		[System.ComponentModel.Description("APostOrGroupOfPostsWhichAVesselMaySwingAroundForCompassAdjustment")]
		[EnumMember(Value = "Deviation Dolphin")] 
		[XmlEnum("2")] 
		DeviationDolphin = 2,

		[System.ComponentModel.Description("SmallShapedPostMountedOnAWharfOrDolphinUsedToSecureShipSLines")]
		[EnumMember(Value = "Bollard")] 
		[XmlEnum("3")] 
		Bollard = 3,

		[System.ComponentModel.Description("ASectionOfWallDesignatedForTyingUpVesselsAwaitingTransitBollardsAndMooringDevicesAreAvailableForBothLargeAndSmallShips")]
		[EnumMember(Value = "Tie-Up Wall")] 
		[XmlEnum("4")] 
		TieUpWall = 4,

		[System.ComponentModel.Description("ALongHeavyTimberOrSectionOfSteelWoodConcreteEtcForcedIntoTheSeabedToServeAsAMooringFacility")]
		[EnumMember(Value = "Post or Pile")] 
		[XmlEnum("5")] 
		PostOrPile = 5,

		[System.ComponentModel.Description("AChainOrVeryStrongFibreOrWireRopeUsedToAnchorOrMoorVesselsOrBuoys")]
		[EnumMember(Value = "Mooring Cable")] 
		[XmlEnum("6")] 
		MooringCable = 6,

		[System.ComponentModel.Description("ABuoySecuredToTheBottomByPermanentMooringsWithMeansForMooringAVesselByUseOfItsAnchorChainOrMooringLines")]
		[EnumMember(Value = "Mooring Buoy")] 
		[XmlEnum("7")] 
		MooringBuoy = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPortSection : int {
		[System.ComponentModel.Description("TheMainNavigableChannelInAHarbourOrItsApproachesForVesselsOfLargerSize")]
		[EnumMember(Value = "Port Fairway")] 
		[XmlEnum("1")] 
		PortFairway = 1,

		[System.ComponentModel.Description("ABodyOfWaterAtABerthOrAnchorBerthOfAdequateDimensionsToAllowAVesselToMakeFastToTheShoreMooringBuoysBerthingDolphinsOrToAnchor")]
		[EnumMember(Value = "Berth Pocket")] 
		[XmlEnum("3")] 
		BerthPocket = 3,

		[System.ComponentModel.Description("AnAreaInWhichSeaPlanesAnchorOrMayAnchor")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		[XmlEnum("8")] 
		SeaplaneAnchorage = 8,

		[System.ComponentModel.Description("AnAreaOfWaterOrChannelEnlargementOfIncreasedDepthComparedToAdjacentAreasWhereTheDepthIsMaintainedByDredgingOperations")]
		[EnumMember(Value = "Dredged Basin")] 
		[XmlEnum("9")] 
		DredgedBasin = 9,

		[System.ComponentModel.Description("TheAreaAroundAPortFacilityOrHarbourInstallationWithinWhichVesselsAreProhibitedFromEnteringWithoutPermission")]
		[EnumMember(Value = "Port Safety Zone")] 
		[XmlEnum("11")] 
		PortSafetyZone = 11,

		[System.ComponentModel.Description("AGeneralBerthForUseByVesselsForShortTermWaitingUntilALoadingOrDischargingBerthIsAvailable")]
		[EnumMember(Value = "Lay-by Berth")] 
		[XmlEnum("12")] 
		LayByBerth = 12,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRelationship : int {
		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsForbidden")]
		[EnumMember(Value = "Prohibited")] 
		[XmlEnum("1")] 
		Prohibited = 1,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsNotRecommended")]
		[EnumMember(Value = "Not Recommended")] 
		[XmlEnum("2")] 
		NotRecommended = 2,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsPermittedButNotRequired")]
		[EnumMember(Value = "Permitted")] 
		[XmlEnum("3")] 
		Permitted = 3,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsRecommended")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("4")] 
		Recommended = 4,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsRequired")]
		[EnumMember(Value = "Required")] 
		[XmlEnum("5")] 
		Required = 5,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsNotRequired")]
		[EnumMember(Value = "Not Required")] 
		[XmlEnum("6")] 
		NotRequired = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSchedule : int {
		[System.ComponentModel.Description("TheServiceOfficeIsOpenFullyMannedAndOperatingNormallyOrTheAreaIsAccessibleAsUsual")]
		[EnumMember(Value = "Normal Operation")] 
		[XmlEnum("1")] 
		NormalOperation = 1,

		[System.ComponentModel.Description("TheServiceOfficeOrAreaIsClosed")]
		[EnumMember(Value = "Closure")] 
		[XmlEnum("2")] 
		Closure = 2,

		[System.ComponentModel.Description("TheServiceIsAvailableButNotManned")]
		[EnumMember(Value = "Unmanned Operation")] 
		[XmlEnum("3")] 
		UnmannedOperation = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTemporalVariation : int {
		[System.ComponentModel.Description("IndicationOfThePossibleImpactOfASignificantEventForExampleHurricaneEarthquakeVolcanicEruptionLandslideEtcWhichIsConsideredLikelyToHaveChangedTheSeafloorOrLandscapeSignificantly")]
		[EnumMember(Value = "Extreme Event")] 
		[XmlEnum("1")] 
		ExtremeEvent = 1,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeForExampleRiverSiltationSandWavesSeasonalStormsIceBergsEtcThatIsLikelyToResultInNewSignificantShoaling")]
		[EnumMember(Value = "Likely to Change and Significant Shoaling Expected")] 
		[XmlEnum("2")] 
		LikelyToChangeAndSignificantShoalingExpected = 2,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeForExampleSandWaveShiftSeasonalStormsIceBergsEtcThatIsNotLikelyToResultInNewSignificantShoaling")]
		[EnumMember(Value = "Likely to Change But Significant Shoaling Not Expected")] 
		[XmlEnum("3")] 
		LikelyToChangeButSignificantShoalingNotExpected = 3,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeToNonBathymetricFeaturesForExampleRiverSiltationGlacierCreepRecessionSandDunesBuoysMarineFarmsEtc")]
		[EnumMember(Value = "Likely to Change")] 
		[XmlEnum("4")] 
		LikelyToChange = 4,

		[System.ComponentModel.Description("SignificantChangeToTheSeafloorIsNotExpected")]
		[EnumMember(Value = "Unlikely to Change")] 
		[XmlEnum("5")] 
		UnlikelyToChange = 5,

		[System.ComponentModel.Description("NotHavingBeenAssessed")]
		[EnumMember(Value = "Unassessed")] 
		[XmlEnum("6")] 
		Unassessed = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfText : int {
		[System.ComponentModel.Description("AStatementSummarizingTheImportantPointsOfAText")]
		[EnumMember(Value = "Abstract or Summary")] 
		[XmlEnum("1")] 
		AbstractOrSummary = 1,

		[System.ComponentModel.Description("AnExcerptOrExcerptsFromAText")]
		[EnumMember(Value = "Extract")] 
		[XmlEnum("2")] 
		Extract = 2,

		[System.ComponentModel.Description("TheWholeText")]
		[EnumMember(Value = "Full Text")] 
		[XmlEnum("3")] 
		FullText = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfVesselRegistry : int {
		[System.ComponentModel.Description("TheVesselIsRegisteredOrEnrolledUnderTheSameNationalFlagAsThePortHarbourTerritorialSeaExclusiveEconomicZoneOrAdministrativeAreaInWhichTheObjectThatPossessesThisAttributeAppliesOrIsLocated")]
		[EnumMember(Value = "Domestic")] 
		[XmlEnum("1")] 
		Domestic = 1,

		[System.ComponentModel.Description("TheVesselIsRegisteredOrEnrolledUnderANationalFlagDifferentFromThePortHarbourTerritorialSeaExclusiveEconomicZoneOrOtherAdministrativeAreaInWhichTheObjectThatPossessesThisAttributeAppliesOrIsLocated")]
		[EnumMember(Value = "Foreign")] 
		[XmlEnum("2")] 
		Foreign = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[System.ComponentModel.Description("TheValueOfTheLeftValueIsGreaterThanThatOfTheRight")]
		[EnumMember(Value = "Greater Than")] 
		[XmlEnum("1")] 
		GreaterThan = 1,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsGreaterThanOrEqualToThatOfTheRight")]
		[EnumMember(Value = "Greater Than or Equal To")] 
		[XmlEnum("2")] 
		GreaterThanOrEqualTo = 2,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanThatOfTheRight")]
		[EnumMember(Value = "Less Than")] 
		[XmlEnum("3")] 
		LessThan = 3,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanOrEqualToThatOfTheRight")]
		[EnumMember(Value = "Less Than or Equal To")] 
		[XmlEnum("4")] 
		LessThanOrEqualTo = 4,

		[System.ComponentModel.Description("TheTwoValuesAreEquivalent")]
		[EnumMember(Value = "Equal To")] 
		[XmlEnum("5")] 
		EqualTo = 5,

		[System.ComponentModel.Description("TheTwoValuesAreNotEquivalent")]
		[EnumMember(Value = "Not Equal To")] 
		[XmlEnum("6")] 
		NotEqualTo = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum condition : int {
		[System.ComponentModel.Description("BeingBuiltButNotYetCapableOfFunction")]
		[EnumMember(Value = "Under Construction")] 
		[XmlEnum("1")] 
		UnderConstruction = 1,

		[System.ComponentModel.Description("AStructureInADecayedOrDeterioratedConditionResultingFromNeglectOrDisuseOrADamagedStructureInNeedOfRepair")]
		[EnumMember(Value = "Ruined")] 
		[XmlEnum("2")] 
		Ruined = 2,

		[System.ComponentModel.Description("AnAreaOfTheSeaALakeOrTheNavigablePartOfARiverThatIsBeingReclaimedAsLandUsuallyByTheDumpingOfEarthAndOtherMaterial")]
		[EnumMember(Value = "Under Reclamation")] 
		[XmlEnum("3")] 
		UnderReclamation = 3,

		[System.ComponentModel.Description("DetailedPlanningHasBeenCompletedButConstructionHasNotBeenInitiated")]
		[EnumMember(Value = "Planned Construction")] 
		[XmlEnum("5")] 
		PlannedConstruction = 5,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dayOfWeek : int {
		[System.ComponentModel.Description("TheFirstDayOfTheWeek")]
		[EnumMember(Value = "Sunday")] 
		[XmlEnum("1")] 
		Sunday = 1,

		[System.ComponentModel.Description("TheSecondDayOfTheWeek")]
		[EnumMember(Value = "Monday")] 
		[XmlEnum("2")] 
		Monday = 2,

		[System.ComponentModel.Description("TheThirdDayOfTheWeek")]
		[EnumMember(Value = "Tuesday")] 
		[XmlEnum("3")] 
		Tuesday = 3,

		[System.ComponentModel.Description("TheFourthDayOfTheWeek")]
		[EnumMember(Value = "Wednesday")] 
		[XmlEnum("4")] 
		Wednesday = 4,

		[System.ComponentModel.Description("TheFifthDayOfTheWeek")]
		[EnumMember(Value = "Thursday")] 
		[XmlEnum("5")] 
		Thursday = 5,

		[System.ComponentModel.Description("TheSixthDayOfTheWeek")]
		[EnumMember(Value = "Friday")] 
		[XmlEnum("6")] 
		Friday = 6,

		[System.ComponentModel.Description("TheSeventhDayOfTheWeek")]
		[EnumMember(Value = "Saturday")] 
		[XmlEnum("7")] 
		Saturday = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dynamicResource : int {
		[System.ComponentModel.Description("TheInformationIsStaticOrASourceOfUpToDateInformationIsUnavailableOrUnknown")]
		[EnumMember(Value = "Static")] 
		[XmlEnum("1")] 
		Static = 1,

		[System.ComponentModel.Description("AnExternalSourceOfUpToDateInformationIsAvailableAndInteractionWithItToObtainUpToDateInformationIsRequired")]
		[EnumMember(Value = "Mandatory External Dynamic")] 
		[XmlEnum("2")] 
		MandatoryExternalDynamic = 2,

		[System.ComponentModel.Description("AnExternalSourceOfUpToDateInformationIsAvailableButInteractionWithItToObtainUpToDateInformationIsNotRequired")]
		[EnumMember(Value = "Optional External Dynamic")] 
		[XmlEnum("3")] 
		OptionalExternalDynamic = 3,

		[System.ComponentModel.Description("UpToDateInformationMayBeComputedUsingOnlyOnboardResources")]
		[EnumMember(Value = "Onboard Dynamic")] 
		[XmlEnum("4")] 
		OnboardDynamic = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum firefightingService : int {
		[System.ComponentModel.Description("PersonnelAndEquipmentThatAreCapableOfCombatingAFireFromAshore")]
		[EnumMember(Value = "Shore-Based Firefighting")] 
		[XmlEnum("1")] 
		ShoreBasedFirefighting = 1,

		[System.ComponentModel.Description("TrainedFirefightingPersonnelWithTheCapabilityOfBoardingAndCombatingAFireOnAVessel")]
		[EnumMember(Value = "Onboard Firefighting")] 
		[XmlEnum("2")] 
		OnboardFirefighting = 2,

		[System.ComponentModel.Description("SpecialisedWatercraftWithFirefightingApparatusDesignedForFightingShorelineAndShipboardFires")]
		[EnumMember(Value = "Firefighting Boat")] 
		[XmlEnum("3")] 
		FirefightingBoat = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iSPSLevel : int {
		[System.ComponentModel.Description("TheLevelForWhichMinimumAppropriateProtectiveSecurityMeasuresShallBeMaintainedAtAllTimes")]
		[EnumMember(Value = "ISPS Level 1")] 
		[XmlEnum("1")] 
		IspsLevel1 = 1,

		[System.ComponentModel.Description("TheLevelForWhichAppropriateAdditionalProtectiveSecurityMeasuresShallBeMaintainedForAPeriodOfTimeAsAResultOfHeightenedRiskOfASecurityIncident")]
		[EnumMember(Value = "ISPS Level 2")] 
		[XmlEnum("2")] 
		IspsLevel2 = 2,

		[System.ComponentModel.Description("TheLevelForWhichFurtherSpecificProtectiveSecurityMeasuresShallBeMaintainedForALimitedPeriodOfTimeWhenASecurityIncidentIsProbableOrImminentAlthoughItMayNotBePossibleToIdentifyTheSpecificTarget")]
		[EnumMember(Value = "ISPS Level 3")] 
		[XmlEnum("3")] 
		IspsLevel3 = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum logicalConnectives : int {
		[System.ComponentModel.Description("AllTheConditionsDescribedByTheOtherAttributesOfTheObjectOrSubAttributesOfTheSameComplexAttributeAreTrue")]
		[EnumMember(Value = "Logical Conjunction")] 
		[XmlEnum("1")] 
		LogicalConjunction = 1,

		[System.ComponentModel.Description("AtLeastOneOfTheConditionsDescribedByTheOtherAttributesOfTheObjectOrSubAttributesOfTheSameComplexAttributesIsTrue")]
		[EnumMember(Value = "Logical Disjunction")] 
		[XmlEnum("2")] 
		LogicalDisjunction = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum medicalService : int {
		[System.ComponentModel.Description("AVehicleForConveyingTheSickOrInjuredToOrFromAHospital")]
		[EnumMember(Value = "Ambulance")] 
		[XmlEnum("1")] 
		Ambulance = 1,

		[System.ComponentModel.Description("DisinfectionOrPurificationWithFumes")]
		[EnumMember(Value = "Fumigation")] 
		[XmlEnum("2")] 
		Fumigation = 2,

		[System.ComponentModel.Description("APlaceWhereADoctorIsAvailableToProvideMedicalAttention")]
		[EnumMember(Value = "Doctor")] 
		[XmlEnum("3")] 
		Doctor = 3,

		[System.ComponentModel.Description("TheIsolationOfPatientsWithContagiousDiseases")]
		[EnumMember(Value = "Quarantine")] 
		[XmlEnum("4")] 
		Quarantine = 4,

		[System.ComponentModel.Description("APlaceWhereSubstancesIntendedToProcureImmunityAgainstOneOrSeveralDiseasesAreAdministered")]
		[EnumMember(Value = "Vaccination Centre")] 
		[XmlEnum("5")] 
		VaccinationCentre = 5,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum membership : int {
		[System.ComponentModel.Description("VesselsWithTheseCharacteristicsAreIncludedInTheRegulationRestrictionRecommendationNauticalInformation")]
		[EnumMember(Value = "Included")] 
		[XmlEnum("1")] 
		Included = 1,

		[System.ComponentModel.Description("VesselsWithTheseCharacteristicsAreExcludedFromTheRegulationRestrictionRecommendationNauticalInformation")]
		[EnumMember(Value = "Excluded")] 
		[XmlEnum("2")] 
		Excluded = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum methodOfSecuring : int {
		[System.ComponentModel.Description("VesselIsSecuredPerpendicularToTheWharfWithBowToSeaward")]
		[EnumMember(Value = "Bow to Seaward")] 
		[XmlEnum("1")] 
		BowToSeaward = 1,

		[System.ComponentModel.Description("VesselIsSecuredPerpendicularToTheWharfWithSternToTheSeaward")]
		[EnumMember(Value = "Stern to Seaward")] 
		[XmlEnum("2")] 
		SternToSeaward = 2,

		[System.ComponentModel.Description("TheVesselIsSecuredPerpendicularToTheWharf")]
		[EnumMember(Value = "Mediterranean Mooring")] 
		[XmlEnum("3")] 
		MediterraneanMooring = 3,

		[System.ComponentModel.Description("MooringMethodProcedureUsedDuringOnshoreWindConditionsWithoutATug")]
		[EnumMember(Value = "Baltic Mooring")] 
		[XmlEnum("4")] 
		BalticMooring = 4,

		[System.ComponentModel.Description("MooringByManeuveringAheadAndAsternWhileDroppingAnchorsToSecureTheVesselWithReducedSwingingRoom")]
		[EnumMember(Value = "Running Mooring")] 
		[XmlEnum("5")] 
		RunningMooring = 5,

		[System.ComponentModel.Description("MooringByUsingMainlyWindAndTideToPositionTheVesselWhileDroppingAnchorsToSecureTheVesselWithReducedSwingingRoomMakesLimitedUseOfTheEngineToPositionTheVessel")]
		[EnumMember(Value = "Standing Mooring")] 
		[XmlEnum("6")] 
		StandingMooring = 6,

		[System.ComponentModel.Description("AMooringStructureUsedByTankersToLoadAndUnloadInPortApproachesOrInOffshoreOilAndGasFieldsTheSizeOfTheStructureCanVaryBetweenALargeMooringBuoyAndAMannedFloatingStructure")]
		[EnumMember(Value = "Single Point Mooring")] 
		[XmlEnum("7")] 
		SinglePointMooring = 7,

		[System.ComponentModel.Description("MooringUsingTheVesselSAnchorsAndBuoysToSecureTheVesselAtMultiplePoints")]
		[EnumMember(Value = "Conventional Mooring")] 
		[XmlEnum("8")] 
		ConventionalMooring = 8,

		[System.ComponentModel.Description("MooringAlongsideAnotherVessel")]
		[EnumMember(Value = "Ship-to-Ship Mooring")] 
		[XmlEnum("9")] 
		ShipToShipMooring = 9,

		[System.ComponentModel.Description("MooringSystemSupportedByASpiderBuoy")]
		[EnumMember(Value = "Spider Buoy Mooring")] 
		[XmlEnum("10")] 
		SpiderBuoyMooring = 10,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum onlineFunction : int {
		[System.ComponentModel.Description("OnlineInstructionsForTransferringDataFromOneStorageDeviceOrSystemToAnother")]
		[EnumMember(Value = "Download")] 
		[XmlEnum("1")] 
		Download = 1,

		[System.ComponentModel.Description("OnlineInstructionsForRequestingTheResourceFromTheProvider")]
		[EnumMember(Value = "Offline Access")] 
		[XmlEnum("3")] 
		OfflineAccess = 3,

		[System.ComponentModel.Description("OnlineOrderProcessForObtainingTheResource")]
		[EnumMember(Value = "Order")] 
		[XmlEnum("4")] 
		Order = 4,

		[System.ComponentModel.Description("ToMakePainstakingInvestigationOrExamination")]
		[EnumMember(Value = "Search")] 
		[XmlEnum("5")] 
		Search = 5,

		[System.ComponentModel.Description("CompleteMetadataProvided")]
		[EnumMember(Value = "Complete Metadata")] 
		[XmlEnum("6")] 
		CompleteMetadata = 6,

		[System.ComponentModel.Description("BrowseGraphicProvided")]
		[EnumMember(Value = "Browse Graphic")] 
		[XmlEnum("7")] 
		BrowseGraphic = 7,

		[System.ComponentModel.Description("OnlineResourceUploadCapabilityProvided")]
		[EnumMember(Value = "Upload")] 
		[XmlEnum("8")] 
		Upload = 8,

		[System.ComponentModel.Description("OnlineEmailServiceProvided")]
		[EnumMember(Value = "Email Service")] 
		[XmlEnum("9")] 
		EmailService = 9,

		[System.ComponentModel.Description("OnlineBrowsingProvided")]
		[EnumMember(Value = "Browsing")] 
		[XmlEnum("10")] 
		Browsing = 10,

		[System.ComponentModel.Description("OnlineFileAccessProvided")]
		[EnumMember(Value = "File Access")] 
		[XmlEnum("11")] 
		FileAccess = 11,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum product : int {
		[System.ComponentModel.Description("AThickSlipperyLiquidThatWillNotDissolveInWaterUsuallyPetroleumBasedInTheContextOfStorageTanks")]
		[EnumMember(Value = "Oil")] 
		[XmlEnum("1")] 
		Oil = 1,

		[System.ComponentModel.Description("ASubstanceWithParticlesThatCanMoveFreelyUsuallyAFuelSubstanceInTheContextOfStorageTanks")]
		[EnumMember(Value = "Gas")] 
		[XmlEnum("2")] 
		Gas = 2,

		[System.ComponentModel.Description("AGeneralTermForRockAndRockFragmentsRangingInSizeFromPebblesAndGravelToBouldersOrLargeRockMasses")]
		[EnumMember(Value = "Stone")] 
		[XmlEnum("4")] 
		Stone = 4,

		[System.ComponentModel.Description("AHardBlackMineralThatIsBurnedAsFuel")]
		[EnumMember(Value = "Coal")] 
		[XmlEnum("5")] 
		Coal = 5,

		[System.ComponentModel.Description("ASolidRockOrMineralFromWhichMetalIsObtained")]
		[EnumMember(Value = "Ore")] 
		[XmlEnum("6")] 
		Ore = 6,

		[System.ComponentModel.Description("AnySubstanceObtainedByOrUsedInAChemicalProcess")]
		[EnumMember(Value = "Chemicals")] 
		[XmlEnum("7")] 
		Chemicals = 7,

		[System.ComponentModel.Description("AWhiteFluidSecretedByFemaleMammalsAsFoodForTheirYoung")]
		[EnumMember(Value = "Milk")] 
		[XmlEnum("9")] 
		Milk = 9,

		[System.ComponentModel.Description("AMineralFromWhichAluminumIsObtained")]
		[EnumMember(Value = "Bauxite")] 
		[XmlEnum("10")] 
		Bauxite = 10,

		[System.ComponentModel.Description("ASolidSubstanceObtainedAfterGasAndTarHaveBeenExtractedFromCoalUsedAsAFuel")]
		[EnumMember(Value = "Coke")] 
		[XmlEnum("11")] 
		Coke = 11,

		[System.ComponentModel.Description("AnOblongLumpOfCastIronMetal")]
		[EnumMember(Value = "Iron Ingots")] 
		[XmlEnum("12")] 
		IronIngots = 12,

		[System.ComponentModel.Description("SodiumChlorideObtainedFromMinesOrByTheEvaporationOfSeaWater")]
		[EnumMember(Value = "Salt")] 
		[XmlEnum("13")] 
		Salt = 13,

		[System.ComponentModel.Description("LooseMaterialConsistingOfSmallButEasilyDistinguishableSeparateGrainsBetween00625And2000MillimetresInDiameter")]
		[EnumMember(Value = "Sand")] 
		[XmlEnum("14")] 
		Sand = 14,

		[System.ComponentModel.Description("WoodPreparedForUseInBuildingOrCarpentry")]
		[EnumMember(Value = "Timber")] 
		[XmlEnum("15")] 
		Timber = 15,

		[System.ComponentModel.Description("PowderyFragmentsOfWoodMadeInSawingTimberOrCoarseChipsProducedForUseInManufacturingPressedBoard")]
		[EnumMember(Value = "Sawdust/Wood Chips")] 
		[XmlEnum("16")] 
		SawdustWoodChips = 16,

		[System.ComponentModel.Description("DiscardedMetalSuitableForBeingReprocessed")]
		[EnumMember(Value = "Scrap Metal")] 
		[XmlEnum("17")] 
		ScrapMetal = 17,

		[System.ComponentModel.Description("NaturalGasThatHasBeenLiquefiedForEaseOfTransportByCoolingTheGasTo162Celsius")]
		[EnumMember(Value = "Liquefied Natural Gas")] 
		[XmlEnum("18")] 
		LiquefiedNaturalGas = 18,

		[System.ComponentModel.Description("ACompressedGasConsistingOfFlammableLightHydrocarbonsAndDerivedFromPetroleum")]
		[EnumMember(Value = "Liquefied Petroleum Gas")] 
		[XmlEnum("19")] 
		LiquefiedPetroleumGas = 19,

		[System.ComponentModel.Description("TheFermentedJuiceOfGrapes")]
		[EnumMember(Value = "Wine")] 
		[XmlEnum("20")] 
		Wine = 20,

		[System.ComponentModel.Description("ASubstanceMadeOfPowderedLimeAndClayMixedWithWater")]
		[EnumMember(Value = "Cement")] 
		[XmlEnum("21")] 
		Cement = 21,

		[System.ComponentModel.Description("ASmallHardSeedEspeciallyThatOfAnyCerealPlantSuchAsWheatRiceCornRyeEtc")]
		[EnumMember(Value = "Grain")] 
		[XmlEnum("22")] 
		Grain = 22,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("ThePositionSWasWereDeterminedByTheOperationOfMakingMeasurementsForDeterminingTheRelativePositionOfPointsOnAboveOrBeneathTheEarthSSurfaceSurveyImpliesARegularControlledSurveyOfAnyDate")]
		[EnumMember(Value = "Surveyed")] 
		[XmlEnum("1")] 
		Surveyed = 1,

		[System.ComponentModel.Description("SurveyDataIsDoesNotExistOrIsVeryPoor")]
		[EnumMember(Value = "Unsurveyed")] 
		[XmlEnum("2")] 
		Unsurveyed = 2,

		[System.ComponentModel.Description("NotSurveyedToModernStandardsOrDueToItsAgeScaleOrPositionalOrVerticalUncertaintiesIsNotSuitableToTheTypeOfNavigationExpectedInTheArea")]
		[EnumMember(Value = "Inadequately Surveyed")] 
		[XmlEnum("3")] 
		InadequatelySurveyed = 3,

		[System.ComponentModel.Description("APositionThatIsConsideredToBeLessThanThirdOrderAccuracyButIsGenerallyConsideredToBeWithin305MetresOfItsCorrectGeographicLocationAlsoMayApplyToAnObjectWhosePositionDoesNotRemainFixed")]
		[EnumMember(Value = "Approximate")] 
		[XmlEnum("4")] 
		Approximate = 4,

		[System.ComponentModel.Description("OfUncertainPositionTheExpressionIsUsedPrincipallyOnChartsToIndicateThatAWreckShoalEtcHasBeenReportedInVariousPositionsAndNotDefinitelyDeterminedInAny")]
		[EnumMember(Value = "Position Doubtful")] 
		[XmlEnum("5")] 
		PositionDoubtful = 5,

		[System.ComponentModel.Description("AFeatureSPositionHasBeenObtainedFromQuestionableOrUnreliableData")]
		[EnumMember(Value = "Unreliable")] 
		[XmlEnum("6")] 
		Unreliable = 6,

		[System.ComponentModel.Description("AnObjectWhosePositionHasBeenReportedAndItsPositionConfirmedBySomeMeansOtherThanAFormalSurveySuchAsAnIndependentReportOfTheSameObject")]
		[EnumMember(Value = "Reported (Not Surveyed)")] 
		[XmlEnum("7")] 
		ReportedNotSurveyed = 7,

		[System.ComponentModel.Description("AnObjectWhosePositionHasBeenReportedAndItsPositionHasNotBeenConfirmed")]
		[EnumMember(Value = "Reported (Not Confirmed)")] 
		[XmlEnum("8")] 
		ReportedNotConfirmed = 8,

		[System.ComponentModel.Description("TheMostProbablePositionOfAnObjectDeterminedFromIncompleteDataOrDataOfQuestionableAccuracy")]
		[EnumMember(Value = "Estimated")] 
		[XmlEnum("9")] 
		Estimated = 9,

		[System.ComponentModel.Description("APositionThatIsOfAKnownValueSuchAsThePositionOfAnAnchorBerthOrOtherDefinedObject")]
		[EnumMember(Value = "Precisely Known")] 
		[XmlEnum("10")] 
		PreciselyKnown = 10,

		[System.ComponentModel.Description("APositionThatIsComputedFromData")]
		[EnumMember(Value = "Calculated")] 
		[XmlEnum("11")] 
		Calculated = 11,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum repairService : int {
		[System.ComponentModel.Description("TheProcessOfNeutralizingOrReducingToAMinimumTheMagneticEffectsTheVesselItselfExertsOnAMagneticCompassItIsBasedOnThePrincipleThatTheMagneticEffectOfTheIronAndSteelOfTheVesselCanBeCounterbalancedByMeansOfMagnetsAndSoftIronPlacedNearTheCompassAlsoCalledCompassAdjustmentCompassCompensationOrMagneticCompensation")]
		[EnumMember(Value = "Compensation of Magnetic Compass")] 
		[XmlEnum("1")] 
		CompensationOfMagneticCompass = 1,

		[System.ComponentModel.Description("UnderwaterInspectionAndRepairPerformedByDivers")]
		[EnumMember(Value = "Diver Service")] 
		[XmlEnum("2")] 
		DiverService = 2,

		[System.ComponentModel.Description("RepairsToEqipmentInstalledOnTheShipSBridge")]
		[EnumMember(Value = "Bridge Equipment Repair")] 
		[XmlEnum("3")] 
		BridgeEquipmentRepair = 3,

		[System.ComponentModel.Description("RepairOfAnEngineOrMachineParts")]
		[EnumMember(Value = "Engine Repair")] 
		[XmlEnum("4")] 
		EngineRepair = 4,

		[System.ComponentModel.Description("RepairOfMarineElectronicInstruments")]
		[EnumMember(Value = "Electronic Equipment Repair")] 
		[XmlEnum("5")] 
		ElectronicEquipmentRepair = 5,

		[System.ComponentModel.Description("RepairsToTheShipSBodyFrameOrSuperstructure")]
		[EnumMember(Value = "Hull Repair")] 
		[XmlEnum("6")] 
		HullRepair = 6,

		[System.ComponentModel.Description("RepairsToEquipmentUsedInTheActOfNavigatingAShip")]
		[EnumMember(Value = "Navigational Equipment Repair")] 
		[XmlEnum("7")] 
		NavigationalEquipmentRepair = 7,

		[System.ComponentModel.Description("RepairsToPropellerHubAndBlades")]
		[EnumMember(Value = "Propeller Repair")] 
		[XmlEnum("8")] 
		PropellerRepair = 8,

		[System.ComponentModel.Description("RepairsToEquipmentUsedInSalvageOperations")]
		[EnumMember(Value = "Salvage Gear Repair")] 
		[XmlEnum("9")] 
		SalvageGearRepair = 9,

		[System.ComponentModel.Description("RepairsToDriveShaftsUsedForTransmittingMechanicalPowerAndTorqueToAPropeller")]
		[EnumMember(Value = "Shaft Repair")] 
		[XmlEnum("10")] 
		ShaftRepair = 10,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum shipSanitationControl : int {
		[System.ComponentModel.Description("CapableOfApplyingMeasuresToEnsureThatAVesselIsFreeOfDiseaseAndDiseaseRisksButCannotIssueACertificate")]
		[EnumMember(Value = "Sanitation Measures Only")] 
		[XmlEnum("1")] 
		SanitationMeasuresOnly = 1,

		[System.ComponentModel.Description("TheCompetentAuthorityCanIssueAShipSanitationControlCertificateAfterSatisfactorilyCompletingOrSupervisingTheCompletionOfShipSanitationControlMeasures")]
		[EnumMember(Value = "Issue SSCC")] 
		[XmlEnum("2")] 
		IssueSscc = 2,

		[System.ComponentModel.Description("TheCompetentAuthorityMayIssueAShipSanitationControlExemptionCertificateIfItIsSatisfiedThatTheShipIsFreeOfInfectionAndContaminationIncludingVectorsAndReservoirs")]
		[EnumMember(Value = "Issue SSCEC")] 
		[XmlEnum("3")] 
		IssueSscec = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum sourceType : int {
		[System.ComponentModel.Description("TreatyConventionOrInternationalAgreementLawOrRegulationIssuedByANationalOrOtherAuthority")]
		[EnumMember(Value = "Law or Regulation")] 
		[XmlEnum("1")] 
		LawOrRegulation = 1,

		[System.ComponentModel.Description("PublicationNotHavingTheForceOfLawIssuedByAnInternationalOrganisationOrANationalOrLocalAdministration")]
		[EnumMember(Value = "Official Publication")] 
		[XmlEnum("2")] 
		OfficialPublication = 2,

		[System.ComponentModel.Description("ReportedByMarinerSAndConfirmedByAnotherSource")]
		[EnumMember(Value = "Mariner Report, Confirmed")] 
		[XmlEnum("7")] 
		MarinerReportConfirmed = 7,

		[System.ComponentModel.Description("ReportedByMarinerSButNotConfirmed")]
		[EnumMember(Value = "Mariner Report, Not Confirmed")] 
		[XmlEnum("8")] 
		MarinerReportNotConfirmed = 8,

		[System.ComponentModel.Description("ShippingAndOtherIndustryPublicationsIncludingGraphicsChartsAndWebSites")]
		[EnumMember(Value = "Industry Publications and Reports")] 
		[XmlEnum("9")] 
		IndustryPublicationsAndReports = 9,

		[System.ComponentModel.Description("InformationObtainedFromSatelliteImages")]
		[EnumMember(Value = "Remotely Sensed Images")] 
		[XmlEnum("10")] 
		RemotelySensedImages = 10,

		[System.ComponentModel.Description("InformationObtainedFromPhotographs")]
		[EnumMember(Value = "Photographs")] 
		[XmlEnum("11")] 
		Photographs = 11,

		[System.ComponentModel.Description("InformationObtainedFromProductsIssuedByHydrographicOffices")]
		[EnumMember(Value = "Products Issued by HO Services")] 
		[XmlEnum("12")] 
		ProductsIssuedByHoServices = 12,

		[System.ComponentModel.Description("InformationObtainedFromNewsMedia")]
		[EnumMember(Value = "News Media")] 
		[XmlEnum("13")] 
		NewsMedia = 13,

		[System.ComponentModel.Description("InformationObtainedFromTheAnalysisOfTrafficData")]
		[EnumMember(Value = "Traffic Data")] 
		[XmlEnum("14")] 
		TrafficData = 14,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supplyService : int {
		[System.ComponentModel.Description("TheProvisionOfShoresideElectricalPowerToAShipAtBerthWhileItsMainAndAuxiliaryEnginesAreShutDown")]
		[EnumMember(Value = "Shore Power")] 
		[XmlEnum("1")] 
		ShorePower = 1,

		[System.ComponentModel.Description("TransferOfFuelOilToTheFuelCompartmentsOfAShip")]
		[EnumMember(Value = "Fuel Oil Bunkering")] 
		[XmlEnum("2")] 
		FuelOilBunkering = 2,

		[System.ComponentModel.Description("TransferOfLiquefiedNaturalGasToTheFuelCompartmentsOfAShip")]
		[EnumMember(Value = "LNG Bunkering")] 
		[XmlEnum("3")] 
		LngBunkering = 3,

		[System.ComponentModel.Description("SubstancesCapableOfReducingFrictionHeatAndWearWhenIntroducedAsAFilmBetweenSolidSurfaces")]
		[EnumMember(Value = "Lubricants")] 
		[XmlEnum("4")] 
		Lubricants = 4,

		[System.ComponentModel.Description("TheGasIntoWhichWaterIsChangedByBoiling")]
		[EnumMember(Value = "Steam")] 
		[XmlEnum("5")] 
		Steam = 5,

		[System.ComponentModel.Description("WaterWhichCanBeUsedForDrinkingAndFoodPreparation")]
		[EnumMember(Value = "Potable Water")] 
		[XmlEnum("6")] 
		PotableWater = 6,

		[System.ComponentModel.Description("AUniversalHoseConnectionForTheSupplyOfWaterForFightingFires")]
		[EnumMember(Value = "International Shore Connection")] 
		[XmlEnum("7")] 
		InternationalShoreConnection = 7,

		[System.ComponentModel.Description("APlaceWhereFoodAndOtherSuchSuppliesAreAvailable")]
		[EnumMember(Value = "Provisions")] 
		[XmlEnum("8")] 
		Provisions = 8,

		[System.ComponentModel.Description("ADealerInShipsSupplies")]
		[EnumMember(Value = "Chandler")] 
		[XmlEnum("9")] 
		Chandler = 9,

		[System.ComponentModel.Description("APlaceWhereMechanicalRepairsCanBeUndertakenToEnginesOrOtherVesselEquipment")]
		[EnumMember(Value = "Mechanics Workshop")] 
		[XmlEnum("10")] 
		MechanicsWorkshop = 10,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum technicalPortService : int {
		[System.ComponentModel.Description("TheProcessOfNeutralizingOrReducingToAMinimumTheMagneticEffectsTheVesselItselfExertsOnAMagneticCompassItIsBasedOnThePrincipleThatTheMagneticEffectOfTheIronAndSteelOfTheVesselCanBeCounterbalancedByMeansOfMagnetsAndSoftIronPlacedNearTheCompassAlsoCalledCompassAdjustmentCompassCompensationOrMagneticCompensation")]
		[EnumMember(Value = "Compensation of Magnetic Compass")] 
		[XmlEnum("1")] 
		CompensationOfMagneticCompass = 1,

		[System.ComponentModel.Description("NeutralizationOfTheStrengthOfTheMagneticFieldOfAVesselByMeansOfSuitablyArrangedElectricCoilsPermanentlyInstalledInTheVesselSeeAlsoDegaussingCable")]
		[EnumMember(Value = "Degaussing")] 
		[XmlEnum("2")] 
		Degaussing = 2,

		[System.ComponentModel.Description("InspectionEvaluationOrMonitoringOfTheQuantityStowageLoadingAndUnloadingAndConditionOfCargoAndTheEffectsOfCargoesOnVesselStabilityAndSafety")]
		[EnumMember(Value = "Cargo Surveying")] 
		[XmlEnum("3")] 
		CargoSurveying = 3,

		[System.ComponentModel.Description("AssessmentOfQualityAndComplianceWithApplicableLawRegulationsAndSafetyStandards")]
		[EnumMember(Value = "Vetting")] 
		[XmlEnum("4")] 
		Vetting = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum telecommunicationService : int {
		[System.ComponentModel.Description("TheTransferOrExchangeOfInformationByUsingSoundsThatAreBeingMadeByMouthAndThroatWhenSpeaking")]
		[EnumMember(Value = "Voice")] 
		[XmlEnum("1")] 
		Voice = 1,

		[System.ComponentModel.Description("ASystemOfTransmittingAndReproducingGraphicMatterAsPrintingOrStillPicturesByMeansOfSignalsSentOverTelephoneLines")]
		[EnumMember(Value = "Facsimile")] 
		[XmlEnum("2")] 
		Facsimile = 2,

		[System.ComponentModel.Description("ShortMessageServiceIsAFormOfTextMessagingCommunicationOnPhonesAndMobilePhones")]
		[EnumMember(Value = "SMS")] 
		[XmlEnum("3")] 
		Sms = 3,

		[System.ComponentModel.Description("ARepresentationOfFactsConceptsOrInstructionsInAFormalisedMannerSuitableForCommunicationInterpretationOrProcessing")]
		[EnumMember(Value = "Data")] 
		[XmlEnum("4")] 
		Data = 4,

		[System.ComponentModel.Description("DataThatIsConstantlyReceivedByAndPresentedToAnEndUserWhileBeingDeliveredByAProvider")]
		[EnumMember(Value = "Streamed Data")] 
		[XmlEnum("5")] 
		StreamedData = 5,

		[System.ComponentModel.Description("ASystemOfCommunicationInWhichMessagesAreSentOverLongDistancesByUsingATelephoneSystemAndArePrintedByUsingASpecialMachineCalledATeletypewriter")]
		[EnumMember(Value = "Telex")] 
		[XmlEnum("6")] 
		Telex = 6,

		[System.ComponentModel.Description("AnApparatusSystemOrProcessForCommunicationAtADistanceByElectricTransmissionOverWire")]
		[EnumMember(Value = "Telegraph")] 
		[XmlEnum("7")] 
		Telegraph = 7,

		[System.ComponentModel.Description("MessagesAndOtherDataExchangedBetweenIndividualsUsingComputersInANetwork")]
		[EnumMember(Value = "Email")] 
		[XmlEnum("8")] 
		Email = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum textType : int {
		[System.ComponentModel.Description("TheIndividualNameOfAFeature")]
		[EnumMember(Value = "Name")] 
		[XmlEnum("1")] 
		Name = 1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("TheAverageHeightOfTheLowWatersOfSpringTidesThisLevelIsUsedAsATidalDatumInSomeAreasAlsoCalledSpringLowWater")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		[XmlEnum("1")] 
		MeanLowWaterSprings = 1,

		[System.ComponentModel.Description("TheAverageHeightOfLowerLowWaterSpringsAtAPlace")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		[XmlEnum("2")] 
		MeanLowerLowWaterSprings = 2,

		[System.ComponentModel.Description("TheAverageHeightOfTheSurfaceOfTheSeaAtATideStationForAllStagesOfTheTideOverA19YearPeriodUsuallyDeterminedFromHourlyHeightReadingsMeasuredFromAFixedPredeterminedReferenceLevel")]
		[EnumMember(Value = "Mean Sea Level")] 
		[XmlEnum("3")] 
		MeanSeaLevel = 3,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestTideObservedAtAPlaceOrSomeWhatLower")]
		[EnumMember(Value = "Lowest Low Water")] 
		[XmlEnum("4")] 
		LowestLowWater = 4,

		[System.ComponentModel.Description("TheAverageHeightOfAllLowWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Low Water")] 
		[XmlEnum("5")] 
		MeanLowWater = 5,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestWaterLevelObservedAtAPlaceAtSpringTidesDuringAPeriodOfTimeShorterThan19Years")]
		[EnumMember(Value = "Lowest Low Water Springs")] 
		[XmlEnum("6")] 
		LowestLowWaterSprings = 6,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowWaterSpringsMlws")]
		[EnumMember(Value = "Approximate Mean Low Water Springs")] 
		[XmlEnum("7")] 
		ApproximateMeanLowWaterSprings = 7,

		[System.ComponentModel.Description("AnArbitraryTidalDatumApproximatingTheLevelOfTheMeanOfTheLowerLowWaterAtSpringTidesItWasFirstUsedInWatersSurroundingIndia")]
		[EnumMember(Value = "Indian Spring Low Water")] 
		[XmlEnum("8")] 
		IndianSpringLowWater = 8,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingThatOfMeanLowWaterSpringsMlws")]
		[EnumMember(Value = "Low Water Springs")] 
		[XmlEnum("9")] 
		LowWaterSprings = 9,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfLowestAstronomicalTideLat")]
		[EnumMember(Value = "Approximate Lowest Astronomical Tide")] 
		[XmlEnum("10")] 
		ApproximateLowestAstronomicalTide = 10,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingTheLowestWaterLevelObservedAtAPlaceUsuallyEquivalentToTheIndianSpringLowWaterIslw")]
		[EnumMember(Value = "Nearly Lowest Low Water")] 
		[XmlEnum("11")] 
		NearlyLowestLowWater = 11,

		[System.ComponentModel.Description("TheAverageHeightOfTheLowerLowWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Lower Low Water")] 
		[XmlEnum("12")] 
		MeanLowerLowWater = 12,

		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillationAlsoCalledLowTide")]
		[EnumMember(Value = "Low Water")] 
		[XmlEnum("13")] 
		LowWater = 13,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowWaterMlw")]
		[EnumMember(Value = "Approximate Mean Low Water")] 
		[XmlEnum("14")] 
		ApproximateMeanLowWater = 14,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowerLowWaterMllw")]
		[EnumMember(Value = "Approximate Mean Lower Low Water")] 
		[XmlEnum("15")] 
		ApproximateMeanLowerLowWater = 15,

		[System.ComponentModel.Description("TheAverageHeightOfAllHighWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean High Water")] 
		[XmlEnum("16")] 
		MeanHighWater = 16,

		[System.ComponentModel.Description("TheAverageHeightOfTheHighWatersOfSpringTidesAlsoCalledSpringHighWater")]
		[EnumMember(Value = "Mean High Water Springs")] 
		[XmlEnum("17")] 
		MeanHighWaterSprings = 17,

		[System.ComponentModel.Description("TheHighestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "High Water")] 
		[XmlEnum("18")] 
		HighWater = 18,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanSeaLevelMsl")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		[XmlEnum("19")] 
		ApproximateMeanSeaLevel = 19,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingThatOfMeanHighWaterSpringsMhws")]
		[EnumMember(Value = "High Water Springs")] 
		[XmlEnum("20")] 
		HighWaterSprings = 20,

		[System.ComponentModel.Description("TheAverageHeightOfHigherHighWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Higher High Water")] 
		[XmlEnum("21")] 
		MeanHigherHighWater = 21,

		[System.ComponentModel.Description("TheLevelOfLowWaterSpringsNearTheTimeOfAnEquinox")]
		[EnumMember(Value = "Equinoctial Spring Low Water")] 
		[XmlEnum("22")] 
		EquinoctialSpringLowWater = 22,

		[System.ComponentModel.Description("TheLowestTideLevelWhichCanBePredictedToOccurUnderAverageMeteorologicalConditionsAndUnderAnyCombinationOfAstronomicalConditions")]
		[EnumMember(Value = "Lowest Astronomical Tide")] 
		[XmlEnum("23")] 
		LowestAstronomicalTide = 23,

		[System.ComponentModel.Description("AnArbitraryDatumDefinedByALocalHarbourAuthorityFromWhichLevelsAndTidalHeightsAreMeasuredByThisAuthority")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("24")] 
		LocalDatum = 24,

		[System.ComponentModel.Description("AVerticalReferenceSystemWithItsZeroBasedOnTheMeanWaterLevelAtRimouskiPointeAuPereQuebecOverThePeriod1970To1988")]
		[EnumMember(Value = "International Great Lakes Datum 1985")] 
		[XmlEnum("25")] 
		InternationalGreatLakesDatum1985 = 25,

		[System.ComponentModel.Description("TheAverageOfAllHourlyWaterLevelsOverTheAvailablePeriodOfRecord")]
		[EnumMember(Value = "Mean Water Level")] 
		[XmlEnum("26")] 
		MeanWaterLevel = 26,

		[System.ComponentModel.Description("TheAverageOfTheLowestLowWatersOneFromEachOf19YearsOfObservations")]
		[EnumMember(Value = "Lower Low Water Large Tide")] 
		[XmlEnum("27")] 
		LowerLowWaterLargeTide = 27,

		[System.ComponentModel.Description("TheAverageOfTheHighestHighWatersOneFromEachOf19YearsOfObservations")]
		[EnumMember(Value = "Higher High Water Large Tide")] 
		[XmlEnum("28")] 
		HigherHighWaterLargeTide = 28,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingTheHighestWaterLevelObservedAtAPlaceUsuallyEquivalentToTheHighWaterSprings")]
		[EnumMember(Value = "Nearly Highest High Water")] 
		[XmlEnum("29")] 
		NearlyHighestHighWater = 29,

		[System.ComponentModel.Description("TheHighestTidalLevelWhichCanBePredictedToOccurUnderAverageMeteorologicalConditionsAndUnderAnyCombinationOfAstronomicalConditions")]
		[EnumMember(Value = "Highest Astronomical Tide")] 
		[XmlEnum("30")] 
		HighestAstronomicalTide = 30,

		[System.ComponentModel.Description("TheDatumRefersToEachBalticCountrySRealizationOfTheEuropeanVerticalReferenceSystemEvrsWithLandUpliftEpoch2000WhichIsConnectedToTheNormaalAmsterdamsPeilNap")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		[XmlEnum("44")] 
		BalticSeaChartDatum2000 = 44,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[System.ComponentModel.Description("TheMaximumLengthOfTheShip")]
		[EnumMember(Value = "Length Overall")] 
		[XmlEnum("1")] 
		LengthOverall = 1,

		[System.ComponentModel.Description("TheShipSLengthMeasuredAtTheWaterline")]
		[EnumMember(Value = "Length at Waterline")] 
		[XmlEnum("2")] 
		LengthAtWaterline = 2,

		[System.ComponentModel.Description("TheWidthOrBeamOfTheVessel")]
		[EnumMember(Value = "Breadth")] 
		[XmlEnum("3")] 
		Breadth = 3,

		[System.ComponentModel.Description("TheDepthOfWaterNecessaryToFloatAVesselFullyLoaded")]
		[EnumMember(Value = "Draught")] 
		[XmlEnum("4")] 
		Draught = 4,

		[System.ComponentModel.Description("AMeasurementOfTheWeightOfTheVesselUsuallyUsedForWarshipsMerchantShipsAreUsuallyMeasuredBasedOnTheVolumeOfCargoSpaceSeeTonnageDisplacementIsExpressedEitherInLongTonsOf2240PoundsOrMetricTonnesOf1000KgSinceTheTwoUnitsAreVeryCloseInSize2240Pounds1016KgAnd1000Kg2205PoundsItIsCommonNotToDistinguishBetweenThemToPreserveSecrecyNationsSometimesMisstateAWarshipSDisplacement")]
		[EnumMember(Value = "Displacement Tonnage")] 
		[XmlEnum("6")] 
		DisplacementTonnage = 6,

		[System.ComponentModel.Description("TheWeightOfTheShipExcludingCargoFuelBallastStoresPassengersAndCrewButWithWaterInTheBoilersToSteamingLevel")]
		[EnumMember(Value = "Displacement Tonnage, Light")] 
		[XmlEnum("7")] 
		DisplacementTonnageLight = 7,

		[System.ComponentModel.Description("TheWeightOfTheShipIncludingCargoPassengersFuelWaterStoresDunnageAndSuchOtherItemsNecessaryForUseOnAVoyageWhichBringsTheVesselDownToHerLoadDraft")]
		[EnumMember(Value = "Displacement Tonnage, Loaded")] 
		[XmlEnum("8")] 
		DisplacementTonnageLoaded = 8,

		[System.ComponentModel.Description("TheDifferenceBetweenDisplacementLightAndDisplacementLoadedAMeasureOfTheShipSTotalCarryingCapacity")]
		[EnumMember(Value = "Deadweight Tonnage")] 
		[XmlEnum("9")] 
		DeadweightTonnage = 9,

		[System.ComponentModel.Description("TheEntireInternalCubicCapacityOfTheShipExpressedInTonsOf100CubicFeetToTheTonExceptCertainSpacesWithAreExemptedSuchAsPeakAndOtherTanksForWaterBallastOpenForecastleBridgeAndPoopAccessOfHatchwaysCertainLightAndAirSpacesDomesOfSkylightsCondenserAnchorGearSteeringGearWheelHouseGalleyAndCabinForPassengers")]
		[EnumMember(Value = "Gross Tonnage")] 
		[XmlEnum("10")] 
		GrossTonnage = 10,

		[System.ComponentModel.Description("ObtainedFromTheGrossTonnageByDeductingCrewAndNavigatingSpacesAndAllowancesForPropulsionMachinery")]
		[EnumMember(Value = "Net Tonnage")] 
		[XmlEnum("11")] 
		NetTonnage = 11,

		[System.ComponentModel.Description("ThePanamaCanalUniversalMeasurementSystemPcUmsIsBasedOnNetTonnageModifiedForPanamaCanalPurposesPcUmsIsBasedOnAMathematicalFormulaToCalculateAVesselSTotalVolumeAPcUmsNetTonIsEquivalentTo100CubicFeetOfCapacity")]
		[EnumMember(Value = "Panama Canal/Universal Measurement System Net Tonnage")] 
		[XmlEnum("12")] 
		PanamaCanalUniversalMeasurementSystemNetTonnage = 12,

		[System.ComponentModel.Description("TheSuezCanalNetTonnageScntIsDerivedWithANumberOfModificationsFromTheFormerNetRegisterTonnageOfTheMoorsomSystemAndWasEstablishedByTheInternationalCommissionOfConstantinopleInItsProtocolOf18December1873ItIsStillInUseAsAmendedByTheRulesOfNavigationOfTheSuezCanalAuthorityAndIsRegisteredInTheSuezCanalTonnageCertificate")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("13")] 
		SuezCanalNetTonnage = 13,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[System.ComponentModel.Description("TheTonneOrMetricTonUSOftenRedundantlyReferredToAsAMetricTonneIsAUnitOfMassEqualTo1000Kg2205LbOrApproximatelyTheMassOfOneCubicMetreOfWaterAtFourDegreesCelsiusItIsSometimesAbbreviatedAsMtInTheUnitedStatesButThisConflictsWithOtherSiSymbolsTheTonneIsNotAUnitInTheInternationalSystemOfUnitsSiButIsAcceptedForUseWithTheSiInSiUnitsAndPrefixesTheTonneIsAMegagramMgTheImperialAndUsCustomaryUnitsComparableToTheTonneAreBothSpelledTonInEnglishThoughTheyDifferInMassPronunciationOfTonneTheWordUsedInTheUkAndTonIsUsuallyIdenticalButIsNotTooConfusingUnlessAccuracyIsImportantAsTheTonneAndUkLongTonDifferByOnly16")]
		[EnumMember(Value = "Metric Ton")] 
		[XmlEnum("3")] 
		MetricTon = 3,

		[System.ComponentModel.Description("LongTonWeightTonOrImperialTonIsTheNameForTheUnitCalledTheTonInTheAvoirdupoisOrImperialSystemOfMeasurementsAsUsedInTheUnitedKingdomAndSeveralOtherCommonwealthCountriesItHasBeenMostlyReplacedByTheTonneAndInTheUnitedStatesByTheShortTonOneLongTonIsEqualTo2240Pounds1016KgOr35CubicFeet09911MOfSaltWaterWithADensityOf64LbFt1025GMlItHasSomeLimitedUseInTheUnitedStatesMostCommonlyInMeasuringTheDisplacementOfShipsAndWasTheUnitPrescribedForWarshipsByTheWashingtonNavalTreatyForExampleBattleshipsWereLimitedToAMassOf35000LongTons36000T39000St")]
		[EnumMember(Value = "Ton")] 
		[XmlEnum("4")] 
		Ton = 4,

		[System.ComponentModel.Description("AUnitOfWeightEqualTo2000Pounds90718474KgInTheUnitedStatesItIsOftenCalledSimplyTonWithoutDistinguishingItFromTheMetricTonTonne1000KilogramsOrTheLongTon2240Pounds10160469088KilogramsRatherTheOtherTwoAreSpecificallyNotedThereAreHoweverSomeUsApplicationsForWhichUnspecifiedTonsNormallyMeansLongTonsForExampleNavyShipsOrMetricTonsWorldGrainProductionFiguresBothTheLongAndShortTonAreDefinedAs20HundredweightsButAHundredweightIs100Pounds45359237KgInTheUsSystemShortOrNetHundredweightAnd112Pounds5080234544KgInTheImperialSystemLongOrGrossHundredweight")]
		[EnumMember(Value = "Short Ton")] 
		[XmlEnum("5")] 
		ShortTon = 5,

		[System.ComponentModel.Description("GrossTonnageGtIsAFunctionOfTheVolumeOfAllShipSEnclosedSpacesFromKeelToFunnelMeasuredToTheOutsideOfTheHullFramingThereIsASlidingScaleFactorSoGtIsAKindOfCapacityDerivedIndexThatIsUsedToRankAShipForPurposesOfDeterminingManningSafetyAndOtherStatutoryRequirementsAndIsExpressedSimplyAsGtWhichIsAUnitlessEntityEvenThoughItsDerivationIsTiedToTheCubicMeterUnitOfVolumetricCapacityTonnageMeasurementsAreNowGovernedByAnImoConventionInternationalConventionOnTonnageMeasurementOfShips1969LondonRulesWhichAppliesToAllShipsBuiltAfterJuly1982InAccordanceWithTheConventionTheCorrectTermToUseNowIsGtWhichIsAFunctionOfTheMouldedVolumeOfAllEnclosedSpacesOfTheShip")]
		[EnumMember(Value = "Gross Ton")] 
		[XmlEnum("6")] 
		GrossTon = 6,

		[System.ComponentModel.Description("NetTonnageNtIsBasedOnACalculationOfTheVolumeOfAllCargoSpacesOfTheShipItIndicatesAVesselsEarningSpaceAndIsAFunctionOfTheMouldedVolumeOfAllCargoSpacesOfTheShip")]
		[EnumMember(Value = "Net Ton")] 
		[XmlEnum("7")] 
		NetTon = 7,

		[System.ComponentModel.Description("TheSuezCanalNetTonnageScntIsDerivedWithANumberOfModificationsFromTheFormerNetRegisterTonnageOfTheMoorsomSystemAndWasEstablishedByTheInternationalCommissionOfConstantinopleInItsProtocolOf18December1873ItIsStillInUseAsAmendedByTheRulesOfNavigationOfTheSuezCanalAuthorityAndIsRegisteredInTheSuezCanalTonnageCertificate")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("9")] 
		SuezCanalNetTonnage = 9,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum wasteDisposalService : int {
		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeOilyBilgeWaterAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Oily Bilge Water")] 
		[XmlEnum("1")] 
		MarpolAnnexIOilyBilgeWater = 1,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeOilyResiduesSludgeAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Oily Residues")] 
		[XmlEnum("2")] 
		MarpolAnnexIOilyResidues = 2,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeOilyTankWashingsSlopsAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Oily Tank Washings")] 
		[XmlEnum("3")] 
		MarpolAnnexIOilyTankWashings = 3,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeDirtyBallastWaterAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Dirty Ballast Water")] 
		[XmlEnum("4")] 
		MarpolAnnexIDirtyBallastWater = 4,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeScaleAndSludgeFromTankCleaningAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Scale and Sludge from Tank Cleaning")] 
		[XmlEnum("5")] 
		MarpolAnnexIScaleAndSludgeFromTankCleaning = 5,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeOtherAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Other Oily Waste")] 
		[XmlEnum("6")] 
		MarpolAnnexIOtherOilyWaste = 6,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveChemicalNoxiousLiquidSubstancesRelatedWasteResidueOfTheTypeCategoryXAsSpecifiedInMarpolAnnexIi")]
		[EnumMember(Value = "MARPOL Annex II Category X")] 
		[XmlEnum("7")] 
		MarpolAnnexIiCategoryX = 7,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveChemicalNoxiousLiquidSubstancesRelatedWasteResidueOfTheTypeCategoryYAsSpecifiedInMarpolAnnexIi")]
		[EnumMember(Value = "MARPOL Annex II Category Y")] 
		[XmlEnum("8")] 
		MarpolAnnexIiCategoryY = 8,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveChemicalNoxiousLiquidSubstancesRelatedWasteResidueOfTheTypeCategoryZAsSpecifiedInMarpolAnnexIi")]
		[EnumMember(Value = "MARPOL Annex II Category Z")] 
		[XmlEnum("9")] 
		MarpolAnnexIiCategoryZ = 9,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveChemicalNoxiousLiquidSubstancesRelatedWasteResidueOfTheTypeOtherSubstanceAsSpecifiedInMarpolAnnexIi")]
		[EnumMember(Value = "MARPOL Annex II Category OS")] 
		[XmlEnum("10")] 
		MarpolAnnexIiCategoryOs = 10,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveWasteResidueOfTheTypeSewageAsSpecifiedInMarpolAnnexIv")]
		[EnumMember(Value = "MARPOL Annex IV Sewage")] 
		[XmlEnum("11")] 
		MarpolAnnexIvSewage = 11,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypePlasticsAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Plastics")] 
		[XmlEnum("12")] 
		MarpolAnnexVPlastics = 12,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeFoodWastesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Food Wastes")] 
		[XmlEnum("13")] 
		MarpolAnnexVFoodWastes = 13,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeDomesticWastesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Domestic Wastes")] 
		[XmlEnum("14")] 
		MarpolAnnexVDomesticWastes = 14,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeCookingOilAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Cooking Oil")] 
		[XmlEnum("15")] 
		MarpolAnnexVCookingOil = 15,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeIncineratorAshesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Incinerator Ashes")] 
		[XmlEnum("16")] 
		MarpolAnnexVIncineratorAshes = 16,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeOperationalWastesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Operational Wastes")] 
		[XmlEnum("17")] 
		MarpolAnnexVOperationalWastes = 17,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeAnimalCarcassesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Animal Carcasses")] 
		[XmlEnum("18")] 
		MarpolAnnexVAnimalCarcasses = 18,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeFishingGearAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Fishing Gear")] 
		[XmlEnum("19")] 
		MarpolAnnexVFishingGear = 19,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeEWasteAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V E-Waste")] 
		[XmlEnum("20")] 
		MarpolAnnexVEWaste = 20,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeCargoResiduesNotDeterminedToBeHarmfulToTheMarineEnvironmentAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Cargo Residues - non-HME")] 
		[XmlEnum("21")] 
		MarpolAnnexVCargoResiduesNonHme = 21,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeCargoResiduesHarmfulToTheMarineEnvironmentAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Cargo Residues - HME")] 
		[XmlEnum("22")] 
		MarpolAnnexVCargoResiduesHme = 22,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveAirPollutionRelatedWasteResidueOfTheTypeOzoneDepletingSubstancesAsSpecifiedInMarpolAnnexVi")]
		[EnumMember(Value = "MARPOL Annex VI Ozone-Depleting Substances")] 
		[XmlEnum("23")] 
		MarpolAnnexViOzoneDepletingSubstances = 23,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveAirPollutionRelatedWasteResidueOfTheTypeExhaustGasCleaningResiduesAsSpecifiedInMarpolAnnexVi")]
		[EnumMember(Value = "MARPOL Annex VI Exhaust Gas-Cleaning Residues")] 
		[XmlEnum("24")] 
		MarpolAnnexViExhaustGasCleaningResidues = 24,
	}

	[System.Serializable()]
	public class actionOrActivity
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	[System.Serializable()]
	public class categoryOfRxN
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	[System.Serializable()]
	public class categoryOfVessel
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	[System.Serializable()]
	public class securitySafetyEmergencyService
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

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
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress {
			[XmlElement("deliveryPoint")]
			public List<String> deliveryPoint {get;set;} = [];

			public bool ShouldSerializedeliveryPoint() { return deliveryPoint.Any(); }

			[XmlElement("cityName")]
			public String? cityName {get;set;} = default;

			public bool ShouldSerializecityName() { return !string.IsNullOrEmpty(cityName); }

			[XmlElement("administrativeDivision")]
			public String? administrativeDivision {get;set;} = default;

			public bool ShouldSerializeadministrativeDivision() { return !string.IsNullOrEmpty(administrativeDivision); }

			[XmlElement("countryName")]
			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlElement("postalCode")]
			public String? postalCode {get;set;} = default;

			public bool ShouldSerializepostalCode() { return !string.IsNullOrEmpty(postalCode); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			[XmlElement("displayName")]
			public Boolean? displayName {get;set;} = default;

			public bool ShouldSerializedisplayName() { return displayName.HasValue; }

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("name")]
			public required String name {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class fixedDateRange {
			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			[XmlElement("dateEnd")]
			public String? dateEnd {get;set;} = default;

			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair {
			[XmlElement("frequencyShoreStationTransmits")]
			public List<int> frequencyShoreStationTransmits {get;set;} = [];

			public bool ShouldSerializefrequencyShoreStationTransmits() { return frequencyShoreStationTransmits.Any(); }

			[XmlElement("frequencyShoreStationReceives")]
			public List<int> frequencyShoreStationReceives {get;set;} = [];

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.Any(); }

			[XmlElement("contactInstructions")]
			public List<String> contactInstructions {get;set;} = [];

			public bool ShouldSerializecontactInstructions() { return contactInstructions.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty {
			[XmlElement("uncertaintyFixed")]
			public required decimal uncertaintyFixed {get;set;} = default;

			[XmlElement("uncertaintyVariableFactor")]
			public decimal? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			[XmlElement("fileLocator")]
			public String? fileLocator {get;set;} = default;

			public bool ShouldSerializefileLocator() { return !string.IsNullOrEmpty(fileLocator); }

			[XmlElement("fileReference")]
			public String? fileReference {get;set;} = default;

			public bool ShouldSerializefileReference() { return !string.IsNullOrEmpty(fileReference); }

			[XmlElement("headline")]
			public List<String> headline {get;set;} = [];

			public bool ShouldSerializeheadline() { return headline.Any(); }

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("onlineResourceLinkageURL")]
			public required String onlineResourceLinkageURL {get;set;} = string.Empty;

			[XmlElement("protocol")]
			public String? protocol {get;set;} = default;

			public bool ShouldSerializeprotocol() { return !string.IsNullOrEmpty(protocol); }

			[XmlElement("applicationProfile")]
			public String? applicationProfile {get;set;} = default;

			public bool ShouldSerializeapplicationProfile() { return !string.IsNullOrEmpty(applicationProfile); }

			[XmlElement("nameOfResource")]
			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }

			[XmlElement("onlineResourceDescription")]
			public String? onlineResourceDescription {get;set;} = default;

			public bool ShouldSerializeonlineResourceDescription() { return !string.IsNullOrEmpty(onlineResourceDescription); }

			[XmlElement("onlineFunction")]
			[EnumerationValue([1,3,4,5,6,7,8,9,10,11])]
			public onlineFunction? onlineFunction {get;set;} = default;

			public bool ShouldSerializeonlineFunction() { return onlineFunction.HasValue; }

			[XmlElement("protocolRequest")]
			public String? protocolRequest {get;set;} = default;

			public bool ShouldSerializeprotocolRequest() { return !string.IsNullOrEmpty(protocolRequest); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation {
			[XmlElement("orientationUncertainty")]
			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			[XmlElement("orientationValue")]
			public required decimal orientationValue {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[XmlElement("dateStart")]
			public required String dateStart {get;set;} = string.Empty;

			[XmlElement("dateEnd")]
			public required String dateEnd {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rxNCode {
			[XmlElement("categoryOfRxN")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public categoryOfRxN? categoryOfRxN {get;set;} = default;

			public bool ShouldSerializecategoryOfRxN() { return categoryOfRxN != default; }

			[XmlElement("actionOrActivity")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public actionOrActivity? actionOrActivity {get;set;} = default;

			public bool ShouldSerializeactionOrActivity() { return actionOrActivity != default; }

			[XmlElement("headline")]
			public List<String> headline {get;set;} = [];

			public bool ShouldSerializeheadline() { return headline.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surveyDateRange {
			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }

			[XmlElement("dateEnd")]
			public required String dateEnd {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textContent {
			[XmlElement("categoryOfText")]
			[EnumerationValue([1,2,3])]
			public categoryOfText? categoryOfText {get;set;} = default;

			public bool ShouldSerializecategoryOfText() { return categoryOfText.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("onlineResource")]
			public onlineResource? onlineResource {get;set;} = default;

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlElement("sourceType")]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalsByDayOfWeek {
			[XmlElement("dayOfWeek")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public List<dayOfWeek> dayOfWeek {get;set;} = [];

			public bool ShouldSerializedayOfWeek() { return dayOfWeek.Any(); }

			[XmlElement("dayOfWeekIsRange")]
			public Boolean? dayOfWeekIsRange {get;set;} = default;

			public bool ShouldSerializedayOfWeekIsRange() { return dayOfWeekIsRange.HasValue; }

			[XmlElement("timeOfDayStart")]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayStart {get;set;} = [];

			public bool ShouldSerializetimeOfDayStart() { return timeOfDayStart.Any(); }

			[XmlElement("timeOfDayEnd")]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayEnd {get;set;} = [];

			public bool ShouldSerializetimeOfDayEnd() { return timeOfDayEnd.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class usefulMarkDescription {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalUncertainty {
			[XmlElement("uncertaintyFixed")]
			public required decimal uncertaintyFixed {get;set;} = default;

			[XmlElement("uncertaintyVariableFactor")]
			public decimal? uncertaintyVariableFactor {get;set;} = default;

			public bool ShouldSerializeuncertaintyVariableFactor() { return uncertaintyVariableFactor.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselsMeasurements {
			[XmlElement("comparisonOperator")]
			[EnumerationValue([1,2,3,4,5,6])]
			public required comparisonOperator comparisonOperator {get;set;} = default;

			[XmlElement("vesselsCharacteristics")]
			[EnumerationValue([1,2,3,4,6,7,8,9,10,11,12,13])]
			public required vesselsCharacteristics vesselsCharacteristics {get;set;} = default;

			[XmlElement("vesselsCharacteristicsValue")]
			public required decimal vesselsCharacteristicsValue {get;set;} = default;

			[XmlElement("vesselsCharacteristicsUnit")]
			[EnumerationValue([1,3,4,5,6,7,9])]
			public required vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class weatherResource {
			[XmlElement("onlineResource")]
			public onlineResource? onlineResource {get;set;} = default;

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			[XmlElement("dynamicResource")]
			[EnumerationValue([1,2,3,4])]
			public dynamicResource? dynamicResource {get;set;} = default;

			public bool ShouldSerializedynamicResource() { return dynamicResource.HasValue; }

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class bearingInformation {
			[XmlElement("cardinalDirection")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public cardinalDirection? cardinalDirection {get;set;} = default;

			public bool ShouldSerializecardinalDirection() { return cardinalDirection.HasValue; }

			[XmlElement("distance")]
			public decimal? distance {get;set;} = default;

			public bool ShouldSerializedistance() { return distance.HasValue; }

			[XmlElement("sectorBearing")]
			public List<decimal> sectorBearing {get;set;} = [];

			public bool ShouldSerializesectorBearing() { return sectorBearing.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("orientation")]
			public orientation? orientation {get;set;} = default;

			public bool ShouldSerializeorientation() { return orientation!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class cargoServicesDescription {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class constructionInformation {
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("condition")]
			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("development")]
			public required String development {get;set;} = string.Empty;

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class depthsDescription {
			[XmlElement("categoryOfDepthsDescription")]
			[EnumerationValue([1,2,3])]
			public required categoryOfDepthsDescription categoryOfDepthsDescription {get;set;} = default;

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class facilitiesLayoutDescription {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class generalPortDescription {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class graphic {
			[XmlElement("pictorialRepresentation")]
			public List<String> pictorialRepresentation {get;set;} = [];

			public bool ShouldSerializepictorialRepresentation() { return pictorialRepresentation.Any(); }

			[XmlElement("pictureCaption")]
			public String? pictureCaption {get;set;} = default;

			public bool ShouldSerializepictureCaption() { return !string.IsNullOrEmpty(pictureCaption); }

			[XmlElement("sourceDate")]
			[XmlIgnore]
			public DateOnly? sourceDate {get;set;} = default;

			public bool ShouldSerializesourceDate() { return sourceDate.HasValue; }

			[XmlElement("pictureInformation")]
			public String? pictureInformation {get;set;} = default;

			public bool ShouldSerializepictureInformation() { return !string.IsNullOrEmpty(pictureInformation); }

			[XmlElement("bearingInformation")]
			public bearingInformation? bearingInformation {get;set;} = default;

			public bool ShouldSerializebearingInformation() { return bearingInformation!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class landmarkDescription {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class limitsDescription {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class majorLightDescription {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class markedBy {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class offshoreMarkDescription {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class scheduleByDayOfWeek {
			[XmlElement("categoryOfSchedule")]
			[EnumerationValue([1,2,3])]
			public categoryOfSchedule? categoryOfSchedule {get;set;} = default;

			public bool ShouldSerializecategoryOfSchedule() { return categoryOfSchedule.HasValue; }

			[XmlElement("timeIntervalsByDayOfWeek")]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class spatialAccuracy {
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			[XmlElement("categoryOfCommunicationPreference")]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlElement("telecommunicationIdentifier")]
			public required String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlElement("telecommunicationCarrier")]
			public String? telecommunicationCarrier {get;set;} = default;

			public bool ShouldSerializetelecommunicationCarrier() { return !string.IsNullOrEmpty(telecommunicationCarrier); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("telecommunicationService")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.Any(); }

			[XmlElement("scheduleByDayOfWeek")]
			public scheduleByDayOfWeek? scheduleByDayOfWeek {get;set;} = default;

			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class generalHarbourInformation {
			[XmlElement("generalPortDescription")]
			public generalPortDescription? generalPortDescription {get;set;} = default;

			public bool ShouldSerializegeneralPortDescription() { return generalPortDescription!=default; }

			[XmlElement("facilitiesLayoutDescription")]
			public facilitiesLayoutDescription? facilitiesLayoutDescription {get;set;} = default;

			public bool ShouldSerializefacilitiesLayoutDescription() { return facilitiesLayoutDescription!=default; }

			[XmlElement("limitsDescription")]
			public limitsDescription? limitsDescription {get;set;} = default;

			public bool ShouldSerializelimitsDescription() { return limitsDescription!=default; }

			[XmlElement("constructionInformation")]
			public constructionInformation? constructionInformation {get;set;} = default;

			public bool ShouldSerializeconstructionInformation() { return constructionInformation!=default; }

			[XmlElement("cargoServicesDescription")]
			public cargoServicesDescription? cargoServicesDescription {get;set;} = default;

			public bool ShouldSerializecargoServicesDescription() { return cargoServicesDescription!=default; }

			[XmlElement("weatherResource")]
			public List<weatherResource> weatherResource {get;set;} = [];

			public bool ShouldSerializeweatherResource() { return weatherResource.Any(); }
		}

	}
	public enum Role {
		[System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
		positions,
		[System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
		componentOf,
		[System.ComponentModel.Description("A pointer to a specific feature(s) for which further information is required.")]
		informationProvidedFor,
		[System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
		providesInformation,
		[System.ComponentModel.Description("The applicable regulation, restriction, recommendation or nautical information")]
		theApplicableRxN,
		[System.ComponentModel.Description("The location in which the information item applies")]
		appliesInLocation,
		[System.ComponentModel.Description("A pointer to an Authority object")]
		theAuthority,
		[System.ComponentModel.Description("The authority for which service hours are given")]
		theAuthority_srvHrs,
		[System.ComponentModel.Description("A pointer to an Contact Details object")]
		theContactDetails,
		[System.ComponentModel.Description("The controlling organization or authority for a geographically located service")]
		controlAuthority,
		[System.ComponentModel.Description("The service controlled by an organisation or authority")]
		controlledService,
		[System.ComponentModel.Description("A pointer to a specific feature(s).")]
		identifies,
		[System.ComponentModel.Description("The object or class of objects to which the regulation, restriction, recommendation, or nautical information applies")]
		isApplicableTo,
		[System.ComponentModel.Description("Service hours for an authority or service provider")]
		theServiceHours,
		[System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
		theRxN,
		[System.ComponentModel.Description("The usual service hours to which an exception applies")]
		theServiceHours_nsdy,
		[System.ComponentModel.Description("The location to which the permission statement applies")]
		vslLocation,
		[System.ComponentModel.Description("The work hours for a non-standard workday")]
		partialWorkingDay,
		[System.ComponentModel.Description("Pointer to service or facility")]
		servicePlace,
		[System.ComponentModel.Description("The location for which service hours are given")]
		location_srvHrs,
		[System.ComponentModel.Description("The organisation to which information relates")]
		theOrganisation,
		[System.ComponentModel.Description("Information related to an organisation")]
		theInformation,
		[System.ComponentModel.Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.")]
		permission,
		[System.ComponentModel.Description("Reference to a whole of the same type as the part feature in the relationship.")]
		constitute,
		[System.ComponentModel.Description("A reference to a feature that supplements or supports the use of the primary feature in an AuxiliaryFacility relationship.")]
		auxiliaryFacility,
		[System.ComponentModel.Description("Reference to the feature within which locations are demarcated.")]
		demarcatedFeature,
		[System.ComponentModel.Description("Reference to a feature demarcating a location within another feature.")]
		demarcationIndicator,
		[System.ComponentModel.Description("Reference to an information type describing the entrance to a limit area.")]
		entranceReference,
		[System.ComponentModel.Description("A reference to the feature to which entrance information pertains.")]
		entranceTo,
		[System.ComponentModel.Description("Reference to the feature describing a particular instance of physical infrastructure.")]
		hasInfrastructure,
		[System.ComponentModel.Description("Reference to the feature within which the infrastructure is located.")]
		infrastructureLocation,
		[System.ComponentModel.Description("Reference to a feature demarcating the extent to which a coastal State claims or may claim a specific jurisdiction.")]
		limitExtent,
		[System.ComponentModel.Description("Reference to the feature for which a coastal State claims a specific jurisdiction different from the feature's geographic boundary.")]
		limitReference,
		[System.ComponentModel.Description("A reference to the diverse units comprising a feature of a different type.")]
		layoutUnit,
		[System.ComponentModel.Description("Reference to the location (feature) where specified services are available.")]
		locationServed,
		[System.ComponentModel.Description("Reference to information about the days and times during which a facility operates or may be used.")]
		facilityOperatingHours,
		[System.ComponentModel.Description("A reference to the primary feature in an Auxiliaryfacility relationship.")]
		primaryFacility,
		[System.ComponentModel.Description("Reference to an information object describing services.")]
		serviceDescriptionReference,
		[System.ComponentModel.Description("Reference to a part of the same type as the whole feature in the relationship.")]
		subUnit,
		[System.ComponentModel.Description("A pointer to a specific spatial type(s).")]
		definedFor,
		[System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
		defines,
	}

	namespace InformationAssociations {
		/// <summary>
		/// A feature association for the binding between at least one instance of a geo feature and an instance of an information type.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AdditionalInformation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AdditionalInformation);
		}

		/// <summary>
		/// Contact information for an authority
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityContact : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AuthorityContact);
		}

		/// <summary>
		/// Service hours for an authority
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityHours : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AuthorityHours);
		}

		/// <summary>
		/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AssociatedRxN : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AssociatedRxN);
		}

		/// <summary>
		/// Exception to the usual working day
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ExceptionalWorkday : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ExceptionalWorkday);
		}

		/// <summary>
		/// The controlling authority for a service area
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceControl : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ServiceControl);
		}

		/// <summary>
		/// Contact details for a service or facility
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceContact : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ServiceContact);
		}

		/// <summary>
		/// Working hours for a service or facility described by a geographic location
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocationHours : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(LocationHours);
		}

		/// <summary>
		/// Related organisation
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RelatedOrganisation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(RelatedOrganisation);
		}

		/// <summary>
		/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InclusionType : InformationAssociation {
			[XmlElement("membership")]
			[EnumerationValue([1,2])]
			public required membership membership {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(InclusionType);
		}

		/// <summary>
		/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PermissionType : InformationAssociation {
			[XmlElement("categoryOfRelationship")]
			[EnumerationValue([1,2,3,4,5,6])]
			public required categoryOfRelationship categoryOfRelationship {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(PermissionType);
		}

		/// <summary>
		/// Association for linking spatial quality to spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialAssociation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(SpatialAssociation);
		}

		/// <summary>
		/// Association between a limit feature and the entrance for the limit.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LimitEntrance : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(LimitEntrance);
		}

		/// <summary>
		/// The services available within a location.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceAvailability : InformationAssociation {
			[JsonIgnore]
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
			[JsonIgnore]
			public override string Code => nameof(TextAssociation);
		}

		/// <summary>
		/// A division of a feature into parts of the same type as the whole.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Subsection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(Subsection);
		}

		/// <summary>
		/// The infrastructure facilities in an area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Infrastructure : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(Infrastructure);
		}

		/// <summary>
		/// Describes the relationship between a primary feature and a feature that plays a supporting role in the use of the primary facility by a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PrimaryAuxiliaryFacility : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(PrimaryAuxiliaryFacility);
		}

		/// <summary>
		/// Demarcation of location(s) within a feature by relation to another feature or features
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Demarcation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(Demarcation);
		}

		/// <summary>
		/// The limit(s) of a jurisdiction claimed by a coastal State.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class JurisdictionalLimit : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(JurisdictionalLimit);
		}

		/// <summary>
		/// A division of a feature into parts of type(s) different from the type of the whole.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LayoutDivision : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(LayoutDivision);
		}
	}

}

namespace S100Framework.DomainModel.S131 {
	using ComplexAttributes;
	using InformationAssociations;

	namespace InformationTypes {
		/// <summary>
		/// Generalized information type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class InformationType : InformationNode, IInformationBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("graphic")]
			public List<graphic> graphic {get;set;} = [];

			public bool ShouldSerializegraphic() { return graphic.Any(); }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlElement("sourceType")]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			public override string Code => nameof(InformationType);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationType._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.providesInformation)!,
					informationTypes = [nameof(NauticalInformation)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class AbstractRxN : InformationType {
			[XmlElement("categoryOfAuthority")]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("rxNCode")]
			public List<rxNCode> rxNCode {get;set;} = [];

			public bool ShouldSerializerxNCode() { return rxNCode.Any(); }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[JsonIgnore]
			public override string Code => nameof(AbstractRxN);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..AbstractRxN._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Applicability : InformationType {
			[XmlElement("inBallast")]
			public Boolean? inBallast {get;set;} = default;

			public bool ShouldSerializeinBallast() { return inBallast.HasValue; }

			[XmlElement("categoryOfCargo")]
			[EnumerationValue([2,5,6,7,8,10,11,12,13,14,15])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			[XmlElement("categoryOfDangerousOrHazardousCargo")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21])]
			public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo {get;set;} = [];

			public bool ShouldSerializecategoryOfDangerousOrHazardousCargo() { return categoryOfDangerousOrHazardousCargo.Any(); }

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public categoryOfVessel? categoryOfVessel {get;set;} = default;

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel != default; }

			[XmlElement("categoryOfVesselRegistry")]
			[EnumerationValue([1,2])]
			public categoryOfVesselRegistry? categoryOfVesselRegistry {get;set;} = default;

			public bool ShouldSerializecategoryOfVesselRegistry() { return categoryOfVesselRegistry.HasValue; }

			[XmlElement("logicalConnectives")]
			[EnumerationValue([1,2])]
			public logicalConnectives? logicalConnectives {get;set;} = default;

			public bool ShouldSerializelogicalConnectives() { return logicalConnectives.HasValue; }

			[XmlElement("thicknessOfIceCapability")]
			public int? thicknessOfIceCapability {get;set;} = default;

			public bool ShouldSerializethicknessOfIceCapability() { return thicknessOfIceCapability.HasValue; }

			[XmlElement("vesselPerformance")]
			public String? vesselPerformance {get;set;} = default;

			public bool ShouldSerializevesselPerformance() { return !string.IsNullOrEmpty(vesselPerformance); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("vesselsMeasurements")]
			public List<vesselsMeasurements> vesselsMeasurements {get;set;} = [];

			public bool ShouldSerializevesselsMeasurements() { return vesselsMeasurements.Any(); }

			[JsonIgnore]
			public override string Code => nameof(Applicability);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..Applicability._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(InclusionType),
					role = Enum.GetName<Role>(Role.theApplicableRxN)!,
					informationTypes = [nameof(AbstractRxN)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PermissionType),
					role = Enum.GetName<Role>(Role.vslLocation)!,
					informationTypes = [nameof(InformationType)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A person or organisation having political or administrative power and control.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Authority : InformationType {
			[XmlElement("categoryOfAuthority")]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public required categoryOfAuthority categoryOfAuthority {get;set;} = default;

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }

			[JsonIgnore]
			public override string Code => nameof(Authority);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..Authority._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					role = Enum.GetName<Role>(Role.theInformation)!,
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Services that are available for a given port.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AvailablePortServices : InformationType {
			[XmlElement("firefightingService")]
			[EnumerationValue([1,2,3])]
			public List<firefightingService> firefightingService {get;set;} = [];

			public bool ShouldSerializefirefightingService() { return firefightingService.Any(); }

			[XmlElement("medicalService")]
			[EnumerationValue([1,2,3,4,5])]
			public List<medicalService> medicalService {get;set;} = [];

			public bool ShouldSerializemedicalService() { return medicalService.Any(); }

			[XmlElement("repairService")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public List<repairService> repairService {get;set;} = [];

			public bool ShouldSerializerepairService() { return repairService.Any(); }

			[XmlElement("technicalPortService")]
			[EnumerationValue([1,2,3,4])]
			public List<technicalPortService> technicalPortService {get;set;} = [];

			public bool ShouldSerializetechnicalPortService() { return technicalPortService.Any(); }

			[XmlElement("shipSanitationControl")]
			[EnumerationValue([1,2,3])]
			public List<shipSanitationControl> shipSanitationControl {get;set;} = [];

			public bool ShouldSerializeshipSanitationControl() { return shipSanitationControl.Any(); }

			[XmlElement("transportConnection")]
			[EnumerationValue([2,3,4,5,6,8,9,11,12,13])]
			public List<transportConnection> transportConnection {get;set;} = [];

			public bool ShouldSerializetransportConnection() { return transportConnection.Any(); }

			[XmlElement("berthingAssistance")]
			[EnumerationValue([1,2,3,4,5,6])]
			public List<berthingAssistance> berthingAssistance {get;set;} = [];

			public bool ShouldSerializeberthingAssistance() { return berthingAssistance.Any(); }

			[XmlElement("cargoService")]
			[EnumerationValue([1,2,3,4])]
			public List<cargoService> cargoService {get;set;} = [];

			public bool ShouldSerializecargoService() { return cargoService.Any(); }

			[XmlElement("securitySafetyEmergencyService")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<securitySafetyEmergencyService> securitySafetyEmergencyService {get;set;} = [];

			public bool ShouldSerializesecuritySafetyEmergencyService() { return securitySafetyEmergencyService.Any(); }

			[XmlElement("wasteDisposalService")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
			public List<wasteDisposalService> wasteDisposalService {get;set;} = [];

			public bool ShouldSerializewasteDisposalService() { return wasteDisposalService.Any(); }

			[XmlElement("supplyService")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public List<supplyService> supplyService {get;set;} = [];

			public bool ShouldSerializesupplyService() { return supplyService.Any(); }

			[XmlElement("tugInformation")]
			public String? tugInformation {get;set;} = default;

			public bool ShouldSerializetugInformation() { return !string.IsNullOrEmpty(tugInformation); }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[JsonIgnore]
			public override string Code => nameof(AvailablePortServices);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..AvailablePortServices._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContactDetails : InformationType {
			[XmlElement("callName")]
			public String? callName {get;set;} = default;

			public bool ShouldSerializecallName() { return !string.IsNullOrEmpty(callName); }

			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlElement("categoryOfCommunicationPreference")]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("signalFrequency")]
			public List<int> signalFrequency {get;set;} = [];

			public bool ShouldSerializesignalFrequency() { return signalFrequency.Any(); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[JsonIgnore]
			public override string Code => nameof(ContactDetails);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ContactDetails._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// The seaward end of a channel, harbour, dock, etc.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Entrance : InformationType {
			[XmlElement("entranceDescription")]
			public String? entranceDescription {get;set;} = default;

			public bool ShouldSerializeentranceDescription() { return !string.IsNullOrEmpty(entranceDescription); }

			[XmlElement("associatedFeatureName")]
			public List<String> associatedFeatureName {get;set;} = [];

			public bool ShouldSerializeassociatedFeatureName() { return associatedFeatureName.Any(); }

			[XmlElement("localKnowledgeDescription")]
			public String? localKnowledgeDescription {get;set;} = default;

			public bool ShouldSerializelocalKnowledgeDescription() { return !string.IsNullOrEmpty(localKnowledgeDescription); }

			[XmlElement("approachDescription")]
			public String? approachDescription {get;set;} = default;

			public bool ShouldSerializeapproachDescription() { return !string.IsNullOrEmpty(approachDescription); }

			[XmlElement("markedBy")]
			public List<markedBy> markedBy {get;set;} = [];

			public bool ShouldSerializemarkedBy() { return markedBy.Any(); }

			[XmlElement("landmarkDescription")]
			public List<landmarkDescription> landmarkDescription {get;set;} = [];

			public bool ShouldSerializelandmarkDescription() { return landmarkDescription.Any(); }

			[XmlElement("offshoreMarkDescription")]
			public List<offshoreMarkDescription> offshoreMarkDescription {get;set;} = [];

			public bool ShouldSerializeoffshoreMarkDescription() { return offshoreMarkDescription.Any(); }

			[XmlElement("majorLightDescription")]
			public List<majorLightDescription> majorLightDescription {get;set;} = [];

			public bool ShouldSerializemajorLightDescription() { return majorLightDescription.Any(); }

			[XmlElement("usefulMarkDescription")]
			public List<usefulMarkDescription> usefulMarkDescription {get;set;} = [];

			public bool ShouldSerializeusefulMarkDescription() { return usefulMarkDescription.Any(); }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[JsonIgnore]
			public override string Code => nameof(Entrance);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..Entrance._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Nautical information about a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NauticalInformation : AbstractRxN {
			[JsonIgnore]
			public override string Code => nameof(NauticalInformation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..NauticalInformation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.informationProvidedFor)!,
					informationTypes = [nameof(InformationType)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NonStandardWorkingDay : InformationType {
			[XmlElement("dateFixed")]
			public List<String> dateFixed {get;set;} = [];

			public bool ShouldSerializedateFixed() { return dateFixed.Any(); }

			[XmlElement("dateVariable")]
			public List<String> dateVariable {get;set;} = [];

			public bool ShouldSerializedateVariable() { return dateVariable.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(NonStandardWorkingDay);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..NonStandardWorkingDay._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Recommendations for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Recommendations : AbstractRxN {
			[JsonIgnore]
			public override string Code => nameof(Recommendations);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..Recommendations._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Regulations for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Regulations : AbstractRxN {
			[JsonIgnore]
			public override string Code => nameof(Regulations);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..Regulations._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Restrictions for a related area or facility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Restrictions : AbstractRxN {
			[JsonIgnore]
			public override string Code => nameof(Restrictions);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..Restrictions._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// The time when a service is available and known exceptions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceHours : InformationType {
			[XmlElement("scheduleByDayOfWeek")]
			public List<scheduleByDayOfWeek> scheduleByDayOfWeek {get;set;} = [];

			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(ServiceHours);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ServiceHours._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// The indication of the quality of the locational information for features in a dataset.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQuality : InformationNode, IInformationBindingDefinition {
			[XmlElement("qualityOfHorizontalMeasurement")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			[XmlElement("spatialAccuracy")]
			public List<spatialAccuracy> spatialAccuracy {get;set;} = [];

			public bool ShouldSerializespatialAccuracy() { return spatialAccuracy.Any(); }

			[JsonIgnore]
			public override string Code => nameof(SpatialQuality);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}
	}
	namespace FeatureTypes {
		using FeatureAssociations;
		using InformationTypes;
		using System.Xml;

		/// <summary>
		/// Generalized feature type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FeatureType : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("locationMRN")]
			public String? locationMRN {get;set;} = default;

			public bool ShouldSerializelocationMRN() { return !string.IsNullOrEmpty(locationMRN); }

			[XmlElement("globalLocationNumber")]
			public String? globalLocationNumber {get;set;} = default;

			public bool ShouldSerializeglobalLocationNumber() { return !string.IsNullOrEmpty(globalLocationNumber); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("rxNCode")]
			public List<rxNCode> rxNCode {get;set;} = [];

			public bool ShouldSerializerxNCode() { return rxNCode.Any(); }

			[XmlElement("graphic")]
			public List<graphic> graphic {get;set;} = [];

			public bool ShouldSerializegraphic() { return graphic.Any(); }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlElement("sourceType")]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[JsonIgnore]
			public override string Code => nameof(FeatureType);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FeatureType._informationBindingDefinitions;
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
					role = Enum.GetName<Role>(Role.providesInformation)!,
					informationTypes = [nameof(NauticalInformation)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureType._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => FeatureType._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.positions)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A feature often associated with contact information for an organization that exercises a management role or offers a service in the location.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class OrganizationContactArea : FeatureType {
			[JsonIgnore]
			public override string Code => nameof(OrganizationContactArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..OrganizationContactArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..OrganizationContactArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..OrganizationContactArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A location which may be supervised by a responsible or controlling authority.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class SupervisedArea : OrganizationContactArea {
			[JsonIgnore]
			public override string Code => nameof(SupervisedArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..OrganizationContactArea._informationBindingDefinitions, ..SupervisedArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..SupervisedArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..SupervisedArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// The physical installations and facilities that support operations in a port or harbour.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class HarbourPhysicalInfrastructure : SupervisedArea {
			[XmlElement("verticalClearanceValue")]
			public decimal? verticalClearanceValue {get;set;} = default;

			public bool ShouldSerializeverticalClearanceValue() { return verticalClearanceValue.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(HarbourPhysicalInfrastructure);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..HarbourPhysicalInfrastructure._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..HarbourPhysicalInfrastructure._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..HarbourPhysicalInfrastructure._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(Infrastructure),
					role = Enum.GetName<Role>(Role.infrastructureLocation)!,
					featureTypes = [nameof(HarbourAreaSection),nameof(Terminal)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// The spatial arrangement of areas and other types of locations that are designated for specified purposes or otherwise distinguished from other areas and locations.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class Layout : SupervisedArea {
			[JsonIgnore]
			public override string Code => nameof(Layout);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..Layout._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..Layout._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..Layout._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A designated area of water where a vessel, sea plane, etc., may anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorBerth : Layout {
			[JsonIgnore]
			public override string Code => nameof(AnchorBerth);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..AnchorBerth._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..AnchorBerth._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..AnchorBerth._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PrimaryAuxiliaryFacility),
					role = Enum.GetName<Role>(Role.auxiliaryFacility)!,
					featureTypes = [nameof(MooringWarpingFacility)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area in which vessels or seaplanes anchor or may anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorageArea : Layout {
			[XmlElement("depthsDescription")]
			public depthsDescription? depthsDescription {get;set;} = default;

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("markedBy")]
			public markedBy? markedBy {get;set;} = default;

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(AnchorageArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..AnchorageArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..AnchorageArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..AnchorageArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A place, generally named or numbered, where a vessel may moor or anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Berth : Layout {
			[XmlElement("availableBerthingLength")]
			public decimal? availableBerthingLength {get;set;} = default;

			public bool ShouldSerializeavailableBerthingLength() { return availableBerthingLength.HasValue; }

			[XmlElement("bollardDescription")]
			public String? bollardDescription {get;set;} = default;

			public bool ShouldSerializebollardDescription() { return !string.IsNullOrEmpty(bollardDescription); }

			[XmlElement("bollardPull")]
			public decimal? bollardPull {get;set;} = default;

			public bool ShouldSerializebollardPull() { return bollardPull.HasValue; }

			[XmlElement("minimumBerthDepth")]
			public decimal? minimumBerthDepth {get;set;} = default;

			public bool ShouldSerializeminimumBerthDepth() { return minimumBerthDepth.HasValue; }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("cathodicProtectionSystem")]
			public Boolean? cathodicProtectionSystem {get;set;} = default;

			public bool ShouldSerializecathodicProtectionSystem() { return cathodicProtectionSystem.HasValue; }

			[XmlElement("categoryOfBerthLocation")]
			[EnumerationValue([1,2,3,4])]
			public categoryOfBerthLocation? categoryOfBerthLocation {get;set;} = default;

			public bool ShouldSerializecategoryOfBerthLocation() { return categoryOfBerthLocation.HasValue; }

			[XmlElement("portFacilityNumber")]
			public String? portFacilityNumber {get;set;} = default;

			public bool ShouldSerializeportFacilityNumber() { return !string.IsNullOrEmpty(portFacilityNumber); }

			[XmlElement("bollardNumber")]
			public List<String> bollardNumber {get;set;} = [];

			public bool ShouldSerializebollardNumber() { return bollardNumber.Any(); }

			[XmlElement("gLNExtension")]
			public String? gLNExtension {get;set;} = default;

			public bool ShouldSerializegLNExtension() { return !string.IsNullOrEmpty(gLNExtension); }

			[XmlElement("metreMarkNumber")]
			public List<String> metreMarkNumber {get;set;} = [];

			public bool ShouldSerializemetreMarkNumber() { return metreMarkNumber.Any(); }

			[XmlElement("manifoldNumber")]
			public List<String> manifoldNumber {get;set;} = [];

			public bool ShouldSerializemanifoldNumber() { return manifoldNumber.Any(); }

			[XmlElement("rampNumber")]
			public String? rampNumber {get;set;} = default;

			public bool ShouldSerializerampNumber() { return !string.IsNullOrEmpty(rampNumber); }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("methodOfSecuring")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public methodOfSecuring? methodOfSecuring {get;set;} = default;

			public bool ShouldSerializemethodOfSecuring() { return methodOfSecuring.HasValue; }

			[XmlElement("uNLocationCode")]
			public required String uNLocationCode {get;set;} = string.Empty;

			[XmlElement("terminalIdentifier")]
			public String? terminalIdentifier {get;set;} = default;

			public bool ShouldSerializeterminalIdentifier() { return !string.IsNullOrEmpty(terminalIdentifier); }

			[JsonIgnore]
			public override string Code => nameof(Berth);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..Berth._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..Berth._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..Berth._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(Demarcation),
					role = Enum.GetName<Role>(Role.demarcationIndicator)!,
					featureTypes = [nameof(BerthPosition)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection),nameof(Terminal)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A specific position within a berth where a vessel may be moored or anchored.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BerthPosition : Layout {
			[XmlElement("availableBerthingLength")]
			public decimal? availableBerthingLength {get;set;} = default;

			public bool ShouldSerializeavailableBerthingLength() { return availableBerthingLength.HasValue; }

			[XmlElement("bollardDescription")]
			public String? bollardDescription {get;set;} = default;

			public bool ShouldSerializebollardDescription() { return !string.IsNullOrEmpty(bollardDescription); }

			[XmlElement("bollardPull")]
			public decimal? bollardPull {get;set;} = default;

			public bool ShouldSerializebollardPull() { return bollardPull.HasValue; }

			[XmlElement("bollardNumber")]
			public List<String> bollardNumber {get;set;} = [];

			public bool ShouldSerializebollardNumber() { return bollardNumber.Any(); }

			[XmlElement("gLNExtension")]
			public String? gLNExtension {get;set;} = default;

			public bool ShouldSerializegLNExtension() { return !string.IsNullOrEmpty(gLNExtension); }

			[XmlElement("metreMarkNumber")]
			public List<String> metreMarkNumber {get;set;} = [];

			public bool ShouldSerializemetreMarkNumber() { return metreMarkNumber.Any(); }

			[XmlElement("manifoldNumber")]
			public List<String> manifoldNumber {get;set;} = [];

			public bool ShouldSerializemanifoldNumber() { return manifoldNumber.Any(); }

			[XmlElement("rampNumber")]
			public String? rampNumber {get;set;} = default;

			public bool ShouldSerializerampNumber() { return !string.IsNullOrEmpty(rampNumber); }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[JsonIgnore]
			public override string Code => nameof(BerthPosition);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..BerthPosition._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..BerthPosition._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..BerthPosition._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 1,
					upper =  1,
					association = nameof(Demarcation),
					role = Enum.GetName<Role>(Role.demarcatedFeature)!,
					featureTypes = [nameof(Berth)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PrimaryAuxiliaryFacility),
					role = Enum.GetName<Role>(Role.auxiliaryFacility)!,
					featureTypes = [nameof(MooringWarpingFacility)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An artificially enclosed area within which ships may moor and which may have gates to regulate water level.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DockArea : Layout {
			[XmlElement("depthsDescription")]
			public depthsDescription? depthsDescription {get;set;} = default;

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("markedBy")]
			public markedBy? markedBy {get;set;} = default;

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(DockArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..DockArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..DockArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..DockArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An artificial basin fitted with a gate or caisson, into which vessels can be floated and the water pumped out to expose the vessel's bottom. Also called graving dock.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DryDock : HarbourPhysicalInfrastructure {
			[XmlElement("sillDepth")]
			public decimal? sillDepth {get;set;} = default;

			public bool ShouldSerializesillDepth() { return sillDepth.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(DryDock);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..HarbourPhysicalInfrastructure._informationBindingDefinitions, ..DryDock._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..HarbourPhysicalInfrastructure._featureBindingDefinitions, ..DryDock._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..DryDock._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A sea area where dredged material or other potentially more harmful material, for example explosives, chemical waste, is deliberately deposited.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DumpingGround : Layout {
			[XmlElement("depthsDescription")]
			public depthsDescription? depthsDescription {get;set;} = default;

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("markedBy")]
			public markedBy? markedBy {get;set;} = default;

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(DumpingGround);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..DumpingGround._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..DumpingGround._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..DumpingGround._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A form of dry dock consisting of a floating structure of one or more sections which can be partly submerged by controlled flooding to receive a vessel, then raised by pumping out the water so that the vessel's bottom can be exposed.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FloatingDock : HarbourPhysicalInfrastructure {
			[XmlElement("sillDepth")]
			public decimal? sillDepth {get;set;} = default;

			public bool ShouldSerializesillDepth() { return sillDepth.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(FloatingDock);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..HarbourPhysicalInfrastructure._informationBindingDefinitions, ..FloatingDock._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FloatingDock._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..FloatingDock._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A structure in the intertidal zone serving as a support for vessels at low stages of the tide to permit work on the exposed portion of the vessel's hull.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Gridiron : HarbourPhysicalInfrastructure {
			[XmlElement("sillDepth")]
			public decimal? sillDepth {get;set;} = default;

			public bool ShouldSerializesillDepth() { return sillDepth.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(Gridiron);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..HarbourPhysicalInfrastructure._informationBindingDefinitions, ..Gridiron._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..HarbourPhysicalInfrastructure._featureBindingDefinitions, ..Gridiron._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..Gridiron._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The area over which a harbour authority has jurisdiction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourAreaAdministrative : Layout {
			[XmlElement("uNLocationCode")]
			public String? uNLocationCode {get;set;} = default;

			public bool ShouldSerializeuNLocationCode() { return !string.IsNullOrEmpty(uNLocationCode); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlElement("applicableLoadLineZone")]
			public String? applicableLoadLineZone {get;set;} = default;

			public bool ShouldSerializeapplicableLoadLineZone() { return !string.IsNullOrEmpty(applicableLoadLineZone); }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[XmlElement("categoryOfHarbourFacility")]
			[EnumerationValue([1,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

			public bool ShouldSerializecategoryOfHarbourFacility() { return categoryOfHarbourFacility.Any(); }

			[XmlElement("generalHarbourInformation")]
			public generalHarbourInformation? generalHarbourInformation {get;set;} = default;

			public bool ShouldSerializegeneralHarbourInformation() { return generalHarbourInformation!=default; }

			[JsonIgnore]
			public override string Code => nameof(HarbourAreaAdministrative);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..HarbourAreaAdministrative._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..HarbourAreaAdministrative._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..HarbourAreaAdministrative._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(JurisdictionalLimit),
					role = Enum.GetName<Role>(Role.limitExtent)!,
					featureTypes = [nameof(OuterLimit)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.layoutUnit)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A distinguishable portion of the area over which a harbour authority has jurisdiction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourAreaSection : Layout {
			[XmlElement("categoryOfPortSection")]
			[EnumerationValue([1,3,8,9,11,12])]
			public categoryOfPortSection? categoryOfPortSection {get;set;} = default;

			public bool ShouldSerializecategoryOfPortSection() { return categoryOfPortSection.HasValue; }

			[XmlElement("categoryOfHarbourFacility")]
			[EnumerationValue([4,5,6,9,14,15,16,17])]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

			public bool ShouldSerializecategoryOfHarbourFacility() { return categoryOfHarbourFacility.Any(); }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[XmlElement("facilitiesLayoutDescription")]
			public facilitiesLayoutDescription? facilitiesLayoutDescription {get;set;} = default;

			public bool ShouldSerializefacilitiesLayoutDescription() { return facilitiesLayoutDescription!=default; }

			[JsonIgnore]
			public override string Code => nameof(HarbourAreaSection);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..HarbourAreaSection._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..HarbourAreaSection._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..HarbourAreaSection._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaAdministrative)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(Subsection),
					role = Enum.GetName<Role>(Role.constitute)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(Subsection),
					role = Enum.GetName<Role>(Role.subUnit)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(Infrastructure),
					role = Enum.GetName<Role>(Role.hasInfrastructure)!,
					featureTypes = [nameof(HarbourPhysicalInfrastructure)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.layoutUnit)!,
					featureTypes = [nameof(AnchorageArea),nameof(Berth),nameof(DockArea),nameof(DumpingGround),nameof(HarbourBasin),nameof(PilotBoardingPlace),nameof(SeaplaneLandingArea),nameof(Terminal),nameof(TurningBasin),nameof(WaterwayArea)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An enclosed area of water surrounded by quay walls constructed to provide means for the transfer of cargos from and to ships.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourBasin : Layout {
			[XmlElement("depthsDescription")]
			public depthsDescription? depthsDescription {get;set;} = default;

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("markedBy")]
			public markedBy? markedBy {get;set;} = default;

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(HarbourBasin);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..HarbourBasin._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..HarbourBasin._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..HarbourBasin._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A harbour installation with a service or commercial operation of public interest.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourFacility : HarbourPhysicalInfrastructure {
			[XmlElement("categoryOfHarbourFacility")]
			[EnumerationValue([12,13])]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

			public bool ShouldSerializecategoryOfHarbourFacility() { return categoryOfHarbourFacility.Any(); }

			[JsonIgnore]
			public override string Code => nameof(HarbourFacility);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..HarbourPhysicalInfrastructure._informationBindingDefinitions, ..HarbourFacility._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..HarbourPhysicalInfrastructure._featureBindingDefinitions, ..HarbourFacility._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..HarbourPhysicalInfrastructure._primitives, ..HarbourFacility._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The equipment or structure used to secure a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringWarpingFacility : Layout {
			[XmlElement("categoryOfMooringWarpingFacility")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility {get;set;} = default;

			[XmlElement("iDCode")]
			public required String iDCode {get;set;} = string.Empty;

			[XmlElement("bollardDescription")]
			public String? bollardDescription {get;set;} = default;

			public bool ShouldSerializebollardDescription() { return !string.IsNullOrEmpty(bollardDescription); }

			[XmlElement("bollardPull")]
			public decimal? bollardPull {get;set;} = default;

			public bool ShouldSerializebollardPull() { return bollardPull.HasValue; }

			[XmlElement("heavingLinesFromShore")]
			public Boolean? heavingLinesFromShore {get;set;} = default;

			public bool ShouldSerializeheavingLinesFromShore() { return heavingLinesFromShore.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(MooringWarpingFacility);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..MooringWarpingFacility._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..MooringWarpingFacility._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..MooringWarpingFacility._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(PrimaryAuxiliaryFacility),
					role = Enum.GetName<Role>(Role.primaryFacility)!,
					featureTypes = [nameof(AnchorBerth),nameof(BerthPosition)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The extent to which a coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OuterLimit : Layout {
			[XmlElement("limitsDescription")]
			public limitsDescription? limitsDescription {get;set;} = default;

			public bool ShouldSerializelimitsDescription() { return limitsDescription!=default; }

			[XmlElement("markedBy")]
			public List<markedBy> markedBy {get;set;} = [];

			public bool ShouldSerializemarkedBy() { return markedBy.Any(); }

			[XmlElement("landmarkDescription")]
			public List<landmarkDescription> landmarkDescription {get;set;} = [];

			public bool ShouldSerializelandmarkDescription() { return landmarkDescription.Any(); }

			[XmlElement("offshoreMarkDescription")]
			public List<offshoreMarkDescription> offshoreMarkDescription {get;set;} = [];

			public bool ShouldSerializeoffshoreMarkDescription() { return offshoreMarkDescription.Any(); }

			[XmlElement("majorLightDescription")]
			public List<majorLightDescription> majorLightDescription {get;set;} = [];

			public bool ShouldSerializemajorLightDescription() { return majorLightDescription.Any(); }

			[XmlElement("usefulMarkDescription")]
			public List<usefulMarkDescription> usefulMarkDescription {get;set;} = [];

			public bool ShouldSerializeusefulMarkDescription() { return usefulMarkDescription.Any(); }

			[JsonIgnore]
			public override string Code => nameof(OuterLimit);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..OuterLimit._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..OuterLimit._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..OuterLimit._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(JurisdictionalLimit),
					role = Enum.GetName<Role>(Role.limitReference)!,
					featureTypes = [nameof(HarbourAreaAdministrative)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotBoardingPlace : Layout {
			[XmlElement("depthsDescription")]
			public depthsDescription? depthsDescription {get;set;} = default;

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("markedBy")]
			public markedBy? markedBy {get;set;} = default;

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(PilotBoardingPlace);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..PilotBoardingPlace._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..PilotBoardingPlace._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..PilotBoardingPlace._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A designated portion of water for the landing and take-off of seaplanes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeaplaneLandingArea : Layout {
			[XmlElement("depthsDescription")]
			public depthsDescription? depthsDescription {get;set;} = default;

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("markedBy")]
			public markedBy? markedBy {get;set;} = default;

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(SeaplaneLandingArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..SeaplaneLandingArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..SeaplaneLandingArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..SeaplaneLandingArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A terminal covers that area on shore which provides buildings and constructions for the transfer of cargo or passengers from and to ships.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Terminal : Layout {
			[XmlElement("portFacilityNumber")]
			public String? portFacilityNumber {get;set;} = default;

			public bool ShouldSerializeportFacilityNumber() { return !string.IsNullOrEmpty(portFacilityNumber); }

			[XmlElement("categoryOfHarbourFacility")]
			[EnumerationValue([1,3,5,7,8,10,11])]
			public categoryOfHarbourFacility? categoryOfHarbourFacility {get;set;} = default;

			public bool ShouldSerializecategoryOfHarbourFacility() { return categoryOfHarbourFacility.HasValue; }

			[XmlElement("categoryOfCargo")]
			[EnumerationValue([2,5,6,7,8,10,11,12,13,14,15])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			[XmlElement("product")]
			[EnumerationValue([1,2,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,22])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("terminalIdentifier")]
			public String? terminalIdentifier {get;set;} = default;

			public bool ShouldSerializeterminalIdentifier() { return !string.IsNullOrEmpty(terminalIdentifier); }

			[XmlElement("sMDGTerminalCode")]
			public String? sMDGTerminalCode {get;set;} = default;

			public bool ShouldSerializesMDGTerminalCode() { return !string.IsNullOrEmpty(sMDGTerminalCode); }

			[XmlElement("uNLocationCode")]
			public String? uNLocationCode {get;set;} = default;

			public bool ShouldSerializeuNLocationCode() { return !string.IsNullOrEmpty(uNLocationCode); }

			[JsonIgnore]
			public override string Code => nameof(Terminal);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..Terminal._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..Terminal._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..Terminal._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.layoutUnit)!,
					featureTypes = [nameof(Berth)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(Infrastructure),
					role = Enum.GetName<Role>(Role.hasInfrastructure)!,
					featureTypes = [nameof(HarbourPhysicalInfrastructure)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area of water or enlargement of a channel used for turning vessels.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TurningBasin : Layout {
			[XmlElement("depthsDescription")]
			public depthsDescription? depthsDescription {get;set;} = default;

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("markedBy")]
			public markedBy? markedBy {get;set;} = default;

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			[XmlElement("iSPSLevel")]
			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public bool ShouldSerializeiSPSLevel() { return iSPSLevel.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(TurningBasin);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..TurningBasin._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..TurningBasin._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..TurningBasin._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area in which uniform general information of the waterway exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WaterwayArea : Layout {
			[XmlElement("categoryOfPortSection")]
			[EnumerationValue([1,3,8,9,11,12])]
			public required categoryOfPortSection categoryOfPortSection {get;set;} = default;

			[XmlElement("depthsDescription")]
			public depthsDescription? depthsDescription {get;set;} = default;

			public bool ShouldSerializedepthsDescription() { return depthsDescription!=default; }

			[XmlElement("locationByText")]
			public String? locationByText {get;set;} = default;

			public bool ShouldSerializelocationByText() { return !string.IsNullOrEmpty(locationByText); }

			[XmlElement("markedBy")]
			public markedBy? markedBy {get;set;} = default;

			public bool ShouldSerializemarkedBy() { return markedBy!=default; }

			[JsonIgnore]
			public override string Code => nameof(WaterwayArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..WaterwayArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..WaterwayArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Layout._primitives, ..WaterwayArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(LayoutDivision),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(HarbourAreaSection)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A geographical area that describes the coverage and extent of spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("maximumDisplayScale")]
			public required int maximumDisplayScale {get;set;} = default;

			[XmlElement("minimumDisplayScale")]
			public required int minimumDisplayScale {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(DataCoverage);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DataCoverage._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfNonBathymetricData : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("categoryOfTemporalVariation")]
			[EnumerationValue([1,2,3,4,5,6])]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			public bool ShouldSerializecategoryOfTemporalVariation() { return categoryOfTemporalVariation.HasValue; }

			[XmlElement("horizontalDistanceUncertainty")]
			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			[XmlElement("horizontalPositionUncertainty")]
			public required horizontalPositionUncertainty horizontalPositionUncertainty {get;set;} = default;

			[XmlElement("orientationUncertainty")]
			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			[XmlElement("surveyDateRange")]
			public surveyDateRange? surveyDateRange {get;set;} = default;

			public bool ShouldSerializesurveyDateRange() { return surveyDateRange!=default; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(QualityOfNonBathymetricData);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => QualityOfNonBathymetricData._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SoundingDatum : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,19,22,23,24,25,26,27,44])]
			public required verticalDatum verticalDatum {get;set;} = default;

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(SoundingDatum);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SoundingDatum._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SoundingDatum._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => SoundingDatum._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Any level surface (for example Mean Sea Level) taken as a surface of reference to which the elevations within a data set are reduced. Also called datum level, reference level, reference plane, levelling datum, datum for heights.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VerticalDatumOfData : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("verticalDatum")]
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			public required verticalDatum verticalDatum {get;set;} = default;

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(VerticalDatumOfData);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => VerticalDatumOfData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => VerticalDatumOfData._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => VerticalDatumOfData._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("orientationValue")]
			public required decimal orientationValue {get;set;} = default;

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }

			[XmlElement("textOffsetMm")]
			public required int textOffsetMm {get;set;} = default;

			[XmlElement("textType")]
			[EnumerationValue([1])]
			public textType? textType {get;set;} = default;

			public bool ShouldSerializetextType() { return textType.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(TextPlacement);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
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
					role = Enum.GetName<Role>(Role.identifies)!,
					featureTypes = [nameof(FeatureType)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S131/1.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S131/1.0 131_1.0.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S131/1.0", TypeName = "members")]
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
		[XmlElement("FeatureTypes.Berth", typeof(FeatureTypes.Berth), Order = 1, ElementName = "Berth")]
		[XmlElement("FeatureTypes.BerthPosition", typeof(FeatureTypes.BerthPosition), Order = 1, ElementName = "BerthPosition")]
		[XmlElement("FeatureTypes.DockArea", typeof(FeatureTypes.DockArea), Order = 1, ElementName = "DockArea")]
		[XmlElement("FeatureTypes.DryDock", typeof(FeatureTypes.DryDock), Order = 1, ElementName = "DryDock")]
		[XmlElement("FeatureTypes.DumpingGround", typeof(FeatureTypes.DumpingGround), Order = 1, ElementName = "DumpingGround")]
		[XmlElement("FeatureTypes.FloatingDock", typeof(FeatureTypes.FloatingDock), Order = 1, ElementName = "FloatingDock")]
		[XmlElement("FeatureTypes.Gridiron", typeof(FeatureTypes.Gridiron), Order = 1, ElementName = "Gridiron")]
		[XmlElement("FeatureTypes.HarbourAreaAdministrative", typeof(FeatureTypes.HarbourAreaAdministrative), Order = 1, ElementName = "HarbourAreaAdministrative")]
		[XmlElement("FeatureTypes.HarbourAreaSection", typeof(FeatureTypes.HarbourAreaSection), Order = 1, ElementName = "HarbourAreaSection")]
		[XmlElement("FeatureTypes.HarbourBasin", typeof(FeatureTypes.HarbourBasin), Order = 1, ElementName = "HarbourBasin")]
		[XmlElement("FeatureTypes.HarbourFacility", typeof(FeatureTypes.HarbourFacility), Order = 1, ElementName = "HarbourFacility")]
		[XmlElement("FeatureTypes.MooringWarpingFacility", typeof(FeatureTypes.MooringWarpingFacility), Order = 1, ElementName = "MooringWarpingFacility")]
		[XmlElement("FeatureTypes.OuterLimit", typeof(FeatureTypes.OuterLimit), Order = 1, ElementName = "OuterLimit")]
		[XmlElement("FeatureTypes.PilotBoardingPlace", typeof(FeatureTypes.PilotBoardingPlace), Order = 1, ElementName = "PilotBoardingPlace")]
		[XmlElement("FeatureTypes.SeaplaneLandingArea", typeof(FeatureTypes.SeaplaneLandingArea), Order = 1, ElementName = "SeaplaneLandingArea")]
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
