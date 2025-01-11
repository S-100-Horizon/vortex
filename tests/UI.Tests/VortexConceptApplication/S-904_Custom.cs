using S100Framework.Catalogues;
using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S201.FeatureTypes;
using S100Framework.WPF.ViewModel.S101;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel.S903
{
    public abstract class S100_FC_FeatureAssociation
    {
        public abstract string Code { get; }
        public abstract string[] Roles { get; }

        public abstract S100_FC_AssociationEndpointDescriptor[] associationDescriptors { get; }
    }

    public abstract class S100_FC_AssociationEndpointDescriptor
    {
        public roleType roleType { get; set; }

        public string role { get; set; }

        [Browsable(false)]
        public Type[] FeatureTypes { get; set; }

        [PropertyOrder(1)]
        public abstract int Lower { get; }

        [PropertyOrder(2)]
        public abstract int? Upper { get; }

    }

    public abstract class S100_FC_AssociationEndpointDescriptor<T> : S100_FC_AssociationEndpointDescriptor where T : FeatureTypeBase
    {
    }

    public class S100_FC_S100_FC_AssociationEndpointSingleDescriptor<T> : S100_FC_AssociationEndpointDescriptor<T> where T : FeatureTypeBase
    {
        public string RefId { get; set; }

        public override int Lower => 1;

        public override int? Upper => 1;
    }

    public class S100_FC_S100_FC_AssociationEndpointOptionalDescriptor<T> : S100_FC_AssociationEndpointDescriptor<T> where T : FeatureTypeBase
    {
        public string? RefId { get; set; } = default;

        public override int Lower => 0;

        public override int? Upper => 1;
    }

    public class S100_FC_S100_FC_AssociationEndpointMultiDescriptor<T> : S100_FC_AssociationEndpointDescriptor<T> where T : FeatureTypeBase
    {
        private int _lower;
        private int? _upper;

        public S100_FC_S100_FC_AssociationEndpointMultiDescriptor(int lower, int? upper = default) {
            _lower = lower;
            _upper = upper;
        }

        public List<string> RefId { get; set; } = new();

        public override int Lower => _lower;

        public override int? Upper => _upper;
    }



    public class S100_FC_FeatureBinding
    {
        public roleType roleType { get; set; }
        public int Lower { get; set; }
        public int? Upper { get; set; } = default;

        public string Role { get; set; }

        public Type[] FeatureTypes { get; set; }
    }


    public abstract class S100_FC_AssociationEndpoint
    {
    }

    public class S100_FC_AssociationEndpoint<T> : S100_FC_AssociationEndpoint where T : FeatureTypeBase
    {
        public Type FeatureType => typeof(T);

        //RefID
    }

    public class IslandAggregation : S100_FC_FeatureAssociation
    {
        public override string Code => "IslandAggregation";

        public override string[] Roles => ["theCollection", "theComponent"];

        //public S100_FC_FeatureBinding[] theCollection => new S100_FC_FeatureBinding[] { 
        //    new S100_FC_FeatureBinding {
        //        Lower = 0,
        //        Upper = 1,
        //        Role = "theCollection",
        //        FeatureType = typeof(LandArea),
        //    },
        //    new S100_FC_FeatureBinding {
        //        Lower = 0,
        //        Upper = 1,
        //        Role = "theCollection",
        //        FeatureType = typeof(IslandGroup),
        //    },
        //};

        //public S100_FC_FeatureBinding[] theComponent => new S100_FC_FeatureBinding[] {
        //    new S100_FC_FeatureBinding {
        //        Lower = 0,
        //        Upper = default,
        //        Role = "theComponent",
        //        FeatureType = typeof(IslandGroup),
        //    },
        //};

        //public Type[] theCollections => [typeof(IslandGroup)];

        //public Type[] theComponents => [typeof(LandArea),typeof(IslandGroup)];

        [ExpandableObject]
        public S100_FC_AssociationEndpoint? theComponent { get; set; } = default;

        [ExpandableObject]
        public S100_FC_AssociationEndpoint? theCollection { get; set; } = default;


        public override S100_FC_AssociationEndpointDescriptor[] associationDescriptors => new S100_FC_AssociationEndpointDescriptor[] {
            new S100_FC_S100_FC_AssociationEndpointOptionalDescriptor<LandArea>() {
                roleType = roleType.aggregation,
                role = nameof(theCollection),
                FeatureTypes = [typeof(IslandGroup)],
            },
            new S100_FC_S100_FC_AssociationEndpointOptionalDescriptor<IslandGroup>() {
                roleType = roleType.aggregation,
                role = nameof(theCollection),
                FeatureTypes = [typeof(IslandGroup)],
            },
            new S100_FC_S100_FC_AssociationEndpointOptionalDescriptor<IslandGroup>() {
                roleType = roleType.association,
                role = nameof(theComponent),
                FeatureTypes = [typeof(LandArea),typeof(IslandGroup)],
            },
        };

        public static IslandAggregation TestIslandGroup => new IslandAggregation() {

        };

        /*
            <S100FC:featureBinding roleType="association">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="true" infinite="true" />
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theComponent" />
                <S100FC:featureType ref="LandArea" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>
         */
        //public static IslandAggregation TestIslandGroup => new IslandAggregation {
        //    theCollection = new S100_FC_S100_FC_AssociationEndpointOptional {
        //        roleType = roleType.aggregation,
        //        FeatureTypes = [typeof(IslandGroup)],
        //    },

        //    theComponent = new S100_FC_S100_FC_AssociationEndpointMulti(lower: 0) {
        //        roleType = roleType.association,
        //        FeatureTypes = [typeof(LandArea),typeof(IslandGroup)],
        //    },
        //};

        /*
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>
         */
        //public static IslandAggregation TestLandArea => new IslandAggregation {
        //    theCollection = new S100_FC_FeatureBinding {
        //        roleType = roleType.aggregation,
        //        Lower = 0,
        //        Upper = 1,
        //        Role = "theCollection",
        //        FeatureTypes = [typeof(IslandGroup)]
        //    },
        //};

    }

}

/*
    LandArea:
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>


    IslandGroup:
            <S100FC:featureBinding roleType="association">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="true" infinite="true" />
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theComponent" />
                <S100FC:featureType ref="LandArea" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="IslandAggregation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="IslandGroup" />
            </S100FC:featureBinding>

 */



/*
    Building:
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="AidsToNavigationAssociation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="DeepWaterRoute" />
                <S100FC:featureType ref="FairwaySystem" />
                <S100FC:featureType ref="TrafficSeparationScheme" />
                <S100FC:featureType ref="TwoWayRoute" />
            </S100FC:featureBinding>

    BRIDGE:
            <S100FC:featureBinding roleType="aggregation">
                <S100FC:multiplicity>
                    <S100Base:lower>0</S100Base:lower>
                    <S100Base:upper xsi:nil="false" infinite="false">1</S100Base:upper>
                </S100FC:multiplicity>
                <S100FC:association ref="AidsToNavigationAssociation" />
                <S100FC:role ref="theCollection" />
                <S100FC:featureType ref="FairwaySystem" />
                <S100FC:featureType ref="TrafficSeparationScheme" />
                <S100FC:featureType ref="TwoWayRoute" />
            </S100FC:featureBinding>

 */