using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S201 {
	public static class Summary
	{
		public static Version Version => new Version("2.0.0");
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
	public enum ChangeTypes : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Advanced notice of changes")] 
		AdvancedNoticeOfChanges = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Discrepancy")] 
		Discrepancy = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Proposed changes")] 
		ProposedChanges = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Temporary changes")] 
		TemporaryChanges = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum heightLengthUnits : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Metres")] 
		Metres = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Feet")] 
		Feet = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Kilometres")] 
		Kilometres = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Hectometres")] 
		Hectometres = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Statute Miles")] 
		StatuteMiles = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Nautical Miles")] 
		NauticalMiles = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum horizontalDatum : int {
		[System.ComponentModel.Description("AStandardForUseInCartographyGeodesyAndSatelliteNavigationIncludingGpsThisStandardIncludesTheDefinitionOfTheCoordinateSystemSFundamentalAndDerivedConstantsTheEllipsoidalNormalEarthGravitationalModelEgmADescriptionOfTheAssociatedWorldMagneticModelWmmAndACurrentListOfLocalDatumTransformationsTheWgs72IsBasedOnSelectedSatelliteSurfaceGravityAndAstrogeodeticDataAvailableThrough1972")]
		[EnumMember(Value = "WGS 72")] 
		Wgs72 = 1,

		[System.ComponentModel.Description("AStandardForUseInCartographyGeodesyAndSatelliteNavigationIncludingGpsThisStandardIncludesTheDefinitionOfTheCoordinateSystemSFundamentalAndDerivedConstantsTheEllipsoidalNormalEarthGravitationalModelEgmADescriptionOfTheAssociatedWorldMagneticModelWmmAndACurrentListOfLocalDatumTransformationsWgs84IsTheReferenceCoordinateSystemUsedByTheGlobalPositioningSystem")]
		[EnumMember(Value = "WGS 84")] 
		Wgs84 = 2,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1950SuitableForUseInEuropeWestAndorraCyprusDenmarkOnshoreAndOffshoreFaroeIslandsOnshoreFranceOffshoreGermanyOffshoreNorthSeaGibraltarGreeceOffshoreIsraelOffshoreItalyIncludingSanMarinoAndVaticanCityStateIrelandOffshoreMaltaNetherlandsOffshoreNorthSeaNorwayIncludingSvalbardOnshoreAndOffshorePortugalMainlandOffshoreSpainOnshoreTurkeyOnshoreAndOffshoreUnitedKingdomUkcsOffshoreEastOf6wIncludingChannelIslandsGuernseyAndJerseyEgyptWesternDesertIraqOnshoreJordanEuropeanDatum1950ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianEuropeanDatum1950OriginIsFundamentalPointPotsdamHelmertTowerLatitude5222514456NLongitude1303589283EOfGreenwichEuropeanDatum1950IsAGeodeticDatumForTopographicMappingGeodeticSurvey")]
		[EnumMember(Value = "European 1950")] 
		European1950 = 3,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1990SuitableForUseInGermanyThuringenPotsdamDatum83ReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianPotsdamDatum83OriginIsFundamentalPointRauenbergLatitude522712021NLongitude132204928EOfGreenwichThisStationWasDestroyedIn1910AndTheStationAtPotsdamSubstitutedAsTheFundamentalPointPotsdamDatum83IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromBkgViaEurogeographicsHttpCrsBkgBundDePd83IsTheRealisationOfDhdnInThuringenItIsTheResultantOfApplyingATransformationDerivedAt13PointsOnTheBorderBetweenEastAndWestGermanyToPulkovo194283PointsInThuringen")]
		[EnumMember(Value = "Potsdam Datum")] 
		PotsdamDatum = 4,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1958SuitableForUseInEritreaEthiopiaSouthSudanSudanAdindanReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianAdindanOriginIsFundamentalPointStation15AdindanLatitude221007110NLongitude312921608EOfGreenwichAdindanIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromUsCoastAndGeodeticSurveyViaGeophysicalReasearchVol6711October1962The12thParallelTraverseOf196670Point58DatumCode6620IsConnectedToTheBlueNile1958NetworkInWesternSudanThisHasGivenRiseToMisconceptionsThatTheBlueNileNetworkIsUsedInWestAfrica")]
		[EnumMember(Value = "Adindan")] 
		Adindan = 5,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedInAndSuitableForUseInSomaliaOnshoreAfgooyeReferencesTheKrassowsky1940EllipsoidAndTheGreenwichPrimeMeridianAfgooyeIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Afgooye")] 
		Afgooye = 6,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1970AndSuitableForUseInBahrainKuwaitAndSaudiArabiaOnshoreAinElAbd1970ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAinElAbd1970OriginIsFundamentalPointAinElAbdLatitude281406171NLongitude481620906EOfGreenwichAinElAbd1970IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Ain el Abd 1970")] 
		AinElAbd1970 = 7,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1965SuitableForUseInCocosKeelingIslandsOnshoreCocosIslands1965ReferencesTheAustralianNationalSpheroidEllipsoidAndTheGreenwichPrimeMeridianCocosIslands1965OriginIsFundamentalPointAnna1CocosIslands1965IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Anna 1 Astro 1965")] 
		Anna1Astro1965 = 8,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1943SuitableForUseInAntiguaIslandOnshoreAntigua1943ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianAntigua1943OriginIsFundamentalPointStationA14Antigua1943IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfGreatBritain")]
		[EnumMember(Value = "Antigua Island Astro 1943")] 
		AntiguaIslandAstro1943 = 9,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1950SuitableForUseInBotswanaMalawiZambiaZimbabweArc1950ReferencesTheClarke1880ArcEllipsoidAndTheGreenwichPrimeMeridianArc1950OriginIsFundamentalPointBuffelsfonteinLatitude335932000SLongitude253044622EOfGreenwichArc1950IsAGeodeticDatumForTopographicMappingGeodeticSurvey")]
		[EnumMember(Value = "Arc 1950")] 
		Arc1950 = 10,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1960SuitableForUseInKenyaTanzaniaUgandaArc1960ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianArc1960OriginIsFundamentalPointBuffelsfonteinLatitude335932000SLongitude253044622EOfGreenwichArc1960IsAGeodeticDatumForTopographicMappingGeodeticSurvey")]
		[EnumMember(Value = "Arc 1960")] 
		Arc1960 = 11,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1958SuitableForUseInStHelenaAscensionAndTristanDaCunhaAscensionIslandOnshoreAscensionIsland1958ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAscensionIsland1958IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Ascension Island 1958")] 
		AscensionIsland1958 = 12,

		[System.ComponentModel.Description("AstroBeaconE1945")]
		[EnumMember(Value = "Astro Beacon 'E' 1945")] 
		AstroBeaconE1945 = 13,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1971SuitableForUseInStHelenaAscensionAndTristanDaCunhaStHelenaIslandOnshoreAstroDos71ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAstroDos71OriginIsFundamentalPointDos714LadderHillFortLatitude155530SLongitude54325WOfGreenwichAstroDos71IsAGeodeticDatumForGeodeticControlMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000AndStHelenaGovernmentEnvironmentAndNaturalResourcesDirectorateEnrd")]
		[EnumMember(Value = "Astro DOS 71/4")] 
		AstroDos714 = 14,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1961SuitableForUseInUnitedStatesUsaHawaiiTernIslandAndSorelAtollTernIsland1961ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianTernIsland1961OriginIsFundamentalPointStationFrigOnTernIslandStationB4OnSorolAtollTernIsland1961IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr83502Original1987FirstEditionAnd3rdEditionAmendment13January2000TwoIndependentAstronomicDeterminationsConsideredToBeConsistentThroughAdoptionOfCommonTransformationToWgs84SeeTfmCode15795")]
		[EnumMember(Value = "Astro Tern Island (FRIG) 1961")] 
		AstroTernIslandFrig1961 = 15,

		[System.ComponentModel.Description("AstronomicalStation1952")]
		[EnumMember(Value = "Astronomical Station 1952")] 
		AstronomicalStation1952 = 16,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1966SuitableForUseInAustraliaOnshoreAndOffshorePapuaNewGuineaOnshoreAustralianGeodeticDatum1966ReferencesTheAustralianNationalSpheroidEllipsoidAndTheGreenwichPrimeMeridianAustralianGeodeticDatum1966OriginIsFundamentalPointJohnsonMemorialCairnLatitude2556545515SLongitude13312300771EOfGreenwichAustralianGeodeticDatum1966IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromAustralianMapGridTechnicalManualNationalMappingCouncilOfAustraliaTechnicalPublication71972")]
		[EnumMember(Value = "Australian Geodetic 1966")] 
		AustralianGeodetic1966 = 17,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1984SuitableForUseInAustraliaQueenslandSouthAustraliaWesternAustraliaFederalAreasOffshoreWestOf129eAustralianGeodeticDatum1984ReferencesTheAustralianNationalSpheroidEllipsoidAndTheGreenwichPrimeMeridianAustralianGeodeticDatum1984OriginIsFundamentalPointJohnsonMemorialCairnLatitude2556545515SLongitude13312300771EOfGreenwichAustralianGeodeticDatum1984IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromGdaTechnicalManualV2_2IntergovernmentalCommitteeOnSurveyingAndMappingWwwAnzlicOrgAuIcsmGdtmUsesAllDataFrom1966AdjustmentWithAdditionalObservationsImprovedSoftwareAndAGeoidModel")]
		[EnumMember(Value = "Australian Geodetic 1984")] 
		AustralianGeodetic1984 = 18,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInDjiboutiOnshoreAndOffshoreAyabelleLighthouseReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianAyabelleLighthouseOriginIsFundamentalPointAyabelleLighthouseAyabelleLighthouseIsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Ayabelle Lighthouse")] 
		AyabelleLighthouse = 19,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1960SuitableForUseInVanuatuSouthernIslandsAneityumEfateErromangoAndTannaBellevueReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianBellevueIsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000DatumCoversAllTheMajorIslandsOfVanuatuInTwoDifferentAdjustmentBlocksButPracticalUsageIsAsGivenInTheAreaOfUse")]
		[EnumMember(Value = "Bellevue (IGN)")] 
		BellevueIgn = 20,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1957SuitableForUseInBermudaOnshoreBermuda1957ReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianBermuda1957OriginIsFundamentalPointFortGeorgeBaseLatitude32224436NLongitude64405811WOfGreenwichBermuda1957IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromVariousOilIndustrySources")]
		[EnumMember(Value = "Bermuda 1957")] 
		Bermuda1957 = 21,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedInAndIsSuitableForUseInGuineaBissauOnshoreBissauReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianBissauOriginIsBissauIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaTr83502Ftp164214265PubGigTr83502ChangesPdf")]
		[EnumMember(Value = "Bissau")] 
		Bissau = 22,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1975SuitableForUseInColombiaMainlandAndOffshoreCaribbeanBogota1975ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianBogota1975OriginIsFundamentalPointBogotaObservatoryLatitude43556570NLongitude740451300WOfGreenwichBogota1975IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoAgustinCodazziIgacSpecialPublicationNo14thEdition1975GeodesiaResultadosDefinitvosDeParteDeLasRedesGeodesicasEstablecidasEnElPaisReplaces1951AdjustmentReplacedByMagnaSirgasDatumCode6685")]
		[EnumMember(Value = "Bogota Observatory")] 
		BogotaObservatory = 23,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInIndonesiaBangaAndBelitungIslandsBukitRimpahReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianBukitRimpahOriginIs2004016S105513976EOfGreenwichBukitRimpahIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Bukit Rimpah")] 
		BukitRimpah = 24,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInAntarcticaMcmurdoSoundCampMcmurdoAreaCampAreaAstroReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianCampAreaAstroIsAGeodeticDatumForGeodeticAndTopographicSurveyItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Camp Area Astro")] 
		CampAreaAstro = 25,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInArgentinaMainlandOnshoreAndAtlanticOffshoreTierraDelFuegoCampoInchauspeReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianCampoInchauspeOriginIsFundamentalPointCampoInchauspeLatitude35581656SLongitude62101203WOfGreenwichCampoInchauspeIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Campo Inchauspe 1969")] 
		CampoInchauspe1969 = 26,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1966SuitableForUseInKiribatiPhoenixIslandsKantonOronaMckeanAtollBirnieAtollPhoenixSeamountsPhoenixIslands1966ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianPhoenixIslands1966IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Canton Astro 1966")] 
		CantonAstro1966 = 27,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInBotswanaLesothoSouthAfricaMainlandSwazilandCapeReferencesTheClarke1880ArcEllipsoidAndTheGreenwichPrimeMeridianCapeOriginIsFundamentalPointBuffelsfonteinLatitude335932000SLongitude253044622EOfGreenwichCapeIsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromPrivateCommunicationDirectorateOfSurveysAndLandInformationCapeTown")]
		[EnumMember(Value = "Cape Datum")] 
		CapeDatum = 28,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1963SuitableForUseInNorthAmericaOnshoreBahamasAndUsaFloridaEastCapeCanaveralReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianCapeCanaveralOriginIsFundamentalPointCentral1950Latitude28293236555NLongitude80343877362WOfGreenwichCapeCanaveralIsAGeodeticDatumForUsSpaceAndMilitaryOperationsItWasDefinedByInformationFromUsNgsAndDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Cape Canaveral")] 
		CapeCanaveral = 29,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1925SuitableForUseInTunisiaOnshoreAndOffshoreCarthageReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianCarthageOriginIsFundamentalPointCarthageLatitude409464506g36510650NLongitude88724368gEOfParis10192072EOfGreenwichCarthageIsAGeodeticDatumForTopographicMappingFundamentalPointAstronomicCoordinatesDeterminedIn1878")]
		[EnumMember(Value = "Carthage")] 
		Carthage = 30,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1971SuitableForUseInNewZealandChathamIslandsGroupOnshoreChathamIslandsDatum1971ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianChathamIslandsDatum1971IsAGeodeticDatumForGeodeticSurveyTopographicMappingEngineeringSurveyItWasDefinedByInformationFromOfficeOfSurveyorGeneralOsgTechnicalReport14June2001ReplacedByChathamIslandsDatum1979Code6673")]
		[EnumMember(Value = "Chatam Island Astro 1971")] 
		ChatamIslandAstro1971 = 31,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInBrazilSouthOf18sAndWestOf54wPlusDistritoFederalParaguayNorthChuaReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianChuaOriginIsFundamentalPointChuaLatitude194541160SLongitude480607560WOfGreenwichChuaIsAGeodeticDatumForGeodeticSurveyItWasDefinedByInformationFromNimaHttpEarthInfoNimaMilTheChuaOriginAndAssociatedNetworkIsInBrazilWithAConnectingTraverseThroughNorthernParaguayItWasUsedInBrazilOnlyAsInputIntoTheCorregoAllegreAdjustmentAndForGovernmentWorkInDistritoFederal")]
		[EnumMember(Value = "Chua Astro")] 
		ChuaAstro = 32,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1972SuitableForUseInBrazilOnshoreWestOf54wAndSouthOf18sAlsoSouthOf15sBetween54wAnd42wAlsoEastOf42wCorregoAlegre197072ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianCorregoAlegre197072OriginIsFundamentalPointCorregoAlegreLatitude19501491SLongitude48574198WOfGreenwichCorregoAlegre197072IsAGeodeticDatumForTopographicMappingGeodeticSurveySupersededBySad69ItWasDefinedByInformationFromIbgeReplaces1961AdjustmentDatumCode1074NimaGivesCoordinatesOfOriginAsLatitude19501514SLongitude48574275WTheseMayReferTo1961Adjustment")]
		[EnumMember(Value = "Corrego Alegre")] 
		CorregoAlegre = 33,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1981SuitableForUseInGuineaOnshoreDabola1981ReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianDabola1981IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromIgnParis")]
		[EnumMember(Value = "Dabola")] 
		Dabola = 34,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInIndonesiaOnshoreJavaAndBaliBataviaJakartaReferencesTheBessel1841EllipsoidAndTheJakartaPrimeMeridianBataviaJakartaOriginIsFundamentalPointLongitudeAtBataviaAstronomicalStationLatitude60739522SLongitude000000EOfJakartaLatitudeAndAzimuthAtGenukBataviaJakartaIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Djakarta (Batavia)")] 
		DjakartaBatavia = 35,

		[System.ComponentModel.Description("Dos1968")]
		[EnumMember(Value = "DOS 1968")] 
		Dos1968 = 36,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1967SuitableForUseInChileEasterIslandOnshoreEasterIsland1967ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianEasterIsland1967IsAGeodeticDatumForMilitaryAndTopographicMapping25MetersInEachComponentItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Easter Island 1967")] 
		EasterIsland1967 = 37,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1979SuitableForUseInEuropeWestEuropeanDatum1979ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianEuropeanDatum1979OriginIsFundamentalPointPotsdamHelmertTowerLatitude5222514456NLongitude1303589283EOfGreenwichEuropeanDatum1979IsAGeodeticDatumForScientificNetworkReplacedBy1987Adjustment")]
		[EnumMember(Value = "European 1979")] 
		European1979 = 38,

		[System.ComponentModel.Description("FortThomas1955Datum")]
		[EnumMember(Value = "Fort Thomas 1955")] 
		FortThomas1955 = 39,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1970SuitableForUseInMaldivesOnshoreGan1970ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianGan1970IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromVariousIndustrySourcesInSomeReferencesIncorrectlyNamedGandajika1970")]
		[EnumMember(Value = "Gan 1970")] 
		Gan1970 = 40,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1949SuitableForUseInNewZealandNorthIslandSouthIslandStewartIslandOnshoreAndNearshoreNewZealandGeodeticDatum1949ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianNewZealandGeodeticDatum1949OriginIsFundamentalPointPapatahiLatitude41198900SLongitude1750251000EOfGreenwichNewZealandGeodeticDatum1949IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromLandInformationNewZealandHttpWwwLinzGovtNzRcsLinzPubWebRootCoreSurveysystemGeodeticinfoGeodeticdatumsNzgd2000factsheetIndexJspReplacedByNewZealandGeodeticDatum2000Code6167FromMarch2000")]
		[EnumMember(Value = "Geodetic Datum 1949")] 
		GeodeticDatum1949 = 41,

		[System.ComponentModel.Description("GraciosaBaseSw1948Datum")]
		[EnumMember(Value = "Graciosa Base SW 1948")] 
		GraciosaBaseSw1948 = 42,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1963SuitableForUseInGuamOnshoreGuam1963ReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianGuam1963OriginIsFundamentalPointTagchaLatitude13223849NLongitude144455156EOfGreenwichGuam1963IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromUsNationalGeospatialIntelligenceAgencyNgaHttpEarthInfoNgaMilReplacedByNad83Harn")]
		[EnumMember(Value = "Guam 1963")] 
		Guam1963 = 43,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInIndonesiaKalimantanOnshoreEastCoastalAreaIncludingMahakamDeltaCoastalAndOffshoreShelfAreasGunungSegaraReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianGunungSegaraOriginIsStationP5GunungSegaraLatitude0321283SLongitude117084847EOfGreenwichGunungSegaraIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromTotalfinaelf")]
		[EnumMember(Value = "Gunung Segara")] 
		GunungSegara = 44,

		[System.ComponentModel.Description("Gux1AstroDatum")]
		[EnumMember(Value = "GUX 1 Astro")] 
		Gux1Astro = 45,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInAfghanistanHeratNorthReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianHeratNorthOriginIsFundamentalPointHeratNorthLatitude34230908NLongitude64105894EOfGreenwichHeratNorthIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Herat North")] 
		HeratNorth = 46,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1955SuitableForUseInIcelandOnshoreHjorsey1955ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianHjorsey1955OriginIsFundamentalPointLatitude64312926NLongitude22220584WOfGreenwichHjorsey1955IsAGeodeticDatumFor150000ScaleTopographicMappingItWasDefinedByInformationFromLandmaelingarIslandsNationalSurveyOfIceland")]
		[EnumMember(Value = "Hjorsey 1955")] 
		Hjorsey1955 = 47,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1963SuitableForUseInChinaHongKongOnshoreAndOffshoreHongKong1963ReferencesTheClarke1858EllipsoidAndTheGreenwichPrimeMeridianHongKong1963OriginIsFundamentalPointTrigZero384FeetSouthAlongTheTransitCircleOfTheKowloonObservatoryLatitude22181282NLongitude114101875EOfGreenwichHongKong1963IsAGeodeticDatumForTopographicMappingAndHydrographicChartingItWasDefinedByInformationFromSurveyAndMappingOfficeLandsDepartmentHttpWwwInfoGovHkLandsdReplacedByHongKong196367ForMilitaryPurposesOnlyIn1967ReplacedByHongKong1980")]
		[EnumMember(Value = "Hong Kong 1963")] 
		HongKong1963 = 48,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1950SuitableForUseInTaiwanRepublicOfChinaOnshoreTaiwanIslandPenghuPescadoresIslandsHuTzuShan1950ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianHuTzuShan1950OriginIsFundamentalPointHuTzuShanLatitude23583234NLongitude1205825975EOfGreenwichHuTzuShan1950IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaUsNgaHttpEarthInfoNgaMilGandgIndexHtml")]
		[EnumMember(Value = "Hu-Tzu-Shan")] 
		HuTzuShan = 49,

		[System.ComponentModel.Description("IndianDatum")]
		[EnumMember(Value = "Indian")] 
		Indian = 50,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1954SuitableForUseInMyanmarBurmaOnshoreThailandOnshoreIndian1954ReferencesTheEverest18301937AdjustmentEllipsoidAndTheGreenwichPrimeMeridianIndian1954OriginIsExtensionOfKalianpur1937OverMyanmarAndThailandIndian1954IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Indian 1954")] 
		Indian1954 = 51,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1975SuitableForUseInThailandOnshorePlusOffshoreGulfOfThailandIndian1975ReferencesTheEverest18301937AdjustmentEllipsoidAndTheGreenwichPrimeMeridianIndian1975OriginIsFundamentalPointKhauSakaerangIndian1975IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Indian 1975")] 
		Indian1975 = 52,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1975SuitableForUseInIrelandOnshoreUnitedKingdomUkNorthernIrelandUlsterOnshoreIreland1965ReferencesTheAiryModified1849EllipsoidAndTheGreenwichPrimeMeridianIreland1965OriginIsAdjustedToBestMeanFit9StationsOfTheOsni1952PrimaryAdjustmentInNorthernIrelandPlusThe1965ValuesOf3StationsInTheRepublicOfIrelandIreland1965IsAGeodeticDatumForGeodeticSurveyTopographicMappingAndEngineeringSurveyItWasDefinedByInformationFromTheIrishGridADescriptionOfTheCoOrdinateReferenceSystemPublishedByOrdnanceSurveyOfIrelandDublinAndOrdnanceSurveyOfNorthernIrelandBelfastDifferencesFromThe1965AdjustmentDatumCode6299AreAverageDifferenceInEastings0092mAverageDifferenceInNorthings0108mMaximumVectorDifference0548m")]
		[EnumMember(Value = "Ireland 1965")] 
		Ireland1965 = 53,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1968SuitableForUseInSouthGeorgiaAndTheSouthSandwichIslandsSouthGeorgiaOnshoreIsts061Astro1968ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianIsts061Astro1968OriginIsFundamentalPointIsts061Ists061Astro1968IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "ISTS 061 Astro 1968")] 
		Ists061Astro1968 = 54,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1969SuitableForUseInBritishIndianOceanTerritoryChagosArchipelagoDiegoGarciaIsts073Astro1969ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianIsts073Astro1969OriginIsFundamentalPointIsts073Ists073Astro1969IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "ISTS 073 Astro 1969")] 
		Ists073Astro1969 = 55,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1961SuitableForUseInUnitedStatesMinorOutlyingIslandsJohnstonIslandJohnstonIsland1961ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianJohnstonIsland1961IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Johnston Island 1961")] 
		JohnstonIsland1961 = 56,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1930SuitableForUseInSriLankaOnshoreKandawalaReferencesTheEverest18301937AdjustmentEllipsoidAndTheGreenwichPrimeMeridianKandawalaOriginIsFundamentalPointKandawalaLatitude71406838NLongitude795236670EKandawalaIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromAbeyratneFeatherstoneAndTantrigodaInSurveyReviewVol42No317July2010")]
		[EnumMember(Value = "Kandawala")] 
		Kandawala = 57,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1949SuitableForUseInFrenchSouthernTerritoriesKerguelenOnshoreReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianOriginIsK01949IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromIgnParis")]
		[EnumMember(Value = "Kerguelen Island 1949")] 
		KerguelenIsland1949 = 58,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1968SuitableForUseInMalaysiaWestMalaysiaOnshoreAndOffshoreEastCoastSingaporeOnshoreAndOffshoreKertau1968ReferencesTheEverest1830ModifiedEllipsoidAndTheGreenwichPrimeMeridianKertau1968OriginIsFundamentalPointKertauLatitude32750710NLongitude1023724550EOfGreenwichKertau1968IsAGeodeticDatumForGeodeticSurveyCadastreItWasDefinedByInformationFromDefenceGeographicCentreReplacesMrt48AndEarlierAdjustmentsAdoptsMetricConversionOf39370113InchesPerMetreNotUsedFor1969MetricationOfRsoGridSeeKertauRsoCode6751")]
		[EnumMember(Value = "Kertau 1968")] 
		Kertau1968 = 59,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1951SuitableForUseInFederatedStatesOfMicronesiaKosraeKusaieKusaie1951ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianKusaie1951IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Kusaie Astro 1951")] 
		KusaieAstro1951 = 60,

		[System.ComponentModel.Description("LC5Astro1961Datum")]
		[EnumMember(Value = "L. C. 5 Astro 1961")] 
		LC5Astro1961 = 61,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInGhanaOnshoreAndOffshoreLeigonReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianLeigonOriginIsFundamentalPointGcsStation121LeigonLatitude5385227NLongitude0114608WOfGreenwichLeigonIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyInternationalReplacedAccraDatumCode6168From1978CoordinatesAtLeigonFundamentalPointDefinedAsAccraDatumValuesForThatPoint")]
		[EnumMember(Value = "Leigon")] 
		Leigon = 62,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1964SuitableForUseInLiberiaOnshoreLiberia1964ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianLiberia1964OriginIsFundamentalPointRobertsfieldLatitude6135302NLongitude10213544WOfGreenwichLiberia1964IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Liberia 1964")] 
		Liberia1964 = 63,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1911SuitableForUseInPhilippinesOnshoreLuzonReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianLuzonOriginIsFundamentalPointBalacanLatitude133341000NLongitude1215203000EOfGreenwichLuzonIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromCoastAndGeodeticSurveyReplacedByPhilippineReferenceSystemOf1992DatumCode6683")]
		[EnumMember(Value = "Luzon")] 
		Luzon = 64,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1971SuitableForUseInSeychellesMaheIslandMahe1971ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianMahe1971OriginIsFundamentalPointStationSiteLatitude44014644SLongitude552844488EOfGreenwichMahe1971IsAGeodeticDatumForUsMilitarySurveyItWasDefinedByInformationFromCliffordMugnierSSeptember2007PeRsGridsAndDatumsArticleOnSeychellesWwwAsprsOrgResourcesGridsSouthEastIsland1943DatumCode1138UsedForTopographicMappingCadastralAndHydrographicSurvey")]
		[EnumMember(Value = "Mahe 1971")] 
		Mahe1971 = 65,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInEritreaOnshoreAndOffshoreMassawaReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianMassawaIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Massawa")] 
		Massawa = 66,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1922SuitableForUseInMoroccoOnshoreMerchichReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianMerchichOriginIsFundamentalPointMerchichLatitude332659672NLongitude73327295WOfGreenwichMerchichIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Merchich")] 
		Merchich = 67,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1961SuitableForUseInUnitedStatesMinorOutlyingIslandsMidwayIslandsSandIslandAndEasternIslandMidway1961ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianMidway1961IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Midway Astro 1961")] 
		MidwayAstro1961 = 68,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInNigeriaOnshoreAndOffshoreMinnaReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianMinnaOriginIsFundamentalPointMinnaBaseStationL40Latitude9380887NLongitude6305876EOfGreenwichMinnaIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Minna")] 
		Minna = 69,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1958SuitableForUseInMontserratOnshoreMontserrat1958ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianMontserrat1958OriginIsFundamentalPointStationM36Montserrat1958IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfGreatBritain")]
		[EnumMember(Value = "Montserrat Island Astro 1958")] 
		MontserratIslandAstro1958 = 70,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInGabonOnshoreAndOffshoreMPoralokoReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianMPoralokoIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "M'poraloko")] 
		MPoraloko = 71,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1934SuitableForUseInIraqOnshoreIranOnshoreNorthernGulfCoastAndWestBorderingSoutheastIraqNahrwan1934ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianNahrwan1934OriginIsFundamentalPointNahrwanSouthBaseLatitude33191087NLongitude44432554EOfGreenwichNahrwan1934IsAGeodeticDatumForOilExplorationAndProductionItWasDefinedByInformationFromVariousIndustrySourcesThisAdjustmentLaterDiscoveredToHaveASignificantOrientationErrorInIranReplacedByFd58InIraqReplacedByKarbala1979")]
		[EnumMember(Value = "Nahrwan")] 
		Nahrwan = 72,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1972SuitableForUseInTrinidadAndTobagoTobagoOnshoreNaparima1972ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianNaparima1972OriginIsFundamentalPointNaparimaLatitude101644860NLongitude612734620WOfGreenwichNaparima1972IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyInternationalNaparima1972IsAnExtensionOfTheNaparima1955NetworkOfTrinidadToIncludeTobago")]
		[EnumMember(Value = "Naparima, BWI")] 
		NaparimaBwi = 73,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1927SuitableForUseInNorthAndCentralAmericaAntiguaAndBarbudaBahamasBelizeBritishVirginIslandssUsageShallBeOnshoreOnlyExceptThatOnshoreAndOffshoreShallApplyToCanadaEastCoastNewBrunswickNewfoundlandAndLabradorPrinceEdwardIslandQuebecCubaMexicoGulfOfMexicoAndCaribbeanCoastsOnlyUsaAlaskaUsaGulfOfMexicoAlabamaFloridaLouisianaMississippiTexasUsaEastCoastBahamasOnshorePlusOffshoreOverInternalContinentalShelfOnlyNorthAmericanDatum1927ReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianNorthAmericanDatum1927OriginIsFundamentalPointMeadeSRanchLatitude391326686NLongitude983230506WOfGreenwichNorthAmericanDatum1927IsAGeodeticDatumForTopographicMappingInUnitedStatesUsaAndCanadaReplacedByNorthAmericanDatum1983Nad83Code6269InMexicoReplacedByMexicanDatumOf1993Code1042")]
		[EnumMember(Value = "North American 1927")] 
		NorthAmerican1927 = 74,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1986SuitableForUseInNorthAmericaOnshoreAndOffshoreCanadaPuertoRicoUnitedStatesUsaUsVirginIslandsBritishVirginIslandsNorthAmericanDatum1983ReferencesTheGrs1980EllipsoidAndTheGreenwichPrimeMeridianNorthAmericanDatum1983OriginIsOriginAtGeocentreNorthAmericanDatum1983IsAGeodeticDatumForTopographicMappingAlthoughThe1986AdjustmentIncludedConnectionsToGreenlandAndMexicoItHasNotBeenAdoptedThereInCanadaAndUsReplacedNad27")]
		[EnumMember(Value = "North American 1983")] 
		NorthAmerican1983 = 75,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1939SuitableForUseInPortugalWesternAzoresOnshoreFloresCorvoAzoresOccidentalIslands1939ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAzoresOccidentalIslands1939OriginIsFundamentalPointObservatarioMeteorologicoFloresAzoresOccidentalIslands1939IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoECadastralLisbonViaEurogeographicsHttpCrsBkgBundDeCrsEu")]
		[EnumMember(Value = "Observatorio Meteorologico 1939")] 
		ObservatorioMeteorologico1939 = 76,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1907SuitableForUseInEgyptOnshoreAndOffshoreEgypt1907ReferencesTheHelmert1906EllipsoidAndTheGreenwichPrimeMeridianEgypt1907OriginIsFundamentalPointStationF1VenusLatitude30014286NLongitude31163360EOfGreenwichEgypt1907IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurvey")]
		[EnumMember(Value = "Old Egyptian 1907")] 
		OldEgyptian1907 = 77,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInUnitedStatesUsaHawaiiMainIslandsOnshoreOldHawaiianReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianOldHawaiianOriginIsFundamentalPointOahuWestBaseAstroLatitude21181389NLongitude157505579WOfGreenwichOldHawaiianIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromHttpWwwNgsNoaaGovNadconReadmeFileHawaiianIslandsWereNeverOnNad27ButRatherOnOldHawaiianDatumNadconConversionProgramProvidesTransformationFromOldHawaiianDatumToNad83Original1986RealizationButMakingTheTransformationAppearToUserAsIfFromNad27")]
		[EnumMember(Value = "Old Hawaiian")] 
		OldHawaiian = 78,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn2013SuitableForUseInOmanOnshoreAndOffshoreOmanNationalGeodeticDatum2014ReferencesTheGrs1980EllipsoidAndTheGreenwichPrimeMeridianOmanNationalGeodeticDatum2014OriginIs20StationsOfTheOmanPrimaryNetworkTiedToItrf2008AtEpoch201315OmanNationalGeodeticDatum2014IsAGeodeticDatumForGeodeticSurveyItWasDefinedByInformationFromNationalSurveyAuthoritySultanateOfOmanReplacesWgs84G874")]
		[EnumMember(Value = "Oman")] 
		Oman = 79,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1936SuitableForUseInUnitedKingdomUkOffshoreToBoundaryOfUkcsWithin4946NTo6101NAnd733WTo333EOnshoreGreatBritainEnglandWalesAndScotlandIsleOfManOnshoreOsgb1936ReferencesTheAiry1830EllipsoidAndTheGreenwichPrimeMeridianOsgb1936OriginIsPriorTo2002FundamentalPointHerstmonceuxLatitude505155271NLongitude02045882EOfGreenwichFromApril2002TheDatumIsDefinedThroughTheApplicationOfTheOstnTransformationFromEtrs89Osgb1936IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfGreatBritainTheAverageAccuracyOfOstnComparedToTheOldTriangulationNetworkDownTo3rdOrderIs01mWithTheIntroductionOfOstn15TheAreaForOsgb1936HasEffectivelyBeenExtendedFromBritainToCoverTheAdjacentUkContinentalShelf")]
		[EnumMember(Value = "Ordnance Survey of Great Britain 1936")] 
		OrdnanceSurveyOfGreatBritain1936 = 80,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInSpainCanaryIslandsOnshorePicoDeLasNieves1984ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianPicoDeLasNieves1984IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000ReplacesPicoDeLasNieves1968Pn68ReplacedByRegcan95")]
		[EnumMember(Value = "Pico de las Nieves")] 
		PicoDeLasNieves = 81,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1967SuitableForUseInPitcairnPitcairnIslandPitcairn1967ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianPitcairn1967OriginIsFundamentalPointPitcairnAstroLatitude25040687SLongitude130064783WOfGreenwichPitcairn1967IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000ReplacedByPitcairn2006")]
		[EnumMember(Value = "Pitcairn Astro 1967")] 
		PitcairnAstro1967 = 82,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1969SuitableForUseInSenegalCentralMaliSouthwestBurkinaFasoCentralNigerSouthwestNigeriaNorthChadCentralAllInProximityToTheParallelOfLatitudeOf12nPoint58ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianPoint58OriginIsFundamentalPointPoint58Latitude125244045NLongitude35837040EOfGreenwichPoint58IsAGeodeticDatumForGeodeticSurveyItWasDefinedByInformationFromIgnParisUsedAsTheBasisForComputationOfThe12thParallelTraverseConducted196670FromSenegalToChadAndConnectingToTheBlueNile1958AdindanTriangulationInSudan")]
		[EnumMember(Value = "Point 58")] 
		Point58 = 83,

		[System.ComponentModel.Description("PointeNoire1948Datum")]
		[EnumMember(Value = "Pointe Noire 1948")] 
		PointeNoire1948 = 84,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1936SuitableForUseInPortugalMadeiraPortoSantoAndDesertasIslandsOnshorePortoSanto1936ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianPortoSanto1936OriginIsSeBaseOnPortoSantoIslandPortoSanto1936IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoECadastralLisbonHttpWwwIgeoPtReplacedBy1995AdjustmentDatumCode6663ForSelvagensSeeSelvagemGrandeCode6616")]
		[EnumMember(Value = "Porto Santo 1936")] 
		PortoSanto1936 = 85,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1956SuitableForUseInArubaOnshoreBoliviaBonaireOnshoreBrazilOffshoreAmazonConeShelfChileOnshoreNorthOf4330SCuracaoOnshoreEcuadorMainlandOnshoreGuyanaOnshorePeruOnshoreVenezuelaOnshoreProvisionalSouthAmericanDatum1956ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianProvisionalSouthAmericanDatum1956OriginIsFundamentalPointLaCanoaLatitude83417170NLongitude635134880WOfGreenwichProvisionalSouthAmericanDatum1956IsAGeodeticDatumForTopographicMappingSameOriginAsLaCanoaDatum")]
		[EnumMember(Value = "Provisional South American 1956")] 
		ProvisionalSouthAmerican1956 = 86,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1963SuitableForUseInArgentinaAndChileTierraDelFuegoOnshoreHitoXviii1963ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianHitoXviii1963OriginIsChileArgentinaBoundarySurveyHitoXviii1963IsAGeodeticDatumForGeodeticSurveyItWasDefinedByInformationFromVariousOilCompanyRecordsUsedInTierraDelFuego")]
		[EnumMember(Value = "Provisional South Chilean 1963")] 
		ProvisionalSouthChilean1963 = 87,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1901SuitableForUseInPuertoRicoUsVirginIslandsAndBritishVirginIslandsOnshorePuertoRicoReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianPuertoRicoOriginIsFundamentalPointCardonaIslandLighthouseLatitude17573140NLongitude66380753WOfGreenwichPuertoRicoIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfGreatBritainAndHttpWwwNgsNoaaGovNadconReadmeFileNadconConversionProgramProvidesTransformationFromPuertoRicoDatumToNad83Original1986RealizationButMakingTheTransformationAppearToUserAsIfFromNad27")]
		[EnumMember(Value = "Puerto Rico")] 
		PuertoRico = 88,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1995SuitableForUseInQatarOnshoreQatarNationalDatum1995ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianQatarNationalDatum1995OriginIsDefinedByTransformationFromWgs84SeeCoordinateOperationCode1840QatarNationalDatum1995IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromQatarCentreForGeographicInformation")]
		[EnumMember(Value = "Qatar National")] 
		QatarNational = 89,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1927SuitableForUseInGreenlandWestCoastOnshoreQornoq1927ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianQornoq1927OriginIsFundamentalPointStation7008Latitude64310627NLongitude51122486WOfGreenwichQornoq1927IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromKortMatrikelstyrelsenCopenhagenOriginCoordinatesFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Qornoq")] 
		Qornoq = 90,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1947SuitableForUseInReunionOnshoreReunion1947ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianReunion1947OriginIsFundamentalPointPitonDesNeigesBorneLatitude210513119SLongitude552909193EOfGreenwichReunion1947IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromIgnParisReplacedByRgr92DatumCode6627")]
		[EnumMember(Value = "Reunion")] 
		Reunion = 91,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedInAndIsSuitableForUseInItalyOnshoreAndOffshoreSanMarinoVaticanCityStateMonteMarioRomeReferencesTheInternational1924EllipsoidAndTheRomePrimeMeridianMonteMarioRomeOriginIsFundamentalPointMonteMarioLatitude41552551NLongitude0000000EOfRomeMonteMarioRomeIsAGeodeticDatumForTopographicMappingReplacedGenovaDatumBessel1841EllipsoidFrom1940")]
		[EnumMember(Value = "Rome 1940")] 
		Rome1940 = 92,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1965SuitableForUseInVanuatuNorthernIslandsAeseAmbrymAobaEpiEspirituSantoMaewoMaloMalkulaPaamaPentecostShepherdAndTutubaSanto1965ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianSanto1965IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000DatumCoversAllTheMajorIslandsOfVanuatuInTwoDifferentAdjustmentBlocksButPracticalUsageIsAsGivenInTheAreaOfUse")]
		[EnumMember(Value = "Santo (DOS) 1965")] 
		SantoDos1965 = 93,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1995SuitableForUseInPortugalEasternAzoresOnshoreSaoMiguelSantaMariaFormigasAzoresOrientalIslands1995ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAzoresOrientalIslands1995OriginIsFundamentalPointForteDeSoBrasOriginAndOrientationConstrainedToThoseOfThe1940AdjustmentAzoresOrientalIslands1995IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoECadastralLisbonHttpWwwIgeoPtClassicalAndGpsObservationsReplaces1940AdjustmentDatumCode6184")]
		[EnumMember(Value = "Sao Braz")] 
		SaoBraz = 94,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1943SuitableForUseInFalklandIslandsMalvinasOnshoreSapperHill1943ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianSapperHill1943IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Sapper Hill 1943")] 
		SapperHill1943 = 95,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInNamibiaOnshoreAndOffshoreSchwarzeckReferencesTheBesselNamibiaGlmEllipsoidAndTheGreenwichPrimeMeridianSchwarzeckOriginIsFundamentalPointSchwarzeckLatitude224535820SLongitude184034549EOfGreenwichFixedDuringGermanSouthWestAfricaBritishBechuanalandBoundarySurveyOf18981903SchwarzeckIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromPrivateCommunicationDirectorateOfSurveysAndLandInformationCapeTown")]
		[EnumMember(Value = "Schwarzeck")] 
		Schwarzeck = 96,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInPortugalSelvagensIslandsMadeiraProvinceOnshoreSelvagemGrandeReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianSelvagemGrandeIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoECadastralLisbonHttpWwwIgeoPt")]
		[EnumMember(Value = "Selvagem Grande 1938")] 
		SelvagemGrande1938 = 97,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1969SuitableForUseInBrazilOnshoreAndOffshoreInRestOfSouthAmericaOnshoreNorthOfApproximately45sAndTierraDelFuegoSouthAmericanDatum1969ReferencesTheGrs1967ModifiedEllipsoidAndTheGreenwichPrimeMeridianSouthAmericanDatum1969OriginIsFundamentalPointChuaGeodeticLatitude1945416527SGeodeticLongitude4806040639WOfGreenwichAstronomicCoordinatesLatitude19454134S005Longitude48060780W008SouthAmericanDatum1969IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromDma1974Sad69UsesGrs1967EllipsoidButWith1FToExactly2DecimalPlacesInBrazilOnlyReplacedBySad6996DatumCode1075")]
		[EnumMember(Value = "South American 1969")] 
		SouthAmerican1969 = 98,

		[System.ComponentModel.Description("SouthAsiaDatum")]
		[EnumMember(Value = "South Asia")] 
		SouthAsia = 99,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1925SuitableForUseInMadagascarOnshoreAndNearshoreTananarive1925ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianTananarive1925OriginIsFundamentalPointTananariveObservatoryLatitude18550210SLongitude47330675EOfGreenwichTananarive1925IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromIgnParis")]
		[EnumMember(Value = "Tananarive Observatory 1925")] 
		TananariveObservatory1925 = 100,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1948SuitableForUseInBruneiOnshoreAndOffshoreMalaysiaEastMalaysiaSabahSarawakOnshoreAndOffshoreTimbalai1948ReferencesTheEverest18301967DefinitionEllipsoidAndTheGreenwichPrimeMeridianTimbalai1948OriginIsFundamentalPointStationP85AtTimbalaiLatitude5173548NLongitude1151056409EOfGreenwichTimbalai1948IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromDefenceGeographicCentreIn1968TheOriginalAdjustmentWasDensifiedInSarawakAndExtendedToSabah")]
		[EnumMember(Value = "Timbalai 1948")] 
		Timbalai1948 = 101,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1918SuitableForUseInJapanOnshoreNorthKoreaOnshoreSouthKoreaOnshoreTokyoReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianTokyoOriginIsFundamentalPointNikonKeidoGentenLatitude3539175148NLongitude13944405020EOfGreenwichLongitudeDerivedIn1918TokyoIsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromGeographicSurveyInstituteJapanBulletin40March1994AlsoHttpVldbGsiGoJpSokuchiDatumTokyodatumHtmlInJapanReplacesTokyo1892Code1048AndReplacedByJapaneseGeodeticDatum2000Code6611InKoreaUsedOnlyForGeodeticApplicationsBeforeBeingReplacedByKorean1985Code6162")]
		[EnumMember(Value = "Tokyo")] 
		Tokyo = 102,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1968SuitableForUseInStHelenaAscensionAndTristanDaCunhaTristanDaCunhaIslandGroupIncludingTristanInaccessibleNightingaleMiddleAndStoltenhoffIslandsTristan1968ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianTristan1968IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Tristan Astro 1968")] 
		TristanAstro1968 = 103,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1912SuitableForUseInFijiVitiLevuIslandVitiLevu1912ReferencesTheClarke1880InternationalFootEllipsoidAndTheGreenwichPrimeMeridianVitiLevu1912LatitudeOriginWasObtainedAstronomicallyAtStationMonavatu175328285SLongitudeOriginWasObtainedAstronomicallyAtStationSuva1782535835EVitiLevu1912IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromCliffordJMugnierInPhotogrammetricEngineeringAndRemoteSensingOctober2000WwwAsprsOrgForTopographicMappingReplacedByFiji1956ForOtherPurposesReplacedByFiji1986")]
		[EnumMember(Value = "Viti Levu 1916")] 
		VitiLevu1916 = 104,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1960SuitableForUseInMarshallIslandsOnshoreWakeAtollOnshoreMarshallIslands1960ReferencesTheHough1960EllipsoidAndTheGreenwichPrimeMeridianMarshallIslands1960IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Wake-Eniwetok 1960")] 
		WakeEniwetok1960 = 105,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1952SuitableForUseInWakeAtollOnshoreWakeIsland1952ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianWakeIsland1952IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Wake Island Astro 1952")] 
		WakeIslandAstro1952 = 106,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInUruguayOnshoreYacareReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianYacareOriginIsFundamentalPointYacareLatitude30355368SLongitude57250130WOfGreenwichYacareIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Yacare")] 
		Yacare = 107,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInSurinameOnshoreAndOffshoreZanderijReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianZanderijIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Zanderij")] 
		Zanderij = 108,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1962SuitableForUseInAmericanSamoaTutuilaAunuUOfuOlesegaAndTaUIslandsAmericanSamoa1962ReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianAmericanSamoa1962OriginIsFundamentalPointBetty13EccentricLatitude14200834SLongitude170425225WOfGreenwichAmericanSamoa1962IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaTr83502RevisionOfJanuary2000OilIndustrySourcesForOriginDescriptionDetails")]
		[EnumMember(Value = "American Samoa 1962")] 
		AmericanSamoa1962 = 109,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInAntarcticaSouthShetlandIslandsDeceptionIslandDeceptionIslandReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianDeceptionIslandIsAGeodeticDatumForMilitaryAndScientificMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Deception Island")] 
		DeceptionIsland = 110,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInCambodiaOnshoreVietnamOnshoreAndOffshoreCuuLongBasinIndian1960ReferencesTheEverest18301937AdjustmentEllipsoidAndTheGreenwichPrimeMeridianIndian1960OriginIsDmaExtensionOverIndochinaOfTheIndian1954NetworkAdjustedToBetterFitLocalGeoidIndian1960IsAGeodeticDatumForTopographicMappingAlsoKnownAsIndianDmaReduced")]
		[EnumMember(Value = "Indian 1960")] 
		Indian1960 = 111,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1974SuitableForUseInIndonesiaOnshoreIndonesianDatum1974ReferencesTheIndonesianNationalSpheroidEllipsoidAndTheGreenwichPrimeMeridianIndonesianDatum1974OriginIsFundamentalPointPadangLatitude05638414SLongitude100228804EOfGreenwichEllipsoidalHeight3190mGravityRelatedHeight140mAboveMeanSeaLevelIndonesianDatum1974IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromBakosurtanal1979PaperByJacobRaisReplacedByDgn95")]
		[EnumMember(Value = "Indonesian 1974")] 
		Indonesian1974 = 112,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1959SuitableForUseInAlgeriaOnshoreAndOffshoreNordSahara1959ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianNordSahara1959OriginIsCoordinatesOfPrimaryNetworkReadjustedOnEd50DatumAndThenTransformedConformallyToClarke1880RgsEllipsoidNordSahara1959IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromLeSystemGeodesiqueNordSaharaIgnParisAdjustmentIncludesMoroccoAndTunisiaButUseOnlyInAlgeriaWithinAlgeriaTheAdjustmentIsNorthOf32nButUseHasBeenExtendedSouthwardsInManyDisconnectedProjectsSomeBasedOnIndependentAstroStationsRatherThanTheGeodeticNetwork")]
		[EnumMember(Value = "North Sahara 1959")] 
		NorthSahara1959 = 113,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1942SuitableForUseInArmeniaAzerbaijanBelarusEstoniaOnshoreGeorgiaOnshoreKazakhstanKyrgyzstanLatviaOnshoreLithuaniaOnshoreMoldovaRussianFederationOnshoreTajikistanTurkmenistanUkraineOnshoreUzbekistanPulkovo1942ReferencesTheKrassowsky1940EllipsoidAndTheGreenwichPrimeMeridianPulkovo1942OriginIsFundamentalPointPulkovoObservatoryLatitude594618550NLongitude301942090EOfGreenwichPulkovo1942IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Pulkovo 1942")] 
		Pulkovo1942 = 114,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInCzechRepublicSlovakiaSystemJednotneTrigonometrickeSiteKatastralniReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianSystemJednotneTrigonometrickeSiteKatastralniOriginIsModificationOfAustrianMgiDatumCode6312SystemJednotneTrigonometrickeSiteKatastralniIsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromResearchInstituteForGeodesyTopographyAndCartographyVugtkPragueSJtskSystemOfTheUnifiedTrigonometricalCadastralNetwork")]
		[EnumMember(Value = "S-JTSK")] 
		SJtsk = 116,

		[System.ComponentModel.Description("Voirol1950Datum")]
		[EnumMember(Value = "Voirol 1950")] 
		Voirol1950 = 117,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1977SuitableForUseInCanadaNewBrunswickNovaScotiaPrinceEdwardIslandAverageTerrestrialSystem1977ReferencesTheAverageTerrestrialSystem1977EllipsoidAndTheGreenwichPrimeMeridianAverageTerrestrialSystem1977IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNewBrunswickGeographicInformationCorporationLandAndWaterInformationStandardsManualInUseFrom1979")]
		[EnumMember(Value = "Average Terrestrial System 1977")] 
		AverageTerrestrialSystem1977 = 118,

		[System.ComponentModel.Description("CompensationGeodesiqueDuQuebec1977")]
		[EnumMember(Value = "Compensation Geodesique du Quebec 1977")] 
		CompensationGeodesiqueDuQuebec1977 = 119,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1966SuitableForUseInFinlandOnshoreKartastokoordinaattijarjestelma1966ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianKartastokoordinaattijarjestelma1966OriginIsAdjustmentWithFundamentalPointSf31BasedOnEd50TransformedToBestFitTheOlderVvjAdjustmentKartastokoordinaattijarjestelma1966IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromNationalLandSurveyOfFinlandHttpWwwMaanmittauslaitosFiAdoptedIn1970")]
		[EnumMember(Value = "Finnish (KKJ)")] 
		FinnishKkj = 120,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1952SuitableForUseInUnitedKingdomUkNorthernIrelandUlsterOnshoreOsni1952ReferencesTheAiry1830EllipsoidAndTheGreenwichPrimeMeridianOsni1952OriginIsPositionFixedToTheCoordinatesFromThe19thCenturyPrincipleTriangulationOfStationDivisScaleAndOrientationControlledByPositionOfPrincipleTriangulationStationsKnocklaydAndTrostanOsni1952IsAGeodeticDatumForGeodeticSurveyAndTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfNorthernIrelandReplacedByGeodeticDatumOf1965Alias1975MappingAdjustmentOrTm75DatumCode6300")]
		[EnumMember(Value = "Ordnance Survey of Ireland")] 
		OrdnanceSurveyOfIreland = 121,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1969SuitableForUseInMalaysiaWestMalaysiaSingaporeKertauRsoReferencesTheEverest1830Rso1969EllipsoidAndTheGreenwichPrimeMeridianKertauRsoIsAGeodeticDatumForMetricationOfRsoGridItWasDefinedByInformationFromDefenceGeographicCentreAdoptsMetricConversionOf0914398MetresPerYardExactlyThisIsATruncationOfTheSears1922Ratio")]
		[EnumMember(Value = "Revised Kertau")] 
		RevisedKertau = 122,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1967SuitableForUseInArabianGulfQatarOffshoreUnitedArabEmiratesUaeAbuDhabiDubaiSharjahAjmanFujairahRasAlKaimahUmmAlQaiwainOnshoreAndOffshoreNahrwan1967ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianNahrwan1967OriginIsFundamentalPointNahrwanSouthBaseLatitude33191087NLongitude44432554EOfGreenwichNahrwan1967IsAGeodeticDatumForTopographicMappingInIraqReplacesNahrwan1934")]
		[EnumMember(Value = "Revised Nahrwan")] 
		RevisedNahrwan = 123,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1987SuitableForUseInGreeceOnshoreGreekGeodeticReferenceSystem1987ReferencesTheGrs1980EllipsoidAndTheGreenwichPrimeMeridianGreekGeodeticReferenceSystem1987OriginIsFundamentalPointDionysosLatitude3804338NLongitude2355510EOfGreenwichGeoidHeight70MGreekGeodeticReferenceSystem1987IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromLPortokalakisPublicPetroleumCorporationOfGreeceReplacedOldGreekDatumOilIndustryWorkBasedOnEd50")]
		[EnumMember(Value = "GGRS 76 (Greece)")] 
		Ggrs76Greece = 124,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1895SuitableForUseInFranceOnshoreMainlandAndCorsicaNouvelleTriangulationFrancaiseReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianNouvelleTriangulationFrancaiseOriginIsFundamentalPointPantheonLatitude485046522NLongitude22048667EOfGreenwichNouvelleTriangulationFrancaiseIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Nouvelle Triangulation de France")] 
		NouvelleTriangulationDeFrance = 125,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1982SuitableForUseInSwedenOnshoreAndOffshoreRiketsKoordinatsystem1990ReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianRiketsKoordinatsystem1990IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromNationalLandSurveyOfSwedenReplacesRt38AdjustmentDatumCode6308")]
		[EnumMember(Value = "RT 90 (Sweden)")] 
		Rt90Sweden = 126,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1994SuitableForUseInAustraliaIncludingLordHoweIslandMacquarieIslandsAshmoreAndCartierIslandsChristmasIslandCocosKeelingIslandsNorfolkIslandAllOnshoreAndOffshoreGeocentricDatumOfAustralia1994ReferencesTheGrs1980EllipsoidAndTheGreenwichPrimeMeridianGeocentricDatumOfAustralia1994OriginIsItrf92AtEpoch19940GeocentricDatumOfAustralia1994IsAGeodeticDatumForTopographicMappingGeodeticSurveyItWasDefinedByInformationFromAustralianSurveyingAndLandInformationGroupInternetWwwPageHttpWwwAusligGovAuGeodesyDatumsGdaHtmSpecsCoincidentWithWgs84ToWithin1Metre")]
		[EnumMember(Value = "Geocentric Datum of Australia")] 
		GeocentricDatumOfAustralia = 127,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1954SuitableForUseInChinaOnshoreBeijing1954ReferencesTheKrassowsky1940EllipsoidAndTheGreenwichPrimeMeridianBeijing1954OriginIsPulkovoTransferredThroughRussianTriangulationBeijing1954IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromChineseScienceBulletin20095427142721ScaleDeterminedThroughThreeBaselinesInNortheastChinaDiscontinuitiesAtBoundariesOfAdjustmentBlocksFrom1982ReplacedByXian1980AndNewBeijing")]
		[EnumMember(Value = "BJZ54 (A954 Beijing Coordinates)")] 
		Bjz54A954BeijingCoordinates = 128,

		[System.ComponentModel.Description("ModifiedBjz54Datum")]
		[EnumMember(Value = "Modified BJZ54")] 
		ModifiedBjz54 = 129,

		[System.ComponentModel.Description("Gdz80Datum")]
		[EnumMember(Value = "GDZ80")] 
		Gdz80 = 130,

		[System.ComponentModel.Description("AnArbitraryDatumDefinedByALocalHarbourAuthorityFromWhichLevelsAndTidalHeightsAreMeasuredByThisAuthority")]
		[EnumMember(Value = "Local Datum")] 
		LocalDatum = 131,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalStatus : int {
		[System.ComponentModel.Description("TheIndicationOfAnElementOfASignalSequenceBeingAPeriodOfLightOrSound")]
		[EnumMember(Value = "Lit/Sound")] 
		LitSound = 1,

		[System.ComponentModel.Description("TheIndicationOfAnElementOfASignalSequenceBeingAPeriodOfEclipseOrSilence")]
		[EnumMember(Value = "Eclipsed/Silent")] 
		EclipsedSilent = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCable : int {
		[System.ComponentModel.Description("ACableThatTransmitsOrDistributesElectricalPower")]
		[EnumMember(Value = "Power Line")] 
		PowerLine = 1,

		[System.ComponentModel.Description("MultipleUnInsulatedCablesUsuallySupportedBySteelLatticeTowersSuchFeaturesAreGenerallyMoreProminentThanNormalPowerLines")]
		[EnumMember(Value = "Transmission Line")] 
		TransmissionLine = 3,

		[System.ComponentModel.Description("ACableThatTransmitsTelephoneSignals")]
		[EnumMember(Value = "Telephone")] 
		Telephone = 4,

		[System.ComponentModel.Description("AnApparatusSystemOrProcessForCommunicationAtADistanceByElectricTransmissionOverWire")]
		[EnumMember(Value = "Telegraph")] 
		Telegraph = 5,

		[System.ComponentModel.Description("AChainOrVeryStrongFibreOrWireRopeUsedToAnchorOrMoorVesselsOrBuoys")]
		[EnumMember(Value = "Mooring Cable")] 
		MooringCable = 6,

		[System.ComponentModel.Description("AVesselForTransportingPassengersVehiclesAndOrGoodsAcrossAStretchOfWaterEspeciallyAsARegularService")]
		[EnumMember(Value = "Ferry")] 
		Ferry = 7,

		[System.ComponentModel.Description("ACableMadeOfGlassOrPlasticFiberDesignedToGuideLightAlongItsLengthFibreOpticCablesAreWidelyUsedInFiberOpticCommunicationWhichPermitsTransmissionOverLongerDistancesAndAtHigherDataRatesThanOtherFormsOfCommunication")]
		[EnumMember(Value = "Fibre Optic Cable")] 
		FibreOpticCable = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfInstallationBuoy : int {
		[System.ComponentModel.Description("IncorporatesALargeBuoyWhichRemainsOnTheSurfaceAtAllTimesAndIsMooredBy4OrMoreAnchorsMooringHawsersAndCargoHosesLeadFromATurntableOnTopOfTheBuoySoThatTheBuoyDoesNotTurnAsTheShipSwingsToWindAndStream")]
		[EnumMember(Value = "Catenary Anchor Leg Mooring")] 
		CatenaryAnchorLegMooring = 1,

		[System.ComponentModel.Description("AMooringStructureUsedByTankersToLoadAndUnloadInPortApproachesOrInOffshoreOilAndGasFieldsTheSizeOfTheStructureCanVaryBetweenALargeMooringBuoyAndAMannedFloatingStructureAlsoKnownAsSinglePointMooringSpm")]
		[EnumMember(Value = "Single Buoy Mooring")] 
		SingleBuoyMooring = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum ShackleType : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "forelock shackles")] 
		ForelockShackles = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "clenching shackles")] 
		ClenchingShackles = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "bolt shackles")] 
		BoltShackles = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "screw pin shackles")] 
		ScrewPinShackles = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "kenter shackle")] 
		KenterShackle = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "quick release link")] 
		QuickReleaseLink = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPile : int {
		[System.ComponentModel.Description("AnElongatedWoodOrMetalPoleEmbeddedInTheSeabedToServeAsAMarkerOrSupport")]
		[EnumMember(Value = "Stake")] 
		Stake = 1,

		[System.ComponentModel.Description("AVerticalPieceOfTimberMetalOrConcreteForcedIntoTheEarthOrSeaBed")]
		[EnumMember(Value = "Post")] 
		Post = 3,

		[System.ComponentModel.Description("ASingleStructureComprising3OrMorePilesHeldTogetherSectionsOfHeavyTimberSteelOrConcreteAndForcedIntoTheEarthOrSeaBed")]
		[EnumMember(Value = "Tripodal")] 
		Tripodal = 4,

		[System.ComponentModel.Description("ANumberOfPilesUsuallyInAStraightLineAndUsuallyConnectedOrBoltedTogether")]
		[EnumMember(Value = "Piling")] 
		Piling = 5,

		[System.ComponentModel.Description("ANumberOfPilesUsuallyInAStraightLineButNotConnectedByStructuralMembers")]
		[EnumMember(Value = "Area of Piles")] 
		AreaOfPiles = 6,

		[System.ComponentModel.Description("AVerticalHollowCylinderOfMetalWoodOrOtherMaterialForcedIntoTheEarthOrSeabed")]
		[EnumMember(Value = "Pipe")] 
		Pipe = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSiloTank : int {
		[System.ComponentModel.Description("ALargeStorageStructureUsedForStoringLooseMaterials")]
		[EnumMember(Value = "Silo in General")] 
		SiloInGeneral = 1,

		[System.ComponentModel.Description("AFixedStructureForStoringLiquids")]
		[EnumMember(Value = "Tank in General")] 
		TankInGeneral = 2,

		[System.ComponentModel.Description("AStorageBuildingForGrainUsuallyATallFrameMetalOrConcreteStructureWithAnEspeciallyCompartmentedInterior")]
		[EnumMember(Value = "Grain Elevator")] 
		GrainElevator = 3,

		[System.ComponentModel.Description("ATowerSupportingAnElevatedStorageTankOfWater")]
		[EnumMember(Value = "Water Tower")] 
		WaterTower = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buildingShape : int {
		[System.ComponentModel.Description("ABuildingHavingManyStoreys")]
		[EnumMember(Value = "High-Rise Building")] 
		HighRiseBuilding = 5,

		[System.ComponentModel.Description("APolyhedronOfWhichOneFaceIsAPolygonOfAnyNumberOfSidesAndTheOtherFacesAreTrianglesWithACommonVertex")]
		[EnumMember(Value = "Pyramid")] 
		Pyramid = 6,

		[System.ComponentModel.Description("ShapedLikeACylinderWhichIsASolidGeometricalFigureGeneratedByStraightLinesFixedInDirectionAndDescribingWithOneOfItsPointsAClosedCurveEspeciallyACircle")]
		[EnumMember(Value = "Cylindrical")] 
		Cylindrical = 7,

		[System.ComponentModel.Description("ShapedLikeASphereWhichIsABodyTheSurfaceOfWhichIsAtAllPointsEquidistantFromTheCentre")]
		[EnumMember(Value = "Spherical")] 
		Spherical = 8,

		[System.ComponentModel.Description("AShapeTheSidesOfWhichAreSixEqualSquaresARegularHexahedron")]
		[EnumMember(Value = "Cubic")] 
		Cubic = 9,
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

		[System.ComponentModel.Description("AColourlessOdourlessTastelessLiquidThatIsACompoundOfHydrogenAndOxygen")]
		[EnumMember(Value = "Water")] 
		Water = 3,

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

		[System.ComponentModel.Description("WaterThatIsSuitableForHumanConsumption")]
		[EnumMember(Value = "Drinking Water")] 
		DrinkingWater = 8,

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

		[System.ComponentModel.Description("ElectricChargeOrCurrent")]
		[EnumMember(Value = "Electricity")] 
		Electricity = 23,

		[System.ComponentModel.Description("TheSolidFormOfWater")]
		[EnumMember(Value = "Ice")] 
		Ice = 24,

		[System.ComponentModel.Description("ParticlesOfLessThan0002mmStiffStickyEarthThatBecomesHardWhenBaked")]
		[EnumMember(Value = "Clay")] 
		Clay = 25,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfOffshorePlatform : int {
		[System.ComponentModel.Description("ATemporaryMobileStructureEitherFixedOrFloatingUsedInTheExplorationStagesOfOilAndGasFields")]
		[EnumMember(Value = "Oil Rig")] 
		OilRig = 1,

		[System.ComponentModel.Description("ATermUsedToIndicateAPermanentOffshoreStructureEquippedToControlTheFlowOfOilOrGasItDoesNotIncludeEntirelySubmarineStructures")]
		[EnumMember(Value = "Production Platform")] 
		ProductionPlatform = 2,

		[System.ComponentModel.Description("APlatformFromWhichOneSSurroundingsOrEventsCanBeObservedNotedOrRecordedSuchAsForScientificStudy")]
		[EnumMember(Value = "Observation/Research Platform")] 
		ObservationResearchPlatform = 3,

		[System.ComponentModel.Description("AMetalLatticeTowerBuoyantAtOneEndAndAttachedAtTheOtherByAUniversalJointToAConcreteFilledBaseOnTheSeaBedThePlatformMayBeFittedWithAHelicopterPlatformEmergencyAccommodationAndHawserHoseRetrieval")]
		[EnumMember(Value = "Articulated Loading Platform")] 
		ArticulatedLoadingPlatform = 4,

		[System.ComponentModel.Description("ARigidFrameOrTubeWithABuoyancyDeviceAtItsUpperEndSecuredAtItsLowerEndToAUniversalJointOnALargeSteelOrConcreteBaseRestingOnTheSeaBedAndAtItsUpperEndToAMooringBuoyByAChainOrWire")]
		[EnumMember(Value = "Single Anchor Leg Mooring")] 
		SingleAnchorLegMooring = 5,

		[System.ComponentModel.Description("APlatformSecuredToTheSeaBedAndSurmountedByATurntableToWhichShipsMoor")]
		[EnumMember(Value = "Mooring Tower")] 
		MooringTower = 6,

		[System.ComponentModel.Description("AManMadeStructureUsuallyBuiltForTheExplorationOrExploitationOfMarineResourcesMarineScientificResearchTidalObservationsEtc")]
		[EnumMember(Value = "Artificial Island")] 
		ArtificialIsland = 7,

		[System.ComponentModel.Description("AnOffshoreOilGasFacilityConsistingOfAMooredTankerBargeByWhichTheProductIsExtractedStoredAndExported")]
		[EnumMember(Value = "Floating Production, Storage and Off-Loading Vessel")] 
		FloatingProductionStorageAndOffLoadingVessel = 8,

		[System.ComponentModel.Description("APlatformUsedPrimarilyForEatingSleepingAndRecreationPurposes")]
		[EnumMember(Value = "Accommodation Platform")] 
		AccommodationPlatform = 9,

		[System.ComponentModel.Description("AFloatingStructureWithControlRoomPowerAndStorageFacilitiesAttachedToTheSeaBedByAFlexiblePipelineAndCables")]
		[EnumMember(Value = "Navigation, Communication and Control Buoy")] 
		NavigationCommunicationAndControlBuoy = 10,

		[System.ComponentModel.Description("AFloatingStructureAnchoredToTheSeabedForStoringOil")]
		[EnumMember(Value = "Floating Oil Tank")] 
		FloatingOilTank = 11,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCardinalMark : int {
		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingNwNeTakenFromThePointOfInterestItShouldBePassedToTheNorthSideOfTheMark")]
		[EnumMember(Value = "North Cardinal Mark")] 
		NorthCardinalMark = 1,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingNeSeTakenFromThePointOfInterestItShouldBePassedToTheEastSideOfTheMark")]
		[EnumMember(Value = "East Cardinal Mark")] 
		EastCardinalMark = 2,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingSeSwTakenFromThePointOfInterestItShouldBePassedToTheSouthSideOfTheMark")]
		[EnumMember(Value = "South Cardinal Mark")] 
		SouthCardinalMark = 3,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingSwNwTakenFromThePointOfInterestItShouldBePassedToTheWestSideOfTheMark")]
		[EnumMember(Value = "West Cardinal Mark")] 
		WestCardinalMark = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightCharacteristic : int {
		[System.ComponentModel.Description("ASignalLightThatShowsContinuouslyInAnyGivenDirectionWithConstantLuminousIntensityAndColour")]
		[EnumMember(Value = "Fixed")] 
		Fixed = 1,

		[System.ComponentModel.Description("ARhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyShorterThanTheTotalDurationOfDarknessAndAllTheAppearancesOfLightAreOfEqualDuration")]
		[EnumMember(Value = "Flashing")] 
		Flashing = 2,

		[System.ComponentModel.Description("ASingleFlashingLightInWhichASingleFlashOfNotLessThanTwoSecondsDurationIsRegularlyRepeated")]
		[EnumMember(Value = "Long-Flashing")] 
		LongFlashing = 3,

		[System.ComponentModel.Description("ARhythmicLightInWhichFlashesAreRepeatedAtARateOfNotLessThan50FlashesPerMinutesButLessThan80FlashesPerMinutesItMayBeContinuousQuickFlashingAQuickFlashingLightInWhichAFlashIsRegularlyRepeatedGroupQuickFlashingAQuickFlashingLightInWhichAGroupOfTwoOrMoreFlashesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Quick-Flashing")] 
		QuickFlashing = 4,

		[System.ComponentModel.Description("ARhythmicLightInWhichFlashesAreRepeatedAtARateOfNotLessThan80FlashesPerMinuteButLessThan160FlashesPerMinuteItMayBeContinuousVeryQuickFlashingAVeryQuickFlashingLightInWhichAFlashIsRegularlyRepeatedGroupVeryQuickFlashingAVeryQuickFlashingLightInWhichAGroupOfTwoOrMoreFlashesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Very Quick-Flashing")] 
		VeryQuickFlashing = 5,

		[System.ComponentModel.Description("ARhythmicLightInWhichFlashesAreRegularlyRepeatedAtARateOfNotLessThan160FlashesPerMinute")]
		[EnumMember(Value = "Continuous Ultra Quick-Flashing")] 
		ContinuousUltraQuickFlashing = 6,

		[System.ComponentModel.Description("ALightWithAllDurationsOfLightAndDarknessEqual")]
		[EnumMember(Value = "Isophased")] 
		Isophased = 7,

		[System.ComponentModel.Description("ARhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyLongerThanTheTotalDurationOfDarknessAndAllTheEclipsesAreOfEqualDurationItMayBeSingleOccultingAnOccultingLightInWhichAnEclipseIsRegularlyRepeatedGroupOccultingAnOccultingLightInWhichAGroupOfTwoOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedCompositeGroupOccultingAnOccultingLightInWhichASequenceOfGroupsOfOneOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedAndTheGroupsCompriseDifferentNumbersOfEclipses")]
		[EnumMember(Value = "Occulting")] 
		Occulting = 8,

		[System.ComponentModel.Description("ARhythmicLightInWhichAppearancesOfLightOfTwoClearlyDifferentDurationsAreGroupedToRepresentACharacterOrCharactersInTheMorseCode")]
		[EnumMember(Value = "Morse")] 
		Morse = 12,

		[System.ComponentModel.Description("ARhythmicLightInWhichAFixedLightIsCombinedWithAFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Fixed and Flash")] 
		FixedAndFlash = 13,

		[System.ComponentModel.Description("ARhythmicLightInWhichAFlashingLightIsCombinedWithALongFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Flash and Long-Flash")] 
		FlashAndLongFlash = 14,

		[System.ComponentModel.Description("ARhythmicLightInWhichAnOccultingLightIsCombinedWithAFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Occulting and Flash")] 
		OccultingAndFlash = 15,

		[System.ComponentModel.Description("ARhythmicLightInWhichAFixedLightIsCombinedWithALongFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Fixed and Long-Flash")] 
		FixedAndLongFlash = 16,

		[System.ComponentModel.Description("AnAlternatingLightInWhichTheTotalDurationOfLightInEachPeriodIsClearlyLongerThanTheTotalDurationOfDarknessAndInWhichTheIntervalsOfDarknessOccultationsAreAllOfEqualDuration")]
		[EnumMember(Value = "Occulting Alternating")] 
		OccultingAlternating = 17,

		[System.ComponentModel.Description("AnAlternatingSingleFlashingLightInWhichAnAppearanceOfLightOfNotLessThanTwoSecondsDurationIsRegularlyRepeated")]
		[EnumMember(Value = "Long-Flash Alternating")] 
		LongFlashAlternating = 18,

		[System.ComponentModel.Description("AnAlternatingRhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyShorterThanTheTotalDurationOfDarknessAndAllTheAppearancesOfLightAreOfEqualDuration")]
		[EnumMember(Value = "Flash Alternating")] 
		FlashAlternating = 19,

		[System.ComponentModel.Description("OccultingLightInWhichTheOccultationsAreCombinedInGroupsEachGroupIncludingTheSameNumberOfOccultationsAndInWhichTheGroupsAreRepeatedAtRegularIntervals")]
		[EnumMember(Value = "Group Alternating")] 
		GroupAlternating = 20,

		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Quick-Flash Plus Long-Flash")] 
		QuickFlashPlusLongFlash = 25,

		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfVeryQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Very Quick-Flash Plus Long-Flash")] 
		VeryQuickFlashPlusLongFlash = 26,

		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfUltraQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Ultra Quick-Flash Plus Long-Flash")] 
		UltraQuickFlashPlusLongFlash = 27,

		[System.ComponentModel.Description("ASignalLightThatShowsInAnyGivenDirectionTwoOrMoreColoursInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Alternating")] 
		Alternating = 28,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fixed and Alternating Flashing")] 
		FixedAndAlternatingFlashing = 29,

		[System.ComponentModel.Description("AnOccultingLightInWhichAGroupOfTwoOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Group-occulting light")] 
		GroupOccultingLight = 30,

		[System.ComponentModel.Description("AnOccultingLightInWhichASequenceOfGroupsOfOneOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedAndTheGroupsCompriseDifferentNumbersOfEclipses")]
		[EnumMember(Value = "Composite group-occulting light")] 
		CompositeGroupOccultingLight = 31,

		[System.ComponentModel.Description("AFlashingLightInWhichAGroupOfFlashesSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Group flashing light")] 
		GroupFlashingLight = 32,

		[System.ComponentModel.Description("ALightSimilarToAGroupFlashingLightExceptThatSuccessiveGroupsInAPeriodHaveDifferentNumbersOfFlashes")]
		[EnumMember(Value = "Composite group-flashing light")] 
		CompositeGroupFlashingLight = 33,

		[System.ComponentModel.Description("AQuickFlashingLightInWhichAGroupOfTwoOrMoreFlashesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Group quick light")] 
		GroupQuickLight = 34,

		[System.ComponentModel.Description("AVeryQuickFlashingLightInWhichAGroupOfTwoOrMoreFlashesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Group very quick light")] 
		GroupVeryQuickLight = 35,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfPowerSource : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "battery")] 
		Battery = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "generator")] 
		Generator = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "solar panel")] 
		SolarPanel = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "electrical service")] 
		ElectricalService = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfSyntheticAISAidtoNavigation : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "predicted")] 
		Predicted = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "monitored")] 
		Monitored = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfPhysicalAISAidToNavigation : int {
		[System.ComponentModel.Description("SimpleTransmissionOfStaticPreProgrammedInformation")]
		[EnumMember(Value = "Physical AIS Type 1")] 
		PhysicalAisType1 = 1,

		[System.ComponentModel.Description("TransmissionOfDynamicRealTimeUpdatedInformationViaConnectedSensors")]
		[EnumMember(Value = "Physical AIS Type 2")] 
		PhysicalAisType2 = 2,

		[System.ComponentModel.Description("FullTwoWayCommunicationTransmissionRemoteControlConfiguration")]
		[EnumMember(Value = "Physical AIS Type 3")] 
		PhysicalAisType3 = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum virtualAISAidToNavigationType : int {
		[System.ComponentModel.Description("IndicatesThatItShouldBePassedToTheNorthSideOfTheAid")]
		[EnumMember(Value = "North Cardinal")] 
		NorthCardinal = 1,

		[System.ComponentModel.Description("IndicatesThatItShouldBePassedToTheEastSideOfTheAid")]
		[EnumMember(Value = "East Cardinal")] 
		EastCardinal = 2,

		[System.ComponentModel.Description("IndicatesThatItShouldBePassedToTheSouthSideOfTheAid")]
		[EnumMember(Value = "South Cardinal")] 
		SouthCardinal = 3,

		[System.ComponentModel.Description("IndicatesThatItShouldBePassedToTheWestSideOfTheAid")]
		[EnumMember(Value = "West Cardinal")] 
		WestCardinal = 4,

		[System.ComponentModel.Description("IndicatesThePortBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyage")]
		[EnumMember(Value = "Port Lateral")] 
		PortLateral = 5,

		[System.ComponentModel.Description("IndicatesTheStarboardBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyage")]
		[EnumMember(Value = "Starboard Lateral")] 
		StarboardLateral = 6,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedPortHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Port")] 
		PreferredChannelToPort = 7,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedStarboardHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Starboard")] 
		PreferredChannelToStarboard = 8,

		[System.ComponentModel.Description("AMarkUsedAloneToIndicateADangerousReefOrShoalTheMarkMayBePassedOnEitherHand")]
		[EnumMember(Value = "Isolated Danger")] 
		IsolatedDanger = 9,

		[System.ComponentModel.Description("IndicatesThatThereIsNavigableWaterAroundTheMark")]
		[EnumMember(Value = "Safe Water")] 
		SafeWater = 10,

		[System.ComponentModel.Description("ASpecialPurposeAidIsPrimarilyUsedToIndicateAnAreaOrFeatureTheNatureOfWhichIsApparentFromReferenceToAChartSailingDirectionsOrNoticeToMariners")]
		[EnumMember(Value = "Special Purpose")] 
		SpecialPurpose = 11,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfARecentlyIdentifiedNewDangerSuchAsAWreck")]
		[EnumMember(Value = "New Danger Marking")] 
		NewDangerMarking = 12,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadarTransponderBeacon : int {
		[System.ComponentModel.Description("ARadarMarkerBeaconWhichContinuouslyTransmitsASignalAppearingAsARadialLineOnARadarScreenTheLineIndicatingTheDirectionOfTheBeaconRamarksAreIntendedPrimarilyForMarineUseTheNameRamarkIsDerivedFromTheWordsRadarMarker")]
		[EnumMember(Value = "Ramark, Radar Beacon Transmitting Continuously")] 
		RamarkRadarBeaconTransmittingContinuously = 1,

		[System.ComponentModel.Description("ARadarBeaconWhichReturnsACodedSignalWhichProvidesIdentificationOfTheBeaconAsWellAsRangeAndBearingTheRangeAndBearingAreIndicatedByTheLocationOfTheFirstCharacterReceivedOnTheRadarScreenTheNameRaconIsDerivedFromTheWordsRadarBeacon")]
		[EnumMember(Value = "Racon, Radar Transponder Beacon")] 
		RaconRadarTransponderBeacon = 2,

		[System.ComponentModel.Description("ARadarBeaconThatMayBeUsedInConjunctionWithAtLeastOneOtherRadarBeaconToIndicateALeadingLine")]
		[EnumMember(Value = "Leading Racon/Radar Transponder Beacon")] 
		LeadingRaconRadarTransponderBeacon = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum topmarkDaymarkShape : int {
		[System.ComponentModel.Description("IsWhereTheVertexPointsUpAConeIsASolidFigureGeneratedByStraightLinesDrawnFromAFixedPointTheVertexToACircleInAPlaneNotContainingTheVertexConesAreCommonlyUsedAsInternationalAssociationOfLighthouseAuthoritiesIalaTopmarksLateral")]
		[EnumMember(Value = "Cone (Point Up)")] 
		ConePointUp = 1,

		[System.ComponentModel.Description("IsWhereTheVertexPointsDownAConeIsASolidFigureGeneratedByStraightLinesDrawnFromAFixedPointTheVertexToACircleInAPlaneNotContainingTheVertexConesAreCommonlyUsedAsInternationalAssociationOfLighthouseAuthoritiesIalaTopmarksLateral")]
		[EnumMember(Value = "Cone (Point Down)")] 
		ConePointDown = 2,

		[System.ComponentModel.Description("ACurvedSurfaceAllPointsOfWhichAreEquidistantFromAFixedPointWithinCalledTheCentre")]
		[EnumMember(Value = "Sphere")] 
		Sphere = 3,

		[System.ComponentModel.Description("TwoSpheresOneAboveTheOtherTwoBlackSpheresAreCommonlyUsedAsAnInternationalAssociationOfLighthouseAuthoritiesIalaTopmarkIsolatedDanger")]
		[EnumMember(Value = "2 Spheres")] 
		twoSpheres = 4,

		[System.ComponentModel.Description("ASolidGeometricalFigureGeneratedByStraightLinesFixedInDirectionAndDescribingWithOneOfPointAClosedCurveEspeciallyACircleInWhichCaseTheFigureIsCircularCylinderItSEndsBeingParallelCirclesCylindersAreCommonlyUsedAsInternationalAssociationOfLighthouseAuthoritiesIalaTopmarksLateral")]
		[EnumMember(Value = "Cylinder")] 
		Cylinder = 5,

		[System.ComponentModel.Description("UsuallyOfRectangularShapeMadeFromTimberOrMetalAndUsedToProvideAContrastWithTheNaturalBackgroundOfADaymarkTheActualDaymarkIsOftenPaintedOnToThisBoard")]
		[EnumMember(Value = "Board")] 
		Board = 6,

		[System.ComponentModel.Description("HavingAShapeOrACrossSectionLikeTheCapitalLetterXAnXShapeAsAnInternationalAssociationOfLighthouseAuthoritiesIalaTopmarkShouldBe3DimensionalInShapeItIsMadeOfAtLeastThreeCrossedBars")]
		[EnumMember(Value = "X-Shaped")] 
		XShaped = 7,

		[System.ComponentModel.Description("ACrossWithOneVerticalMemberAndOneHorizontalMemberThatIsSimilarInShapeToTheCharacter")]
		[EnumMember(Value = "Upright Cross")] 
		UprightCross = 8,

		[System.ComponentModel.Description("ACubeStandingOnOneOfItsVertexesACubeIsASolidContainedBySixEqualSquaresARegularHexahedron")]
		[EnumMember(Value = "Cube (Point Up)")] 
		CubePointUp = 9,

		[System.ComponentModel.Description("twoConesOneAboveTheOtherWithTheirVerticesTogetherInTheCentre")]
		[EnumMember(Value = "2 Cones (Point to Point)")] 
		twoConesPointToPoint = 10,

		[System.ComponentModel.Description("twoConesOneAboveTheOtherWithTheirBasesTogetherInTheCentreAndTheirVerticesPointingUpAndDown")]
		[EnumMember(Value = "2 Cones (Base to Base)")] 
		twoConesBaseToBase = 11,

		[System.ComponentModel.Description("APlaneFigureHavingFourEqualSidesAndEqualOppositeAnglesTwoAcuteAndTwoObtuseAnObliqueEquilateralParallelogram")]
		[EnumMember(Value = "Rhombus")] 
		Rhombus = 12,

		[System.ComponentModel.Description("twoConesOneAboveTheOtherWithTheirVerticesPointingUp")]
		[EnumMember(Value = "2 Cones (Points Upward)")] 
		twoConesPointsUpward = 13,

		[System.ComponentModel.Description("twoConesOneAboveTheOtherWithTheirVerticesPointingDown")]
		[EnumMember(Value = "2 Cones (Points Downward)")] 
		twoConesPointsDownward = 14,

		[System.ComponentModel.Description("BesomABundleOfRodsOrTwigsPerchAStaffPlacedOnTopOfABuoyRockOrShoalAsAMarkForNavigationABesomPointUpIsWhereTheThickerUntiedEndOfTheBesomIsAtTheBottom")]
		[EnumMember(Value = "Besom (Point Up)")] 
		BesomPointUp = 15,

		[System.ComponentModel.Description("BesomABundleOfRodsOrTwigsPerchAStaffPlacedOnTopOfABuoyRockOrShoalAsAMarkForNavigationABesomPointDownIsWhereTheThinnerTiedEndOfTheBesomIsAtTheBottom")]
		[EnumMember(Value = "Besom (Point Down)")] 
		BesomPointDown = 16,

		[System.ComponentModel.Description("AFlagMountedOnAShortPole")]
		[EnumMember(Value = "Flag")] 
		Flag = 17,

		[System.ComponentModel.Description("ASphereLocatedAboveARhombus")]
		[EnumMember(Value = "Sphere Over a Rhombus")] 
		SphereOverARhombus = 18,

		[System.ComponentModel.Description("APlaneFigureWithFourRightAnglesAndFourEqualStraightSides")]
		[EnumMember(Value = "Square")] 
		Square = 19,

		[System.ComponentModel.Description("WhereTheTwoLongerOppositeSidesAreStandingHorizontallyARectangleIsAPlaneFigureWithFourRightAnglesAndFourStraightSidesOppositeSidesBeingParallelAndEqualInLength")]
		[EnumMember(Value = "Rectangle (Horizontal)")] 
		RectangleHorizontal = 20,

		[System.ComponentModel.Description("WhereTheTwoLongerOppositeSidesAreStandingVerticallyARectangleIsAPlaneFigureWithFourRightAnglesAndFourStraightSidesOppositeSidesBeingParallelAndEqualInLength")]
		[EnumMember(Value = "Rectangle (Vertical)")] 
		RectangleVertical = 21,

		[System.ComponentModel.Description("AQuadrilateralHavingOnePairOfOppositeSidesParallelAndWhichStandsOnItsLongerParallelSide")]
		[EnumMember(Value = "Trapezium (Up)")] 
		TrapeziumUp = 22,

		[System.ComponentModel.Description("AQuadrilateralHavingOnePairOfOppositeSidesParallelAndWhichStandsOnItsShorterParallelSide")]
		[EnumMember(Value = "Trapezium (Down)")] 
		TrapeziumDown = 23,

		[System.ComponentModel.Description("AFigureHavingThreeAnglesAndThreeSidesAndWhichHasAVertexAtTheTop")]
		[EnumMember(Value = "Triangle (Point Up)")] 
		TrianglePointUp = 24,

		[System.ComponentModel.Description("AFigureHavingThreeAnglesAndThreeSidesAndWhichHasASideAtTheTop")]
		[EnumMember(Value = "Triangle (Point Down)")] 
		TrianglePointDown = 25,

		[System.ComponentModel.Description("APerfectlyRoundPlaneFigureWhoseCircumferenceIsEverywhereEquidistantFromItsCentre")]
		[EnumMember(Value = "Circle")] 
		Circle = 26,

		[System.ComponentModel.Description("TwoUprightCrossesGenerallyVerticallyDisposedOneAboveTheOther")]
		[EnumMember(Value = "Two Upright Crosses (One Over the Other)")] 
		TwoUprightCrossesOneOverTheOther = 27,

		[System.ComponentModel.Description("HavingAShapeLikeTheCapitalLetterT")]
		[EnumMember(Value = "T-Shape")] 
		TShape = 28,

		[System.ComponentModel.Description("ATriangleVertexUppermostLocatedAboveACircle")]
		[EnumMember(Value = "Triangle Pointing Up Over a Circle")] 
		TrianglePointingUpOverACircle = 29,

		[System.ComponentModel.Description("AnUprightCrossLocatedAboveACircle")]
		[EnumMember(Value = "Upright Cross Over a Circle")] 
		UprightCrossOverACircle = 30,

		[System.ComponentModel.Description("ARhombusLocatedAboveACircle")]
		[EnumMember(Value = "Rhombus Over a Circle")] 
		RhombusOverACircle = 31,

		[System.ComponentModel.Description("ACircleLocatedOverATriangleVertexUppermost")]
		[EnumMember(Value = "Circle Over a Triangle Pointing Up")] 
		CircleOverATrianglePointingUp = 32,

		[System.ComponentModel.Description("AnUncommonAndOrNonStandardizedShapeAsTextuallyDescribedUsingAnAssociatedAttribute")]
		[EnumMember(Value = "Other Shape (See Shape Information)")] 
		OtherShapeSeeShapeInformation = 33,

		[System.ComponentModel.Description("HavingTheFormOfOrConsistingOfATube")]
		[EnumMember(Value = "Tubular")] 
		Tubular = 34,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSpecialPurposeMark : int {
		[System.ComponentModel.Description("AMarkUsedToIndicateAFiringDangerAreaUsuallyAtSea")]
		[EnumMember(Value = "Firing Danger Mark")] 
		FiringDangerMark = 1,

		[System.ComponentModel.Description("AnyObjectTowardWhichSomethingIsDirectedTheDistinctiveMarkingOrInstrumentationOfAGroundPointToAidItsIdentificationOnAPhotograph")]
		[EnumMember(Value = "Target Mark")] 
		TargetMark = 2,

		[System.ComponentModel.Description("AMarkMarkingThePositionOfAShipWhichIsUsedAsATargetDuringSomeMilitaryExercise")]
		[EnumMember(Value = "Marker Ship Mark")] 
		MarkerShipMark = 3,

		[System.ComponentModel.Description("AMarkUsedToIndicateADegaussingRange")]
		[EnumMember(Value = "Degaussing Range Mark")] 
		DegaussingRangeMark = 4,

		[System.ComponentModel.Description("AMarkOfRelevanceToBarges")]
		[EnumMember(Value = "Barge Mark")] 
		BargeMark = 5,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfSubmarineCablesOrThePointAtWhichTheyRunOnToTheLand")]
		[EnumMember(Value = "Cable Mark")] 
		CableMark = 6,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheLimitOfASpoilGround")]
		[EnumMember(Value = "Spoil Ground Mark")] 
		SpoilGroundMark = 7,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfAnOutfallOrThePointAtWhichItLeavesTheLand")]
		[EnumMember(Value = "Outfall Mark")] 
		OutfallMark = 8,

		[System.ComponentModel.Description("OceanDataAcquisitionSystem")]
		[EnumMember(Value = "ODAS")] 
		Odas = 9,

		[System.ComponentModel.Description("AMarkUsedToRecordDataForScientificPurposes")]
		[EnumMember(Value = "Recording Mark")] 
		RecordingMark = 10,

		[System.ComponentModel.Description("AMarkUsedToIndicateASeaplaneAnchorage")]
		[EnumMember(Value = "Seaplane Anchorage Mark")] 
		SeaplaneAnchorageMark = 11,

		[System.ComponentModel.Description("AMarkUsedToIndicateARecreationZone")]
		[EnumMember(Value = "Recreation Zone Mark")] 
		RecreationZoneMark = 12,

		[System.ComponentModel.Description("APrivatelyMaintainedMark")]
		[EnumMember(Value = "Private Mark")] 
		PrivateMark = 13,

		[System.ComponentModel.Description("AMarkIndicatingAMooringOrMoorings")]
		[EnumMember(Value = "Mooring Mark")] 
		MooringMark = 14,

		[System.ComponentModel.Description("ALargeBuoyDesignedToTakeThePlaceOfALightshipWhereConstructionOfAnOffshoreLightStationIsNotFeasible")]
		[EnumMember(Value = "LANBY")] 
		Lanby = 15,

		[System.ComponentModel.Description("AidsToNavigationOrOtherIndicatorsSoLocatedAsToIndicateThePathToBeFollowedLeadingMarksIdentifyALeadingLineWhenTheyAreInTransit")]
		[EnumMember(Value = "Leading Mark")] 
		LeadingMark = 16,

		[System.ComponentModel.Description("AMarkFormingPartOfATransitIndicatingOneEndOfAMeasuredDistance")]
		[EnumMember(Value = "Measured Distance Mark")] 
		MeasuredDistanceMark = 17,

		[System.ComponentModel.Description("ANoticeBoardOrSignIndicatingInformationToTheMariner")]
		[EnumMember(Value = "Notice Mark")] 
		NoticeMark = 18,

		[System.ComponentModel.Description("AMarkIndicatingATrafficSeparationScheme")]
		[EnumMember(Value = "TSS Mark")] 
		TssMark = 19,

		[System.ComponentModel.Description("AMarkIndicatingAnAnchoringProhibitedArea")]
		[EnumMember(Value = "Anchoring Prohibited Mark")] 
		AnchoringProhibitedMark = 20,

		[System.ComponentModel.Description("AMarkIndicatingThatBerthingIsProhibited")]
		[EnumMember(Value = "Berthing Prohibited Mark")] 
		BerthingProhibitedMark = 21,

		[System.ComponentModel.Description("AMarkIndicatingThatOvertakingIsProhibited")]
		[EnumMember(Value = "Overtaking Prohibited Mark")] 
		OvertakingProhibitedMark = 22,

		[System.ComponentModel.Description("AMarkIndicatingAOneWayRoute")]
		[EnumMember(Value = "Two-Way Traffic Prohibited Mark")] 
		TwoWayTrafficProhibitedMark = 23,

		[System.ComponentModel.Description("AMarkIndicatingThatVesselsMustNotGenerateExcessiveWake")]
		[EnumMember(Value = "Reduced Wake Mark")] 
		ReducedWakeMark = 24,

		[System.ComponentModel.Description("AMarkIndicatingThatASpeedLimitApplies")]
		[EnumMember(Value = "Speed Limit Mark")] 
		SpeedLimitMark = 25,

		[System.ComponentModel.Description("AMarkIndicatingThePlaceWhereTheBowOfAShipMustStopWhenTrafficLightsShowRed")]
		[EnumMember(Value = "Stop Mark")] 
		StopMark = 26,

		[System.ComponentModel.Description("AMarkIndicatingThatSpecialCautionMustBeExercisedInTheVicinityOfTheMark")]
		[EnumMember(Value = "General Warning Mark")] 
		GeneralWarningMark = 27,

		[System.ComponentModel.Description("AMarkIndicatingThatAShipShouldSoundItsSirenOrHorn")]
		[EnumMember(Value = "Sound Ship's Siren Mark")] 
		SoundShipSSirenMark = 28,

		[System.ComponentModel.Description("AMarkIndicatingTheMinimumVerticalSpaceAvailableForPassage")]
		[EnumMember(Value = "Restricted Vertical Clearance Mark")] 
		RestrictedVerticalClearanceMark = 29,

		[System.ComponentModel.Description("AMarkIndicatingTheMaximumDraughtOfVesselPermitted")]
		[EnumMember(Value = "Maximum Vessel's Draught Mark")] 
		MaximumVesselSDraughtMark = 30,

		[System.ComponentModel.Description("AMarkIndicatingTheMinimumHorizontalSpaceAvailableForPassage")]
		[EnumMember(Value = "Restricted Horizontal Clearance Mark")] 
		RestrictedHorizontalClearanceMark = 31,

		[System.ComponentModel.Description("AMarkWarningOfStrongCurrents")]
		[EnumMember(Value = "Strong Current Warning Mark")] 
		StrongCurrentWarningMark = 32,

		[System.ComponentModel.Description("AMarkIndicatingThatBerthingIsAllowed")]
		[EnumMember(Value = "Berthing Permitted Mark")] 
		BerthingPermittedMark = 33,

		[System.ComponentModel.Description("AMarkIndicatingAnOverheadPowerCable")]
		[EnumMember(Value = "Overhead Power Cable Mark")] 
		OverheadPowerCableMark = 34,

		[System.ComponentModel.Description("AMarkIndicatingTheGradientOfTheSlopeOfADredgeChannelEdge")]
		[EnumMember(Value = "Channel Edge Gradient Mark")] 
		ChannelEdgeGradientMark = 35,

		[System.ComponentModel.Description("AMarkIndicatingThePresenceOfATelephone")]
		[EnumMember(Value = "Telephone Mark")] 
		TelephoneMark = 36,

		[System.ComponentModel.Description("AMarkIndicatingThatAFerryRouteCrossesTheShipRouteOftenUsedWithASoundShipSSirenMark")]
		[EnumMember(Value = "Ferry Crossing Mark")] 
		FerryCrossingMark = 37,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfSubmarinePipelinesOrThePointAtWhichTheyRunOnToTheLand")]
		[EnumMember(Value = "Pipeline Mark")] 
		PipelineMark = 39,

		[System.ComponentModel.Description("AMarkIndicatingAnAnchorageArea")]
		[EnumMember(Value = "Anchorage Mark")] 
		AnchorageMark = 40,

		[System.ComponentModel.Description("AMarkUsedToIndicateAClearingLine")]
		[EnumMember(Value = "Clearing Mark")] 
		ClearingMark = 41,

		[System.ComponentModel.Description("AMarkIndicatingTheLocationAtWhichARestrictionOrRequirementExists")]
		[EnumMember(Value = "Control Mark")] 
		ControlMark = 42,

		[System.ComponentModel.Description("AMarkIndicatingThatDivingMayTakePlaceInTheVicinity")]
		[EnumMember(Value = "Diving Mark")] 
		DivingMark = 43,

		[System.ComponentModel.Description("AMarkProvidingOrIndicatingAPlaceOfSafety")]
		[EnumMember(Value = "Refuge Beacon")] 
		RefugeBeacon = 44,

		[System.ComponentModel.Description("AMarkIndicatingAFoulGround")]
		[EnumMember(Value = "Foul Ground Mark")] 
		FoulGroundMark = 45,

		[System.ComponentModel.Description("AMarkInstalledForUseByYachtsmen")]
		[EnumMember(Value = "Yachting Mark")] 
		YachtingMark = 46,

		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereHelicoptersMayLand")]
		[EnumMember(Value = "Heliport Mark")] 
		HeliportMark = 47,

		[System.ComponentModel.Description("AMarkIndicatingALocationAtWhichAGnssPositionHasBeenAccuratelyDetermined")]
		[EnumMember(Value = "GNSS Mark")] 
		GnssMark = 48,

		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereSeaPlanesLand")]
		[EnumMember(Value = "Seaplane Landing Mark")] 
		SeaplaneLandingMark = 49,

		[System.ComponentModel.Description("AMarkIndicatingThatEntryIsProhibited")]
		[EnumMember(Value = "Entry Prohibited Mark")] 
		EntryProhibitedMark = 50,

		[System.ComponentModel.Description("AMarkIndicatingThatWorkGenerallyConstructionIsInProgress")]
		[EnumMember(Value = "Work in Progress Mark")] 
		WorkInProgressMark = 51,

		[System.ComponentModel.Description("AMarkWhoseDetailedCharacteristicsAreUnknown")]
		[EnumMember(Value = "Mark With Unknown Purpose")] 
		MarkWithUnknownPurpose = 52,

		[System.ComponentModel.Description("AMarkIndicatingABoreholeThatProducesOrIsCapableOfProducingOilOrNaturalGas")]
		[EnumMember(Value = "Wellhead Mark")] 
		WellheadMark = 53,

		[System.ComponentModel.Description("AMarkIndicatingThePointAtWhichAChannelDividesSeparatelyIntoTwoChannels")]
		[EnumMember(Value = "Channel Separation Mark")] 
		ChannelSeparationMark = 54,

		[System.ComponentModel.Description("AMarkIndicatingTheExistenceOfAFishMusselOysterOrPearlFarmCulture")]
		[EnumMember(Value = "Marine Farm Mark")] 
		MarineFarmMark = 55,

		[System.ComponentModel.Description("AMarkIndicatingTheExistenceOrTheExtentOfAnArtificialReef")]
		[EnumMember(Value = "Artificial Reef Mark")] 
		ArtificialReefMark = 56,

		[System.ComponentModel.Description("AMarkUsedYearRoundThatMayBeSubmergedWhenIcePassesThroughTheArea")]
		[EnumMember(Value = "Ice Mark")] 
		IceMark = 57,

		[System.ComponentModel.Description("AMarkUsedToDefineTheBoundaryOfANatureReserve")]
		[EnumMember(Value = "Nature Reserve Mark")] 
		NatureReserveMark = 58,

		[System.ComponentModel.Description("AFishAggregatingOrAggregationDeviceFadIsAManMadeObjectUsedToAttractOceanGoingPelagicFishSuchAsMarlinTunaAndMahiMahiDolphinFishTheyUsuallyConsistOfBuoysOrFloatsTetheredToTheOceanFloorWithConcreteBlocks")]
		[EnumMember(Value = "Fish Aggregating Device")] 
		FishAggregatingDevice = 59,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfAWreck")]
		[EnumMember(Value = "Wreck Mark")] 
		WreckMark = 60,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfACustomsCheckpoint")]
		[EnumMember(Value = "Customs Mark")] 
		CustomsMark = 61,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfACauseway")]
		[EnumMember(Value = "Causeway Mark")] 
		CausewayMark = 62,

		[System.ComponentModel.Description("ASurfaceFollowingBuoyUsedToMeasureWaveActivity")]
		[EnumMember(Value = "Wave Recorder")] 
		WaveRecorder = 63,

		[System.ComponentModel.Description("AMarkIndicatingAJetskiProhibitedArea")]
		[EnumMember(Value = "Jetski Prohibited")] 
		JetskiProhibited = 64,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioStation : int {
		[System.ComponentModel.Description("ARadioStationWhichNeedNotNecessarilyBeMannedTheEmissionsOfWhichRadiatedAroundTheHorizonEnableItsBearingToBeDeterminedByMeansOfTheRadioDirectionFinderOfAShip")]
		[EnumMember(Value = "Circular (Non-Directional) Marine or Aero-Marine Radiobeacon")] 
		CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,

		[System.ComponentModel.Description("ASpecialTypeOfRadiobeaconStationTheEmissionsOfWhichAreIntendedToProvideADefiniteTrackForGuidance")]
		[EnumMember(Value = "Directional Radiobeacon")] 
		DirectionalRadiobeacon = 2,

		[System.ComponentModel.Description("ASpecialTypeOfRadiobeaconStationEmittingABeamOfWavesToWhichAUniformTurningMovementIsGivenTheBearingOfTheStationBeingDeterminedByMeansOfAnOrdinaryListeningReceiverAndAStopWatchAlsoReferredToAsARotatingLoopRadiobeacon")]
		[EnumMember(Value = "Rotating Pattern Radiobeacon")] 
		RotatingPatternRadiobeacon = 3,

		[System.ComponentModel.Description("ATypeOfLongRangePositionFixingBeacon")]
		[EnumMember(Value = "Consol Beacon")] 
		ConsolBeacon = 4,

		[System.ComponentModel.Description("ARadioStationIntendedToDetermineOnlyTheDirectionOfOtherStationsByMeansOfTransmissionFromTheLatter")]
		[EnumMember(Value = "Radio Direction-Finding Station")] 
		RadioDirectionFindingStation = 5,

		[System.ComponentModel.Description("ARadioStationWhichIsPreparedToProvideQtgServiceThatIsToSayToTransmitUponRequestFromAShipARadioSignalTheBearingOfWhichCanBeTakenByThatShip")]
		[EnumMember(Value = "Coast Radio Station Providing QTG Service")] 
		CoastRadioStationProvidingQtgService = 6,

		[System.ComponentModel.Description("ARadioBeaconDesignedForAeronauticalUse")]
		[EnumMember(Value = "Aeronautical Radiobeacon")] 
		AeronauticalRadiobeacon = 7,

		[System.ComponentModel.Description("TheDeccaNavigatorSystemIsAHighAccuracyShortToMediumRangeRadioNavigationalAidIntendedForCoastalAndLandfallNavigation")]
		[EnumMember(Value = "Decca")] 
		Decca = 8,

		[System.ComponentModel.Description("ALowFrequencyElectronicPositionFixingSystemUsingPulsedTransmissionsAt100Khz")]
		[EnumMember(Value = "Loran C")] 
		LoranC = 9,

		[System.ComponentModel.Description("ARadiobeaconTransmittingDgpsCorrectionSignals")]
		[EnumMember(Value = "Differential GNSS")] 
		DifferentialGnss = 10,

		[System.ComponentModel.Description("AnElectronicPositionFixingSystemUsedMainlyByAircraft")]
		[EnumMember(Value = "Toran")] 
		Toran = 11,

		[System.ComponentModel.Description("ALongRangeRadioNavigationalAidWhichOperatesWithinTheVlfFrequencyBandTheSystemComprisesEightLandBasedStations")]
		[EnumMember(Value = "Omega")] 
		Omega = 12,

		[System.ComponentModel.Description("ARangingPositionFixingSystemOperatingAt420450MhzOverARangeOfUpTo400Km")]
		[EnumMember(Value = "Syledis")] 
		Syledis = 13,

		[System.ComponentModel.Description("ChaikaIsALowFrequencyElectronicPositionFixingSystemUsingPulsedTransmissionsAt100Khz")]
		[EnumMember(Value = "Chaika")] 
		Chaika = 14,

		[System.ComponentModel.Description("TheEquipmentNeededAtOneStationToCarryOnTwoWayVoiceCommunicationByRadioWavesOnly")]
		[EnumMember(Value = "Radio Telephone Station")] 
		RadioTelephoneStation = 19,

		[System.ComponentModel.Description("AnOnshoreAisUnitThatMonitorsTrafficInTheWaterways")]
		[EnumMember(Value = "AIS Base Station")] 
		AisBaseStation = 20,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFogSignal : int {
		[System.ComponentModel.Description("ASignalProducedByTheFiringOfExplosiveCharges")]
		[EnumMember(Value = "Explosive")] 
		Explosive = 1,

		[System.ComponentModel.Description("ADiaphoneUsesCompressedAirAndGenerallyEmitsAPowerfulLowPitchedSoundWhichOftenConcludesWithABriefSoundOfSuddenlyLoweredPitchTermedTheGrunt")]
		[EnumMember(Value = "Diaphone")] 
		Diaphone = 2,

		[System.ComponentModel.Description("ATypeOfFogSignalApparatusWhichProducesSoundByVirtueOfThePassageOfAirThroughSlotsOrHolesInARevolvingDisk")]
		[EnumMember(Value = "Siren")] 
		Siren = 3,

		[System.ComponentModel.Description("AHornHavingADiaphragmOscillatedByElectricity")]
		[EnumMember(Value = "Nautophone")] 
		Nautophone = 4,

		[System.ComponentModel.Description("oneAReedUsesCompressedAirAndEmitsAWeakHighPitchedSound2AnyOfVariousWaterOrMarshPlantsWithAFirmStemConciseOxfordEnglishDictionary")]
		[EnumMember(Value = "Reed")] 
		Reed = 5,

		[System.ComponentModel.Description("ADiaphragmHornWhichOperatesUnderTheInfluenceOfCompressedAirOrSteam")]
		[EnumMember(Value = "Tyfon")] 
		Tyfon = 6,

		[System.ComponentModel.Description("ARingingSoundWithAShortRange")]
		[EnumMember(Value = "Bell")] 
		Bell = 7,

		[System.ComponentModel.Description("ADistinctiveSoundMadeByAJetOfAirPassingThroughAnOrificeTheApparatusMayBeOperatedAutomaticallyByHandOrByAirBeingForcedUpATubeByWavesActingOnABuoy")]
		[EnumMember(Value = "Whistle")] 
		Whistle = 8,

		[System.ComponentModel.Description("ASoundProducedByVibrationOfADiscWhenStruck")]
		[EnumMember(Value = "Gong")] 
		Gong = 9,

		[System.ComponentModel.Description("AHornUsesCompressedAirOrElectricityToVibrateADiaphragmAndExistsInAVarietyOfTypesWhichDifferGreatlyInTheirSoundAndPower")]
		[EnumMember(Value = "Horn")] 
		Horn = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightVisibility : int {
		[System.ComponentModel.Description("NonMarineLightsWithAHigherPowerThanMarineLightsAndVisibleFromWellOffShoreOftenAeroLights")]
		[EnumMember(Value = "High Intensity")] 
		HighIntensity = 1,

		[System.ComponentModel.Description("NonMarineLightsWithLowerPowerThanMarineLights")]
		[EnumMember(Value = "Low Intensity")] 
		LowIntensity = 2,

		[System.ComponentModel.Description("ADecreaseInTheApparentIntensityOfALightWhichMayOccurInTheCaseOfPartialObstructions")]
		[EnumMember(Value = "Faint")] 
		Faint = 3,

		[System.ComponentModel.Description("ALightInASectorIsIntensifiedThatIsHasLongerRangeThanOtherSectors")]
		[EnumMember(Value = "Intensified")] 
		Intensified = 4,

		[System.ComponentModel.Description("ALightInASectorIsUnintensifiedThatIsHasShorterRangeThanOtherSectors")]
		[EnumMember(Value = "Unintensified")] 
		Unintensified = 5,

		[System.ComponentModel.Description("ALightSectorIsDeliberatelyReducedInIntensityForExampleToReduceItsEffectOnABuiltUpArea")]
		[EnumMember(Value = "Visibility Deliberately Restricted")] 
		VisibilityDeliberatelyRestricted = 6,

		[System.ComponentModel.Description("SaidOfTheArcOfALightSectorDesignatedByItsLimitingBearingsInWhichTheLightIsNotVisibleFromSeaward")]
		[EnumMember(Value = "Obscured")] 
		Obscured = 7,

		[System.ComponentModel.Description("ThisValueSpecifiesThatPartsOfTheSectorAreObscured")]
		[EnumMember(Value = "Partially Obscured")] 
		PartiallyObscured = 8,

		[System.ComponentModel.Description("LightsThatMustInLineToBeVisible")]
		[EnumMember(Value = "Visible in Line of Range")] 
		VisibleInLineOfRange = 9,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalGeneration : int {
		[System.ComponentModel.Description("SignalGenerationIsInitiatedByASelfRegulatingMechanismSuchAsATimerOrLightSensor")]
		[EnumMember(Value = "Automatically")] 
		Automatically = 1,

		[System.ComponentModel.Description("TheSignalIsGeneratedByTheMotionOfTheSeaSurfaceSuchAsABellInABuoy")]
		[EnumMember(Value = "By Wave Action")] 
		ByWaveAction = 2,

		[System.ComponentModel.Description("TheSignalIsGeneratedByAManuallyOperatedMechanismSuchAsAHandCrankedSiren")]
		[EnumMember(Value = "By Hand")] 
		ByHand = 3,

		[System.ComponentModel.Description("TheSignalIsGeneratedByTheMotionOfAirSuchAsAWindDrivenWhistle")]
		[EnumMember(Value = "By Wind")] 
		ByWind = 4,

		[System.ComponentModel.Description("ActivatedByRadioSignal")]
		[EnumMember(Value = "Radio Activated")] 
		RadioActivated = 5,

		[System.ComponentModel.Description("ActivatedByMakingACallToAMannedStation")]
		[EnumMember(Value = "Call Activated")] 
		CallActivated = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum exhibitionConditionOfLight : int {
		[System.ComponentModel.Description("ALightShownThroughoutThe24HoursWithoutChangeOfCharacter")]
		[EnumMember(Value = "Light Shown Without Change of Character")] 
		LightShownWithoutChangeOfCharacter = 1,

		[System.ComponentModel.Description("ALightWhichIsOnlyExhibitedByDay")]
		[EnumMember(Value = "Daytime Light")] 
		DaytimeLight = 2,

		[System.ComponentModel.Description("ALightWhichIsExhibitedInFogOrConditionsOfReducedVisibility")]
		[EnumMember(Value = "Fog Light")] 
		FogLight = 3,

		[System.ComponentModel.Description("ALightWhichIsOnlyExhibitedAtNight")]
		[EnumMember(Value = "Night Light")] 
		NightLight = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLight : int {
		[System.ComponentModel.Description("ALightIlluminatingASectorOfVeryNarrowAngleAndIntendedToMarkADirectionToFollow")]
		[EnumMember(Value = "Directional Function")] 
		DirectionalFunction = 1,

		[System.ComponentModel.Description("ALightAssociatedWithOtherLightsSoAsToFormALeadingLineToBeFollowed")]
		[EnumMember(Value = "Leading Light")] 
		LeadingLight = 4,

		[System.ComponentModel.Description("AnAeroLightIsEstablishedForAeronauticalNavigationAndMayBeOfHigherPowerThanMarineLightsAndVisibleFromWellOffshore")]
		[EnumMember(Value = "Aero Light")] 
		AeroLight = 5,

		[System.ComponentModel.Description("ALightMarkingAnObstacleWhichConstitutesADangerToAirNavigation")]
		[EnumMember(Value = "Air Obstruction Light")] 
		AirObstructionLight = 6,

		[System.ComponentModel.Description("ABroadBeamLightUsedToIlluminateAStructureOrArea")]
		[EnumMember(Value = "Flood Light")] 
		FloodLight = 8,

		[System.ComponentModel.Description("ALightWhoseSourceHasALinearFormGenerallyHorizontalWhichCanReachALengthOfSeveralMetres")]
		[EnumMember(Value = "Strip Light")] 
		StripLight = 9,

		[System.ComponentModel.Description("ALightPlacedOnOrNearTheSupportOfAMainLightAndHavingASpecialUseInNavigation")]
		[EnumMember(Value = "Subsidiary Light")] 
		SubsidiaryLight = 10,

		[System.ComponentModel.Description("APowerfulLightFocusedSoAsToIlluminateASmallArea")]
		[EnumMember(Value = "Spotlight")] 
		Spotlight = 11,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Front")] 
		Front = 12,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Rear")] 
		Rear = 13,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Lower")] 
		Lower = 14,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Upper")] 
		Upper = 15,

		[System.ComponentModel.Description("ALightAvailableAsABackupToAMainLightWhichWillBeIlluminatedShouldTheMainLightFail")]
		[EnumMember(Value = "Emergency")] 
		Emergency = 17,

		[System.ComponentModel.Description("ALightWhichEnablesItsApproximateBearingToBeObtainedWithoutTheUseOfACompass")]
		[EnumMember(Value = "Bearing Light")] 
		BearingLight = 18,

		[System.ComponentModel.Description("AGroupOfLightsOfIdenticalCharacterAndAlmostIdenticalPositionThatAreDisposedHorizontally")]
		[EnumMember(Value = "Horizontally Disposed")] 
		HorizontallyDisposed = 19,

		[System.ComponentModel.Description("AGroupOfLightsOfIdenticalCharacterAndAlmostIdenticalPositionThatAreDisposedVertically")]
		[EnumMember(Value = "Vertically Disposed")] 
		VerticallyDisposed = 20,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum trafficFlow : int {
		[System.ComponentModel.Description("TrafficFlowInAGeneralDirectionTowardAPortOrSimilarDestination")]
		[EnumMember(Value = "Inbound")] 
		Inbound = 1,

		[System.ComponentModel.Description("TrafficFlowInAGeneralDirectionAwayFromAPortOrSimilarPointOfOrigin")]
		[EnumMember(Value = "Outbound")] 
		Outbound = 2,

		[System.ComponentModel.Description("TrafficFlowInOneGeneralDirectionOnly")]
		[EnumMember(Value = "One-Way")] 
		OneWay = 3,

		[System.ComponentModel.Description("TrafficFlowInTwoGenerallyOppositeDirections")]
		[EnumMember(Value = "Two-Way")] 
		TwoWay = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum techniqueOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAnInstrumentThatDeterminesDepthOfWaterByMeasuringTheTimeIntervalBetweenEmissionOfASonicOrUltrasonicSignalAndReturnOfItsEchoFromTheBottom")]
		[EnumMember(Value = "Found by Echo Sounder")] 
		FoundByEchoSounder = 1,

		[System.ComponentModel.Description("TheDepthWasComputedFromARecordProducedByActiveSonarInWhichFixedAcousticBeamsAreDirectedIntoTheWaterPerpendicularlyToTheDirectionOfTravelToScanTheSeabedAndGenerateARecordOfTheSeabedConfiguration")]
		[EnumMember(Value = "Found by Side Scan Sonar")] 
		FoundBySideScanSonar = 2,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAWideSwathEchoSounderThatUsesMultipleBeamsToMeasureDepthsDirectlyBelowAndTransverseToTheShipSTrack")]
		[EnumMember(Value = "Found by Multi Beam")] 
		FoundByMultiBeam = 3,

		[System.ComponentModel.Description("TheDepthWasDeterminedByAPersonSkilledInThePracticeOfDiving")]
		[EnumMember(Value = "Found by Diver")] 
		FoundByDiver = 4,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingALineGraduatedWithAttachedMarksAndFastenedToASoundingLead")]
		[EnumMember(Value = "Found by Lead Line")] 
		FoundByLeadLine = 5,

		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingABuoyedWireAtTheDesiredDepthByTwoLaunchesOrALeastDepthWasIdentifiedUsingTheSameTechnique")]
		[EnumMember(Value = "Swept by Wire-Drag")] 
		SweptByWireDrag = 6,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAnInstrumentThatMeasuresDistanceByEmittingTimedPulsesOfLaserLightAndMeasuringTheTimeBetweenEmissionAndReceptionOfTheReflectedPulses")]
		[EnumMember(Value = "Found by Laser")] 
		FoundByLaser = 7,

		[System.ComponentModel.Description("TheGivenAreaHasBeenSweptUsingASystemComprisedOfMultipleEchoSounderTransducersAttachedToBoomsDeployedFromTheSurveyVessel")]
		[EnumMember(Value = "Swept by Vertical Acoustic System")] 
		SweptByVerticalAcousticSystem = 8,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAnInstrumentThatComparesElectromagneticSignals")]
		[EnumMember(Value = "Found by Electromagnetic Sensor")] 
		FoundByElectromagneticSensor = 9,

		[System.ComponentModel.Description("TheScienceOrArtOfObtainingReliableMeasurementsFromPhotographs")]
		[EnumMember(Value = "Photogrammetry")] 
		Photogrammetry = 10,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingInstrumentsPlacedAboardAnArtificialSatellite")]
		[EnumMember(Value = "Satellite Imagery")] 
		SatelliteImagery = 11,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingLevellingTechniquesToFindTheElevationOfThePointRelativeToADatum")]
		[EnumMember(Value = "Found by Levelling")] 
		FoundByLevelling = 12,

		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingASideScanSonar")]
		[EnumMember(Value = "Swept by Side Scan Sonar")] 
		SweptBySideScanSonar = 13,

		[System.ComponentModel.Description("TheSoundingWasDeterminedFromABottomModelConstructedUsingAComputer")]
		[EnumMember(Value = "Computer Generated")] 
		ComputerGenerated = 14,

		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAnInstrumentThatMeasuresDistanceByEmittingTimedPulsesOfLaserLightAndMeasuringTheTimeBetweenEmissionAndReceptionOfTheReflectedPulses")]
		[EnumMember(Value = "Found by LIDAR")] 
		FoundByLidar = 15,

		[System.ComponentModel.Description("ARadarWithASyntheticApertureAntennaWhichIsComposedOfALargeNumberOfElementaryTransducingElementsTheSignalsAreElectronicallyCombinedIntoAResultingSignalEquivalentToThatOfASingleAntennaOfAGivenApertureInAGivenDirection")]
		[EnumMember(Value = "Synthetic Aperture Radar")] 
		SyntheticApertureRadar = 16,

		[System.ComponentModel.Description("TermUsedToDescribeTheImageryDerivedFromSubdividingTheElectromagneticSpectrumIntoVeryNarrowBandwidthsTheseNarrowBandwidthsMayBeCombinedWithOrSubtractedFromEachOtherInVariousWaysToFormImagesUsefulInPreciseTerrainOrTargetAnalysis")]
		[EnumMember(Value = "Hyperspectral Imagery")] 
		HyperspectralImagery = 17,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthFromTheChartDatumToTheSeabedOrToTheTopOfADryingFeatureIsKnown")]
		[EnumMember(Value = "Depth Known")] 
		DepthKnown = 1,

		[System.ComponentModel.Description("TheDepthFromChartDatumToTheSeabedOrTheShoalestDepthOfTheFeatureIsUnknown")]
		[EnumMember(Value = "Depth or Least Depth Unknown")] 
		DepthOrLeastDepthUnknown = 2,

		[System.ComponentModel.Description("ADepthThatMayBeLessThanIndicated")]
		[EnumMember(Value = "Doubtful Sounding")] 
		DoubtfulSounding = 3,

		[System.ComponentModel.Description("ADepthThatIsConsideredToBeAnUnreliableValue")]
		[EnumMember(Value = "Unreliable Sounding")] 
		UnreliableSounding = 4,

		[System.ComponentModel.Description("UponInvestigationTheBottomWasNotFoundAtThisDepth")]
		[EnumMember(Value = "No Bottom Found at Value Shown")] 
		NoBottomFoundAtValueShown = 5,

		[System.ComponentModel.Description("TheShoalestDepthOverAFeatureIsOfKnownValue")]
		[EnumMember(Value = "Least Depth Known")] 
		LeastDepthKnown = 6,

		[System.ComponentModel.Description("TheLeastDepthOverAFeatureIsUnknownButThereIsConsideredToBeSafeClearanceAtThisDepth")]
		[EnumMember(Value = "Least Depth Unknown, Safe Clearance at Value Shown")] 
		LeastDepthUnknownSafeClearanceAtValueShown = 7,

		[System.ComponentModel.Description("DepthValueObtainedFromAReportButNotFullySurveyed")]
		[EnumMember(Value = "Value Reported (Not Surveyed)")] 
		ValueReportedNotSurveyed = 8,

		[System.ComponentModel.Description("DepthValueObtainedFromAReportWhichItHasNotBeenPossibleToConfirm")]
		[EnumMember(Value = "Value Reported (Not Confirmed)")] 
		ValueReportedNotConfirmed = 9,

		[System.ComponentModel.Description("TheDepthAtWhichAChannelIsKeptByHumanInfluenceUsuallyByDredging")]
		[EnumMember(Value = "Maintained Depth")] 
		MaintainedDepth = 10,

		[System.ComponentModel.Description("DepthsMayBeAlteredByHumanInfluenceButWillNotBeRoutinelyMaintained")]
		[EnumMember(Value = "Not Regularly Maintained")] 
		NotRegularlyMaintained = 11,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfNavigationLine : int {
		[System.ComponentModel.Description("AStraightLineThatMarksTheBoundaryBetweenASafeAndADangerousAreaOrThatPassesClearOfANavigationalDanger")]
		[EnumMember(Value = "Clearing Line")] 
		ClearingLine = 1,

		[System.ComponentModel.Description("ALinePassingThroughOneOrMoreFixedMarks")]
		[EnumMember(Value = "Transit Line")] 
		TransitLine = 2,

		[System.ComponentModel.Description("ALinePassingThroughOneOrMoreClearlyDefinedObjectsAlongThePathOfWhichAVesselCanApproachSafelyUpToACertainDistanceOff")]
		[EnumMember(Value = "Leading Line Bearing a Recommended Track")] 
		LeadingLineBearingARecommendedTrack = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLateralMark : int {
		[System.ComponentModel.Description("IndicatesThePortBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyage")]
		[EnumMember(Value = "Port-Hand Lateral Mark")] 
		PortHandLateralMark = 1,

		[System.ComponentModel.Description("IndicatesTheStarboardBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyage")]
		[EnumMember(Value = "Starboard-Hand Lateral Mark")] 
		StarboardHandLateralMark = 2,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedPortHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Starboard Lateral Mark")] 
		PreferredChannelToStarboardLateralMark = 3,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedStarboardHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Port Lateral Mark")] 
		PreferredChannelToPortLateralMark = 4,

		[System.ComponentModel.Description("IndicatesTheRightHandSideOfTheInlandWaterway")]
		[EnumMember(Value = "Right-Hand Side of the Waterway")] 
		RightHandSideOfTheWaterway = 5,

		[System.ComponentModel.Description("IndicatesTheLeftHandSideOfTheInlandWaterway")]
		[EnumMember(Value = "Left-Hand Side of the Waterway")] 
		LeftHandSideOfTheWaterway = 6,

		[System.ComponentModel.Description("IndicatesTheRightHandSideOfAChannelOfAnInlandWaterway")]
		[EnumMember(Value = "Right-Hand Side of the Channel")] 
		RightHandSideOfTheChannel = 7,

		[System.ComponentModel.Description("IndicatesTheLeftHandSideOfAChannelOfAnInlandWaterway")]
		[EnumMember(Value = "Left-Hand Side of the Channel")] 
		LeftHandSideOfTheChannel = 8,

		[System.ComponentModel.Description("IndicatesABifurcationOfTheInlandWaterway")]
		[EnumMember(Value = "Bifurcation of the Waterway")] 
		BifurcationOfTheWaterway = 9,

		[System.ComponentModel.Description("IndicatesABifurcationOfAChannelOfAnInlandWaterway")]
		[EnumMember(Value = "Bifurcation of the Channel")] 
		BifurcationOfTheChannel = 10,

		[System.ComponentModel.Description("IndicatesThatTheChannelIsNearTheRightBank")]
		[EnumMember(Value = "Channel Near the Right Bank")] 
		ChannelNearTheRightBank = 11,

		[System.ComponentModel.Description("IndicatesThatTheChannelIsNearTheLeftBank")]
		[EnumMember(Value = "Channel Near the Left Bank")] 
		ChannelNearTheLeftBank = 12,

		[System.ComponentModel.Description("IndicatesThatTheChannelCrossesFromTheLeftToTheRightBank")]
		[EnumMember(Value = "Channel Cross-Over to the Right Bank")] 
		ChannelCrossOverToTheRightBank = 13,

		[System.ComponentModel.Description("IndicatesThatTheChannelCrossesFromTheRightToTheLeftBank")]
		[EnumMember(Value = "Channel Cross-Over to the Left Bank")] 
		ChannelCrossOverToTheLeftBank = 14,

		[System.ComponentModel.Description("IndicatesADangerPointOrObstaclesAtTheRightHandSide")]
		[EnumMember(Value = "Danger Point or Obstacles at the Right-Hand Side")] 
		DangerPointOrObstaclesAtTheRightHandSide = 15,

		[System.ComponentModel.Description("IndicatesADangerPointOrObstaclesAtTheLeftHandSide")]
		[EnumMember(Value = "Danger Point or Obstacles at the Left-Hand Side")] 
		DangerPointOrObstaclesAtTheLeftHandSide = 16,

		[System.ComponentModel.Description("IndicatesATurnOffAtTheRightHandSide")]
		[EnumMember(Value = "Turn Off at the Right-Hand Side")] 
		TurnOffAtTheRightHandSide = 17,

		[System.ComponentModel.Description("IndicatesATurnOffAtTheLeftHandSide")]
		[EnumMember(Value = "Turn Off at the Left-Hand Side")] 
		TurnOffAtTheLeftHandSide = 18,

		[System.ComponentModel.Description("IndicatesAJunctionAtTheRightHandSide")]
		[EnumMember(Value = "Junction at the Right-Hand Side")] 
		JunctionAtTheRightHandSide = 19,

		[System.ComponentModel.Description("IndicatesAJunctionAtTheLeftHandSide")]
		[EnumMember(Value = "Junction at the Left-Hand Side")] 
		JunctionAtTheLeftHandSide = 20,

		[System.ComponentModel.Description("IndicatesAHarbourEntryAtTheRightHandSide")]
		[EnumMember(Value = "Harbour Entry at the Right-Hand Side")] 
		HarbourEntryAtTheRightHandSide = 21,

		[System.ComponentModel.Description("IndicatesAHarbourEntryAtTheLeftHandSide")]
		[EnumMember(Value = "Harbour Entry at the Left-Hand Side")] 
		HarbourEntryAtTheLeftHandSide = 22,

		[System.ComponentModel.Description("IndicatesABridgePierInAnInlandWaterway")]
		[EnumMember(Value = "Bridge Pier Mark")] 
		BridgePierMark = 23,

		[System.ComponentModel.Description("IndicatesTheRightBankOfTheEntryFromALakeOrALakeLikeExpansionToASectionOfTheWaterwayWhichIsNarrower")]
		[EnumMember(Value = "Entry From a Lake to a Narrower Waterway, Right Bank")] 
		EntryFromALakeToANarrowerWaterwayRightBank = 24,

		[System.ComponentModel.Description("IndicatesTheLeftBankOfTheEntryFromALakeOrALakeLikeExpansionToASectionOfTheWaterwayWhichIsNarrower")]
		[EnumMember(Value = "Entry From a Lake to a Narrower Waterway, Left Bank")] 
		EntryFromALakeToANarrowerWaterwayLeftBank = 25,

		[System.ComponentModel.Description("ChangeBank")]
		[EnumMember(Value = "Change Bank")] 
		ChangeBank = 26,

		[System.ComponentModel.Description("ContinueAlongBank")]
		[EnumMember(Value = "Continue Along Bank")] 
		ContinueAlongBank = 27,
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
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum function : int {
		[System.ComponentModel.Description("ALocalOfficialWhoHasChargeOfMooringAndBerthingOfVesselsCollectingHarbourFeesEtc")]
		[EnumMember(Value = "Harbour-Masters Office")] 
		HarbourMastersOffice = 2,

		[System.ComponentModel.Description("ServesAsAGovernmentOfficeWhereCustomsDutiesAreCollectedTheFlowOfGoodsAreRegulatedAndRestrictionsEnforcedAndShipmentsOrVehiclesAreClearedForEnteringOrLeavingACountry")]
		[EnumMember(Value = "Customs Office")] 
		CustomsOffice = 3,

		[System.ComponentModel.Description("TheOfficeWhichIsChargedWithTheAdministrationOfHealthLawsAndSanitaryInspections")]
		[EnumMember(Value = "Health Office")] 
		HealthOffice = 4,

		[System.ComponentModel.Description("AnInstitutionOrEstablishmentProvidingMedicalOrSurgicalTreatmentForTheIllOrWounded")]
		[EnumMember(Value = "Hospital")] 
		Hospital = 5,

		[System.ComponentModel.Description("ThePublicDepartmentAgencyOrOrganisationResponsiblePrimarilyForTheCollectionTransmissionAndDistributionOfMail")]
		[EnumMember(Value = "Post Office")] 
		PostOffice = 6,

		[System.ComponentModel.Description("AnEstablishmentEspeciallyOfAComfortableOrLuxuriousKindWherePayingVisitorsAreProvidedWithAccommodationMealsAndOtherServices")]
		[EnumMember(Value = "Hotel")] 
		Hotel = 7,

		[System.ComponentModel.Description("ABuildingWithPlatformsWhereTrainsArriveLoadDischargeAndDepart")]
		[EnumMember(Value = "Railway Station")] 
		RailwayStation = 8,

		[System.ComponentModel.Description("TheHeadquartersOfALocalPoliceForceAndThatIsWhereThoseUnderArrestAreFirstCharged")]
		[EnumMember(Value = "Police Station")] 
		PoliceStation = 9,

		[System.ComponentModel.Description("TheHeadquartersOfALocalWaterPoliceForce")]
		[EnumMember(Value = "Water-Police Station")] 
		WaterPoliceStation = 10,

		[System.ComponentModel.Description("TheOfficeOrHeadquartersOfPilotsThePlaceWhereTheServicesOfAPilotMayBeObtained")]
		[EnumMember(Value = "Pilot Office")] 
		PilotOffice = 11,

		[System.ComponentModel.Description("ADistinctiveStructureOrPlaceOnShoreFromWhichPersonnelKeepWatchUponEventsAtSeaOrAlongTheCoast")]
		[EnumMember(Value = "Pilot Lookout")] 
		PilotLookout = 12,

		[System.ComponentModel.Description("AnOfficeForCustodyDepositLoanExchangeOrIssueOfMoney")]
		[EnumMember(Value = "Bank Office")] 
		BankOffice = 13,

		[System.ComponentModel.Description("TheQuartersOfAnExecutiveOfficerDirectorManagerEtcWithResponsibilityForAnAdministrativeArea")]
		[EnumMember(Value = "Headquarters for District Control")] 
		HeadquartersForDistrictControl = 14,

		[System.ComponentModel.Description("ABuildingOrPartOfABuildingForStorageOfWaresOrGoods")]
		[EnumMember(Value = "Transit Shed/Warehouse")] 
		TransitShedWarehouse = 15,

		[System.ComponentModel.Description("ABuildingOrBuildingsWithEquipmentForManufacturingAWorkshop")]
		[EnumMember(Value = "Factory")] 
		Factory = 16,

		[System.ComponentModel.Description("AStationaryPlantContainingApparatusForLargeScaleConversionOfSomeFormOfEnergySuchAsHydraulicSteamChemicalOrNuclearEnergyIntoElectricalEnergy")]
		[EnumMember(Value = "Power Station")] 
		PowerStation = 17,

		[System.ComponentModel.Description("ABuildingForTheManagementOfAffairs")]
		[EnumMember(Value = "Administrative")] 
		Administrative = 18,

		[System.ComponentModel.Description("ABuildingConcernedWithEducationForExampleSchoolCollegeUniversityEtc")]
		[EnumMember(Value = "Educational Facility")] 
		EducationalFacility = 19,

		[System.ComponentModel.Description("ABuildingForPublicChristianWorship")]
		[EnumMember(Value = "Church")] 
		Church = 20,

		[System.ComponentModel.Description("APlaceForChristianWorshipOtherThanAParishCathedralOrChurchEspeciallyOneAttachedToAPrivateHouseOrInstitution")]
		[EnumMember(Value = "Chapel")] 
		Chapel = 21,

		[System.ComponentModel.Description("ABuildingForPublicJewishWorship")]
		[EnumMember(Value = "Temple")] 
		Temple = 22,

		[System.ComponentModel.Description("AHinduOrBuddhistTempleOrSacredBuilding")]
		[EnumMember(Value = "Pagoda")] 
		Pagoda = 23,

		[System.ComponentModel.Description("ABuildingForPublicShintoWorship")]
		[EnumMember(Value = "Shinto Shrine")] 
		ShintoShrine = 24,

		[System.ComponentModel.Description("ABuildingForPublicBuddhistWorship")]
		[EnumMember(Value = "Buddhist Temple")] 
		BuddhistTemple = 25,

		[System.ComponentModel.Description("AMuslimPlaceOfWorship")]
		[EnumMember(Value = "Mosque")] 
		Mosque = 26,

		[System.ComponentModel.Description("AShrineMarkingTheBurialPlaceOfAMuslimHolyMan")]
		[EnumMember(Value = "Marabout")] 
		Marabout = 27,

		[System.ComponentModel.Description("KeepingAWatchUponEventsAtSeaOrAlongTheCoast")]
		[EnumMember(Value = "Lookout")] 
		Lookout = 28,

		[System.ComponentModel.Description("TransmittingAndOrReceivingElectronicCommunicationSignals")]
		[EnumMember(Value = "Communication")] 
		Communication = 29,

		[System.ComponentModel.Description("ASystemForReproducingOnAScreenVisualImagesTransmittedUsuallyWithSoundByRadioSignals")]
		[EnumMember(Value = "Television")] 
		Television = 30,

		[System.ComponentModel.Description("TransmittingAndOrReceivingRadioFrequencyElectromagneticWavesAsAMeansOfCommunication")]
		[EnumMember(Value = "Radio")] 
		Radio = 31,

		[System.ComponentModel.Description("AMethodSystemOrTechniqueOfUsingBeamedReflectedAndTimedRadioWavesForDetectingLocatingOrTrackingObjectsAndForMeasuringAltitudes")]
		[EnumMember(Value = "Radar")] 
		Radar = 32,

		[System.ComponentModel.Description("AStructureServingAsASupportForOneOrMoreLights")]
		[EnumMember(Value = "Light Support")] 
		LightSupport = 33,

		[System.ComponentModel.Description("BroadcastingAndReceivingSignalsUsingMicrowaves")]
		[EnumMember(Value = "Microwave")] 
		Microwave = 34,

		[System.ComponentModel.Description("GenerationOfChilledLiquidAndOrGasForCoolingPurposes")]
		[EnumMember(Value = "Cooling")] 
		Cooling = 35,

		[System.ComponentModel.Description("APlaceFromWhichTheSurroundingsCanBeObservedButAtWhichAWatchIsNotHabituallyMaintained")]
		[EnumMember(Value = "Observation")] 
		Observation = 36,

		[System.ComponentModel.Description("AVisualTimeSignalInTheFormOfABall")]
		[EnumMember(Value = "Timeball")] 
		Timeball = 37,

		[System.ComponentModel.Description("InstrumentForMeasuringTimeAndRecordingHours")]
		[EnumMember(Value = "Clock")] 
		Clock = 38,

		[System.ComponentModel.Description("UsedToControlTheFlowOfTrafficWithinASpecifiedRangeOfAnInstallation")]
		[EnumMember(Value = "Control")] 
		Control = 39,

		[System.ComponentModel.Description("EquipmentOrStructureToSecureAnAirship")]
		[EnumMember(Value = "Airship Mooring")] 
		AirshipMooring = 40,

		[System.ComponentModel.Description("AnArenaForHoldingAndViewingEvents")]
		[EnumMember(Value = "Stadium")] 
		Stadium = 41,

		[System.ComponentModel.Description("ABuildingWhereBusesAndCoachesRegularlyStopToTakeOnAndOrLetOffPassengersEspeciallyForLongDistanceTravel")]
		[EnumMember(Value = "Bus Station")] 
		BusStation = 42,

		[System.ComponentModel.Description("ABuildingWithinATerminalForTheLoadingAndUnloadingOfPassengers")]
		[EnumMember(Value = "Passenger Terminal Building")] 
		PassengerTerminalBuilding = 43,

		[System.ComponentModel.Description("AUnitResponsibleForPromotingEfficientOrganizationOfSearchAndRescueServicesAndForCoordinatingTheConductOfSearchAndRescueOperationsWithinASearchAndRescueRegion")]
		[EnumMember(Value = "Sea Rescue Control")] 
		SeaRescueControl = 44,

		[System.ComponentModel.Description("ABuildingDesignedAndEquippedForMakingObservationsOfAstronomicalMeteorologicalOrOtherNaturalPhenomena")]
		[EnumMember(Value = "Observatory")] 
		Observatory = 45,

		[System.ComponentModel.Description("ABuildingOrStructureUsedToCrushOre")]
		[EnumMember(Value = "Ore Crusher")] 
		OreCrusher = 46,

		[System.ComponentModel.Description("ABuildingOrShedUsuallyBuiltPartlyOverWaterForShelteringABoatOrBoats")]
		[EnumMember(Value = "Boathouse")] 
		Boathouse = 47,

		[System.ComponentModel.Description("AFacilityToMoveSolidsLiquidsOrGasesByMeansOfPressureOrSuction")]
		[EnumMember(Value = "Pumping Station")] 
		PumpingStation = 48,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLandmark : int {
		[System.ComponentModel.Description("AMoundOfStonesUsuallyConicalOrPyramidalRaisedAsALandmarkOrToDesignateAPointOfImportanceInSurveying")]
		[EnumMember(Value = "Cairn")] 
		Cairn = 1,

		[System.ComponentModel.Description("ASiteAndAssociatedStructuresDevotedToTheBurialOfTheDead")]
		[EnumMember(Value = "Cemetery")] 
		Cemetery = 2,

		[System.ComponentModel.Description("AVerticalStructureContainingAPassageOrFlueForDischargingSmokeAndGasesOfCombustion")]
		[EnumMember(Value = "Chimney")] 
		Chimney = 3,

		[System.ComponentModel.Description("AParabolicAerialForTheReceiptAndTransmissionOfHighFrequencyRadioSignals")]
		[EnumMember(Value = "Dish Aerial")] 
		DishAerial = 4,

		[System.ComponentModel.Description("AStaffOrPoleOnWhichFlagsAreRaised")]
		[EnumMember(Value = "Flagstaff")] 
		Flagstaff = 5,

		[System.ComponentModel.Description("ATallStructureUsedForBurningOffWasteOilOrGas")]
		[EnumMember(Value = "Flare Stack")] 
		FlareStack = 6,

		[System.ComponentModel.Description("ARelativelyTallStructureUsuallyHeldVerticalByGuyLines")]
		[EnumMember(Value = "Mast")] 
		Mast = 7,

		[System.ComponentModel.Description("ATaperedFabricSleeveMountedSoAsToCatchAndSwingWithTheWindThusIndicatingTheWindDirection")]
		[EnumMember(Value = "Windsock")] 
		Windsock = 8,

		[System.ComponentModel.Description("AStructureErectedAndOrMaintainedAsAMemorialToAPersonAndOrEvent")]
		[EnumMember(Value = "Monument")] 
		Monument = 9,

		[System.ComponentModel.Description("ACylindricalOrSlightlyTaperingBodyOfConsiderablyGreaterLengthThanDiameterErectedVertically")]
		[EnumMember(Value = "Column/Pillar")] 
		ColumnPillar = 10,

		[System.ComponentModel.Description("ASlabOfMetalUsuallyOrnamentedErectedAsAMemorialToAPersonOrEvent")]
		[EnumMember(Value = "Memorial Plaque")] 
		MemorialPlaque = 11,

		[System.ComponentModel.Description("ATaperingShaftUsuallyOfStoneOrConcreteSquareOrRectangularInSectionWithAPyramidalApex")]
		[EnumMember(Value = "Obelisk")] 
		Obelisk = 12,

		[System.ComponentModel.Description("ARepresentationOfALivingBeingSculpturedMouldedOrCastInAVarietyOfMaterialsForExampleMarbleMetalOrPlaster")]
		[EnumMember(Value = "Statue")] 
		Statue = 13,

		[System.ComponentModel.Description("AMonumentOrOtherStructureInFormOfACross")]
		[EnumMember(Value = "Cross")] 
		Cross = 14,

		[System.ComponentModel.Description("ALandmarkComprisingAHemisphericalOrSpheroidalShapedStructure")]
		[EnumMember(Value = "Dome")] 
		Dome = 15,

		[System.ComponentModel.Description("ADeviceUsedForDirectingARadarBeamThroughASearchPattern")]
		[EnumMember(Value = "Radar Scanner")] 
		RadarScanner = 16,

		[System.ComponentModel.Description("ARelativelyTallNarrowStructureThatMayEitherStandAloneOrMayFormPartOfAnotherStructure")]
		[EnumMember(Value = "Tower")] 
		Tower = 17,

		[System.ComponentModel.Description("ASystemOfVanesAttachedToATowerAndDrivenByWindExcludingWindTurbines")]
		[EnumMember(Value = "Windmill")] 
		Windmill = 18,

		[System.ComponentModel.Description("AModernStructureForTheUseOfWindPower")]
		[EnumMember(Value = "Windmotor")] 
		Windmotor = 19,

		[System.ComponentModel.Description("ATallConicalOrPyramidShapedStructureOftenBuiltOnTheRoofOrTowerOfABuildingEspeciallyAChurchOrMosque")]
		[EnumMember(Value = "Spire/Minaret")] 
		SpireMinaret = 20,

		[System.ComponentModel.Description("AnIsolatedRockyFormationOrASingleLargeStone")]
		[EnumMember(Value = "Large Rock or Boulder on Land")] 
		LargeRockOrBoulderOnLand = 21,

		[System.ComponentModel.Description("ARecoverablePointOnTheEarthWhoseGeographicPositionHasBeenDeterminedByAngularMethodsWithGeodeticInstrumentsATriangulationPointIsASelectedPointWhichHasBeenMarkedWithAStationMarkOrItIsAConspicuousNaturalOrArtificialFeature")]
		[EnumMember(Value = "Triangulation Mark")] 
		TriangulationMark = 22,

		[System.ComponentModel.Description("AMarkerIdentifyingTheLocationOfASurveyedBoundaryLine")]
		[EnumMember(Value = "Boundary Mark")] 
		BoundaryMark = 23,

		[System.ComponentModel.Description("WheelsWithPassengerCarsMountedExternalToTheRimAndIndependentlyRotatedByElectricMotors")]
		[EnumMember(Value = "Observation Wheel")] 
		ObservationWheel = 24,

		[System.ComponentModel.Description("AFormOfDecorativeGatewayOrPortalConsistingOfTwoUprightWoodenPostsConnectedAtTheTopByTwoHorizontalCrosspiecesCommonlyFoundAtTheEntranceToShintoTemples")]
		[EnumMember(Value = "Torii")] 
		Torii = 25,

		[System.ComponentModel.Description("oneAnElevatedStructureExtendingAcrossOrOverTheWeatherDeckOfAVesselOrPartOfSuchAStructureTheTermIsSometimesModifiedToIndicateTheIntendedUseSuchAsNavigatingBridgeOrSignalBridge2AStructureErectedOverADepressionOrAnObstacleSuchAsABodyOfWaterRailroadEtcToProvideARoadwayForVehiclesOrPedestrians")]
		[EnumMember(Value = "Bridge")] 
		Bridge = 26,

		[System.ComponentModel.Description("ABarrierToCheckOrConfineAnythingInMotionParticularlyOneConstructedToHoldBackWaterAndRaiseItsLevelToFormAReservoirOrToPreventFlooding")]
		[EnumMember(Value = "Dam")] 
		Dam = 27,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buoyShape : int {
		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasApproximatelyTheShapeOrTheAppearanceOfAPointedConeWithThePointUpwards")]
		[EnumMember(Value = "Conical")] 
		Conical = 1,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheShapeOfACylinderOrATruncatedConeThatApproximatesToACylinderWithAFlatEndUppermost")]
		[EnumMember(Value = "Can")] 
		Can = 2,

		[System.ComponentModel.Description("ShapedLikeASphereWhichIsABodyTheSurfaceOfWhichIsAtAllPointsEquidistantFromTheCentre")]
		[EnumMember(Value = "Spherical")] 
		Spherical = 3,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureIsANarrowVerticalStructurePillarOrLatticeTower")]
		[EnumMember(Value = "Pillar")] 
		Pillar = 4,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheFormOfAPoleOrOfAVeryLongCylinderFloatingUpright")]
		[EnumMember(Value = "Spar")] 
		Spar = 5,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheFormOfABarrelOrCylinderFloatingHorizontally")]
		[EnumMember(Value = "Barrel")] 
		Barrel = 6,

		[System.ComponentModel.Description("AVeryLargeBuoyDesignedToCarryASignalLightOfHighLuminousIntensityAtAHighElevation")]
		[EnumMember(Value = "Superbuoy")] 
		Superbuoy = 7,

		[System.ComponentModel.Description("ASpeciallyConstructedShuttleShapedBuoyWhichIsUsedInIceConditions")]
		[EnumMember(Value = "Ice Buoy")] 
		IceBuoy = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum visualProminence : int {
		[System.ComponentModel.Description("TermAppliedToAFeatureEitherNaturalOrArtificialWhichIsDistinctlyAndNotablyVisibleFromSeaward")]
		[EnumMember(Value = "Visually Conspicuous")] 
		VisuallyConspicuous = 1,

		[System.ComponentModel.Description("AnObjectThatMayBeVisibleFromSeawardButCannotBeUsedAsAFixingMarkAndIsNotConspicuous")]
		[EnumMember(Value = "Not Visually Conspicuous")] 
		NotVisuallyConspicuous = 2,

		[System.ComponentModel.Description("ObjectsWhichAreEasilyIdentifiableButDoNotJustifyBeingClassedAsConspicuous")]
		[EnumMember(Value = "Prominent")] 
		Prominent = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum status : int {
		[System.ComponentModel.Description("IntendedToLastOrFunctionIndefinitely")]
		[EnumMember(Value = "Permanent")] 
		Permanent = 1,

		[System.ComponentModel.Description("ActingOnSpecialOccasionsHappeningIrregularly")]
		[EnumMember(Value = "Occasional")] 
		Occasional = 2,

		[System.ComponentModel.Description("PresentedAsWorthyOfConfidenceAcceptanceUseEtc")]
		[EnumMember(Value = "Recommended")] 
		Recommended = 3,

		[System.ComponentModel.Description("UseHasCeasedButTheFacilityStillExistsIntactDisused")]
		[EnumMember(Value = "Not in Use")] 
		NotInUse = 4,

		[System.ComponentModel.Description("RecurringAtIntervals")]
		[EnumMember(Value = "Periodic/Intermittent")] 
		PeriodicIntermittent = 5,

		[System.ComponentModel.Description("SetApartForSomeSpecificUse")]
		[EnumMember(Value = "Reserved")] 
		Reserved = 6,

		[System.ComponentModel.Description("MeantToLastOnlyForATime")]
		[EnumMember(Value = "Temporary")] 
		Temporary = 7,

		[System.ComponentModel.Description("AdministeredByAnIndividualOrCorporationRatherThanAStateOrAPublicBody")]
		[EnumMember(Value = "Private")] 
		Private = 8,

		[System.ComponentModel.Description("CompulsoryEnforced")]
		[EnumMember(Value = "Mandatory")] 
		Mandatory = 9,

		[System.ComponentModel.Description("NoLongerLit")]
		[EnumMember(Value = "Extinguished")] 
		Extinguished = 11,

		[System.ComponentModel.Description("LitByFloodlightsStripLightsEtc")]
		[EnumMember(Value = "Illuminated")] 
		Illuminated = 12,

		[System.ComponentModel.Description("FamousInHistoryOfHistoricalInterest")]
		[EnumMember(Value = "Historic")] 
		Historic = 13,

		[System.ComponentModel.Description("BelongingToAvailableToUsedOrSharedByTheCommunityAsAWholeAndNotRestrictedToPrivateUse")]
		[EnumMember(Value = "Public")] 
		Public = 14,

		[System.ComponentModel.Description("OccurAtATimeCoincideInPointOfTimeBeContemporaryOrSimultaneous")]
		[EnumMember(Value = "Synchronized")] 
		Synchronized = 15,

		[System.ComponentModel.Description("LookedAtOrObservedOverAPeriodOfTimeEspeciallySoAsToBeAwareOfAnyMovementOrChange")]
		[EnumMember(Value = "Watched")] 
		Watched = 16,

		[System.ComponentModel.Description("UsuallyAutomaticInOperationWithoutAnyPermanentlyStationedPersonnelToSuperintendIt")]
		[EnumMember(Value = "Unwatched")] 
		Unwatched = 17,

		[System.ComponentModel.Description("AFeatureThatHasBeenReportedButHasNotBeenDefinitelyDeterminedToExist")]
		[EnumMember(Value = "Existence Doubtful")] 
		ExistenceDoubtful = 18,

		[System.ComponentModel.Description("WhenYouAskForIt")]
		[EnumMember(Value = "On Request")] 
		OnRequest = 19,

		[System.ComponentModel.Description("ToBecomeLowerInLevel")]
		[EnumMember(Value = "Drop Away")] 
		DropAway = 20,

		[System.ComponentModel.Description("ToBecomeHigherInLevel")]
		[EnumMember(Value = "Rising")] 
		Rising = 21,

		[System.ComponentModel.Description("BecomingLargerInMagnitude")]
		[EnumMember(Value = "Increasing")] 
		Increasing = 22,

		[System.ComponentModel.Description("BecomingSmallerInMagnitude")]
		[EnumMember(Value = "Decreasing")] 
		Decreasing = 23,

		[System.ComponentModel.Description("NotEasilyBrokenOrDestroyed")]
		[EnumMember(Value = "Strong")] 
		Strong = 24,

		[System.ComponentModel.Description("InASatisfactoryConditionToUse")]
		[EnumMember(Value = "Good")] 
		Good = 25,

		[System.ComponentModel.Description("FairlyButNotVery")]
		[EnumMember(Value = "Moderately")] 
		Moderately = 26,

		[System.ComponentModel.Description("NotAsGoodAsItCouldBeOrShould")]
		[EnumMember(Value = "Poor")] 
		Poor = 27,

		[System.ComponentModel.Description("MarkedByBuoys")]
		[EnumMember(Value = "Buoyed")] 
		Buoyed = 28,

		[System.ComponentModel.Description("EntireObservationPlatformIsOperatingInAccordanceWithOrExceedingManufacturerSpecifications")]
		[EnumMember(Value = "Fully Operational")] 
		FullyOperational = 29,

		[System.ComponentModel.Description("AtLeastOneInstrumentThatIsPartOfAnObservationPlatformIsNotOperatingToManufacturerSpecification")]
		[EnumMember(Value = "Partially Operational")] 
		PartiallyOperational = 30,

		[System.ComponentModel.Description("FloatingPlatformAtTheMercyOfEnvironmentalElementsWhetherIntentionalOrNot")]
		[EnumMember(Value = "Drifting")] 
		Drifting = 31,

		[System.ComponentModel.Description("FracturedOrInPieces")]
		[EnumMember(Value = "Broken")] 
		Broken = 32,

		[System.ComponentModel.Description("ObservationPlatformIsIntentionallyNotReportingAnEnvironmentalObservation")]
		[EnumMember(Value = "Offline")] 
		Offline = 33,

		[System.ComponentModel.Description("ObservationStationSuiteOfInstrumentsOrAnIndividualInstrumentForAParticularLocationHasBeenRemovedAndIsNoLongerAtTheParticularLocation")]
		[EnumMember(Value = "Discontinued")] 
		Discontinued = 34,

		[System.ComponentModel.Description("ObservationsMadeByAHumanObserver")]
		[EnumMember(Value = "Manual Observation")] 
		ManualObservation = 35,

		[System.ComponentModel.Description("StatusOfAnObservationPlatformSuiteOfInstrumentsOrIndividualInstrumentIsNotKnownOrUnspecified")]
		[EnumMember(Value = "Unknown Status")] 
		UnknownStatus = 36,

		[System.ComponentModel.Description("MadeCertainAsToTruthAccuracyValidityAvailabilityEtc")]
		[EnumMember(Value = "Confirmed")] 
		Confirmed = 37,

		[System.ComponentModel.Description("ItemSelectedForAnAction")]
		[EnumMember(Value = "Candidate")] 
		Candidate = 38,

		[System.ComponentModel.Description("ItemThatIsInTheProcessOfBeingModified")]
		[EnumMember(Value = "Under Modification")] 
		UnderModification = 39,

		[System.ComponentModel.Description("ItemInTheProcessOfBeingRemovedOrDeleted")]
		[EnumMember(Value = "Under Removal / Deletion")] 
		UnderRemovalDeletion = 41,

		[System.ComponentModel.Description("ItemThatHasBeenRemovedOrDeleted")]
		[EnumMember(Value = "Removed / Deleted")] 
		RemovedDeleted = 42,

		[System.ComponentModel.Description("ItemSelectedForModification")]
		[EnumMember(Value = "Candidate for Modification")] 
		CandidateForModification = 43,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfConstruction : int {
		[System.ComponentModel.Description("ConstructedOfStonesOrBricksUsuallyQuarriedShapedAndMortared")]
		[EnumMember(Value = "Masonry")] 
		Masonry = 1,

		[System.ComponentModel.Description("ConstructedOfConcreteAMaterialMadeOfSandAndGravelThatIsUnitedByCementIntoAHardenedMassUsedForRoadsFoundationsEtc")]
		[EnumMember(Value = "Concreted")] 
		Concreted = 2,

		[System.ComponentModel.Description("ConstructedFromLargeStonesOrBlocksOfConcreteOftenPlacedLooselyForProtectionAgainstWavesOrWaterTurbulence")]
		[EnumMember(Value = "Loose Boulders")] 
		LooseBoulders = 3,

		[System.ComponentModel.Description("ConstructedWithASurfaceOfHardMaterialUsuallyATermAppliedToRoadsSurfacedWithAsphaltOrConcrete")]
		[EnumMember(Value = "Hard Surfaced")] 
		HardSurfaced = 4,

		[System.ComponentModel.Description("ConstructedWithNoExtraProtectionUsuallyATermAppliedToRoadsNotSurfacedWithAHardMaterial")]
		[EnumMember(Value = "Unsurfaced")] 
		Unsurfaced = 5,

		[System.ComponentModel.Description("ConstructedFromWood")]
		[EnumMember(Value = "Wooden")] 
		Wooden = 6,

		[System.ComponentModel.Description("ConstructedFromMetal")]
		[EnumMember(Value = "Metal")] 
		Metal = 7,

		[System.ComponentModel.Description("ConstructedFromAPlasticMaterialStrengthenedWithFibresOfGlass")]
		[EnumMember(Value = "Glass Reinforced Plastic")] 
		GlassReinforcedPlastic = 8,

		[System.ComponentModel.Description("TheApplicationOfPaintToSomeOtherConstructionOrNaturalFeature")]
		[EnumMember(Value = "Painted")] 
		Painted = 9,

		[System.ComponentModel.Description("ConstructedFromALatticeFrameworkOfOftenDiagonalIntersectingStruts")]
		[EnumMember(Value = "Framework")] 
		Framework = 10,

		[System.ComponentModel.Description("AStructureOfCrossedWoodenOrMetalStripsUsuallyArrangedToFormADiagonalPatternOfOpenSpacesBetweenTheStrips")]
		[EnumMember(Value = "Latticed")] 
		Latticed = 11,

		[System.ComponentModel.Description("oneAnyArtificialOrNaturalSubstanceHavingSimilarPropertiesAndCompositionAsFusedBoraxObsidianOrTheLike2SomethingMadeOfSuchASubstanceAsAWindowpane")]
		[EnumMember(Value = "Glass")] 
		Glass = 12,

		[System.ComponentModel.Description("ConstructedFromFiberglass")]
		[EnumMember(Value = "Fiberglass")] 
		Fiberglass = 13,

		[System.ComponentModel.Description("ConstructedFromPlastic")]
		[EnumMember(Value = "Plastic")] 
		Plastic = 14,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum marksNavigationalSystemOf : int {
		[System.ComponentModel.Description("NavigationalAidsConformToTheInternationalAssociationOfLighthouseAuthoritiesIalaASystem")]
		[EnumMember(Value = "IALA A")] 
		IalaA = 1,

		[System.ComponentModel.Description("NavigationalAidsConformToTheInternationalAssociationOfLighthouseAuthoritiesIalaBSystem")]
		[EnumMember(Value = "IALA B")] 
		IalaB = 2,

		[System.ComponentModel.Description("NavigationalAidsDoNotConformToAnyDefinedSystem")]
		[EnumMember(Value = "No System")] 
		NoSystem = 9,

		[System.ComponentModel.Description("NavigationalAidsConformToADefinedSystemOtherThanInternationalAssociationOfLighthouseAuthoritiesIala")]
		[EnumMember(Value = "Other System")] 
		OtherSystem = 10,

		[System.ComponentModel.Description("CevniEuropeanCodeForNavigationOnInlandWaterwaysIsTheEuropeanCodeForRiversCanalsLandLakesInMostOfEurope")]
		[EnumMember(Value = "CEVNI")] 
		Cevni = 11,

		[System.ComponentModel.Description("NavigationalAidsConformToTheRussianInlandWaterwayRegulations")]
		[EnumMember(Value = "Russian Inland Waterway Regulations")] 
		RussianInlandWaterwayRegulations = 12,

		[System.ComponentModel.Description("NavigationalAidsConformToTheBrazilianNationalInlandWaterwayRegulationsForTwoSides")]
		[EnumMember(Value = "Brazilian National Inland Waterway Regulations - Two Sides")] 
		BrazilianNationalInlandWaterwayRegulationsTwoSides = 13,

		[System.ComponentModel.Description("NavigationalAidsConformToTheBrazilianNationalInlandWaterwayRegulationsSideIndependent")]
		[EnumMember(Value = "Brazilian National Inland Waterway Regulations - Side Independent")] 
		BrazilianNationalInlandWaterwayRegulationsSideIndependent = 14,

		[System.ComponentModel.Description("NavigationalAidsConformToTheBrazilianComplementaryAidsOnTheParaguayParanaWaterway")]
		[EnumMember(Value = "Paraguay-Parana Waterway - Brazilian Complementary Aids")] 
		ParaguayParanaWaterwayBrazilianComplementaryAids = 15,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colourPattern : int {
		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedHorizontally")]
		[EnumMember(Value = "Horizontal Stripes")] 
		HorizontalStripes = 1,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedVertically")]
		[EnumMember(Value = "Vertical Stripes")] 
		VerticalStripes = 2,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedDiagonallyThatIsNotHorizontallyOrVertically")]
		[EnumMember(Value = "Diagonal Stripes")] 
		DiagonalStripes = 3,

		[System.ComponentModel.Description("OftenReferredToAsCheckerPlateWhereAlternateColoursAreUsedToCreateSquaresSimilarToAChessOrDraughtBoardThePatternMayBeStraightOrDiagonal")]
		[EnumMember(Value = "Squared")] 
		Squared = 4,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedInAnUnknownDirection")]
		[EnumMember(Value = "Stripes (Direction Unknown)")] 
		StripesDirectionUnknown = 5,

		[System.ComponentModel.Description("ABandOrStripeOfColourWhichIsDisplayedAroundTheOuterEdgeOfTheObjectWhichMayAlsoFormABorderToAnInnerPatternOrPlainColour")]
		[EnumMember(Value = "Border Stripe")] 
		BorderStripe = 6,

		[System.ComponentModel.Description("OneSolidColourOfUniformCoverage")]
		[EnumMember(Value = "Single Colour")] 
		SingleColour = 7,

		[System.ComponentModel.Description("AFourSidedShapeThatIsMadeUpOfTwoPairsOfParallelLinesAndThatHasFourRightAnglesOnADifferentColouredBackground")]
		[EnumMember(Value = "Rectangle")] 
		Rectangle = 8,

		[System.ComponentModel.Description("AShapeThatIsMadeUpOfThreeLinesAndThreeAnglesOnADifferentColouredBackground")]
		[EnumMember(Value = "Triangle")] 
		Triangle = 9,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colour : int {
		[System.ComponentModel.Description("TheAchromaticObjectColourOfGreatestLightnessCharacteristicallyPerceivedToBelongToObjectsThatReflectDiffuselyNearlyAllIncidentEnergyThroughoutTheVisibleSpectrum")]
		[EnumMember(Value = "White")] 
		White = 1,

		[System.ComponentModel.Description("TheAchromaticColorOfLeastLightnessCharacteristicallyPerceivedToBelongToObjectsThatNeitherReflectNorTransmitLight")]
		[EnumMember(Value = "Black")] 
		Black = 2,

		[System.ComponentModel.Description("AColorWhoseHueResemblesThatOfBloodOrOfTheRubyOrIsThatOfTheLongWaveExtremeOfTheVisibleSpectrum")]
		[EnumMember(Value = "Red")] 
		Red = 3,

		[System.ComponentModel.Description("OfTheColorGreen")]
		[EnumMember(Value = "Green")] 
		Green = 4,

		[System.ComponentModel.Description("AColorWhoseHueIsThatOfTheClearSkyOrThatOfThePortionOfTheColorSpectrumLyingBetweenGreenAndViolet")]
		[EnumMember(Value = "Blue")] 
		Blue = 5,

		[System.ComponentModel.Description("AColorWhoseHueResemblesThatOfRipeLemonsOrSunflowersOrIsThatOfThePortionOfTheSpectrumLyingBetweenGreenAndOrange")]
		[EnumMember(Value = "Yellow")] 
		Yellow = 6,

		[System.ComponentModel.Description("OfTheColorGrey")]
		[EnumMember(Value = "Grey")] 
		Grey = 7,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsBetweenRedAndYellowInHueOfMediumToLowLightnessAndOfModerateToLowSaturation")]
		[EnumMember(Value = "Brown")] 
		Brown = 8,

		[System.ComponentModel.Description("AVariableColorAveragingADarkOrangeYellow")]
		[EnumMember(Value = "Amber")] 
		Amber = 9,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsOfReddishBlueHueLowLightnessAndMediumSaturation")]
		[EnumMember(Value = "Violet")] 
		Violet = 10,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsThatAreBetweenRedAndYellowInHue")]
		[EnumMember(Value = "Orange")] 
		Orange = 11,

		[System.ComponentModel.Description("ADeepPurplishRed")]
		[EnumMember(Value = "Magenta")] 
		Magenta = 12,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsBluishRedToRedInHueOfMediumToHighLightnessAndOfLowToModerateSaturation")]
		[EnumMember(Value = "Pink")] 
		Pink = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green A")] 
		GreenA = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green B")] 
		GreenB = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "White Temporary")] 
		WhiteTemporary = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Red Temporary")] 
		RedTemporary = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Yellow Temporary")] 
		YellowTemporary = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green Preferred")] 
		GreenPreferred = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green Temporary")] 
		GreenTemporary = 20,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum beaconShape : int {
		[System.ComponentModel.Description("AnElongatedWoodOrMetalPoleDrivenIntoTheGroundOrSeabedWhichServesAsANavigationalAidOrASupportForANavigationalAid")]
		[EnumMember(Value = "Stake, Pole, Perch, Post")] 
		StakePolePerchPost = 1,

		[System.ComponentModel.Description("ATreeWithoutRootsStuckOrSpoiledIntoTheBottomOfTheSeaToServeAsANavigationalAid")]
		[EnumMember(Value = "Withy")] 
		Withy = 2,

		[System.ComponentModel.Description("ASolidStructureOfTheOrderOf10MetresInHeightUsedAsANavigationalAid")]
		[EnumMember(Value = "Beacon Tower")] 
		BeaconTower = 3,

		[System.ComponentModel.Description("AStructureConsistingOfStripsOfMetalOrWoodCrossedOrInterlacedToFormAStructureToServeAsAnAidToNavigationOrAsASupportForAnAidToNavigation")]
		[EnumMember(Value = "Lattice Beacon")] 
		LatticeBeacon = 4,

		[System.ComponentModel.Description("ALongHeavyTimberSOrSectionSOfSteelWoodConcreteEtcForcedIntoTheSeabedToServeAsAnAidToNavigationOrAsASupportForAnAidToNavigation")]
		[EnumMember(Value = "Pile Beacon")] 
		PileBeacon = 5,

		[System.ComponentModel.Description("AMoundOfStonesUsuallyConicalOrPyramidalRaisedAsALandmarkOrToDesignateAPointOfImportanceInSurveying")]
		[EnumMember(Value = "Cairn")] 
		Cairn = 6,

		[System.ComponentModel.Description("ATallSparLikeBeaconFittedWithAPermanentlySubmergedBuoyancyChamberTheLowerEndOfTheBodyIsSecuredToSeabedSinkerEitherByAFlexibleJointOrByACableUnderTension")]
		[EnumMember(Value = "Buoyant Beacon")] 
		BuoyantBeacon = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum aidAvailabilityCategory : int {
		[System.ComponentModel.Description("AnAtonOrSystemOfAtonThatIsConsideredByTheCompetentAuthorityToBeOfVitalNavigationalSignificance")]
		[EnumMember(Value = "Category 1")] 
		Category1 = 1,

		[System.ComponentModel.Description("AnAtonOrSystemOfAtonThatIsConsideredByTheCompetentAuthorityToBeOfImportantNavigationalSignificance")]
		[EnumMember(Value = "Category 2")] 
		Category2 = 2,

		[System.ComponentModel.Description("AnAtonOrSystemOfAtonThatIsConsideredByTheCompetentAuthorityToBeOfNecessaryNavigationalSignificance")]
		[EnumMember(Value = "Category 3")] 
		Category3 = 3,
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

		[System.ComponentModel.Description("AWindmillOrWindTurbineFromWhichTheVanesOrTurbineBladesAreMissing")]
		[EnumMember(Value = "Wingless")] 
		Wingless = 4,

		[System.ComponentModel.Description("DetailedPlanningHasBeenCompletedButConstructionHasNotBeenInitiated")]
		[EnumMember(Value = "Planned Construction")] 
		PlannedConstruction = 5,
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

		[System.ComponentModel.Description("ContinuousOrFrequentChangeForExampleRiverSiltationSandWavesSeasonalStormsIcebergsEtcThatIsLikelyToResultInNewSignificantShoaling")]
		[EnumMember(Value = "Likely to Change and Significant Shoaling Expected")] 
		LikelyToChangeAndSignificantShoalingExpected = 2,

		[System.ComponentModel.Description("ContinuousOrFrequentChangeForExampleSandWaveShiftSeasonalStormsIcebergsEtcThatIsNotLikelyToResultInNewSignificantShoaling")]
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
	public enum atonCommissioning : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy establishment")] 
		BuoyEstablishment = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light establishment")] 
		LightEstablishment = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon establishment")] 
		BeaconEstablishment = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal establishment")] 
		AudibleSignalEstablishment = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal establishment")] 
		FogSignalEstablishment = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "AIS transmitter establishment")] 
		AisTransmitterEstablishment = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS establishment")] 
		VAisEstablishment = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON establishment")] 
		RaconEstablishment = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS station establishment")] 
		DgpsStationEstablishment = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN station establishment")] 
		EloranStationEstablishment = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGLONASS station establishment")] 
		DglonassStationEstablishment = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka station establishment")] 
		EChaykaStationEstablishment = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS establishment")] 
		EgnosEstablishment = 13,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonRemoval : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy removal")] 
		BuoyRemoval = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy temporary removal")] 
		BuoyTemporaryRemoval = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light removal")] 
		LightRemoval = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light temporary removal")] 
		LightTemporaryRemoval = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon removal")] 
		BeaconRemoval = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon temporary removal")] 
		BeaconTemporaryRemoval = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal removal")] 
		FogSignalRemoval = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal temporary removal")] 
		FogSignalTemporaryRemoval = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal removal")] 
		AudibleSignalRemoval = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal temporary removal")] 
		AudibleSignalTemporaryRemoval = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS removal")] 
		VAisRemoval = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS temporary removal")] 
		VAisTemporaryRemoval = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON signal removal")] 
		RaconSignalRemoval = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON temporary removal")] 
		RaconTemporaryRemoval = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS removal")] 
		DgpsRemoval = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS temporary removal")] 
		DgpsTemporaryRemoval = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS removal")] 
		EgnosRemoval = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS temporary removal")] 
		EgnosTemporaryRemoval = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C station removal")] 
		LoranCStationRemoval = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C station temporary removal")] 
		LoranCStationTemporaryRemoval = 20,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN removal")] 
		EloranRemoval = 21,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN temporary removal")] 
		EloranTemporaryRemoval = 22,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka station removal")] 
		ChaykaStationRemoval = 23,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka station temporary removal")] 
		ChaykaStationTemporaryRemoval = 24,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka station removal")] 
		EChaykaStationRemoval = 25,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka station temporary removal")] 
		EChaykaStationTemporaryRemoval = 26,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonReplacement : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy change")] 
		BuoyChange = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy temporary change")] 
		BuoyTemporaryChange = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light change")] 
		LightChange = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light temporary change")] 
		LightTemporaryChange = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Sector light change")] 
		SectorLightChange = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Sector light temporary change")] 
		SectorLightTemporaryChange = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon change")] 
		BeaconChange = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon temporary change")] 
		BeaconTemporaryChange = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal change")] 
		FogSignalChange = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal temporary change")] 
		FogSignalTemporaryChange = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal change")] 
		AudibleSignalChange = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal temporary change")] 
		AudibleSignalTemporaryChange = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS change")] 
		VAisChange = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS temporary change")] 
		VAisTemporaryChange = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON signal change")] 
		RaconSignalChange = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON temporary change")] 
		RaconTemporaryChange = 16,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum fixedAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon missing")] 
		BeaconMissing = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon damaged")] 
		BeaconDamaged = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light beacon Unlit")] 
		LightBeaconUnlit = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light beacon Unreliable")] 
		LightBeaconUnreliable = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light beacon Not synchronized")] 
		LightBeaconNotSynchronized = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light beacon damaged")] 
		LightBeaconDamaged = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon topmark missing")] 
		BeaconTopmarkMissing = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon topmark damaged")] 
		BeaconTopmarkDamaged = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon daymark unreliable")] 
		BeaconDaymarkUnreliable = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Floodlit beacon Unlit")] 
		FloodlitBeaconUnlit = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon restored to normal")] 
		BeaconRestoredToNormal = 11,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum floatingAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy adrift")] 
		BuoyAdrift = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy damaged")] 
		BuoyDamaged = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy daymark unreliable")] 
		BuoyDaymarkUnreliable = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy destroyed")] 
		BuoyDestroyed = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy missing")] 
		BuoyMissing = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy move")] 
		BuoyMove = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy off position")] 
		BuoyOffPosition = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy re-establishment")] 
		BuoyReEstablishment = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy restored to normal")] 
		BuoyRestoredToNormal = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy topmark damaged")] 
		BuoyTopmarkDamaged = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy topmark missing")] 
		BuoyTopmarkMissing = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy will be withdrawn")] 
		BuoyWillBeWithdrawn = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy withdrawn")] 
		BuoyWithdrawn = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Decommissioned for winter")] 
		DecommissionedForWinter = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Lifted for Winter")] 
		LiftedForWinter = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light buoy Light damaged")] 
		LightBuoyLightDamaged = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light buoy Light not synchronized")] 
		LightBuoyLightNotSynchronized = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light buoy Light unlit")] 
		LightBuoyLightUnlit = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light buoy Light unreliable")] 
		LightBuoyLightUnreliable = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Marine Aids to Navigation unreliable")] 
		MarineAidsToNavigationUnreliable = 20,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Recommissioned for navigation season")] 
		RecommissionedForNavigationSeason = 21,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Replaced by Winter Spar")] 
		ReplacedByWinterSpar = 22,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Seasonal decommissioning complete")] 
		SeasonalDecommissioningComplete = 23,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Seasonal decommissioning in progress")] 
		SeasonalDecommissioningInProgress = 24,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Seasonal recommissioning complete")] 
		SeasonalRecommissioningComplete = 25,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Seasonal recommissioning in progress")] 
		SeasonalRecommissioningInProgress = 26,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum audibleSignalAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal out of service")] 
		AudibleSignalOutOfService = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal out of service")] 
		FogSignalOutOfService = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal operating properly")] 
		AudibleSignalOperatingProperly = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal operating properly")] 
		FogSignalOperatingProperly = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightedAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light unlit")] 
		LightUnlit = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light unreliable")] 
		LightUnreliable = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light re-establishment")] 
		LightReEstablishment = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light range reduced")] 
		LightRangeReduced = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light without rhythm")] 
		LightWithoutRhythm = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light out of synchronization")] 
		LightOutOfSynchronization = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light daymark unreliable")] 
		LightDaymarkUnreliable = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light operating properly")] 
		LightOperatingProperly = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Sector light Sector obscured")] 
		SectorLightSectorObscured = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light Unlit")] 
		FrontLeadingRangeLightUnlit = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light Unlit")] 
		RearLeadingRangeLightUnlit = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light Unreliable")] 
		FrontLeadingRangeLightUnreliable = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light Unreliable")] 
		RearLeadingRangeLightUnreliable = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light Light range reduced")] 
		FrontLeadingRangeLightLightRangeReduced = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light Light range reduced")] 
		RearLeadingRangeLightLightRangeReduced = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light without rhythm")] 
		FrontLeadingRangeLightWithoutRhythm = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light without rhythm")] 
		RearLeadingRangeLightWithoutRhythm = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Leading/range lights out of synchronization")] 
		LeadingRangeLightsOutOfSynchronization = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range beacon Unreliable")] 
		FrontLeadingRangeBeaconUnreliable = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range beacon Unreliable")] 
		RearLeadingRangeBeaconUnreliable = 20,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light is operating properly")] 
		FrontLeadingRangeLightIsOperatingProperly = 21,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light is operating properly")] 
		RearLeadingRangeLightIsOperatingProperly = 22,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range beacon restored to normal")] 
		FrontLeadingRangeBeaconRestoredToNormal = 23,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range beacon restored to normal")] 
		RearLeadingRangeBeaconRestoredToNormal = 24,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum electronicAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "AIS transmitter out of service")] 
		AisTransmitterOutOfService = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "AIS transmitter unreliable")] 
		AisTransmitterUnreliable = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "AIS transmitter operating properly")] 
		AisTransmitterOperatingProperly = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS out of service")] 
		VAisOutOfService = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS unreliable")] 
		VAisUnreliable = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS operating properly")] 
		VAisOperatingProperly = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON out of service")] 
		RaconOutOfService = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON unreliable")] 
		RaconUnreliable = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON operating properly")] 
		RaconOperatingProperly = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS out of service")] 
		DgpsOutOfService = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS operating properly")] 
		DgpsOperatingProperly = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS unreliable")] 
		DgpsUnreliable = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C operating properly")] 
		LoranCOperatingProperly = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C unreliable")] 
		LoranCUnreliable = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C out of service")] 
		LoranCOutOfService = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN operating properly")] 
		EloranOperatingProperly = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN unreliable")] 
		EloranUnreliable = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN out of service")] 
		EloranOutOfService = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGLOANSS operating properly")] 
		DgloanssOperatingProperly = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGLOANSS unreliable")] 
		DgloanssUnreliable = 20,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGLOANSS out of service")] 
		DgloanssOutOfService = 21,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka operating properly")] 
		ChaykaOperatingProperly = 22,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka unreliable")] 
		ChaykaUnreliable = 23,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka out of service")] 
		ChaykaOutOfService = 24,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka operating properly")] 
		EChaykaOperatingProperly = 25,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka unreliable")] 
		EChaykaUnreliable = 26,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka out of service")] 
		EChaykaOutOfService = 27,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS operating properly")] 
		EgnosOperatingProperly = 28,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS unreliable")] 
		EgnosUnreliable = 29,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS out of service")] 
		EgnosOutOfService = 30,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum positioningEquipment : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS Receiver")] 
		DgpsReceiver = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "GLONASS Receiver")] 
		GlonassReceiver = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "GPS Receiver")] 
		GpsReceiver = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "GPS/WAAS Receiver")] 
		GpsWaasReceiver = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Serializable()]
	public class CategoryOfAssociation
	{
		public required string label { get; set; }
		public required string definition { get; set; }
		public required int code { get; set; }
	}

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
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class contactAddress {
			public String? deliveryPoint {get;set;} = default;
			public bool ShouldSerializedeliveryPoint() { return false; }

			public String? cityName {get;set;} = default;
			public bool ShouldSerializecityName() { return false; }

			public String? administrativeDivision {get;set;} = default;
			public bool ShouldSerializeadministrativeDivision() { return false; }

			public String? countryName {get;set;} = default;
			public bool ShouldSerializecountryName() { return false; }

			public String? postalCode {get;set;} = default;
			public bool ShouldSerializepostalCode() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class featureName {
			public Boolean? displayName {get;set;} = default;
			public bool ShouldSerializedisplayName() { return false; }

			public String? language {get;set;} = default;
			public bool ShouldSerializelanguage() { return false; }

			public String name {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class fixedDateRange {
			public String? dateEnd {get;set;} = default;
			public bool ShouldSerializedateEnd() { return false; }

			public String? dateStart {get;set;} = default;
			public bool ShouldSerializedateStart() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class multiplicityOfFeatures {
			[Required()]
			public Boolean multiplicityKnown {get;set;} = false;

			public int? numberOfFeatures {get;set;} = default;
			public bool ShouldSerializenumberOfFeatures() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class orientation {
			public decimal? orientationUncertainty {get;set;} = default;
			public bool ShouldSerializeorientationUncertainty() { return false; }

			[Required()]
			public decimal orientationValue {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class periodicDateRange {
			public String dateEnd {get;set;}

			public String dateStart {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class radarWaveLength {
			public String radarBand {get;set;} = string.Empty;

			[Required()]
			public decimal waveLengthValue {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorInformation {
			public String? language {get;set;} = default;
			public bool ShouldSerializelanguage() { return false; }

			public String text {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitOne {
			[Required()]
			public decimal sectorBearing {get;set;}

			public int? sectorLineLength {get;set;} = default;
			public bool ShouldSerializesectorLineLength() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimitTwo {
			[Required()]
			public decimal sectorBearing {get;set;}

			public int? sectorLineLength {get;set;} = default;
			public bool ShouldSerializesectorLineLength() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class shapeInformation {
			public String? language {get;set;} = default;
			public bool ShouldSerializelanguage() { return false; }

			public String text {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class signalSequence {
			[Required()]
			public decimal signalDuration {get;set;}

			[EnumerationValue([1,2])]
			[Required()]
			public signalStatus signalStatus {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class CableDimensions {
			[Required()]
			public decimal cableLength {get;set;}

			[EnumerationValue([1,2,3,4,5,6])]
			[Required()]
			public heightLengthUnits heightLengthUnits {get;set;}

			[Required()]
			public decimal diameter {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class ChangeDetails {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public atonCommissioning? atonCommissioning {get;set;} = default;
			public bool ShouldSerializeatonCommissioning() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public atonRemoval? atonRemoval {get;set;} = default;
			public bool ShouldSerializeatonRemoval() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public atonReplacement? atonReplacement {get;set;} = default;
			public bool ShouldSerializeatonReplacement() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public fixedAtonChange? fixedAtonChange {get;set;} = default;
			public bool ShouldSerializefixedAtonChange() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26])]
			public floatingAtonChange? floatingAtonChange {get;set;} = default;
			public bool ShouldSerializefloatingAtonChange() { return false; }

			[EnumerationValue([1,2,3,4])]
			public audibleSignalAtonChange? audibleSignalAtonChange {get;set;} = default;
			public bool ShouldSerializeaudibleSignalAtonChange() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
			public lightedAtonChange? lightedAtonChange {get;set;} = default;
			public bool ShouldSerializelightedAtonChange() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30])]
			public electronicAtonChange? electronicAtonChange {get;set;} = default;
			public bool ShouldSerializeelectronicAtonChange() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sinkerDimensions {
			[EnumerationValue([1,2,3,4,5,6])]
			[Required()]
			public heightLengthUnits heightLengthUnits {get;set;}

			public decimal? horizontalLength {get;set;} = default;
			public bool ShouldSerializehorizontalLength() { return false; }

			public decimal? horizontalWidth {get;set;} = default;
			public bool ShouldSerializehorizontalWidth() { return false; }

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class positioningMethod {
			[EnumerationValue([1,2,3,4])]
			[Required()]
			public positioningEquipment positioningEquipment {get;set;}

			public String NMEAString {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class horizontalPositionUncertainty {
			[Required()]
			public decimal uncertaintyFixed {get;set;}

			public decimal? uncertaintyVariableFactor {get;set;} = default;
			public bool ShouldSerializeuncertaintyVariableFactor() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class information {
			public String? fileLocator {get;set;} = default;
			public bool ShouldSerializefileLocator() { return false; }

			public String? fileReference {get;set;} = default;
			public bool ShouldSerializefileReference() { return false; }

			public String? headline {get;set;} = default;
			public bool ShouldSerializeheadline() { return false; }

			public String language {get;set;} = string.Empty;

			public String? text {get;set;} = default;
			public bool ShouldSerializetext() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class textualDescription {
			public String fileReference {get;set;} = string.Empty;

			public String? language {get;set;} = default;
			public bool ShouldSerializelanguage() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class verticalUncertainty {
			[Required()]
			public decimal uncertaintyFixed {get;set;}

			public decimal? uncertaintyVariableFactor {get;set;} = default;
			public bool ShouldSerializeuncertaintyVariableFactor() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class directionalCharacter {
			public Boolean? moireEffect {get;set;} = default;
			public bool ShouldSerializemoireEffect() { return false; }

			[Required()]
			public orientation orientation {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rhythmOfLight {
			[EnumerationValue([1,2,3,4,5,6,7,8,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,31,32,33,34,35])]
			[Required()]
			public lightCharacteristic lightCharacteristic {get;set;}

			public List<String> signalGroup {get;set;} = [];

			public decimal? signalPeriod {get;set;} = default;
			public bool ShouldSerializesignalPeriod() { return false; }

			public List<signalSequence> signalSequence {get;set;} = [];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorLimit {
			[Required()]
			public sectorLimitOne sectorLimitOne {get;set;}

			[Required()]
			public sectorLimitTwo sectorLimitTwo {get;set;}
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class spatialAccuracy {
			public fixedDateRange? fixedDateRange {get;set;} = default;
			public bool ShouldSerializefixedDateRange() { return false; }

			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;
			public bool ShouldSerializehorizontalPositionUncertainty() { return false; }

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
			public bool ShouldSerializeverticalUncertainty() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class ObscuredSector {
			[Required()]
			public sectorLimit sectorLimit {get;set;}

			public sectorInformation? sectorInformation {get;set;} = default;
			public bool ShouldSerializesectorInformation() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lightSector {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public directionalCharacter? directionalCharacter {get;set;} = default;
			public bool ShouldSerializedirectionalCharacter() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			public sectorLimit? sectorLimit {get;set;} = default;
			public bool ShouldSerializesectorLimit() { return false; }

			public decimal? valueOfNominalRange {get;set;} = default;
			public bool ShouldSerializevalueOfNominalRange() { return false; }

			public List<sectorInformation> sectorInformation {get;set;} = [];

			public Boolean? sectorExtension {get;set;} = default;
			public bool ShouldSerializesectorExtension() { return false; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorCharacteristics {
			[EnumerationValue([1,2,3,4,5,6,7,8,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,31,32,33,34,35])]
			[Required()]
			public lightCharacteristic lightCharacteristic {get;set;}

			public List<lightSector> lightSector {get;set;} = [];

			public List<String> signalGroup {get;set;} = [];

			public decimal? signalPeriod {get;set;} = default;
			public bool ShouldSerializesignalPeriod() { return false; }

			public List<signalSequence> signalSequence {get;set;} = [];

			public decimal? candela {get;set;} = default;
			public bool ShouldSerializecandela() { return false; }
		}

	}
	public enum Role {
		[System.ComponentModel.Description("-")]
		Atonpart,
		[System.ComponentModel.Description("-")]
		Statuspart,
		[System.ComponentModel.Description("TBD")]
		buoyPart,
		[System.ComponentModel.Description("TBD")]
		topmarkPart,
		[System.ComponentModel.Description("-")]
		parent,
		[System.ComponentModel.Description("-")]
		child,
		[System.ComponentModel.Description("-")]
		physicalAISbroadcastBy,
		[System.ComponentModel.Description("-")]
		physicalAISbroadcasts,
		[System.ComponentModel.Description("-")]
		syntheticAISbroadcastBy,
		[System.ComponentModel.Description("-")]
		syntheticAISbroadcasts,
		[System.ComponentModel.Description("-")]
		virtualAISbroadcastBy,
		[System.ComponentModel.Description("-")]
		virtualAISbroadcasts,
		[System.ComponentModel.Description("-")]
		buoyattached,
		[System.ComponentModel.Description("-")]
		counterWeightholds,
		[System.ComponentModel.Description("-")]
		buoyhangs,
		[System.ComponentModel.Description("-")]
		bridleholds,
		[System.ComponentModel.Description("-")]
		shackleToCableconnectedTo,
		[System.ComponentModel.Description("-")]
		shackleToCableconnected,
		[System.ComponentModel.Description("-")]
		swivelattached,
		[System.ComponentModel.Description("-")]
		bridleattached,
		[System.ComponentModel.Description("-")]
		cableholds,
		[System.ComponentModel.Description("-")]
		shackleToBridleconnected,
		[System.ComponentModel.Description("-")]
		shackleToBridleconnectedTo,
		[System.ComponentModel.Description("-")]
		shackleToBuoyconnected,
		[System.ComponentModel.Description("-")]
		shackleToBuoyconnectedTo,
		[System.ComponentModel.Description("-")]
		shackleToSwivelconnected,
		[System.ComponentModel.Description("-")]
		shackleToSwivelconnectedTo,
		[System.ComponentModel.Description("-")]
		shackleToAnchorconnectedTo,
		[System.ComponentModel.Description("-")]
		shackleToAnchorconnected,
		[System.ComponentModel.Description("-")]
		bridlehangs,
		[System.ComponentModel.Description("-")]
		swivelholds,
		[System.ComponentModel.Description("TBD")]
		peerAtonAggregation,
		[System.ComponentModel.Description("TBD")]
		atonAggregationBy,
		[System.ComponentModel.Description("TBD")]
		peerAtonAssociation,
		[System.ComponentModel.Description("TBD")]
		atonAssociationBy,
		[System.ComponentModel.Description("The role given to the navigable part of the navigation line.")]
		navigableTrack,
		[System.ComponentModel.Description("The role given to the navigation line(s) that is generally formed between two or more objects, or by one object and a bearing.")]
		navigationLine,
		[System.ComponentModel.Description("-")]
		fixingMethod,
		[System.ComponentModel.Description("-")]
		fixedBy,
		[System.ComponentModel.Description("-")]
		positioningMethod,
		[System.ComponentModel.Description("-")]
		positionedBy,
		[System.ComponentModel.Description("-")]
		danger,
		[System.ComponentModel.Description("-")]
		markingAton,
	}

	namespace InformationAssociations {
		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Atonstatus : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(Atonstatus);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonFixingMethodAssociation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AtonFixingMethodAssociation);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonPositioningInformationAssociation : InformationAssociation {
			[JsonIgnore]
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
			[JsonIgnore]
			public override string Code => nameof(BuoyTopmark);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StructureEquipment : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(StructureEquipment);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalAIS : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(PhysicalAIS);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SyntheticAIS : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(SyntheticAIS);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VirtualAIS : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(VirtualAIS);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BuoyCounterWeight : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(BuoyCounterWeight);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BridleConnection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(BridleConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleConnection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(ShackleConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleConnectionFromCable : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(ShackleConnectionFromCable);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SwivelCableConnection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(SwivelCableConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BridleCableConnection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(BridleCableConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleToBridleConnection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(ShackleToBridleConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleToSwivelConnection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(ShackleToSwivelConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShackleToAnchorConnection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(ShackleToAnchorConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SwivelConnection : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(SwivelConnection);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAggregations : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(AtonAggregations);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAssociations : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(AtonAssociations);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RangeSystem : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(RangeSystem);
		}

		/// <summary>
		/// 
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DangerousFeatureAssociation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(DangerousFeatureAssociation);
		}
	}

}

namespace S100Framework.DomainModel.S201 {
	using ComplexAttributes;
	using InformationAssociations;

	namespace InformationTypes {
		/// <summary>
		/// Method used for fixing the position of an aid to navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtoNFixingMethod : InformationNode, IInformationBindingDefinition {
			public String? referencePoint {get;set;} = default;
			public bool ShouldSerializereferencePoint() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131])]
			public horizontalDatum? horizontalDatum {get;set;} = default;
			public bool ShouldSerializehorizontalDatum() { return false; }

			[Required()]
			public DateOnly sourceDate {get;set;}

			public String positioningProcedure {get;set;} = string.Empty;

			[JsonIgnore]
			public override string Code => nameof(AtoNFixingMethod);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtoNFixingMethod._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonStatusInformation : InformationNode, IInformationBindingDefinition {
			[Required()]
			public ChangeDetails ChangeDetails {get;set;}

			[EnumerationValue([1,2,3,4])]
			public ChangeTypes? ChangeTypes {get;set;} = default;
			public bool ShouldSerializeChangeTypes() { return false; }

			[JsonIgnore]
			public override string Code => nameof(AtonStatusInformation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtonStatusInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}

		/// <summary>
		/// Information about how a position was obtained. (proposed by CCG)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PositioningInformation : InformationNode, IInformationBindingDefinition {
			public String positioningDevice {get;set;} = string.Empty;

			public positioningMethod? positioningMethod {get;set;} = default;
			public bool ShouldSerializepositioningMethod() { return false; }

			[JsonIgnore]
			public override string Code => nameof(PositioningInformation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => PositioningInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
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
			public bool ShouldSerializequalityOfHorizontalMeasurement() { return false; }

			public spatialAccuracy? spatialAccuracy {get;set;} = default;
			public bool ShouldSerializespatialAccuracy() { return false; }

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
		/// A visual, acoustical, or radio device, external to a ship, designed to assist in determining a safe course or a vessel's position, or to warn of dangers and/or obstructions. Aids to navigation usually include buoys, beacons, fog signals, lights, radio beacons, leading marks, radio position fixing systems and GNSS which are chart-related and assist safe navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class AidsToNavigation : FeatureNode, IFeatureBindingDefinition {
			public String? iDCode {get;set;} = default;
			public bool ShouldSerializeiDCode() { return false; }

			public List<information> information {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;
			public bool ShouldSerializescaleMinimum() { return false; }

			public DateOnly? sourceDate {get;set;} = default;
			public bool ShouldSerializesourceDate() { return false; }

			public String? source {get;set;} = default;
			public bool ShouldSerializesource() { return false; }

			public String? pictorialRepresentation {get;set;} = default;
			public bool ShouldSerializepictorialRepresentation() { return false; }

			public String? inspectionFrequency {get;set;} = default;
			public bool ShouldSerializeinspectionFrequency() { return false; }

			public String? inspectionRequirements {get;set;} = default;
			public bool ShouldSerializeinspectionRequirements() { return false; }

			public String? aToNMaintenanceRecord {get;set;} = default;
			public bool ShouldSerializeaToNMaintenanceRecord() { return false; }

			public DateOnly? installationDate {get;set;} = default;
			public bool ShouldSerializeinstallationDate() { return false; }

			public fixedDateRange? fixedDateRange {get;set;} = default;
			public bool ShouldSerializefixedDateRange() { return false; }

			public periodicDateRange? periodicDateRange {get;set;} = default;
			public bool ShouldSerializeperiodicDateRange() { return false; }

			public List<String> SeasonalActionRequired {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(AidsToNavigation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AidsToNavigation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(Atonstatus),
					role = Enum.GetName<Role>(Role.Statuspart)!,
					informationTypes = [nameof(AtonStatusInformation)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AidsToNavigation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AidsToNavigation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonAggregations),
					role = Enum.GetName<Role>(Role.peerAtonAggregation)!,
					featureTypes = [nameof(AtonAggregation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonAssociations),
					role = Enum.GetName<Role>(Role.peerAtonAssociation)!,
					featureTypes = [nameof(AtonAssociation)],
				},
			];
		}

		/// <summary>
		/// Something (such as a house, tower, bridge, etc.) that is built by putting parts together and that usually stands on its own.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class StructureObject : AidsToNavigation {
			public String AtoNNumber {get;set;} = string.Empty;

			[EnumerationValue([1,2,3])]
			public aidAvailabilityCategory? aidAvailabilityCategory {get;set;} = default;
			public bool ShouldSerializeaidAvailabilityCategory() { return false; }

			[EnumerationValue([1,2,3,4,5])]
			public condition? condition {get;set;} = default;
			public bool ShouldSerializecondition() { return false; }

			public contactAddress? contactAddress {get;set;} = default;
			public bool ShouldSerializecontactAddress() { return false; }

			[JsonIgnore]
			public override string Code => nameof(StructureObject);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..StructureObject._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonPositioningInformationAssociation),
					role = Enum.GetName<Role>(Role.positioningMethod)!,
					informationTypes = [nameof(PositioningInformation)],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonFixingMethodAssociation),
					role = Enum.GetName<Role>(Role.fixingMethod)!,
					informationTypes = [nameof(AtoNFixingMethod)],
				},
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..StructureObject._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..StructureObject._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.child)!,
					featureTypes = [nameof(Equipment)],
				},
			];
		}

		/// <summary>
		/// The implements used in an operation or activity.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class Equipment : AidsToNavigation {
			public List<String> remoteMonitoringSystem {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Equipment);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..Equipment._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..Equipment._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Equipment._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.parent)!,
					featureTypes = [nameof(StructureObject)],
				},
			];
		}

		/// <summary>
		/// TBD
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class ElectronicAton : AidsToNavigation {
			public String? AtoNNumber {get;set;} = default;
			public bool ShouldSerializeAtoNNumber() { return false; }

			public String mMSICode {get;set;} = string.Empty;

			public List<status> status {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ElectronicAton);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..ElectronicAton._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..ElectronicAton._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..ElectronicAton._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A fixed artificial navigation mark that can be recognized by its shape, colour, pattern, topmark or light character, or a combination of these. It may carry various additional aids to navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericBeacon : StructureObject {
			[EnumerationValue([1,2,3,4,5,6,7])]
			[Required()]
			public beaconShape beaconShape {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public decimal? elevation {get;set;} = default;
			public bool ShouldSerializeelevation() { return false; }

			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;
			public bool ShouldSerializemarksNavigationalSystemOf() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;
			public bool ShouldSerializeradarConspicuous() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;
			public bool ShouldSerializevisualProminence() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(GenericBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..GenericBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..GenericBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..GenericBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A floating object moored to the bottom in a particular (charted) place, as an aid to navigation or for other specific purposes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericBuoy : StructureObject {
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;
			public bool ShouldSerializemarksNavigationalSystemOf() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;
			public bool ShouldSerializeradarConspicuous() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public String? typeOfBuoy {get;set;} = default;
			public bool ShouldSerializetypeOfBuoy() { return false; }

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(GenericBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..GenericBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..GenericBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..GenericBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BuoyTopmark),
					role = Enum.GetName<Role>(Role.topmarkPart)!,
					featureTypes = [nameof(Topmark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(ShackleConnection),
					role = Enum.GetName<Role>(Role.shackleToBuoyconnected)!,
					featureTypes = [nameof(MooringShackle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(BridleConnection),
					role = Enum.GetName<Role>(Role.buoyhangs)!,
					featureTypes = [nameof(Bridle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(BuoyCounterWeight),
					role = Enum.GetName<Role>(Role.buoyattached)!,
					featureTypes = [nameof(CounterWeight)],
				},
			];
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericLight : Equipment {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20])]
			public List<colour> colour {get;set;} = [];

			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			public decimal? effectiveIntensity {get;set;} = default;
			public bool ShouldSerializeeffectiveIntensity() { return false; }

			public decimal? peakIntensity {get;set;} = default;
			public bool ShouldSerializepeakIntensity() { return false; }

			[JsonIgnore]
			public override string Code => nameof(GenericLight);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..GenericLight._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..GenericLight._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..GenericLight._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A prominent object at a fixed location on land which can be used in determining a location or a direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Landmark : StructureObject {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public List<categoryOfLandmark> categoryOfLandmark {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48])]
			public List<function> function {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;
			public bool ShouldSerializeradarConspicuous() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			[EnumerationValue([1,2,3])]
			[Required()]
			public visualProminence visualProminence {get;set;}

			public decimal? elevation {get;set;} = default;
			public bool ShouldSerializeelevation() { return false; }

			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			public Boolean? mannedStructure {get;set;} = default;
			public bool ShouldSerializemannedStructure() { return false; }

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(Landmark);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..Landmark._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..Landmark._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Landmark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.curve, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage. (UKHO NP 735, 5th Edition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBeacon : GenericBeacon {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			[Required()]
			public categoryOfLateralMark categoryOfLateralMark {get;set;}

			[JsonIgnore]
			public override string Code => nameof(LateralBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..LateralBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..LateralBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..LateralBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage. (UKHO NP 735, 5th Edition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBuoy : GenericBuoy {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			[Required()]
			public categoryOfLateralMark categoryOfLateralMark {get;set;}

			[JsonIgnore]
			public override string Code => nameof(LateralBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..LateralBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..LateralBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..LateralBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationLine : AidsToNavigation {
			[EnumerationValue([1,2,3])]
			[Required()]
			public categoryOfNavigationLine categoryOfNavigationLine {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[Required()]
			public orientation orientation {get;set;}

			[JsonIgnore]
			public override string Code => nameof(NavigationLine);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..NavigationLine._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..NavigationLine._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..NavigationLine._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RangeSystem),
					role = Enum.GetName<Role>(Role.navigableTrack)!,
					featureTypes = [nameof(RecommendedTrack)],
				},
			];
		}

		/// <summary>
		/// A route which has been specially examined to ensure so far as possible that it is free of dangers and along which ships are advised to navigate.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RecommendedTrack : AidsToNavigation {
			[Required()]
			public Boolean basedOnFixedMarks {get;set;} = false;

			public decimal? depthRangeMinimumValue {get;set;} = default;
			public bool ShouldSerializedepthRangeMinimumValue() { return false; }

			public decimal? maximalPermittedDraught {get;set;} = default;
			public bool ShouldSerializemaximalPermittedDraught() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			[Required()]
			public orientation orientation {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
			public bool ShouldSerializeverticalUncertainty() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue([1,2,3,4])]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

			[JsonIgnore]
			public override string Code => nameof(RecommendedTrack);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..RecommendedTrack._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..RecommendedTrack._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..RecommendedTrack._primitives];
			public new static Primitives[] _primitives => [
				Primitives.curve
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(RangeSystem),
					role = Enum.GetName<Role>(Role.navigationLine)!,
					featureTypes = [nameof(NavigationLine)],
				},
			];
		}

		/// <summary>
		/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightSectored : GenericLight {
			[EnumerationValue([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;
			public bool ShouldSerializeexhibitionConditionOfLight() { return false; }

			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public List<marksNavigationalSystemOf> marksNavigationalSystemOf {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;
			public bool ShouldSerializesignalGeneration() { return false; }

			public List<ObscuredSector> ObscuredSector {get;set;} = [];

			public List<sectorCharacteristics> sectorCharacteristics {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LightSectored);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericLight._informationBindingDefinitions, ..LightSectored._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericLight._featureBindingDefinitions, ..LightSectored._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightSectored._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAllAround : GenericLight {
			[EnumerationValue([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[EnumerationValue([1,2,3,4])]
			public List<exhibitionConditionOfLight> exhibitionConditionOfLight {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public lightVisibility? lightVisibility {get;set;} = default;
			public bool ShouldSerializelightVisibility() { return false; }

			public Boolean? majorLight {get;set;} = default;
			public bool ShouldSerializemajorLight() { return false; }

			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;
			public bool ShouldSerializemarksNavigationalSystemOf() { return false; }

			[EnumerationValue([1,2,3,4,5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;
			public bool ShouldSerializesignalGeneration() { return false; }

			public decimal? valueOfNominalRange {get;set;} = default;
			public bool ShouldSerializevalueOfNominalRange() { return false; }

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;
			public bool ShouldSerializemultiplicityOfFeatures() { return false; }

			[Required()]
			public rhythmOfLight rhythmOfLight {get;set;}

			public int? flareBearing {get;set;} = default;
			public bool ShouldSerializeflareBearing() { return false; }

			[JsonIgnore]
			public override string Code => nameof(LightAllAround);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericLight._informationBindingDefinitions, ..LightAllAround._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericLight._featureBindingDefinitions, ..LightAllAround._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightAllAround._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAirObstruction : GenericLight {
			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;
			public bool ShouldSerializeexhibitionConditionOfLight() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			public decimal? valueOfGeographicRange {get;set;} = default;
			public bool ShouldSerializevalueOfGeographicRange() { return false; }

			public decimal? valueOfLuminousRange {get;set;} = default;
			public bool ShouldSerializevalueOfLuminousRange() { return false; }

			public decimal? valueOfNominalRange {get;set;} = default;
			public bool ShouldSerializevalueOfNominalRange() { return false; }

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;
			public bool ShouldSerializemultiplicityOfFeatures() { return false; }

			[Required()]
			public rhythmOfLight rhythmOfLight {get;set;}

			public int? flareBearing {get;set;} = default;
			public bool ShouldSerializeflareBearing() { return false; }

			[JsonIgnore]
			public override string Code => nameof(LightAirObstruction);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericLight._informationBindingDefinitions, ..LightAirObstruction._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericLight._featureBindingDefinitions, ..LightAirObstruction._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightAirObstruction._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFogDetector : GenericLight {
			[EnumerationValue([1,2,3,4,5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;
			public bool ShouldSerializesignalGeneration() { return false; }

			[Required()]
			public rhythmOfLight rhythmOfLight {get;set;}

			[JsonIgnore]
			public override string Code => nameof(LightFogDetector);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericLight._informationBindingDefinitions, ..LightFogDetector._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericLight._featureBindingDefinitions, ..LightFogDetector._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericLight._primitives, ..LightFogDetector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A device capable of, or intended for, reflecting radar signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarReflector : Equipment {
			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(RadarReflector);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..RadarReflector._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..RadarReflector._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadarReflector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A warning signal transmitted by a vessel, or aid to navigation, during periods of low visibility. Also, the device producing such a signal.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FogSignal : Equipment {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			[Required()]
			public categoryOfFogSignal categoryOfFogSignal {get;set;}

			public int? signalFrequency {get;set;} = default;
			public bool ShouldSerializesignalFrequency() { return false; }

			[EnumerationValue([1,2,3,4,5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;
			public bool ShouldSerializesignalGeneration() { return false; }

			public String? signalGroup {get;set;} = default;
			public bool ShouldSerializesignalGroup() { return false; }

			public decimal? signalOutput {get;set;} = default;
			public bool ShouldSerializesignalOutput() { return false; }

			public decimal? signalPeriod {get;set;} = default;
			public bool ShouldSerializesignalPeriod() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public decimal? valueOfMaximumRange {get;set;} = default;
			public bool ShouldSerializevalueOfMaximumRange() { return false; }

			public signalSequence? signalSequence {get;set;} = default;
			public bool ShouldSerializesignalSequence() { return false; }

			[JsonIgnore]
			public override string Code => nameof(FogSignal);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..FogSignal._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..FogSignal._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..FogSignal._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A sensor used to observe the environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class EnvironmentObservationEquipment : Equipment {
			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public List<String> typeOfEnvironmentalObservationEquipment {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(EnvironmentObservationEquipment);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..EnvironmentObservationEquipment._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..EnvironmentObservationEquipment._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..EnvironmentObservationEquipment._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A place equipped to transmit radio waves. Such a station may be either stationary or mobile, and may also be provided with a radio receiver.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioStation : Equipment {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,19,20])]
			[Required()]
			public categoryOfRadioStation categoryOfRadioStation {get;set;}

			public decimal? estimatedRangeOfTransmission {get;set;} = default;
			public bool ShouldSerializeestimatedRangeOfTransmission() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public status? status {get;set;} = default;
			public bool ShouldSerializestatus() { return false; }

			[JsonIgnore]
			public override string Code => nameof(RadioStation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..RadioStation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..RadioStation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadioStation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(PhysicalAIS),
					role = Enum.GetName<Role>(Role.physicalAISbroadcastBy)!,
					featureTypes = [nameof(PhysicalAISAidToNavigation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(SyntheticAIS),
					role = Enum.GetName<Role>(Role.syntheticAISbroadcastBy)!,
					featureTypes = [nameof(SyntheticAISAidToNavigation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(VirtualAIS),
					role = Enum.GetName<Role>(Role.virtualAISbroadcastBy)!,
					featureTypes = [nameof(VirtualAISAidToNavigation)],
				},
			];
		}

		/// <summary>
		/// (1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Daymark : Equipment {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			public categoryOfSpecialPurposeMark? categoryOfSpecialPurposeMark {get;set;} = default;
			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public decimal? elevation {get;set;} = default;
			public bool ShouldSerializeelevation() { return false; }

			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public decimal? orientationValue {get;set;} = default;
			public bool ShouldSerializeorientationValue() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
			[Required()]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			public shapeInformation? shapeInformation {get;set;} = default;
			public bool ShouldSerializeshapeInformation() { return false; }

			[Required()]
			public Boolean isSlatted {get;set;} = false;

			[JsonIgnore]
			public override string Code => nameof(Daymark);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..Daymark._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..Daymark._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..Daymark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A means of distinguishing unlighted marks at night. Retro-reflective material is secured to the mark in a particular pattern to reflect back light.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Retroreflector : Equipment {
			[EnumerationValue([1,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;
			public bool ShouldSerializemarksNavigationalSystemOf() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(Retroreflector);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..Retroreflector._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..Retroreflector._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..Retroreflector._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A transponder beacon transmitting a coded signal on radar frequency, permitting an interrogating craft to determine the bearing and range of the transponder.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarTransponderBeacon : Equipment {
			[EnumerationValue([1,2,3])]
			[Required()]
			public categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon {get;set;}

			public radarWaveLength? radarWaveLength {get;set;} = default;
			public bool ShouldSerializeradarWaveLength() { return false; }

			public String? signalGroup {get;set;} = default;
			public bool ShouldSerializesignalGroup() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public decimal? valueOfNominalRange {get;set;} = default;
			public bool ShouldSerializevalueOfNominalRange() { return false; }

			public String? manufactorer {get;set;} = default;
			public bool ShouldSerializemanufactorer() { return false; }

			public sectorLimitOne? sectorLimitOne {get;set;} = default;
			public bool ShouldSerializesectorLimitOne() { return false; }

			public sectorLimitTwo? sectorLimitTwo {get;set;} = default;
			public bool ShouldSerializesectorLimitTwo() { return false; }

			public signalSequence? signalSequence {get;set;} = default;
			public bool ShouldSerializesignalSequence() { return false; }

			[JsonIgnore]
			public override string Code => nameof(RadarTransponderBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..RadarTransponderBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..RadarTransponderBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..RadarTransponderBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VirtualAISAidToNavigation : ElectronicAton {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Required()]
			public virtualAISAidToNavigationType virtualAISAidToNavigationType {get;set;}

			[JsonIgnore]
			public override string Code => nameof(VirtualAISAidToNavigation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ElectronicAton._informationBindingDefinitions, ..VirtualAISAidToNavigation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ElectronicAton._featureBindingDefinitions, ..VirtualAISAidToNavigation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..VirtualAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(VirtualAIS),
					role = Enum.GetName<Role>(Role.virtualAISbroadcasts)!,
					featureTypes = [nameof(RadioStation)],
				},
			];
		}

		/// <summary>
		/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalAISAidToNavigation : ElectronicAton {
			[EnumerationValue([1,2,3])]
			[Required()]
			public CategoryOfPhysicalAISAidToNavigation CategoryOfPhysicalAISAidToNavigation {get;set;}

			[JsonIgnore]
			public override string Code => nameof(PhysicalAISAidToNavigation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ElectronicAton._informationBindingDefinitions, ..PhysicalAISAidToNavigation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ElectronicAton._featureBindingDefinitions, ..PhysicalAISAidToNavigation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..PhysicalAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(PhysicalAIS),
					role = Enum.GetName<Role>(Role.physicalAISbroadcasts)!,
					featureTypes = [nameof(RadioStation)],
				},
			];
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SyntheticAISAidToNavigation : ElectronicAton {
			[EnumerationValue([1,2])]
			[Required()]
			public CategoryOfSyntheticAISAidtoNavigation CategoryOfSyntheticAISAidtoNavigation {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			[Required()]
			public virtualAISAidToNavigationType virtualAISAidToNavigationType {get;set;}

			[JsonIgnore]
			public override string Code => nameof(SyntheticAISAidToNavigation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..ElectronicAton._informationBindingDefinitions, ..SyntheticAISAidToNavigation._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..ElectronicAton._featureBindingDefinitions, ..SyntheticAISAidToNavigation._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..ElectronicAton._primitives, ..SyntheticAISAidToNavigation._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(SyntheticAIS),
					role = Enum.GetName<Role>(Role.syntheticAISbroadcasts)!,
					featureTypes = [nameof(RadioStation)],
				},
			];
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PowerSource : Equipment {
			[EnumerationValue([1,2,3,4])]
			[Required()]
			public CategoryOfPowerSource CategoryOfPowerSource {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(PowerSource);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Equipment._informationBindingDefinitions, ..PowerSource._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Equipment._featureBindingDefinitions, ..PowerSource._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Equipment._primitives, ..PowerSource._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). An isolated danger beacon is a beacon erected on an isolated danger of limited extent, which has navigable water all around it. (UKHO NP735, 5th Edition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBeacon : GenericBeacon {
			[JsonIgnore]
			public override string Code => nameof(IsolatedDangerBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..IsolatedDangerBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..IsolatedDangerBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..IsolatedDangerBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBeacon : GenericBeacon {
			[EnumerationValue([1,2,3,4])]
			[Required()]
			public categoryOfCardinalMark categoryOfCardinalMark {get;set;}

			[JsonIgnore]
			public override string Code => nameof(CardinalBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..CardinalBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..CardinalBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..CardinalBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A isolated danger buoy is a buoy moored on or above an isolated danger of limited extent, which has navigable water all around it. (UKHO NP735, 5th Edition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBuoy : GenericBuoy {
			[JsonIgnore]
			public override string Code => nameof(IsolatedDangerBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..IsolatedDangerBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..IsolatedDangerBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..IsolatedDangerBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A cardinal buoy is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBuoy : GenericBuoy {
			[EnumerationValue([1,2,3,4])]
			[Required()]
			public categoryOfCardinalMark categoryOfCardinalMark {get;set;}

			[JsonIgnore]
			public override string Code => nameof(CardinalBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..CardinalBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..CardinalBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..CardinalBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). An installation buoy is a buoy used for loading tankers with gas or oil. (IHO Chart Specifications, M-4)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InstallationBuoy : GenericBuoy {
			[EnumerationValue([1,2])]
			[Required()]
			public categoryOfInstallationBuoy categoryOfInstallationBuoy {get;set;}

			[JsonIgnore]
			public override string Code => nameof(InstallationBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..InstallationBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..InstallationBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..InstallationBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// The equipment or structure used to secure a vessel. (IHO Registry)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringBuoy : GenericBuoy {
			[JsonIgnore]
			public override string Code => nameof(MooringBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..MooringBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..MooringBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..MooringBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// An emergency wreck marking buoy is a buoy moored on or above a new wreck, designed to provide a prominent (both visual and radio) and easily identifiable temporary (24-72 hours) first response. (IHO Registry)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class EmergencyWreckMarkingBuoy : GenericBuoy {
			[JsonIgnore]
			public override string Code => nameof(EmergencyWreckMarkingBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..EmergencyWreckMarkingBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..EmergencyWreckMarkingBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..EmergencyWreckMarkingBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A distinctive structure on or off a coast exhibiting a major light designed to serve as an aid to navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Lighthouse : Landmark {
			[JsonIgnore]
			public override string Code => nameof(Lighthouse);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..Landmark._informationBindingDefinitions, ..Lighthouse._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..Landmark._featureBindingDefinitions, ..Lighthouse._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..Landmark._primitives, ..Lighthouse._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFloat : StructureObject {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public decimal? horizontalLength {get;set;} = default;
			public bool ShouldSerializehorizontalLength() { return false; }

			public decimal? horizontalWidth {get;set;} = default;
			public bool ShouldSerializehorizontalWidth() { return false; }

			public Boolean? mannedStructure {get;set;} = default;
			public bool ShouldSerializemannedStructure() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;
			public bool ShouldSerializeradarConspicuous() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;
			public bool ShouldSerializevisualProminence() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			public decimal? horizontalAccuracy {get;set;} = default;
			public bool ShouldSerializehorizontalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(LightFloat);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..LightFloat._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..LightFloat._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..LightFloat._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A distinctively marked vessel anchored or moored at a charted point, to serve as an aid to navigation. By night, it displays a characteristic light(s) and is usually equipped with other devices, such as fog signal, submarine sound signal, and radio-beacon, to assist navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightVessel : StructureObject {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public decimal? horizontalLength {get;set;} = default;
			public bool ShouldSerializehorizontalLength() { return false; }

			public decimal? horizontalWidth {get;set;} = default;
			public bool ShouldSerializehorizontalWidth() { return false; }

			public Boolean? mannedStructure {get;set;} = default;
			public bool ShouldSerializemannedStructure() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;
			public bool ShouldSerializeradarConspicuous() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;
			public bool ShouldSerializevisualProminence() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			public decimal? horizontalAccuracy {get;set;} = default;
			public bool ShouldSerializehorizontalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(LightVessel);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..LightVessel._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..LightVessel._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..LightVessel._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A permanent offshore structure, either fixed or floating.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OffshorePlatform : StructureObject {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public List<categoryOfOffshorePlatform> categoryOfOffshorePlatform {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			public Boolean? mannedStructure {get;set;} = default;
			public bool ShouldSerializemannedStructure() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25])]
			public List<product> product {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;
			public bool ShouldSerializeradarConspicuous() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;
			public bool ShouldSerializevisualProminence() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(OffshorePlatform);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..OffshorePlatform._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..OffshorePlatform._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..OffshorePlatform._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A large storage structure used for storing loose materials, liquids and/or gases.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SiloTank : StructureObject {
			[EnumerationValue([5,6,7,8,9])]
			public buildingShape? buildingShape {get;set;} = default;
			public bool ShouldSerializebuildingShape() { return false; }

			[EnumerationValue([1,2,3,4])]
			public categoryOfSiloTank? categoryOfSiloTank {get;set;} = default;
			public bool ShouldSerializecategoryOfSiloTank() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public decimal? elevation {get;set;} = default;
			public bool ShouldSerializeelevation() { return false; }

			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;
			public bool ShouldSerializeradarConspicuous() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;
			public bool ShouldSerializevisualProminence() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(SiloTank);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..SiloTank._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..SiloTank._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..SiloTank._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point, Primitives.surface
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A long heavy timber or section of steel, wood, concrete, etc., forced into the earth or sea floor to serve as a support, as for a pier, or to resist lateral pressure; or as a free standing pole within a marine environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Pile : StructureObject {
			[EnumerationValue([1,3,4,5,6,7])]
			public categoryOfPile? categoryOfPile {get;set;} = default;
			public bool ShouldSerializecategoryOfPile() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public decimal? height {get;set;} = default;
			public bool ShouldSerializeheight() { return false; }

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;
			public bool ShouldSerializeverticalDatum() { return false; }

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;
			public bool ShouldSerializevisualProminence() { return false; }

			public decimal? verticalAccuracy {get;set;} = default;
			public bool ShouldSerializeverticalAccuracy() { return false; }

			[JsonIgnore]
			public override string Code => nameof(Pile);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..Pile._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..Pile._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Pile._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A free-standing self-supporting construction that is roofed, usually walled, and is intended for human occupancy (for example: a place of work or recreation) and/or habitation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Building : StructureObject {
			[JsonIgnore]
			public override string Code => nameof(Building);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..Building._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..Building._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Building._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// (1) An elevated structure extending across or over the weather deck of a vessel, or part of such a structure. The term is sometimes modified to indicate the intended use, such as navigating bridge or signal bridge.  (2) A structure erected over a depression or an obstacle such as a body of water, railroad, etc., to provide a roadway for vehicles or pedestrians.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bridge : StructureObject {
			[JsonIgnore]
			public override string Code => nameof(Bridge);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..StructureObject._informationBindingDefinitions, ..Bridge._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..StructureObject._featureBindingDefinitions, ..Bridge._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..StructureObject._primitives, ..Bridge._primitives];
			public new static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A heavy weight (of concrete, cast-iron, etc..) that rests on the sea bed and to which a mooring line can be attached. (IALA Dictionary, 8-5-025)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SinkerAnchor : AidsToNavigation {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;
			public bool ShouldSerializenatureOfConstruction() { return false; }

			public sinkerDimensions? sinkerDimensions {get;set;} = default;
			public bool ShouldSerializesinkerDimensions() { return false; }

			[Required()]
			public decimal weight {get;set;}

			public String? sinkerType {get;set;} = default;
			public bool ShouldSerializesinkerType() { return false; }

			[JsonIgnore]
			public override string Code => nameof(SinkerAnchor);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..SinkerAnchor._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..SinkerAnchor._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..SinkerAnchor._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(ShackleToAnchorConnection),
					role = Enum.GetName<Role>(Role.shackleToAnchorconnected)!,
					featureTypes = [nameof(MooringShackle)],
				},
			];
		}

		/// <summary>
		/// A shackle at the lower end of a mooring chain, for attachment to an anchor or sinker. (IALA Dictionary, 8-5-150)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringShackle : AidsToNavigation {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;
			public bool ShouldSerializenatureOfConstruction() { return false; }

			[EnumerationValue([1,2,3,4,5,6])]
			public ShackleType? ShackleType {get;set;} = default;
			public bool ShouldSerializeShackleType() { return false; }

			public decimal? weight {get;set;} = default;
			public bool ShouldSerializeweight() { return false; }

			[JsonIgnore]
			public override string Code => nameof(MooringShackle);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..MooringShackle._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..MooringShackle._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..MooringShackle._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ShackleConnection),
					role = Enum.GetName<Role>(Role.shackleToBuoyconnectedTo)!,
					featureTypes = [nameof(GenericBuoy)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ShackleToBridleConnection),
					role = Enum.GetName<Role>(Role.shackleToBridleconnectedTo)!,
					featureTypes = [nameof(Bridle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BridleCableConnection),
					role = Enum.GetName<Role>(Role.bridleattached)!,
					featureTypes = [nameof(CableSubmarine)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ShackleToSwivelConnection),
					role = Enum.GetName<Role>(Role.shackleToSwivelconnectedTo)!,
					featureTypes = [nameof(Swivel)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(ShackleToAnchorConnection),
					role = Enum.GetName<Role>(Role.shackleToAnchorconnectedTo)!,
					featureTypes = [nameof(SinkerAnchor)],
				},
			];
		}

		/// <summary>
		/// An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the sea floor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableSubmarine : AidsToNavigation {
			public CableDimensions? CableDimensions {get;set;} = default;
			public bool ShouldSerializeCableDimensions() { return false; }

			[EnumerationValue([1,3,4,5,6,7,8])]
			[Required()]
			public categoryOfCable categoryOfCable {get;set;}

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CableSubmarine);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..CableSubmarine._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..CableSubmarine._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..CableSubmarine._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(BridleCableConnection),
					role = Enum.GetName<Role>(Role.cableholds)!,
					featureTypes = [nameof(Bridle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(SwivelCableConnection),
					role = Enum.GetName<Role>(Role.cableholds)!,
					featureTypes = [nameof(Swivel)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(ShackleConnectionFromCable),
					role = Enum.GetName<Role>(Role.shackleToCableconnected)!,
					featureTypes = [nameof(MooringShackle)],
				},
			];
		}

		/// <summary>
		/// A chain link that provides for rotary motion between the lengths of chain that it connects. (IALA Dictionary, 8-5-165)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Swivel : AidsToNavigation {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;
			public bool ShouldSerializenatureOfConstruction() { return false; }

			public decimal? weight {get;set;} = default;
			public bool ShouldSerializeweight() { return false; }

			public String? swivelType {get;set;} = default;
			public bool ShouldSerializeswivelType() { return false; }

			[JsonIgnore]
			public override string Code => nameof(Swivel);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..Swivel._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..Swivel._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Swivel._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(SwivelConnection),
					role = Enum.GetName<Role>(Role.swivelholds)!,
					featureTypes = [nameof(Bridle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(SwivelCableConnection),
					role = Enum.GetName<Role>(Role.swivelattached)!,
					featureTypes = [nameof(CableSubmarine)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(ShackleToSwivelConnection),
					role = Enum.GetName<Role>(Role.shackleToSwivelconnected)!,
					featureTypes = [nameof(MooringShackle)],
				},
			];
		}

		/// <summary>
		/// Two lengths of chain connected by a central ring and used for lifting wide loads. (IALA Dictionary,8-3-195)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bridle : AidsToNavigation {
			public String? bridleLinkType {get;set;} = default;
			public bool ShouldSerializebridleLinkType() { return false; }

			public String? legsDetails {get;set;} = default;
			public bool ShouldSerializelegsDetails() { return false; }

			[JsonIgnore]
			public override string Code => nameof(Bridle);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..Bridle._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..Bridle._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Bridle._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(BridleConnection),
					role = Enum.GetName<Role>(Role.bridleholds)!,
					featureTypes = [nameof(GenericBuoy)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(SwivelConnection),
					role = Enum.GetName<Role>(Role.bridlehangs)!,
					featureTypes = [nameof(Swivel)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(ShackleToBridleConnection),
					role = Enum.GetName<Role>(Role.shackleToBridleconnected)!,
					featureTypes = [nameof(MooringShackle)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BridleCableConnection),
					role = Enum.GetName<Role>(Role.bridleattached)!,
					featureTypes = [nameof(CableSubmarine)],
				},
			];
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CounterWeight : AidsToNavigation {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;
			public bool ShouldSerializenatureOfConstruction() { return false; }

			[Required()]
			public decimal weight {get;set;}

			public String? counterWeightType {get;set;} = default;
			public bool ShouldSerializecounterWeightType() { return false; }

			[JsonIgnore]
			public override string Code => nameof(CounterWeight);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..CounterWeight._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..CounterWeight._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..CounterWeight._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(BuoyCounterWeight),
					role = Enum.GetName<Role>(Role.counterWeightholds)!,
					featureTypes = [nameof(GenericBuoy)],
				},
			];
		}

		/// <summary>
		/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification. (IHO Dictionary, S-32, 5th Edition, 5548)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Topmark : AidsToNavigation {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
			[Required()]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}

			public decimal? verticalLength {get;set;} = default;
			public bool ShouldSerializeverticalLength() { return false; }

			[JsonIgnore]
			public override string Code => nameof(Topmark);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..AidsToNavigation._informationBindingDefinitions, ..Topmark._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..AidsToNavigation._featureBindingDefinitions, ..Topmark._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..AidsToNavigation._primitives, ..Topmark._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  1,
					association = nameof(BuoyTopmark),
					role = Enum.GetName<Role>(Role.buoyPart)!,
					featureTypes = [nameof(GenericBuoy)],
				},
			];
		}

		/// <summary>
		/// A safe water beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). A safe water beacon may be used to indicate that there is navigable water around the mark. (UKHO NP735, 5th Edition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBeacon : GenericBeacon {
			[JsonIgnore]
			public override string Code => nameof(SafeWaterBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..SafeWaterBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..SafeWaterBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..SafeWaterBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners. (UKHO NP 735, 5th Edition) Beacon in general: A beacon whose appearance or purpose is not adequately known.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBeacon : GenericBeacon {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBeacon);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBeacon._informationBindingDefinitions, ..SpecialPurposeGeneralBeacon._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBeacon._featureBindingDefinitions, ..SpecialPurposeGeneralBeacon._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBeacon._primitives, ..SpecialPurposeGeneralBeacon._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A safe water buoy is used to indicate that there is navigable water around the mark. (UKHO NP735, 5th Edition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBuoy : GenericBuoy {
			[JsonIgnore]
			public override string Code => nameof(SafeWaterBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..SafeWaterBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..SafeWaterBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..SafeWaterBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners. (UKHO NP 735, 5th Edition) Buoy in general: A buoy whose appearance or purpose is not adequately known.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBuoy : GenericBuoy {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBuoy);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => [..GenericBuoy._informationBindingDefinitions, ..SpecialPurposeGeneralBuoy._informationBindingDefinitions];
			public new static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => [..GenericBuoy._featureBindingDefinitions, ..SpecialPurposeGeneralBuoy._featureBindingDefinitions];

			[JsonIgnore]
			public override Primitives[] primitives => [..GenericBuoy._primitives, ..SpecialPurposeGeneralBuoy._primitives];
			public new static Primitives[] _primitives => [
				Primitives.point
			];

			public new static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DangerousFeature : FeatureNode, IFeatureBindingDefinition {
			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DangerousFeature);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => DangerousFeature._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => DangerousFeature._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => DangerousFeature._primitives;
			public static Primitives[] _primitives => [
				Primitives.point
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 1,
					upper =  default,
					association = nameof(DangerousFeatureAssociation),
					role = Enum.GetName<Role>(Role.markingAton)!,
					featureTypes = [nameof(AtonAssociation)],
				},
			];
		}

		/// <summary>
		/// Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAggregation : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([1,3,2])]
			[Required()]
			public CategoryOfAggregation CategoryOfAggregation {get;set;}

			[JsonIgnore]
			public override string Code => nameof(AtonAggregation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtonAggregation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AtonAggregation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AtonAggregation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonAggregations),
					role = Enum.GetName<Role>(Role.atonAggregationBy)!,
					featureTypes = [nameof(AidsToNavigation)],
				},
			];
		}

		/// <summary>
		/// Used to identify an association between two or more objects. The association may be named content of categoryOfAssociation should be put in information attribute when converting to S-57
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAssociation : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([1,2])]
			[Required()]
			public CategoryOfAssociation CategoryOfAssociation {get;set;}

			[JsonIgnore]
			public override string Code => nameof(AtonAssociation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtonAssociation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => AtonAssociation._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => AtonAssociation._primitives;
			public static Primitives[] _primitives => [
				Primitives.noGeometry
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DangerousFeatureAssociation),
					role = Enum.GetName<Role>(Role.danger)!,
					featureTypes = [nameof(DangerousFeature)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonAssociations),
					role = Enum.GetName<Role>(Role.atonAssociationBy)!,
					featureTypes = [nameof(AidsToNavigation)],
				},
			];
		}

		/// <summary>
		/// An area within which a uniform assessment of the quality of the non-bathymetric data exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfNonBathymetricData : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([1,2,3,4,5,6])]
			[Required()]
			public categoryOfTemporalVariation categoryOfTemporalVariation {get;set;}

			public decimal? orientationUncertainty {get;set;} = default;
			public bool ShouldSerializeorientationUncertainty() { return false; }

			public decimal? horizontalDistanceUncertainty {get;set;} = default;
			public bool ShouldSerializehorizontalDistanceUncertainty() { return false; }

			[Required()]
			public horizontalPositionUncertainty horizontalPositionUncertainty {get;set;}

			public information? information {get;set;} = default;
			public bool ShouldSerializeinformation() { return false; }

			public String? informationInNationalLanguage {get;set;} = default;
			public bool ShouldSerializeinformationInNationalLanguage() { return false; }

			public textualDescription? textualDescription {get;set;} = default;
			public bool ShouldSerializetextualDescription() { return false; }

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
			public bool ShouldSerializeverticalUncertainty() { return false; }

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

			[JsonIgnore]
			public override Primitives[] primitives => DataCoverage._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// An area within which the navigational system of marks has been established in relation to a specific direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocalDirectionOfBuoyage : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public orientation orientation {get;set;}

			[JsonIgnore]
			public override string Code => nameof(LocalDirectionOfBuoyage);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => LocalDirectionOfBuoyage._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => LocalDirectionOfBuoyage._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => LocalDirectionOfBuoyage._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// An area within which the navigational system of marks has been established in relation to a specific direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationalSystemOfMarks : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([1,2,9,10,11,12,13,15])]
			[Required()]
			public marksNavigationalSystemOf marksNavigationalSystemOf {get;set;}

			[JsonIgnore]
			public override string Code => nameof(NavigationalSystemOfMarks);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => NavigationalSystemOfMarks._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			public override featureBindingDefinition[] featureBindingDefinitions => NavigationalSystemOfMarks._featureBindingDefinitions;

			[JsonIgnore]
			public override Primitives[] primitives => NavigationalSystemOfMarks._primitives;
			public static Primitives[] _primitives => [
				Primitives.surface
			];

			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		/// <summary>
		/// The horizontal plane or tidal datum to which soundings have been reduced. Also called datum for sounding reduction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SoundingDatum : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Required()]
			public verticalDatum verticalDatum {get;set;}

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
		}

		/// <summary>
		/// Any level surface (for example Mean Sea Level) taken as a surface of reference to which the elevations within a data set are reduced. Also called datum level, reference level, reference plane, levelling datum, datum for heights.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VerticalDatumOfData : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			[Required()]
			public verticalDatum verticalDatum {get;set;}

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
		}
	}

	[XmlType(Namespace = "http://www.iho.int/S201/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
	}

	[XmlType(Namespace = "http://www.iho.int/S201/2.0", TypeName = "members")]
	public class Members : S100Framework.DomainModel.S100.MembersBase
	{
		[XmlElement("InformationTypes.AtoNFixingMethod", typeof(InformationTypes.AtoNFixingMethod), Order = 1)]
		[XmlElement("InformationTypes.AtonStatusInformation", typeof(InformationTypes.AtonStatusInformation), Order = 1)]
		[XmlElement("InformationTypes.PositioningInformation", typeof(InformationTypes.PositioningInformation), Order = 1)]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1)]
		[XmlElement("FeatureTypes.Landmark", typeof(FeatureTypes.Landmark), Order = 1)]
		[XmlElement("FeatureTypes.LateralBeacon", typeof(FeatureTypes.LateralBeacon), Order = 1)]
		[XmlElement("FeatureTypes.LateralBuoy", typeof(FeatureTypes.LateralBuoy), Order = 1)]
		[XmlElement("FeatureTypes.NavigationLine", typeof(FeatureTypes.NavigationLine), Order = 1)]
		[XmlElement("FeatureTypes.RecommendedTrack", typeof(FeatureTypes.RecommendedTrack), Order = 1)]
		[XmlElement("FeatureTypes.LightSectored", typeof(FeatureTypes.LightSectored), Order = 1)]
		[XmlElement("FeatureTypes.LightAllAround", typeof(FeatureTypes.LightAllAround), Order = 1)]
		[XmlElement("FeatureTypes.LightAirObstruction", typeof(FeatureTypes.LightAirObstruction), Order = 1)]
		[XmlElement("FeatureTypes.LightFogDetector", typeof(FeatureTypes.LightFogDetector), Order = 1)]
		[XmlElement("FeatureTypes.RadarReflector", typeof(FeatureTypes.RadarReflector), Order = 1)]
		[XmlElement("FeatureTypes.FogSignal", typeof(FeatureTypes.FogSignal), Order = 1)]
		[XmlElement("FeatureTypes.EnvironmentObservationEquipment", typeof(FeatureTypes.EnvironmentObservationEquipment), Order = 1)]
		[XmlElement("FeatureTypes.RadioStation", typeof(FeatureTypes.RadioStation), Order = 1)]
		[XmlElement("FeatureTypes.Daymark", typeof(FeatureTypes.Daymark), Order = 1)]
		[XmlElement("FeatureTypes.Retroreflector", typeof(FeatureTypes.Retroreflector), Order = 1)]
		[XmlElement("FeatureTypes.RadarTransponderBeacon", typeof(FeatureTypes.RadarTransponderBeacon), Order = 1)]
		[XmlElement("FeatureTypes.VirtualAISAidToNavigation", typeof(FeatureTypes.VirtualAISAidToNavigation), Order = 1)]
		[XmlElement("FeatureTypes.PhysicalAISAidToNavigation", typeof(FeatureTypes.PhysicalAISAidToNavigation), Order = 1)]
		[XmlElement("FeatureTypes.SyntheticAISAidToNavigation", typeof(FeatureTypes.SyntheticAISAidToNavigation), Order = 1)]
		[XmlElement("FeatureTypes.PowerSource", typeof(FeatureTypes.PowerSource), Order = 1)]
		[XmlElement("FeatureTypes.IsolatedDangerBeacon", typeof(FeatureTypes.IsolatedDangerBeacon), Order = 1)]
		[XmlElement("FeatureTypes.CardinalBeacon", typeof(FeatureTypes.CardinalBeacon), Order = 1)]
		[XmlElement("FeatureTypes.IsolatedDangerBuoy", typeof(FeatureTypes.IsolatedDangerBuoy), Order = 1)]
		[XmlElement("FeatureTypes.CardinalBuoy", typeof(FeatureTypes.CardinalBuoy), Order = 1)]
		[XmlElement("FeatureTypes.InstallationBuoy", typeof(FeatureTypes.InstallationBuoy), Order = 1)]
		[XmlElement("FeatureTypes.MooringBuoy", typeof(FeatureTypes.MooringBuoy), Order = 1)]
		[XmlElement("FeatureTypes.EmergencyWreckMarkingBuoy", typeof(FeatureTypes.EmergencyWreckMarkingBuoy), Order = 1)]
		[XmlElement("FeatureTypes.Lighthouse", typeof(FeatureTypes.Lighthouse), Order = 1)]
		[XmlElement("FeatureTypes.LightFloat", typeof(FeatureTypes.LightFloat), Order = 1)]
		[XmlElement("FeatureTypes.LightVessel", typeof(FeatureTypes.LightVessel), Order = 1)]
		[XmlElement("FeatureTypes.OffshorePlatform", typeof(FeatureTypes.OffshorePlatform), Order = 1)]
		[XmlElement("FeatureTypes.SiloTank", typeof(FeatureTypes.SiloTank), Order = 1)]
		[XmlElement("FeatureTypes.Pile", typeof(FeatureTypes.Pile), Order = 1)]
		[XmlElement("FeatureTypes.Building", typeof(FeatureTypes.Building), Order = 1)]
		[XmlElement("FeatureTypes.Bridge", typeof(FeatureTypes.Bridge), Order = 1)]
		[XmlElement("FeatureTypes.SinkerAnchor", typeof(FeatureTypes.SinkerAnchor), Order = 1)]
		[XmlElement("FeatureTypes.MooringShackle", typeof(FeatureTypes.MooringShackle), Order = 1)]
		[XmlElement("FeatureTypes.CableSubmarine", typeof(FeatureTypes.CableSubmarine), Order = 1)]
		[XmlElement("FeatureTypes.Swivel", typeof(FeatureTypes.Swivel), Order = 1)]
		[XmlElement("FeatureTypes.Bridle", typeof(FeatureTypes.Bridle), Order = 1)]
		[XmlElement("FeatureTypes.CounterWeight", typeof(FeatureTypes.CounterWeight), Order = 1)]
		[XmlElement("FeatureTypes.Topmark", typeof(FeatureTypes.Topmark), Order = 1)]
		[XmlElement("FeatureTypes.SafeWaterBeacon", typeof(FeatureTypes.SafeWaterBeacon), Order = 1)]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBeacon", typeof(FeatureTypes.SpecialPurposeGeneralBeacon), Order = 1)]
		[XmlElement("FeatureTypes.SafeWaterBuoy", typeof(FeatureTypes.SafeWaterBuoy), Order = 1)]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBuoy", typeof(FeatureTypes.SpecialPurposeGeneralBuoy), Order = 1)]
		[XmlElement("FeatureTypes.DangerousFeature", typeof(FeatureTypes.DangerousFeature), Order = 1)]
		[XmlElement("FeatureTypes.AtonAggregation", typeof(FeatureTypes.AtonAggregation), Order = 1)]
		[XmlElement("FeatureTypes.AtonAssociation", typeof(FeatureTypes.AtonAssociation), Order = 1)]
		[XmlElement("FeatureTypes.QualityOfNonBathymetricData", typeof(FeatureTypes.QualityOfNonBathymetricData), Order = 1)]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1)]
		[XmlElement("FeatureTypes.LocalDirectionOfBuoyage", typeof(FeatureTypes.LocalDirectionOfBuoyage), Order = 1)]
		[XmlElement("FeatureTypes.NavigationalSystemOfMarks", typeof(FeatureTypes.NavigationalSystemOfMarks), Order = 1)]
		[XmlElement("FeatureTypes.SoundingDatum", typeof(FeatureTypes.SoundingDatum), Order = 1)]
		[XmlElement("FeatureTypes.VerticalDatumOfData", typeof(FeatureTypes.VerticalDatumOfData), Order = 1)]
		public override List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
