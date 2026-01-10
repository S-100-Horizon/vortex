using S100Framework.AttributeModel;
using S100Framework.AttributeModel.S101;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.FeatureTypes;
using S100Framework.AttributeModel.S101.SimpleAttributes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PropertyGridApplication
{
	public class featuresDetectedNested : featuresDetected {
        [JsonIgnore]
        public override string S100FC_code => nameof(featuresDetectedNested);
        [JsonIgnore]
        public override string S100FC_name => "Features Detected Nested";

        public override attributeBinding[] attributeBindingsCatalogue => [
                .. base.attributeBindingsCatalogue,
                new attributeBinding {
                    attribute = nameof(featureName),
                    lower = 1,
                    upper = 1,
                },
            ];
    }

    public class TestFeatureSimple : S100Framework.AttributeModel.FeatureType
    {
        [JsonIgnore]
        public override string S100FC_code => nameof(TestFeatureSimple);
        [JsonIgnore]
        public override string S100FC_name => "TestFeatureSimple";

        public override attributeBinding[] attributeBindingsCatalogue => [
                 new attributeBinding {
                    attribute = nameof(featuresDetectedNested),
                    lower = 1,
                    upper = 1,
                },
            ];
    }

    public class TestFeature : QualityOfBathymetricData
    {
        [JsonIgnore]
        public override string S100FC_code => nameof(TestFeature);
        [JsonIgnore]
        public override string S100FC_name => "TestFeature : QualityOfBathymetricData";

        public override attributeBinding[] attributeBindingsCatalogue => [
                .. base.attributeBindingsCatalogue,
                new attributeBinding {
                    attribute = nameof(featuresDetectedNested),
                    lower = 1,
                    upper = 1,
                },                
            ];
    }
}
