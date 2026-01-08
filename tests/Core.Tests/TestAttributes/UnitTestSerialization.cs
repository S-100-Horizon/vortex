using S100Framework.AttributeModel;

using System.Reflection;
using System.Text.Json;
using Xunit.Abstractions;

namespace TestAttributes.S101
{
    using S100Framework.AttributeModel.S101;
    using S100Framework.AttributeModel.S101.ComplexAttributes;
    using S100Framework.AttributeModel.S101.FeatureAssociation;
    using S100Framework.AttributeModel.S101.FeatureTypes;
    using S100Framework.AttributeModel.S101.SimpleAttributes;

    public class UnitTestAttributes
    {
        private readonly ITestOutputHelper _output;

        private readonly string _iho;
        private readonly string _iala;

        private JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        }.AppendTypeInfoResolver();

        public UnitTestAttributes(ITestOutputHelper output) {
            this._output = output;

            this._iho = Environment.GetEnvironmentVariable("GITHUB-IHO")!;
            this._iala = Environment.GetEnvironmentVariable("GITHUB-IALA")!;
        }

        [Fact]
        public void S101_Serialization() {
            var relatedFeature = new SpanFixed {
                verticalClearanceFixed = new verticalClearanceFixed { verticalClearanceValue = new verticalClearanceValue { value = 0 } },
            };
            var feature = new Bridge {
            };

            feature.featureName_optional = [new featureName {
                language = "eng",
                name = "No where!",
                nameUsage_optional = 1,
            }];

            feature.featureBindings = [new featureBinding<BridgeAggregation>{
                featureId = "1234",
                featureType = relatedFeature.S100FC_code,
                role = "theComponent",
                roleType = "association",
            }];

            //var instance = complexAttribute.subAttributes[0] as lightCharacteristic;
            //instance.value = 2;

            var json = System.Text.Json.JsonSerializer.Serialize(feature, jsonSerializerOptions);

            var reloaded = System.Text.Json.JsonSerializer.Deserialize<Bridge>(json, jsonSerializerOptions);

            System.Diagnostics.Debugger.Break();
        }        

        [Fact]
        public void Test_AttributeAssignment() {
            var drval1 = 10d;
            var drval2 = default(double?);

            var instance = new DepthArea {
                depthRangeMinimumValue = drval1,
                depthRangeMaximumValue = drval2.GetValueOrDefault(),
                interoperabilityIdentifier_optional = "ID:1234",
            };
            //instance.interoperabilityIdentifier(new interoperabilityIdentifier {
            //    value = "ID:1234"
            //});
        }
    }

    public static class Extension
    {
        public static DepthArea interoperabilityIdentifier(this DepthArea instance, interoperabilityIdentifier value) {
            return instance;
        }
    }
}

namespace TestAttributes.S128
{
    using S100Framework.AttributeModel.S128;
    using S100Framework.AttributeModel.S128.ComplexAttributes;
    using S100Framework.AttributeModel.S128.FeatureAssociation;
    using S100Framework.AttributeModel.S128.FeatureTypes;
    using S100Framework.AttributeModel.S128.SimpleAttributes;

    public class UnitTestAttributes
    {
        private readonly ITestOutputHelper _output;

        private readonly string _iho;
        private readonly string _iala;

        private JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        }.AppendTypeInfoResolver();

        public UnitTestAttributes(ITestOutputHelper output) {
            this._output = output;

            this._iho = Environment.GetEnvironmentVariable("GITHUB-IHO")!;
            this._iala = Environment.GetEnvironmentVariable("GITHUB-IALA")!;
        }

        [Fact]
        public void S128_Serialization() {
            var relatedFeature = new ElectronicProduct {
            };
            var feature = new ElectronicProduct {                
            };

            var featureBinding = new featureBinding<ProductMapping>{
                featureId = "1234",
                featureType = relatedFeature.S100FC_code,
                role = "theReference",
                roleType = "association",                
            };
            featureBinding.association.categoryOfProductMapping = 2;    //Lower Priority Alternative

            feature.featureBindings = [featureBinding];

            var json = System.Text.Json.JsonSerializer.Serialize(feature, jsonSerializerOptions);

            var reloaded = System.Text.Json.JsonSerializer.Deserialize<ElectronicProduct>(json, jsonSerializerOptions);

            System.Diagnostics.Debugger.Break();
        }
    }
}