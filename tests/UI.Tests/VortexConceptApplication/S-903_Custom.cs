using S100Framework.Catalogues;
using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.WPF.ViewModel.S101;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel.S903
{
    //[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    //public class InformationTypeAttribute : System.Attribute
    //{
    //    private Type _informationType;

    //    public Type informationType => _informationType;

    //    public InformationTypeAttribute(Type informationType) {
    //        _informationType = informationType;
    //    }
    //}

    //[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]
    //public class FeatureTypeAttribute : System.Attribute
    //{
    //    private Type _featureType;

    //    public Type FeatureType => _featureType;

    //    public FeatureTypeAttribute(Type featureType) {
    //        _featureType = featureType;
    //    }
    //}


    public class S101_PileTest : DomainModel.S101.FeatureTypes.Pile
    {
        [FeatureType(typeof(ArchipelagicSeaLane))]
        [FeatureType(typeof(DeepWaterRoute))]
        [FeatureType(typeof(FairwaySystem))]
        [FeatureType(typeof(TrafficSeparationScheme))]
        [FeatureType(typeof(TwoWayRoute))]
        public featureBinding<DomainModel.S101.Associations.FeatureAssociations.AidsToNavigationAssociation>? theCollectionOfAidsToNavigationAssociationTest { get; set; }
    }

    public class StructureEquipment : FeatureAssociation
    {
        public StructureEquipment() {
        }
        public static Role[] Roles => new[] { Role.theStructure, Role.theEquipment };

        public Type[] theStructures => new[] {
            typeof(Bridge),
            typeof(Building),
            typeof(Crane),
            typeof(CardinalBeacon),
            //...
        };

        public Type[] theEquipment => new[] {
            typeof(Daymark),
            typeof(DistanceMark),
            typeof(FogSignal),
            typeof(Helipad),
            //...
        };
    }


    [CategoryOrder("Pile", 0)]
    public class S101_PileTestViewModel : PileViewModel
    {
        //  public informationBinding<Associations.InformationAssociations.AdditionalInformation>? theInformationOfAdditionalInformation { get; set; }

        //private FeatureBindingViewModel<DomainModel.S101.Associations.FeatureAssociations.AidsToNavigationAssociation> _theCollectionOfAidsToNavigationAssociationTest = new(typeof(S100Framework.WPF.ViewModel.S903.S101_PileTest).GetProperty("theCollectionOfAidsToNavigationAssociationTest")!.GetCustomAttributes<FeatureTypeAttribute>());

        //[ExpandableObject]
        //public FeatureBindingViewModel<DomainModel.S101.Associations.FeatureAssociations.AidsToNavigationAssociation> theCollectionOfAidsToNavigationAssociationTest {
        //    get { return _theCollectionOfAidsToNavigationAssociationTest; }
        //    set { base.SetValue(ref _theCollectionOfAidsToNavigationAssociationTest, value); }
        //}
    }
}
