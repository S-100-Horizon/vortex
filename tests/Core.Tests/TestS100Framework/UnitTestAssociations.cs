using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureAssociations;
using S100Framework.DomainModel.S101.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit.Abstractions;

namespace TestS100Framework
{
    public class UnitTestAssociations
    {
        public readonly ITestOutputHelper _output;

        public UnitTestAssociations(ITestOutputHelper output) {
            this._output = output;

            ArcGIS.Core.Hosting.Host.Initialize();
        }


        /// <summary>
        /// https://aistudio.google.com/app/prompts?state=%7B%22ids%22:%5B%221Ih22k4hMVU-Zuruw-Hm9MK_ksr463ptX%22%5D,%22action%22:%22open%22,%22userId%22:%22109331526588514144777%22,%22resourceKeys%22:%7B%7D%7D&usp=sharing
        /// </summary>
        [Fact]
        public void Test_Serialization() {
            //var ass1 = new featureBinding<BridgeAggregation> {

            //};




            //var association1 = new featureBindingNew<BridgeAggregationTest> {
            //    roleType = roleType.aggregation.ToString(),
            //    role = Enum.GetName<Role>(Role.theComponent)!,
            //    association = new BridgeAggregationTest {
            //        name = "NoName",
            //    },
            //    featureId = "123456",
            //    featureType = nameof(SpanFixed),
            //};

            //var association2 = new featureBindingNew<StructureEquipmentTest> {
            //    roleType = roleType.association.ToString(),
            //    role = Enum.GetName<Role>(Role.theEquipment)!,
            //    association = new StructureEquipmentTest {
            //        interoperabilityIdentifier = "Hello World",
            //    },
            //    featureId = "123444",
            //    featureType = nameof(Daymark),
            //};

            //object[] array = [association1, association2];

            //var json = System.Text.Json.JsonSerializer.Serialize(array);            

            System.Diagnostics.Debugger.Break();
        }


        const string json = "[{\"roleType\":\"aggregation\",\"association\":\"BridgeAggregation\",\"role\":\"theCollection\",\"associationId\":\"988364506\",\"featureId\":\"3313401958\"}]";

        //var featureBindings = System.Text.Json.JsonSerializer.Deserialize<List<featureBindingTest>>(json);
    }
}
