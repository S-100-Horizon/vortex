using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S123 {
	public static class Summary
	{
		public static Version Version => new Version("1.1.0");
		public static string[] ComplexTypes => ["areaA3ServiceDescription","bearingInformation","broadcastContent","contactAddress","coverageIndication","featureName","fixedDateRange","frequencyPair","frequencyRange","graphic","horizontalPositionUncertainty","information","onlineResource","orientation","periodicDateRange","radioChannelDetails","radiocommunicationIdentifier","rxNCode","scheduleByDayOfWeek","sectorLimit","sectorLimitOne","sectorLimitTwo","spatialAccuracy","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","timesOfTransmission","verticalUncertainty","vesselMeasurementsSpecification"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AssociatedRxN","AuthorityContact","AuthorityHours","AvailableQoS","BroadcastService","BroadcastTransmission","ConnectivityService","ExceptionalWorkday","InclusionType","LocationHours","PermissionType","RadioServiceControl","relatedOrganisation","ServiceContact","ServiceCoordination","SpatialAssociation","TransmissionService"];
		public static string[] FeatureAssociationTypes => ["coreAggregation","fuzzyZoneAggregation","ServiceProvisionArea","TextAssociation"];
		public static string[] InformationTypes => ["Applicability","Authority","BroadcastDetails","ConnectivityQualityOfService","ContactDetails","NauticalInformation","NonStandardWorkingDay","RadioControlCentre","Recommendations","Regulations","Restrictions","ServiceHours","SpatialQuality","TransmissionDetails"];
		public static string[] FeatureTypes => ["ConnectivitySubscriptionArea","GMDSSArea","IndeterminateZone","MetArea","NavArea","NavtexServiceArea","RadioServiceArea","RadioStation","WeatherForecastAndWarningArea","RadioServiceAreaAggregate","DataCoverage","QualityOfNonBathymetricData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType","FuzzyAreaAggregate","RadioServiceAreaAggregate"],
			Primitives.surface => ["ConnectivitySubscriptionArea","GMDSSArea","IndeterminateZone","MetArea","NavArea","NavtexServiceArea","RadioServiceArea","WeatherForecastAndWarningArea","DataCoverage","QualityOfNonBathymetricData"],
			Primitives.point => ["ConnectivitySubscriptionArea","RadioStation","TextPlacement"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"FeatureType" => [Primitives.noGeometry],
			"ConnectivitySubscriptionArea" => [Primitives.surface,Primitives.point],
			"GMDSSArea" => [Primitives.surface],
			"IndeterminateZone" => [Primitives.surface],
			"MetArea" => [Primitives.surface],
			"NavArea" => [Primitives.surface],
			"NavtexServiceArea" => [Primitives.surface],
			"RadioServiceArea" => [Primitives.surface],
			"RadioStation" => [Primitives.point],
			"WeatherForecastAndWarningArea" => [Primitives.surface],
			"FuzzyAreaAggregate" => [Primitives.noGeometry],
			"RadioServiceAreaAggregate" => [Primitives.noGeometry],
			"DataCoverage" => [Primitives.surface],
			"QualityOfNonBathymetricData" => [Primitives.surface],
			"TextPlacement" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
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
	public enum categoryOfBroadcastCommunication : int {
		[System.ComponentModel.Description("AServiceOperatedWithTheIntentionOfEarningMoney")]
		[EnumMember(Value = "Commercial")] 
		[XmlEnum("1")] 
		Commercial = 1,

		[System.ComponentModel.Description("AServiceWithoutAnyFinancialInterest")]
		[EnumMember(Value = "Non-Commercial")] 
		[XmlEnum("2")] 
		NonCommercial = 2,

		[System.ComponentModel.Description("BelongingToAvailableToUsedOrSharedByTheCommunityAsAWholeAndNotRestrictedToPrivateUse")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("3")] 
		Public = 3,

		[System.ComponentModel.Description("AServiceAvailableForLimitedAndPredefinedCustomers")]
		[EnumMember(Value = "Non-Public")] 
		[XmlEnum("4")] 
		NonPublic = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("UnpackedHomogenousCargoPouredLooseInACertainSpaceOfAVesselForExampleOilOrGrain")]
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
	public enum categoryOfForecastOrWarningArea : int {
		[System.ComponentModel.Description("TheForecastAndWarningAreaDefinedByWmo")]
		[EnumMember(Value = "World Meteorological Organization (WMO)")] 
		[XmlEnum("1")] 
		WorldMeteorologicalOrganizationWmo = 1,

		[System.ComponentModel.Description("TheForecastAndWarningAreaDefinedByNationalAuthoritiesCoveringHighSeas")]
		[EnumMember(Value = "National High Seas")] 
		[XmlEnum("2")] 
		NationalHighSeas = 2,

		[System.ComponentModel.Description("TheForecastAndWarningAreaDefinedByNationalAuthoritiesCoveringOffshoreWaters")]
		[EnumMember(Value = "National Offshore")] 
		[XmlEnum("3")] 
		NationalOffshore = 3,

		[System.ComponentModel.Description("TheForecastAndWarningAreaDefinedByNationalAuthoritiesCoveringCoastalWaters")]
		[EnumMember(Value = "National Coastal")] 
		[XmlEnum("4")] 
		NationalCoastal = 4,

		[System.ComponentModel.Description("TheForecastAndWarningAreaDefinedByNationalAuthoritiesCoveringInshoreWaters")]
		[EnumMember(Value = "National Inshore")] 
		[XmlEnum("5")] 
		NationalInshore = 5,

		[System.ComponentModel.Description("TheForecastAndWarningAreaDefinedByNationalAuthoritiesCoveringLocalWaters")]
		[EnumMember(Value = "National Local")] 
		[XmlEnum("6")] 
		NationalLocal = 6,

		[System.ComponentModel.Description("TheSolidFormOfWater")]
		[EnumMember(Value = "Ice")] 
		[XmlEnum("7")] 
		Ice = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfGMDSSArea : int {
		[System.ComponentModel.Description("WithinRangeOfVhfCoastStationsWithContinuousDscAlertingAvailableAbout2030Miles")]
		[EnumMember(Value = "Area A1")] 
		[XmlEnum("1")] 
		AreaA1 = 1,

		[System.ComponentModel.Description("BeyondAreaA1ButWithinRangeOfMfCoastalStationsWithContinuousDscAlertingAvailableAboutL00Miles")]
		[EnumMember(Value = "Area A2")] 
		[XmlEnum("2")] 
		AreaA2 = 2,

		[System.ComponentModel.Description("BeyondArea1AndArea2ButWithinCoverageOfGeostationaryMaritimeCommunicationSatellitesInPracticeThisMeansInmarsatThisCoversTheAreaBetweenRoughly70DegNAnd70DegS")]
		[EnumMember(Value = "Area A3")] 
		[XmlEnum("3")] 
		AreaA3 = 3,

		[System.ComponentModel.Description("TheSeaAreasBeyondArea3TheMostImportantOfTheseIsTheSeaAroundTheNorthPoleTheAreaAroundTheSouthPoleIsMostlyLandGeostationarySatellitesWhichArePositionedAboveTheEquatorCannotReachThisFar")]
		[EnumMember(Value = "Area A4")] 
		[XmlEnum("4")] 
		AreaA4 = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioStation : int {
		[System.ComponentModel.Description("ARadioStationIntendedToDetermineOnlyTheDirectionOfOtherStationsByMeansOfTransmissionFromTheLatter")]
		[EnumMember(Value = "Radio Direction-Finding Station")] 
		[XmlEnum("5")] 
		RadioDirectionFindingStation = 5,

		[System.ComponentModel.Description("DifferentialGnssIsImplementedByPlacingAGnssMonitorReceiverAtAPreciselyKnownLocationInsteadOfComputingANavigationFixTheMonitorDeterminesTheRangeErrorToEveryGnssSatelliteItCanTrackTheseRangingErrorsAreThenTransmittedToLocalUsersWhereTheyAreAppliedAsCorrectionsBeforeComputingTheNavigationResult")]
		[EnumMember(Value = "Differential GNSS")] 
		[XmlEnum("10")] 
		DifferentialGnss = 10,

		[System.ComponentModel.Description("TheEquipmentNeededAtOneStationToCarryOnTwoWayVoiceCommunicationByRadioWavesOnly")]
		[EnumMember(Value = "Radio Telephone Station")] 
		[XmlEnum("19")] 
		RadioTelephoneStation = 19,

		[System.ComponentModel.Description("AnAisShoreStationForUseByCompetentAuthoritiesToProvideAisServiceManageTheDataLinkAndEnableEffectiveShipToShoreShoreToShipTransmissionOfInformation")]
		[EnumMember(Value = "AIS Base Station")] 
		[XmlEnum("20")] 
		AisBaseStation = 20,
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

		[System.ComponentModel.Description("ContinuousOrFrequentChangeForExampleRiverSiltationSandWavesSeasonalStormsIcebergsEtcThatIsLikelyToResultInNewSignificantShoaling")]
		[EnumMember(Value = "Likely to Change and Significant Shoaling Expected")] 
		[XmlEnum("2")] 
		LikelyToChangeAndSignificantShoalingExpected = 2,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeForExampleSandWaveShiftSeasonalStormsIcebergsEtcThatIsNotLikelyToResultInNewSignificantShoaling")]
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
	public enum categoryOfConnectivitySubscription : int {
		[System.ComponentModel.Description("CommunicationUsingGeoGeosynchronousEarthOrbitSatellites")]
		[EnumMember(Value = "Satellite Communication GEO")] 
		[XmlEnum("1")] 
		SatelliteCommunicationGeo = 1,

		[System.ComponentModel.Description("CommunicationUsingLeoLowEarthOrbitSatellites")]
		[EnumMember(Value = "Satellite Communication LEO")] 
		[XmlEnum("2")] 
		SatelliteCommunicationLeo = 2,

		[System.ComponentModel.Description("CommunicationUsingCellularNetworkCellularNetwotkOrMobileNetworkEnablesWirelessCommunicationBetweenMobileDevicesTheFinalStageOfConnectivityIsAchievedBySegmentingTheComprehensiveServiceAreaIntoSeveralCompactZonesEachCalledACellAStationaryTransceiverKnownAsACellSiteOrBaseStationProvidesServiceInEachCellTheCellSiteLinksToThePrimaryNetworkInfrastructureEmployingEitherAWirelessOrWiredConnection")]
		[EnumMember(Value = "Cellular Communication")] 
		[XmlEnum("3")] 
		CellularCommunication = 3,

		[System.ComponentModel.Description("CommunicationUsingAdHocNetworkingWhichUsesWhateverResourcesAvailableToCreateCommunicationPathsFromAnEndUserDeviceToItsDesiredDestinationIndependentFromCentralNetworkInfrastructureOrAdministration")]
		[EnumMember(Value = "Terrestrial Ad-Hoc Communication")] 
		[XmlEnum("4")] 
		TerrestrialAdHocCommunication = 4,
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
	public enum dayOfWeek : int {
		[System.ComponentModel.Description("TheDayOfTheWeekFollowingSaturdayAndPrecedingMonday")]
		[EnumMember(Value = "Sunday")] 
		[XmlEnum("1")] 
		Sunday = 1,

		[System.ComponentModel.Description("TheDayOfTheWeekFollowingSundayAndPrecedingTuesday")]
		[EnumMember(Value = "Monday")] 
		[XmlEnum("2")] 
		Monday = 2,

		[System.ComponentModel.Description("TheDayOfTheWeekFollowingMondayAndPrecedingWednesday")]
		[EnumMember(Value = "Tuesday")] 
		[XmlEnum("3")] 
		Tuesday = 3,

		[System.ComponentModel.Description("TheDayOfTheWeekFollowingTuesdayAndPrecedingThursday")]
		[EnumMember(Value = "Wednesday")] 
		[XmlEnum("4")] 
		Wednesday = 4,

		[System.ComponentModel.Description("TheDayOfTheWeekFollowingWednesdayAndPrecedingFriday")]
		[EnumMember(Value = "Thursday")] 
		[XmlEnum("5")] 
		Thursday = 5,

		[System.ComponentModel.Description("TheDayOfTheWeekFollowingThursdayAndPrecedingSaturday")]
		[EnumMember(Value = "Friday")] 
		[XmlEnum("6")] 
		Friday = 6,

		[System.ComponentModel.Description("TheDayOfTheWeekFollowingFridayAndPrecedingSunday")]
		[EnumMember(Value = "Saturday")] 
		[XmlEnum("7")] 
		Saturday = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum frequencyBand : int {
		[System.ComponentModel.Description("RadioFrequenciesBetween30KhzAnd300Khz")]
		[EnumMember(Value = "LF")] 
		[XmlEnum("1")] 
		Lf = 1,

		[System.ComponentModel.Description("RadioFrequenciesBetween300KhzAnd3000Khz")]
		[EnumMember(Value = "MF")] 
		[XmlEnum("2")] 
		Mf = 2,

		[System.ComponentModel.Description("RadioFrequenciesBetween300KhzAnd30Mhz")]
		[EnumMember(Value = "MF/HF")] 
		[XmlEnum("3")] 
		MfHf = 3,

		[System.ComponentModel.Description("RadioFrequenciesBetween3MhzAnd30Mhz")]
		[EnumMember(Value = "HF")] 
		[XmlEnum("4")] 
		Hf = 4,

		[System.ComponentModel.Description("RadioFrequenciesBetween30MhzAnd300Mhz")]
		[EnumMember(Value = "VHF")] 
		[XmlEnum("5")] 
		Vhf = 5,

		[System.ComponentModel.Description("RadioFrequenciesBetween300MhzAnd3Ghz")]
		[EnumMember(Value = "UHF")] 
		[XmlEnum("6")] 
		Uhf = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum informationConfidence : int {
		[System.ComponentModel.Description("VirtuallyCertainToBeExperiencedByOrAvailableToAnIndividualVesselWillBeExperiencedByNearlyAllVessels")]
		[EnumMember(Value = "Virtually Certain")] 
		[XmlEnum("1")] 
		VirtuallyCertain = 1,

		[System.ComponentModel.Description("FrequentlyExperiencedByOrAvailableToAnIndividualVesselExperiencedByAMajorityOfVessels")]
		[EnumMember(Value = "High Likelihood")] 
		[XmlEnum("2")] 
		HighLikelihood = 2,

		[System.ComponentModel.Description("OccasionallyExperiencedByOrAvailableToAnIndividualVesselExperiencedByOrAvailableToAboutHalfOfAllVessels")]
		[EnumMember(Value = "Medium Likelihood")] 
		[XmlEnum("3")] 
		MediumLikelihood = 3,

		[System.ComponentModel.Description("UnlikelyButSometimesRarelyExperiencedByOrAvailableToAnIndividualVesselExperiencedByOrAvailableToAMinorityOfVessels")]
		[EnumMember(Value = "Low Likelihood")] 
		[XmlEnum("4")] 
		LowLikelihood = 4,
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
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("APositionThatIsConsideredToBeLessThanThirdOrderAccuracyButIsGenerallyConsideredToBeWithin305MetresOfItsCorrectGeographicLocationAlsoMayApplyToAFeatureWhosePositionDoesNotRemainFixed")]
		[EnumMember(Value = "Approximate")] 
		[XmlEnum("4")] 
		Approximate = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum servingMobileSatelliteService : int {
		[System.ComponentModel.Description("AnInternationalAutomaticDirectPrintingSatelliteBasedServiceUsingInmarsatCEnhancedGroupCallEgcSystemForThePromulgationOfMaritimeSafetyInformationMsiNavigationalAndMeteorologicalWarningsMeteorologicalForecastsSearchAndRescueSarRelatedInformationAndOtherUrgentSafetyRelatedMessagesToShips")]
		[EnumMember(Value = "Inmarsat SafetyNET")] 
		[XmlEnum("1")] 
		InmarsatSafetynet = 1,

		[System.ComponentModel.Description("AServiceBasedOnIridiumMobileSatelliteSystemForThePromulgationOfMaritimeSafetyInformationMsiNavigationalAndMeteorologicalWarningsMeteorologicalForecastsSarRelatedInformationAndOtherUrgentSafetyRelatedMessagesToShips")]
		[EnumMember(Value = "Iridium SafetyCast")] 
		[XmlEnum("2")] 
		IridiumSafetycast = 2,
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

		[System.ComponentModel.Description("UseHasCeasedButTheFacilityStillExistsIntactDisused")]
		[EnumMember(Value = "Not in Use")] 
		[XmlEnum("4")] 
		NotInUse = 4,

		[System.ComponentModel.Description("RecurringAtIntervals")]
		[EnumMember(Value = "Periodic/Intermittent")] 
		[XmlEnum("5")] 
		PeriodicIntermittent = 5,

		[System.ComponentModel.Description("MeantToLastOnlyForATime")]
		[EnumMember(Value = "Temporary")] 
		[XmlEnum("7")] 
		Temporary = 7,

		[System.ComponentModel.Description("AdministeredByAnIndividualOrCorporationRatherThanAStateOrAPublicBody")]
		[EnumMember(Value = "Private")] 
		[XmlEnum("8")] 
		Private = 8,

		[System.ComponentModel.Description("BelongingToAvailableToUsedOrSharedByTheCommunityAsAWholeAndNotRestrictedToPrivateUse")]
		[EnumMember(Value = "Public")] 
		[XmlEnum("14")] 
		Public = 14,

		[System.ComponentModel.Description("LookedAtOrObservedOverAPeriodOfTimeEspeciallySoAsToBeAwareOfAnyMovementOrChange")]
		[EnumMember(Value = "Watched")] 
		[XmlEnum("16")] 
		Watched = 16,

		[System.ComponentModel.Description("UsuallyAutomaticInOperationWithoutAnyPermanentlyStationedPersonnelToSuperintendIt")]
		[EnumMember(Value = "Unwatched")] 
		[XmlEnum("17")] 
		Unwatched = 17,

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

		[System.ComponentModel.Description("ADistinguishingTraitQualityOrPropertyOfAFeatureClass")]
		[EnumMember(Value = "Feature Characteristic")] 
		[XmlEnum("2")] 
		FeatureCharacteristic = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum transmissionRegularity : int {
		[System.ComponentModel.Description("TransmissionIsMadeContinuously")]
		[EnumMember(Value = "Continuous")] 
		[XmlEnum("1")] 
		Continuous = 1,

		[System.ComponentModel.Description("TransmissionIsMadeRegularlyAccordingToASchedule")]
		[EnumMember(Value = "Regular")] 
		[XmlEnum("2")] 
		Regular = 2,

		[System.ComponentModel.Description("TransmissionIsMadeWhenWarningOrInformationIsReceivedFromAnotherAuthority")]
		[EnumMember(Value = "On Receipt")] 
		[XmlEnum("3")] 
		OnReceipt = 3,

		[System.ComponentModel.Description("TransmissionIsMadeUnderSpecifiedConditionsOrWhenNeeded")]
		[EnumMember(Value = "As Required")] 
		[XmlEnum("4")] 
		AsRequired = 4,

		[System.ComponentModel.Description("WhenYouAskForIt")]
		[EnumMember(Value = "On Request")] 
		[XmlEnum("5")] 
		OnRequest = 5,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfBroadcastContent : int {
		[System.ComponentModel.Description("MessagesContainingUrgentInformationRelevantToSafeNavigationBroadcastToShipsInAccordanceWithTheProvisionsOfTheInternationalConventionForTheSafetyOfLifeAtSea1974")]
		[EnumMember(Value = "Navigational warnings")] 
		[XmlEnum("1")] 
		NavigationalWarnings = 1,

		[System.ComponentModel.Description("MarineMeteorologicalWarningAndForecastInformationInAccordanceWithTheProvisionsOfTheInternationalConventionForTheSafetyOfLifeAtSea1974")]
		[EnumMember(Value = "Meteorological warnings and forecasts")] 
		[XmlEnum("2")] 
		MeteorologicalWarningsAndForecasts = 2,

		[System.ComponentModel.Description("SearchAndRescueSarRelatedInformationProvidedByTheAuthorityResponsibleForCoordinatingMaritimeSarOperations")]
		[EnumMember(Value = "Search and rescue information")] 
		[XmlEnum("3")] 
		SearchAndRescueInformation = 3,

		[System.ComponentModel.Description("SecurityRelatedRequirementsInAccordanceToInternationalShipAndPortFacilitySecurityIspsCodeOrWarningsRelatedToActsOfPiracyAndArmedRobberyAgainstShips")]
		[EnumMember(Value = "Marine security or piracy warnings")] 
		[XmlEnum("4")] 
		MarineSecurityOrPiracyWarnings = 4,

		[System.ComponentModel.Description("WarningsRealtedToTsunamisAndOtherNaturalPhenomenaSuchAsAbnormalChangesToSeaLevel")]
		[EnumMember(Value = "Tsunamis or natural phenomena warnings")] 
		[XmlEnum("5")] 
		TsunamisOrNaturalPhenomenaWarnings = 5,

		[System.ComponentModel.Description("MessagesRelatedToPilotAndVtsServiceSuchAsTemporaryAlterationsMovementOrSuspensionToPilotOrVtsServices")]
		[EnumMember(Value = "Pilot and VTS service messages")] 
		[XmlEnum("6")] 
		PilotAndVtsServiceMessages = 6,

		[System.ComponentModel.Description("InformationConcerningMilitaryEventsSuchAsMilitaryExercisesMissileFirings")]
		[EnumMember(Value = "Military information")] 
		[XmlEnum("7")] 
		MilitaryInformation = 7,

		[System.ComponentModel.Description("BroadcastForSpecialServicesOrOtherApplicationSpecificMessages")]
		[EnumMember(Value = "Special service or application specific messages")] 
		[XmlEnum("8")] 
		SpecialServiceOrApplicationSpecificMessages = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfConnectivityResource : int {
		[System.ComponentModel.Description("TheTypeOfQualityOfServiceQosFlowOrAQosParameterThatDefinesTheMinimumDataRateThatMustBeGuaranteedForASpecificServiceOrTrafficFlow")]
		[EnumMember(Value = "Guaranteed Bit Rate")] 
		[XmlEnum("1")] 
		GuaranteedBitRate = 1,

		[System.ComponentModel.Description("TheTypeOfQualityOfServiceQosFlowThatDoesNotProvideTheEndUserAGuaranteedFlowBitRateTypicallyUsedForNonTimeSensitiveApplicationsEGWebBrowsingBufferedStreamingAndInstantMessengerApplications")]
		[EnumMember(Value = "Non-Guaranteed Bit Rate")] 
		[XmlEnum("2")] 
		NonGuaranteedBitRate = 2,

		[System.ComponentModel.Description("TheTypeOfQualityOfServiceQosFlowThatProvidesLatenciesSignificantlyLowerThanGuaranteedFlowBitRateTypicallyUsedInMissionCriticalApplicationLikeAutomationOrIntelligentTransportationSystems")]
		[EnumMember(Value = "Delay Critical Guaranteed Bit Rate")] 
		[XmlEnum("3")] 
		DelayCriticalGuaranteedBitRate = 3,

		[System.ComponentModel.Description("TheNetworkOrServiceThatDoesNotSupportQualityOfServiceDoesItsBestToDeliverPacketsButDoesNotGuaranteeDeliveryOrControlDelay")]
		[EnumMember(Value = "Best Effort")] 
		[XmlEnum("4")] 
		BestEffort = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfNAVTEXService : int {
		[System.ComponentModel.Description("TheCoordinatedBroadcastAndAutomaticReceptionOn518KhzOfMaritimeSafetyInformationByMeansOfNarrowBandDirectPrintingTelegraphyUsingTheEnglishLanguageImoMsc1Circ1403Rev2NavtexManual")]
		[EnumMember(Value = "International NAVTEX")] 
		[XmlEnum("1")] 
		InternationalNavtex = 1,

		[System.ComponentModel.Description("TheBroadcastAndAutomaticReceptionOfMaritimeSafetyInformationByMeansOfNarrowBandDirectPrintingTelegraphyUsingFrequenciesOtherThan518KhzAndLanguagesAsDecidedByTheAdministrationConcernedImoMsc1Circ1403Rev2NavtexManual")]
		[EnumMember(Value = "national NAVTEX")] 
		[XmlEnum("2")] 
		NationalNavtex = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum typeOfRadioService : int {
		[System.ComponentModel.Description("RadioServiceUsingDigitalSelectiveCallingDscTechniques")]
		[EnumMember(Value = "Digital Selective Calling (DSC)")] 
		[XmlEnum("1")] 
		DigitalSelectiveCallingDsc = 1,

		[System.ComponentModel.Description("RadioServiceUsingRadioTelephonyRt")]
		[EnumMember(Value = "Radio Telephony (RT)")] 
		[XmlEnum("2")] 
		RadioTelephonyRt = 2,

		[System.ComponentModel.Description("RadioServiceWithTheCoastStationProvidingAPublicCorrespondenceService")]
		[EnumMember(Value = "Public correspondence service (CP)")] 
		[XmlEnum("3")] 
		PublicCorrespondenceServiceCp = 3,

		[System.ComponentModel.Description("RadioServiceUsingRadioTelegraphyWt")]
		[EnumMember(Value = "Radio Telegraphy (WT)")] 
		[XmlEnum("4")] 
		RadioTelegraphyWt = 4,

		[System.ComponentModel.Description("RadioServiceUsingNarrowBandDirectPrintingNbdpTelegraphy")]
		[EnumMember(Value = "Radiotelex (NBDP telegraphy)")] 
		[XmlEnum("5")] 
		RadiotelexNbdpTelegraphy = 5,

		[System.ComponentModel.Description("RadioServiceUsingRadioFacsimile")]
		[EnumMember(Value = "Radio facsimile")] 
		[XmlEnum("6")] 
		RadioFacsimile = 6,

		[System.ComponentModel.Description("RadioServiceUsingDigitalModulationInTheTransmittedSignal")]
		[EnumMember(Value = "Digital")] 
		[XmlEnum("7")] 
		Digital = 7,

		[System.ComponentModel.Description("RadioServiceUsingDataCommunication")]
		[EnumMember(Value = "Data")] 
		[XmlEnum("8")] 
		Data = 8,

		[System.ComponentModel.Description("TheSystemForTheBroadcastAndAutomaticReceptionOfMaritimeSafetyInformationByMeansOfNarrowBandDirectPrintingTelegraphy")]
		[EnumMember(Value = "NAVTEX")] 
		[XmlEnum("9")] 
		Navtex = 9,

		[System.ComponentModel.Description("TheBroadcastOfCoordinatedMaritimeSafetyInformationAndSearchAndRescueRelatedInformationToADefinedGeographicalAreaUsingARecognizedMobileSatelliteService")]
		[EnumMember(Value = "Enhanced Group Call (EGC)")] 
		[XmlEnum("10")] 
		EnhancedGroupCallEgc = 10,

		[System.ComponentModel.Description("AutomaticIdentificationSystem")]
		[EnumMember(Value = "AIS")] 
		[XmlEnum("11")] 
		Ais = 11,

		[System.ComponentModel.Description("ApplicationSpecificMessage")]
		[EnumMember(Value = "ASM")] 
		[XmlEnum("12")] 
		Asm = 12,

		[System.ComponentModel.Description("CommunicationUsingASatelliteSystem")]
		[EnumMember(Value = "Satellite communication")] 
		[XmlEnum("13")] 
		SatelliteCommunication = 13,
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
	}

	namespace ComplexAttributes {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class areaA3ServiceDescription {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			public List<servingMobileSatelliteService> servingMobileSatelliteService {get;set;} = [];

			[JsonIgnore]
			[XmlElement("servingMobileSatelliteService")]
			public SerializableEnumeration<servingMobileSatelliteService>[] servingMobileSatelliteServiceElement { get { return [.. servingMobileSatelliteService]; } set { } }

			public bool ShouldSerializeservingMobileSatelliteService() { return servingMobileSatelliteService.Any(); }

			[XmlElement("satelliteOceanRegion")]
			public String? satelliteOceanRegion {get;set;} = default;

			public bool ShouldSerializesatelliteOceanRegion() { return !string.IsNullOrEmpty(satelliteOceanRegion); }

			[XmlElement("mSICoastalWarningArea")]
			public String? mSICoastalWarningArea {get;set;} = default;

			public bool ShouldSerializemSICoastalWarningArea() { return !string.IsNullOrEmpty(mSICoastalWarningArea); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class broadcastContent {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<typeOfBroadcastContent> typeOfBroadcastContent {get;set;} = [];

			[JsonIgnore]
			[XmlElement("typeOfBroadcastContent")]
			public SerializableEnumeration<typeOfBroadcastContent>[] typeOfBroadcastContentElement { get { return [.. typeOfBroadcastContent]; } set { } }

			public bool ShouldSerializetypeOfBroadcastContent() { return typeOfBroadcastContent.Any(); }

			[XmlElement("subjectIndicatorCharacter")]
			public String? subjectIndicatorCharacter {get;set;} = default;

			public bool ShouldSerializesubjectIndicatorCharacter() { return !string.IsNullOrEmpty(subjectIndicatorCharacter); }

			[XmlElement("subjectDescription")]
			public String? subjectDescription {get;set;} = default;

			public bool ShouldSerializesubjectDescription() { return !string.IsNullOrEmpty(subjectDescription); }

			[XmlElement("observationTime")]
			public S100Framework.DomainModel.S100.Time? observationTime {get;set;} = default;

			public bool ShouldSerializeobservationTime() { return observationTime.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5])]
			public transmissionRegularity? transmissionRegularity {get;set;} = default;

			[JsonIgnore]
			[XmlElement("transmissionRegularity")]
			public SerializableEnumeration<transmissionRegularity>? transmissionRegularityElement { get { return transmissionRegularity; } set { } }

			public bool ShouldSerializetransmissionRegularity() { return transmissionRegularity.HasValue; }
		}

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
		public class coverageIndication {
			[XmlElement("minimumReceivedPower")]
			public int? minimumReceivedPower {get;set;} = default;

			public bool ShouldSerializeminimumReceivedPower() { return minimumReceivedPower.HasValue; }

			[XmlElement("presumedReceiverAntennaHeight")]
			public int? presumedReceiverAntennaHeight {get;set;} = default;

			public bool ShouldSerializepresumedReceiverAntennaHeight() { return presumedReceiverAntennaHeight.HasValue; }

			[XmlElement("minimumSignalToInterferenceNoiseRatio")]
			public int? minimumSignalToInterferenceNoiseRatio {get;set;} = default;

			public bool ShouldSerializeminimumSignalToInterferenceNoiseRatio() { return minimumSignalToInterferenceNoiseRatio.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17,24,25,26,27])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("text")]
			public List<String> text {get;set;} = [];

			public bool ShouldSerializetext() { return text.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			[XmlElement("language")]
			public required String language {get;set;} = string.Empty;

			[XmlElement("name")]
			public required String name {get;set;} = string.Empty;

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public nameUsage? nameUsage {get;set;} = default;

			[JsonIgnore]
			[XmlElement("nameUsage")]
			public SerializableEnumeration<nameUsage>? nameUsageElement { get { return nameUsage; } set { } }

			public bool ShouldSerializenameUsage() { return nameUsage.HasValue; }
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

			[XmlElement("timeOfDayStart")]
			public S100Framework.DomainModel.S100.Time? timeOfDayStart {get;set;} = default;

			public bool ShouldSerializetimeOfDayStart() { return timeOfDayStart.HasValue; }

			[XmlElement("timeOfDayEnd")]
			public S100Framework.DomainModel.S100.Time? timeOfDayEnd {get;set;} = default;

			public bool ShouldSerializetimeOfDayEnd() { return timeOfDayEnd.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyPair {
			[XmlElement("frequencyShoreStationReceives")]
			public int? frequencyShoreStationReceives {get;set;} = default;

			public bool ShouldSerializefrequencyShoreStationReceives() { return frequencyShoreStationReceives.HasValue; }

			[XmlElement("frequencyShoreStationTransmits")]
			public required int frequencyShoreStationTransmits {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class frequencyRange {
			[XmlElement("frequencyLimitLower")]
			public int? frequencyLimitLower {get;set;} = default;

			public bool ShouldSerializefrequencyLimitLower() { return frequencyLimitLower.HasValue; }

			[XmlElement("frequencyLimitUpper")]
			public int? frequencyLimitUpper {get;set;} = default;

			public bool ShouldSerializefrequencyLimitUpper() { return frequencyLimitUpper.HasValue; }
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
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("language")]
			public required String language {get;set;} = string.Empty;

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("linkage")]
			public required String linkage {get;set;} = string.Empty;

			[XmlElement("nameOfResource")]
			public String? nameOfResource {get;set;} = default;

			public bool ShouldSerializenameOfResource() { return !string.IsNullOrEmpty(nameOfResource); }
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
		public class radioChannelDetails {
			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("transmissionOfTrafficLists")]
			public required Boolean transmissionOfTrafficLists {get;set;} = false;

			[XmlElement("hoursOfWatch")]
			public String? hoursOfWatch {get;set;} = default;

			public bool ShouldSerializehoursOfWatch() { return !string.IsNullOrEmpty(hoursOfWatch); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class radiocommunicationIdentifier {
			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("selectiveCallNumber")]
			public int? selectiveCallNumber {get;set;} = default;

			public bool ShouldSerializeselectiveCallNumber() { return selectiveCallNumber.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rxNCode {
			[XmlElement("headline")]
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }

			[XmlElement("categoryOfRxN")]
			public categoryOfRxN? categoryOfRxN {get;set;} = default;

			public bool ShouldSerializecategoryOfRxN() { return categoryOfRxN != default; }

			[XmlElement("actionOrActivity")]
			public actionOrActivity? actionOrActivity {get;set;} = default;

			public bool ShouldSerializeactionOrActivity() { return actionOrActivity != default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne {
			[XmlElement("sectorBearing")]
			public required decimal sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			public decimal? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo {
			[XmlElement("sectorBearing")]
			public required decimal sectorBearing {get;set;} = default;

			[XmlElement("sectorLineLength")]
			public decimal? sectorLineLength {get;set;} = default;

			public bool ShouldSerializesectorLineLength() { return sectorLineLength.HasValue; }
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
		public class telecommunications {
			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("telecommunicationIdentifier")]
			public required String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public telecommunicationService? telecommunicationService {get;set;} = default;

			[JsonIgnore]
			[XmlElement("telecommunicationService")]
			public SerializableEnumeration<telecommunicationService>? telecommunicationServiceElement { get { return telecommunicationService; } set { } }

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textContent {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfText? categoryOfText {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfText")]
			public SerializableEnumeration<categoryOfText>? categoryOfTextElement { get { return categoryOfText; } set { } }

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

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class timeIntervalsByDayOfWeek {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public List<dayOfWeek> dayOfWeek {get;set;} = [];

			[JsonIgnore]
			[XmlElement("dayOfWeek")]
			public SerializableEnumeration<dayOfWeek>[] dayOfWeekElement { get { return [.. dayOfWeek]; } set { } }

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
		public class timesOfTransmission {
			[XmlElement("minutePastEvenHours")]
			public int? minutePastEvenHours {get;set;} = default;

			public bool ShouldSerializeminutePastEvenHours() { return minutePastEvenHours.HasValue; }

			[XmlElement("minutePastOddHours")]
			public int? minutePastOddHours {get;set;} = default;

			public bool ShouldSerializeminutePastOddHours() { return minutePastOddHours.HasValue; }

			[XmlElement("minutePastEveryHour")]
			public int? minutePastEveryHour {get;set;} = default;

			public bool ShouldSerializeminutePastEveryHour() { return minutePastEveryHour.HasValue; }

			[XmlElement("transmissionTime")]
			public List<S100Framework.DomainModel.S100.Time> transmissionTime {get;set;} = [];

			public bool ShouldSerializetransmissionTime() { return transmissionTime.Any(); }
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
		public class vesselMeasurementsSpecification {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,6,7,8,9,10,11,12,13])]
			public required vesselsCharacteristics vesselsCharacteristics {get;set;} = default;

			[JsonIgnore]
			[XmlElement("vesselsCharacteristics")]
			public SerializableEnumeration<vesselsCharacteristics> vesselsCharacteristicsElement { get { return vesselsCharacteristics; } set { } }

			[XmlElement("vesselsCharacteristicsValue")]
			public required decimal vesselsCharacteristicsValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,9])]
			public required vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;} = default;

			[JsonIgnore]
			[XmlElement("vesselsCharacteristicsUnit")]
			public SerializableEnumeration<vesselsCharacteristicsUnit> vesselsCharacteristicsUnitElement { get { return vesselsCharacteristicsUnit; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public required comparisonOperator comparisonOperator {get;set;} = default;

			[JsonIgnore]
			[XmlElement("comparisonOperator")]
			public SerializableEnumeration<comparisonOperator> comparisonOperatorElement { get { return comparisonOperator; } set { } }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class scheduleByDayOfWeek {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfSchedule? categoryOfSchedule {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfSchedule")]
			public SerializableEnumeration<categoryOfSchedule>? categoryOfScheduleElement { get { return categoryOfSchedule; } set { } }

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
		public class bearingInformation {
			[XmlElement("distance")]
			public decimal? distance {get;set;} = default;

			public bool ShouldSerializedistance() { return distance.HasValue; }

			[XmlElement("information")]
			public information? information {get;set;} = default;

			public bool ShouldSerializeinformation() { return information!=default; }

			[XmlElement("orientation")]
			public orientation? orientation {get;set;} = default;

			public bool ShouldSerializeorientation() { return orientation!=default; }

			[XmlElement("sectorLimit")]
			public sectorLimit? sectorLimit {get;set;} = default;

			public bool ShouldSerializesectorLimit() { return sectorLimit!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class graphic {
			[XmlElement("pictorialRepresentation")]
			public required String pictorialRepresentation {get;set;} = string.Empty;

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

	}
	public enum Role {
		[System.ComponentModel.Description("The location in which the information item applies")]
		appliesInLocation,
		[System.ComponentModel.Description("A pointer to an Authority object")]
		theAuthority,
		[System.ComponentModel.Description("The authority for which service hours are given")]
		theAuthority_srvHrs,
		[System.ComponentModel.Description("The area where the connectivity service is provided.")]
		connectivityServiceArea,
		[System.ComponentModel.Description("The provider of the connectivity service.")]
		connectivityServiceProvider,
		[System.ComponentModel.Description("A pointer to an Contact Details object")]
		theContactDetails,
		[System.ComponentModel.Description("The coordinated service area.")]
		coordinatedService,
		[System.ComponentModel.Description("The authority coordinating the service provision.")]
		coordinatingAuthority,
		[System.ComponentModel.Description("The object or class of objects to which the regulation, restriction, recommendation, or nautical information applies")]
		isApplicableTo,
		[System.ComponentModel.Description("The location for which service hours are given")]
		location_srvHrs,
		[System.ComponentModel.Description("The work hours for a non-standard workday")]
		partialWorkingDay,
		[System.ComponentModel.Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.")]
		permission,
		[System.ComponentModel.Description("The area served by a service provider")]
		serviceArea,
		[System.ComponentModel.Description("Service hours for an authority ore service provider")]
		theServiceHours,
		[System.ComponentModel.Description("Pointer to service or facility")]
		servicePlace,
		[System.ComponentModel.Description("Pointer to a feature from where a provider supplies a service")]
		serviceProvider,
		[System.ComponentModel.Description("The applicable regulation, restriction, recommendation or nautical information")]
		theApplicableRxN,
		[System.ComponentModel.Description("The details of the broadcast service, such as the content and schedule.")]
		theBroadcastDetails,
		[System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
		theCartographicText,
		[System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
		theCollection,
		[System.ComponentModel.Description("A pointer to a part in a whole-part relationship.")]
		theComponent,
		[System.ComponentModel.Description("A pointer to the centre controlling or operating the service.")]
		theControlCentre,
		[System.ComponentModel.Description("A pointer to the controlled or operated service.")]
		theControlledService,
		[System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
		theInformation,
		[System.ComponentModel.Description("The organisation to which information relates")]
		theOrganisation,
		[System.ComponentModel.Description("A pointer to a specific feature(s).")]
		thePositionProvider,
		[System.ComponentModel.Description("The connectivity QoS information for the area.")]
		theQoS,
		[System.ComponentModel.Description("The area where the connectivity QoS information applies.")]
		theQoSArea,
		[System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
		theQualityInformation,
		[System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
		theRxN,
		[System.ComponentModel.Description("The usual service hours to which an exception applies")]
		theServiceHours_nsdy,
		[System.ComponentModel.Description("The details of the radio transmission service.")]
		theTransmissionDetails,
		[System.ComponentModel.Description("The location to which the permission statement applies")]
		vslLocation,
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
		/// Association between a geographic location and a regulation, restriction, recommendation, or nautical information
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AssociatedRxN : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AssociatedRxN);
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
		/// Available Quality of Service (QoS) within the area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AvailableQoS : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AvailableQoS);
		}

		/// <summary>
		/// The broadcast content and schedule of a service area or facility
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BroadcastService : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(BroadcastService);
		}

		/// <summary>
		/// The transmission details for the broadcast or the broadcast details available from the transmission
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BroadcastTransmission : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(BroadcastTransmission);
		}

		/// <summary>
		/// The service that allows users to connect to the internet.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ConnectivityService : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ConnectivityService);
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
		/// Association class specifying the relationship between the subset of vessels described by an APPLIC data object and a regulation (restriction, recommendation, or nautical information).
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InclusionType : InformationAssociation {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			public required membership membership {get;set;} = default;

			[JsonIgnore]
			[XmlElement("membership")]
			public SerializableEnumeration<membership> membershipElement { get { return membership; } set { } }

			[JsonIgnore]
			public override string Code => nameof(InclusionType);
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
		/// Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit,  enter, or use  a feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PermissionType : InformationAssociation {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public required categoryOfRelationship categoryOfRelationship {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfRelationship")]
			public SerializableEnumeration<categoryOfRelationship> categoryOfRelationshipElement { get { return categoryOfRelationship; } set { } }

			[JsonIgnore]
			public override string Code => nameof(PermissionType);
		}

		/// <summary>
		/// The radio control centre for a marine radio service
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioServiceControl : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(RadioServiceControl);
		}

		/// <summary>
		/// Related organisation
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class relatedOrganisation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(relatedOrganisation);
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
		/// The coordinating authority for a service area
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceCoordination : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ServiceCoordination);
		}

		/// <summary>
		/// An association for the binding between a spatial type and its spatial quality information.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialAssociation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(SpatialAssociation);
		}

		/// <summary>
		/// The radio transmission of a service area or facility
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TransmissionService : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(TransmissionService);
		}
	}

	namespace FeatureAssociations {
		/// <summary>
		/// A feature association for the binding between an aggregation feature that describes areas of varying uncertainty about a service or phenomenon and a geographic feature describing the service or phenomenon.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class coreAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(coreAggregation);
		}

		/// <summary>
		/// A feature association for the binding between an aggregation feature that describes areas of varying uncertainty about a service or phenomenon and zones of uncertainty about the service or phenomenon.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class fuzzyZoneAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(fuzzyZoneAggregation);
		}

		/// <summary>
		/// Association linking the location from which a service is provided and the area(s) served.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceProvisionArea : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(ServiceProvisionArea);
		}

		/// <summary>
		/// A feature association for the binding between a geo feature and the cartographically positioned location for text.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextAssociation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(TextAssociation);
		}
	}

}

namespace S100Framework.DomainModel.S123 {
	using ComplexAttributes;
	using InformationAssociations;

	namespace InformationTypes {
		/// <summary>
		/// Generalized information type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class InformationType : InformationNode, IInformationBindingDefinition {
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

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
					role = Enum.GetName<Role>(Role.theInformation)!,
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
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[XmlElement("graphic")]
			public List<graphic> graphic {get;set;} = [];

			public bool ShouldSerializegraphic() { return graphic.Any(); }

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
					association = nameof(InclusionType),
					role = Enum.GetName<Role>(Role.isApplicableTo)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(relatedOrganisation),
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

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public List<categoryOfVessel> categoryOfVessel {get;set;} = [];

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfVesselRegistry? categoryOfVesselRegistry {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfVesselRegistry")]
			public SerializableEnumeration<categoryOfVesselRegistry>? categoryOfVesselRegistryElement { get { return categoryOfVesselRegistry; } set { } }

			public bool ShouldSerializecategoryOfVesselRegistry() { return categoryOfVesselRegistry.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
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

			[XmlElement("vesselMeasurementsSpecification")]
			public List<vesselMeasurementsSpecification> vesselMeasurementsSpecification {get;set;} = [];

			public bool ShouldSerializevesselMeasurementsSpecification() { return vesselMeasurementsSpecification.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

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
					upper =  1,
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
		/// Description of the content and schedule of a service using broadcast technology of radiocommunications to deliver information (to every receiver within a direct range). Online resource to access the content may also be included.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BroadcastDetails : InformationType {
			[XmlElement("language")]
			public List<String> language {get;set;} = [];

			public bool ShouldSerializelanguage() { return language.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfBroadcastCommunication? categoryOfBroadcastCommunication {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfBroadcastCommunication")]
			public SerializableEnumeration<categoryOfBroadcastCommunication>? categoryOfBroadcastCommunicationElement { get { return categoryOfBroadcastCommunication; } set { } }

			public bool ShouldSerializecategoryOfBroadcastCommunication() { return categoryOfBroadcastCommunication.HasValue; }

			[XmlElement("broadcastContent")]
			public List<broadcastContent> broadcastContent {get;set;} = [];

			public bool ShouldSerializebroadcastContent() { return broadcastContent.Any(); }

			[XmlElement("timesOfTransmission")]
			public List<timesOfTransmission> timesOfTransmission {get;set;} = [];

			public bool ShouldSerializetimesOfTransmission() { return timesOfTransmission.Any(); }

			[XmlElement("timeIntervalsByDayOfWeek")]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }

			[XmlElement("onlineResource")]
			public onlineResource? onlineResource {get;set;} = default;

			public bool ShouldSerializeonlineResource() { return onlineResource!=default; }

			[JsonIgnore]
			public override string Code => nameof(BroadcastDetails);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..BroadcastDetails._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastTransmission),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Information related to the Quality of Service (QoS) of the connectivity.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ConnectivityQualityOfService : InformationType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public List<typeOfConnectivityResource> typeOfConnectivityResource {get;set;} = [];

			[JsonIgnore]
			[XmlElement("typeOfConnectivityResource")]
			public SerializableEnumeration<typeOfConnectivityResource>[] typeOfConnectivityResourceElement { get { return [.. typeOfConnectivityResource]; } set { } }

			public bool ShouldSerializetypeOfConnectivityResource() { return typeOfConnectivityResource.Any(); }

			[XmlElement("uplinkBandwidth")]
			public decimal? uplinkBandwidth {get;set;} = default;

			public bool ShouldSerializeuplinkBandwidth() { return uplinkBandwidth.HasValue; }

			[XmlElement("downlinkBandwidth")]
			public decimal? downlinkBandwidth {get;set;} = default;

			public bool ShouldSerializedownlinkBandwidth() { return downlinkBandwidth.HasValue; }

			[XmlElement("packetDelay")]
			public decimal? packetDelay {get;set;} = default;

			public bool ShouldSerializepacketDelay() { return packetDelay.HasValue; }

			[XmlElement("maximumDataBurstVolume")]
			public int? maximumDataBurstVolume {get;set;} = default;

			public bool ShouldSerializemaximumDataBurstVolume() { return maximumDataBurstVolume.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17,25,26,27])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(ConnectivityQualityOfService);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ConnectivityQualityOfService._informationBindingDefinitions];
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
			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("information")]
			public information? information {get;set;} = default;

			public bool ShouldSerializeinformation() { return information!=default; }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[XmlElement("callName")]
			public String? callName {get;set;} = default;

			public bool ShouldSerializecallName() { return !string.IsNullOrEmpty(callName); }

			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[JsonIgnore]
			public override string Code => nameof(ContactDetails);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ContactDetails._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AuthorityContact),
					role = Enum.GetName<Role>(Role.theAuthority)!,
					informationTypes = [nameof(Authority),nameof(RadioControlCentre)],
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
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("dateFixed")]
			public List<String> dateFixed {get;set;} = [];

			public bool ShouldSerializedateFixed() { return dateFixed.Any(); }

			[XmlElement("dateVariable")]
			public List<String> dateVariable {get;set;} = [];

			public bool ShouldSerializedateVariable() { return dateVariable.Any(); }

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
		/// The control centre of the radio service or radio stations
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioControlCentre : InformationType {
			[XmlElement("isMRCC")]
			public Boolean? isMRCC {get;set;} = default;

			public bool ShouldSerializeisMRCC() { return isMRCC.HasValue; }

			[XmlElement("acceptAMVER")]
			public Boolean? acceptAMVER {get;set;} = default;

			public bool ShouldSerializeacceptAMVER() { return acceptAMVER.HasValue; }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("hoursOfWatch")]
			public String? hoursOfWatch {get;set;} = default;

			public bool ShouldSerializehoursOfWatch() { return !string.IsNullOrEmpty(hoursOfWatch); }

			[JsonIgnore]
			public override string Code => nameof(RadioControlCentre);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..RadioControlCentre._informationBindingDefinitions];
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
					upper =  1,
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
					association = nameof(AuthorityHours),
					role = Enum.GetName<Role>(Role.theAuthority)!,
					informationTypes = [nameof(Authority),nameof(RadioControlCentre)],
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
		/// The indication of the quality of the locational information for features in a dataset.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQuality : InformationNode, IInformationBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfHorizontalMeasurement")]
			public SerializableEnumeration<qualityOfHorizontalMeasurement>? qualityOfHorizontalMeasurementElement { get { return qualityOfHorizontalMeasurement; } set { } }

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

		/// <summary>
		/// Description of the radiocommunication service with respect to the radio method and radio channels for the transfer of information by means of signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TransmissionDetails : InformationType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public typeOfRadioService? typeOfRadioService {get;set;} = default;

			[JsonIgnore]
			[XmlElement("typeOfRadioService")]
			public SerializableEnumeration<typeOfRadioService>? typeOfRadioServiceElement { get { return typeOfRadioService; } set { } }

			public bool ShouldSerializetypeOfRadioService() { return typeOfRadioService.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public frequencyBand? frequencyBand {get;set;} = default;

			[JsonIgnore]
			[XmlElement("frequencyBand")]
			public SerializableEnumeration<frequencyBand>? frequencyBandElement { get { return frequencyBand; } set { } }

			public bool ShouldSerializefrequencyBand() { return frequencyBand.HasValue; }

			[XmlElement("classOfEmission")]
			public String? classOfEmission {get;set;} = default;

			public bool ShouldSerializeclassOfEmission() { return !string.IsNullOrEmpty(classOfEmission); }

			[XmlElement("communicationStandard")]
			public String? communicationStandard {get;set;} = default;

			public bool ShouldSerializecommunicationStandard() { return !string.IsNullOrEmpty(communicationStandard); }

			[XmlElement("radioChannelDetails")]
			public List<radioChannelDetails> radioChannelDetails {get;set;} = [];

			public bool ShouldSerializeradioChannelDetails() { return radioChannelDetails.Any(); }

			[JsonIgnore]
			public override string Code => nameof(TransmissionDetails);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..TransmissionDetails._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastTransmission),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
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
		/// Generalized feature type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FeatureType : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("textContent")]
			public List<textContent> textContent {get;set;} = [];

			public bool ShouldSerializetextContent() { return textContent.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
					association = nameof(PermissionType),
					role = Enum.GetName<Role>(Role.permission)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
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
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// An area of connectivity coverage available for the subscription of connectivity service.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ConnectivitySubscriptionArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfConnectivitySubscription? categoryOfConnectivitySubscription {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfConnectivitySubscription")]
			public SerializableEnumeration<categoryOfConnectivitySubscription>? categoryOfConnectivitySubscriptionElement { get { return categoryOfConnectivitySubscription; } set { } }

			public bool ShouldSerializecategoryOfConnectivitySubscription() { return categoryOfConnectivitySubscription.HasValue; }

			[XmlElement("communicationStandard")]
			public String? communicationStandard {get;set;} = default;

			public bool ShouldSerializecommunicationStandard() { return !string.IsNullOrEmpty(communicationStandard); }

			[XmlElement("estimatedRangeOfTransmission")]
			public decimal? estimatedRangeOfTransmission {get;set;} = default;

			public bool ShouldSerializeestimatedRangeOfTransmission() { return estimatedRangeOfTransmission.HasValue; }

			[XmlElement("baseStationAntennaHeight")]
			public decimal? baseStationAntennaHeight {get;set;} = default;

			public bool ShouldSerializebaseStationAntennaHeight() { return baseStationAntennaHeight.HasValue; }

			[XmlElement("frequencyRange")]
			public List<frequencyRange> frequencyRange {get;set;} = [];

			public bool ShouldSerializefrequencyRange() { return frequencyRange.Any(); }

			[XmlElement("sectorLimit")]
			public List<sectorLimit> sectorLimit {get;set;} = [];

			public bool ShouldSerializesectorLimit() { return sectorLimit.Any(); }

			[XmlElement("coverageIndication")]
			public coverageIndication? coverageIndication {get;set;} = default;

			public bool ShouldSerializecoverageIndication() { return coverageIndication!=default; }

			[JsonIgnore]
			public override string Code => nameof(ConnectivitySubscriptionArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..ConnectivitySubscriptionArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ConnectivityService),
					role = Enum.GetName<Role>(Role.connectivityServiceProvider)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AvailableQoS),
					role = Enum.GetName<Role>(Role.theQoS)!,
					informationTypes = [nameof(ConnectivityQualityOfService)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..ConnectivitySubscriptionArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..ConnectivitySubscriptionArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
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
		/// An area defined for a global communications service based upon automated systems, both satellite based and terrestrial, to provide distress alerting and promulgation of maritime safety information for mariners.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class GMDSSArea : FeatureType {
			[XmlElement("idNAVAREA")]
			public required String idNAVAREA {get;set;} = string.Empty;

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfGMDSSArea categoryOfGMDSSArea {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfGMDSSArea")]
			public SerializableEnumeration<categoryOfGMDSSArea> categoryOfGMDSSAreaElement { get { return categoryOfGMDSSArea; } set { } }

			[XmlElement("areaA3ServiceDescription")]
			public areaA3ServiceDescription? areaA3ServiceDescription {get;set;} = default;

			public bool ShouldSerializeareaA3ServiceDescription() { return areaA3ServiceDescription!=default; }

			[JsonIgnore]
			public override string Code => nameof(GMDSSArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..GMDSSArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RadioServiceControl),
					role = Enum.GetName<Role>(Role.theControlCentre)!,
					informationTypes = [nameof(RadioControlCentre)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..GMDSSArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..GMDSSArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
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
		/// A region in which the perception of a phenomenon or the availability of a service is known only to a specified level of confidence.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IndeterminateZone : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public informationConfidence? informationConfidence {get;set;} = default;

			[JsonIgnore]
			[XmlElement("informationConfidence")]
			public SerializableEnumeration<informationConfidence>? informationConfidenceElement { get { return informationConfidence; } set { } }

			public bool ShouldSerializeinformationConfidence() { return informationConfidence.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(IndeterminateZone);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..IndeterminateZone._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..IndeterminateZone._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..IndeterminateZone._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 1,
					upper =  1,
					association = nameof(fuzzyZoneAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FuzzyAreaAggregate)],
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
		/// A geographical sea area (which may include inland seas, lakes and waterways navigable by seagoing ships) established for the purpose of coordinating the broadcast of marine meteorological information.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MetArea : FeatureType {
			[XmlElement("idMETAREA")]
			public required String idMETAREA {get;set;} = string.Empty;

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[JsonIgnore]
			public override string Code => nameof(MetArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..MetArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..MetArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..MetArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
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
		/// A geographical sea area (which may include inland seas, lakes and waterways navigable by seagoing ships) established for the purpose of coordinating the broadcast of navigational warnings.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavArea : FeatureType {
			[XmlElement("idNAVAREA")]
			public required String idNAVAREA {get;set;} = string.Empty;

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[JsonIgnore]
			public override string Code => nameof(NavArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..NavArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..NavArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..NavArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
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
		/// A unique and precisely defined sea area, wholly contained within the NAVTEX coverage area, for which maritime safety information is provided from a particular NAVTEX transmitter.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavtexServiceArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2])]
			public required typeOfNAVTEXService typeOfNAVTEXService {get;set;} = default;

			[JsonIgnore]
			[XmlElement("typeOfNAVTEXService")]
			public SerializableEnumeration<typeOfNAVTEXService> typeOfNAVTEXServiceElement { get { return typeOfNAVTEXService; } set { } }

			[XmlElement("idNAVAREA")]
			public required String idNAVAREA {get;set;} = string.Empty;

			[XmlElement("transmitterIdentificationCharacter")]
			public required String transmitterIdentificationCharacter {get;set;} = string.Empty;

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,4,7])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(NavtexServiceArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..NavtexServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..NavtexServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..NavtexServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
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
		/// The area where a radio service can be obtained and the characteristics of the radio transmission.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioServiceArea : FeatureType {
			[XmlElement("languageInformation")]
			public String? languageInformation {get;set;} = default;

			public bool ShouldSerializelanguageInformation() { return !string.IsNullOrEmpty(languageInformation); }

			[XmlElement("transmissionPower")]
			public decimal? transmissionPower {get;set;} = default;

			public bool ShouldSerializetransmissionPower() { return transmissionPower.HasValue; }

			[XmlElement("transmissionOfTrafficLists")]
			public Boolean? transmissionOfTrafficLists {get;set;} = default;

			public bool ShouldSerializetransmissionOfTrafficLists() { return transmissionOfTrafficLists.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14,16,17])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("hoursOfWatch")]
			public String? hoursOfWatch {get;set;} = default;

			public bool ShouldSerializehoursOfWatch() { return !string.IsNullOrEmpty(hoursOfWatch); }

			[JsonIgnore]
			public override string Code => nameof(RadioServiceArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RadioServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RadioServiceControl),
					role = Enum.GetName<Role>(Role.theControlCentre)!,
					informationTypes = [nameof(RadioControlCentre)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RadioServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RadioServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(coreAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RadioServiceAreaAggregate)],
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
		/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioStation : FeatureType {
			[XmlIgnore]
			[EnumerationValue([5,10,19,20])]
			public categoryOfRadioStation? categoryOfRadioStation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfRadioStation")]
			public SerializableEnumeration<categoryOfRadioStation>? categoryOfRadioStationElement { get { return categoryOfRadioStation; } set { } }

			public bool ShouldSerializecategoryOfRadioStation() { return categoryOfRadioStation.HasValue; }

			[XmlElement("estimatedRangeOfTransmission")]
			public decimal? estimatedRangeOfTransmission {get;set;} = default;

			public bool ShouldSerializeestimatedRangeOfTransmission() { return estimatedRangeOfTransmission.HasValue; }

			[XmlElement("transmissionContent")]
			public String? transmissionContent {get;set;} = default;

			public bool ShouldSerializetransmissionContent() { return !string.IsNullOrEmpty(transmissionContent); }

			[XmlElement("remoteControlled")]
			public Boolean? remoteControlled {get;set;} = default;

			public bool ShouldSerializeremoteControlled() { return remoteControlled.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,16,17])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[XmlElement("radiocommunicationIdentifier")]
			public required radiocommunicationIdentifier radiocommunicationIdentifier {get;set;} = default;

			[XmlElement("sectorLimit")]
			public List<sectorLimit> sectorLimit {get;set;} = [];

			public bool ShouldSerializesectorLimit() { return sectorLimit.Any(); }

			[XmlElement("hoursOfWatch")]
			public String? hoursOfWatch {get;set;} = default;

			public bool ShouldSerializehoursOfWatch() { return !string.IsNullOrEmpty(hoursOfWatch); }

			[JsonIgnore]
			public override string Code => nameof(RadioStation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RadioStation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RadioServiceControl),
					role = Enum.GetName<Role>(Role.theControlCentre)!,
					informationTypes = [nameof(RadioControlCentre)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RadioStation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RadioStation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceArea)!,
					featureTypes = [nameof(ConnectivitySubscriptionArea),nameof(GMDSSArea),nameof(MetArea),nameof(NavArea),nameof(NavtexServiceArea),nameof(RadioServiceArea),nameof(WeatherForecastAndWarningArea)],
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
		/// An area for which weather forecasts and warnings are provided for specified periods.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WeatherForecastAndWarningArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required categoryOfForecastOrWarningArea categoryOfForecastOrWarningArea {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfForecastOrWarningArea")]
			public SerializableEnumeration<categoryOfForecastOrWarningArea> categoryOfForecastOrWarningAreaElement { get { return categoryOfForecastOrWarningArea; } set { } }

			[XmlElement("idMETAREA")]
			public String? idMETAREA {get;set;} = default;

			public bool ShouldSerializeidMETAREA() { return !string.IsNullOrEmpty(idMETAREA); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,14])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(WeatherForecastAndWarningArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..WeatherForecastAndWarningArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceCoordination),
					role = Enum.GetName<Role>(Role.coordinatingAuthority)!,
					informationTypes = [nameof(Authority)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceContact),
					role = Enum.GetName<Role>(Role.theContactDetails)!,
					informationTypes = [nameof(ContactDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(LocationHours),
					role = Enum.GetName<Role>(Role.theServiceHours)!,
					informationTypes = [nameof(ServiceHours)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BroadcastService),
					role = Enum.GetName<Role>(Role.theBroadcastDetails)!,
					informationTypes = [nameof(BroadcastDetails)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TransmissionService),
					role = Enum.GetName<Role>(Role.theTransmissionDetails)!,
					informationTypes = [nameof(TransmissionDetails)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..WeatherForecastAndWarningArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..WeatherForecastAndWarningArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(RadioStation)],
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
		/// Aggregation of a geographic feature describing a service or phenomenon with zones of different confidence about the availability of the service, occurrence of the phenomenon, or applicability of the information described by the geographic feature.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class FuzzyAreaAggregate : FeatureType {
			[JsonIgnore]
			public override string Code => nameof(FuzzyAreaAggregate);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..FuzzyAreaAggregate._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..FuzzyAreaAggregate._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..FuzzyAreaAggregate._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 1,
					upper =  default,
					association = nameof(fuzzyZoneAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(IndeterminateZone)],
				},
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Aggregation of areas where radio services from a single radio service are available to different levels of reliability.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioServiceAreaAggregate : FuzzyAreaAggregate {
			[JsonIgnore]
			public override string Code => nameof(RadioServiceAreaAggregate);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FuzzyAreaAggregate._informationBindingDefinitions, ..RadioServiceAreaAggregate._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FuzzyAreaAggregate._featureBindingDefinitions, ..RadioServiceAreaAggregate._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FuzzyAreaAggregate._primitives, ..RadioServiceAreaAggregate._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 1,
					upper =  1,
					association = nameof(coreAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(RadioServiceArea)],
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

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
			[XmlIgnore]
			[EnumerationValue([1,4,5])]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfTemporalVariation")]
			public SerializableEnumeration<categoryOfTemporalVariation>? categoryOfTemporalVariationElement { get { return categoryOfTemporalVariation; } set { } }

			public bool ShouldSerializecategoryOfTemporalVariation() { return categoryOfTemporalVariation.HasValue; }

			[XmlElement("horizontalDistanceUncertainty")]
			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

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

			[XmlElement("interoperabilityIdentifier")]
			public String? interoperabilityIdentifier {get;set;} = default;

			public bool ShouldSerializeinteroperabilityIdentifier() { return !string.IsNullOrEmpty(interoperabilityIdentifier); }

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
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("textOffsetBearing")]
			public required int textOffsetBearing {get;set;} = default;

			[XmlElement("textOffsetDistance")]
			public required int textOffsetDistance {get;set;} = default;

			[XmlElement("textRotation")]
			public Boolean? textRotation {get;set;} = default;

			public bool ShouldSerializetextRotation() { return textRotation.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1])]
			public List<textType> textType {get;set;} = [];

			[JsonIgnore]
			[XmlElement("textType")]
			public SerializableEnumeration<textType>[] textTypeElement { get { return [.. textType]; } set { } }

			public bool ShouldSerializetextType() { return textType.Any(); }

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
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.thePositionProvider)!,
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

	[XmlType(Namespace = "http://www.iho.int/S123/1.1")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S123/1.1 123_1.1.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S123/1.1", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.Applicability", typeof(InformationTypes.Applicability), Order = 1, ElementName = "Applicability")]
		[XmlElement("InformationTypes.Authority", typeof(InformationTypes.Authority), Order = 1, ElementName = "Authority")]
		[XmlElement("InformationTypes.BroadcastDetails", typeof(InformationTypes.BroadcastDetails), Order = 1, ElementName = "BroadcastDetails")]
		[XmlElement("InformationTypes.ConnectivityQualityOfService", typeof(InformationTypes.ConnectivityQualityOfService), Order = 1, ElementName = "ConnectivityQualityOfService")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.NauticalInformation", typeof(InformationTypes.NauticalInformation), Order = 1, ElementName = "NauticalInformation")]
		[XmlElement("InformationTypes.NonStandardWorkingDay", typeof(InformationTypes.NonStandardWorkingDay), Order = 1, ElementName = "NonStandardWorkingDay")]
		[XmlElement("InformationTypes.RadioControlCentre", typeof(InformationTypes.RadioControlCentre), Order = 1, ElementName = "RadioControlCentre")]
		[XmlElement("InformationTypes.Recommendations", typeof(InformationTypes.Recommendations), Order = 1, ElementName = "Recommendations")]
		[XmlElement("InformationTypes.Regulations", typeof(InformationTypes.Regulations), Order = 1, ElementName = "Regulations")]
		[XmlElement("InformationTypes.Restrictions", typeof(InformationTypes.Restrictions), Order = 1, ElementName = "Restrictions")]
		[XmlElement("InformationTypes.ServiceHours", typeof(InformationTypes.ServiceHours), Order = 1, ElementName = "ServiceHours")]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1, ElementName = "SpatialQuality")]
		[XmlElement("InformationTypes.TransmissionDetails", typeof(InformationTypes.TransmissionDetails), Order = 1, ElementName = "TransmissionDetails")]
		[XmlElement("FeatureTypes.ConnectivitySubscriptionArea", typeof(FeatureTypes.ConnectivitySubscriptionArea), Order = 1, ElementName = "ConnectivitySubscriptionArea")]
		[XmlElement("FeatureTypes.GMDSSArea", typeof(FeatureTypes.GMDSSArea), Order = 1, ElementName = "GMDSSArea")]
		[XmlElement("FeatureTypes.IndeterminateZone", typeof(FeatureTypes.IndeterminateZone), Order = 1, ElementName = "IndeterminateZone")]
		[XmlElement("FeatureTypes.MetArea", typeof(FeatureTypes.MetArea), Order = 1, ElementName = "MetArea")]
		[XmlElement("FeatureTypes.NavArea", typeof(FeatureTypes.NavArea), Order = 1, ElementName = "NavArea")]
		[XmlElement("FeatureTypes.NavtexServiceArea", typeof(FeatureTypes.NavtexServiceArea), Order = 1, ElementName = "NavtexServiceArea")]
		[XmlElement("FeatureTypes.RadioServiceArea", typeof(FeatureTypes.RadioServiceArea), Order = 1, ElementName = "RadioServiceArea")]
		[XmlElement("FeatureTypes.RadioStation", typeof(FeatureTypes.RadioStation), Order = 1, ElementName = "RadioStation")]
		[XmlElement("FeatureTypes.WeatherForecastAndWarningArea", typeof(FeatureTypes.WeatherForecastAndWarningArea), Order = 1, ElementName = "WeatherForecastAndWarningArea")]
		[XmlElement("FeatureTypes.RadioServiceAreaAggregate", typeof(FeatureTypes.RadioServiceAreaAggregate), Order = 1, ElementName = "RadioServiceAreaAggregate")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.QualityOfNonBathymetricData", typeof(FeatureTypes.QualityOfNonBathymetricData), Order = 1, ElementName = "QualityOfNonBathymetricData")]
		[XmlElement("FeatureTypes.TextPlacement", typeof(FeatureTypes.TextPlacement), Order = 1, ElementName = "TextPlacement")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
