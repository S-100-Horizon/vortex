using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S127 {
	public static class Summary
	{
		public static Version Version => new Version("2.0.0");
		public static string[] ComplexTypes => ["bearingInformation","contactAddress","featureName","fixedDateRange","frequencyPair","graphic","horizontalPositionUncertainty","information","noticeTime","onlineResource","orientation","scheduleByDayOfWeek","periodicDateRange","radiocommunications","rxNCode","sourceIndication","surveyDateRange","telecommunications","textContent","timeIntervalsByDayOfWeek","underKeelAllowance","vesselsMeasurements"];
		public static string[] InformationAssociationTypes => ["AdditionalInformation","AuthorityContact","AuthorityHours","AssociatedRxN","ExceptionalWorkday","InclusionType","PermissionType","RelatedOrganisation","ReportingAuthority","ReportingRequirement","ServiceContact","ServiceControl","SpatialAssociation","LocationHours","TrafficServiceReport"];
		public static string[] FeatureAssociationTypes => ["ServiceProvisionArea","PilotageDistrictAssociation","TextAssociation","TrafficControlServiceAggregation"];
		public static string[] InformationTypes => ["InformationType","AbstractRxN","Applicability","Authority","ContactDetails","NauticalInformation","NonStandardWorkingDay","ServiceHours","ShipReport","Recommendations","Regulations","Restrictions","SpatialQuality","SpatialQualityPoints"];
		public static string[] FeatureTypes => ["CautionArea","ConcentrationOfShippingHazardArea","ISPSCodeSecurityLevel","LocalPortServiceArea","MilitaryPracticeArea","PilotBoardingPlace","PilotService","PilotageDistrict","PiracyRiskArea","PlaceOfRefuge","RadarRange","RadioCallingInPoint","RestrictedAreaNavigational","RestrictedAreaRegulatory","RouteingMeasure","ShipReportingServiceArea","SignalStationWarning","SignalStationTraffic","UnderKeelClearanceAllowanceArea","UnderKeelClearanceManagementArea","VesselTrafficServiceArea","WaterwayArea","DataCoverage","QualityOfNonBathymetricData","TextPlacement"];
		public static string[] PrimitiveFeatures(Primitives primitive) => primitive switch {
			Primitives.noGeometry => ["FeatureType","OrganizationContactArea","SupervisedArea","ReportableServiceArea"],
			Primitives.point => ["CautionArea","MilitaryPracticeArea","PilotBoardingPlace","PiracyRiskArea","PlaceOfRefuge","RadioCallingInPoint","SignalStationWarning","SignalStationTraffic","TextPlacement"],
			Primitives.surface => ["CautionArea","ConcentrationOfShippingHazardArea","ISPSCodeSecurityLevel","LocalPortServiceArea","MilitaryPracticeArea","PilotBoardingPlace","PilotService","PilotageDistrict","PiracyRiskArea","PlaceOfRefuge","RadarRange","RestrictedAreaNavigational","RestrictedAreaRegulatory","RouteingMeasure","ShipReportingServiceArea","SignalStationWarning","SignalStationTraffic","UnderKeelClearanceAllowanceArea","UnderKeelClearanceManagementArea","VesselTrafficServiceArea","WaterwayArea","DataQuality","QualityOfTemporalVariation","DataCoverage","QualityOfNonBathymetricData"],
			Primitives.curve => ["ISPSCodeSecurityLevel","RadioCallingInPoint","RouteingMeasure"],
			_ => throw new InvalidOperationException(),
		};
		public static Primitives[] FeaturePrimitives(string featureType) => featureType switch {
			"FeatureType" => [Primitives.noGeometry],
			"OrganizationContactArea" => [Primitives.noGeometry],
			"SupervisedArea" => [Primitives.noGeometry],
			"ReportableServiceArea" => [Primitives.noGeometry],
			"CautionArea" => [Primitives.point,Primitives.surface],
			"ConcentrationOfShippingHazardArea" => [Primitives.surface],
			"ISPSCodeSecurityLevel" => [Primitives.curve,Primitives.surface],
			"LocalPortServiceArea" => [Primitives.surface],
			"MilitaryPracticeArea" => [Primitives.point,Primitives.surface],
			"PilotBoardingPlace" => [Primitives.point,Primitives.surface],
			"PilotService" => [Primitives.surface],
			"PilotageDistrict" => [Primitives.surface],
			"PiracyRiskArea" => [Primitives.point,Primitives.surface],
			"PlaceOfRefuge" => [Primitives.point,Primitives.surface],
			"RadarRange" => [Primitives.surface],
			"RadioCallingInPoint" => [Primitives.point,Primitives.curve],
			"RestrictedAreaNavigational" => [Primitives.surface],
			"RestrictedAreaRegulatory" => [Primitives.surface],
			"RouteingMeasure" => [Primitives.surface,Primitives.curve],
			"ShipReportingServiceArea" => [Primitives.surface],
			"SignalStationWarning" => [Primitives.point,Primitives.surface],
			"SignalStationTraffic" => [Primitives.point,Primitives.surface],
			"UnderKeelClearanceAllowanceArea" => [Primitives.surface],
			"UnderKeelClearanceManagementArea" => [Primitives.surface],
			"VesselTrafficServiceArea" => [Primitives.surface],
			"WaterwayArea" => [Primitives.surface],
			"DataQuality" => [Primitives.surface],
			"QualityOfTemporalVariation" => [Primitives.surface],
			"DataCoverage" => [Primitives.surface],
			"QualityOfNonBathymetricData" => [Primitives.surface],
			"TextPlacement" => [Primitives.point],
			_ or "" => throw new InvalidOperationException(),
		};
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
	public enum categoryOfConcentrationOfShippingHazardArea : int {
		[System.ComponentModel.Description("ConcentrationOfVesselsWhosePrimaryPurposeIsToEngageInCommerceIncludingFerries")]
		[EnumMember(Value = "Concentration of Merchant Shipping")] 
		[XmlEnum("1")] 
		ConcentrationOfMerchantShipping = 1,

		[System.ComponentModel.Description("ConcentrationOfPoweredOrSailingVesselsPrincipallyEngagedInRecreationLeisureOrSportingCompetition")]
		[EnumMember(Value = "Concentration of Recreational Vessels")] 
		[XmlEnum("2")] 
		ConcentrationOfRecreationalVessels = 2,

		[System.ComponentModel.Description("ConcentrationOfVesselsWhosePrimaryPurposeIsToHuntTrapOrProcessFishTheConcentrationCouldBeOnTheFishingGroundInTransitOrInTheApproachesToHomeBasesOrFishMarkets")]
		[EnumMember(Value = "Concentration of Fishing Vessels")] 
		[XmlEnum("3")] 
		ConcentrationOfFishingVessels = 3,

		[System.ComponentModel.Description("ConcentrationOfVesselsPrincipallyEngagedInMilitaryActivitiesThisIncludesActivitiesBasedOnMandateOfInternationalOrganizationsForExampleUnTheConcentrationIsInAreasOthersThanMilitaryExerciseAreas")]
		[EnumMember(Value = "Concentration of Military Vessels")] 
		[XmlEnum("4")] 
		ConcentrationOfMilitaryVessels = 4,
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
	public enum categoryOfMaritimeBroadcast : int {
		[System.ComponentModel.Description("AMessageContainingUrgentInformationRelevantToSafeNavigationBroadcastToShipsInAccordanceWithTheProvisionsOfTheInternationalConventionForTheSafetyOfLifeAtSea1974AsAmended")]
		[EnumMember(Value = "Navigational Warning")] 
		[XmlEnum("1")] 
		NavigationalWarning = 1,

		[System.ComponentModel.Description("WarningOfAdverseWeatherConditions")]
		[EnumMember(Value = "Meteorological Warning")] 
		[XmlEnum("2")] 
		MeteorologicalWarning = 2,

		[System.ComponentModel.Description("ReportOfTheIceSituationAndRestrictionsToShipping")]
		[EnumMember(Value = "Ice Report")] 
		[XmlEnum("3")] 
		IceReport = 3,

		[System.ComponentModel.Description("BroadcastMessageWithInformationAboutAnOngoingSearchAndRescueOperation")]
		[EnumMember(Value = "SAR Information")] 
		[XmlEnum("4")] 
		SarInformation = 4,

		[System.ComponentModel.Description("WarningOfPossibleAttackByPirates")]
		[EnumMember(Value = "Pirate Attack Warning")] 
		[XmlEnum("5")] 
		PirateAttackWarning = 5,

		[System.ComponentModel.Description("BroadcastMessageContainingMeteorologicalForecast")]
		[EnumMember(Value = "Meteorological Forecast")] 
		[XmlEnum("6")] 
		MeteorologicalForecast = 6,

		[System.ComponentModel.Description("BroadcastMessageAboutAPilotService")]
		[EnumMember(Value = "Pilot Service Message")] 
		[XmlEnum("7")] 
		PilotServiceMessage = 7,

		[System.ComponentModel.Description("BroadcastMessageAboutAisInformation")]
		[EnumMember(Value = "AIS Information")] 
		[XmlEnum("8")] 
		AisInformation = 8,

		[System.ComponentModel.Description("BroadcastMessageAboutTheLoranService")]
		[EnumMember(Value = "LORAN Message")] 
		[XmlEnum("9")] 
		LoranMessage = 9,

		[System.ComponentModel.Description("BroadcastMessageAboutSatelliteNavigationService")]
		[EnumMember(Value = "SATNAV Message")] 
		[XmlEnum("10")] 
		SatnavMessage = 10,

		[System.ComponentModel.Description("WarningOfWindsOfBeaufortForce8Or9")]
		[EnumMember(Value = "Gale Warning")] 
		[XmlEnum("11")] 
		GaleWarning = 11,

		[System.ComponentModel.Description("WarningOfWindsOfBeaufortForce10OrOver")]
		[EnumMember(Value = "Storm Warning")] 
		[XmlEnum("12")] 
		StormWarning = 12,

		[System.ComponentModel.Description("WarningOfHurricanesInTheNorthAtlanticAndEasternNorthPacificTyphoonsInTheWesternPacificCyclonesInTheIndianOceanAndCyclonesOfSimilarNatureInOtherRegions")]
		[EnumMember(Value = "Tropical Revolving Storm Warning")] 
		[XmlEnum("13")] 
		TropicalRevolvingStormWarning = 13,

		[System.ComponentModel.Description("NavigationalWarningOrInForceBulletinPromulgatedAsPartOfANumberedSeriesByANavareaCoordinator")]
		[EnumMember(Value = "NAVAREA Warning")] 
		[XmlEnum("14")] 
		NavareaWarning = 14,

		[System.ComponentModel.Description("ANavigationalWarningOrInForceBulletinPromulgatedAsPartOfANumberedSeriesByANationalCoordinator")]
		[EnumMember(Value = "Coastal Warning")] 
		[XmlEnum("15")] 
		CoastalWarning = 15,

		[System.ComponentModel.Description("WarningWhichCoversInshoreWatersOftenWithinTheLimitsOfJurisdictionOfAHarbourOrPortAuthority")]
		[EnumMember(Value = "Local Warning")] 
		[XmlEnum("16")] 
		LocalWarning = 16,

		[System.ComponentModel.Description("WarningOfActualOrExpectedLowWaterLevel")]
		[EnumMember(Value = "Low Water Level Warning/Negative Tidal Surge")] 
		[XmlEnum("17")] 
		LowWaterLevelWarningNegativeTidalSurge = 17,

		[System.ComponentModel.Description("WarningOfAccretionOfIceOnShips")]
		[EnumMember(Value = "Icing Warning")] 
		[XmlEnum("18")] 
		IcingWarning = 18,

		[System.ComponentModel.Description("BroadcastsAboutTsunamisIncludingWatchesAdvisoriesAndOtherTypesOfMessagesRelatingToTsunamisOrPotentialTsunamis")]
		[EnumMember(Value = "Tsunami Broadcast")] 
		[XmlEnum("19")] 
		TsunamiBroadcast = 19,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfMilitaryPracticeArea : int {
		[System.ComponentModel.Description("AnAreaWithinWhichExercisesAreCarriedOutWithTorpedoes")]
		[EnumMember(Value = "Torpedo Exercise Area")] 
		[XmlEnum("2")] 
		TorpedoExerciseArea = 2,

		[System.ComponentModel.Description("AnAreaWithinWhichSubmarineExercisesAreCarriedOut")]
		[EnumMember(Value = "Submarine Exercise Area")] 
		[XmlEnum("3")] 
		SubmarineExerciseArea = 3,

		[System.ComponentModel.Description("AreasForBombingAndMissileExercises")]
		[EnumMember(Value = "Firing Danger Area")] 
		[XmlEnum("4")] 
		FiringDangerArea = 4,

		[System.ComponentModel.Description("AnAreaWithinWhichMineLayingExercisesAreCarriedOut")]
		[EnumMember(Value = "Mine-Laying Practice Area")] 
		[XmlEnum("5")] 
		MineLayingPracticeArea = 5,

		[System.ComponentModel.Description("AnAreaForShootingPistolsRiflesAndMachineGunsEtcAtATarget")]
		[EnumMember(Value = "Small Arms Firing Range")] 
		[XmlEnum("6")] 
		SmallArmsFiringRange = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfNavigationLine : int {
		[System.ComponentModel.Description("AStraightLineThatMarksTheBoundaryBetweenASafeAndADangerousAreaOrThatPassesClearOfANavigationalDanger")]
		[EnumMember(Value = "Clearing Line")] 
		[XmlEnum("1")] 
		ClearingLine = 1,

		[System.ComponentModel.Description("ALinePassingThroughOneOrMoreFixedMarks")]
		[EnumMember(Value = "Transit Line")] 
		[XmlEnum("2")] 
		TransitLine = 2,

		[System.ComponentModel.Description("ALinePassingThroughOneOrMoreClearlyDefinedObjectsAlongThePathOfWhichAVesselCanApproachSafelyUpToACertainDistanceOff")]
		[EnumMember(Value = "Leading Line Bearing a Recommended Track")] 
		[XmlEnum("3")] 
		LeadingLineBearingARecommendedTrack = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPilot : int {
		[System.ComponentModel.Description("PilotLicencedToConductVesselsDuringApproachFromSeaToASpecifiedPlaceWhichMayBeAHandoverPlaceAnAnchorageOrAlongside")]
		[EnumMember(Value = "Pilot")] 
		[XmlEnum("1")] 
		Pilot = 1,

		[System.ComponentModel.Description("PilotLicencedToConductVesselsOverExtensiveSeaAreas")]
		[EnumMember(Value = "Deep Sea")] 
		[XmlEnum("2")] 
		DeepSea = 2,

		[System.ComponentModel.Description("AReportingPointOfAHarbour")]
		[EnumMember(Value = "Harbour")] 
		[XmlEnum("3")] 
		Harbour = 3,

		[System.ComponentModel.Description("ARidgeOrSuccessionOfRidgesOfSandOrOtherSubstancesExtendingAcrossTheMouthOfARiverOrHarbourAndWhichMayObstructNavigation")]
		[EnumMember(Value = "Bar")] 
		[XmlEnum("4")] 
		Bar = 4,

		[System.ComponentModel.Description("ARelativelyLargeNaturalStreamOfWater")]
		[EnumMember(Value = "River")] 
		[XmlEnum("5")] 
		River = 5,

		[System.ComponentModel.Description("PilotLicensedToConductVesselsFromAndToSpecifiedPlacesAlongTheCourseOfAChannelForExampleAsUsedInRioAmazonasAndRioDeLaPlata")]
		[EnumMember(Value = "Channel")] 
		[XmlEnum("6")] 
		Channel = 6,

		[System.ComponentModel.Description("ALargeBodyOfWaterEntirelySurroundedByLand")]
		[EnumMember(Value = "Lake")] 
		[XmlEnum("7")] 
		Lake = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPilotBoardingPlace : int {
		[System.ComponentModel.Description("PilotBoardsFromACruisingVessel")]
		[EnumMember(Value = "Boarding by Pilot-Cruising Vessel")] 
		[XmlEnum("1")] 
		BoardingByPilotCruisingVessel = 1,

		[System.ComponentModel.Description("PilotBoardsByHelicopterWhichComesOutFromTheShore")]
		[EnumMember(Value = "Boarding by Helicopter")] 
		[XmlEnum("2")] 
		BoardingByHelicopter = 2,

		[System.ComponentModel.Description("PilotEmbarksFromAVesselOrDisembarksOnAVesselWhichComesOutFromTheShoreOnRequest")]
		[EnumMember(Value = "Pilot Comes Out from Shore")] 
		[XmlEnum("3")] 
		PilotComesOutFromShore = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPreference : int {
		[System.ComponentModel.Description("ThePreferredFirstChoiceUsedInNormalConditions")]
		[EnumMember(Value = "Primary")] 
		[XmlEnum("1")] 
		Primary = 1,

		[System.ComponentModel.Description("ThePreferredChoiceInExtraordinaryConditions")]
		[EnumMember(Value = "Alternate")] 
		[XmlEnum("2")] 
		Alternate = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioMethods : int {
		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween30And300KhzUsedForVoiceTraffic")]
		[EnumMember(Value = "Low Frequency Voice Traffic")] 
		[XmlEnum("1")] 
		LowFrequencyVoiceTraffic = 1,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween300And3000KhzUsedForVoiceTraffic")]
		[EnumMember(Value = "Medium Frequency Voice Traffic")] 
		[XmlEnum("2")] 
		MediumFrequencyVoiceTraffic = 2,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween3And30MhzUsedForVoiceTraffic")]
		[EnumMember(Value = "High Frequency (HF) Voice Traffic")] 
		[XmlEnum("3")] 
		HighFrequencyHfVoiceTraffic = 3,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween30And300MhzUsedForVoiceTraffic")]
		[EnumMember(Value = "Very High Frequency (VHF) Voice Traffic")] 
		[XmlEnum("4")] 
		VeryHighFrequencyVhfVoiceTraffic = 4,

		[System.ComponentModel.Description("AnAutomatedDirectPrintingServiceInTheHighFrequencyRangeSimilarToNavtexButDoesNotOfferAllOfTheSameFunctionalitySuchAsAvoidingRepeatedMessages")]
		[EnumMember(Value = "High Frequency Narrow Band Direct Printing")] 
		[XmlEnum("5")] 
		HighFrequencyNarrowBandDirectPrinting = 5,

		[System.ComponentModel.Description("TheSystemForTheBroadcastAndAutomaticReceptionOfMaritimeSafetyInformationByMeansOfNarrowBandDirectPrintingTelegraphy")]
		[EnumMember(Value = "NAVTEX")] 
		[XmlEnum("6")] 
		Navtex = 6,

		[System.ComponentModel.Description("SafetynetIsAnInternationalAutomaticDirectPrintingSatelliteBasedServiceForThePromulgationOfNavigationalAndMeteorologicalWarningsMeteorologicalForecastsAndOtherUrgentSafetyRelatedMessagesMaritimeSafetyInformationMsiToShips")]
		[EnumMember(Value = "SafetyNET")] 
		[XmlEnum("7")] 
		Safetynet = 7,

		[System.ComponentModel.Description("ACommunicationsSystemConsistingOfTeletypewritersConnectedToATelephonicNetworkToSendAndReceiveNarrowBandDirectPrinting")]
		[EnumMember(Value = "NBDP Telegraphy (Narrow Band Direct Printing Telegraphy)")] 
		[XmlEnum("8")] 
		NbdpTelegraphyNarrowBandDirectPrintingTelegraphy = 8,

		[System.ComponentModel.Description("ASystemOfTransmittingAndReproducingGraphicMatterAsPrintingOrStillPicturesByMeansOfSignalsSentOverTelephoneLines")]
		[EnumMember(Value = "Facsimile")] 
		[XmlEnum("9")] 
		Facsimile = 9,

		[System.ComponentModel.Description("ARussianSystemTransmittingNavigationalInformationSentByRadioAndContainingInformationRelevantToCoastalWatersOfForeignCountriesAndHighSeas")]
		[EnumMember(Value = "NAVIP")] 
		[XmlEnum("10")] 
		Navip = 10,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween30And300KhzUsedForDigitalTraffic")]
		[EnumMember(Value = "Low Frequency Digital Traffic")] 
		[XmlEnum("11")] 
		LowFrequencyDigitalTraffic = 11,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween300And3000KhzUsedForDigitalTraffic")]
		[EnumMember(Value = "Medium Frequency Digital Traffic")] 
		[XmlEnum("12")] 
		MediumFrequencyDigitalTraffic = 12,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween3And30MhzUsedForDigitalTraffic")]
		[EnumMember(Value = "High Frequency (HF) Digital Traffic")] 
		[XmlEnum("13")] 
		HighFrequencyHfDigitalTraffic = 13,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween30And300MhzUsedForDigitalTraffic")]
		[EnumMember(Value = "Very High Frequency (VHF) Digital Traffic")] 
		[XmlEnum("14")] 
		VeryHighFrequencyVhfDigitalTraffic = 14,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween30And300KhzUsedForTelegraphTraffic")]
		[EnumMember(Value = "Low Frequency Telegraph Traffic")] 
		[XmlEnum("15")] 
		LowFrequencyTelegraphTraffic = 15,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween300And3000KhzUsedForTelegraphTraffic")]
		[EnumMember(Value = "Medium Frequency Telegraph Traffic")] 
		[XmlEnum("16")] 
		MediumFrequencyTelegraphTraffic = 16,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween3And30MhzUsedForTelegraphTraffic")]
		[EnumMember(Value = "High Frequency (HF) Telegraph Traffic")] 
		[XmlEnum("17")] 
		HighFrequencyHfTelegraphTraffic = 17,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween300And3000KhzUsedForDigitalSelectiveCallTraffic")]
		[EnumMember(Value = "Medium Frequency Digital Selective Call Traffic")] 
		[XmlEnum("18")] 
		MediumFrequencyDigitalSelectiveCallTraffic = 18,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween3And30MhzUsedForDigitalSelectiveCallTraffic")]
		[EnumMember(Value = "High Frequency (HF) Digital Selective Call Traffic")] 
		[XmlEnum("19")] 
		HighFrequencyHfDigitalSelectiveCallTraffic = 19,

		[System.ComponentModel.Description("FrequencyInAFrequencyRangeBetween30And300MhzUsedForDigitalSelectiveCallTraffic")]
		[EnumMember(Value = "Very High Frequency (VHF) Digital Selective Call Traffic")] 
		[XmlEnum("20")] 
		VeryHighFrequencyVhfDigitalSelectiveCallTraffic = 20,
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

		[System.ComponentModel.Description("AnAreaReservedForVesselsWaitingToEnterAHarbour")]
		[EnumMember(Value = "Waiting Area")] 
		[XmlEnum("19")] 
		WaitingArea = 19,

		[System.ComponentModel.Description("AnAreaWhereMarineResearchTakesPlace")]
		[EnumMember(Value = "Research Area")] 
		[XmlEnum("20")] 
		ResearchArea = 20,

		[System.ComponentModel.Description("APlaceWhereFishIncludingShellfishAndCrustaceansAreProtected")]
		[EnumMember(Value = "Fish Sanctuary")] 
		[XmlEnum("22")] 
		FishSanctuary = 22,

		[System.ComponentModel.Description("ATractOfLandManagedSoAsToPreserveTheRelationOfPlantsAndLivingCreaturesToEachOtherAndToTheirSurroundings")]
		[EnumMember(Value = "Ecological Reserve")] 
		[XmlEnum("23")] 
		EcologicalReserve = 23,

		[System.ComponentModel.Description("AnAreaWhereVesselsTurn")]
		[EnumMember(Value = "Swinging Area")] 
		[XmlEnum("25")] 
		SwingingArea = 25,

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
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRouteingMeasure : int {
		[System.ComponentModel.Description("SeaLanesDesignatedByAnArchipelagicStateForThePassageOfShipsAndAircraftTheArchipelagicSeaLaneAggregatesAllComponentPartsOfAnArchipelagicSeaLaneSystem")]
		[EnumMember(Value = "Archipelagic Sea Lane")] 
		[XmlEnum("1")] 
		ArchipelagicSeaLane = 1,

		[System.ComponentModel.Description("ARouteWithinDefinedLimitsWhichHasBeenAccuratelySurveyedForClearanceOfSeaBottomAndSubmergedObstaclesAsIndicatedOnTheChart")]
		[EnumMember(Value = "Deep Water Route")] 
		[XmlEnum("2")] 
		DeepWaterRoute = 2,

		[System.ComponentModel.Description("ThatPartOfARiverHarbourAndSoOnWhereTheMainNavigableChannelForVesselsOfLargerSizeLiesItIsAlsoTheUsualCourseFollowedByVesselsEnteringOrLeavingHarboursCalledShipChannelAFairwaySystemIsAnAggregationOfConnectedFairwayFeaturesMakingUpAComplexFairwaySystem")]
		[EnumMember(Value = "Fairway System")] 
		[XmlEnum("3")] 
		FairwaySystem = 3,

		[System.ComponentModel.Description("ANavigationLineRangeSystemOrARecommendedTrackLaneOrRoute")]
		[EnumMember(Value = "Recommended Route")] 
		[XmlEnum("4")] 
		RecommendedRoute = 4,

		[System.ComponentModel.Description("ARouteingMeasureAimedAtTheSeparationOfOpposingStreamsOfTrafficByAppropriateMeansAndByTheEstablishmentOfTrafficLanes")]
		[EnumMember(Value = "Traffic Separation Scheme")] 
		[XmlEnum("5")] 
		TrafficSeparationScheme = 5,

		[System.ComponentModel.Description("ARouteWithinDefinedLimitsInsideWhichTwoWayTrafficIsEstablishedAimedAtProvidingSafePassageOfShipsThroughWatersWhereNavigationIsDifficultOrDangerous")]
		[EnumMember(Value = "Two-Way Route")] 
		[XmlEnum("6")] 
		TwoWayRoute = 6,
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
	public enum categoryOfShipReport : int {
		[System.ComponentModel.Description("BeforeOrAsNearAsPossibleToTheTimeOfDepartureFromAPortWithinASystemOrWhenEnteringTheAreaCoveredByASystemForInstanceABJXEtc")]
		[EnumMember(Value = "Sailing Plan")] 
		[XmlEnum("1")] 
		SailingPlan = 1,

		[System.ComponentModel.Description("WhenNecessaryToEnsureEffectiveOperationOfTheSystem")]
		[EnumMember(Value = "Position Report")] 
		[XmlEnum("2")] 
		PositionReport = 2,

		[System.ComponentModel.Description("WhenTheShipsPositionVariesSignificantlyFromThePositionThatWouldHaveBeenPredictedFromPreviousReportsWhenChangingTheReportedRouteOrAsDecidedByTheMaster")]
		[EnumMember(Value = "Deviation Report")] 
		[XmlEnum("3")] 
		DeviationReport = 3,

		[System.ComponentModel.Description("OnArrivalAtTheDestinationOrOnLeavingTheAreaCoveredByTheSystem")]
		[EnumMember(Value = "Final Report")] 
		[XmlEnum("4")] 
		FinalReport = 4,

		[System.ComponentModel.Description("WhenAnIncidentTakesPlaceInvolvingTheLossOrLikelyLossOverboardOfPackagedDangerousGoodsIncludingThoseInFreightContainersPortableTanksRoadAndRailVehiclesAndShipBorneBargesIntoTheSea")]
		[EnumMember(Value = "Dangerous Goods Report")] 
		[XmlEnum("5")] 
		DangerousGoodsReport = 5,

		[System.ComponentModel.Description("ReportSubmittedWhenAnIncidentTakesPlaceInvolvingTheDischargeOrProbableDischargeOfOilOrNoxiousLiquidSubstancesInBulk")]
		[EnumMember(Value = "Harmful Substances Report")] 
		[XmlEnum("6")] 
		HarmfulSubstancesReport = 6,

		[System.ComponentModel.Description("InTheCaseOfTheLossOrLikelyLossOverboardOfHarmfulSubstancesInPackagedFormIncludingThoseInFreightContainersPortableTanksRoadAndRailVehiclesAndShipBorneBargesIdentifiedInTheInternationalMaritimeGoodsCodeAsMarinePollutants")]
		[EnumMember(Value = "Marine Pollutants Report")] 
		[XmlEnum("7")] 
		MarinePollutantsReport = 7,

		[System.ComponentModel.Description("AnyOtherTypeOfNonDefinedReportThatIsMadeInAccordanceWithTheSystemProceduresAsNotifiedInAccordanceWithParagraph9OfTheGeneralPrinciples")]
		[EnumMember(Value = "Any Other Report")] 
		[XmlEnum("8")] 
		AnyOtherReport = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSignalStationTraffic : int {
		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsWithinAPort")]
		[EnumMember(Value = "Port Control")] 
		[XmlEnum("1")] 
		PortControl = 1,

		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsEnteringOrLeavingAPort")]
		[EnumMember(Value = "Port Entry and Departure")] 
		[XmlEnum("2")] 
		PortEntryAndDeparture = 2,

		[System.ComponentModel.Description("ASignalStationDisplayingInternationalPortTrafficSignals")]
		[EnumMember(Value = "International Port Traffic")] 
		[XmlEnum("3")] 
		InternationalPortTraffic = 3,

		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsWhenBerthing")]
		[EnumMember(Value = "Berthing")] 
		[XmlEnum("4")] 
		Berthing = 4,

		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsEnteringOrLeavingADock")]
		[EnumMember(Value = "Dock")] 
		[XmlEnum("5")] 
		Dock = 5,

		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsEnteringOrLeavingALock")]
		[EnumMember(Value = "Lock")] 
		[XmlEnum("6")] 
		Lock = 6,

		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsWishingToPassThroughAFloodControlBarrage")]
		[EnumMember(Value = "Flood Barrage Station")] 
		[XmlEnum("7")] 
		FloodBarrageStation = 7,

		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsWishingToPassUnderABridge")]
		[EnumMember(Value = "Bridge Passage")] 
		[XmlEnum("8")] 
		BridgePassage = 8,

		[System.ComponentModel.Description("ASignalStationIndicatingWhenDredgingIsInProgress")]
		[EnumMember(Value = "Dredging")] 
		[XmlEnum("9")] 
		Dredging = 9,

		[System.ComponentModel.Description("VisualSignalLightsPlacedInAWaterwayToIndicateToShippingTheMovementsAuthorizedAtTheTimeAtWhichTheyAreShown")]
		[EnumMember(Value = "Traffic Control Light")] 
		[XmlEnum("10")] 
		TrafficControlLight = 10,

		[System.ComponentModel.Description("IndicatesTheOncomingTrafficOnAnInlandWaterway")]
		[EnumMember(Value = "Oncoming Traffic Indication")] 
		[XmlEnum("13")] 
		OncomingTrafficIndication = 13,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSignalStationWarning : int {
		[System.ComponentModel.Description("ASignalOrMessageWarningOfThePresenceOfADangerToNavigation")]
		[EnumMember(Value = "Danger")] 
		[XmlEnum("1")] 
		Danger = 1,

		[System.ComponentModel.Description("ASignalOrMessageWarningOfThePresenceOfAMaritimeObstruction")]
		[EnumMember(Value = "Maritime Obstruction")] 
		[XmlEnum("2")] 
		MaritimeObstruction = 2,

		[System.ComponentModel.Description("ASignalOrMessageWarningOfThePresenceOfACable")]
		[EnumMember(Value = "Cable")] 
		[XmlEnum("3")] 
		Cable = 3,

		[System.ComponentModel.Description("ASignalOrMessageWarningOfActivityInAMilitaryPracticeArea")]
		[EnumMember(Value = "Military Practice")] 
		[XmlEnum("4")] 
		MilitaryPractice = 4,

		[System.ComponentModel.Description("AStationThatMayReceiveOrTransmitDistressSignals")]
		[EnumMember(Value = "Distress")] 
		[XmlEnum("5")] 
		Distress = 5,

		[System.ComponentModel.Description("AVisualSignalDisplayedToIndicateAWeatherForecast")]
		[EnumMember(Value = "Weather")] 
		[XmlEnum("6")] 
		Weather = 6,

		[System.ComponentModel.Description("ASignalOrMessageConveyingInformationAboutStormConditions")]
		[EnumMember(Value = "Storm")] 
		[XmlEnum("7")] 
		Storm = 7,

		[System.ComponentModel.Description("ASignalOrMessageConveyingInformationAboutIceConditions")]
		[EnumMember(Value = "Ice Warning")] 
		[XmlEnum("8")] 
		IceWarning = 8,

		[System.ComponentModel.Description("AnAccurateSignalMarkingASpecifiedTimeOrTimeIntervalItIsUsedPrimarilyForDeterminingErrorsOfTimepiecesSuchSignalsAreUsuallySentFromAnObservatoryByRadioOrTelegraphButVisualSignalsAreUsedAtSomePorts")]
		[EnumMember(Value = "Time")] 
		[XmlEnum("9")] 
		Time = 9,

		[System.ComponentModel.Description("ASignalOrMessageConveyingInformationOnTidalConditionsInTheAreaInQuestion")]
		[EnumMember(Value = "Tide")] 
		[XmlEnum("10")] 
		Tide = 10,

		[System.ComponentModel.Description("ASignalOrMessageConveyingInformationOnConditionOfTidalCurrentsInTheAreaInQuestion")]
		[EnumMember(Value = "Tidal Stream")] 
		[XmlEnum("11")] 
		TidalStream = 11,

		[System.ComponentModel.Description("ADeviceForMeasuringTheHeightOfTideAGraduatedStaffInAShelteredAreaWhereVisualObservationsCanBeMadeOrItMayConsistOfAnElaborateRecordingInstrumentMakingAContinuousGraphicRecordOfTideHeightAgainstTimeSuchAnInstrumentIsUsuallyActuatedByAFloatInAPipeCommunicatingWithTheSeaThroughASmallHoleWhichFiltersOutShorterWaves")]
		[EnumMember(Value = "Tide Gauge")] 
		[XmlEnum("12")] 
		TideGauge = 12,

		[System.ComponentModel.Description("AVisualScaleWhichDirectlyShowsTheHeightOfTheWaterAboveChartDatumOrALocalDatum")]
		[EnumMember(Value = "Tide Scale")] 
		[XmlEnum("13")] 
		TideScale = 13,

		[System.ComponentModel.Description("ASignalOrMessageWarningOfDivingActivity")]
		[EnumMember(Value = "Diving")] 
		[XmlEnum("14")] 
		Diving = 14,

		[System.ComponentModel.Description("ADeviceForMeasuringAndConveyingInformationAboutTheWaterLevelNonTidalInTheAreaInQuestion")]
		[EnumMember(Value = "Water Level Gauge")] 
		[XmlEnum("15")] 
		WaterLevelGauge = 15,

		[System.ComponentModel.Description("AnIndicationOfTheVerticalClearanceOfABridgeOverheadCableEtc")]
		[EnumMember(Value = "Vertical Clearance Indication")] 
		[XmlEnum("16")] 
		VerticalClearanceIndication = 16,

		[System.ComponentModel.Description("AnIndicationOfTheOfficialHighWaterLevel")]
		[EnumMember(Value = "High Water Mark")] 
		[XmlEnum("17")] 
		HighWaterMark = 17,

		[System.ComponentModel.Description("AnIndicationOfTheLocalDepth")]
		[EnumMember(Value = "Depth Indication")] 
		[XmlEnum("18")] 
		DepthIndication = 18,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTemporalVariation : int {
		[System.ComponentModel.Description("IndicationOfThePossibleImpactOfASignificantEventForExampleHurricaneEarthquakeVolcanicEruptionLandslideEtcWhichIsConsideredLikelyToHaveChangedTheSeafloorOrLandscapeSignificantly")]
		[EnumMember(Value = "Extreme Event")] 
		[XmlEnum("1")] 
		ExtremeEvent = 1,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeToNonBathymetricFeaturesForExampleRiverSiltationGlacierCreepRecessionSandDunesBuoysMarineFarmsEtc")]
		[EnumMember(Value = "Likely to Change")] 
		[XmlEnum("4")] 
		LikelyToChange = 4,

		[System.ComponentModel.Description("SignificantChangeToTheSeafloorIsNotExpected")]
		[EnumMember(Value = "Unlikely to Change")] 
		[XmlEnum("5")] 
		UnlikelyToChange = 5,
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
	public enum categoryOfTrafficSeparationScheme : int {
		[System.ComponentModel.Description("ADefinedMaritimeTrafficRouteThatHasBeenAdoptedAsAnImoRouteingMeasure")]
		[EnumMember(Value = "IMO Adopted")] 
		[XmlEnum("1")] 
		ImoAdopted = 1,

		[System.ComponentModel.Description("ADefinedTrafficSeparationSchemeThatHasNotBeenAdoptedAsAnImoRoutingMeasure")]
		[EnumMember(Value = "Not IMO - Adopted")] 
		[XmlEnum("2")] 
		NotImoAdopted = 2,
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
	public enum operation : int {
		[System.ComponentModel.Description("TheNumericallyLargestValueComputedFromTheApplicableAttributesOrSubAttributes")]
		[EnumMember(Value = "Largest Value")] 
		[XmlEnum("1")] 
		LargestValue = 1,

		[System.ComponentModel.Description("TheNumericallySmallestValueComputedFromTheApplicableAttributesOrSubAttributes")]
		[EnumMember(Value = "Smallest Value")] 
		[XmlEnum("2")] 
		SmallestValue = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum pilotMovement : int {
		[System.ComponentModel.Description("ThePlaceWhereVesselsNotBeingNavigatedAccordingToAPilotsInstructionsPickUpAPilotWhileInTransitFromSeaToAPortOrConstrictedWatersForFutureNavigationUnderPilotInstructions")]
		[EnumMember(Value = "Embarkation")] 
		[XmlEnum("1")] 
		Embarkation = 1,

		[System.ComponentModel.Description("ThePlaceWhereVesselsBeingNavigatedUnderAPilotsInstructionsInTransitFromSeaToAPortOrConstrictedWatersDropThePilotAndProceedWithoutBeingSubjectToPilotInstructions")]
		[EnumMember(Value = "Disembarkation")] 
		[XmlEnum("2")] 
		Disembarkation = 2,

		[System.ComponentModel.Description("ThePlaceWhereVesselsBeingNavigatedUnderAPilotsInstructionsDropOffThePilotAndPickUpADifferentPilotForFutureNavigationUnderPilotsInstructions")]
		[EnumMember(Value = "Pilot Change")] 
		[XmlEnum("3")] 
		PilotChange = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum pilotQualification : int {
		[System.ComponentModel.Description("APilotServiceCarriedOutByGovernmentPilots")]
		[EnumMember(Value = "Government Pilot")] 
		[XmlEnum("1")] 
		GovernmentPilot = 1,

		[System.ComponentModel.Description("APilotServiceCarriedOutByPilotsWhoAreApprovedByGovernment")]
		[EnumMember(Value = "Pilot Approved by Government")] 
		[XmlEnum("2")] 
		PilotApprovedByGovernment = 2,

		[System.ComponentModel.Description("APilotThatIsLicensedByTheStateUsaAndOrTheirRespectivePilotAssociationRequiredForAllForeignVesselsAndAllAmericanVesselsUnderRegistryBoundForAPortWithCompulsoryStatePilotageAFederalLicenceIsNotSufficientToPilotSuchVesselsIntoThePort")]
		[EnumMember(Value = "State Pilot")] 
		[XmlEnum("3")] 
		StatePilot = 3,

		[System.ComponentModel.Description("APilotWhoCarriesAFederalEndorsementOfferingServicesToVesselsThatAreNotRequiredToObtainCompulsoryStatePilotageServicesAreUsuallyContractedForInAdvance")]
		[EnumMember(Value = "Federal Pilot")] 
		[XmlEnum("4")] 
		FederalPilot = 4,

		[System.ComponentModel.Description("APilotProvidedByACommercialCompany")]
		[EnumMember(Value = "Company Pilot")] 
		[XmlEnum("5")] 
		CompanyPilot = 5,

		[System.ComponentModel.Description("APilotWithLocalKnowledgeButWhoDoesNotHoldAQualificationAsAPilot")]
		[EnumMember(Value = "Local Pilot")] 
		[XmlEnum("6")] 
		LocalPilot = 6,

		[System.ComponentModel.Description("APilotServiceCarriedOutByACitizenWithSufficientLocalKnowledge")]
		[EnumMember(Value = "Citizen With Sufficient Local Knowledge")] 
		[XmlEnum("7")] 
		CitizenWithSufficientLocalKnowledge = 7,

		[System.ComponentModel.Description("APilotServiceCarriedOutByACitizenWhoseLocalKnowledgeIsUncertain")]
		[EnumMember(Value = "Citizen With Doubtful Local Knowledge")] 
		[XmlEnum("8")] 
		CitizenWithDoubtfulLocalKnowledge = 8,
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

		[System.ComponentModel.Description("AnAreaInWhichSwimmingIsProhibited")]
		[EnumMember(Value = "Swimming Prohibited")] 
		[XmlEnum("39")] 
		SwimmingProhibited = 39,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum waterLevelTrend : int {
		[System.ComponentModel.Description("BecomingSmallerInMagnitude")]
		[EnumMember(Value = "Decreasing")] 
		[XmlEnum("1")] 
		Decreasing = 1,

		[System.ComponentModel.Description("BecomingLargerInMagnitude")]
		[EnumMember(Value = "Increasing")] 
		[XmlEnum("2")] 
		Increasing = 2,

		[System.ComponentModel.Description("Constant")]
		[EnumMember(Value = "Steady")] 
		[XmlEnum("3")] 
		Steady = 3,
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

		[System.ComponentModel.Description("LitByFloodlightsStripLightsEtc")]
		[EnumMember(Value = "Illuminated")] 
		[XmlEnum("12")] 
		Illuminated = 12,

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

		[System.ComponentModel.Description("MarkedByBuoys")]
		[EnumMember(Value = "Buoyed")] 
		[XmlEnum("28")] 
		Buoyed = 28,
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
	public enum textJustification : int {
		[System.ComponentModel.Description("OfRelatingToOrLocatedOnOrNearTheSideOfAPersonOrThingThatIsTurnedTowardTheWestWhenTheSubjectIsFacingNorthOpposedToRight")]
		[EnumMember(Value = "Left")] 
		[XmlEnum("1")] 
		Left = 1,

		[System.ComponentModel.Description("EquidistantFromAllBorderingOrAdjacentAreasSituatedInTheCentre")]
		[EnumMember(Value = "Centred")] 
		[XmlEnum("2")] 
		Centred = 2,

		[System.ComponentModel.Description("OfRelatingToOrLocatedOnOrNearTheSideOfAPersonOrThingThatIsTurnedTowardTheEastWhenTheSubjectIsFacingNorthOpposedToLeft")]
		[EnumMember(Value = "Right")] 
		[XmlEnum("3")] 
		Right = 3,
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
	public enum trafficFlow : int {
		[System.ComponentModel.Description("TrafficFlowInAGeneralDirectionTowardAPortOrSimilarDestination")]
		[EnumMember(Value = "Inbound")] 
		[XmlEnum("1")] 
		Inbound = 1,

		[System.ComponentModel.Description("TrafficFlowInAGeneralDirectionAwayFromAPortOrSimilarPointOfOrigin")]
		[EnumMember(Value = "Outbound")] 
		[XmlEnum("2")] 
		Outbound = 2,

		[System.ComponentModel.Description("TrafficFlowInOneGeneralDirectionOnly")]
		[EnumMember(Value = "One-Way")] 
		[XmlEnum("3")] 
		OneWay = 3,

		[System.ComponentModel.Description("TrafficFlowInTwoGenerallyOppositeDirections")]
		[EnumMember(Value = "Two-Way")] 
		[XmlEnum("4")] 
		TwoWay = 4,
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
			[XmlElement("dateEnd")]
			public String? dateEnd {get;set;} = default;

			public bool ShouldSerializedateEnd() { return !string.IsNullOrEmpty(dateEnd); }

			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }
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
		public class noticeTime {
			[XmlElement("noticeTimeHours")]
			public List<decimal> noticeTimeHours {get;set;} = [];

			public bool ShouldSerializenoticeTimeHours() { return noticeTimeHours.Any(); }

			[XmlElement("noticeTimeText")]
			public String? noticeTimeText {get;set;} = default;

			public bool ShouldSerializenoticeTimeText() { return !string.IsNullOrEmpty(noticeTimeText); }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public operation? operation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("operation")]
			public SerializableEnumeration<operation>? operationElement { get { return operation; } set { } }

			public bool ShouldSerializeoperation() { return operation.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class onlineResource {
			[XmlElement("linkage")]
			public required String linkage {get;set;} = string.Empty;

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

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public onlineFunction? onlineFunction {get;set;} = default;

			[JsonIgnore]
			[XmlElement("onlineFunction")]
			public SerializableEnumeration<onlineFunction>? onlineFunctionElement { get { return onlineFunction; } set { } }

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
			[XmlElement("dateEnd")]
			public required String dateEnd {get;set;} = string.Empty;

			[XmlElement("dateStart")]
			public required String dateStart {get;set;} = string.Empty;
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
			public String? headline {get;set;} = default;

			public bool ShouldSerializeheadline() { return !string.IsNullOrEmpty(headline); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sourceIndication {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public categoryOfAuthority? categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority>? categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

			public bool ShouldSerializecategoryOfAuthority() { return categoryOfAuthority.HasValue; }

			[XmlElement("countryName")]
			public String? countryName {get;set;} = default;

			public bool ShouldSerializecountryName() { return !string.IsNullOrEmpty(countryName); }

			[XmlElement("reportedDate")]
			public String? reportedDate {get;set;} = default;

			public bool ShouldSerializereportedDate() { return !string.IsNullOrEmpty(reportedDate); }

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

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class surveyDateRange {
			[XmlElement("dateEnd")]
			public required String dateEnd {get;set;} = string.Empty;

			[XmlElement("dateStart")]
			public String? dateStart {get;set;} = default;

			public bool ShouldSerializedateStart() { return !string.IsNullOrEmpty(dateStart); }
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

			[XmlElement("sourceIndication")]
			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }
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
		public class underKeelAllowance {
			[XmlElement("underKeelAllowanceFixed")]
			public decimal? underKeelAllowanceFixed {get;set;} = default;

			public bool ShouldSerializeunderKeelAllowanceFixed() { return underKeelAllowanceFixed.HasValue; }

			[XmlElement("underKeelAllowanceVariableBeamBased")]
			public decimal? underKeelAllowanceVariableBeamBased {get;set;} = default;

			public bool ShouldSerializeunderKeelAllowanceVariableBeamBased() { return underKeelAllowanceVariableBeamBased.HasValue; }

			[XmlElement("underKeelAllowanceVariableDraughtBased")]
			public decimal? underKeelAllowanceVariableDraughtBased {get;set;} = default;

			public bool ShouldSerializeunderKeelAllowanceVariableDraughtBased() { return underKeelAllowanceVariableDraughtBased.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public operation? operation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("operation")]
			public SerializableEnumeration<operation>? operationElement { get { return operation; } set { } }

			public bool ShouldSerializeoperation() { return operation.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class vesselsMeasurements {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public required comparisonOperator comparisonOperator {get;set;} = default;

			[JsonIgnore]
			[XmlElement("comparisonOperator")]
			public SerializableEnumeration<comparisonOperator> comparisonOperatorElement { get { return comparisonOperator; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public required vesselsCharacteristics vesselsCharacteristics {get;set;} = default;

			[JsonIgnore]
			[XmlElement("vesselsCharacteristics")]
			public SerializableEnumeration<vesselsCharacteristics> vesselsCharacteristicsElement { get { return vesselsCharacteristics; } set { } }

			[XmlElement("vesselsCharacteristicsValue")]
			public required decimal vesselsCharacteristicsValue {get;set;} = default;

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			public required vesselsCharacteristicsUnit vesselsCharacteristicsUnit {get;set;} = default;

			[JsonIgnore]
			[XmlElement("vesselsCharacteristicsUnit")]
			public SerializableEnumeration<vesselsCharacteristicsUnit> vesselsCharacteristicsUnitElement { get { return vesselsCharacteristicsUnit; } set { } }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class bearingInformation {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public cardinalDirection? cardinalDirection {get;set;} = default;

			[JsonIgnore]
			[XmlElement("cardinalDirection")]
			public SerializableEnumeration<cardinalDirection>? cardinalDirectionElement { get { return cardinalDirection; } set { } }

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
		public class radiocommunications {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCommunicationPreference")]
			public SerializableEnumeration<categoryOfCommunicationPreference>? categoryOfCommunicationPreferenceElement { get { return categoryOfCommunicationPreference; } set { } }

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19])]
			public List<categoryOfMaritimeBroadcast> categoryOfMaritimeBroadcast {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfMaritimeBroadcast")]
			public SerializableEnumeration<categoryOfMaritimeBroadcast>[] categoryOfMaritimeBroadcastElement { get { return [.. categoryOfMaritimeBroadcast]; } set { } }

			public bool ShouldSerializecategoryOfMaritimeBroadcast() { return categoryOfMaritimeBroadcast.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20])]
			public List<categoryOfRadioMethods> categoryOfRadioMethods {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRadioMethods")]
			public SerializableEnumeration<categoryOfRadioMethods>[] categoryOfRadioMethodsElement { get { return [.. categoryOfRadioMethods]; } set { } }

			public bool ShouldSerializecategoryOfRadioMethods() { return categoryOfRadioMethods.Any(); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("signalFrequency")]
			public List<int> signalFrequency {get;set;} = [];

			public bool ShouldSerializesignalFrequency() { return signalFrequency.Any(); }

			[XmlElement("transmissionContent")]
			public String? transmissionContent {get;set;} = default;

			public bool ShouldSerializetransmissionContent() { return !string.IsNullOrEmpty(transmissionContent); }

			[XmlElement("timeIntervalsByDayOfWeek")]
			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];

			public bool ShouldSerializetimeIntervalsByDayOfWeek() { return timeIntervalsByDayOfWeek.Any(); }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class telecommunications {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public categoryOfCommunicationPreference? categoryOfCommunicationPreference {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfCommunicationPreference")]
			public SerializableEnumeration<categoryOfCommunicationPreference>? categoryOfCommunicationPreferenceElement { get { return categoryOfCommunicationPreference; } set { } }

			public bool ShouldSerializecategoryOfCommunicationPreference() { return categoryOfCommunicationPreference.HasValue; }

			[XmlElement("telecommunicationIdentifier")]
			public required String telecommunicationIdentifier {get;set;} = string.Empty;

			[XmlElement("telecommunicationCarrier")]
			public String? telecommunicationCarrier {get;set;} = default;

			public bool ShouldSerializetelecommunicationCarrier() { return !string.IsNullOrEmpty(telecommunicationCarrier); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<telecommunicationService> telecommunicationService {get;set;} = [];

			[JsonIgnore]
			[XmlElement("telecommunicationService")]
			public SerializableEnumeration<telecommunicationService>[] telecommunicationServiceElement { get { return [.. telecommunicationService]; } set { } }

			public bool ShouldSerializetelecommunicationService() { return telecommunicationService.Any(); }

			[XmlElement("scheduleByDayOfWeek")]
			public scheduleByDayOfWeek? scheduleByDayOfWeek {get;set;} = default;

			public bool ShouldSerializescheduleByDayOfWeek() { return scheduleByDayOfWeek!=default; }
		}

	}
	public enum Role {
		[System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
		componentOf,
		[System.ComponentModel.Description("A pointer to a part in a whole-part relationship.")]
		consistsOf,
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
		[System.ComponentModel.Description("A pointer to a specific spatial type(s).")]
		definedFor,
		[System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
		defines,
		[System.ComponentModel.Description("A pointer to a specific feature(s).")]
		identifies,
		[System.ComponentModel.Description("A pointer to a specific feature(s) for which further information is required.")]
		informationProvidedFor,
		[System.ComponentModel.Description("The object or class of objects to which the regulation, restriction, recommendation, or nautical information applies")]
		isApplicableTo,
		[System.ComponentModel.Description("The location for which service hours are given")]
		location_srvHrs,
		[System.ComponentModel.Description("The information")]
		theInformation,
		[System.ComponentModel.Description("The organisation to which information relates")]
		theOrganisation,
		[System.ComponentModel.Description("The work hours for a non-standard workday")]
		partialWorkingDay,
		[System.ComponentModel.Description("Association class for associations describing whether the subsets of vessels determined by the ship characteristics specified in APPLIC may (or must, etc.) transit, enter, or use a feature.")]
		permission,
		[System.ComponentModel.Description("The class (generally, qualifying vessels) which must file the report")]
		mustBeFiledBy,
		[System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
		positions,
		[System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
		providesInformation,
		[System.ComponentModel.Description("The feature pertaining to a report")]
		reptForLocation,
		[System.ComponentModel.Description("The organisation or place to which a report is sent.")]
		reportTo,
		[System.ComponentModel.Description("The regulation, restriction, recommendation, or nautical information")]
		theRxN,
		[System.ComponentModel.Description("Service hours for an authority or service provider")]
		theServiceHours,
		[System.ComponentModel.Description("The usual service hours to which an exception applies")]
		theServiceHours_nsdy,
		[System.ComponentModel.Description("Pointer to service or facility")]
		servicePlace,
		[System.ComponentModel.Description("The area served by a service provider")]
		serviceArea,
		[System.ComponentModel.Description("Pointer to a feature from where a provider supplies a service")]
		serviceProvider,
		[System.ComponentModel.Description("The report to be filed by a vessel")]
		theShipReport,
		[System.ComponentModel.Description("The report for a traffic service")]
		reptForTrafficServ,
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
		/// Related organisation
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RelatedOrganisation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(RelatedOrganisation);
		}

		/// <summary>
		/// The authority with which a report must be filed
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ReportingAuthority : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ReportingAuthority);
		}

		/// <summary>
		/// Association between types of reports and classes of vessels which must file report of the type described
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ReportingRequirement : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ReportingRequirement);
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
		/// Association between a geographically located service and the organisation that controls it
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceControl : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(ServiceControl);
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
		/// Working hours for a service or facility described by a geographic location
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocationHours : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(LocationHours);
		}

		/// <summary>
		/// Association between traffic control service and reports required of vessels pertaining to that area
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficServiceReport : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(TrafficServiceReport);
		}
	}

	namespace FeatureAssociations {
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
		/// A feature association for the binding between a pilotage district and its component pilot boarding places.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotageDistrictAssociation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(PilotageDistrictAssociation);
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

		/// <summary>
		/// A feature association for the binding between a traffic control service and auxiliary features.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficControlServiceAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(TrafficControlServiceAggregation);
		}
	}

}

namespace S100Framework.DomainModel.S127 {
	using ComplexAttributes;
	using InformationAssociations;

	namespace InformationTypes {
		/// <summary>
		/// Generalized information type which carries all the common attributes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InformationType : InformationNode, IInformationBindingDefinition {
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIndication")]
			public List<sourceIndication> sourceIndication {get;set;} = [];

			public bool ShouldSerializesourceIndication() { return sourceIndication.Any(); }

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
		public partial class AbstractRxN : InformationType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
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
					association = nameof(RelatedOrganisation),
					role = Enum.GetName<Role>(Role.theOrganisation)!,
					informationTypes = [nameof(AbstractRxN)],
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
					association = nameof(ReportingRequirement),
					role = Enum.GetName<Role>(Role.theShipReport)!,
					informationTypes = [nameof(ShipReport)],
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
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15])]
			public required categoryOfAuthority categoryOfAuthority {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfAuthority")]
			public SerializableEnumeration<categoryOfAuthority> categoryOfAuthorityElement { get { return categoryOfAuthority; } set { } }

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
					association = nameof(ReportingAuthority),
					role = Enum.GetName<Role>(Role.theShipReport)!,
					informationTypes = [nameof(ShipReport)],
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

			[XmlElement("contactAddress")]
			public List<contactAddress> contactAddress {get;set;} = [];

			public bool ShouldSerializecontactAddress() { return contactAddress.Any(); }

			[XmlElement("contactInstructions")]
			public String? contactInstructions {get;set;} = default;

			public bool ShouldSerializecontactInstructions() { return !string.IsNullOrEmpty(contactInstructions); }

			[XmlElement("frequencyPair")]
			public List<frequencyPair> frequencyPair {get;set;} = [];

			public bool ShouldSerializefrequencyPair() { return frequencyPair.Any(); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("mMSICode")]
			public String? mMSICode {get;set;} = default;

			public bool ShouldSerializemMSICode() { return !string.IsNullOrEmpty(mMSICode); }

			[XmlElement("onlineResource")]
			public List<onlineResource> onlineResource {get;set;} = [];

			public bool ShouldSerializeonlineResource() { return onlineResource.Any(); }

			[XmlElement("telecommunications")]
			public List<telecommunications> telecommunications {get;set;} = [];

			public bool ShouldSerializetelecommunications() { return telecommunications.Any(); }

			[XmlElement("radiocommunications")]
			public List<radiocommunications> radiocommunications {get;set;} = [];

			public bool ShouldSerializeradiocommunications() { return radiocommunications.Any(); }

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
		/// Description of how a ship should report to a maritime authority, including when to report, what to report and whether the format conforms to the IMO standard.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShipReport : InformationType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public List<categoryOfShipReport> categoryOfShipReport {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfShipReport")]
			public SerializableEnumeration<categoryOfShipReport>[] categoryOfShipReportElement { get { return [.. categoryOfShipReport]; } set { } }

			public bool ShouldSerializecategoryOfShipReport() { return categoryOfShipReport.Any(); }

			[XmlElement("iMOFormatForReporting")]
			public required Boolean iMOFormatForReporting {get;set;} = false;

			[XmlElement("noticeTime")]
			public List<noticeTime> noticeTime {get;set;} = [];

			public bool ShouldSerializenoticeTime() { return noticeTime.Any(); }

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }

			[JsonIgnore]
			public override string Code => nameof(ShipReport);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..InformationType._informationBindingDefinitions, ..ShipReport._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ReportingRequirement),
					role = Enum.GetName<Role>(Role.mustBeFiledBy)!,
					informationTypes = [nameof(Applicability)],
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ReportingAuthority),
					role = Enum.GetName<Role>(Role.reportTo)!,
					informationTypes = [nameof(Authority)],
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
		/// The indication of the quality of the locational information for features in a dataset.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQuality : InformationNode, IInformationBindingDefinition {
			[XmlIgnore]
			[EnumerationValue([1,4,5])]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfTemporalVariation")]
			public SerializableEnumeration<categoryOfTemporalVariation>? categoryOfTemporalVariationElement { get { return categoryOfTemporalVariation; } set { } }

			public bool ShouldSerializecategoryOfTemporalVariation() { return categoryOfTemporalVariation.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("qualityOfHorizontalMeasurement")]
			public SerializableEnumeration<qualityOfHorizontalMeasurement>? qualityOfHorizontalMeasurementElement { get { return qualityOfHorizontalMeasurement; } set { } }

			public bool ShouldSerializequalityOfHorizontalMeasurement() { return qualityOfHorizontalMeasurement.HasValue; }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

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
		/// Spatial quality points.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQualityPoints : SpatialQuality {
			[JsonIgnore]
			public override string Code => nameof(SpatialQualityPoints);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SpatialQuality._informationBindingDefinitions, ..SpatialQualityPoints._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("sourceIndication")]
			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }

			[XmlElement("textContent")]
			public textContent? textContent {get;set;} = default;

			public bool ShouldSerializetextContent() { return textContent!=default; }

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
		/// A service feature generally involving one or more reports from the requester, including communications not strictly considered "reporting".
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class ReportableServiceArea : SupervisedArea {
			[JsonIgnore]
			public override string Code => nameof(ReportableServiceArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..ReportableServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficServiceReport),
					role = Enum.GetName<Role>(Role.reptForTrafficServ)!,
					informationTypes = [nameof(ShipReport)],
					primitives = [],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..ReportableServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..ReportableServiceArea._primitives];
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
		/// Generally, an area where the mariner has to be made aware of circumstances influencing the safety of navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CautionArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,3,5])]
			public condition? condition {get;set;} = default;

			[JsonIgnore]
			[XmlElement("condition")]
			public SerializableEnumeration<condition>? conditionElement { get { return condition; } set { } }

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlIgnore]
			[EnumerationValue([5,7])]
			public status? status {get;set;} = default;

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>? statusElement { get { return status; } set { } }

			public bool ShouldSerializestatus() { return status.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(CautionArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..CautionArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..CautionArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..CautionArea._primitives];
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
		/// An area where hazards, caused by concentrations of shipping, may occur. Hazards are risks to shipping, which stem from sources other than shoal water or obstructions.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ConcentrationOfShippingHazardArea : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public List<categoryOfConcentrationOfShippingHazardArea> categoryOfConcentrationOfShippingHazardArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfConcentrationOfShippingHazardArea")]
			public SerializableEnumeration<categoryOfConcentrationOfShippingHazardArea>[] categoryOfConcentrationOfShippingHazardAreaElement { get { return [.. categoryOfConcentrationOfShippingHazardArea]; } set { } }

			public bool ShouldSerializecategoryOfConcentrationOfShippingHazardArea() { return categoryOfConcentrationOfShippingHazardArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(ConcentrationOfShippingHazardArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..ConcentrationOfShippingHazardArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..ConcentrationOfShippingHazardArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..ConcentrationOfShippingHazardArea._primitives];
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
		/// The area to which an International Ship and Port Facility Security (ISPS) level applies. The ISPS Code is a comprehensive set of measures to enhance the security of ships and port facilities, developed in response to the perceived threats to ships and port facilities in the wake of the 9/11 attacks in the United States.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ISPSCodeSecurityLevel : OrganizationContactArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public required iSPSLevel iSPSLevel {get;set;} = default;

			[JsonIgnore]
			[XmlElement("iSPSLevel")]
			public SerializableEnumeration<iSPSLevel> iSPSLevelElement { get { return iSPSLevel; } set { } }

			[JsonIgnore]
			public override string Code => nameof(ISPSCodeSecurityLevel);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..OrganizationContactArea._informationBindingDefinitions, ..ISPSCodeSecurityLevel._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..ISPSCodeSecurityLevel._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..ISPSCodeSecurityLevel._primitives];
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
		/// A service established to provide port information without interaction between the customer and the service provider. This information could be inter alia berthing information, availability of port services, shipping schedules, meteorological and hydrological data.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocalPortServiceArea : ReportableServiceArea {
			[XmlElement("serviceAccessProcedure")]
			public String? serviceAccessProcedure {get;set;} = default;

			public bool ShouldSerializeserviceAccessProcedure() { return !string.IsNullOrEmpty(serviceAccessProcedure); }

			[XmlElement("requirementsForMaintenanceOfListeningWatch")]
			public required String requirementsForMaintenanceOfListeningWatch {get;set;} = string.Empty;

			[JsonIgnore]
			public override string Code => nameof(LocalPortServiceArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..LocalPortServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..LocalPortServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..LocalPortServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadioCallingInPoint)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadarRange)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationTraffic)],
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
		/// An area within which naval, military or aerial exercises are carried out. Also called an 'exercise area'.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MilitaryPracticeArea : SupervisedArea {
			[XmlIgnore]
			[EnumerationValue([2,3,4,5,6])]
			public List<categoryOfMilitaryPracticeArea> categoryOfMilitaryPracticeArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfMilitaryPracticeArea")]
			public SerializableEnumeration<categoryOfMilitaryPracticeArea>[] categoryOfMilitaryPracticeAreaElement { get { return [.. categoryOfMilitaryPracticeArea]; } set { } }

			public bool ShouldSerializecategoryOfMilitaryPracticeArea() { return categoryOfMilitaryPracticeArea.Any(); }

			[XmlElement("nationality")]
			public String? nationality {get;set;} = default;

			public bool ShouldSerializenationality() { return !string.IsNullOrEmpty(nationality); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,15,16,17,18,19,20,21,22,23,24,25,26,27,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,6,7,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(MilitaryPracticeArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..MilitaryPracticeArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..MilitaryPracticeArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..MilitaryPracticeArea._primitives];
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
		/// A location offshore where a pilot may board a vessel in preparation to piloting it through local waters.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotBoardingPlace : OrganizationContactArea {
			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfPilotBoardingPlace? categoryOfPilotBoardingPlace {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfPilotBoardingPlace")]
			public SerializableEnumeration<categoryOfPilotBoardingPlace>? categoryOfPilotBoardingPlaceElement { get { return categoryOfPilotBoardingPlace; } set { } }

			public bool ShouldSerializecategoryOfPilotBoardingPlace() { return categoryOfPilotBoardingPlace.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfPreference? categoryOfPreference {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfPreference")]
			public SerializableEnumeration<categoryOfPreference>? categoryOfPreferenceElement { get { return categoryOfPreference; } set { } }

			public bool ShouldSerializecategoryOfPreference() { return categoryOfPreference.HasValue; }

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public categoryOfVessel? categoryOfVessel {get;set;} = default;

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel != default; }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlElement("destination")]
			public String? destination {get;set;} = default;

			public bool ShouldSerializedestination() { return !string.IsNullOrEmpty(destination); }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public pilotMovement? pilotMovement {get;set;} = default;

			[JsonIgnore]
			[XmlElement("pilotMovement")]
			public SerializableEnumeration<pilotMovement>? pilotMovementElement { get { return pilotMovement; } set { } }

			public bool ShouldSerializepilotMovement() { return pilotMovement.HasValue; }

			[XmlElement("pilotVessel")]
			public String? pilotVessel {get;set;} = default;

			public bool ShouldSerializepilotVessel() { return !string.IsNullOrEmpty(pilotVessel); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,6,9,16,17,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(PilotBoardingPlace);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..OrganizationContactArea._informationBindingDefinitions, ..PilotBoardingPlace._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..PilotBoardingPlace._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..PilotBoardingPlace._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(PilotageDistrictAssociation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(PilotageDistrict)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(PilotService)],
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
		/// The service provided by a person who directs the movements of a vessel through pilot waters, usually a person who has demonstrated extensive knowledge of channels, aids to navigation, dangers to navigation, etc., in a particular area and is licensed for that area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotService : ReportableServiceArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public List<categoryOfPilot> categoryOfPilot {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfPilot")]
			public SerializableEnumeration<categoryOfPilot>[] categoryOfPilotElement { get { return [.. categoryOfPilot]; } set { } }

			public bool ShouldSerializecategoryOfPilot() { return categoryOfPilot.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public pilotQualification? pilotQualification {get;set;} = default;

			[JsonIgnore]
			[XmlElement("pilotQualification")]
			public SerializableEnumeration<pilotQualification>? pilotQualificationElement { get { return pilotQualification; } set { } }

			public bool ShouldSerializepilotQualification() { return pilotQualification.HasValue; }

			[XmlElement("pilotRequest")]
			public String? pilotRequest {get;set;} = default;

			public bool ShouldSerializepilotRequest() { return !string.IsNullOrEmpty(pilotRequest); }

			[XmlElement("remotePilot")]
			public required Boolean remotePilot {get;set;} = false;

			[XmlElement("noticeTime")]
			public noticeTime? noticeTime {get;set;} = default;

			public bool ShouldSerializenoticeTime() { return noticeTime!=default; }

			[JsonIgnore]
			public override string Code => nameof(PilotService);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..PilotService._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
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
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..PilotService._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..PilotService._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceArea)!,
					featureTypes = [nameof(PilotageDistrict)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceArea)!,
					featureTypes = [nameof(PilotBoardingPlace)],
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
		/// An area within which a pilotage direction exists. Such directions are regulated by a competent harbour authority which dictates circumstances under which they apply.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotageDistrict : FeatureType {
			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[JsonIgnore]
			public override string Code => nameof(PilotageDistrict);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..PilotageDistrict._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..PilotageDistrict._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..PilotageDistrict._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  default,
					association = nameof(PilotageDistrictAssociation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(PilotBoardingPlace)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ServiceProvisionArea),
					role = Enum.GetName<Role>(Role.serviceProvider)!,
					featureTypes = [nameof(PilotService)],
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
		/// An area where there is a raised risk of piracy or armed robbery.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PiracyRiskArea : ReportableServiceArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,14,18,19,20,21,24,25,26,27,31,32,33,34])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,5,7])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(PiracyRiskArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..PiracyRiskArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..PiracyRiskArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..PiracyRiskArea._primitives];
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
		/// A place where a ship in need of assistance can take action to enable it to stabilize its condition and reduce the hazards to navigation, and to protect human life and the environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PlaceOfRefuge : ReportableServiceArea {
			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(PlaceOfRefuge);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..PlaceOfRefuge._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..PlaceOfRefuge._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..PlaceOfRefuge._primitives];
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
		/// Indicates the coverage of a sea area by a radar surveillance station. Inside this area a vessel may request shore-based radar assistance, particularly in poor visibility.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarRange : FeatureType {
			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,7])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(RadarRange);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RadarRange._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RadarRange._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RadarRange._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(VesselTrafficServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(LocalPortServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(ShipReportingServiceArea)],
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
		/// A designated position at which vessels are required to report to a traffic control centre. Also called reporting point or radio reporting point.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioCallingInPoint : FeatureType {
			[XmlElement("callSign")]
			public String? callSign {get;set;} = default;

			public bool ShouldSerializecallSign() { return !string.IsNullOrEmpty(callSign); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfCargo")]
			public SerializableEnumeration<categoryOfCargo>[] categoryOfCargoElement { get { return [.. categoryOfCargo]; } set { } }

			public bool ShouldSerializecategoryOfCargo() { return categoryOfCargo.Any(); }

			[XmlElement("categoryOfVessel")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public List<categoryOfVessel> categoryOfVessel {get;set;} = [];

			public bool ShouldSerializecategoryOfVessel() { return categoryOfVessel.Any(); }

			[XmlElement("orientationValue")]
			public List<decimal> orientationValue {get;set;} = [];

			public bool ShouldSerializeorientationValue() { return orientationValue.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,3,4,5,6,7,9])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required trafficFlow trafficFlow {get;set;} = default;

			[JsonIgnore]
			[XmlElement("trafficFlow")]
			public SerializableEnumeration<trafficFlow> trafficFlowElement { get { return trafficFlow; } set { } }

			[JsonIgnore]
			public override string Code => nameof(RadioCallingInPoint);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RadioCallingInPoint._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RadioCallingInPoint._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RadioCallingInPoint._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.curve
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(VesselTrafficServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(LocalPortServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(ShipReportingServiceArea)],
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
		/// A specified area on land or water designated by an appropriate authority within which access or navigation is restricted in accordance with certain specified conditions. A navigational restricted area is an area where the restrictions have a direct impact on the navigation of a vessel in the area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RestrictedAreaNavigational : SupervisedArea {
			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,19,20,22,23,25,27,28,29,30,31,32])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,7,8,13,14,25,26,27,28,29,30,35,36,37])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,9,18,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(RestrictedAreaNavigational);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..RestrictedAreaNavigational._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..RestrictedAreaNavigational._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..RestrictedAreaNavigational._primitives];
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
		/// A specified area on land or water designated by an appropriate authority within which access or navigation is restricted in accordance with certain specified conditions. A regulatory restricted area is an area where the restrictions have no direct impact on the navigation of a vessel in the area, but impact on the activities that can take place within the area.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RestrictedAreaRegulatory : SupervisedArea {
			[XmlIgnore]
			[EnumerationValue([1,4,5,6,7,8,9,10,12,14,19,20,22,23,25,27,28,29,30,31,32])]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfRestrictedArea")]
			public SerializableEnumeration<categoryOfRestrictedArea>[] categoryOfRestrictedAreaElement { get { return [.. categoryOfRestrictedArea]; } set { } }

			public bool ShouldSerializecategoryOfRestrictedArea() { return categoryOfRestrictedArea.Any(); }

			[XmlIgnore]
			[EnumerationValue([3,4,5,6,9,10,11,12,15,16,17,18,19,20,21,22,23,24,39])]
			public List<restriction> restriction {get;set;} = [];

			[JsonIgnore]
			[XmlElement("restriction")]
			public SerializableEnumeration<restriction>[] restrictionElement { get { return [.. restriction]; } set { } }

			public bool ShouldSerializerestriction() { return restriction.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,9,18,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(RestrictedAreaRegulatory);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..RestrictedAreaRegulatory._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..RestrictedAreaRegulatory._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..RestrictedAreaRegulatory._primitives];
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
		/// An area or line designating the limits or central line of a routeing measure (or part of a routeing measure). Routeing measures include traffic separation schemes, deep-water routes, two-way routes, archipelagic sea lanes, and fairway systems.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RouteingMeasure : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6])]
			public required categoryOfRouteingMeasure categoryOfRouteingMeasure {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfRouteingMeasure")]
			public SerializableEnumeration<categoryOfRouteingMeasure> categoryOfRouteingMeasureElement { get { return categoryOfRouteingMeasure; } set { } }

			[XmlIgnore]
			[EnumerationValue([1,2])]
			public categoryOfTrafficSeparationScheme? categoryOfTrafficSeparationScheme {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfTrafficSeparationScheme")]
			public SerializableEnumeration<categoryOfTrafficSeparationScheme>? categoryOfTrafficSeparationSchemeElement { get { return categoryOfTrafficSeparationScheme; } set { } }

			public bool ShouldSerializecategoryOfTrafficSeparationScheme() { return categoryOfTrafficSeparationScheme.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public categoryOfNavigationLine? categoryOfNavigationLine {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfNavigationLine")]
			public SerializableEnumeration<categoryOfNavigationLine>? categoryOfNavigationLineElement { get { return categoryOfNavigationLine; } set { } }

			public bool ShouldSerializecategoryOfNavigationLine() { return categoryOfNavigationLine.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(RouteingMeasure);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..RouteingMeasure._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..RouteingMeasure._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..RouteingMeasure._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface, Primitives.curve
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
		/// A service established by a relevant authority consisting of one or more reporting points or lines at which ships are required to report their identity, course, speed and other data to the monitoring authority.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShipReportingServiceArea : ReportableServiceArea {
			[XmlElement("serviceAccessProcedure")]
			public String? serviceAccessProcedure {get;set;} = default;

			public bool ShouldSerializeserviceAccessProcedure() { return !string.IsNullOrEmpty(serviceAccessProcedure); }

			[XmlElement("requirementsForMaintenanceOfListeningWatch")]
			public required String requirementsForMaintenanceOfListeningWatch {get;set;} = string.Empty;

			[JsonIgnore]
			public override string Code => nameof(ShipReportingServiceArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..ShipReportingServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..ShipReportingServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..ShipReportingServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadioCallingInPoint)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadarRange)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationTraffic)],
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
		/// A warning signal station is a place on shore from which warning signals are made to ships at sea.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SignalStationWarning : FeatureType {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18])]
			public List<categoryOfSignalStationWarning> categoryOfSignalStationWarning {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfSignalStationWarning")]
			public SerializableEnumeration<categoryOfSignalStationWarning>[] categoryOfSignalStationWarningElement { get { return [.. categoryOfSignalStationWarning]; } set { } }

			public bool ShouldSerializecategoryOfSignalStationWarning() { return categoryOfSignalStationWarning.Any(); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,12,14,15,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(SignalStationWarning);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..SignalStationWarning._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..SignalStationWarning._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..SignalStationWarning._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(VesselTrafficServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(LocalPortServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(ShipReportingServiceArea)],
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
		/// A traffic signal station is a place on shore from which signals are made to regulate the movement of traffic.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SignalStationTraffic : OrganizationContactArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,13])]
			public List<categoryOfSignalStationTraffic> categoryOfSignalStationTraffic {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfSignalStationTraffic")]
			public SerializableEnumeration<categoryOfSignalStationTraffic>[] categoryOfSignalStationTrafficElement { get { return [.. categoryOfSignalStationTraffic]; } set { } }

			public bool ShouldSerializecategoryOfSignalStationTraffic() { return categoryOfSignalStationTraffic.Any(); }

			[XmlElement("communicationChannel")]
			public List<String> communicationChannel {get;set;} = [];

			public bool ShouldSerializecommunicationChannel() { return communicationChannel.Any(); }

			[XmlIgnore]
			[EnumerationValue([1,2,4,5,7,8,12,14,15,16,17])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(SignalStationTraffic);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..OrganizationContactArea._informationBindingDefinitions, ..SignalStationTraffic._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..OrganizationContactArea._featureBindingDefinitions, ..SignalStationTraffic._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..OrganizationContactArea._primitives, ..SignalStationTraffic._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(VesselTrafficServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(LocalPortServiceArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.componentOf)!,
					featureTypes = [nameof(ShipReportingServiceArea)],
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
		/// An area for which an authority has stated under keel allowance requirements.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UnderKeelClearanceAllowanceArea : FeatureType {
			[XmlElement("underKeelAllowance")]
			public underKeelAllowance? underKeelAllowance {get;set;} = default;

			public bool ShouldSerializeunderKeelAllowance() { return underKeelAllowance!=default; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public waterLevelTrend? waterLevelTrend {get;set;} = default;

			[JsonIgnore]
			[XmlElement("waterLevelTrend")]
			public SerializableEnumeration<waterLevelTrend>? waterLevelTrendElement { get { return waterLevelTrend; } set { } }

			public bool ShouldSerializewaterLevelTrend() { return waterLevelTrend.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(UnderKeelClearanceAllowanceArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..FeatureType._informationBindingDefinitions, ..UnderKeelClearanceAllowanceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..FeatureType._featureBindingDefinitions, ..UnderKeelClearanceAllowanceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..FeatureType._primitives, ..UnderKeelClearanceAllowanceArea._primitives];
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
		/// An area for which an authority permits use of dynamic under keel clearance information or provides dynamic information related to under keel clearances.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UnderKeelClearanceManagementArea : ReportableServiceArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required dynamicResource dynamicResource {get;set;} = default;

			[JsonIgnore]
			[XmlElement("dynamicResource")]
			public SerializableEnumeration<dynamicResource> dynamicResourceElement { get { return dynamicResource; } set { } }

			[JsonIgnore]
			public override string Code => nameof(UnderKeelClearanceManagementArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..UnderKeelClearanceManagementArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..UnderKeelClearanceManagementArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..UnderKeelClearanceManagementArea._primitives];
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
		/// The area of any service implemented by a relevant authority primarily designed to improve safety and efficiency of traffic flow and the protection of the environment. It may range from simple information messages, to extensive organisation of the traffic involving national or regional schemes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VesselTrafficServiceArea : ReportableServiceArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public List<categoryOfVesselTrafficService> categoryOfVesselTrafficService {get;set;} = [];

			[JsonIgnore]
			[XmlElement("categoryOfVesselTrafficService")]
			public SerializableEnumeration<categoryOfVesselTrafficService>[] categoryOfVesselTrafficServiceElement { get { return [.. categoryOfVesselTrafficService]; } set { } }

			public bool ShouldSerializecategoryOfVesselTrafficService() { return categoryOfVesselTrafficService.Any(); }

			[XmlElement("serviceAccessProcedure")]
			public String? serviceAccessProcedure {get;set;} = default;

			public bool ShouldSerializeserviceAccessProcedure() { return !string.IsNullOrEmpty(serviceAccessProcedure); }

			[XmlElement("requirementsForMaintenanceOfListeningWatch")]
			public required String requirementsForMaintenanceOfListeningWatch {get;set;} = string.Empty;

			[JsonIgnore]
			public override string Code => nameof(VesselTrafficServiceArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ReportableServiceArea._informationBindingDefinitions, ..VesselTrafficServiceArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ReportableServiceArea._featureBindingDefinitions, ..VesselTrafficServiceArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ReportableServiceArea._primitives, ..VesselTrafficServiceArea._primitives];
			public new static Primitives[] _primitives => [
				Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadioCallingInPoint)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(RadarRange)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficControlServiceAggregation),
					role = Enum.GetName<Role>(Role.consistsOf)!,
					featureTypes = [nameof(SignalStationTraffic)],
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
		public partial class WaterwayArea : SupervisedArea {
			[XmlIgnore]
			[EnumerationValue([1,2,3,4])]
			public required dynamicResource dynamicResource {get;set;} = default;

			[JsonIgnore]
			[XmlElement("dynamicResource")]
			public SerializableEnumeration<dynamicResource> dynamicResourceElement { get { return dynamicResource; } set { } }

			[XmlElement("siltationRate")]
			public String? siltationRate {get;set;} = default;

			public bool ShouldSerializesiltationRate() { return !string.IsNullOrEmpty(siltationRate); }

			[XmlIgnore]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,28])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			[XmlElement("status")]
			public SerializableEnumeration<status>[] statusElement { get { return [.. status]; } set { } }

			public bool ShouldSerializestatus() { return status.Any(); }

			[JsonIgnore]
			public override string Code => nameof(WaterwayArea);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..SupervisedArea._informationBindingDefinitions, ..WaterwayArea._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..SupervisedArea._featureBindingDefinitions, ..WaterwayArea._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..SupervisedArea._primitives, ..WaterwayArea._primitives];
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
		/// Abstract feature type for data quality meta-features.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class DataQuality : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[JsonIgnore]
			public override string Code => nameof(DataQuality);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DataQuality._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DataQuality._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DataQuality._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Abstract type for meta-feature which can describe temporal variation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class QualityOfTemporalVariation : DataQuality {
			[XmlIgnore]
			[EnumerationValue([1,4,5])]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			[JsonIgnore]
			[XmlElement("categoryOfTemporalVariation")]
			public SerializableEnumeration<categoryOfTemporalVariation>? categoryOfTemporalVariationElement { get { return categoryOfTemporalVariation; } set { } }

			public bool ShouldSerializecategoryOfTemporalVariation() { return categoryOfTemporalVariation.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(QualityOfTemporalVariation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..DataQuality._informationBindingDefinitions, ..QualityOfTemporalVariation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..DataQuality._featureBindingDefinitions, ..QualityOfTemporalVariation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..DataQuality._primitives, ..QualityOfTemporalVariation._primitives];
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
		public partial class QualityOfNonBathymetricData : QualityOfTemporalVariation {
			[XmlElement("orientationUncertainty")]
			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			[XmlElement("horizontalDistanceUncertainty")]
			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			[XmlElement("horizontalPositionUncertainty")]
			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalPositionUncertainty() { return horizontalPositionUncertainty!=default; }

			[XmlElement("sourceIndication")]
			public sourceIndication? sourceIndication {get;set;} = default;

			public bool ShouldSerializesourceIndication() { return sourceIndication!=default; }

			[XmlElement("surveyDateRange")]
			public surveyDateRange? surveyDateRange {get;set;} = default;

			public bool ShouldSerializesurveyDateRange() { return surveyDateRange!=default; }

			[JsonIgnore]
			public override string Code => nameof(QualityOfNonBathymetricData);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..QualityOfTemporalVariation._informationBindingDefinitions, ..QualityOfNonBathymetricData._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..QualityOfTemporalVariation._featureBindingDefinitions, ..QualityOfNonBathymetricData._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..QualityOfTemporalVariation._primitives, ..QualityOfNonBathymetricData._primitives];
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
		/// The Text Placement feature is used in association with the Feature Name attribute or a light description to optimize text positioning in ECDIS.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("flipBearing")]
			public decimal? flipBearing {get;set;} = default;

			public bool ShouldSerializeflipBearing() { return flipBearing.HasValue; }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlIgnore]
			[EnumerationValue([1,2,3])]
			public required textJustification textJustification {get;set;} = default;

			[JsonIgnore]
			[XmlElement("textJustification")]
			public SerializableEnumeration<textJustification> textJustificationElement { get { return textJustification; } set { } }

			[XmlElement("text")]
			public String? text {get;set;} = default;

			public bool ShouldSerializetext() { return !string.IsNullOrEmpty(text); }

			[XmlIgnore]
			[EnumerationValue([1])]
			public textType? textType {get;set;} = default;

			[JsonIgnore]
			[XmlElement("textType")]
			public SerializableEnumeration<textType>? textTypeElement { get { return textType; } set { } }

			public bool ShouldSerializetextType() { return textType.HasValue; }

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

	[XmlType(Namespace = "http://www.iho.int/S127/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;

		[JsonIgnore]
		[XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public override string SchemaLocation { get; set; } = "http://www.iho.int/S127/2.0 127_2.0.0.xsd";
	}

	[XmlType(Namespace = "http://www.iho.int/S127/2.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.InformationType", typeof(InformationTypes.InformationType), Order = 1, ElementName = "InformationType")]
		[XmlElement("InformationTypes.AbstractRxN", typeof(InformationTypes.AbstractRxN), Order = 1, ElementName = "AbstractRxN")]
		[XmlElement("InformationTypes.Applicability", typeof(InformationTypes.Applicability), Order = 1, ElementName = "Applicability")]
		[XmlElement("InformationTypes.Authority", typeof(InformationTypes.Authority), Order = 1, ElementName = "Authority")]
		[XmlElement("InformationTypes.ContactDetails", typeof(InformationTypes.ContactDetails), Order = 1, ElementName = "ContactDetails")]
		[XmlElement("InformationTypes.NauticalInformation", typeof(InformationTypes.NauticalInformation), Order = 1, ElementName = "NauticalInformation")]
		[XmlElement("InformationTypes.NonStandardWorkingDay", typeof(InformationTypes.NonStandardWorkingDay), Order = 1, ElementName = "NonStandardWorkingDay")]
		[XmlElement("InformationTypes.ServiceHours", typeof(InformationTypes.ServiceHours), Order = 1, ElementName = "ServiceHours")]
		[XmlElement("InformationTypes.ShipReport", typeof(InformationTypes.ShipReport), Order = 1, ElementName = "ShipReport")]
		[XmlElement("InformationTypes.Recommendations", typeof(InformationTypes.Recommendations), Order = 1, ElementName = "Recommendations")]
		[XmlElement("InformationTypes.Regulations", typeof(InformationTypes.Regulations), Order = 1, ElementName = "Regulations")]
		[XmlElement("InformationTypes.Restrictions", typeof(InformationTypes.Restrictions), Order = 1, ElementName = "Restrictions")]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1, ElementName = "SpatialQuality")]
		[XmlElement("InformationTypes.SpatialQualityPoints", typeof(InformationTypes.SpatialQualityPoints), Order = 1, ElementName = "SpatialQualityPoints")]
		[XmlElement("FeatureTypes.CautionArea", typeof(FeatureTypes.CautionArea), Order = 1, ElementName = "CautionArea")]
		[XmlElement("FeatureTypes.ConcentrationOfShippingHazardArea", typeof(FeatureTypes.ConcentrationOfShippingHazardArea), Order = 1, ElementName = "ConcentrationOfShippingHazardArea")]
		[XmlElement("FeatureTypes.ISPSCodeSecurityLevel", typeof(FeatureTypes.ISPSCodeSecurityLevel), Order = 1, ElementName = "ISPSCodeSecurityLevel")]
		[XmlElement("FeatureTypes.LocalPortServiceArea", typeof(FeatureTypes.LocalPortServiceArea), Order = 1, ElementName = "LocalPortServiceArea")]
		[XmlElement("FeatureTypes.MilitaryPracticeArea", typeof(FeatureTypes.MilitaryPracticeArea), Order = 1, ElementName = "MilitaryPracticeArea")]
		[XmlElement("FeatureTypes.PilotBoardingPlace", typeof(FeatureTypes.PilotBoardingPlace), Order = 1, ElementName = "PilotBoardingPlace")]
		[XmlElement("FeatureTypes.PilotService", typeof(FeatureTypes.PilotService), Order = 1, ElementName = "PilotService")]
		[XmlElement("FeatureTypes.PilotageDistrict", typeof(FeatureTypes.PilotageDistrict), Order = 1, ElementName = "PilotageDistrict")]
		[XmlElement("FeatureTypes.PiracyRiskArea", typeof(FeatureTypes.PiracyRiskArea), Order = 1, ElementName = "PiracyRiskArea")]
		[XmlElement("FeatureTypes.PlaceOfRefuge", typeof(FeatureTypes.PlaceOfRefuge), Order = 1, ElementName = "PlaceOfRefuge")]
		[XmlElement("FeatureTypes.RadarRange", typeof(FeatureTypes.RadarRange), Order = 1, ElementName = "RadarRange")]
		[XmlElement("FeatureTypes.RadioCallingInPoint", typeof(FeatureTypes.RadioCallingInPoint), Order = 1, ElementName = "RadioCallingInPoint")]
		[XmlElement("FeatureTypes.RestrictedAreaNavigational", typeof(FeatureTypes.RestrictedAreaNavigational), Order = 1, ElementName = "RestrictedAreaNavigational")]
		[XmlElement("FeatureTypes.RestrictedAreaRegulatory", typeof(FeatureTypes.RestrictedAreaRegulatory), Order = 1, ElementName = "RestrictedAreaRegulatory")]
		[XmlElement("FeatureTypes.RouteingMeasure", typeof(FeatureTypes.RouteingMeasure), Order = 1, ElementName = "RouteingMeasure")]
		[XmlElement("FeatureTypes.ShipReportingServiceArea", typeof(FeatureTypes.ShipReportingServiceArea), Order = 1, ElementName = "ShipReportingServiceArea")]
		[XmlElement("FeatureTypes.SignalStationWarning", typeof(FeatureTypes.SignalStationWarning), Order = 1, ElementName = "SignalStationWarning")]
		[XmlElement("FeatureTypes.SignalStationTraffic", typeof(FeatureTypes.SignalStationTraffic), Order = 1, ElementName = "SignalStationTraffic")]
		[XmlElement("FeatureTypes.UnderKeelClearanceAllowanceArea", typeof(FeatureTypes.UnderKeelClearanceAllowanceArea), Order = 1, ElementName = "UnderKeelClearanceAllowanceArea")]
		[XmlElement("FeatureTypes.UnderKeelClearanceManagementArea", typeof(FeatureTypes.UnderKeelClearanceManagementArea), Order = 1, ElementName = "UnderKeelClearanceManagementArea")]
		[XmlElement("FeatureTypes.VesselTrafficServiceArea", typeof(FeatureTypes.VesselTrafficServiceArea), Order = 1, ElementName = "VesselTrafficServiceArea")]
		[XmlElement("FeatureTypes.WaterwayArea", typeof(FeatureTypes.WaterwayArea), Order = 1, ElementName = "WaterwayArea")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.QualityOfNonBathymetricData", typeof(FeatureTypes.QualityOfNonBathymetricData), Order = 1, ElementName = "QualityOfNonBathymetricData")]
		[XmlElement("FeatureTypes.TextPlacement", typeof(FeatureTypes.TextPlacement), Order = 1, ElementName = "TextPlacement")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
