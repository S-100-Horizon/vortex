using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S201.FeatureTypes;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel.S902
{
    public class informationBinding
    {
        public string? RefId { get; set; } = default;

        public InformationAssociation? association { get; set; }
        public Type? informationType { get; set; }

        public InformationBindingDescriptor? informationBindingDescriptor { get; set; }
    }

    public class S131_FeatureTypeTest : DomainModel.S131.FeatureTypes.FeatureType
    {
        //    public static informationBindingDescriptor[] informationBindings => new informationBindingDescriptor[] {
        //        new informationBindingDescriptor<DomainModel.S131.Associations.InformationAssociations.PermissionType>(roleType.association, 0, int.MaxValue, "permission", [typeof(Applicability),typeof(AbstractRxN)]),
        //        new informationBindingDescriptor<DomainModel.S131.Associations.InformationAssociations.AssociatedRxN>(roleType.association, 0, int.MaxValue, "theRxN", [typeof(AbstractRxN)]),
        //        new informationBindingDescriptor<DomainModel.S131.Associations.InformationAssociations.AdditionalInformation>(roleType.association, 0, int.MaxValue, "providesInformation", [typeof(NauticalInformation)]),
        //    };
    }

    public class S131_FeatureTypeTestViewModel : ViewModelBase
    {
        private informationBinding<DomainModel.S131.Associations.InformationAssociations.AdditionalInformation> _providesInformationOfAdditionalInformation;

        [ExpandableObject]
        public informationBinding<DomainModel.S131.Associations.InformationAssociations.AdditionalInformation> providesInformationOfAdditionalInformation {
            get { return _providesInformationOfAdditionalInformation; }
            set { base.SetValue(ref _providesInformationOfAdditionalInformation, value); }
        }


        private InformationBindingViewModel _informationBinding1;

        [ExpandableObject]
        public InformationBindingViewModel informationBinding {
            get { return _informationBinding1; }
            set { base.SetValue(ref _informationBinding1, value); }
        }

        [Browsable(false)]
        public InformationBindingDescriptor[] InformationBindingDescriptors => DomainModel.S131.FeatureTypes.FeatureType.InformationBindingDescriptors;

        public void Load(S131_FeatureTypeTest instance) {
            _providesInformationOfAdditionalInformation = new();
            _informationBinding1 = new InformationBindingViewModel() {
                //association = new DomainModel.S131.Associations.InformationAssociations.PermissionType(),
                //informationBindingDescriptor = S131_FeatureTypeTest.informationBindingDescriptors[0],
            };
        }

        public override string Serialize() {
            throw new NotImplementedException();
        }
    }





}

/*
			<S100FC:informationBinding roleType="association">
				<S100FC:multiplicity>
					<S100Base:lower>0</S100Base:lower>
					<S100Base:upper xsi:nil="true" infinite="true"/>
				</S100FC:multiplicity>
				<S100FC:association ref="AdditionalInformation"/>
				<S100FC:role ref="providesInformation"/>
				<S100FC:informationType ref="NauticalInformation"/>
			</S100FC:informationBinding>
 */