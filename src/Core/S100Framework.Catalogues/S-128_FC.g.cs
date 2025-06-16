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
		Enc = 1,

		[System.ComponentModel.Description("ATopographicChartOfTheBedOfABodyOfWaterOrAPartOfItGenerallyBathymetricChartsShowDepthsByContourLinesAndGradientTints")]
		[EnumMember(Value = "Bathymetric Chart")] 
		BathymetricChart = 2,

		[System.ComponentModel.Description("WaterLevelInformationForSurfaceNavigation")]
		[EnumMember(Value = "Water Level Product")] 
		WaterLevelProduct = 3,

		[System.ComponentModel.Description("AProductRepresentingTheWaterVelocityAtOneOrMoreGeographicLocationsDownToAGivenDepth")]
		[EnumMember(Value = "Surface Current Product")] 
		SurfaceCurrentProduct = 4,

		[System.ComponentModel.Description("AnOutageOfAMaritimeSafetyInformationBroadcastServiceSatelliteOrTerrestrialSystem")]
		[EnumMember(Value = "MSI Service")] 
		MsiService = 5,

		[System.ComponentModel.Description("AServiceProvidingInformationRelatedToMarineAidsToNavigation")]
		[EnumMember(Value = "AtoN Information")] 
		AtonInformation = 6,

		[System.ComponentModel.Description("AServiceProvidingStructuredRecordsOfItems")]
		[EnumMember(Value = "Catalogue Service")] 
		CatalogueService = 7,

		[System.ComponentModel.Description("ServicesAssociatedWithShipsRouteing")]
		[EnumMember(Value = "Routeing Service")] 
		RouteingService = 8,

		[System.ComponentModel.Description("NewlyDiscoveredIcebergsChangesToIceConditionsAndIceRelatedInformationLikelyToImpactNavigation")]
		[EnumMember(Value = "Ice Information")] 
		IceInformation = 9,

		[System.ComponentModel.Description("InformationAssociatedWithShipsRouteing")]
		[EnumMember(Value = "Routeing Information")] 
		RouteingInformation = 10,

		[System.ComponentModel.Description("AnyChartDesignedPrimarilyToMeetSpecificRequirements")]
		[EnumMember(Value = "Special Purpose Chart")] 
		SpecialPurposeChart = 11,

		[System.ComponentModel.Description("ANauticalChartOrNauticalPublicationIsAASpecialPurposeMapOrBookOrASpeciallyCompiledDatabaseFromWhichSuchAMapOrBookIsDerivedThatIsIssuedOfficiallyByOrOnTheAuthorityOfAGovernmentAuthorizedHydrographicOfficeOrOtherRelevantGovernmentInstitutionAndIsDesignedToMeetTheRequirementsOfMarineNavigation")]
		[EnumMember(Value = "Nautical Publication")] 
		NauticalPublication = 12,

		[System.ComponentModel.Description("APrintedNauticalChartIsAASpecialPurposeMapThatIsIssuedOfficiallyByOrOnTheAuthorityOfAGovernmentAuthorizedHydrographicOfficeOrOtherRelevantGovernmentInstitutionAndIsDesignedToMeetTheRequirementsOfMarineNavigation")]
		[EnumMember(Value = "Printed Nautical Chart")] 
		PrintedNauticalChart = 13,
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

		[System.ComponentModel.Description("StateAgencyInChargeOfMarineSurveysAndHydrography")]
		[EnumMember(Value = "Hydrographic Office")] 
		HydrographicOffice = 17,

		[System.ComponentModel.Description("RegionalEncCoordinationCentre")]
		[EnumMember(Value = "RENC")] 
		Renc = 18,

		[System.ComponentModel.Description("ValueAddedResellersVarsWhoAreAbleToOfferComprehensiveEndUseServicesThatBringTogetherVariousNavigationalProductsIntoOnePackage")]
		[EnumMember(Value = "VARs")] 
		Vars = 19,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum digitalSignatureValue : int {
		[System.ComponentModel.Description("MetaDataRecordIdentifierForQualityofbathymetricCoverage")]
		[EnumMember(Value = "ID")] 
		Id = 1,

		[System.ComponentModel.Description("SpecifiesTheAlgorithmUsedToComputeDigitalSignatureValue")]
		[EnumMember(Value = "Digital Signature Reference")] 
		DigitalSignatureReference = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum nameUsage : int {
		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToTheDefaultNameTextDisplaySetting")]
		[EnumMember(Value = "Default Name Display")] 
		DefaultNameDisplay = 1,

		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToAnAlternateNameTextDisplaySettingForExampleAnAlternateLanguage")]
		[EnumMember(Value = "Alternate Name Display")] 
		AlternateNameDisplay = 2,

		[System.ComponentModel.Description("TheNameOrTextIsNotIntendedToBeDisplayed")]
		[EnumMember(Value = "No Chart Display")] 
		NoChartDisplay = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum distributionStatus : int {
		[System.ComponentModel.Description("AProductOrServiceThatIsCurrentlyInProduction")]
		[EnumMember(Value = "Production")] 
		Production = 1,

		[System.ComponentModel.Description("AProductOrServiceThatHasBeenWithdrawn")]
		[EnumMember(Value = "Withdrawn")] 
		Withdrawn = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iMOMaritimeService : int {
		[System.ComponentModel.Description("AnyServiceImplementedByARelevantAuthorityPrimarilyDesignedToImproveSafetyAndEfficiencyOfTrafficFlowAndTheProtectionOfTheEnvironmentItMayRangeFromSimpleInformationMessagesToExtensiveOrganizationOfTheTrafficInvolvingNationalOrRegionalSchemes")]
		[EnumMember(Value = "Vessel Traffic Service")] 
		VesselTrafficService = 1,

		[System.ComponentModel.Description("AServiceProvidingUpToDateInformationOfAidsToNavigation")]
		[EnumMember(Value = "Aids to Navigation Service")] 
		AidsToNavigationService = 2,

		[System.ComponentModel.Description("AnOptionThatIsReservedForFutureUse")]
		[EnumMember(Value = "Reserved for Future Use")] 
		ReservedForFutureUse = 3,

		[System.ComponentModel.Description("AServiceThatProvidesInformationNecessaryToOrganizeAndSupportPortCallsAndVariesDependingOnTheLocalNeeds")]
		[EnumMember(Value = "Port Support Service")] 
		PortSupportService = 4,

		[System.ComponentModel.Description("AServiceProvidingNavigationalAndMeteorologicalWarningsMeteorologicalForecastsAndOtherUrgentSafetyRelatedMessagesBroadcastToShips")]
		[EnumMember(Value = "Maritime Safety Information Service")] 
		MaritimeSafetyInformationService = 5,

		[System.ComponentModel.Description("TheServicesOfAPersonWhoDirectsTheMovementsOfAVesselThroughPilotWatersUsuallyAPersonWhoHasDemonstratedExtensiveKnowledgeOfChannelsAidsToNavigationDangersToNavigationEtcInAParticularAreaAndIsLicensedForThatAreaAreAvailable")]
		[EnumMember(Value = "Pilotage Service")] 
		PilotageService = 6,

		[System.ComponentModel.Description("AServiceThatContributesToTheSafetyOfNavigationProtectionOfTheMarineEnvironmentAndEfficiencyOfMarineTransportationByConductingDifferentTypesOfOperationsIncludingTugboatsSuchAsShipAssistanceSalvalgeTowageEscortEtc")]
		[EnumMember(Value = "Tug Service")] 
		TugService = 7,

		[System.ComponentModel.Description("AServiceProvidingInformationRelatedToVesselShoreReportingAndShipReportingSystems")]
		[EnumMember(Value = "Vessel Shore Reporting")] 
		VesselShoreReporting = 8,

		[System.ComponentModel.Description("AServiceToProvideDecisionSupportAndAdviceToTheSeafarerOnBoardResponsibleForMedicalCare")]
		[EnumMember(Value = "Telemedical Assistance Service")] 
		TelemedicalAssistanceService = 9,

		[System.ComponentModel.Description("AServiceToManageCommunicationsBetweenTheCoastalStateShipsOfficersRequiringAssistanceAndOtherResponsibleMaritimeOrganizationsFleetOwnersSalvageCompaniesPortAuthoritiesBrokersEtc")]
		[EnumMember(Value = "Maritime Assistance Service")] 
		MaritimeAssistanceService = 10,

		[System.ComponentModel.Description("AServiceThatProvidesGeospatialInformationInDigitalAndOrPrintedFormatToSupportSafeMaritimeNavigationWithTheAimToFulfillSolasRegulationV19214RequirementsForShipsToCarryNauticalChartsAndNauticalPublicationsToPlanAndDisplayTheShipSRouteForTheIntendedVoyageAndToPlotAndMonitorPositionsThroughoutTheVoyage")]
		[EnumMember(Value = "Nautical Chart Service")] 
		NauticalChartService = 11,

		[System.ComponentModel.Description("AServiceToProvideInformationAsASupportToTheNavigationProcessThisComprisesInformationToComplementNauticalChartsSuchAsInformationOnPortsAndSeaAreasAsWellAsTheContactInformationOfAuthoritiesAndServicesForASeaAreaOrPortItFurtherDescribesRegulationsRestrictionsRecommendationsAndOtherNauticalInformationApplicableInTheseAreasAndAimToFulfillSolasRegulationV19214RequirementsForShipsToCarryNauticalChartsAndNauticalPublicationsToPlanAndDisplayTheShipSRouteForTheIntendedVoyageAndToPlotAndMonitorPositionsThroughoutTheVoyage")]
		[EnumMember(Value = "Nautical Publications Service")] 
		NauticalPublicationsService = 12,

		[System.ComponentModel.Description("AServiceToProvideIceNavigationInformationToShipsInAndInTheVicinityOfPossibleIceInfestedRegions")]
		[EnumMember(Value = "Ice Navigation Service")] 
		IceNavigationService = 13,

		[System.ComponentModel.Description("AServiceToProvideMeteorologicalInformationDigitallyToShips")]
		[EnumMember(Value = "Meteorological Information Service")] 
		MeteorologicalInformationService = 14,

		[System.ComponentModel.Description("AServiceProvidingHydrographicAndEnvironmentalObservationsAndForecastsSuchAsWaterLevelAndSurfaceCurrentInformation")]
		[EnumMember(Value = "Real-Time Hydrographic and Environmental Information Service")] 
		RealTimeHydrographicAndEnvironmentalInformationService = 15,

		[System.ComponentModel.Description("AServiceAimedAtProvidingInformationAboutAndAssistWithSearchAndRescueFunctions")]
		[EnumMember(Value = "Search and Rescue Service")] 
		SearchAndRescueService = 16,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iSO216 : int {
		[System.ComponentModel.Description("ThePaperSizeA0AsDefinedInIso216")]
		[EnumMember(Value = "A0")] 
		A0 = 1,

		[System.ComponentModel.Description("TheFirstSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A1")] 
		A1 = 2,

		[System.ComponentModel.Description("ThePaperSizeA2AsDefinedInIso216")]
		[EnumMember(Value = "A2")] 
		A2 = 3,

		[System.ComponentModel.Description("TheFourthSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A3")] 
		A3 = 4,

		[System.ComponentModel.Description("TheFifthSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A4")] 
		A4 = 5,

		[System.ComponentModel.Description("TheSixthSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A5")] 
		A5 = 6,

		[System.ComponentModel.Description("TheSeventhSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A6")] 
		A6 = 7,

		[System.ComponentModel.Description("TheEighthSizeAsOutputSizeOnNauticalPaperChartReferringToIso216")]
		[EnumMember(Value = "A7")] 
		A7 = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfProductMapping : int {
		[System.ComponentModel.Description("AHigherPrioritizedOrRecommendedAlternativeProductOrServiceThatCanFullyReplaceAnother")]
		[EnumMember(Value = "Higher Priority Alternative")] 
		HigherPriorityAlternative = 1,

		[System.ComponentModel.Description("ALowerPrioritizedOrNotRecommendedAlternativeProductOrServiceThatCanFullyReplaceAnother")]
		[EnumMember(Value = "Lower Priority Alternative")] 
		LowerPriorityAlternative = 2,

		[System.ComponentModel.Description("ARecommendedAdditionalProductOrServiceThatProvidesAddedValueToAnother")]
		[EnumMember(Value = "Recommended Enhancement Provider")] 
		RecommendedEnhancementProvider = 3,

		[System.ComponentModel.Description("AProductOrServiceThatIsRecommendedToMakeUseOfAddedValueProvidedByAnotherProductOrService")]
		[EnumMember(Value = "Recommended Enhancement User")] 
		RecommendedEnhancementUser = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum digitalSignatureReference : int {
		[System.ComponentModel.Description("EllipticCurveDigitalSignatureAlgorithmEcdsaThatUsesSignaturesBasedOnTheIssuingCertificateAndGeneratedUsingTheIssuerSP384EllipticCurveKey")]
		[EnumMember(Value = "ECDSA-384-SHA2")] 
		Ecdsa384Sha2 = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum navigationPurpose : int {
		[System.ComponentModel.Description("PersonOrCorporationOwnersOfOrEntrustedWithOrInvestedWithThePowerOfManagingAPortMayBeCalledAHarbourBoardPortTrustPortCommissionHarbourCommissionMarineDepartment")]
		[EnumMember(Value = "Port")] 
		Port = 1,

		[System.ComponentModel.Description("oneInAstronomyTheApparentPassageOfAStarOrOtherCelestialBodyAcrossADefinedLineOfTheCelestialSphereAsAMeridianPrimeVerticalOrAlmucantarWhenNoLineIsSpecifiedATransitAcrossTheMeridianIsUsuallyIntendedSeeMeridianTransit2TheApparentPassageOfAStarOrOtherCelestialBodyAcrossALineInTheReticleOfATelescopeOrSomeLineOfSight3TheApparentPassageOfASmallerCelestialBodyAcrossTheDiskOfALargerCelestialBody4ASurveyingInstrumentComposedOfAHorizontalCircleGraduatedInCircularMeasureAndAnAlidadeWithATelescopeWhichCanBeReversedInItsSupportsWithoutBeingLiftedTherefromAlsoTheActOfMakingSuchAReversal5ATheodoliteHavingATelescopeThatCanBeTransitedInItsSupportsIsATransitAndIsSometimesTermedATransitTheodoliteAllModernTheodolitesAreTransits6AnAstronomicalInstrumentHavingATelescopeWhichCanBeSoAdjustedInPositionThatTheLineOfSightMayBeMadeToDefineAVerticalCircleATransitUsedInAstronomicalWorkIsUsuallyTermedEitherAnAstronomicAlTransitOrATransitInstrument7InNavigationThePositionOfTwoDistantFixedObjectsWhenTheyAreInLineToAnObserverTheLinePassingThroughThemAndTheObserverBeingALineOfPositionSeeAlsoRange")]
		[EnumMember(Value = "Transit")] 
		Transit = 2,

		[System.ComponentModel.Description("ForOceanCrossingAndPlanningPurposes")]
		[EnumMember(Value = "Overview")] 
		Overview = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supportFileFormat : int {
		[System.ComponentModel.Description("Utf8TextExcludingControlCodes")]
		[EnumMember(Value = "ASCII")] 
		Ascii = 1,

		[System.ComponentModel.Description("Jpeg2000Format")]
		[EnumMember(Value = "JPEG2000")] 
		Jpeg2000 = 2,

		[System.ComponentModel.Description("HypertextMarkupLanguage")]
		[EnumMember(Value = "HTML")] 
		Html = 3,

		[System.ComponentModel.Description("ExtensibleMarkupLanguage")]
		[EnumMember(Value = "XML")] 
		Xml = 4,

		[System.ComponentModel.Description("ExtensibleStylesheetLanguageTransformations")]
		[EnumMember(Value = "XSLT")] 
		Xslt = 5,

		[System.ComponentModel.Description("ADigitalRecordingOfAnImageOrSetOfImagesSuchAsAMovieOrAnimation")]
		[EnumMember(Value = "Video")] 
		Video = 6,

		[System.ComponentModel.Description("TaggedImageFileFormatTiff")]
		[EnumMember(Value = "TIFF")] 
		Tiff = 7,

		[System.ComponentModel.Description("PortableDocumentFormat")]
		[EnumMember(Value = "PDF/A Or U/A")] 
		PdfAOrUA = 8,

		[System.ComponentModel.Description("LuaProgrammingLanguage")]
		[EnumMember(Value = "LUA")] 
		Lua = 9,

		[System.ComponentModel.Description("BeingTheOneOrOnesDistinctFromThatOrThoseFirstMentionedOrImplied")]
		[EnumMember(Value = "Other")] 
		Other = 100,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supportFilePurpose : int {
		[System.ComponentModel.Description("AFileWhichIsNew")]
		[EnumMember(Value = "New")] 
		New = 1,

		[System.ComponentModel.Description("AFileWhichReplacesAnExistingFile")]
		[EnumMember(Value = "Replacement")] 
		Replacement = 2,

		[System.ComponentModel.Description("DeletesAnExistingFile")]
		[EnumMember(Value = "Deletion")] 
		Deletion = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum serviceStatus : int {
		[System.ComponentModel.Description("IndicatesATemporaryPreliminaryOrInterimStatusAProvisionalItemIsNotYetFinalizedOrFullyApproved")]
		[EnumMember(Value = "Provisional")] 
		Provisional = 1,

		[System.ComponentModel.Description("IndicatesAFinalizedOfficiallyApprovedOrPubliclyAvailableStatusAReleasedItemIsReadyForGeneralUseOrDistribution")]
		[EnumMember(Value = "Released")] 
		Released = 2,

		[System.ComponentModel.Description("IndicatesThatAFeatureMethodProductOrComponentIsNoLongerRecommendedForUseButIsStillAvailable")]
		[EnumMember(Value = "Deprecated")] 
		Deprecated = 3,

		[System.ComponentModel.Description("IndicatesThatAFeatureMethodProductOrComponentIsNoLongerAvailableOrHasBeenPermanentlyRemoved")]
		[EnumMember(Value = "Deleted")] 
		Deleted = 4,
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

		[System.ComponentModel.Description("ANationalOrRegionalAuthorityChargedWithAdministrationOfMaritimeAffairs")]
		[EnumMember(Value = "Maritime")] 
		Maritime = 15,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum specificUsage : int {
		[System.ComponentModel.Description("ForUseInTheStudyOfTheCharacteristicsOfMaritimeZonesInTheFormulationOfPlansInTheSelectionOfRoutesEtcShowingOnlyRelevantElementsOfTheCoastlineHarboursIslandsPrincipalNavigationalMarksAndObstructionsAndSubmarineLandforms")]
		[EnumMember(Value = "Navigational Purpose Overview")] 
		NavigationalPurposeOverview = 1,

		[System.ComponentModel.Description("ANauticalChartWithUniversalityIEGeneralityInUseCharacterizedByTheRequirementThatTheChartMustComprehensivelyDescribeVariousNaturalElementsAndSocioeconomicElementsAndThatEachElementOfTheSubjectMatterExpressedIsUniversal")]
		[EnumMember(Value = "Navigational Purpose General")] 
		NavigationalPurposeGeneral = 2,

		[System.ComponentModel.Description("UsedForMarineNavigationMainlyDisplayingSubmarineLandformsNavigationalMarksNavigationalObstaclesAndOtherElementsRelatedToNavigation")]
		[EnumMember(Value = "Navigational Purpose Coastal")] 
		NavigationalPurposeCoastal = 3,

		[System.ComponentModel.Description("UsedForNearShoreNavigationMainlyShowingTheMarineElementsCloseToCoastalAreas")]
		[EnumMember(Value = "Navigational Purpose Approach")] 
		NavigationalPurposeApproach = 4,

		[System.ComponentModel.Description("UsedForEnteringAndLeavingHarboursSelectingAnchorageStudyingHarbourTopographyAndCarryingOutTheConstructionOfHarbours")]
		[EnumMember(Value = "Navigational Purpose Harbour")] 
		NavigationalPurposeHarbour = 5,

		[System.ComponentModel.Description("ForShipsBerthing")]
		[EnumMember(Value = "Navigational Purpose Berthing")] 
		NavigationalPurposeBerthing = 6,
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
	public enum typeOfProductFormat : int {
		[System.ComponentModel.Description("GeographyMarkupLanguageAnXmlBasedGeographicInformationEncodingLanguageDevelopedByTheOpenGisConsortiumOgcToEnhanceTheInteroperabilityOfGeographicInformation")]
		[EnumMember(Value = "GML")] 
		Gml = 1,

		[System.ComponentModel.Description("SpecificationForADataDescriptiveFileForInformationInterchange")]
		[EnumMember(Value = "ISO/IEC 8211")] 
		IsoIec8211 = 2,

		[System.ComponentModel.Description("PortableDocumentFormatAFileFormatDevelopedByAdobeIn1993ToPresentDocumentsIncludingTextFormattingAndImagesInAMannerIndependentOfApplicationSoftwareHardwareAndOperatingSystems")]
		[EnumMember(Value = "PDF")] 
		Pdf = 3,

		[System.ComponentModel.Description("HypertextMarkupLanguage")]
		[EnumMember(Value = "HTML")] 
		Html = 4,

		[System.ComponentModel.Description("EBookFileFormat")]
		[EnumMember(Value = "ePub")] 
		Epub = 5,

		[System.ComponentModel.Description("ForPrintingHydrographicChartsHeavyweightSingleLayerPaperIsUsedSuchPaperIsGenerallyMadeWhollyOrPartlyFromRagsAndSimulatesHandMadePaperItIsStrongMoistureResistantAndManufacturedToWithstandSurfaceErasure")]
		[EnumMember(Value = "Paper")] 
		Paper = 6,

		[System.ComponentModel.Description("HierarchicalDataFormatVersion5IsAFileFormatAndDataModelDesignedForStoringAndOrganizingLargeAmountsOfNumericalDataEfficiently")]
		[EnumMember(Value = "HDF-5")] 
		Hdf5 = 7,

		[System.ComponentModel.Description("AFileFormatUsedPrimarilyForStoringNauticalChartsInRasterForm")]
		[EnumMember(Value = "BSB")] 
		Bsb = 8,

		[System.ComponentModel.Description("ExtensionOfTheTiffSpecificationToAllowTheStorageOfGeoReferencingInformation")]
		[EnumMember(Value = "GeoTiff")] 
		Geotiff = 9,

		[System.ComponentModel.Description("ProvisionOfDataInAFormatIncludingOperationalFunctionalitySuchAsASoftwareProgramDesignedToPerformSpecificTasksOrFunctionsForTheUser")]
		[EnumMember(Value = "Application")] 
		Application = 10,

		[System.ComponentModel.Description("ExtensibleMarkupLanguage")]
		[EnumMember(Value = "XML")] 
		Xml = 11,

		[System.ComponentModel.Description("PortableNetworkGraphicsFormat")]
		[EnumMember(Value = "PNG")] 
		Png = 12,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfTimeIntervalUnit : int {
		[System.ComponentModel.Description("AUnitOfTimeEqualTo60MinutesOr3600Seconds")]
		[EnumMember(Value = "Hour")] 
		Hour = 1,

		[System.ComponentModel.Description("oneTheDurationOfOneRotationOfTheEarthOrOccasionallyAnotherCelestialBodyOnItsAxisItIsMeasuredBySuccessiveTransitsOfAReferencePointOnTheCelestialSphereOverTheMeridianAndEachTypeTakesItsNameFromTheReferenceUsed2ThePeriodOfDaylightAsDistinguishedFromNight")]
		[EnumMember(Value = "Day")] 
		Day = 2,

		[System.ComponentModel.Description("AMeasureOfTimeBasedOnTheMotionOfTheMoonInItsOrbit")]
		[EnumMember(Value = "Month")] 
		Month = 3,

		[System.ComponentModel.Description("APeriodOfOneRevolutionOfTheEarthAroundTheSun")]
		[EnumMember(Value = "Year")] 
		Year = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum verticalDatum : int {
		[System.ComponentModel.Description("TheAverageHeightOfTheLowWatersOfSpringTidesThisLevelIsUsedAsATidalDatumInSomeAreas")]
		[EnumMember(Value = "Mean Low Water Springs")] 
		MeanLowWaterSprings = 1,

		[System.ComponentModel.Description("TheAverageHeightOfLowerLowWaterSpringsAtAPlace")]
		[EnumMember(Value = "Mean Lower Low Water Springs")] 
		MeanLowerLowWaterSprings = 2,

		[System.ComponentModel.Description("TheAverageHeightOfTheSurfaceOfTheSeaAtATideStationForAllStagesOfTheTideOverA19YearPeriodUsuallyDeterminedFromHourlyHeightReadingsMeasuredFromAFixedPredeterminedReferenceLevel")]
		[EnumMember(Value = "Mean Sea Level")] 
		MeanSeaLevel = 3,

		[System.ComponentModel.Description("AnArbitraryLevelConformingToTheLowestTideObservedAtAPlaceOrSomewhatLower")]
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

		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
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

		[System.ComponentModel.Description("TheAverageHeightOfTheHighWatersOfSpringTides")]
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

		[System.ComponentModel.Description("AVerticalReferenceSystemWithItsZeroBasedOnTheMeanWaterLevelAtRimouskiPointeAuPReQuebecOverThePeriod1970To1988")]
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

		[System.ComponentModel.Description("LowWaterReferenceLevelOfTheLocalArea")]
		[EnumMember(Value = "Local Low Water Reference Level")] 
		LocalLowWaterReferenceLevel = 31,

		[System.ComponentModel.Description("HighWaterReferenceLevelOfTheLocalArea")]
		[EnumMember(Value = "Local High Water Reference Level")] 
		LocalHighWaterReferenceLevel = 32,

		[System.ComponentModel.Description("MeanWaterReferenceLevelOfTheLocalArea")]
		[EnumMember(Value = "Local Mean Water Reference Level")] 
		LocalMeanWaterReferenceLevel = 33,

		[System.ComponentModel.Description("ALowWaterLevelWhichIsTheResultOfADefinedLowWaterDischargeCalledEquivalentDischarge")]
		[EnumMember(Value = "Equivalent Height of Water (German GlW)")] 
		EquivalentHeightOfWaterGermanGlw = 34,

		[System.ComponentModel.Description("UpperLimitOfWaterLevelsWhereNavigationIsAllowed")]
		[EnumMember(Value = "Highest Shipping Height of Water (German HSW)")] 
		HighestShippingHeightOfWaterGermanHsw = 35,

		[System.ComponentModel.Description("TheWaterLevelAtADischargeWhichIsExceeded94OfTheYearWithinAPeriodOf30Years")]
		[EnumMember(Value = "Reference Low Water Level According to Danube Commission")] 
		ReferenceLowWaterLevelAccordingToDanubeCommission = 36,

		[System.ComponentModel.Description("TheWaterLevelAtADischargeWhichIsExceeded1OfTheYearWithinAPeriodOf30Years")]
		[EnumMember(Value = "Highest Shipping Height of Water According to Danube Commission")] 
		HighestShippingHeightOfWaterAccordingToDanubeCommission = 37,

		[System.ComponentModel.Description("TheWaterLevelAtADischargeWhichIsExceeded95OfTheYearWithinAPeriodOf20Years")]
		[EnumMember(Value = "Dutch River Low Water Reference Level (OLR)")] 
		DutchRiverLowWaterReferenceLevelOlr = 38,

		[System.ComponentModel.Description("ConditionalLowWaterLevelWithEstablishedProbability")]
		[EnumMember(Value = "Russian Project Water Level")] 
		RussianProjectWaterLevel = 39,

		[System.ComponentModel.Description("HighestWaterLevelDerivedFromTheUpperBackwaterStreamInWatercourseOrReservoirUnderTheNormalOperationalConditions")]
		[EnumMember(Value = "Russian Normal Backwater Level")] 
		RussianNormalBackwaterLevel = 40,

		[System.ComponentModel.Description("TheOhioRiverDatum")]
		[EnumMember(Value = "Ohio River Datum")] 
		OhioRiverDatum = 41,

		[System.ComponentModel.Description("DutchHighWaterReferenceLevel")]
		[EnumMember(Value = "Dutch High Water Reference Level")] 
		DutchHighWaterReferenceLevel = 43,

		[System.ComponentModel.Description("TheDatumRefersToEachBalticCountrySRealizationOfTheEuropeanVerticalReferenceSystemEvrsWithLandUpliftEpoch2000WhichIsConnectedToTheNormaalAmsterdamsPeilNap")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		BalticSeaChartDatum2000 = 44,

		[System.ComponentModel.Description("DutchEstuaryLowWaterReferenceLevelOlw")]
		[EnumMember(Value = "Dutch Estuary Low Water Reference Level (OLW)")] 
		DutchEstuaryLowWaterReferenceLevelOlw = 45,

		[System.ComponentModel.Description("The2020UpdateToTheInternationalGreatLakesDatumTheOfficialReferenceSystemUsedToMeasureWaterLevelHeightsInTheGreatLakesConnectingChannelsAndTheStLawrenceRiverSystem")]
		[EnumMember(Value = "International Great Lakes Datum 2020")] 
		InternationalGreatLakesDatum2020 = 46,

		[System.ComponentModel.Description("TheBottomOfTheOceanAndSeasWhereThereIsAGenerallySmoothGentleGradientAlsoReferredToAsSeaBedSometimesSeabedOrSeaBedAndSeaBottom")]
		[EnumMember(Value = "Sea Floor")] 
		SeaFloor = 47,

		[System.ComponentModel.Description("ATwoDimensionalInTheHorizontalPlaneFieldRepresentingTheAirSeaInterfaceWithHighFrequencyFluctuationsSuchAsWindWavesAndSwellButNotAstronomicalTidesFilteredOut")]
		[EnumMember(Value = "Sea Surface")] 
		SeaSurface = 48,

		[System.ComponentModel.Description("AVerticalReferenceNearTheLowestAstronomicalTideLatBelowWhichTheSeaLevelFallsOnlyVeryExceptionally")]
		[EnumMember(Value = "Hydrographic Zero")] 
		HydrographicZero = 49,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
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
			public String? administrativeDivision {get;set;} = default;

			public bool ShouldSerializeadministrativeDivision() { return !string.IsNullOrEmpty(administrativeDivision); }

			public String? cityName {get;set;} = default;

			public bool ShouldSerializecityName() { return !string.IsNullOrEmpty(cityName); }

			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			public List<String> deliveryPoint {get;set;} = [];

			public bool ShouldSerializedeliveryPoint() { return deliveryPoint.Any(); }

			public String? postalCode {get;set;} = default;

			public bool ShouldSerializepostalCode() { return !string.IsNullOrEmpty(postalCode); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class customPaperSize {
			[Required()]
			public decimal paperWidth {get;set;}

			[Required()]
			public decimal paperLength {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class defaultLocale {
			public String characterEncoding {get;set;} = string.Empty;

			public String countryName {get;set;} = string.Empty;

			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			public String name {get;set;} = string.Empty;

			public nameUsage? nameUsage {get;set;} = default;

			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			public String? fileLocator {get;set;} = default;

			public bool ShouldSerializefileLocator() { return !string.IsNullOrEmpty(fileLocator); }

			public String? fileReference {get;set;} = default;

			public bool ShouldSerializefileReference() { return !string.IsNullOrEmpty(fileReference); }

			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			public List<String> text {get;set;} = [];

			public bool ShouldSerializetext() { return text.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			public String? applicationProfile {get;set;} = default;

			public bool ShouldSerializeapplicationProfile() { return !string.IsNullOrEmpty(applicationProfile); }

			public String linkage {get;set;} = string.Empty;

			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }

			public String? onlineDescription {get;set;} = default;

			public bool ShouldSerializeonlineDescription() { return !string.IsNullOrEmpty(onlineDescription); }

			public String? protocol {get;set;} = default;

			public bool ShouldSerializeprotocol() { return !string.IsNullOrEmpty(protocol); }

			public String? protocolRequest {get;set;} = default;

			public bool ShouldSerializeprotocolRequest() { return !string.IsNullOrEmpty(protocolRequest); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			public String dateEnd {get;set;}

			public String dateStart {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class pricing {
			public String? contractPeriod {get;set;} = default;

			public bool ShouldSerializecontractPeriod() { return !string.IsNullOrEmpty(contractPeriod); }

			public String currency {get;set;} = string.Empty;

			[Required()]
			public decimal price {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class printSize {
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public iSO216? iSO216 {get;set;} = default;

			public bool ShouldSerializeiSO216() { return iSO216.HasValue; }

			public customPaperSize? customPaperSize {get;set;} = default;

			public bool ShouldSerializecustomPaperSize() { return customPaperSize!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class productSpecification {
			[XmlIgnore]
			[Required()]
			public DateOnly editionDate {get;set;}

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			public String? iSSN {get;set;} = default;

			public bool ShouldSerializeiSSN() { return !string.IsNullOrEmpty(iSSN); }

			public String name {get;set;} = string.Empty;

			public String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class supportFileSpecification {
			[XmlIgnore]
			[Required()]
			public DateOnly editionDate {get;set;}

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			public String name {get;set;} = string.Empty;

			public String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class serviceSpecification {
			[XmlIgnore]
			[Required()]
			public DateOnly editionDate {get;set;}

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			public String name {get;set;} = string.Empty;

			public String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIndication {
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlIgnore]
			public DateOnly? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return reportedDate.HasValue; }

			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[EnumerationValue([1,2,7,8,9,10,11,12,13,14,15])]
			public sourceType? sourceType {get;set;} = default;

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			public String contactInstructions {get;set;} = string.Empty;

			public String telecommunicationIdentifier {get;set;} = string.Empty;

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalOfCycle {
			[EnumerationValue([1,2,3,4])]
			public List<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit {get;set;} = [];

			public bool ShouldSerializetypeOfTimeIntervalUnit() { return typeOfTimeIntervalUnit.Any(); }

			[Required()]
			public int valueOfTime {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class weekOfYear {
			[Required()]
			public int weekNumber {get;set;}

			[Required()]
			public int yearNumber {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class issuanceCycle {
			public periodicDateRange? periodicDateRange {get;set;} = default;

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange!=default; }

			public timeIntervalOfCycle? timeIntervalOfCycle {get;set;} = default;

			public bool ShouldSerializetimeIntervalOfCycle() { return timeIntervalOfCycle!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class printInformation {
			public String? printAgency {get;set;} = default;

			public bool ShouldSerializeprintAgency() { return !string.IsNullOrEmpty(printAgency); }

			public String? printNation {get;set;} = default;

			public bool ShouldSerializeprintNation() { return !string.IsNullOrEmpty(printNation); }

			public String? reprintEdition {get;set;} = default;

			public bool ShouldSerializereprintEdition() { return !string.IsNullOrEmpty(reprintEdition); }

			public String? reprintNation {get;set;} = default;

			public bool ShouldSerializereprintNation() { return !string.IsNullOrEmpty(reprintNation); }

			[Required()]
			public printSize printSize {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class supportFile {
			public String? comment {get;set;} = default;

			public bool ShouldSerializecomment() { return !string.IsNullOrEmpty(comment); }

			[EnumerationValue([8])]
			[Required()]
			public digitalSignatureReference digitalSignatureReference {get;set;}

			[EnumerationValue([1,2])]
			public digitalSignatureValue? digitalSignatureValue {get;set;} = default;

			public bool ShouldSerializedigitalSignatureValue() { return digitalSignatureValue.HasValue; }

			public int? editionNumber {get;set;} = default;

			public bool ShouldSerializeeditionNumber() { return editionNumber.HasValue; }

			public String fileLocator {get;set;} = string.Empty;

			public String fileName {get;set;} = string.Empty;

			[XmlIgnore]
			public DateOnly? issueDate {get;set;} = default;

			public bool ShouldSerializeissueDate() { return issueDate.HasValue; }

			public String? otherDataTypeDescription {get;set;} = default;

			public bool ShouldSerializeotherDataTypeDescription() { return !string.IsNullOrEmpty(otherDataTypeDescription); }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,100])]
			[Required()]
			public supportFileFormat supportFileFormat {get;set;}

			[EnumerationValue([1,2,3])]
			[Required()]
			public supportFilePurpose supportFilePurpose {get;set;}

			[Required()]
			public defaultLocale defaultLocale {get;set;}

			[Required()]
			public supportFileSpecification supportFileSpecification {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalOfProduct {
			[XmlIgnore]
			public DateOnly? expirationDate {get;set;} = default;

			public bool ShouldSerializeexpirationDate() { return expirationDate.HasValue; }

			[XmlIgnore]
			[Required()]
			public DateOnly issueDate {get;set;}

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "issueDate")]
			public DateTime issueDateField {
				get { return issueDate.ToDateTime(TimeOnly.MinValue); }
				set { issueDate = DateOnly.FromDateTime(value); }
			}

			public issuanceCycle? issuanceCycle {get;set;} = default;

			public bool ShouldSerializeissuanceCycle() { return issuanceCycle!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class referenceToNM {
			[XmlIgnore]
			[Required()]
			public DateOnly publicationDate {get;set;}

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "publicationDate")]
			public DateTime publicationDateField {
				get { return publicationDate.ToDateTime(TimeOnly.MinValue); }
				set { publicationDate = DateOnly.FromDateTime(value); }
			}

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
			[EnumerationValue([1,2,3,4])]
			[Required()]
			public categoryOfProductMapping categoryOfProductMapping {get;set;}

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
			[Required()]
			public int catalogueSectionNumber {get;set;}

			public String? catalogueSectionTitle {get;set;} = default;

			public bool ShouldSerializecatalogueSectionTitle() { return !string.IsNullOrEmpty(catalogueSectionTitle); }

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ProductionDetails),
					role = Enum.GetName<Role>(Role.theProducer)!,
					informationTypes = [nameof(ProducerInformation)],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DistributionDetails),
					role = Enum.GetName<Role>(Role.theDistributor)!,
					informationTypes = [nameof(DistributorInformation)],
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
			public String contactInstructions {get;set;} = string.Empty;

			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(DistributorContact),
					role = Enum.GetName<Role>(Role.theDistributor)!,
					informationTypes = [nameof(DistributorInformation)],
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
			public String? domesticCarriageRequirements {get;set;} = default;

			public bool ShouldSerializedomesticCarriageRequirements() { return !string.IsNullOrEmpty(domesticCarriageRequirements); }

			public String? internationalCarriageRequirements {get;set;} = default;

			public bool ShouldSerializeinternationalCarriageRequirements() { return !string.IsNullOrEmpty(internationalCarriageRequirements); }

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
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			public List<pricing> pricing {get;set;} = [];

			public bool ShouldSerializepricing() { return pricing.Any(); }

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
			public String agencyResponsibleForProduction {get;set;} = string.Empty;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProductionDetails),
					role = Enum.GetName<Role>(Role.catalogueHeader)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
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
			public String distributorName {get;set;} = string.Empty;

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DistributorContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
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

		/// <summary>
		/// An element within a catalogue of elements.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class CatalogueElement : FeatureNode, IFeatureBindingDefinition {
			public String? agencyResponsibleForProduction {get;set;} = default;

			public bool ShouldSerializeagencyResponsibleForProduction() { return !string.IsNullOrEmpty(agencyResponsibleForProduction); }

			public List<catalogueElementClassification> catalogueElementClassification {get;set;} = [];

			public bool ShouldSerializecatalogueElementClassification() { return catalogueElementClassification.Any(); }

			public String? catalogueElementIdentifier {get;set;} = default;

			public bool ShouldSerializecatalogueElementIdentifier() { return !string.IsNullOrEmpty(catalogueElementIdentifier); }

			public String? classification {get;set;} = default;

			public bool ShouldSerializeclassification() { return !string.IsNullOrEmpty(classification); }

			public List<iMOMaritimeService> iMOMaritimeService {get;set;} = [];

			public bool ShouldSerializeiMOMaritimeService() { return iMOMaritimeService.Any(); }

			[Required()]
			public Boolean notForNavigation {get;set;} = false;

			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			public onlineResource? onlineResource {get;set;} = default;

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }

			public List<supportFile> supportFile {get;set;} = [];

			public bool ShouldSerializesupportFile() { return supportFile.Any(); }

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
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PriceOfElement),
					role = Enum.GetName<Role>(Role.thePriceInformation)!,
					informationTypes = [nameof(PriceInformation)],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(ProductPackage),
					role = Enum.GetName<Role>(Role.elementContainer)!,
					informationTypes = [nameof(CatalogueSectionHeader)],
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
			public List<decimal> approximateGridResolution {get;set;} = [];

			public bool ShouldSerializeapproximateGridResolution() { return approximateGridResolution.Any(); }

			public List<int> compilationScale {get;set;} = [];

			public bool ShouldSerializecompilationScale() { return compilationScale.Any(); }

			[EnumerationValue([1,2])]
			public distributionStatus? distributionStatus {get;set;} = default;

			public bool ShouldSerializedistributionStatus() { return distributionStatus.HasValue; }

			public int? editionNumber {get;set;} = default;

			public bool ShouldSerializeeditionNumber() { return editionNumber.HasValue; }

			public int? maximumDisplayScale {get;set;} = default;

			public bool ShouldSerializemaximumDisplayScale() { return maximumDisplayScale.HasValue; }

			public int? minimumDisplayScale {get;set;} = default;

			public bool ShouldSerializeminimumDisplayScale() { return minimumDisplayScale.HasValue; }

			[EnumerationValue([1,2,3])]
			public List<navigationPurpose> navigationPurpose {get;set;} = [];

			public bool ShouldSerializenavigationPurpose() { return navigationPurpose.Any(); }

			public String? optimumDisplayScale {get;set;} = default;

			public bool ShouldSerializeoptimumDisplayScale() { return !string.IsNullOrEmpty(optimumDisplayScale); }

			public String? originalProductNumber {get;set;} = default;

			public bool ShouldSerializeoriginalProductNumber() { return !string.IsNullOrEmpty(originalProductNumber); }

			public String? producerNation {get;set;} = default;

			public bool ShouldSerializeproducerNation() { return !string.IsNullOrEmpty(producerNation); }

			public String? productNumber {get;set;} = default;

			public bool ShouldSerializeproductNumber() { return !string.IsNullOrEmpty(productNumber); }

			[EnumerationValue([1,2,3,4,5,6])]
			public specificUsage? specificUsage {get;set;} = default;

			public bool ShouldSerializespecificUsage() { return specificUsage.HasValue; }

			[XmlIgnore]
			public DateOnly? updateDate {get;set;} = default;

			public bool ShouldSerializeupdateDate() { return updateDate.HasValue; }

			public int? updateNumber {get;set;} = default;

			public bool ShouldSerializeupdateNumber() { return updateNumber.HasValue; }

			public horizontalDatumEPSGCode? horizontalDatumEPSGCode {get;set;} = default;

			public bool ShouldSerializehorizontalDatumEPSGCode() { return horizontalDatumEPSGCode != default; }

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
			public Boolean? compressionFlag {get;set;} = default;

			public bool ShouldSerializecompressionFlag() { return compressionFlag.HasValue; }

			public String? datasetName {get;set;} = default;

			public bool ShouldSerializedatasetName() { return !string.IsNullOrEmpty(datasetName); }

			[XmlIgnore]
			[Required()]
			public DateOnly issueDate {get;set;}

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "issueDate")]
			public DateTime issueDateField {
				get { return issueDate.ToDateTime(TimeOnly.MinValue); }
				set { issueDate = DateOnly.FromDateTime(value); }
			}

			public TimeOnly? issueTime {get;set;} = default;

			public bool ShouldSerializeissueTime() { return issueTime.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Required()]
			public typeOfProductFormat typeOfProductFormat {get;set;}

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
		}

		/// <summary>
		/// A product printed on paper.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalProduct : NavigationalProduct {
			[XmlIgnore]
			[Required()]
			public DateOnly editionDate {get;set;}

			[JsonIgnore]
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", ElementName = "editionDate")]
			public DateTime editionDateField {
				get { return editionDate.ToDateTime(TimeOnly.MinValue); }
				set { editionDate = DateOnly.FromDateTime(value); }
			}

			public String? iSBN {get;set;} = default;

			public bool ShouldSerializeiSBN() { return !string.IsNullOrEmpty(iSBN); }

			public String? publicationNumber {get;set;} = default;

			public bool ShouldSerializepublicationNumber() { return !string.IsNullOrEmpty(publicationNumber); }

			public String? typeOfPhysicalProduct {get;set;} = default;

			public bool ShouldSerializetypeOfPhysicalProduct() { return !string.IsNullOrEmpty(typeOfPhysicalProduct); }

			public printInformation? printInformation {get;set;} = default;

			public bool ShouldSerializeprintInformation() { return printInformation!=default; }

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
		}

		/// <summary>
		/// A service that makes use of S-100 based product specifications to support data transfer.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class S100Service : CatalogueElement {
			public Boolean? compressionFlag {get;set;} = default;

			public bool ShouldSerializecompressionFlag() { return compressionFlag.HasValue; }

			public String? serviceName {get;set;} = default;

			public bool ShouldSerializeserviceName() { return !string.IsNullOrEmpty(serviceName); }

			[EnumerationValue([1,2,3,4])]
			public serviceStatus? serviceStatus {get;set;} = default;

			public bool ShouldSerializeserviceStatus() { return serviceStatus.HasValue; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Required()]
			public typeOfProductFormat typeOfProductFormat {get;set;}

			public serviceSpecification? serviceSpecification {get;set;} = default;

			public bool ShouldSerializeserviceSpecification() { return serviceSpecification!=default; }

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
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S128/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;
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
