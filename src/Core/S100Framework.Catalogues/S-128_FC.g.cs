using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S128 {
	public static class Summary
	{
		public static Version Version => new Version("2.0.0");
		public static string[] ComplexTypes => ["contactAddress","customPaperSize","defaultLocale","featureName","information","issuanceCycle","onlineResource","periodicDateRange","pricing","printInformation","printSize","productSpecification","supportFile","supportFileSpecification","serviceSpecification","sourceIndication","telecommunications","timeIntervalOfProduct","timeIntervalOfCycle","referenceToNM","weekOfYear"];
		public static string[] InformationAssociationTypes => ["CarriageRequirement","DistributionDetails","DistributorContact","PriceOfElement","PriceOfNauticalProduct","ProducerContact","ProductionDetails","ProductPackage"];
		public static string[] FeatureAssociationTypes => ["ProductMapping","Correlated"];
		public static string[] InformationTypes => ["CatalogueSectionHeader","ContactDetails","IndicationOfCarriageRequirement","PriceInformation","ProducerInformation","DistributorInformation"];
		public static string[] FeatureTypes => ["ElectronicProduct","PhysicalProduct","S100Service"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.surface => ["CatalogueElement","NavigationalProduct","ElectronicProduct","PhysicalProduct","S100Service"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"CatalogueElement" => [Primitives.surface],
			"NavigationalProduct" => [Primitives.surface],
			"ElectronicProduct" => [Primitives.surface],
			"PhysicalProduct" => [Primitives.surface],
			"S100Service" => [Primitives.surface],
			_ or "" => throw new InvalidOperationException(),
		};
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum catalogueElementClassification : int {
		[System.ComponentModel.Description("ElectronicNavigationalChart")]
		[EnumMember(Value = "ENC")] 
		[XmlEnum("1")] 
		Enc = 1,

		[System.ComponentModel.Description("ATopographicChartOfTheBedOfABodyOfWaterOrAPartOfItGenerallyBathymetricChartsShowDepthsByContourLinesAndGradientTints")]
		[EnumMember(Value = "Bathymetric Chart")] 
		[XmlEnum("2")] 
		BathymetricChart = 2,

		[System.ComponentModel.Description("WaterLevelInformationForSurfaceNavigation")]
		[EnumMember(Value = "Water Level Product")] 
		[XmlEnum("3")] 
		WaterLevelProduct = 3,

		[System.ComponentModel.Description("AProductRepresentingTheWaterVelocityAtOneOrMoreGeographicLocationsDownToAGivenDepth")]
		[EnumMember(Value = "Surface Current Product")] 
		[XmlEnum("4")] 
		SurfaceCurrentProduct = 4,

		[System.ComponentModel.Description("AnOutageOfAMaritimeSafetyInformationBroadcastServiceSatelliteOrTerrestrialSystem")]
		[EnumMember(Value = "MSI Service")] 
		[XmlEnum("5")] 
		MsiService = 5,

		[System.ComponentModel.Description("AServiceProvidingInformationRelatedToMarineAidsToNavigation")]
		[EnumMember(Value = "AtoN Information")] 
		[XmlEnum("6")] 
		AtonInformation = 6,

		[System.ComponentModel.Description("AServiceProvidingStructuredRecordsOfItems")]
		[EnumMember(Value = "Catalogue Service")] 
		[XmlEnum("7")] 
		CatalogueService = 7,

		[System.ComponentModel.Description("ServicesAssociatedWithShipsRouteing")]
		[EnumMember(Value = "Routeing Service")] 
		[XmlEnum("8")] 
		RouteingService = 8,

		[System.ComponentModel.Description("NewlyDiscoveredIcebergsChangesToIceConditionsAndIceRelatedInformationLikelyToImpactNavigation")]
		[EnumMember(Value = "Ice Information")] 
		[XmlEnum("9")] 
		IceInformation = 9,

		[System.ComponentModel.Description("InformationAssociatedWithShipsRouteing")]
		[EnumMember(Value = "Routeing Information")] 
		[XmlEnum("10")] 
		RouteingInformation = 10,

		[System.ComponentModel.Description("AnyChartDesignedPrimarilyToMeetSpecificRequirements")]
		[EnumMember(Value = "Special Purpose Chart")] 
		[XmlEnum("11")] 
		SpecialPurposeChart = 11,

		[System.ComponentModel.Description("ANauticalChartOrNauticalPublicationIsAASpecialPurposeMapOrBookOrASpeciallyCompiledDatabaseFromWhichSuchAMapOrBookIsDerivedThatIsIssuedOfficiallyByOrOnTheAuthorityOfAGovernmentAuthorizedHydrographicOfficeOrOtherRelevantGovernmentInstitutionAndIsDesignedToMeetTheRequirementsOfMarineNavigation")]
		[EnumMember(Value = "Nautical Publication")] 
		[XmlEnum("12")] 
		NauticalPublication = 12,

		[System.ComponentModel.Description("APrintedNauticalChartIsAASpecialPurposeMapThatIsIssuedOfficiallyByOrOnTheAuthorityOfAGovernmentAuthorizedHydrographicOfficeOrOtherRelevantGovernmentInstitutionAndIsDesignedToMeetTheRequirementsOfMarineNavigation")]
		[EnumMember(Value = "Printed Nautical Chart")] 
		[XmlEnum("13")] 
		PrintedNauticalChart = 13,
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

		[System.ComponentModel.Description("StateAgencyInChargeOfMarineSurveysAndHydrography")]
		[EnumMember(Value = "Hydrographic Office")] 
		[XmlEnum("17")] 
		HydrographicOffice = 17,

		[System.ComponentModel.Description("RegionalEncCoordinationCentre")]
		[EnumMember(Value = "RENC")] 
		[XmlEnum("18")] 
		Renc = 18,

		[System.ComponentModel.Description("ValueAddedResellersVarsWhoAreAbleToOfferComprehensiveEndUseServicesThatBringTogetherVariousNavigationalProductsIntoOnePackage")]
		[EnumMember(Value = "VARs")] 
		[XmlEnum("19")] 
		Vars = 19,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum digitalSignatureValue : int {
		[System.ComponentModel.Description("MetaDataRecordIdentifierForQualityofbathymetricCoverage")]
		[EnumMember(Value = "ID")] 
		[XmlEnum("1")] 
		Id = 1,

		[System.ComponentModel.Description("SpecifiesTheAlgorithmUsedToComputeDigitalSignatureValue")]
		[EnumMember(Value = "Digital Signature Reference")] 
		[XmlEnum("2")] 
		DigitalSignatureReference = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum nameUsage : int {
		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToTheDefaultNameTextDisplaySetting")]
		[EnumMember(Value = "Default Name Display")] 
		[XmlEnum("1")] 
		DefaultNameDisplay = 1,

		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToAnAlternateNameTextDisplaySettingForExampleAnAlternateLanguage")]
		[EnumMember(Value = "Alternate Name Display")] 
		[XmlEnum("2")] 
		AlternateNameDisplay = 2,

		[System.ComponentModel.Description("TheNameOrTextIsNotIntendedToBeDisplayed")]
		[EnumMember(Value = "No Chart Display")] 
		[XmlEnum("3")] 
		NoChartDisplay = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum distributionStatus : int {
		[System.ComponentModel.Description("AProductOrServiceThatIsCurrentlyInProduction")]
		[EnumMember(Value = "Production")] 
		[XmlEnum("1")] 
		Production = 1,

		[System.ComponentModel.Description("AProductOrServiceThatHasBeenWithdrawn")]
		[EnumMember(Value = "Withdrawn")] 
		[XmlEnum("2")] 
		Withdrawn = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iMOMaritimeService : int {
		[System.ComponentModel.Description("AnyServiceImplementedByARelevantAuthorityPrimarilyDesignedToImproveSafetyAndEfficiencyOfTrafficFlowAndTheProtectionOfTheEnvironmentItMayRangeFromSimpleInformationMessagesToExtensiveOrganizationOfTheTrafficInvolvingNationalOrRegionalSchemes")]
		[EnumMember(Value = "Vessel Traffic Service")] 
		[XmlEnum("1")] 
		VesselTrafficService = 1,

		[System.ComponentModel.Description("AServiceProvidingUpToDateInformationOfAidsToNavigation")]
		[EnumMember(Value = "Aids to Navigation Service")] 
		[XmlEnum("2")] 
		AidsToNavigationService = 2,

		[System.ComponentModel.Description("AnOptionThatIsReservedForFutureUse")]
		[EnumMember(Value = "Reserved for Future Use")] 
		[XmlEnum("3")] 
		ReservedForFutureUse = 3,

		[System.ComponentModel.Description("AServiceThatProvidesInformationNecessaryToOrganizeAndSupportPortCallsAndVariesDependingOnTheLocalNeeds")]
		[EnumMember(Value = "Port Support Service")] 
		[XmlEnum("4")] 
		PortSupportService = 4,

		[System.ComponentModel.Description("AServiceProvidingNavigationalAndMeteorologicalWarningsMeteorologicalForecastsAndOtherUrgentSafetyRelatedMessagesBroadcastToShips")]
		[EnumMember(Value = "Maritime Safety Information Service")] 
		[XmlEnum("5")] 
		MaritimeSafetyInformationService = 5,

		[System.ComponentModel.Description("TheServicesOfAPersonWhoDirectsTheMovementsOfAVesselThroughPilotWatersUsuallyAPersonWhoHasDemonstratedExtensiveKnowledgeOfChannelsAidsToNavigationDangersToNavigationEtcInAParticularAreaAndIsLicensedForThatAreaAreAvailable")]
		[EnumMember(Value = "Pilotage Service")] 
		[XmlEnum("6")] 
		PilotageService = 6,

		[System.ComponentModel.Description("AServiceThatContributesToTheSafetyOfNavigationProtectionOfTheMarineEnvironmentAndEfficiencyOfMarineTransportationByConductingDifferentTypesOfOperationsIncludingTugboatsSuchAsShipAssistanceSalvalgeTowageEscortEtc")]
		[EnumMember(Value = "Tug Service")] 
		[XmlEnum("7")] 
		TugService = 7,

		[System.ComponentModel.Description("AServiceProvidingInformationRelatedToVesselShoreReportingAndShipReportingSystems")]
		[EnumMember(Value = "Vessel Shore Reporting")] 
		[XmlEnum("8")] 
		VesselShoreReporting = 8,

		[System.ComponentModel.Description("AServiceToProvideDecisionSupportAndAdviceToTheSeafarerOnBoardResponsibleForMedicalCare")]
		[EnumMember(Value = "Telemedical Assistance Service")] 
		[XmlEnum("9")] 
		TelemedicalAssistanceService = 9,

		[System.ComponentModel.Description("AServiceToManageCommunicationsBetweenTheCoastalStateShipsOfficersRequiringAssistanceAndOtherResponsibleMaritimeOrganizationsFleetOwnersSalvageCompaniesPortAuthoritiesBrokersEtc")]
		[EnumMember(Value = "Maritime Assistance Service")] 
		[XmlEnum("10")] 
		MaritimeAssistanceService = 10,

		[System.ComponentModel.Description("AServiceThatProvidesGeospatialInformationInDigitalAndOrPrintedFormatToSupportSafeMaritimeNavigationWithTheAimToFulfillSolasRegulationV19214RequirementsForShipsToCarryNauticalChartsAndNauticalPublicationsToPlanAndDisplayTheShipSRouteForTheIntendedVoyageAndToPlotAndMonitorPositionsThroughoutTheVoyage")]
		[EnumMember(Value = "Nautical Chart Service")] 
		[XmlEnum("11")] 
		NauticalChartService = 11,

		[System.ComponentModel.Description("AServiceToProvideInformationAsASupportToTheNavigationProcessThisComprisesInformationToComplementNauticalChartsSuchAsInformationOnPortsAndSeaAreasAsWellAsTheContactInformationOfAuthoritiesAndServicesForASeaAreaOrPortItFurtherDescribesRegulationsRestrictionsRecommendationsAndOtherNauticalInformationApplicableInTheseAreasAndAimToFulfillSolasRegulationV19214RequirementsForShipsToCarryNauticalChartsAndNauticalPublicationsToPlanAndDisplayTheShipSRouteForTheIntendedVoyageAndToPlotAndMonitorPositionsThroughoutTheVoyage")]
		[EnumMember(Value = "Nautical Publications Service")] 
		[XmlEnum("12")] 
		NauticalPublicationsService = 12,

		[System.ComponentModel.Description("AServiceToProvideIceNavigationInformationToShipsInAndInTheVicinityOfPossibleIceInfestedRegions")]
		[EnumMember(Value = "Ice Navigation Service")] 
		[XmlEnum("13")] 
		IceNavigationService = 13,

		[System.ComponentModel.Description("AServiceToProvideMeteorologicalInformationDigitallyToShips")]
		[EnumMember(Value = "Meteorological Information Service")] 
		[XmlEnum("14")] 
		MeteorologicalInformationService = 14,

		[System.ComponentModel.Description("AServiceProvidingHydrographicAndEnvironmentalObservationsAndForecastsSuchAsWaterLevelAndSurfaceCurrentInformation")]
		[EnumMember(Value = "Real-Time Hydrographic and Environmental Information Service")] 
		[XmlEnum("15")] 
		RealTimeHydrographicAndEnvironmentalInformationService = 15,

		[System.ComponentModel.Description("AServiceAimedAtProvidingInformationAboutAndAssistWithSearchAndRescueFunctions")]
		[EnumMember(Value = "Search and Rescue Service")] 
		[XmlEnum("16")] 
		SearchAndRescueService = 16,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iSO216 : int {
		[System.ComponentModel.Description("ThePaperSizeA0AsDefinedInIso216")]
		[EnumMember(Value = "A0")] 
		[XmlEnum("1")] 
		A0 = 1,

		[System.ComponentModel.Description("TheFirstSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A1")] 
		[XmlEnum("2")] 
		A1 = 2,

		[System.ComponentModel.Description("ThePaperSizeA2AsDefinedInIso216")]
		[EnumMember(Value = "A2")] 
		[XmlEnum("3")] 
		A2 = 3,

		[System.ComponentModel.Description("TheFourthSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A3")] 
		[XmlEnum("4")] 
		A3 = 4,

		[System.ComponentModel.Description("TheFifthSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A4")] 
		[XmlEnum("5")] 
		A4 = 5,

		[System.ComponentModel.Description("TheSixthSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A5")] 
		[XmlEnum("6")] 
		A5 = 6,

		[System.ComponentModel.Description("TheSeventhSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A6")] 
		[XmlEnum("7")] 
		A6 = 7,

		[System.ComponentModel.Description("TheEighthSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A7")] 
		[XmlEnum("8")] 
		A7 = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfProductMapping : int {
		[System.ComponentModel.Description("AHigherPrioritizedOrRecommendedAlternativeProductOrServiceThatCanFullyReplaceAnother")]
		[EnumMember(Value = "Higher Priority Alternative")] 
		[XmlEnum("1")] 
		HigherPriorityAlternative = 1,

		[System.ComponentModel.Description("ALowerPrioritizedOrNotRecommendedAlternativeProductOrServiceThatCanFullyReplaceAnother")]
		[EnumMember(Value = "Lower Priority Alternative")] 
		[XmlEnum("2")] 
		LowerPriorityAlternative = 2,

		[System.ComponentModel.Description("ARecommendedAdditionalProductOrServiceThatProvidesAddedValueToAnother")]
		[EnumMember(Value = "Recommended Enhancement Provider")] 
		[XmlEnum("3")] 
		RecommendedEnhancementProvider = 3,

		[System.ComponentModel.Description("AProductOrServiceThatIsRecommendedToMakeUseOfAddedValueProvidedByAnotherProductOrService")]
		[EnumMember(Value = "Recommended Enhancement User")] 
		[XmlEnum("4")] 
		RecommendedEnhancementUser = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum digitalSignatureReference : int {
		[System.ComponentModel.Description("EllipticCurveDigitalSignatureAlgorithmEcdsaThatUsesSignaturesBasedOnTheIssuingCertificateAndGeneratedUsingTheIssuerSP384EllipticCurveKey")]
		[EnumMember(Value = "ECDSA-384-SHA2")] 
		[XmlEnum("8")] 
		Ecdsa384Sha2 = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum navigationPurpose : int {
		[System.ComponentModel.Description("PersonOrCorporationOwnersOfOrEntrustedWithOrInvestedWithThePowerOfManagingAPortMayBeCalledAHarbourBoardPortTrustPortCommissionHarbourCommissionMarineDepartment")]
		[EnumMember(Value = "Port")] 
		[XmlEnum("1")] 
		Port = 1,

		[System.ComponentModel.Description("oneInAstronomyTheApparentPassageOfAStarOrOtherCelestialBodyAcrossADefinedLineOfTheCelestialSphereAsAMeridianPrimeVerticalOrAlmucantarWhenNoLineIsSpecifiedATransitAcrossTheMeridianIsUsuallyIntendedSeeMeridianTransit2TheApparentPassageOfAStarOrOtherCelestialBodyAcrossALineInTheReticleOfATelescopeOrSomeLineOfSight3TheApparentPassageOfASmallerCelestialBodyAcrossTheDiskOfALargerCelestialBody4ASurveyingInstrumentComposedOfAHorizontalCircleGraduatedInCircularMeasureAndAnAlidadeWithATelescopeWhichCanBeReversedInItsSupportsWithoutBeingLiftedTherefromAlsoTheActOfMakingSuchAReversal5ATheodoliteHavingATelescopeThatCanBeTransitedInItsSupportsIsATransitAndIsSometimesTermedATransitTheodoliteAllModernTheodolitesAreTransits6AnAstronomicalInstrumentHavingATelescopeWhichCanBeSoAdjustedInPositionThatTheLineOfSightMayBeMadeToDefineAVerticalCircleATransitUsedInAstronomicalWorkIsUsuallyTermedEitherAnAstronomicAlTransitOrATransitInstrument7InNavigationThePositionOfTwoDistantFixedObjectsWhenTheyAreInLineToAnObserverTheLinePassingThroughThemAndTheObserverBeingALineOfPositionSeeAlsoRange")]
		[EnumMember(Value = "Transit")] 
		[XmlEnum("2")] 
		Transit = 2,

		[System.ComponentModel.Description("ForOceanCrossingAndPlanningPurposes")]
		[EnumMember(Value = "Overview")] 
		[XmlEnum("3")] 
		Overview = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supportFileFormat : int {
		[System.ComponentModel.Description("Utf8TextExcludingControlCodes")]
		[EnumMember(Value = "ASCII")] 
		[XmlEnum("1")] 
		Ascii = 1,

		[System.ComponentModel.Description("Jpeg2000Format")]
		[EnumMember(Value = "JPEG2000")] 
		[XmlEnum("2")] 
		Jpeg2000 = 2,

		[System.ComponentModel.Description("HypertextMarkupLanguage")]
		[EnumMember(Value = "HTML")] 
		[XmlEnum("3")] 
		Html = 3,

		[System.ComponentModel.Description("ExtensibleMarkupLanguage")]
		[EnumMember(Value = "XML")] 
		[XmlEnum("4")] 
		Xml = 4,

		[System.ComponentModel.Description("ExtensibleStylesheetLanguageTransformations")]
		[EnumMember(Value = "XSLT")] 
		[XmlEnum("5")] 
		Xslt = 5,

		[System.ComponentModel.Description("ADigitalRecordingOfAnImageOrSetOfImagesSuchAsAMovieOrAnimation")]
		[EnumMember(Value = "Video")] 
		[XmlEnum("6")] 
		Video = 6,

		[System.ComponentModel.Description("TaggedImageFileFormatTiff")]
		[EnumMember(Value = "TIFF")] 
		[XmlEnum("7")] 
		Tiff = 7,

		[System.ComponentModel.Description("PortableDocumentFormat")]
		[EnumMember(Value = "PDF/A Or U/A")] 
		[XmlEnum("8")] 
		PdfAOrUA = 8,

		[System.ComponentModel.Description("LuaProgrammingLanguage")]
		[EnumMember(Value = "LUA")] 
		[XmlEnum("9")] 
		Lua = 9,

		[System.ComponentModel.Description("BeingTheOneOrOnesDistinctFromThatOrThoseFirstMentionedOrImplied")]
		[EnumMember(Value = "Other")] 
		[XmlEnum("100")] 
		Other = 100,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supportFilePurpose : int {
		[System.ComponentModel.Description("AFileWhichIsNew")]
		[EnumMember(Value = "New")] 
		[XmlEnum("1")] 
		New = 1,

		[System.ComponentModel.Description("AFileWhichReplacesAnExistingFile")]
		[EnumMember(Value = "Replacement")] 
		[XmlEnum("2")] 
		Replacement = 2,

		[System.ComponentModel.Description("DeletesAnExistingFile")]
		[EnumMember(Value = "Deletion")] 
		[XmlEnum("3")] 
		Deletion = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum serviceStatus : int {
		[System.ComponentModel.Description("IndicatesATemporaryPreliminaryOrInterimStatusAProvisionalItemIsNotYetFinalizedOrFullyApproved")]
		[EnumMember(Value = "Provisional")] 
		[XmlEnum("1")] 
		Provisional = 1,

		[System.ComponentModel.Description("IndicatesAFinalizedOfficiallyApprovedOrPubliclyAvailableStatusAReleasedItemIsReadyForGeneralUseOrDistribution")]
		[EnumMember(Value = "Released")] 
		[XmlEnum("2")] 
		Released = 2,

		[System.ComponentModel.Description("IndicatesThatAFeatureMethodProductOrComponentIsNoLongerRecommendedForUseButIsStillAvailable")]
		[EnumMember(Value = "Deprecated")] 
		[XmlEnum("3")] 
		Deprecated = 3,

		[System.ComponentModel.Description("IndicatesThatAFeatureMethodProductOrComponentIsNoLongerAvailableOrHasBeenPermanentlyRemoved")]
		[EnumMember(Value = "Deleted")] 
		[XmlEnum("4")] 
		Deleted = 4,
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

		[System.ComponentModel.Description("ANationalOrRegionalAuthorityChargedWithAdministrationOfMaritimeAffairs")]
		[EnumMember(Value = "Maritime")] 
		[XmlEnum("15")] 
		Maritime = 15,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum specificUsage : int {
		[System.ComponentModel.Description("ForUseInTheStudyOfTheCharacteristicsOfMaritimeZonesInTheFormulationOfPlansInTheSelectionOfRoutesEtcShowingOnlyRelevantElementsOfTheCoastlineHarboursIslandsPrincipalNavigationalMarksAndObstructionsAndSubmarineLandforms")]
		[EnumMember(Value = "Navigational Purpose Overview")] 
		[XmlEnum("1")] 
		NavigationalPurposeOverview = 1,

		[System.ComponentModel.Description("ANauticalChartWithUniversalityIEGeneralityInUseCharacterizedByTheRequirementThatTheChartMustComprehensivelyDescribeVariousNaturalElementsAndSocioeconomicElementsAndThatEachElementOfTheSubjectMatterExpressedIsUniversal")]
		[EnumMember(Value = "Navigational Purpose General")] 
		[XmlEnum("2")] 
		NavigationalPurposeGeneral = 2,

		[System.ComponentModel.Description("UsedForMarineNavigationMainlyDisplayingSubmarineLandformsNavigationalMarksNavigationalObstaclesAndOtherElementsRelatedToNavigation")]
		[EnumMember(Value = "Navigational Purpose Coastal")] 
		[XmlEnum("3")] 
		NavigationalPurposeCoastal = 3,

		[System.ComponentModel.Description("UsedForNearShoreNavigationMainlyShowingTheMarineElementsCloseToCoastalAreas")]
		[EnumMember(Value = "Navigational Purpose Approach")] 
		[XmlEnum("4")] 
		NavigationalPurposeApproach = 4,

		[System.ComponentModel.Description("UsedForEnteringAndLeavingHarboursSelectingAnchorageStudyingHarbourTopographyAndCarryingOutTheConstructionOfHarbours")]
		[EnumMember(Value = "Navigational Purpose Harbour")] 
		[XmlEnum("5")] 
		NavigationalPurposeHarbour = 5,

		[System.ComponentModel.Description("ForShipsBerthing")]
		[EnumMember(Value = "Navigational Purpose Berthing")] 
		[XmlEnum("6")] 
		NavigationalPurposeBerthing = 6,
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
	public enum typeOfProductFormat : int {
		[System.ComponentModel.Description("GeographyMarkupLanguageAnXmlBasedGeographicInformationEncodingLanguageDevelopedByTheOpenGisConsortiumOgcToEnhanceTheInteroperabilityOfGeographicInformation")]
		[EnumMember(Value = "GML")] 
		[XmlEnum("1")] 
		Gml = 1,

		[System.ComponentModel.Description("SpecificationForADataDescriptiveFileForInformationInterchange")]
		[EnumMember(Value = "ISO/IEC 8211")] 
		[XmlEnum("2")] 
		IsoIec8211 = 2,

		[System.ComponentModel.Description("PortableDocumentFormatAFileFormatDevelopedByAdobeIn1993ToPresentDocumentsIncludingTextFormattingAndImagesInAMannerIndependentOfApplicationSoftwareHardwareAndOperatingSystems")]
		[EnumMember(Value = "PDF")] 
		[XmlEnum("3")] 
		Pdf = 3,

		[System.ComponentModel.Description("HypertextMarkupLanguage")]
		[EnumMember(Value = "HTML")] 
		[XmlEnum("4")] 
		Html = 4,

		[System.ComponentModel.Description("EBookFileFormat")]
		[EnumMember(Value = "ePub")] 
		[XmlEnum("5")] 
		Epub = 5,

		[System.ComponentModel.Description("ForPrintingHydrographicChartsHeavyweightSingleLayerPaperIsUsedSuchPaperIsGenerallyMadeWhollyOrPartlyFromRagsAndSimulatesHandMadePaperItIsStrongMoistureResistantAndManufacturedToWithstandSurfaceErasure")]
		[EnumMember(Value = "Paper")] 
		[XmlEnum("6")] 
		Paper = 6,

		[System.ComponentModel.Description("HierarchicalDataFormatVersion5IsAFileFormatAndDataModelDesignedForStoringAndOrganizingLargeAmountsOfNumericalDataEfficiently")]
		[EnumMember(Value = "HDF-5")] 
		[XmlEnum("7")] 
		Hdf5 = 7,

		[System.ComponentModel.Description("AFileFormatUsedPrimarilyForStoringNauticalChartsInRasterForm")]
		[EnumMember(Value = "BSB")] 
		[XmlEnum("8")] 
		Bsb = 8,

		[System.ComponentModel.Description("ExtensionOfTheTiffSpecificationToAllowTheStorageOfGeoReferencingInformation")]
		[EnumMember(Value = "GeoTiff")] 
		[XmlEnum("9")] 
		Geotiff = 9,

		[System.ComponentModel.Description("ProvisionOfDataInAFormatIncludingOperationalFunctionalitySuchAsASoftwareProgramDesignedToPerformSpecificTasksOrFunctionsForTheUser")]
		[EnumMember(Value = "Application")] 
		[XmlEnum("10")] 
		Application = 10,

		[System.ComponentModel.Description("ExtensibleMarkupLanguage")]
		[EnumMember(Value = "XML")] 
		[XmlEnum("11")] 
		Xml = 11,

		[System.ComponentModel.Description("PortableNetworkGraphicsFormat")]
		[EnumMember(Value = "PNG")] 
		[XmlEnum("12")] 
		Png = 12,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfTimeIntervalUnit : int {
		[System.ComponentModel.Description("AUnitOfTimeEqualTo60MinutesOr3600Seconds")]
		[EnumMember(Value = "Hour")] 
		[XmlEnum("1")] 
		Hour = 1,

		[System.ComponentModel.Description("oneTheDurationOfOneRotationOfTheEarthOrOccasionallyAnotherCelestialBodyOnItsAxisItIsMeasuredBySuccessiveTransitsOfAReferencePointOnTheCelestialSphereOverTheMeridianAndEachTypeTakesItsNameFromTheReferenceUsed2ThePeriodOfDaylightAsDistinguishedFromNight")]
		[EnumMember(Value = "Day")] 
		[XmlEnum("2")] 
		Day = 2,

		[System.ComponentModel.Description("AMeasureOfTimeBasedOnTheMotionOfTheMoonInItsOrbit")]
		[EnumMember(Value = "Month")] 
		[XmlEnum("3")] 
		Month = 3,

		[System.ComponentModel.Description("APeriodOfOneRevolutionOfTheEarthAroundTheSun")]
		[EnumMember(Value = "Year")] 
		[XmlEnum("4")] 
		Year = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("TheAverageHeightOfTheLowWatersOfSpringTidesThisLevelIsUsedAsATidalDatumInSomeAreas")]
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

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestTideObservedAtAPlaceOrSomewhatLower")]
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

		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
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

		[System.ComponentModel.Description("TheAverageHeightOfTheHighWatersOfSpringTides")]
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

		[System.ComponentModel.Description("AVerticalReferenceSystemWithItsZeroBasedOnTheMeanWaterLevelAtRimouskiPointeAuPReQuebecOverThePeriod1970To1988")]
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

		[System.ComponentModel.Description("LowWaterReferenceLevelOfTheLocalArea")]
		[EnumMember(Value = "Local Low Water Reference Level")] 
		[XmlEnum("31")] 
		LocalLowWaterReferenceLevel = 31,

		[System.ComponentModel.Description("HighWaterReferenceLevelOfTheLocalArea")]
		[EnumMember(Value = "Local High Water Reference Level")] 
		[XmlEnum("32")] 
		LocalHighWaterReferenceLevel = 32,

		[System.ComponentModel.Description("MeanWaterReferenceLevelOfTheLocalArea")]
		[EnumMember(Value = "Local Mean Water Reference Level")] 
		[XmlEnum("33")] 
		LocalMeanWaterReferenceLevel = 33,

		[System.ComponentModel.Description("ALowWaterLevelWhichIsTheResultOfADefinedLowWaterDischargeCalledEquivalentDischarge")]
		[EnumMember(Value = "Equivalent Height of Water (German GlW)")] 
		[XmlEnum("34")] 
		EquivalentHeightOfWaterGermanGlw = 34,

		[System.ComponentModel.Description("UpperLimitOfWaterLevelsWhereNavigationIsAllowed")]
		[EnumMember(Value = "Highest Shipping Height of Water (German HSW)")] 
		[XmlEnum("35")] 
		HighestShippingHeightOfWaterGermanHsw = 35,

		[System.ComponentModel.Description("TheWaterLevelAtADischargeWhichIsExceeded94OfTheYearWithinAPeriodOf30Years")]
		[EnumMember(Value = "Reference Low Water Level According to Danube Commission")] 
		[XmlEnum("36")] 
		ReferenceLowWaterLevelAccordingToDanubeCommission = 36,

		[System.ComponentModel.Description("TheWaterLevelAtADischargeWhichIsExceeded1OfTheYearWithinAPeriodOf30Years")]
		[EnumMember(Value = "Highest Shipping Height of Water According to Danube Commission")] 
		[XmlEnum("37")] 
		HighestShippingHeightOfWaterAccordingToDanubeCommission = 37,

		[System.ComponentModel.Description("TheWaterLevelAtADischargeWhichIsExceeded95OfTheYearWithinAPeriodOf20Years")]
		[EnumMember(Value = "Dutch River Low Water Reference Level (OLR)")] 
		[XmlEnum("38")] 
		DutchRiverLowWaterReferenceLevelOlr = 38,

		[System.ComponentModel.Description("ConditionalLowWaterLevelWithEstablishedProbability")]
		[EnumMember(Value = "Russian Project Water Level")] 
		[XmlEnum("39")] 
		RussianProjectWaterLevel = 39,

		[System.ComponentModel.Description("HighestWaterLevelDerivedFromTheUpperBackwaterStreamInWatercourseOrReservoirUnderTheNormalOperationalConditions")]
		[EnumMember(Value = "Russian Normal Backwater Level")] 
		[XmlEnum("40")] 
		RussianNormalBackwaterLevel = 40,

		[System.ComponentModel.Description("TheOhioRiverDatum")]
		[EnumMember(Value = "Ohio River Datum")] 
		[XmlEnum("41")] 
		OhioRiverDatum = 41,

		[System.ComponentModel.Description("DutchHighWaterReferenceLevel")]
		[EnumMember(Value = "Dutch High Water Reference Level")] 
		[XmlEnum("43")] 
		DutchHighWaterReferenceLevel = 43,

		[System.ComponentModel.Description("TheDatumRefersToEachBalticCountrySRealizationOfTheEuropeanVerticalReferenceSystemEvrsWithLandUpliftEpoch2000WhichIsConnectedToTheNormaalAmsterdamsPeilNap")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		[XmlEnum("44")] 
		BalticSeaChartDatum2000 = 44,

		[System.ComponentModel.Description("DutchEstuaryLowWaterReferenceLevelOlw")]
		[EnumMember(Value = "Dutch Estuary Low Water Reference Level (OLW)")] 
		[XmlEnum("45")] 
		DutchEstuaryLowWaterReferenceLevelOlw = 45,

		[System.ComponentModel.Description("The2020UpdateToTheInternationalGreatLakesDatumTheOfficialReferenceSystemUsedToMeasureWaterLevelHeightsInTheGreatLakesConnectingChannelsAndTheStLawrenceRiverSystem")]
		[EnumMember(Value = "International Great Lakes Datum 2020")] 
		[XmlEnum("46")] 
		InternationalGreatLakesDatum2020 = 46,

		[System.ComponentModel.Description("TheBottomOfTheOceanAndSeasWhereThereIsAGenerallySmoothGentleGradientAlsoReferredToAsSeaBedSometimesSeabedOrSeaBedAndSeaBottom")]
		[EnumMember(Value = "Sea Floor")] 
		[XmlEnum("47")] 
		SeaFloor = 47,

		[System.ComponentModel.Description("ATwoDimensionalInTheHorizontalPlaneFieldRepresentingTheAirSeaInterfaceWithHighFrequencyFluctuationsSuchAsWindWavesAndSwellButNotAstronomicalTidesFilteredOut")]
		[EnumMember(Value = "Sea Surface")] 
		[XmlEnum("48")] 
		SeaSurface = 48,

		[System.ComponentModel.Description("AVerticalReferenceNearTheLowestAstronomicalTideLatBelowWhichTheSeaLevelFallsOnlyVeryExceptionally")]
		[EnumMember(Value = "Hydrographic Zero")] 
		[XmlEnum("49")] 
		HydrographicZero = 49,
	}

	[System.Serializable()]
	public class horizontalDatumEPSGCode
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	public static class CodeList
	{
		public static ImmutableArray<horizontalDatumEPSGCode> horizontalDatumEPSGCodes => ImmutableArray.Create<horizontalDatumEPSGCode>(new horizontalDatumEPSGCode[]{
			new() {
				code = 3395,
				definition = "A global Mercator projection commonly used for mapping applications requiring accurate distance measurements near the equator.",
				label = "EPSG3395 (World Mercator)",
			},
			new() {
				code = 3857,
				definition = "A popular web mapping projection used by Google Maps, OpenStreetMap, and Bing Maps. Distorts at the poles but is widely used in online maps.",
				label = "EPSG3857 (Pseudo-Mercator)",
			},
			new() {
				code = 4326,
				definition = "World Geodetic System 1984, used globally for GPS and geographic coordinates. Specifies coordinates in latitude and longitude degrees.",
				label = "EPSG4326 (WGS84)",
			},
		});
	}

	namespace ComplexAttributes {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress {
			[XmlElement("administrativeDivision")]
			public String? administrativeDivision {get;set;} = default;

			public bool ShouldSerializeadministrativeDivision() { return !string.IsNullOrEmpty(administrativeDivision); }

			[XmlElement("cityName")]
			public String? cityName {get;set;} = default;

			public bool ShouldSerializecityName() { return !string.IsNullOrEmpty(cityName); }

			[XmlElement("countryName")]
			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlElement("deliveryPoint")]
			public List<String> deliveryPoint {get;set;} = [];

			public bool ShouldSerializedeliveryPoint() { return deliveryPoint.Any(); }

			[XmlElement("postalCode")]
			public String? postalCode {get;set;} = default;

			public bool ShouldSerializepostalCode() { return !string.IsNullOrEmpty(postalCode); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class customPaperSize {
			[XmlElement("paperWidth")]
			public required decimal paperWidth {get;set;} = default;

			[XmlElement("paperLength")]
			public required decimal paperLength {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class defaultLocale {
			[XmlElement("characterEncoding")]
			public required String characterEncoding {get;set;} = string.Empty;

			[XmlElement("countryName")]
			public required String countryName {get;set;} = string.Empty;

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("name")]
			public required String name {get;set;} = string.Empty;

			[XmlElement("nameUsage")]
			public nameUsage? nameUsage {get;set;} = default;

			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }
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
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("text")]
			public List<String> text {get;set;} = [];

			public bool ShouldSerializetext() { return text.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("applicationProfile")]
			public String? applicationProfile {get;set;} = default;

			public bool ShouldSerializeapplicationProfile() { return !string.IsNullOrEmpty(applicationProfile); }

			[XmlElement("linkage")]
			public required String linkage {get;set;} = string.Empty;

			[XmlElement("nameOfResource")]
			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }

			[XmlElement("onlineDescription")]
			public String? onlineDescription {get;set;} = default;

			public bool ShouldSerializeonlineDescription() { return !string.IsNullOrEmpty(onlineDescription); }

			[XmlElement("protocol")]
			public String? protocol {get;set;} = default;

			public bool ShouldSerializeprotocol() { return !string.IsNullOrEmpty(protocol); }

			[XmlElement("protocolRequest")]
			public String? protocolRequest {get;set;} = default;

			public bool ShouldSerializeprotocolRequest() { return !string.IsNullOrEmpty(protocolRequest); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[XmlElement("dateEnd")]
			public required String dateEnd {get;set;} = string.Empty;

			[XmlElement("dateStart")]
			public required String dateStart {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class pricing {
			[XmlElement("contractPeriod")]
			public String? contractPeriod {get;set;} = default;

			public bool ShouldSerializecontractPeriod() { return !string.IsNullOrEmpty(contractPeriod); }

			[XmlElement("currency")]
			public required String currency {get;set;} = string.Empty;

			[XmlElement("price")]
			public required decimal price {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class printSize {
			[XmlElement("iSO216")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public iSO216? iSO216 {get;set;} = default;

			public bool ShouldSerializeiSO216() { return iSO216.HasValue; }

			[XmlElement("customPaperSize")]
			public customPaperSize? customPaperSize {get;set;} = default;

			public bool ShouldSerializecustomPaperSize() { return customPaperSize!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class productSpecification {
			[XmlElement("editionDate")]
			[XmlIgnore]
			public required DateOnly editionDate {get;set;} = default;

			[XmlElement("iSSN")]
			public String? iSSN {get;set;} = default;

			public bool ShouldSerializeiSSN() { return !string.IsNullOrEmpty(iSSN); }

			[XmlElement("name")]
			public required String name {get;set;} = string.Empty;

			[XmlElement("version")]
			public required String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class supportFileSpecification {
			[XmlElement("editionDate")]
			[XmlIgnore]
			public required DateOnly editionDate {get;set;} = default;

			[XmlElement("name")]
			public required String name {get;set;} = string.Empty;

			[XmlElement("version")]
			public required String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class serviceSpecification {
			[XmlElement("editionDate")]
			[XmlIgnore]
			public required DateOnly editionDate {get;set;} = default;

			[XmlElement("name")]
			public required String name {get;set;} = string.Empty;

			[XmlElement("version")]
			public required String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIndication {
			[XmlElement("categoryOfAuthority")]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("countryName")]
			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlElement("reportedDate")]
			[XmlIgnore]
			public DateOnly? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return reportedDate.HasValue; }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlElement("sourceType")]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14,15])]
			public sourceType? sourceType {get;set;} = default;

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			[XmlElement("contactInstructions")]
			public required String contactInstructions {get;set;} = string.Empty;

			[XmlElement("telecommunicationIdentifier")]
			public required String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlElement("telecommunicationService")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalOfCycle {
			[XmlElement("typeOfTimeIntervalUnit")]
			[EnumerationValue([1,2,3,4])]
			public List<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit {get;set;} = [];

			public bool ShouldSerializetypeOfTimeIntervalUnit() { return typeOfTimeIntervalUnit.Any(); }

			[XmlElement("valueOfTime")]
			public required int valueOfTime {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class weekOfYear {
			[XmlElement("weekNumber")]
			public required int weekNumber {get;set;} = default;

			[XmlElement("yearNumber")]
			public required int yearNumber {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class issuanceCycle {
			[XmlElement("periodicDateRange")]
			public periodicDateRange? periodicDateRange {get;set;} = default;

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange!=default; }

			[XmlElement("timeIntervalOfCycle")]
			public timeIntervalOfCycle? timeIntervalOfCycle {get;set;} = default;

			public bool ShouldSerializetimeIntervalOfCycle() { return timeIntervalOfCycle!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class printInformation {
			[XmlElement("printAgency")]
			public String? printAgency {get;set;} = default;

			public bool ShouldSerializeprintAgency() { return !string.IsNullOrEmpty(printAgency); }

			[XmlElement("printNation")]
			public String? printNation {get;set;} = default;

			public bool ShouldSerializeprintNation() { return !string.IsNullOrEmpty(printNation); }

			[XmlElement("reprintEdition")]
			public String? reprintEdition {get;set;} = default;

			public bool ShouldSerializereprintEdition() { return !string.IsNullOrEmpty(reprintEdition); }

			[XmlElement("reprintNation")]
			public String? reprintNation {get;set;} = default;

			public bool ShouldSerializereprintNation() { return !string.IsNullOrEmpty(reprintNation); }

			[XmlElement("printSize")]
			public required printSize printSize {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class supportFile {
			[XmlElement("comment")]
			public String? comment {get;set;} = default;

			public bool ShouldSerializecomment() { return !string.IsNullOrEmpty(comment); }

			[XmlElement("digitalSignatureReference")]
			[EnumerationValue([8])]
			public required digitalSignatureReference digitalSignatureReference {get;set;} = default;

			[XmlElement("digitalSignatureValue")]
			[EnumerationValue([1,2])]
			public digitalSignatureValue? digitalSignatureValue {get;set;} = default;

			public bool ShouldSerializedigitalSignatureValue() { return digitalSignatureValue.HasValue; }

			[XmlElement("editionNumber")]
			public int? editionNumber {get;set;} = default;

			public bool ShouldSerializeeditionNumber() { return editionNumber.HasValue; }

			[XmlElement("fileLocator")]
			public required String fileLocator {get;set;} = string.Empty;

			[XmlElement("fileName")]
			public required String fileName {get;set;} = string.Empty;

			[XmlElement("issueDate")]
			[XmlIgnore]
			public DateOnly? issueDate {get;set;} = default;

			public bool ShouldSerializeissueDate() { return issueDate.HasValue; }

			[XmlElement("otherDataTypeDescription")]
			public String? otherDataTypeDescription {get;set;} = default;

			public bool ShouldSerializeotherDataTypeDescription() { return !string.IsNullOrEmpty(otherDataTypeDescription); }

			[XmlElement("supportFileFormat")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,100])]
			public required supportFileFormat supportFileFormat {get;set;} = default;

			[XmlElement("supportFilePurpose")]
			[EnumerationValue([1,2,3])]
			public required supportFilePurpose supportFilePurpose {get;set;} = default;

			[XmlElement("defaultLocale")]
			public required defaultLocale defaultLocale {get;set;} = default;

			[XmlElement("supportFileSpecification")]
			public required supportFileSpecification supportFileSpecification {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalOfProduct {
			[XmlElement("expirationDate")]
			[XmlIgnore]
			public DateOnly? expirationDate {get;set;} = default;

			public bool ShouldSerializeexpirationDate() { return expirationDate.HasValue; }

			[XmlElement("issueDate")]
			[XmlIgnore]
			public required DateOnly issueDate {get;set;} = default;

			[XmlElement("issuanceCycle")]
			public issuanceCycle? issuanceCycle {get;set;} = default;

			public bool ShouldSerializeissuanceCycle() { return issuanceCycle!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class referenceToNM {
			[XmlElement("publicationDate")]
			[XmlIgnore]
			public required DateOnly publicationDate {get;set;} = default;

			[XmlElement("weekOfYear")]
			public weekOfYear? weekOfYear {get;set;} = default;

			public bool ShouldSerializeweekOfYear() { return weekOfYear!=default; }
		}

	}
	public enum Role {
		[System.ComponentModel.Description("The top section of a catalogue.")]
		catalogueHeader,
		[System.ComponentModel.Description("A container of elements.")]
		elementContainer,
		[System.ComponentModel.Description("Reference to an element within a catalogue.")]
		theCatalogueElement,
		[System.ComponentModel.Description("Reference to a Catalogue of Nautical product.")]
		theCatalogueOfNauticalProduct,
		[System.ComponentModel.Description("Reference to Contact details.")]
		theContactDetails,
		[System.ComponentModel.Description("Reference to the distributor.")]
		theDistributor,
		[System.ComponentModel.Description("Reference to an element.")]
		theElement,
		[System.ComponentModel.Description("Reference to price information.")]
		thePriceInformation,
		[System.ComponentModel.Description("Reference to a producer.")]
		theProducer,
		[System.ComponentModel.Description("Reference to  supporting material or information related to a specific element or data.")]
		theReference,
		[System.ComponentModel.Description("Reference to a requirement for a specific system or process.")]
		theRequirement,
		[System.ComponentModel.Description("Reference to the source of information or data.")]
		theSource,
		[System.ComponentModel.Description("Reference to the main product containg panel(s).")]
		theMain,
		[System.ComponentModel.Description("Reference to the panel of a main product.")]
		thePanel,
	}

	namespace InformationAssociations {
		/// <summary>
		/// A carriage requirement required by SOLAS or other regulation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CarriageRequirement : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(CarriageRequirement);
		}

		/// <summary>
		/// Details related to distribution.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributionDetails : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(DistributionDetails);
		}

		/// <summary>
		/// Contact information of distributor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributorContact : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(DistributorContact);
		}

		/// <summary>
		/// An association of price information to a catalogue element.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceOfElement : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(PriceOfElement);
		}

		/// <summary>
		/// The price of a nautical product.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceOfNauticalProduct : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(PriceOfNauticalProduct);
		}

		/// <summary>
		/// Contact information of producer.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProducerContact : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ProducerContact);
		}

		/// <summary>
		/// Contact information of a producing organization.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductionDetails : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ProductionDetails);
		}

		/// <summary>
		/// A package or distinct set of products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductPackage : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ProductPackage);
		}
	}

	namespace FeatureAssociations {
		/// <summary>
		/// Mapping between traditional products and S-100 Products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductMapping : FeatureAssociation {
			[XmlElement("categoryOfProductMapping")]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfProductMapping categoryOfProductMapping {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(ProductMapping);
		}

		/// <summary>
		/// A supplementary or secondary part of the product, which may appear multiple times, offering control or display functionalities depending on its configuration.
			
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Correlated : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(Correlated);
		}
	}

}

namespace S100Framework.DomainModel.S128 {
	using ComplexAttributes;
	using InformationAssociations;

	namespace InformationTypes {
		/// <summary>
		/// A header identifying a section within a catalogue.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CatalogueSectionHeader : InformationNode, IInformationBindingDefinition {
			[XmlElement("catalogueSectionNumber")]
			public required int catalogueSectionNumber {get;set;} = default;

			[XmlElement("catalogueSectionTitle")]
			public String? catalogueSectionTitle {get;set;} = default;

			public bool ShouldSerializecatalogueSectionTitle() { return !string.IsNullOrEmpty(catalogueSectionTitle); }

			[XmlElement("information")]
			public information? information {get;set;} = default;

			public bool ShouldSerializeinformation() { return information!=default; }

			[JsonIgnore]
			public override string Code => nameof(CatalogueSectionHeader);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CatalogueSectionHeader._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PriceOfNauticalProduct),
					role = Enum.GetName<Role>(Role.thePriceInformation)!,
					informationTypes = [nameof(PriceInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ProductionDetails),
					role = Enum.GetName<Role>(Role.theProducer)!,
					informationTypes = [nameof(ProducerInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DistributionDetails),
					role = Enum.GetName<Role>(Role.theDistributor)!,
					informationTypes = [nameof(DistributorInformation)],
					primitives = [],
				},
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
		public partial class ContactDetails : InformationNode, IInformationBindingDefinition {
			[XmlElement("contactInstructions")]
			public required String contactInstructions {get;set;} = string.Empty;

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[XmlElement("sourceIndication")]
			public List<sourceIndication> sourceIndication {get;set;} = [];

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }

			[JsonIgnore]
			public override string Code => nameof(ContactDetails);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ContactDetails._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ProducerContact),
					role = Enum.GetName<Role>(Role.theProducer)!,
					informationTypes = [nameof(ProducerInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(DistributorContact),
					role = Enum.GetName<Role>(Role.theDistributor)!,
					informationTypes = [nameof(DistributorInformation)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// An indication of the type or justification of a carriage requirement.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IndicationOfCarriageRequirement : InformationNode, IInformationBindingDefinition {
			[XmlElement("domesticCarriageRequirements")]
			public String? domesticCarriageRequirements {get;set;} = default;

			public bool ShouldSerializedomesticCarriageRequirements() { return !string.IsNullOrEmpty(domesticCarriageRequirements); }

			[XmlElement("internationalCarriageRequirements")]
			public String? internationalCarriageRequirements {get;set;} = default;

			public bool ShouldSerializeinternationalCarriageRequirements() { return !string.IsNullOrEmpty(internationalCarriageRequirements); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[JsonIgnore]
			public override string Code => nameof(IndicationOfCarriageRequirement);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => IndicationOfCarriageRequirement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Pricing information of nautical products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("pricing")]
			public List<pricing> pricing {get;set;} = [];

			public bool ShouldSerializepricing() { return pricing.Any(); }

			[XmlElement("sourceIndication")]
			public List<sourceIndication> sourceIndication {get;set;} = [];

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }

			[JsonIgnore]
			public override string Code => nameof(PriceInformation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => PriceInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PriceOfNauticalProduct),
					role = Enum.GetName<Role>(Role.theCatalogueOfNauticalProduct)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Information about the authority responsible for production.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProducerInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("agencyResponsibleForProduction")]
			public required String agencyResponsibleForProduction {get;set;} = string.Empty;

			[XmlElement("agencyName")]
			public String? agencyName {get;set;} = default;

			public bool ShouldSerializeagencyName() { return !string.IsNullOrEmpty(agencyName); }

			[JsonIgnore]
			public override string Code => nameof(ProducerInformation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => ProducerInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProducerContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProductionDetails),
					role = Enum.GetName<Role>(Role.catalogueHeader)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Information related to a distributor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributorInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("distributorName")]
			public required String distributorName {get;set;} = string.Empty;

			[JsonIgnore]
			public override string Code => nameof(DistributorInformation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DistributorInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DistributionDetails),
					role = Enum.GetName<Role>(Role.catalogueHeader)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DistributorContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
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
		/// An element within a catalogue of elements.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class CatalogueElement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("agencyResponsibleForProduction")]
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			[XmlElement("catalogueElementClassification")]
			public List<catalogueElementClassification> catalogueElementClassification {get;set;} = [];

			public bool ShouldSerializecatalogueElementClassification() { return catalogueElementClassification.Any(); }

			[XmlElement("catalogueElementIdentifier")]
			public String? catalogueElementIdentifier {get;set;} = default;

			public bool ShouldSerializecatalogueElementIdentifier() { return !string.IsNullOrEmpty(catalogueElementIdentifier); }

			[XmlElement("classification")]
			public String? classification {get;set;} = default;

			public bool ShouldSerializeclassification() { return !string.IsNullOrEmpty(classification); }

			[XmlElement("iMOMaritimeService")]
			public List<iMOMaritimeService> iMOMaritimeService {get;set;} = [];

			public bool ShouldSerializeiMOMaritimeService() { return iMOMaritimeService.Any(); }

			[XmlElement("notForNavigation")]
			public required Boolean notForNavigation {get;set;} = false;

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("onlineResource")]
			public onlineResource? onlineResource {get;set;} = default;

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			[XmlElement("sourceIndication")]
			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }

			[XmlElement("supportFile")]
			public List<supportFile> supportFile {get;set;} = [];

			public bool ShouldSerializesupportFile() { return supportFile.Any(); }

			[XmlElement("timeIntervalOfProduct")]
			public timeIntervalOfProduct? timeIntervalOfProduct {get;set;} = default;

			public bool ShouldSerializetimeIntervalOfProduct() { return timeIntervalOfProduct!=default; }

			[JsonIgnore]
			public override string Code => nameof(CatalogueElement);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => CatalogueElement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(CarriageRequirement),
					role = Enum.GetName<Role>(Role.theRequirement)!,
					informationTypes = [nameof(IndicationOfCarriageRequirement)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PriceOfElement),
					role = Enum.GetName<Role>(Role.thePriceInformation)!,
					informationTypes = [nameof(PriceInformation)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(ProductPackage),
					role = Enum.GetName<Role>(Role.elementContainer)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => CatalogueElement._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => CatalogueElement._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProductMapping),
					role = Enum.GetName<Role>(Role.theReference)!,
					featureTypes = [nameof(CatalogueElement)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A physical or electronic product, that is primarily intended for navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class NavigationalProduct : CatalogueElement {
			[XmlElement("approximateGridResolution")]
			public List<decimal> approximateGridResolution {get;set;} = [];

			public bool ShouldSerializeapproximateGridResolution() { return approximateGridResolution.Any(); }

			[XmlElement("compilationScale")]
			public List<int> compilationScale {get;set;} = [];

			public bool ShouldSerializecompilationScale() { return compilationScale.Any(); }

			[XmlElement("distributionStatus")]
			[EnumerationValue([1,2])]
			public distributionStatus? distributionStatus {get;set;} = default;

			public bool ShouldSerializedistributionStatus() { return distributionStatus.HasValue; }

			[XmlElement("editionNumber")]
			public int? editionNumber {get;set;} = default;

			public bool ShouldSerializeeditionNumber() { return editionNumber.HasValue; }

			[XmlElement("maximumDisplayScale")]
			public int? maximumDisplayScale {get;set;} = default;

			public bool ShouldSerializemaximumDisplayScale() { return maximumDisplayScale.HasValue; }

			[XmlElement("minimumDisplayScale")]
			public int? minimumDisplayScale {get;set;} = default;

			public bool ShouldSerializeminimumDisplayScale() { return minimumDisplayScale.HasValue; }

			[XmlElement("navigationPurpose")]
			[EnumerationValue([1,2,3])]
			public List<navigationPurpose> navigationPurpose {get;set;} = [];

			public bool ShouldSerializenavigationPurpose() { return navigationPurpose.Any(); }

			[XmlElement("optimumDisplayScale")]
			public String? optimumDisplayScale {get;set;} = default;

			public bool ShouldSerializeoptimumDisplayScale() { return !string.IsNullOrEmpty(optimumDisplayScale); }

			[XmlElement("originalProductNumber")]
			public String? originalProductNumber {get;set;} = default;

			public bool ShouldSerializeoriginalProductNumber() { return !string.IsNullOrEmpty(originalProductNumber); }

			[XmlElement("producerNation")]
			public String? producerNation {get;set;} = default;

			public bool ShouldSerializeproducerNation() { return !string.IsNullOrEmpty(producerNation); }

			[XmlElement("productNumber")]
			public String? productNumber {get;set;} = default;

			public bool ShouldSerializeproductNumber() { return !string.IsNullOrEmpty(productNumber); }

			[XmlElement("specificUsage")]
			[EnumerationValue([1,2,3,4,5,6])]
			public specificUsage? specificUsage {get;set;} = default;

			public bool ShouldSerializespecificUsage() { return specificUsage.HasValue; }

			[XmlElement("updateDate")]
			[XmlIgnore]
			public DateOnly? updateDate {get;set;} = default;

			public bool ShouldSerializeupdateDate() { return updateDate.HasValue; }

			[XmlElement("updateNumber")]
			public int? updateNumber {get;set;} = default;

			public bool ShouldSerializeupdateNumber() { return updateNumber.HasValue; }

			[XmlElement("horizontalDatumEPSGCode")]
			public horizontalDatumEPSGCode? horizontalDatumEPSGCode {get;set;} = default;

			public bool ShouldSerializehorizontalDatumEPSGCode() { return horizontalDatumEPSGCode != default; }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(NavigationalProduct);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..CatalogueElement._informationBindingDefinitions, ..NavigationalProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..CatalogueElement._featureBindingDefinitions, ..NavigationalProduct._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..CatalogueElement._primitives, ..NavigationalProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(Correlated),
					role = Enum.GetName<Role>(Role.theMain)!,
					featureTypes = [nameof(NavigationalProduct)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(Correlated),
					role = Enum.GetName<Role>(Role.thePanel)!,
					featureTypes = [nameof(NavigationalProduct)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Electronic navigation product.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ElectronicProduct : NavigationalProduct {
			[XmlElement("compressionFlag")]
			public Boolean? compressionFlag {get;set;} = default;

			public bool ShouldSerializecompressionFlag() { return compressionFlag.HasValue; }

			[XmlElement("datasetName")]
			public String? datasetName {get;set;} = default;

			public bool ShouldSerializedatasetName() { return !string.IsNullOrEmpty(datasetName); }

			[XmlElement("issueDate")]
			[XmlIgnore]
			public required DateOnly issueDate {get;set;} = default;

			[XmlElement("issueTime")]
			public S100Framework.DomainModel.S100.Time? issueTime {get;set;} = default;

			public bool ShouldSerializeissueTime() { return issueTime.HasValue; }

			[XmlElement("typeOfProductFormat")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			public required typeOfProductFormat typeOfProductFormat {get;set;} = default;

			[XmlElement("productSpecification")]
			public productSpecification? productSpecification {get;set;} = default;

			public bool ShouldSerializeproductSpecification() { return productSpecification!=default; }

			[JsonIgnore]
			public override string Code => nameof(ElectronicProduct);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..NavigationalProduct._informationBindingDefinitions, ..ElectronicProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..NavigationalProduct._featureBindingDefinitions, ..ElectronicProduct._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..NavigationalProduct._primitives, ..ElectronicProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
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
		/// A product printed on paper.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalProduct : NavigationalProduct {
			[XmlElement("editionDate")]
			[XmlIgnore]
			public required DateOnly editionDate {get;set;} = default;

			[XmlElement("iSBN")]
			public String? iSBN {get;set;} = default;

			public bool ShouldSerializeiSBN() { return !string.IsNullOrEmpty(iSBN); }

			[XmlElement("publicationNumber")]
			public String? publicationNumber {get;set;} = default;

			public bool ShouldSerializepublicationNumber() { return !string.IsNullOrEmpty(publicationNumber); }

			[XmlElement("typeOfPhysicalProduct")]
			public String? typeOfPhysicalProduct {get;set;} = default;

			public bool ShouldSerializetypeOfPhysicalProduct() { return !string.IsNullOrEmpty(typeOfPhysicalProduct); }

			[XmlElement("printInformation")]
			public printInformation? printInformation {get;set;} = default;

			public bool ShouldSerializeprintInformation() { return printInformation!=default; }

			[XmlElement("referenceToNM")]
			public referenceToNM? referenceToNM {get;set;} = default;

			public bool ShouldSerializereferenceToNM() { return referenceToNM!=default; }

			[JsonIgnore]
			public override string Code => nameof(PhysicalProduct);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..NavigationalProduct._informationBindingDefinitions, ..PhysicalProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..NavigationalProduct._featureBindingDefinitions, ..PhysicalProduct._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..NavigationalProduct._primitives, ..PhysicalProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
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
		/// A service that makes use of S-100 based product specifications to support data transfer.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class S100Service : CatalogueElement {
			[XmlElement("compressionFlag")]
			public Boolean? compressionFlag {get;set;} = default;

			public bool ShouldSerializecompressionFlag() { return compressionFlag.HasValue; }

			[XmlElement("serviceName")]
			public String? serviceName {get;set;} = default;

			public bool ShouldSerializeserviceName() { return !string.IsNullOrEmpty(serviceName); }

			[XmlElement("serviceStatus")]
			[EnumerationValue([1,2,3,4])]
			public serviceStatus? serviceStatus {get;set;} = default;

			public bool ShouldSerializeserviceStatus() { return serviceStatus.HasValue; }

			[XmlElement("typeOfProductFormat")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			public required typeOfProductFormat typeOfProductFormat {get;set;} = default;

			[XmlElement("serviceSpecification")]
			public serviceSpecification? serviceSpecification {get;set;} = default;

			public bool ShouldSerializeserviceSpecification() { return serviceSpecification!=default; }

			[XmlElement("productSpecification")]
			public productSpecification? productSpecification {get;set;} = default;

			public bool ShouldSerializeproductSpecification() { return productSpecification!=default; }

			[JsonIgnore]
			public override string Code => nameof(S100Service);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..CatalogueElement._informationBindingDefinitions, ..S100Service._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..CatalogueElement._featureBindingDefinitions, ..S100Service._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..CatalogueElement._primitives, ..S100Service._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
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
	}

	[XmlType(Namespace = "http://www.iho.int/S128/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S128/2.0 128_2.0.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S128/2.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.CatalogueSectionHeader", typeof(InformationTypes.CatalogueSectionHeader), Order = 1, ElementName = "CatalogueSectionHeader")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.IndicationOfCarriageRequirement", typeof(InformationTypes.IndicationOfCarriageRequirement), Order = 1, ElementName = "IndicationOfCarriageRequirement")]
		[XmlElement("InformationTypes.PriceInformation", typeof(InformationTypes.PriceInformation), Order = 1, ElementName = "PriceInformation")]
		[XmlElement("InformationTypes.ProducerInformation", typeof(InformationTypes.ProducerInformation), Order = 1, ElementName = "ProducerInformation")]
		[XmlElement("InformationTypes.DistributorInformation", typeof(InformationTypes.DistributorInformation), Order = 1, ElementName = "DistributorInformation")]
		[XmlElement("FeatureTypes.ElectronicProduct", typeof(FeatureTypes.ElectronicProduct), Order = 1, ElementName = "ElectronicProduct")]
		[XmlElement("FeatureTypes.PhysicalProduct", typeof(FeatureTypes.PhysicalProduct), Order = 1, ElementName = "PhysicalProduct")]
		[XmlElement("FeatureTypes.S100Service", typeof(FeatureTypes.S100Service), Order = 1, ElementName = "S100Service")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
