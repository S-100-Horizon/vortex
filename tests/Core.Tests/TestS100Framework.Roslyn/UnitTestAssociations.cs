using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureAssociations;
using S100Framework.DomainModel.S101.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
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
            var association1 = new featureBinding<BridgeAggregation> {
                association = new BridgeAggregation {
                    //  no attributes
                },
                roleType = roleType.aggregation.ToString(),
                role = Enum.GetName<Role>(Role.theComponent)!,
                featureType = nameof(SpanFixed),
                featureId = $"{Guid.NewGuid():N}",
            };

            var association2 = new featureBinding<StructureEquipment> {
                association = new StructureEquipment {
                    //  no attributes
                },
                roleType = roleType.association.ToString(),
                role = Enum.GetName<Role>(Role.theEquipment)!,
                featureType = nameof(Daymark),
                featureId = $"{Guid.NewGuid():N}",
            };

            object[] array = [association1, association2];

            var json = System.Text.Json.JsonSerializer.Serialize(array);

            using var document = JsonDocument.Parse(json);

            foreach (var element in document.RootElement.EnumerateArray()) {
                _ = element.TryGetProperty("code", out var code);

                var instance = System.Text.Json.JsonSerializer.Deserialize(element!, typeof(featureBinding<BridgeAggregation>));
            }

            System.Diagnostics.Debugger.Break();
        }


        const string json = "[{\"roleType\":\"aggregation\",\"association\":\"BridgeAggregation\",\"role\":\"theCollection\",\"associationId\":\"988364506\",\"featureId\":\"3313401958\"}]";

        //var featureBindings = System.Text.Json.JsonSerializer.Deserialize<List<featureBindingTest>>(json);
    }
}



/*
            var lightAllAround = new LightAllAround {
                height = 54,
                valueOfNominalRange = 9,
            };
            var qualityOfBathymetricData = new QualityOfBathymetricData {
                interoperabilityIdentifier = "Yes"
            };

            object[] arr = [lightAllAround, qualityOfBathymetricData];
            var json = System.Text.Json.JsonSerializer.Serialize(arr);




            using var doc = JsonDocument.Parse(json);

            if (doc.RootElement.ValueKind != JsonValueKind.Array) throw new InvalidCastException();

            foreach (var element in doc.RootElement.EnumerateArray()) {
                _ = element.TryGetProperty("Code", out var code);

                var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));

                var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{code}", true)!;

                var instance = System.Text.Json.JsonSerializer.Deserialize(element!, type);

                System.Diagnostics.Debugger.Break();
            }

 */
