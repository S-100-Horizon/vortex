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
            //var resolver = new System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver();
            //resolver.Modifiers.Add(typeInfo => {
            //    System.Diagnostics.Debug.WriteLine($"typeinfo: {typeInfo.Type.FullName}");
            //    //if (typeInfo.Type.IsSubclassOf(typeof(S100Framework.DomainModel.ComplexAttribute))) {
            //    //    System.Diagnostics.Debug.WriteLine($"ComplexAttribute: {typeInfo.Type.FullName}");

            //    //    typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
            //    //        TypeDiscriminatorPropertyName = "code",
            //    //        IgnoreUnrecognizedTypeDiscriminators = true,
            //    //    };
            //    //    typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorCharacteristics), typeDiscriminator: "sectorCharacteristics"));
            //    //    typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(lightSector), typeDiscriminator: "lightSector"));
            //    //}
            //    if (typeInfo.Type == typeof(S100Framework.DomainModel.Attribute)) {
            //        System.Diagnostics.Debug.WriteLine($"SimpleAttribute: {typeInfo.Type.FullName}");
            //        typeInfo.PolymorphismOptions = new System.Text.Json.Serialization.Metadata.JsonPolymorphismOptions {
            //            TypeDiscriminatorPropertyName = "code",
            //            IgnoreUnrecognizedTypeDiscriminators = true,
            //        };
            //        typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(colour), typeDiscriminator: "colour"));
            //        typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(lightCharacteristic), typeDiscriminator: "lightCharacteristic"));
            //        typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(sectorCharacteristics), typeDiscriminator: "sectorCharacteristics"));
            //        typeInfo.PolymorphismOptions.DerivedTypes.Add(new System.Text.Json.Serialization.Metadata.JsonDerivedType(typeof(lightSector), typeDiscriminator: "lightSector"));

            //    }
            //});
            //jsonSerializerOptions.TypeInfoResolver = resolver;

            var complexAttribute = new sectorCharacteristics {
            };

            //var instance = complexAttribute.subAttributes[0] as lightCharacteristic;
            //instance.value = 2;

            var json = System.Text.Json.JsonSerializer.Serialize(complexAttribute, jsonSerializerOptions);

            System.Diagnostics.Debugger.Break();
        }
    }
}