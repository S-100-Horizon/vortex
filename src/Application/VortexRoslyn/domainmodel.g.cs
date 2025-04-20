using System;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable enable
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.


namespace S100Framework.DomainModel.S101 {
	public static class Information
	{
		public static Version Version => new Version("2.0.0");
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
	public enum bridgeConstruction : int {
		[System.ComponentModel.Description("ATypicallyCurvedStructuralMemberSpanningAnOpeningAndServingAsASupportAsForTheWallOrOtherWeightAboveTheOpening")]
		[EnumMember(Value = "Arch")] 
		Arch = 1,
		[System.ComponentModel.Description("AStructureConsistingOfASeriesOfArchesOrTowersSupportingARoadwayWaterwayEtcAcrossADepressionEtc")]
		[EnumMember(Value = "Viaduct")] 
		Viaduct = 2,
		[System.ComponentModel.Description("AFixedFloatingBridgeSupportedByPontoons")]
		[EnumMember(Value = "Pontoon Bridge")] 
		PontoonBridge = 3,
		[System.ComponentModel.Description("AFixedBridgeConsistingOfEitherARoadwayOrATrussSuspendedFromTwoOrMoreCablesWhichPassOverTowersAndAreAnchoredByBackstaysToAFirmFoundation")]
		[EnumMember(Value = "Suspension Bridge")] 
		SuspensionBridge = 4,
		[System.ComponentModel.Description("ConsistsOfTowersOnEachSideOfTheWatercourseConnectedByASystemOfGirdersOnWhichACarriageRuns")]
		[EnumMember(Value = "Transporter Bridge")] 
		TransporterBridge = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum bridgeFunction : int {
		[System.ComponentModel.Description("OfRelatingToOrDesignedForVehiclesAndEspeciallyMotorVehicles")]
		[EnumMember(Value = "Vehicular")] 
		Vehicular = 1,
		[System.ComponentModel.Description("OfRelatingToOrDesignedForVehiclesThatRunOnAGuidingTrackSEspeciallyTrains")]
		[EnumMember(Value = "Rail")] 
		Rail = 2,
		[System.ComponentModel.Description("OfRelatingToOrDesignedForWalking")]
		[EnumMember(Value = "Pedestrian")] 
		Pedestrian = 3,
		[System.ComponentModel.Description("ABridgeSupportingAnArtificiallyElevatedChannelForTheConveyanceOfWater")]
		[EnumMember(Value = "Aqueduct")] 
		Aqueduct = 4,
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
	public enum categoryOfAirportAirfield : int {
		[System.ComponentModel.Description("ALargeMilitaryAirfieldUsuallyEquippedWithAControlTowerHangarsAndAccommodationForTheReceivingAndDischargingOfPassengersOrCargo")]
		[EnumMember(Value = "Military Aeroplane Airport")] 
		MilitaryAeroplaneAirport = 1,
		[System.ComponentModel.Description("ALargeAirfieldUsuallyEquippedWithAControlTowerHangarsAndAccommodationForTheReceivingAndDischargingOfPassengersOrCargo")]
		[EnumMember(Value = "Civil Aeroplane Airport")] 
		CivilAeroplaneAirport = 2,
		[System.ComponentModel.Description("ALandingPlaceForHelicoptersControlledByTheMilitary")]
		[EnumMember(Value = "Military Heliport")] 
		MilitaryHeliport = 3,
		[System.ComponentModel.Description("ALandingPlaceForHelicoptersOftenTheRoofOfABuilding")]
		[EnumMember(Value = "Civil Heliport")] 
		CivilHeliport = 4,
		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfGliders")]
		[EnumMember(Value = "Glider Airfield")] 
		GliderAirfield = 5,
		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfSmallAeroplanes")]
		[EnumMember(Value = "Small Planes Airfield")] 
		SmallPlanesAirfield = 6,
		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfAeroplanesOrHelicoptersInTimesOfEmergency")]
		[EnumMember(Value = "Emergency Airfield")] 
		EmergencyAirfield = 8,
		[System.ComponentModel.Description("AnAreaOfLandSetAsideForTheTakeOffAndLandingOfAeroplanesOrHelicoptersInTimesOfSearchAndRescue")]
		[EnumMember(Value = "Search and Rescue Airfield")] 
		SearchAndRescueAirfield = 9,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfAnchorage : int {
		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchor")]
		[EnumMember(Value = "Unrestricted Anchorage")] 
		UnrestrictedAnchorage = 1,
		[System.ComponentModel.Description("AnAreaInWhichVesselsOfDeepDraughtAnchorOrMayAnchor")]
		[EnumMember(Value = "Deep Water Anchorage")] 
		DeepWaterAnchorage = 2,
		[System.ComponentModel.Description("AnAreaInWhichTankersAnchorOrMayAnchor")]
		[EnumMember(Value = "Tanker Anchorage")] 
		TankerAnchorage = 3,
		[System.ComponentModel.Description("AnAreaWhereAVesselAnchorsWhenSatisfyingQuarantineRegulations")]
		[EnumMember(Value = "Quarantine Anchorage")] 
		QuarantineAnchorage = 5,
		[System.ComponentModel.Description("AnAreaInWhichSeaplanesAnchorOrMayAnchor")]
		[EnumMember(Value = "Seaplane Anchorage")] 
		SeaplaneAnchorage = 6,
		[System.ComponentModel.Description("AnAreaInWhichYachtsAndSmallBoatsAnchorOrMayAnchor")]
		[EnumMember(Value = "Small Craft Anchorage")] 
		SmallCraftAnchorage = 7,
		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchorForPeriodsOfUpTo24Hours")]
		[EnumMember(Value = "Anchorage for Periods Up To 24 Hours")] 
		AnchorageForPeriodsUpTo24Hours = 9,
		[System.ComponentModel.Description("AnAreaInWhichVesselsMayAnchorForAPeriodOfTimeNotToExceedASpecificLimit")]
		[EnumMember(Value = "Anchorage for a Limited Period of Time")] 
		AnchorageForALimitedPeriodOfTime = 10,
		[System.ComponentModel.Description("AnAreaInWhichVesselsAnchorOrMayAnchorWhileWaitingForExampleForAccessToAPortOrBerth")]
		[EnumMember(Value = "Waiting Anchorage")] 
		WaitingAnchorage = 14,
		[System.ComponentModel.Description("ALocationNotDefinedByARegulatoryAuthorityThatHasBeenReportedToBeSuitableAndSafeForAnchoring")]
		[EnumMember(Value = "Reported Anchorage")] 
		ReportedAnchorage = 15,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfBuiltUpArea : int {
		[System.ComponentModel.Description("AnAreaPredominantlyOccupiedByManMadeStructuresUsedForResidentialCommercialAndIndustrialPurposes")]
		[EnumMember(Value = "Urban Area")] 
		UrbanArea = 1,
		[System.ComponentModel.Description("AContinuouslyOccupiedConcentrationOfTentsOrLightweightFixedStructuresForExampleHutsServingAsResidences")]
		[EnumMember(Value = "Settlement")] 
		Settlement = 2,
		[System.ComponentModel.Description("ASelfContainedGroupOfHousesAndAssociatedBuildingsUsuallyInACountryArea")]
		[EnumMember(Value = "Village")] 
		Village = 3,
		[System.ComponentModel.Description("AnInhabitedPlaceLargerAndMoreRegularlyBuiltAndWithMoreCompleteAndIndependentLocalGovernmentThanAVillageButNotIncorporatedAsACity")]
		[EnumMember(Value = "Town")] 
		Town = 4,
		[System.ComponentModel.Description("AMajorTownInhabitedByALargePermanentCommunityWithAllEssentialServices")]
		[EnumMember(Value = "City")] 
		City = 5,
		[System.ComponentModel.Description("AComplexForHolidayMakersWithCottagesShopsAndEntertainmentOnSiteWhichIsMainlyPopulatedOnASeasonalBasis")]
		[EnumMember(Value = "Holiday Village")] 
		HolidayVillage = 6,
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
		[System.ComponentModel.Description("AChainOrVeryStrongFibreOrWireRopeUsedToAnchorOrMoorVesselsOrBuoys")]
		[EnumMember(Value = "Mooring Cable")] 
		MooringCable = 6,
		[System.ComponentModel.Description("AVesselForTransportingPassengersVehiclesAndOrGoodsAcrossAStretchOfWaterEspeciallyAsARegularService")]
		[EnumMember(Value = "Ferry")] 
		Ferry = 7,
		[System.ComponentModel.Description("ACableUsedForJoiningComponentsOfComplexMarineStructuresForExampleMooringTrots")]
		[EnumMember(Value = "Junction Cable")] 
		JunctionCable = 9,
		[System.ComponentModel.Description("ACableUsedForTheTransmissionAndReceptionOfModulatedCommunicationWavesSignals")]
		[EnumMember(Value = "Telecommunications Cable")] 
		TelecommunicationsCable = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCanal : int {
		[System.ComponentModel.Description("ACanalUsedForNavigationAsPartOfATransportSystem")]
		[EnumMember(Value = "Transportation")] 
		Transportation = 1,
		[System.ComponentModel.Description("ACanalUsedToDrainExcessWaterFromSurroundingLand")]
		[EnumMember(Value = "Drainage")] 
		Drainage = 2,
		[System.ComponentModel.Description("ACanalUsedToSupplyWaterForThePurposeOfIrrigation")]
		[EnumMember(Value = "Irrigation")] 
		Irrigation = 3,
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
	public enum categoryOfCheckpoint : int {
		[System.ComponentModel.Description("ServesAsAGovernmentCheckpointWhereCustomsDutiesAreCollectedTheFlowOfGoodsAreRegulatedAndRestrictionsEnforcedAndShipmentsOrVehiclesAreClearedForEnteringOrLeavingACountry")]
		[EnumMember(Value = "Custom")] 
		Custom = 1,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCoastline : int {
		[System.ComponentModel.Description("ACoastBackedByRockOrEarthCliffsGivesAGoodRadarReturnAndIsUsefulForVisualIdentificationFromAConsiderableDistanceOffWhereCliffsAlternateWithLowLyingCoastAlongTheShoreline")]
		[EnumMember(Value = "Steep Coast")] 
		SteepCoast = 1,
		[System.ComponentModel.Description("ALevelCoastWithNoObviousTopographicFeatures")]
		[EnumMember(Value = "Flat Coast")] 
		FlatCoast = 2,
		[System.ComponentModel.Description("ProjectingSeawardExtensionOfGlacierUsuallyAfloat")]
		[EnumMember(Value = "Glacier, Seaward End")] 
		GlacierSeawardEnd = 6,
		[System.ComponentModel.Description("OneOfSeveralGeneraOfTropicalTreesOrShrubsWhichProduceManyPropRootsAndGrowAlongLowLyingCoastsIntoShallowWater")]
		[EnumMember(Value = "Mangrove")] 
		Mangrove = 7,
		[System.ComponentModel.Description("AShorelineAreaMadeUpOfSpongyLandSaturatedWithWaterItMayHaveAShallowCoveringOfWaterUsuallyWithAConsiderableAmountOfVegetationAppearingAboveTheSurface")]
		[EnumMember(Value = "Marshy Shore")] 
		MarshyShore = 8,
		[System.ComponentModel.Description("AVerticalCliffFormingTheSeawardEdgeOfAnIceShelfRangingInHeightFrom2MetresTo50MetresOrMoreAboveSeaLevel")]
		[EnumMember(Value = "Ice Coast")] 
		IceCoast = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfConveyor : int {
		[System.ComponentModel.Description("ATransportationSystemConsistingOfLoadCablesStrungBetweenPylonsOnWhichCarrierUnitsForExampleCarsOrBucketsIntendedToTransportPeopleMaterialAndOrEquipmentAreSuspended")]
		[EnumMember(Value = "Aerial Cableway")] 
		AerialCableway = 1,
		[System.ComponentModel.Description("AConveyorAlongWhichMaterialOrPeopleAreTransportedByMeansOfAMovingBelt")]
		[EnumMember(Value = "Belt Conveyor")] 
		BeltConveyor = 2,
		[System.ComponentModel.Description("AnArtificialChannelUsuallyAnInclinedChuteOrTroughForCarryingWaterToFurnishPowerTransportLogsDownAMountainsideEtc")]
		[EnumMember(Value = "Flume")] 
		Flume = 3,
		[System.ComponentModel.Description("AnyOfVariousMechanicalDevicesForRaisingObjectsOrMaterials")]
		[EnumMember(Value = "Lift/Elevator")] 
		LiftElevator = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCrane : int {
		[System.ComponentModel.Description("AHighSpeedShoreBasedCraneUsedInTheLiftOnLiftOffOperationOfSpeciallyConstructedContainers")]
		[EnumMember(Value = "Container Crane/Gantry")] 
		ContainerCraneGantry = 2,
		[System.ComponentModel.Description("ATripodalStructureUsedInDockyardsAndHarboursForSteppingMastsOrLiftingLoadsInToAndOutOfVessels")]
		[EnumMember(Value = "Sheerlegs")] 
		Sheerlegs = 3,
		[System.ComponentModel.Description("ACraneMountedOnRailsTrackThatCanMoveUsuallyParallelToTheWharfFaceInOrderToLoadAndUnloadCargoVessels")]
		[EnumMember(Value = "Travelling Crane")] 
		TravellingCrane = 4,
		[System.ComponentModel.Description("ATypeOfCraneShapedLikeTheLetterA")]
		[EnumMember(Value = "A-Frame")] 
		AFrame = 5,
		[System.ComponentModel.Description("APowerfulTravellingCraneMountedOnAMovableGantryOfLargeSpan")]
		[EnumMember(Value = "Goliath Crane")] 
		GoliathCrane = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDam : int {
		[System.ComponentModel.Description("ADamErectedAcrossARiverToRaiseTheLevelOfTheWaterAFenceOfStakesSetInARiverOrAlongTheShoreAsATrapForFishTheWordIsNowRestrictedToSmallerWorksTheLargerAreCalledDams")]
		[EnumMember(Value = "Weir")] 
		Weir = 1,
		[System.ComponentModel.Description("ABarrierToCheckOrConfineAnythingInMotionParticularlyOneConstructedToHoldBackWaterAndRaiseItsLevelToFormAReservoirOrToPreventFlooding")]
		[EnumMember(Value = "Dam")] 
		Dam = 2,
		[System.ComponentModel.Description("AnOpeningDamAcrossAChannelWhichWhenRequiredIsClosedToControlFloodWaters")]
		[EnumMember(Value = "Flood Barrage")] 
		FloodBarrage = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDock : int {
		[System.ComponentModel.Description("ADockWhichIsOpenToTheSeaAndInWhichTheWaterLevelIsAffectedByTides")]
		[EnumMember(Value = "Tidal")] 
		Tidal = 1,
		[System.ComponentModel.Description("ADockInWhichWaterCanBeMaintainedAtAnyLevelByClosingAGateWhenTheWaterIsAtTheDesiredLevel")]
		[EnumMember(Value = "Wet Dock")] 
		WetDock = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDolphin : int {
		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedAsAMooringPointForVessels")]
		[EnumMember(Value = "Mooring Dolphin")] 
		MooringDolphin = 1,
		[System.ComponentModel.Description("APostOrGroupOfPostsWhichAVesselMaySwingAroundForCompassAdjustment")]
		[EnumMember(Value = "Deviation Dolphin")] 
		DeviationDolphin = 2,
		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedToExtendTheBerthOfAVesselByProvidingExtraMooringPoints")]
		[EnumMember(Value = "Berthing Dolphin")] 
		BerthingDolphin = 3,
		[System.ComponentModel.Description("APostOrGroupOfPostsDrivenIntoTheSeabedOrRiverbedUsedToAssistInBerthingOfVesselsByTakingUpSomeBerthingLoadsKeepVesselsFromPressingAgainstThePierStructureOrToProtectStructuresFromPossibleImpactByShips")]
		[EnumMember(Value = "Fender or Breasting Dolphin")] 
		FenderOrBreastingDolphin = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfDumpingGround : int {
		[System.ComponentModel.Description("AnAreaAtSeaWhereChemicalWasteIsDumped")]
		[EnumMember(Value = "Chemical Waste Dumping Ground")] 
		ChemicalWasteDumpingGround = 2,
		[System.ComponentModel.Description("AnAreaAtSeaWhereNuclearWasteIsDumped")]
		[EnumMember(Value = "Nuclear Waste Dumping Ground")] 
		NuclearWasteDumpingGround = 3,
		[System.ComponentModel.Description("AnAreaAtSeaWhereExplosivesAreDumped")]
		[EnumMember(Value = "Explosives Dumping Ground")] 
		ExplosivesDumpingGround = 4,
		[System.ComponentModel.Description("ASeaAreaWhereDredgedMaterialIsDeposited")]
		[EnumMember(Value = "Spoil Ground")] 
		SpoilGround = 5,
		[System.ComponentModel.Description("AnAreaAtSeaWhereDisusedVesselsAreScuttled")]
		[EnumMember(Value = "Vessel Dumping Ground")] 
		VesselDumpingGround = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFence : int {
		[System.ComponentModel.Description("AManMadeBarrierOfRelativelyLightStructureUsedAsAnEnclosureOrBoundary")]
		[EnumMember(Value = "Fence")] 
		Fence = 1,
		[System.ComponentModel.Description("AContinuousGrowthOfShrubberyPlantedAsAFenceABoundaryOrAWindBreak")]
		[EnumMember(Value = "Hedge")] 
		Hedge = 3,
		[System.ComponentModel.Description("ASolidManMadeBarrierOfGenerallyHeavyMaterialUsedAsAnEnclosureBoundaryOrForProtection")]
		[EnumMember(Value = "Wall")] 
		Wall = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFerry : int {
		[System.ComponentModel.Description("AFerryWhichMayHaveRoutesThatVaryWithWeatherTideAndTraffic")]
		[EnumMember(Value = "Free Moving Ferry")] 
		FreeMovingFerry = 1,
		[System.ComponentModel.Description("AFerryThatFollowsAFixedRouteGuidedByACable")]
		[EnumMember(Value = "Cable Ferry")] 
		CableFerry = 2,
		[System.ComponentModel.Description("AWinterTimeFerryWhichCrossesALead")]
		[EnumMember(Value = "Ice Ferry")] 
		IceFerry = 3,
		[System.ComponentModel.Description("AHighSpeedWaterVesselForCivilianUse")]
		[EnumMember(Value = "High Speed Ferry")] 
		HighSpeedFerry = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfFishingFacility : int {
		[System.ComponentModel.Description("PolesOrStakesPlacedInShallowWaterToOutlineAFishingGroundOrToCatchFish")]
		[EnumMember(Value = "Fishing Stake")] 
		FishingStake = 1,
		[System.ComponentModel.Description("AStructureUsuallyPortableForCatchingFish")]
		[EnumMember(Value = "Fish Trap")] 
		FishTrap = 2,
		[System.ComponentModel.Description("AFenceOfStakesOrStonesSetInARiverOrAlongTheShoreToTrapFish")]
		[EnumMember(Value = "Fish Weir")] 
		FishWeir = 3,
		[System.ComponentModel.Description("ANetBuiltAtSeaForCatchingTunny")]
		[EnumMember(Value = "Tunny Net")] 
		TunnyNet = 4,
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
		[System.ComponentModel.Description("AReedUsesCompressedAirAndEmitsAWeakHighPitchedSound")]
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
	public enum categoryOfFortifiedStructure : int {
		[System.ComponentModel.Description("ALargeFortifiedBuildingOrStructure")]
		[EnumMember(Value = "Castle")] 
		Castle = 1,
		[System.ComponentModel.Description("AFortifiedEnclosureBuildingOrPositionAbleToBeDefendedAgainstAnEnemy")]
		[EnumMember(Value = "Fort")] 
		Fort = 2,
		[System.ComponentModel.Description("AFortifiedStructureOnWhichArtilleryIsMounted")]
		[EnumMember(Value = "Battery")] 
		Battery = 3,
		[System.ComponentModel.Description("AConcreteStructureStrengthenedToGiveProtectionAgainstEnemyFireWithAperturesToAllowDefensiveGunfire")]
		[EnumMember(Value = "Blockhouse")] 
		Blockhouse = 4,
		[System.ComponentModel.Description("ASmallCircularFortWithVeryThickWallsForExampleMartelloTower")]
		[EnumMember(Value = "Fortified Tower")] 
		FortifiedTower = 5,
		[System.ComponentModel.Description("AnOutworkOrFieldworkUsuallySquareOrPolygonalAndWithoutFlankingDefences")]
		[EnumMember(Value = "Redoubt")] 
		Redoubt = 6,
		[System.ComponentModel.Description("AFortifiedPenToHoldSubmarines")]
		[EnumMember(Value = "Fortified Submarine Shelter")] 
		FortifiedSubmarineShelter = 8,
		[System.ComponentModel.Description("AnythingServingAsABulwarkOrDefence")]
		[EnumMember(Value = "Rampart")] 
		Rampart = 9,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfGate : int {
		[System.ComponentModel.Description("AnOpeningGateUsedToControlFloodWater")]
		[EnumMember(Value = "Flood Barrage Gate")] 
		FloodBarrageGate = 2,
		[System.ComponentModel.Description("ASteelStructureUsedForClosingTheEntranceOfLocksWetAndDryDocks")]
		[EnumMember(Value = "Caisson")] 
		Caisson = 3,
		[System.ComponentModel.Description("PairOfMassiveHingedDoorsAtEachEndOfALock")]
		[EnumMember(Value = "Lock Gate")] 
		LockGate = 4,
		[System.ComponentModel.Description("AnOpeningGateInADyke")]
		[EnumMember(Value = "Dyke Gate")] 
		DykeGate = 5,
		[System.ComponentModel.Description("ASlidingGateOrOtherContrivanceForChangingTheLevelOfABodyOfWaterByControllingTheFlowIntoOrOutOfIt")]
		[EnumMember(Value = "Sluice")] 
		Sluice = 6,
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
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfHulk : int {
		[System.ComponentModel.Description("APermanentlyMooredFloatingStructureForExampleAnOldShipThatIsUsedAsARestaurant")]
		[EnumMember(Value = "Floating Restaurant")] 
		FloatingRestaurant = 1,
		[System.ComponentModel.Description("AShipOfHistoricalInterestPermanentlyMooredAsATouristAttraction")]
		[EnumMember(Value = "Historic Ship")] 
		HistoricShip = 2,
		[System.ComponentModel.Description("APermanentlyMooredFloatingStructureForExampleAnOldShipThatIsUsedAsAMuseum")]
		[EnumMember(Value = "Floating Museum")] 
		FloatingMuseum = 3,
		[System.ComponentModel.Description("APermanentlyMooredFloatingStructureForExampleAnOldShipThatIsUsedForAccommodation")]
		[EnumMember(Value = "Floating Accommodation")] 
		FloatingAccommodation = 4,
		[System.ComponentModel.Description("APermanentlyMooredFloatingStructureOftenConstructedFromOldShipsUsedAsABreakwater")]
		[EnumMember(Value = "Floating Breakwater")] 
		FloatingBreakwater = 5,
		[System.ComponentModel.Description("APermanentlyMooredFloatingStructureSuchAsAnOldShipUsedAsACasinoBoat")]
		[EnumMember(Value = "Casino")] 
		Casino = 6,
		[System.ComponentModel.Description("APermanentlyMooredFloatingStructureOftenConstructedFromOldShipsUsedForTrainingPurposes")]
		[EnumMember(Value = "Training Vessel")] 
		TrainingVessel = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfIce : int {
		[System.ComponentModel.Description("SeaIceWhichRemainsFastGenerallyInThePositionWhereOriginallyFormedAndWhichMayAttainAConsiderableThicknessItIsFoundAlongCoastsWhereItIsAttachedToTheShoreOrOverShoalsWhereItMayBeHeldInPositionByIslandsGroundedIcebergsOrGroundedPolarIce")]
		[EnumMember(Value = "Fast Ice")] 
		FastIce = 1,
		[System.ComponentModel.Description("AMassOfSnowAndIceContinuouslyMovingFromHigherToLowerGroundOrIfAfloatContinuouslySpreading")]
		[EnumMember(Value = "Glacier")] 
		Glacier = 5,
		[System.ComponentModel.Description("SeaIceThatIsMoreThanOneYearOldInContrastToWinterIceTheWmoCodeDefinesPolarIceAsAnySeaIceMoreThanOneYearOldAndMoreThan3MetresThick")]
		[EnumMember(Value = "Polar Ice")] 
		PolarIce = 8,
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
		[System.ComponentModel.Description("ALargeMooringBuoyUsedByTankersToLoadAndUnloadInPortApproachesOrInOffshoreOilAndGasFields")]
		[EnumMember(Value = "Single Buoy Mooring")] 
		SingleBuoyMooring = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLandRegion : int {
		[System.ComponentModel.Description("ATypeOfBogEspeciallyALowLyingAreaWhollyOrPartlyCoveredWithWaterAndDominatedByGrassLikePlantsGrassesSedgesAndReeds")]
		[EnumMember(Value = "Fen")] 
		Fen = 1,
		[System.ComponentModel.Description("AnAreaOfWetOftenSpongyGroundThatIsSubjectToFrequentFloodingOrTidalInundationsButNotConsideredToBeContinuallyUnderWaterItIsCharacterizedByTheGrowthOfNonWoodyPlantsAndByTheLackOfTrees")]
		[EnumMember(Value = "Marsh")] 
		Marsh = 2,
		[System.ComponentModel.Description("WetSpongyGroundConsistingOfDecayingVegetationWhichRetainsStagnantWaterTooSoftToBearTheWeightOfAnyHeavyBody")]
		[EnumMember(Value = "Bog")] 
		Bog = 3,
		[System.ComponentModel.Description("ATractOfWastelandPeatBogUsuallyCoveredByALowScrubbyGrowthButMayHaveScatteredSmallOpenWaterHoles")]
		[EnumMember(Value = "Heathland")] 
		Heathland = 4,
		[System.ComponentModel.Description("ASeriesOfConnectedAndAlignedMountainsOrMountainRidges")]
		[EnumMember(Value = "Mountain Range")] 
		MountainRange = 5,
		[System.ComponentModel.Description("LowAndRelativelyLevelLandAtALowerElevationThanAdjoiningAreas")]
		[EnumMember(Value = "Lowlands")] 
		Lowlands = 6,
		[System.ComponentModel.Description("ARelativelyNarrowDeepDepressionWithSteepSidesTheBottomOfWhichGenerallyHasAContinuousSlope")]
		[EnumMember(Value = "Canyon Lands")] 
		CanyonLands = 7,
		[System.ComponentModel.Description("APieceOfLandSetAsideForCropsWhichArePeriodicallyFloodedForExampleRicePaddy")]
		[EnumMember(Value = "Paddy Field")] 
		PaddyField = 8,
		[System.ComponentModel.Description("OfOrPertainingToTheScienceOrPracticeOfCultivatingTheSoilAndRearingAnimals")]
		[EnumMember(Value = "Agricultural Land")] 
		AgriculturalLand = 9,
		[System.ComponentModel.Description("AnOpenGrassyPlainWithFewOrNoTreesInATropicalOrSubtropicalRegionATractCoveredMainlyByGrassesThatHaveLittleOrNoWoodyTissue")]
		[EnumMember(Value = "Savanna/Grassland")] 
		SavannaGrassland = 10,
		[System.ComponentModel.Description("APieceOfGroundKeptForOrnamentAndOrRecreationOrMaintainedInItsNaturalStateAsAPublicPropertyOrArea")]
		[EnumMember(Value = "Parkland")] 
		Parkland = 11,
		[System.ComponentModel.Description("AnAreaOfSpongyLandSaturatedWithWaterItMayHaveAShallowCoveringOfWaterUsuallyWithAConsiderableAmountOfVegetationAppearingAboveTheSurface")]
		[EnumMember(Value = "Swamp")] 
		Swamp = 12,
		[System.ComponentModel.Description("TheSlidingDownOfAMassOfLandOnAMountainOrCliffSideLandWhichHasSoFallen")]
		[EnumMember(Value = "Landslide")] 
		Landslide = 13,
		[System.ComponentModel.Description("TheSubstanceThatResultsFromTheCoolingOfMoltenRock")]
		[EnumMember(Value = "Lava Flow")] 
		LavaFlow = 14,
		[System.ComponentModel.Description("ShallowPoolsOfBrackishWaterUsedForTheNaturalEvaporationOfSeaWaterToObtainSalt")]
		[EnumMember(Value = "Salt Pan")] 
		SaltPan = 15,
		[System.ComponentModel.Description("AnyAccumulationOfLooseMaterialDepositedByAGlacier")]
		[EnumMember(Value = "Moraine")] 
		Moraine = 16,
		[System.ComponentModel.Description("BowlShapedCavityAtTheSummitOrOnTheSideOfAVolcano")]
		[EnumMember(Value = "Crater")] 
		Crater = 17,
		[System.ComponentModel.Description("ANaturalSubterraneanChamberOrSeriesOfChambersOpenToTheEarthSSurface")]
		[EnumMember(Value = "Cave")] 
		Cave = 18,
		[System.ComponentModel.Description("AnyHighTowerOrSpireShapedPillarOfRockAloneOrCrestingASummit")]
		[EnumMember(Value = "Rock Column or Pinnacle")] 
		RockColumnOrPinnacle = 19,
		[System.ComponentModel.Description("ASmallInsularFeatureUsuallyWithScantVegetationUsuallyOfSandOrCoralOftenAppliedToSmallerCoralShoals")]
		[EnumMember(Value = "Cay")] 
		Cay = 20,
		[System.ComponentModel.Description("AWatercourseThatIsPermanentlyDryOrDryExceptForTheRainySeason")]
		[EnumMember(Value = "Wadi")] 
		Wadi = 21,
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
		[System.ComponentModel.Description("AStructureErectedOverADepressionOrAnObstacleSuchAsABodyOfWaterRailroadEtcToProvideARoadwayForVehiclesOrPedestrians")]
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
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfLight : int {
		[System.ComponentModel.Description("ALightAssociatedWithOtherLightsSoAsToFormALeadingLineToBeFollowed")]
		[EnumMember(Value = "Leading Light")] 
		LeadingLight = 4,
		[System.ComponentModel.Description("AnAeroLightIsEstablishedForAeronauticalNavigationAndMayBeOfHigherPowerThanMarineLightsAndVisibleFromWellOffshore")]
		[EnumMember(Value = "Aero Light")] 
		AeroLight = 5,
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
	public enum categoryOfMarineFarmCulture : int {
		[System.ComponentModel.Description("HardShelledAnimalsForExampleCrabsOrLobsters")]
		[EnumMember(Value = "Crustaceans")] 
		Crustaceans = 1,
		[System.ComponentModel.Description("ATwoPartHingedExternalShellCoveringThatContainsASoftBodiedInvertebrate")]
		[EnumMember(Value = "Edible Bivalve Molluscs")] 
		EdibleBivalveMolluscs = 2,
		[System.ComponentModel.Description("VertebrateColdBloodedAnimalWithGillsLivingInWater")]
		[EnumMember(Value = "Fish")] 
		Fish = 3,
		[System.ComponentModel.Description("TheGeneralNameForMarinePlantsOfTheAlgaeClassWhichGrowInLongNarrowRibbons")]
		[EnumMember(Value = "Seaweed")] 
		Seaweed = 4,
		[System.ComponentModel.Description("AnAreaWherePearlsAreArtificiallyCultivated")]
		[EnumMember(Value = "Pearl Culture Farm")] 
		PearlCultureFarm = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfMilitaryPracticeArea : int {
		[System.ComponentModel.Description("AnAreaWithinWhichExercisesAreCarriedOutWithTorpedoes")]
		[EnumMember(Value = "Torpedo Exercise Area")] 
		TorpedoExerciseArea = 2,
		[System.ComponentModel.Description("AnAreaWithinWhichSubmarineExercisesAreCarriedOut")]
		[EnumMember(Value = "Submarine Exercise Area")] 
		SubmarineExerciseArea = 3,
		[System.ComponentModel.Description("AreasForBombingAndMissileExercises")]
		[EnumMember(Value = "Firing Danger Area")] 
		FiringDangerArea = 4,
		[System.ComponentModel.Description("AnAreaWithinWhichMineLayingExercisesAreCarriedOut")]
		[EnumMember(Value = "Mine-Laying Practice Area")] 
		MineLayingPracticeArea = 5,
		[System.ComponentModel.Description("AnAreaForShootingPistolsRiflesAndMachineGunsEtcAtATarget")]
		[EnumMember(Value = "Small Arms Firing Range")] 
		SmallArmsFiringRange = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfMooringArea : int {
		[System.ComponentModel.Description("AnAreaInWhichYachtsAndSmallBoatsMoor")]
		[EnumMember(Value = "Small Craft Mooring Area")] 
		SmallCraftMooringArea = 1,
		[System.ComponentModel.Description("AnAreaSetAsideForTheMooringOfVisitingVessels")]
		[EnumMember(Value = "Mooring Area for Visitors")] 
		MooringAreaForVisitors = 2,
		[System.ComponentModel.Description("AnAreaSetAsideForTheMooringOfTankers")]
		[EnumMember(Value = "Mooring Area for Tankers")] 
		MooringAreaForTankers = 3,
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
	public enum categoryOfObstruction : int {
		[System.ComponentModel.Description("ATreeBranchOrBrokenPileEmbeddedInTheOceanFloorRiverOrLakeBottomAndNotVisibleOnTheSurfaceFormingTherebyAHazardToVessels")]
		[EnumMember(Value = "Snag/Stump")] 
		SnagStump = 1,
		[System.ComponentModel.Description("ASubmarineStructureProjectingSomeDistanceAboveTheSeabedAndCappingATemporarilyAbandonedOrSuspendedOilOrGasWell")]
		[EnumMember(Value = "Wellhead")] 
		Wellhead = 2,
		[System.ComponentModel.Description("AStructureOnAnOutfallThroughWhichLiquidsAreDischargedTheStructureWillUsuallyProjectAboveTheLevelOfTheOutfallAndCanBeAnObstructionToNavigation")]
		[EnumMember(Value = "Diffuser")] 
		Diffuser = 3,
		[System.ComponentModel.Description("APermanentMarineStructureUsuallyDesignedToSupportOrElevatePipelinesEspeciallyAStructureEnclosingAScreeningDeviceAtTheOffshoreEndOfAPotableWaterIntakePipeTheStructureIsCommonlyAHeavyTimberEnclosureThatHasBeenSunkenWithRocksOrOtherDebris")]
		[EnumMember(Value = "Crib")] 
		Crib = 4,
		[System.ComponentModel.Description("AreasEstablishedByPrivateInterestsUsuallySportFishermenToSimulateNaturalReefsAndWrecksThatAttractFishTheReefsAreConstructedByDumpingAssortedJunkInAreasWhichMayBeOfVerySmallExtentOrMayStretchAConsiderableDistanceAlongADepthContour")]
		[EnumMember(Value = "Fish Haven")] 
		FishHaven = 5,
		[System.ComponentModel.Description("AnAreaOfNumerousUnidentifiedDangersToNavigationTheAreaServesAsAWarningToTheMarinerThatAllDangersAreNotIdentifiedIndividuallyAndThatNavigationThroughTheAreaMayBeHazardous")]
		[EnumMember(Value = "Foul Area")] 
		FoulArea = 6,
		[System.ComponentModel.Description("FloatingBarriersAnchoredToTheBottomUsedToDeflectThePathOfFloatingIceInOrderToPreventTheObstructionOfLocksIntakesEtcAndToPreventDamageToBridgePiersAndOtherStructures")]
		[EnumMember(Value = "Ice Boom")] 
		IceBoom = 8,
		[System.ComponentModel.Description("EquipmentSuchAsAnchorsConcreteBlocksChainsAndCablesEtcUsedToPositionFloatingStructuresSuchAsTrotAndMooringBuoysEtc")]
		[EnumMember(Value = "Ground Tackle")] 
		GroundTackle = 9,
		[System.ComponentModel.Description("AFloatingBarrierUsedToProtectARiverOrHarbourMouthOrToCreateAShelteredAreaForStoragePurposes")]
		[EnumMember(Value = "Boom")] 
		Boom = 10,
		[System.ComponentModel.Description("ADeviceToExtractEnergyFromTheSurfaceMotionOfOceanWavesOrFromPressureFluctuationsBelowTheSurface")]
		[EnumMember(Value = "Wave Energy Device")] 
		WaveEnergyDevice = 12,
		[System.ComponentModel.Description("ASubmergedDeviceNotBeingAShipTogetherWithItsAppurtenantEquipmentDeployedAtSeaEssentiallyForThePurposeOfCollectingStoringOrTransmittingSamplesOrDataRelatingToTheMarineEnvironment")]
		[EnumMember(Value = "Subsurface Ocean Data Acquisition System")] 
		SubsurfaceOceanDataAcquisitionSystem = 13,
		[System.ComponentModel.Description("AManMadeStructureThatMayMimicSomeOfTheCharacteristicsOfANaturalReefIntendedToAttractSeaLife")]
		[EnumMember(Value = "Artificial Reef")] 
		ArtificialReef = 14,
		[System.ComponentModel.Description("AStructurePlacedOnTheSeafloorBelowADrillingRigToGuideTheDrill")]
		[EnumMember(Value = "Template")] 
		Template = 15,
		[System.ComponentModel.Description("ALargeSteelStructureUpTo20MetresInHeightAboveTheSeafloorOrASteelFrameSecuredToTheSeafloorWithPilesToAnchorTheEndOfASubmarinePipelineForDeliveryToAProductionPlatform")]
		[EnumMember(Value = "Manifold")] 
		Manifold = 16,
		[System.ComponentModel.Description("AHillOfSoilCoveredIcePushedUpByHydrostaticPressureInAnAreaOfPermafrostThatIsLocatedUnderwater")]
		[EnumMember(Value = "Submerged Pingo")] 
		SubmergedPingo = 17,
		[System.ComponentModel.Description("TheDistributedRemainsOfAPlatform")]
		[EnumMember(Value = "Remains of Platform")] 
		RemainsOfPlatform = 18,
		[System.ComponentModel.Description("AnInstrumentUsedForScientificPurposes")]
		[EnumMember(Value = "Scientific Instrument")] 
		ScientificInstrument = 19,
		[System.ComponentModel.Description("AnyOfVariousMachinesHavingARotorUsuallyWithVanesOrBladesDrivenByThePressureMomentumOrReactiveThrustOfAMovingFluidAsSteamWaterHotGasesOrAirEitherOccurringInTheFormOfFreeJetsOrAsAFluidPassingThroughAndEntirelyFillingAHousingAroundTheRotorAndIsLocatedUnderwater")]
		[EnumMember(Value = "Underwater Turbine")] 
		UnderwaterTurbine = 20,
		[System.ComponentModel.Description("AnActiveSeabedVolcanoWhichMayBeSubmergedOrProjectingAboveTheWaterAtTheChartSoundingDatum")]
		[EnumMember(Value = "Active Submarine Volcano")] 
		ActiveSubmarineVolcano = 21,
		[System.ComponentModel.Description("ASubmergedNetPlacedAroundBeachesToReduceSharkAttacksOnSwimmers")]
		[EnumMember(Value = "Shark Net")] 
		SharkNet = 22,
		[System.ComponentModel.Description("OneOfSeveralGeneraOfTropicalTreesOrShrubsWhichProduceManyPropRootsAndGrowAlongLowLyingCoastsIntoShallowWater")]
		[EnumMember(Value = "Mangrove")] 
		Mangrove = 23,
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
		[System.ComponentModel.Description("AMetalLatticeTowerBuoyantAtOneEndAndAttachedAtTheOtherByAUniversalJointToAConcreteFilledBaseOnTheSeabedThePlatformMayBeFittedWithAHelicopterPlatformEmergencyAccommodationAndHawserHoseRetrieval")]
		[EnumMember(Value = "Articulated Loading Platform")] 
		ArticulatedLoadingPlatform = 4,
		[System.ComponentModel.Description("ARigidFrameOrTubeWithABuoyancyDeviceAtItsUpperEndSecuredAtItsLowerEndToAUniversalJointOnALargeSteelOrConcreteBaseRestingOnTheSeabedAndAtItsUpperEndToAMooringBuoyByAChainOrWire")]
		[EnumMember(Value = "Single Anchor Leg Mooring")] 
		SingleAnchorLegMooring = 5,
		[System.ComponentModel.Description("APlatformSecuredToTheSeabedAndSurmountedByATurntableToWhichShipsMoor")]
		[EnumMember(Value = "Mooring Tower")] 
		MooringTower = 6,
		[System.ComponentModel.Description("AManMadeStructureUsuallyBuiltForTheExplorationOrExploitationOfMarineResourcesMarineScientificResearchTidalObservationsEtc")]
		[EnumMember(Value = "Artificial Island")] 
		ArtificialIsland = 7,
		[System.ComponentModel.Description("AnOffshoreFacilityConsistingOfAMooredTankerBargeByWhichTheProductIsExtractedStoredAndExported")]
		[EnumMember(Value = "Floating Production, Storage and Off-Loading Vessel")] 
		FloatingProductionStorageAndOffLoadingVessel = 8,
		[System.ComponentModel.Description("APlatformUsedPrimarilyForEatingSleepingAndRecreationPurposes")]
		[EnumMember(Value = "Accommodation Platform")] 
		AccommodationPlatform = 9,
		[System.ComponentModel.Description("AFloatingStructureWithControlRoomPowerAndStorageFacilitiesAttachedToTheSeabedByAFlexiblePipelineAndCables")]
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
	public enum categoryOfOffshoreProductionArea : int {
		[System.ComponentModel.Description("ACollectionOfWindTurbinesThatAreCollocatedAndAreOrganizedAsASinglePowerGenerationUnit")]
		[EnumMember(Value = "Wind Farm")] 
		WindFarm = 1,
		[System.ComponentModel.Description("ACollectionOfCollocatedDevicesWhichHarnessWaveEnergyAndAreOrganizedAsASinglePowerGenerationUnit")]
		[EnumMember(Value = "Wave Farm")] 
		WaveFarm = 2,
		[System.ComponentModel.Description("ACollectionOfCollocatedDevicesWhichHarnessCurrentForExampleTidalEnergyAndAreOrganizedAsASinglePowerGenerationUnit")]
		[EnumMember(Value = "Current Farm")] 
		CurrentFarm = 3,
		[System.ComponentModel.Description("ACollectionOfCollocatedLargeCapacityTanksInWhichPetroleumNaturalGasOrLiquidPetrochemicalsAreStored")]
		[EnumMember(Value = "Tank Farm")] 
		TankFarm = 4,
		[System.ComponentModel.Description("AnAreaInWhichMaterialsFormingOrUnderTheSeabedAreRemoved")]
		[EnumMember(Value = "Seabed Material Extraction Area")] 
		SeabedMaterialExtractionArea = 5,
		[System.ComponentModel.Description("ALargeScalePhotovoltaicSystemPvSystemDesignedForTheSupplyOfMerchantPowerIntoTheElectricityGridTheyAreDifferentiatedFromMostBuildingMountedAndOtherDecentralisedSolarPowerApplicationsBecauseTheySupplyPowerAtTheUtilityLevelRatherThanToALocalUserOrUsersTheGenericExpressionUtilityScaleSolarIsSometimesUsedToDescribeThisTypeOfProject")]
		[EnumMember(Value = "Solar Farm")] 
		SolarFarm = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfOilBarrier : int {
		[System.ComponentModel.Description("APipeWithHolesFromWhichAirBlowsWhenTheAirBubblesReachTheSurfaceTheyFormABarrierWhichPreventsTheSpreadOfOil")]
		[EnumMember(Value = "Oil Retention (High Pressure Pipe)")] 
		OilRetentionHighPressurePipe = 1,
		[System.ComponentModel.Description("AFloatingTubeShapedStructureWithACurtain2MetreHangingUnderItBelowTheSurfaceWhichPreventsTheSpreadOfOil")]
		[EnumMember(Value = "Floating Oil Barrier")] 
		FloatingOilBarrier = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfOpeningBridge : int {
		[System.ComponentModel.Description("AMovableBridgeOrSpanThereofWhichRotatesInAHorizontalPlaneAboutAVerticalPivotToAllowThePassageOfVessels")]
		[EnumMember(Value = "Swing Bridge")] 
		SwingBridge = 3,
		[System.ComponentModel.Description("AMovableBridgeOrSpanThereofWhichIsCapableOfBeingLiftedVerticallyToAllowVesselsToPassBeneath")]
		[EnumMember(Value = "Lifting Bridge")] 
		LiftingBridge = 4,
		[System.ComponentModel.Description("ACounterpoiseBridgeRotatedInAVerticalPlaneAboutAnAxisAtOneOrBothEnds")]
		[EnumMember(Value = "Bascule Bridge")] 
		BasculeBridge = 5,
		[System.ComponentModel.Description("AGeneralNameForBridgesOfWhichPartOrTheEntireSpanOfTheBridgeMayBeRaisedOrDrawnAsideToAllowShipsToPassThrough")]
		[EnumMember(Value = "Drawbridge")] 
		Drawbridge = 7,
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
		[System.ComponentModel.Description("AVerticalPieceOfTimberMetalOrConcreteForcedIntoTheEarthOrSeabed")]
		[EnumMember(Value = "Post")] 
		Post = 3,
		[System.ComponentModel.Description("ASingleStructureComprising3OrMorePilesHeldTogetherSectionsOfHeavyTimberSteelOrConcreteAndForcedIntoTheEarthOrSeabed")]
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
		[System.ComponentModel.Description("APostWhereToWhichSomethingSuchAsACraftCanBeMoored")]
		[EnumMember(Value = "Mooring Post")] 
		MooringPost = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPilotBoardingPlace : int {
		[System.ComponentModel.Description("PilotBoardsFromACruisingVessel")]
		[EnumMember(Value = "Boarding by Pilot-Cruising Vessel")] 
		BoardingByPilotCruisingVessel = 1,
		[System.ComponentModel.Description("PilotBoardsByHelicopterWhichComesOutFromTheShore")]
		[EnumMember(Value = "Boarding by Helicopter")] 
		BoardingByHelicopter = 2,
		[System.ComponentModel.Description("PilotEmbarksFromAVesselOrDisembarksToAVesselWhichComesOutFromTheShoreOnRequest")]
		[EnumMember(Value = "Pilot Comes Out from Shore")] 
		PilotComesOutFromShore = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPipelinePipe : int {
		[System.ComponentModel.Description("APipeGenerallyASewerOrDrainagePipeDischargingIntoTheSeaOrARiver")]
		[EnumMember(Value = "Outfall Pipe")] 
		OutfallPipe = 2,
		[System.ComponentModel.Description("APipeTakingWaterFromARiverOrOtherBodyOfWaterToDriveAMillOrSupplyACanalWaterworksEtc")]
		[EnumMember(Value = "Intake Pipe")] 
		IntakePipe = 3,
		[System.ComponentModel.Description("APipeInASewageSystemForCarryingWaterOrSewageToADisposalArea")]
		[EnumMember(Value = "Sewer")] 
		Sewer = 4,
		[System.ComponentModel.Description("ASubmergedPipeFromWhichWarmWaterBubblesPreventingTheSurroundingWaterFromFreezing")]
		[EnumMember(Value = "Bubbler System")] 
		BubblerSystem = 5,
		[System.ComponentModel.Description("APipeUsedForTransportSupplyOfGasOrLiquidProduct")]
		[EnumMember(Value = "Supply Pipe")] 
		SupplyPipe = 6,
		[System.ComponentModel.Description("AHighPressureSubSurfacePipelineUsuallyOnTheSeafloorWithHolesEmittingACurtainOfAirBubblesItsUsesIncludeThePreventionOfAcousticTransmissionThroughTheWaterPreventingTheSpreadOfSurfaceDebrisOrFloatingLiquidsControllingTheMovementOfFish")]
		[EnumMember(Value = "Bubble Curtain")] 
		BubbleCurtain = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPreference : int {
		[System.ComponentModel.Description("ThePreferredFirstChoiceUsedInNormalConditions")]
		[EnumMember(Value = "Primary")] 
		Primary = 1,
		[System.ComponentModel.Description("ThePreferredChoiceInExtraordinaryConditions")]
		[EnumMember(Value = "Alternate")] 
		Alternate = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfProductionArea : int {
		[System.ComponentModel.Description("AnOpenAirExcavationForTheExtractionOfStoneIntendedPrincipallyForUseInConstruction")]
		[EnumMember(Value = "Quarry")] 
		Quarry = 1,
		[System.ComponentModel.Description("AnExcavationMadeInTheTerrainForThePurposeOfExtractingAndOrExploitingNaturalResources")]
		[EnumMember(Value = "Mine")] 
		Mine = 2,
		[System.ComponentModel.Description("AReserveStockOfMaterialEquipmentOrOtherSupplies")]
		[EnumMember(Value = "Stockpile")] 
		Stockpile = 3,
		[System.ComponentModel.Description("AFacilityIncludingOneOrMoreBuildingsAndEquipmentUsedForPowerGeneration")]
		[EnumMember(Value = "Power Station Area")] 
		PowerStationArea = 4,
		[System.ComponentModel.Description("AFacilityWherePetroleumAndOrPetroleumProductsAreRefined")]
		[EnumMember(Value = "Refinery Area")] 
		RefineryArea = 5,
		[System.ComponentModel.Description("AnOpenTractForTheStorageOfWoodenLumberAndTimbers")]
		[EnumMember(Value = "Timber Yard")] 
		TimberYard = 6,
		[System.ComponentModel.Description("AGroupOfBuildingsWhereGoodsAreManufactured")]
		[EnumMember(Value = "Factory Area")] 
		FactoryArea = 7,
		[System.ComponentModel.Description("ACollectionOfCollocatedLargeCapacityTanksInWhichPetroleumNaturalGasOrLiquidPetrochemicalsAreStored")]
		[EnumMember(Value = "Tank Farm")] 
		TankFarm = 8,
		[System.ComponentModel.Description("ACollectionOfWindTurbinesThatAreCollocatedAndAreOrganizedAsASinglePowerGenerationUnit")]
		[EnumMember(Value = "Wind Farm")] 
		WindFarm = 9,
		[System.ComponentModel.Description("HillOfRefuseFromAMineIndustrialPlantEtcOnLand")]
		[EnumMember(Value = "Slag Heap/Spoil Heap")] 
		SlagHeapSpoilHeap = 10,
		[System.ComponentModel.Description("APlantWhereProductionTakesPlace")]
		[EnumMember(Value = "Production Plant")] 
		ProductionPlant = 11,
		[System.ComponentModel.Description("ALargeScalePhotovoltaicSystemPvSystemDesignedForTheSupplyOfMerchantPowerIntoTheElectricityGridTheyAreDifferentiatedFromMostBuildingMountedAndOtherDecentralisedSolarPowerApplicationsBecauseTheySupplyPowerAtTheUtilityLevelRatherThanToALocalUserOrUsersTheGenericExpressionUtilityScaleSolarIsSometimesUsedToDescribeThisTypeOfProject")]
		[EnumMember(Value = "Solar Farm")] 
		SolarFarm = 12,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfPylon : int {
		[System.ComponentModel.Description("APylonOrPoleThatSupportsOneOrMorePowerLines")]
		[EnumMember(Value = "Power Transmission Pylon/Pole")] 
		PowerTransmissionPylonPole = 1,
		[System.ComponentModel.Description("APylonOrPoleThatSupportsOneOrMoreCommunicationLines")]
		[EnumMember(Value = "Telephone/Telegraph Pylon/Pole")] 
		TelephoneTelegraphPylonPole = 2,
		[System.ComponentModel.Description("ATowerOrPylonSupportingSteelCablesWhichConveyCarsBucketsOrOtherSuspendedCarrierUnits")]
		[EnumMember(Value = "Aerial Cableway Pylon")] 
		AerialCablewayPylon = 3,
		[System.ComponentModel.Description("ATowerAndOrPylonFromWhichTheDeckOfABridgeIsSuspended")]
		[EnumMember(Value = "Bridge Pylon/Tower")] 
		BridgePylonTower = 4,
		[System.ComponentModel.Description("APillarOrAbutmentThatSupportsABridgeSpan")]
		[EnumMember(Value = "Bridge Pier")] 
		BridgePier = 5,
		[System.ComponentModel.Description("ATowerOrPylonSupportingASuspendedPipelineOrPipelines")]
		[EnumMember(Value = "Pipeline Pylon")] 
		PipelinePylon = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRadarStation : int {
		[System.ComponentModel.Description("ARadarStationEstablishedForTrafficSurveillance")]
		[EnumMember(Value = "Radar Surveillance Station")] 
		RadarSurveillanceStation = 1,
		[System.ComponentModel.Description("AShoreBasedStationWhichTheMarinerCanContactByRadioToObtainAPosition")]
		[EnumMember(Value = "Coast Radar Station")] 
		CoastRadarStation = 2,
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
	public enum categoryOfRadioStation : int {
		[System.ComponentModel.Description("ARadioStationIntendedToDetermineOnlyTheDirectionOfOtherStationsByMeansOfTransmissionFromTheLatter")]
		[EnumMember(Value = "Radio Direction-Finding Station")] 
		RadioDirectionFindingStation = 5,
		[System.ComponentModel.Description("DifferentialGnssIsImplementedByPlacingAGnssMonitorReceiverAtAPreciselyKnownLocationInsteadOfComputingANavigationFixTheMonitorDeterminesTheRangeErrorToEveryGnssSatelliteItCanTrackTheseRangingErrorsAreThenTransmittedToLocalUsersWhereTheyAreAppliedAsCorrectionsBeforeComputingTheNavigationResult")]
		[EnumMember(Value = "Differential GNSS")] 
		DifferentialGnss = 10,
		[System.ComponentModel.Description("AnElectronicPositionFixingSystemUsedMainlyByAircraft")]
		[EnumMember(Value = "Toran")] 
		Toran = 11,
		[System.ComponentModel.Description("ALowFrequencyElectronicPositionFixingSystemUsingPulsedTransmissionsAt100Khz")]
		[EnumMember(Value = "Chaika")] 
		Chaika = 14,
		[System.ComponentModel.Description("TheEquipmentNeededAtOneStationToCarryOnTwoWayVoiceCommunicationByRadioWavesOnly")]
		[EnumMember(Value = "Radio Telephone Station")] 
		RadioTelephoneStation = 19,
		[System.ComponentModel.Description("AnAisShoreStationForUseByCompetentAuthoritiesToProvideAisServiceManageTheDataLinkAndEnableEffectiveShipToShoreShoreToShipTransmissionOfInformation")]
		[EnumMember(Value = "AIS Base Station")] 
		AisBaseStation = 20,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRescueStation : int {
		[System.ComponentModel.Description("APlaceWhereEquipmentForSavingLifeAtSeaIsMaintainedTheTypeOfLifeboatMayVaryFromFastLongDistanceBoatsToInflatableInshoreBoats")]
		[EnumMember(Value = "Rescue Station with Lifeboat")] 
		RescueStationWithLifeboat = 1,
		[System.ComponentModel.Description("ALifeSavingStationEquippedWithLineCarryingRocketApparatus")]
		[EnumMember(Value = "Rescue Station with Rocket")] 
		RescueStationWithRocket = 2,
		[System.ComponentModel.Description("ShelterOrProtectionFromDangerOrDistressAtSea")]
		[EnumMember(Value = "Refuge for Shipwrecked Mariners")] 
		RefugeForShipwreckedMariners = 4,
		[System.ComponentModel.Description("ShelterOrProtectionFromDangerInAreasExposedToExtremeAndSuddenTidesOrTidalStreams")]
		[EnumMember(Value = "Refuge for Intertidal Area Walkers")] 
		RefugeForIntertidalAreaWalkers = 5,
		[System.ComponentModel.Description("APlaceWhereALifeboatIsMooredReadyForUse")]
		[EnumMember(Value = "Lifeboat Lying at a Mooring")] 
		LifeboatLyingAtAMooring = 6,
		[System.ComponentModel.Description("ARadioStationReservedForEmergencySituationsMightAlsoBeAPublicTelephone")]
		[EnumMember(Value = "Aid Radio Station")] 
		AidRadioStation = 7,
		[System.ComponentModel.Description("APlaceWhereFirstAidEquipmentIsAvailable")]
		[EnumMember(Value = "First Aid Equipment")] 
		FirstAidEquipment = 8,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRestrictedArea : int {
		[System.ComponentModel.Description("TheAreaAroundAnOffshoreInstallationWithinWhichVesselsAreProhibitedFromEnteringWithoutPermissionSpecialRegulationsProtectInstallationsWithinASafetyZoneAndVesselsOfAllNationalitiesAreRequiredToRespectTheZone")]
		[EnumMember(Value = "Offshore Safety Zone")] 
		OffshoreSafetyZone = 1,
		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveItsFloraFaunaPhysicalFeaturesEtc")]
		[EnumMember(Value = "Nature Reserve")] 
		NatureReserve = 4,
		[System.ComponentModel.Description("APlaceWhereBirdsAreBredAndProtected")]
		[EnumMember(Value = "Bird Sanctuary")] 
		BirdSanctuary = 5,
		[System.ComponentModel.Description("APlaceWhereWildAnimalsOrBirdsHuntedForSportOrFoodAreKeptUndisturbedForPrivateUse")]
		[EnumMember(Value = "Game Reserve")] 
		GameReserve = 6,
		[System.ComponentModel.Description("APlaceWhereSealsAreProtected")]
		[EnumMember(Value = "Seal Sanctuary")] 
		SealSanctuary = 7,
		[System.ComponentModel.Description("AnAreaUsuallyAboutTwoCablesDiameterWithinWhichShipsMagneticFieldsMayBeMeasuredSensingInstrumentsAndCablesAreInstalledOnTheSeabedInTheRangeAndThereAreCablesLeadingFromTheRangeToAControlPositionAshore")]
		[EnumMember(Value = "Degaussing Range")] 
		DegaussingRange = 8,
		[System.ComponentModel.Description("AnAreaControlledByTheMilitaryInWhichRestrictionsMayApply")]
		[EnumMember(Value = "Military Area")] 
		MilitaryArea = 9,
		[System.ComponentModel.Description("AnAreaAroundCertainWrecksOfHistoricalImportanceToProtectTheWrecksFromUnauthorizedInterferenceByDivingSalvageOrDepositionIncludingAnchoring")]
		[EnumMember(Value = "Historic Wreck Area")] 
		HistoricWreckArea = 10,
		[System.ComponentModel.Description("AnAreaAroundANavigationalAidWhichVesselsAreProhibitedFromEntering")]
		[EnumMember(Value = "Navigational Aid Safety Zone")] 
		NavigationalAidSafetyZone = 12,
		[System.ComponentModel.Description("AnAreaLaidAndMaintainedWithExplosiveMinesForDefenceOrPracticePurposes")]
		[EnumMember(Value = "Minefield")] 
		Minefield = 14,
		[System.ComponentModel.Description("AnAreaInWhichPeopleMaySwimAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Swimming Area")] 
		SwimmingArea = 18,
		[System.ComponentModel.Description("AnAreaReservedForVesselsWaitingToEnterAHarbour")]
		[EnumMember(Value = "Waiting Area")] 
		WaitingArea = 19,
		[System.ComponentModel.Description("AnAreaWhereMarineResearchTakesPlace")]
		[EnumMember(Value = "Research Area")] 
		ResearchArea = 20,
		[System.ComponentModel.Description("AnAreaWhereDredgingIsTakingPlace")]
		[EnumMember(Value = "Dredging Area")] 
		DredgingArea = 21,
		[System.ComponentModel.Description("APlaceWhereFishIncludingShellfishAndCrustaceansAreProtected")]
		[EnumMember(Value = "Fish Sanctuary")] 
		FishSanctuary = 22,
		[System.ComponentModel.Description("ATractOfLandOrWaterManagedSoAsToPreserveTheRelationOfPlantsAndLivingCreaturesToEachOtherAndToTheirSurroundings")]
		[EnumMember(Value = "Ecological Reserve")] 
		EcologicalReserve = 23,
		[System.ComponentModel.Description("AnAreaInWhichAVesselsSpeedMustBeReducedInOrderToReduceTheSizeOfTheWakeItProduces")]
		[EnumMember(Value = "No Wake Area")] 
		NoWakeArea = 24,
		[System.ComponentModel.Description("AnAreaWhereVesselsTurn")]
		[EnumMember(Value = "Swinging Area")] 
		SwingingArea = 25,
		[System.ComponentModel.Description("AGenericTermWhichMayBeUsedToDescribeAWideRangeOfAreasConsideredSensitiveForAVarietyOfEnvironmentalReasons")]
		[EnumMember(Value = "Environmentally Sensitive Sea Area")] 
		EnvironmentallySensitiveSeaArea = 27,
		[System.ComponentModel.Description("AnAreaThatNeedsSpecialProtectionThroughActionByImoBecauseOfItsSignificanceForRegionalEcologicalSocioEconomicOrScientificReasonsAndBecauseItMayBeVulnerableToDamageByInternationalShippingActivities")]
		[EnumMember(Value = "Particularly Sensitive Sea Area")] 
		ParticularlySensitiveSeaArea = 28,
		[System.ComponentModel.Description("AnAreaNearAFairwayWhereVesselsCanGoToClearTheWayOrMakeAnAboutTurnAndPossiblyReturnToAWaitingAreaWhenNauticalConditionsImposeIt")]
		[EnumMember(Value = "Disengagement Area")] 
		DisengagementArea = 29,
		[System.ComponentModel.Description("AnAreaInWhichDefenceLawAndTreatyEnforcementAndCounterTerrorismActivitiesThatFallWithinThePortAndMaritimeDomainApply")]
		[EnumMember(Value = "Port Security Area")] 
		PortSecurityArea = 30,
		[System.ComponentModel.Description("APlaceWhereCoralIsProtected")]
		[EnumMember(Value = "Coral Sanctuary")] 
		CoralSanctuary = 31,
		[System.ComponentModel.Description("AnAreaWithinWhichRecreationalActivitiesRegularlyTakePlaceAndThereforeVesselMovementMayBeRestricted")]
		[EnumMember(Value = "Recreation Area")] 
		RecreationArea = 32,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfRoad : int {
		[System.ComponentModel.Description("ALimitedAccessDualCarriagewayRoadSpeciallyDesignedForFastLongDistanceTrafficAndSubjectToSpecialRegulationsConcerningItsUseItMayHaveMoreThanTwoLanes")]
		[EnumMember(Value = "Motorway")] 
		Motorway = 1,
		[System.ComponentModel.Description("AHardSurfacedMetalledRoadAMainThroughRoute")]
		[EnumMember(Value = "Major Road")] 
		MajorRoad = 2,
		[System.ComponentModel.Description("ASecondaryRoadForLocalTraffic")]
		[EnumMember(Value = "Minor Road")] 
		MinorRoad = 3,
		[System.ComponentModel.Description("TrackARoughPathOrWayFormedByUsePathAWayOrTrackLaidDownForWalkingOrMadeByContinualTreading")]
		[EnumMember(Value = "Track/Path")] 
		TrackPath = 4,
		[System.ComponentModel.Description("AMainRoadInAnUrbanAreaForThroughTraffic")]
		[EnumMember(Value = "Major Street")] 
		MajorStreet = 5,
		[System.ComponentModel.Description("ASecondaryRoadInAnUrbanAreaForLocalTraffic")]
		[EnumMember(Value = "Minor Street")] 
		MinorStreet = 6,
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
	public enum categoryOfSeaArea : int {
		[System.ComponentModel.Description("ANaturalOrArtificialPassageOrChannelThroughShoalsOrSteepBanksOrAcrossALineOfBanksLyingBetweenTwoChannels")]
		[EnumMember(Value = "Gat")] 
		Gat = 2,
		[System.ComponentModel.Description("AnElevationOfTheSeafloorAtDepthsGenerallyLessThan200MButSufficientForSafeSurfaceNavigationCommonlyFoundOnTheContinentalShelfOrNearAnIsland")]
		[EnumMember(Value = "Bank")] 
		Bank = 3,
		[System.ComponentModel.Description("InOceanographyAnObsoleteTermWhichWasGenerallyRestrictedToDepthsGreaterThan6000M")]
		[EnumMember(Value = "Deep")] 
		Deep = 4,
		[System.ComponentModel.Description("AWideIndentationInTheCoastlineGenerallySmallerThanAGulfAndLargerThanACoveForThePurposesOfTheUnitedNationsConventionOnTheLawOfTheSeaABayIsAWellMarkedIndentationWhosePenetrationIsInSuchProportionToTheWidthOfItsMouthAsToContainLandLockedWatersAndConstituteMoreThanAMereCurvatureOfTheCoast")]
		[EnumMember(Value = "Bay")] 
		Bay = 5,
		[System.ComponentModel.Description("ALongDeepAsymmetricalDepressionWithRelativelySteepSidesThatIsAssociatedWithSubduction")]
		[EnumMember(Value = "Trench")] 
		Trench = 6,
		[System.ComponentModel.Description("ADepressionOfTheSeafloorMoreOrLessEquidimensionalInPlanAndOfVariableExtent")]
		[EnumMember(Value = "Basin")] 
		Basin = 7,
		[System.ComponentModel.Description("ALevelTractOfLandAsTheBedOfADryLakeOrAnAreaFrequentlyUncoveredAtLowTideUsuallyInPlural")]
		[EnumMember(Value = "Mud Flats")] 
		MudFlats = 8,
		[System.ComponentModel.Description("AShallowElevationComposedOfConsolidatedMaterialThatMayConstituteAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Reef")] 
		Reef = 9,
		[System.ComponentModel.Description("ARockyFormationContinuousWithAndFringingTheShore")]
		[EnumMember(Value = "Ledge")] 
		Ledge = 10,
		[System.ComponentModel.Description("AnElongatedNarrowSteepSidedDepressionThatGenerallyDeepensDownSlope")]
		[EnumMember(Value = "Canyon")] 
		Canyon = 11,
		[System.ComponentModel.Description("ANavigableNarrowPartOfABayStraitRiverEtc")]
		[EnumMember(Value = "Narrows")] 
		Narrows = 12,
		[System.ComponentModel.Description("AShallowElevationComposedOfUnconsolidatedMaterialThatMayConstituteAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Shoal")] 
		Shoal = 13,
		[System.ComponentModel.Description("ADistinctElevationWithARoundedProfileLessThan1000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Knoll")] 
		Knoll = 14,
		[System.ComponentModel.Description("AnElongatedElevationOfVaryingComplexityAndSizeGenerallyHavingSteepSides")]
		[EnumMember(Value = "Ridge")] 
		Ridge = 15,
		[System.ComponentModel.Description("ADistinctGenerallyEquidimensionalElevationGreaterThan1000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Seamount")] 
		Seamount = 16,
		[System.ComponentModel.Description("AnyHighTowerOrSpireShapedPillarOrRockOrCoralAloneOrCrestingASummitItMayExtendAboveTheSurfaceOfTheWaterItMayOrMayNotBeAHazardToSurfaceNavigation")]
		[EnumMember(Value = "Pinnacle")] 
		Pinnacle = 17,
		[System.ComponentModel.Description("AnExtensiveFlatGentlySlopingOrNearlyLevelRegionAtAbyssalDepths")]
		[EnumMember(Value = "Abyssal Plain")] 
		AbyssalPlain = 18,
		[System.ComponentModel.Description("ALargeRelativelyFlatElevationThatIsHigherThanTheSurroundingReliefWithOneOrMoreRelativelySteepSides")]
		[EnumMember(Value = "Plateau")] 
		Plateau = 19,
		[System.ComponentModel.Description("ASubordinateRidgeProtrudingFromALargerFeature")]
		[EnumMember(Value = "Spur")] 
		Spur = 20,
		[System.ComponentModel.Description("TheFlatOrGentlySlopingRegionAdjacentToAContinentOrAroundAnIslandThatExtendsFromTheLowWaterLineToADepthGenerallyAbout200mWhereThereIsAMarkedIncreaseInDownwardSlope")]
		[EnumMember(Value = "Shelf")] 
		Shelf = 21,
		[System.ComponentModel.Description("ALongDepressionGenerallyWideAndFlatBottomedWithSymmetricalAndParallelSides")]
		[EnumMember(Value = "Trough")] 
		Trough = 22,
		[System.ComponentModel.Description("ABroadPassOrColInARidgeRiseOrOtherElevation")]
		[EnumMember(Value = "Saddle")] 
		Saddle = 23,
		[System.ComponentModel.Description("AnIsolatedSmallElevationOnTheDeepSeafloor")]
		[EnumMember(Value = "Abyssal Hill")] 
		AbyssalHill = 24,
		[System.ComponentModel.Description("AGentlyDippingSlopeWithASmoothSurfaceCommonlyFoundAroundGroupsOfIslandsAndSeamounts")]
		[EnumMember(Value = "Apron")] 
		Apron = 25,
		[System.ComponentModel.Description("AGentleSlopeWithAGenerallySmoothSurfaceOfTheSeafloorCharacteristicallyFoundAroundGroupsOfIslandsOrSeamounts")]
		[EnumMember(Value = "Archipelagic Apron")] 
		ArchipelagicApron = 26,
		[System.ComponentModel.Description("ARegionAdjacentToAContinentNormallyOccupiedByOrBorderingAShelfAndSometimesEmergingAsIslandsThatIsIrregularOrBlockyInPlanOrProfileWithDepthsWellInExcessOfThoseTypicalOfAShelf")]
		[EnumMember(Value = "Borderland")] 
		Borderland = 27,
		[System.ComponentModel.Description("TheZoneGenerallyConsistingOfShelfSlopeAndContinentalRiseSeparatingTheContinentFromTheDeepSeafloorOrAbyssalPlainOrPlainOccasionallyATrenchMayBePresentInPlaceOfAContinentalRise")]
		[EnumMember(Value = "Continental Margin")] 
		ContinentalMargin = 28,
		[System.ComponentModel.Description("AGentleSlopeRisingFromTheOceanicDepthsTowardsTheFootOfAContinentalSlope")]
		[EnumMember(Value = "Continental Rise")] 
		ContinentalRise = 29,
		[System.ComponentModel.Description("AnElongatedCharacteristicallyLinearSteepSlopeSeparatingHorizontalOrGentlySlopingAreasOfTheSeafloor")]
		[EnumMember(Value = "Escarpment")] 
		Escarpment = 30,
		[System.ComponentModel.Description("ARelativelySmoothDepositionalFeatureContinuouslyDeepeningAwayFromASedimentSourceCommonlyLocatedAtTheLowerTerminationOfACanyonOrCanyonSystem")]
		[EnumMember(Value = "Fan")] 
		Fan = 31,
		[System.ComponentModel.Description("ALongNarrowZoneOfIrregularTopographyFormedByTheMovementOfTectonicPlatesAssociatedWithAnOffsetOfASpreadingRidgeAxisCharacterizedBySteepSidedAndOrAsymmetricalRidgesTroughsOrEscarpments")]
		[EnumMember(Value = "Fracture Zone")] 
		FractureZone = 32,
		[System.ComponentModel.Description("ANarrowBreakInARidgeRiseOrOtherElevation")]
		[EnumMember(Value = "Gap")] 
		Gap = 33,
		[System.ComponentModel.Description("ASeamountHavingAComparativelySmoothFlatTop")]
		[EnumMember(Value = "Guyot")] 
		Guyot = 34,
		[System.ComponentModel.Description("ADistinctElevationGenerallyOfIrregularShapeLessThan1000mAboveTheSurroundingReliefAsMeasuredFromTheDeepestIsobathThatSurroundsMostOfTheFeature")]
		[EnumMember(Value = "Hill")] 
		Hill = 35,
		[System.ComponentModel.Description("ADepressionOfLimitedExtentWithAllSidesRisingSteeplyFromARelativelyFlatBottom")]
		[EnumMember(Value = "Hole")] 
		Hole = 36,
		[System.ComponentModel.Description("ADepositionalEmbankmentBorderingACanyonValleyOrSeaChannel")]
		[EnumMember(Value = "Levee")] 
		Levee = 37,
		[System.ComponentModel.Description("TheAxialDepressionOfTheMidOceanicRidgeSystem")]
		[EnumMember(Value = "Median Valley")] 
		MedianValley = 38,
		[System.ComponentModel.Description("AnAnnularOrPartiallyAnnularDepressionCommonlyLocatedAtTheBaseOfSeamountsIslandsAndOtherIsolatedElevations")]
		[EnumMember(Value = "Moat")] 
		Moat = 39,
		[System.ComponentModel.Description("ANaturalElevationOfTheEarthSSurfaceRisingMoreOrLessAbruptlyFromTheSurroundingLevelAndAttainingAnAltitudeWhichRelativelyToAdjacentElevationsIsImpressiveOrNotable")]
		[EnumMember(Value = "Mountains")] 
		Mountains = 40,
		[System.ComponentModel.Description("AConicalOrPointedElevationOnALargerFeatureSuchAsASeamount")]
		[EnumMember(Value = "Peak")] 
		Peak = 41,
		[System.ComponentModel.Description("AGeographicallyDistinctRegionWithANumberOfSharedPhysiographicCharacteristicsThatContrastWithThoseInTheSurroundingAreasThisTermShouldBeModifiedWithTheGenericTermThatBestDescribesTheMajorityOfFeaturesInTheRegionForExampleSeamountInBajaCaliforniaSeamountProvince")]
		[EnumMember(Value = "Province")] 
		Province = 42,
		[System.ComponentModel.Description("ABroadElevationThatGenerallyRisesGentlyAndSmoothlyFromTheSurroundingRelief")]
		[EnumMember(Value = "Rise")] 
		Rise = 43,
		[System.ComponentModel.Description("AnElongatedMeanderingDepressionUsuallyOccurringOnAGentlySlopingPlainOrFan")]
		[EnumMember(Value = "Sea Channel")] 
		SeaChannel = 44,
		[System.ComponentModel.Description("SeveralSeamountsInLinearOrArcuateAlignment")]
		[EnumMember(Value = "Seamount Chain")] 
		SeamountChain = 45,
		[System.ComponentModel.Description("TheLineAlongWhichThereIsAMarkedIncreaseInSlopeAtTheSeawardMarginOfAShelf")]
		[EnumMember(Value = "Shelf-Edge")] 
		ShelfEdge = 46,
		[System.ComponentModel.Description("ARelativelyShallowBarrierBetweenBasinsThatMayInhibitWaterMovement")]
		[EnumMember(Value = "Sill")] 
		Sill = 47,
		[System.ComponentModel.Description("TheSlopingRegionThatDeepensFromAShelfToThePointWhereThereIsAGeneralDecreaseInGradient")]
		[EnumMember(Value = "Slope")] 
		Slope = 48,
		[System.ComponentModel.Description("AFlatOrGentlySlopingRegionGenerallyLongAndNarrowBoundedAlongOneEdgeByASteeperDescendingSlopeAndAlongTheOtherByASteeperAscendingSlope")]
		[EnumMember(Value = "Terrace")] 
		Terrace = 49,
		[System.ComponentModel.Description("AnElongatedDepressionThatGenerallyWidensAndDeepensDownSlope")]
		[EnumMember(Value = "Valley")] 
		Valley = 50,
		[System.ComponentModel.Description("AnArtificialWaterwayWithNoFlowOrAControlledFlowUsedForNavigationOrForDrainingOrIrrigatingLandDitch")]
		[EnumMember(Value = "Canal")] 
		Canal = 51,
		[System.ComponentModel.Description("ALargeBodyOfWaterEntirelySurroundedByLand")]
		[EnumMember(Value = "Lake")] 
		Lake = 52,
		[System.ComponentModel.Description("ARelativelyLargeNaturalStreamOfWater")]
		[EnumMember(Value = "River")] 
		River = 53,
		[System.ComponentModel.Description("AStraightSectionOfARiverEspeciallyANavigableRiverBetweenTwoBendsOrAnArmOfTheSeaExtendingIntoTheLand")]
		[EnumMember(Value = "Reach")] 
		Reach = 54,
		[System.ComponentModel.Description("ALowFlatIslandOfSandCoralEtcAwashOrSubmergedAtHighWater")]
		[EnumMember(Value = "Intertidal Cay")] 
		IntertidalCay = 55,
		[System.ComponentModel.Description("ASeabedVolcanoSubmergedAtTheChartSoundingDatumWhichMayOrMayNotBeActive")]
		[EnumMember(Value = "Submarine Volcano")] 
		SubmarineVolcano = 56,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfShorelineConstruction : int {
		[System.ComponentModel.Description("AStructureProtectingAShoreAreaHarbourAnchorageOrBasinFromWaves")]
		[EnumMember(Value = "Breakwater")] 
		Breakwater = 1,
		[System.ComponentModel.Description("ALowArtificialWallLikeStructureOfDurableMaterialExtendingFromTheLandToSeawardForAParticularPurposeSuchAsToProtectTheCoastOrToForceACurrentToScourAChannel")]
		[EnumMember(Value = "Groyne")] 
		Groyne = 2,
		[System.ComponentModel.Description("AFormOfBreakwaterAlongsideWhichVesselsMayLieOnTheShelteredSideOnlyInSomeCasesItMayLieEntirelyWithinAnArtificialHarbourPermittingVesselsToLieAlongBothSides")]
		[EnumMember(Value = "Mole")] 
		Mole = 3,
		[System.ComponentModel.Description("ALongNarrowStructureExtendingIntoTheWaterToAffordABerthingPlaceForVesselsToServeAsAPromenadeEtc")]
		[EnumMember(Value = "Pier (Jetty)")] 
		PierJetty = 4,
		[System.ComponentModel.Description("APierBuiltOnlyForRecreationalPurposes")]
		[EnumMember(Value = "Promenade Pier")] 
		PromenadePier = 5,
		[System.ComponentModel.Description("AStructureServingAsABerthingPlaceForVessels")]
		[EnumMember(Value = "Wharf")] 
		Wharf = 6,
		[System.ComponentModel.Description("AWallOrBankOftenSubmergedBuiltToDirectOrConfineTheFlowOfARiverOrTidalCurrentOrToPromoteAScourAction")]
		[EnumMember(Value = "Training Wall")] 
		TrainingWall = 7,
		[System.ComponentModel.Description("ALayerOfBrokenRockCobblesBouldersOrFragmentsOfSufficientSizeToResistTheErosiveForcesOfFlowingWaterAndWaveAction")]
		[EnumMember(Value = "Rip Rap")] 
		RipRap = 8,
		[System.ComponentModel.Description("FacingOfStoneOrOtherMaterialEitherPermanentOrTemporaryPlacedAlongTheEdgeOfAStreamRiverOrCanalToStabilizeTheBankAndToProtectItFromTheErosiveActionOfTheStream")]
		[EnumMember(Value = "Revetment")] 
		Revetment = 9,
		[System.ComponentModel.Description("AnEmbankmentOrWallForProtectionAgainstWavesOrTidalActionAlongAShoreOrWaterFront")]
		[EnumMember(Value = "Sea Wall")] 
		SeaWall = 10,
		[System.ComponentModel.Description("StepsAtTheShorelineAsTheConnectionBetweenLandAndWaterOnDifferentLevels")]
		[EnumMember(Value = "Landing Steps")] 
		LandingSteps = 11,
		[System.ComponentModel.Description("ASlopingStructureWhichMayIncludeRailsThatCanEitherBeUsedAsALandingPlaceAtVariableWaterLevelsForSmallVesselsLandingShipsOrAFerryBoatOrForHaulingACradleCarryingAVessel")]
		[EnumMember(Value = "Ramp")] 
		Ramp = 12,
		[System.ComponentModel.Description("ThePreparedAndUsuallyReinforcedInclinedSurfaceOnWhichKeelAndBilgeBlocksAreLaidForSupportingAVesselUnderConstruction")]
		[EnumMember(Value = "Slipway")] 
		Slipway = 13,
		[System.ComponentModel.Description("AProtectiveStructureDesignedToCushionTheImpactOfAVesselAndPreventDamage")]
		[EnumMember(Value = "Fender")] 
		Fender = 14,
		[System.ComponentModel.Description("AWharfConsistingOfASolidWallOfConcreteMasonryWoodEtcSuchThatTheWaterCannotCirculateFreelyUnderTheWharfTheTypeOfConstructionAffectsShipHandlingForExampleASolidFaceWharfMayGiveShelterFromTidalStreamsButUnderCertainCircumstancesACushionOfWaterMayBuildUpBetweenSuchAWharfAndAShipAttemptingToBerthAtItCausingDifficultiesInShipHandling")]
		[EnumMember(Value = "Solid Face Wharf")] 
		SolidFaceWharf = 15,
		[System.ComponentModel.Description("AWharfSupportedOnPilesOrOtherStructuresWhichAllowFreeCirculationOfWaterUnderTheWharf")]
		[EnumMember(Value = "Open Face Wharf")] 
		OpenFaceWharf = 16,
		[System.ComponentModel.Description("AnInclinedPlaneUsedToDumpLogsIntoTheWaterForTransportOrToHaulLogsOutOfTheWaterForProcessing")]
		[EnumMember(Value = "Log Ramp")] 
		LogRamp = 17,
		[System.ComponentModel.Description("AnArtificialPoolOrSwimmingEnclosureEspeciallyOneInTheOpenAirWhichMayBeConstructedOfWireMeshOrHeavyNettingSupportedByCablesBuoysOrPilesForSwimmingIn")]
		[EnumMember(Value = "Swimming Facility")] 
		SwimmingFacility = 20,
		[System.ComponentModel.Description("AWharfApproximatelyParallelToTheShorelineAndAccommodatingShipsOnOneSideOnlyTheOtherSideBeingAttachedToTheShoreItIsUsuallyOfSolidConstructionAsContrastedWithTheOpenPileConstructionUsuallyUsedForPiers")]
		[EnumMember(Value = "Quay")] 
		Quay = 22,
		[System.ComponentModel.Description("ASectionOfWallDesignatedForTyingUpVesselsAwaitingTransitBollardsAndMooringDevicesAreAvailableForBothLargeAndSmallShips")]
		[EnumMember(Value = "Tie-Up Wall")] 
		TieUpWall = 23,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSignalStationTraffic : int {
		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsWithinAPort")]
		[EnumMember(Value = "Port Control")] 
		PortControl = 1,
		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsEnteringOrLeavingAPort")]
		[EnumMember(Value = "Port Entry and Departure")] 
		PortEntryAndDeparture = 2,
		[System.ComponentModel.Description("ASignalStationDisplayingInternationalPortTrafficSignals")]
		[EnumMember(Value = "International Port Traffic")] 
		InternationalPortTraffic = 3,
		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsWhenBerthing")]
		[EnumMember(Value = "Berthing Signal Station")] 
		BerthingSignalStation = 4,
		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsEnteringOrLeavingADock")]
		[EnumMember(Value = "Dock")] 
		Dock = 5,
		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsEnteringOrLeavingALock")]
		[EnumMember(Value = "Lock")] 
		Lock = 6,
		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsWishingToPassThroughAFloodControlBarrage")]
		[EnumMember(Value = "Flood Barrage Station")] 
		FloodBarrageStation = 7,
		[System.ComponentModel.Description("ASignalStationForTheControlOfVesselsWishingToPassUnderABridge")]
		[EnumMember(Value = "Bridge Passage")] 
		BridgePassage = 8,
		[System.ComponentModel.Description("ASignalStationIndicatingWhenDredgingIsInProgress")]
		[EnumMember(Value = "Dredging")] 
		Dredging = 9,
		[System.ComponentModel.Description("VisualSignalLightsPlacedInAWaterwayToIndicateToShippingTheMovementsAuthorizedAtTheTimeAtWhichTheyAreShown")]
		[EnumMember(Value = "Traffic Control Light")] 
		TrafficControlLight = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSignalStationWarning : int {
		[System.ComponentModel.Description("ASignalOrMessageWarningOfThePresenceOfADangerToNavigation")]
		[EnumMember(Value = "Danger")] 
		Danger = 1,
		[System.ComponentModel.Description("ASignalOrMessageWarningOfThePresenceOfAMaritimeObstruction")]
		[EnumMember(Value = "Maritime Obstruction")] 
		MaritimeObstruction = 2,
		[System.ComponentModel.Description("ASignalOrMessageWarningOfThePresenceOfACable")]
		[EnumMember(Value = "Cable")] 
		Cable = 3,
		[System.ComponentModel.Description("ASignalOrMessageWarningOfActivityInAMilitaryPracticeArea")]
		[EnumMember(Value = "Military Practice")] 
		MilitaryPractice = 4,
		[System.ComponentModel.Description("AStationThatMayReceiveOrTransmitDistressSignals")]
		[EnumMember(Value = "Distress")] 
		Distress = 5,
		[System.ComponentModel.Description("AVisualSignalDisplayedToIndicateAWeatherForecast")]
		[EnumMember(Value = "Weather")] 
		Weather = 6,
		[System.ComponentModel.Description("ASignalOrMessageConveyingInformationAboutStormConditions")]
		[EnumMember(Value = "Storm")] 
		Storm = 7,
		[System.ComponentModel.Description("ASignalOrMessageConveyingInformationAboutIceConditions")]
		[EnumMember(Value = "Ice Warning")] 
		IceWarning = 8,
		[System.ComponentModel.Description("AnAccurateSignalMarkingASpecifiedTimeOrTimeIntervalItIsUsedPrimarilyForDeterminingErrorsOfTimepiecesSuchSignalsAreUsuallySentFromAnObservatoryByRadioButVisualSignalsAreUsedAtSomePorts")]
		[EnumMember(Value = "Time")] 
		Time = 9,
		[System.ComponentModel.Description("ASignalOrMessageConveyingInformationOnTidalConditionsInTheAreaInQuestion")]
		[EnumMember(Value = "Tide")] 
		Tide = 10,
		[System.ComponentModel.Description("ASignalOrMessageConveyingInformationOnConditionOfTidalCurrentsInTheAreaInQuestion")]
		[EnumMember(Value = "Tidal Stream")] 
		TidalStream = 11,
		[System.ComponentModel.Description("ADeviceForMeasuringTheHeightOfTideAGraduatedStaffInAShelteredAreaWhereVisualObservationsCanBeMadeOrItMayConsistOfAnElaborateRecordingInstrumentMakingAContinuousGraphicRecordOfTideHeightAgainstTimeSuchAnInstrumentIsUsuallyActuatedByAFloatInAPipeCommunicatingWithTheSeaThroughASmallHoleWhichFiltersOutShorterWaves")]
		[EnumMember(Value = "Tide Gauge")] 
		TideGauge = 12,
		[System.ComponentModel.Description("AVisualScaleWhichDirectlyShowsTheHeightOfTheWaterAboveChartDatumOrALocalDatum")]
		[EnumMember(Value = "Tide Scale")] 
		TideScale = 13,
		[System.ComponentModel.Description("ASignalOrMessageWarningOfDivingActivity")]
		[EnumMember(Value = "Diving")] 
		Diving = 14,
		[System.ComponentModel.Description("ADeviceForMeasuringAndConveyingInformationAboutTheWaterLevelNonTidalInTheAreaInQuestion")]
		[EnumMember(Value = "Water Level Gauge")] 
		WaterLevelGauge = 15,
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
	public enum categoryOfSlope : int {
		[System.ComponentModel.Description("AnExcavationThroughHighGroundForARoadCanalEtc")]
		[EnumMember(Value = "Cutting")] 
		Cutting = 1,
		[System.ComponentModel.Description("AManMadeRaisedLongMoundOfEarthOrOtherMaterial")]
		[EnumMember(Value = "Embankment")] 
		Embankment = 2,
		[System.ComponentModel.Description("AMoundRidgeOrHillOfDriftedMaterialOnTheSeaCoastOrInADesert")]
		[EnumMember(Value = "Dune")] 
		Dune = 3,
		[System.ComponentModel.Description("ASmallIsolatedElevationSmallerThanAMountain")]
		[EnumMember(Value = "Hill")] 
		Hill = 4,
		[System.ComponentModel.Description("ADomeShapedHillFormedInAPermafrostAreaWhenTheHydrostaticPressureOfFreezingGroundWaterCausesTheUpheavalOfALayerOfFrozenGround")]
		[EnumMember(Value = "Pingo")] 
		Pingo = 5,
		[System.ComponentModel.Description("LandRisingAbruptlyForAConsiderableDistanceAboveTheWaterOrSurroundingLand")]
		[EnumMember(Value = "Cliff")] 
		Cliff = 6,
		[System.ComponentModel.Description("AMassOfDetritusFormingAPrecipitousStrongSlopeUponAMountainSideAlsoTheMaterialComposingSuchASlope")]
		[EnumMember(Value = "Scree")] 
		Scree = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfSmallCraftFacility : int {
		[System.ComponentModel.Description("ABerthSetAsideForTheUseOfVisitingVessels")]
		[EnumMember(Value = "Visitors Berth")] 
		VisitorsBerth = 1,
		[System.ComponentModel.Description("AClubForMarinersGenerallyAssociatedWithOtherSmallCraftFacilities")]
		[EnumMember(Value = "Nautical Club")] 
		NauticalClub = 2,
		[System.ComponentModel.Description("AHoistForLiftingBoatsOutOfTheWater")]
		[EnumMember(Value = "Boat Hoist")] 
		BoatHoist = 3,
		[System.ComponentModel.Description("APlaceWhereSailsAreMadeOrMayBeTakenForRepair")]
		[EnumMember(Value = "Sailmaker")] 
		Sailmaker = 4,
		[System.ComponentModel.Description("APlaceOnShoreWhereBoatsMayBeBuiltStoredAndRepaired")]
		[EnumMember(Value = "Boatyard")] 
		Boatyard = 5,
		[System.ComponentModel.Description("APublicHouseProvidingFoodDrinkAndAccommodation")]
		[EnumMember(Value = "Public Inn")] 
		PublicInn = 6,
		[System.ComponentModel.Description("ACommercialEstablishmentServingFood")]
		[EnumMember(Value = "Restaurant")] 
		Restaurant = 7,
		[System.ComponentModel.Description("ADealerInShipsSupplies")]
		[EnumMember(Value = "Chandler")] 
		Chandler = 8,
		[System.ComponentModel.Description("APlaceWhereFoodAndOtherSuchSuppliesAreAvailable")]
		[EnumMember(Value = "Provisions")] 
		Provisions = 9,
		[System.ComponentModel.Description("APlaceWhereADoctorIsAvailableToProvideMedicalAttention")]
		[EnumMember(Value = "Doctor")] 
		Doctor = 10,
		[System.ComponentModel.Description("APlaceWhereMedicalDrugsAreDispensed")]
		[EnumMember(Value = "Pharmacy")] 
		Pharmacy = 11,
		[System.ComponentModel.Description("APlaceWhereFreshWaterIsAvailable")]
		[EnumMember(Value = "Water Tap")] 
		WaterTap = 12,
		[System.ComponentModel.Description("APlaceWhereFuelIsAvailable")]
		[EnumMember(Value = "Fuel Station")] 
		FuelStation = 13,
		[System.ComponentModel.Description("APlaceWhereAConnectionToAnElectricalSupplyIsAvailable")]
		[EnumMember(Value = "Electricity Outlet")] 
		ElectricityOutlet = 14,
		[System.ComponentModel.Description("APlaceWhereBottledGasIsAvailable")]
		[EnumMember(Value = "Bottle Gas")] 
		BottleGas = 15,
		[System.ComponentModel.Description("APlaceWhereShowersAreAvailable")]
		[EnumMember(Value = "Showers")] 
		Showers = 16,
		[System.ComponentModel.Description("APlaceWhereThereAreFacilitiesForWashingClothes")]
		[EnumMember(Value = "Launderette")] 
		Launderette = 17,
		[System.ComponentModel.Description("APlaceWhereToiletsAreAvailableForPublicUse")]
		[EnumMember(Value = "Public Toilets")] 
		PublicToilets = 18,
		[System.ComponentModel.Description("APlaceWhereMailMayBePosted")]
		[EnumMember(Value = "Post Box")] 
		PostBox = 19,
		[System.ComponentModel.Description("APlaceWhereATelephoneIsAvailableForPublicUse")]
		[EnumMember(Value = "Public Telephone")] 
		PublicTelephone = 20,
		[System.ComponentModel.Description("APlaceWhereRefuseMayBeDumped")]
		[EnumMember(Value = "Refuse Bin")] 
		RefuseBin = 21,
		[System.ComponentModel.Description("APlaceWhereCarsMayBeParked")]
		[EnumMember(Value = "Car Park")] 
		CarPark = 22,
		[System.ComponentModel.Description("APlaceOnShoreWhereBoatsAndOrTrailersMayBeParked")]
		[EnumMember(Value = "Parking for Boats and Trailers")] 
		ParkingForBoatsAndTrailers = 23,
		[System.ComponentModel.Description("APlaceWhereCaravansMayBeParkedOrWhereCaravanAccommodationIsProvided")]
		[EnumMember(Value = "Caravan Site")] 
		CaravanSite = 24,
		[System.ComponentModel.Description("APlaceWhereVisitorsMayPitchTentsAndCamp")]
		[EnumMember(Value = "Camping Site")] 
		CampingSite = 25,
		[System.ComponentModel.Description("APlaceWhereSewageMayBePumpedOffAVessel")]
		[EnumMember(Value = "Sewage Pump-Out Station")] 
		SewagePumpOutStation = 26,
		[System.ComponentModel.Description("APlaceWhereATelephoneIsAvailableForEmergencyUseOnly")]
		[EnumMember(Value = "Emergency Telephone")] 
		EmergencyTelephone = 27,
		[System.ComponentModel.Description("APlaceWhereBoatsMayBeLandedOrLaunched")]
		[EnumMember(Value = "Landing/Launching Place for Boats")] 
		LandingLaunchingPlaceForBoats = 28,
		[System.ComponentModel.Description("APlaceWhereVesselsMayBerthForThePurposeOfCareening")]
		[EnumMember(Value = "Scrubbing Berth")] 
		ScrubbingBerth = 30,
		[System.ComponentModel.Description("APlaceWherePeopleMayGoToEatAPicnic")]
		[EnumMember(Value = "Picnic Area")] 
		PicnicArea = 31,
		[System.ComponentModel.Description("APlaceWhereMechanicalRepairsCanBeUndertakenToEnginesOrOtherVesselEquipment")]
		[EnumMember(Value = "Mechanics Workshop")] 
		MechanicsWorkshop = 32,
		[System.ComponentModel.Description("APlaceWhereAVesselIsPatrolledByASecurityServiceOrStoredInASecureLockup")]
		[EnumMember(Value = "Guard and/or Security Service")] 
		GuardAndOrSecurityService = 33,
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
		[System.ComponentModel.Description("AMarkIndicatingAnAreaWhereSeaplanesLand")]
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
		[System.ComponentModel.Description("AFishAggregatingOrAggregationDeviceFadIsAManMadeObjectUsedToAttractOceanGoingPelagicFishSuchAsMarlinTunaAndMahiMahiDolphinFishTheyUsuallyConsistOfBuoysOrFloatsTetheredToTheOceanFloorWithConcreteBlocksOrAdrift")]
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
	public enum categoryOfStructure : int {
		[System.ComponentModel.Description("ABuildingOrShedUsuallyBuiltPartlyOverWaterForShelteringABoatOrBoats")]
		[EnumMember(Value = "Boathouse")] 
		Boathouse = 1,
		[System.ComponentModel.Description("ACoveredOrPartiallyCoveredTerminalForTheHandlingOfBulkMaterialsSuchAsIronOreCoalEtc")]
		[EnumMember(Value = "Covered Bulk Terminal")] 
		CoveredBulkTerminal = 2,
		[System.ComponentModel.Description("ACoveredOrPartiallyCoveredStructureServingAsABerthingPlaceForVessels")]
		[EnumMember(Value = "Covered Wharf")] 
		CoveredWharf = 3,
		[System.ComponentModel.Description("ACoveredOrPartiallyCoveredTerminalWithinWhichTheFloatingEquipmentDredgesTugsOfHarbourServicesAreBerthedAndServiced")]
		[EnumMember(Value = "Covered Service Terminal")] 
		CoveredServiceTerminal = 4,
		[System.ComponentModel.Description("ACoveredOrPartiallyCoveredTerminalForTheLoadingAndUnloadingOfPassengers")]
		[EnumMember(Value = "Covered Passenger Terminal")] 
		CoveredPassengerTerminal = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfTidalStream : int {
		[System.ComponentModel.Description("TheHorizontalMovementOfWaterAssociatedWithTheRisingTideFloodStreamsGenerallySetTowardsTheShoreOrInTheDirectionOfTheTideProgression")]
		[EnumMember(Value = "Flood Stream")] 
		FloodStream = 1,
		[System.ComponentModel.Description("TheHorizontalMovementOfWaterAssociatedWithFallingTideEbbStreamsGenerallySetSeawardOrInTheOppositeDirectionToTheTideProgression")]
		[EnumMember(Value = "Ebb Stream")] 
		EbbStream = 2,
		[System.ComponentModel.Description("AnyOtherHorizontalMovementOfWaterAssociatedWithTidesForExampleRotaryFlow")]
		[EnumMember(Value = "Other Tidal Flow")] 
		OtherTidalFlow = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfVegetation : int {
		[System.ComponentModel.Description("AShrubOrClumpOfShrubsWithStemsOfModerateLength")]
		[EnumMember(Value = "Bush")] 
		Bush = 3,
		[System.ComponentModel.Description("AWoodWithTreesThatShedTheirLeavesAnnually")]
		[EnumMember(Value = "Deciduous Wood")] 
		DeciduousWood = 4,
		[System.ComponentModel.Description("AWoodWithEvergreenTreesOfAGroupUsuallyBearingConesIncludingYewsCedarsAndRedwoods")]
		[EnumMember(Value = "Coniferous Wood")] 
		ConiferousWood = 5,
		[System.ComponentModel.Description("GrowingTreesDenselyOccupyingATractOfLand")]
		[EnumMember(Value = "Wood in General (inc Mixed Wood)")] 
		WoodInGeneralIncMixedWood = 6,
		[System.ComponentModel.Description("AnyOfVariousWaterOrMarshPlantsWithAFirmStemConciseOxfordEnglishDictionary")]
		[EnumMember(Value = "Reed")] 
		Reed = 11,
		[System.ComponentModel.Description("AnIndividualWoodyPerennialPlantTypicallyHavingASingleStemOrTrunkGrowingToAConsiderableHeightAndBearingLateralBranchesAtSomeDistanceFromTheGround")]
		[EnumMember(Value = "Tree in General")] 
		TreeInGeneral = 13,
		[System.ComponentModel.Description("HavingGreenFoliageAllTheYearRound")]
		[EnumMember(Value = "Evergreen Tree")] 
		EvergreenTree = 14,
		[System.ComponentModel.Description("AConeBearingNeedleLeavedOrScaleLeavedEvergreenTree")]
		[EnumMember(Value = "Coniferous Tree")] 
		ConiferousTree = 15,
		[System.ComponentModel.Description("ATropicalOrSubTropicalTreeShrubOrVineHavingATallUnbranchedColumnarTrunkTheTrunkIsCrownedByATuftOrLargePleatedFanOrFeatherShapedLeavesWithStoutSheathingAndOftenPricklyPetiolesStalksThePersistentBasesOfWhichFrequentlyClotheTheTrunk")]
		[EnumMember(Value = "Palm Tree")] 
		PalmTree = 16,
		[System.ComponentModel.Description("ARarePalmTreeWithRegularBranchingInvolvingEqualOrSubEqualDivisionOfTheApexThatResultsInForking")]
		[EnumMember(Value = "Nipa Palm Tree")] 
		NipaPalmTree = 17,
		[System.ComponentModel.Description("ATreeCharacterizedBySlenderGreenOftenDroopingBranchesThatAreDeeplyGroovedAndThatBearAtIntervalsWhorlsOfTineLeaves")]
		[EnumMember(Value = "Casuarina Tree")] 
		CasuarinaTree = 18,
		[System.ComponentModel.Description("AnInstanceOfALargeGenusOfMostlyVeryLargeTrees90Metres")]
		[EnumMember(Value = "Eucalypt Tree")] 
		EucalyptTree = 19,
		[System.ComponentModel.Description("ShedsItsLeavesEachYearAtTheEndOfThePeriodOfGrowth")]
		[EnumMember(Value = "Deciduous Tree")] 
		DeciduousTree = 20,
		[System.ComponentModel.Description("CasuarinaEquisetifoliaTheMostWidespreadAndWellKnownMemberOfTheFamilyCasuarinaceae")]
		[EnumMember(Value = "Filao Tree")] 
		FilaoTree = 22,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfWaterTurbulence : int {
		[System.ComponentModel.Description("AWaveBreakingOnTheShoreOverAReefEtcBreakersMayBeRoughlyClassifiedIntoThreeKindsAlthoughTheCategoriesMayOverlapSpillingBreakersBreakGraduallyOverAConsiderableDistancePlungingBreakersTendToCurlOverAndBreakWithACrashAndSurgingBreakersPeakUpButThenInsteadOfSpillingOrPlungingTheySurgeUpOnTheBeachFaceTheFrenchWordBrisantIsAlsoUsedForTheObstacleCausingTheBreakingOfTheWave")]
		[EnumMember(Value = "Breakers")] 
		Breakers = 1,
		[System.ComponentModel.Description("CircularMovementsOfWaterUsuallyFormedWhereCurrentsPassObstructionsBetweenTwoAdjacentCurrentsFlowingCounterToEachOtherOrAlongTheEdgeOfAPermanentCurrent")]
		[EnumMember(Value = "Eddies")] 
		Eddies = 2,
		[System.ComponentModel.Description("ShortBreakingWavesOccurringWhenAStrongCurrentPassesOverAShoalOrOtherSubmarineObstructionOrMeetsAContraryCurrentOrWind")]
		[EnumMember(Value = "Overfalls")] 
		Overfalls = 3,
		[System.ComponentModel.Description("SmallWavesFormedOnTheSurfaceOfWaterByTheMeetingOfOpposingTidalCurrentsOrByATidalCurrentCrossingAnIrregularBottomVerticalOscillationRatherThanProgressiveWavesIsCharacteristicOfTideRips")]
		[EnumMember(Value = "Tide Rips")] 
		TideRips = 4,
		[System.ComponentModel.Description("AWaveThatFormsOverASubmergedOffshoreReefOrRockSometimesInVeryCalmWeatherOrAtHighTideNearlySwellingButInOtherConditionsBreakingHeavilyAndProducingADangerousStretchOfBrokenWaterTheReefOrRockItself")]
		[EnumMember(Value = "Bombora")] 
		Bombora = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfWeedKelp : int {
		[System.ComponentModel.Description("AGiantPlantSometimes60MetresLongWithNoRootsItIsAnchoredByHoldFastsOrTendrilsUpTo10MetresLongThatClingToRockGasFilledBubblesOnFrondsActAsFloatsKeepingTheKelpJustBelowTheSurface")]
		[EnumMember(Value = "Kelp")] 
		Kelp = 1,
		[System.ComponentModel.Description("TheGeneralNameForMarinePlantsOfTheAlgaeClassWhichGrowInLongNarrowRibbons")]
		[EnumMember(Value = "Seaweed")] 
		Seaweed = 2,
		[System.ComponentModel.Description("ACertainTypeOfSeaweedOrMoreGenerallyALargeFloatingMassOfThisSeaweed")]
		[EnumMember(Value = "Sargasso")] 
		Sargasso = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfWreck : int {
		[System.ComponentModel.Description("AWreckWhichIsNotConsideredToBeDangerousToSurfaceNavigation")]
		[EnumMember(Value = "Non-Dangerous Wreck")] 
		NonDangerousWreck = 1,
		[System.ComponentModel.Description("AWreckSubmergedAtSuchADepthAsToBeConsideredDangerousToSurfaceNavigation")]
		[EnumMember(Value = "Dangerous Wreck")] 
		DangerousWreck = 2,
		[System.ComponentModel.Description("ASubstantivelyDecayedWreckOverWhichItIsSafeToNavigateButWhichShouldBeAvoidedForAnchoringTakingTheGroundOrGroundFishing")]
		[EnumMember(Value = "Distributed Remains of Wreck")] 
		DistributedRemainsOfWreck = 3,
		[System.ComponentModel.Description("WreckOfWhichOnlyTheMastSIsVisibleAtTheSoundingDatumIndicated")]
		[EnumMember(Value = "Wreck Showing Mast/Masts")] 
		WreckShowingMastMasts = 4,
		[System.ComponentModel.Description("WreckOfWhichAnyPortionOfTheHullOrSuperstructureIsVisibleAtTheSoundingDatumIndicated")]
		[EnumMember(Value = "Wreck Showing Any Portion of Hull or Superstructure")] 
		WreckShowingAnyPortionOfHullOrSuperstructure = 5,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfZoneOfConfidenceInData : int {
		[System.ComponentModel.Description("PositionalAccuracy5Metres5DepthDepthAccuracy05Metre1DepthFullAreaSearchUndertakenSignificantSeafloorFeaturesDetectedAndDepthsMeasuredControlledSystematicSurveyHighPositionAndDepthAccuracyAchievedUsingDgpsOrAMinimumThreeHighQualityLinesOfPositionLopAndAMultibeamChannelOrMechanicalSweepSystem")]
		[EnumMember(Value = "Zone of Confidence A1")] 
		ZoneOfConfidenceA1 = 1,
		[System.ComponentModel.Description("PositionalAccuracy20MetresDepthAccuracy10Metre2DepthFullAreaSearchUndertakenSignificantSeafloorFeaturesDetectedAndDepthsMeasuredControlledSystematicSurveyAchievingPositionAndDepthAccuracyLessThanZocA1AndUsingAModernSurveyEchosounderAndASonarOrMechanicalSweepSystem")]
		[EnumMember(Value = "Zone of Confidence A2")] 
		ZoneOfConfidenceA2 = 2,
		[System.ComponentModel.Description("PositionalAccuracy50MetresDepthAccuracy10Metre2DepthFullAreaSearchNotAchievedUnchartedFeaturesHazardousToSurfaceNavigationAreNotExpectedButMayExistControlledSystematicSurveyAchievingSimilarDepthButLesserPositionAccuraciesThanZoca2UsingAModernSurveyEchosounderButNoSonarOrMechanicalSweepSystem")]
		[EnumMember(Value = "Zone of Confidence B")] 
		ZoneOfConfidenceB = 3,
		[System.ComponentModel.Description("PositionalAccuracy500MetresDepthAccuracy20Metre5DepthFullAreaSearchNotAchievedDepthAnomaliesMayBeExpectedLowAccuracySurveyOrDataCollectedOnAnOpportunityBasisSuchAsSoundingsOnPassage")]
		[EnumMember(Value = "Zone of Confidence C")] 
		ZoneOfConfidenceC = 4,
		[System.ComponentModel.Description("PositionalAccuracyWorseThanZocCDepthAccuracyWorseThanZocCFullAreaSearchNotAchievedLargeDepthAnomaliesMayBeExpectedPoorQualityDataOrDataThatCannotBeQualityAssessedDueToLackOfInformation")]
		[EnumMember(Value = "Zone of Confidence D")] 
		ZoneOfConfidenceD = 5,
		[System.ComponentModel.Description("TheQualityOfTheBathymetricDataHasYetToBeAssessed")]
		[EnumMember(Value = "Zone of Confidence U")] 
		ZoneOfConfidenceU = 6,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum colour : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "White")] 
		White = 1,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Black")] 
		Black = 2,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Red")] 
		Red = 3,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Green")] 
		Green = 4,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Blue")] 
		Blue = 5,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Yellow")] 
		Yellow = 6,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Grey")] 
		Grey = 7,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Brown")] 
		Brown = 8,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Amber")] 
		Amber = 9,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Violet")] 
		Violet = 10,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Orange")] 
		Orange = 11,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Magenta")] 
		Magenta = 12,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "Pink")] 
		Pink = 13,
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
		[System.ComponentModel.Description("ABandOrStripeOfColourWhichIsDisplayedAroundTheOuterEdgeOfTheFeatureWhichMayAlsoFormABorderToAnInnerPatternOrPlainColour")]
		[EnumMember(Value = "Border Stripe")] 
		BorderStripe = 6,
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
	public enum dataAssessment : int {
		[System.ComponentModel.Description("TheQualityOfTheBathymetricDataHasBeenAssessed")]
		[EnumMember(Value = "Assessed")] 
		Assessed = 1,
		[System.ComponentModel.Description("TheQualityOfOceanicBathymetricDataDepthsDeeperThan200MetresHasBeenAssessedHoweverDetailsAreNotRequired")]
		[EnumMember(Value = "Assessed (Oceanic)")] 
		AssessedOceanic = 2,
		[System.ComponentModel.Description("NotHavingBeenAssessed")]
		[EnumMember(Value = "Unassessed")] 
		Unassessed = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum dayOfWeek : int {
		[System.ComponentModel.Description("TheDayOfTheWeekFollowingSaturdayAndPrecedingMonday")]
		[EnumMember(Value = "Sunday")] 
		Sunday = 1,
		[System.ComponentModel.Description("TheDayOfTheWeekFollowingSundayAndPrecedingTuesday")]
		[EnumMember(Value = "Monday")] 
		Monday = 2,
		[System.ComponentModel.Description("TheDayOfTheWeekFollowingMondayAndPrecedingWednesday")]
		[EnumMember(Value = "Tuesday")] 
		Tuesday = 3,
		[System.ComponentModel.Description("TheDayOfTheWeekFollowingTuesdayAndPrecedingThursday")]
		[EnumMember(Value = "Wednesday")] 
		Wednesday = 4,
		[System.ComponentModel.Description("TheDayOfTheWeekFollowingWednesdayAndPrecedingFriday")]
		[EnumMember(Value = "Thursday")] 
		Thursday = 5,
		[System.ComponentModel.Description("TheDayOfTheWeekFollowingThursdayAndPrecedingSaturday")]
		[EnumMember(Value = "Friday")] 
		Friday = 6,
		[System.ComponentModel.Description("TheDayOfTheWeekFollowingFridayAndPrecedingSunday")]
		[EnumMember(Value = "Saturday")] 
		Saturday = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum distanceUnitOfMeasurement : int {
		[System.ComponentModel.Description("TheBasicUnitOfLengthInTheInternationalSystemOfUnitsSiSystem")]
		[EnumMember(Value = "Metres")] 
		Metres = 1,
		[System.ComponentModel.Description("ACommonUnitOfLinearMeasureInEnglishSpeakingCountriesEqualTo3FeetOr36InchesAndEquivalentTo09144Metre")]
		[EnumMember(Value = "Yards")] 
		Yards = 2,
		[System.ComponentModel.Description("AUnitOfLengthTheCommonMeasureOfDistancesEqualTo1000MetresAndEquivalentTo32808FeetOr0621Mile")]
		[EnumMember(Value = "Kilometres")] 
		Kilometres = 3,
		[System.ComponentModel.Description("AUnitEqualTo5280Feet")]
		[EnumMember(Value = "Statute Miles")] 
		StatuteMiles = 4,
		[System.ComponentModel.Description("AUnitOfLengthEqualTo1852MetresThisValueWasApprovedByTheInternationalHydrographicConferenceOf1929AndHasBeenAdoptedByNearlyAllMaritimeStates")]
		[EnumMember(Value = "Nautical Miles")] 
		NauticalMiles = 5,
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
	public enum expositionOfSounding : int {
		[System.ComponentModel.Description("TheDepthCorrespondsToTheDepthRangeOfTheSurroundingDepthAreaThatIsTheDepthIsNotShoalerThanTheMinimumDepthOfTheSurroundingDepthAreaOrDeeperThanTheMaximumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Within the Range of Depth of the Surrounding Depth Area")] 
		WithinTheRangeOfDepthOfTheSurroundingDepthArea = 1,
		[System.ComponentModel.Description("TheDepthIsShoalerThanTheMinimumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Shoaler Than the Range of Depth of the Surrounding Depth Area")] 
		ShoalerThanTheRangeOfDepthOfTheSurroundingDepthArea = 2,
		[System.ComponentModel.Description("TheDepthIsDeeperThanTheMaximumDepthOfTheSurroundingDepthArea")]
		[EnumMember(Value = "Deeper Than the Range of Depth of the Surrounding Depth Area")] 
		DeeperThanTheRangeOfDepthOfTheSurroundingDepthArea = 3,
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
		[System.ComponentModel.Description("AnEstablishmentForTeachingAndLearningForExampleSchoolCollegeUniversityEtc")]
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
	public enum jurisdiction : int {
		[System.ComponentModel.Description("InvolvingMoreThanOneCountryCoveringMoreThanOneNationalArea")]
		[EnumMember(Value = "International")] 
		International = 1,
		[System.ComponentModel.Description("AnAreaAdministeredOrControlledByASingleNation")]
		[EnumMember(Value = "National")] 
		National = 2,
		[System.ComponentModel.Description("AnAreaSmallerThanTheNationInWhichItLies")]
		[EnumMember(Value = "National Sub-Division")] 
		NationalSubDivision = 3,
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
		[System.ComponentModel.Description("ASingleFlashingLightInWhichAnAppearanceOfLightOfNotLessThanTwoSecondsDurationIsRegularlyRepeated")]
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
		[System.ComponentModel.Description("ALightInWhichTheUltraQuickFlashes160OrMorePerMinuteAreInterruptedAtRegularIntervalsByEclipsesOfLongDuration")]
		[EnumMember(Value = "Interrupted Ultra Quick-Flashing")] 
		InterruptedUltraQuickFlashing = 11,
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
		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Quick-Flash Plus Long-Flash")] 
		QuickFlashPlusLongFlash = 25,
		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfVeryQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Very Quick-Flash Plus Long-Flash")] 
		VeryQuickFlashPlusLongFlash = 26,
		[System.ComponentModel.Description("ARhythmicLightInWhichAGroupOfUltraQuickFlashesIsFollowedByOneOrMoreLongFlashesInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Ultra Quick-Flash Plus Long-Flash")] 
		UltraQuickFlashPlusLongFlash = 27,
		[System.ComponentModel.Description("ASignalLightThatShowsContinuouslyInAnyGivenDirectionTwoOrMoreColoursInARegularlyRepeatedSequenceWithARegularPeriodicity")]
		[EnumMember(Value = "Alternating")] 
		Alternating = 28,
		[System.ComponentModel.Description("ARhythmicLightInWhichAFixedLightIsCombinedWithAFlashingLightOfHigherLuminousIntensityAndDifferentColour")]
		[EnumMember(Value = "Fixed and Alternating Flashing")] 
		FixedAndAlternatingFlashing = 29,
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
		[System.ComponentModel.Description("LightsThatMustBeInLineToBeVisible")]
		[EnumMember(Value = "Visible in Line of Range")] 
		VisibleInLineOfRange = 9,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum referenceDirection : int {
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "East")] 
		East = 5,
		[System.ComponentModel.Description("")]
		[EnumMember(Value = "West")] 
		West = 13,
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
		[EnumMember(Value = "no system")] 
		NoSystem = 9,
		[System.ComponentModel.Description("NavigationalAidsAsRequiredInInternationalNationalOrRegionalRegulationsThatContainTheSameNavigationalAidsAsTheEuropeanCodeForInlandWaterwaysOfUneceOrIfThereIsNoRegulationForAWaterwayNavigationalAidsAsRecommendedInTheEuropeanCodeForInlandWaterwaysOfUnece")]
		[EnumMember(Value = "main European inland waterway marking system")] 
		MainEuropeanInlandWaterwayMarkingSystem = 11,
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
		[System.ComponentModel.Description("AStructureOfCrossedWoodenOrMetalStripsUsuallyArrangedToFormADiagonalPatternOfOpenSpacesBetweenTheStrips")]
		[EnumMember(Value = "Latticed")] 
		Latticed = 11,
		[System.ComponentModel.Description("oneAnyArtificialOrNaturalSubstanceHavingSimilarPropertiesAndCompositionAsFusedBoraxObsidianOrTheLike2SomethingMadeOfSuchASubstanceAsAWindowpane")]
		[EnumMember(Value = "Glass")] 
		Glass = 12,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfSurface : int {
		[System.ComponentModel.Description("SoftWetEarth")]
		[EnumMember(Value = "Mud")] 
		Mud = 1,
		[System.ComponentModel.Description("ParticlesOfLessThan0002mmStiffStickyEarthThatBecomesHardWhenBaked")]
		[EnumMember(Value = "Clay")] 
		Clay = 2,
		[System.ComponentModel.Description("AnUnconsolidatedSedimentWhoseParticlesRangeInSizeFrom00039To00625MillimetresInDiameterBetweenClayAndSandSize")]
		[EnumMember(Value = "Silt")] 
		Silt = 3,
		[System.ComponentModel.Description("LooseMaterialConsistingOfSmallButEasilyDistinguishableSeparateGrainsBetween00625And2000MillimetresInDiameter")]
		[EnumMember(Value = "Sand")] 
		Sand = 4,
		[System.ComponentModel.Description("AGeneralTermForRockAndRockFragmentsRangingInSizeFromPebblesAndGravelToBouldersOrLargeRockMasses")]
		[EnumMember(Value = "Stone")] 
		Stone = 5,
		[System.ComponentModel.Description("ParticlesOf2040mmSmallStonesWithCoarseSand")]
		[EnumMember(Value = "Gravel")] 
		Gravel = 6,
		[System.ComponentModel.Description("ASmallStoneWornSmoothAndRoundedByTheActionOfWaterSandIceEtcRangingInDiameterBetween4And64Millimetres")]
		[EnumMember(Value = "Pebbles")] 
		Pebbles = 7,
		[System.ComponentModel.Description("ANaturallyRoundedStoneLargerThanAPebble")]
		[EnumMember(Value = "Cobbles")] 
		Cobbles = 8,
		[System.ComponentModel.Description("AnyFormationOfNaturalOriginThatConstitutesAnIntegralPartOfTheLithosphereTheNaturalOccurringMaterialThatFormsFirmHardAndSolidMasses")]
		[EnumMember(Value = "Rock")] 
		Rock = 9,
		[System.ComponentModel.Description("TheFluidOrSemiFluidMatterFlowingFromAVolcanoTheSubstanceThatResultsFromTheCoolingOfTheMoltenRockPartOfTheOceanBedIsComposedOfLava")]
		[EnumMember(Value = "Lava")] 
		Lava = 11,
		[System.ComponentModel.Description("HardCalcareousSkeletonsOfManyTribesOfMarinePolyps")]
		[EnumMember(Value = "Coral")] 
		Coral = 14,
		[System.ComponentModel.Description("TheHardOutsideCoveringOfAnAnimalPartOfTheOceanBedIsComposedOfNumerousShellsOfMarineAnimals")]
		[EnumMember(Value = "Shells")] 
		Shells = 17,
		[System.ComponentModel.Description("ARoundedRockWithDiameterOf256MillimetresOrLarger")]
		[EnumMember(Value = "Boulder")] 
		Boulder = 18,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum natureOfSurfaceQualifyingTerms : int {
		[System.ComponentModel.Description("FallsWithinTheSmallestSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Fine")] 
		Fine = 1,
		[System.ComponentModel.Description("FallsWithinTheModerateSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Medium")] 
		Medium = 2,
		[System.ComponentModel.Description("FallsWithinTheLargestSizeContinuumForAParticularNatureOfSurfaceTerm")]
		[EnumMember(Value = "Coarse")] 
		Coarse = 3,
		[System.ComponentModel.Description("FracturedOrInPieces")]
		[EnumMember(Value = "Broken")] 
		Broken = 4,
		[System.ComponentModel.Description("HavingAnAdhesiveOrGlueLikeProperty")]
		[EnumMember(Value = "Sticky")] 
		Sticky = 5,
		[System.ComponentModel.Description("NotHardOrFirm")]
		[EnumMember(Value = "Soft")] 
		Soft = 6,
		[System.ComponentModel.Description("NotPliantThickResistantToFlow")]
		[EnumMember(Value = "Stiff")] 
		Stiff = 7,
		[System.ComponentModel.Description("ComposedOfOrContainingMaterialEjectedFromAVolcano")]
		[EnumMember(Value = "Volcanic")] 
		Volcanic = 8,
		[System.ComponentModel.Description("ComposedOfOrContainingCalciumOrCalciumCarbonate")]
		[EnumMember(Value = "Calcareous")] 
		Calcareous = 9,
		[System.ComponentModel.Description("FirmUsuallyRefersToAnAreaOfTheSeafloorNotCoveredByUnconsolidatedSediment")]
		[EnumMember(Value = "Hard")] 
		Hard = 10,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum pilotMovement : int {
		[System.ComponentModel.Description("ThePlaceWhereVesselsNotBeingNavigatedAccordingToAPilotSInstructionsPickUpAPilotWhileInTransitFromSeaToAPortOrConstrictedWatersForFutureNavigationUnderPilotInstructions")]
		[EnumMember(Value = "Embarkation")] 
		Embarkation = 1,
		[System.ComponentModel.Description("ThePlaceWhereVesselsBeingNavigatedUnderAPilotSInstructionsInTransitFromSeaToAPortOrConstrictedWatersDropThePilotAndProceedWithoutBeingSubjectToPilotInstructions")]
		[EnumMember(Value = "Disembarkation")] 
		Disembarkation = 2,
		[System.ComponentModel.Description("ThePlaceWhereVesselsBeingNavigatedUnderAPilotSInstructionsDropOffThePilotAndPickUpADifferentPilotForFutureNavigationUnderPilotSInstructions")]
		[EnumMember(Value = "Pilot Change")] 
		PilotChange = 3,
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
	public enum qualityOfHorizontalMeasurement : int {
		[System.ComponentModel.Description("APositionThatIsConsideredToBeLessThanThirdOrderAccuracyButIsGenerallyConsideredToBeWithin305MetresOfItsCorrectGeographicLocationAlsoMayApplyToAFeatureWhosePositionDoesNotRemainFixed")]
		[EnumMember(Value = "Approximate")] 
		Approximate = 4,
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
	public enum referenceTide : int {
		[System.ComponentModel.Description("TheHighestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "High Water")] 
		HighWater = 1,
		[System.ComponentModel.Description("TheLowestLevelReachedAtAPlaceByTheWaterSurfaceInOneOscillation")]
		[EnumMember(Value = "Low Water")] 
		LowWater = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum referenceTideType : int {
		[System.ComponentModel.Description("TheTidesOfIncreasedRangeOccurringNearTheTimesOfFullMoonAndNewMoon")]
		[EnumMember(Value = "Springs")] 
		Springs = 1,
		[System.ComponentModel.Description("TheTidesOfDecreasedRangeOccurringNearTheTimesOfFirstAndLastQuarter")]
		[EnumMember(Value = "Neaps")] 
		Neaps = 2,
		[System.ComponentModel.Description("TheTidesOfMeanRangeOccurringBetweenSpringAndNeapTides")]
		[EnumMember(Value = "Mean")] 
		Mean = 3,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum restriction : int {
		[System.ComponentModel.Description("AnAreaWithinWhichAnchoringIsNotPermitted")]
		[EnumMember(Value = "Anchoring Prohibited")] 
		AnchoringProhibited = 1,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichAnchoringIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Anchoring Restricted")] 
		AnchoringRestricted = 2,
		[System.ComponentModel.Description("AnAreaWithinWhichFishingIsNotPermitted")]
		[EnumMember(Value = "Fishing Prohibited")] 
		FishingProhibited = 3,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichFishingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Fishing Restricted")] 
		FishingRestricted = 4,
		[System.ComponentModel.Description("AnAreaWithinWhichTrawlingIsNotPermitted")]
		[EnumMember(Value = "Trawling Prohibited")] 
		TrawlingProhibited = 5,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichTrawlingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Trawling Restricted")] 
		TrawlingRestricted = 6,
		[System.ComponentModel.Description("AnAreaWithinWhichNavigationAndOrAnchoringIsProhibited")]
		[EnumMember(Value = "Entry Prohibited")] 
		EntryProhibited = 7,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichNavigationIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Entry Restricted")] 
		EntryRestricted = 8,
		[System.ComponentModel.Description("AnAreaWithinWhichDredgingIsNotPermitted")]
		[EnumMember(Value = "Dredging Prohibited")] 
		DredgingProhibited = 9,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichDredgingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Dredging Restricted")] 
		DredgingRestricted = 10,
		[System.ComponentModel.Description("AnAreaWithinWhichDivingIsNotPermitted")]
		[EnumMember(Value = "Diving Prohibited")] 
		DivingProhibited = 11,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAppropriateAuthorityWithinWhichDivingIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Diving Restricted")] 
		DivingRestricted = 12,
		[System.ComponentModel.Description("MarinersMustAdjustTheSpeedOfTheirVesselsToReduceTheWaveOrWashWhichMayCauseErosionOrDisturbMooredVessels")]
		[EnumMember(Value = "No Wake")] 
		NoWake = 13,
		[System.ComponentModel.Description("AnImoDeclaredRouteingMeasureComprisingAnAreaWithinDefinedLimitsInWhichEitherNavigationIsParticularlyHazardousOrItIsExceptionallyImportantToAvoidCasualtiesAndWhichShouldBeAvoidedByAllShipsOrCertainClassesOfShips")]
		[EnumMember(Value = "Area To Be Avoided")] 
		AreaToBeAvoided = 14,
		[System.ComponentModel.Description("TheErectionOfPermanentOrTemporaryFixedStructuresOrArtificialIslandsIsProhibited")]
		[EnumMember(Value = "Construction Prohibited")] 
		ConstructionProhibited = 15,
		[System.ComponentModel.Description("AnAreaWithinWhichDischargingOrDumpingIsProhibited")]
		[EnumMember(Value = "Discharging Prohibited")] 
		DischargingProhibited = 16,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichDischargingOrDumpingIsRestrictedInAccordanceWithSpecifiedConditions")]
		[EnumMember(Value = "Discharging Restricted")] 
		DischargingRestricted = 17,
		[System.ComponentModel.Description("AnAreaWithinWhichIndustrialOrMineralExplorationAndDevelopmentAreProhibited")]
		[EnumMember(Value = "Industrial or Mineral Exploration/Development Prohibited")] 
		IndustrialOrMineralExplorationDevelopmentProhibited = 18,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichIndustrialOrMineralExplorationAndDevelopmentIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Industrial or Mineral Exploration/Development Restricted")] 
		IndustrialOrMineralExplorationDevelopmentRestricted = 19,
		[System.ComponentModel.Description("AnAreaWithinWhichExcavatingAHoleOnTheSeabedWithADrillIsProhibited")]
		[EnumMember(Value = "Drilling Prohibited")] 
		DrillingProhibited = 20,
		[System.ComponentModel.Description("ASpecifiedAreaDesignatedByAnAppropriateAuthorityWithinWhichExcavatingAHoleOnTheSeabedWithADrillIsRestrictedInAccordanceWithCertainSpecifiedConditions")]
		[EnumMember(Value = "Drilling Restricted")] 
		DrillingRestricted = 21,
		[System.ComponentModel.Description("AnAreaWithinWhichTheRemovalOfHistoricalArtefactsIsProhibited")]
		[EnumMember(Value = "Removal of Historical Artefacts Prohibited")] 
		RemovalOfHistoricalArtefactsProhibited = 22,
		[System.ComponentModel.Description("AnAreaInWhichCargoTranshipmentLighteningIsProhibited")]
		[EnumMember(Value = "Cargo Transhipment (Lightening) Prohibited")] 
		CargoTranshipmentLighteningProhibited = 23,
		[System.ComponentModel.Description("AnAreaInWhichTheDraggingOfAnythingAlongTheSeabedForExampleBottomTrawlingIsProhibited")]
		[EnumMember(Value = "Dragging Prohibited")] 
		DraggingProhibited = 24,
		[System.ComponentModel.Description("AnAreaInWhichAVesselIsProhibitedFromStopping")]
		[EnumMember(Value = "Stopping Prohibited")] 
		StoppingProhibited = 25,
		[System.ComponentModel.Description("AnAreaInWhichLandingIsProhibited")]
		[EnumMember(Value = "Landing Prohibited")] 
		LandingProhibited = 26,
		[System.ComponentModel.Description("AnAreaWithinWhichSpeedIsRestricted")]
		[EnumMember(Value = "Speed Restricted")] 
		SpeedRestricted = 27,
		[System.ComponentModel.Description("AnAreaInWhichSwimmingIsProhibited")]
		[EnumMember(Value = "Swimming Prohibited")] 
		SwimmingProhibited = 39,
		[System.ComponentModel.Description("AnAreaWithinWhichAnyVesselPropelledByMachineryIsProhibited")]
		[EnumMember(Value = "Power-Driven Vessels Prohibited")] 
		PowerDrivenVesselsProhibited = 42,
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
	public enum speedUnits : int {
		[System.ComponentModel.Description("AUnitOfSpeedExpressingTheNumberOfKilometresTravelledInOneHour")]
		[EnumMember(Value = "Kilometres Per Hour")] 
		KilometresPerHour = 2,
		[System.ComponentModel.Description("AnImperialAndUnitedStatesCustomaryUnitOfSpeedExpressingTheNumberOfStatuteMilesCoveredInOneHour")]
		[EnumMember(Value = "Miles Per Hour")] 
		MilesPerHour = 3,
		[System.ComponentModel.Description("ANauticalUnitOfSpeedOneKnotIsOneNauticalMilePerHourTheNameIsDerivedFromTheKnotsInTheLogLine")]
		[EnumMember(Value = "Knots")] 
		Knots = 4,
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
		[System.ComponentModel.Description("LitByFloodLightsStripLightsEtc")]
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
		[System.ComponentModel.Description("MarkedByBuoys")]
		[EnumMember(Value = "Buoyed")] 
		Buoyed = 28,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum surveyType : int {
		[System.ComponentModel.Description("ASurveyMadeDueToLackOfTimeOrFacilitiesToALowerDegreeOfAccuracyAndDetailThanTheChosenScaleWouldNormallyIndicate")]
		[EnumMember(Value = "Reconnaissance/Sketch Survey")] 
		ReconnaissanceSketchSurvey = 1,
		[System.ComponentModel.Description("AThoroughSurveyUsuallyConductedWithReferenceToGuidelines")]
		[EnumMember(Value = "Controlled Survey")] 
		ControlledSurvey = 2,
		[System.ComponentModel.Description("ASurveyPrincipallyAimedAtTheInvestigationOfUnderwaterObstructionsAndDangers")]
		[EnumMember(Value = "Examination Survey")] 
		ExaminationSurvey = 4,
		[System.ComponentModel.Description("ASurveyWhereSoundingsAreAcquiredByVesselsOnPassage")]
		[EnumMember(Value = "Passage Survey")] 
		PassageSurvey = 5,
		[System.ComponentModel.Description("ASurveyWhereFeaturesHaveBeenPositionedAndDelimitedUsingRemoteSensingTechniques")]
		[EnumMember(Value = "Remotely Sensed")] 
		RemotelySensed = 6,
		[System.ComponentModel.Description("ASurveyAchieving100CoverageUsingSystematicControlledTechniquesProvidingFullSeafloorCoverageOrFullCoverageToADefinedDepthAndAnInvestigationOfAllContacts")]
		[EnumMember(Value = "Full Coverage")] 
		FullCoverage = 7,
		[System.ComponentModel.Description("AControlledSurveyButFullCoverageMayNotHaveBeenAchieved")]
		[EnumMember(Value = "Systematic Survey")] 
		SystematicSurvey = 8,
		[System.ComponentModel.Description("ASurveyOfLowerQualityThanAFullCoverageAndSystematicSurveySuchSurveysMayBeFurtherCategorizedAsReconnaissanceSketchTrackPassageRemotelySensedAndSpotSoundingSurveys")]
		[EnumMember(Value = "Non-Systematic Survey")] 
		NonSystematicSurvey = 9,
		[System.ComponentModel.Description("NotSurveyedToModernStandardsOrDueToItsAgeScaleOrPositionalOrVerticalUncertaintiesIsNotSuitableToTheTypeOfNavigationExpectedInTheArea")]
		[EnumMember(Value = "Inadequately Surveyed")] 
		InadequatelySurveyed = 10,
		[System.ComponentModel.Description("ASurveyThatUsesARegularForExampleGridOrIrregularPatternOfSoundingsObtainedOneAtATimeAndNormallyWithVeryWideSpacing")]
		[EnumMember(Value = "Spot-Sounding Survey")] 
		SpotSoundingSurvey = 11,
		[System.ComponentModel.Description("AControlledSystematicSurveyToStandardAccuracyUsingModernSurveyEchoSounderWithSonarSweep")]
		[EnumMember(Value = "Acoustically Swept Survey")] 
		AcousticallySweptSurvey = 12,
		[System.ComponentModel.Description("SweptAreasWhereTheClearanceDepthIsAccuratelyKnownButTheActualSeabedDepthIsNotAccuratelyKnown")]
		[EnumMember(Value = "Mechanically Swept Survey")] 
		MechanicallySweptSurvey = 13,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum updateType : int {
		[System.ComponentModel.Description("ToPutOrIntroduceIntoTheBodyOfSomething")]
		[EnumMember(Value = "Insert")] 
		Insert = 1,
		[System.ComponentModel.Description("ToEliminateEspeciallyByRemovingCuttingOutOrErasing")]
		[EnumMember(Value = "Delete")] 
		Delete = 2,
		[System.ComponentModel.Description("ToMakeBasicOrFundamentalChangesToTheCharacteristicsOfSomethingOftenToGiveANewOrientationToOrToServeANewEnd")]
		[EnumMember(Value = "Modify")] 
		Modify = 3,
		[System.ComponentModel.Description("ToChangeThePlaceOrPositionOfSomething")]
		[EnumMember(Value = "Move")] 
		Move = 4,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum techniqueOfVerticalMeasurement : int {
		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAnInstrumentThatDeterminesDepthOfWaterByMeasuringTheTimeIntervalBetweenEmissionOfASonicOrUltrasonicSignalAndReturnOfItsEchoFromTheBottom")]
		[EnumMember(Value = "Found by Echo Sounder")] 
		FoundByEchoSounder = 1,
		[System.ComponentModel.Description("TheDepthWasComputedFromARecordProducedByActiveSonarInWhichFixedAcousticBeamsAreDirectedIntoTheWaterPerpendicularlyToTheDirectionOfTravelToScanTheSeabedAndGenerateARecordOfTheSeabedConfiguration")]
		[EnumMember(Value = "Found by Side Scan Sonar")] 
		FoundBySideScanSonar = 2,
		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAWideSwathEchoSounderThatUsesMultipleBeamsToMeasureDepthsDirectlyBelowAndTransverseToTheShipSTrack")]
		[EnumMember(Value = "Found by Multi Beam")] 
		FoundByMultiBeam = 3,
		[System.ComponentModel.Description("TheDepthWasDeterminedByAPersonSkilledInThePracticeOfDiving")]
		[EnumMember(Value = "Found by Diver")] 
		FoundByDiver = 4,
		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingALineGraduatedWithAttachedMarksAndFastenedToASoundingLead")]
		[EnumMember(Value = "Found by Lead Line")] 
		FoundByLeadLine = 5,
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
		[System.ComponentModel.Description("TheDepthWasMeasuredByUsingAnInstrumentThatMeasuresDistanceByEmittingTimedPulsesOfLaserLightAndMeasuringTheTimeBetweenEmissionAndReceptionOfTheReflectedPulses")]
		[EnumMember(Value = "Found by LIDAR")] 
		FoundByLidar = 15,
		[System.ComponentModel.Description("ARadarWithASyntheticApertureAntennaWhichIsComposedOfALargeNumberOfElementaryTransducingElementsTheSignalsAreElectronicallyCombinedIntoAResultingSignalEquivalentToThatOfASingleAntennaOfAGivenApertureInAGivenDirection")]
		[EnumMember(Value = "Synthetic Aperture Radar")] 
		SyntheticApertureRadar = 16,
		[System.ComponentModel.Description("TermUsedToDescribeTheImageryDerivedFromSubdividingTheElectromagneticSpectrumIntoVeryNarrowBandwidthsTheseNarrowBandwidthsMayBeCombinedWithOrSubtractedFromEachOtherInVariousWaysToFormImagesUsefulInPreciseTerrainOrTargetAnalysis")]
		[EnumMember(Value = "Hyperspectral Imagery")] 
		HyperspectralImagery = 17,
		[System.ComponentModel.Description("TheGivenAreaWasDeterminedToBeFreeFromNavigationalDangersToACertainDepthByTowingALineOrObjectBelowTheSurfaceAtTheDesiredDepthOrLeastDepthSAndPositionSWithinAnAreaWasIdentifiedUsingTheSameTechnique")]
		[EnumMember(Value = "Mechanically Swept")] 
		MechanicallySwept = 18,
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
		[System.ComponentModel.Description("ADistinguishingTraitQualityOrPropertyOfAFeatureClass")]
		[EnumMember(Value = "Feature Characteristic")] 
		FeatureCharacteristic = 2,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum topmarkDaymarkShape : int {
		[System.ComponentModel.Description("IsWhereTheVertexPointsUp")]
		[EnumMember(Value = "Cone (Point Up)")] 
		ConePointUp = 1,
		[System.ComponentModel.Description("IsWhereTheVertexPointsDown")]
		[EnumMember(Value = "Cone (Point Down)")] 
		ConePointDown = 2,
		[System.ComponentModel.Description("ACurvedSurfaceAllPointsOfWhichAreEquidistantFromAFixedPointWithinCalledTheCentre")]
		[EnumMember(Value = "Sphere")] 
		Sphere = 3,
		[System.ComponentModel.Description("TwoSpheresOneAboveTheOtherTwoBlackSpheresAreCommonlyUsedAsAnInternationalAssociationOfLighthouseAuthoritiesIalaTopmarkIsolatedDanger")]
		[EnumMember(Value = "2 Spheres")] 
		twoSpheres = 4,
		[System.ComponentModel.Description("ASolidGeometricalFigureGeneratedByStraightLinesFixedInDirectionAndDescribingWithOneOfPointAClosedCurveEspeciallyACircleInWhichCaseTheFigureIsCircularCylinderItsEndsBeingParallelCircles")]
		[EnumMember(Value = "Cylinder")] 
		Cylinder = 5,
		[System.ComponentModel.Description("UsuallyOfRectangularShapeMadeFromTimberOrMetalAndUsedToProvideAContrastWithTheNaturalBackgroundOfADaymarkTheActualDaymarkIsOftenPaintedOnToThisBoard")]
		[EnumMember(Value = "Board")] 
		Board = 6,
		[System.ComponentModel.Description("HavingAShapeOrACrossSectionLikeTheCapitalLetterX")]
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
		[System.ComponentModel.Description("ABundleOfRodsOrTwigsABesomPointUpIsWhereTheThickerUntiedEndOfTheBesomIsAtTheBottom")]
		[EnumMember(Value = "Besom (Point Up)")] 
		BesomPointUp = 15,
		[System.ComponentModel.Description("ABundleOfRodsOrTwigsABesomPointDownIsWhereTheThinnerTiedEndOfTheBesomIsAtTheBottom")]
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
		[System.ComponentModel.Description("AHorizontalRectangleIsWhereTheTwoLongerOppositeSidesAreStandingHorizontally")]
		[EnumMember(Value = "Rectangle (Horizontal)")] 
		RectangleHorizontal = 20,
		[System.ComponentModel.Description("AVerticalRectangleIsWhereTheTwoLongerOppositeSidesAreStandingVertically")]
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
		[System.ComponentModel.Description("TheDatumRefersToEachBalticCountrySRealizationOfTheEuropeanVerticalReferenceSystemEvrsWithLandUpliftEpoch2000WhichIsConnectedToTheNormaalAmsterdamsPeilNap")]
		[EnumMember(Value = "Baltic Sea Chart Datum 2000")] 
		BalticSeaChartDatum2000 = 44,
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
		[System.ComponentModel.Description("IndicatesThePortBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyageInTheIalaASystem")]
		[EnumMember(Value = "Port Lateral (IALA A)")] 
		PortLateralIalaA = 5,
		[System.ComponentModel.Description("IndicatesTheStarboardBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyageInTheIalaASystem")]
		[EnumMember(Value = "Starboard Lateral (IALA A)")] 
		StarboardLateralIalaA = 6,
		[System.ComponentModel.Description("IndicatesThePortBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyageInTheIalaBSystem")]
		[EnumMember(Value = "Port Lateral (IALA B)")] 
		PortLateralIalaB = 7,
		[System.ComponentModel.Description("IndicatesTheStarboardBoundaryOfANavigationalChannelOrSuggestedRouteWhenProceedingInTheConventionalDirectionOfBuoyageInTheIalaBSystem")]
		[EnumMember(Value = "Starboard Lateral (IALA B)")] 
		StarboardLateralIalaB = 8,
		[System.ComponentModel.Description("AMarkUsedAloneToIndicateADangerousReefOrShoalTheMarkMayBePassedOnEitherHand")]
		[EnumMember(Value = "Isolated Danger")] 
		IsolatedDanger = 9,
		[System.ComponentModel.Description("IndicatesThatThereIsNavigableWaterAroundTheMark")]
		[EnumMember(Value = "Safe Water")] 
		SafeWater = 10,
		[System.ComponentModel.Description("ASpecialPurposeAidIsPrimarilyUsedToIndicateAnAreaOrFeatureTheNatureOfWhichIsApparentFromReferenceToAChartSailingDirectionsOrNoticeToMariners")]
		[EnumMember(Value = "Special Purpose")] 
		SpecialPurpose = 11,
		[System.ComponentModel.Description("AMarkUsedToIndicateTheExistenceOfARecentWreck")]
		[EnumMember(Value = "Emergency Wreck Marking")] 
		EmergencyWreckMarking = 12,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum visualProminence : int {
		[System.ComponentModel.Description("TermAppliedToAnObjectEitherNaturalOrArtificialWhichIsDistinctlyAndNotablyVisibleFromSeaward")]
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
	public enum waterLevelEffect : int {
		[System.ComponentModel.Description("PartiallyCoveredAndPartiallyDryAtHighWater")]
		[EnumMember(Value = "Partly Submerged at High Water")] 
		PartlySubmergedAtHighWater = 1,
		[System.ComponentModel.Description("NotCoveredAtHighWaterUnderAverageMeteorologicalConditions")]
		[EnumMember(Value = "Always Dry")] 
		AlwaysDry = 2,
		[System.ComponentModel.Description("RemainsCoveredByWaterAtAllTimesUnderAverageMeteorologicalConditions")]
		[EnumMember(Value = "Always Under Water/Submerged")] 
		AlwaysUnderWaterSubmerged = 3,
		[System.ComponentModel.Description("ExpressionIntendedToIndicateAnAreaOfAReefOrOtherProjectionFromTheBottomOfABodyOfWaterWhichPeriodicallyExtendsAboveAndIsSubmergedBelowTheSurfaceAlsoReferredToAsDriesOrUncovers")]
		[EnumMember(Value = "Covers and Uncovers")] 
		CoversAndUncovers = 4,
		[System.ComponentModel.Description("FlushWithOrWashedByTheWavesAtLowWaterUnderAverageMeteorologicalConditions")]
		[EnumMember(Value = "Awash")] 
		Awash = 5,
		[System.ComponentModel.Description("AnAreaPeriodicallyCoveredByFloodWaterExcludingTidalWaters")]
		[EnumMember(Value = "Subject to Inundation or Flooding")] 
		SubjectToInundationOrFlooding = 6,
		[System.ComponentModel.Description("RestingOrMovingOnTheSurfaceOfALiquidWithoutSinking")]
		[EnumMember(Value = "Floating")] 
		Floating = 7,
		[System.ComponentModel.Description("Unknown value.")]
		[EnumMember(Value = "Unknown")]
		Unknown = -1,
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	[System.Serializable()]
	public enum categoryOfCargo : int {
		[System.ComponentModel.Description("UnpackedHomogenousCargoPouredLooseInACertainSpaceOfAVesselForExampleOilOrGrain")]
		[EnumMember(Value = "Bulk")] 
		Bulk = 1,
		[System.ComponentModel.Description("OneOfANumberOfStandardSizedCargoCarryingUnitsSecuredUsingStandardCornerAttachmentsAndBar")]
		[EnumMember(Value = "Container")] 
		Container = 2,
		[System.ComponentModel.Description("BreakBulkCargoNormallyLoadedByCrane")]
		[EnumMember(Value = "General")] 
		General = 3,
		[System.ComponentModel.Description("AnyCargoLoadedByPipeline")]
		[EnumMember(Value = "Liquid")] 
		Liquid = 4,
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
		[System.ComponentModel.Description("MaterialCarriedByAShipToEnsureItsStability")]
		[EnumMember(Value = "Ballast")] 
		Ballast = 9,
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

	public static class CodeList
	{
	}
	namespace ComplexAttributes {
	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class featureName {
			public String language {get;set;} = string.Empty;

			public String name {get;set;} = string.Empty;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public nameUsage? nameUsage {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class featuresDetected {
			[Required()]
			public Boolean leastDepthOfDetectedFeaturesMeasured {get;set;} = false;

			[Required()]
			public Boolean significantFeaturesDetected {get;set;} = false;

			public decimal? sizeOfFeaturesDetected {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class fixedDateRange {
			public DateOnly? dateEnd {get;set;} = default;

			public DateOnly? dateStart {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class frequencyPair {
			public int? frequencyShoreStationReceives {get;set;} = default;

			[Required()]
			public int frequencyShoreStationTransmits {get;set;}
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class horizontalClearanceFixed {
			[Required()]
			public decimal horizontalClearanceValue {get;set;}

			public decimal? horizontalDistanceUncertainty {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class horizontalClearanceOpen {
			[Required()]
			public decimal horizontalClearanceValue {get;set;}

			public decimal? horizontalDistanceUncertainty {get;set;} = default;
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

			public String? headline {get;set;} = default;

			public String language {get;set;} = string.Empty;

			public String? text {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class measuredDistanceValue {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[Required()]
			public distanceUnitOfMeasurement distanceUnitOfMeasurement {get;set;}

			public String? referenceLocation {get;set;} = default;

			[Required()]
			public decimal waterwayDistance {get;set;}
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class multiplicityOfFeatures {
			[Required()]
			public Boolean multiplicityKnown {get;set;} = false;

			public int? numberOfFeatures {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class onlineResource {
			public String? headline {get;set;} = default;

			public String linkage {get;set;} = string.Empty;

			public String? nameOfResource {get;set;} = default;
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
			public DateOnly dateEnd {get;set;}

			[Required()]
			public DateOnly dateStart {get;set;}
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

			public String text {get;set;} = string.Empty;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class sectorLimitOne {
			[Required()]
			public decimal sectorBearing {get;set;}

			public decimal? sectorLineLength {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class sectorLimitTwo {
			[Required()]
			public decimal sectorBearing {get;set;}

			public decimal? sectorLineLength {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class shapeInformation {
			public String? language {get;set;} = default;

			public String text {get;set;} = string.Empty;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class signalSequence {
			[Required()]
			public decimal signalDuration {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[Required()]
			public signalStatus signalStatus {get;set;}
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class speed {
			[Required()]
			public decimal speedMaximum {get;set;}

			public decimal? speedMinimum {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class surfaceCharacteristics {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			public List<natureOfSurfaceQualifyingTerms> natureOfSurfaceQualifyingTerms {get;set;} = [];

			public int? underlyingLayer {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class surveyDateRange {
			[Required()]
			public DateOnly dateEnd {get;set;}

			public DateOnly? dateStart {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class telecommunications {
			public String? contactInstructions {get;set;} = default;

			public String telecommunicationIdentifier {get;set;} = string.Empty;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public telecommunicationService? telecommunicationService {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class tidalStreamValue {
			[Required()]
			public orientation orientation {get;set;}

			[Required()]
			public decimal speedMaximum {get;set;}

			[Required()]
			public decimal timeRelativeToTide {get;set;}
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class timeIntervalsByDayOfWeek {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<dayOfWeek> dayOfWeek {get;set;} = [];

			public Boolean? dayOfWeekIsRange {get;set;} = default;

			public List<TimeOnly> timeOfDayStart {get;set;} = [];

			public List<TimeOnly> timeOfDayEnd {get;set;} = [];
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class topmark {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			[Required()]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}

			public List<shapeInformation> shapeInformation {get;set;} = [];
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class valueOfLocalMagneticAnomaly {
			[Required()]
			public decimal magneticAnomalyValue {get;set;}

			[EnumerationValue(5)]
			[EnumerationValue(13)]
			public referenceDirection? referenceDirection {get;set;} = default;
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
	public class vesselSpeedLimit {
			[Required()]
			public decimal speedLimit {get;set;}

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public speedUnits speedUnits {get;set;}

			public String? vesselClass {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class zoneOfConfidence {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[Required()]
			public categoryOfZoneOfConfidenceInData categoryOfZoneOfConfidenceInData {get;set;}

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class directionalCharacter {
			public Boolean? moireEffect {get;set;} = default;

			[Required()]
			public orientation orientation {get;set;}
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class rhythmOfLight {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[Required()]
			public lightCharacteristic lightCharacteristic {get;set;}

			public List<String> signalGroup {get;set;} = [];

			public decimal? signalPeriod {get;set;} = default;

			public List<signalSequence> signalSequence {get;set;} = [];
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class scheduleByDayOfWeek {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public categoryOfSchedule? categoryOfSchedule {get;set;} = default;

			public List<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek {get;set;} = [];
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

			public horizontalPositionUncertainty? horizontalPositionUncertainty {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class tidalStreamPanelValues {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[Required()]
			public referenceTide referenceTide {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[Required()]
			public referenceTideType referenceTideType {get;set;}

			public decimal? streamDepth {get;set;} = default;

			public List<tidalStreamValue> tidalStreamValue {get;set;} = [];
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class verticalClearanceClosed {
			[Required()]
			public decimal verticalClearanceValue {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class verticalClearanceFixed {
			[Required()]
			public decimal verticalClearanceValue {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class verticalClearanceOpen {
			[Required()]
			public Boolean verticalClearanceUnlimited {get;set;} = false;

			public decimal? verticalClearanceValue {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class verticalClearanceSafe {
			[Required()]
			public decimal verticalClearanceValue {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class lightSector {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			public List<colour> colour {get;set;} = [];

			public directionalCharacter? directionalCharacter {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			public sectorLimit? sectorLimit {get;set;} = default;

			public decimal? valueOfNominalRange {get;set;} = default;

			public List<sectorInformation> sectorInformation {get;set;} = [];

			public Boolean? sectorArcExtension {get;set;} = default;
		}

	[System.Serializable()]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public class sectorCharacteristics {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[Required()]
			public lightCharacteristic lightCharacteristic {get;set;}

			public List<lightSector> lightSector {get;set;} = [];

			public List<String> signalGroup {get;set;} = [];

			public decimal? signalPeriod {get;set;} = default;

			public List<signalSequence> signalSequence {get;set;} = [];
		}

	}
	public enum Role {
		[System.ComponentModel.Description("A pointer to incidental, secondary or supplementary features related to the referenced feature.")]
		theAuxiliaryFeature,
		[System.ComponentModel.Description("A pointer to a specific cartographically positioned location for text.")]
		theCartographicText,
		[System.ComponentModel.Description("A pointer to the aggregate in a whole-part relationship.")]
		theCollection,
		[System.ComponentModel.Description("A pointer to a part in a whole-part relationship.")]
		theComponent,
		[System.ComponentModel.Description("A pointer to the feature(s) supported by a structure feature.")]
		theEquipment,
		[System.ComponentModel.Description("A pointer to an object that provides more information about the referencing feature or information type.")]
		theInformation,
		[System.ComponentModel.Description("A pointer to a specific feature(s).")]
		thePositionProvider,
		[System.ComponentModel.Description("A pointer to a feature to which incidental, secondary or supplementary features are related.")]
		thePrimaryFeature,
		[System.ComponentModel.Description("A pointer to an information type providing spatial quality information.")]
		theQualityInformation,
		[System.ComponentModel.Description("A pointer to a supported roofed structure.")]
		theRoofedStructure,
		[System.ComponentModel.Description("A pointer to the feature that equipment feature(s) are supported by.")]
		theStructure,
		[System.ComponentModel.Description("A pointer to the feature(s) that support a structure.")]
		theSupport,
		[System.ComponentModel.Description("A pointer to a feature that describes changes made to a dataset.")]
		theUpdate,
		[System.ComponentModel.Description("A pointer to a feature that has been updated.")]
		theUpdatedObject,
	}

	namespace InformationAssociations {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AdditionalInformation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(AdditionalInformation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfBathymetricDataComposition : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(QualityOfBathymetricDataComposition);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialAssociation : InformationAssociation {
			[JsonIgnore]
			public override string Code => nameof(SpatialAssociation);
		}
	}

	namespace FeatureAssociations {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AidsToNavigationAssociation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(AidsToNavigationAssociation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ASLAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(ASLAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BridgeAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(BridgeAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CautionAreaAssociation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(CautionAreaAssociation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DeepWaterRouteAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(DeepWaterRouteAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FairwayAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(FairwayAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FairwayAuxiliary : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(FairwayAuxiliary);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IslandAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(IslandAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringTrotAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(MooringTrotAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotageDistrictAssociation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(PilotageDistrictAssociation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RangeSystemAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(RangeSystemAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RoofedStructureAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(RoofedStructureAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StructureEquipment : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(StructureEquipment);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextAssociation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(TextAssociation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(TrafficSeparationSchemeAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TwoWayRouteAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(TwoWayRouteAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UpdateAggregation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(UpdateAggregation);
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UpdatedInformation : FeatureAssociation {
			[JsonIgnore]
			public override string Code => nameof(UpdatedInformation);
		}
	}

}

namespace S100Framework.DomainModel.S101 {
	using ComplexAttributes;
	using InformationAssociations;

	namespace InformationTypes {
		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContactDetails : InformationNode, IInformationBindingDefinition {
			public String? callSign {get;set;} = default;

			public List<String> communicationChannel {get;set;} = [];

			public String? contactInstructions {get;set;} = default;

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public List<frequencyPair> frequencyPair {get;set;} = [];

			public String? mMSICode {get;set;} = default;

			public List<onlineResource> onlineResource {get;set;} = [];

			public List<telecommunications> telecommunications {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ContactDetails);

			public informationBindingDefinition[] informationBindingDefinitions => ContactDetails._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ServiceHours : InformationNode, IInformationBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public List<scheduleByDayOfWeek> scheduleByDayOfWeek {get;set;} = [];

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ServiceHours);

			public informationBindingDefinition[] informationBindingDefinitions => ServiceHours._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NonStandardWorkingDay : InformationNode, IInformationBindingDefinition {
			public List<DateOnly> dateFixed {get;set;} = [];

			public List<String> dateVariable {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(NonStandardWorkingDay);

			public informationBindingDefinition[] informationBindingDefinitions => NonStandardWorkingDay._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NauticalInformation : InformationNode, IInformationBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(NauticalInformation);

			public informationBindingDefinition[] informationBindingDefinitions => NauticalInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpatialQuality : InformationNode, IInformationBindingDefinition {
			[EnumerationValue(4)]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			public List<spatialAccuracy> spatialAccuracy {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SpatialQuality);

			public informationBindingDefinition[] informationBindingDefinitions => SpatialQuality._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];
		}
	}
	namespace FeatureTypes {
		using FeatureAssociations;
		using InformationTypes;

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfNonBathymetricData : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(4)]
			public categoryOfTemporalVariation? categoryOfTemporalVariation {get;set;} = default;

			public decimal? horizontalDistanceUncertainty {get;set;} = default;

			[Required()]
			public horizontalPositionUncertainty horizontalPositionUncertainty {get;set;}

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? orientationUncertainty {get;set;} = default;

			public surveyDateRange? surveyDateRange {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(QualityOfNonBathymetricData);

			public informationBindingDefinition[] informationBindingDefinitions => QualityOfNonBathymetricData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => QualityOfNonBathymetricData._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DataCoverage : FeatureNode, IFeatureBindingDefinition {
			public int? drawingIndex {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public int maximumDisplayScale {get;set;}

			[Required()]
			public int minimumDisplayScale {get;set;}

			[Required()]
			public int optimumDisplayScale {get;set;}

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DataCoverage);

			public informationBindingDefinition[] informationBindingDefinitions => DataCoverage._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => DataCoverage._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationalSystemOfMarks : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			[Required()]
			public marksNavigationalSystemOf marksNavigationalSystemOf {get;set;}

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(NavigationalSystemOfMarks);

			public informationBindingDefinition[] informationBindingDefinitions => NavigationalSystemOfMarks._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => NavigationalSystemOfMarks._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocalDirectionOfBuoyage : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			[Required()]
			public marksNavigationalSystemOf marksNavigationalSystemOf {get;set;}

			[Required()]
			public decimal orientationValue {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LocalDirectionOfBuoyage);

			public informationBindingDefinition[] informationBindingDefinitions => LocalDirectionOfBuoyage._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => LocalDirectionOfBuoyage._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfBathymetricData : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[Required()]
			public categoryOfTemporalVariation categoryOfTemporalVariation {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[Required()]
			public dataAssessment dataAssessment {get;set;}

			public decimal? depthRangeMaximumValue {get;set;} = default;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			[Required()]
			public featuresDetected featuresDetected {get;set;}

			[Required()]
			public Boolean fullSeafloorCoverageAchieved {get;set;} = false;

			public String? interoperabilityIdentifier {get;set;} = default;

			public surveyDateRange? surveyDateRange {get;set;} = default;

			public List<zoneOfConfidence> zoneOfConfidence {get;set;} = [];

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(QualityOfBathymetricData);

			public informationBindingDefinition[] informationBindingDefinitions => QualityOfBathymetricData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(QualityOfBathymetricDataComposition),
					role = Enum.GetName<Role>(Role.theQualityInformation)!,
					informationTypes = [nameof(SpatialQuality)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => QualityOfBathymetricData._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SoundingDatum : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(19)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(44)]
			[Required()]
			public verticalDatum verticalDatum {get;set;}

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SoundingDatum);

			public informationBindingDefinition[] informationBindingDefinitions => SoundingDatum._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => SoundingDatum._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VerticalDatumOfData : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			[Required()]
			public verticalDatum verticalDatum {get;set;}

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(VerticalDatumOfData);

			public informationBindingDefinition[] informationBindingDefinitions => VerticalDatumOfData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => VerticalDatumOfData._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class QualityOfSurvey : FeatureNode, IFeatureBindingDefinition {
			public decimal? depthRangeMaximumValue {get;set;} = default;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public featuresDetected? featuresDetected {get;set;} = default;

			public Boolean? fullSeafloorCoverageAchieved {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? lineSpacingMaximum {get;set;} = default;

			public int? lineSpacingMinimum {get;set;} = default;

			public int? measurementDistanceMaximum {get;set;} = default;

			public int? measurementDistanceMinimum {get;set;} = default;

			[EnumerationValue(4)]
			public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public int? scaleValueMaximum {get;set;} = default;

			public int? scaleValueMinimum {get;set;} = default;

			public String surveyAuthority {get;set;} = string.Empty;

			[Required()]
			public surveyDateRange surveyDateRange {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<surveyType> surveyType {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(QualityOfSurvey);

			public informationBindingDefinition[] informationBindingDefinitions => QualityOfSurvey._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => QualityOfSurvey._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UpdateInformation : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public int updateNumber {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public updateType updateType {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public String? source {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(UpdateInformation);

			public informationBindingDefinition[] informationBindingDefinitions => UpdateInformation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => UpdateInformation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdateAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(UpdateAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdatedObject)!,
					featureTypes = [nameof(AdministrationArea),nameof(AirportAirfield),nameof(AnchorBerth),nameof(AnchorageArea),nameof(ArchipelagicSeaLane),nameof(ArchipelagicSeaLaneArea),nameof(ArchipelagicSeaLaneAxis),nameof(Berth),nameof(Bollard),nameof(Bridge),nameof(Building),nameof(BuiltUpArea),nameof(CableArea),nameof(CableOverhead),nameof(CableSubmarine),nameof(Canal),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(CargoTranshipmentArea),nameof(Causeway),nameof(CautionArea),nameof(Checkpoint),nameof(CoastGuardStation),nameof(Coastline),nameof(CollisionRegulationsLimit),nameof(ContiguousZone),nameof(ContinentalShelfArea),nameof(Conveyor),nameof(Crane),nameof(CurrentNonGravitational),nameof(CustomZone),nameof(Dam),nameof(Daymark),nameof(DeepWaterRoute),nameof(DeepWaterRouteCentreline),nameof(DeepWaterRoutePart),nameof(DepthArea),nameof(DepthContour),nameof(DepthNoBottomFound),nameof(DiscolouredWater),nameof(DistanceMark),nameof(DockArea),nameof(Dolphin),nameof(DredgedArea),nameof(DryDock),nameof(DumpingGround),nameof(Dyke),nameof(EmergencyWreckMarkingBuoy),nameof(ExclusiveEconomicZone),nameof(Fairway),nameof(FairwaySystem),nameof(FenceWall),nameof(FerryRoute),nameof(FisheryZone),nameof(FishingFacility),nameof(FishingGround),nameof(FloatingDock),nameof(FogSignal),nameof(FortifiedStructure),nameof(FoulGround),nameof(FreePortArea),nameof(Gate),nameof(Gridiron),nameof(HarbourAreaAdministrative),nameof(HarbourFacility),nameof(Helipad),nameof(Hulk),nameof(IceArea),nameof(InformationArea),nameof(InshoreTrafficZone),nameof(InstallationBuoy),nameof(IslandGroup),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Lake),nameof(LandArea),nameof(LandElevation),nameof(LandRegion),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightAirObstruction),nameof(LightAllAround),nameof(LightFloat),nameof(LightFogDetector),nameof(LightSectored),nameof(LightVessel),nameof(LocalDirectionOfBuoyage),nameof(LocalMagneticAnomaly),nameof(LockBasin),nameof(LogPond),nameof(MagneticVariation),nameof(MarineFarmCulture),nameof(MarinePollutionRegulationsArea),nameof(MilitaryPracticeArea),nameof(MooringArea),nameof(MooringBuoy),nameof(MooringTrot),nameof(NavigationLine),nameof(NavigationalSystemOfMarks),nameof(Obstruction),nameof(OffshorePlatform),nameof(OffshoreProductionArea),nameof(OilBarrier),nameof(PhysicalAISAidToNavigation),nameof(Pile),nameof(PilotBoardingPlace),nameof(PilotageDistrict),nameof(PipelineOverhead),nameof(PipelineSubmarineOnLand),nameof(Pontoon),nameof(PrecautionaryArea),nameof(ProductionStorageArea),nameof(PylonBridgeSupport),nameof(QualityOfBathymetricData),nameof(QualityOfNonBathymetricData),nameof(QualityOfSurvey),nameof(RadarLine),nameof(RadarRange),nameof(RadarReflector),nameof(RadarStation),nameof(RadarTransponderBeacon),nameof(RadioCallingInPoint),nameof(RadioStation),nameof(Railway),nameof(RangeSystem),nameof(Rapids),nameof(RecommendedRouteCentreline),nameof(RecommendedTrack),nameof(RecommendedTrafficLanePart),nameof(RescueStation),nameof(RestrictedArea),nameof(Retroreflector),nameof(River),nameof(Road),nameof(Runway),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(Sandwave),nameof(SeaAreaNamedWaterArea),nameof(SeabedArea),nameof(Seagrass),nameof(SeaplaneLandingArea),nameof(SeparationZoneOrLine),nameof(ShorelineConstruction),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(SiloTank),nameof(SmallCraftFacility),nameof(SlopeTopline),nameof(SlopingGround),nameof(Sounding),nameof(SoundingDatum),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(Spring),nameof(StraightTerritorialSeaBaseline),nameof(StructureOverNavigableWater),nameof(SubmarinePipelineArea),nameof(SubmarineTransitLane),nameof(SweptArea),nameof(TerritorialSeaArea),nameof(TidalStreamPanelData),nameof(TidalStreamFloodEbb),nameof(Tideway),nameof(TrafficSeparationScheme),nameof(TrafficSeparationSchemeBoundary),nameof(TrafficSeparationSchemeCrossing),nameof(TrafficSeparationSchemeLanePart),nameof(TrafficSeparationSchemeRoundabout),nameof(Tunnel),nameof(TwoWayRoute),nameof(TwoWayRoutePart),nameof(UnderwaterAwashRock),nameof(UnsurveyedArea),nameof(UpdateInformation),nameof(Vegetation),nameof(VerticalDatumOfData),nameof(VesselTrafficServiceArea),nameof(VirtualAISAidToNavigation),nameof(WaterTurbulence),nameof(Waterfall),nameof(WeedKelp),nameof(WindTurbine),nameof(Wreck)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MagneticVariation : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public DateOnly referenceYearForMagneticVariation {get;set;}

			[Required()]
			public decimal valueOfAnnualChangeInMagneticVariation {get;set;}

			[Required()]
			public decimal valueOfMagneticVariation {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(MagneticVariation);

			public informationBindingDefinition[] informationBindingDefinitions => MagneticVariation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => MagneticVariation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LocalMagneticAnomaly : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			public List<valueOfLocalMagneticAnomaly> valueOfLocalMagneticAnomaly {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LocalMagneticAnomaly);

			public informationBindingDefinition[] informationBindingDefinitions => LocalMagneticAnomaly._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LocalMagneticAnomaly._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Coastline : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(10)]
			public categoryOfCoastline? categoryOfCoastline {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(17)]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Coastline);

			public informationBindingDefinition[] informationBindingDefinitions => Coastline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Coastline._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LandArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(18)]
			public status? status {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LandArea);

			public informationBindingDefinition[] informationBindingDefinitions => LandArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LandArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(IslandAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(IslandGroup)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IslandGroup : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(IslandGroup);

			public informationBindingDefinition[] informationBindingDefinitions => IslandGroup._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => IslandGroup._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(IslandAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(LandArea),nameof(IslandGroup)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(IslandAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(IslandGroup)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LandElevation : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public decimal elevation {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LandElevation);

			public informationBindingDefinition[] informationBindingDefinitions => LandElevation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LandElevation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class River : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(5)]
			public status? status {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(River);

			public informationBindingDefinition[] informationBindingDefinitions => River._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => River._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Rapids : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Rapids);

			public informationBindingDefinition[] informationBindingDefinitions => Rapids._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Rapids._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Waterfall : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Waterfall);

			public informationBindingDefinition[] informationBindingDefinitions => Waterfall._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Waterfall._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Lake : FeatureNode, IFeatureBindingDefinition {
			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(5)]
			public status? status {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Lake);

			public informationBindingDefinition[] informationBindingDefinitions => Lake._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Lake._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LandRegion : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			public List<categoryOfLandRegion> categoryOfLandRegion {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(6)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LandRegion);

			public informationBindingDefinition[] informationBindingDefinitions => LandRegion._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LandRegion._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Vegetation : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(11)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(22)]
			[Required()]
			public categoryOfVegetation categoryOfVegetation {get;set;}

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Vegetation);

			public informationBindingDefinition[] informationBindingDefinitions => Vegetation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Vegetation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IceArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[Required()]
			public categoryOfIce categoryOfIce {get;set;}

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(IceArea);

			public informationBindingDefinition[] informationBindingDefinitions => IceArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => IceArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SlopingGround : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public categoryOfSlope? categoryOfSlope {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SlopingGround);

			public informationBindingDefinition[] informationBindingDefinitions => SlopingGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SlopingGround._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SlopeTopline : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			public categoryOfSlope? categoryOfSlope {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SlopeTopline);

			public informationBindingDefinition[] informationBindingDefinitions => SlopeTopline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SlopeTopline._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Tideway : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Tideway);

			public informationBindingDefinition[] informationBindingDefinitions => Tideway._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Tideway._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class BuiltUpArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public categoryOfBuiltUpArea? categoryOfBuiltUpArea {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			public Boolean? inTheWater {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(BuiltUpArea);

			public informationBindingDefinition[] informationBindingDefinitions => BuiltUpArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => BuiltUpArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Building : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public buildingShape? buildingShape {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			[EnumerationValue(34)]
			[EnumerationValue(35)]
			[EnumerationValue(36)]
			[EnumerationValue(37)]
			[EnumerationValue(38)]
			[EnumerationValue(39)]
			[EnumerationValue(40)]
			[EnumerationValue(41)]
			[EnumerationValue(42)]
			[EnumerationValue(44)]
			[EnumerationValue(45)]
			[EnumerationValue(46)]
			[EnumerationValue(47)]
			[EnumerationValue(48)]
			public List<function> function {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			public Boolean? inTheWater {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Building);

			public informationBindingDefinition[] informationBindingDefinitions => Building._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Building._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(Helipad),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AirportAirfield : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<categoryOfAirportAirfield> categoryOfAirportAirfield {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(AirportAirfield);

			public informationBindingDefinition[] informationBindingDefinitions => AirportAirfield._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => AirportAirfield._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Runway : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Runway);

			public informationBindingDefinition[] informationBindingDefinitions => Runway._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Runway._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Helipad : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Helipad);

			public informationBindingDefinition[] informationBindingDefinitions => Helipad._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Helipad._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Building),nameof(Landmark),nameof(OffshorePlatform)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bridge : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public bridgeConstruction? bridgeConstruction {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public List<bridgeFunction> bridgeFunction {get;set;} = [];

			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			public categoryOfOpeningBridge? categoryOfOpeningBridge {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? openingBridge {get;set;} = default;

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Bridge);

			public informationBindingDefinition[] informationBindingDefinitions => Bridge._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Bridge._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(BridgeAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(SpanFixed),nameof(SpanOpening),nameof(Pontoon),nameof(PylonBridgeSupport)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpanFixed : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public verticalClearanceFixed verticalClearanceFixed {get;set;}

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SpanFixed);

			public informationBindingDefinition[] informationBindingDefinitions => SpanFixed._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SpanFixed._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(BridgeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(Bridge)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpanOpening : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public verticalClearanceClosed verticalClearanceClosed {get;set;}

			[Required()]
			public verticalClearanceOpen verticalClearanceOpen {get;set;}

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SpanOpening);

			public informationBindingDefinition[] informationBindingDefinitions => SpanOpening._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SpanOpening._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(BridgeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(Bridge)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Conveyor : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public categoryOfConveyor? categoryOfConveyor {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? liftingCapacity {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(25)]
			public List<product> product {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Conveyor);

			public informationBindingDefinition[] informationBindingDefinitions => Conveyor._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Conveyor._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableOverhead : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(10)]
			public categoryOfCable? categoryOfCable {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? iceFactor {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(12)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			public verticalClearanceSafe? verticalClearanceSafe {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CableOverhead);

			public informationBindingDefinition[] informationBindingDefinitions => CableOverhead._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CableOverhead._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(RadarReflector)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PipelineOverhead : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			public categoryOfPipelinePipe? categoryOfPipelinePipe {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(22)]
			public List<product> product {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(PipelineOverhead);

			public informationBindingDefinition[] informationBindingDefinitions => PipelineOverhead._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => PipelineOverhead._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(RadarReflector)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PylonBridgeSupport : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[Required()]
			public categoryOfPylon categoryOfPylon {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(PylonBridgeSupport);

			public informationBindingDefinition[] informationBindingDefinitions => PylonBridgeSupport._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => PylonBridgeSupport._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(BridgeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(Bridge)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RoofedStructureAggregation),
					role = Enum.GetName<Role>(Role.theRoofedStructure)!,
					featureTypes = [nameof(StructureOverNavigableWater)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(Bollard),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FenceWall : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public categoryOfFence? categoryOfFence {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(7)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FenceWall);

			public informationBindingDefinition[] informationBindingDefinitions => FenceWall._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FenceWall._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Railway : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Railway);

			public informationBindingDefinition[] informationBindingDefinitions => Railway._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Railway._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Road : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public categoryOfRoad? categoryOfRoad {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Road);

			public informationBindingDefinition[] informationBindingDefinitions => Road._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Road._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Tunnel : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Tunnel);

			public informationBindingDefinition[] informationBindingDefinitions => Tunnel._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Tunnel._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Landmark : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			public List<categoryOfLandmark> categoryOfLandmark {get;set;} = [];

			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(41)]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			[EnumerationValue(34)]
			[EnumerationValue(35)]
			[EnumerationValue(36)]
			[EnumerationValue(37)]
			[EnumerationValue(38)]
			[EnumerationValue(39)]
			[EnumerationValue(40)]
			[EnumerationValue(41)]
			[EnumerationValue(42)]
			[EnumerationValue(44)]
			[EnumerationValue(45)]
			[EnumerationValue(46)]
			[EnumerationValue(47)]
			[EnumerationValue(48)]
			public List<function> function {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[Required()]
			public visualProminence visualProminence {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			public Boolean? inTheWater {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Landmark);

			public informationBindingDefinition[] informationBindingDefinitions => Landmark._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Landmark._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(Helipad),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(Bollard),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SiloTank : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public buildingShape? buildingShape {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public categoryOfSiloTank? categoryOfSiloTank {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(24)]
			public List<product> product {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			public Boolean? inTheWater {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SiloTank);

			public informationBindingDefinition[] informationBindingDefinitions => SiloTank._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SiloTank._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WindTurbine : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			[EnumerationValue(2)]
			[EnumerationValue(7)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			public Boolean? inTheWater {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(WindTurbine);

			public informationBindingDefinition[] informationBindingDefinitions => WindTurbine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => WindTurbine._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FortifiedStructure : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public categoryOfFortifiedStructure? categoryOfFortifiedStructure {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			public Boolean? inTheWater {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(FortifiedStructure);

			public informationBindingDefinition[] informationBindingDefinitions => FortifiedStructure._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FortifiedStructure._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(Bollard)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ProductionStorageArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[Required()]
			public categoryOfProductionArea categoryOfProductionArea {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(25)]
			public List<product> product {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(4)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(ProductionStorageArea);

			public informationBindingDefinition[] informationBindingDefinitions => ProductionStorageArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => ProductionStorageArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Checkpoint : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			public categoryOfCheckpoint? categoryOfCheckpoint {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Checkpoint);

			public informationBindingDefinition[] informationBindingDefinitions => Checkpoint._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Checkpoint._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Hulk : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<categoryOfHulk> categoryOfHulk {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Hulk);

			public informationBindingDefinition[] informationBindingDefinitions => Hulk._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Hulk._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(Bollard)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Pile : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public categoryOfPile? categoryOfPile {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Pile);

			public informationBindingDefinition[] informationBindingDefinitions => Pile._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Pile._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(Bollard)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Dyke : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Dyke);

			public informationBindingDefinition[] informationBindingDefinitions => Dyke._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Dyke._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ShorelineConstruction : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(20)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			public categoryOfShorelineConstruction? categoryOfShorelineConstruction {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ShorelineConstruction);

			public informationBindingDefinition[] informationBindingDefinitions => ShorelineConstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => ShorelineConstruction._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(Bollard)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StructureOverNavigableWater : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public List<categoryOfStructure> categoryOfStructure {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			[Required()]
			public horizontalClearanceFixed horizontalClearanceFixed {get;set;}

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(7)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(25)]
			public product? product {get;set;} = default;

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			[Required()]
			public verticalClearanceFixed verticalClearanceFixed {get;set;}

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(StructureOverNavigableWater);

			public informationBindingDefinition[] informationBindingDefinitions => StructureOverNavigableWater._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => StructureOverNavigableWater._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RoofedStructureAggregation),
					role = Enum.GetName<Role>(Role.theSupport)!,
					featureTypes = [nameof(PylonBridgeSupport)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Causeway : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Causeway);

			public informationBindingDefinition[] informationBindingDefinitions => Causeway._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Causeway._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Canal : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public categoryOfCanal? categoryOfCanal {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Canal);

			public informationBindingDefinition[] informationBindingDefinitions => Canal._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Canal._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DistanceMark : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public Boolean distanceMarkVisible {get;set;} = false;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public measuredDistanceValue measuredDistanceValue {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DistanceMark);

			public informationBindingDefinition[] informationBindingDefinitions => DistanceMark._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DistanceMark._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Gate : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public categoryOfGate? categoryOfGate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public horizontalClearanceOpen? horizontalClearanceOpen {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public verticalClearanceOpen? verticalClearanceOpen {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Gate);

			public informationBindingDefinition[] informationBindingDefinitions => Gate._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Gate._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Dam : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public categoryOfDam? categoryOfDam {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Dam);

			public informationBindingDefinition[] informationBindingDefinitions => Dam._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Dam._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Crane : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public categoryOfCrane? categoryOfCrane {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? liftingCapacity {get;set;} = default;

			public orientation? orientation {get;set;} = default;

			public Boolean? radarConspicuous {get;set;} = default;

			public decimal? radius {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public verticalClearanceFixed? verticalClearanceFixed {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			public Boolean? inTheWater {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Crane);

			public informationBindingDefinition[] informationBindingDefinitions => Crane._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Crane._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Berth : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? horizontalClearanceLength {get;set;} = default;

			public decimal? horizontalClearanceWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public decimal? minimumBerthDepth {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Berth);

			public informationBindingDefinition[] informationBindingDefinitions => Berth._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Berth._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(MooringTrotAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(MooringTrot)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Dolphin : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public List<categoryOfDolphin> categoryOfDolphin {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Dolphin);

			public informationBindingDefinition[] informationBindingDefinitions => Dolphin._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Dolphin._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(Bollard)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Bollard : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Bollard);

			public informationBindingDefinition[] informationBindingDefinitions => Bollard._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Bollard._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Dolphin),nameof(FortifiedStructure),nameof(Hulk),nameof(Landmark),nameof(OffshorePlatform),nameof(Pile),nameof(PylonBridgeSupport),nameof(ShorelineConstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DryDock : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? horizontalClearanceLength {get;set;} = default;

			public decimal? horizontalClearanceWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DryDock);

			public informationBindingDefinition[] informationBindingDefinitions => DryDock._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DryDock._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FloatingDock : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? horizontalClearanceLength {get;set;} = default;

			public decimal? horizontalClearanceWidth {get;set;} = default;

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? liftingCapacity {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(FloatingDock);

			public informationBindingDefinition[] informationBindingDefinitions => FloatingDock._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FloatingDock._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Pontoon : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Pontoon);

			public informationBindingDefinition[] informationBindingDefinitions => Pontoon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Pontoon._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(BridgeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(Bridge)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DockArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public categoryOfDock? categoryOfDock {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public decimal? horizontalClearanceLength {get;set;} = default;

			public decimal? horizontalClearanceWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DockArea);

			public informationBindingDefinition[] informationBindingDefinitions => DockArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DockArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Gridiron : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Gridiron);

			public informationBindingDefinition[] informationBindingDefinitions => Gridiron._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Gridiron._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LockBasin : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public horizontalClearanceFixed? horizontalClearanceFixed {get;set;} = default;

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LockBasin);

			public informationBindingDefinition[] informationBindingDefinitions => LockBasin._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LockBasin._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringTrot : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(MooringTrot);

			public informationBindingDefinition[] informationBindingDefinitions => MooringTrot._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => MooringTrot._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(MooringTrotAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(Berth),nameof(CableSubmarine),nameof(MooringBuoy),nameof(Obstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeaAreaNamedWaterArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			[EnumerationValue(34)]
			[EnumerationValue(35)]
			[EnumerationValue(36)]
			[EnumerationValue(37)]
			[EnumerationValue(38)]
			[EnumerationValue(39)]
			[EnumerationValue(40)]
			[EnumerationValue(41)]
			[EnumerationValue(42)]
			[EnumerationValue(43)]
			[EnumerationValue(44)]
			[EnumerationValue(45)]
			[EnumerationValue(46)]
			[EnumerationValue(47)]
			[EnumerationValue(48)]
			[EnumerationValue(49)]
			[EnumerationValue(50)]
			[EnumerationValue(51)]
			[EnumerationValue(52)]
			[EnumerationValue(53)]
			[EnumerationValue(54)]
			[EnumerationValue(55)]
			[EnumerationValue(56)]
			public categoryOfSeaArea? categoryOfSeaArea {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SeaAreaNamedWaterArea);

			public informationBindingDefinition[] informationBindingDefinitions => SeaAreaNamedWaterArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SeaAreaNamedWaterArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TidalStreamFloodEbb : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[Required()]
			public categoryOfTidalStream categoryOfTidalStream {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public orientation orientation {get;set;}

			[Required()]
			public speed speed {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TidalStreamFloodEbb);

			public informationBindingDefinition[] informationBindingDefinitions => TidalStreamFloodEbb._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TidalStreamFloodEbb._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CurrentNonGravitational : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public orientation orientation {get;set;}

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[Required()]
			public speed speed {get;set;}

			[EnumerationValue(5)]
			public status? status {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CurrentNonGravitational);

			public informationBindingDefinition[] informationBindingDefinitions => CurrentNonGravitational._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CurrentNonGravitational._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WaterTurbulence : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[Required()]
			public categoryOfWaterTurbulence categoryOfWaterTurbulence {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(WaterTurbulence);

			public informationBindingDefinition[] informationBindingDefinitions => WaterTurbulence._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => WaterTurbulence._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TidalStreamPanelData : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public String stationName {get;set;} = string.Empty;

			public String? stationNumber {get;set;} = default;

			public List<tidalStreamPanelValues> tidalStreamPanelValues {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TidalStreamPanelData);

			public informationBindingDefinition[] informationBindingDefinitions => TidalStreamPanelData._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TidalStreamPanelData._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Sounding : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(18)]
			public status? status {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Sounding);

			public informationBindingDefinition[] informationBindingDefinitions => Sounding._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Sounding._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DredgedArea : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public decimal depthRangeMinimumValue {get;set;}

			public decimal? depthRangeMaximumValue {get;set;} = default;

			public DateOnly? dredgedDate {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			[EnumerationValue(10)]
			[EnumerationValue(11)]
			public qualityOfVerticalMeasurement? qualityOfVerticalMeasurement {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(23)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DredgedArea);

			public informationBindingDefinition[] informationBindingDefinitions => DredgedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DredgedArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SweptArea : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public decimal depthRangeMinimumValue {get;set;}

			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? sweptDate {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SweptArea);

			public informationBindingDefinition[] informationBindingDefinitions => SweptArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SweptArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DepthContour : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public decimal valueOfDepthContour {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DepthContour);

			public informationBindingDefinition[] informationBindingDefinitions => DepthContour._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DepthContour._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DepthArea : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public decimal depthRangeMinimumValue {get;set;}

			[Required()]
			public decimal depthRangeMaximumValue {get;set;}

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DepthArea);

			public informationBindingDefinition[] informationBindingDefinitions => DepthArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DepthArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DepthNoBottomFound : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DepthNoBottomFound);

			public informationBindingDefinition[] informationBindingDefinitions => DepthNoBottomFound._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DepthNoBottomFound._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UnsurveyedArea : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(UnsurveyedArea);

			public informationBindingDefinition[] informationBindingDefinitions => UnsurveyedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => UnsurveyedArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeabedArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<surfaceCharacteristics> surfaceCharacteristics {get;set;} = [];

			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SeabedArea);

			public informationBindingDefinition[] informationBindingDefinitions => SeabedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SeabedArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class WeedKelp : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			public categoryOfWeedKelp? categoryOfWeedKelp {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(WeedKelp);

			public informationBindingDefinition[] informationBindingDefinitions => WeedKelp._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => WeedKelp._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Seagrass : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Seagrass);

			public informationBindingDefinition[] informationBindingDefinitions => Seagrass._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Seagrass._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Sandwave : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Sandwave);

			public informationBindingDefinition[] informationBindingDefinitions => Sandwave._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Sandwave._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Spring : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Spring);

			public informationBindingDefinition[] informationBindingDefinitions => Spring._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Spring._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class UnderwaterAwashRock : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(14)]
			public natureOfSurface? natureOfSurface {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(18)]
			public status? status {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[Required()]
			public decimal valueOfSounding {get;set;}

			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public decimal? defaultClearanceDepth {get;set;} = default;

			[Required()]
			public decimal surroundingDepth {get;set;}

			[JsonIgnore]
			public override string Code => nameof(UnderwaterAwashRock);

			public informationBindingDefinition[] informationBindingDefinitions => UnderwaterAwashRock._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => UnderwaterAwashRock._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Wreck : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public categoryOfWreck? categoryOfWreck {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(7)]
			[EnumerationValue(13)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public decimal? valueOfSounding {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			public decimal? defaultClearanceDepth {get;set;} = default;

			[Required()]
			public decimal surroundingDepth {get;set;}

			[JsonIgnore]
			public override string Code => nameof(Wreck);

			public informationBindingDefinition[] informationBindingDefinitions => Wreck._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Wreck._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Obstruction : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			public categoryOfObstruction? categoryOfObstruction {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<natureOfSurface> natureOfSurface {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(8)]
			[EnumerationValue(23)]
			public List<product> product {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(13)]
			[EnumerationValue(18)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public decimal? valueOfSounding {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public decimal? defaultClearanceDepth {get;set;} = default;

			[Required()]
			public decimal surroundingDepth {get;set;}

			[JsonIgnore]
			public override string Code => nameof(Obstruction);

			public informationBindingDefinition[] informationBindingDefinitions => Obstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Obstruction._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(MooringTrotAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(MooringTrot)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FoulGround : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(13)]
			[EnumerationValue(18)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			public decimal? valueOfSounding {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FoulGround);

			public informationBindingDefinition[] informationBindingDefinitions => FoulGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FoulGround._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DiscolouredWater : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DiscolouredWater);

			public informationBindingDefinition[] informationBindingDefinitions => DiscolouredWater._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DiscolouredWater._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FishingFacility : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public categoryOfFishingFacility? categoryOfFishingFacility {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(18)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FishingFacility);

			public informationBindingDefinition[] informationBindingDefinitions => FishingFacility._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FishingFacility._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MarineFarmCulture : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public categoryOfMarineFarmCulture? categoryOfMarineFarmCulture {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public expositionOfSounding? expositionOfSounding {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public decimal? valueOfSounding {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[Required()]
			public waterLevelEffect waterLevelEffect {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(MarineFarmCulture);

			public informationBindingDefinition[] informationBindingDefinitions => MarineFarmCulture._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => MarineFarmCulture._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OffshorePlatform : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			public categoryOfOffshorePlatform? categoryOfOffshorePlatform {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public Boolean? flareStack {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(23)]
			public List<product> product {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(OffshorePlatform);

			public informationBindingDefinition[] informationBindingDefinitions => OffshorePlatform._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => OffshorePlatform._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(Helipad),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored),nameof(Bollard),nameof(LightAirObstruction)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableSubmarine : FeatureNode, IFeatureBindingDefinition {
			public decimal? buriedDepth {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			public categoryOfCable? categoryOfCable {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(13)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CableSubmarine);

			public informationBindingDefinition[] informationBindingDefinitions => CableSubmarine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CableSubmarine._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(MooringTrotAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(MooringTrot)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CableArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(7)]
			[EnumerationValue(10)]
			public List<categoryOfCable> categoryOfCable {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(20)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(7)]
			[EnumerationValue(13)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CableArea);

			public informationBindingDefinition[] informationBindingDefinitions => CableArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CableArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PipelineSubmarineOnLand : FeatureNode, IFeatureBindingDefinition {
			public decimal? buriedDepth {get;set;} = default;

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<categoryOfPipelinePipe> categoryOfPipelinePipe {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public decimal? depthRangeMaximumValue {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			public List<product> product {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(20)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(PipelineSubmarineOnLand);

			public informationBindingDefinition[] informationBindingDefinitions => PipelineSubmarineOnLand._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => PipelineSubmarineOnLand._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SubmarinePipelineArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public List<categoryOfPipelinePipe> categoryOfPipelinePipe {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			public List<product> product {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SubmarinePipelineArea);

			public informationBindingDefinition[] informationBindingDefinitions => SubmarinePipelineArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SubmarinePipelineArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OffshoreProductionArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public categoryOfOffshoreProductionArea? categoryOfOffshoreProductionArea {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(10)]
			[EnumerationValue(14)]
			[EnumerationValue(23)]
			public List<product> product {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			public waterLevelEffect? waterLevelEffect {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(OffshoreProductionArea);

			public informationBindingDefinition[] informationBindingDefinitions => OffshoreProductionArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => OffshoreProductionArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class NavigationLine : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[Required()]
			public categoryOfNavigationLine categoryOfNavigationLine {get;set;}

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? measuredDistance {get;set;} = default;

			[Required()]
			public orientation orientation {get;set;}

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(NavigationLine);

			public informationBindingDefinition[] informationBindingDefinitions => NavigationLine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => NavigationLine._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RecommendedTrack : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public Boolean basedOnFixedMarks {get;set;} = false;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			[Required()]
			public decimal orientationValue {get;set;}

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RecommendedTrack);

			public informationBindingDefinition[] informationBindingDefinitions => RecommendedTrack._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RecommendedTrack._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RangeSystem : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RangeSystem);

			public informationBindingDefinition[] informationBindingDefinitions => RangeSystem._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RangeSystem._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(CardinalBeacon),nameof(Building),nameof(Daymark),nameof(Dolphin),nameof(FortifiedStructure),nameof(IsolatedDangerBeacon),nameof(Landmark),nameof(LateralBeacon),nameof(LightAllAround),nameof(LightSectored),nameof(NavigationLine),nameof(Pile),nameof(RadarTransponderBeacon),nameof(RangeSystem),nameof(RecommendedRouteCentreline),nameof(RecommendedTrack),nameof(SafeWaterBeacon),nameof(SiloTank),nameof(SpecialPurposeGeneralBeacon)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Fairway : FeatureNode, IFeatureBindingDefinition {
			public decimal? depthRangeMinimumValue {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public decimal? orientationValue {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public trafficFlow? trafficFlow {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Fairway);

			public informationBindingDefinition[] informationBindingDefinitions => Fairway._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Fairway._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(FairwaySystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.theAuxiliaryFeature)!,
					featureTypes = [nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(CautionArea),nameof(Daymark),nameof(DredgedArea),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(Landmark),nameof(Pile),nameof(RangeSystem),nameof(RecommendedRouteCentreline),nameof(RecommendedTrack),nameof(RestrictedArea),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(SweptArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FairwaySystem : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FairwaySystem);

			public informationBindingDefinition[] informationBindingDefinitions => FairwaySystem._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FairwaySystem._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Daymark),nameof(EmergencyWreckMarkingBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(Pile),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(Building),nameof(Crane),nameof(Dolphin),nameof(FishingFacility),nameof(FortifiedStructure),nameof(Landmark),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(SiloTank),nameof(WindTurbine),nameof(Bridge),nameof(Conveyor),nameof(FloatingDock),nameof(Hulk),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(ShorelineConstruction),nameof(SpanFixed),nameof(SpanOpening),nameof(StructureOverNavigableWater)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(FairwayAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RecommendedRouteCentreline : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public Boolean basedOnFixedMarks {get;set;} = false;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? orientationValue {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public trafficFlow? trafficFlow {get;set;} = default;

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RecommendedRouteCentreline);

			public informationBindingDefinition[] informationBindingDefinitions => RecommendedRouteCentreline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RecommendedRouteCentreline._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TwoWayRoutePart : FeatureNode, IFeatureBindingDefinition {
			public Boolean? basedOnFixedMarks {get;set;} = default;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public decimal orientationValue {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TwoWayRoutePart);

			public informationBindingDefinition[] informationBindingDefinitions => TwoWayRoutePart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TwoWayRoutePart._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TwoWayRouteAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TwoWayRoute : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TwoWayRoute);

			public informationBindingDefinition[] informationBindingDefinitions => TwoWayRoute._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TwoWayRoute._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Daymark),nameof(EmergencyWreckMarkingBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(Pile),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(Building),nameof(Crane),nameof(Dolphin),nameof(FishingFacility),nameof(FortifiedStructure),nameof(Landmark),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(SiloTank),nameof(WindTurbine),nameof(Bridge),nameof(Conveyor),nameof(FloatingDock),nameof(Hulk),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(ShorelineConstruction),nameof(SpanFixed),nameof(SpanOpening),nameof(StructureOverNavigableWater)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TwoWayRouteAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(TwoWayRoutePart)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RecommendedTrafficLanePart : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public decimal orientationValue {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RecommendedTrafficLanePart);

			public informationBindingDefinition[] informationBindingDefinitions => RecommendedTrafficLanePart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RecommendedTrafficLanePart._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DeepWaterRouteCentreline : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public Boolean basedOnFixedMarks {get;set;} = false;

			public decimal? depthRangeMinimumValue {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public Boolean? iMOAdopted {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public decimal orientationValue {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DeepWaterRouteCentreline);

			public informationBindingDefinition[] informationBindingDefinitions => DeepWaterRouteCentreline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DeepWaterRouteCentreline._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(DeepWaterRouteAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DeepWaterRoutePart : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public decimal depthRangeMinimumValue {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public Boolean? iMOAdopted {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public decimal orientationValue {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<qualityOfVerticalMeasurement> qualityOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			public List<techniqueOfVerticalMeasurement> techniqueOfVerticalMeasurement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

			public verticalUncertainty? verticalUncertainty {get;set;} = default;

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DeepWaterRoutePart);

			public informationBindingDefinition[] informationBindingDefinitions => DeepWaterRoutePart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DeepWaterRoutePart._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(DeepWaterRouteAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DeepWaterRoute : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public Boolean? iMOAdopted {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DeepWaterRoute);

			public informationBindingDefinition[] informationBindingDefinitions => DeepWaterRoute._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DeepWaterRoute._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Daymark),nameof(EmergencyWreckMarkingBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(Pile),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(Building),nameof(Crane),nameof(Dolphin),nameof(FishingFacility),nameof(FortifiedStructure),nameof(Landmark),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(SiloTank),nameof(WindTurbine)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(DeepWaterRouteAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(DeepWaterRouteCentreline),nameof(DeepWaterRoutePart)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InshoreTrafficZone : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(InshoreTrafficZone);

			public informationBindingDefinition[] informationBindingDefinitions => InshoreTrafficZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => InshoreTrafficZone._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PrecautionaryArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public Boolean? iMOAdopted {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(9)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(PrecautionaryArea);

			public informationBindingDefinition[] informationBindingDefinitions => PrecautionaryArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => PrecautionaryArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeLanePart : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? orientationValue {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TrafficSeparationSchemeLanePart);

			public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeLanePart._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeLanePart._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeparationZoneOrLine : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(9)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SeparationZoneOrLine);

			public informationBindingDefinition[] informationBindingDefinitions => SeparationZoneOrLine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SeparationZoneOrLine._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeBoundary : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(9)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TrafficSeparationSchemeBoundary);

			public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeBoundary._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeBoundary._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeCrossing : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TrafficSeparationSchemeCrossing);

			public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeCrossing._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeCrossing._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationSchemeRoundabout : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TrafficSeparationSchemeRoundabout);

			public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationSchemeRoundabout._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationSchemeRoundabout._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TrafficSeparationScheme : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public Boolean? iMOAdopted {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TrafficSeparationScheme);

			public informationBindingDefinition[] informationBindingDefinitions => TrafficSeparationScheme._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TrafficSeparationScheme._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Daymark),nameof(EmergencyWreckMarkingBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(Pile),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(Building),nameof(Crane),nameof(Dolphin),nameof(FishingFacility),nameof(FortifiedStructure),nameof(Landmark),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(SiloTank),nameof(WindTurbine),nameof(Bridge),nameof(Conveyor),nameof(FloatingDock),nameof(Hulk),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(ShorelineConstruction),nameof(SpanFixed),nameof(SpanOpening),nameof(StructureOverNavigableWater)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(DeepWaterRouteCentreline),nameof(DeepWaterRoutePart),nameof(InshoreTrafficZone),nameof(PrecautionaryArea),nameof(RestrictedArea),nameof(SeparationZoneOrLine),nameof(TrafficSeparationScheme),nameof(TrafficSeparationSchemeBoundary),nameof(TrafficSeparationSchemeCrossing),nameof(TrafficSeparationSchemeLanePart),nameof(TrafficSeparationSchemeRoundabout),nameof(TwoWayRoute),nameof(TwoWayRoutePart)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(CautionAreaAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(CautionArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ArchipelagicSeaLaneArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public String? nationality {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ArchipelagicSeaLaneArea);

			public informationBindingDefinition[] informationBindingDefinitions => ArchipelagicSeaLaneArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => ArchipelagicSeaLaneArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(ASLAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ArchipelagicSeaLaneAxis : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public String? nationality {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ArchipelagicSeaLaneAxis);

			public informationBindingDefinition[] informationBindingDefinitions => ArchipelagicSeaLaneAxis._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => ArchipelagicSeaLaneAxis._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(ASLAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ArchipelagicSeaLane : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public String nationality {get;set;} = string.Empty;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ArchipelagicSeaLane);

			public informationBindingDefinition[] informationBindingDefinitions => ArchipelagicSeaLane._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => ArchipelagicSeaLane._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Daymark),nameof(EmergencyWreckMarkingBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(Pile),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(ASLAggregation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(ArchipelagicSeaLaneArea),nameof(ArchipelagicSeaLaneAxis)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(CautionAreaAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(CautionArea)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioCallingInPoint : FeatureNode, IFeatureBindingDefinition {
			public List<String> communicationChannel {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<decimal> orientationValue {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public trafficFlow trafficFlow {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RadioCallingInPoint);

			public informationBindingDefinition[] informationBindingDefinitions => RadioCallingInPoint._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RadioCallingInPoint._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FerryRoute : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public List<categoryOfFerry> categoryOfFerry {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FerryRoute);

			public informationBindingDefinition[] informationBindingDefinitions => FerryRoute._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FerryRoute._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarLine : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[Required()]
			public decimal orientationValue {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RadarLine);

			public informationBindingDefinition[] informationBindingDefinitions => RadarLine._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RadarLine._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarRange : FeatureNode, IFeatureBindingDefinition {
			public List<String> communicationChannel {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RadarRange);

			public informationBindingDefinition[] informationBindingDefinitions => RadarRange._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RadarRange._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarStation : FeatureNode, IFeatureBindingDefinition {
			public String? callSign {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public List<categoryOfRadarStation> categoryOfRadarStation {get;set;} = [];

			public List<String> communicationChannel {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<status> status {get;set;} = [];

			public decimal? valueOfMaximumRange {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RadarStation);

			public informationBindingDefinition[] informationBindingDefinitions => RadarStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RadarStation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorageArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			public List<categoryOfAnchorage> categoryOfAnchorage {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(AnchorageArea);

			public informationBindingDefinition[] informationBindingDefinitions => AnchorageArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => AnchorageArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public List<categoryOfMooringArea> categoryOfMooringArea {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public decimal? maximumPermittedVesselLength {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			[EnumerationValue(42)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(MooringArea);

			public informationBindingDefinition[] informationBindingDefinitions => MooringArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => MooringArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AnchorBerth : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(14)]
			public List<categoryOfAnchorage> categoryOfAnchorage {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			public List<categoryOfCargo> categoryOfCargo {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public decimal? radius {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(AnchorBerth);

			public informationBindingDefinition[] informationBindingDefinitions => AnchorBerth._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => AnchorBerth._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SeaplaneLandingArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SeaplaneLandingArea);

			public informationBindingDefinition[] informationBindingDefinitions => SeaplaneLandingArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SeaplaneLandingArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class DumpingGround : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public List<categoryOfDumpingGround> categoryOfDumpingGround {get;set;} = [];

			public DateOnly? dateDisused {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(DumpingGround);

			public informationBindingDefinition[] informationBindingDefinitions => DumpingGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => DumpingGround._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MilitaryPracticeArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public List<categoryOfMilitaryPracticeArea> categoryOfMilitaryPracticeArea {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public String? nationality {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(MilitaryPracticeArea);

			public informationBindingDefinition[] informationBindingDefinitions => MilitaryPracticeArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => MilitaryPracticeArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class AdministrationArea : FeatureNode, IFeatureBindingDefinition {
			public Boolean? inDispute {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[Required()]
			public jurisdiction jurisdiction {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<String> nationality {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(AdministrationArea);

			public informationBindingDefinition[] informationBindingDefinitions => AdministrationArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => AdministrationArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CargoTranshipmentArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(24)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CargoTranshipmentArea);

			public informationBindingDefinition[] informationBindingDefinitions => CargoTranshipmentArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CargoTranshipmentArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CautionArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(5)]
			[EnumerationValue(7)]
			public status? status {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(CautionArea);

			public informationBindingDefinition[] informationBindingDefinitions => CautionArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CautionArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(CautionAreaAssociation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InformationArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public DateOnly? reportedDate {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(InformationArea);

			public informationBindingDefinition[] informationBindingDefinitions => InformationArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => InformationArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContiguousZone : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public Boolean? inDispute {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<String> nationality {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ContiguousZone);

			public informationBindingDefinition[] informationBindingDefinitions => ContiguousZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => ContiguousZone._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ContinentalShelfArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<String> nationality {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ContinentalShelfArea);

			public informationBindingDefinition[] informationBindingDefinitions => ContinentalShelfArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => ContinentalShelfArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CustomZone : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			public String nationality {get;set;} = string.Empty;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CustomZone);

			public informationBindingDefinition[] informationBindingDefinitions => CustomZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CustomZone._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class ExclusiveEconomicZone : FeatureNode, IFeatureBindingDefinition {
			public Boolean? inDispute {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<String> nationality {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(ExclusiveEconomicZone);

			public informationBindingDefinition[] informationBindingDefinitions => ExclusiveEconomicZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => ExclusiveEconomicZone._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FisheryZone : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public String nationality {get;set;} = string.Empty;

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FisheryZone);

			public informationBindingDefinition[] informationBindingDefinitions => FisheryZone._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FisheryZone._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FishingGround : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FishingGround);

			public informationBindingDefinition[] informationBindingDefinitions => FishingGround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FishingGround._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FreePortArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FreePortArea);

			public informationBindingDefinition[] informationBindingDefinitions => FreePortArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FreePortArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourAreaAdministrative : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(HarbourAreaAdministrative);

			public informationBindingDefinition[] informationBindingDefinitions => HarbourAreaAdministrative._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => HarbourAreaAdministrative._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LogPond : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LogPond);

			public informationBindingDefinition[] informationBindingDefinitions => LogPond._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LogPond._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class OilBarrier : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public categoryOfOilBarrier? categoryOfOilBarrier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(OilBarrier);

			public informationBindingDefinition[] informationBindingDefinitions => OilBarrier._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => OilBarrier._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class StraightTerritorialSeaBaseline : FeatureNode, IFeatureBindingDefinition {
			public String? interoperabilityIdentifier {get;set;} = default;

			public String nationality {get;set;} = string.Empty;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(StraightTerritorialSeaBaseline);

			public informationBindingDefinition[] informationBindingDefinitions => StraightTerritorialSeaBaseline._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => StraightTerritorialSeaBaseline._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TerritorialSeaArea : FeatureNode, IFeatureBindingDefinition {
			public Boolean? inDispute {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<String> nationality {get;set;} = [];

			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(12)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(TerritorialSeaArea);

			public informationBindingDefinition[] informationBindingDefinitions => TerritorialSeaArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => TerritorialSeaArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SubmarineTransitLane : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public String? nationality {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SubmarineTransitLane);

			public informationBindingDefinition[] informationBindingDefinitions => SubmarineTransitLane._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SubmarineTransitLane._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotageDistrict : FeatureNode, IFeatureBindingDefinition {
			public List<String> communicationChannel {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(PilotageDistrict);

			public informationBindingDefinition[] informationBindingDefinitions => PilotageDistrict._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => PilotageDistrict._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(PilotageDistrictAssociation),
					role = Enum.GetName<Role>(Role.theComponent)!,
					featureTypes = [nameof(PilotBoardingPlace)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CollisionRegulationsLimit : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public String? regulationCitation {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CollisionRegulationsLimit);

			public informationBindingDefinition[] informationBindingDefinitions => CollisionRegulationsLimit._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CollisionRegulationsLimit._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MarinePollutionRegulationsArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public String? regulationCitation {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(MarinePollutionRegulationsArea);

			public informationBindingDefinition[] informationBindingDefinitions => MarinePollutionRegulationsArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => MarinePollutionRegulationsArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RestrictedArea : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			public List<categoryOfRestrictedArea> categoryOfRestrictedArea {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(39)]
			[EnumerationValue(42)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(9)]
			[EnumerationValue(18)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RestrictedArea);

			public informationBindingDefinition[] informationBindingDefinitions => RestrictedArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RestrictedArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(TrafficSeparationSchemeAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(TrafficSeparationScheme)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAllAround : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public int? flareBearing {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public lightVisibility? lightVisibility {get;set;} = default;

			public Boolean? majorLight {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[Required()]
			public rhythmOfLight rhythmOfLight {get;set;}

			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public signalGeneration? signalGeneration {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public decimal? valueOfNominalRange {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LightAllAround);

			public informationBindingDefinition[] informationBindingDefinitions => LightAllAround._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LightAllAround._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(LightAllAround),nameof(LightSectored),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(FogSignal),nameof(LightAirObstruction),nameof(LightAllAround),nameof(LightFogDetector),nameof(LightSectored),nameof(RadarTransponderBeacon),nameof(Retroreflector)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightSectored : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			public List<categoryOfLight> categoryOfLight {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public List<sectorCharacteristics> sectorCharacteristics {get;set;} = [];

			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public signalGeneration? signalGeneration {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LightSectored);

			public informationBindingDefinition[] informationBindingDefinitions => LightSectored._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LightSectored._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(FogSignal),nameof(LightAirObstruction),nameof(LightAllAround),nameof(LightFogDetector),nameof(LightSectored),nameof(RadarTransponderBeacon),nameof(Retroreflector)],
				},
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(Conveyor),nameof(Dolphin),nameof(FishingFacility),nameof(FortifiedStructure),nameof(IsolatedDangerBeacon),nameof(Landmark),nameof(LateralBeacon),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(LightAllAround),nameof(LightSectored),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFogDetector : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			public List<colour> colour {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public int? flareBearing {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public rhythmOfLight? rhythmOfLight {get;set;} = default;

			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public signalGeneration? signalGeneration {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LightFogDetector);

			public informationBindingDefinition[] informationBindingDefinitions => LightFogDetector._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LightFogDetector._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(LightAllAround),nameof(LightSectored),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightAirObstruction : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			public exhibitionConditionOfLight? exhibitionConditionOfLight {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public int? flareBearing {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? height {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			public List<lightVisibility> lightVisibility {get;set;} = [];

			public multiplicityOfFeatures? multiplicityOfFeatures {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public rhythmOfLight? rhythmOfLight {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public decimal? valueOfNominalRange {get;set;} = default;

			[EnumerationValue(3)]
			[EnumerationValue(13)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(44)]
			public verticalDatum? verticalDatum {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(LightAirObstruction);

			public informationBindingDefinition[] informationBindingDefinitions => LightAirObstruction._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LightAirObstruction._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(Conveyor),nameof(Landmark),nameof(OffshorePlatform),nameof(PylonBridgeSupport),nameof(SpanFixed),nameof(SpanOpening),nameof(WindTurbine),nameof(LightAllAround),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBuoy : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public categoryOfLateralMark categoryOfLateralMark {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(LateralBuoy);

			public informationBindingDefinition[] informationBindingDefinitions => LateralBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LateralBuoy._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBuoy : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public categoryOfCardinalMark categoryOfCardinalMark {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(CardinalBuoy);

			public informationBindingDefinition[] informationBindingDefinitions => CardinalBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CardinalBuoy._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBuoy : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(IsolatedDangerBuoy);

			public informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBuoy._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBuoy : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SafeWaterBuoy);

			public informationBindingDefinition[] informationBindingDefinitions => SafeWaterBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SafeWaterBuoy._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBuoy : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			[EnumerationValue(34)]
			[EnumerationValue(35)]
			[EnumerationValue(36)]
			[EnumerationValue(37)]
			[EnumerationValue(39)]
			[EnumerationValue(40)]
			[EnumerationValue(42)]
			[EnumerationValue(43)]
			[EnumerationValue(45)]
			[EnumerationValue(46)]
			[EnumerationValue(47)]
			[EnumerationValue(48)]
			[EnumerationValue(49)]
			[EnumerationValue(50)]
			[EnumerationValue(51)]
			[EnumerationValue(52)]
			[EnumerationValue(53)]
			[EnumerationValue(54)]
			[EnumerationValue(55)]
			[EnumerationValue(56)]
			[EnumerationValue(57)]
			[EnumerationValue(58)]
			[EnumerationValue(59)]
			[EnumerationValue(60)]
			[EnumerationValue(61)]
			[EnumerationValue(62)]
			[EnumerationValue(63)]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBuoy);

			public informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBuoy._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class EmergencyWreckMarkingBuoy : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(EmergencyWreckMarkingBuoy);

			public informationBindingDefinition[] informationBindingDefinitions => EmergencyWreckMarkingBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => EmergencyWreckMarkingBuoy._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class InstallationBuoy : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public categoryOfInstallationBuoy? categoryOfInstallationBuoy {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(7)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			public List<product> product {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(InstallationBuoy);

			public informationBindingDefinition[] informationBindingDefinitions => InstallationBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => InstallationBuoy._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class MooringBuoy : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[Required()]
			public buoyShape buoyShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? maximumPermittedDraught {get;set;} = default;

			public decimal? maximumPermittedVesselLength {get;set;} = default;

			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			public Boolean? visitorsMooring {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(MooringBuoy);

			public informationBindingDefinition[] informationBindingDefinitions => MooringBuoy._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => MooringBuoy._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(MooringTrotAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(MooringTrot)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LateralBeacon : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[Required()]
			public beaconShape beaconShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public categoryOfLateralMark categoryOfLateralMark {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public decimal? height {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(LateralBeacon);

			public informationBindingDefinition[] informationBindingDefinitions => LateralBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LateralBeacon._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CardinalBeacon : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[Required()]
			public beaconShape beaconShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[Required()]
			public categoryOfCardinalMark categoryOfCardinalMark {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(CardinalBeacon);

			public informationBindingDefinition[] informationBindingDefinitions => CardinalBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CardinalBeacon._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class IsolatedDangerBeacon : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[Required()]
			public beaconShape beaconShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(IsolatedDangerBeacon);

			public informationBindingDefinition[] informationBindingDefinitions => IsolatedDangerBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => IsolatedDangerBeacon._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SafeWaterBeacon : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[Required()]
			public beaconShape beaconShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SafeWaterBeacon);

			public informationBindingDefinition[] informationBindingDefinitions => SafeWaterBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SafeWaterBeacon._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SpecialPurposeGeneralBeacon : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[Required()]
			public beaconShape beaconShape {get;set;}

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			[EnumerationValue(34)]
			[EnumerationValue(35)]
			[EnumerationValue(36)]
			[EnumerationValue(37)]
			[EnumerationValue(39)]
			[EnumerationValue(40)]
			[EnumerationValue(41)]
			[EnumerationValue(42)]
			[EnumerationValue(43)]
			[EnumerationValue(44)]
			[EnumerationValue(45)]
			[EnumerationValue(46)]
			[EnumerationValue(47)]
			[EnumerationValue(48)]
			[EnumerationValue(49)]
			[EnumerationValue(50)]
			[EnumerationValue(51)]
			[EnumerationValue(52)]
			[EnumerationValue(53)]
			[EnumerationValue(54)]
			[EnumerationValue(55)]
			[EnumerationValue(56)]
			[EnumerationValue(57)]
			[EnumerationValue(58)]
			[EnumerationValue(60)]
			[EnumerationValue(61)]
			[EnumerationValue(62)]
			[EnumerationValue(63)]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(9)]
			[EnumerationValue(11)]
			public marksNavigationalSystemOf? marksNavigationalSystemOf {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(18)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SpecialPurposeGeneralBeacon);

			public informationBindingDefinition[] informationBindingDefinitions => SpecialPurposeGeneralBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SpecialPurposeGeneralBeacon._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(LightSectored)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Daymark : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			[EnumerationValue(34)]
			[EnumerationValue(35)]
			[EnumerationValue(36)]
			[EnumerationValue(37)]
			[EnumerationValue(39)]
			[EnumerationValue(40)]
			[EnumerationValue(41)]
			[EnumerationValue(42)]
			[EnumerationValue(43)]
			[EnumerationValue(44)]
			[EnumerationValue(45)]
			[EnumerationValue(46)]
			[EnumerationValue(47)]
			[EnumerationValue(48)]
			[EnumerationValue(49)]
			[EnumerationValue(50)]
			[EnumerationValue(51)]
			[EnumerationValue(52)]
			[EnumerationValue(53)]
			[EnumerationValue(54)]
			[EnumerationValue(55)]
			[EnumerationValue(56)]
			[EnumerationValue(57)]
			[EnumerationValue(58)]
			[EnumerationValue(60)]
			[EnumerationValue(61)]
			[EnumerationValue(62)]
			[EnumerationValue(63)]
			public List<categoryOfSpecialPurposeMark> categoryOfSpecialPurposeMark {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public decimal? elevation {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			public List<status> status {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(29)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			[Required()]
			public topmarkDaymarkShape topmarkDaymarkShape {get;set;}

			public decimal? verticalLength {get;set;} = default;

			public List<shapeInformation> shapeInformation {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(Daymark);

			public informationBindingDefinition[] informationBindingDefinitions => Daymark._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Daymark._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(LightSectored),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightFloat : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(11)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public topmark? topmark {get;set;} = default;

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(LightFloat);

			public informationBindingDefinition[] informationBindingDefinitions => LightFloat._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LightFloat._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class LightVessel : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? horizontalLength {get;set;} = default;

			public decimal? horizontalWidth {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public Boolean? radarConspicuous {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public decimal? verticalLength {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public visualProminence? visualProminence {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(LightVessel);

			public informationBindingDefinition[] informationBindingDefinitions => LightVessel._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => LightVessel._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theEquipment)!,
					featureTypes = [nameof(Daymark),nameof(DistanceMark),nameof(FogSignal),nameof(LightAllAround),nameof(LightFogDetector),nameof(PhysicalAISAidToNavigation),nameof(RadarTransponderBeacon),nameof(Retroreflector),nameof(SignalStationTraffic),nameof(SignalStationWarning)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(AidsToNavigationAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(ArchipelagicSeaLane),nameof(DeepWaterRoute),nameof(FairwaySystem),nameof(TrafficSeparationScheme),nameof(TwoWayRoute)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(FairwayAuxiliary),
					role = Enum.GetName<Role>(Role.thePrimaryFeature)!,
					featureTypes = [nameof(Fairway)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Retroreflector : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			public List<colour> colour {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public colourPattern? colourPattern {get;set;} = default;

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(8)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Retroreflector);

			public informationBindingDefinition[] informationBindingDefinitions => Retroreflector._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => Retroreflector._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(LightAllAround),nameof(LightSectored),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarReflector : FeatureNode, IFeatureBindingDefinition {
			public fixedDateRange? fixedDateRange {get;set;} = default;

			public decimal? height {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(8)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RadarReflector);

			public informationBindingDefinition[] informationBindingDefinitions => RadarReflector._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RadarReflector._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(CableOverhead),nameof(PipelineOverhead)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class FogSignal : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[Required()]
			public categoryOfFogSignal categoryOfFogSignal {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public int? signalFrequency {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			public signalGeneration? signalGeneration {get;set;} = default;

			public String? signalGroup {get;set;} = default;

			public decimal? signalPeriod {get;set;} = default;

			public List<signalSequence> signalSequence {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(15)]
			public List<status> status {get;set;} = [];

			public decimal? valueOfMaximumRange {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(FogSignal);

			public informationBindingDefinition[] informationBindingDefinitions => FogSignal._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => FogSignal._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(LightAllAround),nameof(LightSectored),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PhysicalAISAidToNavigation : FeatureNode, IFeatureBindingDefinition {
			public decimal? estimatedRangeOfTransmission {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public String? mMSICode {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			public status? status {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(PhysicalAISAidToNavigation);

			public informationBindingDefinition[] informationBindingDefinitions => PhysicalAISAidToNavigation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => PhysicalAISAidToNavigation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VirtualAISAidToNavigation : FeatureNode, IFeatureBindingDefinition {
			public decimal? estimatedRangeOfTransmission {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public String? mMSICode {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			public status? status {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[Required()]
			public virtualAISAidToNavigationType virtualAISAidToNavigationType {get;set;}

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(VirtualAISAidToNavigation);

			public informationBindingDefinition[] informationBindingDefinitions => VirtualAISAidToNavigation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => VirtualAISAidToNavigation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadioStation : FeatureNode, IFeatureBindingDefinition {
			public String? callSign {get;set;} = default;

			[EnumerationValue(5)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(14)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			public List<categoryOfRadioStation> categoryOfRadioStation {get;set;} = [];

			public List<String> communicationChannel {get;set;} = [];

			public decimal? estimatedRangeOfTransmission {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public frequencyPair? frequencyPair {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RadioStation);

			public informationBindingDefinition[] informationBindingDefinitions => RadioStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RadioStation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RadarTransponderBeacon : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[Required()]
			public categoryOfRadarTransponderBeacon categoryOfRadarTransponderBeacon {get;set;}

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			public List<radarWaveLength> radarWaveLength {get;set;} = [];

			public sectorLimit? sectorLimit {get;set;} = default;

			public String? signalGroup {get;set;} = default;

			public List<signalSequence> signalSequence {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<status> status {get;set;} = [];

			public decimal? valueOfMaximumRange {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RadarTransponderBeacon);

			public informationBindingDefinition[] informationBindingDefinitions => RadarTransponderBeacon._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RadarTransponderBeacon._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(LightAllAround),nameof(LightSectored),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(RangeSystemAggregation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(RangeSystem)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class PilotBoardingPlace : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public categoryOfPilotBoardingPlace? categoryOfPilotBoardingPlace {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public categoryOfPreference? categoryOfPreference {get;set;} = default;

			public List<String> communicationChannel {get;set;} = [];

			public List<String> destination {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			public List<pilotMovement> pilotMovement {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(9)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(28)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(PilotBoardingPlace);

			public informationBindingDefinition[] informationBindingDefinitions => PilotBoardingPlace._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => PilotBoardingPlace._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.aggregation,
					lower = 0,
					upper =  1,
					association = nameof(PilotageDistrictAssociation),
					role = Enum.GetName<Role>(Role.theCollection)!,
					featureTypes = [nameof(PilotageDistrict)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class VesselTrafficServiceArea : FeatureNode, IFeatureBindingDefinition {
			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(VesselTrafficServiceArea);

			public informationBindingDefinition[] informationBindingDefinitions => VesselTrafficServiceArea._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => VesselTrafficServiceArea._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class CoastGuardStation : FeatureNode, IFeatureBindingDefinition {
			public List<String> communicationChannel {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public Boolean? isMRCC {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(CoastGuardStation);

			public informationBindingDefinition[] informationBindingDefinitions => CoastGuardStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation),nameof(NonStandardWorkingDay),nameof(ServiceHours)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => CoastGuardStation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SignalStationWarning : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			public List<categoryOfSignalStationWarning> categoryOfSignalStationWarning {get;set;} = [];

			public List<String> communicationChannel {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SignalStationWarning);

			public informationBindingDefinition[] informationBindingDefinitions => SignalStationWarning._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SignalStationWarning._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SignalStationTraffic : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			public List<categoryOfSignalStationTraffic> categoryOfSignalStationTraffic {get;set;} = [];

			public List<String> communicationChannel {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(SignalStationTraffic);

			public informationBindingDefinition[] informationBindingDefinitions => SignalStationTraffic._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SignalStationTraffic._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(StructureEquipment),
					role = Enum.GetName<Role>(Role.theStructure)!,
					featureTypes = [nameof(Bridge),nameof(Building),nameof(Crane),nameof(CardinalBeacon),nameof(CardinalBuoy),nameof(Conveyor),nameof(Dolphin),nameof(EmergencyWreckMarkingBuoy),nameof(FishingFacility),nameof(FloatingDock),nameof(FortifiedStructure),nameof(Hulk),nameof(InstallationBuoy),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightFloat),nameof(LightVessel),nameof(MooringBuoy),nameof(OffshorePlatform),nameof(Pile),nameof(PipelineOverhead),nameof(Pontoon),nameof(PylonBridgeSupport),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(ShorelineConstruction),nameof(SiloTank),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(StructureOverNavigableWater),nameof(WindTurbine),nameof(Wreck),nameof(Daymark)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class RescueStation : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			public List<categoryOfRescueStation> categoryOfRescueStation {get;set;} = [];

			public List<String> communicationChannel {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(RescueStation);

			public informationBindingDefinition[] informationBindingDefinitions => RescueStation._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => RescueStation._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class HarbourFacility : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			public List<categoryOfHarbourFacility> categoryOfHarbourFacility {get;set;} = [];

			public List<String> communicationChannel {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(5)]
			public condition? condition {get;set;} = default;

			public List<featureName> featureName {get;set;} = [];

			public fixedDateRange? fixedDateRange {get;set;} = default;

			public String? interoperabilityIdentifier {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			public List<natureOfConstruction> natureOfConstruction {get;set;} = [];

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(25)]
			public product? product {get;set;} = default;

			public DateOnly? reportedDate {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(27)]
			public List<restriction> restriction {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public List<vesselSpeedLimit> vesselSpeedLimit {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(HarbourFacility);

			public informationBindingDefinition[] informationBindingDefinitions => HarbourFacility._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => HarbourFacility._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class SmallCraftFacility : FeatureNode, IFeatureBindingDefinition {
			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(10)]
			[EnumerationValue(11)]
			[EnumerationValue(12)]
			[EnumerationValue(13)]
			[EnumerationValue(14)]
			[EnumerationValue(15)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			[EnumerationValue(18)]
			[EnumerationValue(19)]
			[EnumerationValue(20)]
			[EnumerationValue(21)]
			[EnumerationValue(22)]
			[EnumerationValue(23)]
			[EnumerationValue(24)]
			[EnumerationValue(25)]
			[EnumerationValue(26)]
			[EnumerationValue(27)]
			[EnumerationValue(28)]
			[EnumerationValue(30)]
			[EnumerationValue(31)]
			[EnumerationValue(32)]
			[EnumerationValue(33)]
			public List<categoryOfSmallCraftFacility> categoryOfSmallCraftFacility {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			public String? interoperabilityIdentifier {get;set;} = default;

			public List<periodicDateRange> periodicDateRange {get;set;} = [];

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			[EnumerationValue(3)]
			[EnumerationValue(4)]
			[EnumerationValue(5)]
			[EnumerationValue(6)]
			[EnumerationValue(7)]
			[EnumerationValue(8)]
			[EnumerationValue(9)]
			[EnumerationValue(12)]
			[EnumerationValue(14)]
			[EnumerationValue(16)]
			[EnumerationValue(17)]
			public List<status> status {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			public List<information> information {get;set;} = [];

			public String? pictorialRepresentation {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(SmallCraftFacility);

			public informationBindingDefinition[] informationBindingDefinitions => SmallCraftFacility._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
				new informationBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  1,
					association = nameof(AdditionalInformation),
					role = Enum.GetName<Role>(Role.theInformation)!,
					informationTypes = [nameof(ContactDetails),nameof(NauticalInformation)],
				},
			];

			public featureBindingDefinition[] featureBindingDefinitions => SmallCraftFacility._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  default,
					association = nameof(UpdatedInformation),
					role = Enum.GetName<Role>(Role.theUpdate)!,
					featureTypes = [nameof(UpdateInformation)],
				},
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class TextPlacement : FeatureNode, IFeatureBindingDefinition {
			[Required()]
			public int textOffsetBearing {get;set;}

			[Required()]
			public int textOffsetDistance {get;set;}

			public Boolean? textRotation {get;set;} = default;

			[EnumerationValue(1)]
			[EnumerationValue(2)]
			public List<textType> textType {get;set;} = [];

			public int? scaleMinimum {get;set;} = default;

			[JsonIgnore]
			public override string Code => nameof(TextPlacement);

			public informationBindingDefinition[] informationBindingDefinitions => TextPlacement._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => TextPlacement._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.composition,
					lower = 0,
					upper =  1,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.thePositionProvider)!,
					featureTypes = [nameof(AdministrationArea),nameof(AirportAirfield),nameof(AnchorBerth),nameof(AnchorageArea),nameof(ArchipelagicSeaLane),nameof(ArchipelagicSeaLaneArea),nameof(ArchipelagicSeaLaneAxis),nameof(Berth),nameof(Bollard),nameof(Bridge),nameof(Building),nameof(BuiltUpArea),nameof(CableArea),nameof(CableOverhead),nameof(CableSubmarine),nameof(Canal),nameof(CardinalBuoy),nameof(CardinalBeacon),nameof(CargoTranshipmentArea),nameof(Causeway),nameof(Chart1Feature),nameof(Checkpoint),nameof(CoastGuardStation),nameof(Coastline),nameof(CollisionRegulationsLimit),nameof(ContinentalShelfArea),nameof(Conveyor),nameof(Crane),nameof(CurrentNonGravitational),nameof(Dam),nameof(Daymark),nameof(DeepWaterRoute),nameof(DeepWaterRouteCentreline),nameof(DeepWaterRoutePart),nameof(DistanceMark),nameof(DockArea),nameof(Dolphin),nameof(DredgedArea),nameof(DryDock),nameof(DumpingGround),nameof(Dyke),nameof(EmergencyWreckMarkingBuoy),nameof(Fairway),nameof(FairwaySystem),nameof(FenceWall),nameof(FerryRoute),nameof(FisheryZone),nameof(FishingFacility),nameof(FishingGround),nameof(FloatingDock),nameof(FogSignal),nameof(FortifiedStructure),nameof(FoulGround),nameof(FreePortArea),nameof(Gate),nameof(Gridiron),nameof(HarbourAreaAdministrative),nameof(HarbourFacility),nameof(Helipad),nameof(Hulk),nameof(IceArea),nameof(InformationArea),nameof(InstallationBuoy),nameof(IslandGroup),nameof(IsolatedDangerBeacon),nameof(IsolatedDangerBuoy),nameof(Lake),nameof(LandArea),nameof(LandElevation),nameof(LandRegion),nameof(Landmark),nameof(LateralBeacon),nameof(LateralBuoy),nameof(LightAirObstruction),nameof(LightAllAround),nameof(LightFloat),nameof(LightFogDetector),nameof(LightSectored),nameof(LightVessel),nameof(LocalMagneticAnomaly),nameof(LockBasin),nameof(LogPond),nameof(MarineFarmCulture),nameof(MarinePollutionRegulationsArea),nameof(MilitaryPracticeArea),nameof(MooringArea),nameof(MooringBuoy),nameof(MooringTrot),nameof(Obstruction),nameof(OffshorePlatform),nameof(OffshoreProductionArea),nameof(OilBarrier),nameof(PhysicalAISAidToNavigation),nameof(Pile),nameof(PilotBoardingPlace),nameof(PilotageDistrict),nameof(PipelineOverhead),nameof(PipelineSubmarineOnLand),nameof(Pontoon),nameof(PrecautionaryArea),nameof(ProductionStorageArea),nameof(PylonBridgeSupport),nameof(RadarLine),nameof(RadarRange),nameof(RadarStation),nameof(RadarTransponderBeacon),nameof(RadioCallingInPoint),nameof(RadioStation),nameof(Railway),nameof(RangeSystem),nameof(Rapids),nameof(RecommendedRouteCentreline),nameof(RecommendedTrack),nameof(RescueStation),nameof(RestrictedArea),nameof(River),nameof(Road),nameof(Runway),nameof(SafeWaterBeacon),nameof(SafeWaterBuoy),nameof(SeaAreaNamedWaterArea),nameof(SeabedArea),nameof(Seagrass),nameof(SeaplaneLandingArea),nameof(ShorelineConstruction),nameof(SignalStationTraffic),nameof(SignalStationWarning),nameof(SiloTank),nameof(SlopeTopline),nameof(SlopingGround),nameof(SmallCraftFacility),nameof(Sounding),nameof(SpanFixed),nameof(SpanOpening),nameof(SpecialPurposeGeneralBeacon),nameof(SpecialPurposeGeneralBuoy),nameof(Spring),nameof(StructureOverNavigableWater),nameof(SubmarinePipelineArea),nameof(SubmarineTransitLane),nameof(SweptArea),nameof(TidalStreamFloodEbb),nameof(TidalStreamPanelData),nameof(Tideway),nameof(TrafficSeparationScheme),nameof(Tunnel),nameof(TwoWayRoute),nameof(UnderwaterAwashRock),nameof(Vegetation),nameof(VesselTrafficServiceArea),nameof(VirtualAISAidToNavigation),nameof(WaterTurbulence),nameof(Waterfall),nameof(WeedKelp),nameof(WindTurbine),nameof(Wreck)],
				},
			];
		}

		[System.Serializable()]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
		public partial class Chart1Feature : FeatureNode, IFeatureBindingDefinition {
			public List<String> drawingInstruction {get;set;} = [];

			public List<featureName> featureName {get;set;} = [];

			[JsonIgnore]
			public override string Code => nameof(Chart1Feature);

			public informationBindingDefinition[] informationBindingDefinitions => Chart1Feature._informationBindingDefinitions;
			public static informationBindingDefinition[] _informationBindingDefinitions => [
			];

			public featureBindingDefinition[] featureBindingDefinitions => Chart1Feature._featureBindingDefinitions;
			public static featureBindingDefinition[] _featureBindingDefinitions => [
				new featureBindingDefinition {
					roleType = roleType.association,
					lower = 0,
					upper =  2,
					association = nameof(TextAssociation),
					role = Enum.GetName<Role>(Role.theCartographicText)!,
					featureTypes = [nameof(TextPlacement)],
				},
			];
		}
	}
}

#pragma warning restore CS8981
