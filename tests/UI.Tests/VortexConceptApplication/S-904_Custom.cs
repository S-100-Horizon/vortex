using S100Framework.Catalogues;
using S100Framework.DomainModel;
using S100Framework.DomainModel.Bindings;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.WPF.ViewModel.S101;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace S100Framework.WPF.ViewModel.S903
{
    public abstract class S100_FC_FeatureAssociation {
        public abstract string Code { get; }
        public abstract string[] Roles { get; }
    }

    public class S100_FC_FeatureBinding
    {
        public int Lower { get; set; }
        public int? Upper { get; set; } = default;

        public string Role { get; set; }

        public Type FeatureType { get; set; }
    }


    public class IslandAggregation : S100_FC_FeatureAssociation
    {
        public override string Code => "IslandAggregation";

        public override string[] Roles => ["theCollection", "theComponent"];

        public object[] theComponents { get; set; }

        public object? theCollection { get; set; }

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