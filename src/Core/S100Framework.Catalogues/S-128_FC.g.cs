using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
		public static string[] FeatureTypes => ["CatalogueElement","NavigationalProduct","ElectronicProduct","PhysicalProduct","S100Service"];
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum catalogueElementClassification : int {
		[System.ComponentModel.Description("ElectronicNavigationalChart")]
		[EnumMember(Value = "ENC")] 
		Enc = 1,

		[System.ComponentModel.Description("BathymetricSurface")]
		[EnumMember(Value = "Bathymetric Chart")] 
		BathymetricChart = 2,

		[System.ComponentModel.Description("WaterLevelInformationForSurfaceNavigation")]
		[EnumMember(Value = "Water Level Product")] 
		WaterLevelProduct = 3,

		[System.ComponentModel.Description("SurfaceCurrents")]
		[EnumMember(Value = "Surface Current Product")] 
		SurfaceCurrentProduct = 4,

		[System.ComponentModel.Description("MsiMaritimeSafetyInformationService")]
		[EnumMember(Value = "MSI Service")] 
		MsiService = 5,

		[System.ComponentModel.Description("MarineAidsToNavigational")]
		[EnumMember(Value = "AtoN Information")] 
		AtonInformation = 6,

		[System.ComponentModel.Description("CatalogueService")]
		[EnumMember(Value = "Catalogue Service")] 
		CatalogueService = 7,

		[System.ComponentModel.Description("TheServicesAssociatedWithTheRoute")]
		[EnumMember(Value = "Routing Service")] 
		RoutingService = 8,

		[System.ComponentModel.Description("IceInformation")]
		[EnumMember(Value = "Ice Information")] 
		IceInformation = 9,

		[System.ComponentModel.Description("TheInformationAssociatedWithTheRoute")]
		[EnumMember(Value = "Routing Information")] 
		RoutingInformation = 10,

		[System.ComponentModel.Description("ASpecialPurposeChart")]
		[EnumMember(Value = "Special Purpose Chart")] 
		SpecialPurposeChart = 11,

		[System.ComponentModel.Description("CatalogueOfNauticalProducts")]
		[EnumMember(Value = "Nautical Publication")] 
		NauticalPublication = 12,

		[System.ComponentModel.Description("PrintedNauticalChart")]
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
		[EnumMember(Value = "border control")] 
		BorderControl = 2,

		[System.ComponentModel.Description("TheDepartmentOfGovernmentOrCivilForceChargedWithMaintainingPublicOrder")]
		[EnumMember(Value = "police")] 
		Police = 3,

		[System.ComponentModel.Description("PersonOrCorporationOwnersOfOrEntrustedWithOrInvestedWithThePowerOfManagingAPortMayBeCalledAHarbourBoardPortTrustPortCommissionHarbourCommissionMarineDepartment")]
		[EnumMember(Value = "port")] 
		Port = 4,

		[System.ComponentModel.Description("TheAuthorityControllingPeopleEnteringACountry")]
		[EnumMember(Value = "immigration")] 
		Immigration = 5,

		[System.ComponentModel.Description("TheAuthorityWithResponsibilityForCheckingTheValidityOfTheHealthDeclarationOfAVesselAndForDeclaringFreePratique")]
		[EnumMember(Value = "health")] 
		Health = 6,

		[System.ComponentModel.Description("OrganizationKeepingWatchOnShippingAndCoastalWatersAccordingToGovernmentalLawNormallyTheAuthorityWithResponsibilityForSearchAndRescue")]
		[EnumMember(Value = "coast guard")] 
		CoastGuard = 7,

		[System.ComponentModel.Description("TheAuthorityWithResponsibilityForPreventingInfectionOfTheAgricultureOfACountryAndForTheProtectionOfTheAgriculturalInterestsOfACountry")]
		[EnumMember(Value = "agricultural")] 
		Agricultural = 8,

		[System.ComponentModel.Description("AMilitaryAuthorityWhichProvidesControlOfAccessToOrApprovalForTransitThroughDesignatedAreasOrAirspace")]
		[EnumMember(Value = "military")] 
		Military = 9,

		[System.ComponentModel.Description("APrivateOrPubliclyOwnedCompanyOrCommercialEnterpriseWhichExercisesControlOfFacilitiesForExampleACalibrationArea")]
		[EnumMember(Value = "private company")] 
		PrivateCompany = 10,

		[System.ComponentModel.Description("AGovernmentalOrMilitaryForceWithJurisdictionInTerritorialWatersExamplesCouldIncludeGendarmerieMaritimeCarabinierieAndGuardiaCivil")]
		[EnumMember(Value = "maritime police")] 
		MaritimePolice = 11,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheProtectionOfTheEnvironment")]
		[EnumMember(Value = "environmental")] 
		Environmental = 12,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheControlOfFisheries")]
		[EnumMember(Value = "fishery")] 
		Fishery = 13,

		[System.ComponentModel.Description("AnAuthorityWithResponsibilityForTheControlAndMovementOfMoney")]
		[EnumMember(Value = "finance")] 
		Finance = 14,

		[System.ComponentModel.Description("ANationalOrRegionalAuthorityChargedWithAdministrationOfMaritimeAffairs")]
		[EnumMember(Value = "maritime")] 
		Maritime = 15,

		[System.ComponentModel.Description("TheAgencyOrEstablishmentForCollectingDutiesTolls")]
		[EnumMember(Value = "customs")] 
		Customs = 16,

		[System.ComponentModel.Description("StateAgencyInChargeOfMarineSurveys")]
		[EnumMember(Value = "hydrographic office")] 
		HydrographicOffice = 17,

		[System.ComponentModel.Description("RegionalEncCoordinationCentreEntitiesSetUpByTheIho")]
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
	public enum nameUsage : int {
		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToTheDefaultNameTextDisplaySetting")]
		[EnumMember(Value = "default name display")] 
		DefaultNameDisplay = 1,

		[System.ComponentModel.Description("TheNameIsIntendedToBeDisplayedWhenTheEndUserSystemIsSetToAnAlternateNameTextDisplaySettingForExampleAnAlternateLanguage")]
		[EnumMember(Value = "alternate name display")] 
		AlternateNameDisplay = 2,

		[System.ComponentModel.Description("TheNameOrTextIsNotIntendedToBeDisplayed")]
		[EnumMember(Value = "no chart display")] 
		NoChartDisplay = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum distributionStatus : int {
		[System.ComponentModel.Description("TheActOrProcessOfProducingSomething")]
		[EnumMember(Value = "production")] 
		Production = 1,

		[System.ComponentModel.Description("TheActionToWithdrawATimeStampUsedWhenATimeStampHasBeenReportedIncorrectly")]
		[EnumMember(Value = "withdrawn")] 
		Withdrawn = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum IMOMaritimeService : int {
		[System.ComponentModel.Description("VtsInformationServiceIs")]
		[EnumMember(Value = "Vessel traffic service")] 
		VesselTrafficService = 1,

		[System.ComponentModel.Description("NavigationalAssistanceServiceNas")]
		[EnumMember(Value = "Aids to navigation service")] 
		AidsToNavigationService = 2,

		[System.ComponentModel.Description("TrafficOrganizationServiceTos")]
		[EnumMember(Value = "Reserved for future use")] 
		ReservedForFutureUse = 3,

		[System.ComponentModel.Description("LocalPortService")]
		[EnumMember(Value = "Port support service")] 
		PortSupportService = 4,

		[System.ComponentModel.Description("MaritimeSafetyInformationServiceMsi")]
		[EnumMember(Value = "Maritime safety information service")] 
		MaritimeSafetyInformationService = 5,

		[System.ComponentModel.Description("PilotageService")]
		[EnumMember(Value = "Pilotage service")] 
		PilotageService = 6,

		[System.ComponentModel.Description("TugService")]
		[EnumMember(Value = "Tug service")] 
		TugService = 7,

		[System.ComponentModel.Description("VesselShoreReporting")]
		[EnumMember(Value = "Vessel shore reporting")] 
		VesselShoreReporting = 8,

		[System.ComponentModel.Description("TelemedicalAssistanceServiceTmas")]
		[EnumMember(Value = "Telemedical assistance service")] 
		TelemedicalAssistanceService = 9,

		[System.ComponentModel.Description("MaritimeAssistnaceServiceMas")]
		[EnumMember(Value = "Maritime assistance service")] 
		MaritimeAssistanceService = 10,

		[System.ComponentModel.Description("NauticalChartService")]
		[EnumMember(Value = "Nautical chart service")] 
		NauticalChartService = 11,

		[System.ComponentModel.Description("NauticalPublicationsService")]
		[EnumMember(Value = "Nautical publications service")] 
		NauticalPublicationsService = 12,

		[System.ComponentModel.Description("IceNavigationService")]
		[EnumMember(Value = "Ice navigation service")] 
		IceNavigationService = 13,

		[System.ComponentModel.Description("MeteorologicalInformationService")]
		[EnumMember(Value = "Meteorological information service")] 
		MeteorologicalInformationService = 14,

		[System.ComponentModel.Description("RealTimeHydrographicAndEnvironmentalInformationService")]
		[EnumMember(Value = "Real-time hydrographic and environmental information services")] 
		RealTimeHydrographicAndEnvironmentalInformationServices = 15,

		[System.ComponentModel.Description("SearchAndRescueService")]
		[EnumMember(Value = "Search and rescue service")] 
		SearchAndRescueService = 16,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum iso216 : int {
		[System.ComponentModel.Description("TheFirstSizeAsOutputSizeOnNauticalPaperChart")]
		[EnumMember(Value = "A0")] 
		A0 = 1,

		[System.ComponentModel.Description("TheSecondSizeAsOutputSizeOnNauticalPaperChart")]
		[EnumMember(Value = "A1")] 
		A1 = 2,

		[System.ComponentModel.Description("TheThirdSizeAsOutputSizeOnNauticalPaperChart")]
		[EnumMember(Value = "A2")] 
		A2 = 3,

		[System.ComponentModel.Description("TheFourthSizeAsOutputSizeOnNauticalPaperChart")]
		[EnumMember(Value = "A3")] 
		A3 = 4,

		[System.ComponentModel.Description("TheFifthSizeAsOutputSizeOnNauticalPaperChart")]
		[EnumMember(Value = "A4")] 
		A4 = 5,

		[System.ComponentModel.Description("TheSixthSizeAsOutputSizeOnNauticalPaperChart")]
		[EnumMember(Value = "A5")] 
		A5 = 6,

		[System.ComponentModel.Description("TheSeventhSizeAsOutputSizeOnNauticalPaperChart")]
		[EnumMember(Value = "A6")] 
		A6 = 7,

		[System.ComponentModel.Description("TheEighthSizeAsOutputSizeOnNauticalPaperChart")]
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
		[EnumMember(Value = "higherPriorityAlternative")] 
		Higherpriorityalternative = 1,

		[System.ComponentModel.Description("ALowerPrioritizedOrNotRecommendedAlternativeProductOrServiceThatCanFullyReplaceAnother")]
		[EnumMember(Value = "lowerPriorityAlternative")] 
		Lowerpriorityalternative = 2,

		[System.ComponentModel.Description("ARecommendedAdditionalProductOrServiceThatProvidesAddedValueToAnother")]
		[EnumMember(Value = "recommendedEnhancementProvider")] 
		Recommendedenhancementprovider = 3,

		[System.ComponentModel.Description("AProductOrServiceThatIsRecommendedToMakeUseOfAddedValueProvidedByAnotherProductOrService")]
		[EnumMember(Value = "recommendedEnhancementUser")] 
		Recommendedenhancementuser = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum digitalSignatureReference : int {
		[System.ComponentModel.Description("EllipticCurveDigitalSignatureAlgorithmEcdsaThatBasedUponTheIssuingCertificateItSSignedWithTheIssuerSKeyP384")]
		[EnumMember(Value = "ECDSA-384-SHA2")] 
		Ecdsa384Sha2 = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum navigationPurpose : int {
		[System.ComponentModel.Description("ForPortAndNearShoreOperations")]
		[EnumMember(Value = "port")] 
		Port = 1,

		[System.ComponentModel.Description("ForCoastAndPlanningPurposes")]
		[EnumMember(Value = "transit")] 
		Transit = 2,

		[System.ComponentModel.Description("ForOceanCrossingAndPlanningPurposes")]
		[EnumMember(Value = "overview")] 
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

		[System.ComponentModel.Description("RepresentationOfMovingImagesInUnspecifiedFormat")]
		[EnumMember(Value = "VIDEO")] 
		Video = 6,

		[System.ComponentModel.Description("TaggedImageFileFormat")]
		[EnumMember(Value = "TIFF")] 
		Tiff = 7,

		[System.ComponentModel.Description("PortableDocumentFormat")]
		[EnumMember(Value = "PDF/A or U/A")] 
		PdfAOrUA = 8,

		[System.ComponentModel.Description("LuaProgrammingLanguage")]
		[EnumMember(Value = "LUA")] 
		Lua = 9,

		[System.ComponentModel.Description("OtherFormat")]
		[EnumMember(Value = "other")] 
		Other = 100,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum supportFilePurpose : int {
		[System.ComponentModel.Description("AFileWhichIsNew")]
		[EnumMember(Value = "new")] 
		New = 1,

		[System.ComponentModel.Description("AFileWhichReplacesAnExistingFile")]
		[EnumMember(Value = "replacement")] 
		Replacement = 2,

		[System.ComponentModel.Description("DeletesAnExistingFile")]
		[EnumMember(Value = "deletion")] 
		Deletion = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum serviceStatus : int {
		[System.ComponentModel.Description("UnderTermsNotFinalOrFullyWorkedOutOrAgreedUpon")]
		[EnumMember(Value = "provisional")] 
		Provisional = 1,

		[System.ComponentModel.Description("MerchandiseIssuedForSaleOrPublicShowing")]
		[EnumMember(Value = "released")] 
		Released = 2,

		[System.ComponentModel.Description("DataThatIsDeprecatedInImportanceAndIsNoLongerUsedAndWillDisappearInTheFuture")]
		[EnumMember(Value = "deprecated")] 
		Deprecated = 3,

		[System.ComponentModel.Description("ItemThatHasBeenRemovedOrDeleted")]
		[EnumMember(Value = "deleted")] 
		Deleted = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum sourceType : int {
		[System.ComponentModel.Description("TreatyConventionOrInternationalAgreementLawOrRegulationIssuedByANationalOrOtherAuthority")]
		[EnumMember(Value = "law or regulation")] 
		LawOrRegulation = 1,

		[System.ComponentModel.Description("PublicationNotHavingTheForceOfLawIssuedByAnInternationalOrganisationOrANationalOrLocalAdministration")]
		[EnumMember(Value = "official publication")] 
		OfficialPublication = 2,

		[System.ComponentModel.Description("ReportedByMarinerSAndConfirmedByAnotherSource")]
		[EnumMember(Value = "mariner report, confirmed")] 
		MarinerReportConfirmed = 7,

		[System.ComponentModel.Description("ReportedByMarinerSButNotConfirmed")]
		[EnumMember(Value = "mariner report, not confirmed")] 
		MarinerReportNotConfirmed = 8,

		[System.ComponentModel.Description("ShippingAndOtherIndustryPublicationsIncludingGraphicsChartsAndWebSites")]
		[EnumMember(Value = "industry publications and reports")] 
		IndustryPublicationsAndReports = 9,

		[System.ComponentModel.Description("InformationObtainedFromSatelliteImages")]
		[EnumMember(Value = "remotely sensed images")] 
		RemotelySensedImages = 10,

		[System.ComponentModel.Description("InformationObtainedFromPhotographs")]
		[EnumMember(Value = "photographs")] 
		Photographs = 11,

		[System.ComponentModel.Description("InformationObtainedFromProductsIssuedByHydrographicOffices")]
		[EnumMember(Value = "products issued by HO service")] 
		ProductsIssuedByHoService = 12,

		[System.ComponentModel.Description("InformationObtainedFromNewsMedia")]
		[EnumMember(Value = "news media")] 
		NewsMedia = 13,

		[System.ComponentModel.Description("InformationObtainedFromTheAnalysisOfTrafficData")]
		[EnumMember(Value = "traffic data")] 
		TrafficData = 14,

		[System.ComponentModel.Description("ANationalOrRegionalAuthorityChargedWithAdministrationOfMaritimeAffairs")]
		[EnumMember(Value = "maritime")] 
		Maritime = 15,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum specificUsage : int {
		[System.ComponentModel.Description("ForUseInTheStudyOfTheCharacteristicsOfMaritimeZonesInTheFormulationOfPlansInTheSelectionOfRoutesEtcShowingOnlyRelevantElementsOfTheCoastlineHarboursIslandsPrincipalNavigationalMarksAndObstructionsAndSubmarineLandforms11499999Scale")]
		[EnumMember(Value = "Navigational Purpose Overview")] 
		NavigationalPurposeOverview = 1,

		[System.ComponentModel.Description("ANauticalChartWithUniversalityIEGeneralityInUseCharacterizedByTheRequirementThatTheChartMustComprehensivelyDescribeVariousNaturalElementsAndSocioeconomicElementsAndThatEachElementOfTheSubjectMatterExpressedIsUniversalTheScaleIsBetween135000011499999")]
		[EnumMember(Value = "Navigational Purpose General")] 
		NavigationalPurposeGeneral = 2,

		[System.ComponentModel.Description("UsedForMarineNavigationMainlyDisplayingSubmarineLandformsNavigationalMarksNavigationalObstaclesAndOtherElementsRelatedToNavigationTheScaleIsBetween1900001349999")]
		[EnumMember(Value = "Navigational Purpose Coastal")] 
		NavigationalPurposeCoastal = 3,

		[System.ComponentModel.Description("UsedForNearShoreNavigationMainlyShowingTheMarineElementsCloseToCoastalAreasTheScaleIsBetween122000189999")]
		[EnumMember(Value = "Navigational Purpose Approach")] 
		NavigationalPurposeApproach = 4,

		[System.ComponentModel.Description("UsedForEnteringAndLeavingHarboursSelectingAnchorageStudyingHarbourTopographyAndCarryingOutTheConstructionOfHarboursTheScaleIsBetween14000121999")]
		[EnumMember(Value = "Navigational Purpose Harbour")] 
		NavigationalPurposeHarbour = 5,

		[System.ComponentModel.Description("ForShipsBerthingScale14000")]
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
		[EnumMember(Value = "voice")] 
		Voice = 1,

		[System.ComponentModel.Description("ASystemOfTransmittingAndReproducingGraphicMatterAsPrintingOrStillPicturesByMeansOfSignalsSentOverTelephoneLines")]
		[EnumMember(Value = "facsimile")] 
		Facsimile = 2,

		[System.ComponentModel.Description("ShortMessageServiceIsAFormOfTextMessagingCommunicationOnPhonesAndMobilePhones")]
		[EnumMember(Value = "sms")] 
		Sms = 3,

		[System.ComponentModel.Description("ARepresentationOfFactsConceptsOrInstructionsInAFormalisedMannerSuitableForCommunicationInterpretationOrProcessing")]
		[EnumMember(Value = "data")] 
		Data = 4,

		[System.ComponentModel.Description("DataThatIsConstantlyReceivedByAndPresentedToAnEndUserWhileBeingDeliveredByAProvider")]
		[EnumMember(Value = "streamedData")] 
		Streameddata = 5,

		[System.ComponentModel.Description("ASystemOfCommunicationInWhichMessagesAreSentOverLongDistancesByUsingATelephoneSystemAndArePrintedByUsingASpecialMachineCalledATeletypewriter")]
		[EnumMember(Value = "telex")] 
		Telex = 6,

		[System.ComponentModel.Description("AnApparatusSystemOrProcessForCommunicationAtADistanceByElectricTransmissionOverWire")]
		[EnumMember(Value = "telegraph")] 
		Telegraph = 7,

		[System.ComponentModel.Description("MessagesAndOtherDataExchangedBetweenIndividualsUsingComputersInANetwork")]
		[EnumMember(Value = "email")] 
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

		[System.ComponentModel.Description("HypertextMarkupLanguageATypeOfBasicWebLanguageUsedToCreateWebDocuments")]
		[EnumMember(Value = "HTML")] 
		Html = 4,

		[System.ComponentModel.Description("EBookFileFormat")]
		[EnumMember(Value = "ePub")] 
		Epub = 5,

		[System.ComponentModel.Description("ForPrintingHydrographicChartsHeavyweightSingleLayerPaperIsUsedSuchPaperIsGenerallyMadeWhollyOrPartlyFromRagsAndSimulatesHandMadePaperItIsStrongMoistureResistantAndManufacturedToWithstandSurfaceErasure")]
		[EnumMember(Value = "paper")] 
		Paper = 6,

		[System.ComponentModel.Description("GridFileFormat")]
		[EnumMember(Value = "HDF-5")] 
		Hdf5 = 7,

		[System.ComponentModel.Description("RasterDataFormatUsedByUsaAndCanadaAndOthers")]
		[EnumMember(Value = "BSB")] 
		Bsb = 8,

		[System.ComponentModel.Description("ExtensionOfTheTiffSpecificationToAllowTheStorageOfGeoReferencingInformation")]
		[EnumMember(Value = "GeoTiff")] 
		Geotiff = 9,

		[System.ComponentModel.Description("")]
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
		[System.ComponentModel.Description("six0MinutesOr3six00Seconds")]
		[EnumMember(Value = "hour")] 
		Hour = 1,

		[System.ComponentModel.Description("ForADay")]
		[EnumMember(Value = "day")] 
		Day = 2,

		[System.ComponentModel.Description("ForAMonth")]
		[EnumMember(Value = "month")] 
		Month = 3,

		[System.ComponentModel.Description("APeriodOfOneYear")]
		[EnumMember(Value = "year")] 
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
		DutchHighWaterReferenceLevel = 42,

		[System.ComponentModel.Description("TheDatumRefersToEachBalticCountrySRealizationOfTheEuropeanVerticalReferenceSystemEvrsWithLandUpliftEpoch2000WhichIsConnectedToTheNormaalAmsterdamsPeilNap")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		BalticSeaChartDatum2000 = 43,

		[System.ComponentModel.Description("DutchEstuaryLowWaterReferenceLevelOlw")]
		[EnumMember(Value = "Dutch Estuary Low Water Reference Level (OLW)")] 
		DutchEstuaryLowWaterReferenceLevelOlw = 44,

		[System.ComponentModel.Description("TheBottomOfTheOceanAndSeasWhereThereIsAGenerallySmoothGentleGradientAlsoReferredToAsSeaBedSometimesSeabedOrSeaBedAndSeaBottom")]
		[EnumMember(Value = "Sea Floor")] 
		SeaFloor = 45,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Serializable()]
	public class horizontalDatumEpsg
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

	public static class CodeList
	{
		public static ImmutableArray<horizontalDatumEpsg> horizontalDatumEpsgs => ImmutableArray.Create<horizontalDatumEpsg>(new horizontalDatumEpsg[]{
			new() {
				code = 4326,
				definition = "World Geodetic System 1984, used globally for GPS and geographic coordinates. Specifies coordinates in latitude and longitude degrees.",
				label = "WGS 84 (EPSG:4326)",
			},
			new() {
				code = 3857,
				definition = "A popular web mapping projection used by Google Maps, OpenStreetMap, and Bing Maps. Distorts at the poles but is widely used in online maps.",
				label = "WGS 84 / Pseudo-Mercator (EPSG:3857)",
			},
			new() {
				code = 3395,
				definition = "A global Mercator projection commonly used for mapping applications requiring accurate distance measurements near the equator.",
				label = "WGS 84 / World Mercator (EPSG:3395)",
			},
		});
	}

	namespace ComplexAttributes {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress {
			public String? administrativeDivision {get;set;} = default;

			public String? cityName {get;set;} = default;

			public String? countryName {get;set;} = default;

			public List<String> deliveryPoint {get;set;} = [];

			public String? postalCode {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class customPaperSize {
			[Required()]
			public int x {get;set;}

			[Required()]
			public int y {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class defaultLocale {
			public String characterEncoding {get;set;} = string.Empty;

			public String countryName {get;set;} = string.Empty;

			public String? language {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			public String? language {get;set;} = default;

			public String name {get;set;} = string.Empty;

			public nameUsage? nameUsage {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			public String? fileLocator {get;set;} = default;

			public String? fileReference {get;set;} = default;

			public String? headline {get;set;} = default;

			public String? language {get;set;} = default;

			public List<String> text {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			public String? applicationProfile {get;set;} = default;

			public String linkage {get;set;} = string.Empty;

			public String? nameOfResource {get;set;} = default;

			public String? onlineDescription {get;set;} = default;

			public String? protocol {get;set;} = default;

			public String? protocolRequest {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			[Required()]
			public DateOnly dateEnd {get;set;}

			[Required()]
			public DateOnly dateStart {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class pricing {
			public String? contractPeriod {get;set;} = default;

			public String currency {get;set;} = string.Empty;

			[Required()]
			public decimal price {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class printSize {
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public iso216? iso216 {get;set;} = default;

			public customPaperSize? customPaperSize {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class productSpecification {
			[Required()]
			public DateOnly date {get;set;}

			public String? ISSN {get;set;} = default;

			public String name {get;set;} = string.Empty;

			public String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class supportFileSpecification {
			[Required()]
			public DateOnly date {get;set;}

			public String name {get;set;} = string.Empty;

			public String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class serviceSpecification {
			[Required()]
			public DateOnly date {get;set;}

			public String name {get;set;} = string.Empty;

			public String version {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIndication {
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			public String? countryName {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			public String? source {get;set;} = default;

			[EnumerationValue([1,2,7,8,9,10,11,12,13,14,15])]
			public sourceType? sourceType {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			public String contactInstructions {get;set;} = string.Empty;

			public String telecommunicationIdentifier {get;set;} = string.Empty;

			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalOfCycle {
			[EnumerationValue([1,2,3,4])]
			public List<typeOfTimeIntervalUnit> typeOfTimeIntervalUnit {get;set;} = [];

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

			public timeIntervalOfCycle? timeIntervalOfCycle {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class printInformation {
			public String? printAgency {get;set;} = default;

			public String? printNation {get;set;} = default;

			public String? rePrintEdition {get;set;} = default;

			public String? rePrintNation {get;set;} = default;

			[Required()]
			public printSize printSize {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class supportFile {
			public String? comment {get;set;} = default;

			[EnumerationValue([1])]
			[Required()]
			public digitalSignatureReference digitalSignatureReference {get;set;}

			public String? digitalSignatureValue {get;set;} = default;

			public int? editionNumber {get;set;} = default;

			public String fileLocator {get;set;} = string.Empty;

			public String fileName {get;set;} = string.Empty;

			public DateOnly? issueDate {get;set;} = default;

			public String? otherDataTypeDescription {get;set;} = default;

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
			[Required()]
			public DateOnly issueDate {get;set;}

			public DateOnly? expirationDate {get;set;} = default;

			public issuanceCycle? issuanceCycle {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class referenceToNM {
			[Required()]
			public DateOnly publicationDate {get;set;}

			public weekOfYear? weekOfYear {get;set;} = default;
		}

	}
	public enum Role {
		[System.ComponentModel.Description("the top section of a catalogue")]
		catalogueHeader,
		[System.ComponentModel.Description("Container of element.")]
		elementContainer,
		[System.ComponentModel.Description("Catalogue of Elements.")]
		theCatalogueElement,
		[System.ComponentModel.Description("Types of nautical products")]
		theCatalogueOfNauticalProduct,
		[System.ComponentModel.Description("Information on how to reach a person or organization by postal, internet, telephone, telex and radio systems.")]
		theContactDetails,
		[System.ComponentModel.Description("One that distributes.")]
		theDistributor,
		[System.ComponentModel.Description("a component or part within the context of maritime information and charts.")]
		theElement,
		[System.ComponentModel.Description("Information of price.")]
		thePriceInformation,
		[System.ComponentModel.Description("information about the producer or creator of chart")]
		theProducer,
		[System.ComponentModel.Description("indicates supporting material or information related to a specific element or data.")]
		theReference,
		[System.ComponentModel.Description("essential conditions or functionalities for a specific system or process.")]
		theRequirement,
		[System.ComponentModel.Description("Source of information or data.")]
		theSource,
		[System.ComponentModel.Description("")]
		main,
		[System.ComponentModel.Description("")]
		panel,
	}

	namespace InformationAssociations {
		/// <summary>
		/// carriage requirement.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CarriageRequirement : InformationAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(CarriageRequirement);
		}

		/// <summary>
		/// Contact information of nautical product suppliers.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributionDetails : InformationAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(DistributionDetails);
		}

		/// <summary>
		/// Contact information of distributor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributorContact : InformationAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(DistributorContact);
		}

		/// <summary>
		/// price of element.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceOfElement : InformationAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(PriceOfElement);
		}

		/// <summary>
		/// The price of nautical product.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceOfNauticalProduct : InformationAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(PriceOfNauticalProduct);
		}

		/// <summary>
		/// Contact information of producer.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProducerContact : InformationAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(ProducerContact);
		}

		/// <summary>
		/// Contact information of nautical product publishing organizations.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductionDetails : InformationAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(ProductionDetails);
		}

		/// <summary>
		/// Package of the various substances which are transported, stored or exploited.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductPackage : InformationAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
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
			[IgnoreDataMember]
			public override string Code => nameof(ProductMapping);
		}

		/// <summary>
		/// A supplementary or secondary part of the product, which may appear multiple times, offering control or display functionalities depending on its configuration.
			
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Correlated : FeatureAssociation {
			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(Correlated);
		}
	}

}

namespace S100Framework.DomainModel.S128 {
	using ComplexAttributes;
	using InformationAssociations;

	namespace InformationTypes {
		/// <summary>
		/// catalogue section header.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CatalogueSectionHeader : InformationNode, IInformationBindingDefinition {
			[Required()]
			public int catalogueSectionNumber {get;set;}

			public String? catalogueSectionTitle {get;set;} = default;

			public information? information {get;set;} = default;

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(CatalogueSectionHeader);

			[JsonIgnore]
			[IgnoreDataMember]
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
		}

		/// <summary>
		/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContactDetails : InformationNode, IInformationBindingDefinition {
			public String contactInstructions {get;set;} = string.Empty;

			public List<contactAddress> contactAddress {get;set;} = [];

			public List<information> information {get;set;} = [];

			public List<onlineResource> onlineResource {get;set;} = [];

			public List<telecommunications> telecommunications {get;set;} = [];

			public List<sourceIndication> sourceIndication {get;set;} = [];

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(ContactDetails);

			[JsonIgnore]
			[IgnoreDataMember]
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
		}

		/// <summary>
		/// requirements for transportation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IndicationOfCarriageRequirement : InformationNode, IInformationBindingDefinition {
			public String? domesticCarriageRequirements {get;set;} = default;

			public String? internationalCarriageRequirements {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(IndicationOfCarriageRequirement);

			[JsonIgnore]
			[IgnoreDataMember]
			public override informationBindingDefinition[] informationBindingDefinitions => IndicationOfCarriageRequirement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}

		/// <summary>
		/// Pricing information of nautical product.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PriceInformation : InformationNode, IInformationBindingDefinition {
			public List<information> information {get;set;} = [];

			public List<onlineResource> onlineResource {get;set;} = [];

			public List<pricing> pricing {get;set;} = [];

			public List<sourceIndication> sourceIndication {get;set;} = [];

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(PriceInformation);

			[JsonIgnore]
			[IgnoreDataMember]
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
		}

		/// <summary>
		/// Information about the country of production.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProducerInformation : InformationNode, IInformationBindingDefinition {
			public String agencyResponsibleForProduction {get;set;} = string.Empty;

			public String? agencyName {get;set;} = default;

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(ProducerInformation);

			[JsonIgnore]
			[IgnoreDataMember]
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
		}

		/// <summary>
		/// distributor information.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistributorInformation : InformationNode, IInformationBindingDefinition {
			public String distributorName {get;set;} = string.Empty;

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(DistributorInformation);

			[JsonIgnore]
			[IgnoreDataMember]
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
		}
	}
	namespace FeatureTypes {
		using FeatureAssociations;
		using InformationTypes;

		/// <summary>
		/// catalogue of element.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class CatalogueElement : FeatureNode, IFeatureBindingDefinition {
			public String? agencyResponsibleForProduction {get;set;} = default;

			public List<catalogueElementClassification> catalogueElementClassification {get;set;} = [];

			public String? catalogueElementIdentifier {get;set;} = default;

			public String? classification {get;set;} = default;

			public List<IMOMaritimeService> IMOMaritimeService {get;set;} = [];

			[Required()]
			public Boolean notForNavigation {get;set;} = false;

			public List<featureName> featureName {get;set;} = [];

			public List<information> information {get;set;} = [];

			public onlineResource? onlineResource {get;set;} = default;

			public sourceIndication? sourceIndication {get;set;} = default;

			public List<supportFile> supportFile {get;set;} = [];

			public timeIntervalOfProduct? timeIntervalOfProduct {get;set;} = default;

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(CatalogueElement);

			[JsonIgnore]
			[IgnoreDataMember]
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
			[IgnoreDataMember]
			public override featureBindingDefinition[] featureBindingDefinitions => CatalogueElement._featureBindingDefinitions;

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
		}

		/// <summary>
		/// navigation products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class NavigationalProduct : CatalogueElement {
			public List<decimal> approximateGridResolution {get;set;} = [];

			public List<int> compilationScale {get;set;} = [];

			[EnumerationValue([1,2])]
			public distributionStatus? distributionStatus {get;set;} = default;

			public int? editionNumber {get;set;} = default;

			public int? maximumDisplayScale {get;set;} = default;

			public int? minimumDisplayScale {get;set;} = default;

			[EnumerationValue([1,2,3])]
			public List<navigationPurpose> navigationPurpose {get;set;} = [];

			public String? optimumDisplayScale {get;set;} = default;

			public String? originalProductNumber {get;set;} = default;

			public String? producerNation {get;set;} = default;

			public String? productNumber {get;set;} = default;

			[EnumerationValue([1,2,3,4,5,6])]
			public specificUsage? specificUsage {get;set;} = default;

			public DateOnly? updateDate {get;set;} = default;

			public int? updateNumber {get;set;} = default;

			public horizontalDatumEpsg? horizontalDatumEpsg {get;set;} = default;

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(NavigationalProduct);

			[JsonIgnore]
			[IgnoreDataMember]
			public override informationBindingDefinition[] informationBindingDefinitions => [..CatalogueElement._informationBindingDefinitions, ..NavigationalProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[IgnoreDataMember]
			public override featureBindingDefinition[] featureBindingDefinitions => [..CatalogueElement._featureBindingDefinitions, ..NavigationalProduct._featureBindingDefinitions];

			public override Primitives[] primitives => [..CatalogueElement._primitives, ..NavigationalProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(Correlated),
					role = Enum.GetName<Role>(Role.main)!,
					featureTypes = [nameof(NavigationalProduct)],
				},
			];
		}

		/// <summary>
		/// Electronic navigation product.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ElectronicProduct : NavigationalProduct {
			public Boolean? compressionFlag {get;set;} = default;

			public String? datasetName {get;set;} = default;

			[Required()]
			public DateOnly issueDate {get;set;}

			public TimeOnly? issueTime {get;set;} = default;

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Required()]
			public typeOfProductFormat typeOfProductFormat {get;set;}

			public productSpecification? productSpecification {get;set;} = default;

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(ElectronicProduct);

			[JsonIgnore]
			[IgnoreDataMember]
			public override informationBindingDefinition[] informationBindingDefinitions => [..NavigationalProduct._informationBindingDefinitions, ..ElectronicProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[IgnoreDataMember]
			public override featureBindingDefinition[] featureBindingDefinitions => [..NavigationalProduct._featureBindingDefinitions, ..ElectronicProduct._featureBindingDefinitions];

			public override Primitives[] primitives => [..NavigationalProduct._primitives, ..ElectronicProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// Paper navigation products.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalProduct : NavigationalProduct {
			[Required()]
			public DateOnly editionDate {get;set;}

			public String? isbn {get;set;} = default;

			public String? publicationNumber {get;set;} = default;

			public String? typeOfPaper {get;set;} = default;

			public printInformation? printInformation {get;set;} = default;

			public referenceToNM? referenceToNM {get;set;} = default;

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(PhysicalProduct);

			[JsonIgnore]
			[IgnoreDataMember]
			public override informationBindingDefinition[] informationBindingDefinitions => [..NavigationalProduct._informationBindingDefinitions, ..PhysicalProduct._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[IgnoreDataMember]
			public override featureBindingDefinition[] featureBindingDefinitions => [..NavigationalProduct._featureBindingDefinitions, ..PhysicalProduct._featureBindingDefinitions];

			public override Primitives[] primitives => [..NavigationalProduct._primitives, ..PhysicalProduct._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A service that makes use of S-100 based product specifications to support data transfer.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class S100Service : CatalogueElement {
			public Boolean? compressionFlag {get;set;} = default;

			public String? serviceName {get;set;} = default;

			[EnumerationValue([1,2,3,4])]
			public serviceStatus? serviceStatus {get;set;} = default;

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Required()]
			public typeOfProductFormat typeOfProductFormat {get;set;}

			public serviceSpecification? serviceSpecification {get;set;} = default;

			public productSpecification? productSpecification {get;set;} = default;

			[JsonIgnore]
			[IgnoreDataMember]
			public override string Code => nameof(S100Service);

			[JsonIgnore]
			[IgnoreDataMember]
			public override informationBindingDefinition[] informationBindingDefinitions => [..CatalogueElement._informationBindingDefinitions, ..S100Service._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[IgnoreDataMember]
			public override featureBindingDefinition[] featureBindingDefinitions => [..CatalogueElement._featureBindingDefinitions, ..S100Service._featureBindingDefinitions];

			public override Primitives[] primitives => [..CatalogueElement._primitives, ..S100Service._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}
	}
}

#pragma warning restore CS8981
