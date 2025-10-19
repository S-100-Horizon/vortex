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
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;
using Xunit.Abstractions;
using static TestS100Framework.UnitTestAssociations;

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

            var resolver = S100Framework.DomainModel.S101.Summary.FeatureBindingResolver();

            var options = new JsonSerializerOptions {
                WriteIndented = true,
                TypeInfoResolver = resolver,
            };

            S100Framework.DomainModel.featureBinding[] array = [aggregation];

            var json = System.Text.Json.JsonSerializer.Serialize(array, options);

            var instance = System.Text.Json.JsonSerializer.Deserialize<featureBinding[]>(json, options);

            System.Diagnostics.Debugger.Break();

        }

        const string json = "[{\"roleType\":\"aggregation\",\"association\":\"BridgeAggregation\",\"role\":\"theCollection\",\"associationId\":\"988364506\",\"featureId\":\"3313401958\"}]";

        public static Func<string> Crc32 = () => {
            return $"{System.IO.Hashing.Crc32.HashToUInt32(Guid.NewGuid().ToByteArray())}";
        };

        public static DefaultJsonTypeInfoResolver Resolver() {
            return null;
        }



        [Fact]
        public void Test_MixingObjects() {
            var mixedVehicles = new List<Vehicle> {
                new Car<Node1> { Name = "Sedan", Year = 2020, NumberOfDoors = 4, HasSunroof = true },
                new Bicycle<Node2> { Name = "Mountain Bike", Year = 2023, NumberOfGears = 21, Type = "Mountain" },
                new Car<Node1> { Name = "Sports Car", Year = 2022, NumberOfDoors = 2, HasSunroof = false },
            };


            var resolver = new DefaultJsonTypeInfoResolver();
            resolver.Modifiers.Add(typeInfo => {
                // Apply this modification only to the 'Vehicle' base type
                if (typeInfo.Type == typeof(Vehicle)) {
                    // Ensure polymorphic serialization is enabled for the base type
                    // This tells the serializer to expect derived types.
                    typeInfo.PolymorphismOptions = new JsonPolymorphismOptions {
                        TypeDiscriminatorPropertyName = "$type", // Optional: Customize discriminator property name
                        IgnoreUnrecognizedTypeDiscriminators = true, // Good practice
                                                                     //UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement // How to handle unknown types
                        UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
                    };

                    // Manually add the derived types with their discriminators
                    typeInfo.PolymorphismOptions.DerivedTypes.Add(
                        new JsonDerivedType(typeof(Car<Node1>), typeDiscriminator: "Car::Node1"));
                    typeInfo.PolymorphismOptions.DerivedTypes.Add(
                        new JsonDerivedType(typeof(Bicycle<Node2>), typeDiscriminator: "Bicycle::Node2"));
                }
            });

            var options = new JsonSerializerOptions {
                WriteIndented = true,
                TypeInfoResolver = resolver // Assign our custom resolver
            };

            string jsonString = JsonSerializer.Serialize(mixedVehicles, options);

            var deserializedVehicles = JsonSerializer.Deserialize<List<Vehicle>>(jsonString, options);

            System.Diagnostics.Debugger.Break();
        }


        public abstract class Node
        {

        }

        public class Node1 : Node { }
        public class Node2 : Node { }


        //[JsonDerivedType(typeof(Car<Node1>), typeDiscriminator: "Car<Node1>")]
        //[JsonDerivedType(typeof(Bicycle<Node2>), typeDiscriminator: "Bicycle<Node2>")]
        public abstract class Vehicle
        {
            public string Name { get; set; }
            public int Year { get; set; }

            public override string ToString() => $"Name: {Name}, Year: {Year}";
        }

        public class Car<T> : Vehicle where T : Node
        {
            public int NumberOfDoors { get; set; }
            public bool HasSunroof { get; set; }

            public override string ToString() => $"Car - {base.ToString()}, Doors: {NumberOfDoors}, Sunroof: {HasSunroof}";
        }

        public class Bicycle<T> : Vehicle where T : Node
        {
            public int NumberOfGears { get; set; }
            public string Type { get; set; } // e.g., "Mountain", "Road"

            public override string ToString() => $"Bicycle - {base.ToString()}, Gears: {NumberOfGears}, Type: {Type}";
        }

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
