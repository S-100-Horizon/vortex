using S100Framework.Catalogues;
using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S201.FeatureTypes;
using S100Framework.WPF.ViewModel.S101;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel.S903
{
    public abstract class S100_FC_FeatureAssociation
    {
        public abstract string Code { get; }
        public abstract string[] Roles { get; }
    }

    public class S100_FC_FeatureBinding {
        public roleType roleType { get; set; }
        public int Lower { get; set; }
        public int? Upper { get; set; } = default;

        public string Role { get; set; }

        public Type[] FeatureTypes { get; set; }
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

        public Type[] theCollections => [typeof(IslandGroup)];

        public Type[] theComponents => [typeof(LandArea),typeof(IslandGroup)];

        public S100_FC_FeatureBinding? theComponent { get; set; } = default;

        public S100_FC_FeatureBinding? theCollection { get; set; } = default;

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
        public static IslandAggregation TestIslandGroup => new IslandAggregation {            
            theComponent = new S100_FC_FeatureBinding {
                roleType = roleType.association,
                Lower = 0,
                Upper = default,
                Role = "theComponent",
                FeatureTypes = [typeof(LandArea),typeof(IslandGroup)]
            },
            theCollection = new S100_FC_FeatureBinding {
                roleType = roleType.aggregation,
                Lower = 0,
                Upper = 1,
                Role = "theCollection",
                FeatureTypes = [typeof(IslandGroup)]
            },
        };

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