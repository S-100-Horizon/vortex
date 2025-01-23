using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S131;
using S100Framework.DomainModel.S131.ComplexAttributes;
using S100Framework.DomainModel.S131.FeatureTypes;
using S100Framework.DomainModel.S131.InformationTypes;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

#nullable enable
namespace S100Framework.WPF.ViewModel.S131
{
    internal static class Preamble
    {
        public static ImmutableDictionary<string, Func<ViewModelBase>> _creators => ImmutableDictionary.Create<string, Func<ViewModelBase>>().AddRange(new Dictionary<string, Func<ViewModelBase>> { { typeof(DomainModel.S131.InformationTypes.Applicability).Name, () =>
        {
            return new ApplicabilityViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.Authority).Name, () =>
        {
            return new AuthorityViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.AvailablePortServices).Name, () =>
        {
            return new AvailablePortServicesViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.ContactDetails).Name, () =>
        {
            return new ContactDetailsViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.Entrance).Name, () =>
        {
            return new EntranceViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.NauticalInformation).Name, () =>
        {
            return new NauticalInformationViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.NonStandardWorkingDay).Name, () =>
        {
            return new NonStandardWorkingDayViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.Recommendations).Name, () =>
        {
            return new RecommendationsViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.Regulations).Name, () =>
        {
            return new RegulationsViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.Restrictions).Name, () =>
        {
            return new RestrictionsViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.ServiceHours).Name, () =>
        {
            return new ServiceHoursViewModel();
        } }, { typeof(DomainModel.S131.InformationTypes.SpatialQuality).Name, () =>
        {
            return new SpatialQualityViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.AnchorBerth).Name, () =>
        {
            return new AnchorBerthViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.AnchorageArea).Name, () =>
        {
            return new AnchorageAreaViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.Berth).Name, () =>
        {
            return new BerthViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.BerthPosition).Name, () =>
        {
            return new BerthPositionViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.DockArea).Name, () =>
        {
            return new DockAreaViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.DryDock).Name, () =>
        {
            return new DryDockViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.DumpingGround).Name, () =>
        {
            return new DumpingGroundViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.FloatingDock).Name, () =>
        {
            return new FloatingDockViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.Gridiron).Name, () =>
        {
            return new GridironViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.HarbourAreaAdministrative).Name, () =>
        {
            return new HarbourAreaAdministrativeViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.HarbourAreaSection).Name, () =>
        {
            return new HarbourAreaSectionViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.HarbourBasin).Name, () =>
        {
            return new HarbourBasinViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.HarbourFacility).Name, () =>
        {
            return new HarbourFacilityViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.MooringWarpingFacility).Name, () =>
        {
            return new MooringWarpingFacilityViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.OuterLimit).Name, () =>
        {
            return new OuterLimitViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.PilotBoardingPlace).Name, () =>
        {
            return new PilotBoardingPlaceViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.SeaplaneLandingArea).Name, () =>
        {
            return new SeaplaneLandingAreaViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.Terminal).Name, () =>
        {
            return new TerminalViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.TurningBasin).Name, () =>
        {
            return new TurningBasinViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.WaterwayArea).Name, () =>
        {
            return new WaterwayAreaViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.DataCoverage).Name, () =>
        {
            return new DataCoverageViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.QualityOfNonBathymetricData).Name, () =>
        {
            return new QualityOfNonBathymetricDataViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.SoundingDatum).Name, () =>
        {
            return new SoundingDatumViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.VerticalDatumOfData).Name, () =>
        {
            return new VerticalDatumOfDataViewModel();
        } }, { typeof(DomainModel.S131.FeatureTypes.TextPlacement).Name, () =>
        {
            return new TextPlacementViewModel();
        } }, });
    }

    public class Handles : iHandles
    {
        public static IDictionary<Type, Func<InformationAssociationConnector[]>> AssociationConnectorInformations => new Dictionary<Type, Func<InformationAssociationConnector[]>>
        {
            {
                typeof(ServiceAvailabilityViewModel),
                () => [new InformationAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "serviceDescriptionReference",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(AvailablePortServices)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceAvailabilityViewModel.serviceDescriptionReferenceAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new InformationAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "serviceDescriptionReference",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(AvailablePortServices)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceAvailabilityViewModel.serviceDescriptionReferenceBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new InformationAssociationConnector<DockArea>()
                {
                    roleType = roleType.association,
                    role = "serviceDescriptionReference",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(AvailablePortServices)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceAvailabilityViewModel.serviceDescriptionReferenceDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "serviceDescriptionReference",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(AvailablePortServices)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceAvailabilityViewModel.serviceDescriptionReferenceHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "serviceDescriptionReference",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(AvailablePortServices)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceAvailabilityViewModel.serviceDescriptionReferenceHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new InformationAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "serviceDescriptionReference",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(AvailablePortServices)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceAvailabilityViewModel.serviceDescriptionReferenceMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "serviceDescriptionReference",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(AvailablePortServices)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceAvailabilityViewModel.serviceDescriptionReferenceTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(LimitEntranceViewModel),
                () => [new InformationAssociationConnector<OuterLimit>()
                {
                    roleType = roleType.association,
                    role = "entranceReference",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Entrance)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LimitEntranceViewModel.entranceReferenceOuterLimitRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<OuterLimitViewModel.OuterLimitRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(PermissionTypeViewModel),
                () => [new InformationAssociationConnector<DryDock>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionDryDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DryDockViewModel.DryDockRefIdViewModel>(),
                }, new InformationAssociationConnector<FloatingDock>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionFloatingDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<FloatingDockViewModel.FloatingDockRefIdViewModel>(),
                }, new InformationAssociationConnector<Gridiron>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionGridironRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<GridironViewModel.GridironRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourFacility>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionHarbourFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourFacilityViewModel.HarbourFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorageArea>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionAnchorageAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorageAreaViewModel.AnchorageAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new InformationAssociationConnector<BerthPosition>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionBerthPositionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthPositionViewModel.BerthPositionRefIdViewModel>(),
                }, new InformationAssociationConnector<DockArea>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<DumpingGround>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionDumpingGroundRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DumpingGroundViewModel.DumpingGroundRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourBasin>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionHarbourBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourBasinViewModel.HarbourBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<OuterLimit>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionOuterLimitRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<OuterLimitViewModel.OuterLimitRefIdViewModel>(),
                }, new InformationAssociationConnector<PilotBoardingPlace>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionPilotBoardingPlaceRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PilotBoardingPlaceViewModel.PilotBoardingPlaceRefIdViewModel>(),
                }, new InformationAssociationConnector<SeaplaneLandingArea>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionSeaplaneLandingAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<SeaplaneLandingAreaViewModel.SeaplaneLandingAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new InformationAssociationConnector<TurningBasin>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionTurningBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TurningBasinViewModel.TurningBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<WaterwayArea>()
                {
                    roleType = roleType.association,
                    role = "permission",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.permissionWaterwayAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<WaterwayAreaViewModel.WaterwayAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Applicability>()
                {
                    roleType = roleType.association,
                    role = "vslLocation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions), typeof(Applicability), typeof(Authority), typeof(AvailablePortServices), typeof(ContactDetails), typeof(Entrance), typeof(NonStandardWorkingDay), typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<PermissionTypeViewModel.vslLocationApplicabilityRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ApplicabilityViewModel.ApplicabilityRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(InclusionTypeViewModel),
                () => [new InformationAssociationConnector<NauticalInformation>()
                {
                    roleType = roleType.association,
                    role = "isApplicableTo",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<InclusionTypeViewModel.isApplicableToNauticalInformationRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<NauticalInformationViewModel.NauticalInformationRefIdViewModel>(),
                }, new InformationAssociationConnector<Recommendations>()
                {
                    roleType = roleType.association,
                    role = "isApplicableTo",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<InclusionTypeViewModel.isApplicableToRecommendationsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RecommendationsViewModel.RecommendationsRefIdViewModel>(),
                }, new InformationAssociationConnector<Regulations>()
                {
                    roleType = roleType.association,
                    role = "isApplicableTo",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<InclusionTypeViewModel.isApplicableToRegulationsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RegulationsViewModel.RegulationsRefIdViewModel>(),
                }, new InformationAssociationConnector<Restrictions>()
                {
                    roleType = roleType.association,
                    role = "isApplicableTo",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Applicability)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<InclusionTypeViewModel.isApplicableToRestrictionsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RestrictionsViewModel.RestrictionsRefIdViewModel>(),
                }, new InformationAssociationConnector<Applicability>()
                {
                    roleType = roleType.association,
                    role = "theApplicableRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<InclusionTypeViewModel.theApplicableRxNApplicabilityRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ApplicabilityViewModel.ApplicabilityRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(RelatedOrganisationViewModel),
                () => [new InformationAssociationConnector<Authority>()
                {
                    roleType = roleType.association,
                    role = "theInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<RelatedOrganisationViewModel.theInformationAuthorityRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<AuthorityViewModel.AuthorityRefIdViewModel>(),
                }, new InformationAssociationConnector<NauticalInformation>()
                {
                    roleType = roleType.association,
                    role = "theOrganisation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<RelatedOrganisationViewModel.theOrganisationNauticalInformationRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<NauticalInformationViewModel.NauticalInformationRefIdViewModel>(),
                }, new InformationAssociationConnector<Recommendations>()
                {
                    roleType = roleType.association,
                    role = "theOrganisation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<RelatedOrganisationViewModel.theOrganisationRecommendationsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RecommendationsViewModel.RecommendationsRefIdViewModel>(),
                }, new InformationAssociationConnector<Regulations>()
                {
                    roleType = roleType.association,
                    role = "theOrganisation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<RelatedOrganisationViewModel.theOrganisationRegulationsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RegulationsViewModel.RegulationsRefIdViewModel>(),
                }, new InformationAssociationConnector<Restrictions>()
                {
                    roleType = roleType.association,
                    role = "theOrganisation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<RelatedOrganisationViewModel.theOrganisationRestrictionsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RestrictionsViewModel.RestrictionsRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(LocationHoursViewModel),
                () => [new InformationAssociationConnector<AnchorageArea>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsAnchorageAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorageAreaViewModel.AnchorageAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new InformationAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new InformationAssociationConnector<DockArea>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<DryDock>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsDryDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DryDockViewModel.DryDockRefIdViewModel>(),
                }, new InformationAssociationConnector<DumpingGround>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsDumpingGroundRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DumpingGroundViewModel.DumpingGroundRefIdViewModel>(),
                }, new InformationAssociationConnector<FloatingDock>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsFloatingDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<FloatingDockViewModel.FloatingDockRefIdViewModel>(),
                }, new InformationAssociationConnector<Gridiron>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsGridironRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<GridironViewModel.GridironRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourBasin>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsHarbourBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourBasinViewModel.HarbourBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourFacility>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsHarbourFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourFacilityViewModel.HarbourFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<PilotBoardingPlace>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsPilotBoardingPlaceRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PilotBoardingPlaceViewModel.PilotBoardingPlaceRefIdViewModel>(),
                }, new InformationAssociationConnector<SeaplaneLandingArea>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsSeaplaneLandingAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<SeaplaneLandingAreaViewModel.SeaplaneLandingAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new InformationAssociationConnector<TurningBasin>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsTurningBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TurningBasinViewModel.TurningBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<WaterwayArea>()
                {
                    roleType = roleType.association,
                    role = "location_srvHrs",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<LocationHoursViewModel.location_srvHrsWaterwayAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<WaterwayAreaViewModel.WaterwayAreaRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(ServiceContactViewModel),
                () => [new InformationAssociationConnector<DryDock>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsDryDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DryDockViewModel.DryDockRefIdViewModel>(),
                }, new InformationAssociationConnector<FloatingDock>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsFloatingDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<FloatingDockViewModel.FloatingDockRefIdViewModel>(),
                }, new InformationAssociationConnector<Gridiron>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsGridironRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<GridironViewModel.GridironRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourFacility>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsHarbourFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourFacilityViewModel.HarbourFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorageArea>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsAnchorageAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorageAreaViewModel.AnchorageAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new InformationAssociationConnector<BerthPosition>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsBerthPositionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthPositionViewModel.BerthPositionRefIdViewModel>(),
                }, new InformationAssociationConnector<DockArea>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<DumpingGround>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsDumpingGroundRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DumpingGroundViewModel.DumpingGroundRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourBasin>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsHarbourBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourBasinViewModel.HarbourBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<OuterLimit>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsOuterLimitRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<OuterLimitViewModel.OuterLimitRefIdViewModel>(),
                }, new InformationAssociationConnector<PilotBoardingPlace>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsPilotBoardingPlaceRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PilotBoardingPlaceViewModel.PilotBoardingPlaceRefIdViewModel>(),
                }, new InformationAssociationConnector<SeaplaneLandingArea>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsSeaplaneLandingAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<SeaplaneLandingAreaViewModel.SeaplaneLandingAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new InformationAssociationConnector<TurningBasin>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsTurningBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TurningBasinViewModel.TurningBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<WaterwayArea>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ServiceContactViewModel.theContactDetailsWaterwayAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<WaterwayAreaViewModel.WaterwayAreaRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(ServiceControlViewModel),
                () => [new InformationAssociationConnector<DryDock>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityDryDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DryDockViewModel.DryDockRefIdViewModel>(),
                }, new InformationAssociationConnector<FloatingDock>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityFloatingDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<FloatingDockViewModel.FloatingDockRefIdViewModel>(),
                }, new InformationAssociationConnector<Gridiron>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityGridironRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<GridironViewModel.GridironRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourFacility>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityHarbourFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourFacilityViewModel.HarbourFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorageArea>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityAnchorageAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorageAreaViewModel.AnchorageAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new InformationAssociationConnector<BerthPosition>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityBerthPositionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthPositionViewModel.BerthPositionRefIdViewModel>(),
                }, new InformationAssociationConnector<DockArea>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<DumpingGround>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityDumpingGroundRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DumpingGroundViewModel.DumpingGroundRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourBasin>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityHarbourBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourBasinViewModel.HarbourBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<OuterLimit>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityOuterLimitRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<OuterLimitViewModel.OuterLimitRefIdViewModel>(),
                }, new InformationAssociationConnector<PilotBoardingPlace>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityPilotBoardingPlaceRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PilotBoardingPlaceViewModel.PilotBoardingPlaceRefIdViewModel>(),
                }, new InformationAssociationConnector<SeaplaneLandingArea>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthoritySeaplaneLandingAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<SeaplaneLandingAreaViewModel.SeaplaneLandingAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new InformationAssociationConnector<TurningBasin>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityTurningBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TurningBasinViewModel.TurningBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<WaterwayArea>()
                {
                    roleType = roleType.association,
                    role = "controlAuthority",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new OptionalInformationBindingViewModel<ServiceControlViewModel.controlAuthorityWaterwayAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<WaterwayAreaViewModel.WaterwayAreaRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(ExceptionalWorkdayViewModel),
                () => [new InformationAssociationConnector<ServiceHours>()
                {
                    roleType = roleType.association,
                    role = "partialWorkingDay",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NonStandardWorkingDay)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<ExceptionalWorkdayViewModel.partialWorkingDayServiceHoursRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ServiceHoursViewModel.ServiceHoursRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(AssociatedRxNViewModel),
                () => [new InformationAssociationConnector<DryDock>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNDryDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DryDockViewModel.DryDockRefIdViewModel>(),
                }, new InformationAssociationConnector<FloatingDock>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNFloatingDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<FloatingDockViewModel.FloatingDockRefIdViewModel>(),
                }, new InformationAssociationConnector<Gridiron>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNGridironRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<GridironViewModel.GridironRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourFacility>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNHarbourFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourFacilityViewModel.HarbourFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorageArea>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNAnchorageAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorageAreaViewModel.AnchorageAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new InformationAssociationConnector<BerthPosition>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNBerthPositionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthPositionViewModel.BerthPositionRefIdViewModel>(),
                }, new InformationAssociationConnector<DockArea>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<DumpingGround>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNDumpingGroundRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DumpingGroundViewModel.DumpingGroundRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourBasin>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNHarbourBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourBasinViewModel.HarbourBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<OuterLimit>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNOuterLimitRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<OuterLimitViewModel.OuterLimitRefIdViewModel>(),
                }, new InformationAssociationConnector<PilotBoardingPlace>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNPilotBoardingPlaceRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PilotBoardingPlaceViewModel.PilotBoardingPlaceRefIdViewModel>(),
                }, new InformationAssociationConnector<SeaplaneLandingArea>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNSeaplaneLandingAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<SeaplaneLandingAreaViewModel.SeaplaneLandingAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new InformationAssociationConnector<TurningBasin>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNTurningBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TurningBasinViewModel.TurningBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<WaterwayArea>()
                {
                    roleType = roleType.association,
                    role = "theRxN",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AssociatedRxNViewModel.theRxNWaterwayAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<WaterwayAreaViewModel.WaterwayAreaRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(AuthorityHoursViewModel),
                () => [new InformationAssociationConnector<ServiceHours>()
                {
                    roleType = roleType.association,
                    role = "theAuthority_srvHrs",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AuthorityHoursViewModel.theAuthority_srvHrsServiceHoursRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ServiceHoursViewModel.ServiceHoursRefIdViewModel>(),
                }, new InformationAssociationConnector<Authority>()
                {
                    roleType = roleType.association,
                    role = "theServiceHours",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AuthorityHoursViewModel.theServiceHoursAuthorityRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<AuthorityViewModel.AuthorityRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(AuthorityContactViewModel),
                () => [new InformationAssociationConnector<ContactDetails>()
                {
                    roleType = roleType.association,
                    role = "theAuthority",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Authority)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AuthorityContactViewModel.theAuthorityContactDetailsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ContactDetailsViewModel.ContactDetailsRefIdViewModel>(),
                }, new InformationAssociationConnector<Authority>()
                {
                    roleType = roleType.association,
                    role = "theContactDetails",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(ContactDetails)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AuthorityContactViewModel.theContactDetailsAuthorityRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<AuthorityViewModel.AuthorityRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(AdditionalInformationViewModel),
                () => [new InformationAssociationConnector<NauticalInformation>()
                {
                    roleType = roleType.association,
                    role = "informationProvidedFor",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions), typeof(Applicability), typeof(Authority), typeof(AvailablePortServices), typeof(ContactDetails), typeof(Entrance), typeof(NonStandardWorkingDay), typeof(ServiceHours)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.informationProvidedForNauticalInformationRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<NauticalInformationViewModel.NauticalInformationRefIdViewModel>(),
                }, new InformationAssociationConnector<DryDock>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationDryDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DryDockViewModel.DryDockRefIdViewModel>(),
                }, new InformationAssociationConnector<FloatingDock>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationFloatingDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<FloatingDockViewModel.FloatingDockRefIdViewModel>(),
                }, new InformationAssociationConnector<Gridiron>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationGridironRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<GridironViewModel.GridironRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourFacility>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationHarbourFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourFacilityViewModel.HarbourFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new InformationAssociationConnector<AnchorageArea>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationAnchorageAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorageAreaViewModel.AnchorageAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new InformationAssociationConnector<BerthPosition>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationBerthPositionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthPositionViewModel.BerthPositionRefIdViewModel>(),
                }, new InformationAssociationConnector<DockArea>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<DumpingGround>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationDumpingGroundRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DumpingGroundViewModel.DumpingGroundRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new InformationAssociationConnector<HarbourBasin>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationHarbourBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourBasinViewModel.HarbourBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }, new InformationAssociationConnector<OuterLimit>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationOuterLimitRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<OuterLimitViewModel.OuterLimitRefIdViewModel>(),
                }, new InformationAssociationConnector<PilotBoardingPlace>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationPilotBoardingPlaceRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PilotBoardingPlaceViewModel.PilotBoardingPlaceRefIdViewModel>(),
                }, new InformationAssociationConnector<SeaplaneLandingArea>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationSeaplaneLandingAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<SeaplaneLandingAreaViewModel.SeaplaneLandingAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new InformationAssociationConnector<TurningBasin>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationTurningBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TurningBasinViewModel.TurningBasinRefIdViewModel>(),
                }, new InformationAssociationConnector<WaterwayArea>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationWaterwayAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<WaterwayAreaViewModel.WaterwayAreaRefIdViewModel>(),
                }, new InformationAssociationConnector<NauticalInformation>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationNauticalInformationRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<NauticalInformationViewModel.NauticalInformationRefIdViewModel>(),
                }, new InformationAssociationConnector<Recommendations>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationRecommendationsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RecommendationsViewModel.RecommendationsRefIdViewModel>(),
                }, new InformationAssociationConnector<Regulations>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationRegulationsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RegulationsViewModel.RegulationsRefIdViewModel>(),
                }, new InformationAssociationConnector<Restrictions>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationRestrictionsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<RestrictionsViewModel.RestrictionsRefIdViewModel>(),
                }, new InformationAssociationConnector<Applicability>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationApplicabilityRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ApplicabilityViewModel.ApplicabilityRefIdViewModel>(),
                }, new InformationAssociationConnector<Authority>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationAuthorityRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<AuthorityViewModel.AuthorityRefIdViewModel>(),
                }, new InformationAssociationConnector<AvailablePortServices>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationAvailablePortServicesRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<AvailablePortServicesViewModel.AvailablePortServicesRefIdViewModel>(),
                }, new InformationAssociationConnector<ContactDetails>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationContactDetailsRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ContactDetailsViewModel.ContactDetailsRefIdViewModel>(),
                }, new InformationAssociationConnector<Entrance>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationEntranceRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<EntranceViewModel.EntranceRefIdViewModel>(),
                }, new InformationAssociationConnector<NonStandardWorkingDay>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationNonStandardWorkingDayRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<NonStandardWorkingDayViewModel.NonStandardWorkingDayRefIdViewModel>(),
                }, new InformationAssociationConnector<ServiceHours>()
                {
                    roleType = roleType.association,
                    role = "providesInformation",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(NauticalInformation)],
                    CreateForeignInformationBinding = () => new MultiInformationBindingViewModel<AdditionalInformationViewModel.providesInformationServiceHoursRefIdViewModel>(),
                    CreateLocalInformationBinding = () => new SingleInformationBindingViewModel<ServiceHoursViewModel.ServiceHoursRefIdViewModel>(),
                }

                ]
            },
        };
        public static IDictionary<Type, Func<FeatureAssociationConnector[]>> AssociationConnectorFeatures => new Dictionary<Type, Func<FeatureAssociationConnector[]>>
        {
            {
                typeof(LayoutDivisionViewModel),
                () => [new FeatureAssociationConnector<AnchorageArea>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfAnchorageAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorageAreaViewModel.AnchorageAreaRefIdViewModel>(),
                }, new FeatureAssociationConnector<Berth>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection), typeof(Terminal)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new FeatureAssociationConnector<DockArea>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new FeatureAssociationConnector<DumpingGround>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfDumpingGroundRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DumpingGroundViewModel.DumpingGroundRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaAdministrative)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<LayoutDivisionViewModel.componentOfHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourBasin>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfHarbourBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourBasinViewModel.HarbourBasinRefIdViewModel>(),
                }, new FeatureAssociationConnector<PilotBoardingPlace>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfPilotBoardingPlaceRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PilotBoardingPlaceViewModel.PilotBoardingPlaceRefIdViewModel>(),
                }, new FeatureAssociationConnector<SeaplaneLandingArea>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfSeaplaneLandingAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<SeaplaneLandingAreaViewModel.SeaplaneLandingAreaRefIdViewModel>(),
                }, new FeatureAssociationConnector<Terminal>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new FeatureAssociationConnector<TurningBasin>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfTurningBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TurningBasinViewModel.TurningBasinRefIdViewModel>(),
                }, new FeatureAssociationConnector<WaterwayArea>()
                {
                    roleType = roleType.aggregation,
                    role = "componentOf",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<LayoutDivisionViewModel.componentOfWaterwayAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<WaterwayAreaViewModel.WaterwayAreaRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "layoutUnit",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<LayoutDivisionViewModel.layoutUnitHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "layoutUnit",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(AnchorageArea), typeof(Berth), typeof(DockArea), typeof(DumpingGround), typeof(HarbourBasin), typeof(PilotBoardingPlace), typeof(SeaplaneLandingArea), typeof(Terminal), typeof(TurningBasin), typeof(WaterwayArea)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<LayoutDivisionViewModel.layoutUnitHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new FeatureAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "layoutUnit",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(Berth)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<LayoutDivisionViewModel.layoutUnitTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(JurisdictionalLimitViewModel),
                () => [new FeatureAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "limitExtent",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(OuterLimit)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<JurisdictionalLimitViewModel.limitExtentHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new FeatureAssociationConnector<OuterLimit>()
                {
                    roleType = roleType.association,
                    role = "limitReference",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaAdministrative)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<JurisdictionalLimitViewModel.limitReferenceOuterLimitRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<OuterLimitViewModel.OuterLimitRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(DemarcationViewModel),
                () => [new FeatureAssociationConnector<BerthPosition>()
                {
                    roleType = roleType.composition,
                    role = "demarcatedFeature",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(Berth)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<DemarcationViewModel.demarcatedFeatureBerthPositionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthPositionViewModel.BerthPositionRefIdViewModel>(),
                }, new FeatureAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "demarcationIndicator",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(BerthPosition)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<DemarcationViewModel.demarcationIndicatorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(PrimaryAuxiliaryFacilityViewModel),
                () => [new FeatureAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "auxiliaryFacility",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(MooringWarpingFacility)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<PrimaryAuxiliaryFacilityViewModel.auxiliaryFacilityAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new FeatureAssociationConnector<BerthPosition>()
                {
                    roleType = roleType.association,
                    role = "auxiliaryFacility",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(MooringWarpingFacility)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<PrimaryAuxiliaryFacilityViewModel.auxiliaryFacilityBerthPositionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthPositionViewModel.BerthPositionRefIdViewModel>(),
                }, new FeatureAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "primaryFacility",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(AnchorBerth), typeof(BerthPosition)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<PrimaryAuxiliaryFacilityViewModel.primaryFacilityMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(InfrastructureViewModel),
                () => [new FeatureAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "hasInfrastructure",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(DryDock), typeof(FloatingDock), typeof(Gridiron), typeof(HarbourFacility)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<InfrastructureViewModel.hasInfrastructureHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new FeatureAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "hasInfrastructure",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(DryDock), typeof(FloatingDock), typeof(Gridiron), typeof(HarbourFacility)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<InfrastructureViewModel.hasInfrastructureTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new FeatureAssociationConnector<DryDock>()
                {
                    roleType = roleType.association,
                    role = "infrastructureLocation",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection), typeof(Terminal)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<InfrastructureViewModel.infrastructureLocationDryDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DryDockViewModel.DryDockRefIdViewModel>(),
                }, new FeatureAssociationConnector<FloatingDock>()
                {
                    roleType = roleType.association,
                    role = "infrastructureLocation",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection), typeof(Terminal)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<InfrastructureViewModel.infrastructureLocationFloatingDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<FloatingDockViewModel.FloatingDockRefIdViewModel>(),
                }, new FeatureAssociationConnector<Gridiron>()
                {
                    roleType = roleType.association,
                    role = "infrastructureLocation",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection), typeof(Terminal)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<InfrastructureViewModel.infrastructureLocationGridironRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<GridironViewModel.GridironRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourFacility>()
                {
                    roleType = roleType.association,
                    role = "infrastructureLocation",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection), typeof(Terminal)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<InfrastructureViewModel.infrastructureLocationHarbourFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourFacilityViewModel.HarbourFacilityRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(SubsectionViewModel),
                () => [new FeatureAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.aggregation,
                    role = "constitute",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<SubsectionViewModel.constituteHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "subUnit",
                    Lower = 0,
                    Upper = default,
                    AssociationTypes = [typeof(HarbourAreaSection)],
                    CreateForeignFeatureBinding = () => new MultiFeatureBindingViewModel<SubsectionViewModel.subUnitHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }

                ]
            },
            {
                typeof(TextAssociationViewModel),
                () => [new FeatureAssociationConnector<DryDock>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsDryDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DryDockViewModel.DryDockRefIdViewModel>(),
                }, new FeatureAssociationConnector<FloatingDock>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsFloatingDockRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<FloatingDockViewModel.FloatingDockRefIdViewModel>(),
                }, new FeatureAssociationConnector<Gridiron>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsGridironRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<GridironViewModel.GridironRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourFacility>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsHarbourFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourFacilityViewModel.HarbourFacilityRefIdViewModel>(),
                }, new FeatureAssociationConnector<AnchorBerth>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsAnchorBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorBerthViewModel.AnchorBerthRefIdViewModel>(),
                }, new FeatureAssociationConnector<AnchorageArea>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsAnchorageAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<AnchorageAreaViewModel.AnchorageAreaRefIdViewModel>(),
                }, new FeatureAssociationConnector<Berth>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsBerthRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthViewModel.BerthRefIdViewModel>(),
                }, new FeatureAssociationConnector<BerthPosition>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsBerthPositionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<BerthPositionViewModel.BerthPositionRefIdViewModel>(),
                }, new FeatureAssociationConnector<DockArea>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsDockAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DockAreaViewModel.DockAreaRefIdViewModel>(),
                }, new FeatureAssociationConnector<DumpingGround>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsDumpingGroundRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<DumpingGroundViewModel.DumpingGroundRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourAreaAdministrative>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsHarbourAreaAdministrativeRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaAdministrativeViewModel.HarbourAreaAdministrativeRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourAreaSection>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsHarbourAreaSectionRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourAreaSectionViewModel.HarbourAreaSectionRefIdViewModel>(),
                }, new FeatureAssociationConnector<HarbourBasin>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsHarbourBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<HarbourBasinViewModel.HarbourBasinRefIdViewModel>(),
                }, new FeatureAssociationConnector<MooringWarpingFacility>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsMooringWarpingFacilityRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<MooringWarpingFacilityViewModel.MooringWarpingFacilityRefIdViewModel>(),
                }, new FeatureAssociationConnector<OuterLimit>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsOuterLimitRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<OuterLimitViewModel.OuterLimitRefIdViewModel>(),
                }, new FeatureAssociationConnector<PilotBoardingPlace>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsPilotBoardingPlaceRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<PilotBoardingPlaceViewModel.PilotBoardingPlaceRefIdViewModel>(),
                }, new FeatureAssociationConnector<SeaplaneLandingArea>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsSeaplaneLandingAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<SeaplaneLandingAreaViewModel.SeaplaneLandingAreaRefIdViewModel>(),
                }, new FeatureAssociationConnector<Terminal>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsTerminalRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TerminalViewModel.TerminalRefIdViewModel>(),
                }, new FeatureAssociationConnector<TurningBasin>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsTurningBasinRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TurningBasinViewModel.TurningBasinRefIdViewModel>(),
                }, new FeatureAssociationConnector<WaterwayArea>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 0,
                    Upper = 1,
                    AssociationTypes = [typeof(TextPlacement)],
                    CreateForeignFeatureBinding = () => new OptionalFeatureBindingViewModel<TextAssociationViewModel.positionsWaterwayAreaRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<WaterwayAreaViewModel.WaterwayAreaRefIdViewModel>(),
                }, new FeatureAssociationConnector<TextPlacement>()
                {
                    roleType = roleType.association,
                    role = "positions",
                    Lower = 1,
                    Upper = 1,
                    AssociationTypes = [typeof(DryDock), typeof(FloatingDock), typeof(Gridiron), typeof(HarbourFacility), typeof(AnchorBerth), typeof(AnchorageArea), typeof(Berth), typeof(BerthPosition), typeof(DockArea), typeof(DumpingGround), typeof(HarbourAreaAdministrative), typeof(HarbourAreaSection), typeof(HarbourBasin), typeof(MooringWarpingFacility), typeof(OuterLimit), typeof(PilotBoardingPlace), typeof(SeaplaneLandingArea), typeof(Terminal), typeof(TurningBasin), typeof(WaterwayArea)],
                    CreateForeignFeatureBinding = () => new SingleFeatureBindingViewModel<TextAssociationViewModel.positionsTextPlacementRefIdViewModel>(),
                    CreateLocalFeatureBinding = () => new SingleFeatureBindingViewModel<TextPlacementViewModel.TextPlacementRefIdViewModel>(),
                }

                ]
            },
        };
    }

    [CategoryOrder("contactAddress", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class contactAddressViewModel : ViewModelBase
    {
        [Category("contactAddress")]
        public ObservableCollection<String> deliveryPoint { get; set; } = new();

        private String _cityName = string.Empty;
        [Category("contactAddress")]
        public String cityName
        {
            get
            {
                return _cityName;
            }

            set
            {
                SetValue(ref _cityName, value);
            }
        }

        private String _administrativeDivision = string.Empty;
        [Category("contactAddress")]
        public String administrativeDivision
        {
            get
            {
                return _administrativeDivision;
            }

            set
            {
                SetValue(ref _administrativeDivision, value);
            }
        }

        private String _countryName = string.Empty;
        [Category("contactAddress")]
        public String countryName
        {
            get
            {
                return _countryName;
            }

            set
            {
                SetValue(ref _countryName, value);
            }
        }

        private String _postalCode = string.Empty;
        [Category("contactAddress")]
        public String postalCode
        {
            get
            {
                return _postalCode;
            }

            set
            {
                SetValue(ref _postalCode, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.contactAddress instance)
        {
            deliveryPoint.Clear();
            if (instance.deliveryPoint is not null)
                foreach (var e in instance.deliveryPoint)
                    deliveryPoint.Add(e);
            cityName = instance.cityName;
            administrativeDivision = instance.administrativeDivision;
            countryName = instance.countryName;
            postalCode = instance.postalCode;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.contactAddress
            {
                deliveryPoint = this.deliveryPoint.ToList(),
                cityName = this.cityName,
                administrativeDivision = this.administrativeDivision,
                countryName = this.countryName,
                postalCode = this.postalCode,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.contactAddress Model => new()
        {
            deliveryPoint = this.deliveryPoint.ToList(),
            cityName = this._cityName,
            administrativeDivision = this._administrativeDivision,
            countryName = this._countryName,
            postalCode = this._postalCode,
        };

        public contactAddressViewModel() : base()
        {
            deliveryPoint.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(deliveryPoint));
            };
        }
    }

    [CategoryOrder("featureName", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class featureNameViewModel : ViewModelBase
    {
        private Boolean? _displayName = default;
        [Category("featureName")]
        public Boolean? displayName
        {
            get
            {
                return _displayName;
            }

            set
            {
                SetValue(ref _displayName, value);
            }
        }

        private String _language = string.Empty;
        [Category("featureName")]
        public String language
        {
            get
            {
                return _language;
            }

            set
            {
                SetValue(ref _language, value);
            }
        }

        private String _name = string.Empty;
        [Category("featureName")]
        public String name
        {
            get
            {
                return _name;
            }

            set
            {
                SetValue(ref _name, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.featureName instance)
        {
            displayName = instance.displayName;
            language = instance.language;
            name = instance.name;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.featureName
            {
                displayName = this.displayName,
                language = this.language,
                name = this.name,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.featureName Model => new()
        {
            displayName = this._displayName,
            language = this._language,
            name = this._name,
        };

        public featureNameViewModel() : base()
        {
        }
    }

    [CategoryOrder("fixedDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class fixedDateRangeViewModel : ViewModelBase
    {
        private DateOnly? _dateStart = default;
        [Category("fixedDateRange")]
        public DateOnly? dateStart
        {
            get
            {
                return _dateStart;
            }

            set
            {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly? _dateEnd = default;
        [Category("fixedDateRange")]
        public DateOnly? dateEnd
        {
            get
            {
                return _dateEnd;
            }

            set
            {
                SetValue(ref _dateEnd, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.fixedDateRange instance)
        {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.fixedDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.fixedDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public fixedDateRangeViewModel() : base()
        {
        }
    }

    [CategoryOrder("frequencyPair", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class frequencyPairViewModel : ViewModelBase
    {
        [Category("frequencyPair")]
        public ObservableCollection<Int32> frequencyShoreStationTransmits { get; set; } = new();

        [Category("frequencyPair")]
        public ObservableCollection<Int32> frequencyShoreStationReceives { get; set; } = new();

        [Category("frequencyPair")]
        public ObservableCollection<String> contactInstructions { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.frequencyPair instance)
        {
            frequencyShoreStationTransmits.Clear();
            if (instance.frequencyShoreStationTransmits is not null)
                foreach (var e in instance.frequencyShoreStationTransmits)
                    frequencyShoreStationTransmits.Add(e);
            frequencyShoreStationReceives.Clear();
            if (instance.frequencyShoreStationReceives is not null)
                foreach (var e in instance.frequencyShoreStationReceives)
                    frequencyShoreStationReceives.Add(e);
            contactInstructions.Clear();
            if (instance.contactInstructions is not null)
                foreach (var e in instance.contactInstructions)
                    contactInstructions.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.frequencyPair
            {
                frequencyShoreStationTransmits = this.frequencyShoreStationTransmits.ToList(),
                frequencyShoreStationReceives = this.frequencyShoreStationReceives.ToList(),
                contactInstructions = this.contactInstructions.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.frequencyPair Model => new()
        {
            frequencyShoreStationTransmits = this.frequencyShoreStationTransmits.ToList(),
            frequencyShoreStationReceives = this.frequencyShoreStationReceives.ToList(),
            contactInstructions = this.contactInstructions.ToList(),
        };

        public frequencyPairViewModel() : base()
        {
            frequencyShoreStationTransmits.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(frequencyShoreStationTransmits));
            };
            frequencyShoreStationReceives.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(frequencyShoreStationReceives));
            };
            contactInstructions.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(contactInstructions));
            };
        }
    }

    [CategoryOrder("horizontalPositionUncertainty", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class horizontalPositionUncertaintyViewModel : ViewModelBase
    {
        private Decimal _uncertaintyFixed;
        [Category("horizontalPositionUncertainty")]
        public Decimal uncertaintyFixed
        {
            get
            {
                return _uncertaintyFixed;
            }

            set
            {
                SetValue(ref _uncertaintyFixed, value);
            }
        }

        private Decimal? _uncertaintyVariableFactor = default;
        [Category("horizontalPositionUncertainty")]
        public Decimal? uncertaintyVariableFactor
        {
            get
            {
                return _uncertaintyVariableFactor;
            }

            set
            {
                SetValue(ref _uncertaintyVariableFactor, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.horizontalPositionUncertainty instance)
        {
            uncertaintyFixed = instance.uncertaintyFixed;
            uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.horizontalPositionUncertainty
            {
                uncertaintyFixed = this.uncertaintyFixed,
                uncertaintyVariableFactor = this.uncertaintyVariableFactor,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.horizontalPositionUncertainty Model => new()
        {
            uncertaintyFixed = this._uncertaintyFixed,
            uncertaintyVariableFactor = this._uncertaintyVariableFactor,
        };

        public horizontalPositionUncertaintyViewModel() : base()
        {
        }
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("information", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class informationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private String _fileLocator = string.Empty;
        [Category("information")]
        public String fileLocator
        {
            get
            {
                return _fileLocator;
            }

            set
            {
                SetValue(ref _fileLocator, value);
            }
        }

        private String _fileReference = string.Empty;
        [Category("information")]
        public String fileReference
        {
            get
            {
                return _fileReference;
            }

            set
            {
                SetValue(ref _fileReference, value);
            }
        }

        [Category("information")]
        public ObservableCollection<String> headline { get; set; } = new();

        private String _language = string.Empty;
        [Category("information")]
        public String language
        {
            get
            {
                return _language;
            }

            set
            {
                SetValue(ref _language, value);
            }
        }

        private String _text = string.Empty;
        [Category("information")]
        public String text
        {
            get
            {
                return _text;
            }

            set
            {
                SetValue(ref _text, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.information instance)
        {
            fileLocator = instance.fileLocator;
            fileReference = instance.fileReference;
            headline.Clear();
            if (instance.headline is not null)
                foreach (var e in instance.headline)
                    headline.Add(e);
            language = instance.language;
            text = instance.text;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.information
            {
                fileLocator = this.fileLocator,
                fileReference = this.fileReference,
                headline = this.headline.ToList(),
                language = this.language,
                text = this.text,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.information Model => new()
        {
            fileLocator = this._fileLocator,
            fileReference = this._fileReference,
            headline = this.headline.ToList(),
            language = this._language,
            text = this._text,
        };

        public informationViewModel() : base()
        {
            headline.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(headline));
            };
        }
    }

    [CategoryOrder("onlineResource", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class onlineResourceViewModel : ViewModelBase
    {
        private String _onlineResourceLinkageURL = string.Empty;
        [Category("onlineResource")]
        public String onlineResourceLinkageURL
        {
            get
            {
                return _onlineResourceLinkageURL;
            }

            set
            {
                SetValue(ref _onlineResourceLinkageURL, value);
            }
        }

        private String _protocol = string.Empty;
        [Category("onlineResource")]
        public String protocol
        {
            get
            {
                return _protocol;
            }

            set
            {
                SetValue(ref _protocol, value);
            }
        }

        private String _applicationProfile = string.Empty;
        [Category("onlineResource")]
        public String applicationProfile
        {
            get
            {
                return _applicationProfile;
            }

            set
            {
                SetValue(ref _applicationProfile, value);
            }
        }

        private String _nameOfResource = string.Empty;
        [Category("onlineResource")]
        public String nameOfResource
        {
            get
            {
                return _nameOfResource;
            }

            set
            {
                SetValue(ref _nameOfResource, value);
            }
        }

        private String _onlineResourceDescription = string.Empty;
        [Category("onlineResource")]
        public String onlineResourceDescription
        {
            get
            {
                return _onlineResourceDescription;
            }

            set
            {
                SetValue(ref _onlineResourceDescription, value);
            }
        }

        private onlineFunction? _onlineFunction = default;
        [Category("onlineResource")]
        public onlineFunction? onlineFunction
        {
            get
            {
                return _onlineFunction;
            }

            set
            {
                SetValue(ref _onlineFunction, value);
            }
        }

        private String _protocolRequest = string.Empty;
        [Category("onlineResource")]
        public String protocolRequest
        {
            get
            {
                return _protocolRequest;
            }

            set
            {
                SetValue(ref _protocolRequest, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.onlineResource instance)
        {
            onlineResourceLinkageURL = instance.onlineResourceLinkageURL;
            protocol = instance.protocol;
            applicationProfile = instance.applicationProfile;
            nameOfResource = instance.nameOfResource;
            onlineResourceDescription = instance.onlineResourceDescription;
            onlineFunction = instance.onlineFunction;
            protocolRequest = instance.protocolRequest;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.onlineResource
            {
                onlineResourceLinkageURL = this.onlineResourceLinkageURL,
                protocol = this.protocol,
                applicationProfile = this.applicationProfile,
                nameOfResource = this.nameOfResource,
                onlineResourceDescription = this.onlineResourceDescription,
                onlineFunction = this.onlineFunction,
                protocolRequest = this.protocolRequest,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.onlineResource Model => new()
        {
            onlineResourceLinkageURL = this._onlineResourceLinkageURL,
            protocol = this._protocol,
            applicationProfile = this._applicationProfile,
            nameOfResource = this._nameOfResource,
            onlineResourceDescription = this._onlineResourceDescription,
            onlineFunction = this._onlineFunction,
            protocolRequest = this._protocolRequest,
        };

        public onlineResourceViewModel() : base()
        {
        }
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("orientation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class orientationViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private Decimal? _orientationUncertainty = default;
        [Category("orientation")]
        public Decimal? orientationUncertainty
        {
            get
            {
                return _orientationUncertainty;
            }

            set
            {
                SetValue(ref _orientationUncertainty, value);
            }
        }

        private Decimal _orientationValue;
        [Category("orientation")]
        public Decimal orientationValue
        {
            get
            {
                return _orientationValue;
            }

            set
            {
                SetValue(ref _orientationValue, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.orientation instance)
        {
            orientationUncertainty = instance.orientationUncertainty;
            orientationValue = instance.orientationValue;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.orientation
            {
                orientationUncertainty = this.orientationUncertainty,
                orientationValue = this.orientationValue,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.orientation Model => new()
        {
            orientationUncertainty = this._orientationUncertainty,
            orientationValue = this._orientationValue,
        };

        public orientationViewModel() : base()
        {
        }
    }

    [CategoryOrder("periodicDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class periodicDateRangeViewModel : ViewModelBase
    {
        private DateOnly _dateStart;
        [Category("periodicDateRange")]
        public DateOnly dateStart
        {
            get
            {
                return _dateStart;
            }

            set
            {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly _dateEnd;
        [Category("periodicDateRange")]
        public DateOnly dateEnd
        {
            get
            {
                return _dateEnd;
            }

            set
            {
                SetValue(ref _dateEnd, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.periodicDateRange instance)
        {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.periodicDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.periodicDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public periodicDateRangeViewModel() : base()
        {
        }
    }

    [CategoryOrder("rxNCode", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class rxNCodeViewModel : ViewModelBase
    {
        private categoryOfRxN? _categoryOfRxN;
        [DomainModel.CodeList(nameof(categoryOfRxNList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("rxNCode")]
        public categoryOfRxN? categoryOfRxN
        {
            get
            {
                return _categoryOfRxN;
            }

            set
            {
                SetValue(ref _categoryOfRxN, value);
            }
        }

        private actionOrActivity? _actionOrActivity;
        [DomainModel.CodeList(nameof(actionOrActivityList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("rxNCode")]
        public actionOrActivity? actionOrActivity
        {
            get
            {
                return _actionOrActivity;
            }

            set
            {
                SetValue(ref _actionOrActivity, value);
            }
        }

        [Category("rxNCode")]
        public ObservableCollection<String> headline { get; set; } = new();

        [Browsable(false)]
        public categoryOfRxN[] categoryOfRxNList => CodeList.categoryOfRxNS.ToArray();

        [Browsable(false)]
        public actionOrActivity[] actionOrActivityList => CodeList.actionOrActivities.ToArray();

        public void Load(DomainModel.S131.ComplexAttributes.rxNCode instance)
        {
            categoryOfRxN = instance.categoryOfRxN;
            actionOrActivity = instance.actionOrActivity;
            headline.Clear();
            if (instance.headline is not null)
                foreach (var e in instance.headline)
                    headline.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.rxNCode
            {
                categoryOfRxN = this.categoryOfRxN,
                actionOrActivity = this.actionOrActivity,
                headline = this.headline.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.rxNCode Model => new()
        {
            categoryOfRxN = this._categoryOfRxN,
            actionOrActivity = this._actionOrActivity,
            headline = this.headline.ToList(),
        };

        public rxNCodeViewModel() : base()
        {
            headline.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(headline));
            };
        }
    }

    [CategoryOrder("surveyDateRange", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class surveyDateRangeViewModel : ViewModelBase
    {
        private DateOnly? _dateStart = default;
        [Category("surveyDateRange")]
        public DateOnly? dateStart
        {
            get
            {
                return _dateStart;
            }

            set
            {
                SetValue(ref _dateStart, value);
            }
        }

        private DateOnly _dateEnd;
        [Category("surveyDateRange")]
        public DateOnly dateEnd
        {
            get
            {
                return _dateEnd;
            }

            set
            {
                SetValue(ref _dateEnd, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.surveyDateRange instance)
        {
            dateStart = instance.dateStart;
            dateEnd = instance.dateEnd;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.surveyDateRange
            {
                dateStart = this.dateStart,
                dateEnd = this.dateEnd,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.surveyDateRange Model => new()
        {
            dateStart = this._dateStart,
            dateEnd = this._dateEnd,
        };

        public surveyDateRangeViewModel() : base()
        {
        }
    }

    [CategoryOrder("textContent", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class textContentViewModel : ViewModelBase
    {
        private categoryOfText? _categoryOfText = default;
        [Category("textContent")]
        public categoryOfText? categoryOfText
        {
            get
            {
                return _categoryOfText;
            }

            set
            {
                SetValue(ref _categoryOfText, value);
            }
        }

        [Category("textContent")]
        public ObservableCollection<information> information { get; set; } = new();

        private onlineResourceViewModel? _onlineResource;
        [Category("textContent")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public onlineResourceViewModel? onlineResource
        {
            get
            {
                return _onlineResource;
            }

            set
            {
                SetValue(ref _onlineResource, value);
            }
        }

        private String _source = string.Empty;
        [Category("textContent")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("textContent")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("textContent")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.textContent instance)
        {
            categoryOfText = instance.categoryOfText;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            onlineResource = new();
            if (instance.onlineResource != null)
            {
                onlineResource = new();
                onlineResource.Load(instance.onlineResource);
            }

            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.textContent
            {
                categoryOfText = this.categoryOfText,
                information = this.information.ToList(),
                onlineResource = this.onlineResource?.Model,
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.textContent Model => new()
        {
            categoryOfText = this._categoryOfText,
            information = this.information.ToList(),
            onlineResource = this._onlineResource?.Model,
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public textContentViewModel() : base()
        {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
        }
    }

    [CategoryOrder("timeIntervalsByDayOfWeek", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class timeIntervalsByDayOfWeekViewModel : ViewModelBase
    {
        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<dayOfWeek> dayOfWeek { get; set; } = new();

        private Boolean? _dayOfWeekIsRange = default;
        [Category("timeIntervalsByDayOfWeek")]
        public Boolean? dayOfWeekIsRange
        {
            get
            {
                return _dayOfWeekIsRange;
            }

            set
            {
                SetValue(ref _dayOfWeekIsRange, value);
            }
        }

        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<TimeOnly> timeOfDayStart { get; set; } = new();

        [Category("timeIntervalsByDayOfWeek")]
        public ObservableCollection<TimeOnly> timeOfDayEnd { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.timeIntervalsByDayOfWeek instance)
        {
            dayOfWeek.Clear();
            if (instance.dayOfWeek is not null)
                foreach (var e in instance.dayOfWeek)
                    dayOfWeek.Add(e);
            dayOfWeekIsRange = instance.dayOfWeekIsRange;
            timeOfDayStart.Clear();
            if (instance.timeOfDayStart is not null)
                foreach (var e in instance.timeOfDayStart)
                    timeOfDayStart.Add(e);
            timeOfDayEnd.Clear();
            if (instance.timeOfDayEnd is not null)
                foreach (var e in instance.timeOfDayEnd)
                    timeOfDayEnd.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.timeIntervalsByDayOfWeek
            {
                dayOfWeek = this.dayOfWeek.ToList(),
                dayOfWeekIsRange = this.dayOfWeekIsRange,
                timeOfDayStart = this.timeOfDayStart.ToList(),
                timeOfDayEnd = this.timeOfDayEnd.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.timeIntervalsByDayOfWeek Model => new()
        {
            dayOfWeek = this.dayOfWeek.ToList(),
            dayOfWeekIsRange = this._dayOfWeekIsRange,
            timeOfDayStart = this.timeOfDayStart.ToList(),
            timeOfDayEnd = this.timeOfDayEnd.ToList(),
        };

        public timeIntervalsByDayOfWeekViewModel() : base()
        {
            dayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(dayOfWeek));
            };
            timeOfDayStart.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(timeOfDayStart));
            };
            timeOfDayEnd.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(timeOfDayEnd));
            };
        }
    }

    [CategoryOrder("usefulMarkDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class usefulMarkDescriptionViewModel : ViewModelBase
    {
        [Category("usefulMarkDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.usefulMarkDescription instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.usefulMarkDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.usefulMarkDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public usefulMarkDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("verticalUncertainty", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class verticalUncertaintyViewModel : ViewModelBase
    {
        private Decimal _uncertaintyFixed;
        [Category("verticalUncertainty")]
        public Decimal uncertaintyFixed
        {
            get
            {
                return _uncertaintyFixed;
            }

            set
            {
                SetValue(ref _uncertaintyFixed, value);
            }
        }

        private Decimal? _uncertaintyVariableFactor = default;
        [Category("verticalUncertainty")]
        public Decimal? uncertaintyVariableFactor
        {
            get
            {
                return _uncertaintyVariableFactor;
            }

            set
            {
                SetValue(ref _uncertaintyVariableFactor, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.verticalUncertainty instance)
        {
            uncertaintyFixed = instance.uncertaintyFixed;
            uncertaintyVariableFactor = instance.uncertaintyVariableFactor;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.verticalUncertainty
            {
                uncertaintyFixed = this.uncertaintyFixed,
                uncertaintyVariableFactor = this.uncertaintyVariableFactor,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.verticalUncertainty Model => new()
        {
            uncertaintyFixed = this._uncertaintyFixed,
            uncertaintyVariableFactor = this._uncertaintyVariableFactor,
        };

        public verticalUncertaintyViewModel() : base()
        {
        }
    }

    [CategoryOrder("vesselsMeasurements", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class vesselsMeasurementsViewModel : ViewModelBase
    {
        private comparisonOperator _comparisonOperator;
        [Category("vesselsMeasurements")]
        public comparisonOperator comparisonOperator
        {
            get
            {
                return _comparisonOperator;
            }

            set
            {
                SetValue(ref _comparisonOperator, value);
            }
        }

        private vesselsCharacteristics _vesselsCharacteristics;
        [Category("vesselsMeasurements")]
        public vesselsCharacteristics vesselsCharacteristics
        {
            get
            {
                return _vesselsCharacteristics;
            }

            set
            {
                SetValue(ref _vesselsCharacteristics, value);
            }
        }

        private Decimal _vesselsCharacteristicsValue;
        [Category("vesselsMeasurements")]
        public Decimal vesselsCharacteristicsValue
        {
            get
            {
                return _vesselsCharacteristicsValue;
            }

            set
            {
                SetValue(ref _vesselsCharacteristicsValue, value);
            }
        }

        private vesselsCharacteristicsUnit _vesselsCharacteristicsUnit;
        [Category("vesselsMeasurements")]
        public vesselsCharacteristicsUnit vesselsCharacteristicsUnit
        {
            get
            {
                return _vesselsCharacteristicsUnit;
            }

            set
            {
                SetValue(ref _vesselsCharacteristicsUnit, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.vesselsMeasurements instance)
        {
            comparisonOperator = instance.comparisonOperator;
            vesselsCharacteristics = instance.vesselsCharacteristics;
            vesselsCharacteristicsValue = instance.vesselsCharacteristicsValue;
            vesselsCharacteristicsUnit = instance.vesselsCharacteristicsUnit;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.vesselsMeasurements
            {
                comparisonOperator = this.comparisonOperator,
                vesselsCharacteristics = this.vesselsCharacteristics,
                vesselsCharacteristicsValue = this.vesselsCharacteristicsValue,
                vesselsCharacteristicsUnit = this.vesselsCharacteristicsUnit,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.vesselsMeasurements Model => new()
        {
            comparisonOperator = this._comparisonOperator,
            vesselsCharacteristics = this._vesselsCharacteristics,
            vesselsCharacteristicsValue = this._vesselsCharacteristicsValue,
            vesselsCharacteristicsUnit = this._vesselsCharacteristicsUnit,
        };

        public vesselsMeasurementsViewModel() : base()
        {
        }
    }

    [CategoryOrder("weatherResource", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class weatherResourceViewModel : ViewModelBase
    {
        private onlineResourceViewModel? _onlineResource;
        [Category("weatherResource")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public onlineResourceViewModel? onlineResource
        {
            get
            {
                return _onlineResource;
            }

            set
            {
                SetValue(ref _onlineResource, value);
            }
        }

        private dynamicResource? _dynamicResource = default;
        [Category("weatherResource")]
        public dynamicResource? dynamicResource
        {
            get
            {
                return _dynamicResource;
            }

            set
            {
                SetValue(ref _dynamicResource, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("weatherResource")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent
        {
            get
            {
                return _textContent;
            }

            set
            {
                SetValue(ref _textContent, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.weatherResource instance)
        {
            onlineResource = new();
            if (instance.onlineResource != null)
            {
                onlineResource = new();
                onlineResource.Load(instance.onlineResource);
            }

            dynamicResource = instance.dynamicResource;
            textContent = new();
            if (instance.textContent != null)
            {
                textContent = new();
                textContent.Load(instance.textContent);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.weatherResource
            {
                onlineResource = this.onlineResource?.Model,
                dynamicResource = this.dynamicResource,
                textContent = this.textContent?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.weatherResource Model => new()
        {
            onlineResource = this._onlineResource?.Model,
            dynamicResource = this._dynamicResource,
            textContent = this._textContent?.Model,
        };

        public weatherResourceViewModel() : base()
        {
        }
    }

    [CategoryOrder("bearingInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class bearingInformationViewModel : ViewModelBase
    {
        private cardinalDirection? _cardinalDirection = default;
        [Category("bearingInformation")]
        public cardinalDirection? cardinalDirection
        {
            get
            {
                return _cardinalDirection;
            }

            set
            {
                SetValue(ref _cardinalDirection, value);
            }
        }

        private Decimal? _distance = default;
        [Category("bearingInformation")]
        public Decimal? distance
        {
            get
            {
                return _distance;
            }

            set
            {
                SetValue(ref _distance, value);
            }
        }

        [Category("bearingInformation")]
        public ObservableCollection<Decimal> sectorBearing { get; set; } = new();

        [Category("bearingInformation")]
        public ObservableCollection<information> information { get; set; } = new();

        private orientationViewModel? _orientation;
        [Category("bearingInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public orientationViewModel? orientation
        {
            get
            {
                return _orientation;
            }

            set
            {
                SetValue(ref _orientation, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.bearingInformation instance)
        {
            cardinalDirection = instance.cardinalDirection;
            distance = instance.distance;
            sectorBearing.Clear();
            if (instance.sectorBearing is not null)
                foreach (var e in instance.sectorBearing)
                    sectorBearing.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            orientation = new();
            if (instance.orientation != null)
            {
                orientation = new();
                orientation.Load(instance.orientation);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.bearingInformation
            {
                cardinalDirection = this.cardinalDirection,
                distance = this.distance,
                sectorBearing = this.sectorBearing.ToList(),
                information = this.information.ToList(),
                orientation = this.orientation?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.bearingInformation Model => new()
        {
            cardinalDirection = this._cardinalDirection,
            distance = this._distance,
            sectorBearing = this.sectorBearing.ToList(),
            information = this.information.ToList(),
            orientation = this._orientation?.Model,
        };

        public bearingInformationViewModel() : base()
        {
            sectorBearing.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(sectorBearing));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
        }
    }

    [CategoryOrder("cargoServicesDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class cargoServicesDescriptionViewModel : ViewModelBase
    {
        [Category("cargoServicesDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.cargoServicesDescription instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.cargoServicesDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.cargoServicesDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public cargoServicesDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("constructionInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class constructionInformationViewModel : ViewModelBase
    {
        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("constructionInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private condition? _condition = default;
        [Category("constructionInformation")]
        public condition? condition
        {
            get
            {
                return _condition;
            }

            set
            {
                SetValue(ref _condition, value);
            }
        }

        private String _development = string.Empty;
        [Category("constructionInformation")]
        public String development
        {
            get
            {
                return _development;
            }

            set
            {
                SetValue(ref _development, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("constructionInformation")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        [Category("constructionInformation")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.constructionInformation instance)
        {
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            condition = instance.condition;
            development = instance.development;
            locationByText = instance.locationByText;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.constructionInformation
            {
                fixedDateRange = this.fixedDateRange?.Model,
                condition = this.condition,
                development = this.development,
                locationByText = this.locationByText,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.constructionInformation Model => new()
        {
            fixedDateRange = this._fixedDateRange?.Model,
            condition = this._condition,
            development = this._development,
            locationByText = this._locationByText,
            textContent = this.textContent.ToList(),
        };

        public constructionInformationViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("depthsDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class depthsDescriptionViewModel : ViewModelBase
    {
        private categoryOfDepthsDescription _categoryOfDepthsDescription;
        [Category("depthsDescription")]
        public categoryOfDepthsDescription categoryOfDepthsDescription
        {
            get
            {
                return _categoryOfDepthsDescription;
            }

            set
            {
                SetValue(ref _categoryOfDepthsDescription, value);
            }
        }

        [Category("depthsDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.depthsDescription instance)
        {
            categoryOfDepthsDescription = instance.categoryOfDepthsDescription;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.depthsDescription
            {
                categoryOfDepthsDescription = this.categoryOfDepthsDescription,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.depthsDescription Model => new()
        {
            categoryOfDepthsDescription = this._categoryOfDepthsDescription,
            textContent = this.textContent.ToList(),
        };

        public depthsDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("facilitiesLayoutDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class facilitiesLayoutDescriptionViewModel : ViewModelBase
    {
        [Category("facilitiesLayoutDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.facilitiesLayoutDescription instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.facilitiesLayoutDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.facilitiesLayoutDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public facilitiesLayoutDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("generalPortDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class generalPortDescriptionViewModel : ViewModelBase
    {
        [Category("generalPortDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.generalPortDescription instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.generalPortDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.generalPortDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public generalPortDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("graphic", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class graphicViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        [Category("graphic")]
        public ObservableCollection<String> pictorialRepresentation { get; set; } = new();

        private String _pictureCaption = string.Empty;
        [Category("graphic")]
        public String pictureCaption
        {
            get
            {
                return _pictureCaption;
            }

            set
            {
                SetValue(ref _pictureCaption, value);
            }
        }

        private DateTime? _sourceDate = default;
        [Category("graphic")]
        public DateTime? sourceDate
        {
            get
            {
                return _sourceDate;
            }

            set
            {
                SetValue(ref _sourceDate, value);
            }
        }

        private String _pictureInformation = string.Empty;
        [Category("graphic")]
        public String pictureInformation
        {
            get
            {
                return _pictureInformation;
            }

            set
            {
                SetValue(ref _pictureInformation, value);
            }
        }

        private bearingInformationViewModel? _bearingInformation;
        [Category("graphic")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public bearingInformationViewModel? bearingInformation
        {
            get
            {
                return _bearingInformation;
            }

            set
            {
                SetValue(ref _bearingInformation, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.graphic instance)
        {
            pictorialRepresentation.Clear();
            if (instance.pictorialRepresentation is not null)
                foreach (var e in instance.pictorialRepresentation)
                    pictorialRepresentation.Add(e);
            pictureCaption = instance.pictureCaption;
            sourceDate = instance.sourceDate;
            pictureInformation = instance.pictureInformation;
            bearingInformation = new();
            if (instance.bearingInformation != null)
            {
                bearingInformation = new();
                bearingInformation.Load(instance.bearingInformation);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.graphic
            {
                pictorialRepresentation = this.pictorialRepresentation.ToList(),
                pictureCaption = this.pictureCaption,
                sourceDate = this.sourceDate,
                pictureInformation = this.pictureInformation,
                bearingInformation = this.bearingInformation?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.graphic Model => new()
        {
            pictorialRepresentation = this.pictorialRepresentation.ToList(),
            pictureCaption = this._pictureCaption,
            sourceDate = this._sourceDate,
            pictureInformation = this._pictureInformation,
            bearingInformation = this._bearingInformation?.Model,
        };

        public graphicViewModel() : base()
        {
            pictorialRepresentation.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(pictorialRepresentation));
            };
        }
    }

    [CategoryOrder("landmarkDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class landmarkDescriptionViewModel : ViewModelBase
    {
        [Category("landmarkDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.landmarkDescription instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.landmarkDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.landmarkDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public landmarkDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("limitsDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class limitsDescriptionViewModel : ViewModelBase
    {
        [Category("limitsDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.limitsDescription instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.limitsDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.limitsDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public limitsDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("majorLightDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class majorLightDescriptionViewModel : ViewModelBase
    {
        [Category("majorLightDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.majorLightDescription instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.majorLightDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.majorLightDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public majorLightDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("markedBy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class markedByViewModel : ViewModelBase
    {
        [Category("markedBy")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.markedBy instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.markedBy
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.markedBy Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public markedByViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("offshoreMarkDescription", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class offshoreMarkDescriptionViewModel : ViewModelBase
    {
        [Category("offshoreMarkDescription")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.offshoreMarkDescription instance)
        {
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.offshoreMarkDescription
            {
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.offshoreMarkDescription Model => new()
        {
            textContent = this.textContent.ToList(),
        };

        public offshoreMarkDescriptionViewModel() : base()
        {
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("scheduleByDayOfWeek", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class scheduleByDayOfWeekViewModel : ViewModelBase
    {
        private categoryOfSchedule? _categoryOfSchedule = default;
        [Category("scheduleByDayOfWeek")]
        public categoryOfSchedule? categoryOfSchedule
        {
            get
            {
                return _categoryOfSchedule;
            }

            set
            {
                SetValue(ref _categoryOfSchedule, value);
            }
        }

        [Category("scheduleByDayOfWeek")]
        public ObservableCollection<timeIntervalsByDayOfWeek> timeIntervalsByDayOfWeek { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.scheduleByDayOfWeek instance)
        {
            categoryOfSchedule = instance.categoryOfSchedule;
            timeIntervalsByDayOfWeek.Clear();
            if (instance.timeIntervalsByDayOfWeek is not null)
                foreach (var e in instance.timeIntervalsByDayOfWeek)
                    timeIntervalsByDayOfWeek.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.scheduleByDayOfWeek
            {
                categoryOfSchedule = this.categoryOfSchedule,
                timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.scheduleByDayOfWeek Model => new()
        {
            categoryOfSchedule = this._categoryOfSchedule,
            timeIntervalsByDayOfWeek = this.timeIntervalsByDayOfWeek.ToList(),
        };

        public scheduleByDayOfWeekViewModel() : base()
        {
            timeIntervalsByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(timeIntervalsByDayOfWeek));
            };
        }
    }

    [CategoryOrder("spatialAccuracy", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class spatialAccuracyViewModel : ViewModelBase
    {
        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("spatialAccuracy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        private horizontalPositionUncertaintyViewModel? _horizontalPositionUncertainty;
        [Category("spatialAccuracy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public horizontalPositionUncertaintyViewModel? horizontalPositionUncertainty
        {
            get
            {
                return _horizontalPositionUncertainty;
            }

            set
            {
                SetValue(ref _horizontalPositionUncertainty, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("spatialAccuracy")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty
        {
            get
            {
                return _verticalUncertainty;
            }

            set
            {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.spatialAccuracy instance)
        {
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            horizontalPositionUncertainty = new();
            if (instance.horizontalPositionUncertainty != null)
            {
                horizontalPositionUncertainty = new();
                horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
            }

            verticalUncertainty = new();
            if (instance.verticalUncertainty != null)
            {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.spatialAccuracy
            {
                fixedDateRange = this.fixedDateRange?.Model,
                horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
                verticalUncertainty = this.verticalUncertainty?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.spatialAccuracy Model => new()
        {
            fixedDateRange = this._fixedDateRange?.Model,
            horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
            verticalUncertainty = this._verticalUncertainty?.Model,
        };

        public spatialAccuracyViewModel() : base()
        {
        }
    }

#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    [CategoryOrder("telecommunications", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class telecommunicationsViewModel : ViewModelBase
#pragma warning restore CS8981
    {
        private categoryOfCommunicationPreference? _categoryOfCommunicationPreference = default;
        [Category("telecommunications")]
        public categoryOfCommunicationPreference? categoryOfCommunicationPreference
        {
            get
            {
                return _categoryOfCommunicationPreference;
            }

            set
            {
                SetValue(ref _categoryOfCommunicationPreference, value);
            }
        }

        private String _telecommunicationIdentifier = string.Empty;
        [Category("telecommunications")]
        public String telecommunicationIdentifier
        {
            get
            {
                return _telecommunicationIdentifier;
            }

            set
            {
                SetValue(ref _telecommunicationIdentifier, value);
            }
        }

        private String _telecommunicationCarrier = string.Empty;
        [Category("telecommunications")]
        public String telecommunicationCarrier
        {
            get
            {
                return _telecommunicationCarrier;
            }

            set
            {
                SetValue(ref _telecommunicationCarrier, value);
            }
        }

        private String _contactInstructions = string.Empty;
        [Category("telecommunications")]
        public String contactInstructions
        {
            get
            {
                return _contactInstructions;
            }

            set
            {
                SetValue(ref _contactInstructions, value);
            }
        }

        [Category("telecommunications")]
        public ObservableCollection<telecommunicationService> telecommunicationService { get; set; } = new();

        private scheduleByDayOfWeekViewModel? _scheduleByDayOfWeek;
        [Category("telecommunications")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public scheduleByDayOfWeekViewModel? scheduleByDayOfWeek
        {
            get
            {
                return _scheduleByDayOfWeek;
            }

            set
            {
                SetValue(ref _scheduleByDayOfWeek, value);
            }
        }

        public void Load(DomainModel.S131.ComplexAttributes.telecommunications instance)
        {
            categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
            telecommunicationIdentifier = instance.telecommunicationIdentifier;
            telecommunicationCarrier = instance.telecommunicationCarrier;
            contactInstructions = instance.contactInstructions;
            telecommunicationService.Clear();
            if (instance.telecommunicationService is not null)
                foreach (var e in instance.telecommunicationService)
                    telecommunicationService.Add(e);
            scheduleByDayOfWeek = new();
            if (instance.scheduleByDayOfWeek != null)
            {
                scheduleByDayOfWeek = new();
                scheduleByDayOfWeek.Load(instance.scheduleByDayOfWeek);
            }
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.telecommunications
            {
                categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
                telecommunicationIdentifier = this.telecommunicationIdentifier,
                telecommunicationCarrier = this.telecommunicationCarrier,
                contactInstructions = this.contactInstructions,
                telecommunicationService = this.telecommunicationService.ToList(),
                scheduleByDayOfWeek = this.scheduleByDayOfWeek?.Model,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.telecommunications Model => new()
        {
            categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
            telecommunicationIdentifier = this._telecommunicationIdentifier,
            telecommunicationCarrier = this._telecommunicationCarrier,
            contactInstructions = this._contactInstructions,
            telecommunicationService = this.telecommunicationService.ToList(),
            scheduleByDayOfWeek = this._scheduleByDayOfWeek?.Model,
        };

        public telecommunicationsViewModel() : base()
        {
            telecommunicationService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(telecommunicationService));
            };
        }
    }

    [CategoryOrder("generalHarbourInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class generalHarbourInformationViewModel : ViewModelBase
    {
        private generalPortDescriptionViewModel? _generalPortDescription;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public generalPortDescriptionViewModel? generalPortDescription
        {
            get
            {
                return _generalPortDescription;
            }

            set
            {
                SetValue(ref _generalPortDescription, value);
            }
        }

        private facilitiesLayoutDescriptionViewModel? _facilitiesLayoutDescription;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public facilitiesLayoutDescriptionViewModel? facilitiesLayoutDescription
        {
            get
            {
                return _facilitiesLayoutDescription;
            }

            set
            {
                SetValue(ref _facilitiesLayoutDescription, value);
            }
        }

        private limitsDescriptionViewModel? _limitsDescription;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public limitsDescriptionViewModel? limitsDescription
        {
            get
            {
                return _limitsDescription;
            }

            set
            {
                SetValue(ref _limitsDescription, value);
            }
        }

        private constructionInformationViewModel? _constructionInformation;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public constructionInformationViewModel? constructionInformation
        {
            get
            {
                return _constructionInformation;
            }

            set
            {
                SetValue(ref _constructionInformation, value);
            }
        }

        private cargoServicesDescriptionViewModel? _cargoServicesDescription;
        [Category("generalHarbourInformation")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public cargoServicesDescriptionViewModel? cargoServicesDescription
        {
            get
            {
                return _cargoServicesDescription;
            }

            set
            {
                SetValue(ref _cargoServicesDescription, value);
            }
        }

        [Category("generalHarbourInformation")]
        public ObservableCollection<weatherResource> weatherResource { get; set; } = new();

        public void Load(DomainModel.S131.ComplexAttributes.generalHarbourInformation instance)
        {
            generalPortDescription = new();
            if (instance.generalPortDescription != null)
            {
                generalPortDescription = new();
                generalPortDescription.Load(instance.generalPortDescription);
            }

            facilitiesLayoutDescription = new();
            if (instance.facilitiesLayoutDescription != null)
            {
                facilitiesLayoutDescription = new();
                facilitiesLayoutDescription.Load(instance.facilitiesLayoutDescription);
            }

            limitsDescription = new();
            if (instance.limitsDescription != null)
            {
                limitsDescription = new();
                limitsDescription.Load(instance.limitsDescription);
            }

            constructionInformation = new();
            if (instance.constructionInformation != null)
            {
                constructionInformation = new();
                constructionInformation.Load(instance.constructionInformation);
            }

            cargoServicesDescription = new();
            if (instance.cargoServicesDescription != null)
            {
                cargoServicesDescription = new();
                cargoServicesDescription.Load(instance.cargoServicesDescription);
            }

            weatherResource.Clear();
            if (instance.weatherResource is not null)
                foreach (var e in instance.weatherResource)
                    weatherResource.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.ComplexAttributes.generalHarbourInformation
            {
                generalPortDescription = this.generalPortDescription?.Model,
                facilitiesLayoutDescription = this.facilitiesLayoutDescription?.Model,
                limitsDescription = this.limitsDescription?.Model,
                constructionInformation = this.constructionInformation?.Model,
                cargoServicesDescription = this.cargoServicesDescription?.Model,
                weatherResource = this.weatherResource.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.ComplexAttributes.generalHarbourInformation Model => new()
        {
            generalPortDescription = this._generalPortDescription?.Model,
            facilitiesLayoutDescription = this._facilitiesLayoutDescription?.Model,
            limitsDescription = this._limitsDescription?.Model,
            constructionInformation = this._constructionInformation?.Model,
            cargoServicesDescription = this._cargoServicesDescription?.Model,
            weatherResource = this.weatherResource.ToList(),
        };

        public generalHarbourInformationViewModel() : base()
        {
            weatherResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(weatherResource));
            };
        }
    }

    [CategoryOrder("Applicability", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ApplicabilityViewModel : ViewModelBase
    {
        private Boolean? _inBallast = default;
        [Category("Applicability")]
        public Boolean? inBallast
        {
            get
            {
                return _inBallast;
            }

            set
            {
                SetValue(ref _inBallast, value);
            }
        }

        [Category("Applicability")]
        public ObservableCollection<categoryOfCargo> categoryOfCargo { get; set; } = new();

        [Category("Applicability")]
        public ObservableCollection<categoryOfDangerousOrHazardousCargo> categoryOfDangerousOrHazardousCargo { get; set; } = new();

        private categoryOfVessel? _categoryOfVessel;
        [DomainModel.CodeList(nameof(categoryOfVesselList))]
        [Editor(typeof(Editors.CodeListComboEditor), typeof(Editors.CodeListComboEditor))]
        [Category("Applicability")]
        public categoryOfVessel? categoryOfVessel
        {
            get
            {
                return _categoryOfVessel;
            }

            set
            {
                SetValue(ref _categoryOfVessel, value);
            }
        }

        private categoryOfVesselRegistry? _categoryOfVesselRegistry = default;
        [Category("Applicability")]
        public categoryOfVesselRegistry? categoryOfVesselRegistry
        {
            get
            {
                return _categoryOfVesselRegistry;
            }

            set
            {
                SetValue(ref _categoryOfVesselRegistry, value);
            }
        }

        private logicalConnectives? _logicalConnectives = default;
        [Category("Applicability")]
        public logicalConnectives? logicalConnectives
        {
            get
            {
                return _logicalConnectives;
            }

            set
            {
                SetValue(ref _logicalConnectives, value);
            }
        }

        private Int32? _thicknessOfIceCapability = default;
        [Category("Applicability")]
        public Int32? thicknessOfIceCapability
        {
            get
            {
                return _thicknessOfIceCapability;
            }

            set
            {
                SetValue(ref _thicknessOfIceCapability, value);
            }
        }

        private String _vesselPerformance = string.Empty;
        [Category("Applicability")]
        public String vesselPerformance
        {
            get
            {
                return _vesselPerformance;
            }

            set
            {
                SetValue(ref _vesselPerformance, value);
            }
        }

        [Category("Applicability")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("Applicability")]
        public ObservableCollection<vesselsMeasurements> vesselsMeasurements { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class ApplicabilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        [Browsable(false)]
        public categoryOfVessel[] categoryOfVesselList => CodeList.categoryOfVessels.ToArray();

        public void Load(DomainModel.S131.InformationTypes.Applicability instance)
        {
            inBallast = instance.inBallast;
            categoryOfCargo.Clear();
            if (instance.categoryOfCargo is not null)
                foreach (var e in instance.categoryOfCargo)
                    categoryOfCargo.Add(e);
            categoryOfDangerousOrHazardousCargo.Clear();
            if (instance.categoryOfDangerousOrHazardousCargo is not null)
                foreach (var e in instance.categoryOfDangerousOrHazardousCargo)
                    categoryOfDangerousOrHazardousCargo.Add(e);
            categoryOfVessel = instance.categoryOfVessel;
            categoryOfVesselRegistry = instance.categoryOfVesselRegistry;
            logicalConnectives = instance.logicalConnectives;
            thicknessOfIceCapability = instance.thicknessOfIceCapability;
            vesselPerformance = instance.vesselPerformance;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            vesselsMeasurements.Clear();
            if (instance.vesselsMeasurements is not null)
                foreach (var e in instance.vesselsMeasurements)
                    vesselsMeasurements.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.Applicability
            {
                inBallast = this.inBallast,
                categoryOfCargo = this.categoryOfCargo.ToList(),
                categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
                categoryOfVessel = this.categoryOfVessel,
                categoryOfVesselRegistry = this.categoryOfVesselRegistry,
                logicalConnectives = this.logicalConnectives,
                thicknessOfIceCapability = this.thicknessOfIceCapability,
                vesselPerformance = this.vesselPerformance,
                information = this.information.ToList(),
                vesselsMeasurements = this.vesselsMeasurements.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Applicability Model => new()
        {
            inBallast = this._inBallast,
            categoryOfCargo = this.categoryOfCargo.ToList(),
            categoryOfDangerousOrHazardousCargo = this.categoryOfDangerousOrHazardousCargo.ToList(),
            categoryOfVessel = this._categoryOfVessel,
            categoryOfVesselRegistry = this._categoryOfVesselRegistry,
            logicalConnectives = this._logicalConnectives,
            thicknessOfIceCapability = this._thicknessOfIceCapability,
            vesselPerformance = this._vesselPerformance,
            information = this.information.ToList(),
            vesselsMeasurements = this.vesselsMeasurements.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ApplicabilityViewModel() : base()
        {
            categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfCargo));
            };
            categoryOfDangerousOrHazardousCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfDangerousOrHazardousCargo));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
            vesselsMeasurements.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(vesselsMeasurements));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Authority", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AuthorityViewModel : ViewModelBase
    {
        private categoryOfAuthority _categoryOfAuthority;
        [Category("Authority")]
        public categoryOfAuthority categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        private textContentViewModel? _textContent;
        [Category("Authority")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public textContentViewModel? textContent
        {
            get
            {
                return _textContent;
            }

            set
            {
                SetValue(ref _textContent, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class AuthorityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public void Load(DomainModel.S131.InformationTypes.Authority instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            textContent = new();
            if (instance.textContent != null)
            {
                textContent = new();
                textContent.Load(instance.textContent);
            }

            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.Authority
            {
                categoryOfAuthority = this.categoryOfAuthority,
                textContent = this.textContent?.Model,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Authority Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            textContent = this._textContent?.Model,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public AuthorityViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("AvailablePortServices", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AvailablePortServicesViewModel : ViewModelBase
    {
        [Category("AvailablePortServices")]
        public ObservableCollection<firefightingService> firefightingService { get; set; } = new();

        [Category("AvailablePortServices")]
        public ObservableCollection<medicalService> medicalService { get; set; } = new();

        [Category("AvailablePortServices")]
        public ObservableCollection<repairService> repairService { get; set; } = new();

        [Category("AvailablePortServices")]
        public ObservableCollection<technicalPortService> technicalPortService { get; set; } = new();

        [Category("AvailablePortServices")]
        public ObservableCollection<shipSanitationControl> shipSanitationControl { get; set; } = new();

        [DomainModel.CodeList(nameof(transportConnectionList))]
        [Editor(typeof(Editors.CodeListCheckComboEditor), typeof(Editors.CodeListCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<transportConnection> transportConnection { get; set; } = new();

        [Category("AvailablePortServices")]
        public ObservableCollection<berthingAssistance> berthingAssistance { get; set; } = new();

        [Category("AvailablePortServices")]
        public ObservableCollection<cargoService> cargoService { get; set; } = new();

        [DomainModel.CodeList(nameof(securitySafetyEmergencyServiceList))]
        [Editor(typeof(Editors.CodeListCheckComboEditor), typeof(Editors.CodeListCheckComboEditor))]
        [Category("AvailablePortServices")]
        public ObservableCollection<securitySafetyEmergencyService> securitySafetyEmergencyService { get; set; } = new();

        [Category("AvailablePortServices")]
        public ObservableCollection<wasteDisposalService> wasteDisposalService { get; set; } = new();

        [Category("AvailablePortServices")]
        public ObservableCollection<supplyService> supplyService { get; set; } = new();

        private String _tugInformation = string.Empty;
        [Category("AvailablePortServices")]
        public String tugInformation
        {
            get
            {
                return _tugInformation;
            }

            set
            {
                SetValue(ref _tugInformation, value);
            }
        }

        [Category("AvailablePortServices")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class AvailablePortServicesRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AvailablePortServices)];
        }

        [Browsable(false)]
        public transportConnection[] transportConnectionList => CodeList.transportConnections.ToArray();

        [Browsable(false)]
        public securitySafetyEmergencyService[] securitySafetyEmergencyServiceList => CodeList.securitySafetyEmergencyServices.ToArray();

        public void Load(DomainModel.S131.InformationTypes.AvailablePortServices instance)
        {
            firefightingService.Clear();
            if (instance.firefightingService is not null)
                foreach (var e in instance.firefightingService)
                    firefightingService.Add(e);
            medicalService.Clear();
            if (instance.medicalService is not null)
                foreach (var e in instance.medicalService)
                    medicalService.Add(e);
            repairService.Clear();
            if (instance.repairService is not null)
                foreach (var e in instance.repairService)
                    repairService.Add(e);
            technicalPortService.Clear();
            if (instance.technicalPortService is not null)
                foreach (var e in instance.technicalPortService)
                    technicalPortService.Add(e);
            shipSanitationControl.Clear();
            if (instance.shipSanitationControl is not null)
                foreach (var e in instance.shipSanitationControl)
                    shipSanitationControl.Add(e);
            transportConnection.Clear();
            if (instance.transportConnection is not null)
                foreach (var e in instance.transportConnection)
                    transportConnection.Add(e);
            berthingAssistance.Clear();
            if (instance.berthingAssistance is not null)
                foreach (var e in instance.berthingAssistance)
                    berthingAssistance.Add(e);
            cargoService.Clear();
            if (instance.cargoService is not null)
                foreach (var e in instance.cargoService)
                    cargoService.Add(e);
            securitySafetyEmergencyService.Clear();
            if (instance.securitySafetyEmergencyService is not null)
                foreach (var e in instance.securitySafetyEmergencyService)
                    securitySafetyEmergencyService.Add(e);
            wasteDisposalService.Clear();
            if (instance.wasteDisposalService is not null)
                foreach (var e in instance.wasteDisposalService)
                    wasteDisposalService.Add(e);
            supplyService.Clear();
            if (instance.supplyService is not null)
                foreach (var e in instance.supplyService)
                    supplyService.Add(e);
            tugInformation = instance.tugInformation;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.AvailablePortServices
            {
                firefightingService = this.firefightingService.ToList(),
                medicalService = this.medicalService.ToList(),
                repairService = this.repairService.ToList(),
                technicalPortService = this.technicalPortService.ToList(),
                shipSanitationControl = this.shipSanitationControl.ToList(),
                transportConnection = this.transportConnection.ToList(),
                berthingAssistance = this.berthingAssistance.ToList(),
                cargoService = this.cargoService.ToList(),
                securitySafetyEmergencyService = this.securitySafetyEmergencyService.ToList(),
                wasteDisposalService = this.wasteDisposalService.ToList(),
                supplyService = this.supplyService.ToList(),
                tugInformation = this.tugInformation,
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.AvailablePortServices Model => new()
        {
            firefightingService = this.firefightingService.ToList(),
            medicalService = this.medicalService.ToList(),
            repairService = this.repairService.ToList(),
            technicalPortService = this.technicalPortService.ToList(),
            shipSanitationControl = this.shipSanitationControl.ToList(),
            transportConnection = this.transportConnection.ToList(),
            berthingAssistance = this.berthingAssistance.ToList(),
            cargoService = this.cargoService.ToList(),
            securitySafetyEmergencyService = this.securitySafetyEmergencyService.ToList(),
            wasteDisposalService = this.wasteDisposalService.ToList(),
            supplyService = this.supplyService.ToList(),
            tugInformation = this._tugInformation,
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public AvailablePortServicesViewModel() : base()
        {
            firefightingService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(firefightingService));
            };
            medicalService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(medicalService));
            };
            repairService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(repairService));
            };
            technicalPortService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(technicalPortService));
            };
            shipSanitationControl.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(shipSanitationControl));
            };
            transportConnection.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(transportConnection));
            };
            berthingAssistance.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(berthingAssistance));
            };
            cargoService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(cargoService));
            };
            securitySafetyEmergencyService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(securitySafetyEmergencyService));
            };
            wasteDisposalService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(wasteDisposalService));
            };
            supplyService.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(supplyService));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("ContactDetails", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ContactDetailsViewModel : ViewModelBase
    {
        private String _callName = string.Empty;
        [Category("ContactDetails")]
        public String callName
        {
            get
            {
                return _callName;
            }

            set
            {
                SetValue(ref _callName, value);
            }
        }

        private String _callSign = string.Empty;
        [Category("ContactDetails")]
        public String callSign
        {
            get
            {
                return _callSign;
            }

            set
            {
                SetValue(ref _callSign, value);
            }
        }

        private categoryOfCommunicationPreference? _categoryOfCommunicationPreference = default;
        [Category("ContactDetails")]
        public categoryOfCommunicationPreference? categoryOfCommunicationPreference
        {
            get
            {
                return _categoryOfCommunicationPreference;
            }

            set
            {
                SetValue(ref _categoryOfCommunicationPreference, value);
            }
        }

        [Category("ContactDetails")]
        public ObservableCollection<String> communicationChannel { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<contactAddress> contactAddress { get; set; } = new();

        private String _contactInstructions = string.Empty;
        [Category("ContactDetails")]
        public String contactInstructions
        {
            get
            {
                return _contactInstructions;
            }

            set
            {
                SetValue(ref _contactInstructions, value);
            }
        }

        [Category("ContactDetails")]
        public ObservableCollection<Int32> signalFrequency { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<frequencyPair> frequencyPair { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<information> information { get; set; } = new();

        private String _mMSICode = string.Empty;
        [Category("ContactDetails")]
        public String mMSICode
        {
            get
            {
                return _mMSICode;
            }

            set
            {
                SetValue(ref _mMSICode, value);
            }
        }

        [Category("ContactDetails")]
        public ObservableCollection<onlineResource> onlineResource { get; set; } = new();

        [Category("ContactDetails")]
        public ObservableCollection<telecommunications> telecommunications { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class ContactDetailsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public void Load(DomainModel.S131.InformationTypes.ContactDetails instance)
        {
            callName = instance.callName;
            callSign = instance.callSign;
            categoryOfCommunicationPreference = instance.categoryOfCommunicationPreference;
            communicationChannel.Clear();
            if (instance.communicationChannel is not null)
                foreach (var e in instance.communicationChannel)
                    communicationChannel.Add(e);
            contactAddress.Clear();
            if (instance.contactAddress is not null)
                foreach (var e in instance.contactAddress)
                    contactAddress.Add(e);
            contactInstructions = instance.contactInstructions;
            signalFrequency.Clear();
            if (instance.signalFrequency is not null)
                foreach (var e in instance.signalFrequency)
                    signalFrequency.Add(e);
            frequencyPair.Clear();
            if (instance.frequencyPair is not null)
                foreach (var e in instance.frequencyPair)
                    frequencyPair.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            mMSICode = instance.mMSICode;
            onlineResource.Clear();
            if (instance.onlineResource is not null)
                foreach (var e in instance.onlineResource)
                    onlineResource.Add(e);
            telecommunications.Clear();
            if (instance.telecommunications is not null)
                foreach (var e in instance.telecommunications)
                    telecommunications.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.ContactDetails
            {
                callName = this.callName,
                callSign = this.callSign,
                categoryOfCommunicationPreference = this.categoryOfCommunicationPreference,
                communicationChannel = this.communicationChannel.ToList(),
                contactAddress = this.contactAddress.ToList(),
                contactInstructions = this.contactInstructions,
                signalFrequency = this.signalFrequency.ToList(),
                frequencyPair = this.frequencyPair.ToList(),
                information = this.information.ToList(),
                mMSICode = this.mMSICode,
                onlineResource = this.onlineResource.ToList(),
                telecommunications = this.telecommunications.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.ContactDetails Model => new()
        {
            callName = this._callName,
            callSign = this._callSign,
            categoryOfCommunicationPreference = this._categoryOfCommunicationPreference,
            communicationChannel = this.communicationChannel.ToList(),
            contactAddress = this.contactAddress.ToList(),
            contactInstructions = this._contactInstructions,
            signalFrequency = this.signalFrequency.ToList(),
            frequencyPair = this.frequencyPair.ToList(),
            information = this.information.ToList(),
            mMSICode = this._mMSICode,
            onlineResource = this.onlineResource.ToList(),
            telecommunications = this.telecommunications.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ContactDetailsViewModel() : base()
        {
            communicationChannel.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(communicationChannel));
            };
            contactAddress.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(contactAddress));
            };
            signalFrequency.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(signalFrequency));
            };
            frequencyPair.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(frequencyPair));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
            onlineResource.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(onlineResource));
            };
            telecommunications.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(telecommunications));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Entrance", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class EntranceViewModel : ViewModelBase
    {
        private String _entranceDescription = string.Empty;
        [Category("Entrance")]
        public String entranceDescription
        {
            get
            {
                return _entranceDescription;
            }

            set
            {
                SetValue(ref _entranceDescription, value);
            }
        }

        [Category("Entrance")]
        public ObservableCollection<String> associatedFeatureName { get; set; } = new();

        private String _localKnowledgeDescription = string.Empty;
        [Category("Entrance")]
        public String localKnowledgeDescription
        {
            get
            {
                return _localKnowledgeDescription;
            }

            set
            {
                SetValue(ref _localKnowledgeDescription, value);
            }
        }

        private String _approachDescription = string.Empty;
        [Category("Entrance")]
        public String approachDescription
        {
            get
            {
                return _approachDescription;
            }

            set
            {
                SetValue(ref _approachDescription, value);
            }
        }

        [Category("Entrance")]
        public ObservableCollection<markedBy> markedBy { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<landmarkDescription> landmarkDescription { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<offshoreMarkDescription> offshoreMarkDescription { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<majorLightDescription> majorLightDescription { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<usefulMarkDescription> usefulMarkDescription { get; set; } = new();

        [Category("Entrance")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class EntranceRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Entrance)];
        }

        public void Load(DomainModel.S131.InformationTypes.Entrance instance)
        {
            entranceDescription = instance.entranceDescription;
            associatedFeatureName.Clear();
            if (instance.associatedFeatureName is not null)
                foreach (var e in instance.associatedFeatureName)
                    associatedFeatureName.Add(e);
            localKnowledgeDescription = instance.localKnowledgeDescription;
            approachDescription = instance.approachDescription;
            markedBy.Clear();
            if (instance.markedBy is not null)
                foreach (var e in instance.markedBy)
                    markedBy.Add(e);
            landmarkDescription.Clear();
            if (instance.landmarkDescription is not null)
                foreach (var e in instance.landmarkDescription)
                    landmarkDescription.Add(e);
            offshoreMarkDescription.Clear();
            if (instance.offshoreMarkDescription is not null)
                foreach (var e in instance.offshoreMarkDescription)
                    offshoreMarkDescription.Add(e);
            majorLightDescription.Clear();
            if (instance.majorLightDescription is not null)
                foreach (var e in instance.majorLightDescription)
                    majorLightDescription.Add(e);
            usefulMarkDescription.Clear();
            if (instance.usefulMarkDescription is not null)
                foreach (var e in instance.usefulMarkDescription)
                    usefulMarkDescription.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.Entrance
            {
                entranceDescription = this.entranceDescription,
                associatedFeatureName = this.associatedFeatureName.ToList(),
                localKnowledgeDescription = this.localKnowledgeDescription,
                approachDescription = this.approachDescription,
                markedBy = this.markedBy.ToList(),
                landmarkDescription = this.landmarkDescription.ToList(),
                offshoreMarkDescription = this.offshoreMarkDescription.ToList(),
                majorLightDescription = this.majorLightDescription.ToList(),
                usefulMarkDescription = this.usefulMarkDescription.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Entrance Model => new()
        {
            entranceDescription = this._entranceDescription,
            associatedFeatureName = this.associatedFeatureName.ToList(),
            localKnowledgeDescription = this._localKnowledgeDescription,
            approachDescription = this._approachDescription,
            markedBy = this.markedBy.ToList(),
            landmarkDescription = this.landmarkDescription.ToList(),
            offshoreMarkDescription = this.offshoreMarkDescription.ToList(),
            majorLightDescription = this.majorLightDescription.ToList(),
            usefulMarkDescription = this.usefulMarkDescription.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public EntranceViewModel() : base()
        {
            associatedFeatureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(associatedFeatureName));
            };
            markedBy.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(markedBy));
            };
            landmarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(landmarkDescription));
            };
            offshoreMarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(offshoreMarkDescription));
            };
            majorLightDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(majorLightDescription));
            };
            usefulMarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(usefulMarkDescription));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("NauticalInformation", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NauticalInformationViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("AbstractRxN")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class NauticalInformationRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public void Load(DomainModel.S131.InformationTypes.NauticalInformation instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.NauticalInformation
            {
                categoryOfAuthority = this.categoryOfAuthority,
                rxNCode = this.rxNCode.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.NauticalInformation Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            rxNCode = this.rxNCode.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public NauticalInformationViewModel() : base()
        {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("NonStandardWorkingDay", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class NonStandardWorkingDayViewModel : ViewModelBase
    {
        [Category("NonStandardWorkingDay")]
        public ObservableCollection<DateOnly> dateFixed { get; set; } = new();

        [Category("NonStandardWorkingDay")]
        public ObservableCollection<String> dateVariable { get; set; } = new();

        [Category("NonStandardWorkingDay")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class NonStandardWorkingDayRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NonStandardWorkingDay)];
        }

        public void Load(DomainModel.S131.InformationTypes.NonStandardWorkingDay instance)
        {
            dateFixed.Clear();
            if (instance.dateFixed is not null)
                foreach (var e in instance.dateFixed)
                    dateFixed.Add(e);
            dateVariable.Clear();
            if (instance.dateVariable is not null)
                foreach (var e in instance.dateVariable)
                    dateVariable.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.NonStandardWorkingDay
            {
                dateFixed = this.dateFixed.ToList(),
                dateVariable = this.dateVariable.ToList(),
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.NonStandardWorkingDay Model => new()
        {
            dateFixed = this.dateFixed.ToList(),
            dateVariable = this.dateVariable.ToList(),
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public NonStandardWorkingDayViewModel() : base()
        {
            dateFixed.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(dateFixed));
            };
            dateVariable.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(dateVariable));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Recommendations", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RecommendationsViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("AbstractRxN")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class RecommendationsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Recommendations)];
        }

        public void Load(DomainModel.S131.InformationTypes.Recommendations instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.Recommendations
            {
                categoryOfAuthority = this.categoryOfAuthority,
                rxNCode = this.rxNCode.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Recommendations Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            rxNCode = this.rxNCode.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RecommendationsViewModel() : base()
        {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Regulations", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RegulationsViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("AbstractRxN")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class RegulationsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Regulations)];
        }

        public void Load(DomainModel.S131.InformationTypes.Regulations instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.Regulations
            {
                categoryOfAuthority = this.categoryOfAuthority,
                rxNCode = this.rxNCode.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Regulations Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            rxNCode = this.rxNCode.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RegulationsViewModel() : base()
        {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("Restrictions", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class RestrictionsViewModel : ViewModelBase
    {
        private categoryOfAuthority? _categoryOfAuthority = default;
        [Category("AbstractRxN")]
        public categoryOfAuthority? categoryOfAuthority
        {
            get
            {
                return _categoryOfAuthority;
            }

            set
            {
                SetValue(ref _categoryOfAuthority, value);
            }
        }

        [Category("AbstractRxN")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("AbstractRxN")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class RestrictionsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Restrictions)];
        }

        public void Load(DomainModel.S131.InformationTypes.Restrictions instance)
        {
            categoryOfAuthority = instance.categoryOfAuthority;
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.Restrictions
            {
                categoryOfAuthority = this.categoryOfAuthority,
                rxNCode = this.rxNCode.ToList(),
                textContent = this.textContent.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.Restrictions Model => new()
        {
            categoryOfAuthority = this._categoryOfAuthority,
            rxNCode = this.rxNCode.ToList(),
            textContent = this.textContent.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public RestrictionsViewModel() : base()
        {
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("ServiceHours", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class ServiceHoursViewModel : ViewModelBase
    {
        [Category("ServiceHours")]
        public ObservableCollection<scheduleByDayOfWeek> scheduleByDayOfWeek { get; set; } = new();

        [Category("ServiceHours")]
        public ObservableCollection<information> information { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("InformationType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("InformationType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("InformationType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("InformationType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("InformationType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("InformationType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        public class ServiceHoursRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public void Load(DomainModel.S131.InformationTypes.ServiceHours instance)
        {
            scheduleByDayOfWeek.Clear();
            if (instance.scheduleByDayOfWeek is not null)
                foreach (var e in instance.scheduleByDayOfWeek)
                    scheduleByDayOfWeek.Add(e);
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.ServiceHours
            {
                scheduleByDayOfWeek = this.scheduleByDayOfWeek.ToList(),
                information = this.information.ToList(),
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.ServiceHours Model => new()
        {
            scheduleByDayOfWeek = this.scheduleByDayOfWeek.ToList(),
            information = this.information.ToList(),
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
        };

        public ServiceHoursViewModel() : base()
        {
            scheduleByDayOfWeek.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(scheduleByDayOfWeek));
            };
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
        }
    }

    [CategoryOrder("SpatialQuality", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SpatialQualityViewModel : ViewModelBase
    {
        private qualityOfHorizontalMeasurement? _qualityOfHorizontalMeasurement = default;
        [Category("SpatialQuality")]
        public qualityOfHorizontalMeasurement? qualityOfHorizontalMeasurement
        {
            get
            {
                return _qualityOfHorizontalMeasurement;
            }

            set
            {
                SetValue(ref _qualityOfHorizontalMeasurement, value);
            }
        }

        [Category("SpatialQuality")]
        public ObservableCollection<spatialAccuracy> spatialAccuracy { get; set; } = new();

        public class SpatialQualityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(SpatialQuality)];
        }

        public void Load(DomainModel.S131.InformationTypes.SpatialQuality instance)
        {
            qualityOfHorizontalMeasurement = instance.qualityOfHorizontalMeasurement;
            spatialAccuracy.Clear();
            if (instance.spatialAccuracy is not null)
                foreach (var e in instance.spatialAccuracy)
                    spatialAccuracy.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.InformationTypes.SpatialQuality
            {
                qualityOfHorizontalMeasurement = this.qualityOfHorizontalMeasurement,
                spatialAccuracy = this.spatialAccuracy.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.InformationTypes.SpatialQuality Model => new()
        {
            qualityOfHorizontalMeasurement = this._qualityOfHorizontalMeasurement,
            spatialAccuracy = this.spatialAccuracy.ToList(),
        };

        public SpatialQualityViewModel() : base()
        {
            spatialAccuracy.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(spatialAccuracy));
            };
        }
    }

    [CategoryOrder("AnchorBerth", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AnchorBerthViewModel : ViewModelBase
    {
        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class AnchorBerthRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AnchorBerth)];
        }

        public void Load(DomainModel.S131.FeatureTypes.AnchorBerth instance)
        {
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.AnchorBerth
            {
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.AnchorBerth Model => new()
        {
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public AnchorBerthViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("AnchorageArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class AnchorageAreaViewModel : ViewModelBase
    {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("AnchorageArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription
        {
            get
            {
                return _depthsDescription;
            }

            set
            {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("AnchorageArea")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("AnchorageArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy
        {
            get
            {
                return _markedBy;
            }

            set
            {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [Category("AnchorageArea")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class AnchorageAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AnchorageArea)];
        }

        public void Load(DomainModel.S131.FeatureTypes.AnchorageArea instance)
        {
            depthsDescription = new();
            if (instance.depthsDescription != null)
            {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null)
            {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.AnchorageArea
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.AnchorageArea Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public AnchorageAreaViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("Berth", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class BerthViewModel : ViewModelBase
    {
        private Decimal? _availableBerthingLength = default;
        [Category("Berth")]
        public Decimal? availableBerthingLength
        {
            get
            {
                return _availableBerthingLength;
            }

            set
            {
                SetValue(ref _availableBerthingLength, value);
            }
        }

        private String _bollardDescription = string.Empty;
        [Category("Berth")]
        public String bollardDescription
        {
            get
            {
                return _bollardDescription;
            }

            set
            {
                SetValue(ref _bollardDescription, value);
            }
        }

        private Decimal? _bollardPull = default;
        [Category("Berth")]
        public Decimal? bollardPull
        {
            get
            {
                return _bollardPull;
            }

            set
            {
                SetValue(ref _bollardPull, value);
            }
        }

        private Decimal? _minimumBerthDepth = default;
        [Category("Berth")]
        public Decimal? minimumBerthDepth
        {
            get
            {
                return _minimumBerthDepth;
            }

            set
            {
                SetValue(ref _minimumBerthDepth, value);
            }
        }

        private Decimal? _elevation = default;
        [Category("Berth")]
        public Decimal? elevation
        {
            get
            {
                return _elevation;
            }

            set
            {
                SetValue(ref _elevation, value);
            }
        }

        private Boolean? _cathodicProtectionSystem = default;
        [Category("Berth")]
        public Boolean? cathodicProtectionSystem
        {
            get
            {
                return _cathodicProtectionSystem;
            }

            set
            {
                SetValue(ref _cathodicProtectionSystem, value);
            }
        }

        private categoryOfBerthLocation? _categoryOfBerthLocation = default;
        [Category("Berth")]
        public categoryOfBerthLocation? categoryOfBerthLocation
        {
            get
            {
                return _categoryOfBerthLocation;
            }

            set
            {
                SetValue(ref _categoryOfBerthLocation, value);
            }
        }

        private String _portFacilityNumber = string.Empty;
        [Category("Berth")]
        public String portFacilityNumber
        {
            get
            {
                return _portFacilityNumber;
            }

            set
            {
                SetValue(ref _portFacilityNumber, value);
            }
        }

        [Category("Berth")]
        public ObservableCollection<String> bollardNumber { get; set; } = new();

        private String _gLNExtension = string.Empty;
        [Category("Berth")]
        public String gLNExtension
        {
            get
            {
                return _gLNExtension;
            }

            set
            {
                SetValue(ref _gLNExtension, value);
            }
        }

        [Category("Berth")]
        public ObservableCollection<String> metreMarkNumber { get; set; } = new();

        [Category("Berth")]
        public ObservableCollection<String> manifoldNumber { get; set; } = new();

        private String _rampNumber = string.Empty;
        [Category("Berth")]
        public String rampNumber
        {
            get
            {
                return _rampNumber;
            }

            set
            {
                SetValue(ref _rampNumber, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("Berth")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private methodOfSecuring? _methodOfSecuring = default;
        [Category("Berth")]
        public methodOfSecuring? methodOfSecuring
        {
            get
            {
                return _methodOfSecuring;
            }

            set
            {
                SetValue(ref _methodOfSecuring, value);
            }
        }

        private String _uNLocationCode = string.Empty;
        [Category("Berth")]
        public String uNLocationCode
        {
            get
            {
                return _uNLocationCode;
            }

            set
            {
                SetValue(ref _uNLocationCode, value);
            }
        }

        private String _terminalIdentifier = string.Empty;
        [Category("Berth")]
        public String terminalIdentifier
        {
            get
            {
                return _terminalIdentifier;
            }

            set
            {
                SetValue(ref _terminalIdentifier, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class BerthRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Berth)];
        }

        public void Load(DomainModel.S131.FeatureTypes.Berth instance)
        {
            availableBerthingLength = instance.availableBerthingLength;
            bollardDescription = instance.bollardDescription;
            bollardPull = instance.bollardPull;
            minimumBerthDepth = instance.minimumBerthDepth;
            elevation = instance.elevation;
            cathodicProtectionSystem = instance.cathodicProtectionSystem;
            categoryOfBerthLocation = instance.categoryOfBerthLocation;
            portFacilityNumber = instance.portFacilityNumber;
            bollardNumber.Clear();
            if (instance.bollardNumber is not null)
                foreach (var e in instance.bollardNumber)
                    bollardNumber.Add(e);
            gLNExtension = instance.gLNExtension;
            metreMarkNumber.Clear();
            if (instance.metreMarkNumber is not null)
                foreach (var e in instance.metreMarkNumber)
                    metreMarkNumber.Add(e);
            manifoldNumber.Clear();
            if (instance.manifoldNumber is not null)
                foreach (var e in instance.manifoldNumber)
                    manifoldNumber.Add(e);
            rampNumber = instance.rampNumber;
            locationByText = instance.locationByText;
            methodOfSecuring = instance.methodOfSecuring;
            uNLocationCode = instance.uNLocationCode;
            terminalIdentifier = instance.terminalIdentifier;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.Berth
            {
                availableBerthingLength = this.availableBerthingLength,
                bollardDescription = this.bollardDescription,
                bollardPull = this.bollardPull,
                minimumBerthDepth = this.minimumBerthDepth,
                elevation = this.elevation,
                cathodicProtectionSystem = this.cathodicProtectionSystem,
                categoryOfBerthLocation = this.categoryOfBerthLocation,
                portFacilityNumber = this.portFacilityNumber,
                bollardNumber = this.bollardNumber.ToList(),
                gLNExtension = this.gLNExtension,
                metreMarkNumber = this.metreMarkNumber.ToList(),
                manifoldNumber = this.manifoldNumber.ToList(),
                rampNumber = this.rampNumber,
                locationByText = this.locationByText,
                methodOfSecuring = this.methodOfSecuring,
                uNLocationCode = this.uNLocationCode,
                terminalIdentifier = this.terminalIdentifier,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.Berth Model => new()
        {
            availableBerthingLength = this._availableBerthingLength,
            bollardDescription = this._bollardDescription,
            bollardPull = this._bollardPull,
            minimumBerthDepth = this._minimumBerthDepth,
            elevation = this._elevation,
            cathodicProtectionSystem = this._cathodicProtectionSystem,
            categoryOfBerthLocation = this._categoryOfBerthLocation,
            portFacilityNumber = this._portFacilityNumber,
            bollardNumber = this.bollardNumber.ToList(),
            gLNExtension = this._gLNExtension,
            metreMarkNumber = this.metreMarkNumber.ToList(),
            manifoldNumber = this.manifoldNumber.ToList(),
            rampNumber = this._rampNumber,
            locationByText = this._locationByText,
            methodOfSecuring = this._methodOfSecuring,
            uNLocationCode = this._uNLocationCode,
            terminalIdentifier = this._terminalIdentifier,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public BerthViewModel() : base()
        {
            bollardNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(bollardNumber));
            };
            metreMarkNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(metreMarkNumber));
            };
            manifoldNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(manifoldNumber));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("BerthPosition", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class BerthPositionViewModel : ViewModelBase
    {
        private Decimal? _availableBerthingLength = default;
        [Category("BerthPosition")]
        public Decimal? availableBerthingLength
        {
            get
            {
                return _availableBerthingLength;
            }

            set
            {
                SetValue(ref _availableBerthingLength, value);
            }
        }

        private String _bollardDescription = string.Empty;
        [Category("BerthPosition")]
        public String bollardDescription
        {
            get
            {
                return _bollardDescription;
            }

            set
            {
                SetValue(ref _bollardDescription, value);
            }
        }

        private Decimal? _bollardPull = default;
        [Category("BerthPosition")]
        public Decimal? bollardPull
        {
            get
            {
                return _bollardPull;
            }

            set
            {
                SetValue(ref _bollardPull, value);
            }
        }

        [Category("BerthPosition")]
        public ObservableCollection<String> bollardNumber { get; set; } = new();

        private String _gLNExtension = string.Empty;
        [Category("BerthPosition")]
        public String gLNExtension
        {
            get
            {
                return _gLNExtension;
            }

            set
            {
                SetValue(ref _gLNExtension, value);
            }
        }

        [Category("BerthPosition")]
        public ObservableCollection<String> metreMarkNumber { get; set; } = new();

        [Category("BerthPosition")]
        public ObservableCollection<String> manifoldNumber { get; set; } = new();

        private String _rampNumber = string.Empty;
        [Category("BerthPosition")]
        public String rampNumber
        {
            get
            {
                return _rampNumber;
            }

            set
            {
                SetValue(ref _rampNumber, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("BerthPosition")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class BerthPositionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(BerthPosition)];
        }

        public void Load(DomainModel.S131.FeatureTypes.BerthPosition instance)
        {
            availableBerthingLength = instance.availableBerthingLength;
            bollardDescription = instance.bollardDescription;
            bollardPull = instance.bollardPull;
            bollardNumber.Clear();
            if (instance.bollardNumber is not null)
                foreach (var e in instance.bollardNumber)
                    bollardNumber.Add(e);
            gLNExtension = instance.gLNExtension;
            metreMarkNumber.Clear();
            if (instance.metreMarkNumber is not null)
                foreach (var e in instance.metreMarkNumber)
                    metreMarkNumber.Add(e);
            manifoldNumber.Clear();
            if (instance.manifoldNumber is not null)
                foreach (var e in instance.manifoldNumber)
                    manifoldNumber.Add(e);
            rampNumber = instance.rampNumber;
            locationByText = instance.locationByText;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.BerthPosition
            {
                availableBerthingLength = this.availableBerthingLength,
                bollardDescription = this.bollardDescription,
                bollardPull = this.bollardPull,
                bollardNumber = this.bollardNumber.ToList(),
                gLNExtension = this.gLNExtension,
                metreMarkNumber = this.metreMarkNumber.ToList(),
                manifoldNumber = this.manifoldNumber.ToList(),
                rampNumber = this.rampNumber,
                locationByText = this.locationByText,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.BerthPosition Model => new()
        {
            availableBerthingLength = this._availableBerthingLength,
            bollardDescription = this._bollardDescription,
            bollardPull = this._bollardPull,
            bollardNumber = this.bollardNumber.ToList(),
            gLNExtension = this._gLNExtension,
            metreMarkNumber = this.metreMarkNumber.ToList(),
            manifoldNumber = this.manifoldNumber.ToList(),
            rampNumber = this._rampNumber,
            locationByText = this._locationByText,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public BerthPositionViewModel() : base()
        {
            bollardNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(bollardNumber));
            };
            metreMarkNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(metreMarkNumber));
            };
            manifoldNumber.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(manifoldNumber));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("DockArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DockAreaViewModel : ViewModelBase
    {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("DockArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription
        {
            get
            {
                return _depthsDescription;
            }

            set
            {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("DockArea")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("DockArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy
        {
            get
            {
                return _markedBy;
            }

            set
            {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [Category("DockArea")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class DockAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(DockArea)];
        }

        public void Load(DomainModel.S131.FeatureTypes.DockArea instance)
        {
            depthsDescription = new();
            if (instance.depthsDescription != null)
            {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null)
            {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.DockArea
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.DockArea Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public DockAreaViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("DryDock", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DryDockViewModel : ViewModelBase
    {
        private Decimal? _sillDepth = default;
        [Category("DryDock")]
        public Decimal? sillDepth
        {
            get
            {
                return _sillDepth;
            }

            set
            {
                SetValue(ref _sillDepth, value);
            }
        }

        private Decimal? _verticalClearanceValue = default;
        [Category("HarbourPhysicalInfrastructure")]
        public Decimal? verticalClearanceValue
        {
            get
            {
                return _verticalClearanceValue;
            }

            set
            {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class DryDockRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(DryDock)];
        }

        public void Load(DomainModel.S131.FeatureTypes.DryDock instance)
        {
            sillDepth = instance.sillDepth;
            verticalClearanceValue = instance.verticalClearanceValue;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.DryDock
            {
                sillDepth = this.sillDepth,
                verticalClearanceValue = this.verticalClearanceValue,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.DryDock Model => new()
        {
            sillDepth = this._sillDepth,
            verticalClearanceValue = this._verticalClearanceValue,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public DryDockViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("DumpingGround", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DumpingGroundViewModel : ViewModelBase
    {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("DumpingGround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription
        {
            get
            {
                return _depthsDescription;
            }

            set
            {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("DumpingGround")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("DumpingGround")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy
        {
            get
            {
                return _markedBy;
            }

            set
            {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [Category("DumpingGround")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class DumpingGroundRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(DumpingGround)];
        }

        public void Load(DomainModel.S131.FeatureTypes.DumpingGround instance)
        {
            depthsDescription = new();
            if (instance.depthsDescription != null)
            {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null)
            {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.DumpingGround
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.DumpingGround Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public DumpingGroundViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("FloatingDock", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class FloatingDockViewModel : ViewModelBase
    {
        private Decimal? _sillDepth = default;
        [Category("FloatingDock")]
        public Decimal? sillDepth
        {
            get
            {
                return _sillDepth;
            }

            set
            {
                SetValue(ref _sillDepth, value);
            }
        }

        private Decimal? _verticalClearanceValue = default;
        [Category("HarbourPhysicalInfrastructure")]
        public Decimal? verticalClearanceValue
        {
            get
            {
                return _verticalClearanceValue;
            }

            set
            {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class FloatingDockRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(FloatingDock)];
        }

        public void Load(DomainModel.S131.FeatureTypes.FloatingDock instance)
        {
            sillDepth = instance.sillDepth;
            verticalClearanceValue = instance.verticalClearanceValue;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.FloatingDock
            {
                sillDepth = this.sillDepth,
                verticalClearanceValue = this.verticalClearanceValue,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.FloatingDock Model => new()
        {
            sillDepth = this._sillDepth,
            verticalClearanceValue = this._verticalClearanceValue,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public FloatingDockViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("Gridiron", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class GridironViewModel : ViewModelBase
    {
        private Decimal? _sillDepth = default;
        [Category("Gridiron")]
        public Decimal? sillDepth
        {
            get
            {
                return _sillDepth;
            }

            set
            {
                SetValue(ref _sillDepth, value);
            }
        }

        private Decimal? _verticalClearanceValue = default;
        [Category("HarbourPhysicalInfrastructure")]
        public Decimal? verticalClearanceValue
        {
            get
            {
                return _verticalClearanceValue;
            }

            set
            {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class GridironRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Gridiron)];
        }

        public void Load(DomainModel.S131.FeatureTypes.Gridiron instance)
        {
            sillDepth = instance.sillDepth;
            verticalClearanceValue = instance.verticalClearanceValue;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.Gridiron
            {
                sillDepth = this.sillDepth,
                verticalClearanceValue = this.verticalClearanceValue,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.Gridiron Model => new()
        {
            sillDepth = this._sillDepth,
            verticalClearanceValue = this._verticalClearanceValue,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public GridironViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("HarbourAreaAdministrative", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class HarbourAreaAdministrativeViewModel : ViewModelBase
    {
        private String _uNLocationCode = string.Empty;
        [Category("HarbourAreaAdministrative")]
        public String uNLocationCode
        {
            get
            {
                return _uNLocationCode;
            }

            set
            {
                SetValue(ref _uNLocationCode, value);
            }
        }

        private String _nationality = string.Empty;
        [Category("HarbourAreaAdministrative")]
        public String nationality
        {
            get
            {
                return _nationality;
            }

            set
            {
                SetValue(ref _nationality, value);
            }
        }

        private String _applicableLoadLineZone = string.Empty;
        [Category("HarbourAreaAdministrative")]
        public String applicableLoadLineZone
        {
            get
            {
                return _applicableLoadLineZone;
            }

            set
            {
                SetValue(ref _applicableLoadLineZone, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [Category("HarbourAreaAdministrative")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        [Category("HarbourAreaAdministrative")]
        public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = new();

        private generalHarbourInformationViewModel? _generalHarbourInformation;
        [Category("HarbourAreaAdministrative")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public generalHarbourInformationViewModel? generalHarbourInformation
        {
            get
            {
                return _generalHarbourInformation;
            }

            set
            {
                SetValue(ref _generalHarbourInformation, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class HarbourAreaAdministrativeRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaAdministrative)];
        }

        public void Load(DomainModel.S131.FeatureTypes.HarbourAreaAdministrative instance)
        {
            uNLocationCode = instance.uNLocationCode;
            nationality = instance.nationality;
            applicableLoadLineZone = instance.applicableLoadLineZone;
            iSPSLevel = instance.iSPSLevel;
            categoryOfHarbourFacility.Clear();
            if (instance.categoryOfHarbourFacility is not null)
                foreach (var e in instance.categoryOfHarbourFacility)
                    categoryOfHarbourFacility.Add(e);
            generalHarbourInformation = new();
            if (instance.generalHarbourInformation != null)
            {
                generalHarbourInformation = new();
                generalHarbourInformation.Load(instance.generalHarbourInformation);
            }

            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.HarbourAreaAdministrative
            {
                uNLocationCode = this.uNLocationCode,
                nationality = this.nationality,
                applicableLoadLineZone = this.applicableLoadLineZone,
                iSPSLevel = this.iSPSLevel,
                categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
                generalHarbourInformation = this.generalHarbourInformation?.Model,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.HarbourAreaAdministrative Model => new()
        {
            uNLocationCode = this._uNLocationCode,
            nationality = this._nationality,
            applicableLoadLineZone = this._applicableLoadLineZone,
            iSPSLevel = this._iSPSLevel,
            categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
            generalHarbourInformation = this._generalHarbourInformation?.Model,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public HarbourAreaAdministrativeViewModel() : base()
        {
            categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfHarbourFacility));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("HarbourAreaSection", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class HarbourAreaSectionViewModel : ViewModelBase
    {
        private categoryOfPortSection? _categoryOfPortSection = default;
        [Category("HarbourAreaSection")]
        public categoryOfPortSection? categoryOfPortSection
        {
            get
            {
                return _categoryOfPortSection;
            }

            set
            {
                SetValue(ref _categoryOfPortSection, value);
            }
        }

        [Category("HarbourAreaSection")]
        public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = new();

        private iSPSLevel? _iSPSLevel = default;
        [Category("HarbourAreaSection")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private facilitiesLayoutDescriptionViewModel? _facilitiesLayoutDescription;
        [Category("HarbourAreaSection")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public facilitiesLayoutDescriptionViewModel? facilitiesLayoutDescription
        {
            get
            {
                return _facilitiesLayoutDescription;
            }

            set
            {
                SetValue(ref _facilitiesLayoutDescription, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class HarbourAreaSectionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public void Load(DomainModel.S131.FeatureTypes.HarbourAreaSection instance)
        {
            categoryOfPortSection = instance.categoryOfPortSection;
            categoryOfHarbourFacility.Clear();
            if (instance.categoryOfHarbourFacility is not null)
                foreach (var e in instance.categoryOfHarbourFacility)
                    categoryOfHarbourFacility.Add(e);
            iSPSLevel = instance.iSPSLevel;
            facilitiesLayoutDescription = new();
            if (instance.facilitiesLayoutDescription != null)
            {
                facilitiesLayoutDescription = new();
                facilitiesLayoutDescription.Load(instance.facilitiesLayoutDescription);
            }

            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.HarbourAreaSection
            {
                categoryOfPortSection = this.categoryOfPortSection,
                categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
                iSPSLevel = this.iSPSLevel,
                facilitiesLayoutDescription = this.facilitiesLayoutDescription?.Model,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.HarbourAreaSection Model => new()
        {
            categoryOfPortSection = this._categoryOfPortSection,
            categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
            iSPSLevel = this._iSPSLevel,
            facilitiesLayoutDescription = this._facilitiesLayoutDescription?.Model,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public HarbourAreaSectionViewModel() : base()
        {
            categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfHarbourFacility));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("HarbourBasin", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class HarbourBasinViewModel : ViewModelBase
    {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("HarbourBasin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription
        {
            get
            {
                return _depthsDescription;
            }

            set
            {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("HarbourBasin")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("HarbourBasin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy
        {
            get
            {
                return _markedBy;
            }

            set
            {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [Category("HarbourBasin")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class HarbourBasinRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourBasin)];
        }

        public void Load(DomainModel.S131.FeatureTypes.HarbourBasin instance)
        {
            depthsDescription = new();
            if (instance.depthsDescription != null)
            {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null)
            {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.HarbourBasin
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.HarbourBasin Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public HarbourBasinViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("HarbourFacility", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class HarbourFacilityViewModel : ViewModelBase
    {
        [Category("HarbourFacility")]
        public ObservableCollection<categoryOfHarbourFacility> categoryOfHarbourFacility { get; set; } = new();

        private Decimal? _verticalClearanceValue = default;
        [Category("HarbourPhysicalInfrastructure")]
        public Decimal? verticalClearanceValue
        {
            get
            {
                return _verticalClearanceValue;
            }

            set
            {
                SetValue(ref _verticalClearanceValue, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class HarbourFacilityRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourFacility)];
        }

        public void Load(DomainModel.S131.FeatureTypes.HarbourFacility instance)
        {
            categoryOfHarbourFacility.Clear();
            if (instance.categoryOfHarbourFacility is not null)
                foreach (var e in instance.categoryOfHarbourFacility)
                    categoryOfHarbourFacility.Add(e);
            verticalClearanceValue = instance.verticalClearanceValue;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.HarbourFacility
            {
                categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
                verticalClearanceValue = this.verticalClearanceValue,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.HarbourFacility Model => new()
        {
            categoryOfHarbourFacility = this.categoryOfHarbourFacility.ToList(),
            verticalClearanceValue = this._verticalClearanceValue,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public HarbourFacilityViewModel() : base()
        {
            categoryOfHarbourFacility.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfHarbourFacility));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("MooringWarpingFacility", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class MooringWarpingFacilityViewModel : ViewModelBase
    {
        private categoryOfMooringWarpingFacility _categoryOfMooringWarpingFacility;
        [Category("MooringWarpingFacility")]
        public categoryOfMooringWarpingFacility categoryOfMooringWarpingFacility
        {
            get
            {
                return _categoryOfMooringWarpingFacility;
            }

            set
            {
                SetValue(ref _categoryOfMooringWarpingFacility, value);
            }
        }

        private String _iDCode = string.Empty;
        [Category("MooringWarpingFacility")]
        public String iDCode
        {
            get
            {
                return _iDCode;
            }

            set
            {
                SetValue(ref _iDCode, value);
            }
        }

        private String _bollardDescription = string.Empty;
        [Category("MooringWarpingFacility")]
        public String bollardDescription
        {
            get
            {
                return _bollardDescription;
            }

            set
            {
                SetValue(ref _bollardDescription, value);
            }
        }

        private Decimal? _bollardPull = default;
        [Category("MooringWarpingFacility")]
        public Decimal? bollardPull
        {
            get
            {
                return _bollardPull;
            }

            set
            {
                SetValue(ref _bollardPull, value);
            }
        }

        private Boolean? _heavingLinesFromShore = default;
        [Category("MooringWarpingFacility")]
        public Boolean? heavingLinesFromShore
        {
            get
            {
                return _heavingLinesFromShore;
            }

            set
            {
                SetValue(ref _heavingLinesFromShore, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class MooringWarpingFacilityRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(MooringWarpingFacility)];
        }

        public void Load(DomainModel.S131.FeatureTypes.MooringWarpingFacility instance)
        {
            categoryOfMooringWarpingFacility = instance.categoryOfMooringWarpingFacility;
            iDCode = instance.iDCode;
            bollardDescription = instance.bollardDescription;
            bollardPull = instance.bollardPull;
            heavingLinesFromShore = instance.heavingLinesFromShore;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.MooringWarpingFacility
            {
                categoryOfMooringWarpingFacility = this.categoryOfMooringWarpingFacility,
                iDCode = this.iDCode,
                bollardDescription = this.bollardDescription,
                bollardPull = this.bollardPull,
                heavingLinesFromShore = this.heavingLinesFromShore,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.MooringWarpingFacility Model => new()
        {
            categoryOfMooringWarpingFacility = this._categoryOfMooringWarpingFacility,
            iDCode = this._iDCode,
            bollardDescription = this._bollardDescription,
            bollardPull = this._bollardPull,
            heavingLinesFromShore = this._heavingLinesFromShore,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public MooringWarpingFacilityViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("OuterLimit", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class OuterLimitViewModel : ViewModelBase
    {
        private limitsDescriptionViewModel? _limitsDescription;
        [Category("OuterLimit")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public limitsDescriptionViewModel? limitsDescription
        {
            get
            {
                return _limitsDescription;
            }

            set
            {
                SetValue(ref _limitsDescription, value);
            }
        }

        [Category("OuterLimit")]
        public ObservableCollection<markedBy> markedBy { get; set; } = new();

        [Category("OuterLimit")]
        public ObservableCollection<landmarkDescription> landmarkDescription { get; set; } = new();

        [Category("OuterLimit")]
        public ObservableCollection<offshoreMarkDescription> offshoreMarkDescription { get; set; } = new();

        [Category("OuterLimit")]
        public ObservableCollection<majorLightDescription> majorLightDescription { get; set; } = new();

        [Category("OuterLimit")]
        public ObservableCollection<usefulMarkDescription> usefulMarkDescription { get; set; } = new();

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class OuterLimitRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(OuterLimit)];
        }

        public void Load(DomainModel.S131.FeatureTypes.OuterLimit instance)
        {
            limitsDescription = new();
            if (instance.limitsDescription != null)
            {
                limitsDescription = new();
                limitsDescription.Load(instance.limitsDescription);
            }

            markedBy.Clear();
            if (instance.markedBy is not null)
                foreach (var e in instance.markedBy)
                    markedBy.Add(e);
            landmarkDescription.Clear();
            if (instance.landmarkDescription is not null)
                foreach (var e in instance.landmarkDescription)
                    landmarkDescription.Add(e);
            offshoreMarkDescription.Clear();
            if (instance.offshoreMarkDescription is not null)
                foreach (var e in instance.offshoreMarkDescription)
                    offshoreMarkDescription.Add(e);
            majorLightDescription.Clear();
            if (instance.majorLightDescription is not null)
                foreach (var e in instance.majorLightDescription)
                    majorLightDescription.Add(e);
            usefulMarkDescription.Clear();
            if (instance.usefulMarkDescription is not null)
                foreach (var e in instance.usefulMarkDescription)
                    usefulMarkDescription.Add(e);
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.OuterLimit
            {
                limitsDescription = this.limitsDescription?.Model,
                markedBy = this.markedBy.ToList(),
                landmarkDescription = this.landmarkDescription.ToList(),
                offshoreMarkDescription = this.offshoreMarkDescription.ToList(),
                majorLightDescription = this.majorLightDescription.ToList(),
                usefulMarkDescription = this.usefulMarkDescription.ToList(),
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.OuterLimit Model => new()
        {
            limitsDescription = this._limitsDescription?.Model,
            markedBy = this.markedBy.ToList(),
            landmarkDescription = this.landmarkDescription.ToList(),
            offshoreMarkDescription = this.offshoreMarkDescription.ToList(),
            majorLightDescription = this.majorLightDescription.ToList(),
            usefulMarkDescription = this.usefulMarkDescription.ToList(),
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public OuterLimitViewModel() : base()
        {
            markedBy.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(markedBy));
            };
            landmarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(landmarkDescription));
            };
            offshoreMarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(offshoreMarkDescription));
            };
            majorLightDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(majorLightDescription));
            };
            usefulMarkDescription.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(usefulMarkDescription));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("PilotBoardingPlace", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class PilotBoardingPlaceViewModel : ViewModelBase
    {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("PilotBoardingPlace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription
        {
            get
            {
                return _depthsDescription;
            }

            set
            {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("PilotBoardingPlace")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("PilotBoardingPlace")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy
        {
            get
            {
                return _markedBy;
            }

            set
            {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [Category("PilotBoardingPlace")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class PilotBoardingPlaceRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(PilotBoardingPlace)];
        }

        public void Load(DomainModel.S131.FeatureTypes.PilotBoardingPlace instance)
        {
            depthsDescription = new();
            if (instance.depthsDescription != null)
            {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null)
            {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.PilotBoardingPlace
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.PilotBoardingPlace Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public PilotBoardingPlaceViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("SeaplaneLandingArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SeaplaneLandingAreaViewModel : ViewModelBase
    {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("SeaplaneLandingArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription
        {
            get
            {
                return _depthsDescription;
            }

            set
            {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("SeaplaneLandingArea")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("SeaplaneLandingArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy
        {
            get
            {
                return _markedBy;
            }

            set
            {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [Category("SeaplaneLandingArea")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class SeaplaneLandingAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(SeaplaneLandingArea)];
        }

        public void Load(DomainModel.S131.FeatureTypes.SeaplaneLandingArea instance)
        {
            depthsDescription = new();
            if (instance.depthsDescription != null)
            {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null)
            {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.SeaplaneLandingArea
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.SeaplaneLandingArea Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public SeaplaneLandingAreaViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("Terminal", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TerminalViewModel : ViewModelBase
    {
        private String _portFacilityNumber = string.Empty;
        [Category("Terminal")]
        public String portFacilityNumber
        {
            get
            {
                return _portFacilityNumber;
            }

            set
            {
                SetValue(ref _portFacilityNumber, value);
            }
        }

        private categoryOfHarbourFacility? _categoryOfHarbourFacility = default;
        [Category("Terminal")]
        public categoryOfHarbourFacility? categoryOfHarbourFacility
        {
            get
            {
                return _categoryOfHarbourFacility;
            }

            set
            {
                SetValue(ref _categoryOfHarbourFacility, value);
            }
        }

        [Category("Terminal")]
        public ObservableCollection<categoryOfCargo> categoryOfCargo { get; set; } = new();

        [Category("Terminal")]
        public ObservableCollection<product> product { get; set; } = new();

        private String _terminalIdentifier = string.Empty;
        [Category("Terminal")]
        public String terminalIdentifier
        {
            get
            {
                return _terminalIdentifier;
            }

            set
            {
                SetValue(ref _terminalIdentifier, value);
            }
        }

        private String _sMDGTerminalCode = string.Empty;
        [Category("Terminal")]
        public String sMDGTerminalCode
        {
            get
            {
                return _sMDGTerminalCode;
            }

            set
            {
                SetValue(ref _sMDGTerminalCode, value);
            }
        }

        private String _uNLocationCode = string.Empty;
        [Category("Terminal")]
        public String uNLocationCode
        {
            get
            {
                return _uNLocationCode;
            }

            set
            {
                SetValue(ref _uNLocationCode, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class TerminalRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Terminal)];
        }

        public void Load(DomainModel.S131.FeatureTypes.Terminal instance)
        {
            portFacilityNumber = instance.portFacilityNumber;
            categoryOfHarbourFacility = instance.categoryOfHarbourFacility;
            categoryOfCargo.Clear();
            if (instance.categoryOfCargo is not null)
                foreach (var e in instance.categoryOfCargo)
                    categoryOfCargo.Add(e);
            product.Clear();
            if (instance.product is not null)
                foreach (var e in instance.product)
                    product.Add(e);
            terminalIdentifier = instance.terminalIdentifier;
            sMDGTerminalCode = instance.sMDGTerminalCode;
            uNLocationCode = instance.uNLocationCode;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.Terminal
            {
                portFacilityNumber = this.portFacilityNumber,
                categoryOfHarbourFacility = this.categoryOfHarbourFacility,
                categoryOfCargo = this.categoryOfCargo.ToList(),
                product = this.product.ToList(),
                terminalIdentifier = this.terminalIdentifier,
                sMDGTerminalCode = this.sMDGTerminalCode,
                uNLocationCode = this.uNLocationCode,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.Terminal Model => new()
        {
            portFacilityNumber = this._portFacilityNumber,
            categoryOfHarbourFacility = this._categoryOfHarbourFacility,
            categoryOfCargo = this.categoryOfCargo.ToList(),
            product = this.product.ToList(),
            terminalIdentifier = this._terminalIdentifier,
            sMDGTerminalCode = this._sMDGTerminalCode,
            uNLocationCode = this._uNLocationCode,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public TerminalViewModel() : base()
        {
            categoryOfCargo.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(categoryOfCargo));
            };
            product.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(product));
            };
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("TurningBasin", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TurningBasinViewModel : ViewModelBase
    {
        private depthsDescriptionViewModel? _depthsDescription;
        [Category("TurningBasin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription
        {
            get
            {
                return _depthsDescription;
            }

            set
            {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("TurningBasin")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("TurningBasin")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy
        {
            get
            {
                return _markedBy;
            }

            set
            {
                SetValue(ref _markedBy, value);
            }
        }

        private iSPSLevel? _iSPSLevel = default;
        [Category("TurningBasin")]
        public iSPSLevel? iSPSLevel
        {
            get
            {
                return _iSPSLevel;
            }

            set
            {
                SetValue(ref _iSPSLevel, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class TurningBasinRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TurningBasin)];
        }

        public void Load(DomainModel.S131.FeatureTypes.TurningBasin instance)
        {
            depthsDescription = new();
            if (instance.depthsDescription != null)
            {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null)
            {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            iSPSLevel = instance.iSPSLevel;
            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.TurningBasin
            {
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                iSPSLevel = this.iSPSLevel,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.TurningBasin Model => new()
        {
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            iSPSLevel = this._iSPSLevel,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public TurningBasinViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("WaterwayArea", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class WaterwayAreaViewModel : ViewModelBase
    {
        private categoryOfPortSection _categoryOfPortSection;
        [Category("WaterwayArea")]
        public categoryOfPortSection categoryOfPortSection
        {
            get
            {
                return _categoryOfPortSection;
            }

            set
            {
                SetValue(ref _categoryOfPortSection, value);
            }
        }

        private depthsDescriptionViewModel? _depthsDescription;
        [Category("WaterwayArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public depthsDescriptionViewModel? depthsDescription
        {
            get
            {
                return _depthsDescription;
            }

            set
            {
                SetValue(ref _depthsDescription, value);
            }
        }

        private String _locationByText = string.Empty;
        [Category("WaterwayArea")]
        public String locationByText
        {
            get
            {
                return _locationByText;
            }

            set
            {
                SetValue(ref _locationByText, value);
            }
        }

        private markedByViewModel? _markedBy;
        [Category("WaterwayArea")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public markedByViewModel? markedBy
        {
            get
            {
                return _markedBy;
            }

            set
            {
                SetValue(ref _markedBy, value);
            }
        }

        private String _locationMRN = string.Empty;
        [Category("FeatureType")]
        public String locationMRN
        {
            get
            {
                return _locationMRN;
            }

            set
            {
                SetValue(ref _locationMRN, value);
            }
        }

        private String _globalLocationNumber = string.Empty;
        [Category("FeatureType")]
        public String globalLocationNumber
        {
            get
            {
                return _globalLocationNumber;
            }

            set
            {
                SetValue(ref _globalLocationNumber, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<featureName> featureName { get; set; } = new();

        private fixedDateRangeViewModel? _fixedDateRange;
        [Category("FeatureType")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public fixedDateRangeViewModel? fixedDateRange
        {
            get
            {
                return _fixedDateRange;
            }

            set
            {
                SetValue(ref _fixedDateRange, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<periodicDateRange> periodicDateRange { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<rxNCode> rxNCode { get; set; } = new();

        [Category("FeatureType")]
        public ObservableCollection<graphic> graphic { get; set; } = new();

        private String _source = string.Empty;
        [Category("FeatureType")]
        public String source
        {
            get
            {
                return _source;
            }

            set
            {
                SetValue(ref _source, value);
            }
        }

        private sourceType? _sourceType = default;
        [Category("FeatureType")]
        public sourceType? sourceType
        {
            get
            {
                return _sourceType;
            }

            set
            {
                SetValue(ref _sourceType, value);
            }
        }

        private DateOnly? _reportedDate = default;
        [Category("FeatureType")]
        public DateOnly? reportedDate
        {
            get
            {
                return _reportedDate;
            }

            set
            {
                SetValue(ref _reportedDate, value);
            }
        }

        [Category("FeatureType")]
        public ObservableCollection<textContent> textContent { get; set; } = new();

        public class WaterwayAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(WaterwayArea)];
        }

        public void Load(DomainModel.S131.FeatureTypes.WaterwayArea instance)
        {
            categoryOfPortSection = instance.categoryOfPortSection;
            depthsDescription = new();
            if (instance.depthsDescription != null)
            {
                depthsDescription = new();
                depthsDescription.Load(instance.depthsDescription);
            }

            locationByText = instance.locationByText;
            markedBy = new();
            if (instance.markedBy != null)
            {
                markedBy = new();
                markedBy.Load(instance.markedBy);
            }

            locationMRN = instance.locationMRN;
            globalLocationNumber = instance.globalLocationNumber;
            featureName.Clear();
            if (instance.featureName is not null)
                foreach (var e in instance.featureName)
                    featureName.Add(e);
            fixedDateRange = new();
            if (instance.fixedDateRange != null)
            {
                fixedDateRange = new();
                fixedDateRange.Load(instance.fixedDateRange);
            }

            periodicDateRange.Clear();
            if (instance.periodicDateRange is not null)
                foreach (var e in instance.periodicDateRange)
                    periodicDateRange.Add(e);
            rxNCode.Clear();
            if (instance.rxNCode is not null)
                foreach (var e in instance.rxNCode)
                    rxNCode.Add(e);
            graphic.Clear();
            if (instance.graphic is not null)
                foreach (var e in instance.graphic)
                    graphic.Add(e);
            source = instance.source;
            sourceType = instance.sourceType;
            reportedDate = instance.reportedDate;
            textContent.Clear();
            if (instance.textContent is not null)
                foreach (var e in instance.textContent)
                    textContent.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.WaterwayArea
            {
                categoryOfPortSection = this.categoryOfPortSection,
                depthsDescription = this.depthsDescription?.Model,
                locationByText = this.locationByText,
                markedBy = this.markedBy?.Model,
                locationMRN = this.locationMRN,
                globalLocationNumber = this.globalLocationNumber,
                featureName = this.featureName.ToList(),
                fixedDateRange = this.fixedDateRange?.Model,
                periodicDateRange = this.periodicDateRange.ToList(),
                rxNCode = this.rxNCode.ToList(),
                graphic = this.graphic.ToList(),
                source = this.source,
                sourceType = this.sourceType,
                reportedDate = this.reportedDate,
                textContent = this.textContent.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.WaterwayArea Model => new()
        {
            categoryOfPortSection = this._categoryOfPortSection,
            depthsDescription = this._depthsDescription?.Model,
            locationByText = this._locationByText,
            markedBy = this._markedBy?.Model,
            locationMRN = this._locationMRN,
            globalLocationNumber = this._globalLocationNumber,
            featureName = this.featureName.ToList(),
            fixedDateRange = this._fixedDateRange?.Model,
            periodicDateRange = this.periodicDateRange.ToList(),
            rxNCode = this.rxNCode.ToList(),
            graphic = this.graphic.ToList(),
            source = this._source,
            sourceType = this._sourceType,
            reportedDate = this._reportedDate,
            textContent = this.textContent.ToList(),
        };

        public WaterwayAreaViewModel() : base()
        {
            featureName.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(featureName));
            };
            periodicDateRange.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(periodicDateRange));
            };
            rxNCode.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(rxNCode));
            };
            graphic.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(graphic));
            };
            textContent.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(textContent));
            };
        }
    }

    [CategoryOrder("DataCoverage", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class DataCoverageViewModel : ViewModelBase
    {
        private Int32 _maximumDisplayScale;
        [Category("DataCoverage")]
        public Int32 maximumDisplayScale
        {
            get
            {
                return _maximumDisplayScale;
            }

            set
            {
                SetValue(ref _maximumDisplayScale, value);
            }
        }

        private Int32 _minimumDisplayScale;
        [Category("DataCoverage")]
        public Int32 minimumDisplayScale
        {
            get
            {
                return _minimumDisplayScale;
            }

            set
            {
                SetValue(ref _minimumDisplayScale, value);
            }
        }

        public class DataCoverageRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(DataCoverage)];
        }

        public void Load(DomainModel.S131.FeatureTypes.DataCoverage instance)
        {
            maximumDisplayScale = instance.maximumDisplayScale;
            minimumDisplayScale = instance.minimumDisplayScale;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.DataCoverage
            {
                maximumDisplayScale = this.maximumDisplayScale,
                minimumDisplayScale = this.minimumDisplayScale,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.DataCoverage Model => new()
        {
            maximumDisplayScale = this._maximumDisplayScale,
            minimumDisplayScale = this._minimumDisplayScale,
        };

        public DataCoverageViewModel() : base()
        {
        }
    }

    [CategoryOrder("QualityOfNonBathymetricData", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class QualityOfNonBathymetricDataViewModel : ViewModelBase
    {
        private categoryOfTemporalVariation? _categoryOfTemporalVariation = default;
        [Category("QualityOfNonBathymetricData")]
        public categoryOfTemporalVariation? categoryOfTemporalVariation
        {
            get
            {
                return _categoryOfTemporalVariation;
            }

            set
            {
                SetValue(ref _categoryOfTemporalVariation, value);
            }
        }

        private Decimal? _horizontalDistanceUncertainty = default;
        [Category("QualityOfNonBathymetricData")]
        public Decimal? horizontalDistanceUncertainty
        {
            get
            {
                return _horizontalDistanceUncertainty;
            }

            set
            {
                SetValue(ref _horizontalDistanceUncertainty, value);
            }
        }

        private horizontalPositionUncertaintyViewModel _horizontalPositionUncertainty;
        [Category("QualityOfNonBathymetricData")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public horizontalPositionUncertaintyViewModel horizontalPositionUncertainty
        {
            get
            {
                return _horizontalPositionUncertainty;
            }

            set
            {
                SetValue(ref _horizontalPositionUncertainty, value);
            }
        }

        private Decimal? _orientationUncertainty = default;
        [Category("QualityOfNonBathymetricData")]
        public Decimal? orientationUncertainty
        {
            get
            {
                return _orientationUncertainty;
            }

            set
            {
                SetValue(ref _orientationUncertainty, value);
            }
        }

        private surveyDateRangeViewModel? _surveyDateRange;
        [Category("QualityOfNonBathymetricData")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public surveyDateRangeViewModel? surveyDateRange
        {
            get
            {
                return _surveyDateRange;
            }

            set
            {
                SetValue(ref _surveyDateRange, value);
            }
        }

        private verticalUncertaintyViewModel? _verticalUncertainty;
        [Category("QualityOfNonBathymetricData")]
        [Xceed.Wpf.Toolkit.PropertyGrid.Attributes.ExpandableObject]
        public verticalUncertaintyViewModel? verticalUncertainty
        {
            get
            {
                return _verticalUncertainty;
            }

            set
            {
                SetValue(ref _verticalUncertainty, value);
            }
        }

        [Category("QualityOfNonBathymetricData")]
        public ObservableCollection<information> information { get; set; } = new();

        public class QualityOfNonBathymetricDataRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(QualityOfNonBathymetricData)];
        }

        public void Load(DomainModel.S131.FeatureTypes.QualityOfNonBathymetricData instance)
        {
            categoryOfTemporalVariation = instance.categoryOfTemporalVariation;
            horizontalDistanceUncertainty = instance.horizontalDistanceUncertainty;
            horizontalPositionUncertainty = new();
            if (instance.horizontalPositionUncertainty != null)
            {
                horizontalPositionUncertainty = new();
                horizontalPositionUncertainty.Load(instance.horizontalPositionUncertainty);
            }

            orientationUncertainty = instance.orientationUncertainty;
            surveyDateRange = new();
            if (instance.surveyDateRange != null)
            {
                surveyDateRange = new();
                surveyDateRange.Load(instance.surveyDateRange);
            }

            verticalUncertainty = new();
            if (instance.verticalUncertainty != null)
            {
                verticalUncertainty = new();
                verticalUncertainty.Load(instance.verticalUncertainty);
            }

            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.QualityOfNonBathymetricData
            {
                categoryOfTemporalVariation = this.categoryOfTemporalVariation,
                horizontalDistanceUncertainty = this.horizontalDistanceUncertainty,
                horizontalPositionUncertainty = this.horizontalPositionUncertainty?.Model,
                orientationUncertainty = this.orientationUncertainty,
                surveyDateRange = this.surveyDateRange?.Model,
                verticalUncertainty = this.verticalUncertainty?.Model,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.QualityOfNonBathymetricData Model => new()
        {
            categoryOfTemporalVariation = this._categoryOfTemporalVariation,
            horizontalDistanceUncertainty = this._horizontalDistanceUncertainty,
            horizontalPositionUncertainty = this._horizontalPositionUncertainty?.Model,
            orientationUncertainty = this._orientationUncertainty,
            surveyDateRange = this._surveyDateRange?.Model,
            verticalUncertainty = this._verticalUncertainty?.Model,
            information = this.information.ToList(),
        };

        public QualityOfNonBathymetricDataViewModel() : base()
        {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
        }
    }

    [CategoryOrder("SoundingDatum", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class SoundingDatumViewModel : ViewModelBase
    {
        private verticalDatum _verticalDatum;
        [Category("SoundingDatum")]
        public verticalDatum verticalDatum
        {
            get
            {
                return _verticalDatum;
            }

            set
            {
                SetValue(ref _verticalDatum, value);
            }
        }

        [Category("SoundingDatum")]
        public ObservableCollection<information> information { get; set; } = new();

        public class SoundingDatumRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(SoundingDatum)];
        }

        public void Load(DomainModel.S131.FeatureTypes.SoundingDatum instance)
        {
            verticalDatum = instance.verticalDatum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.SoundingDatum
            {
                verticalDatum = this.verticalDatum,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.SoundingDatum Model => new()
        {
            verticalDatum = this._verticalDatum,
            information = this.information.ToList(),
        };

        public SoundingDatumViewModel() : base()
        {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
        }
    }

    [CategoryOrder("VerticalDatumOfData", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class VerticalDatumOfDataViewModel : ViewModelBase
    {
        private verticalDatum _verticalDatum;
        [Category("VerticalDatumOfData")]
        public verticalDatum verticalDatum
        {
            get
            {
                return _verticalDatum;
            }

            set
            {
                SetValue(ref _verticalDatum, value);
            }
        }

        [Category("VerticalDatumOfData")]
        public ObservableCollection<information> information { get; set; } = new();

        public class VerticalDatumOfDataRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(VerticalDatumOfData)];
        }

        public void Load(DomainModel.S131.FeatureTypes.VerticalDatumOfData instance)
        {
            verticalDatum = instance.verticalDatum;
            information.Clear();
            if (instance.information is not null)
                foreach (var e in instance.information)
                    information.Add(e);
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.VerticalDatumOfData
            {
                verticalDatum = this.verticalDatum,
                information = this.information.ToList(),
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.VerticalDatumOfData Model => new()
        {
            verticalDatum = this._verticalDatum,
            information = this.information.ToList(),
        };

        public VerticalDatumOfDataViewModel() : base()
        {
            information.CollectionChanged += (object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) =>
            {
                OnPropertyChanged(nameof(information));
            };
        }
    }

    [CategoryOrder("TextPlacement", 0)]
    [CategoryOrder("InformationBindings", 100)]
    [CategoryOrder("FeatureBindings", 200)]
    public partial class TextPlacementViewModel : ViewModelBase
    {
        private Decimal _orientationValue;
        [Category("TextPlacement")]
        public Decimal orientationValue
        {
            get
            {
                return _orientationValue;
            }

            set
            {
                SetValue(ref _orientationValue, value);
            }
        }

        private String _text = string.Empty;
        [Category("TextPlacement")]
        public String text
        {
            get
            {
                return _text;
            }

            set
            {
                SetValue(ref _text, value);
            }
        }

        private Int32 _textOffsetMm;
        [Category("TextPlacement")]
        public Int32 textOffsetMm
        {
            get
            {
                return _textOffsetMm;
            }

            set
            {
                SetValue(ref _textOffsetMm, value);
            }
        }

        private textType? _textType = default;
        [Category("TextPlacement")]
        public textType? textType
        {
            get
            {
                return _textType;
            }

            set
            {
                SetValue(ref _textType, value);
            }
        }

        private Int32? _scaleMinimum = default;
        [Category("TextPlacement")]
        public Int32? scaleMinimum
        {
            get
            {
                return _scaleMinimum;
            }

            set
            {
                SetValue(ref _scaleMinimum, value);
            }
        }

        public class TextPlacementRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public void Load(DomainModel.S131.FeatureTypes.TextPlacement instance)
        {
            orientationValue = instance.orientationValue;
            text = instance.text;
            textOffsetMm = instance.textOffsetMm;
            textType = instance.textType;
            scaleMinimum = instance.scaleMinimum;
        }

        public override string Serialize()
        {
            var instance = new DomainModel.S131.FeatureTypes.TextPlacement
            {
                orientationValue = this.orientationValue,
                text = this.text,
                textOffsetMm = this.textOffsetMm,
                textType = this.textType,
                scaleMinimum = this.scaleMinimum,
            };
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        [Browsable(false)]
        public DomainModel.S131.FeatureTypes.TextPlacement Model => new()
        {
            orientationValue = this._orientationValue,
            text = this._text,
            textOffsetMm = this._textOffsetMm,
            textType = this._textType,
            scaleMinimum = this._scaleMinimum,
        };

        public TextPlacementViewModel() : base()
        {
        }
    }

    public class TextAssociationViewModel : FeatureAssociationViewModel
    {
        public override string Code => "TextAssociation";
        public override string[] Roles => ["identifies", "positions"];

        private FeatureBindingViewModel? _positions;
        [ExpandableObject]
        public FeatureBindingViewModel? positions
        {
            get
            {
                return _positions;
            }

            set
            {
                this.SetValue(ref _positions, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                positions = null;
                if (value is not null)
                {
                    positions = value?.role switch
                    {
                        "identifies" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => TextAssociationViewModel._associationConnectorFeatures;

        public class positionsDryDockRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsFloatingDockRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsGridironRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsHarbourFacilityRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsAnchorBerthRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsAnchorageAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsBerthRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsBerthPositionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsDockAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsDumpingGroundRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsHarbourAreaAdministrativeRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsHarbourAreaSectionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsHarbourBasinRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsMooringWarpingFacilityRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsOuterLimitRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsPilotBoardingPlaceRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsSeaplaneLandingAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsTerminalRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsTurningBasinRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsWaterwayAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(TextPlacement)];
        }

        public class positionsTextPlacementRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(DryDock), typeof(FloatingDock), typeof(Gridiron), typeof(HarbourFacility), typeof(AnchorBerth), typeof(AnchorageArea), typeof(Berth), typeof(BerthPosition), typeof(DockArea), typeof(DumpingGround), typeof(HarbourAreaAdministrative), typeof(HarbourAreaSection), typeof(HarbourBasin), typeof(MooringWarpingFacility), typeof(OuterLimit), typeof(PilotBoardingPlace), typeof(SeaplaneLandingArea), typeof(Terminal), typeof(TurningBasin), typeof(WaterwayArea)];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(TextAssociationViewModel)]();
    }

    public class SubsectionViewModel : FeatureAssociationViewModel
    {
        public override string Code => "Subsection";
        public override string[] Roles => ["subUnit", "constitute"];

        private FeatureBindingViewModel? _subUnit;
        [ExpandableObject]
        public FeatureBindingViewModel? subUnit
        {
            get
            {
                return _subUnit;
            }

            set
            {
                this.SetValue(ref _subUnit, value);
            }
        }

        private FeatureBindingViewModel? _constitute;
        [ExpandableObject]
        public FeatureBindingViewModel? constitute
        {
            get
            {
                return _constitute;
            }

            set
            {
                this.SetValue(ref _constitute, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                subUnit = null;
                if (value is not null)
                {
                    subUnit = value?.role switch
                    {
                        "constitute" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }

                constitute = null;
                if (value is not null)
                {
                    constitute = value?.role switch
                    {
                        "subUnit" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => SubsectionViewModel._associationConnectorFeatures;

        public class constituteHarbourAreaSectionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class subUnitHarbourAreaSectionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(SubsectionViewModel)]();
    }

    public class InfrastructureViewModel : FeatureAssociationViewModel
    {
        public override string Code => "Infrastructure";
        public override string[] Roles => ["infrastructureLocation", "hasInfrastructure"];

        private FeatureBindingViewModel? _infrastructureLocation;
        [ExpandableObject]
        public FeatureBindingViewModel? infrastructureLocation
        {
            get
            {
                return _infrastructureLocation;
            }

            set
            {
                this.SetValue(ref _infrastructureLocation, value);
            }
        }

        private FeatureBindingViewModel? _hasInfrastructure;
        [ExpandableObject]
        public FeatureBindingViewModel? hasInfrastructure
        {
            get
            {
                return _hasInfrastructure;
            }

            set
            {
                this.SetValue(ref _hasInfrastructure, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                infrastructureLocation = null;
                if (value is not null)
                {
                    infrastructureLocation = value?.role switch
                    {
                        "hasInfrastructure" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }

                hasInfrastructure = null;
                if (value is not null)
                {
                    hasInfrastructure = value?.role switch
                    {
                        "infrastructureLocation" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => InfrastructureViewModel._associationConnectorFeatures;

        public class hasInfrastructureHarbourAreaSectionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(DryDock), typeof(FloatingDock), typeof(Gridiron), typeof(HarbourFacility)];
        }

        public class hasInfrastructureTerminalRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(DryDock), typeof(FloatingDock), typeof(Gridiron), typeof(HarbourFacility)];
        }

        public class infrastructureLocationDryDockRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection), typeof(Terminal)];
        }

        public class infrastructureLocationFloatingDockRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection), typeof(Terminal)];
        }

        public class infrastructureLocationGridironRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection), typeof(Terminal)];
        }

        public class infrastructureLocationHarbourFacilityRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection), typeof(Terminal)];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(InfrastructureViewModel)]();
    }

    public class PrimaryAuxiliaryFacilityViewModel : FeatureAssociationViewModel
    {
        public override string Code => "PrimaryAuxiliaryFacility";
        public override string[] Roles => ["primaryFacility", "auxiliaryFacility"];

        private FeatureBindingViewModel? _primaryFacility;
        [ExpandableObject]
        public FeatureBindingViewModel? primaryFacility
        {
            get
            {
                return _primaryFacility;
            }

            set
            {
                this.SetValue(ref _primaryFacility, value);
            }
        }

        private FeatureBindingViewModel? _auxiliaryFacility;
        [ExpandableObject]
        public FeatureBindingViewModel? auxiliaryFacility
        {
            get
            {
                return _auxiliaryFacility;
            }

            set
            {
                this.SetValue(ref _auxiliaryFacility, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                primaryFacility = null;
                if (value is not null)
                {
                    primaryFacility = value?.role switch
                    {
                        "auxiliaryFacility" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }

                auxiliaryFacility = null;
                if (value is not null)
                {
                    auxiliaryFacility = value?.role switch
                    {
                        "primaryFacility" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => PrimaryAuxiliaryFacilityViewModel._associationConnectorFeatures;

        public class auxiliaryFacilityAnchorBerthRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(MooringWarpingFacility)];
        }

        public class auxiliaryFacilityBerthPositionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(MooringWarpingFacility)];
        }

        public class primaryFacilityMooringWarpingFacilityRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AnchorBerth), typeof(BerthPosition)];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(PrimaryAuxiliaryFacilityViewModel)]();
    }

    public class DemarcationViewModel : FeatureAssociationViewModel
    {
        public override string Code => "Demarcation";
        public override string[] Roles => ["demarcationIndicator", "demarcatedFeature"];

        private FeatureBindingViewModel? _demarcationIndicator;
        [ExpandableObject]
        public FeatureBindingViewModel? demarcationIndicator
        {
            get
            {
                return _demarcationIndicator;
            }

            set
            {
                this.SetValue(ref _demarcationIndicator, value);
            }
        }

        private FeatureBindingViewModel? _demarcatedFeature;
        [ExpandableObject]
        public FeatureBindingViewModel? demarcatedFeature
        {
            get
            {
                return _demarcatedFeature;
            }

            set
            {
                this.SetValue(ref _demarcatedFeature, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                demarcationIndicator = null;
                if (value is not null)
                {
                    demarcationIndicator = value?.role switch
                    {
                        "demarcatedFeature" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }

                demarcatedFeature = null;
                if (value is not null)
                {
                    demarcatedFeature = value?.role switch
                    {
                        "demarcationIndicator" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => DemarcationViewModel._associationConnectorFeatures;

        public class demarcatedFeatureBerthPositionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Berth)];
        }

        public class demarcationIndicatorBerthRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(BerthPosition)];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(DemarcationViewModel)]();
    }

    public class JurisdictionalLimitViewModel : FeatureAssociationViewModel
    {
        public override string Code => "JurisdictionalLimit";
        public override string[] Roles => ["limitReference", "limitExtent"];

        private FeatureBindingViewModel? _limitReference;
        [ExpandableObject]
        public FeatureBindingViewModel? limitReference
        {
            get
            {
                return _limitReference;
            }

            set
            {
                this.SetValue(ref _limitReference, value);
            }
        }

        private FeatureBindingViewModel? _limitExtent;
        [ExpandableObject]
        public FeatureBindingViewModel? limitExtent
        {
            get
            {
                return _limitExtent;
            }

            set
            {
                this.SetValue(ref _limitExtent, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                limitReference = null;
                if (value is not null)
                {
                    limitReference = value?.role switch
                    {
                        "limitExtent" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }

                limitExtent = null;
                if (value is not null)
                {
                    limitExtent = value?.role switch
                    {
                        "limitReference" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => JurisdictionalLimitViewModel._associationConnectorFeatures;

        public class limitExtentHarbourAreaAdministrativeRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(OuterLimit)];
        }

        public class limitReferenceOuterLimitRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaAdministrative)];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(JurisdictionalLimitViewModel)]();
    }

    public class LayoutDivisionViewModel : FeatureAssociationViewModel
    {
        public override string Code => "LayoutDivision";
        public override string[] Roles => ["layoutUnit", "componentOf"];

        private FeatureBindingViewModel? _layoutUnit;
        [ExpandableObject]
        public FeatureBindingViewModel? layoutUnit
        {
            get
            {
                return _layoutUnit;
            }

            set
            {
                this.SetValue(ref _layoutUnit, value);
            }
        }

        private FeatureBindingViewModel? _componentOf;
        [ExpandableObject]
        public FeatureBindingViewModel? componentOf
        {
            get
            {
                return _componentOf;
            }

            set
            {
                this.SetValue(ref _componentOf, value);
            }
        }

        public override FeatureAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                layoutUnit = null;
                if (value is not null)
                {
                    layoutUnit = value?.role switch
                    {
                        "componentOf" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }

                componentOf = null;
                if (value is not null)
                {
                    componentOf = value?.role switch
                    {
                        "layoutUnit" => value.CreateForeignFeatureBinding(),
                        _ => value.CreateLocalFeatureBinding(),
                    };
                }
            }
        }

        public override FeatureAssociationConnector[] associationConnectorFeatures => LayoutDivisionViewModel._associationConnectorFeatures;

        public class componentOfAnchorageAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class componentOfBerthRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection), typeof(Terminal)];
        }

        public class componentOfDockAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class componentOfDumpingGroundRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class componentOfHarbourAreaSectionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaAdministrative)];
        }

        public class componentOfHarbourBasinRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class componentOfPilotBoardingPlaceRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class componentOfSeaplaneLandingAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class componentOfTerminalRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class componentOfTurningBasinRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class componentOfWaterwayAreaRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class layoutUnitHarbourAreaAdministrativeRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(HarbourAreaSection)];
        }

        public class layoutUnitHarbourAreaSectionRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AnchorageArea), typeof(Berth), typeof(DockArea), typeof(DumpingGround), typeof(HarbourBasin), typeof(PilotBoardingPlace), typeof(SeaplaneLandingArea), typeof(Terminal), typeof(TurningBasin), typeof(WaterwayArea)];
        }

        public class layoutUnitTerminalRefIdViewModel : FeatureRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Berth)];
        }

        public static FeatureAssociationConnector[] _associationConnectorFeatures => Handles.AssociationConnectorFeatures[typeof(LayoutDivisionViewModel)]();
    }

    public class AdditionalInformationViewModel : InformationAssociationViewModel
    {
        public override string Code => "AdditionalInformation";
        public override string[] Roles => ["providesInformation", "informationProvidedFor"];

        private InformationBindingViewModel? _providesInformation;
        [ExpandableObject]
        public InformationBindingViewModel? providesInformation
        {
            get
            {
                return _providesInformation;
            }

            set
            {
                this.SetValue(ref _providesInformation, value);
            }
        }

        private InformationBindingViewModel? _informationProvidedFor;
        [ExpandableObject]
        public InformationBindingViewModel? informationProvidedFor
        {
            get
            {
                return _informationProvidedFor;
            }

            set
            {
                this.SetValue(ref _informationProvidedFor, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                providesInformation = null;
                if (value is not null)
                {
                    providesInformation = value?.role switch
                    {
                        "informationProvidedFor" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                informationProvidedFor = null;
                if (value is not null)
                {
                    informationProvidedFor = value?.role switch
                    {
                        "providesInformation" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => AdditionalInformationViewModel._associationConnectorInformations;

        public class informationProvidedForNauticalInformationRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions), typeof(Applicability), typeof(Authority), typeof(AvailablePortServices), typeof(ContactDetails), typeof(Entrance), typeof(NonStandardWorkingDay), typeof(ServiceHours)];
        }

        public class providesInformationDryDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationFloatingDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationGridironRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationHarbourFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationAnchorBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationAnchorageAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationBerthPositionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationDockAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationDumpingGroundRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationHarbourAreaAdministrativeRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationHarbourAreaSectionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationHarbourBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationMooringWarpingFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationOuterLimitRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationPilotBoardingPlaceRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationSeaplaneLandingAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationTerminalRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationTurningBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationWaterwayAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationNauticalInformationRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationRecommendationsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationRegulationsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationRestrictionsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationApplicabilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationAuthorityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationAvailablePortServicesRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationContactDetailsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationEntranceRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationNonStandardWorkingDayRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public class providesInformationServiceHoursRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(AdditionalInformationViewModel)]();
    }

    public class AuthorityContactViewModel : InformationAssociationViewModel
    {
        public override string Code => "AuthorityContact";
        public override string[] Roles => ["theAuthority", "theContactDetails"];

        private InformationBindingViewModel? _theAuthority;
        [ExpandableObject]
        public InformationBindingViewModel? theAuthority
        {
            get
            {
                return _theAuthority;
            }

            set
            {
                this.SetValue(ref _theAuthority, value);
            }
        }

        private InformationBindingViewModel? _theContactDetails;
        [ExpandableObject]
        public InformationBindingViewModel? theContactDetails
        {
            get
            {
                return _theContactDetails;
            }

            set
            {
                this.SetValue(ref _theContactDetails, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                theAuthority = null;
                if (value is not null)
                {
                    theAuthority = value?.role switch
                    {
                        "theContactDetails" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theContactDetails = null;
                if (value is not null)
                {
                    theContactDetails = value?.role switch
                    {
                        "theAuthority" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => AuthorityContactViewModel._associationConnectorInformations;

        public class theAuthorityContactDetailsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class theContactDetailsAuthorityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(AuthorityContactViewModel)]();
    }

    public class AuthorityHoursViewModel : InformationAssociationViewModel
    {
        public override string Code => "AuthorityHours";
        public override string[] Roles => ["theAuthority_srvHrs", "theServiceHours"];

        private InformationBindingViewModel? _theAuthority_srvHrs;
        [ExpandableObject]
        public InformationBindingViewModel? theAuthority_srvHrs
        {
            get
            {
                return _theAuthority_srvHrs;
            }

            set
            {
                this.SetValue(ref _theAuthority_srvHrs, value);
            }
        }

        private InformationBindingViewModel? _theServiceHours;
        [ExpandableObject]
        public InformationBindingViewModel? theServiceHours
        {
            get
            {
                return _theServiceHours;
            }

            set
            {
                this.SetValue(ref _theServiceHours, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                theAuthority_srvHrs = null;
                if (value is not null)
                {
                    theAuthority_srvHrs = value?.role switch
                    {
                        "theServiceHours" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theServiceHours = null;
                if (value is not null)
                {
                    theServiceHours = value?.role switch
                    {
                        "theAuthority_srvHrs" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => AuthorityHoursViewModel._associationConnectorInformations;

        public class theAuthority_srvHrsServiceHoursRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class theServiceHoursAuthorityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(AuthorityHoursViewModel)]();
    }

    public class AssociatedRxNViewModel : InformationAssociationViewModel
    {
        public override string Code => "AssociatedRxN";
        public override string[] Roles => ["appliesInLocation", "theRxN"];

        private InformationBindingViewModel? _appliesInLocation;
        [ExpandableObject]
        public InformationBindingViewModel? appliesInLocation
        {
            get
            {
                return _appliesInLocation;
            }

            set
            {
                this.SetValue(ref _appliesInLocation, value);
            }
        }

        private InformationBindingViewModel? _theRxN;
        [ExpandableObject]
        public InformationBindingViewModel? theRxN
        {
            get
            {
                return _theRxN;
            }

            set
            {
                this.SetValue(ref _theRxN, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                appliesInLocation = null;
                if (value is not null)
                {
                    appliesInLocation = value?.role switch
                    {
                        "theRxN" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theRxN = null;
                if (value is not null)
                {
                    theRxN = value?.role switch
                    {
                        "appliesInLocation" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => AssociatedRxNViewModel._associationConnectorInformations;

        public class theRxNDryDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNFloatingDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNGridironRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNHarbourFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNAnchorBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNAnchorageAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNBerthPositionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNDockAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNDumpingGroundRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNHarbourAreaAdministrativeRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNHarbourAreaSectionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNHarbourBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNMooringWarpingFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNOuterLimitRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNPilotBoardingPlaceRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNSeaplaneLandingAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNTerminalRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNTurningBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theRxNWaterwayAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(AssociatedRxNViewModel)]();
    }

    public class ExceptionalWorkdayViewModel : InformationAssociationViewModel
    {
        public override string Code => "ExceptionalWorkday";
        public override string[] Roles => ["theServiceHours_nsdy", "partialWorkingDay"];

        private InformationBindingViewModel? _theServiceHours_nsdy;
        [ExpandableObject]
        public InformationBindingViewModel? theServiceHours_nsdy
        {
            get
            {
                return _theServiceHours_nsdy;
            }

            set
            {
                this.SetValue(ref _theServiceHours_nsdy, value);
            }
        }

        private InformationBindingViewModel? _partialWorkingDay;
        [ExpandableObject]
        public InformationBindingViewModel? partialWorkingDay
        {
            get
            {
                return _partialWorkingDay;
            }

            set
            {
                this.SetValue(ref _partialWorkingDay, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                theServiceHours_nsdy = null;
                if (value is not null)
                {
                    theServiceHours_nsdy = value?.role switch
                    {
                        "partialWorkingDay" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                partialWorkingDay = null;
                if (value is not null)
                {
                    partialWorkingDay = value?.role switch
                    {
                        "theServiceHours_nsdy" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => ExceptionalWorkdayViewModel._associationConnectorInformations;

        public class partialWorkingDayServiceHoursRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NonStandardWorkingDay)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(ExceptionalWorkdayViewModel)]();
    }

    public class ServiceControlViewModel : InformationAssociationViewModel
    {
        public override string Code => "ServiceControl";
        public override string[] Roles => ["controlledService", "controlAuthority"];

        private InformationBindingViewModel? _controlledService;
        [ExpandableObject]
        public InformationBindingViewModel? controlledService
        {
            get
            {
                return _controlledService;
            }

            set
            {
                this.SetValue(ref _controlledService, value);
            }
        }

        private InformationBindingViewModel? _controlAuthority;
        [ExpandableObject]
        public InformationBindingViewModel? controlAuthority
        {
            get
            {
                return _controlAuthority;
            }

            set
            {
                this.SetValue(ref _controlAuthority, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                controlledService = null;
                if (value is not null)
                {
                    controlledService = value?.role switch
                    {
                        "controlAuthority" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                controlAuthority = null;
                if (value is not null)
                {
                    controlAuthority = value?.role switch
                    {
                        "controlledService" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => ServiceControlViewModel._associationConnectorInformations;

        public class controlAuthorityDryDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityFloatingDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityGridironRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityHarbourFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityAnchorBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityAnchorageAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityBerthPositionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityDockAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityDumpingGroundRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityHarbourAreaAdministrativeRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityHarbourAreaSectionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityHarbourBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityMooringWarpingFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityOuterLimitRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityPilotBoardingPlaceRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthoritySeaplaneLandingAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityTerminalRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityTurningBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class controlAuthorityWaterwayAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(ServiceControlViewModel)]();
    }

    public class ServiceContactViewModel : InformationAssociationViewModel
    {
        public override string Code => "ServiceContact";
        public override string[] Roles => ["servicePlace", "theContactDetails"];

        private InformationBindingViewModel? _servicePlace;
        [ExpandableObject]
        public InformationBindingViewModel? servicePlace
        {
            get
            {
                return _servicePlace;
            }

            set
            {
                this.SetValue(ref _servicePlace, value);
            }
        }

        private InformationBindingViewModel? _theContactDetails;
        [ExpandableObject]
        public InformationBindingViewModel? theContactDetails
        {
            get
            {
                return _theContactDetails;
            }

            set
            {
                this.SetValue(ref _theContactDetails, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                servicePlace = null;
                if (value is not null)
                {
                    servicePlace = value?.role switch
                    {
                        "theContactDetails" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theContactDetails = null;
                if (value is not null)
                {
                    theContactDetails = value?.role switch
                    {
                        "servicePlace" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => ServiceContactViewModel._associationConnectorInformations;

        public class theContactDetailsDryDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsFloatingDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsGridironRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsHarbourFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsAnchorBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsAnchorageAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsBerthPositionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsDockAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsDumpingGroundRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsHarbourAreaAdministrativeRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsHarbourAreaSectionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsHarbourBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsMooringWarpingFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsOuterLimitRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsPilotBoardingPlaceRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsSeaplaneLandingAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsTerminalRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsTurningBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public class theContactDetailsWaterwayAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ContactDetails)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(ServiceContactViewModel)]();
    }

    public class LocationHoursViewModel : InformationAssociationViewModel
    {
        public override string Code => "LocationHours";
        public override string[] Roles => ["location_srvHrs", "facilityOperatingHours"];

        private InformationBindingViewModel? _location_srvHrs;
        [ExpandableObject]
        public InformationBindingViewModel? location_srvHrs
        {
            get
            {
                return _location_srvHrs;
            }

            set
            {
                this.SetValue(ref _location_srvHrs, value);
            }
        }

        private InformationBindingViewModel? _facilityOperatingHours;
        [ExpandableObject]
        public InformationBindingViewModel? facilityOperatingHours
        {
            get
            {
                return _facilityOperatingHours;
            }

            set
            {
                this.SetValue(ref _facilityOperatingHours, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                location_srvHrs = null;
                if (value is not null)
                {
                    location_srvHrs = value?.role switch
                    {
                        "facilityOperatingHours" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                facilityOperatingHours = null;
                if (value is not null)
                {
                    facilityOperatingHours = value?.role switch
                    {
                        "location_srvHrs" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => LocationHoursViewModel._associationConnectorInformations;

        public class location_srvHrsAnchorageAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsAnchorBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsDockAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsDryDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsDumpingGroundRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsFloatingDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsGridironRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsHarbourAreaAdministrativeRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsHarbourAreaSectionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsHarbourBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsHarbourFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsMooringWarpingFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsPilotBoardingPlaceRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsSeaplaneLandingAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsTerminalRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsTurningBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public class location_srvHrsWaterwayAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(ServiceHours)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(LocationHoursViewModel)]();
    }

    public class RelatedOrganisationViewModel : InformationAssociationViewModel
    {
        public override string Code => "RelatedOrganisation";
        public override string[] Roles => ["theInformation", "theOrganisation"];

        private InformationBindingViewModel? _theInformation;
        [ExpandableObject]
        public InformationBindingViewModel? theInformation
        {
            get
            {
                return _theInformation;
            }

            set
            {
                this.SetValue(ref _theInformation, value);
            }
        }

        private InformationBindingViewModel? _theOrganisation;
        [ExpandableObject]
        public InformationBindingViewModel? theOrganisation
        {
            get
            {
                return _theOrganisation;
            }

            set
            {
                this.SetValue(ref _theOrganisation, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                theInformation = null;
                if (value is not null)
                {
                    theInformation = value?.role switch
                    {
                        "theOrganisation" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                theOrganisation = null;
                if (value is not null)
                {
                    theOrganisation = value?.role switch
                    {
                        "theInformation" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => RelatedOrganisationViewModel._associationConnectorInformations;

        public class theInformationAuthorityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public class theOrganisationNauticalInformationRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class theOrganisationRecommendationsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class theOrganisationRegulationsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public class theOrganisationRestrictionsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Authority)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(RelatedOrganisationViewModel)]();
    }

    public class InclusionTypeViewModel : InformationAssociationViewModel
    {
        public override string Code => "InclusionType";
        public override string[] Roles => ["theApplicableRxN", "isApplicableTo"];

        private InformationBindingViewModel? _theApplicableRxN;
        [ExpandableObject]
        public InformationBindingViewModel? theApplicableRxN
        {
            get
            {
                return _theApplicableRxN;
            }

            set
            {
                this.SetValue(ref _theApplicableRxN, value);
            }
        }

        private InformationBindingViewModel? _isApplicableTo;
        [ExpandableObject]
        public InformationBindingViewModel? isApplicableTo
        {
            get
            {
                return _isApplicableTo;
            }

            set
            {
                this.SetValue(ref _isApplicableTo, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                theApplicableRxN = null;
                if (value is not null)
                {
                    theApplicableRxN = value?.role switch
                    {
                        "isApplicableTo" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                isApplicableTo = null;
                if (value is not null)
                {
                    isApplicableTo = value?.role switch
                    {
                        "theApplicableRxN" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => InclusionTypeViewModel._associationConnectorInformations;

        public class isApplicableToNauticalInformationRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class isApplicableToRecommendationsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class isApplicableToRegulationsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class isApplicableToRestrictionsRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class theApplicableRxNApplicabilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(InclusionTypeViewModel)]();
    }

    public class PermissionTypeViewModel : InformationAssociationViewModel
    {
        public override string Code => "PermissionType";
        public override string[] Roles => ["vslLocation", "permission"];

        private InformationBindingViewModel? _vslLocation;
        [ExpandableObject]
        public InformationBindingViewModel? vslLocation
        {
            get
            {
                return _vslLocation;
            }

            set
            {
                this.SetValue(ref _vslLocation, value);
            }
        }

        private InformationBindingViewModel? _permission;
        [ExpandableObject]
        public InformationBindingViewModel? permission
        {
            get
            {
                return _permission;
            }

            set
            {
                this.SetValue(ref _permission, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                vslLocation = null;
                if (value is not null)
                {
                    vslLocation = value?.role switch
                    {
                        "permission" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                permission = null;
                if (value is not null)
                {
                    permission = value?.role switch
                    {
                        "vslLocation" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => PermissionTypeViewModel._associationConnectorInformations;

        public class permissionDryDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionFloatingDockRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionGridironRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionHarbourFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionAnchorBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionAnchorageAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionBerthPositionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionDockAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionDumpingGroundRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionHarbourAreaAdministrativeRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionHarbourAreaSectionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionHarbourBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionMooringWarpingFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionOuterLimitRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionPilotBoardingPlaceRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionSeaplaneLandingAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionTerminalRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionTurningBasinRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class permissionWaterwayAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Applicability)];
        }

        public class vslLocationApplicabilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(NauticalInformation), typeof(Recommendations), typeof(Regulations), typeof(Restrictions), typeof(Applicability), typeof(Authority), typeof(AvailablePortServices), typeof(ContactDetails), typeof(Entrance), typeof(NonStandardWorkingDay), typeof(ServiceHours)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(PermissionTypeViewModel)]();
    }

    public class SpatialAssociationViewModel : InformationAssociationViewModel
    {
        public override string Code => "SpatialAssociation";
        public override string[] Roles => ["defines", "definedFor"];

        private InformationBindingViewModel? _defines;
        [ExpandableObject]
        public InformationBindingViewModel? defines
        {
            get
            {
                return _defines;
            }

            set
            {
                this.SetValue(ref _defines, value);
            }
        }

        private InformationBindingViewModel? _definedFor;
        [ExpandableObject]
        public InformationBindingViewModel? definedFor
        {
            get
            {
                return _definedFor;
            }

            set
            {
                this.SetValue(ref _definedFor, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                defines = null;
                if (value is not null)
                {
                    defines = value?.role switch
                    {
                        "definedFor" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                definedFor = null;
                if (value is not null)
                {
                    definedFor = value?.role switch
                    {
                        "defines" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => SpatialAssociationViewModel._associationConnectorInformations;
        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(SpatialAssociationViewModel)]();
    }

    public class LimitEntranceViewModel : InformationAssociationViewModel
    {
        public override string Code => "LimitEntrance";
        public override string[] Roles => ["entranceTo", "entranceReference"];

        private InformationBindingViewModel? _entranceTo;
        [ExpandableObject]
        public InformationBindingViewModel? entranceTo
        {
            get
            {
                return _entranceTo;
            }

            set
            {
                this.SetValue(ref _entranceTo, value);
            }
        }

        private InformationBindingViewModel? _entranceReference;
        [ExpandableObject]
        public InformationBindingViewModel? entranceReference
        {
            get
            {
                return _entranceReference;
            }

            set
            {
                this.SetValue(ref _entranceReference, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                entranceTo = null;
                if (value is not null)
                {
                    entranceTo = value?.role switch
                    {
                        "entranceReference" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                entranceReference = null;
                if (value is not null)
                {
                    entranceReference = value?.role switch
                    {
                        "entranceTo" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => LimitEntranceViewModel._associationConnectorInformations;

        public class entranceReferenceOuterLimitRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(Entrance)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(LimitEntranceViewModel)]();
    }

    public class ServiceAvailabilityViewModel : InformationAssociationViewModel
    {
        public override string Code => "ServiceAvailability";
        public override string[] Roles => ["locationServed", "serviceDescriptionReference"];

        private InformationBindingViewModel? _locationServed;
        [ExpandableObject]
        public InformationBindingViewModel? locationServed
        {
            get
            {
                return _locationServed;
            }

            set
            {
                this.SetValue(ref _locationServed, value);
            }
        }

        private InformationBindingViewModel? _serviceDescriptionReference;
        [ExpandableObject]
        public InformationBindingViewModel? serviceDescriptionReference
        {
            get
            {
                return _serviceDescriptionReference;
            }

            set
            {
                this.SetValue(ref _serviceDescriptionReference, value);
            }
        }

        public override InformationAssociationConnector? associationConnector
        {
            get
            {
                return _associationConnector;
            }

            set
            {
                this.SetValue(ref _associationConnector, value);
                locationServed = null;
                if (value is not null)
                {
                    locationServed = value?.role switch
                    {
                        "serviceDescriptionReference" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }

                serviceDescriptionReference = null;
                if (value is not null)
                {
                    serviceDescriptionReference = value?.role switch
                    {
                        "locationServed" => value.CreateForeignInformationBinding(),
                        _ => value.CreateLocalInformationBinding(),
                    };
                }
            }
        }

        public override InformationAssociationConnector[] associationConnectorInformations => ServiceAvailabilityViewModel._associationConnectorInformations;

        public class serviceDescriptionReferenceAnchorBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AvailablePortServices)];
        }

        public class serviceDescriptionReferenceBerthRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AvailablePortServices)];
        }

        public class serviceDescriptionReferenceDockAreaRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AvailablePortServices)];
        }

        public class serviceDescriptionReferenceHarbourAreaAdministrativeRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AvailablePortServices)];
        }

        public class serviceDescriptionReferenceHarbourAreaSectionRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AvailablePortServices)];
        }

        public class serviceDescriptionReferenceMooringWarpingFacilityRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AvailablePortServices)];
        }

        public class serviceDescriptionReferenceTerminalRefIdViewModel : InformationRefIdViewModel
        {
            public Type[] AssociationTypes => [typeof(AvailablePortServices)];
        }

        public static InformationAssociationConnector[] _associationConnectorInformations => Handles.AssociationConnectorInformations[typeof(ServiceAvailabilityViewModel)]();
    }
}