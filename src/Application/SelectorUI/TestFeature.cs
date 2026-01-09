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

        [JsonIgnore]
        public featureName featureName { get; init; } = new featureName();

        public override S100Framework.AttributeModel.Attribute[] attributeBindings => [
                featureName,
                .. base.attributeBindings,
            ];
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

        [JsonIgnore]
        public featuresDetectedNested featuresDetectedNested { get; init; } = new featuresDetectedNested();

        public override S100Framework.AttributeModel.Attribute[] attributeBindings => [
                featuresDetectedNested,
            ];
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

        [JsonIgnore]
        public featuresDetectedNested featuresDetectedNested { get; init; } = new featuresDetectedNested();

        public override S100Framework.AttributeModel.Attribute[] attributeBindings => [
                featuresDetectedNested,
                .. base.attributeBindings,
            ];
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
