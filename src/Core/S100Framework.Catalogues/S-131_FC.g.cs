using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S131 {
	public static class Summary
	{
		public static Version Version => new Version("1.0.0");
		public static string[] ComplexTypes => ["bearingInformation","cargoServicesDescription","constructionInformation","contactAddress","depthsDescription","facilitiesLayoutDescription","featureName","fixedDateRange","frequencyPair","generalHarbourInformation","generalPortDescription","graphic","horizontalPositionUncertainty","information","landmarkDescription","limitsDescription","majorLightDescription","markedBy","offshoreMarkDescription","onlineResource","orientation","periodicDateRange","rxNCode","scheduleByDayOfWeek","spatialAccuracy","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","usefulMarkDescription","verticalUncertainty","vesselsMeasurements","weatherResource"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AuthorityContact","AuthorityHours","AssociatedRxN","ExceptionalWorkday","ServiceControl","ServiceContact","LocationHours","RelatedOrganisation","InclusionType","PermissionType","SpatialAssociation","LimitEntrance","ServiceAvailability"];
		public static string[] FeatureAssociationTypes => ["TextAssociation","Subsection","Infrastructure","PrimaryAuxiliaryFacility","Demarcation","JurisdictionalLimit","LayoutDivision"];
		public static string[] InformationTypes => ["InformationType","AbstractRxN","Applicability","Authority","AvailablePortServices","ContactDetails","Entrance","NauticalInformation","NonStandardWorkingDay","Recommendations","Regulations","Restrictions","ServiceHours","SpatialQuality"];
		public static string[] FeatureTypes => ["FeatureType","OrganizationContactArea","SupervisedArea","HarbourPhysicalInfrastructure","Layout","AnchorBerth","AnchorageArea","Berth","BerthPosition","DockArea","DryDock","DumpingGround","FloatingDock","Gridiron","HarbourAreaAdministrative","HarbourAreaSection","HarbourBasin","HarbourFacility","MooringWarpingFacility","OuterLimit","PilotBoardingPlace","SeaplaneLandingArea","Terminal","TurningBasin","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","SoundingDatum","VerticalDatumOfData","TextPlacement"];
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum berthingAssistance : int {
		[System.ComponentModel.Description("InformationAboutAssistanceOrArrangementsForAServiceRelatedToBerthingOperations")]
		[EnumMember(Value = "Berthing Information")] 
		BerthingInformation = 1,

		[System.ComponentModel.Description("PersonnelSpecializingInTheMooringAndUnmooringOfVessels")]
		[EnumMember(Value = "Line Personnel")] 
		LinePersonnel = 2,

		[System.ComponentModel.Description("ABoatWhichAssistsTheSecurementOfAVesselToABerthOrMooringWithRopesOrAnchor")]
		[EnumMember(Value = "Mooring Boat")] 
		MooringBoat = 3,

		[System.ComponentModel.Description("ALocomotiveForMovingVessels")]
		[EnumMember(Value = "Mule")] 
		Mule = 4,

		[System.ComponentModel.Description("APowerfulSmallBoatDesignedToPullOrPushLargerShipsOrPowerlessBarges")]
		[EnumMember(Value = "Tugboat")] 
		Tugboat = 5,

		[System.ComponentModel.Description("AShipEquippedToMakeAndMaintainAChannelThroughIce")]
		[EnumMember(Value = "Icebreaking Ship")] 
		IcebreakingShip = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalDirection : int {
		[System.ComponentModel.Description("three487501125DegreesTrueNorth")]
		[EnumMember(Value = "North")] 
		North = 1,

		[System.ComponentModel.Description("zero1125zero3375Degrees")]
		[EnumMember(Value = "North Northeast")] 
		NorthNortheast = 2,

		[System.ComponentModel.Description("zero3375zero5625Degrees")]
		[EnumMember(Value = "Northeast")] 
		Northeast = 3,

		[System.ComponentModel.Description("zero5625zero7875Degrees")]
		[EnumMember(Value = "East Northeast")] 
		EastNortheast = 4,

		[System.ComponentModel.Description("zero78751zero125Degrees")]
		[EnumMember(Value = "East")] 
		East = 5,

		[System.ComponentModel.Description("one0one25one2375Degrees")]
		[EnumMember(Value = "East Southeast")] 
		EastSoutheast = 6,

		[System.ComponentModel.Description("one2375one4625Degrees")]
		[EnumMember(Value = "Southeast")] 
		Southeast = 7,

		[System.ComponentModel.Description("one4625one6875Degrees")]
		[EnumMember(Value = "South Southeast")] 
		SouthSoutheast = 8,

		[System.ComponentModel.Description("one6875one9one25Degrees")]
		[EnumMember(Value = "South")] 
		South = 9,

		[System.ComponentModel.Description("one9one252one375Degrees")]
		[EnumMember(Value = "South Southwest")] 
		SouthSouthwest = 10,

		[System.ComponentModel.Description("two1375two36two5Degrees")]
		[EnumMember(Value = "Southwest")] 
		Southwest = 11,

		[System.ComponentModel.Description("two36two5two5875Degrees")]
		[EnumMember(Value = "West Southwest")] 
		WestSouthwest = 12,

		[System.ComponentModel.Description("two5875two81two5Degrees")]
		[EnumMember(Value = "West")] 
		West = 13,

		[System.ComponentModel.Description("two81two530375Degrees")]
		[EnumMember(Value = "West Northwest")] 
		WestNorthwest = 14,

		[System.ComponentModel.Description("three0three75three2625Degrees")]
		[EnumMember(Value = "Northwest")] 
		Northwest = 15,

		[System.ComponentModel.Description("three2625three4875Degrees")]
		[EnumMember(Value = "North Northwest")] 
		NorthNorthwest = 16,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cargoService : int {
		[System.ComponentModel.Description("TheLoadingUnloadingMovingOrHandlingOfCargoShipSStoresGearOrOtherMaterialsIntoInOnOrOutOfAnyVessel")]
		[EnumMember(Value = "Stevedoring")] 
		Stevedoring = 1,

		[System.ComponentModel.Description("InspectionEvaluationOrMonitoringOfTheQuantityStowageLoadingAndUnloadingAndConditionOfCargoAndTheEffectsOfCargoesOnVesselStabilityAndSafety")]
		[EnumMember(Value = "Cargo Surveying")] 
		CargoSurveying = 2,

		[System.ComponentModel.Description("TheSecurementOfCargoToTheShipSStructureAndOrOtherCargo")]
		[EnumMember(Value = "Cargo Lashing")] 
		CargoLashing = 3,

		[System.ComponentModel.Description("DeterminationOfTheQuantityOfCertainTypesOfBulkCargoByAssessmentOfItsEffectOnDisplacementWhenLoadedInAVessel")]
		[EnumMember(Value = "Draught Survey")] 
		DraughtSurvey = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAuthority : int {
		[System.ComponentModel.Description("TheAdministrationToPreventOrDetectAndProsecuteViolationsOfRulesAndRegulationsAtInternationalBoundaries")]
		[EnumMember(Value = "Border Control")] 
		BorderControl = 2,

		[System.ComponentModel.Description("TheDepartmentOfGovernmentOrCivilForceChargedWithMaintainingPublicOrder")]
		[EnumMember(Value = "Police")] 
		Police = 3,

		[System.ComponentModel.Description("PersonOrCorporationOwnersOfOrEntrustedWithOrInvestedWithThePowerOfManagingAPortMayBeCalledAHarbourBoardPortTrustPortCommissionHarbourCommissionMarineDepartment")]
		[EnumMember(Value = "Port")] 
		Port = 4,

		[System.ComponentModel.Description("TheAuthorityControllingPeopleEnteringACountry")]
		[EnumMember(Value = "Immigration")] 
		Immigration = 5,

		[System.ComponentModel.Description("TheAuthorityWithResponsibilityForCheckingTheValidityOfTheHealthDeclarationOfAVesselAndForDeclaringFreePratique")]
		[EnumMember(Value = "Health")] 
		Health = 6,

		[System.ComponentModel.Description("OrganizationKeepingWatchOnShippingAndCoastalWatersAccordingToGovernmentalLawNormallyTheAuthorityWithResponsibilityForSearchAndRescue")]
		[EnumMember(Value = "Coast Guard")] 
		CoastGuard = 7,

		[System.ComponentModel.Description("TheAuthorityWithResponsibilityForPreventingInfectionOfTheAgricultureOfACountryAndForTheProtectionOfTheAgriculturalInterestsOfACountry")]
		[EnumMember(Value = "Agricultural")] 
		Agricultural = 8,

		[System.ComponentModel.Description("AMilitaryAuthorityWhichProvidesControlOfAccessToOrApprovalForTransitThroughDesignatedAreasOrAirspace")]
		[EnumMember(Value = "Military")] 
		Military = 9,

		[System.ComponentModel.Description("APrivateOrPubliclyOwnedCompanyOrCommercialEnterpriseWhichExercisesControlOfFacilitiesForExampleACalibrationArea")]
		[EnumMember(Value = "Private Company")] 
		PrivateCompany = 10,

		[System.ComponentModel.Description("AGovernmentalOrMilitaryForceWithJurisdictionInTerritorialWatersExamplesCouldIncludeGendarmerieMaritimeCarabinierieAndGuardiaCivil")]
		[EnumMember(Value = "Maritime Police")] 
		MaritimePolice = 11,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheProtectionOfTheEnvironment")]
		[EnumMember(Value = "Environmental")] 
		Environmental = 12,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheControlOfFisheries")]
		[EnumMember(Value = "Fishery")] 
		Fishery = 13,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheControlAndMovementOfMoney")]
		[EnumMember(Value = "Finance")] 
		Finance = 14,

		[System.ComponentModel.Description("ANationalOrRegionalAuthorityChargedWithAdministrationOfMaritimeAffairs")]
		[EnumMember(Value = "Maritime")] 
		Maritime = 15,

		[System.ComponentModel.Description("TheAgencyOrEstablishmentForCollectingDutiesTolls")]
		[EnumMember(Value = "Customs")] 
		Customs = 16,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfBerthLocation : int {
		[System.ComponentModel.Description("AWharfOrQuayWithReferencePositionSGivenByOneOrMoreMetreMarks")]
		[EnumMember(Value = "Wharf Reference Metre Mark")] 
		WharfReferenceMetreMark = 1,

		[System.ComponentModel.Description("AWharfOrQuayWithReferencePositionSGivenByOneOrMorePointOrPointsInGeographicCoordinates")]
		[EnumMember(Value = "Wharf Reference Position")] 
		WharfReferencePosition = 2,

		[System.ComponentModel.Description("ALongNarrowStructureExtendingIntoTheWaterToAffordABerthingPlaceForVesselsToServeAsAPromenadeEtc")]
		[EnumMember(Value = "Pier (Jetty)")] 
		PierJetty = 3,

		[System.ComponentModel.Description("MooringUsingTheVesselSAnchorsAndBuoysToSecureTheVesselAtMultiplePoints")]
		[EnumMember(Value = "Conventional Mooring")] 
		ConventionalMooring = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("OneOfANumberOfStandardSizedCargoCarryingUnitsSecuredUsingStandardCornerAttachmentsAndBar")]
		[EnumMember(Value = "Container")] 
		Container = 2,

		[System.ComponentModel.Description("AFeePayingTraveller")]
		[EnumMember(Value = "Passenger")] 
		Passenger = 5,

		[System.ComponentModel.Description("LiveAnimalsCarriedInBulk")]
		[EnumMember(Value = "Livestock")] 
		Livestock = 6,

		[System.ComponentModel.Description("DangerousOrHazardousCargoAsDescribedByTheImoInternationalMaritimeDangerousGoodsCode")]
		[EnumMember(Value = "Dangerous or Hazardous")] 
		DangerousOrHazardous = 7,

		[System.ComponentModel.Description("IndivisibleHeavyItemsOfWeightGenerallyOver100TonsAndWidthOrHeightGreaterThan100Metres")]
		[EnumMember(Value = "Heavy Lift")] 
		HeavyLift = 8,

		[System.ComponentModel.Description("CommodityCargoThatIsTransportedUnpackagedInLargeQuantitiesTheseTypesOfGoodsUsuallyNeedToBeKeptDryDuringTheWholeTransportationPeriod")]
		[EnumMember(Value = "Dry Bulk Cargo")] 
		DryBulkCargo = 10,

		[System.ComponentModel.Description("LiquidsOrGasesThatAreTransportedInBulkAndCarriedUnpackaged")]
		[EnumMember(Value = "Liquid Bulk Cargo")] 
		LiquidBulkCargo = 11,

		[System.ComponentModel.Description("CargoTransportedInRefrigeratedContainersGenerallyPerishableCommoditiesWhichRequireTemperatureControlledTransportationSuchAsFruitMeatFishVegetablesDairyProductsAndOtherFoods")]
		[EnumMember(Value = "Reefer Container Cargo")] 
		ReeferContainerCargo = 12,

		[System.ComponentModel.Description("WheeledCargoSuchAsCarsBussesTrucksAgriculturalVehiclesAndCranesThatAreDrivenOnAndOffTheShipOnTheirOwnWheelsOrUsingAPlatformVehicleSuchAsASelfPropelledModularTransporter")]
		[EnumMember(Value = "Ro-Ro Cargo")] 
		RoRoCargo = 13,

		[System.ComponentModel.Description("ProjectCargoIsATermUsedToBroadlyDescribeTheNationalOrInternationalTransportationOfLargeHeavyHighValueOrCriticalToTheProjectTheyAreIntendedForPiecesOfEquipmentAlsoCommonlyReferredToAsHeavyLiftThisIncludesShipmentsMadeOfVariousComponentsWhichNeedDisassemblyForShipmentAndReassemblyAfterDelivery")]
		[EnumMember(Value = "Project Cargo")] 
		ProjectCargo = 14,

		[System.ComponentModel.Description("GoodsThatAreStowedOnBoardShipInIndividuallyCountedUnitsAndNotInIntermodalContainersNorInBulkAsWithOilOrGrain")]
		[EnumMember(Value = "Break Bulk Cargo")] 
		BreakBulkCargo = 15,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCommunicationPreference : int {
		[System.ComponentModel.Description("TheFirstChoiceChannelOrFrequencyToBeUsedWhenCallingARadioStation")]
		[EnumMember(Value = "Preferred Calling")] 
		PreferredCalling = 1,

		[System.ComponentModel.Description("AChannelOrFrequencyToBeUsedForCallingARadioStationWhenThePreferredChannelOrFrequencyIsBusyOrIsSufferingFromInterference")]
		[EnumMember(Value = "Alternate Calling")] 
		AlternateCalling = 2,

		[System.ComponentModel.Description("TheFirstChoiceChannelOrFrequencyToBeUsedWhenWorkingWithARadioStation")]
		[EnumMember(Value = "Preferred Working")] 
		PreferredWorking = 3,

		[System.ComponentModel.Description("AChannelOrFrequencyToBeUsedForWorkingWithARadioStationWhenThePreferredWorkingChannelOrFrequencyIsBusyOrIsSufferingFromInterference")]
		[EnumMember(Value = "Alternate Working")] 
		AlternateWorking = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDangerousOrHazardousCargo : int {
		[System.ComponentModel.Description("ExplosivesDivision1SubstancesAndArticlesWhichHaveAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.1")] 
		ImdgCodeClass1Div11 = 1,

		[System.ComponentModel.Description("ExplosivesDivision2SubstancesAndArticlesWhichHaveAProjectionHazardButNotAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.2")] 
		ImdgCodeClass1Div12 = 2,

		[System.ComponentModel.Description("ExplosivesDivision3SubstancesAndArticlesWhichHaveAFireHazardAndEitherAMinorBlastHazardOrAMinorProjectionHazardOrBothButNotAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.3")] 
		ImdgCodeClass1Div13 = 3,

		[System.ComponentModel.Description("ExplosivesDivision4SubstancesAndArticlesWhichPresentNoSignificantHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.4")] 
		ImdgCodeClass1Div14 = 4,

		[System.ComponentModel.Description("ExplosivesDivision5VeryInsensitiveSubstancesWhichHaveAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.5")] 
		ImdgCodeClass1Div15 = 5,

		[System.ComponentModel.Description("ExplosivesDivision6ExtremelyInsensitiveArticlesWhichDoNotHaveAMassExplosionHazard")]
		[EnumMember(Value = "IMDG Code Class 1 Div. 1.6")] 
		ImdgCodeClass1Div16 = 6,

		[System.ComponentModel.Description("GasesFlammableGases")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.1")] 
		ImdgCodeClass2Div21 = 7,

		[System.ComponentModel.Description("GasesNonFlammableNonToxicGases")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.2")] 
		ImdgCodeClass2Div22 = 8,

		[System.ComponentModel.Description("GasesToxicGases")]
		[EnumMember(Value = "IMDG Code Class 2 Div. 2.3")] 
		ImdgCodeClass2Div23 = 9,

		[System.ComponentModel.Description("FlammableLiquids")]
		[EnumMember(Value = "IMDG Code Class 3")] 
		ImdgCodeClass3 = 10,

		[System.ComponentModel.Description("FlammableSolidsSelfReactiveSubstancesAndDesensitizedExplosives")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.1")] 
		ImdgCodeClass4Div41 = 11,

		[System.ComponentModel.Description("SubstancesLiableToSpontaneousCombustion")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.2")] 
		ImdgCodeClass4Div42 = 12,

		[System.ComponentModel.Description("SubstancesWhichInContactWithWaterEmitFlammableGases")]
		[EnumMember(Value = "IMDG Code Class 4 Div. 4.3")] 
		ImdgCodeClass4Div43 = 13,

		[System.ComponentModel.Description("OxidizingSubstances")]
		[EnumMember(Value = "IMDG Code Class 5 Div. 5.1")] 
		ImdgCodeClass5Div51 = 14,

		[System.ComponentModel.Description("OrganicPeroxides")]
		[EnumMember(Value = "IMDG Code Class 5 Div. 5.2")] 
		ImdgCodeClass5Div52 = 15,

		[System.ComponentModel.Description("ToxicSubstances")]
		[EnumMember(Value = "IMDG Code Class 6 Div. 6.1")] 
		ImdgCodeClass6Div61 = 16,

		[System.ComponentModel.Description("InfectiousSubstances")]
		[EnumMember(Value = "IMDG Code Class 6 Div. 6.2")] 
		ImdgCodeClass6Div62 = 17,

		[System.ComponentModel.Description("RadioactiveMaterial")]
		[EnumMember(Value = "IMDG Code Class 7")] 
		ImdgCodeClass7 = 18,

		[System.ComponentModel.Description("CorrosiveSubstances")]
		[EnumMember(Value = "IMDG Code Class 8")] 
		ImdgCodeClass8 = 19,

		[System.ComponentModel.Description("MiscellaneousDangerousSubstancesAndArticles")]
		[EnumMember(Value = "IMDG Code Class 9")] 
		ImdgCodeClass9 = 20,

		[System.ComponentModel.Description("HarmfulSubstancesAreThoseSubstancesWhichAreIdentifiedAsMarinePollutantsInTheInternationalMaritimeDangerousGoodsCodeImdgCodePackagedFormIsDefinedAsTheFormsOfContainmentSpecifiedForHarmfulSubstancesInTheImdgCode")]
		[EnumMember(Value = "Harmful Substances in Packaged Form")] 
		HarmfulSubstancesInPackagedForm = 21,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDepthsDescription : int {
		[System.ComponentModel.Description("AShallowElevationComposedOfUnconsolidatedMaterialThatMayConstituteAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Shoal")] 
		Shoal = 1,

		[System.ComponentModel.Description("GeneralInformationAboutTheVerticalDistanceFromTheWaterSurfaceToTheBottom")]
		[EnumMember(Value = "General Depth")] 
		GeneralDepth = 2,

		[System.ComponentModel.Description("TheLeastDepthInTheApproachOrChannelToAnAreaSuchAsAPortOrAnchorageGoverningTheMaximumDraftOfVesselsThatCanEnter")]
		[EnumMember(Value = "Controlling Depth")] 
		ControllingDepth = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfHarbourFacility : int {
		[System.ComponentModel.Description("ATerminalForRollOnRollOffFerries")]
		[EnumMember(Value = "RoRo Terminal")] 
		RoroTerminal = 1,

		[System.ComponentModel.Description("ATerminalForPassengerAndVehicleFerries")]
		[EnumMember(Value = "Ferry Terminal")] 
		FerryTerminal = 3,

		[System.ComponentModel.Description("AHarbourWithFacilitiesForFishingBoats")]
		[EnumMember(Value = "Fishing Harbour")] 
		FishingHarbour = 4,

		[System.ComponentModel.Description("AHarbourFacilityForSmallBoatsYachtsEtcWhereSuppliesRepairsAndVariousServicesAreAvailable")]
		[EnumMember(Value = "Yacht Harbour/Marina")] 
		YachtHarbourMarina = 5,

		[System.ComponentModel.Description("ACentreOfOperationsForNavalVessels")]
		[EnumMember(Value = "Naval Base")] 
		NavalBase = 6,

		[System.ComponentModel.Description("ATerminalForTheBulkHandlingOfLiquidCargoes")]
		[EnumMember(Value = "Tanker Terminal")] 
		TankerTerminal = 7,

		[System.ComponentModel.Description("ATerminalForTheLoadingAndUnloadingOfPassengers")]
		[EnumMember(Value = "Passenger Terminal")] 
		PassengerTerminal = 8,

		[System.ComponentModel.Description("APlaceWhereShipsAreBuiltOrRepaired")]
		[EnumMember(Value = "Shipyard")] 
		Shipyard = 9,

		[System.ComponentModel.Description("ATerminalWithFacilitiesToLoadUnloadOrStoreShippingContainers")]
		[EnumMember(Value = "Container Terminal")] 
		ContainerTerminal = 10,

		[System.ComponentModel.Description("ATerminalForTheHandlingOfBulkMaterialsSuchAsIronOreCoalEtc")]
		[EnumMember(Value = "Bulk Terminal")] 
		BulkTerminal = 11,

		[System.ComponentModel.Description("APlatformPoweredBySynchronousElectricMotorsForExampleSyncroliftUsedToLiftVesselsLargerThanBoatsInAndOutOfTheWater")]
		[EnumMember(Value = "Ship Lift")] 
		ShipLift = 12,

		[System.ComponentModel.Description("AWheeledVehicleDesignedToLiftAndCarryContainersOrVesselsWithinItsOwnFrameworkItIsUsedForMovingAndSometimesStackingShippingContainersAndVessels")]
		[EnumMember(Value = "Straddle Carrier")] 
		StraddleCarrier = 13,

		[System.ComponentModel.Description("AHarbourWithinWhichTheFloatingEquipmentDredgesTugsOfHarbourServicesAreStationed")]
		[EnumMember(Value = "Service Harbour")] 
		ServiceHarbour = 14,

		[System.ComponentModel.Description("TheServicesOfAPersonWhoDirectsTheMovementsOfAVesselThroughPilotWatersUsuallyAPersonWhoHasDemonstratedExtensiveKnowledgeOfChannelsAidsToNavigationDangersToNavigationEtcInAParticularAreaAndIsLicensedForThatAreaAreAvailable")]
		[EnumMember(Value = "Pilotage Service")] 
		PilotageService = 15,

		[System.ComponentModel.Description("APlaceWhereMechanicalServicesOrRepairsCanBeUndertakenToEnginesOrOtherVesselEquipment")]
		[EnumMember(Value = "Service and Repair")] 
		ServiceAndRepair = 16,

		[System.ComponentModel.Description("AMedicalControlCenterLocatedInAnIsolatedSpotAshoreWherePatientsWithContagiousDiseasesFromVesselInQuarantineAreTaken")]
		[EnumMember(Value = "Quarantine Station")] 
		QuarantineStation = 17,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfMooringWarpingFacility : int {
		[System.ComponentModel.Description("APostOrGroupOfPostsUsedForMooringOrWarpingAVesselOrAsAnAidToNavigationTheDolphinMayBeInTheWaterOnAWharfOrOnTheBeach")]
		[EnumMember(Value = "Dolphin")] 
		Dolphin = 1,

		[System.ComponentModel.Description("APostOrGroupOfPostsWhichAVesselMaySwingAroundForCompassAdjustment")]
		[EnumMember(Value = "Deviation Dolphin")] 
		DeviationDolphin = 2,

		[System.ComponentModel.Description("SmallShapedPostMountedOnAWharfOrDolphinUsedToSecureShipSLines")]
		[EnumMember(Value = "Bollard")] 
		Bollard = 3,

		[System.ComponentModel.Description("ASectionOfWallDesignatedForTyingUpVesselsAwaitingTransitBollardsAndMooringDevicesAreAvailableForBothLargeAndSmallShips")]
		[EnumMember(Value = "Tie-Up Wall")] 
		TieUpWall = 4,

		[System.ComponentModel.Description("ALongHeavyTimberOrSectionOfSteelWoodConcreteEtcForcedIntoTheSeabedToServeAsAMooringFacility")]
		[EnumMember(Value = "Post or Pile")] 
		PostOrPile = 5,

		[System.ComponentModel.Description("AChainOrVeryStrongFibreOrWireRopeUsedToAnchorOrMoorVesselsOrBuoys")]
		[EnumMember(Value = "Mooring Cable")] 
		MooringCable = 6,

		[System.ComponentModel.Description("ABuoySecuredToTheBottomByPermanentMooringsWithMeansForMooringAVesselByUseOfItsAnchorChainOrMooringLines")]
		[EnumMember(Value = "Mooring Buoy")] 
		MooringBuoy = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPortSection : int {
		[System.ComponentModel.Description("TheMainNavigableChannelInAHarbourOrItsApproachesForVesselsOfLargerSize")]
		[EnumMember(Value = "Port Fairway")] 
		PortFairway = 1,

		[System.ComponentModel.Description("ABodyOfWaterAtABerthOrAnchorBerthOfAdequateDimensionsToAllowAVesselToMakeFastToTheShoreMooringBuoysBerthingDolphinsOrToAnchor")]
		[EnumMember(Value = "Berth Pocket")] 
		BerthPocket = 3,

		[System.ComponentModel.Description("AnAreaInWhichSeaPlanesAnchorOrMayAnchor")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		SeaplaneAnchorage = 8,

		[System.ComponentModel.Description("AnAreaOfWaterOrChannelEnlargementOfIncreasedDepthComparedToAdjacentAreasWhereTheDepthIsMaintainedByDredgingOperations")]
		[EnumMember(Value = "Dredged Basin")] 
		DredgedBasin = 9,

		[System.ComponentModel.Description("TheAreaAroundAPortFacilityOrHarbourInstallationWithinWhichVesselsAreProhibitedFromEnteringWithoutPermission")]
		[EnumMember(Value = "Port Safety Zone")] 
		PortSafetyZone = 11,

		[System.ComponentModel.Description("AGeneralBerthForUseByVesselsForShortTermWaitingUntilALoadingOrDischargingBerthIsAvailable")]
		[EnumMember(Value = "Lay-by Berth")] 
		LayByBerth = 12,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRelationship : int {
		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsForbidden")]
		[EnumMember(Value = "Prohibited")] 
		Prohibited = 1,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsNotRecommended")]
		[EnumMember(Value = "Not Recommended")] 
		NotRecommended = 2,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsPermittedButNotRequired")]
		[EnumMember(Value = "Permitted")] 
		Permitted = 3,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsRecommended")]
		[EnumMember(Value = "Recommended")] 
		Recommended = 4,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsRequired")]
		[EnumMember(Value = "Required")] 
		Required = 5,

		[System.ComponentModel.Description("UseOfFacilityWaterwayOrServiceIsNotRequired")]
		[EnumMember(Value = "Not Required")] 
		NotRequired = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSchedule : int {
		[System.ComponentModel.Description("TheServiceOfficeIsOpenFullyMannedAndOperatingNormallyOrTheAreaIsAccessibleAsUsual")]
		[EnumMember(Value = "Normal Operation")] 
		NormalOperation = 1,

		[System.ComponentModel.Description("TheServiceOfficeOrAreaIsClosed")]
		[EnumMember(Value = "Closure")] 
		Closure = 2,

		[System.ComponentModel.Description("TheServiceIsAvailableButNotManned")]
		[EnumMember(Value = "Unmanned Operation")] 
		UnmannedOperation = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTemporalVariation : int {
		[System.ComponentModel.Description("IndicationOfThePossibleImpactOfASignificantEventForExampleHurricaneEarthquakeVolcanicEruptionLandslideEtcWhichIsConsideredLikelyToHaveChangedTheSeafloorOrLandscapeSignificantly")]
		[EnumMember(Value = "Extreme Event")] 
		ExtremeEvent = 1,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeForExampleRiverSiltationSandWavesSeasonalStormsIceBergsEtcThatIsLikelyToResultInNewSignificantShoaling")]
		[EnumMember(Value = "Likely to Change and Significant Shoaling Expected")] 
		LikelyToChangeAndSignificantShoalingExpected = 2,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeForExampleSandWaveShiftSeasonalStormsIceBergsEtcThatIsNotLikelyToResultInNewSignificantShoaling")]
		[EnumMember(Value = "Likely to Change But Significant Shoaling Not Expected")] 
		LikelyToChangeButSignificantShoalingNotExpected = 3,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeToNonBathymetricFeaturesForExampleRiverSiltationGlacierCreepRecessionSandDunesBuoysMarineFarmsEtc")]
		[EnumMember(Value = "Likely to Change")] 
		LikelyToChange = 4,

		[System.ComponentModel.Description("SignificantChangeToTheSeafloorIsNotExpected")]
		[EnumMember(Value = "Unlikely to Change")] 
		UnlikelyToChange = 5,

		[System.ComponentModel.Description("NotHavingBeenAssessed")]
		[EnumMember(Value = "Unassessed")] 
		Unassessed = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfText : int {
		[System.ComponentModel.Description("AStatementSummarizingTheImportantPointsOfAText")]
		[EnumMember(Value = "Abstract or Summary")] 
		AbstractOrSummary = 1,

		[System.ComponentModel.Description("AnExcerptOrExcerptsFromAText")]
		[EnumMember(Value = "Extract")] 
		Extract = 2,

		[System.ComponentModel.Description("TheWholeText")]
		[EnumMember(Value = "Full Text")] 
		FullText = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfVesselRegistry : int {
		[System.ComponentModel.Description("TheVesselIsRegisteredOrEnrolledUnderTheSameNationalFlagAsThePortHarbourTerritorialSeaExclusiveEconomicZoneOrAdministrativeAreaInWhichTheObjectThatPossessesThisAttributeAppliesOrIsLocated")]
		[EnumMember(Value = "Domestic")] 
		Domestic = 1,

		[System.ComponentModel.Description("TheVesselIsRegisteredOrEnrolledUnderANationalFlagDifferentFromThePortHarbourTerritorialSeaExclusiveEconomicZoneOrOtherAdministrativeAreaInWhichTheObjectThatPossessesThisAttributeAppliesOrIsLocated")]
		[EnumMember(Value = "Foreign")] 
		Foreign = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[System.ComponentModel.Description("TheValueOfTheLeftValueIsGreaterThanThatOfTheRight")]
		[EnumMember(Value = "Greater Than")] 
		GreaterThan = 1,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsGreaterThanOrEqualToThatOfTheRight")]
		[EnumMember(Value = "Greater Than or Equal To")] 
		GreaterThanOrEqualTo = 2,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanThatOfTheRight")]
		[EnumMember(Value = "Less Than")] 
		LessThan = 3,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanOrEqualToThatOfTheRight")]
		[EnumMember(Value = "Less Than or Equal To")] 
		LessThanOrEqualTo = 4,

		[System.ComponentModel.Description("TheTwoValuesAreEquivalent")]
		[EnumMember(Value = "Equal To")] 
		EqualTo = 5,

		[System.ComponentModel.Description("TheTwoValuesAreNotEquivalent")]
		[EnumMember(Value = "Not Equal To")] 
		NotEqualTo = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum condition : int {
		[System.ComponentModel.Description("BeingBuiltButNotYetCapableOfFunction")]
		[EnumMember(Value = "Under Construction")] 
		UnderConstruction = 1,

		[System.ComponentModel.Description("AStructureInADecayedOrDeterioratedConditionResultingFromNeglectOrDisuseOrADamagedStructureInNeedOfRepair")]
		[EnumMember(Value = "Ruined")] 
		Ruined = 2,

		[System.ComponentModel.Description("AnAreaOfTheSeaALakeOrTheNavigablePartOfARiverThatIsBeingReclaimedAsLandUsuallyByTheDumpingOfEarthAndOtherMaterial")]
		[EnumMember(Value = "Under Reclamation")] 
		UnderReclamation = 3,

		[System.ComponentModel.Description("DetailedPlanningHasBeenCompletedButConstructionHasNotBeenInitiated")]
		[EnumMember(Value = "Planned Construction")] 
		PlannedConstruction = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dayOfWeek : int {
		[System.ComponentModel.Description("TheFirstDayOfTheWeek")]
		[EnumMember(Value = "Sunday")] 
		Sunday = 1,

		[System.ComponentModel.Description("TheSecondDayOfTheWeek")]
		[EnumMember(Value = "Monday")] 
		Monday = 2,

		[System.ComponentModel.Description("TheThirdDayOfTheWeek")]
		[EnumMember(Value = "Tuesday")] 
		Tuesday = 3,

		[System.ComponentModel.Description("TheFourthDayOfTheWeek")]
		[EnumMember(Value = "Wednesday")] 
		Wednesday = 4,

		[System.ComponentModel.Description("TheFifthDayOfTheWeek")]
		[EnumMember(Value = "Thursday")] 
		Thursday = 5,

		[System.ComponentModel.Description("TheSixthDayOfTheWeek")]
		[EnumMember(Value = "Friday")] 
		Friday = 6,

		[System.ComponentModel.Description("TheSeventhDayOfTheWeek")]
		[EnumMember(Value = "Saturday")] 
		Saturday = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dynamicResource : int {
		[System.ComponentModel.Description("TheInformationIsStaticOrASourceOfUpToDateInformationIsUnavailableOrUnknown")]
		[EnumMember(Value = "Static")] 
		Static = 1,

		[System.ComponentModel.Description("AnExternalSourceOfUpToDateInformationIsAvailableAndInteractionWithItToObtainUpToDateInformationIsRequired")]
		[EnumMember(Value = "Mandatory External Dynamic")] 
		MandatoryExternalDynamic = 2,

		[System.ComponentModel.Description("AnExternalSourceOfUpToDateInformationIsAvailableButInteractionWithItToObtainUpToDateInformationIsNotRequired")]
		[EnumMember(Value = "Optional External Dynamic")] 
		OptionalExternalDynamic = 3,

		[System.ComponentModel.Description("UpToDateInformationMayBeComputedUsingOnlyOnboardResources")]
		[EnumMember(Value = "Onboard Dynamic")] 
		OnboardDynamic = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum firefightingService : int {
		[System.ComponentModel.Description("PersonnelAndEquipmentThatAreCapableOfCombatingAFireFromAshore")]
		[EnumMember(Value = "Shore-Based Firefighting")] 
		ShoreBasedFirefighting = 1,

		[System.ComponentModel.Description("TrainedFirefightingPersonnelWithTheCapabilityOfBoardingAndCombatingAFireOnAVessel")]
		[EnumMember(Value = "Onboard Firefighting")] 
		OnboardFirefighting = 2,

		[System.ComponentModel.Description("SpecialisedWatercraftWithFirefightingApparatusDesignedForFightingShorelineAndShipboardFires")]
		[EnumMember(Value = "Firefighting Boat")] 
		FirefightingBoat = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iSPSLevel : int {
		[System.ComponentModel.Description("TheLevelForWhichMinimumAppropriateProtectiveSecurityMeasuresShallBeMaintainedAtAllTimes")]
		[EnumMember(Value = "ISPS Level 1")] 
		IspsLevel1 = 1,

		[System.ComponentModel.Description("TheLevelForWhichAppropriateAdditionalProtectiveSecurityMeasuresShallBeMaintainedForAPeriodOfTimeAsAResultOfHeightenedRiskOfASecurityIncident")]
		[EnumMember(Value = "ISPS Level 2")] 
		IspsLevel2 = 2,

		[System.ComponentModel.Description("TheLevelForWhichFurtherSpecificProtectiveSecurityMeasuresShallBeMaintainedForALimitedPeriodOfTimeWhenASecurityIncidentIsProbableOrImminentAlthoughItMayNotBePossibleToIdentifyTheSpecificTarget")]
		[EnumMember(Value = "ISPS Level 3")] 
		IspsLevel3 = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum logicalConnectives : int {
		[System.ComponentModel.Description("AllTheConditionsDescribedByTheOtherAttributesOfTheObjectOrSubAttributesOfTheSameComplexAttributeAreTrue")]
		[EnumMember(Value = "Logical Conjunction")] 
		LogicalConjunction = 1,

		[System.ComponentModel.Description("AtLeastOneOfTheConditionsDescribedByTheOtherAttributesOfTheObjectOrSubAttributesOfTheSameComplexAttributesIsTrue")]
		[EnumMember(Value = "Logical Disjunction")] 
		LogicalDisjunction = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum medicalService : int {
		[System.ComponentModel.Description("AVehicleForConveyingTheSickOrInjuredToOrFromAHospital")]
		[EnumMember(Value = "Ambulance")] 
		Ambulance = 1,

		[System.ComponentModel.Description("DisinfectionOrPurificationWithFumes")]
		[EnumMember(Value = "Fumigation")] 
		Fumigation = 2,

		[System.ComponentModel.Description("APlaceWhereADoctorIsAvailableToProvideMedicalAttention")]
		[EnumMember(Value = "Doctor")] 
		Doctor = 3,

		[System.ComponentModel.Description("TheIsolationOfPatientsWithContagiousDiseases")]
		[EnumMember(Value = "Quarantine")] 
		Quarantine = 4,

		[System.ComponentModel.Description("APlaceWhereSubstancesIntendedToProcureImmunityAgainstOneOrSeveralDiseasesAreAdministered")]
		[EnumMember(Value = "Vaccination Centre")] 
		VaccinationCentre = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum membership : int {
		[System.ComponentModel.Description("VesselsWithTheseCharacteristicsAreIncludedInTheRegulationRestrictionRecommendationNauticalInformation")]
		[EnumMember(Value = "Included")] 
		Included = 1,

		[System.ComponentModel.Description("VesselsWithTheseCharacteristicsAreExcludedFromTheRegulationRestrictionRecommendationNauticalInformation")]
		[EnumMember(Value = "Excluded")] 
		Excluded = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum methodOfSecuring : int {
		[System.ComponentModel.Description("VesselIsSecuredPerpendicularToTheWharfWithBowToSeaward")]
		[EnumMember(Value = "Bow to Seaward")] 
		BowToSeaward = 1,

		[System.ComponentModel.Description("VesselIsSecuredPerpendicularToTheWharfWithSternToTheSeaward")]
		[EnumMember(Value = "Stern to Seaward")] 
		SternToSeaward = 2,

		[System.ComponentModel.Description("TheVesselIsSecuredPerpendicularToTheWharf")]
		[EnumMember(Value = "Mediterranean Mooring")] 
		MediterraneanMooring = 3,

		[System.ComponentModel.Description("MooringMethodProcedureUsedDuringOnshoreWindConditionsWithoutATug")]
		[EnumMember(Value = "Baltic Mooring")] 
		BalticMooring = 4,

		[System.ComponentModel.Description("MooringByManeuveringAheadAndAsternWhileDroppingAnchorsToSecureTheVesselWithReducedSwingingRoom")]
		[EnumMember(Value = "Running Mooring")] 
		RunningMooring = 5,

		[System.ComponentModel.Description("MooringByUsingMainlyWindAndTideToPositionTheVesselWhileDroppingAnchorsToSecureTheVesselWithReducedSwingingRoomMakesLimitedUseOfTheEngineToPositionTheVessel")]
		[EnumMember(Value = "Standing Mooring")] 
		StandingMooring = 6,

		[System.ComponentModel.Description("AMooringStructureUsedByTankersToLoadAndUnloadInPortApproachesOrInOffshoreOilAndGasFieldsTheSizeOfTheStructureCanVaryBetweenALargeMooringBuoyAndAMannedFloatingStructure")]
		[EnumMember(Value = "Single Point Mooring")] 
		SinglePointMooring = 7,

		[System.ComponentModel.Description("MooringUsingTheVesselSAnchorsAndBuoysToSecureTheVesselAtMultiplePoints")]
		[EnumMember(Value = "Conventional Mooring")] 
		ConventionalMooring = 8,

		[System.ComponentModel.Description("MooringAlongsideAnotherVessel")]
		[EnumMember(Value = "Ship-to-Ship Mooring")] 
		ShipToShipMooring = 9,

		[System.ComponentModel.Description("MooringSystemSupportedByASpiderBuoy")]
		[EnumMember(Value = "Spider Buoy Mooring")] 
		SpiderBuoyMooring = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum onlineFunction : int {
		[System.ComponentModel.Description("OnlineInstructionsForTransferringDataFromOneStorageDeviceOrSystemToAnother")]
		[EnumMember(Value = "Download")] 
		Download = 1,

		[System.ComponentModel.Description("OnlineInstructionsForRequestingTheResourceFromTheProvider")]
		[EnumMember(Value = "Offline Access")] 
		OfflineAccess = 3,

		[System.ComponentModel.Description("OnlineOrderProcessForObtainingTheResource")]
		[EnumMember(Value = "Order")] 
		Order = 4,

		[System.ComponentModel.Description("ToMakePainstakingInvestigationOrExamination")]
		[EnumMember(Value = "Search")] 
		Search = 5,

		[System.ComponentModel.Description("CompleteMetadataProvided")]
		[EnumMember(Value = "Complete Metadata")] 
		CompleteMetadata = 6,

		[System.ComponentModel.Description("BrowseGraphicProvided")]
		[EnumMember(Value = "Browse Graphic")] 
		BrowseGraphic = 7,

		[System.ComponentModel.Description("OnlineResourceUploadCapabilityProvided")]
		[EnumMember(Value = "Upload")] 
		Upload = 8,

		[System.ComponentModel.Description("OnlineEmailServiceProvided")]
		[EnumMember(Value = "Email Service")] 
		EmailService = 9,

		[System.ComponentModel.Description("OnlineBrowsingProvided")]
		[EnumMember(Value = "Browsing")] 
		Browsing = 10,

		[System.ComponentModel.Description("OnlineFileAccessProvided")]
		[EnumMember(Value = "File Access")] 
		FileAccess = 11,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum product : int {
		[System.ComponentModel.Description("AThickSlipperyLiquidThatWillNotDissolveInWaterUsuallyPetroleumBasedInTheContextOfStorageTanks")]
		[EnumMember(Value = "Oil")] 
		Oil = 1,

		[System.ComponentModel.Description("ASubstanceWithParticlesThatCanMoveFreelyUsuallyAFuelSubstanceInTheContextOfStorageTanks")]
		[EnumMember(Value = "Gas")] 
		Gas = 2,

		[System.ComponentModel.Description("AGeneralTermForRockAndRockFragmentsRangingInSizeFromPebblesAndGravelToBouldersOrLargeRockMasses")]
		[EnumMember(Value = "Stone")] 
		Stone = 4,

		[System.ComponentModel.Description("AHardBlackMineralThatIsBurnedAsFuel")]
		[EnumMember(Value = "Coal")] 
		Coal = 5,

		[System.ComponentModel.Description("ASolidRockOrMineralFromWhichMetalIsObtained")]
		[EnumMember(Value = "Ore")] 
		Ore = 6,

		[System.ComponentModel.Description("AnySubstanceObtainedByOrUsedInAChemicalProcess")]
		[EnumMember(Value = "Chemicals")] 
		Chemicals = 7,

		[System.ComponentModel.Description("AWhiteFluidSecretedByFemaleMammalsAsFoodForTheirYoung")]
		[EnumMember(Value = "Milk")] 
		Milk = 9,

		[System.ComponentModel.Description("AMineralFromWhichAluminumIsObtained")]
		[EnumMember(Value = "Bauxite")] 
		Bauxite = 10,

		[System.ComponentModel.Description("ASolidSubstanceObtainedAfterGasAndTarHaveBeenExtractedFromCoalUsedAsAFuel")]
		[EnumMember(Value = "Coke")] 
		Coke = 11,

		[System.ComponentModel.Description("AnOblongLumpOfCastIronMetal")]
		[EnumMember(Value = "Iron Ingots")] 
		IronIngots = 12,

		[System.ComponentModel.Description("SodiumChlorideObtainedFromMinesOrByTheEvaporationOfSeaWater")]
		[EnumMember(Value = "Salt")] 
		Salt = 13,

		[System.ComponentModel.Description("LooseMaterialConsistingOfSmallButEasilyDistinguishableSeparateGrainsBetween00625And2000MillimetresInDiameter")]
		[EnumMember(Value = "Sand")] 
		Sand = 14,

		[System.ComponentModel.Description("WoodPreparedForUseInBuildingOrCarpentry")]
		[EnumMember(Value = "Timber")] 
		Timber = 15,

		[System.ComponentModel.Description("PowderyFragmentsOfWoodMadeInSawingTimberOrCoarseChipsProducedForUseInManufacturingPressedBoard")]
		[EnumMember(Value = "Sawdust/Wood Chips")] 
		SawdustWoodChips = 16,

		[System.ComponentModel.Description("DiscardedMetalSuitableForBeingReprocessed")]
		[EnumMember(Value = "Scrap Metal")] 
		ScrapMetal = 17,

		[System.ComponentModel.Description("NaturalGasThatHasBeenLiquefiedForEaseOfTransportByCoolingTheGasTo162Celsius")]
		[EnumMember(Value = "Liquefied Natural Gas")] 
		LiquefiedNaturalGas = 18,

		[System.ComponentModel.Description("ACompressedGasConsistingOfFlammableLightHydrocarbonsAndDerivedFromPetroleum")]
		[EnumMember(Value = "Liquefied Petroleum Gas")] 
		LiquefiedPetroleumGas = 19,

		[System.ComponentModel.Description("TheFermentedJuiceOfGrapes")]
		[EnumMember(Value = "Wine")] 
		Wine = 20,

		[System.ComponentModel.Description("ASubstanceMadeOfPowderedLimeAndClayMixedWithWater")]
		[EnumMember(Value = "Cement")] 
		Cement = 21,

		[System.ComponentModel.Description("ASmallHardSeedEspeciallyThatOfAnyCerealPlantSuchAsWheatRiceCornRyeEtc")]
		[EnumMember(Value = "Grain")] 
		Grain = 22,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("ThePositionSWasWereDeterminedByTheOperationOfMakingMeasurementsForDeterminingTheRelativePositionOfPointsOnAboveOrBeneathTheEarthSSurfaceSurveyImpliesARegularControlledSurveyOfAnyDate")]
		[EnumMember(Value = "Surveyed")] 
		Surveyed = 1,

		[System.ComponentModel.Description("SurveyDataIsDoesNotExistOrIsVeryPoor")]
		[EnumMember(Value = "Unsurveyed")] 
		Unsurveyed = 2,

		[System.ComponentModel.Description("NotSurveyedToModernStandardsOrDueToItsAgeScaleOrPositionalOrVerticalUncertaintiesIsNotSuitableToTheTypeOfNavigationExpectedInTheArea")]
		[EnumMember(Value = "Inadequately Surveyed")] 
		InadequatelySurveyed = 3,

		[System.ComponentModel.Description("APositionThatIsConsideredToBeLessThanThirdOrderAccuracyButIsGenerallyConsideredToBeWithin305MetresOfItsCorrectGeographicLocationAlsoMayApplyToAnObjectWhosePositionDoesNotRemainFixed")]
		[EnumMember(Value = "Approximate")] 
		Approximate = 4,

		[System.ComponentModel.Description("OfUncertainPositionTheExpressionIsUsedPrincipallyOnChartsToIndicateThatAWreckShoalEtcHasBeenReportedInVariousPositionsAndNotDefinitelyDeterminedInAny")]
		[EnumMember(Value = "Position Doubtful")] 
		PositionDoubtful = 5,

		[System.ComponentModel.Description("AFeatureSPositionHasBeenObtainedFromQuestionableOrUnreliableData")]
		[EnumMember(Value = "Unreliable")] 
		Unreliable = 6,

		[System.ComponentModel.Description("AnObjectWhosePositionHasBeenReportedAndItsPositionConfirmedBySomeMeansOtherThanAFormalSurveySuchAsAnIndependentReportOfTheSameObject")]
		[EnumMember(Value = "Reported (Not Surveyed)")] 
		ReportedNotSurveyed = 7,

		[System.ComponentModel.Description("AnObjectWhosePositionHasBeenReportedAndItsPositionHasNotBeenConfirmed")]
		[EnumMember(Value = "Reported (Not Confirmed)")] 
		ReportedNotConfirmed = 8,

		[System.ComponentModel.Description("TheMostProbablePositionOfAnObjectDeterminedFromIncompleteDataOrDataOfQuestionableAccuracy")]
		[EnumMember(Value = "Estimated")] 
		Estimated = 9,

		[System.ComponentModel.Description("APositionThatIsOfAKnownValueSuchAsThePositionOfAnAnchorBerthOrOtherDefinedObject")]
		[EnumMember(Value = "Precisely Known")] 
		PreciselyKnown = 10,

		[System.ComponentModel.Description("APositionThatIsComputedFromData")]
		[EnumMember(Value = "Calculated")] 
		Calculated = 11,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum repairService : int {
		[System.ComponentModel.Description("TheProcessOfNeutralizingOrReducingToAMinimumTheMagneticEffectsTheVesselItselfExertsOnAMagneticCompassItIsBasedOnThePrincipleThatTheMagneticEffectOfTheIronAndSteelOfTheVesselCanBeCounterbalancedByMeansOfMagnetsAndSoftIronPlacedNearTheCompassAlsoCalledCompassAdjustmentCompassCompensationOrMagneticCompensation")]
		[EnumMember(Value = "Compensation of Magnetic Compass")] 
		CompensationOfMagneticCompass = 1,

		[System.ComponentModel.Description("UnderwaterInspectionAndRepairPerformedByDivers")]
		[EnumMember(Value = "Diver Service")] 
		DiverService = 2,

		[System.ComponentModel.Description("RepairsToEqipmentInstalledOnTheShipSBridge")]
		[EnumMember(Value = "Bridge Equipment Repair")] 
		BridgeEquipmentRepair = 3,

		[System.ComponentModel.Description("RepairOfAnEngineOrMachineParts")]
		[EnumMember(Value = "Engine Repair")] 
		EngineRepair = 4,

		[System.ComponentModel.Description("RepairOfMarineElectronicInstruments")]
		[EnumMember(Value = "Electronic Equipment Repair")] 
		ElectronicEquipmentRepair = 5,

		[System.ComponentModel.Description("RepairsToTheShipSBodyFrameOrSuperstructure")]
		[EnumMember(Value = "Hull Repair")] 
		HullRepair = 6,

		[System.ComponentModel.Description("RepairsToEquipmentUsedInTheActOfNavigatingAShip")]
		[EnumMember(Value = "Navigational Equipment Repair")] 
		NavigationalEquipmentRepair = 7,

		[System.ComponentModel.Description("RepairsToPropellerHubAndBlades")]
		[EnumMember(Value = "Propeller Repair")] 
		PropellerRepair = 8,

		[System.ComponentModel.Description("RepairsToEquipmentUsedInSalvageOperations")]
		[EnumMember(Value = "Salvage Gear Repair")] 
		SalvageGearRepair = 9,

		[System.ComponentModel.Description("RepairsToDriveShaftsUsedForTransmittingMechanicalPowerAndTorqueToAPropeller")]
		[EnumMember(Value = "Shaft Repair")] 
		ShaftRepair = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum shipSanitationControl : int {
		[System.ComponentModel.Description("CapableOfApplyingMeasuresToEnsureThatAVesselIsFreeOfDiseaseAndDiseaseRisksButCannotIssueACertificate")]
		[EnumMember(Value = "Sanitation Measures Only")] 
		SanitationMeasuresOnly = 1,

		[System.ComponentModel.Description("TheCompetentAuthorityCanIssueAShipSanitationControlCertificateAfterSatisfactorilyCompletingOrSupervisingTheCompletionOfShipSanitationControlMeasures")]
		[EnumMember(Value = "Issue SSCC")] 
		IssueSscc = 2,

		[System.ComponentModel.Description("TheCompetentAuthorityMayIssueAShipSanitationControlExemptionCertificateIfItIsSatisfiedThatTheShipIsFreeOfInfectionAndContaminationIncludingVectorsAndReservoirs")]
		[EnumMember(Value = "Issue SSCEC")] 
		IssueSscec = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum sourceType : int {
		[System.ComponentModel.Description("TreatyConventionOrInternationalAgreementLawOrRegulationIssuedByANationalOrOtherAuthority")]
		[EnumMember(Value = "Law or Regulation")] 
		LawOrRegulation = 1,

		[System.ComponentModel.Description("PublicationNotHavingTheForceOfLawIssuedByAnInternationalOrganisationOrANationalOrLocalAdministration")]
		[EnumMember(Value = "Official Publication")] 
		OfficialPublication = 2,

		[System.ComponentModel.Description("ReportedByMarinerSAndConfirmedByAnotherSource")]
		[EnumMember(Value = "Mariner Report, Confirmed")] 
		MarinerReportConfirmed = 7,

		[System.ComponentModel.Description("ReportedByMarinerSButNotConfirmed")]
		[EnumMember(Value = "Mariner Report, Not Confirmed")] 
		MarinerReportNotConfirmed = 8,

		[System.ComponentModel.Description("ShippingAndOtherIndustryPublicationsIncludingGraphicsChartsAndWebSites")]
		[EnumMember(Value = "Industry Publications and Reports")] 
		IndustryPublicationsAndReports = 9,

		[System.ComponentModel.Description("InformationObtainedFromSatelliteImages")]
		[EnumMember(Value = "Remotely Sensed Images")] 
		RemotelySensedImages = 10,

		[System.ComponentModel.Description("InformationObtainedFromPhotographs")]
		[EnumMember(Value = "Photographs")] 
		Photographs = 11,

		[System.ComponentModel.Description("InformationObtainedFromProductsIssuedByHydrographicOffices")]
		[EnumMember(Value = "Products Issued by HO Services")] 
		ProductsIssuedByHoServices = 12,

		[System.ComponentModel.Description("InformationObtainedFromNewsMedia")]
		[EnumMember(Value = "News Media")] 
		NewsMedia = 13,

		[System.ComponentModel.Description("InformationObtainedFromTheAnalysisOfTrafficData")]
		[EnumMember(Value = "Traffic Data")] 
		TrafficData = 14,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supplyService : int {
		[System.ComponentModel.Description("TheProvisionOfShoresideElectricalPowerToAShipAtBerthWhileItsMainAndAuxiliaryEnginesAreShutDown")]
		[EnumMember(Value = "Shore Power")] 
		ShorePower = 1,

		[System.ComponentModel.Description("TransferOfFuelOilToTheFuelCompartmentsOfAShip")]
		[EnumMember(Value = "Fuel Oil Bunkering")] 
		FuelOilBunkering = 2,

		[System.ComponentModel.Description("TransferOfLiquefiedNaturalGasToTheFuelCompartmentsOfAShip")]
		[EnumMember(Value = "LNG Bunkering")] 
		LngBunkering = 3,

		[System.ComponentModel.Description("SubstancesCapableOfReducingFrictionHeatAndWearWhenIntroducedAsAFilmBetweenSolidSurfaces")]
		[EnumMember(Value = "Lubricants")] 
		Lubricants = 4,

		[System.ComponentModel.Description("TheGasIntoWhichWaterIsChangedByBoiling")]
		[EnumMember(Value = "Steam")] 
		Steam = 5,

		[System.ComponentModel.Description("WaterWhichCanBeUsedForDrinkingAndFoodPreparation")]
		[EnumMember(Value = "Potable Water")] 
		PotableWater = 6,

		[System.ComponentModel.Description("AUniversalHoseConnectionForTheSupplyOfWaterForFightingFires")]
		[EnumMember(Value = "International Shore Connection")] 
		InternationalShoreConnection = 7,

		[System.ComponentModel.Description("APlaceWhereFoodAndOtherSuchSuppliesAreAvailable")]
		[EnumMember(Value = "Provisions")] 
		Provisions = 8,

		[System.ComponentModel.Description("ADealerInShipsSupplies")]
		[EnumMember(Value = "Chandler")] 
		Chandler = 9,

		[System.ComponentModel.Description("APlaceWhereMechanicalRepairsCanBeUndertakenToEnginesOrOtherVesselEquipment")]
		[EnumMember(Value = "Mechanics Workshop")] 
		MechanicsWorkshop = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum technicalPortService : int {
		[System.ComponentModel.Description("TheProcessOfNeutralizingOrReducingToAMinimumTheMagneticEffectsTheVesselItselfExertsOnAMagneticCompassItIsBasedOnThePrincipleThatTheMagneticEffectOfTheIronAndSteelOfTheVesselCanBeCounterbalancedByMeansOfMagnetsAndSoftIronPlacedNearTheCompassAlsoCalledCompassAdjustmentCompassCompensationOrMagneticCompensation")]
		[EnumMember(Value = "Compensation of Magnetic Compass")] 
		CompensationOfMagneticCompass = 1,

		[System.ComponentModel.Description("NeutralizationOfTheStrengthOfTheMagneticFieldOfAVesselByMeansOfSuitablyArrangedElectricCoilsPermanentlyInstalledInTheVesselSeeAlsoDegaussingCable")]
		[EnumMember(Value = "Degaussing")] 
		Degaussing = 2,

		[System.ComponentModel.Description("InspectionEvaluationOrMonitoringOfTheQuantityStowageLoadingAndUnloadingAndConditionOfCargoAndTheEffectsOfCargoesOnVesselStabilityAndSafety")]
		[EnumMember(Value = "Cargo Surveying")] 
		CargoSurveying = 3,

		[System.ComponentModel.Description("AssessmentOfQualityAndComplianceWithApplicableLawRegulationsAndSafetyStandards")]
		[EnumMember(Value = "Vetting")] 
		Vetting = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum telecommunicationService : int {
		[System.ComponentModel.Description("TheTransferOrExchangeOfInformationByUsingSoundsThatAreBeingMadeByMouthAndThroatWhenSpeaking")]
		[EnumMember(Value = "Voice")] 
		Voice = 1,

		[System.ComponentModel.Description("ASystemOfTransmittingAndReproducingGraphicMatterAsPrintingOrStillPicturesByMeansOfSignalsSentOverTelephoneLines")]
		[EnumMember(Value = "Facsimile")] 
		Facsimile = 2,

		[System.ComponentModel.Description("ShortMessageServiceIsAFormOfTextMessagingCommunicationOnPhonesAndMobilePhones")]
		[EnumMember(Value = "SMS")] 
		Sms = 3,

		[System.ComponentModel.Description("ARepresentationOfFactsConceptsOrInstructionsInAFormalisedMannerSuitableForCommunicationInterpretationOrProcessing")]
		[EnumMember(Value = "Data")] 
		Data = 4,

		[System.ComponentModel.Description("DataThatIsConstantlyReceivedByAndPresentedToAnEndUserWhileBeingDeliveredByAProvider")]
		[EnumMember(Value = "Streamed Data")] 
		StreamedData = 5,

		[System.ComponentModel.Description("ASystemOfCommunicationInWhichMessagesAreSentOverLongDistancesByUsingATelephoneSystemAndArePrintedByUsingASpecialMachineCalledATeletypewriter")]
		[EnumMember(Value = "Telex")] 
		Telex = 6,

		[System.ComponentModel.Description("AnApparatusSystemOrProcessForCommunicationAtADistanceByElectricTransmissionOverWire")]
		[EnumMember(Value = "Telegraph")] 
		Telegraph = 7,

		[System.ComponentModel.Description("MessagesAndOtherDataExchangedBetweenIndividualsUsingComputersInANetwork")]
		[EnumMember(Value = "Email")] 
		Email = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum textType : int {
		[System.ComponentModel.Description("TheIndividualNameOfAFeature")]
		[EnumMember(Value = "Name")] 
		Name = 1,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("TheAverageHeightOfTheLowWatersOfSpringTidesThisLevelIsUsedAsATidalDatumInSomeAreasAlsoCalledSpringLowWater")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		MeanLowWaterSprings = 1,

		[System.ComponentModel.Description("TheAverageHeightOfLowerLowWaterSpringsAtAPlace")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		MeanLowerLowWaterSprings = 2,

		[System.ComponentModel.Description("TheAverageHeightOfTheSurfaceOfTheSeaAtATideStationForAllStagesOfTheTideOverA19YearPeriodUsuallyDeterminedFromHourlyHeightReadingsMeasuredFromAFixedPredeterminedReferenceLevel")]
		[EnumMember(Value = "Mean Sea Level")] 
		MeanSeaLevel = 3,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestTideObservedAtAPlaceOrSomeWhatLower")]
		[EnumMember(Value = "Lowest Low Water")] 
		LowestLowWater = 4,

		[System.ComponentModel.Description("TheAverageHeightOfAllLowWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Low Water")] 
		MeanLowWater = 5,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestWaterLevelObservedAtAPlaceAtSpringTidesDuringAPeriodOfTimeShorterThan19Years")]
		[EnumMember(Value = "Lowest Low Water Springs")] 
		LowestLowWaterSprings = 6,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowWaterSpringsMlws")]
		[EnumMember(Value = "Approximate Mean Low Water Springs")] 
		ApproximateMeanLowWaterSprings = 7,

		[System.ComponentModel.Description("AnArbitraryTidalDatumApproximatingTheLevelOfTheMeanOfTheLowerLowWaterAtSpringTidesItWasFirstUsedInWatersSurroundingIndia")]
		[EnumMember(Value = "Indian Spring Low Water")] 
		IndianSpringLowWater = 8,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingThatOfMeanLowWaterSpringsMlws")]
		[EnumMember(Value = "Low Water Springs")] 
		LowWaterSprings = 9,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfLowestAstronomicalTideLat")]
		[EnumMember(Value = "Approximate Lowest Astronomical Tide")] 
		ApproximateLowestAstronomicalTide = 10,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingTheLowestWaterLevelObservedAtAPlaceUsuallyEquivalentToTheIndianSpringLowWaterIslw")]
		[EnumMember(Value = "Nearly Lowest Low Water")] 
		NearlyLowestLowWater = 11,

		[System.ComponentModel.Description("TheAverageHeightOfTheLowerLowWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Lower Low Water")] 
		MeanLowerLowWater = 12,

		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillationAlsoCalledLowTide")]
		[EnumMember(Value = "Low Water")] 
		LowWater = 13,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowWaterMlw")]
		[EnumMember(Value = "Approximate Mean Low Water")] 
		ApproximateMeanLowWater = 14,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanLowerLowWaterMllw")]
		[EnumMember(Value = "Approximate Mean Lower Low Water")] 
		ApproximateMeanLowerLowWater = 15,

		[System.ComponentModel.Description("TheAverageHeightOfAllHighWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean High Water")] 
		MeanHighWater = 16,

		[System.ComponentModel.Description("TheAverageHeightOfTheHighWatersOfSpringTidesAlsoCalledSpringHighWater")]
		[EnumMember(Value = "Mean High Water Springs")] 
		MeanHighWaterSprings = 17,

		[System.ComponentModel.Description("TheHighestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "High Water")] 
		HighWater = 18,

		[System.ComponentModel.Description("AnArbitraryLevelUsuallyWithin03mFromThatOfMeanSeaLevelMsl")]
		[EnumMember(Value = "Approximate Mean Sea Level")] 
		ApproximateMeanSeaLevel = 19,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingThatOfMeanHighWaterSpringsMhws")]
		[EnumMember(Value = "High Water Springs")] 
		HighWaterSprings = 20,

		[System.ComponentModel.Description("TheAverageHeightOfHigherHighWatersAtAPlaceOverA19YearPeriod")]
		[EnumMember(Value = "Mean Higher High Water")] 
		MeanHigherHighWater = 21,

		[System.ComponentModel.Description("TheLevelOfLowWaterSpringsNearTheTimeOfAnEquinox")]
		[EnumMember(Value = "Equinoctial Spring Low Water")] 
		EquinoctialSpringLowWater = 22,

		[System.ComponentModel.Description("TheLowestTideLevelWhichCanBePredictedToOccurUnderAverageMeteorologicalConditionsAndUnderAnyCombinationOfAstronomicalConditions")]
		[EnumMember(Value = "Lowest Astronomical Tide")] 
		LowestAstronomicalTide = 23,

		[System.ComponentModel.Description("AnArbitraryDatumDefinedByALocalHarbourAuthorityFromWhichLevelsAndTidalHeightsAreMeasuredByThisAuthority")]
		[EnumMember(Value = "Local Datum")] 
		LocalDatum = 24,

		[System.ComponentModel.Description("AVerticalReferenceSystemWithItsZeroBasedOnTheMeanWaterLevelAtRimouskiPointeAuPereQuebecOverThePeriod1970To1988")]
		[EnumMember(Value = "International Great Lakes Datum 1985")] 
		InternationalGreatLakesDatum1985 = 25,

		[System.ComponentModel.Description("TheAverageOfAllHourlyWaterLevelsOverTheAvailablePeriodOfRecord")]
		[EnumMember(Value = "Mean Water Level")] 
		MeanWaterLevel = 26,

		[System.ComponentModel.Description("TheAverageOfTheLowestLowWatersOneFromEachOf19YearsOfObservations")]
		[EnumMember(Value = "Lower Low Water Large Tide")] 
		LowerLowWaterLargeTide = 27,

		[System.ComponentModel.Description("TheAverageOfTheHighestHighWatersOneFromEachOf19YearsOfObservations")]
		[EnumMember(Value = "Higher High Water Large Tide")] 
		HigherHighWaterLargeTide = 28,

		[System.ComponentModel.Description("AnArbitraryLevelApproximatingTheHighestWaterLevelObservedAtAPlaceUsuallyEquivalentToTheHighWaterSprings")]
		[EnumMember(Value = "Nearly Highest High Water")] 
		NearlyHighestHighWater = 29,

		[System.ComponentModel.Description("TheHighestTidalLevelWhichCanBePredictedToOccurUnderAverageMeteorologicalConditionsAndUnderAnyCombinationOfAstronomicalConditions")]
		[EnumMember(Value = "Highest Astronomical Tide")] 
		HighestAstronomicalTide = 30,

		[System.ComponentModel.Description("TheDatumRefersToEachBalticCountrySRealizationOfTheEuropeanVerticalReferenceSystemEvrsWithLandUpliftEpoch2000WhichIsConnectedToTheNormaalAmsterdamsPeilNap")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		BalticSeaChartDatum2000 = 44,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[System.ComponentModel.Description("TheMaximumLengthOfTheShip")]
		[EnumMember(Value = "Length Overall")] 
		LengthOverall = 1,

		[System.ComponentModel.Description("TheShipSLengthMeasuredAtTheWaterline")]
		[EnumMember(Value = "Length at Waterline")] 
		LengthAtWaterline = 2,

		[System.ComponentModel.Description("TheWidthOrBeamOfTheVessel")]
		[EnumMember(Value = "Breadth")] 
		Breadth = 3,

		[System.ComponentModel.Description("TheDepthOfWaterNecessaryToFloatAVesselFullyLoaded")]
		[EnumMember(Value = "Draught")] 
		Draught = 4,

		[System.ComponentModel.Description("AMeasurementOfTheWeightOfTheVesselUsuallyUsedForWarshipsMerchantShipsAreUsuallyMeasuredBasedOnTheVolumeOfCargoSpaceSeeTonnageDisplacementIsExpressedEitherInLongTonsOf2240PoundsOrMetricTonnesOf1000KgSinceTheTwoUnitsAreVeryCloseInSize2240Pounds1016KgAnd1000Kg2205PoundsItIsCommonNotToDistinguishBetweenThemToPreserveSecrecyNationsSometimesMisstateAWarshipSDisplacement")]
		[EnumMember(Value = "Displacement Tonnage")] 
		DisplacementTonnage = 6,

		[System.ComponentModel.Description("TheWeightOfTheShipExcludingCargoFuelBallastStoresPassengersAndCrewButWithWaterInTheBoilersToSteamingLevel")]
		[EnumMember(Value = "Displacement Tonnage, Light")] 
		DisplacementTonnageLight = 7,

		[System.ComponentModel.Description("TheWeightOfTheShipIncludingCargoPassengersFuelWaterStoresDunnageAndSuchOtherItemsNecessaryForUseOnAVoyageWhichBringsTheVesselDownToHerLoadDraft")]
		[EnumMember(Value = "Displacement Tonnage, Loaded")] 
		DisplacementTonnageLoaded = 8,

		[System.ComponentModel.Description("TheDifferenceBetweenDisplacementLightAndDisplacementLoadedAMeasureOfTheShipSTotalCarryingCapacity")]
		[EnumMember(Value = "Deadweight Tonnage")] 
		DeadweightTonnage = 9,

		[System.ComponentModel.Description("TheEntireInternalCubicCapacityOfTheShipExpressedInTonsOf100CubicFeetToTheTonExceptCertainSpacesWithAreExemptedSuchAsPeakAndOtherTanksForWaterBallastOpenForecastleBridgeAndPoopAccessOfHatchwaysCertainLightAndAirSpacesDomesOfSkylightsCondenserAnchorGearSteeringGearWheelHouseGalleyAndCabinForPassengers")]
		[EnumMember(Value = "Gross Tonnage")] 
		GrossTonnage = 10,

		[System.ComponentModel.Description("ObtainedFromTheGrossTonnageByDeductingCrewAndNavigatingSpacesAndAllowancesForPropulsionMachinery")]
		[EnumMember(Value = "Net Tonnage")] 
		NetTonnage = 11,

		[System.ComponentModel.Description("ThePanamaCanalUniversalMeasurementSystemPcUmsIsBasedOnNetTonnageModifiedForPanamaCanalPurposesPcUmsIsBasedOnAMathematicalFormulaToCalculateAVesselSTotalVolumeAPcUmsNetTonIsEquivalentTo100CubicFeetOfCapacity")]
		[EnumMember(Value = "Panama Canal/Universal Measurement System Net Tonnage")] 
		PanamaCanalUniversalMeasurementSystemNetTonnage = 12,

		[System.ComponentModel.Description("TheSuezCanalNetTonnageScntIsDerivedWithANumberOfModificationsFromTheFormerNetRegisterTonnageOfTheMoorsomSystemAndWasEstablishedByTheInternationalCommissionOfConstantinopleInItsProtocolOf18December1873ItIsStillInUseAsAmendedByTheRulesOfNavigationOfTheSuezCanalAuthorityAndIsRegisteredInTheSuezCanalTonnageCertificate")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		SuezCanalNetTonnage = 13,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		Metres = 1,

		[System.ComponentModel.Description("TheTonneOrMetricTonUSOftenRedundantlyReferredToAsAMetricTonneIsAUnitOfMassEqualTo1000Kg2205LbOrApproximatelyTheMassOfOneCubicMetreOfWaterAtFourDegreesCelsiusItIsSometimesAbbreviatedAsMtInTheUnitedStatesButThisConflictsWithOtherSiSymbolsTheTonneIsNotAUnitInTheInternationalSystemOfUnitsSiButIsAcceptedForUseWithTheSiInSiUnitsAndPrefixesTheTonneIsAMegagramMgTheImperialAndUsCustomaryUnitsComparableToTheTonneAreBothSpelledTonInEnglishThoughTheyDifferInMassPronunciationOfTonneTheWordUsedInTheUkAndTonIsUsuallyIdenticalButIsNotTooConfusingUnlessAccuracyIsImportantAsTheTonneAndUkLongTonDifferByOnly16")]
		[EnumMember(Value = "Metric Ton")] 
		MetricTon = 3,

		[System.ComponentModel.Description("LongTonWeightTonOrImperialTonIsTheNameForTheUnitCalledTheTonInTheAvoirdupoisOrImperialSystemOfMeasurementsAsUsedInTheUnitedKingdomAndSeveralOtherCommonwealthCountriesItHasBeenMostlyReplacedByTheTonneAndInTheUnitedStatesByTheShortTonOneLongTonIsEqualTo2240Pounds1016KgOr35CubicFeet09911MOfSaltWaterWithADensityOf64LbFt1025GMlItHasSomeLimitedUseInTheUnitedStatesMostCommonlyInMeasuringTheDisplacementOfShipsAndWasTheUnitPrescribedForWarshipsByTheWashingtonNavalTreatyForExampleBattleshipsWereLimitedToAMassOf35000LongTons36000T39000St")]
		[EnumMember(Value = "Ton")] 
		Ton = 4,

		[System.ComponentModel.Description("AUnitOfWeightEqualTo2000Pounds90718474KgInTheUnitedStatesItIsOftenCalledSimplyTonWithoutDistinguishingItFromTheMetricTonTonne1000KilogramsOrTheLongTon2240Pounds10160469088KilogramsRatherTheOtherTwoAreSpecificallyNotedThereAreHoweverSomeUsApplicationsForWhichUnspecifiedTonsNormallyMeansLongTonsForExampleNavyShipsOrMetricTonsWorldGrainProductionFiguresBothTheLongAndShortTonAreDefinedAs20HundredweightsButAHundredweightIs100Pounds45359237KgInTheUsSystemShortOrNetHundredweightAnd112Pounds5080234544KgInTheImperialSystemLongOrGrossHundredweight")]
		[EnumMember(Value = "Short Ton")] 
		ShortTon = 5,

		[System.ComponentModel.Description("GrossTonnageGtIsAFunctionOfTheVolumeOfAllShipSEnclosedSpacesFromKeelToFunnelMeasuredToTheOutsideOfTheHullFramingThereIsASlidingScaleFactorSoGtIsAKindOfCapacityDerivedIndexThatIsUsedToRankAShipForPurposesOfDeterminingManningSafetyAndOtherStatutoryRequirementsAndIsExpressedSimplyAsGtWhichIsAUnitlessEntityEvenThoughItsDerivationIsTiedToTheCubicMeterUnitOfVolumetricCapacityTonnageMeasurementsAreNowGovernedByAnImoConventionInternationalConventionOnTonnageMeasurementOfShips1969LondonRulesWhichAppliesToAllShipsBuiltAfterJuly1982InAccordanceWithTheConventionTheCorrectTermToUseNowIsGtWhichIsAFunctionOfTheMouldedVolumeOfAllEnclosedSpacesOfTheShip")]
		[EnumMember(Value = "Gross Ton")] 
		GrossTon = 6,

		[System.ComponentModel.Description("NetTonnageNtIsBasedOnACalculationOfTheVolumeOfAllCargoSpacesOfTheShipItIndicatesAVesselsEarningSpaceAndIsAFunctionOfTheMouldedVolumeOfAllCargoSpacesOfTheShip")]
		[EnumMember(Value = "Net Ton")] 
		NetTon = 7,

		[System.ComponentModel.Description("TheSuezCanalNetTonnageScntIsDerivedWithANumberOfModificationsFromTheFormerNetRegisterTonnageOfTheMoorsomSystemAndWasEstablishedByTheInternationalCommissionOfConstantinopleInItsProtocolOf18December1873ItIsStillInUseAsAmendedByTheRulesOfNavigationOfTheSuezCanalAuthorityAndIsRegisteredInTheSuezCanalTonnageCertificate")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		SuezCanalNetTonnage = 9,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum wasteDisposalService : int {
		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeOilyBilgeWaterAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Oily Bilge Water")] 
		MarpolAnnexIOilyBilgeWater = 1,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeOilyResiduesSludgeAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Oily Residues")] 
		MarpolAnnexIOilyResidues = 2,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeOilyTankWashingsSlopsAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Oily Tank Washings")] 
		MarpolAnnexIOilyTankWashings = 3,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeDirtyBallastWaterAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Dirty Ballast Water")] 
		MarpolAnnexIDirtyBallastWater = 4,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeScaleAndSludgeFromTankCleaningAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Scale and Sludge from Tank Cleaning")] 
		MarpolAnnexIScaleAndSludgeFromTankCleaning = 5,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveOilRelatedWasteResidueOfTheTypeOtherAsSpecifiedInMarpolAnnexI")]
		[EnumMember(Value = "MARPOL Annex I Other Oily Waste")] 
		MarpolAnnexIOtherOilyWaste = 6,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveChemicalNoxiousLiquidSubstancesRelatedWasteResidueOfTheTypeCategoryXAsSpecifiedInMarpolAnnexIi")]
		[EnumMember(Value = "MARPOL Annex II Category X")] 
		MarpolAnnexIiCategoryX = 7,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveChemicalNoxiousLiquidSubstancesRelatedWasteResidueOfTheTypeCategoryYAsSpecifiedInMarpolAnnexIi")]
		[EnumMember(Value = "MARPOL Annex II Category Y")] 
		MarpolAnnexIiCategoryY = 8,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveChemicalNoxiousLiquidSubstancesRelatedWasteResidueOfTheTypeCategoryZAsSpecifiedInMarpolAnnexIi")]
		[EnumMember(Value = "MARPOL Annex II Category Z")] 
		MarpolAnnexIiCategoryZ = 9,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveChemicalNoxiousLiquidSubstancesRelatedWasteResidueOfTheTypeOtherSubstanceAsSpecifiedInMarpolAnnexIi")]
		[EnumMember(Value = "MARPOL Annex II Category OS")] 
		MarpolAnnexIiCategoryOs = 10,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveWasteResidueOfTheTypeSewageAsSpecifiedInMarpolAnnexIv")]
		[EnumMember(Value = "MARPOL Annex IV Sewage")] 
		MarpolAnnexIvSewage = 11,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypePlasticsAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Plastics")] 
		MarpolAnnexVPlastics = 12,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeFoodWastesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Food Wastes")] 
		MarpolAnnexVFoodWastes = 13,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeDomesticWastesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Domestic Wastes")] 
		MarpolAnnexVDomesticWastes = 14,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeCookingOilAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Cooking Oil")] 
		MarpolAnnexVCookingOil = 15,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeIncineratorAshesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Incinerator Ashes")] 
		MarpolAnnexVIncineratorAshes = 16,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeOperationalWastesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Operational Wastes")] 
		MarpolAnnexVOperationalWastes = 17,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeAnimalCarcassesAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Animal Carcasses")] 
		MarpolAnnexVAnimalCarcasses = 18,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeFishingGearAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Fishing Gear")] 
		MarpolAnnexVFishingGear = 19,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeEWasteAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V E-Waste")] 
		MarpolAnnexVEWaste = 20,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeCargoResiduesNotDeterminedToBeHarmfulToTheMarineEnvironmentAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Cargo Residues - non-HME")] 
		MarpolAnnexVCargoResiduesNonHme = 21,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveGarbageRelatedWasteResidueOfTheTypeCargoResiduesHarmfulToTheMarineEnvironmentAsSpecifiedInMarpolAnnexV")]
		[EnumMember(Value = "MARPOL Annex V Cargo Residues - HME")] 
		MarpolAnnexVCargoResiduesHme = 22,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveAirPollutionRelatedWasteResidueOfTheTypeOzoneDepletingSubstancesAsSpecifiedInMarpolAnnexVi")]
		[EnumMember(Value = "MARPOL Annex VI Ozone-Depleting Substances")] 
		MarpolAnnexViOzoneDepletingSubstances = 23,

		[System.ComponentModel.Description("TheServiceWithFacilityToReceiveAirPollutionRelatedWasteResidueOfTheTypeExhaustGasCleaningResiduesAsSpecifiedInMarpolAnnexVi")]
		[EnumMember(Value = "MARPOL Annex VI Exhaust Gas-Cleaning Residues")] 
		MarpolAnnexViExhaustGasCleaningResidues = 24,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
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
			public List<String> deliveryPoint {get;set;} = [];

			public String? cityName {get;set;} = default;

			public String? administrativeDivision {get;set;} = default;

			public String? countryName {get;set;} = default;

			public String? postalCode {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			public Boolean? displayName {get;set;} = default;

			public String? language {get;set;} = default;

			public String name {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class fixedDateRange {
			public DateOnly? dateStart {get;set;} = default;

			public DateOnly? dateEnd {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair {
			public List<int> frequencyShoreStationTransmits {get;set;} = [];

			public List<int> frequencyShoreStationReceives {get;set;} = [];

			public List<String> contactInstructions {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty {
			[Required()]
			public decimal uncertaintyFixed {get;set;}

			public decimal? uncertaintyVariableFactor {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			public String? fileLocator {get;set;} = default;

			public String? fileReference {get;set;} = default;

			public List<String> headline {get;set;} = [];

			public String? language {get;set;} = default;

			public String? text {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			public String onlineResourceLinkageURL {get;set;} = string.Empty;

			public String? protocol {get;set;} = default;

			public String? applicationProfile {get;set;} = default;

			public String? nameOfResource {get;set;} = default;

			public String? onlineResourceDescription {get;set;} = default;

			[EnumerationValue([1,3,4,5,6,7,8,9,10,11])]
			public onlineFunction? onlineFunction {get;set;} = default;

			public String? protocolRequest {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation {
			public decimal? orientationUncertainty {get;set;} = default;

			[Required()]
			public decimal orientationValue {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[Required()]
			public DateOnly dateStart {get;set;}

			[Required()]
			public DateOnly dateEnd {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rxNCode {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public categoryOfRxN? categoryOfRxN {get;set;} = default;

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public actionOrActivity? actionOrActivity {get;set;} = default;

			public List<String> headline {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surveyDateRange {
			public DateOnly? dateStart {get;set;} = default;

			[Required()]
			public DateOnly dateEnd {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textContent {
			[EnumerationValue([1,2,3])]
			public categoryOfText? categoryOfText {get;set;} = default;

			public List<information> information {get;set;} = [];

			public onlineResource? onlineResource {get;set;} = default;

			public String? source {get;set;} = default;

			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalsByDayOfWeek {
			[EnumerationValue([1,2,3,4,5,6,7])]
			public List<dayOfWeek> dayOfWeek {get;set;} = [];

			public Boolean? dayOfWeekIsRange {get;set;} = default;

			public List<TimeOnly> timeOfDayStart {get;set;} = [];

			public List<TimeOnly> timeOfDayEnd {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class usefulMarkDescription {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalUncertainty {
			[Required()]
			public decimal uncertaintyFixed {get;set;}

			public decimal? uncertaintyVariableFactor {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselsMeasurements {
			[EnumerationValue([1,2,3,4,5,6])]
			[Required()]
			public comparisonOperator comparisonOperator {get;set;}

			[EnumerationValue([1,2,3,4,6,7,8,9,10,11,12,13])]
			[Required()]
			public vesselsCharacteristics vesselsCharacteristics {get;set;}

			[Required()]
			public decimal vesselsCharacteristicsValue {get;set;}

			[EnumerationValue([1,3,4,5,6,7,9])]
			[Required()]
			public vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class weatherResource {
			public onlineResource? onlineResource {get;set;} = default;

			[EnumerationValue([1,2,3,4])]
			public dynamicResource? dynamicResource {get;set;} = default;

			public textContent? textContent {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class bearingInformation {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public cardinalDirection? cardinalDirection {get;set;} = default;

			public decimal? distance {get;set;} = default;

			public List<decimal> sectorBearing {get;set;} = [];

			public List<information> information {get;set;} = [];

			public orientation? orientation {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class cargoServicesDescription {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class constructionInformation {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			[EnumerationValue([1,2,3,5])]
			public condition? condition {get;set;} = default;

			public String development {get;set;} = string.Empty;

			public String? locationByText {get;set;} = default;

			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class depthsDescription {
			[EnumerationValue([1,2,3])]
			[Required()]
			public categoryOfDepthsDescription categoryOfDepthsDescription {get;set;}

			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class facilitiesLayoutDescription {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class generalPortDescription {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class graphic {
			public List<String> pictorialRepresentation {get;set;} = [];

			public String? pictureCaption {get;set;} = default;

			public DateOnly? sourceDate {get;set;} = default;

			public String? pictureInformation {get;set;} = default;

			public bearingInformation? bearingInformation {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class landmarkDescription {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class limitsDescription {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class majorLightDescription {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class markedBy {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class offshoreMarkDescription {
			public List<textContent> textContent {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class scheduleByDayOfWeek {
			[EnumerationValue([1,2,3])]
			public categoryOfSchedule? categoryOfSchedule {get;set;} = default;

			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class spatialAccuracy {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			public String telecommunicationIdentifier {get;set;} = string.Empty;

			public String? telecommunicationCarrier {get;set;} = default;

			public String? contactInstructions {get;set;} = default;

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];

			public scheduleByDayOfWeek? scheduleByDayOfWeek {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class generalHarbourInformation {
			public generalPortDescription? generalPortDescription {get;set;} = default;

			public facilitiesLayoutDescription? facilitiesLayoutDescription {get;set;} = default;

			public limitsDescription? limitsDescription {get;set;} = default;

			public constructionInformation? constructionInformation {get;set;} = default;

			public cargoServicesDescription? cargoServicesDescription {get;set;} = default;

			public List<weatherResource> weatherResource {get;set;} = [];
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
			[EnumerationValue([1,2])]
			[Required()]
			public membership membership {get;set;}

			[JsonIgnore]
			public override string Code => nameof(InclusionType);
		}

		/// <summary>
		/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PermissionType : InformationAssociation {
			[EnumerationValue([1,2,3,4,5,6])]
			[Required()]
			public categoryOfRelationship categoryOfRelationship {get;set;}

			[JsonIgnore]
			public override string Code => nameof(PermissionType);
		}

		[SpatialAssocation]
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
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public List<graphic> graphic {get;set;} = [];

			public String? source {get;set;} = default;

			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

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
				},
			];
		}

		/// <summary>
		/// An abstract superclass for information types that encode rules, recommendations, and general information in text or graphic form.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class AbstractRxN : InformationType {
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			public List<rxNCode> rxNCode {get;set;} = [];

			public List<textContent> textContent {get;set;} = [];

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.theOrganisation)!,
					informationTypes = [nameof(Authority)],
				},
			];
		}

		/// <summary>
		/// Describes the relationship between vessel characteristics and: (i) the applicability of an associated information object or feature to the vessel; or, (ii) the use of a facility, place, or service by the vessel; or, (iii) passage of the vessel through an area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Applicability : InformationType {
			public Boolean? inBallast {get;set;} = default;

			[EnumerationValue([2,5,6,7,8,10,11,12,13,14,15])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21])]
			public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public categoryOfVessel? categoryOfVessel {get;set;} = default;

			[EnumerationValue([1,2])]
			public categoryOfVesselRegistry? categoryOfVesselRegistry {get;set;} = default;

			[EnumerationValue([1,2])]
			public logicalConnectives? logicalConnectives {get;set;} = default;

			public int? thicknessOfIceCapability {get;set;} = default;

			public String? vesselPerformance {get;set;} = default;

			public List<information> information {get;set;} = [];

			public List<vesselsMeasurements> vesselsMeasurements {get;set;} = [];

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PermissionType),
					role = Enum.GetName<Role>(Role.vslLocation)!,
					informationTypes = [nameof(InformationType)],
				},
			];
		}

		/// <summary>
		/// A person or organisation having political or administrative power and control.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Authority : InformationType {
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			[Required()]
			public categoryOfAuthority categoryOfAuthority {get;set;}

			public textContent? textContent {get;set;} = default;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(AbstractRxN)],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
				},
			];
		}

		/// <summary>
		/// Services that are available for a given port.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AvailablePortServices : InformationType {
			[EnumerationValue([1,2,3])]
			public List<firefightingService> firefightingService {get;set;} = [];

			[EnumerationValue([1,2,3,4,5])]
			public List<medicalService> medicalService {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public List<repairService> repairService {get;set;} = [];

			[EnumerationValue([1,2,3,4])]
			public List<technicalPortService> technicalPortService {get;set;} = [];

			[EnumerationValue([1,2,3])]
			public List<shipSanitationControl> shipSanitationControl {get;set;} = [];

			[EnumerationValue([2,3,4,5,6,8,9,11,12,13])]
			public List<transportConnection> transportConnection {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6])]
			public List<berthingAssistance> berthingAssistance {get;set;} = [];

			[EnumerationValue([1,2,3,4])]
			public List<cargoService> cargoService {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<securitySafetyEmergencyService> securitySafetyEmergencyService {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
			public List<wasteDisposalService> wasteDisposalService {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public List<supplyService> supplyService {get;set;} = [];

			public String? tugInformation {get;set;} = default;

			public List<textContent> textContent {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(AvailablePortServices);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..AvailablePortServices._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}

		/// <summary>
		/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContactDetails : InformationType {
			public String? callName {get;set;} = default;

			public String? callSign {get;set;} = default;

			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			public List<String> communicationChannel {get;set;} = [];

			public List<contactAddress> contactAddress {get;set;} = [];

			public String? contactInstructions {get;set;} = default;

			public List<int> signalFrequency {get;set;} = [];

			public List<frequencyPair> frequencyPair {get;set;} = [];

			public List<information> information {get;set;} = [];

			public String? mMSICode {get;set;} = default;

			public List<onlineResource> onlineResource {get;set;} = [];

			public List<telecommunications> telecommunications {get;set;} = [];

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
				},
			];
		}

		/// <summary>
		/// The seaward end of a channel, harbour, dock, etc.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Entrance : InformationType {
			public String? entranceDescription {get;set;} = default;

			public List<String> associatedFeatureName {get;set;} = [];

			public String? localKnowledgeDescription {get;set;} = default;

			public String? approachDescription {get;set;} = default;

			public List<markedBy> markedBy {get;set;} = [];

			public List<landmarkDescription> landmarkDescription {get;set;} = [];

			public List<offshoreMarkDescription> offshoreMarkDescription {get;set;} = [];

			public List<majorLightDescription> majorLightDescription {get;set;} = [];

			public List<usefulMarkDescription> usefulMarkDescription {get;set;} = [];

			public List<textContent> textContent {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Entrance);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..Entrance._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
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
				},
			];
		}

		/// <summary>
		/// Days when many services are not available. Often days of festivity or recreation or public holidays when normal working hours are limited, especially a national or religious festival, etc.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NonStandardWorkingDay : InformationType {
			public List<DateOnly> dateFixed {get;set;} = [];

			public List<String> dateVariable {get;set;} = [];

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(NonStandardWorkingDay);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..NonStandardWorkingDay._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];
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
		}

		/// <summary>
		/// The time when a service is available and known exceptions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceHours : InformationType {
			public List<scheduleByDayOfWeek> scheduleByDayOfWeek {get;set;} = [];

			public List<information> information {get;set;} = [];

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theAuthority_srvHrs)!,
					informationTypes = [nameof(Authority)],
				},
			];
		}

		/// <summary>
		/// The indication of the quality of the locational information for features in a dataset.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQuality : InformationNode, IInformationBindingDefinition {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			public List<spatialAccuracy> spatialAccuracy {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SpatialQuality);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
	}
	namespace FeatureTypes {
		using FeatureAssociations;
		using InformationTypes;

		/// <summary>
		/// Generalized feature type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FeatureType : FeatureNode, IFeatureBindingDefinition {
			public String? locationMRN {get;set;} = default;

			public String? globalLocationNumber {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public List<rxNCode> rxNCode {get;set;} = [];

			public List<graphic> graphic {get;set;} = [];

			public String? source {get;set;} = default;

			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			public List<textContent> textContent {get;set;} = [];

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AssociatedRxN),
					role = Enum.GetName<Role>(Role.theRxN)!,
					informationTypes = [nameof(AbstractRxN)],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.providesInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => FeatureType._featureBindingDefinitions;
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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..OrganizationContactArea._featureBindingDefinitions];
			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..SupervisedArea._featureBindingDefinitions];
			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// The physical installations and facilities that support operations in a port or harbour.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class HarbourPhysicalInfrastructure : SupervisedArea {
			public decimal? verticalClearanceValue {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(HarbourPhysicalInfrastructure);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..HarbourPhysicalInfrastructure._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..HarbourPhysicalInfrastructure._featureBindingDefinitions];
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
			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..AnchorBerth._featureBindingDefinitions];
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
		}

		/// <summary>
		/// An area in which vessels or seaplanes anchor or may anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorageArea : Layout {
			public depthsDescription? depthsDescription {get;set;} = default;

			public String? locationByText {get;set;} = default;

			public markedBy? markedBy {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..AnchorageArea._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A place, generally named or numbered, where a vessel may moor or anchor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Berth : Layout {
			public decimal? availableBerthingLength {get;set;} = default;

			public String? bollardDescription {get;set;} = default;

			public decimal? bollardPull {get;set;} = default;

			public decimal? minimumBerthDepth {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public Boolean? cathodicProtectionSystem {get;set;} = default;

			[EnumerationValue([1,2,3,4])]
			public categoryOfBerthLocation? categoryOfBerthLocation {get;set;} = default;

			public String? portFacilityNumber {get;set;} = default;

			public List<String> bollardNumber {get;set;} = [];

			public String? gLNExtension {get;set;} = default;

			public List<String> metreMarkNumber {get;set;} = [];

			public List<String> manifoldNumber {get;set;} = [];

			public String? rampNumber {get;set;} = default;

			public String? locationByText {get;set;} = default;

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public methodOfSecuring? methodOfSecuring {get;set;} = default;

			public String uNLocationCode {get;set;} = string.Empty;

			public String? terminalIdentifier {get;set;} = default;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..Berth._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A specific position within a berth where a vessel may be moored or anchored.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BerthPosition : Layout {
			public decimal? availableBerthingLength {get;set;} = default;

			public String? bollardDescription {get;set;} = default;

			public decimal? bollardPull {get;set;} = default;

			public List<String> bollardNumber {get;set;} = [];

			public String? gLNExtension {get;set;} = default;

			public List<String> metreMarkNumber {get;set;} = [];

			public List<String> manifoldNumber {get;set;} = [];

			public String? rampNumber {get;set;} = default;

			public String? locationByText {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(BerthPosition);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Layout._informationBindingDefinitions, ..BerthPosition._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..BerthPosition._featureBindingDefinitions];
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
		}

		/// <summary>
		/// An artificially enclosed area within which ships may moor and which may have gates to regulate water level.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DockArea : Layout {
			public depthsDescription? depthsDescription {get;set;} = default;

			public String? locationByText {get;set;} = default;

			public markedBy? markedBy {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..DockArea._featureBindingDefinitions];
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
		}

		/// <summary>
		/// An artificial basin fitted with a gate or caisson, into which vessels can be floated and the water pumped out to expose the vessel's bottom. Also called graving dock.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DryDock : HarbourPhysicalInfrastructure {
			public decimal? sillDepth {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..HarbourPhysicalInfrastructure._featureBindingDefinitions, ..DryDock._featureBindingDefinitions];
			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A sea area where dredged material or other potentially more harmful material, for example explosives, chemical waste, is deliberately deposited.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DumpingGround : Layout {
			public depthsDescription? depthsDescription {get;set;} = default;

			public String? locationByText {get;set;} = default;

			public markedBy? markedBy {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..DumpingGround._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A form of dry dock consisting of a floating structure of one or more sections which can be partly submerged by controlled flooding to receive a vessel, then raised by pumping out the water so that the vessel's bottom can be exposed.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FloatingDock : HarbourPhysicalInfrastructure {
			public decimal? sillDepth {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..HarbourPhysicalInfrastructure._featureBindingDefinitions, ..FloatingDock._featureBindingDefinitions];
			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A structure in the intertidal zone serving as a support for vessels at low stages of the tide to permit work on the exposed portion of the vessel's hull.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Gridiron : HarbourPhysicalInfrastructure {
			public decimal? sillDepth {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..HarbourPhysicalInfrastructure._featureBindingDefinitions, ..Gridiron._featureBindingDefinitions];
			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// The area over which a harbour authority has jurisdiction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourAreaAdministrative : Layout {
			public String? uNLocationCode {get;set;} = default;

			public String? nationality {get;set;} = default;

			public String? applicableLoadLineZone {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			[EnumerationValue([1,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

			public generalHarbourInformation? generalHarbourInformation {get;set;} = default;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..HarbourAreaAdministrative._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A distinguishable portion of the area over which a harbour authority has jurisdiction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourAreaSection : Layout {
			[EnumerationValue([1,3,8,9,11,12])]
			public categoryOfPortSection? categoryOfPortSection {get;set;} = default;

			[EnumerationValue([4,5,6,9,14,15,16,17])]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

			public facilitiesLayoutDescription? facilitiesLayoutDescription {get;set;} = default;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..HarbourAreaSection._featureBindingDefinitions];
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
		}

		/// <summary>
		/// An enclosed area of water surrounded by quay walls constructed to provide means for the transfer of cargos from and to ships.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourBasin : Layout {
			public depthsDescription? depthsDescription {get;set;} = default;

			public String? locationByText {get;set;} = default;

			public markedBy? markedBy {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..HarbourBasin._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A harbour installation with a service or commercial operation of public interest.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourFacility : HarbourPhysicalInfrastructure {
			[EnumerationValue([12,13])]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..HarbourPhysicalInfrastructure._featureBindingDefinitions, ..HarbourFacility._featureBindingDefinitions];
			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// The equipment or structure used to secure a vessel.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringWarpingFacility : Layout {
			[EnumerationValue([1,2,3,4,5,6,7])]
			[Required()]
			public categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility {get;set;}

			public String iDCode {get;set;} = string.Empty;

			public String? bollardDescription {get;set;} = default;

			public decimal? bollardPull {get;set;} = default;

			public Boolean? heavingLinesFromShore {get;set;} = default;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..MooringWarpingFacility._featureBindingDefinitions];
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
		}

		/// <summary>
		/// The extent to which a coastal State claims or may claim a specific jurisdiction in accordance with the provisions of International Law.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OuterLimit : Layout {
			public limitsDescription? limitsDescription {get;set;} = default;

			public List<markedBy> markedBy {get;set;} = [];

			public List<landmarkDescription> landmarkDescription {get;set;} = [];

			public List<offshoreMarkDescription> offshoreMarkDescription {get;set;} = [];

			public List<majorLightDescription> majorLightDescription {get;set;} = [];

			public List<usefulMarkDescription> usefulMarkDescription {get;set;} = [];

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..OuterLimit._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotBoardingPlace : Layout {
			public depthsDescription? depthsDescription {get;set;} = default;

			public String? locationByText {get;set;} = default;

			public markedBy? markedBy {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..PilotBoardingPlace._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A designated portion of water for the landing and take-off of seaplanes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeaplaneLandingArea : Layout {
			public depthsDescription? depthsDescription {get;set;} = default;

			public String? locationByText {get;set;} = default;

			public markedBy? markedBy {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..SeaplaneLandingArea._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A terminal covers that area on shore which provides buildings and constructions for the transfer of cargo or passengers from and to ships.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Terminal : Layout {
			public String? portFacilityNumber {get;set;} = default;

			[EnumerationValue([1,3,5,7,8,10,11])]
			public categoryOfHarbourFacility? categoryOfHarbourFacility {get;set;} = default;

			[EnumerationValue([2,5,6,7,8,10,11,12,13,14,15])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[EnumerationValue([1,2,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,22])]
			public List<product> product {get;set;} = [];

			public String? terminalIdentifier {get;set;} = default;

			public String? sMDGTerminalCode {get;set;} = default;

			public String? uNLocationCode {get;set;} = default;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.location_srvHrs)!,
					informationTypes = [nameof(ServiceHours)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..Terminal._featureBindingDefinitions];
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
		}

		/// <summary>
		/// An area of water or enlargement of a channel used for turning vessels.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TurningBasin : Layout {
			public depthsDescription? depthsDescription {get;set;} = default;

			public String? locationByText {get;set;} = default;

			public markedBy? markedBy {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public iSPSLevel? iSPSLevel {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..TurningBasin._featureBindingDefinitions];
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
		}

		/// <summary>
		/// An area in which uniform general information of the waterway exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WaterwayArea : Layout {
			[EnumerationValue([1,3,8,9,11,12])]
			[Required()]
			public categoryOfPortSection categoryOfPortSection {get;set;}

			public depthsDescription? depthsDescription {get;set;} = default;

			public String? locationByText {get;set;} = default;

			public markedBy? markedBy {get;set;} = default;

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
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Layout._featureBindingDefinitions, ..WaterwayArea._featureBindingDefinitions];
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
		}

		/// <summary>
		/// A geographical area that describes the coverage and extent of spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public int maximumDisplayScale {get;set;}

			[Required()]
			public int minimumDisplayScale {get;set;}

			[JsonIgnore]
			public override string Code => nameof(DataCoverage);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfNonBathymetricData : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([1,2,3,4,5,6])]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			[Required()]
			public horizontalPositionUncertainty horizontalPositionUncertainty {get;set;}

			public decimal? orientationUncertainty {get;set;} = default;

			public surveyDateRange? surveyDateRange {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(QualityOfNonBathymetricData);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SoundingDatum : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,19,22,23,24,25,26,27,44])]
			[Required()]
			public verticalDatum verticalDatum {get;set;}

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SoundingDatum);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => SoundingDatum._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => SoundingDatum._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// Any level surface (for example Mean Sea Level) taken as a surface of reference to which the elevations within a data set are reduced. Also called datum level, reference level, reference plane, levelling datum, datum for heights.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VerticalDatumOfData : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([3,16,17,18,19,20,21,24,25,26,28,29,30,44])]
			[Required()]
			public verticalDatum verticalDatum {get;set;}

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(VerticalDatumOfData);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => VerticalDatumOfData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => VerticalDatumOfData._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public decimal orientationValue {get;set;}

			public String? text {get;set;} = default;

			[Required()]
			public int textOffsetMm {get;set;}

			[EnumerationValue([1])]
			public textType? textType {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(TextPlacement);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => TextPlacement._featureBindingDefinitions;
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
		}
	}
}

#pragma warning restore CS8981
