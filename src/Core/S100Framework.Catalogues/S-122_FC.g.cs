using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S122 {
	public static class Summary
	{
		public static Version Version => new Version("1.2.1");
		public static string[] ComplexTypes => ["bearingInformation","contactAddress","featureName","fixedDateRange","frequencyPair","graphic","information","onlineResource","orientation","periodicDateRange","rxNCode","scheduleByDayOfWeek","sectorLimit","sectorLimitOne","sectorLimitTwo","telecommunications","textContent","timeIntervalsByDayOfWeek","vesselsMeasurements","designation"];
		public static string[] InformationAssociationTypes => ["AssociatedRxN","ExceptionalWorkday","ProtectedAreaAuthority","ServiceControl","RelatedOrganisation","PermissionType","InclusionType","AuthorityContact","AuthorityHours","additionalInformation"];
		public static string[] FeatureAssociationTypes => [];
		public static string[] InformationTypes => ["InformationType","AbstractRxN","NauticalInformation","Regulations","Restrictions","Recommendations","Authority","ContactDetails","NonStandardWorkingDay","ServiceHours","Applicability"];
		public static string[] FeatureTypes => ["RestrictedArea","MarineProtectedArea","VesselTrafficServiceArea","DataCoverage","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType"],
			Primitives.surface => ["RestrictedArea","MarineProtectedArea","VesselTrafficServiceArea","DataCoverage"],
			Primitives.curve => ["MarineProtectedArea"],
			Primitives.point => ["TextPlacement"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"FeatureType" => [Primitives.noGeometry],
			"RestrictedArea" => [Primitives.surface],
			"MarineProtectedArea" => [Primitives.curve,Primitives.surface],
			"VesselTrafficServiceArea" => [Primitives.surface],
			"DataCoverage" => [Primitives.surface],
			"TextPlacement" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum cardinalDirection : int {
		[System.ComponentModel.Description("North")]
		[EnumMember(Value = "N")] 
		[XmlEnum("1")] 
		N = 1,

		[System.ComponentModel.Description("Northnortheast")]
		[EnumMember(Value = "NNE")] 
		[XmlEnum("2")] 
		Nne = 2,

		[System.ComponentModel.Description("Northeast")]
		[EnumMember(Value = "NE")] 
		[XmlEnum("3")] 
		Ne = 3,

		[System.ComponentModel.Description("Eastnortheast")]
		[EnumMember(Value = "ENE")] 
		[XmlEnum("4")] 
		Ene = 4,

		[System.ComponentModel.Description("East")]
		[EnumMember(Value = "E")] 
		[XmlEnum("5")] 
		E = 5,

		[System.ComponentModel.Description("Eastsoutheast")]
		[EnumMember(Value = "ESE")] 
		[XmlEnum("6")] 
		Ese = 6,

		[System.ComponentModel.Description("Southeast")]
		[EnumMember(Value = "SE")] 
		[XmlEnum("7")] 
		Se = 7,

		[System.ComponentModel.Description("Southsoutheast")]
		[EnumMember(Value = "SSE")] 
		[XmlEnum("8")] 
		Sse = 8,

		[System.ComponentModel.Description("South")]
		[EnumMember(Value = "S")] 
		[XmlEnum("9")] 
		S = 9,

		[System.ComponentModel.Description("Southsouthwest")]
		[EnumMember(Value = "SSW")] 
		[XmlEnum("10")] 
		Ssw = 10,

		[System.ComponentModel.Description("Southwest")]
		[EnumMember(Value = "SW")] 
		[XmlEnum("11")] 
		Sw = 11,

		[System.ComponentModel.Description("Westsouthwest")]
		[EnumMember(Value = "WSW")] 
		[XmlEnum("12")] 
		Wsw = 12,

		[System.ComponentModel.Description("West")]
		[EnumMember(Value = "W")] 
		[XmlEnum("13")] 
		W = 13,

		[System.ComponentModel.Description("Westnorthwest")]
		[EnumMember(Value = "WNW")] 
		[XmlEnum("14")] 
		Wnw = 14,

		[System.ComponentModel.Description("Northwest")]
		[EnumMember(Value = "NW")] 
		[XmlEnum("15")] 
		Nw = 15,

		[System.ComponentModel.Description("Northnorthwest")]
		[EnumMember(Value = "NNW")] 
		[XmlEnum("16")] 
		Nnw = 16,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum onlineFunction : int {
		[System.ComponentModel.Description("OnlineInstructionsForTransferringDataFromOneStorageDeviceOrSystemToAnotherIso191152014")]
		[EnumMember(Value = "Download")] 
		[XmlEnum("1")] 
		Download = 1,

		[System.ComponentModel.Description("OnlineInformationAboutTheResourceIso191152014")]
		[EnumMember(Value = "Information")] 
		[XmlEnum("2")] 
		Information = 2,

		[System.ComponentModel.Description("OnlineInstructionsForRequestingTheResourceFromTheProviderIso191152014")]
		[EnumMember(Value = "Offline Access")] 
		[XmlEnum("3")] 
		OfflineAccess = 3,

		[System.ComponentModel.Description("OnlineOrderProcessForObtainingTheResourceIso191152014")]
		[EnumMember(Value = "Order")] 
		[XmlEnum("4")] 
		Order = 4,

		[System.ComponentModel.Description("OnlineSearchInterfaceForSeekingOutInformationAboutTheResourceIso191152014")]
		[EnumMember(Value = "Search")] 
		[XmlEnum("5")] 
		Search = 5,

		[System.ComponentModel.Description("CompleteMetadataProvidedIso191152014")]
		[EnumMember(Value = "Complete Metadata")] 
		[XmlEnum("6")] 
		CompleteMetadata = 6,

		[System.ComponentModel.Description("BrowseGraphicProvidedIso191152014")]
		[EnumMember(Value = "Browse Graphic")] 
		[XmlEnum("7")] 
		BrowseGraphic = 7,

		[System.ComponentModel.Description("OnlineResourceUploadCapabilityProvidedIso191152014")]
		[EnumMember(Value = "Upload")] 
		[XmlEnum("8")] 
		Upload = 8,

		[System.ComponentModel.Description("OnlineEmailServiceProvidedIso191152014")]
		[EnumMember(Value = "Email Service")] 
		[XmlEnum("9")] 
		EmailService = 9,

		[System.ComponentModel.Description("OnlineBrowsingProvidedIso191152014")]
		[EnumMember(Value = "Browsing")] 
		[XmlEnum("10")] 
		Browsing = 10,

		[System.ComponentModel.Description("OnlineFileAccessProvidedIso191152014")]
		[EnumMember(Value = "File Access")] 
		[XmlEnum("11")] 
		FileAccess = 11,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristics : int {
		[System.ComponentModel.Description("TheMaximumLengthOfTheShipLOAHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Length Overall")] 
		[XmlEnum("1")] 
		LengthOverall = 1,

		[System.ComponentModel.Description("TheShipSLengthMeasuredAtTheWaterlineLWLHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Length at waterline")] 
		[XmlEnum("2")] 
		LengthAtWaterline = 2,

		[System.ComponentModel.Description("TheWidthOrBeamOfTheVesselAdaptedFromHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Breadth")] 
		[XmlEnum("3")] 
		Breadth = 3,

		[System.ComponentModel.Description("TheDepthOfWaterNecessaryToFloatAVesselFullyLoadedHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Draught")] 
		[XmlEnum("4")] 
		Draught = 4,

		[System.ComponentModel.Description("TheHeightOfTheHighestPointOfAVesselSStructureEGRadarAerialFunnelCranesMastheadAboveHerWaterlineUkhoNp1002009")]
		[EnumMember(Value = "Height")] 
		[XmlEnum("5")] 
		Height = 5,

		[System.ComponentModel.Description("AMeasurementOfTheWeightOfTheVesselUsuallyUsedForWarshipsMerchantShipsAreUsuallyMeasuredBasedOnTheVolumeOfCargoSpaceSeeTonnageDisplacementIsExpressedEitherInLongTonsOf2240PoundsOrMetricTonnesOf1000KgSinceTheTwoUnitsAreVeryCloseInSize2240Pounds1016KgAnd1000Kg2205PoundsItIsCommonNotToDistinguishBetweenThemToPreserveSecrecyNationsSometimesMisstateAWarshipSDisplacementHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Displacement Tonnage")] 
		[XmlEnum("6")] 
		DisplacementTonnage = 6,

		[System.ComponentModel.Description("TheWeightOfTheShipExcludingCargoFuelBallastStoresPassengersAndCrewButWithWaterInTheBoilersToSteamingLevelHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Displacement Tonnage, Light")] 
		[XmlEnum("7")] 
		DisplacementTonnageLight = 7,

		[System.ComponentModel.Description("TheWeightOfTheShipIncludingCargoPassengersFuelWaterStoresDunnageAndSuchOtherItemsNecessaryForUseOnAVoyageWhichBringsTheVesselDownToHerLoadDraftHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Displacement Tonnage, Loaded")] 
		[XmlEnum("8")] 
		DisplacementTonnageLoaded = 8,

		[System.ComponentModel.Description("TheDifferenceBetweenDisplacementLightAndDisplacementLoadedAMeasureOfTheShipSTotalCarryingCapacityHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Deadweight Tonnage")] 
		[XmlEnum("9")] 
		DeadweightTonnage = 9,

		[System.ComponentModel.Description("TheEntireInternalCubicCapacityOfTheShipExpressedInTonsOf100CubicFeetToTheTonExceptCertainSpacesWithAreExemptedSuchAsPeakAndOtherTanksForWaterBallastOpenForecastleBridgeAndPoopAccessOfHatchwaysCertainLightAndAirSpacesDomesOfSkylightsCondenserAnchorGearSteeringGearWheelHouseGalleyAndCabinForPassengersHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Gross Tonnage")] 
		[XmlEnum("10")] 
		GrossTonnage = 10,

		[System.ComponentModel.Description("ObtainedFromTheGrossTonnageByDeductingCrewAndNavigatingSpacesAndAllowancesForPropulsionMachineryHttpEnWikipediaOrgWikiShip_measurements24July2010")]
		[EnumMember(Value = "Panama Canal/Universal Measurement System Net")] 
		[XmlEnum("11")] 
		PanamaCanalUniversalMeasurementSystemNet = 11,

		[System.ComponentModel.Description("ThePanamaCanalUniversalMeasurementSystemPcUmsIsBasedOnNetTonnageModifiedForPanamaCanalPurposesPcUmsIsBasedOnAMathematicalFormulaToCalculateAVesselSTotalVolumeAPcUmsNetTonIsEquivalentTo100CubicFeetOfCapacityAdaptedFromHttpEnWikipediaOrgWikiTonnage4Oct2010")]
		[EnumMember(Value = "Tonnage")] 
		[XmlEnum("12")] 
		Tonnage = 12,

		[System.ComponentModel.Description("TheSuezCanalNetTonnageScntIsDerivedWithANumberOfModificationsFromTheFormerNetRegisterTonnageOfTheMoorsomSystemAndWasEstablishedByTheInternationalCommissionOfConstantinopleInItsProtocolOf18December1873ItIsStillInUseAsAmendedByTheRulesOfNavigationOfTheSuezCanalAuthorityAndIsRegisteredInTheSuezCanalTonnageCertificateAdaptedFromHttpEnWikipediaOrgWikiTonnage4Oct2010")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("13")] 
		SuezCanalNetTonnage = 13,

		[System.ComponentModel.Description("SuezCanalGrossTonnageScgtIsDerivedWithANumberOfModificationsFromTheFormerNetRegisterTonnageOfTheMoorsomSystemAndWasEstablishedByTheInternationalCommissionOfConstantinopleInItsProtocolOf18December1873ItIsStillInUseAsAmendedByTheRulesOfNavigationOfTheSuezCanalAuthorityAndIsRegisteredInTheSuezCanalTonnageCertificate")]
		[EnumMember(Value = "Suez Canal Gross Tonnage")] 
		[XmlEnum("14")] 
		SuezCanalGrossTonnage = 14,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum vesselsCharacteristicsUnit : int {
		[System.ComponentModel.Description("TheMetreOrMeterIsTheBaseUnitOfLengthInTheInternationalSystemOfUnitsSiItIsDefinedAsTheDistanceTravelledByLightInVacuumIn1299792458OfASecond")]
		[EnumMember(Value = "Metre")] 
		[XmlEnum("1")] 
		Metre = 1,

		[System.ComponentModel.Description("AFootPluralFeetIsANonSiUnitOfLengthInANumberOfDifferentSystemsIncludingEnglishUnitsImperialUnitsAndUnitedStatesCustomaryUnitsTheMostCommonlyUsedFootTodayIsTheInternationalFootThereAreThreeFeetInAYardAnd12InchesInAFoot")]
		[EnumMember(Value = "Foot")] 
		[XmlEnum("2")] 
		Foot = 2,

		[System.ComponentModel.Description("TheTonneOrMetricTonUSOftenRedundantlyReferredToAsAMetricTonneIsAUnitOfMassEqualTo1000Kg2205LbOrApproximatelyTheMassOfOneCubicMetreOfWaterAtFourDegreesCelsiusItIsSometimesAbbreviatedAsMtInTheUnitedStatesButThisConflictsWithOtherSiSymbolsTheTonneIsNotAUnitInTheInternationalSystemOfUnitsSiButIsAcceptedForUseWithTheSiInSiUnitsAndPrefixesTheTonneIsAMegagramMgTheImperialAndUsCustomaryUnitsComparableToTheTonneAreBothSpelledTonInEnglishThoughTheyDifferInMassPronunciationOfTonneTheWordUsedInTheUkAndTonIsUsuallyIdenticalButIsNotTooConfusingUnlessAccuracyIsImportantAsTheTonneAndUkLongTonDifferByOnly16")]
		[EnumMember(Value = "Metric Ton")] 
		[XmlEnum("3")] 
		MetricTon = 3,

		[System.ComponentModel.Description("LongTonWeightTonOrImperialTonIsTheNameForTheUnitCalledTheTonInTheAvoirdupoisOrImperialSystemOfMeasurementsAsUsedInTheUnitedKingdomAndSeveralOtherCommonwealthCountriesItHasBeenMostlyReplacedByTheTonneAndInTheUnitedStatesByTheShortTonOneLongTonIsEqualTo2240Pounds1016KgOr35CubicFeet09911M3OfSaltWaterWithADensityOf64LbFt1025GMlItHasSomeLimitedUseInTheUnitedStatesMostCommonlyInMeasuringTheDisplacementOfShipsAndWasTheUnitPrescribedForWarshipsByTheWashingtonNavalTreatyForExampleBattleshipsWereLimitedToAMassOf35000LongTons36000T39000St")]
		[EnumMember(Value = "Ton")] 
		[XmlEnum("4")] 
		Ton = 4,

		[System.ComponentModel.Description("TheShortTonIsAUnitOfWeightEqualTo2000Pounds90718474KgInTheUnitedStatesItIsOftenCalledSimplyTonWithoutDistinguishingItFromTheMetricTonTonne1000KilogramsOrTheLongTon2240Pounds10160469088KilogramsRatherTheOtherTwoAreSpecificallyNotedThereAreHoweverSomeUSApplicationsForWhichUnspecifiedTonsNormallyMeansLongTonsForExampleNavyShipsOrMetricTonsWorldGrainProductionFiguresBothTheLongAndShortTonAreDefinedAs20HundredweightsButAHundredweightIs100Pounds45359237KgInTheUSSystemShortOrNetHundredweightAnd112Pounds5080234544KgInTheImperialSystemLongOrGrossHundredweight")]
		[EnumMember(Value = "Short Ton")] 
		[XmlEnum("5")] 
		ShortTon = 5,

		[System.ComponentModel.Description("GrossTonnageGtIsAFunctionOfTheVolumeOfAllShipSEnclosedSpacesFromKeelToFunnelMeasuredToTheOutsideOfTheHullFramingThereIsASlidingScaleFactorSoGtIsAKindOfCapacityDerivedIndexThatIsUsedToRankAShipForPurposesOfDeterminingManningSafetyAndOtherStatutoryRequirementsAndIsExpressedSimplyAsGtWhichIsAUnitlessEntityEvenThoughItsDerivationIsTiedToTheCubicMeterUnitOfVolumetricCapacityTonnageMeasurementsAreNowGovernedByAnImoConventionInternationalConventionOnTonnageMeasurementOfShips1969LondonRulesWhichAppliesToAllShipsBuiltAfterJuly1982InAccordanceWithTheConventionTheCorrectTermToUseNowIsGtWhichIsAFunctionOfTheMouldedVolumeOfAllEnclosedSpacesOfTheShip")]
		[EnumMember(Value = "Gross ton")] 
		[XmlEnum("6")] 
		GrossTon = 6,

		[System.ComponentModel.Description("NetTonnageNtIsBasedOnACalculationOfTheVolumeOfAllCargoSpacesOfTheShipItIndicatesAVesselSEarningSpaceAndIsAFunctionOfTheMouldedVolumeOfAllCargoSpacesOfTheShip")]
		[EnumMember(Value = "Net Ton")] 
		[XmlEnum("7")] 
		NetTon = 7,

		[System.ComponentModel.Description("ThePanamaCanalUniversalMeasurementSystemPcUmsIsBasedOnNetTonnageModifiedForPanamaCanalPurposesPcUmsIsBasedOnAMathematicalFormulaToCalculateAVesselSTotalVolumeAPcUmsNetTonIsEquivalentTo100CubicFeetOfCapacity")]
		[EnumMember(Value = "Panama Canal/Universal Measurement System Net Tonnage")] 
		[XmlEnum("8")] 
		PanamaCanalUniversalMeasurementSystemNetTonnage = 8,

		[System.ComponentModel.Description("TheSuezCanalNetTonnageScntIsDerivedWithANumberOfModificationsFromTheFormerNetRegisterTonnageOfTheMoorsomSystemAndWasEstablishedByTheInternationalCommissionOfConstantinopleInItsProtocolOf18December1873ItIsStillInUseAsAmendedByTheRulesOfNavigationOfTheSuezCanalAuthorityAndIsRegisteredInTheSuezCanalTonnageCertificate")]
		[EnumMember(Value = "Suez Canal Net Tonnage")] 
		[XmlEnum("9")] 
		SuezCanalNetTonnage = 9,

		[System.ComponentModel.Description("CanBeUsedForNetAndGrossTonnagesIncludingPanamaCanalUniversalMeasurementSystemNetTonnageAndTheSuezCanalNetTonnage")]
		[EnumMember(Value = "None")] 
		[XmlEnum("10")] 
		None = 10,

		[System.ComponentModel.Description("CubicMetres")]
		[EnumMember(Value = "Cubic Metres")] 
		[XmlEnum("11")] 
		CubicMetres = 11,

		[System.ComponentModel.Description("TheSuezCanalGrossTonnageScgtIsDerivedWithANumberOfModificationsFromTheFormerNetRegisterTonnageOfTheMoorsomSystemAndWasEstablishedByTheInternationalCommissionOfConstantinopleInItsProtocolOf18December1873ItIsStillInUseAsAmendedByTheRulesOfNavigationOfTheSuezCanalAuthorityAndIsRegisteredInTheSuezCanalTonnageCertificate")]
		[EnumMember(Value = "Suez Canal Gross Tonnage")] 
		[XmlEnum("12")] 
		SuezCanalGrossTonnage = 12,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum comparisonOperator : int {
		[System.ComponentModel.Description("TheValueOfTheLeftValueIsGreaterThanThatOfTheRightHttpEnWikipediaOrgWikiLogical_connective")]
		[EnumMember(Value = "Greater than")] 
		[XmlEnum("1")] 
		GreaterThan = 1,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsGreaterThanOrEqualToThatOfTheRightHttpEnWikipediaOrgWikiLogical_connective")]
		[EnumMember(Value = "Greater than or equal to")] 
		[XmlEnum("2")] 
		GreaterThanOrEqualTo = 2,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanThatOfTheRightHttpEnWikipediaOrgWikiLogical_connective")]
		[EnumMember(Value = "Less than")] 
		[XmlEnum("3")] 
		LessThan = 3,

		[System.ComponentModel.Description("TheValueOfTheLeftExpressionIsLessThanOrEqualToThatOfTheRightHttpEnWikipediaOrgWikiLogical_connective")]
		[EnumMember(Value = "Less than or equal to")] 
		[XmlEnum("4")] 
		LessThanOrEqualTo = 4,

		[System.ComponentModel.Description("TheTwoValuesAreEquivalentAdaptedHttpEnWikipediaOrgWikiLogical_connective")]
		[EnumMember(Value = "Equal to")] 
		[XmlEnum("5")] 
		EqualTo = 5,

		[System.ComponentModel.Description("TheTwoValuesAreNotEquivalentAdaptedHttpEnWikipediaOrgWikiLogical_connective")]
		[EnumMember(Value = "Not equal to")] 
		[XmlEnum("6")] 
		NotEqualTo = 6,
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
	public enum membership : int {
		[System.ComponentModel.Description("VesselsWithTheseCharacteristicsAreIncludedInTheRegulationRestrictionRecommendationNauticalInformation")]
		[EnumMember(Value = "included")] 
		[XmlEnum("1")] 
		Included = 1,

		[System.ComponentModel.Description("VesselsWithTheseCharacteristicsAreExcludedFromTheRegulationRestrictionRecommendationNauticalInformation")]
		[EnumMember(Value = "excluded")] 
		[XmlEnum("2")] 
		Excluded = 2,
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
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("UnpackedHomogenousCargoPouredLooseInACertainSpaceOfAVesselEGOilOrGrain")]
		[EnumMember(Value = "Bulk")] 
		[XmlEnum("1")] 
		Bulk = 1,

		[System.ComponentModel.Description("OneOfANumberOfStandardSizedCargoCarryingUnitsSecuredUsingStandardCornerAttachmentsAndBar")]
		[EnumMember(Value = "Container")] 
		[XmlEnum("2")] 
		Container = 2,

		[System.ComponentModel.Description("BreakBulkCargoNormallyLoadedByCrane")]
		[EnumMember(Value = "General")] 
		[XmlEnum("3")] 
		General = 3,

		[System.ComponentModel.Description("AnyCargoLoadedByPipeline")]
		[EnumMember(Value = "Liquid")] 
		[XmlEnum("4")] 
		Liquid = 4,

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

		[System.ComponentModel.Description("MaterialCarriedByAShipToEnsureItsStability")]
		[EnumMember(Value = "Ballast")] 
		[XmlEnum("9")] 
		Ballast = 9,
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
	public enum categoryOfVesselTrafficService : int {
		[System.ComponentModel.Description("AServiceToEnsureThatEssentialInformationBecomesAvailableInTimeForOnBoardNavigationalDecisionMaking")]
		[EnumMember(Value = "Information Service")] 
		[XmlEnum("1")] 
		InformationService = 1,

		[System.ComponentModel.Description("AServiceToAssistOnBoardNavigationalDecisionMakingAndToMonitorItsEffects")]
		[EnumMember(Value = "Traffic Organization Service")] 
		[XmlEnum("2")] 
		TrafficOrganizationService = 2,

		[System.ComponentModel.Description("AServiceToPreventTheDevelopmentOfDangerousMaritimeTrafficSituationsAndToProvideForTheSafeAndEfficientMovementOfVesselTrafficWithinTheVtsArea")]
		[EnumMember(Value = "Navigational Assistance Service")] 
		[XmlEnum("3")] 
		NavigationalAssistanceService = 3,

		[System.ComponentModel.Description("AServiceEstablishedByARelevantAuthorityConsistingOfOneOrMoreReportingPointsOrLinesAtWhichShipsAreRequiredToReportTheirIdentityCourseSpeedAndOtherDataToTheMonitoringAuthority")]
		[EnumMember(Value = "Ship Reporting Service")] 
		[XmlEnum("4")] 
		ShipReportingService = 4,

		[System.ComponentModel.Description("AServiceEstablishedToProvidePortInformationWithoutInteractionBetweenTheCustomerAndTheServiceProviderThisInformationCouldBeInterAliaBerthingInformationAvailabilityOfPortServicesShippingSchedulesMeteorologicalAndHydrologicalData")]
		[EnumMember(Value = "Local Port Service")] 
		[XmlEnum("5")] 
		LocalPortService = 5,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum status : int {
		[System.ComponentModel.Description("IntendedToLastOrFunctionIndefinitely")]
		[EnumMember(Value = "Permanent")] 
		[XmlEnum("1")] 
		Permanent = 1,

		[System.ComponentModel.Description("ActingOnSpecialOccasionsHappeningIrregularly")]
		[EnumMember(Value = "Occasional")] 
		[XmlEnum("2")] 
		Occasional = 2,

		[System.ComponentModel.Description("PresentedAsWorthyOfConfidenceAcceptanceUseEtc")]
		[EnumMember(Value = "Recommended")] 
		[XmlEnum("3")] 
		Recommended = 3,

		[System.ComponentModel.Description("UseHasCeasedButTheFacilityStillExistsIntactDisused")]
		[EnumMember(Value = "Not in Use")] 
		[XmlEnum("4")] 
		NotInUse = 4,

		[System.ComponentModel.Description("RecurringAtIntervals")]
		[EnumMember(Value = "Periodic/Intermittent")] 
		[XmlEnum("5")] 
		PeriodicIntermittent = 5,

		[System.ComponentModel.Description("SetApartForSomeSpecificUse")]
		[EnumMember(Value = "Reserved")] 
		[XmlEnum("6")] 
		Reserved = 6,

		[System.ComponentModel.Description("MeantToLastOnlyForATime")]
		[EnumMember(Value = "Temporary")] 
		[XmlEnum("7")] 
		Temporary = 7,

		[System.ComponentModel.Description("AdministeredByAnIndividualOrCorporationRatherThanAStateOrAPublicBody")]
		[EnumMember(Value = "Private")] 
		[XmlEnum("8")] 
		Private = 8,

		[System.ComponentModel.Description("CompulsoryEnforced")]
		[EnumMember(Value = "Mandatory")] 
		[XmlEnum("9")] 
		Mandatory = 9,

		[System.ComponentModel.Description("NoLongerLit")]
		[EnumMember(Value = "Extinguished")] 
		[XmlEnum("11")] 
		Extinguished = 11,

		[System.ComponentModel.Description("LitByFloodlightsStripLightsEtc")]
		[EnumMember(Value = "Illuminated")] 
		[XmlEnum("12")] 
		Illuminated = 12,

		[System.ComponentModel.Description("FamousInHistoryOfHistoricalInterest")]
		[EnumMember(Value = "Historic")] 
		[XmlEnum("13")] 
		Historic = 13,

		[System.ComponentModel.Description("BelongingToAvailableToUsedOrSharedByTheCommunityAsAWholeAndNotRestrictedToPrivateUse")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("14")] 
		Public = 14,

		[System.ComponentModel.Description("OccurAtATimeCoincideInPointOfTimeBeContemporaryOrSimultaneous")]
		[EnumMember(Value = "Synchronized")] 
		[XmlEnum("15")] 
		Synchronized = 15,

		[System.ComponentModel.Description("LookedAtOrObservedOverAPeriodOfTimeEspeciallySoAsToBeAwareOfAnyMovementOrChange")]
		[EnumMember(Value = "Watched")] 
		[XmlEnum("16")] 
		Watched = 16,

		[System.ComponentModel.Description("UsuallyAutomaticInOperationWithoutAnyPermanentlyStationedPersonnelToSuperintendIt")]
		[EnumMember(Value = "Unwatched")] 
		[XmlEnum("17")] 
		Unwatched = 17,

		[System.ComponentModel.Description("AFeatureThatHasBeenReportedButHasNotBeenDefinitelyDeterminedToExist")]
		[EnumMember(Value = "Existence Doubtful")] 
		[XmlEnum("18")] 
		ExistenceDoubtful = 18,

		[System.ComponentModel.Description("WhenYouAskForIt")]
		[EnumMember(Value = "On Request")] 
		[XmlEnum("19")] 
		OnRequest = 19,

		[System.ComponentModel.Description("ToBecomeLowerInLevel")]
		[EnumMember(Value = "Drop Away")] 
		[XmlEnum("20")] 
		DropAway = 20,

		[System.ComponentModel.Description("ToBecomeHigherInLevel")]
		[EnumMember(Value = "Rising")] 
		[XmlEnum("21")] 
		Rising = 21,

		[System.ComponentModel.Description("BecomingLargerInMagnitude")]
		[EnumMember(Value = "Increasing")] 
		[XmlEnum("22")] 
		Increasing = 22,

		[System.ComponentModel.Description("BecomingSmallerInMagnitude")]
		[EnumMember(Value = "Decreasing")] 
		[XmlEnum("23")] 
		Decreasing = 23,

		[System.ComponentModel.Description("NotEasilyBrokenOrDestroyed")]
		[EnumMember(Value = "Strong")] 
		[XmlEnum("24")] 
		Strong = 24,

		[System.ComponentModel.Description("InASatisfactoryConditionToUse")]
		[EnumMember(Value = "Good")] 
		[XmlEnum("25")] 
		Good = 25,

		[System.ComponentModel.Description("FairlyButNotVery")]
		[EnumMember(Value = "Moderately")] 
		[XmlEnum("26")] 
		Moderately = 26,

		[System.ComponentModel.Description("NotAsGoodAsItCouldBeOrShould")]
		[EnumMember(Value = "Poor")] 
		[XmlEnum("27")] 
		Poor = 27,

		[System.ComponentModel.Description("MarkedByBuoys")]
		[EnumMember(Value = "Buoyed")] 
		[XmlEnum("28")] 
		Buoyed = 28,

		[System.ComponentModel.Description("EntireObservationPlatformIsOperatingInAccordanceWithOrExceedingManufacturerSpecifications")]
		[EnumMember(Value = "Fully Operational")] 
		[XmlEnum("29")] 
		FullyOperational = 29,

		[System.ComponentModel.Description("AtLeastOneInstrumentThatIsPartOfAnObservationPlatformIsNotOperatingToManufacturerSpecification")]
		[EnumMember(Value = "Partially Operational")] 
		[XmlEnum("30")] 
		PartiallyOperational = 30,

		[System.ComponentModel.Description("FloatingPlatformAtTheMercyOfEnvironmentalElementsWhetherIntentionalOrNot")]
		[EnumMember(Value = "Drifting")] 
		[XmlEnum("31")] 
		Drifting = 31,

		[System.ComponentModel.Description("FracturedOrInPieces")]
		[EnumMember(Value = "Broken")] 
		[XmlEnum("32")] 
		Broken = 32,

		[System.ComponentModel.Description("ObservationPlatformIsIntentionallyNotReportingAnEnvironmentalObservation")]
		[EnumMember(Value = "Offline")] 
		[XmlEnum("33")] 
		Offline = 33,

		[System.ComponentModel.Description("ObservationStationSuiteOfInstrumentsOrAnIndividualInstrumentForAParticularLocationHasBeenRemovedAndIsNoLongerAtTheParticularLocation")]
		[EnumMember(Value = "Discontinued")] 
		[XmlEnum("34")] 
		Discontinued = 34,

		[System.ComponentModel.Description("ObservationsMadeByAHumanObserver")]
		[EnumMember(Value = "Manual Observation")] 
		[XmlEnum("35")] 
		ManualObservation = 35,

		[System.ComponentModel.Description("StatusOfAnObservationPlatformSuiteOfInstrumentsOrIndividualInstrumentIsNotKnownOrUnspecified")]
		[EnumMember(Value = "Unknown Status")] 
		[XmlEnum("36")] 
		UnknownStatus = 36,

		[System.ComponentModel.Description("MadeCertainAsToTruthAccuracyValidityAvailabilityEtc")]
		[EnumMember(Value = "Confirmed")] 
		[XmlEnum("37")] 
		Confirmed = 37,

		[System.ComponentModel.Description("ItemSelectedForAnAction")]
		[EnumMember(Value = "Candidate")] 
		[XmlEnum("38")] 
		Candidate = 38,

		[System.ComponentModel.Description("ItemThatIsInTheProcessOfBeingModified")]
		[EnumMember(Value = "Under Modification")] 
		[XmlEnum("39")] 
		UnderModification = 39,

		[System.ComponentModel.Description("ItemInTheProcessOfBeingRemovedOrDeleted")]
		[EnumMember(Value = "Under Removal / Deletion")] 
		[XmlEnum("41")] 
		UnderRemovalDeletion = 41,

		[System.ComponentModel.Description("ItemThatHasBeenRemovedOrDeleted")]
		[EnumMember(Value = "Removed / Deleted")] 
		[XmlEnum("42")] 
		RemovedDeleted = 42,

		[System.ComponentModel.Description("ItemSelectedForModification")]
		[EnumMember(Value = "Candidate for Modification")] 
		[XmlEnum("43")] 
		CandidateForModification = 43,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum restriction : int {
		[System.ComponentModel.Description("AnAreaWithinWhichAnchoringIsNotPermitted")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		[XmlEnum("1")] 
		AnchoringProhibited = 1,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichAnchoringIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Anchoring Restricted")] 
		[XmlEnum("2")] 
		AnchoringRestricted = 2,

		[System.ComponentModel.Description("AnAreaWithinWhichFishingIsNotPermitted")]
		[EnumMember(Value = "Fishing Prohibited")] 
		[XmlEnum("3")] 
		FishingProhibited = 3,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichFishingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Fishing Restricted")] 
		[XmlEnum("4")] 
		FishingRestricted = 4,

		[System.ComponentModel.Description("AnAreaWithinWhichTrawlingIsNotPermitted")]
		[EnumMember(Value = "Trawling Prohibited")] 
		[XmlEnum("5")] 
		TrawlingProhibited = 5,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichTrawlingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Trawling Restricted")] 
		[XmlEnum("6")] 
		TrawlingRestricted = 6,

		[System.ComponentModel.Description("AnAreaWithinWhichNavigationAndOrAnchoringIsProhibited")]
		[EnumMember(Value = "Entry Prohibited")] 
		[XmlEnum("7")] 
		EntryProhibited = 7,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichNavigationIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Entry Restricted")] 
		[XmlEnum("8")] 
		EntryRestricted = 8,

		[System.ComponentModel.Description("AnAreaWithinWhichDredgingIsNotPermitted")]
		[EnumMember(Value = "Dredging Prohibited")] 
		[XmlEnum("9")] 
		DredgingProhibited = 9,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichDredgingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Dredging Restricted")] 
		[XmlEnum("10")] 
		DredgingRestricted = 10,

		[System.ComponentModel.Description("AnAreaWithinWhichDivingIsNotPermitted")]
		[EnumMember(Value = "Diving Prohibited")] 
		[XmlEnum("11")] 
		DivingProhibited = 11,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichDivingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Diving Restricted")] 
		[XmlEnum("12")] 
		DivingRestricted = 12,

		[System.ComponentModel.Description("MarinersMustAdjustTheSpeedOfTheirVesselsToReduceTheWaveOrWashWhichMayCauseErosionOrDisturbMooredVessels")]
		[EnumMember(Value = "No Wake")] 
		[XmlEnum("13")] 
		NoWake = 13,

		[System.ComponentModel.Description("AnImoDeclaredRouteingMeasureComprisingAnAreaWithinDefinedLimitsInWhichEitherNavigationIsParticularlyHazardousOrItIsExceptionallyImportantToAvoidCasualtiesAndWhichShouldBeAvoidedByAllShipsOrCertainClassesOfShips")]
		[EnumMember(Value = "Area To Be Avoided")] 
		[XmlEnum("14")] 
		AreaToBeAvoided = 14,

		[System.ComponentModel.Description("TheErectionOfPermanentOrTemporaryFixedStructuresOrArtificialIslandsIsProhibited")]
		[EnumMember(Value = "Construction Prohibited")] 
		[XmlEnum("15")] 
		ConstructionProhibited = 15,

		[System.ComponentModel.Description("AnAreaWithinWhichDischargingOrDumpingIsProhibited")]
		[EnumMember(Value = "Discharging Prohibited")] 
		[XmlEnum("16")] 
		DischargingProhibited = 16,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichDischargingOrDumpingIsRestrictedInAccordanceWithSpecifiedConditions")]
		[EnumMember(Value = "Discharging Restricted")] 
		[XmlEnum("17")] 
		DischargingRestricted = 17,

		[System.ComponentModel.Description("AnAreaWithinWhichIndustrialOrMineralExplorationAndDevelopmentAreProhibited")]
		[EnumMember(Value = "Industrial or Mineral Exploration/Development Prohibited")] 
		[XmlEnum("18")] 
		IndustrialOrMineralExplorationDevelopmentProhibited = 18,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichIndustrialOrMineralExplorationAndDevelopmentIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Industrial or Mineral Exploration/Development Restricted")] 
		[XmlEnum("19")] 
		IndustrialOrMineralExplorationDevelopmentRestricted = 19,

		[System.ComponentModel.Description("AnAreaWithinWhichExcavatingAHoleOnTheSeaBottomWithADrillIsProhibited")]
		[EnumMember(Value = "Drilling Prohibited")] 
		[XmlEnum("20")] 
		DrillingProhibited = 20,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichExcavatingAHoleOnTheSeaBottomWithADrillIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Drilling Restricted")] 
		[XmlEnum("21")] 
		DrillingRestricted = 21,

		[System.ComponentModel.Description("AnAreaWithinWhichTheRemovalOfHistoricalArtefactsIsProhibited")]
		[EnumMember(Value = "Removal of Historical Artefacts Prohibited")] 
		[XmlEnum("22")] 
		RemovalOfHistoricalArtefactsProhibited = 22,

		[System.ComponentModel.Description("AnAreaInWhichCargoTranshipmentLighteningIsProhibited")]
		[EnumMember(Value = "Cargo Transhipment (Lightening) Prohibited")] 
		[XmlEnum("23")] 
		CargoTranshipmentLighteningProhibited = 23,

		[System.ComponentModel.Description("AnAreaInWhichTheDraggingOfAnythingAlongTheBottomEGBottomTrawlingIsProhibited")]
		[EnumMember(Value = "Dragging Prohibited")] 
		[XmlEnum("24")] 
		DraggingProhibited = 24,

		[System.ComponentModel.Description("AnAreaInWhichAVesselIsProhibitedFromStopping")]
		[EnumMember(Value = "Stopping Prohibited")] 
		[XmlEnum("25")] 
		StoppingProhibited = 25,

		[System.ComponentModel.Description("AnAreaInWhichLandingIsProhibited")]
		[EnumMember(Value = "Landing Prohibited")] 
		[XmlEnum("26")] 
		LandingProhibited = 26,

		[System.ComponentModel.Description("AnAreaWithinWhichSpeedIsRestricted")]
		[EnumMember(Value = "Speed Restricted")] 
		[XmlEnum("27")] 
		SpeedRestricted = 27,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichOvertakingIsGenerallyProhibited")]
		[EnumMember(Value = "Overtaking Prohibited")] 
		[XmlEnum("28")] 
		OvertakingProhibited = 28,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichOvertakingBetweenConvoysIsProhibited")]
		[EnumMember(Value = "Overtaking of Convoys by Convoys Prohibited")] 
		[XmlEnum("29")] 
		OvertakingOfConvoysByConvoysProhibited = 29,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichPassingOrOvertakingIsGenerallyProhibited")]
		[EnumMember(Value = "Passing or Overtaking Prohibited")] 
		[XmlEnum("30")] 
		PassingOrOvertakingProhibited = 30,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichVesselsAssembliesOfFloatingMaterialOrFloatingEstablishmentsMayNotBerth")]
		[EnumMember(Value = "Berthing Prohibited")] 
		[XmlEnum("31")] 
		BerthingProhibited = 31,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichBerthingIsRestricted")]
		[EnumMember(Value = "Berthing Restricted")] 
		[XmlEnum("32")] 
		BerthingRestricted = 32,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichVesselsAssembliesOfFloatingMaterialOrFloatingEstablishmentsMayNotMakeFastToTheBank")]
		[EnumMember(Value = "Making Fast Prohibited")] 
		[XmlEnum("33")] 
		MakingFastProhibited = 33,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichMakingFastToTheBankIsRestricted")]
		[EnumMember(Value = "Making Fast Restricted")] 
		[XmlEnum("34")] 
		MakingFastRestricted = 34,

		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichAllTurningIsGenerallyProhibited")]
		[EnumMember(Value = "Turning Prohibited")] 
		[XmlEnum("35")] 
		TurningProhibited = 35,

		[System.ComponentModel.Description("AnAreaWithinWhichTheFairwayDepthIsRestricted")]
		[EnumMember(Value = "Restricted Fairway Depth")] 
		[XmlEnum("36")] 
		RestrictedFairwayDepth = 36,

		[System.ComponentModel.Description("AnAreaWithinWhichTheFairwayWidthIsRestricted")]
		[EnumMember(Value = "Restricted Fairway Width")] 
		[XmlEnum("37")] 
		RestrictedFairwayWidth = 37,

		[System.ComponentModel.Description("TheUseOfAnchoringSpudsTelescopicPilesIsProhibited")]
		[EnumMember(Value = "Use of Spuds Prohibited")] 
		[XmlEnum("38")] 
		UseOfSpudsProhibited = 38,

		[System.ComponentModel.Description("AnAreaInWhichSwimmingIsProhibited")]
		[EnumMember(Value = "Swimming Prohibited")] 
		[XmlEnum("39")] 
		SwimmingProhibited = 39,

		[System.ComponentModel.Description("AnAreaWithinWhichTheEmissionOfSoxIsRestricted")]
		[EnumMember(Value = "SOx Emission Restricted")] 
		[XmlEnum("40")] 
		SoxEmissionRestricted = 40,

		[System.ComponentModel.Description("AnAreaWithinWhichTheEmissionOfNoxIsRestricted")]
		[EnumMember(Value = "NOx Emission Restricted")] 
		[XmlEnum("41")] 
		NoxEmissionRestricted = 41,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum jurisdiction : int {
		[System.ComponentModel.Description("InvolvingMoreThanOneCountryCoveringMoreThanOneNationalArea")]
		[EnumMember(Value = "International")] 
		[XmlEnum("1")] 
		International = 1,

		[System.ComponentModel.Description("AnAreaAdministeredOrControlledByASingleNation")]
		[EnumMember(Value = "National")] 
		[XmlEnum("2")] 
		National = 2,

		[System.ComponentModel.Description("AnAreaSmallerThanTheNationInWhichItLies")]
		[EnumMember(Value = "National Sub-Division")] 
		[XmlEnum("3")] 
		NationalSubDivision = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRestrictedArea : int {
		[System.ComponentModel.Description("TheAreaAroundAnOffshoreInstallationWithinWhichVesselsAreProhibitedFromEnteringWithoutPermissionSpecialRegulationsProtectInstallationsWithinASafetyZoneAndVesselsOfAllNationalitiesAreRequiredToRespectTheZone")]
		[EnumMember(Value = "Offshore Safety Zone")] 
		[XmlEnum("1")] 
		OffshoreSafetyZone = 1,

		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveItsFloraFaunaPhysicalFeaturesEtc")]
		[EnumMember(Value = "Nature Reserve")] 
		[XmlEnum("4")] 
		NatureReserve = 4,

		[System.ComponentModel.Description("APlaceWhereBirdsAreBredAndProtected")]
		[EnumMember(Value = "Bird Sanctuary")] 
		[XmlEnum("5")] 
		BirdSanctuary = 5,

		[System.ComponentModel.Description("APlaceWhereWildAnimalsOrBirdsHuntedForSportOrFoodAreKeptUndisturbedForPrivateUse")]
		[EnumMember(Value = "Game Reserve")] 
		[XmlEnum("6")] 
		GameReserve = 6,

		[System.ComponentModel.Description("APlaceWhereSealsAreProtected")]
		[EnumMember(Value = "Seal Sanctuary")] 
		[XmlEnum("7")] 
		SealSanctuary = 7,

		[System.ComponentModel.Description("AnAreaUsuallyAboutTwoCablesDiameterWithinWhichShipsMagneticFieldsMayBeMeasuredSensingInstrumentsAndCablesAreInstalledOnTheSeaBedInTheRangeAndThereAreCablesLeadingFromTheRangeToAControlPositionAshore")]
		[EnumMember(Value = "Degaussing Range")] 
		[XmlEnum("8")] 
		DegaussingRange = 8,

		[System.ComponentModel.Description("AnAreaControlledByTheMilitaryInWhichRestrictionsMayApply")]
		[EnumMember(Value = "Military Area")] 
		[XmlEnum("9")] 
		MilitaryArea = 9,

		[System.ComponentModel.Description("AnAreaAroundCertainWrecksOfHistoricalImportanceToProtectTheWrecksFromUnauthorizedInterferenceByDivingSalvageOrDepositionIncludingAnchoring")]
		[EnumMember(Value = "Historic Wreck Area")] 
		[XmlEnum("10")] 
		HistoricWreckArea = 10,

		[System.ComponentModel.Description("AnAreaAroundANavigationalAidWhichVesselsAreProhibitedFromEntering")]
		[EnumMember(Value = "Navigational Aid Safety Zone")] 
		[XmlEnum("12")] 
		NavigationalAidSafetyZone = 12,

		[System.ComponentModel.Description("AnAreaLaidAndMaintainedWithExplosiveMinesForDefenceOrPracticePurposes")]
		[EnumMember(Value = "Minefield")] 
		[XmlEnum("14")] 
		Minefield = 14,

		[System.ComponentModel.Description("AnAreaInWhichPeopleMaySwimAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Swimming Area")] 
		[XmlEnum("18")] 
		SwimmingArea = 18,

		[System.ComponentModel.Description("AnAreaReservedForVesselsWaitingToEnterAHarbour")]
		[EnumMember(Value = "Waiting Area")] 
		[XmlEnum("19")] 
		WaitingArea = 19,

		[System.ComponentModel.Description("AnAreaWhereMarineResearchTakesPlace")]
		[EnumMember(Value = "Research Area")] 
		[XmlEnum("20")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("AnAreaWhereDredgingIsTakingPlace")]
		[EnumMember(Value = "Dredging Area")] 
		[XmlEnum("21")] 
		DredgingArea = 21,

		[System.ComponentModel.Description("APlaceWhereFishIncludingShellfishAndCrustaceansAreProtected")]
		[EnumMember(Value = "Fish Sanctuary")] 
		[XmlEnum("22")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("ATractOfLandManagedSoAsToPreserveTheRelationOfPlantsAndLivingCreaturesToEachOtherAndToTheirSurroundings")]
		[EnumMember(Value = "Ecological Reserve")] 
		[XmlEnum("23")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("AnAreaInWhichAVesselsSpeedMustBeReducedInOrderToReduceTheSizeOfTheWakeItProduces")]
		[EnumMember(Value = "No Wake Area")] 
		[XmlEnum("24")] 
		NoWakeArea = 24,

		[System.ComponentModel.Description("AnAreaWhereVesselsTurn")]
		[EnumMember(Value = "Swinging Area")] 
		[XmlEnum("25")] 
		SwingingArea = 25,

		[System.ComponentModel.Description("AnAreaWithinWhichPeopleMayWaterSkiAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Water Skiing Area")] 
		[XmlEnum("26")] 
		WaterSkiingArea = 26,

		[System.ComponentModel.Description("AGenericTermWhichMayBeUsedToDescribeAWideRangeOfAreasConsideredSensitiveForAVarietyOfEnvironmentalReasons")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area")] 
		[XmlEnum("27")] 
		EnvironmentallySensitiveSeaArea = 27,

		[System.ComponentModel.Description("AnAreaThatNeedsSpecialProtectionThroughActionByImoBecauseOfItsSignificanceForRegionalEcologicalSocioEconomicOrScientificReasonsAndBecauseItMayBeVulnerableToDamageByInternationalShippingActivities")]
		[EnumMember(Value = "Particularly Sensitive Sea Area")] 
		[XmlEnum("28")] 
		ParticularlySensitiveSeaArea = 28,

		[System.ComponentModel.Description("AnAreaNearAFairwayWhereVesselsCanGoToClearTheWayOrMakeAnAboutTurnAndPossiblyReturnToAWaitingAreaWhenNauticalConditionsImposeIt")]
		[EnumMember(Value = "Disengagement Area")] 
		[XmlEnum("29")] 
		DisengagementArea = 29,

		[System.ComponentModel.Description("AnAreaInWhichDefenceLawAndTreatyEnforcementAndCounterTerrorismActivitiesThatFallWithinThePortAndMaritimeDomainApply")]
		[EnumMember(Value = "Port Security Area")] 
		[XmlEnum("30")] 
		PortSecurityArea = 30,

		[System.ComponentModel.Description("APlaceWhereCoralIsProtected")]
		[EnumMember(Value = "Coral Sanctuary")] 
		[XmlEnum("31")] 
		CoralSanctuary = 31,

		[System.ComponentModel.Description("AnAreaWithinWhichRecreationalActivitiesRegularlyTakePlaceAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Recreation Area")] 
		[XmlEnum("32")] 
		RecreationArea = 32,

		[System.ComponentModel.Description("AnAreaWithinWhichTheShipPollutionEmissionIsControlled")]
		[EnumMember(Value = "Ship Pollution Emission Control")] 
		[XmlEnum("33")] 
		ShipPollutionEmissionControl = 33,
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

	[System.Serializable()]
	public class categoryOfMarineProtectedArea
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

	public static class CodeList
	{
		public static ImmutableArray<categoryOfMarineProtectedArea> categoryOfMarineProtectedAreas => ImmutableArray.Create<categoryOfMarineProtectedArea>(new categoryOfMarineProtectedArea[]{
			new() {
				code = 1,
				definition = "-",
				label = "IUCN Category Ia",
			},
			new() {
				code = 2,
				definition = "-",
				label = "IUCN Category Ib",
			},
			new() {
				code = 3,
				definition = "-",
				label = "IUCN Category II",
			},
			new() {
				code = 4,
				definition = "-",
				label = "IUCN Category III",
			},
			new() {
				code = 5,
				definition = "-",
				label = "IUCN Category IV",
			},
			new() {
				code = 6,
				definition = "-",
				label = "IUCN Category V",
			},
			new() {
				code = 7,
				definition = "-",
				label = "IUCN Category VI",
			},
		});

		public static ImmutableArray<categoryOfVessel> categoryOfVessels => ImmutableArray.Create<categoryOfVessel>(new categoryOfVessel[]{
			new() {
				code = 1,
				definition = "-",
				label = "General Cargo Vessel",
			},
			new() {
				code = 2,
				definition = "-",
				label = "Container Carrier",
			},
			new() {
				code = 3,
				definition = "-",
				label = "Tanker",
			},
			new() {
				code = 4,
				definition = "-",
				label = "Bulk Carrier",
			},
			new() {
				code = 5,
				definition = "-",
				label = "Passenger Vessel",
			},
			new() {
				code = 6,
				definition = "-",
				label = "Roll-On Roll-Off",
			},
			new() {
				code = 7,
				definition = "-",
				label = "Refrigerated Cargo Vessel",
			},
			new() {
				code = 8,
				definition = "-",
				label = "Fishing Vessel",
			},
			new() {
				code = 9,
				definition = "-",
				label = "Service",
			},
			new() {
				code = 10,
				definition = "-",
				label = "Warship",
			},
			new() {
				code = 11,
				definition = "-",
				label = "Towed or Pushed Composite Unit",
			},
			new() {
				code = 12,
				definition = "-",
				label = "Tug and Tow",
			},
			new() {
				code = 13,
				definition = "-",
				label = "Light Recreational",
			},
			new() {
				code = 14,
				definition = "-",
				label = "Semi-Submersible Offshore Installation",
			},
			new() {
				code = 15,
				definition = "-",
				label = "Jack-Up Exploration or Project Installation",
			},
			new() {
				code = 16,
				definition = "-",
				label = "Livestock Carrier",
			},
			new() {
				code = 17,
				definition = "-",
				label = "Sport Fishing",
			},
		});

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
				definition = "A signal station for the control of vessels when berthing.",
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
	}

	namespace ComplexAttributes {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress {
			[XmlElement("deliveryPoint")]
			public String? deliveryPoint {get;set;} = default;

			public bool ShouldSerializedeliveryPoint() { return !string.IsNullOrEmpty(deliveryPoint); }

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
			public required String language {get;set;} = string.Empty;

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
			[XmlElement("frequencyShoreStationReceives")]
			public int? frequencyShoreStationReceives {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.HasValue; }

			[XmlElement("frequencyShoreStationTransmits")]
			public int? frequencyShoreStationTransmits {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationTransmits() { return frequencyShoreStationTransmits.HasValue; }
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

			[XmlElement("protocolRequest")]
			public String? protocolRequest {get;set;} = default;

			public bool ShouldSerializeprotocolRequest() { return !string.IsNullOrEmpty(protocolRequest); }

			[XmlElement("onlineFunction")]
			public onlineFunction? onlineFunction {get;set;} = default;

			public bool ShouldSerializeonlineFunction() { return onlineFunction.HasValue; }
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
			public categoryOfRxN? categoryOfRxN {get;set;} = default;

			public bool ShouldSerializecategoryOfRxN() { return categoryOfRxN != default; }

			[XmlElement("actionOrActivity")]
			public actionOrActivity? actionOrActivity {get;set;} = default;

			public bool ShouldSerializeactionOrActivity() { return actionOrActivity != default; }

			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne {
			[XmlElement("sectorBearing")]
			public required decimal sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			public int? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo {
			[XmlElement("sectorBearing")]
			public required decimal sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			public int? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textContent {
			[XmlElement("categoryOfText")]
			[EnumerationValue([1,2,3])]
			public categoryOfText? categoryOfText {get;set;} = default;

			public bool ShouldSerializecategoryOfText() { return categoryOfText.HasValue; }

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

			[XmlElement("timeOfDayEnd")]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayEnd {get;set;} = [];

			public bool ShouldSerializetimeOfDayEnd() { return timeOfDayEnd.Any(); }

			[XmlElement("timeOfDayStart")]
			public List<S100Framework.DomainModel.S100.Time> timeOfDayStart {get;set;} = [];

			public bool ShouldSerializetimeOfDayStart() { return timeOfDayStart.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselsMeasurements {
			[XmlElement("vesselsCharacteristics")]
			[EnumerationValue([1,2,3,4,6,7,8,9,10,11,12,13])]
			public required vesselsCharacteristics vesselsCharacteristics {get;set;} = default;

			[XmlElement("vesselsCharacteristicsValue")]
			public required decimal vesselsCharacteristicsValue {get;set;} = default;

			[XmlElement("vesselsCharacteristicsUnit")]
			[EnumerationValue([3,4,5,6,7,9])]
			public required vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;} = default;

			[XmlElement("comparisonOperator")]
			[EnumerationValue([1,2,3,4,5,6])]
			public required comparisonOperator comparisonOperator {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class designation {
			[XmlElement("designationScheme")]
			public String? designationScheme {get;set;} = default;

			public bool ShouldSerializedesignationScheme() { return !string.IsNullOrEmpty(designationScheme); }

			[XmlElement("designationIdentifier")]
			public String? designationIdentifier {get;set;} = default;

			public bool ShouldSerializedesignationIdentifier() { return !string.IsNullOrEmpty(designationIdentifier); }

			[XmlElement("jurisdiction")]
			public jurisdiction? jurisdiction {get;set;} = default;

			public bool ShouldSerializejurisdiction() { return jurisdiction.HasValue; }

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class bearingInformation {
			[XmlElement("cardinalDirection")]
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
		public class sectorLimit {
			[XmlElement("sectorLimitOne")]
			public required sectorLimitOne sectorLimitOne {get;set;} = default;

			[XmlElement("sectorLimitTwo")]
			public required sectorLimitTwo sectorLimitTwo {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			[XmlElement("categoryOfCommunicationPreference")]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("telecomCarrier")]
			public String? telecomCarrier {get;set;} = default;

			public bool ShouldSerializetelecomCarrier() { return !string.IsNullOrEmpty(telecomCarrier); }

			[XmlElement("telecommunicationIdentifier")]
			public required String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlElement("telecommunicationService")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public telecommunicationService? telecommunicationService {get;set;} = default;

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.HasValue; }

			[XmlElement("scheduleByDayOfWeek")]
			public scheduleByDayOfWeek? scheduleByDayOfWeek {get;set;} = default;

			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek!=default; }
		}

	}
	public enum Role {
		[System.ComponentModel.Description("The location in which the information item applies")]
		appliesInLocation,
		[System.ComponentModel.Description("The controlling organization or authority for a geographically located service")]
		controlAuthority,
		[System.ComponentModel.Description("The service controlled by an organisation or authority")]
		controlledService,
		[System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
		theRxN,
		[System.ComponentModel.Description("The usual service hours to which an exception applies")]
		theServiceHours_nsdy,
		[System.ComponentModel.Description("The work hours for a non-standard workday")]
		partialWorkingDay,
		[System.ComponentModel.Description("The responsible authority")]
		responsibleAuthority,
		[System.ComponentModel.Description("The marine protected area for which the authority is responsible")]
		theMarineProtectedArea,
		[System.ComponentModel.Description("The organisation to which information relates")]
		theOrganisation,
		[System.ComponentModel.Description("The information")]
		theInformation,
		[System.ComponentModel.Description("-")]
		permission,
		[System.ComponentModel.Description("-")]
		vslLocation,
		[System.ComponentModel.Description("-")]
		theApplicationRXN,
		[System.ComponentModel.Description("-")]
		isApplicableTo,
		[System.ComponentModel.Description("-")]
		theAuthority,
		[System.ComponentModel.Description("-")]
		theContactDetails,
		[System.ComponentModel.Description("-")]
		theAuthority_srvHrs,
		[System.ComponentModel.Description("-")]
		theServiceHours,
		[System.ComponentModel.Description("-")]
		informationProvidedFor,
		[System.ComponentModel.Description("-")]
		providesInformation,
	}

	namespace InformationAssociations {
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
		/// There may be more than one such authority depending on how responsibilities are divided
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProtectedAreaAuthority : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ProtectedAreaAuthority);
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
		/// Related organisation
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RelatedOrganisation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(RelatedOrganisation);
		}

		/// <summary>
		/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PermissionType : InformationAssociation {
			[XmlIgnore]
			public required categoryOfRelationship categoryOfRelationship {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfRelationship")]
			public SerializableEnumeration<categoryOfRelationship> categoryOfRelationshipElement { get { return categoryOfRelationship; } set { } }

			[JsonIgnore]
			public override string Code => nameof(PermissionType);
		}

		/// <summary>
		/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InclusionType : InformationAssociation {
			[XmlIgnore]
			public required membership membership {get;set;} = default;

			[JsonIgnore]
			[XmlElement("membership")]
			public SerializableEnumeration<membership> membershipElement { get { return membership; } set { } }

			[JsonIgnore]
			public override string Code => nameof(InclusionType);
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityContact : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AuthorityContact);
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AuthorityHours : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AuthorityHours);
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class additionalInformation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(additionalInformation);
		}
	}

}

namespace S100Framework.DomainModel.S122 {
	using ComplexAttributes;
	using InformationAssociations;

	namespace InformationTypes {
		/// <summary>
		/// Generalized information type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InformationType : InformationNode, IInformationBindingDefinition {
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

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("sourceType")]
			public SerializableEnumeration<sourceType>? sourceTypeElement { get { return sourceType; } set { } }

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			public override string Code => nameof(InformationType);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => InformationType._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
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
		public partial class AbstractRxN : InformationType {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }

			[XmlElement("rxNCode")]
			public List<rxNCode> rxNCode {get;set;} = [];

			public bool ShouldSerializerxNCode() { return rxNCode.Any(); }

			[JsonIgnore]
			public override string Code => nameof(AbstractRxN);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..AbstractRxN._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
		/// A person or organisation having political or administrative power and control.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Authority : InformationType {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public required categoryOfAuthority categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority> categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[JsonIgnore]
			public override string Code => nameof(Authority);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..Authority._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
					association = nameof(AuthorityContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
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
		/// Information on how to reach a person or organisation by postal, internet, telephone, telex and radio systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContactDetails : AbstractRxN {
			[XmlElement("callName")]
			public String? callName {get;set;} = default;

			public bool ShouldSerializecallName() { return !string.IsNullOrEmpty(callName); }

			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCommunicationPreference")]
			public SerializableEnumeration<categoryOfCommunicationPreference>? categoryOfCommunicationPreferenceElement { get { return categoryOfCommunicationPreference; } set { } }

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("signalFrequency")]
			public List<int> signalFrequency {get;set;} = [];

			public bool ShouldSerializesignalFrequency() { return signalFrequency.Any(); }

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(ContactDetails);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AbstractRxN._informationBindingDefinitions, ..ContactDetails._informationBindingDefinitions];
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
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ExceptionalWorkday),
					role = Enum.GetName<Role>(Role.theServiceHours_nsdy)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
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
			public required information information {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(ServiceHours);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ServiceHours._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theAuthority_srvHrs)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ExceptionalWorkday),
					role = Enum.GetName<Role>(Role.partialWorkingDay)!,
					informationTypes = [nameof(NonStandardWorkingDay)],
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

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21])]
			public List<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfDangerousOrHazardousCargo")]
			public SerializableEnumeration<categoryOfDangerousOrHazardousCargo>[] categoryOfDangerousOrHazardousCargoElement { get { return [.. categoryOfDangerousOrHazardousCargo]; } set { } }

			public bool ShouldSerializecategoryOfDangerousOrHazardousCargo() { return categoryOfDangerousOrHazardousCargo.Any(); }

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public categoryOfVessel? categoryOfVessel {get;set;} = default;

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel != default; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfVesselRegistry? categoryOfVesselRegistry {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfVesselRegistry")]
			public SerializableEnumeration<categoryOfVesselRegistry>? categoryOfVesselRegistryElement { get { return categoryOfVesselRegistry; } set { } }

			public bool ShouldSerializecategoryOfVesselRegistry() { return categoryOfVesselRegistry.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public logicalConnectives? logicalConnectives {get;set;} = default;

			[JsonIgnore]
			[XmlElement("logicalConnectives")]
			public SerializableEnumeration<logicalConnectives>? logicalConnectivesElement { get { return logicalConnectives; } set { } }

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
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}
	}
	namespace FeatureTypes {
		using InformationTypes;
		using System.Xml;

		/// <summary>
		/// Generalized feature type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FeatureType : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public required String interoperabilityIdentifier {get;set;} = string.Empty;

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,9,10,11,12,13,14])]
			public sourceType? sourceType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("sourceType")]
			public SerializableEnumeration<sourceType>? sourceTypeElement { get { return sourceType; } set { } }

			public bool ShouldSerializesourceType() { return sourceType.HasValue; }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[JsonIgnore]
			public override string Code => nameof(FeatureType);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => FeatureType._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
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
					association = nameof(additionalInformation),
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
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A specified area designated by an appropriate authority within which navigation is restricted in accordance with certain specified conditions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RestrictedArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(RestrictedArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RestrictedArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RestrictedArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RestrictedArea._primitives];
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
		/// Any area of the intertidal or sub-tidal terrain, together with its overlying water and associated flora, fauna, historical and cultural features, which has been reserved by law or other effective means to protect part or all of the enclosed environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MarineProtectedArea : FeatureType {
			[XmlElement("categoryOfMarineProtectedArea")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required categoryOfMarineProtectedArea categoryOfMarineProtectedArea {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public required jurisdiction jurisdiction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("jurisdiction")]
			public SerializableEnumeration<jurisdiction> jurisdictionElement { get { return jurisdiction; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("designation")]
			public List<designation> designation {get;set;} = [];

			public bool ShouldSerializedesignation() { return designation.Any(); }

			[JsonIgnore]
			public override string Code => nameof(MarineProtectedArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..MarineProtectedArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ProtectedAreaAuthority),
					role = Enum.GetName<Role>(Role.responsibleAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..MarineProtectedArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..MarineProtectedArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve, Primitives.surface
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
		/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VesselTrafficServiceArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5])]
			public required categoryOfVesselTrafficService categoryOfVesselTrafficService {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfVesselTrafficService")]
			public SerializableEnumeration<categoryOfVesselTrafficService> categoryOfVesselTrafficServiceElement { get { return categoryOfVesselTrafficService; } set { } }

			[JsonIgnore]
			public override string Code => nameof(VesselTrafficServiceArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..VesselTrafficServiceArea._informationBindingDefinitions];
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
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..VesselTrafficServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..VesselTrafficServiceArea._primitives];
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
		/// A geographical area that describes the coverage and extent of spatial objects.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
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
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
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
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S122/1.2")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S122/1.2 122_1.2.1.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S122/1.2", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.InformationType", typeof(InformationTypes.InformationType), Order = 1, ElementName = "InformationType")]
		[XmlElement("InformationTypes.AbstractRxN", typeof(InformationTypes.AbstractRxN), Order = 1, ElementName = "AbstractRxN")]
		[XmlElement("InformationTypes.NauticalInformation", typeof(InformationTypes.NauticalInformation), Order = 1, ElementName = "NauticalInformation")]
		[XmlElement("InformationTypes.Regulations", typeof(InformationTypes.Regulations), Order = 1, ElementName = "Regulations")]
		[XmlElement("InformationTypes.Restrictions", typeof(InformationTypes.Restrictions), Order = 1, ElementName = "Restrictions")]
		[XmlElement("InformationTypes.Recommendations", typeof(InformationTypes.Recommendations), Order = 1, ElementName = "Recommendations")]
		[XmlElement("InformationTypes.Authority", typeof(InformationTypes.Authority), Order = 1, ElementName = "Authority")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.NonStandardWorkingDay", typeof(InformationTypes.NonStandardWorkingDay), Order = 1, ElementName = "NonStandardWorkingDay")]
		[XmlElement("InformationTypes.ServiceHours", typeof(InformationTypes.ServiceHours), Order = 1, ElementName = "ServiceHours")]
		[XmlElement("InformationTypes.Applicability", typeof(InformationTypes.Applicability), Order = 1, ElementName = "Applicability")]
		[XmlElement("FeatureTypes.RestrictedArea", typeof(FeatureTypes.RestrictedArea), Order = 1, ElementName = "RestrictedArea")]
		[XmlElement("FeatureTypes.MarineProtectedArea", typeof(FeatureTypes.MarineProtectedArea), Order = 1, ElementName = "MarineProtectedArea")]
		[XmlElement("FeatureTypes.VesselTrafficServiceArea", typeof(FeatureTypes.VesselTrafficServiceArea), Order = 1, ElementName = "VesselTrafficServiceArea")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.TextPlacement", typeof(FeatureTypes.TextPlacement), Order = 1, ElementName = "TextPlacement")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
