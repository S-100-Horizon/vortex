using ArcGIS.Core.Data.UtilityNetwork;
using S100Framework.DomainModel;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.FeatureAssociations;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.WPF.ViewModel.S101;
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
                referenceId = $"{Guid.NewGuid():N}",
            };

            var association2 = new featureBinding<StructureEquipment> {
                association = new StructureEquipment {
                    //  no attributes
                },
                roleType = roleType.association.ToString(),
                role = Enum.GetName<Role>(Role.theEquipment)!,
                featureType = nameof(Daymark),
                referenceId = $"{Guid.NewGuid():N}",
            };

            object[] array = [association1, association2];

            var json = System.Text.Json.JsonSerializer.Serialize(array);

            using var document = JsonDocument.Parse(json);

            foreach (var element in document.RootElement.EnumerateArray()) {
                var code = element.GetProperty("code").GetString()!;

                var instance = System.Text.Json.JsonSerializer.Deserialize(element!, Summary.FeatureBindings(code));
            }

            var bridge = new BridgeViewModel {
            }.Load(new Bridge {
            }).ParseFeatureBindings(json);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_BridgeAggregation() {
            var aggregation = new featureBinding<BridgeAggregation> {
                featureType = nameof(SpanOpening),
                role = "theCollection",
                roleType = "aggregation",
                referenceId = "123456",
            };

            object[] array = [aggregation];

            var json = System.Text.Json.JsonSerializer.Serialize(array);

            var instance1 = System.Text.Json.JsonSerializer.Deserialize<featureBinding<BridgeAggregation>[]>(json);

            var instance2 = System.Text.Json.JsonSerializer.Deserialize<featureBinding[]>(json);

            System.Diagnostics.Debugger.Break();

        }

        const string json = "[{\"roleType\":\"aggregation\",\"association\":\"BridgeAggregation\",\"role\":\"theCollection\",\"associationId\":\"988364506\",\"featureId\":\"3313401958\"}]";

        //var featureBindings = System.Text.Json.JsonSerializer.Deserialize<List<featureBindingTest>>(json);
    }
}

//namespace S100Framework.WPF.ViewModel.S101
//{
//    public static class FeatureBindingExtension {
//        public static BridgeViewModel LoadFeatureBinding(this BridgeViewModel instance, JsonDocument document) {
//            foreach (var element in document.RootElement.EnumerateArray()) {
//                var code = element.GetProperty("code").GetString()!;

//                var featureBinding = System.Text.Json.JsonSerializer.Deserialize(element!, Summary.FeatureBindings(code));

//                if (featureBinding is featureBinding<BridgeAggregation> bridgeAggregation) {
//                    instance.BridgeAggregation.Add(new BridgeViewModel.BridgeAggregationViewModel {
//                        featureId = bridgeAggregation.referenceId,
//                        role = bridgeAggregation.role,
//                    });
//                }
//                if (featureBinding is featureBinding<StructureEquipment> structureEquipment) {
//                    instance.StructureEquipment.Add(new BridgeViewModel.StructureEquipmentViewModel {
//                        featureId = structureEquipment.referenceId,
//                        role = structureEquipment.role,
//                    });
//                }
//            }

//            return instance;
//        }
//    }
//}



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
