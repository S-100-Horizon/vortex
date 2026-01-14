using S100FC;
using S100FC.S101;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.FeatureTypes;
using S100FC.S101.SimpleAttributes;
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

        public override attributeBindingDefinition[] attributeBindingsCatalogue => [
                .. base.attributeBindingsCatalogue,
                new attributeBindingDefinition {
                    attribute = nameof(featureName),
                    lower = 1,
                    upper = 1,
                },
            ];

        [JsonIgnore]
        public featureName?[] featureName {
            set { base.SetAttribute(value); }
            get { return base.GetAttributeValues<featureName>(nameof(featureName)); }
        }
    }

    public class TestFeatureSimple : S100FC.FeatureType
    {
        [JsonIgnore]
        public override string S100FC_code => nameof(TestFeatureSimple);
        [JsonIgnore]
        public override string S100FC_name => "TestFeatureSimple";

        public override attributeBindingDefinition[] attributeBindingsCatalogue => [
                 new attributeBindingDefinition {
                    attribute = nameof(beaconShape),
                    lower = 1,
                    upper = 1,
                    CreateInstance = () => new beaconShape(),
                },
                new attributeBindingDefinition {
                    attribute = nameof(callSign),
                    lower = 1,
                    upper = 1,
                    CreateInstance = () => new callSign(),
                },
            ];

        [JsonIgnore]
        public beaconShape? beaconShape {
            set { base.SetAttribute(value); }
            get { return base.GetAttributeValue<beaconShape>(nameof(beaconShape)); }
        }

        [JsonIgnore]
        public callSign? callSign {
            set { base.SetAttribute(value); }
            get { return base.GetAttributeValue<callSign>(nameof(callSign)); }
        }

        public override Primitives[] permittedPrimitives => [Primitives.noGeometry];
    }

    public class TestFeature : QualityOfBathymetricData
    {
        [JsonIgnore]
        public override string S100FC_code => nameof(TestFeature);
        [JsonIgnore]
        public override string S100FC_name => "TestFeature : QualityOfBathymetricData";

        public override attributeBindingDefinition[] attributeBindingsCatalogue => [
                .. base.attributeBindingsCatalogue,
                new attributeBindingDefinition {
                    attribute = nameof(featuresDetectedNested),
                    lower = 1,
                    upper = 1,
                },                
            ];

        [JsonIgnore]
        public featuresDetectedNested? featuresDetectedNested {
            set { base.SetAttribute(value); }
            get { return base.GetAttributeValue<featuresDetectedNested>(nameof(featuresDetectedNested)); }
        }
    }
}
