using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.SimpleAttributes;
using System.Reflection;
using System.Text.Json;
using Xunit.Abstractions;

namespace TestAttributes
{
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
        public void Test_Serialization() {            
            var complexAttribute = new sectorCharacteristics {
            };

            //var instance = complexAttribute.subAttributes[0] as lightCharacteristic;
            //instance.value = 2;

            var json = System.Text.Json.JsonSerializer.Serialize(complexAttribute, jsonSerializerOptions);

            System.Diagnostics.Debugger.Break();
        }
    }
}