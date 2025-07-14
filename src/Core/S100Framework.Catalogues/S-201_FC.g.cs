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
	public enum ChangeTypes : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Advanced notice of changes")] 
		[XmlEnum("1")] 
		AdvancedNoticeOfChanges = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Discrepancy")] 
		[XmlEnum("2")] 
		Discrepancy = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Proposed changes")] 
		[XmlEnum("3")] 
		ProposedChanges = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Temporary changes")] 
		[XmlEnum("4")] 
		TemporaryChanges = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum heightLengthUnits : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Metres")] 
		[XmlEnum("1")] 
		Metres = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Feet")] 
		[XmlEnum("2")] 
		Feet = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Kilometres")] 
		[XmlEnum("3")] 
		Kilometres = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Hectometres")] 
		[XmlEnum("4")] 
		Hectometres = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Statute Miles")] 
		[XmlEnum("5")] 
		StatuteMiles = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Nautical Miles")] 
		[XmlEnum("6")] 
		NauticalMiles = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum horizontalDatum : int {
		[System.ComponentModel.Description("AStandardForUseInCartographyGeodesyAndSatelliteNavigationIncludingGpsThisStandardIncludesTheDefinitionOfTheCoordinateSystemSFundamentalAndDerivedConstantsTheEllipsoidalNormalEarthGravitationalModelEgmADescriptionOfTheAssociatedWorldMagneticModelWmmAndACurrentListOfLocalDatumTransformationsTheWgs72IsBasedOnSelectedSatelliteSurfaceGravityAndAstrogeodeticDataAvailableThrough1972")]
		[EnumMember(Value = "WGS 72")] 
		[XmlEnum("1")] 
		Wgs72 = 1,

		[System.ComponentModel.Description("AStandardForUseInCartographyGeodesyAndSatelliteNavigationIncludingGpsThisStandardIncludesTheDefinitionOfTheCoordinateSystemSFundamentalAndDerivedConstantsTheEllipsoidalNormalEarthGravitationalModelEgmADescriptionOfTheAssociatedWorldMagneticModelWmmAndACurrentListOfLocalDatumTransformationsWgs84IsTheReferenceCoordinateSystemUsedByTheGlobalPositioningSystem")]
		[EnumMember(Value = "WGS 84")] 
		[XmlEnum("2")] 
		Wgs84 = 2,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1950SuitableForUseInEuropeWestAndorraCyprusDenmarkOnshoreAndOffshoreFaroeIslandsOnshoreFranceOffshoreGermanyOffshoreNorthSeaGibraltarGreeceOffshoreIsraelOffshoreItalyIncludingSanMarinoAndVaticanCityStateIrelandOffshoreMaltaNetherlandsOffshoreNorthSeaNorwayIncludingSvalbardOnshoreAndOffshorePortugalMainlandOffshoreSpainOnshoreTurkeyOnshoreAndOffshoreUnitedKingdomUkcsOffshoreEastOf6wIncludingChannelIslandsGuernseyAndJerseyEgyptWesternDesertIraqOnshoreJordanEuropeanDatum1950ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianEuropeanDatum1950OriginIsFundamentalPointPotsdamHelmertTowerLatitude5222514456NLongitude1303589283EOfGreenwichEuropeanDatum1950IsAGeodeticDatumForTopographicMappingGeodeticSurvey")]
		[EnumMember(Value = "European 1950")] 
		[XmlEnum("3")] 
		European1950 = 3,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1990SuitableForUseInGermanyThuringenPotsdamDatum83ReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianPotsdamDatum83OriginIsFundamentalPointRauenbergLatitude522712021NLongitude132204928EOfGreenwichThisStationWasDestroyedIn1910AndTheStationAtPotsdamSubstitutedAsTheFundamentalPointPotsdamDatum83IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromBkgViaEurogeographicsHttpCrsBkgBundDePd83IsTheRealisationOfDhdnInThuringenItIsTheResultantOfApplyingATransformationDerivedAt13PointsOnTheBorderBetweenEastAndWestGermanyToPulkovo194283PointsInThuringen")]
		[EnumMember(Value = "Potsdam Datum")] 
		[XmlEnum("4")] 
		PotsdamDatum = 4,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1958SuitableForUseInEritreaEthiopiaSouthSudanSudanAdindanReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianAdindanOriginIsFundamentalPointStation15AdindanLatitude221007110NLongitude312921608EOfGreenwichAdindanIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromUsCoastAndGeodeticSurveyViaGeophysicalReasearchVol6711October1962The12thParallelTraverseOf196670Point58DatumCode6620IsConnectedToTheBlueNile1958NetworkInWesternSudanThisHasGivenRiseToMisconceptionsThatTheBlueNileNetworkIsUsedInWestAfrica")]
		[EnumMember(Value = "Adindan")] 
		[XmlEnum("5")] 
		Adindan = 5,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedInAndSuitableForUseInSomaliaOnshoreAfgooyeReferencesTheKrassowsky1940EllipsoidAndTheGreenwichPrimeMeridianAfgooyeIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Afgooye")] 
		[XmlEnum("6")] 
		Afgooye = 6,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1970AndSuitableForUseInBahrainKuwaitAndSaudiArabiaOnshoreAinElAbd1970ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAinElAbd1970OriginIsFundamentalPointAinElAbdLatitude281406171NLongitude481620906EOfGreenwichAinElAbd1970IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Ain el Abd 1970")] 
		[XmlEnum("7")] 
		AinElAbd1970 = 7,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1965SuitableForUseInCocosKeelingIslandsOnshoreCocosIslands1965ReferencesTheAustralianNationalSpheroidEllipsoidAndTheGreenwichPrimeMeridianCocosIslands1965OriginIsFundamentalPointAnna1CocosIslands1965IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Anna 1 Astro 1965")] 
		[XmlEnum("8")] 
		Anna1Astro1965 = 8,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1943SuitableForUseInAntiguaIslandOnshoreAntigua1943ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianAntigua1943OriginIsFundamentalPointStationA14Antigua1943IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfGreatBritain")]
		[EnumMember(Value = "Antigua Island Astro 1943")] 
		[XmlEnum("9")] 
		AntiguaIslandAstro1943 = 9,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1950SuitableForUseInBotswanaMalawiZambiaZimbabweArc1950ReferencesTheClarke1880ArcEllipsoidAndTheGreenwichPrimeMeridianArc1950OriginIsFundamentalPointBuffelsfonteinLatitude335932000SLongitude253044622EOfGreenwichArc1950IsAGeodeticDatumForTopographicMappingGeodeticSurvey")]
		[EnumMember(Value = "Arc 1950")] 
		[XmlEnum("10")] 
		Arc1950 = 10,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1960SuitableForUseInKenyaTanzaniaUgandaArc1960ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianArc1960OriginIsFundamentalPointBuffelsfonteinLatitude335932000SLongitude253044622EOfGreenwichArc1960IsAGeodeticDatumForTopographicMappingGeodeticSurvey")]
		[EnumMember(Value = "Arc 1960")] 
		[XmlEnum("11")] 
		Arc1960 = 11,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1958SuitableForUseInStHelenaAscensionAndTristanDaCunhaAscensionIslandOnshoreAscensionIsland1958ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAscensionIsland1958IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Ascension Island 1958")] 
		[XmlEnum("12")] 
		AscensionIsland1958 = 12,

		[System.ComponentModel.Description("AstroBeaconE1945")]
		[EnumMember(Value = "Astro Beacon 'E' 1945")] 
		[XmlEnum("13")] 
		AstroBeaconE1945 = 13,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1971SuitableForUseInStHelenaAscensionAndTristanDaCunhaStHelenaIslandOnshoreAstroDos71ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAstroDos71OriginIsFundamentalPointDos714LadderHillFortLatitude155530SLongitude54325WOfGreenwichAstroDos71IsAGeodeticDatumForGeodeticControlMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000AndStHelenaGovernmentEnvironmentAndNaturalResourcesDirectorateEnrd")]
		[EnumMember(Value = "Astro DOS 71/4")] 
		[XmlEnum("14")] 
		AstroDos714 = 14,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1961SuitableForUseInUnitedStatesUsaHawaiiTernIslandAndSorelAtollTernIsland1961ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianTernIsland1961OriginIsFundamentalPointStationFrigOnTernIslandStationB4OnSorolAtollTernIsland1961IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr83502Original1987FirstEditionAnd3rdEditionAmendment13January2000TwoIndependentAstronomicDeterminationsConsideredToBeConsistentThroughAdoptionOfCommonTransformationToWgs84SeeTfmCode15795")]
		[EnumMember(Value = "Astro Tern Island (FRIG) 1961")] 
		[XmlEnum("15")] 
		AstroTernIslandFrig1961 = 15,

		[System.ComponentModel.Description("AstronomicalStation1952")]
		[EnumMember(Value = "Astronomical Station 1952")] 
		[XmlEnum("16")] 
		AstronomicalStation1952 = 16,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1966SuitableForUseInAustraliaOnshoreAndOffshorePapuaNewGuineaOnshoreAustralianGeodeticDatum1966ReferencesTheAustralianNationalSpheroidEllipsoidAndTheGreenwichPrimeMeridianAustralianGeodeticDatum1966OriginIsFundamentalPointJohnsonMemorialCairnLatitude2556545515SLongitude13312300771EOfGreenwichAustralianGeodeticDatum1966IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromAustralianMapGridTechnicalManualNationalMappingCouncilOfAustraliaTechnicalPublication71972")]
		[EnumMember(Value = "Australian Geodetic 1966")] 
		[XmlEnum("17")] 
		AustralianGeodetic1966 = 17,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1984SuitableForUseInAustraliaQueenslandSouthAustraliaWesternAustraliaFederalAreasOffshoreWestOf129eAustralianGeodeticDatum1984ReferencesTheAustralianNationalSpheroidEllipsoidAndTheGreenwichPrimeMeridianAustralianGeodeticDatum1984OriginIsFundamentalPointJohnsonMemorialCairnLatitude2556545515SLongitude13312300771EOfGreenwichAustralianGeodeticDatum1984IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromGdaTechnicalManualV2_2IntergovernmentalCommitteeOnSurveyingAndMappingWwwAnzlicOrgAuIcsmGdtmUsesAllDataFrom1966AdjustmentWithAdditionalObservationsImprovedSoftwareAndAGeoidModel")]
		[EnumMember(Value = "Australian Geodetic 1984")] 
		[XmlEnum("18")] 
		AustralianGeodetic1984 = 18,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInDjiboutiOnshoreAndOffshoreAyabelleLighthouseReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianAyabelleLighthouseOriginIsFundamentalPointAyabelleLighthouseAyabelleLighthouseIsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Ayabelle Lighthouse")] 
		[XmlEnum("19")] 
		AyabelleLighthouse = 19,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1960SuitableForUseInVanuatuSouthernIslandsAneityumEfateErromangoAndTannaBellevueReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianBellevueIsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000DatumCoversAllTheMajorIslandsOfVanuatuInTwoDifferentAdjustmentBlocksButPracticalUsageIsAsGivenInTheAreaOfUse")]
		[EnumMember(Value = "Bellevue (IGN)")] 
		[XmlEnum("20")] 
		BellevueIgn = 20,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1957SuitableForUseInBermudaOnshoreBermuda1957ReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianBermuda1957OriginIsFundamentalPointFortGeorgeBaseLatitude32224436NLongitude64405811WOfGreenwichBermuda1957IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromVariousOilIndustrySources")]
		[EnumMember(Value = "Bermuda 1957")] 
		[XmlEnum("21")] 
		Bermuda1957 = 21,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedInAndIsSuitableForUseInGuineaBissauOnshoreBissauReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianBissauOriginIsBissauIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaTr83502Ftp164214265PubGigTr83502ChangesPdf")]
		[EnumMember(Value = "Bissau")] 
		[XmlEnum("22")] 
		Bissau = 22,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1975SuitableForUseInColombiaMainlandAndOffshoreCaribbeanBogota1975ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianBogota1975OriginIsFundamentalPointBogotaObservatoryLatitude43556570NLongitude740451300WOfGreenwichBogota1975IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoAgustinCodazziIgacSpecialPublicationNo14thEdition1975GeodesiaResultadosDefinitvosDeParteDeLasRedesGeodesicasEstablecidasEnElPaisReplaces1951AdjustmentReplacedByMagnaSirgasDatumCode6685")]
		[EnumMember(Value = "Bogota Observatory")] 
		[XmlEnum("23")] 
		BogotaObservatory = 23,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInIndonesiaBangaAndBelitungIslandsBukitRimpahReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianBukitRimpahOriginIs2004016S105513976EOfGreenwichBukitRimpahIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Bukit Rimpah")] 
		[XmlEnum("24")] 
		BukitRimpah = 24,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInAntarcticaMcmurdoSoundCampMcmurdoAreaCampAreaAstroReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianCampAreaAstroIsAGeodeticDatumForGeodeticAndTopographicSurveyItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Camp Area Astro")] 
		[XmlEnum("25")] 
		CampAreaAstro = 25,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInArgentinaMainlandOnshoreAndAtlanticOffshoreTierraDelFuegoCampoInchauspeReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianCampoInchauspeOriginIsFundamentalPointCampoInchauspeLatitude35581656SLongitude62101203WOfGreenwichCampoInchauspeIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Campo Inchauspe 1969")] 
		[XmlEnum("26")] 
		CampoInchauspe1969 = 26,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1966SuitableForUseInKiribatiPhoenixIslandsKantonOronaMckeanAtollBirnieAtollPhoenixSeamountsPhoenixIslands1966ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianPhoenixIslands1966IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Canton Astro 1966")] 
		[XmlEnum("27")] 
		CantonAstro1966 = 27,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInBotswanaLesothoSouthAfricaMainlandSwazilandCapeReferencesTheClarke1880ArcEllipsoidAndTheGreenwichPrimeMeridianCapeOriginIsFundamentalPointBuffelsfonteinLatitude335932000SLongitude253044622EOfGreenwichCapeIsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromPrivateCommunicationDirectorateOfSurveysAndLandInformationCapeTown")]
		[EnumMember(Value = "Cape Datum")] 
		[XmlEnum("28")] 
		CapeDatum = 28,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1963SuitableForUseInNorthAmericaOnshoreBahamasAndUsaFloridaEastCapeCanaveralReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianCapeCanaveralOriginIsFundamentalPointCentral1950Latitude28293236555NLongitude80343877362WOfGreenwichCapeCanaveralIsAGeodeticDatumForUsSpaceAndMilitaryOperationsItWasDefinedByInformationFromUsNgsAndDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Cape Canaveral")] 
		[XmlEnum("29")] 
		CapeCanaveral = 29,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1925SuitableForUseInTunisiaOnshoreAndOffshoreCarthageReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianCarthageOriginIsFundamentalPointCarthageLatitude409464506g36510650NLongitude88724368gEOfParis10192072EOfGreenwichCarthageIsAGeodeticDatumForTopographicMappingFundamentalPointAstronomicCoordinatesDeterminedIn1878")]
		[EnumMember(Value = "Carthage")] 
		[XmlEnum("30")] 
		Carthage = 30,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1971SuitableForUseInNewZealandChathamIslandsGroupOnshoreChathamIslandsDatum1971ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianChathamIslandsDatum1971IsAGeodeticDatumForGeodeticSurveyTopographicMappingEngineeringSurveyItWasDefinedByInformationFromOfficeOfSurveyorGeneralOsgTechnicalReport14June2001ReplacedByChathamIslandsDatum1979Code6673")]
		[EnumMember(Value = "Chatam Island Astro 1971")] 
		[XmlEnum("31")] 
		ChatamIslandAstro1971 = 31,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInBrazilSouthOf18sAndWestOf54wPlusDistritoFederalParaguayNorthChuaReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianChuaOriginIsFundamentalPointChuaLatitude194541160SLongitude480607560WOfGreenwichChuaIsAGeodeticDatumForGeodeticSurveyItWasDefinedByInformationFromNimaHttpEarthInfoNimaMilTheChuaOriginAndAssociatedNetworkIsInBrazilWithAConnectingTraverseThroughNorthernParaguayItWasUsedInBrazilOnlyAsInputIntoTheCorregoAllegreAdjustmentAndForGovernmentWorkInDistritoFederal")]
		[EnumMember(Value = "Chua Astro")] 
		[XmlEnum("32")] 
		ChuaAstro = 32,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1972SuitableForUseInBrazilOnshoreWestOf54wAndSouthOf18sAlsoSouthOf15sBetween54wAnd42wAlsoEastOf42wCorregoAlegre197072ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianCorregoAlegre197072OriginIsFundamentalPointCorregoAlegreLatitude19501491SLongitude48574198WOfGreenwichCorregoAlegre197072IsAGeodeticDatumForTopographicMappingGeodeticSurveySupersededBySad69ItWasDefinedByInformationFromIbgeReplaces1961AdjustmentDatumCode1074NimaGivesCoordinatesOfOriginAsLatitude19501514SLongitude48574275WTheseMayReferTo1961Adjustment")]
		[EnumMember(Value = "Corrego Alegre")] 
		[XmlEnum("33")] 
		CorregoAlegre = 33,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1981SuitableForUseInGuineaOnshoreDabola1981ReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianDabola1981IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromIgnParis")]
		[EnumMember(Value = "Dabola")] 
		[XmlEnum("34")] 
		Dabola = 34,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInIndonesiaOnshoreJavaAndBaliBataviaJakartaReferencesTheBessel1841EllipsoidAndTheJakartaPrimeMeridianBataviaJakartaOriginIsFundamentalPointLongitudeAtBataviaAstronomicalStationLatitude60739522SLongitude000000EOfJakartaLatitudeAndAzimuthAtGenukBataviaJakartaIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Djakarta (Batavia)")] 
		[XmlEnum("35")] 
		DjakartaBatavia = 35,

		[System.ComponentModel.Description("Dos1968")]
		[EnumMember(Value = "DOS 1968")] 
		[XmlEnum("36")] 
		Dos1968 = 36,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1967SuitableForUseInChileEasterIslandOnshoreEasterIsland1967ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianEasterIsland1967IsAGeodeticDatumForMilitaryAndTopographicMapping25MetersInEachComponentItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Easter Island 1967")] 
		[XmlEnum("37")] 
		EasterIsland1967 = 37,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1979SuitableForUseInEuropeWestEuropeanDatum1979ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianEuropeanDatum1979OriginIsFundamentalPointPotsdamHelmertTowerLatitude5222514456NLongitude1303589283EOfGreenwichEuropeanDatum1979IsAGeodeticDatumForScientificNetworkReplacedBy1987Adjustment")]
		[EnumMember(Value = "European 1979")] 
		[XmlEnum("38")] 
		European1979 = 38,

		[System.ComponentModel.Description("FortThomas1955Datum")]
		[EnumMember(Value = "Fort Thomas 1955")] 
		[XmlEnum("39")] 
		FortThomas1955 = 39,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1970SuitableForUseInMaldivesOnshoreGan1970ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianGan1970IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromVariousIndustrySourcesInSomeReferencesIncorrectlyNamedGandajika1970")]
		[EnumMember(Value = "Gan 1970")] 
		[XmlEnum("40")] 
		Gan1970 = 40,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1949SuitableForUseInNewZealandNorthIslandSouthIslandStewartIslandOnshoreAndNearshoreNewZealandGeodeticDatum1949ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianNewZealandGeodeticDatum1949OriginIsFundamentalPointPapatahiLatitude41198900SLongitude1750251000EOfGreenwichNewZealandGeodeticDatum1949IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromLandInformationNewZealandHttpWwwLinzGovtNzRcsLinzPubWebRootCoreSurveysystemGeodeticinfoGeodeticdatumsNzgd2000factsheetIndexJspReplacedByNewZealandGeodeticDatum2000Code6167FromMarch2000")]
		[EnumMember(Value = "Geodetic Datum 1949")] 
		[XmlEnum("41")] 
		GeodeticDatum1949 = 41,

		[System.ComponentModel.Description("GraciosaBaseSw1948Datum")]
		[EnumMember(Value = "Graciosa Base SW 1948")] 
		[XmlEnum("42")] 
		GraciosaBaseSw1948 = 42,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1963SuitableForUseInGuamOnshoreGuam1963ReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianGuam1963OriginIsFundamentalPointTagchaLatitude13223849NLongitude144455156EOfGreenwichGuam1963IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromUsNationalGeospatialIntelligenceAgencyNgaHttpEarthInfoNgaMilReplacedByNad83Harn")]
		[EnumMember(Value = "Guam 1963")] 
		[XmlEnum("43")] 
		Guam1963 = 43,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInIndonesiaKalimantanOnshoreEastCoastalAreaIncludingMahakamDeltaCoastalAndOffshoreShelfAreasGunungSegaraReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianGunungSegaraOriginIsStationP5GunungSegaraLatitude0321283SLongitude117084847EOfGreenwichGunungSegaraIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromTotalfinaelf")]
		[EnumMember(Value = "Gunung Segara")] 
		[XmlEnum("44")] 
		GunungSegara = 44,

		[System.ComponentModel.Description("Gux1AstroDatum")]
		[EnumMember(Value = "GUX 1 Astro")] 
		[XmlEnum("45")] 
		Gux1Astro = 45,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInAfghanistanHeratNorthReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianHeratNorthOriginIsFundamentalPointHeratNorthLatitude34230908NLongitude64105894EOfGreenwichHeratNorthIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Herat North")] 
		[XmlEnum("46")] 
		HeratNorth = 46,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1955SuitableForUseInIcelandOnshoreHjorsey1955ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianHjorsey1955OriginIsFundamentalPointLatitude64312926NLongitude22220584WOfGreenwichHjorsey1955IsAGeodeticDatumFor150000ScaleTopographicMappingItWasDefinedByInformationFromLandmaelingarIslandsNationalSurveyOfIceland")]
		[EnumMember(Value = "Hjorsey 1955")] 
		[XmlEnum("47")] 
		Hjorsey1955 = 47,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1963SuitableForUseInChinaHongKongOnshoreAndOffshoreHongKong1963ReferencesTheClarke1858EllipsoidAndTheGreenwichPrimeMeridianHongKong1963OriginIsFundamentalPointTrigZero384FeetSouthAlongTheTransitCircleOfTheKowloonObservatoryLatitude22181282NLongitude114101875EOfGreenwichHongKong1963IsAGeodeticDatumForTopographicMappingAndHydrographicChartingItWasDefinedByInformationFromSurveyAndMappingOfficeLandsDepartmentHttpWwwInfoGovHkLandsdReplacedByHongKong196367ForMilitaryPurposesOnlyIn1967ReplacedByHongKong1980")]
		[EnumMember(Value = "Hong Kong 1963")] 
		[XmlEnum("48")] 
		HongKong1963 = 48,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1950SuitableForUseInTaiwanRepublicOfChinaOnshoreTaiwanIslandPenghuPescadoresIslandsHuTzuShan1950ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianHuTzuShan1950OriginIsFundamentalPointHuTzuShanLatitude23583234NLongitude1205825975EOfGreenwichHuTzuShan1950IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaUsNgaHttpEarthInfoNgaMilGandgIndexHtml")]
		[EnumMember(Value = "Hu-Tzu-Shan")] 
		[XmlEnum("49")] 
		HuTzuShan = 49,

		[System.ComponentModel.Description("IndianDatum")]
		[EnumMember(Value = "Indian")] 
		[XmlEnum("50")] 
		Indian = 50,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1954SuitableForUseInMyanmarBurmaOnshoreThailandOnshoreIndian1954ReferencesTheEverest18301937AdjustmentEllipsoidAndTheGreenwichPrimeMeridianIndian1954OriginIsExtensionOfKalianpur1937OverMyanmarAndThailandIndian1954IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Indian 1954")] 
		[XmlEnum("51")] 
		Indian1954 = 51,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1975SuitableForUseInThailandOnshorePlusOffshoreGulfOfThailandIndian1975ReferencesTheEverest18301937AdjustmentEllipsoidAndTheGreenwichPrimeMeridianIndian1975OriginIsFundamentalPointKhauSakaerangIndian1975IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Indian 1975")] 
		[XmlEnum("52")] 
		Indian1975 = 52,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1975SuitableForUseInIrelandOnshoreUnitedKingdomUkNorthernIrelandUlsterOnshoreIreland1965ReferencesTheAiryModified1849EllipsoidAndTheGreenwichPrimeMeridianIreland1965OriginIsAdjustedToBestMeanFit9StationsOfTheOsni1952PrimaryAdjustmentInNorthernIrelandPlusThe1965ValuesOf3StationsInTheRepublicOfIrelandIreland1965IsAGeodeticDatumForGeodeticSurveyTopographicMappingAndEngineeringSurveyItWasDefinedByInformationFromTheIrishGridADescriptionOfTheCoOrdinateReferenceSystemPublishedByOrdnanceSurveyOfIrelandDublinAndOrdnanceSurveyOfNorthernIrelandBelfastDifferencesFromThe1965AdjustmentDatumCode6299AreAverageDifferenceInEastings0092mAverageDifferenceInNorthings0108mMaximumVectorDifference0548m")]
		[EnumMember(Value = "Ireland 1965")] 
		[XmlEnum("53")] 
		Ireland1965 = 53,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1968SuitableForUseInSouthGeorgiaAndTheSouthSandwichIslandsSouthGeorgiaOnshoreIsts061Astro1968ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianIsts061Astro1968OriginIsFundamentalPointIsts061Ists061Astro1968IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "ISTS 061 Astro 1968")] 
		[XmlEnum("54")] 
		Ists061Astro1968 = 54,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1969SuitableForUseInBritishIndianOceanTerritoryChagosArchipelagoDiegoGarciaIsts073Astro1969ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianIsts073Astro1969OriginIsFundamentalPointIsts073Ists073Astro1969IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "ISTS 073 Astro 1969")] 
		[XmlEnum("55")] 
		Ists073Astro1969 = 55,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1961SuitableForUseInUnitedStatesMinorOutlyingIslandsJohnstonIslandJohnstonIsland1961ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianJohnstonIsland1961IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Johnston Island 1961")] 
		[XmlEnum("56")] 
		JohnstonIsland1961 = 56,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1930SuitableForUseInSriLankaOnshoreKandawalaReferencesTheEverest18301937AdjustmentEllipsoidAndTheGreenwichPrimeMeridianKandawalaOriginIsFundamentalPointKandawalaLatitude71406838NLongitude795236670EKandawalaIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromAbeyratneFeatherstoneAndTantrigodaInSurveyReviewVol42No317July2010")]
		[EnumMember(Value = "Kandawala")] 
		[XmlEnum("57")] 
		Kandawala = 57,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1949SuitableForUseInFrenchSouthernTerritoriesKerguelenOnshoreReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianOriginIsK01949IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromIgnParis")]
		[EnumMember(Value = "Kerguelen Island 1949")] 
		[XmlEnum("58")] 
		KerguelenIsland1949 = 58,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1968SuitableForUseInMalaysiaWestMalaysiaOnshoreAndOffshoreEastCoastSingaporeOnshoreAndOffshoreKertau1968ReferencesTheEverest1830ModifiedEllipsoidAndTheGreenwichPrimeMeridianKertau1968OriginIsFundamentalPointKertauLatitude32750710NLongitude1023724550EOfGreenwichKertau1968IsAGeodeticDatumForGeodeticSurveyCadastreItWasDefinedByInformationFromDefenceGeographicCentreReplacesMrt48AndEarlierAdjustmentsAdoptsMetricConversionOf39370113InchesPerMetreNotUsedFor1969MetricationOfRsoGridSeeKertauRsoCode6751")]
		[EnumMember(Value = "Kertau 1968")] 
		[XmlEnum("59")] 
		Kertau1968 = 59,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1951SuitableForUseInFederatedStatesOfMicronesiaKosraeKusaieKusaie1951ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianKusaie1951IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Kusaie Astro 1951")] 
		[XmlEnum("60")] 
		KusaieAstro1951 = 60,

		[System.ComponentModel.Description("LC5Astro1961Datum")]
		[EnumMember(Value = "L. C. 5 Astro 1961")] 
		[XmlEnum("61")] 
		LC5Astro1961 = 61,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInGhanaOnshoreAndOffshoreLeigonReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianLeigonOriginIsFundamentalPointGcsStation121LeigonLatitude5385227NLongitude0114608WOfGreenwichLeigonIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyInternationalReplacedAccraDatumCode6168From1978CoordinatesAtLeigonFundamentalPointDefinedAsAccraDatumValuesForThatPoint")]
		[EnumMember(Value = "Leigon")] 
		[XmlEnum("62")] 
		Leigon = 62,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1964SuitableForUseInLiberiaOnshoreLiberia1964ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianLiberia1964OriginIsFundamentalPointRobertsfieldLatitude6135302NLongitude10213544WOfGreenwichLiberia1964IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Liberia 1964")] 
		[XmlEnum("63")] 
		Liberia1964 = 63,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1911SuitableForUseInPhilippinesOnshoreLuzonReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianLuzonOriginIsFundamentalPointBalacanLatitude133341000NLongitude1215203000EOfGreenwichLuzonIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromCoastAndGeodeticSurveyReplacedByPhilippineReferenceSystemOf1992DatumCode6683")]
		[EnumMember(Value = "Luzon")] 
		[XmlEnum("64")] 
		Luzon = 64,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1971SuitableForUseInSeychellesMaheIslandMahe1971ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianMahe1971OriginIsFundamentalPointStationSiteLatitude44014644SLongitude552844488EOfGreenwichMahe1971IsAGeodeticDatumForUsMilitarySurveyItWasDefinedByInformationFromCliffordMugnierSSeptember2007PeRsGridsAndDatumsArticleOnSeychellesWwwAsprsOrgResourcesGridsSouthEastIsland1943DatumCode1138UsedForTopographicMappingCadastralAndHydrographicSurvey")]
		[EnumMember(Value = "Mahe 1971")] 
		[XmlEnum("65")] 
		Mahe1971 = 65,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInEritreaOnshoreAndOffshoreMassawaReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianMassawaIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Massawa")] 
		[XmlEnum("66")] 
		Massawa = 66,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1922SuitableForUseInMoroccoOnshoreMerchichReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianMerchichOriginIsFundamentalPointMerchichLatitude332659672NLongitude73327295WOfGreenwichMerchichIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Merchich")] 
		[XmlEnum("67")] 
		Merchich = 67,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1961SuitableForUseInUnitedStatesMinorOutlyingIslandsMidwayIslandsSandIslandAndEasternIslandMidway1961ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianMidway1961IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Midway Astro 1961")] 
		[XmlEnum("68")] 
		MidwayAstro1961 = 68,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInNigeriaOnshoreAndOffshoreMinnaReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianMinnaOriginIsFundamentalPointMinnaBaseStationL40Latitude9380887NLongitude6305876EOfGreenwichMinnaIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Minna")] 
		[XmlEnum("69")] 
		Minna = 69,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1958SuitableForUseInMontserratOnshoreMontserrat1958ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianMontserrat1958OriginIsFundamentalPointStationM36Montserrat1958IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfGreatBritain")]
		[EnumMember(Value = "Montserrat Island Astro 1958")] 
		[XmlEnum("70")] 
		MontserratIslandAstro1958 = 70,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInGabonOnshoreAndOffshoreMPoralokoReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianMPoralokoIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "M'poraloko")] 
		[XmlEnum("71")] 
		MPoraloko = 71,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1934SuitableForUseInIraqOnshoreIranOnshoreNorthernGulfCoastAndWestBorderingSoutheastIraqNahrwan1934ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianNahrwan1934OriginIsFundamentalPointNahrwanSouthBaseLatitude33191087NLongitude44432554EOfGreenwichNahrwan1934IsAGeodeticDatumForOilExplorationAndProductionItWasDefinedByInformationFromVariousIndustrySourcesThisAdjustmentLaterDiscoveredToHaveASignificantOrientationErrorInIranReplacedByFd58InIraqReplacedByKarbala1979")]
		[EnumMember(Value = "Nahrwan")] 
		[XmlEnum("72")] 
		Nahrwan = 72,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1972SuitableForUseInTrinidadAndTobagoTobagoOnshoreNaparima1972ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianNaparima1972OriginIsFundamentalPointNaparimaLatitude101644860NLongitude612734620WOfGreenwichNaparima1972IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyInternationalNaparima1972IsAnExtensionOfTheNaparima1955NetworkOfTrinidadToIncludeTobago")]
		[EnumMember(Value = "Naparima, BWI")] 
		[XmlEnum("73")] 
		NaparimaBwi = 73,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1927SuitableForUseInNorthAndCentralAmericaAntiguaAndBarbudaBahamasBelizeBritishVirginIslandssUsageShallBeOnshoreOnlyExceptThatOnshoreAndOffshoreShallApplyToCanadaEastCoastNewBrunswickNewfoundlandAndLabradorPrinceEdwardIslandQuebecCubaMexicoGulfOfMexicoAndCaribbeanCoastsOnlyUsaAlaskaUsaGulfOfMexicoAlabamaFloridaLouisianaMississippiTexasUsaEastCoastBahamasOnshorePlusOffshoreOverInternalContinentalShelfOnlyNorthAmericanDatum1927ReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianNorthAmericanDatum1927OriginIsFundamentalPointMeadeSRanchLatitude391326686NLongitude983230506WOfGreenwichNorthAmericanDatum1927IsAGeodeticDatumForTopographicMappingInUnitedStatesUsaAndCanadaReplacedByNorthAmericanDatum1983Nad83Code6269InMexicoReplacedByMexicanDatumOf1993Code1042")]
		[EnumMember(Value = "North American 1927")] 
		[XmlEnum("74")] 
		NorthAmerican1927 = 74,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1986SuitableForUseInNorthAmericaOnshoreAndOffshoreCanadaPuertoRicoUnitedStatesUsaUsVirginIslandsBritishVirginIslandsNorthAmericanDatum1983ReferencesTheGrs1980EllipsoidAndTheGreenwichPrimeMeridianNorthAmericanDatum1983OriginIsOriginAtGeocentreNorthAmericanDatum1983IsAGeodeticDatumForTopographicMappingAlthoughThe1986AdjustmentIncludedConnectionsToGreenlandAndMexicoItHasNotBeenAdoptedThereInCanadaAndUsReplacedNad27")]
		[EnumMember(Value = "North American 1983")] 
		[XmlEnum("75")] 
		NorthAmerican1983 = 75,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1939SuitableForUseInPortugalWesternAzoresOnshoreFloresCorvoAzoresOccidentalIslands1939ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAzoresOccidentalIslands1939OriginIsFundamentalPointObservatarioMeteorologicoFloresAzoresOccidentalIslands1939IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoECadastralLisbonViaEurogeographicsHttpCrsBkgBundDeCrsEu")]
		[EnumMember(Value = "Observatorio Meteorologico 1939")] 
		[XmlEnum("76")] 
		ObservatorioMeteorologico1939 = 76,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1907SuitableForUseInEgyptOnshoreAndOffshoreEgypt1907ReferencesTheHelmert1906EllipsoidAndTheGreenwichPrimeMeridianEgypt1907OriginIsFundamentalPointStationF1VenusLatitude30014286NLongitude31163360EOfGreenwichEgypt1907IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurvey")]
		[EnumMember(Value = "Old Egyptian 1907")] 
		[XmlEnum("77")] 
		OldEgyptian1907 = 77,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInUnitedStatesUsaHawaiiMainIslandsOnshoreOldHawaiianReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianOldHawaiianOriginIsFundamentalPointOahuWestBaseAstroLatitude21181389NLongitude157505579WOfGreenwichOldHawaiianIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromHttpWwwNgsNoaaGovNadconReadmeFileHawaiianIslandsWereNeverOnNad27ButRatherOnOldHawaiianDatumNadconConversionProgramProvidesTransformationFromOldHawaiianDatumToNad83Original1986RealizationButMakingTheTransformationAppearToUserAsIfFromNad27")]
		[EnumMember(Value = "Old Hawaiian")] 
		[XmlEnum("78")] 
		OldHawaiian = 78,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn2013SuitableForUseInOmanOnshoreAndOffshoreOmanNationalGeodeticDatum2014ReferencesTheGrs1980EllipsoidAndTheGreenwichPrimeMeridianOmanNationalGeodeticDatum2014OriginIs20StationsOfTheOmanPrimaryNetworkTiedToItrf2008AtEpoch201315OmanNationalGeodeticDatum2014IsAGeodeticDatumForGeodeticSurveyItWasDefinedByInformationFromNationalSurveyAuthoritySultanateOfOmanReplacesWgs84G874")]
		[EnumMember(Value = "Oman")] 
		[XmlEnum("79")] 
		Oman = 79,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1936SuitableForUseInUnitedKingdomUkOffshoreToBoundaryOfUkcsWithin4946NTo6101NAnd733WTo333EOnshoreGreatBritainEnglandWalesAndScotlandIsleOfManOnshoreOsgb1936ReferencesTheAiry1830EllipsoidAndTheGreenwichPrimeMeridianOsgb1936OriginIsPriorTo2002FundamentalPointHerstmonceuxLatitude505155271NLongitude02045882EOfGreenwichFromApril2002TheDatumIsDefinedThroughTheApplicationOfTheOstnTransformationFromEtrs89Osgb1936IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfGreatBritainTheAverageAccuracyOfOstnComparedToTheOldTriangulationNetworkDownTo3rdOrderIs01mWithTheIntroductionOfOstn15TheAreaForOsgb1936HasEffectivelyBeenExtendedFromBritainToCoverTheAdjacentUkContinentalShelf")]
		[EnumMember(Value = "Ordnance Survey of Great Britain 1936")] 
		[XmlEnum("80")] 
		OrdnanceSurveyOfGreatBritain1936 = 80,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInSpainCanaryIslandsOnshorePicoDeLasNieves1984ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianPicoDeLasNieves1984IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000ReplacesPicoDeLasNieves1968Pn68ReplacedByRegcan95")]
		[EnumMember(Value = "Pico de las Nieves")] 
		[XmlEnum("81")] 
		PicoDeLasNieves = 81,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1967SuitableForUseInPitcairnPitcairnIslandPitcairn1967ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianPitcairn1967OriginIsFundamentalPointPitcairnAstroLatitude25040687SLongitude130064783WOfGreenwichPitcairn1967IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000ReplacedByPitcairn2006")]
		[EnumMember(Value = "Pitcairn Astro 1967")] 
		[XmlEnum("82")] 
		PitcairnAstro1967 = 82,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1969SuitableForUseInSenegalCentralMaliSouthwestBurkinaFasoCentralNigerSouthwestNigeriaNorthChadCentralAllInProximityToTheParallelOfLatitudeOf12nPoint58ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianPoint58OriginIsFundamentalPointPoint58Latitude125244045NLongitude35837040EOfGreenwichPoint58IsAGeodeticDatumForGeodeticSurveyItWasDefinedByInformationFromIgnParisUsedAsTheBasisForComputationOfThe12thParallelTraverseConducted196670FromSenegalToChadAndConnectingToTheBlueNile1958AdindanTriangulationInSudan")]
		[EnumMember(Value = "Point 58")] 
		[XmlEnum("83")] 
		Point58 = 83,

		[System.ComponentModel.Description("PointeNoire1948Datum")]
		[EnumMember(Value = "Pointe Noire 1948")] 
		[XmlEnum("84")] 
		PointeNoire1948 = 84,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1936SuitableForUseInPortugalMadeiraPortoSantoAndDesertasIslandsOnshorePortoSanto1936ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianPortoSanto1936OriginIsSeBaseOnPortoSantoIslandPortoSanto1936IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoECadastralLisbonHttpWwwIgeoPtReplacedBy1995AdjustmentDatumCode6663ForSelvagensSeeSelvagemGrandeCode6616")]
		[EnumMember(Value = "Porto Santo 1936")] 
		[XmlEnum("85")] 
		PortoSanto1936 = 85,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1956SuitableForUseInArubaOnshoreBoliviaBonaireOnshoreBrazilOffshoreAmazonConeShelfChileOnshoreNorthOf4330SCuracaoOnshoreEcuadorMainlandOnshoreGuyanaOnshorePeruOnshoreVenezuelaOnshoreProvisionalSouthAmericanDatum1956ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianProvisionalSouthAmericanDatum1956OriginIsFundamentalPointLaCanoaLatitude83417170NLongitude635134880WOfGreenwichProvisionalSouthAmericanDatum1956IsAGeodeticDatumForTopographicMappingSameOriginAsLaCanoaDatum")]
		[EnumMember(Value = "Provisional South American 1956")] 
		[XmlEnum("86")] 
		ProvisionalSouthAmerican1956 = 86,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1963SuitableForUseInArgentinaAndChileTierraDelFuegoOnshoreHitoXviii1963ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianHitoXviii1963OriginIsChileArgentinaBoundarySurveyHitoXviii1963IsAGeodeticDatumForGeodeticSurveyItWasDefinedByInformationFromVariousOilCompanyRecordsUsedInTierraDelFuego")]
		[EnumMember(Value = "Provisional South Chilean 1963")] 
		[XmlEnum("87")] 
		ProvisionalSouthChilean1963 = 87,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1901SuitableForUseInPuertoRicoUsVirginIslandsAndBritishVirginIslandsOnshorePuertoRicoReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianPuertoRicoOriginIsFundamentalPointCardonaIslandLighthouseLatitude17573140NLongitude66380753WOfGreenwichPuertoRicoIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfGreatBritainAndHttpWwwNgsNoaaGovNadconReadmeFileNadconConversionProgramProvidesTransformationFromPuertoRicoDatumToNad83Original1986RealizationButMakingTheTransformationAppearToUserAsIfFromNad27")]
		[EnumMember(Value = "Puerto Rico")] 
		[XmlEnum("88")] 
		PuertoRico = 88,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1995SuitableForUseInQatarOnshoreQatarNationalDatum1995ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianQatarNationalDatum1995OriginIsDefinedByTransformationFromWgs84SeeCoordinateOperationCode1840QatarNationalDatum1995IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromQatarCentreForGeographicInformation")]
		[EnumMember(Value = "Qatar National")] 
		[XmlEnum("89")] 
		QatarNational = 89,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1927SuitableForUseInGreenlandWestCoastOnshoreQornoq1927ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianQornoq1927OriginIsFundamentalPointStation7008Latitude64310627NLongitude51122486WOfGreenwichQornoq1927IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromKortMatrikelstyrelsenCopenhagenOriginCoordinatesFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Qornoq")] 
		[XmlEnum("90")] 
		Qornoq = 90,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1947SuitableForUseInReunionOnshoreReunion1947ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianReunion1947OriginIsFundamentalPointPitonDesNeigesBorneLatitude210513119SLongitude552909193EOfGreenwichReunion1947IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromIgnParisReplacedByRgr92DatumCode6627")]
		[EnumMember(Value = "Reunion")] 
		[XmlEnum("91")] 
		Reunion = 91,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedInAndIsSuitableForUseInItalyOnshoreAndOffshoreSanMarinoVaticanCityStateMonteMarioRomeReferencesTheInternational1924EllipsoidAndTheRomePrimeMeridianMonteMarioRomeOriginIsFundamentalPointMonteMarioLatitude41552551NLongitude0000000EOfRomeMonteMarioRomeIsAGeodeticDatumForTopographicMappingReplacedGenovaDatumBessel1841EllipsoidFrom1940")]
		[EnumMember(Value = "Rome 1940")] 
		[XmlEnum("92")] 
		Rome1940 = 92,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1965SuitableForUseInVanuatuNorthernIslandsAeseAmbrymAobaEpiEspirituSantoMaewoMaloMalkulaPaamaPentecostShepherdAndTutubaSanto1965ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianSanto1965IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000DatumCoversAllTheMajorIslandsOfVanuatuInTwoDifferentAdjustmentBlocksButPracticalUsageIsAsGivenInTheAreaOfUse")]
		[EnumMember(Value = "Santo (DOS) 1965")] 
		[XmlEnum("93")] 
		SantoDos1965 = 93,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1995SuitableForUseInPortugalEasternAzoresOnshoreSaoMiguelSantaMariaFormigasAzoresOrientalIslands1995ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianAzoresOrientalIslands1995OriginIsFundamentalPointForteDeSoBrasOriginAndOrientationConstrainedToThoseOfThe1940AdjustmentAzoresOrientalIslands1995IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoECadastralLisbonHttpWwwIgeoPtClassicalAndGpsObservationsReplaces1940AdjustmentDatumCode6184")]
		[EnumMember(Value = "Sao Braz")] 
		[XmlEnum("94")] 
		SaoBraz = 94,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1943SuitableForUseInFalklandIslandsMalvinasOnshoreSapperHill1943ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianSapperHill1943IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Sapper Hill 1943")] 
		[XmlEnum("95")] 
		SapperHill1943 = 95,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInNamibiaOnshoreAndOffshoreSchwarzeckReferencesTheBesselNamibiaGlmEllipsoidAndTheGreenwichPrimeMeridianSchwarzeckOriginIsFundamentalPointSchwarzeckLatitude224535820SLongitude184034549EOfGreenwichFixedDuringGermanSouthWestAfricaBritishBechuanalandBoundarySurveyOf18981903SchwarzeckIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromPrivateCommunicationDirectorateOfSurveysAndLandInformationCapeTown")]
		[EnumMember(Value = "Schwarzeck")] 
		[XmlEnum("96")] 
		Schwarzeck = 96,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInPortugalSelvagensIslandsMadeiraProvinceOnshoreSelvagemGrandeReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianSelvagemGrandeIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromInstitutoGeograficoECadastralLisbonHttpWwwIgeoPt")]
		[EnumMember(Value = "Selvagem Grande 1938")] 
		[XmlEnum("97")] 
		SelvagemGrande1938 = 97,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1969SuitableForUseInBrazilOnshoreAndOffshoreInRestOfSouthAmericaOnshoreNorthOfApproximately45sAndTierraDelFuegoSouthAmericanDatum1969ReferencesTheGrs1967ModifiedEllipsoidAndTheGreenwichPrimeMeridianSouthAmericanDatum1969OriginIsFundamentalPointChuaGeodeticLatitude1945416527SGeodeticLongitude4806040639WOfGreenwichAstronomicCoordinatesLatitude19454134S005Longitude48060780W008SouthAmericanDatum1969IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromDma1974Sad69UsesGrs1967EllipsoidButWith1FToExactly2DecimalPlacesInBrazilOnlyReplacedBySad6996DatumCode1075")]
		[EnumMember(Value = "South American 1969")] 
		[XmlEnum("98")] 
		SouthAmerican1969 = 98,

		[System.ComponentModel.Description("SouthAsiaDatum")]
		[EnumMember(Value = "South Asia")] 
		[XmlEnum("99")] 
		SouthAsia = 99,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1925SuitableForUseInMadagascarOnshoreAndNearshoreTananarive1925ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianTananarive1925OriginIsFundamentalPointTananariveObservatoryLatitude18550210SLongitude47330675EOfGreenwichTananarive1925IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromIgnParis")]
		[EnumMember(Value = "Tananarive Observatory 1925")] 
		[XmlEnum("100")] 
		TananariveObservatory1925 = 100,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1948SuitableForUseInBruneiOnshoreAndOffshoreMalaysiaEastMalaysiaSabahSarawakOnshoreAndOffshoreTimbalai1948ReferencesTheEverest18301967DefinitionEllipsoidAndTheGreenwichPrimeMeridianTimbalai1948OriginIsFundamentalPointStationP85AtTimbalaiLatitude5173548NLongitude1151056409EOfGreenwichTimbalai1948IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromDefenceGeographicCentreIn1968TheOriginalAdjustmentWasDensifiedInSarawakAndExtendedToSabah")]
		[EnumMember(Value = "Timbalai 1948")] 
		[XmlEnum("101")] 
		Timbalai1948 = 101,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1918SuitableForUseInJapanOnshoreNorthKoreaOnshoreSouthKoreaOnshoreTokyoReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianTokyoOriginIsFundamentalPointNikonKeidoGentenLatitude3539175148NLongitude13944405020EOfGreenwichLongitudeDerivedIn1918TokyoIsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromGeographicSurveyInstituteJapanBulletin40March1994AlsoHttpVldbGsiGoJpSokuchiDatumTokyodatumHtmlInJapanReplacesTokyo1892Code1048AndReplacedByJapaneseGeodeticDatum2000Code6611InKoreaUsedOnlyForGeodeticApplicationsBeforeBeingReplacedByKorean1985Code6162")]
		[EnumMember(Value = "Tokyo")] 
		[XmlEnum("102")] 
		Tokyo = 102,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1968SuitableForUseInStHelenaAscensionAndTristanDaCunhaTristanDaCunhaIslandGroupIncludingTristanInaccessibleNightingaleMiddleAndStoltenhoffIslandsTristan1968ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianTristan1968IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Tristan Astro 1968")] 
		[XmlEnum("103")] 
		TristanAstro1968 = 103,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1912SuitableForUseInFijiVitiLevuIslandVitiLevu1912ReferencesTheClarke1880InternationalFootEllipsoidAndTheGreenwichPrimeMeridianVitiLevu1912LatitudeOriginWasObtainedAstronomicallyAtStationMonavatu175328285SLongitudeOriginWasObtainedAstronomicallyAtStationSuva1782535835EVitiLevu1912IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromCliffordJMugnierInPhotogrammetricEngineeringAndRemoteSensingOctober2000WwwAsprsOrgForTopographicMappingReplacedByFiji1956ForOtherPurposesReplacedByFiji1986")]
		[EnumMember(Value = "Viti Levu 1916")] 
		[XmlEnum("104")] 
		VitiLevu1916 = 104,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1960SuitableForUseInMarshallIslandsOnshoreWakeAtollOnshoreMarshallIslands1960ReferencesTheHough1960EllipsoidAndTheGreenwichPrimeMeridianMarshallIslands1960IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Wake-Eniwetok 1960")] 
		[XmlEnum("105")] 
		WakeEniwetok1960 = 105,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1952SuitableForUseInWakeAtollOnshoreWakeIsland1952ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianWakeIsland1952IsAGeodeticDatumForMilitaryAndTopographicMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Wake Island Astro 1952")] 
		[XmlEnum("106")] 
		WakeIslandAstro1952 = 106,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInUruguayOnshoreYacareReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianYacareOriginIsFundamentalPointYacareLatitude30355368SLongitude57250130WOfGreenwichYacareIsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaHttpEarthInfoNimaMil")]
		[EnumMember(Value = "Yacare")] 
		[XmlEnum("107")] 
		Yacare = 107,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInSurinameOnshoreAndOffshoreZanderijReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianZanderijIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Zanderij")] 
		[XmlEnum("108")] 
		Zanderij = 108,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1962SuitableForUseInAmericanSamoaTutuilaAunuUOfuOlesegaAndTaUIslandsAmericanSamoa1962ReferencesTheClarke1866EllipsoidAndTheGreenwichPrimeMeridianAmericanSamoa1962OriginIsFundamentalPointBetty13EccentricLatitude14200834SLongitude170425225WOfGreenwichAmericanSamoa1962IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNimaTr83502RevisionOfJanuary2000OilIndustrySourcesForOriginDescriptionDetails")]
		[EnumMember(Value = "American Samoa 1962")] 
		[XmlEnum("109")] 
		AmericanSamoa1962 = 109,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInAntarcticaSouthShetlandIslandsDeceptionIslandDeceptionIslandReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianDeceptionIslandIsAGeodeticDatumForMilitaryAndScientificMappingItWasDefinedByInformationFromDmaNimaNgaTr835023rdEditionAmendment13January2000")]
		[EnumMember(Value = "Deception Island")] 
		[XmlEnum("110")] 
		DeceptionIsland = 110,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInCambodiaOnshoreVietnamOnshoreAndOffshoreCuuLongBasinIndian1960ReferencesTheEverest18301937AdjustmentEllipsoidAndTheGreenwichPrimeMeridianIndian1960OriginIsDmaExtensionOverIndochinaOfTheIndian1954NetworkAdjustedToBetterFitLocalGeoidIndian1960IsAGeodeticDatumForTopographicMappingAlsoKnownAsIndianDmaReduced")]
		[EnumMember(Value = "Indian 1960")] 
		[XmlEnum("111")] 
		Indian1960 = 111,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1974SuitableForUseInIndonesiaOnshoreIndonesianDatum1974ReferencesTheIndonesianNationalSpheroidEllipsoidAndTheGreenwichPrimeMeridianIndonesianDatum1974OriginIsFundamentalPointPadangLatitude05638414SLongitude100228804EOfGreenwichEllipsoidalHeight3190mGravityRelatedHeight140mAboveMeanSeaLevelIndonesianDatum1974IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromBakosurtanal1979PaperByJacobRaisReplacedByDgn95")]
		[EnumMember(Value = "Indonesian 1974")] 
		[XmlEnum("112")] 
		Indonesian1974 = 112,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1959SuitableForUseInAlgeriaOnshoreAndOffshoreNordSahara1959ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianNordSahara1959OriginIsCoordinatesOfPrimaryNetworkReadjustedOnEd50DatumAndThenTransformedConformallyToClarke1880RgsEllipsoidNordSahara1959IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromLeSystemGeodesiqueNordSaharaIgnParisAdjustmentIncludesMoroccoAndTunisiaButUseOnlyInAlgeriaWithinAlgeriaTheAdjustmentIsNorthOf32nButUseHasBeenExtendedSouthwardsInManyDisconnectedProjectsSomeBasedOnIndependentAstroStationsRatherThanTheGeodeticNetwork")]
		[EnumMember(Value = "North Sahara 1959")] 
		[XmlEnum("113")] 
		NorthSahara1959 = 113,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1942SuitableForUseInArmeniaAzerbaijanBelarusEstoniaOnshoreGeorgiaOnshoreKazakhstanKyrgyzstanLatviaOnshoreLithuaniaOnshoreMoldovaRussianFederationOnshoreTajikistanTurkmenistanUkraineOnshoreUzbekistanPulkovo1942ReferencesTheKrassowsky1940EllipsoidAndTheGreenwichPrimeMeridianPulkovo1942OriginIsFundamentalPointPulkovoObservatoryLatitude594618550NLongitude301942090EOfGreenwichPulkovo1942IsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Pulkovo 1942")] 
		[XmlEnum("114")] 
		Pulkovo1942 = 114,

		[System.ComponentModel.Description("AGeodeticDatumSuitableForUseInCzechRepublicSlovakiaSystemJednotneTrigonometrickeSiteKatastralniReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianSystemJednotneTrigonometrickeSiteKatastralniOriginIsModificationOfAustrianMgiDatumCode6312SystemJednotneTrigonometrickeSiteKatastralniIsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromResearchInstituteForGeodesyTopographyAndCartographyVugtkPragueSJtskSystemOfTheUnifiedTrigonometricalCadastralNetwork")]
		[EnumMember(Value = "S-JTSK")] 
		[XmlEnum("116")] 
		SJtsk = 116,

		[System.ComponentModel.Description("Voirol1950Datum")]
		[EnumMember(Value = "Voirol 1950")] 
		[XmlEnum("117")] 
		Voirol1950 = 117,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1977SuitableForUseInCanadaNewBrunswickNovaScotiaPrinceEdwardIslandAverageTerrestrialSystem1977ReferencesTheAverageTerrestrialSystem1977EllipsoidAndTheGreenwichPrimeMeridianAverageTerrestrialSystem1977IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromNewBrunswickGeographicInformationCorporationLandAndWaterInformationStandardsManualInUseFrom1979")]
		[EnumMember(Value = "Average Terrestrial System 1977")] 
		[XmlEnum("118")] 
		AverageTerrestrialSystem1977 = 118,

		[System.ComponentModel.Description("CompensationGeodesiqueDuQuebec1977")]
		[EnumMember(Value = "Compensation Geodesique du Quebec 1977")] 
		[XmlEnum("119")] 
		CompensationGeodesiqueDuQuebec1977 = 119,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1966SuitableForUseInFinlandOnshoreKartastokoordinaattijarjestelma1966ReferencesTheInternational1924EllipsoidAndTheGreenwichPrimeMeridianKartastokoordinaattijarjestelma1966OriginIsAdjustmentWithFundamentalPointSf31BasedOnEd50TransformedToBestFitTheOlderVvjAdjustmentKartastokoordinaattijarjestelma1966IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromNationalLandSurveyOfFinlandHttpWwwMaanmittauslaitosFiAdoptedIn1970")]
		[EnumMember(Value = "Finnish (KKJ)")] 
		[XmlEnum("120")] 
		FinnishKkj = 120,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1952SuitableForUseInUnitedKingdomUkNorthernIrelandUlsterOnshoreOsni1952ReferencesTheAiry1830EllipsoidAndTheGreenwichPrimeMeridianOsni1952OriginIsPositionFixedToTheCoordinatesFromThe19thCenturyPrincipleTriangulationOfStationDivisScaleAndOrientationControlledByPositionOfPrincipleTriangulationStationsKnocklaydAndTrostanOsni1952IsAGeodeticDatumForGeodeticSurveyAndTopographicMappingItWasDefinedByInformationFromOrdnanceSurveyOfNorthernIrelandReplacedByGeodeticDatumOf1965Alias1975MappingAdjustmentOrTm75DatumCode6300")]
		[EnumMember(Value = "Ordnance Survey of Ireland")] 
		[XmlEnum("121")] 
		OrdnanceSurveyOfIreland = 121,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1969SuitableForUseInMalaysiaWestMalaysiaSingaporeKertauRsoReferencesTheEverest1830Rso1969EllipsoidAndTheGreenwichPrimeMeridianKertauRsoIsAGeodeticDatumForMetricationOfRsoGridItWasDefinedByInformationFromDefenceGeographicCentreAdoptsMetricConversionOf0914398MetresPerYardExactlyThisIsATruncationOfTheSears1922Ratio")]
		[EnumMember(Value = "Revised Kertau")] 
		[XmlEnum("122")] 
		RevisedKertau = 122,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1967SuitableForUseInArabianGulfQatarOffshoreUnitedArabEmiratesUaeAbuDhabiDubaiSharjahAjmanFujairahRasAlKaimahUmmAlQaiwainOnshoreAndOffshoreNahrwan1967ReferencesTheClarke1880RgsEllipsoidAndTheGreenwichPrimeMeridianNahrwan1967OriginIsFundamentalPointNahrwanSouthBaseLatitude33191087NLongitude44432554EOfGreenwichNahrwan1967IsAGeodeticDatumForTopographicMappingInIraqReplacesNahrwan1934")]
		[EnumMember(Value = "Revised Nahrwan")] 
		[XmlEnum("123")] 
		RevisedNahrwan = 123,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1987SuitableForUseInGreeceOnshoreGreekGeodeticReferenceSystem1987ReferencesTheGrs1980EllipsoidAndTheGreenwichPrimeMeridianGreekGeodeticReferenceSystem1987OriginIsFundamentalPointDionysosLatitude3804338NLongitude2355510EOfGreenwichGeoidHeight70MGreekGeodeticReferenceSystem1987IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromLPortokalakisPublicPetroleumCorporationOfGreeceReplacedOldGreekDatumOilIndustryWorkBasedOnEd50")]
		[EnumMember(Value = "GGRS 76 (Greece)")] 
		[XmlEnum("124")] 
		Ggrs76Greece = 124,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1895SuitableForUseInFranceOnshoreMainlandAndCorsicaNouvelleTriangulationFrancaiseReferencesTheClarke1880IgnEllipsoidAndTheGreenwichPrimeMeridianNouvelleTriangulationFrancaiseOriginIsFundamentalPointPantheonLatitude485046522NLongitude22048667EOfGreenwichNouvelleTriangulationFrancaiseIsAGeodeticDatumForTopographicMapping")]
		[EnumMember(Value = "Nouvelle Triangulation de France")] 
		[XmlEnum("125")] 
		NouvelleTriangulationDeFrance = 125,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1982SuitableForUseInSwedenOnshoreAndOffshoreRiketsKoordinatsystem1990ReferencesTheBessel1841EllipsoidAndTheGreenwichPrimeMeridianRiketsKoordinatsystem1990IsAGeodeticDatumForGeodeticSurveyCadastreTopographicMappingEngineeringSurveyItWasDefinedByInformationFromNationalLandSurveyOfSwedenReplacesRt38AdjustmentDatumCode6308")]
		[EnumMember(Value = "RT 90 (Sweden)")] 
		[XmlEnum("126")] 
		Rt90Sweden = 126,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1994SuitableForUseInAustraliaIncludingLordHoweIslandMacquarieIslandsAshmoreAndCartierIslandsChristmasIslandCocosKeelingIslandsNorfolkIslandAllOnshoreAndOffshoreGeocentricDatumOfAustralia1994ReferencesTheGrs1980EllipsoidAndTheGreenwichPrimeMeridianGeocentricDatumOfAustralia1994OriginIsItrf92AtEpoch19940GeocentricDatumOfAustralia1994IsAGeodeticDatumForTopographicMappingGeodeticSurveyItWasDefinedByInformationFromAustralianSurveyingAndLandInformationGroupInternetWwwPageHttpWwwAusligGovAuGeodesyDatumsGdaHtmSpecsCoincidentWithWgs84ToWithin1Metre")]
		[EnumMember(Value = "Geocentric Datum of Australia")] 
		[XmlEnum("127")] 
		GeocentricDatumOfAustralia = 127,

		[System.ComponentModel.Description("AGeodeticDatumFirstDefinedIn1954SuitableForUseInChinaOnshoreBeijing1954ReferencesTheKrassowsky1940EllipsoidAndTheGreenwichPrimeMeridianBeijing1954OriginIsPulkovoTransferredThroughRussianTriangulationBeijing1954IsAGeodeticDatumForTopographicMappingItWasDefinedByInformationFromChineseScienceBulletin20095427142721ScaleDeterminedThroughThreeBaselinesInNortheastChinaDiscontinuitiesAtBoundariesOfAdjustmentBlocksFrom1982ReplacedByXian1980AndNewBeijing")]
		[EnumMember(Value = "BJZ54 (A954 Beijing Coordinates)")] 
		[XmlEnum("128")] 
		Bjz54A954BeijingCoordinates = 128,

		[System.ComponentModel.Description("ModifiedBjz54Datum")]
		[EnumMember(Value = "Modified BJZ54")] 
		[XmlEnum("129")] 
		ModifiedBjz54 = 129,

		[System.ComponentModel.Description("Gdz80Datum")]
		[EnumMember(Value = "GDZ80")] 
		[XmlEnum("130")] 
		Gdz80 = 130,

		[System.ComponentModel.Description("AnArbitraryDatumDefinedByALocalHarbourAuthorityFromWhichLevelsAndTidalHeightsAreMeasuredByThisAuthority")]
		[EnumMember(Value = "Local Datum")] 
		[XmlEnum("131")] 
		LocalDatum = 131,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalStatus : int {
		[System.ComponentModel.Description("TheIndicationOfAnElementOfASignalSequenceBeingAPeriodOfLightOrSound")]
		[EnumMember(Value = "Lit/Sound")] 
		[XmlEnum("1")] 
		LitSound = 1,

		[System.ComponentModel.Description("TheIndicationOfAnElementOfASignalSequenceBeingAPeriodOfEclipseOrSilence")]
		[EnumMember(Value = "Eclipsed/Silent")] 
		[XmlEnum("2")] 
		EclipsedSilent = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCable : int {
		[System.ComponentModel.Description("ACableThatTransmitsOrDistributesElectricalPower")]
		[EnumMember(Value = "Power Line")] 
		[XmlEnum("1")] 
		PowerLine = 1,

		[System.ComponentModel.Description("MultipleUnInsulatedCablesUsuallySupportedBySteelLatticeTowersSuchFeaturesAreGenerallyMoreProminentThanNormalPowerLines")]
		[EnumMember(Value = "Transmission Line")] 
		[XmlEnum("3")] 
		TransmissionLine = 3,

		[System.ComponentModel.Description("ACableThatTransmitsTelephoneSignals")]
		[EnumMember(Value = "Telephone")] 
		[XmlEnum("4")] 
		Telephone = 4,

		[System.ComponentModel.Description("AnApparatusSystemOrProcessForCommunicationAtADistanceByElectricTransmissionOverWire")]
		[EnumMember(Value = "Telegraph")] 
		[XmlEnum("5")] 
		Telegraph = 5,

		[System.ComponentModel.Description("AChainOrVeryStrongFibreOrWireRopeUsedToAnchorOrMoorVesselsOrBuoys")]
		[EnumMember(Value = "Mooring Cable")] 
		[XmlEnum("6")] 
		MooringCable = 6,

		[System.ComponentModel.Description("AVesselForTransportingPassengersVehiclesAndOrGoodsAcrossAStretchOfWaterEspeciallyAsARegularService")]
		[EnumMember(Value = "Ferry")] 
		[XmlEnum("7")] 
		Ferry = 7,

		[System.ComponentModel.Description("ACableMadeOfGlassOrPlasticFiberDesignedToGuideLightAlongItsLengthFibreOpticCablesAreWidelyUsedInFiberOpticCommunicationWhichPermitsTransmissionOverLongerDistancesAndAtHigherDataRatesThanOtherFormsOfCommunication")]
		[EnumMember(Value = "Fibre Optic Cable")] 
		[XmlEnum("8")] 
		FibreOpticCable = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfInstallationBuoy : int {
		[System.ComponentModel.Description("IncorporatesALargeBuoyWhichRemainsOnTheSurfaceAtAllTimesAndIsMooredBy4OrMoreAnchorsMooringHawsersAndCargoHosesLeadFromATurntableOnTopOfTheBuoySoThatTheBuoyDoesNotTurnAsTheShipSwingsToWindAndStream")]
		[EnumMember(Value = "Catenary Anchor Leg Mooring")] 
		[XmlEnum("1")] 
		CatenaryAnchorLegMooring = 1,

		[System.ComponentModel.Description("AMooringStructureUsedByTankersToLoadAndUnloadInPortApproachesOrInOffshoreOilAndGasFieldsTheSizeOfTheStructureCanVaryBetweenALargeMooringBuoyAndAMannedFloatingStructureAlsoKnownAsSinglePointMooringSpm")]
		[EnumMember(Value = "Single Buoy Mooring")] 
		[XmlEnum("2")] 
		SingleBuoyMooring = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum ShackleType : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "forelock shackles")] 
		[XmlEnum("1")] 
		ForelockShackles = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "clenching shackles")] 
		[XmlEnum("2")] 
		ClenchingShackles = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "bolt shackles")] 
		[XmlEnum("3")] 
		BoltShackles = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "screw pin shackles")] 
		[XmlEnum("4")] 
		ScrewPinShackles = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "kenter shackle")] 
		[XmlEnum("5")] 
		KenterShackle = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "quick release link")] 
		[XmlEnum("6")] 
		QuickReleaseLink = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPile : int {
		[System.ComponentModel.Description("AnElongatedWoodOrMetalPoleEmbeddedInTheSeabedToServeAsAMarkerOrSupport")]
		[EnumMember(Value = "Stake")] 
		[XmlEnum("1")] 
		Stake = 1,

		[System.ComponentModel.Description("AVerticalPieceOfTimberMetalOrConcreteForcedIntoTheEarthOrSeaBed")]
		[EnumMember(Value = "Post")] 
		[XmlEnum("3")] 
		Post = 3,

		[System.ComponentModel.Description("ASingleStructureComprising3OrMorePilesHeldTogetherSectionsOfHeavyTimberSteelOrConcreteAndForcedIntoTheEarthOrSeaBed")]
		[EnumMember(Value = "Tripodal")] 
		[XmlEnum("4")] 
		Tripodal = 4,

		[System.ComponentModel.Description("ANumberOfPilesUsuallyInAStraightLineAndUsuallyConnectedOrBoltedTogether")]
		[EnumMember(Value = "Piling")] 
		[XmlEnum("5")] 
		Piling = 5,

		[System.ComponentModel.Description("ANumberOfPilesUsuallyInAStraightLineButNotConnectedByStructuralMembers")]
		[EnumMember(Value = "Area of Piles")] 
		[XmlEnum("6")] 
		AreaOfPiles = 6,

		[System.ComponentModel.Description("AVerticalHollowCylinderOfMetalWoodOrOtherMaterialForcedIntoTheEarthOrSeabed")]
		[EnumMember(Value = "Pipe")] 
		[XmlEnum("7")] 
		Pipe = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSiloTank : int {
		[System.ComponentModel.Description("ALargeStorageStructureUsedForStoringLooseMaterials")]
		[EnumMember(Value = "Silo in General")] 
		[XmlEnum("1")] 
		SiloInGeneral = 1,

		[System.ComponentModel.Description("AFixedStructureForStoringLiquids")]
		[EnumMember(Value = "Tank in General")] 
		[XmlEnum("2")] 
		TankInGeneral = 2,

		[System.ComponentModel.Description("AStorageBuildingForGrainUsuallyATallFrameMetalOrConcreteStructureWithAnEspeciallyCompartmentedInterior")]
		[EnumMember(Value = "Grain Elevator")] 
		[XmlEnum("3")] 
		GrainElevator = 3,

		[System.ComponentModel.Description("ATowerSupportingAnElevatedStorageTankOfWater")]
		[EnumMember(Value = "Water Tower")] 
		[XmlEnum("4")] 
		WaterTower = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buildingShape : int {
		[System.ComponentModel.Description("ABuildingHavingManyStoreys")]
		[EnumMember(Value = "High-Rise Building")] 
		[XmlEnum("5")] 
		HighRiseBuilding = 5,

		[System.ComponentModel.Description("APolyhedronOfWhichOneFaceIsAPolygonOfAnyNumberOfSidesAndTheOtherFacesAreTrianglesWithACommonVertex")]
		[EnumMember(Value = "Pyramid")] 
		[XmlEnum("6")] 
		Pyramid = 6,

		[System.ComponentModel.Description("ShapedLikeACylinderWhichIsASolidGeometricalFigureGeneratedByStraightLinesFixedInDirectionAndDescribingWithOneOfItsPointsAClosedCurveEspeciallyACircle")]
		[EnumMember(Value = "Cylindrical")] 
		[XmlEnum("7")] 
		Cylindrical = 7,

		[System.ComponentModel.Description("ShapedLikeASphereWhichIsABodyTheSurfaceOfWhichIsAtAllPointsEquidistantFromTheCentre")]
		[EnumMember(Value = "Spherical")] 
		[XmlEnum("8")] 
		Spherical = 8,

		[System.ComponentModel.Description("AShapeTheSidesOfWhichAreSixEqualSquaresARegularHexahedron")]
		[EnumMember(Value = "Cubic")] 
		[XmlEnum("9")] 
		Cubic = 9,
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

		[System.ComponentModel.Description("AColourlessOdourlessTastelessLiquidThatIsACompoundOfHydrogenAndOxygen")]
		[EnumMember(Value = "Water")] 
		[XmlEnum("3")] 
		Water = 3,

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

		[System.ComponentModel.Description("WaterThatIsSuitableForHumanConsumption")]
		[EnumMember(Value = "Drinking Water")] 
		[XmlEnum("8")] 
		DrinkingWater = 8,

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

		[System.ComponentModel.Description("ElectricChargeOrCurrent")]
		[EnumMember(Value = "Electricity")] 
		[XmlEnum("23")] 
		Electricity = 23,

		[System.ComponentModel.Description("TheSolidFormOfWater")]
		[EnumMember(Value = "Ice")] 
		[XmlEnum("24")] 
		Ice = 24,

		[System.ComponentModel.Description("ParticlesOfLessThan0002mmStiffStickyEarthThatBecomesHardWhenBaked")]
		[EnumMember(Value = "Clay")] 
		[XmlEnum("25")] 
		Clay = 25,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfOffshorePlatform : int {
		[System.ComponentModel.Description("ATemporaryMobileStructureEitherFixedOrFloatingUsedInTheExplorationStagesOfOilAndGasFields")]
		[EnumMember(Value = "Oil Rig")] 
		[XmlEnum("1")] 
		OilRig = 1,

		[System.ComponentModel.Description("ATermUsedToIndicateAPermanentOffshoreStructureEquippedToControlTheFlowOfOilOrGasItDoesNotIncludeEntirelySubmarineStructures")]
		[EnumMember(Value = "Production Platform")] 
		[XmlEnum("2")] 
		ProductionPlatform = 2,

		[System.ComponentModel.Description("APlatformFromWhichOneSSurroundingsOrEventsCanBeObservedNotedOrRecordedSuchAsForScientificStudy")]
		[EnumMember(Value = "Observation/Research Platform")] 
		[XmlEnum("3")] 
		ObservationResearchPlatform = 3,

		[System.ComponentModel.Description("AMetalLatticeTowerBuoyantAtOneEndAndAttachedAtTheOtherByAUniversalJointToAConcreteFilledBaseOnTheSeaBedThePlatformMayBeFittedWithAHelicopterPlatformEmergencyAccommodationAndHawserHoseRetrieval")]
		[EnumMember(Value = "Articulated Loading Platform")] 
		[XmlEnum("4")] 
		ArticulatedLoadingPlatform = 4,

		[System.ComponentModel.Description("ARigidFrameOrTubeWithABuoyancyDeviceAtItsUpperEndSecuredAtItsLowerEndToAUniversalJointOnALargeSteelOrConcreteBaseRestingOnTheSeaBedAndAtItsUpperEndToAMooringBuoyByAChainOrWire")]
		[EnumMember(Value = "Single Anchor Leg Mooring")] 
		[XmlEnum("5")] 
		SingleAnchorLegMooring = 5,

		[System.ComponentModel.Description("APlatformSecuredToTheSeaBedAndSurmountedByATurntableToWhichShipsMoor")]
		[EnumMember(Value = "Mooring Tower")] 
		[XmlEnum("6")] 
		MooringTower = 6,

		[System.ComponentModel.Description("AManMadeStructureUsuallyBuiltForTheExplorationOrExploitationOfMarineResourcesMarineScientificResearchTidalObservationsEtc")]
		[EnumMember(Value = "Artificial Island")] 
		[XmlEnum("7")] 
		ArtificialIsland = 7,

		[System.ComponentModel.Description("AnOffshoreOilGasFacilityConsistingOfAMooredTankerBargeByWhichTheProductIsExtractedStoredAndExported")]
		[EnumMember(Value = "Floating Production, Storage and Off-Loading Vessel")] 
		[XmlEnum("8")] 
		FloatingProductionStorageAndOffLoadingVessel = 8,

		[System.ComponentModel.Description("APlatformUsedPrimarilyForEatingSleepingAndRecreationPurposes")]
		[EnumMember(Value = "Accommodation Platform")] 
		[XmlEnum("9")] 
		AccommodationPlatform = 9,

		[System.ComponentModel.Description("AFloatingStructureWithControlRoomPowerAndStorageFacilitiesAttachedToTheSeaBedByAFlexiblePipelineAndCables")]
		[EnumMember(Value = "Navigation, Communication and Control Buoy")] 
		[XmlEnum("10")] 
		NavigationCommunicationAndControlBuoy = 10,

		[System.ComponentModel.Description("AFloatingStructureAnchoredToTheSeabedForStoringOil")]
		[EnumMember(Value = "Floating Oil Tank")] 
		[XmlEnum("11")] 
		FloatingOilTank = 11,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCardinalMark : int {
		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingNwNeTakenFromThePointOfInterestItShouldBePassedToTheNorthSideOfTheMark")]
		[EnumMember(Value = "North Cardinal Mark")] 
		[XmlEnum("1")] 
		NorthCardinalMark = 1,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingNeSeTakenFromThePointOfInterestItShouldBePassedToTheEastSideOfTheMark")]
		[EnumMember(Value = "East Cardinal Mark")] 
		[XmlEnum("2")] 
		EastCardinalMark = 2,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingSeSwTakenFromThePointOfInterestItShouldBePassedToTheSouthSideOfTheMark")]
		[EnumMember(Value = "South Cardinal Mark")] 
		[XmlEnum("3")] 
		SouthCardinalMark = 3,

		[System.ComponentModel.Description("QuadrantBoundedByTheTrueBearingSwNwTakenFromThePointOfInterestItShouldBePassedToTheWestSideOfTheMark")]
		[EnumMember(Value = "West Cardinal Mark")] 
		[XmlEnum("4")] 
		WestCardinalMark = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightCharacteristic : int {
		[System.ComponentModel.Description("ASignalLightThatShowsContinuouslyInAnyGivenDirectionWithConstantLuminousIntensityAndColour")]
		[EnumMember(Value = "Fixed")] 
		[XmlEnum("1")] 
		Fixed = 1,

		[System.ComponentModel.Description("ARhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyShorterThanTheTotalDurationOfDarknessAndAllTheAppearancesOfLightAreOfEqualDuration")]
		[EnumMember(Value = "Flashing")] 
		[XmlEnum("2")] 
		Flashing = 2,

		[System.ComponentModel.Description("ASingleFlashingLightInWhichASingleFlashOfNotLessThanTwoSecondsDurationIsRegularlyRepeated")]
		[EnumMember(Value = "Long-Flashing")] 
		[XmlEnum("3")] 
		LongFlashing = 3,

		[System.ComponentModel.Description("ARhythmicLightInWhichFlashesAreRepeatedAtARateOfNotLessThan50FlashesPerMinutesButLessThan80FlashesPerMinutesItMayBeContinuousQuickFlashingAQuickFlashingLightInWhichAFlashIsRegularlyRepeatedGroupQuickFlashingAQuickFlashingLightInWhichAGroupOfTwoOrMoreFlashesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Quick-Flashing")] 
		[XmlEnum("4")] 
		QuickFlashing = 4,

		[System.ComponentModel.Description("ARhythmicLightInWhichFlashesAreRepeatedAtARateOfNotLessThan80FlashesPerMinuteButLessThan160FlashesPerMinuteItMayBeContinuousVeryQuickFlashingAVeryQuickFlashingLightInWhichAFlashIsRegularlyRepeatedGroupVeryQuickFlashingAVeryQuickFlashingLightInWhichAGroupOfTwoOrMoreFlashesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Very Quick-Flashing")] 
		[XmlEnum("5")] 
		VeryQuickFlashing = 5,

		[System.ComponentModel.Description("ARhythmicLightInWhichFlashesAreRegularlyRepeatedAtARateOfNotLessThan160FlashesPerMinute")]
		[EnumMember(Value = "Continuous Ultra Quick-Flashing")] 
		[XmlEnum("6")] 
		ContinuousUltraQuickFlashing = 6,

		[System.ComponentModel.Description("ALightWithAllDurationsOfLightAndDarknessEqual")]
		[EnumMember(Value = "Isophased")] 
		[XmlEnum("7")] 
		Isophased = 7,

		[System.ComponentModel.Description("ARhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyLongerThanTheTotalDurationOfDarknessAndAllTheEclipsesAreOfEqualDurationItMayBeSingleOccultingAnOccultingLightInWhichAnEclipseIsRegularlyRepeatedGroupOccultingAnOccultingLightInWhichAGroupOfTwoOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedCompositeGroupOccultingAnOccultingLightInWhichASequenceOfGroupsOfOneOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedAndTheGroupsCompriseDifferentNumbersOfEclipses")]
		[EnumMember(Value = "Occulting")] 
		[XmlEnum("8")] 
		Occulting = 8,

		[System.ComponentModel.Description("ARhythmicLightInWhichAppearancesOfLightOfTwoClearlyDifferentDurationsAreGroupedToRepresentACharacterOrCharactersInTheMorseCode")]
		[EnumMember(Value = "Morse")] 
		[XmlEnum("12")] 
		Morse = 12,

		[System.ComponentModel.Description("ARhythmicLightInWhichAFixedLightIsCombinedWithAFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Fixed and Flash")] 
		[XmlEnum("13")] 
		FixedAndFlash = 13,

		[System.ComponentModel.Description("ARhythmicLightInWhichAFlashingLightIsCombinedWithALongFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Flash and Long-Flash")] 
		[XmlEnum("14")] 
		FlashAndLongFlash = 14,

		[System.ComponentModel.Description("ARhythmicLightInWhichAnOccultingLightIsCombinedWithAFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Occulting and Flash")] 
		[XmlEnum("15")] 
		OccultingAndFlash = 15,

		[System.ComponentModel.Description("ARhythmicLightInWhichAFixedLightIsCombinedWithALongFlashingLightOfHigherLuminousIntensity")]
		[EnumMember(Value = "Fixed and Long-Flash")] 
		[XmlEnum("16")] 
		FixedAndLongFlash = 16,

		[System.ComponentModel.Description("AnAlternatingLightInWhichTheTotalDurationOfLightInEachPeriodIsClearlyLongerThanTheTotalDurationOfDarknessAndInWhichTheIntervalsOfDarknessOccultationsAreAllOfEqualDuration")]
		[EnumMember(Value = "Occulting Alternating")] 
		[XmlEnum("17")] 
		OccultingAlternating = 17,

		[System.ComponentModel.Description("AnAlternatingSingleFlashingLightInWhichAnAppearanceOfLightOfNotLessThanTwoSecondsDurationIsRegularlyRepeated")]
		[EnumMember(Value = "Long-Flash Alternating")] 
		[XmlEnum("18")] 
		LongFlashAlternating = 18,

		[System.ComponentModel.Description("AnAlternatingRhythmicLightInWhichTheTotalDurationOfLightInAPeriodIsClearlyShorterThanTheTotalDurationOfDarknessAndAllTheAppearancesOfLightAreOfEqualDuration")]
		[EnumMember(Value = "Flash Alternating")] 
		[XmlEnum("19")] 
		FlashAlternating = 19,

		[System.ComponentModel.Description("OccultingLightInWhichTheOccultationsAreCombinedInGroupsEachGroupIncludingTheSameNumberOfOccultationsAndInWhichTheGroupsAreRepeatedAtRegularIntervals")]
		[EnumMember(Value = "Group Alternating")] 
		[XmlEnum("20")] 
		GroupAlternating = 20,

		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Quick-Flash Plus Long-Flash")] 
		[XmlEnum("25")] 
		QuickFlashPlusLongFlash = 25,

		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfVeryQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Very Quick-Flash Plus Long-Flash")] 
		[XmlEnum("26")] 
		VeryQuickFlashPlusLongFlash = 26,

		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfUltraQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Ultra Quick-Flash Plus Long-Flash")] 
		[XmlEnum("27")] 
		UltraQuickFlashPlusLongFlash = 27,

		[System.ComponentModel.Description("ASignalLightThatShowsInAnyGivenDirectionTwoOrMoreColoursInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Alternating")] 
		[XmlEnum("28")] 
		Alternating = 28,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fixed and Alternating Flashing")] 
		[XmlEnum("29")] 
		FixedAndAlternatingFlashing = 29,

		[System.ComponentModel.Description("AnOccultingLightInWhichAGroupOfTwoOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Group-occulting light")] 
		[XmlEnum("30")] 
		GroupOccultingLight = 30,

		[System.ComponentModel.Description("AnOccultingLightInWhichASequenceOfGroupsOfOneOrMoreEclipsesWhichAreSpecifiedInNumberIsRegularlyRepeatedAndTheGroupsCompriseDifferentNumbersOfEclipses")]
		[EnumMember(Value = "Composite group-occulting light")] 
		[XmlEnum("31")] 
		CompositeGroupOccultingLight = 31,

		[System.ComponentModel.Description("AFlashingLightInWhichAGroupOfFlashesSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Group flashing light")] 
		[XmlEnum("32")] 
		GroupFlashingLight = 32,

		[System.ComponentModel.Description("ALightSimilarToAGroupFlashingLightExceptThatSuccessiveGroupsInAPeriodHaveDifferentNumbersOfFlashes")]
		[EnumMember(Value = "Composite group-flashing light")] 
		[XmlEnum("33")] 
		CompositeGroupFlashingLight = 33,

		[System.ComponentModel.Description("AQuickFlashingLightInWhichAGroupOfTwoOrMoreFlashesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Group quick light")] 
		[XmlEnum("34")] 
		GroupQuickLight = 34,

		[System.ComponentModel.Description("AVeryQuickFlashingLightInWhichAGroupOfTwoOrMoreFlashesWhichAreSpecifiedInNumberIsRegularlyRepeated")]
		[EnumMember(Value = "Group very quick light")] 
		[XmlEnum("35")] 
		GroupVeryQuickLight = 35,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfPowerSource : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "battery")] 
		[XmlEnum("1")] 
		Battery = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "generator")] 
		[XmlEnum("2")] 
		Generator = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "solar panel")] 
		[XmlEnum("3")] 
		SolarPanel = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "electrical service")] 
		[XmlEnum("4")] 
		ElectricalService = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfSyntheticAISAidtoNavigation : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "predicted")] 
		[XmlEnum("1")] 
		Predicted = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "monitored")] 
		[XmlEnum("2")] 
		Monitored = 2,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum CategoryOfPhysicalAISAidToNavigation : int {
		[System.ComponentModel.Description("SimpleTransmissionOfStaticPreProgrammedInformation")]
		[EnumMember(Value = "Physical AIS Type 1")] 
		[XmlEnum("1")] 
		PhysicalAisType1 = 1,

		[System.ComponentModel.Description("TransmissionOfDynamicRealTimeUpdatedInformationViaConnectedSensors")]
		[EnumMember(Value = "Physical AIS Type 2")] 
		[XmlEnum("2")] 
		PhysicalAisType2 = 2,

		[System.ComponentModel.Description("FullTwoWayCommunicationTransmissionRemoteControlConfiguration")]
		[EnumMember(Value = "Physical AIS Type 3")] 
		[XmlEnum("3")] 
		PhysicalAisType3 = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum virtualAISAidToNavigationType : int {
		[System.ComponentModel.Description("IndicatesThatItShouldBePassedToTheNorthSideOfTheAid")]
		[EnumMember(Value = "North Cardinal")] 
		[XmlEnum("1")] 
		NorthCardinal = 1,

		[System.ComponentModel.Description("IndicatesThatItShouldBePassedToTheEastSideOfTheAid")]
		[EnumMember(Value = "East Cardinal")] 
		[XmlEnum("2")] 
		EastCardinal = 2,

		[System.ComponentModel.Description("IndicatesThatItShouldBePassedToTheSouthSideOfTheAid")]
		[EnumMember(Value = "South Cardinal")] 
		[XmlEnum("3")] 
		SouthCardinal = 3,

		[System.ComponentModel.Description("IndicatesThatItShouldBePassedToTheWestSideOfTheAid")]
		[EnumMember(Value = "West Cardinal")] 
		[XmlEnum("4")] 
		WestCardinal = 4,

		[System.ComponentModel.Description("IndicatesThePortBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyage")]
		[EnumMember(Value = "Port Lateral")] 
		[XmlEnum("5")] 
		PortLateral = 5,

		[System.ComponentModel.Description("IndicatesTheStarboardBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyage")]
		[EnumMember(Value = "Starboard Lateral")] 
		[XmlEnum("6")] 
		StarboardLateral = 6,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedPortHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Port")] 
		[XmlEnum("7")] 
		PreferredChannelToPort = 7,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedStarboardHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Starboard")] 
		[XmlEnum("8")] 
		PreferredChannelToStarboard = 8,

		[System.ComponentModel.Description("AMarkUsedAloneToIndicateADangerousReefOrShoalTheMarkMayBePassedOnEitherHand")]
		[EnumMember(Value = "Isolated Danger")] 
		[XmlEnum("9")] 
		IsolatedDanger = 9,

		[System.ComponentModel.Description("IndicatesThatThereIsNavigableWaterAroundTheMark")]
		[EnumMember(Value = "Safe Water")] 
		[XmlEnum("10")] 
		SafeWater = 10,

		[System.ComponentModel.Description("ASpecialPurposeAidIsPrimarilyUsedToIndicateAnAreaOrFeatureTheNatureOfWhichIsApparentFromReferenceToAChartSailingDirectionsOrNoticeToMariners")]
		[EnumMember(Value = "Special Purpose")] 
		[XmlEnum("11")] 
		SpecialPurpose = 11,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfARecentlyIdentifiedNewDangerSuchAsAWreck")]
		[EnumMember(Value = "New Danger Marking")] 
		[XmlEnum("12")] 
		NewDangerMarking = 12,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadarTransponderBeacon : int {
		[System.ComponentModel.Description("ARadarMarkerBeaconWhichContinuouslyTransmitsASignalAppearingAsARadialLineOnARadarScreenTheLineIndicatingTheDirectionOfTheBeaconRamarksAreIntendedPrimarilyForMarineUseTheNameRamarkIsDerivedFromTheWordsRadarMarker")]
		[EnumMember(Value = "Ramark, Radar Beacon Transmitting Continuously")] 
		[XmlEnum("1")] 
		RamarkRadarBeaconTransmittingContinuously = 1,

		[System.ComponentModel.Description("ARadarBeaconWhichReturnsACodedSignalWhichProvidesIdentificationOfTheBeaconAsWellAsRangeAndBearingTheRangeAndBearingAreIndicatedByTheLocationOfTheFirstCharacterReceivedOnTheRadarScreenTheNameRaconIsDerivedFromTheWordsRadarBeacon")]
		[EnumMember(Value = "Racon, Radar Transponder Beacon")] 
		[XmlEnum("2")] 
		RaconRadarTransponderBeacon = 2,

		[System.ComponentModel.Description("ARadarBeaconThatMayBeUsedInConjunctionWithAtLeastOneOtherRadarBeaconToIndicateALeadingLine")]
		[EnumMember(Value = "Leading Racon/Radar Transponder Beacon")] 
		[XmlEnum("3")] 
		LeadingRaconRadarTransponderBeacon = 3,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum topmarkDaymarkShape : int {
		[System.ComponentModel.Description("IsWhereTheVertexPointsUpAConeIsASolidFigureGeneratedByStraightLinesDrawnFromAFixedPointTheVertexToACircleInAPlaneNotContainingTheVertexConesAreCommonlyUsedAsInternationalAssociationOfLighthouseAuthoritiesIalaTopmarksLateral")]
		[EnumMember(Value = "Cone (Point Up)")] 
		[XmlEnum("1")] 
		ConePointUp = 1,

		[System.ComponentModel.Description("IsWhereTheVertexPointsDownAConeIsASolidFigureGeneratedByStraightLinesDrawnFromAFixedPointTheVertexToACircleInAPlaneNotContainingTheVertexConesAreCommonlyUsedAsInternationalAssociationOfLighthouseAuthoritiesIalaTopmarksLateral")]
		[EnumMember(Value = "Cone (Point Down)")] 
		[XmlEnum("2")] 
		ConePointDown = 2,

		[System.ComponentModel.Description("ACurvedSurfaceAllPointsOfWhichAreEquidistantFromAFixedPointWithinCalledTheCentre")]
		[EnumMember(Value = "Sphere")] 
		[XmlEnum("3")] 
		Sphere = 3,

		[System.ComponentModel.Description("TwoSpheresOneAboveTheOtherTwoBlackSpheresAreCommonlyUsedAsAnInternationalAssociationOfLighthouseAuthoritiesIalaTopmarkIsolatedDanger")]
		[EnumMember(Value = "2 Spheres")] 
		[XmlEnum("4")] 
		twoSpheres = 4,

		[System.ComponentModel.Description("ASolidGeometricalFigureGeneratedByStraightLinesFixedInDirectionAndDescribingWithOneOfPointAClosedCurveEspeciallyACircleInWhichCaseTheFigureIsCircularCylinderItSEndsBeingParallelCirclesCylindersAreCommonlyUsedAsInternationalAssociationOfLighthouseAuthoritiesIalaTopmarksLateral")]
		[EnumMember(Value = "Cylinder")] 
		[XmlEnum("5")] 
		Cylinder = 5,

		[System.ComponentModel.Description("UsuallyOfRectangularShapeMadeFromTimberOrMetalAndUsedToProvideAContrastWithTheNaturalBackgroundOfADaymarkTheActualDaymarkIsOftenPaintedOnToThisBoard")]
		[EnumMember(Value = "Board")] 
		[XmlEnum("6")] 
		Board = 6,

		[System.ComponentModel.Description("HavingAShapeOrACrossSectionLikeTheCapitalLetterXAnXShapeAsAnInternationalAssociationOfLighthouseAuthoritiesIalaTopmarkShouldBe3DimensionalInShapeItIsMadeOfAtLeastThreeCrossedBars")]
		[EnumMember(Value = "X-Shaped")] 
		[XmlEnum("7")] 
		XShaped = 7,

		[System.ComponentModel.Description("ACrossWithOneVerticalMemberAndOneHorizontalMemberThatIsSimilarInShapeToTheCharacter")]
		[EnumMember(Value = "Upright Cross")] 
		[XmlEnum("8")] 
		UprightCross = 8,

		[System.ComponentModel.Description("ACubeStandingOnOneOfItsVertexesACubeIsASolidContainedBySixEqualSquaresARegularHexahedron")]
		[EnumMember(Value = "Cube (Point Up)")] 
		[XmlEnum("9")] 
		CubePointUp = 9,

		[System.ComponentModel.Description("twoConesOneAboveTheOtherWithTheirVerticesTogetherInTheCentre")]
		[EnumMember(Value = "2 Cones (Point to Point)")] 
		[XmlEnum("10")] 
		twoConesPointToPoint = 10,

		[System.ComponentModel.Description("twoConesOneAboveTheOtherWithTheirBasesTogetherInTheCentreAndTheirVerticesPointingUpAndDown")]
		[EnumMember(Value = "2 Cones (Base to Base)")] 
		[XmlEnum("11")] 
		twoConesBaseToBase = 11,

		[System.ComponentModel.Description("APlaneFigureHavingFourEqualSidesAndEqualOppositeAnglesTwoAcuteAndTwoObtuseAnObliqueEquilateralParallelogram")]
		[EnumMember(Value = "Rhombus")] 
		[XmlEnum("12")] 
		Rhombus = 12,

		[System.ComponentModel.Description("twoConesOneAboveTheOtherWithTheirVerticesPointingUp")]
		[EnumMember(Value = "2 Cones (Points Upward)")] 
		[XmlEnum("13")] 
		twoConesPointsUpward = 13,

		[System.ComponentModel.Description("twoConesOneAboveTheOtherWithTheirVerticesPointingDown")]
		[EnumMember(Value = "2 Cones (Points Downward)")] 
		[XmlEnum("14")] 
		twoConesPointsDownward = 14,

		[System.ComponentModel.Description("BesomABundleOfRodsOrTwigsPerchAStaffPlacedOnTopOfABuoyRockOrShoalAsAMarkForNavigationABesomPointUpIsWhereTheThickerUntiedEndOfTheBesomIsAtTheBottom")]
		[EnumMember(Value = "Besom (Point Up)")] 
		[XmlEnum("15")] 
		BesomPointUp = 15,

		[System.ComponentModel.Description("BesomABundleOfRodsOrTwigsPerchAStaffPlacedOnTopOfABuoyRockOrShoalAsAMarkForNavigationABesomPointDownIsWhereTheThinnerTiedEndOfTheBesomIsAtTheBottom")]
		[EnumMember(Value = "Besom (Point Down)")] 
		[XmlEnum("16")] 
		BesomPointDown = 16,

		[System.ComponentModel.Description("AFlagMountedOnAShortPole")]
		[EnumMember(Value = "Flag")] 
		[XmlEnum("17")] 
		Flag = 17,

		[System.ComponentModel.Description("ASphereLocatedAboveARhombus")]
		[EnumMember(Value = "Sphere Over a Rhombus")] 
		[XmlEnum("18")] 
		SphereOverARhombus = 18,

		[System.ComponentModel.Description("APlaneFigureWithFourRightAnglesAndFourEqualStraightSides")]
		[EnumMember(Value = "Square")] 
		[XmlEnum("19")] 
		Square = 19,

		[System.ComponentModel.Description("WhereTheTwoLongerOppositeSidesAreStandingHorizontallyARectangleIsAPlaneFigureWithFourRightAnglesAndFourStraightSidesOppositeSidesBeingParallelAndEqualInLength")]
		[EnumMember(Value = "Rectangle (Horizontal)")] 
		[XmlEnum("20")] 
		RectangleHorizontal = 20,

		[System.ComponentModel.Description("WhereTheTwoLongerOppositeSidesAreStandingVerticallyARectangleIsAPlaneFigureWithFourRightAnglesAndFourStraightSidesOppositeSidesBeingParallelAndEqualInLength")]
		[EnumMember(Value = "Rectangle (Vertical)")] 
		[XmlEnum("21")] 
		RectangleVertical = 21,

		[System.ComponentModel.Description("AQuadrilateralHavingOnePairOfOppositeSidesParallelAndWhichStandsOnItsLongerParallelSide")]
		[EnumMember(Value = "Trapezium (Up)")] 
		[XmlEnum("22")] 
		TrapeziumUp = 22,

		[System.ComponentModel.Description("AQuadrilateralHavingOnePairOfOppositeSidesParallelAndWhichStandsOnItsShorterParallelSide")]
		[EnumMember(Value = "Trapezium (Down)")] 
		[XmlEnum("23")] 
		TrapeziumDown = 23,

		[System.ComponentModel.Description("AFigureHavingThreeAnglesAndThreeSidesAndWhichHasAVertexAtTheTop")]
		[EnumMember(Value = "Triangle (Point Up)")] 
		[XmlEnum("24")] 
		TrianglePointUp = 24,

		[System.ComponentModel.Description("AFigureHavingThreeAnglesAndThreeSidesAndWhichHasASideAtTheTop")]
		[EnumMember(Value = "Triangle (Point Down)")] 
		[XmlEnum("25")] 
		TrianglePointDown = 25,

		[System.ComponentModel.Description("APerfectlyRoundPlaneFigureWhoseCircumferenceIsEverywhereEquidistantFromItsCentre")]
		[EnumMember(Value = "Circle")] 
		[XmlEnum("26")] 
		Circle = 26,

		[System.ComponentModel.Description("TwoUprightCrossesGenerallyVerticallyDisposedOneAboveTheOther")]
		[EnumMember(Value = "Two Upright Crosses (One Over the Other)")] 
		[XmlEnum("27")] 
		TwoUprightCrossesOneOverTheOther = 27,

		[System.ComponentModel.Description("HavingAShapeLikeTheCapitalLetterT")]
		[EnumMember(Value = "T-Shape")] 
		[XmlEnum("28")] 
		TShape = 28,

		[System.ComponentModel.Description("ATriangleVertexUppermostLocatedAboveACircle")]
		[EnumMember(Value = "Triangle Pointing Up Over a Circle")] 
		[XmlEnum("29")] 
		TrianglePointingUpOverACircle = 29,

		[System.ComponentModel.Description("AnUprightCrossLocatedAboveACircle")]
		[EnumMember(Value = "Upright Cross Over a Circle")] 
		[XmlEnum("30")] 
		UprightCrossOverACircle = 30,

		[System.ComponentModel.Description("ARhombusLocatedAboveACircle")]
		[EnumMember(Value = "Rhombus Over a Circle")] 
		[XmlEnum("31")] 
		RhombusOverACircle = 31,

		[System.ComponentModel.Description("ACircleLocatedOverATriangleVertexUppermost")]
		[EnumMember(Value = "Circle Over a Triangle Pointing Up")] 
		[XmlEnum("32")] 
		CircleOverATrianglePointingUp = 32,

		[System.ComponentModel.Description("AnUncommonAndOrNonStandardizedShapeAsTextuallyDescribedUsingAnAssociatedAttribute")]
		[EnumMember(Value = "Other Shape (See Shape Information)")] 
		[XmlEnum("33")] 
		OtherShapeSeeShapeInformation = 33,

		[System.ComponentModel.Description("HavingTheFormOfOrConsistingOfATube")]
		[EnumMember(Value = "Tubular")] 
		[XmlEnum("34")] 
		Tubular = 34,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSpecialPurposeMark : int {
		[System.ComponentModel.Description("AMarkUsedToIndicateAFiringDangerAreaUsuallyAtSea")]
		[EnumMember(Value = "Firing Danger Mark")] 
		[XmlEnum("1")] 
		FiringDangerMark = 1,

		[System.ComponentModel.Description("AnyObjectTowardWhichSomethingIsDirectedTheDistinctiveMarkingOrInstrumentationOfAGroundPointToAidItsIdentificationOnAPhotograph")]
		[EnumMember(Value = "Target Mark")] 
		[XmlEnum("2")] 
		TargetMark = 2,

		[System.ComponentModel.Description("AMarkMarkingThePositionOfAShipWhichIsUsedAsATargetDuringSomeMilitaryExercise")]
		[EnumMember(Value = "Marker Ship Mark")] 
		[XmlEnum("3")] 
		MarkerShipMark = 3,

		[System.ComponentModel.Description("AMarkUsedToIndicateADegaussingRange")]
		[EnumMember(Value = "Degaussing Range Mark")] 
		[XmlEnum("4")] 
		DegaussingRangeMark = 4,

		[System.ComponentModel.Description("AMarkOfRelevanceToBarges")]
		[EnumMember(Value = "Barge Mark")] 
		[XmlEnum("5")] 
		BargeMark = 5,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfSubmarineCablesOrThePointAtWhichTheyRunOnToTheLand")]
		[EnumMember(Value = "Cable Mark")] 
		[XmlEnum("6")] 
		CableMark = 6,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheLimitOfASpoilGround")]
		[EnumMember(Value = "Spoil Ground Mark")] 
		[XmlEnum("7")] 
		SpoilGroundMark = 7,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfAnOutfallOrThePointAtWhichItLeavesTheLand")]
		[EnumMember(Value = "Outfall Mark")] 
		[XmlEnum("8")] 
		OutfallMark = 8,

		[System.ComponentModel.Description("OceanDataAcquisitionSystem")]
		[EnumMember(Value = "ODAS")] 
		[XmlEnum("9")] 
		Odas = 9,

		[System.ComponentModel.Description("AMarkUsedToRecordDataForScientificPurposes")]
		[EnumMember(Value = "Recording Mark")] 
		[XmlEnum("10")] 
		RecordingMark = 10,

		[System.ComponentModel.Description("AMarkUsedToIndicateASeaplaneAnchorage")]
		[EnumMember(Value = "Seaplane Anchorage Mark")] 
		[XmlEnum("11")] 
		SeaplaneAnchorageMark = 11,

		[System.ComponentModel.Description("AMarkUsedToIndicateARecreationZone")]
		[EnumMember(Value = "Recreation Zone Mark")] 
		[XmlEnum("12")] 
		RecreationZoneMark = 12,

		[System.ComponentModel.Description("APrivatelyMaintainedMark")]
		[EnumMember(Value = "Private Mark")] 
		[XmlEnum("13")] 
		PrivateMark = 13,

		[System.ComponentModel.Description("AMarkIndicatingAMooringOrMoorings")]
		[EnumMember(Value = "Mooring Mark")] 
		[XmlEnum("14")] 
		MooringMark = 14,

		[System.ComponentModel.Description("ALargeBuoyDesignedToTakeThePlaceOfALightshipWhereConstructionOfAnOffshoreLightStationIsNotFeasible")]
		[EnumMember(Value = "LANBY")] 
		[XmlEnum("15")] 
		Lanby = 15,

		[System.ComponentModel.Description("AidsToNavigationOrOtherIndicatorsSoLocatedAsToIndicateThePathToBeFollowedLeadingMarksIdentifyALeadingLineWhenTheyAreInTransit")]
		[EnumMember(Value = "Leading Mark")] 
		[XmlEnum("16")] 
		LeadingMark = 16,

		[System.ComponentModel.Description("AMarkFormingPartOfATransitIndicatingOneEndOfAMeasuredDistance")]
		[EnumMember(Value = "Measured Distance Mark")] 
		[XmlEnum("17")] 
		MeasuredDistanceMark = 17,

		[System.ComponentModel.Description("ANoticeBoardOrSignIndicatingInformationToTheMariner")]
		[EnumMember(Value = "Notice Mark")] 
		[XmlEnum("18")] 
		NoticeMark = 18,

		[System.ComponentModel.Description("AMarkIndicatingATrafficSeparationScheme")]
		[EnumMember(Value = "TSS Mark")] 
		[XmlEnum("19")] 
		TssMark = 19,

		[System.ComponentModel.Description("AMarkIndicatingAnAnchoringProhibitedArea")]
		[EnumMember(Value = "Anchoring Prohibited Mark")] 
		[XmlEnum("20")] 
		AnchoringProhibitedMark = 20,

		[System.ComponentModel.Description("AMarkIndicatingThatBerthingIsProhibited")]
		[EnumMember(Value = "Berthing Prohibited Mark")] 
		[XmlEnum("21")] 
		BerthingProhibitedMark = 21,

		[System.ComponentModel.Description("AMarkIndicatingThatOvertakingIsProhibited")]
		[EnumMember(Value = "Overtaking Prohibited Mark")] 
		[XmlEnum("22")] 
		OvertakingProhibitedMark = 22,

		[System.ComponentModel.Description("AMarkIndicatingAOneWayRoute")]
		[EnumMember(Value = "Two-Way Traffic Prohibited Mark")] 
		[XmlEnum("23")] 
		TwoWayTrafficProhibitedMark = 23,

		[System.ComponentModel.Description("AMarkIndicatingThatVesselsMustNotGenerateExcessiveWake")]
		[EnumMember(Value = "Reduced Wake Mark")] 
		[XmlEnum("24")] 
		ReducedWakeMark = 24,

		[System.ComponentModel.Description("AMarkIndicatingThatASpeedLimitApplies")]
		[EnumMember(Value = "Speed Limit Mark")] 
		[XmlEnum("25")] 
		SpeedLimitMark = 25,

		[System.ComponentModel.Description("AMarkIndicatingThePlaceWhereTheBowOfAShipMustStopWhenTrafficLightsShowRed")]
		[EnumMember(Value = "Stop Mark")] 
		[XmlEnum("26")] 
		StopMark = 26,

		[System.ComponentModel.Description("AMarkIndicatingThatSpecialCautionMustBeExercisedInTheVicinityOfTheMark")]
		[EnumMember(Value = "General Warning Mark")] 
		[XmlEnum("27")] 
		GeneralWarningMark = 27,

		[System.ComponentModel.Description("AMarkIndicatingThatAShipShouldSoundItsSirenOrHorn")]
		[EnumMember(Value = "Sound Ship's Siren Mark")] 
		[XmlEnum("28")] 
		SoundShipSSirenMark = 28,

		[System.ComponentModel.Description("AMarkIndicatingTheMinimumVerticalSpaceAvailableForPassage")]
		[EnumMember(Value = "Restricted Vertical Clearance Mark")] 
		[XmlEnum("29")] 
		RestrictedVerticalClearanceMark = 29,

		[System.ComponentModel.Description("AMarkIndicatingTheMaximumDraughtOfVesselPermitted")]
		[EnumMember(Value = "Maximum Vessel's Draught Mark")] 
		[XmlEnum("30")] 
		MaximumVesselSDraughtMark = 30,

		[System.ComponentModel.Description("AMarkIndicatingTheMinimumHorizontalSpaceAvailableForPassage")]
		[EnumMember(Value = "Restricted Horizontal Clearance Mark")] 
		[XmlEnum("31")] 
		RestrictedHorizontalClearanceMark = 31,

		[System.ComponentModel.Description("AMarkWarningOfStrongCurrents")]
		[EnumMember(Value = "Strong Current Warning Mark")] 
		[XmlEnum("32")] 
		StrongCurrentWarningMark = 32,

		[System.ComponentModel.Description("AMarkIndicatingThatBerthingIsAllowed")]
		[EnumMember(Value = "Berthing Permitted Mark")] 
		[XmlEnum("33")] 
		BerthingPermittedMark = 33,

		[System.ComponentModel.Description("AMarkIndicatingAnOverheadPowerCable")]
		[EnumMember(Value = "Overhead Power Cable Mark")] 
		[XmlEnum("34")] 
		OverheadPowerCableMark = 34,

		[System.ComponentModel.Description("AMarkIndicatingTheGradientOfTheSlopeOfADredgeChannelEdge")]
		[EnumMember(Value = "Channel Edge Gradient Mark")] 
		[XmlEnum("35")] 
		ChannelEdgeGradientMark = 35,

		[System.ComponentModel.Description("AMarkIndicatingThePresenceOfATelephone")]
		[EnumMember(Value = "Telephone Mark")] 
		[XmlEnum("36")] 
		TelephoneMark = 36,

		[System.ComponentModel.Description("AMarkIndicatingThatAFerryRouteCrossesTheShipRouteOftenUsedWithASoundShipSSirenMark")]
		[EnumMember(Value = "Ferry Crossing Mark")] 
		[XmlEnum("37")] 
		FerryCrossingMark = 37,

		[System.ComponentModel.Description("AMarkUsedToIndicateThePositionOfSubmarinePipelinesOrThePointAtWhichTheyRunOnToTheLand")]
		[EnumMember(Value = "Pipeline Mark")] 
		[XmlEnum("39")] 
		PipelineMark = 39,

		[System.ComponentModel.Description("AMarkIndicatingAnAnchorageArea")]
		[EnumMember(Value = "Anchorage Mark")] 
		[XmlEnum("40")] 
		AnchorageMark = 40,

		[System.ComponentModel.Description("AMarkUsedToIndicateAClearingLine")]
		[EnumMember(Value = "Clearing Mark")] 
		[XmlEnum("41")] 
		ClearingMark = 41,

		[System.ComponentModel.Description("AMarkIndicatingTheLocationAtWhichARestrictionOrRequirementExists")]
		[EnumMember(Value = "Control Mark")] 
		[XmlEnum("42")] 
		ControlMark = 42,

		[System.ComponentModel.Description("AMarkIndicatingThatDivingMayTakePlaceInTheVicinity")]
		[EnumMember(Value = "Diving Mark")] 
		[XmlEnum("43")] 
		DivingMark = 43,

		[System.ComponentModel.Description("AMarkProvidingOrIndicatingAPlaceOfSafety")]
		[EnumMember(Value = "Refuge Beacon")] 
		[XmlEnum("44")] 
		RefugeBeacon = 44,

		[System.ComponentModel.Description("AMarkIndicatingAFoulGround")]
		[EnumMember(Value = "Foul Ground Mark")] 
		[XmlEnum("45")] 
		FoulGroundMark = 45,

		[System.ComponentModel.Description("AMarkInstalledForUseByYachtsmen")]
		[EnumMember(Value = "Yachting Mark")] 
		[XmlEnum("46")] 
		YachtingMark = 46,

		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereHelicoptersMayLand")]
		[EnumMember(Value = "Heliport Mark")] 
		[XmlEnum("47")] 
		HeliportMark = 47,

		[System.ComponentModel.Description("AMarkIndicatingALocationAtWhichAGnssPositionHasBeenAccuratelyDetermined")]
		[EnumMember(Value = "GNSS Mark")] 
		[XmlEnum("48")] 
		GnssMark = 48,

		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereSeaPlanesLand")]
		[EnumMember(Value = "Seaplane Landing Mark")] 
		[XmlEnum("49")] 
		SeaplaneLandingMark = 49,

		[System.ComponentModel.Description("AMarkIndicatingThatEntryIsProhibited")]
		[EnumMember(Value = "Entry Prohibited Mark")] 
		[XmlEnum("50")] 
		EntryProhibitedMark = 50,

		[System.ComponentModel.Description("AMarkIndicatingThatWorkGenerallyConstructionIsInProgress")]
		[EnumMember(Value = "Work in Progress Mark")] 
		[XmlEnum("51")] 
		WorkInProgressMark = 51,

		[System.ComponentModel.Description("AMarkWhoseDetailedCharacteristicsAreUnknown")]
		[EnumMember(Value = "Mark With Unknown Purpose")] 
		[XmlEnum("52")] 
		MarkWithUnknownPurpose = 52,

		[System.ComponentModel.Description("AMarkIndicatingABoreholeThatProducesOrIsCapableOfProducingOilOrNaturalGas")]
		[EnumMember(Value = "Wellhead Mark")] 
		[XmlEnum("53")] 
		WellheadMark = 53,

		[System.ComponentModel.Description("AMarkIndicatingThePointAtWhichAChannelDividesSeparatelyIntoTwoChannels")]
		[EnumMember(Value = "Channel Separation Mark")] 
		[XmlEnum("54")] 
		ChannelSeparationMark = 54,

		[System.ComponentModel.Description("AMarkIndicatingTheExistenceOfAFishMusselOysterOrPearlFarmCulture")]
		[EnumMember(Value = "Marine Farm Mark")] 
		[XmlEnum("55")] 
		MarineFarmMark = 55,

		[System.ComponentModel.Description("AMarkIndicatingTheExistenceOrTheExtentOfAnArtificialReef")]
		[EnumMember(Value = "Artificial Reef Mark")] 
		[XmlEnum("56")] 
		ArtificialReefMark = 56,

		[System.ComponentModel.Description("AMarkUsedYearRoundThatMayBeSubmergedWhenIcePassesThroughTheArea")]
		[EnumMember(Value = "Ice Mark")] 
		[XmlEnum("57")] 
		IceMark = 57,

		[System.ComponentModel.Description("AMarkUsedToDefineTheBoundaryOfANatureReserve")]
		[EnumMember(Value = "Nature Reserve Mark")] 
		[XmlEnum("58")] 
		NatureReserveMark = 58,

		[System.ComponentModel.Description("AFishAggregatingOrAggregationDeviceFadIsAManMadeObjectUsedToAttractOceanGoingPelagicFishSuchAsMarlinTunaAndMahiMahiDolphinFishTheyUsuallyConsistOfBuoysOrFloatsTetheredToTheOceanFloorWithConcreteBlocks")]
		[EnumMember(Value = "Fish Aggregating Device")] 
		[XmlEnum("59")] 
		FishAggregatingDevice = 59,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfAWreck")]
		[EnumMember(Value = "Wreck Mark")] 
		[XmlEnum("60")] 
		WreckMark = 60,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfACustomsCheckpoint")]
		[EnumMember(Value = "Customs Mark")] 
		[XmlEnum("61")] 
		CustomsMark = 61,

		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfACauseway")]
		[EnumMember(Value = "Causeway Mark")] 
		[XmlEnum("62")] 
		CausewayMark = 62,

		[System.ComponentModel.Description("ASurfaceFollowingBuoyUsedToMeasureWaveActivity")]
		[EnumMember(Value = "Wave Recorder")] 
		[XmlEnum("63")] 
		WaveRecorder = 63,

		[System.ComponentModel.Description("AMarkIndicatingAJetskiProhibitedArea")]
		[EnumMember(Value = "Jetski Prohibited")] 
		[XmlEnum("64")] 
		JetskiProhibited = 64,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadioStation : int {
		[System.ComponentModel.Description("ARadioStationWhichNeedNotNecessarilyBeMannedTheEmissionsOfWhichRadiatedAroundTheHorizonEnableItsBearingToBeDeterminedByMeansOfTheRadioDirectionFinderOfAShip")]
		[EnumMember(Value = "Circular (Non-Directional) Marine or Aero-Marine Radiobeacon")] 
		[XmlEnum("1")] 
		CircularNonDirectionalMarineOrAeroMarineRadiobeacon = 1,

		[System.ComponentModel.Description("ASpecialTypeOfRadiobeaconStationTheEmissionsOfWhichAreIntendedToProvideADefiniteTrackForGuidance")]
		[EnumMember(Value = "Directional Radiobeacon")] 
		[XmlEnum("2")] 
		DirectionalRadiobeacon = 2,

		[System.ComponentModel.Description("ASpecialTypeOfRadiobeaconStationEmittingABeamOfWavesToWhichAUniformTurningMovementIsGivenTheBearingOfTheStationBeingDeterminedByMeansOfAnOrdinaryListeningReceiverAndAStopWatchAlsoReferredToAsARotatingLoopRadiobeacon")]
		[EnumMember(Value = "Rotating Pattern Radiobeacon")] 
		[XmlEnum("3")] 
		RotatingPatternRadiobeacon = 3,

		[System.ComponentModel.Description("ATypeOfLongRangePositionFixingBeacon")]
		[EnumMember(Value = "Consol Beacon")] 
		[XmlEnum("4")] 
		ConsolBeacon = 4,

		[System.ComponentModel.Description("ARadioStationIntendedToDetermineOnlyTheDirectionOfOtherStationsByMeansOfTransmissionFromTheLatter")]
		[EnumMember(Value = "Radio Direction-Finding Station")] 
		[XmlEnum("5")] 
		RadioDirectionFindingStation = 5,

		[System.ComponentModel.Description("ARadioStationWhichIsPreparedToProvideQtgServiceThatIsToSayToTransmitUponRequestFromAShipARadioSignalTheBearingOfWhichCanBeTakenByThatShip")]
		[EnumMember(Value = "Coast Radio Station Providing QTG Service")] 
		[XmlEnum("6")] 
		CoastRadioStationProvidingQtgService = 6,

		[System.ComponentModel.Description("ARadioBeaconDesignedForAeronauticalUse")]
		[EnumMember(Value = "Aeronautical Radiobeacon")] 
		[XmlEnum("7")] 
		AeronauticalRadiobeacon = 7,

		[System.ComponentModel.Description("TheDeccaNavigatorSystemIsAHighAccuracyShortToMediumRangeRadioNavigationalAidIntendedForCoastalAndLandfallNavigation")]
		[EnumMember(Value = "Decca")] 
		[XmlEnum("8")] 
		Decca = 8,

		[System.ComponentModel.Description("ALowFrequencyElectronicPositionFixingSystemUsingPulsedTransmissionsAt100Khz")]
		[EnumMember(Value = "Loran C")] 
		[XmlEnum("9")] 
		LoranC = 9,

		[System.ComponentModel.Description("ARadiobeaconTransmittingDgpsCorrectionSignals")]
		[EnumMember(Value = "Differential GNSS")] 
		[XmlEnum("10")] 
		DifferentialGnss = 10,

		[System.ComponentModel.Description("AnElectronicPositionFixingSystemUsedMainlyByAircraft")]
		[EnumMember(Value = "Toran")] 
		[XmlEnum("11")] 
		Toran = 11,

		[System.ComponentModel.Description("ALongRangeRadioNavigationalAidWhichOperatesWithinTheVlfFrequencyBandTheSystemComprisesEightLandBasedStations")]
		[EnumMember(Value = "Omega")] 
		[XmlEnum("12")] 
		Omega = 12,

		[System.ComponentModel.Description("ARangingPositionFixingSystemOperatingAt420450MhzOverARangeOfUpTo400Km")]
		[EnumMember(Value = "Syledis")] 
		[XmlEnum("13")] 
		Syledis = 13,

		[System.ComponentModel.Description("ChaikaIsALowFrequencyElectronicPositionFixingSystemUsingPulsedTransmissionsAt100Khz")]
		[EnumMember(Value = "Chaika")] 
		[XmlEnum("14")] 
		Chaika = 14,

		[System.ComponentModel.Description("TheEquipmentNeededAtOneStationToCarryOnTwoWayVoiceCommunicationByRadioWavesOnly")]
		[EnumMember(Value = "Radio Telephone Station")] 
		[XmlEnum("19")] 
		RadioTelephoneStation = 19,

		[System.ComponentModel.Description("AnOnshoreAisUnitThatMonitorsTrafficInTheWaterways")]
		[EnumMember(Value = "AIS Base Station")] 
		[XmlEnum("20")] 
		AisBaseStation = 20,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFogSignal : int {
		[System.ComponentModel.Description("ASignalProducedByTheFiringOfExplosiveCharges")]
		[EnumMember(Value = "Explosive")] 
		[XmlEnum("1")] 
		Explosive = 1,

		[System.ComponentModel.Description("ADiaphoneUsesCompressedAirAndGenerallyEmitsAPowerfulLowPitchedSoundWhichOftenConcludesWithABriefSoundOfSuddenlyLoweredPitchTermedTheGrunt")]
		[EnumMember(Value = "Diaphone")] 
		[XmlEnum("2")] 
		Diaphone = 2,

		[System.ComponentModel.Description("ATypeOfFogSignalApparatusWhichProducesSoundByVirtueOfThePassageOfAirThroughSlotsOrHolesInARevolvingDisk")]
		[EnumMember(Value = "Siren")] 
		[XmlEnum("3")] 
		Siren = 3,

		[System.ComponentModel.Description("AHornHavingADiaphragmOscillatedByElectricity")]
		[EnumMember(Value = "Nautophone")] 
		[XmlEnum("4")] 
		Nautophone = 4,

		[System.ComponentModel.Description("oneAReedUsesCompressedAirAndEmitsAWeakHighPitchedSound2AnyOfVariousWaterOrMarshPlantsWithAFirmStemConciseOxfordEnglishDictionary")]
		[EnumMember(Value = "Reed")] 
		[XmlEnum("5")] 
		Reed = 5,

		[System.ComponentModel.Description("ADiaphragmHornWhichOperatesUnderTheInfluenceOfCompressedAirOrSteam")]
		[EnumMember(Value = "Tyfon")] 
		[XmlEnum("6")] 
		Tyfon = 6,

		[System.ComponentModel.Description("ARingingSoundWithAShortRange")]
		[EnumMember(Value = "Bell")] 
		[XmlEnum("7")] 
		Bell = 7,

		[System.ComponentModel.Description("ADistinctiveSoundMadeByAJetOfAirPassingThroughAnOrificeTheApparatusMayBeOperatedAutomaticallyByHandOrByAirBeingForcedUpATubeByWavesActingOnABuoy")]
		[EnumMember(Value = "Whistle")] 
		[XmlEnum("8")] 
		Whistle = 8,

		[System.ComponentModel.Description("ASoundProducedByVibrationOfADiscWhenStruck")]
		[EnumMember(Value = "Gong")] 
		[XmlEnum("9")] 
		Gong = 9,

		[System.ComponentModel.Description("AHornUsesCompressedAirOrElectricityToVibrateADiaphragmAndExistsInAVarietyOfTypesWhichDifferGreatlyInTheirSoundAndPower")]
		[EnumMember(Value = "Horn")] 
		[XmlEnum("10")] 
		Horn = 10,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightVisibility : int {
		[System.ComponentModel.Description("NonMarineLightsWithAHigherPowerThanMarineLightsAndVisibleFromWellOffShoreOftenAeroLights")]
		[EnumMember(Value = "High Intensity")] 
		[XmlEnum("1")] 
		HighIntensity = 1,

		[System.ComponentModel.Description("NonMarineLightsWithLowerPowerThanMarineLights")]
		[EnumMember(Value = "Low Intensity")] 
		[XmlEnum("2")] 
		LowIntensity = 2,

		[System.ComponentModel.Description("ADecreaseInTheApparentIntensityOfALightWhichMayOccurInTheCaseOfPartialObstructions")]
		[EnumMember(Value = "Faint")] 
		[XmlEnum("3")] 
		Faint = 3,

		[System.ComponentModel.Description("ALightInASectorIsIntensifiedThatIsHasLongerRangeThanOtherSectors")]
		[EnumMember(Value = "Intensified")] 
		[XmlEnum("4")] 
		Intensified = 4,

		[System.ComponentModel.Description("ALightInASectorIsUnintensifiedThatIsHasShorterRangeThanOtherSectors")]
		[EnumMember(Value = "Unintensified")] 
		[XmlEnum("5")] 
		Unintensified = 5,

		[System.ComponentModel.Description("ALightSectorIsDeliberatelyReducedInIntensityForExampleToReduceItsEffectOnABuiltUpArea")]
		[EnumMember(Value = "Visibility Deliberately Restricted")] 
		[XmlEnum("6")] 
		VisibilityDeliberatelyRestricted = 6,

		[System.ComponentModel.Description("SaidOfTheArcOfALightSectorDesignatedByItsLimitingBearingsInWhichTheLightIsNotVisibleFromSeaward")]
		[EnumMember(Value = "Obscured")] 
		[XmlEnum("7")] 
		Obscured = 7,

		[System.ComponentModel.Description("ThisValueSpecifiesThatPartsOfTheSectorAreObscured")]
		[EnumMember(Value = "Partially Obscured")] 
		[XmlEnum("8")] 
		PartiallyObscured = 8,

		[System.ComponentModel.Description("LightsThatMustInLineToBeVisible")]
		[EnumMember(Value = "Visible in Line of Range")] 
		[XmlEnum("9")] 
		VisibleInLineOfRange = 9,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum signalGeneration : int {
		[System.ComponentModel.Description("SignalGenerationIsInitiatedByASelfRegulatingMechanismSuchAsATimerOrLightSensor")]
		[EnumMember(Value = "Automatically")] 
		[XmlEnum("1")] 
		Automatically = 1,

		[System.ComponentModel.Description("TheSignalIsGeneratedByTheMotionOfTheSeaSurfaceSuchAsABellInABuoy")]
		[EnumMember(Value = "By Wave Action")] 
		[XmlEnum("2")] 
		ByWaveAction = 2,

		[System.ComponentModel.Description("TheSignalIsGeneratedByAManuallyOperatedMechanismSuchAsAHandCrankedSiren")]
		[EnumMember(Value = "By Hand")] 
		[XmlEnum("3")] 
		ByHand = 3,

		[System.ComponentModel.Description("TheSignalIsGeneratedByTheMotionOfAirSuchAsAWindDrivenWhistle")]
		[EnumMember(Value = "By Wind")] 
		[XmlEnum("4")] 
		ByWind = 4,

		[System.ComponentModel.Description("ActivatedByRadioSignal")]
		[EnumMember(Value = "Radio Activated")] 
		[XmlEnum("5")] 
		RadioActivated = 5,

		[System.ComponentModel.Description("ActivatedByMakingACallToAMannedStation")]
		[EnumMember(Value = "Call Activated")] 
		[XmlEnum("6")] 
		CallActivated = 6,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum exhibitionConditionOfLight : int {
		[System.ComponentModel.Description("ALightShownThroughoutThe24HoursWithoutChangeOfCharacter")]
		[EnumMember(Value = "Light Shown Without Change of Character")] 
		[XmlEnum("1")] 
		LightShownWithoutChangeOfCharacter = 1,

		[System.ComponentModel.Description("ALightWhichIsOnlyExhibitedByDay")]
		[EnumMember(Value = "Daytime Light")] 
		[XmlEnum("2")] 
		DaytimeLight = 2,

		[System.ComponentModel.Description("ALightWhichIsExhibitedInFogOrConditionsOfReducedVisibility")]
		[EnumMember(Value = "Fog Light")] 
		[XmlEnum("3")] 
		FogLight = 3,

		[System.ComponentModel.Description("ALightWhichIsOnlyExhibitedAtNight")]
		[EnumMember(Value = "Night Light")] 
		[XmlEnum("4")] 
		NightLight = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLight : int {
		[System.ComponentModel.Description("ALightIlluminatingASectorOfVeryNarrowAngleAndIntendedToMarkADirectionToFollow")]
		[EnumMember(Value = "Directional Function")] 
		[XmlEnum("1")] 
		DirectionalFunction = 1,

		[System.ComponentModel.Description("ALightAssociatedWithOtherLightsSoAsToFormALeadingLineToBeFollowed")]
		[EnumMember(Value = "Leading Light")] 
		[XmlEnum("4")] 
		LeadingLight = 4,

		[System.ComponentModel.Description("AnAeroLightIsEstablishedForAeronauticalNavigationAndMayBeOfHigherPowerThanMarineLightsAndVisibleFromWellOffshore")]
		[EnumMember(Value = "Aero Light")] 
		[XmlEnum("5")] 
		AeroLight = 5,

		[System.ComponentModel.Description("ALightMarkingAnObstacleWhichConstitutesADangerToAirNavigation")]
		[EnumMember(Value = "Air Obstruction Light")] 
		[XmlEnum("6")] 
		AirObstructionLight = 6,

		[System.ComponentModel.Description("ABroadBeamLightUsedToIlluminateAStructureOrArea")]
		[EnumMember(Value = "Flood Light")] 
		[XmlEnum("8")] 
		FloodLight = 8,

		[System.ComponentModel.Description("ALightWhoseSourceHasALinearFormGenerallyHorizontalWhichCanReachALengthOfSeveralMetres")]
		[EnumMember(Value = "Strip Light")] 
		[XmlEnum("9")] 
		StripLight = 9,

		[System.ComponentModel.Description("ALightPlacedOnOrNearTheSupportOfAMainLightAndHavingASpecialUseInNavigation")]
		[EnumMember(Value = "Subsidiary Light")] 
		[XmlEnum("10")] 
		SubsidiaryLight = 10,

		[System.ComponentModel.Description("APowerfulLightFocusedSoAsToIlluminateASmallArea")]
		[EnumMember(Value = "Spotlight")] 
		[XmlEnum("11")] 
		Spotlight = 11,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Front")] 
		[XmlEnum("12")] 
		Front = 12,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Rear")] 
		[XmlEnum("13")] 
		Rear = 13,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Lower")] 
		[XmlEnum("14")] 
		Lower = 14,

		[System.ComponentModel.Description("TermUsedWithLeadingLightsToDescribeThePositionOfTheLightOnTheLeadAsViewedFromSeaward")]
		[EnumMember(Value = "Upper")] 
		[XmlEnum("15")] 
		Upper = 15,

		[System.ComponentModel.Description("ALightAvailableAsABackupToAMainLightWhichWillBeIlluminatedShouldTheMainLightFail")]
		[EnumMember(Value = "Emergency")] 
		[XmlEnum("17")] 
		Emergency = 17,

		[System.ComponentModel.Description("ALightWhichEnablesItsApproximateBearingToBeObtainedWithoutTheUseOfACompass")]
		[EnumMember(Value = "Bearing Light")] 
		[XmlEnum("18")] 
		BearingLight = 18,

		[System.ComponentModel.Description("AGroupOfLightsOfIdenticalCharacterAndAlmostIdenticalPositionThatAreDisposedHorizontally")]
		[EnumMember(Value = "Horizontally Disposed")] 
		[XmlEnum("19")] 
		HorizontallyDisposed = 19,

		[System.ComponentModel.Description("AGroupOfLightsOfIdenticalCharacterAndAlmostIdenticalPositionThatAreDisposedVertically")]
		[EnumMember(Value = "Vertically Disposed")] 
		[XmlEnum("20")] 
		VerticallyDisposed = 20,
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
	public enum techniqueOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAnInstrumentThatDeterminesDepthOfWaterByMeasuringTheTimeIntervalBetweenEmissionOfASonicOrUltrasonicSignalAndReturnOfItsEchoFromTheBottom")]
		[EnumMember(Value = "Found by Echo Sounder")] 
		[XmlEnum("1")] 
		FoundByEchoSounder = 1,

		[System.ComponentModel.Description("TheDepthWasComputedFromARecordProducedByActiveSonarInWhichFixedAcousticBeamsAreDirectedIntoTheWaterPerpendicularlyToTheDirectionOfTravelToScanTheSeabedAndGenerateARecordOfTheSeabedConfiguration")]
		[EnumMember(Value = "Found by Side Scan Sonar")] 
		[XmlEnum("2")] 
		FoundBySideScanSonar = 2,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAWideSwathEchoSounderThatUsesMultipleBeamsToMeasureDepthsDirectlyBelowAndTransverseToTheShipSTrack")]
		[EnumMember(Value = "Found by Multi Beam")] 
		[XmlEnum("3")] 
		FoundByMultiBeam = 3,

		[System.ComponentModel.Description("TheDepthWasDeterminedByAPersonSkilledInThePracticeOfDiving")]
		[EnumMember(Value = "Found by Diver")] 
		[XmlEnum("4")] 
		FoundByDiver = 4,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingALineGraduatedWithAttachedMarksAndFastenedToASoundingLead")]
		[EnumMember(Value = "Found by Lead Line")] 
		[XmlEnum("5")] 
		FoundByLeadLine = 5,

		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingABuoyedWireAtTheDesiredDepthByTwoLaunchesOrALeastDepthWasIdentifiedUsingTheSameTechnique")]
		[EnumMember(Value = "Swept by Wire-Drag")] 
		[XmlEnum("6")] 
		SweptByWireDrag = 6,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAnInstrumentThatMeasuresDistanceByEmittingTimedPulsesOfLaserLightAndMeasuringTheTimeBetweenEmissionAndReceptionOfTheReflectedPulses")]
		[EnumMember(Value = "Found by Laser")] 
		[XmlEnum("7")] 
		FoundByLaser = 7,

		[System.ComponentModel.Description("TheGivenAreaHasBeenSweptUsingASystemComprisedOfMultipleEchoSounderTransducersAttachedToBoomsDeployedFromTheSurveyVessel")]
		[EnumMember(Value = "Swept by Vertical Acoustic System")] 
		[XmlEnum("8")] 
		SweptByVerticalAcousticSystem = 8,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingAnInstrumentThatComparesElectromagneticSignals")]
		[EnumMember(Value = "Found by Electromagnetic Sensor")] 
		[XmlEnum("9")] 
		FoundByElectromagneticSensor = 9,

		[System.ComponentModel.Description("TheScienceOrArtOfObtainingReliableMeasurementsFromPhotographs")]
		[EnumMember(Value = "Photogrammetry")] 
		[XmlEnum("10")] 
		Photogrammetry = 10,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingInstrumentsPlacedAboardAnArtificialSatellite")]
		[EnumMember(Value = "Satellite Imagery")] 
		[XmlEnum("11")] 
		SatelliteImagery = 11,

		[System.ComponentModel.Description("TheDepthWasDeterminedByUsingLevellingTechniquesToFindTheElevationOfThePointRelativeToADatum")]
		[EnumMember(Value = "Found by Levelling")] 
		[XmlEnum("12")] 
		FoundByLevelling = 12,

		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingASideScanSonar")]
		[EnumMember(Value = "Swept by Side Scan Sonar")] 
		[XmlEnum("13")] 
		SweptBySideScanSonar = 13,

		[System.ComponentModel.Description("TheSoundingWasDeterminedFromABottomModelConstructedUsingAComputer")]
		[EnumMember(Value = "Computer Generated")] 
		[XmlEnum("14")] 
		ComputerGenerated = 14,

		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAnInstrumentThatMeasuresDistanceByEmittingTimedPulsesOfLaserLightAndMeasuringTheTimeBetweenEmissionAndReceptionOfTheReflectedPulses")]
		[EnumMember(Value = "Found by LIDAR")] 
		[XmlEnum("15")] 
		FoundByLidar = 15,

		[System.ComponentModel.Description("ARadarWithASyntheticApertureAntennaWhichIsComposedOfALargeNumberOfElementaryTransducingElementsTheSignalsAreElectronicallyCombinedIntoAResultingSignalEquivalentToThatOfASingleAntennaOfAGivenApertureInAGivenDirection")]
		[EnumMember(Value = "Synthetic Aperture Radar")] 
		[XmlEnum("16")] 
		SyntheticApertureRadar = 16,

		[System.ComponentModel.Description("TermUsedToDescribeTheImageryDerivedFromSubdividingTheElectromagneticSpectrumIntoVeryNarrowBandwidthsTheseNarrowBandwidthsMayBeCombinedWithOrSubtractedFromEachOtherInVariousWaysToFormImagesUsefulInPreciseTerrainOrTargetAnalysis")]
		[EnumMember(Value = "Hyperspectral Imagery")] 
		[XmlEnum("17")] 
		HyperspectralImagery = 17,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum qualityOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthFromTheChartDatumToTheSeabedOrToTheTopOfADryingFeatureIsKnown")]
		[EnumMember(Value = "Depth Known")] 
		[XmlEnum("1")] 
		DepthKnown = 1,

		[System.ComponentModel.Description("TheDepthFromChartDatumToTheSeabedOrTheShoalestDepthOfTheFeatureIsUnknown")]
		[EnumMember(Value = "Depth or Least Depth Unknown")] 
		[XmlEnum("2")] 
		DepthOrLeastDepthUnknown = 2,

		[System.ComponentModel.Description("ADepthThatMayBeLessThanIndicated")]
		[EnumMember(Value = "Doubtful Sounding")] 
		[XmlEnum("3")] 
		DoubtfulSounding = 3,

		[System.ComponentModel.Description("ADepthThatIsConsideredToBeAnUnreliableValue")]
		[EnumMember(Value = "Unreliable Sounding")] 
		[XmlEnum("4")] 
		UnreliableSounding = 4,

		[System.ComponentModel.Description("UponInvestigationTheBottomWasNotFoundAtThisDepth")]
		[EnumMember(Value = "No Bottom Found at Value Shown")] 
		[XmlEnum("5")] 
		NoBottomFoundAtValueShown = 5,

		[System.ComponentModel.Description("TheShoalestDepthOverAFeatureIsOfKnownValue")]
		[EnumMember(Value = "Least Depth Known")] 
		[XmlEnum("6")] 
		LeastDepthKnown = 6,

		[System.ComponentModel.Description("TheLeastDepthOverAFeatureIsUnknownButThereIsConsideredToBeSafeClearanceAtThisDepth")]
		[EnumMember(Value = "Least Depth Unknown, Safe Clearance at Value Shown")] 
		[XmlEnum("7")] 
		LeastDepthUnknownSafeClearanceAtValueShown = 7,

		[System.ComponentModel.Description("DepthValueObtainedFromAReportButNotFullySurveyed")]
		[EnumMember(Value = "Value Reported (Not Surveyed)")] 
		[XmlEnum("8")] 
		ValueReportedNotSurveyed = 8,

		[System.ComponentModel.Description("DepthValueObtainedFromAReportWhichItHasNotBeenPossibleToConfirm")]
		[EnumMember(Value = "Value Reported (Not Confirmed)")] 
		[XmlEnum("9")] 
		ValueReportedNotConfirmed = 9,

		[System.ComponentModel.Description("TheDepthAtWhichAChannelIsKeptByHumanInfluenceUsuallyByDredging")]
		[EnumMember(Value = "Maintained Depth")] 
		[XmlEnum("10")] 
		MaintainedDepth = 10,

		[System.ComponentModel.Description("DepthsMayBeAlteredByHumanInfluenceButWillNotBeRoutinelyMaintained")]
		[EnumMember(Value = "Not Regularly Maintained")] 
		[XmlEnum("11")] 
		NotRegularlyMaintained = 11,
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
	public enum categoryOfLateralMark : int {
		[System.ComponentModel.Description("IndicatesThePortBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyage")]
		[EnumMember(Value = "Port-Hand Lateral Mark")] 
		[XmlEnum("1")] 
		PortHandLateralMark = 1,

		[System.ComponentModel.Description("IndicatesTheStarboardBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyage")]
		[EnumMember(Value = "Starboard-Hand Lateral Mark")] 
		[XmlEnum("2")] 
		StarboardHandLateralMark = 2,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedPortHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Starboard Lateral Mark")] 
		[XmlEnum("3")] 
		PreferredChannelToStarboardLateralMark = 3,

		[System.ComponentModel.Description("AtAPointWhereAChannelDividesWhenProceedingInTheConventionalDirectionOfBuoyageThePreferredChannelOrPrimaryRouteIsIndicatedByAModifiedStarboardHandLateralMark")]
		[EnumMember(Value = "Preferred Channel to Port Lateral Mark")] 
		[XmlEnum("4")] 
		PreferredChannelToPortLateralMark = 4,

		[System.ComponentModel.Description("IndicatesTheRightHandSideOfTheInlandWaterway")]
		[EnumMember(Value = "Right-Hand Side of the Waterway")] 
		[XmlEnum("5")] 
		RightHandSideOfTheWaterway = 5,

		[System.ComponentModel.Description("IndicatesTheLeftHandSideOfTheInlandWaterway")]
		[EnumMember(Value = "Left-Hand Side of the Waterway")] 
		[XmlEnum("6")] 
		LeftHandSideOfTheWaterway = 6,

		[System.ComponentModel.Description("IndicatesTheRightHandSideOfAChannelOfAnInlandWaterway")]
		[EnumMember(Value = "Right-Hand Side of the Channel")] 
		[XmlEnum("7")] 
		RightHandSideOfTheChannel = 7,

		[System.ComponentModel.Description("IndicatesTheLeftHandSideOfAChannelOfAnInlandWaterway")]
		[EnumMember(Value = "Left-Hand Side of the Channel")] 
		[XmlEnum("8")] 
		LeftHandSideOfTheChannel = 8,

		[System.ComponentModel.Description("IndicatesABifurcationOfTheInlandWaterway")]
		[EnumMember(Value = "Bifurcation of the Waterway")] 
		[XmlEnum("9")] 
		BifurcationOfTheWaterway = 9,

		[System.ComponentModel.Description("IndicatesABifurcationOfAChannelOfAnInlandWaterway")]
		[EnumMember(Value = "Bifurcation of the Channel")] 
		[XmlEnum("10")] 
		BifurcationOfTheChannel = 10,

		[System.ComponentModel.Description("IndicatesThatTheChannelIsNearTheRightBank")]
		[EnumMember(Value = "Channel Near the Right Bank")] 
		[XmlEnum("11")] 
		ChannelNearTheRightBank = 11,

		[System.ComponentModel.Description("IndicatesThatTheChannelIsNearTheLeftBank")]
		[EnumMember(Value = "Channel Near the Left Bank")] 
		[XmlEnum("12")] 
		ChannelNearTheLeftBank = 12,

		[System.ComponentModel.Description("IndicatesThatTheChannelCrossesFromTheLeftToTheRightBank")]
		[EnumMember(Value = "Channel Cross-Over to the Right Bank")] 
		[XmlEnum("13")] 
		ChannelCrossOverToTheRightBank = 13,

		[System.ComponentModel.Description("IndicatesThatTheChannelCrossesFromTheRightToTheLeftBank")]
		[EnumMember(Value = "Channel Cross-Over to the Left Bank")] 
		[XmlEnum("14")] 
		ChannelCrossOverToTheLeftBank = 14,

		[System.ComponentModel.Description("IndicatesADangerPointOrObstaclesAtTheRightHandSide")]
		[EnumMember(Value = "Danger Point or Obstacles at the Right-Hand Side")] 
		[XmlEnum("15")] 
		DangerPointOrObstaclesAtTheRightHandSide = 15,

		[System.ComponentModel.Description("IndicatesADangerPointOrObstaclesAtTheLeftHandSide")]
		[EnumMember(Value = "Danger Point or Obstacles at the Left-Hand Side")] 
		[XmlEnum("16")] 
		DangerPointOrObstaclesAtTheLeftHandSide = 16,

		[System.ComponentModel.Description("IndicatesATurnOffAtTheRightHandSide")]
		[EnumMember(Value = "Turn Off at the Right-Hand Side")] 
		[XmlEnum("17")] 
		TurnOffAtTheRightHandSide = 17,

		[System.ComponentModel.Description("IndicatesATurnOffAtTheLeftHandSide")]
		[EnumMember(Value = "Turn Off at the Left-Hand Side")] 
		[XmlEnum("18")] 
		TurnOffAtTheLeftHandSide = 18,

		[System.ComponentModel.Description("IndicatesAJunctionAtTheRightHandSide")]
		[EnumMember(Value = "Junction at the Right-Hand Side")] 
		[XmlEnum("19")] 
		JunctionAtTheRightHandSide = 19,

		[System.ComponentModel.Description("IndicatesAJunctionAtTheLeftHandSide")]
		[EnumMember(Value = "Junction at the Left-Hand Side")] 
		[XmlEnum("20")] 
		JunctionAtTheLeftHandSide = 20,

		[System.ComponentModel.Description("IndicatesAHarbourEntryAtTheRightHandSide")]
		[EnumMember(Value = "Harbour Entry at the Right-Hand Side")] 
		[XmlEnum("21")] 
		HarbourEntryAtTheRightHandSide = 21,

		[System.ComponentModel.Description("IndicatesAHarbourEntryAtTheLeftHandSide")]
		[EnumMember(Value = "Harbour Entry at the Left-Hand Side")] 
		[XmlEnum("22")] 
		HarbourEntryAtTheLeftHandSide = 22,

		[System.ComponentModel.Description("IndicatesABridgePierInAnInlandWaterway")]
		[EnumMember(Value = "Bridge Pier Mark")] 
		[XmlEnum("23")] 
		BridgePierMark = 23,

		[System.ComponentModel.Description("IndicatesTheRightBankOfTheEntryFromALakeOrALakeLikeExpansionToASectionOfTheWaterwayWhichIsNarrower")]
		[EnumMember(Value = "Entry From a Lake to a Narrower Waterway, Right Bank")] 
		[XmlEnum("24")] 
		EntryFromALakeToANarrowerWaterwayRightBank = 24,

		[System.ComponentModel.Description("IndicatesTheLeftBankOfTheEntryFromALakeOrALakeLikeExpansionToASectionOfTheWaterwayWhichIsNarrower")]
		[EnumMember(Value = "Entry From a Lake to a Narrower Waterway, Left Bank")] 
		[XmlEnum("25")] 
		EntryFromALakeToANarrowerWaterwayLeftBank = 25,

		[System.ComponentModel.Description("ChangeBank")]
		[EnumMember(Value = "Change Bank")] 
		[XmlEnum("26")] 
		ChangeBank = 26,

		[System.ComponentModel.Description("ContinueAlongBank")]
		[EnumMember(Value = "Continue Along Bank")] 
		[XmlEnum("27")] 
		ContinueAlongBank = 27,
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
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum function : int {
		[System.ComponentModel.Description("ALocalOfficialWhoHasChargeOfMooringAndBerthingOfVesselsCollectingHarbourFeesEtc")]
		[EnumMember(Value = "Harbour-Masters Office")] 
		[XmlEnum("2")] 
		HarbourMastersOffice = 2,

		[System.ComponentModel.Description("ServesAsAGovernmentOfficeWhereCustomsDutiesAreCollectedTheFlowOfGoodsAreRegulatedAndRestrictionsEnforcedAndShipmentsOrVehiclesAreClearedForEnteringOrLeavingACountry")]
		[EnumMember(Value = "Customs Office")] 
		[XmlEnum("3")] 
		CustomsOffice = 3,

		[System.ComponentModel.Description("TheOfficeWhichIsChargedWithTheAdministrationOfHealthLawsAndSanitaryInspections")]
		[EnumMember(Value = "Health Office")] 
		[XmlEnum("4")] 
		HealthOffice = 4,

		[System.ComponentModel.Description("AnInstitutionOrEstablishmentProvidingMedicalOrSurgicalTreatmentForTheIllOrWounded")]
		[EnumMember(Value = "Hospital")] 
		[XmlEnum("5")] 
		Hospital = 5,

		[System.ComponentModel.Description("ThePublicDepartmentAgencyOrOrganisationResponsiblePrimarilyForTheCollectionTransmissionAndDistributionOfMail")]
		[EnumMember(Value = "Post Office")] 
		[XmlEnum("6")] 
		PostOffice = 6,

		[System.ComponentModel.Description("AnEstablishmentEspeciallyOfAComfortableOrLuxuriousKindWherePayingVisitorsAreProvidedWithAccommodationMealsAndOtherServices")]
		[EnumMember(Value = "Hotel")] 
		[XmlEnum("7")] 
		Hotel = 7,

		[System.ComponentModel.Description("ABuildingWithPlatformsWhereTrainsArriveLoadDischargeAndDepart")]
		[EnumMember(Value = "Railway Station")] 
		[XmlEnum("8")] 
		RailwayStation = 8,

		[System.ComponentModel.Description("TheHeadquartersOfALocalPoliceForceAndThatIsWhereThoseUnderArrestAreFirstCharged")]
		[EnumMember(Value = "Police Station")] 
		[XmlEnum("9")] 
		PoliceStation = 9,

		[System.ComponentModel.Description("TheHeadquartersOfALocalWaterPoliceForce")]
		[EnumMember(Value = "Water-Police Station")] 
		[XmlEnum("10")] 
		WaterPoliceStation = 10,

		[System.ComponentModel.Description("TheOfficeOrHeadquartersOfPilotsThePlaceWhereTheServicesOfAPilotMayBeObtained")]
		[EnumMember(Value = "Pilot Office")] 
		[XmlEnum("11")] 
		PilotOffice = 11,

		[System.ComponentModel.Description("ADistinctiveStructureOrPlaceOnShoreFromWhichPersonnelKeepWatchUponEventsAtSeaOrAlongTheCoast")]
		[EnumMember(Value = "Pilot Lookout")] 
		[XmlEnum("12")] 
		PilotLookout = 12,

		[System.ComponentModel.Description("AnOfficeForCustodyDepositLoanExchangeOrIssueOfMoney")]
		[EnumMember(Value = "Bank Office")] 
		[XmlEnum("13")] 
		BankOffice = 13,

		[System.ComponentModel.Description("TheQuartersOfAnExecutiveOfficerDirectorManagerEtcWithResponsibilityForAnAdministrativeArea")]
		[EnumMember(Value = "Headquarters for District Control")] 
		[XmlEnum("14")] 
		HeadquartersForDistrictControl = 14,

		[System.ComponentModel.Description("ABuildingOrPartOfABuildingForStorageOfWaresOrGoods")]
		[EnumMember(Value = "Transit Shed/Warehouse")] 
		[XmlEnum("15")] 
		TransitShedWarehouse = 15,

		[System.ComponentModel.Description("ABuildingOrBuildingsWithEquipmentForManufacturingAWorkshop")]
		[EnumMember(Value = "Factory")] 
		[XmlEnum("16")] 
		Factory = 16,

		[System.ComponentModel.Description("AStationaryPlantContainingApparatusForLargeScaleConversionOfSomeFormOfEnergySuchAsHydraulicSteamChemicalOrNuclearEnergyIntoElectricalEnergy")]
		[EnumMember(Value = "Power Station")] 
		[XmlEnum("17")] 
		PowerStation = 17,

		[System.ComponentModel.Description("ABuildingForTheManagementOfAffairs")]
		[EnumMember(Value = "Administrative")] 
		[XmlEnum("18")] 
		Administrative = 18,

		[System.ComponentModel.Description("ABuildingConcernedWithEducationForExampleSchoolCollegeUniversityEtc")]
		[EnumMember(Value = "Educational Facility")] 
		[XmlEnum("19")] 
		EducationalFacility = 19,

		[System.ComponentModel.Description("ABuildingForPublicChristianWorship")]
		[EnumMember(Value = "Church")] 
		[XmlEnum("20")] 
		Church = 20,

		[System.ComponentModel.Description("APlaceForChristianWorshipOtherThanAParishCathedralOrChurchEspeciallyOneAttachedToAPrivateHouseOrInstitution")]
		[EnumMember(Value = "Chapel")] 
		[XmlEnum("21")] 
		Chapel = 21,

		[System.ComponentModel.Description("ABuildingForPublicJewishWorship")]
		[EnumMember(Value = "Temple")] 
		[XmlEnum("22")] 
		Temple = 22,

		[System.ComponentModel.Description("AHinduOrBuddhistTempleOrSacredBuilding")]
		[EnumMember(Value = "Pagoda")] 
		[XmlEnum("23")] 
		Pagoda = 23,

		[System.ComponentModel.Description("ABuildingForPublicShintoWorship")]
		[EnumMember(Value = "Shinto Shrine")] 
		[XmlEnum("24")] 
		ShintoShrine = 24,

		[System.ComponentModel.Description("ABuildingForPublicBuddhistWorship")]
		[EnumMember(Value = "Buddhist Temple")] 
		[XmlEnum("25")] 
		BuddhistTemple = 25,

		[System.ComponentModel.Description("AMuslimPlaceOfWorship")]
		[EnumMember(Value = "Mosque")] 
		[XmlEnum("26")] 
		Mosque = 26,

		[System.ComponentModel.Description("AShrineMarkingTheBurialPlaceOfAMuslimHolyMan")]
		[EnumMember(Value = "Marabout")] 
		[XmlEnum("27")] 
		Marabout = 27,

		[System.ComponentModel.Description("KeepingAWatchUponEventsAtSeaOrAlongTheCoast")]
		[EnumMember(Value = "Lookout")] 
		[XmlEnum("28")] 
		Lookout = 28,

		[System.ComponentModel.Description("TransmittingAndOrReceivingElectronicCommunicationSignals")]
		[EnumMember(Value = "Communication")] 
		[XmlEnum("29")] 
		Communication = 29,

		[System.ComponentModel.Description("ASystemForReproducingOnAScreenVisualImagesTransmittedUsuallyWithSoundByRadioSignals")]
		[EnumMember(Value = "Television")] 
		[XmlEnum("30")] 
		Television = 30,

		[System.ComponentModel.Description("TransmittingAndOrReceivingRadioFrequencyElectromagneticWavesAsAMeansOfCommunication")]
		[EnumMember(Value = "Radio")] 
		[XmlEnum("31")] 
		Radio = 31,

		[System.ComponentModel.Description("AMethodSystemOrTechniqueOfUsingBeamedReflectedAndTimedRadioWavesForDetectingLocatingOrTrackingObjectsAndForMeasuringAltitudes")]
		[EnumMember(Value = "Radar")] 
		[XmlEnum("32")] 
		Radar = 32,

		[System.ComponentModel.Description("AStructureServingAsASupportForOneOrMoreLights")]
		[EnumMember(Value = "Light Support")] 
		[XmlEnum("33")] 
		LightSupport = 33,

		[System.ComponentModel.Description("BroadcastingAndReceivingSignalsUsingMicrowaves")]
		[EnumMember(Value = "Microwave")] 
		[XmlEnum("34")] 
		Microwave = 34,

		[System.ComponentModel.Description("GenerationOfChilledLiquidAndOrGasForCoolingPurposes")]
		[EnumMember(Value = "Cooling")] 
		[XmlEnum("35")] 
		Cooling = 35,

		[System.ComponentModel.Description("APlaceFromWhichTheSurroundingsCanBeObservedButAtWhichAWatchIsNotHabituallyMaintained")]
		[EnumMember(Value = "Observation")] 
		[XmlEnum("36")] 
		Observation = 36,

		[System.ComponentModel.Description("AVisualTimeSignalInTheFormOfABall")]
		[EnumMember(Value = "Timeball")] 
		[XmlEnum("37")] 
		Timeball = 37,

		[System.ComponentModel.Description("InstrumentForMeasuringTimeAndRecordingHours")]
		[EnumMember(Value = "Clock")] 
		[XmlEnum("38")] 
		Clock = 38,

		[System.ComponentModel.Description("UsedToControlTheFlowOfTrafficWithinASpecifiedRangeOfAnInstallation")]
		[EnumMember(Value = "Control")] 
		[XmlEnum("39")] 
		Control = 39,

		[System.ComponentModel.Description("EquipmentOrStructureToSecureAnAirship")]
		[EnumMember(Value = "Airship Mooring")] 
		[XmlEnum("40")] 
		AirshipMooring = 40,

		[System.ComponentModel.Description("AnArenaForHoldingAndViewingEvents")]
		[EnumMember(Value = "Stadium")] 
		[XmlEnum("41")] 
		Stadium = 41,

		[System.ComponentModel.Description("ABuildingWhereBusesAndCoachesRegularlyStopToTakeOnAndOrLetOffPassengersEspeciallyForLongDistanceTravel")]
		[EnumMember(Value = "Bus Station")] 
		[XmlEnum("42")] 
		BusStation = 42,

		[System.ComponentModel.Description("ABuildingWithinATerminalForTheLoadingAndUnloadingOfPassengers")]
		[EnumMember(Value = "Passenger Terminal Building")] 
		[XmlEnum("43")] 
		PassengerTerminalBuilding = 43,

		[System.ComponentModel.Description("AUnitResponsibleForPromotingEfficientOrganizationOfSearchAndRescueServicesAndForCoordinatingTheConductOfSearchAndRescueOperationsWithinASearchAndRescueRegion")]
		[EnumMember(Value = "Sea Rescue Control")] 
		[XmlEnum("44")] 
		SeaRescueControl = 44,

		[System.ComponentModel.Description("ABuildingDesignedAndEquippedForMakingObservationsOfAstronomicalMeteorologicalOrOtherNaturalPhenomena")]
		[EnumMember(Value = "Observatory")] 
		[XmlEnum("45")] 
		Observatory = 45,

		[System.ComponentModel.Description("ABuildingOrStructureUsedToCrushOre")]
		[EnumMember(Value = "Ore Crusher")] 
		[XmlEnum("46")] 
		OreCrusher = 46,

		[System.ComponentModel.Description("ABuildingOrShedUsuallyBuiltPartlyOverWaterForShelteringABoatOrBoats")]
		[EnumMember(Value = "Boathouse")] 
		[XmlEnum("47")] 
		Boathouse = 47,

		[System.ComponentModel.Description("AFacilityToMoveSolidsLiquidsOrGasesByMeansOfPressureOrSuction")]
		[EnumMember(Value = "Pumping Station")] 
		[XmlEnum("48")] 
		PumpingStation = 48,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLandmark : int {
		[System.ComponentModel.Description("AMoundOfStonesUsuallyConicalOrPyramidalRaisedAsALandmarkOrToDesignateAPointOfImportanceInSurveying")]
		[EnumMember(Value = "Cairn")] 
		[XmlEnum("1")] 
		Cairn = 1,

		[System.ComponentModel.Description("ASiteAndAssociatedStructuresDevotedToTheBurialOfTheDead")]
		[EnumMember(Value = "Cemetery")] 
		[XmlEnum("2")] 
		Cemetery = 2,

		[System.ComponentModel.Description("AVerticalStructureContainingAPassageOrFlueForDischargingSmokeAndGasesOfCombustion")]
		[EnumMember(Value = "Chimney")] 
		[XmlEnum("3")] 
		Chimney = 3,

		[System.ComponentModel.Description("AParabolicAerialForTheReceiptAndTransmissionOfHighFrequencyRadioSignals")]
		[EnumMember(Value = "Dish Aerial")] 
		[XmlEnum("4")] 
		DishAerial = 4,

		[System.ComponentModel.Description("AStaffOrPoleOnWhichFlagsAreRaised")]
		[EnumMember(Value = "Flagstaff")] 
		[XmlEnum("5")] 
		Flagstaff = 5,

		[System.ComponentModel.Description("ATallStructureUsedForBurningOffWasteOilOrGas")]
		[EnumMember(Value = "Flare Stack")] 
		[XmlEnum("6")] 
		FlareStack = 6,

		[System.ComponentModel.Description("ARelativelyTallStructureUsuallyHeldVerticalByGuyLines")]
		[EnumMember(Value = "Mast")] 
		[XmlEnum("7")] 
		Mast = 7,

		[System.ComponentModel.Description("ATaperedFabricSleeveMountedSoAsToCatchAndSwingWithTheWindThusIndicatingTheWindDirection")]
		[EnumMember(Value = "Windsock")] 
		[XmlEnum("8")] 
		Windsock = 8,

		[System.ComponentModel.Description("AStructureErectedAndOrMaintainedAsAMemorialToAPersonAndOrEvent")]
		[EnumMember(Value = "Monument")] 
		[XmlEnum("9")] 
		Monument = 9,

		[System.ComponentModel.Description("ACylindricalOrSlightlyTaperingBodyOfConsiderablyGreaterLengthThanDiameterErectedVertically")]
		[EnumMember(Value = "Column/Pillar")] 
		[XmlEnum("10")] 
		ColumnPillar = 10,

		[System.ComponentModel.Description("ASlabOfMetalUsuallyOrnamentedErectedAsAMemorialToAPersonOrEvent")]
		[EnumMember(Value = "Memorial Plaque")] 
		[XmlEnum("11")] 
		MemorialPlaque = 11,

		[System.ComponentModel.Description("ATaperingShaftUsuallyOfStoneOrConcreteSquareOrRectangularInSectionWithAPyramidalApex")]
		[EnumMember(Value = "Obelisk")] 
		[XmlEnum("12")] 
		Obelisk = 12,

		[System.ComponentModel.Description("ARepresentationOfALivingBeingSculpturedMouldedOrCastInAVarietyOfMaterialsForExampleMarbleMetalOrPlaster")]
		[EnumMember(Value = "Statue")] 
		[XmlEnum("13")] 
		Statue = 13,

		[System.ComponentModel.Description("AMonumentOrOtherStructureInFormOfACross")]
		[EnumMember(Value = "Cross")] 
		[XmlEnum("14")] 
		Cross = 14,

		[System.ComponentModel.Description("ALandmarkComprisingAHemisphericalOrSpheroidalShapedStructure")]
		[EnumMember(Value = "Dome")] 
		[XmlEnum("15")] 
		Dome = 15,

		[System.ComponentModel.Description("ADeviceUsedForDirectingARadarBeamThroughASearchPattern")]
		[EnumMember(Value = "Radar Scanner")] 
		[XmlEnum("16")] 
		RadarScanner = 16,

		[System.ComponentModel.Description("ARelativelyTallNarrowStructureThatMayEitherStandAloneOrMayFormPartOfAnotherStructure")]
		[EnumMember(Value = "Tower")] 
		[XmlEnum("17")] 
		Tower = 17,

		[System.ComponentModel.Description("ASystemOfVanesAttachedToATowerAndDrivenByWindExcludingWindTurbines")]
		[EnumMember(Value = "Windmill")] 
		[XmlEnum("18")] 
		Windmill = 18,

		[System.ComponentModel.Description("AModernStructureForTheUseOfWindPower")]
		[EnumMember(Value = "Windmotor")] 
		[XmlEnum("19")] 
		Windmotor = 19,

		[System.ComponentModel.Description("ATallConicalOrPyramidShapedStructureOftenBuiltOnTheRoofOrTowerOfABuildingEspeciallyAChurchOrMosque")]
		[EnumMember(Value = "Spire/Minaret")] 
		[XmlEnum("20")] 
		SpireMinaret = 20,

		[System.ComponentModel.Description("AnIsolatedRockyFormationOrASingleLargeStone")]
		[EnumMember(Value = "Large Rock or Boulder on Land")] 
		[XmlEnum("21")] 
		LargeRockOrBoulderOnLand = 21,

		[System.ComponentModel.Description("ARecoverablePointOnTheEarthWhoseGeographicPositionHasBeenDeterminedByAngularMethodsWithGeodeticInstrumentsATriangulationPointIsASelectedPointWhichHasBeenMarkedWithAStationMarkOrItIsAConspicuousNaturalOrArtificialFeature")]
		[EnumMember(Value = "Triangulation Mark")] 
		[XmlEnum("22")] 
		TriangulationMark = 22,

		[System.ComponentModel.Description("AMarkerIdentifyingTheLocationOfASurveyedBoundaryLine")]
		[EnumMember(Value = "Boundary Mark")] 
		[XmlEnum("23")] 
		BoundaryMark = 23,

		[System.ComponentModel.Description("WheelsWithPassengerCarsMountedExternalToTheRimAndIndependentlyRotatedByElectricMotors")]
		[EnumMember(Value = "Observation Wheel")] 
		[XmlEnum("24")] 
		ObservationWheel = 24,

		[System.ComponentModel.Description("AFormOfDecorativeGatewayOrPortalConsistingOfTwoUprightWoodenPostsConnectedAtTheTopByTwoHorizontalCrosspiecesCommonlyFoundAtTheEntranceToShintoTemples")]
		[EnumMember(Value = "Torii")] 
		[XmlEnum("25")] 
		Torii = 25,

		[System.ComponentModel.Description("oneAnElevatedStructureExtendingAcrossOrOverTheWeatherDeckOfAVesselOrPartOfSuchAStructureTheTermIsSometimesModifiedToIndicateTheIntendedUseSuchAsNavigatingBridgeOrSignalBridge2AStructureErectedOverADepressionOrAnObstacleSuchAsABodyOfWaterRailroadEtcToProvideARoadwayForVehiclesOrPedestrians")]
		[EnumMember(Value = "Bridge")] 
		[XmlEnum("26")] 
		Bridge = 26,

		[System.ComponentModel.Description("ABarrierToCheckOrConfineAnythingInMotionParticularlyOneConstructedToHoldBackWaterAndRaiseItsLevelToFormAReservoirOrToPreventFlooding")]
		[EnumMember(Value = "Dam")] 
		[XmlEnum("27")] 
		Dam = 27,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum buoyShape : int {
		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasApproximatelyTheShapeOrTheAppearanceOfAPointedConeWithThePointUpwards")]
		[EnumMember(Value = "Conical")] 
		[XmlEnum("1")] 
		Conical = 1,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheShapeOfACylinderOrATruncatedConeThatApproximatesToACylinderWithAFlatEndUppermost")]
		[EnumMember(Value = "Can")] 
		[XmlEnum("2")] 
		Can = 2,

		[System.ComponentModel.Description("ShapedLikeASphereWhichIsABodyTheSurfaceOfWhichIsAtAllPointsEquidistantFromTheCentre")]
		[EnumMember(Value = "Spherical")] 
		[XmlEnum("3")] 
		Spherical = 3,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureIsANarrowVerticalStructurePillarOrLatticeTower")]
		[EnumMember(Value = "Pillar")] 
		[XmlEnum("4")] 
		Pillar = 4,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheFormOfAPoleOrOfAVeryLongCylinderFloatingUpright")]
		[EnumMember(Value = "Spar")] 
		[XmlEnum("5")] 
		Spar = 5,

		[System.ComponentModel.Description("TheUpperPartOfTheBodyAboveTheWaterLineOrTheGreaterPartOfTheSuperstructureHasTheFormOfABarrelOrCylinderFloatingHorizontally")]
		[EnumMember(Value = "Barrel")] 
		[XmlEnum("6")] 
		Barrel = 6,

		[System.ComponentModel.Description("AVeryLargeBuoyDesignedToCarryASignalLightOfHighLuminousIntensityAtAHighElevation")]
		[EnumMember(Value = "Superbuoy")] 
		[XmlEnum("7")] 
		Superbuoy = 7,

		[System.ComponentModel.Description("ASpeciallyConstructedShuttleShapedBuoyWhichIsUsedInIceConditions")]
		[EnumMember(Value = "Ice Buoy")] 
		[XmlEnum("8")] 
		IceBuoy = 8,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum visualProminence : int {
		[System.ComponentModel.Description("TermAppliedToAFeatureEitherNaturalOrArtificialWhichIsDistinctlyAndNotablyVisibleFromSeaward")]
		[EnumMember(Value = "Visually Conspicuous")] 
		[XmlEnum("1")] 
		VisuallyConspicuous = 1,

		[System.ComponentModel.Description("AnObjectThatMayBeVisibleFromSeawardButCannotBeUsedAsAFixingMarkAndIsNotConspicuous")]
		[EnumMember(Value = "Not Visually Conspicuous")] 
		[XmlEnum("2")] 
		NotVisuallyConspicuous = 2,

		[System.ComponentModel.Description("ObjectsWhichAreEasilyIdentifiableButDoNotJustifyBeingClassedAsConspicuous")]
		[EnumMember(Value = "Prominent")] 
		[XmlEnum("3")] 
		Prominent = 3,
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
	public enum natureOfConstruction : int {
		[System.ComponentModel.Description("ConstructedOfStonesOrBricksUsuallyQuarriedShapedAndMortared")]
		[EnumMember(Value = "Masonry")] 
		[XmlEnum("1")] 
		Masonry = 1,

		[System.ComponentModel.Description("ConstructedOfConcreteAMaterialMadeOfSandAndGravelThatIsUnitedByCementIntoAHardenedMassUsedForRoadsFoundationsEtc")]
		[EnumMember(Value = "Concreted")] 
		[XmlEnum("2")] 
		Concreted = 2,

		[System.ComponentModel.Description("ConstructedFromLargeStonesOrBlocksOfConcreteOftenPlacedLooselyForProtectionAgainstWavesOrWaterTurbulence")]
		[EnumMember(Value = "Loose Boulders")] 
		[XmlEnum("3")] 
		LooseBoulders = 3,

		[System.ComponentModel.Description("ConstructedWithASurfaceOfHardMaterialUsuallyATermAppliedToRoadsSurfacedWithAsphaltOrConcrete")]
		[EnumMember(Value = "Hard Surfaced")] 
		[XmlEnum("4")] 
		HardSurfaced = 4,

		[System.ComponentModel.Description("ConstructedWithNoExtraProtectionUsuallyATermAppliedToRoadsNotSurfacedWithAHardMaterial")]
		[EnumMember(Value = "Unsurfaced")] 
		[XmlEnum("5")] 
		Unsurfaced = 5,

		[System.ComponentModel.Description("ConstructedFromWood")]
		[EnumMember(Value = "Wooden")] 
		[XmlEnum("6")] 
		Wooden = 6,

		[System.ComponentModel.Description("ConstructedFromMetal")]
		[EnumMember(Value = "Metal")] 
		[XmlEnum("7")] 
		Metal = 7,

		[System.ComponentModel.Description("ConstructedFromAPlasticMaterialStrengthenedWithFibresOfGlass")]
		[EnumMember(Value = "Glass Reinforced Plastic")] 
		[XmlEnum("8")] 
		GlassReinforcedPlastic = 8,

		[System.ComponentModel.Description("TheApplicationOfPaintToSomeOtherConstructionOrNaturalFeature")]
		[EnumMember(Value = "Painted")] 
		[XmlEnum("9")] 
		Painted = 9,

		[System.ComponentModel.Description("ConstructedFromALatticeFrameworkOfOftenDiagonalIntersectingStruts")]
		[EnumMember(Value = "Framework")] 
		[XmlEnum("10")] 
		Framework = 10,

		[System.ComponentModel.Description("AStructureOfCrossedWoodenOrMetalStripsUsuallyArrangedToFormADiagonalPatternOfOpenSpacesBetweenTheStrips")]
		[EnumMember(Value = "Latticed")] 
		[XmlEnum("11")] 
		Latticed = 11,

		[System.ComponentModel.Description("oneAnyArtificialOrNaturalSubstanceHavingSimilarPropertiesAndCompositionAsFusedBoraxObsidianOrTheLike2SomethingMadeOfSuchASubstanceAsAWindowpane")]
		[EnumMember(Value = "Glass")] 
		[XmlEnum("12")] 
		Glass = 12,

		[System.ComponentModel.Description("ConstructedFromFiberglass")]
		[EnumMember(Value = "Fiberglass")] 
		[XmlEnum("13")] 
		Fiberglass = 13,

		[System.ComponentModel.Description("ConstructedFromPlastic")]
		[EnumMember(Value = "Plastic")] 
		[XmlEnum("14")] 
		Plastic = 14,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum marksNavigationalSystemOf : int {
		[System.ComponentModel.Description("NavigationalAidsConformToTheInternationalAssociationOfLighthouseAuthoritiesIalaASystem")]
		[EnumMember(Value = "IALA A")] 
		[XmlEnum("1")] 
		IalaA = 1,

		[System.ComponentModel.Description("NavigationalAidsConformToTheInternationalAssociationOfLighthouseAuthoritiesIalaBSystem")]
		[EnumMember(Value = "IALA B")] 
		[XmlEnum("2")] 
		IalaB = 2,

		[System.ComponentModel.Description("NavigationalAidsDoNotConformToAnyDefinedSystem")]
		[EnumMember(Value = "No System")] 
		[XmlEnum("9")] 
		NoSystem = 9,

		[System.ComponentModel.Description("NavigationalAidsConformToADefinedSystemOtherThanInternationalAssociationOfLighthouseAuthoritiesIala")]
		[EnumMember(Value = "Other System")] 
		[XmlEnum("10")] 
		OtherSystem = 10,

		[System.ComponentModel.Description("CevniEuropeanCodeForNavigationOnInlandWaterwaysIsTheEuropeanCodeForRiversCanalsLandLakesInMostOfEurope")]
		[EnumMember(Value = "CEVNI")] 
		[XmlEnum("11")] 
		Cevni = 11,

		[System.ComponentModel.Description("NavigationalAidsConformToTheRussianInlandWaterwayRegulations")]
		[EnumMember(Value = "Russian Inland Waterway Regulations")] 
		[XmlEnum("12")] 
		RussianInlandWaterwayRegulations = 12,

		[System.ComponentModel.Description("NavigationalAidsConformToTheBrazilianNationalInlandWaterwayRegulationsForTwoSides")]
		[EnumMember(Value = "Brazilian National Inland Waterway Regulations - Two Sides")] 
		[XmlEnum("13")] 
		BrazilianNationalInlandWaterwayRegulationsTwoSides = 13,

		[System.ComponentModel.Description("NavigationalAidsConformToTheBrazilianNationalInlandWaterwayRegulationsSideIndependent")]
		[EnumMember(Value = "Brazilian National Inland Waterway Regulations - Side Independent")] 
		[XmlEnum("14")] 
		BrazilianNationalInlandWaterwayRegulationsSideIndependent = 14,

		[System.ComponentModel.Description("NavigationalAidsConformToTheBrazilianComplementaryAidsOnTheParaguayParanaWaterway")]
		[EnumMember(Value = "Paraguay-Parana Waterway - Brazilian Complementary Aids")] 
		[XmlEnum("15")] 
		ParaguayParanaWaterwayBrazilianComplementaryAids = 15,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colourPattern : int {
		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedHorizontally")]
		[EnumMember(Value = "Horizontal Stripes")] 
		[XmlEnum("1")] 
		HorizontalStripes = 1,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedVertically")]
		[EnumMember(Value = "Vertical Stripes")] 
		[XmlEnum("2")] 
		VerticalStripes = 2,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedDiagonallyThatIsNotHorizontallyOrVertically")]
		[EnumMember(Value = "Diagonal Stripes")] 
		[XmlEnum("3")] 
		DiagonalStripes = 3,

		[System.ComponentModel.Description("OftenReferredToAsCheckerPlateWhereAlternateColoursAreUsedToCreateSquaresSimilarToAChessOrDraughtBoardThePatternMayBeStraightOrDiagonal")]
		[EnumMember(Value = "Squared")] 
		[XmlEnum("4")] 
		Squared = 4,

		[System.ComponentModel.Description("StraightBandsOrStripesOfDifferingColoursOrientedInAnUnknownDirection")]
		[EnumMember(Value = "Stripes (Direction Unknown)")] 
		[XmlEnum("5")] 
		StripesDirectionUnknown = 5,

		[System.ComponentModel.Description("ABandOrStripeOfColourWhichIsDisplayedAroundTheOuterEdgeOfTheObjectWhichMayAlsoFormABorderToAnInnerPatternOrPlainColour")]
		[EnumMember(Value = "Border Stripe")] 
		[XmlEnum("6")] 
		BorderStripe = 6,

		[System.ComponentModel.Description("OneSolidColourOfUniformCoverage")]
		[EnumMember(Value = "Single Colour")] 
		[XmlEnum("7")] 
		SingleColour = 7,

		[System.ComponentModel.Description("AFourSidedShapeThatIsMadeUpOfTwoPairsOfParallelLinesAndThatHasFourRightAnglesOnADifferentColouredBackground")]
		[EnumMember(Value = "Rectangle")] 
		[XmlEnum("8")] 
		Rectangle = 8,

		[System.ComponentModel.Description("AShapeThatIsMadeUpOfThreeLinesAndThreeAnglesOnADifferentColouredBackground")]
		[EnumMember(Value = "Triangle")] 
		[XmlEnum("9")] 
		Triangle = 9,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colour : int {
		[System.ComponentModel.Description("TheAchromaticObjectColourOfGreatestLightnessCharacteristicallyPerceivedToBelongToObjectsThatReflectDiffuselyNearlyAllIncidentEnergyThroughoutTheVisibleSpectrum")]
		[EnumMember(Value = "White")] 
		[XmlEnum("1")] 
		White = 1,

		[System.ComponentModel.Description("TheAchromaticColorOfLeastLightnessCharacteristicallyPerceivedToBelongToObjectsThatNeitherReflectNorTransmitLight")]
		[EnumMember(Value = "Black")] 
		[XmlEnum("2")] 
		Black = 2,

		[System.ComponentModel.Description("AColorWhoseHueResemblesThatOfBloodOrOfTheRubyOrIsThatOfTheLongWaveExtremeOfTheVisibleSpectrum")]
		[EnumMember(Value = "Red")] 
		[XmlEnum("3")] 
		Red = 3,

		[System.ComponentModel.Description("OfTheColorGreen")]
		[EnumMember(Value = "Green")] 
		[XmlEnum("4")] 
		Green = 4,

		[System.ComponentModel.Description("AColorWhoseHueIsThatOfTheClearSkyOrThatOfThePortionOfTheColorSpectrumLyingBetweenGreenAndViolet")]
		[EnumMember(Value = "Blue")] 
		[XmlEnum("5")] 
		Blue = 5,

		[System.ComponentModel.Description("AColorWhoseHueResemblesThatOfRipeLemonsOrSunflowersOrIsThatOfThePortionOfTheSpectrumLyingBetweenGreenAndOrange")]
		[EnumMember(Value = "Yellow")] 
		[XmlEnum("6")] 
		Yellow = 6,

		[System.ComponentModel.Description("OfTheColorGrey")]
		[EnumMember(Value = "Grey")] 
		[XmlEnum("7")] 
		Grey = 7,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsBetweenRedAndYellowInHueOfMediumToLowLightnessAndOfModerateToLowSaturation")]
		[EnumMember(Value = "Brown")] 
		[XmlEnum("8")] 
		Brown = 8,

		[System.ComponentModel.Description("AVariableColorAveragingADarkOrangeYellow")]
		[EnumMember(Value = "Amber")] 
		[XmlEnum("9")] 
		Amber = 9,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsOfReddishBlueHueLowLightnessAndMediumSaturation")]
		[EnumMember(Value = "Violet")] 
		[XmlEnum("10")] 
		Violet = 10,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsThatAreBetweenRedAndYellowInHue")]
		[EnumMember(Value = "Orange")] 
		[XmlEnum("11")] 
		Orange = 11,

		[System.ComponentModel.Description("ADeepPurplishRed")]
		[EnumMember(Value = "Magenta")] 
		[XmlEnum("12")] 
		Magenta = 12,

		[System.ComponentModel.Description("AnyOfAGroupOfColorsBluishRedToRedInHueOfMediumToHighLightnessAndOfLowToModerateSaturation")]
		[EnumMember(Value = "Pink")] 
		[XmlEnum("13")] 
		Pink = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green A")] 
		[XmlEnum("14")] 
		GreenA = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green B")] 
		[XmlEnum("15")] 
		GreenB = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "White Temporary")] 
		[XmlEnum("16")] 
		WhiteTemporary = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Red Temporary")] 
		[XmlEnum("17")] 
		RedTemporary = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Yellow Temporary")] 
		[XmlEnum("18")] 
		YellowTemporary = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green Preferred")] 
		[XmlEnum("19")] 
		GreenPreferred = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green Temporary")] 
		[XmlEnum("20")] 
		GreenTemporary = 20,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum beaconShape : int {
		[System.ComponentModel.Description("AnElongatedWoodOrMetalPoleDrivenIntoTheGroundOrSeabedWhichServesAsANavigationalAidOrASupportForANavigationalAid")]
		[EnumMember(Value = "Stake, Pole, Perch, Post")] 
		[XmlEnum("1")] 
		StakePolePerchPost = 1,

		[System.ComponentModel.Description("ATreeWithoutRootsStuckOrSpoiledIntoTheBottomOfTheSeaToServeAsANavigationalAid")]
		[EnumMember(Value = "Withy")] 
		[XmlEnum("2")] 
		Withy = 2,

		[System.ComponentModel.Description("ASolidStructureOfTheOrderOf10MetresInHeightUsedAsANavigationalAid")]
		[EnumMember(Value = "Beacon Tower")] 
		[XmlEnum("3")] 
		BeaconTower = 3,

		[System.ComponentModel.Description("AStructureConsistingOfStripsOfMetalOrWoodCrossedOrInterlacedToFormAStructureToServeAsAnAidToNavigationOrAsASupportForAnAidToNavigation")]
		[EnumMember(Value = "Lattice Beacon")] 
		[XmlEnum("4")] 
		LatticeBeacon = 4,

		[System.ComponentModel.Description("ALongHeavyTimberSOrSectionSOfSteelWoodConcreteEtcForcedIntoTheSeabedToServeAsAnAidToNavigationOrAsASupportForAnAidToNavigation")]
		[EnumMember(Value = "Pile Beacon")] 
		[XmlEnum("5")] 
		PileBeacon = 5,

		[System.ComponentModel.Description("AMoundOfStonesUsuallyConicalOrPyramidalRaisedAsALandmarkOrToDesignateAPointOfImportanceInSurveying")]
		[EnumMember(Value = "Cairn")] 
		[XmlEnum("6")] 
		Cairn = 6,

		[System.ComponentModel.Description("ATallSparLikeBeaconFittedWithAPermanentlySubmergedBuoyancyChamberTheLowerEndOfTheBodyIsSecuredToSeabedSinkerEitherByAFlexibleJointOrByACableUnderTension")]
		[EnumMember(Value = "Buoyant Beacon")] 
		[XmlEnum("7")] 
		BuoyantBeacon = 7,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum aidAvailabilityCategory : int {
		[System.ComponentModel.Description("AnAtonOrSystemOfAtonThatIsConsideredByTheCompetentAuthorityToBeOfVitalNavigationalSignificance")]
		[EnumMember(Value = "Category 1")] 
		[XmlEnum("1")] 
		Category1 = 1,

		[System.ComponentModel.Description("AnAtonOrSystemOfAtonThatIsConsideredByTheCompetentAuthorityToBeOfImportantNavigationalSignificance")]
		[EnumMember(Value = "Category 2")] 
		[XmlEnum("2")] 
		Category2 = 2,

		[System.ComponentModel.Description("AnAtonOrSystemOfAtonThatIsConsideredByTheCompetentAuthorityToBeOfNecessaryNavigationalSignificance")]
		[EnumMember(Value = "Category 3")] 
		[XmlEnum("3")] 
		Category3 = 3,
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

		[System.ComponentModel.Description("AWindmillOrWindTurbineFromWhichTheVanesOrTurbineBladesAreMissing")]
		[EnumMember(Value = "Wingless")] 
		[XmlEnum("4")] 
		Wingless = 4,

		[System.ComponentModel.Description("DetailedPlanningHasBeenCompletedButConstructionHasNotBeenInitiated")]
		[EnumMember(Value = "Planned Construction")] 
		[XmlEnum("5")] 
		PlannedConstruction = 5,
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
	public enum atonCommissioning : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy establishment")] 
		[XmlEnum("1")] 
		BuoyEstablishment = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light establishment")] 
		[XmlEnum("2")] 
		LightEstablishment = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon establishment")] 
		[XmlEnum("3")] 
		BeaconEstablishment = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal establishment")] 
		[XmlEnum("4")] 
		AudibleSignalEstablishment = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal establishment")] 
		[XmlEnum("5")] 
		FogSignalEstablishment = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "AIS transmitter establishment")] 
		[XmlEnum("6")] 
		AisTransmitterEstablishment = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS establishment")] 
		[XmlEnum("7")] 
		VAisEstablishment = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON establishment")] 
		[XmlEnum("8")] 
		RaconEstablishment = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS station establishment")] 
		[XmlEnum("9")] 
		DgpsStationEstablishment = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN station establishment")] 
		[XmlEnum("10")] 
		EloranStationEstablishment = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGLONASS station establishment")] 
		[XmlEnum("11")] 
		DglonassStationEstablishment = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka station establishment")] 
		[XmlEnum("12")] 
		EChaykaStationEstablishment = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS establishment")] 
		[XmlEnum("13")] 
		EgnosEstablishment = 13,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonRemoval : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy removal")] 
		[XmlEnum("1")] 
		BuoyRemoval = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy temporary removal")] 
		[XmlEnum("2")] 
		BuoyTemporaryRemoval = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light removal")] 
		[XmlEnum("3")] 
		LightRemoval = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light temporary removal")] 
		[XmlEnum("4")] 
		LightTemporaryRemoval = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon removal")] 
		[XmlEnum("5")] 
		BeaconRemoval = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon temporary removal")] 
		[XmlEnum("6")] 
		BeaconTemporaryRemoval = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal removal")] 
		[XmlEnum("7")] 
		FogSignalRemoval = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal temporary removal")] 
		[XmlEnum("8")] 
		FogSignalTemporaryRemoval = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal removal")] 
		[XmlEnum("9")] 
		AudibleSignalRemoval = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal temporary removal")] 
		[XmlEnum("10")] 
		AudibleSignalTemporaryRemoval = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS removal")] 
		[XmlEnum("11")] 
		VAisRemoval = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS temporary removal")] 
		[XmlEnum("12")] 
		VAisTemporaryRemoval = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON signal removal")] 
		[XmlEnum("13")] 
		RaconSignalRemoval = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON temporary removal")] 
		[XmlEnum("14")] 
		RaconTemporaryRemoval = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS removal")] 
		[XmlEnum("15")] 
		DgpsRemoval = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS temporary removal")] 
		[XmlEnum("16")] 
		DgpsTemporaryRemoval = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS removal")] 
		[XmlEnum("17")] 
		EgnosRemoval = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS temporary removal")] 
		[XmlEnum("18")] 
		EgnosTemporaryRemoval = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C station removal")] 
		[XmlEnum("19")] 
		LoranCStationRemoval = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C station temporary removal")] 
		[XmlEnum("20")] 
		LoranCStationTemporaryRemoval = 20,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN removal")] 
		[XmlEnum("21")] 
		EloranRemoval = 21,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN temporary removal")] 
		[XmlEnum("22")] 
		EloranTemporaryRemoval = 22,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka station removal")] 
		[XmlEnum("23")] 
		ChaykaStationRemoval = 23,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka station temporary removal")] 
		[XmlEnum("24")] 
		ChaykaStationTemporaryRemoval = 24,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka station removal")] 
		[XmlEnum("25")] 
		EChaykaStationRemoval = 25,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka station temporary removal")] 
		[XmlEnum("26")] 
		EChaykaStationTemporaryRemoval = 26,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum atonReplacement : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy change")] 
		[XmlEnum("1")] 
		BuoyChange = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy temporary change")] 
		[XmlEnum("2")] 
		BuoyTemporaryChange = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light change")] 
		[XmlEnum("3")] 
		LightChange = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light temporary change")] 
		[XmlEnum("4")] 
		LightTemporaryChange = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Sector light change")] 
		[XmlEnum("5")] 
		SectorLightChange = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Sector light temporary change")] 
		[XmlEnum("6")] 
		SectorLightTemporaryChange = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon change")] 
		[XmlEnum("7")] 
		BeaconChange = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon temporary change")] 
		[XmlEnum("8")] 
		BeaconTemporaryChange = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal change")] 
		[XmlEnum("9")] 
		FogSignalChange = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal temporary change")] 
		[XmlEnum("10")] 
		FogSignalTemporaryChange = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal change")] 
		[XmlEnum("11")] 
		AudibleSignalChange = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal temporary change")] 
		[XmlEnum("12")] 
		AudibleSignalTemporaryChange = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS change")] 
		[XmlEnum("13")] 
		VAisChange = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS temporary change")] 
		[XmlEnum("14")] 
		VAisTemporaryChange = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON signal change")] 
		[XmlEnum("15")] 
		RaconSignalChange = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON temporary change")] 
		[XmlEnum("16")] 
		RaconTemporaryChange = 16,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum fixedAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon missing")] 
		[XmlEnum("1")] 
		BeaconMissing = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon damaged")] 
		[XmlEnum("2")] 
		BeaconDamaged = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light beacon Unlit")] 
		[XmlEnum("3")] 
		LightBeaconUnlit = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light beacon Unreliable")] 
		[XmlEnum("4")] 
		LightBeaconUnreliable = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light beacon Not synchronized")] 
		[XmlEnum("5")] 
		LightBeaconNotSynchronized = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light beacon damaged")] 
		[XmlEnum("6")] 
		LightBeaconDamaged = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon topmark missing")] 
		[XmlEnum("7")] 
		BeaconTopmarkMissing = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon topmark damaged")] 
		[XmlEnum("8")] 
		BeaconTopmarkDamaged = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon daymark unreliable")] 
		[XmlEnum("9")] 
		BeaconDaymarkUnreliable = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Floodlit beacon Unlit")] 
		[XmlEnum("10")] 
		FloodlitBeaconUnlit = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Beacon restored to normal")] 
		[XmlEnum("11")] 
		BeaconRestoredToNormal = 11,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum floatingAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy adrift")] 
		[XmlEnum("1")] 
		BuoyAdrift = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy damaged")] 
		[XmlEnum("2")] 
		BuoyDamaged = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy daymark unreliable")] 
		[XmlEnum("3")] 
		BuoyDaymarkUnreliable = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy destroyed")] 
		[XmlEnum("4")] 
		BuoyDestroyed = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy missing")] 
		[XmlEnum("5")] 
		BuoyMissing = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy move")] 
		[XmlEnum("6")] 
		BuoyMove = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy off position")] 
		[XmlEnum("7")] 
		BuoyOffPosition = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy re-establishment")] 
		[XmlEnum("8")] 
		BuoyReEstablishment = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy restored to normal")] 
		[XmlEnum("9")] 
		BuoyRestoredToNormal = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy topmark damaged")] 
		[XmlEnum("10")] 
		BuoyTopmarkDamaged = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy topmark missing")] 
		[XmlEnum("11")] 
		BuoyTopmarkMissing = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy will be withdrawn")] 
		[XmlEnum("12")] 
		BuoyWillBeWithdrawn = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Buoy withdrawn")] 
		[XmlEnum("13")] 
		BuoyWithdrawn = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Decommissioned for winter")] 
		[XmlEnum("14")] 
		DecommissionedForWinter = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Lifted for Winter")] 
		[XmlEnum("15")] 
		LiftedForWinter = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light buoy Light damaged")] 
		[XmlEnum("16")] 
		LightBuoyLightDamaged = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light buoy Light not synchronized")] 
		[XmlEnum("17")] 
		LightBuoyLightNotSynchronized = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light buoy Light unlit")] 
		[XmlEnum("18")] 
		LightBuoyLightUnlit = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light buoy Light unreliable")] 
		[XmlEnum("19")] 
		LightBuoyLightUnreliable = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Marine Aids to Navigation unreliable")] 
		[XmlEnum("20")] 
		MarineAidsToNavigationUnreliable = 20,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Recommissioned for navigation season")] 
		[XmlEnum("21")] 
		RecommissionedForNavigationSeason = 21,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Replaced by Winter Spar")] 
		[XmlEnum("22")] 
		ReplacedByWinterSpar = 22,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Seasonal decommissioning complete")] 
		[XmlEnum("23")] 
		SeasonalDecommissioningComplete = 23,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Seasonal decommissioning in progress")] 
		[XmlEnum("24")] 
		SeasonalDecommissioningInProgress = 24,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Seasonal recommissioning complete")] 
		[XmlEnum("25")] 
		SeasonalRecommissioningComplete = 25,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Seasonal recommissioning in progress")] 
		[XmlEnum("26")] 
		SeasonalRecommissioningInProgress = 26,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum audibleSignalAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal out of service")] 
		[XmlEnum("1")] 
		AudibleSignalOutOfService = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal out of service")] 
		[XmlEnum("2")] 
		FogSignalOutOfService = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Audible signal operating properly")] 
		[XmlEnum("3")] 
		AudibleSignalOperatingProperly = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Fog signal operating properly")] 
		[XmlEnum("4")] 
		FogSignalOperatingProperly = 4,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum lightedAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light unlit")] 
		[XmlEnum("1")] 
		LightUnlit = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light unreliable")] 
		[XmlEnum("2")] 
		LightUnreliable = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light re-establishment")] 
		[XmlEnum("3")] 
		LightReEstablishment = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light range reduced")] 
		[XmlEnum("4")] 
		LightRangeReduced = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light without rhythm")] 
		[XmlEnum("5")] 
		LightWithoutRhythm = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light out of synchronization")] 
		[XmlEnum("6")] 
		LightOutOfSynchronization = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light daymark unreliable")] 
		[XmlEnum("7")] 
		LightDaymarkUnreliable = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Light operating properly")] 
		[XmlEnum("8")] 
		LightOperatingProperly = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Sector light Sector obscured")] 
		[XmlEnum("9")] 
		SectorLightSectorObscured = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light Unlit")] 
		[XmlEnum("10")] 
		FrontLeadingRangeLightUnlit = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light Unlit")] 
		[XmlEnum("11")] 
		RearLeadingRangeLightUnlit = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light Unreliable")] 
		[XmlEnum("12")] 
		FrontLeadingRangeLightUnreliable = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light Unreliable")] 
		[XmlEnum("13")] 
		RearLeadingRangeLightUnreliable = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light Light range reduced")] 
		[XmlEnum("14")] 
		FrontLeadingRangeLightLightRangeReduced = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light Light range reduced")] 
		[XmlEnum("15")] 
		RearLeadingRangeLightLightRangeReduced = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light without rhythm")] 
		[XmlEnum("16")] 
		FrontLeadingRangeLightWithoutRhythm = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light without rhythm")] 
		[XmlEnum("17")] 
		RearLeadingRangeLightWithoutRhythm = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Leading/range lights out of synchronization")] 
		[XmlEnum("18")] 
		LeadingRangeLightsOutOfSynchronization = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range beacon Unreliable")] 
		[XmlEnum("19")] 
		FrontLeadingRangeBeaconUnreliable = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range beacon Unreliable")] 
		[XmlEnum("20")] 
		RearLeadingRangeBeaconUnreliable = 20,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range light is operating properly")] 
		[XmlEnum("21")] 
		FrontLeadingRangeLightIsOperatingProperly = 21,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range light is operating properly")] 
		[XmlEnum("22")] 
		RearLeadingRangeLightIsOperatingProperly = 22,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Front leading/range beacon restored to normal")] 
		[XmlEnum("23")] 
		FrontLeadingRangeBeaconRestoredToNormal = 23,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Rear leading/range beacon restored to normal")] 
		[XmlEnum("24")] 
		RearLeadingRangeBeaconRestoredToNormal = 24,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum electronicAtonChange : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "AIS transmitter out of service")] 
		[XmlEnum("1")] 
		AisTransmitterOutOfService = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "AIS transmitter unreliable")] 
		[XmlEnum("2")] 
		AisTransmitterUnreliable = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "AIS transmitter operating properly")] 
		[XmlEnum("3")] 
		AisTransmitterOperatingProperly = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS out of service")] 
		[XmlEnum("4")] 
		VAisOutOfService = 4,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS unreliable")] 
		[XmlEnum("5")] 
		VAisUnreliable = 5,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "V-AIS operating properly")] 
		[XmlEnum("6")] 
		VAisOperatingProperly = 6,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON out of service")] 
		[XmlEnum("7")] 
		RaconOutOfService = 7,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON unreliable")] 
		[XmlEnum("8")] 
		RaconUnreliable = 8,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "RACON operating properly")] 
		[XmlEnum("9")] 
		RaconOperatingProperly = 9,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS out of service")] 
		[XmlEnum("10")] 
		DgpsOutOfService = 10,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS operating properly")] 
		[XmlEnum("11")] 
		DgpsOperatingProperly = 11,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS unreliable")] 
		[XmlEnum("12")] 
		DgpsUnreliable = 12,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C operating properly")] 
		[XmlEnum("13")] 
		LoranCOperatingProperly = 13,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C unreliable")] 
		[XmlEnum("14")] 
		LoranCUnreliable = 14,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "LORAN C out of service")] 
		[XmlEnum("15")] 
		LoranCOutOfService = 15,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN operating properly")] 
		[XmlEnum("16")] 
		EloranOperatingProperly = 16,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN unreliable")] 
		[XmlEnum("17")] 
		EloranUnreliable = 17,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "eLORAN out of service")] 
		[XmlEnum("18")] 
		EloranOutOfService = 18,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGLOANSS operating properly")] 
		[XmlEnum("19")] 
		DgloanssOperatingProperly = 19,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGLOANSS unreliable")] 
		[XmlEnum("20")] 
		DgloanssUnreliable = 20,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGLOANSS out of service")] 
		[XmlEnum("21")] 
		DgloanssOutOfService = 21,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka operating properly")] 
		[XmlEnum("22")] 
		ChaykaOperatingProperly = 22,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka unreliable")] 
		[XmlEnum("23")] 
		ChaykaUnreliable = 23,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Chayka out of service")] 
		[XmlEnum("24")] 
		ChaykaOutOfService = 24,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka operating properly")] 
		[XmlEnum("25")] 
		EChaykaOperatingProperly = 25,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka unreliable")] 
		[XmlEnum("26")] 
		EChaykaUnreliable = 26,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "e-Chayka out of service")] 
		[XmlEnum("27")] 
		EChaykaOutOfService = 27,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS operating properly")] 
		[XmlEnum("28")] 
		EgnosOperatingProperly = 28,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS unreliable")] 
		[XmlEnum("29")] 
		EgnosUnreliable = 29,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "EGNOS out of service")] 
		[XmlEnum("30")] 
		EgnosOutOfService = 30,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum positioningEquipment : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "DGPS Receiver")] 
		[XmlEnum("1")] 
		DgpsReceiver = 1,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "GLONASS Receiver")] 
		[XmlEnum("2")] 
		GlonassReceiver = 2,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "GPS Receiver")] 
		[XmlEnum("3")] 
		GpsReceiver = 3,

		[System.ComponentModel.Description("")]
		[EnumMember(Value = "GPS/WAAS Receiver")] 
		[XmlEnum("4")] 
		GpsWaasReceiver = 4,
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
		public class multiplicityOfFeatures {
			[XmlElement("multiplicityKnown")]
			public required Boolean multiplicityKnown {get;set;} = false;

			[XmlElement("numberOfFeatures")]
			public int? numberOfFeatures {get;set;} = default;

			public bool ShouldSerializenumberOfFeatures() { return numberOfFeatures.HasValue; }
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
		public class radarWaveLength {
			[XmlElement("radarBand")]
			public required String radarBand {get;set;} = string.Empty;

			[XmlElement("waveLengthValue")]
			public required decimal waveLengthValue {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorInformation {
			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("text")]
			public required String text {get;set;} = string.Empty;
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
		public class shapeInformation {
			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }

			[XmlElement("text")]
			public required String text {get;set;} = string.Empty;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class signalSequence {
			[XmlElement("signalDuration")]
			public required decimal signalDuration {get;set;} = default;

			[XmlElement("signalStatus")]
			[EnumerationValue([1,2])]
			public required signalStatus signalStatus {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class CableDimensions {
			[XmlElement("cableLength")]
			public required decimal cableLength {get;set;} = default;

			[XmlElement("heightLengthUnits")]
			[EnumerationValue([1,2,3,4,5,6])]
			public required heightLengthUnits heightLengthUnits {get;set;} = default;

			[XmlElement("diameter")]
			public required decimal diameter {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class ChangeDetails {
			[XmlElement("atonCommissioning")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public atonCommissioning? atonCommissioning {get;set;} = default;

			public bool ShouldSerializeatonCommissioning() { return atonCommissioning.HasValue; }

			[XmlElement("atonRemoval")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public atonRemoval? atonRemoval {get;set;} = default;

			public bool ShouldSerializeatonRemoval() { return atonRemoval.HasValue; }

			[XmlElement("atonReplacement")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16])]
			public atonReplacement? atonReplacement {get;set;} = default;

			public bool ShouldSerializeatonReplacement() { return atonReplacement.HasValue; }

			[XmlElement("fixedAtonChange")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public fixedAtonChange? fixedAtonChange {get;set;} = default;

			public bool ShouldSerializefixedAtonChange() { return fixedAtonChange.HasValue; }

			[XmlElement("floatingAtonChange")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26])]
			public floatingAtonChange? floatingAtonChange {get;set;} = default;

			public bool ShouldSerializefloatingAtonChange() { return floatingAtonChange.HasValue; }

			[XmlElement("audibleSignalAtonChange")]
			[EnumerationValue([1,2,3,4])]
			public audibleSignalAtonChange? audibleSignalAtonChange {get;set;} = default;

			public bool ShouldSerializeaudibleSignalAtonChange() { return audibleSignalAtonChange.HasValue; }

			[XmlElement("lightedAtonChange")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24])]
			public lightedAtonChange? lightedAtonChange {get;set;} = default;

			public bool ShouldSerializelightedAtonChange() { return lightedAtonChange.HasValue; }

			[XmlElement("electronicAtonChange")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30])]
			public electronicAtonChange? electronicAtonChange {get;set;} = default;

			public bool ShouldSerializeelectronicAtonChange() { return electronicAtonChange.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sinkerDimensions {
			[XmlElement("heightLengthUnits")]
			[EnumerationValue([1,2,3,4,5,6])]
			public required heightLengthUnits heightLengthUnits {get;set;} = default;

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class positioningMethod {
			[XmlElement("positioningEquipment")]
			[EnumerationValue([1,2,3,4])]
			public required positioningEquipment positioningEquipment {get;set;} = default;

			[XmlElement("NMEAString")]
			public required String NMEAString {get;set;} = string.Empty;
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
		public class textualDescription {
			[XmlElement("fileReference")]
			public required String fileReference {get;set;} = string.Empty;

			[XmlElement("language")]
			public String? language {get;set;} = default;

			public bool ShouldSerializelanguage() { return !string.IsNullOrEmpty(language); }
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
		public class directionalCharacter {
			[XmlElement("moireEffect")]
			public Boolean? moireEffect {get;set;} = default;

			public bool ShouldSerializemoireEffect() { return moireEffect.HasValue; }

			[XmlElement("orientation")]
			public required orientation orientation {get;set;} = default;
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class rhythmOfLight {
			[XmlElement("lightCharacteristic")]
			[EnumerationValue([1,2,3,4,5,6,7,8,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,31,32,33,34,35])]
			public required lightCharacteristic lightCharacteristic {get;set;} = default;

			[XmlElement("signalGroup")]
			public List<String> signalGroup {get;set;} = [];

			public bool ShouldSerializesignalGroup() { return signalGroup.Any(); }

			[XmlElement("signalPeriod")]
			public decimal? signalPeriod {get;set;} = default;

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			[XmlElement("signalSequence")]
			public List<signalSequence> signalSequence {get;set;} = [];

			public bool ShouldSerializesignalSequence() { return signalSequence.Any(); }
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
		public class ObscuredSector {
			[XmlElement("sectorLimit")]
			public required sectorLimit sectorLimit {get;set;} = default;

			[XmlElement("sectorInformation")]
			public sectorInformation? sectorInformation {get;set;} = default;

			public bool ShouldSerializesectorInformation() { return sectorInformation!=default; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class lightSector {
			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("directionalCharacter")]
			public directionalCharacter? directionalCharacter {get;set;} = default;

			public bool ShouldSerializedirectionalCharacter() { return directionalCharacter!=default; }

			[XmlElement("lightVisibility")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			[XmlElement("sectorLimit")]
			public sectorLimit? sectorLimit {get;set;} = default;

			public bool ShouldSerializesectorLimit() { return sectorLimit!=default; }

			[XmlElement("valueOfNominalRange")]
			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			[XmlElement("sectorInformation")]
			public List<sectorInformation> sectorInformation {get;set;} = [];

			public bool ShouldSerializesectorInformation() { return sectorInformation.Any(); }

			[XmlElement("sectorExtension")]
			public Boolean? sectorExtension {get;set;} = default;

			public bool ShouldSerializesectorExtension() { return sectorExtension.HasValue; }
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		public class sectorCharacteristics {
			[XmlElement("lightCharacteristic")]
			[EnumerationValue([1,2,3,4,5,6,7,8,12,13,14,15,16,17,18,19,20,25,26,27,28,29,30,31,32,33,34,35])]
			public required lightCharacteristic lightCharacteristic {get;set;} = default;

			[XmlElement("lightSector")]
			public List<lightSector> lightSector {get;set;} = [];

			public bool ShouldSerializelightSector() { return lightSector.Any(); }

			[XmlElement("signalGroup")]
			public List<String> signalGroup {get;set;} = [];

			public bool ShouldSerializesignalGroup() { return signalGroup.Any(); }

			[XmlElement("signalPeriod")]
			public decimal? signalPeriod {get;set;} = default;

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			[XmlElement("signalSequence")]
			public List<signalSequence> signalSequence {get;set;} = [];

			public bool ShouldSerializesignalSequence() { return signalSequence.Any(); }

			[XmlElement("candela")]
			public decimal? candela {get;set;} = default;

			public bool ShouldSerializecandela() { return candela.HasValue; }
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
			[XmlElement("referencePoint")]
			public String? referencePoint {get;set;} = default;

			public bool ShouldSerializereferencePoint() { return !string.IsNullOrEmpty(referencePoint); }

			[XmlElement("horizontalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,116,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131])]
			public horizontalDatum? horizontalDatum {get;set;} = default;

			public bool ShouldSerializehorizontalDatum() { return horizontalDatum.HasValue; }

			[XmlElement("sourceDate")]
			[XmlIgnore]
			public required DateOnly sourceDate {get;set;} = default;

			[XmlElement("positioningProcedure")]
			public required String positioningProcedure {get;set;} = string.Empty;

			[JsonIgnore]
			public override string Code => nameof(AtoNFixingMethod);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtoNFixingMethod._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonStatusInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("ChangeDetails")]
			public required ChangeDetails ChangeDetails {get;set;} = default;

			[XmlElement("ChangeTypes")]
			[EnumerationValue([1,2,3,4])]
			public ChangeTypes? ChangeTypes {get;set;} = default;

			public bool ShouldSerializeChangeTypes() { return ChangeTypes.HasValue; }

			[JsonIgnore]
			public override string Code => nameof(AtonStatusInformation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => AtonStatusInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Information about how a position was obtained. (proposed by CCG)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PositioningInformation : InformationNode, IInformationBindingDefinition {
			[XmlElement("positioningDevice")]
			public required String positioningDevice {get;set;} = string.Empty;

			[XmlElement("positioningMethod")]
			public positioningMethod? positioningMethod {get;set;} = default;

			public bool ShouldSerializepositioningMethod() { return positioningMethod!=default; }

			[JsonIgnore]
			public override string Code => nameof(PositioningInformation);

			[JsonIgnore]
			public override informationBindingDefinition[] informationBindingDefinitions => PositioningInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
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
			public spatialAccuracy? spatialAccuracy {get;set;} = default;

			public bool ShouldSerializespatialAccuracy() { return spatialAccuracy!=default; }

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
		/// A visual, acoustical, or radio device, external to a ship, designed to assist in determining a safe course or a vessel's position, or to warn of dangers and/or obstructions. Aids to navigation usually include buoys, beacons, fog signals, lights, radio beacons, leading marks, radio position fixing systems and GNSS which are chart-related and assist safe navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class AidsToNavigation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("iDCode")]
			public String? iDCode {get;set;} = default;

			public bool ShouldSerializeiDCode() { return !string.IsNullOrEmpty(iDCode); }

			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

			[XmlElement("featureName")]
			public List<featureName> featureName {get;set;} = [];

			public bool ShouldSerializefeatureName() { return featureName.Any(); }

			[XmlElement("scaleMinimum")]
			public int? scaleMinimum {get;set;} = default;

			public bool ShouldSerializescaleMinimum() { return scaleMinimum.HasValue; }

			[XmlElement("sourceDate")]
			[XmlIgnore]
			public DateOnly? sourceDate {get;set;} = default;

			public bool ShouldSerializesourceDate() { return sourceDate.HasValue; }

			[XmlElement("source")]
			public String? source {get;set;} = default;

			public bool ShouldSerializesource() { return !string.IsNullOrEmpty(source); }

			[XmlElement("pictorialRepresentation")]
			public String? pictorialRepresentation {get;set;} = default;

			public bool ShouldSerializepictorialRepresentation() { return !string.IsNullOrEmpty(pictorialRepresentation); }

			[XmlElement("inspectionFrequency")]
			public String? inspectionFrequency {get;set;} = default;

			public bool ShouldSerializeinspectionFrequency() { return !string.IsNullOrEmpty(inspectionFrequency); }

			[XmlElement("inspectionRequirements")]
			public String? inspectionRequirements {get;set;} = default;

			public bool ShouldSerializeinspectionRequirements() { return !string.IsNullOrEmpty(inspectionRequirements); }

			[XmlElement("aToNMaintenanceRecord")]
			public String? aToNMaintenanceRecord {get;set;} = default;

			public bool ShouldSerializeaToNMaintenanceRecord() { return !string.IsNullOrEmpty(aToNMaintenanceRecord); }

			[XmlElement("installationDate")]
			[XmlIgnore]
			public DateOnly? installationDate {get;set;} = default;

			public bool ShouldSerializeinstallationDate() { return installationDate.HasValue; }

			[XmlElement("fixedDateRange")]
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public bool ShouldSerializefixedDateRange() { return fixedDateRange!=default; }

			[XmlElement("periodicDateRange")]
			public periodicDateRange? periodicDateRange {get;set;} = default;

			public bool ShouldSerializeperiodicDateRange() { return periodicDateRange!=default; }

			[XmlElement("SeasonalActionRequired")]
			public List<String> SeasonalActionRequired {get;set;} = [];

			public bool ShouldSerializeSeasonalActionRequired() { return SeasonalActionRequired.Any(); }

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
					primitives = [],
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// Something (such as a house, tower, bridge, etc.) that is built by putting parts together and that usually stands on its own.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class StructureObject : AidsToNavigation {
			[XmlElement("AtoNNumber")]
			public required String AtoNNumber {get;set;} = string.Empty;

			[XmlElement("aidAvailabilityCategory")]
			[EnumerationValue([1,2,3])]
			public aidAvailabilityCategory? aidAvailabilityCategory {get;set;} = default;

			public bool ShouldSerializeaidAvailabilityCategory() { return aidAvailabilityCategory.HasValue; }

			[XmlElement("condition")]
			[EnumerationValue([1,2,3,4,5])]
			public condition? condition {get;set;} = default;

			public bool ShouldSerializecondition() { return condition.HasValue; }

			[XmlElement("contactAddress")]
			public contactAddress? contactAddress {get;set;} = default;

			public bool ShouldSerializecontactAddress() { return contactAddress!=default; }

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
					primitives = [],
				},
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AtonFixingMethodAssociation),
					role = Enum.GetName<Role>(Role.fixingMethod)!,
					informationTypes = [nameof(AtoNFixingMethod)],
					primitives = [],
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// The implements used in an operation or activity.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class Equipment : AidsToNavigation {
			[XmlElement("remoteMonitoringSystem")]
			public List<String> remoteMonitoringSystem {get;set;} = [];

			public bool ShouldSerializeremoteMonitoringSystem() { return remoteMonitoringSystem.Any(); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// TBD
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class ElectronicAton : AidsToNavigation {
			[XmlElement("AtoNNumber")]
			public String? AtoNNumber {get;set;} = default;

			public bool ShouldSerializeAtoNNumber() { return !string.IsNullOrEmpty(AtoNNumber); }

			[XmlElement("mMSICode")]
			public required String mMSICode {get;set;} = string.Empty;

			[XmlElement("status")]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A fixed artificial navigation mark that can be recognized by its shape, colour, pattern, topmark or light character, or a combination of these. It may carry various additional aids to navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericBeacon : StructureObject {
			[XmlElement("beaconShape")]
			[EnumerationValue([1,2,3,4,5,6,7])]
			public required beaconShape beaconShape {get;set;} = default;

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A floating object moored to the bottom in a particular (charted) place, as an aid to navigation or for other specific purposes.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericBuoy : StructureObject {
			[XmlElement("buoyShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8])]
			public required buoyShape buoyShape {get;set;} = default;

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("typeOfBuoy")]
			public String? typeOfBuoy {get;set;} = default;

			public bool ShouldSerializetypeOfBuoy() { return !string.IsNullOrEmpty(typeOfBuoy); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public abstract class GenericLight : Equipment {
			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("effectiveIntensity")]
			public decimal? effectiveIntensity {get;set;} = default;

			public bool ShouldSerializeeffectiveIntensity() { return effectiveIntensity.HasValue; }

			[XmlElement("peakIntensity")]
			public decimal? peakIntensity {get;set;} = default;

			public bool ShouldSerializepeakIntensity() { return peakIntensity.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }
		}

		/// <summary>
		/// A prominent object at a fixed location on land which can be used in determining a location or a direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Landmark : StructureObject {
			[XmlElement("categoryOfLandmark")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public List<categoryOfLandmark> categoryOfLandmark {get;set;} = [];

			public bool ShouldSerializecategoryOfLandmark() { return categoryOfLandmark.Any(); }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("function")]
			[EnumerationValue([2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48])]
			public List<function> function {get;set;} = [];

			public bool ShouldSerializefunction() { return function.Any(); }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public required visualProminence visualProminence {get;set;} = default;

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("mannedStructure")]
			public Boolean? mannedStructure {get;set;} = default;

			public bool ShouldSerializemannedStructure() { return mannedStructure.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). A lateral beacon is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage. (UKHO NP 735, 5th Edition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBeacon : GenericBeacon {
			[XmlElement("categoryOfLateralMark")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public required categoryOfLateralMark categoryOfLateralMark {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A lateral buoy is used to indicate the port or starboard hand side of the route to be followed. They are generally used for well defined channels and are used in conjunction with a conventional direction of buoyage. (UKHO NP 735, 5th Edition)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBuoy : GenericBuoy {
			[XmlElement("categoryOfLateralMark")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27])]
			public required categoryOfLateralMark categoryOfLateralMark {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A straight line extending towards an area of navigational interest and generally generated by two navigational aids or one navigational aid and a bearing.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationLine : AidsToNavigation {
			[XmlElement("categoryOfNavigationLine")]
			[EnumerationValue([1,2,3])]
			public required categoryOfNavigationLine categoryOfNavigationLine {get;set;} = default;

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("orientation")]
			public required orientation orientation {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A route which has been specially examined to ensure so far as possible that it is free of dangers and along which ships are advised to navigate.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RecommendedTrack : AidsToNavigation {
			[XmlElement("basedOnFixedMarks")]
			public required Boolean basedOnFixedMarks {get;set;} = false;

			[XmlElement("depthRangeMinimumValue")]
			public decimal? depthRangeMinimumValue {get;set;} = default;

			public bool ShouldSerializedepthRangeMinimumValue() { return depthRangeMinimumValue.HasValue; }

			[XmlElement("maximalPermittedDraught")]
			public decimal? maximalPermittedDraught {get;set;} = default;

			public bool ShouldSerializemaximalPermittedDraught() { return maximalPermittedDraught.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("orientation")]
			public required orientation orientation {get;set;} = default;

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

			[XmlElement("qualityOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializequalityOfVerticalMeasurement() { return qualityOfVerticalMeasurement.Any(); }

			[XmlElement("techniqueOfVerticalMeasurement")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17])]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public bool ShouldSerializetechniqueOfVerticalMeasurement() { return techniqueOfVerticalMeasurement.Any(); }

			[XmlElement("trafficFlow")]
			[EnumerationValue([1,2,3,4])]
			public required trafficFlow trafficFlow {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A light presenting different appearances (in particular, different colours) over various parts of the horizon of interest to maritime navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightSectored : GenericLight {
			[XmlElement("categoryOfLight")]
			[EnumerationValue([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			[XmlElement("exhibitionConditionOfLight")]
			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public List<marksNavigationalSystemOf> marksNavigationalSystemOf {get;set;} = [];

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.Any(); }

			[XmlElement("signalGeneration")]
			[EnumerationValue([1,2,3,4,5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[XmlElement("ObscuredSector")]
			public List<ObscuredSector> ObscuredSector {get;set;} = [];

			public bool ShouldSerializeObscuredSector() { return ObscuredSector.Any(); }

			[XmlElement("sectorCharacteristics")]
			public List<sectorCharacteristics> sectorCharacteristics {get;set;} = [];

			public bool ShouldSerializesectorCharacteristics() { return sectorCharacteristics.Any(); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An all around light is a light that is visible over the whole horizon of interest to marine navigation and having no change in the characteristics of the light.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAllAround : GenericLight {
			[XmlElement("categoryOfLight")]
			[EnumerationValue([1,4,5,6,8,9,10,11,12,13,14,15,17,18,19,20])]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			public bool ShouldSerializecategoryOfLight() { return categoryOfLight.Any(); }

			[XmlElement("exhibitionConditionOfLight")]
			[EnumerationValue([1,2,3,4])]
			public List<exhibitionConditionOfLight> exhibitionConditionOfLight {get;set;} = [];

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.Any(); }

			[XmlElement("lightVisibility")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public lightVisibility? lightVisibility {get;set;} = default;

			public bool ShouldSerializelightVisibility() { return lightVisibility.HasValue; }

			[XmlElement("majorLight")]
			public Boolean? majorLight {get;set;} = default;

			public bool ShouldSerializemajorLight() { return majorLight.HasValue; }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("signalGeneration")]
			[EnumerationValue([1,2,3,4,5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[XmlElement("valueOfNominalRange")]
			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			[XmlElement("multiplicityOfFeatures")]
			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			[XmlElement("rhythmOfLight")]
			public required rhythmOfLight rhythmOfLight {get;set;} = default;

			[XmlElement("flareBearing")]
			public int? flareBearing {get;set;} = default;

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An air obstruction light is a light marking an obstacle which constitutes a danger to air navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAirObstruction : GenericLight {
			[XmlElement("exhibitionConditionOfLight")]
			[EnumerationValue([1,2,3,4])]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public bool ShouldSerializeexhibitionConditionOfLight() { return exhibitionConditionOfLight.HasValue; }

			[XmlElement("lightVisibility")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			public bool ShouldSerializelightVisibility() { return lightVisibility.Any(); }

			[XmlElement("valueOfGeographicRange")]
			public decimal? valueOfGeographicRange {get;set;} = default;

			public bool ShouldSerializevalueOfGeographicRange() { return valueOfGeographicRange.HasValue; }

			[XmlElement("valueOfLuminousRange")]
			public decimal? valueOfLuminousRange {get;set;} = default;

			public bool ShouldSerializevalueOfLuminousRange() { return valueOfLuminousRange.HasValue; }

			[XmlElement("valueOfNominalRange")]
			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			[XmlElement("multiplicityOfFeatures")]
			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public bool ShouldSerializemultiplicityOfFeatures() { return multiplicityOfFeatures!=default; }

			[XmlElement("rhythmOfLight")]
			public required rhythmOfLight rhythmOfLight {get;set;} = default;

			[XmlElement("flareBearing")]
			public int? flareBearing {get;set;} = default;

			public bool ShouldSerializeflareBearing() { return flareBearing.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A fog detector light is a light used to automatically determine conditions of visibility which warrant the turning on or off of a sound signal.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFogDetector : GenericLight {
			[XmlElement("signalGeneration")]
			[EnumerationValue([1,2,3,4,5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[XmlElement("rhythmOfLight")]
			public required rhythmOfLight rhythmOfLight {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A device capable of, or intended for, reflecting radar signals.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarReflector : Equipment {
			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A warning signal transmitted by a vessel, or aid to navigation, during periods of low visibility. Also, the device producing such a signal.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FogSignal : Equipment {
			[XmlElement("categoryOfFogSignal")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10])]
			public required categoryOfFogSignal categoryOfFogSignal {get;set;} = default;

			[XmlElement("signalFrequency")]
			public int? signalFrequency {get;set;} = default;

			public bool ShouldSerializesignalFrequency() { return signalFrequency.HasValue; }

			[XmlElement("signalGeneration")]
			[EnumerationValue([1,2,3,4,5,6])]
			public signalGeneration? signalGeneration {get;set;} = default;

			public bool ShouldSerializesignalGeneration() { return signalGeneration.HasValue; }

			[XmlElement("signalGroup")]
			public String? signalGroup {get;set;} = default;

			public bool ShouldSerializesignalGroup() { return !string.IsNullOrEmpty(signalGroup); }

			[XmlElement("signalOutput")]
			public decimal? signalOutput {get;set;} = default;

			public bool ShouldSerializesignalOutput() { return signalOutput.HasValue; }

			[XmlElement("signalPeriod")]
			public decimal? signalPeriod {get;set;} = default;

			public bool ShouldSerializesignalPeriod() { return signalPeriod.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("valueOfMaximumRange")]
			public decimal? valueOfMaximumRange {get;set;} = default;

			public bool ShouldSerializevalueOfMaximumRange() { return valueOfMaximumRange.HasValue; }

			[XmlElement("signalSequence")]
			public signalSequence? signalSequence {get;set;} = default;

			public bool ShouldSerializesignalSequence() { return signalSequence!=default; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A sensor used to observe the environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class EnvironmentObservationEquipment : Equipment {
			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("typeOfEnvironmentalObservationEquipment")]
			public List<String> typeOfEnvironmentalObservationEquipment {get;set;} = [];

			public bool ShouldSerializetypeOfEnvironmentalObservationEquipment() { return typeOfEnvironmentalObservationEquipment.Any(); }

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
		public partial class RadioStation : Equipment {
			[XmlElement("categoryOfRadioStation")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,19,20])]
			public required categoryOfRadioStation categoryOfRadioStation {get;set;} = default;

			[XmlElement("estimatedRangeOfTransmission")]
			public decimal? estimatedRangeOfTransmission {get;set;} = default;

			public bool ShouldSerializeestimatedRangeOfTransmission() { return estimatedRangeOfTransmission.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public status? status {get;set;} = default;

			public bool ShouldSerializestatus() { return status.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// (1) The identifying characteristics of an aid to navigation which serve to facilitate its recognition against a daylight viewing background. On those structures that do not by themselves present an adequate viewing area to be seen at the required distance, the aid is made more visible by affixing a daymark to the structure. A daymark so affixed has a distinctive colour and shape depending on the purpose of the aid. (2) An unlighted navigational mark.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Daymark : Equipment {
			[XmlElement("categoryOfSpecialPurposeMark")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			public categoryOfSpecialPurposeMark? categoryOfSpecialPurposeMark {get;set;} = default;

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("orientationValue")]
			public decimal? orientationValue {get;set;} = default;

			public bool ShouldSerializeorientationValue() { return orientationValue.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("topmarkDaymarkShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
			public required topmarkDaymarkShape topmarkDaymarkShape {get;set;} = default;

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("shapeInformation")]
			public shapeInformation? shapeInformation {get;set;} = default;

			public bool ShouldSerializeshapeInformation() { return shapeInformation!=default; }

			[XmlElement("isSlatted")]
			public required Boolean isSlatted {get;set;} = false;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A means of distinguishing unlighted marks at night. Retro-reflective material is secured to the mark in a particular pattern to reflect back light.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Retroreflector : Equipment {
			[XmlElement("colour")]
			[EnumerationValue([1,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,10,11,12,13,14,15])]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public bool ShouldSerializemarksNavigationalSystemOf() { return marksNavigationalSystemOf.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A transponder beacon transmitting a coded signal on radar frequency, permitting an interrogating craft to determine the bearing and range of the transponder.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarTransponderBeacon : Equipment {
			[XmlElement("categoryOfRadarTransponderBeacon")]
			[EnumerationValue([1,2,3])]
			public required categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon {get;set;} = default;

			[XmlElement("radarWaveLength")]
			public radarWaveLength? radarWaveLength {get;set;} = default;

			public bool ShouldSerializeradarWaveLength() { return radarWaveLength!=default; }

			[XmlElement("signalGroup")]
			public String? signalGroup {get;set;} = default;

			public bool ShouldSerializesignalGroup() { return !string.IsNullOrEmpty(signalGroup); }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("valueOfNominalRange")]
			public decimal? valueOfNominalRange {get;set;} = default;

			public bool ShouldSerializevalueOfNominalRange() { return valueOfNominalRange.HasValue; }

			[XmlElement("manufactorer")]
			public String? manufactorer {get;set;} = default;

			public bool ShouldSerializemanufactorer() { return !string.IsNullOrEmpty(manufactorer); }

			[XmlElement("sectorLimitOne")]
			public sectorLimitOne? sectorLimitOne {get;set;} = default;

			public bool ShouldSerializesectorLimitOne() { return sectorLimitOne!=default; }

			[XmlElement("sectorLimitTwo")]
			public sectorLimitTwo? sectorLimitTwo {get;set;} = default;

			public bool ShouldSerializesectorLimitTwo() { return sectorLimitTwo!=default; }

			[XmlElement("signalSequence")]
			public signalSequence? signalSequence {get;set;} = default;

			public bool ShouldSerializesignalSequence() { return signalSequence!=default; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An Automatic Identification System (AIS) message 21 transmitted from an AIS station to simulate on navigation systems an Aid to Navigation which does not physically exist.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VirtualAISAidToNavigation : ElectronicAton {
			[XmlElement("virtualAISAidToNavigationType")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			public required virtualAISAidToNavigationType virtualAISAidToNavigationType {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An Automatic Identification System (AIS) message 21 transmitted from a physical Aid to Navigation, or transmitted from an AIS station for an Aid to Navigation which physically exists.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalAISAidToNavigation : ElectronicAton {
			[XmlElement("CategoryOfPhysicalAISAidToNavigation")]
			[EnumerationValue([1,2,3])]
			public required CategoryOfPhysicalAISAidToNavigation CategoryOfPhysicalAISAidToNavigation {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SyntheticAISAidToNavigation : ElectronicAton {
			[XmlElement("CategoryOfSyntheticAISAidtoNavigation")]
			[EnumerationValue([1,2])]
			public required CategoryOfSyntheticAISAidtoNavigation CategoryOfSyntheticAISAidtoNavigation {get;set;} = default;

			[XmlElement("virtualAISAidToNavigationType")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12])]
			public required virtualAISAidToNavigationType virtualAISAidToNavigationType {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PowerSource : Equipment {
			[XmlElement("CategoryOfPowerSource")]
			[EnumerationValue([1,2,3,4])]
			public required CategoryOfPowerSource CategoryOfPowerSource {get;set;} = default;

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A cardinal beacon is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBeacon : GenericBeacon {
			[XmlElement("categoryOfCardinalMark")]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfCardinalMark categoryOfCardinalMark {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A cardinal buoy is used in conjunction with the compass to indicate where the mariner may find the best navigable water. It is placed in one of the four quadrants (North, East, South and West), bounded by inter-cardinal bearings from the point marked.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBuoy : GenericBuoy {
			[XmlElement("categoryOfCardinalMark")]
			[EnumerationValue([1,2,3,4])]
			public required categoryOfCardinalMark categoryOfCardinalMark {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). An installation buoy is a buoy used for loading tankers with gas or oil. (IHO Chart Specifications, M-4)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InstallationBuoy : GenericBuoy {
			[XmlElement("categoryOfInstallationBuoy")]
			[EnumerationValue([1,2])]
			public required categoryOfInstallationBuoy categoryOfInstallationBuoy {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A boat-like structure used instead of a light buoy in waters where strong streams or currents are experienced, or when a greater elevation than that of a light buoy is necessary.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFloat : StructureObject {
			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlElement("mannedStructure")]
			public Boolean? mannedStructure {get;set;} = default;

			public bool ShouldSerializemannedStructure() { return mannedStructure.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

			[XmlElement("horizontalAccuracy")]
			public decimal? horizontalAccuracy {get;set;} = default;

			public bool ShouldSerializehorizontalAccuracy() { return horizontalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A distinctively marked vessel anchored or moored at a charted point, to serve as an aid to navigation. By night, it displays a characteristic light(s) and is usually equipped with other devices, such as fog signal, submarine sound signal, and radio-beacon, to assist navigation.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightVessel : StructureObject {
			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("horizontalLength")]
			public decimal? horizontalLength {get;set;} = default;

			public bool ShouldSerializehorizontalLength() { return horizontalLength.HasValue; }

			[XmlElement("horizontalWidth")]
			public decimal? horizontalWidth {get;set;} = default;

			public bool ShouldSerializehorizontalWidth() { return horizontalWidth.HasValue; }

			[XmlElement("mannedStructure")]
			public Boolean? mannedStructure {get;set;} = default;

			public bool ShouldSerializemannedStructure() { return mannedStructure.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

			[XmlElement("horizontalAccuracy")]
			public decimal? horizontalAccuracy {get;set;} = default;

			public bool ShouldSerializehorizontalAccuracy() { return horizontalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A permanent offshore structure, either fixed or floating.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OffshorePlatform : StructureObject {
			[XmlElement("categoryOfOffshorePlatform")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11])]
			public List<categoryOfOffshorePlatform> categoryOfOffshorePlatform {get;set;} = [];

			public bool ShouldSerializecategoryOfOffshorePlatform() { return categoryOfOffshorePlatform.Any(); }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("mannedStructure")]
			public Boolean? mannedStructure {get;set;} = default;

			public bool ShouldSerializemannedStructure() { return mannedStructure.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("product")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25])]
			public List<product> product {get;set;} = [];

			public bool ShouldSerializeproduct() { return product.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A large storage structure used for storing loose materials, liquids and/or gases.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SiloTank : StructureObject {
			[XmlElement("buildingShape")]
			[EnumerationValue([5,6,7,8,9])]
			public buildingShape? buildingShape {get;set;} = default;

			public bool ShouldSerializebuildingShape() { return buildingShape.HasValue; }

			[XmlElement("categoryOfSiloTank")]
			[EnumerationValue([1,2,3,4])]
			public categoryOfSiloTank? categoryOfSiloTank {get;set;} = default;

			public bool ShouldSerializecategoryOfSiloTank() { return categoryOfSiloTank.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("elevation")]
			public decimal? elevation {get;set;} = default;

			public bool ShouldSerializeelevation() { return elevation.HasValue; }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.Any(); }

			[XmlElement("radarConspicuous")]
			public Boolean? radarConspicuous {get;set;} = default;

			public bool ShouldSerializeradarConspicuous() { return radarConspicuous.HasValue; }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A long heavy timber or section of steel, wood, concrete, etc., forced into the earth or sea floor to serve as a support, as for a pier, or to resist lateral pressure; or as a free standing pole within a marine environment.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Pile : StructureObject {
			[XmlElement("categoryOfPile")]
			[EnumerationValue([1,3,4,5,6,7])]
			public categoryOfPile? categoryOfPile {get;set;} = default;

			public bool ShouldSerializecategoryOfPile() { return categoryOfPile.HasValue; }

			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("height")]
			public decimal? height {get;set;} = default;

			public bool ShouldSerializeheight() { return height.HasValue; }

			[XmlElement("verticalDatum")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45])]
			public verticalDatum? verticalDatum {get;set;} = default;

			public bool ShouldSerializeverticalDatum() { return verticalDatum.HasValue; }

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

			[XmlElement("visualProminence")]
			[EnumerationValue([1,2,3])]
			public visualProminence? visualProminence {get;set;} = default;

			public bool ShouldSerializevisualProminence() { return visualProminence.HasValue; }

			[XmlElement("verticalAccuracy")]
			public decimal? verticalAccuracy {get;set;} = default;

			public bool ShouldSerializeverticalAccuracy() { return verticalAccuracy.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A heavy weight (of concrete, cast-iron, etc..) that rests on the sea bed and to which a mooring line can be attached. (IALA Dictionary, 8-5-025)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SinkerAnchor : AidsToNavigation {
			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.HasValue; }

			[XmlElement("sinkerDimensions")]
			public sinkerDimensions? sinkerDimensions {get;set;} = default;

			public bool ShouldSerializesinkerDimensions() { return sinkerDimensions!=default; }

			[XmlElement("weight")]
			public required decimal weight {get;set;} = default;

			[XmlElement("sinkerType")]
			public String? sinkerType {get;set;} = default;

			public bool ShouldSerializesinkerType() { return !string.IsNullOrEmpty(sinkerType); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A shackle at the lower end of a mooring chain, for attachment to an anchor or sinker. (IALA Dictionary, 8-5-150)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringShackle : AidsToNavigation {
			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.HasValue; }

			[XmlElement("ShackleType")]
			[EnumerationValue([1,2,3,4,5,6])]
			public ShackleType? ShackleType {get;set;} = default;

			public bool ShouldSerializeShackleType() { return ShackleType.HasValue; }

			[XmlElement("weight")]
			public decimal? weight {get;set;} = default;

			public bool ShouldSerializeweight() { return weight.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An assembly of wires or fibres, or a wire rope or chain, which has been laid underwater or buried beneath the sea floor.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableSubmarine : AidsToNavigation {
			[XmlElement("CableDimensions")]
			public CableDimensions? CableDimensions {get;set;} = default;

			public bool ShouldSerializeCableDimensions() { return CableDimensions!=default; }

			[XmlElement("categoryOfCable")]
			[EnumerationValue([1,3,4,5,6,7,8])]
			public required categoryOfCable categoryOfCable {get;set;} = default;

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A chain link that provides for rotary motion between the lengths of chain that it connects. (IALA Dictionary, 8-5-165)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Swivel : AidsToNavigation {
			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.HasValue; }

			[XmlElement("weight")]
			public decimal? weight {get;set;} = default;

			public bool ShouldSerializeweight() { return weight.HasValue; }

			[XmlElement("swivelType")]
			public String? swivelType {get;set;} = default;

			public bool ShouldSerializeswivelType() { return !string.IsNullOrEmpty(swivelType); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Two lengths of chain connected by a central ring and used for lifting wide loads. (IALA Dictionary,8-3-195)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bridle : AidsToNavigation {
			[XmlElement("bridleLinkType")]
			public String? bridleLinkType {get;set;} = default;

			public bool ShouldSerializebridleLinkType() { return !string.IsNullOrEmpty(bridleLinkType); }

			[XmlElement("legsDetails")]
			public String? legsDetails {get;set;} = default;

			public bool ShouldSerializelegsDetails() { return !string.IsNullOrEmpty(legsDetails); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CounterWeight : AidsToNavigation {
			[XmlElement("natureOfConstruction")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14])]
			public natureOfConstruction? natureOfConstruction {get;set;} = default;

			public bool ShouldSerializenatureOfConstruction() { return natureOfConstruction.HasValue; }

			[XmlElement("weight")]
			public required decimal weight {get;set;} = default;

			[XmlElement("counterWeightType")]
			public String? counterWeightType {get;set;} = default;

			public bool ShouldSerializecounterWeightType() { return !string.IsNullOrEmpty(counterWeightType); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A characteristic shape secured at the top of a buoy or beacon to aid in its identification. (IHO Dictionary, S-32, 5th Edition, 5548)
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Topmark : AidsToNavigation {
			[XmlElement("colour")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13])]
			public List<colour> colour {get;set;} = [];

			public bool ShouldSerializecolour() { return colour.Any(); }

			[XmlElement("colourPattern")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9])]
			public List<colourPattern> colourPattern {get;set;} = [];

			public bool ShouldSerializecolourPattern() { return colourPattern.Any(); }

			[XmlElement("status")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,41,42,43])]
			public List<status> status {get;set;} = [];

			public bool ShouldSerializestatus() { return status.Any(); }

			[XmlElement("topmarkDaymarkShape")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34])]
			public required topmarkDaymarkShape topmarkDaymarkShape {get;set;} = default;

			[XmlElement("verticalLength")]
			public decimal? verticalLength {get;set;} = default;

			public bool ShouldSerializeverticalLength() { return verticalLength.HasValue; }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A beacon is a prominent specially constructed object forming a conspicuous mark as a fixed aid to navigation or for use in hydrographic survey (IHO Dictionary, S-32, 5th Edition, 420). A special purpose beacon is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners. (UKHO NP 735, 5th Edition) Beacon in general: A beacon whose appearance or purpose is not adequately known.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBeacon : GenericBeacon {
			[XmlElement("categoryOfSpecialPurposeMark")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// A buoy is a floating object moored to the bottom in a particular place, as an aid to navigation or for other specific purposes. (IHO Dictionary, S-32, 5th Edition, 565). A special purpose buoy is primarily used to indicate an area or feature, the nature of which is apparent from reference to a chart, Sailing Directions or Notices to Mariners. (UKHO NP 735, 5th Edition) Buoy in general: A buoy whose appearance or purpose is not adequately known.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBuoy : GenericBuoy {
			[XmlElement("categoryOfSpecialPurposeMark")]
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64])]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			public bool ShouldSerializecategoryOfSpecialPurposeMark() { return categoryOfSpecialPurposeMark.Any(); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// -
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DangerousFeature : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("information")]
			public List<information> information {get;set;} = [];

			public bool ShouldSerializeinformation() { return information.Any(); }

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Used to identify an aggregation of two or more objects. This aggregation may be named content of categoryOfAggregation should be put in information attribute when converting to S-57.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAggregation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("CategoryOfAggregation")]
			[EnumerationValue([1,3,2])]
			public required CategoryOfAggregation CategoryOfAggregation {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// Used to identify an association between two or more objects. The association may be named content of categoryOfAssociation should be put in information attribute when converting to S-57
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AtonAssociation : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("CategoryOfAssociation")]
			[EnumerationValue([1,2])]
			public required CategoryOfAssociation CategoryOfAssociation {get;set;} = default;

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
			public required categoryOfTemporalVariation categoryOfTemporalVariation {get;set;} = default;

			[XmlElement("orientationUncertainty")]
			public decimal? orientationUncertainty {get;set;} = default;

			public bool ShouldSerializeorientationUncertainty() { return orientationUncertainty.HasValue; }

			[XmlElement("horizontalDistanceUncertainty")]
			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			public bool ShouldSerializehorizontalDistanceUncertainty() { return horizontalDistanceUncertainty.HasValue; }

			[XmlElement("horizontalPositionUncertainty")]
			public required horizontalPositionUncertainty horizontalPositionUncertainty {get;set;} = default;

			[XmlElement("information")]
			public information? information {get;set;} = default;

			public bool ShouldSerializeinformation() { return information!=default; }

			[XmlElement("informationInNationalLanguage")]
			public String? informationInNationalLanguage {get;set;} = default;

			public bool ShouldSerializeinformationInNationalLanguage() { return !string.IsNullOrEmpty(informationInNationalLanguage); }

			[XmlElement("textualDescription")]
			public textualDescription? textualDescription {get;set;} = default;

			public bool ShouldSerializetextualDescription() { return textualDescription!=default; }

			[XmlElement("verticalUncertainty")]
			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public bool ShouldSerializeverticalUncertainty() { return verticalUncertainty!=default; }

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
		/// An area within which the navigational system of marks has been established in relation to a specific direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocalDirectionOfBuoyage : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("orientation")]
			public required orientation orientation {get;set;} = default;

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

			[JsonIgnore]
			[XmlAttribute("id", Namespace = "http://www.opengis.net/gml/3.2")]
			public string? gmlId { get; set; }

			[JsonIgnore]
			[XmlAnyElement]
			public XmlElement[]? Geometry { get; set; } = default;
		}

		/// <summary>
		/// An area within which the navigational system of marks has been established in relation to a specific direction.
		/// </summary>
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationalSystemOfMarks : FeatureNode, IFeatureBindingDefinition {
			[XmlElement("marksNavigationalSystemOf")]
			[EnumerationValue([1,2,9,10,11,12,13,15])]
			public required marksNavigationalSystemOf marksNavigationalSystemOf {get;set;} = default;

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
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			public required verticalDatum verticalDatum {get;set;} = default;

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
			[EnumerationValue([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,43,44,45,46,47,48,49])]
			public required verticalDatum verticalDatum {get;set;} = default;

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
	}

	[XmlType(Namespace = "http://www.iho.int/S201/2.0")]
	public class Dataset : S100Framework.DomainModel.S100.DatasetBase
	{
		[XmlElement(Order = 1)]
		public Members? members { get; set; } = default;
	}

	[XmlType(Namespace = "http://www.iho.int/S201/2.0", TypeName = "members")]
	public class Members
	{
		[XmlElement("InformationTypes.AtoNFixingMethod", typeof(InformationTypes.AtoNFixingMethod), Order = 1, ElementName = "AtoNFixingMethod")]
		[XmlElement("InformationTypes.AtonStatusInformation", typeof(InformationTypes.AtonStatusInformation), Order = 1, ElementName = "AtonStatusInformation")]
		[XmlElement("InformationTypes.PositioningInformation", typeof(InformationTypes.PositioningInformation), Order = 1, ElementName = "PositioningInformation")]
		[XmlElement("InformationTypes.SpatialQuality", typeof(InformationTypes.SpatialQuality), Order = 1, ElementName = "SpatialQuality")]
		[XmlElement("FeatureTypes.Landmark", typeof(FeatureTypes.Landmark), Order = 1, ElementName = "Landmark")]
		[XmlElement("FeatureTypes.LateralBeacon", typeof(FeatureTypes.LateralBeacon), Order = 1, ElementName = "LateralBeacon")]
		[XmlElement("FeatureTypes.LateralBuoy", typeof(FeatureTypes.LateralBuoy), Order = 1, ElementName = "LateralBuoy")]
		[XmlElement("FeatureTypes.NavigationLine", typeof(FeatureTypes.NavigationLine), Order = 1, ElementName = "NavigationLine")]
		[XmlElement("FeatureTypes.RecommendedTrack", typeof(FeatureTypes.RecommendedTrack), Order = 1, ElementName = "RecommendedTrack")]
		[XmlElement("FeatureTypes.LightSectored", typeof(FeatureTypes.LightSectored), Order = 1, ElementName = "LightSectored")]
		[XmlElement("FeatureTypes.LightAllAround", typeof(FeatureTypes.LightAllAround), Order = 1, ElementName = "LightAllAround")]
		[XmlElement("FeatureTypes.LightAirObstruction", typeof(FeatureTypes.LightAirObstruction), Order = 1, ElementName = "LightAirObstruction")]
		[XmlElement("FeatureTypes.LightFogDetector", typeof(FeatureTypes.LightFogDetector), Order = 1, ElementName = "LightFogDetector")]
		[XmlElement("FeatureTypes.RadarReflector", typeof(FeatureTypes.RadarReflector), Order = 1, ElementName = "RadarReflector")]
		[XmlElement("FeatureTypes.FogSignal", typeof(FeatureTypes.FogSignal), Order = 1, ElementName = "FogSignal")]
		[XmlElement("FeatureTypes.EnvironmentObservationEquipment", typeof(FeatureTypes.EnvironmentObservationEquipment), Order = 1, ElementName = "EnvironmentObservationEquipment")]
		[XmlElement("FeatureTypes.RadioStation", typeof(FeatureTypes.RadioStation), Order = 1, ElementName = "RadioStation")]
		[XmlElement("FeatureTypes.Daymark", typeof(FeatureTypes.Daymark), Order = 1, ElementName = "Daymark")]
		[XmlElement("FeatureTypes.Retroreflector", typeof(FeatureTypes.Retroreflector), Order = 1, ElementName = "Retroreflector")]
		[XmlElement("FeatureTypes.RadarTransponderBeacon", typeof(FeatureTypes.RadarTransponderBeacon), Order = 1, ElementName = "RadarTransponderBeacon")]
		[XmlElement("FeatureTypes.VirtualAISAidToNavigation", typeof(FeatureTypes.VirtualAISAidToNavigation), Order = 1, ElementName = "VirtualAISAidToNavigation")]
		[XmlElement("FeatureTypes.PhysicalAISAidToNavigation", typeof(FeatureTypes.PhysicalAISAidToNavigation), Order = 1, ElementName = "PhysicalAISAidToNavigation")]
		[XmlElement("FeatureTypes.SyntheticAISAidToNavigation", typeof(FeatureTypes.SyntheticAISAidToNavigation), Order = 1, ElementName = "SyntheticAISAidToNavigation")]
		[XmlElement("FeatureTypes.PowerSource", typeof(FeatureTypes.PowerSource), Order = 1, ElementName = "PowerSource")]
		[XmlElement("FeatureTypes.IsolatedDangerBeacon", typeof(FeatureTypes.IsolatedDangerBeacon), Order = 1, ElementName = "IsolatedDangerBeacon")]
		[XmlElement("FeatureTypes.CardinalBeacon", typeof(FeatureTypes.CardinalBeacon), Order = 1, ElementName = "CardinalBeacon")]
		[XmlElement("FeatureTypes.IsolatedDangerBuoy", typeof(FeatureTypes.IsolatedDangerBuoy), Order = 1, ElementName = "IsolatedDangerBuoy")]
		[XmlElement("FeatureTypes.CardinalBuoy", typeof(FeatureTypes.CardinalBuoy), Order = 1, ElementName = "CardinalBuoy")]
		[XmlElement("FeatureTypes.InstallationBuoy", typeof(FeatureTypes.InstallationBuoy), Order = 1, ElementName = "InstallationBuoy")]
		[XmlElement("FeatureTypes.MooringBuoy", typeof(FeatureTypes.MooringBuoy), Order = 1, ElementName = "MooringBuoy")]
		[XmlElement("FeatureTypes.EmergencyWreckMarkingBuoy", typeof(FeatureTypes.EmergencyWreckMarkingBuoy), Order = 1, ElementName = "EmergencyWreckMarkingBuoy")]
		[XmlElement("FeatureTypes.Lighthouse", typeof(FeatureTypes.Lighthouse), Order = 1, ElementName = "Lighthouse")]
		[XmlElement("FeatureTypes.LightFloat", typeof(FeatureTypes.LightFloat), Order = 1, ElementName = "LightFloat")]
		[XmlElement("FeatureTypes.LightVessel", typeof(FeatureTypes.LightVessel), Order = 1, ElementName = "LightVessel")]
		[XmlElement("FeatureTypes.OffshorePlatform", typeof(FeatureTypes.OffshorePlatform), Order = 1, ElementName = "OffshorePlatform")]
		[XmlElement("FeatureTypes.SiloTank", typeof(FeatureTypes.SiloTank), Order = 1, ElementName = "SiloTank")]
		[XmlElement("FeatureTypes.Pile", typeof(FeatureTypes.Pile), Order = 1, ElementName = "Pile")]
		[XmlElement("FeatureTypes.Building", typeof(FeatureTypes.Building), Order = 1, ElementName = "Building")]
		[XmlElement("FeatureTypes.Bridge", typeof(FeatureTypes.Bridge), Order = 1, ElementName = "Bridge")]
		[XmlElement("FeatureTypes.SinkerAnchor", typeof(FeatureTypes.SinkerAnchor), Order = 1, ElementName = "SinkerAnchor")]
		[XmlElement("FeatureTypes.MooringShackle", typeof(FeatureTypes.MooringShackle), Order = 1, ElementName = "MooringShackle")]
		[XmlElement("FeatureTypes.CableSubmarine", typeof(FeatureTypes.CableSubmarine), Order = 1, ElementName = "CableSubmarine")]
		[XmlElement("FeatureTypes.Swivel", typeof(FeatureTypes.Swivel), Order = 1, ElementName = "Swivel")]
		[XmlElement("FeatureTypes.Bridle", typeof(FeatureTypes.Bridle), Order = 1, ElementName = "Bridle")]
		[XmlElement("FeatureTypes.CounterWeight", typeof(FeatureTypes.CounterWeight), Order = 1, ElementName = "CounterWeight")]
		[XmlElement("FeatureTypes.Topmark", typeof(FeatureTypes.Topmark), Order = 1, ElementName = "Topmark")]
		[XmlElement("FeatureTypes.SafeWaterBeacon", typeof(FeatureTypes.SafeWaterBeacon), Order = 1, ElementName = "SafeWaterBeacon")]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBeacon", typeof(FeatureTypes.SpecialPurposeGeneralBeacon), Order = 1, ElementName = "SpecialPurposeGeneralBeacon")]
		[XmlElement("FeatureTypes.SafeWaterBuoy", typeof(FeatureTypes.SafeWaterBuoy), Order = 1, ElementName = "SafeWaterBuoy")]
		[XmlElement("FeatureTypes.SpecialPurposeGeneralBuoy", typeof(FeatureTypes.SpecialPurposeGeneralBuoy), Order = 1, ElementName = "SpecialPurposeGeneralBuoy")]
		[XmlElement("FeatureTypes.DangerousFeature", typeof(FeatureTypes.DangerousFeature), Order = 1, ElementName = "DangerousFeature")]
		[XmlElement("FeatureTypes.AtonAggregation", typeof(FeatureTypes.AtonAggregation), Order = 1, ElementName = "AtonAggregation")]
		[XmlElement("FeatureTypes.AtonAssociation", typeof(FeatureTypes.AtonAssociation), Order = 1, ElementName = "AtonAssociation")]
		[XmlElement("FeatureTypes.QualityOfNonBathymetricData", typeof(FeatureTypes.QualityOfNonBathymetricData), Order = 1, ElementName = "QualityOfNonBathymetricData")]
		[XmlElement("FeatureTypes.DataCoverage", typeof(FeatureTypes.DataCoverage), Order = 1, ElementName = "DataCoverage")]
		[XmlElement("FeatureTypes.LocalDirectionOfBuoyage", typeof(FeatureTypes.LocalDirectionOfBuoyage), Order = 1, ElementName = "LocalDirectionOfBuoyage")]
		[XmlElement("FeatureTypes.NavigationalSystemOfMarks", typeof(FeatureTypes.NavigationalSystemOfMarks), Order = 1, ElementName = "NavigationalSystemOfMarks")]
		[XmlElement("FeatureTypes.SoundingDatum", typeof(FeatureTypes.SoundingDatum), Order = 1, ElementName = "SoundingDatum")]
		[XmlElement("FeatureTypes.VerticalDatumOfData", typeof(FeatureTypes.VerticalDatumOfData), Order = 1, ElementName = "VerticalDatumOfData")]
		public List<object> elements { get; set; } = new List<object>();
	}
}

#pragma warning restore CS8981
