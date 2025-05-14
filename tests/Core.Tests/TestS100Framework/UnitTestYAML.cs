using ArcGIS.Core.Internal.CIM;
using JsonFlatten;
using Newtonsoft.Json.Linq;
using S100Framework.Catalogues;
using S100Framework.DomainModel.S101.FeatureTypes;
using System.Collections;
using System.Text;
using System.Text.Json;
using Xunit.Abstractions;


namespace TestS100Framework
{
    public class UnitTestYAML
    {
        private readonly ITestOutputHelper output;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new() {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
        };

        public UnitTestYAML(ITestOutputHelper output) {
            this.output = output;

            //ArcGIS.Core.Hosting.Host.Initialize();
        }

        [Fact]
        public void Test_Serialize_LightAllAround() {
            var lightAllAround = new LightAllAround {
                colour = new List<S100Framework.DomainModel.S101.colour> {
                    S100Framework.DomainModel.S101.colour.Red,
                    S100Framework.DomainModel.S101.colour.White,
                },
                featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                    new S100Framework.DomainModel.S101.ComplexAttributes.featureName {
                        language = "eng",
                        name = "Light E",
                    },
                },
                height = 54,
                rhythmOfLight = new S100Framework.DomainModel.S101.ComplexAttributes.rhythmOfLight {
                    lightCharacteristic = S100Framework.DomainModel.S101.lightCharacteristic.ContinuousUltraQuickFlashing,
                    signalGroup = new List<string> {
                        "6",
                    },
                    signalPeriod = 5,
                },
                valueOfNominalRange = 9,
            };

            var yaml = S100Framework.YAML.Converter.Serialize(lightAllAround);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_Dataset() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DatasetPoint() {
            var p1101 = new S100Framework.YAML.Point(-32.1333332, 62.5) {
                Name = "P1101",
            };

            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            }.AddPoint(p1101);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DatasetCurve() {
            var p1101 = new S100Framework.YAML.Point(-32.1333332, 62.5) {
                Name = "P1101",
            };

            var c1201 = new S100Framework.YAML.Curve(p1101, new S100Framework.YAML.Coordinate[]{
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.6666666),
                        new S100Framework.YAML.Coordinate(-32.1333332,62.6666666),
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                    }) {
                Name = "C1201",
            };

            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            }.AddPoint(p1101).AddCurve(c1201);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DatasetSurface() {
            var p1101 = new S100Framework.YAML.Point(-32.1333332, 62.5) {
                Name = "P1101",
            };

            var c1201 = new S100Framework.YAML.Curve(p1101, [
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.6666666),
                        new S100Framework.YAML.Coordinate(-32.1333332,62.6666666),
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                    ]) {
                Name = "C1201",
            };

            var c12010 = new S100Framework.YAML.Curve([
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.6666666),
                    ]) {
                Name = "C12010",
            };

            var c12011 = new S100Framework.YAML.Curve([
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.6666666),
                    ]) {
                Name = "C12011",
            };

            var s1301 = new S100Framework.YAML.Surface(c1201.Vertices!) {
                Name = "S1301",
                InteriorRings = [
                    c12010.Vertices!, c12011.Vertices!
                    ],
            };

            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            }
            .AddPoint(p1101)
            .AddCurve(c1201).AddCurve(c12010).AddCurve(c12011)
            .AddSurface(s1301);


            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DataCoverage() {
            var dataCoverage = new DataCoverage {
                maximumDisplayScale = 22000,
                minimumDisplayScale = 180000,
                optimumDisplayScale = 45000,
            };

            var yaml = S100Framework.YAML.Converter.Serialize(dataCoverage);


            var lightAllAround = new LightAllAround {
                colour = new List<S100Framework.DomainModel.S101.colour> {
                    S100Framework.DomainModel.S101.colour.Red,
                    S100Framework.DomainModel.S101.colour.White,
                },
                featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                    new S100Framework.DomainModel.S101.ComplexAttributes.featureName {
                        language = "eng",
                        name = "Light E",
                    },
                },
                height = 54,
                rhythmOfLight = new S100Framework.DomainModel.S101.ComplexAttributes.rhythmOfLight {
                    lightCharacteristic = S100Framework.DomainModel.S101.lightCharacteristic.ContinuousUltraQuickFlashing,
                    signalGroup = new List<string> {
                        "6",
                    },
                    signalPeriod = 5,
                },
                valueOfNominalRange = 9,
            };

            {
                output.WriteLine("--- Direct ----------------------------------------");

                var flatten = Implementation.Execute(lightAllAround);

                foreach (var e in flatten) {
                    output.WriteLine($"{e.Key}: {e.Value}");
                }
            }

            {
                output.WriteLine("--- JSON ------------------------------------------");

                var json = System.Text.Json.JsonSerializer.Serialize(lightAllAround, jsonSerializerOptions);
                var jsonObject = JObject.Parse(json);

                var flatten = jsonObject.Flatten(includeNullAndEmptyValues: false);

                foreach (var e in flatten) {
                    output.WriteLine($"{e.Key}: {e.Value}");
                }

                output.WriteLine("");

                output.WriteLine("Attributes:");
                foreach (var e in flatten) {
                    output.WriteLine($"\t- Name: {e.Key}");
                    output.WriteLine($"\t  Value: {e.Value}");
                }
            }
        }

        [Fact]
        public void Test_DatasetFeature() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var feature = new S100Framework.YAML.Feature() {
                Name = "QualityOfBathymetricData",
                Foid = "1810:3:2",
                Prim = S100Framework.YAML.Primitive.Surface,
                Attributes = new LightAllAround {
                    colour = new List<S100Framework.DomainModel.S101.colour> {
                        S100Framework.DomainModel.S101.colour.Red,
                        S100Framework.DomainModel.S101.colour.White,
                    },
                    exhibitionConditionOfLight = S100Framework.DomainModel.S101.exhibitionConditionOfLight.LightShownWithoutChangeOfCharacter,
                    featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                        new S100Framework.DomainModel.S101.ComplexAttributes.featureName {
                            language = "eng",
                            name = "Light E",
                        },
                    },
                    height = 54,
                    rhythmOfLight = new S100Framework.DomainModel.S101.ComplexAttributes.rhythmOfLight {
                        lightCharacteristic = S100Framework.DomainModel.S101.lightCharacteristic.ContinuousUltraQuickFlashing,
                        signalGroup = new List<string> {
                        "6",
                    },
                        signalPeriod = 5,
                    },
                    valueOfNominalRange = 9,
                }
            };

            dataset.AddFeature(feature);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }


        [Fact]
        public void Test_FeatureDecimal() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var feature = new S100Framework.YAML.Feature() {
                Name = "QualityOfBathymetricData",
                Foid = "1810:3:2",
                Prim = S100Framework.YAML.Primitive.Surface,
                Attributes = new SpecialPurposeGeneralBeacon {
                    verticalLength = 4.5m
                }
            };

            dataset.AddFeature(feature);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DatasetInformationType() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var informationType = new S100Framework.YAML.Information() {
                Name = "SpatialQuality",
                ID = "I83413",
                Attributes = new S100Framework.DomainModel.S101.InformationTypes.SpatialQuality {
                    qualityOfHorizontalMeasurement = S100Framework.DomainModel.S101.qualityOfHorizontalMeasurement.Approximate,
                },
            };

            dataset.AddInformation(informationType);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }


        [Fact]
        public void Test_SerializeBridge() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var json = @"{""bridgeConstruction"":null,""bridgeFunction"":[],""categoryOfOpeningBridge"":null,""colour"":[],""colourPattern"":null,""condition"":null,""featureName"":[{""language"":""eng"",""name"":""Dronning Alexandrines Bro"",""nameUsage"":1}],""fixedDateRange"":null,""height"":null,""interoperabilityIdentifier"":null,""natureOfConstruction"":[],""openingBridge"":false,""radarConspicuous"":null,""reportedDate"":null,""status"":[],""visualProminence"":null,""scaleMinimum"":null,""information"":[],""pictorialRepresentation"":null}";

            var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));
            var name = "Bridge";
            var geometry = "S874953";
            var foid = "110:874953:1";

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{name}", true) ?? default;
            

            var instance = System.Text.Json.JsonSerializer.Deserialize(json!, type!);

            var feature = new S100Framework.YAML.Feature {
                Name = name,
                Foid = foid,
                Prim = S100Framework.YAML.Primitive.Surface,
                Geometry = geometry,
                Attributes = (S100Framework.DomainModel.FeatureNode)instance!,
            };

            dataset.AddFeature(feature);


            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_FeatureWIthStaticProperties() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var feature = new S100Framework.YAML.Feature() {
                Name = "Coastline",
                Foid = "1810:3:2",
                Prim = S100Framework.YAML.Primitive.Surface,
                Attributes = new Coastline {
                    colour = new List<S100Framework.DomainModel.S101.colour> {
                        S100Framework.DomainModel.S101.colour.Red,
                        S100Framework.DomainModel.S101.colour.White,
                    },
                    featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                        new S100Framework.DomainModel.S101.ComplexAttributes.featureName {
                            language = "eng",
                            name = "Light E",
                        },
                    },
                }
            };

            dataset.AddFeature(feature);


            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }



        [Fact]
        public void Test_DatasetFeatureAssociation() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var informationType = new S100Framework.YAML.Information() {
                Name = "SpatialQuality",
                ID = "I83413",
                Attributes = new S100Framework.DomainModel.S101.InformationTypes.SpatialQuality {
                    qualityOfHorizontalMeasurement = S100Framework.DomainModel.S101.qualityOfHorizontalMeasurement.Approximate,
                },
            };

            var feature = new S100Framework.YAML.Feature() {
                Name = "QualityOfBathymetricData",
                Foid = "1810:3:2",
                Prim = S100Framework.YAML.Primitive.Surface,
                Attributes = new LightAllAround {
                    colour = new List<S100Framework.DomainModel.S101.colour> {
                    S100Framework.DomainModel.S101.colour.Red,
                    S100Framework.DomainModel.S101.colour.White,
                },
                    featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                    new S100Framework.DomainModel.S101.ComplexAttributes.featureName {
                        language = "eng",
                        name = "Light E",
                    },
                },
                    height = 54,
                    rhythmOfLight = new S100Framework.DomainModel.S101.ComplexAttributes.rhythmOfLight {
                        lightCharacteristic = S100Framework.DomainModel.S101.lightCharacteristic.ContinuousUltraQuickFlashing,
                        signalGroup = new List<string> {
                        "6",
                    },
                        signalPeriod = 5,
                    },
                    valueOfNominalRange = 9,
                }
            };

            var association = new S100Framework.YAML.Association {
                To = "I83413",
                Name = "QualityOfBathymetricDataComposition",
                Role = "theQualityInformation"
            };

            var featureAssociation = new S100Framework.YAML.Association {
                To = "1810:3:2",
                Name = "StructureEquipment",
                Role = "theEquipment"
            };

            feature.AddAssociation(association);
            feature.AddFeatureAssociation(featureAssociation);
            dataset.AddInformation(informationType);
            dataset.AddFeature(feature);


            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }
    }
}

namespace TestS100Framework
{
    public static class Extension
    {
        public static string Attributes(this LightAllAround instance) {
            var b = new StringBuilder();


            return string.Empty;
        }

        internal static bool IsValueTypeOrString(this Type type) {
            return type.IsValueType || type == typeof(string);
        }

        internal static string ToStringValueType(this object value) {
            return value switch {
                DateTime dateTime => dateTime.ToString("o"),
                bool boolean => boolean.ToStringLowerCase(),
                _ => value.ToString()
            };
        }

        internal static bool IsIEnumerable(this Type type) {
            return type.IsAssignableTo(typeof(IEnumerable));
        }

        internal static string ToStringLowerCase(this bool boolean) {
            return boolean ? "true" : "false";
        }
    }
}

namespace TestS100Framework
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public interface IFlatDictionaryProvider
    {
        //Dictionary<string, string> Execute(object @object, string prefix = "");
    }

    public class Implementation : IFlatDictionaryProvider
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<PropertyInfo, Func<object, object>>> CachedProperties;

        static Implementation() {
            CachedProperties = new ConcurrentDictionary<Type, Dictionary<PropertyInfo, Func<object, object>>>();
        }

        public static Dictionary<string, string> Execute(object @object, string prefix = "") {
            return ExecuteInternal(@object, prefix: prefix);
        }

        private static Dictionary<string, string> ExecuteInternal(
            object @object,
            Dictionary<string, string> dictionary = default,
            string prefix = "") {
            dictionary ??= new Dictionary<string, string>();
            var type = @object.GetType();
            var properties = GetProperties(type);

            foreach (var (property, getter) in properties) {
                var key = string.IsNullOrWhiteSpace(prefix) ? property.Name : $"{prefix}.{property.Name}";
                var value = getter(@object);

                if (value == null) {
                    dictionary.Add(key, null);
                    continue;
                }

                if (property.PropertyType.IsValueTypeOrString()) {
                    dictionary.Add(key, value.ToStringValueType());
                }
                else {
                    if (value is IEnumerable enumerable) {
                        var counter = 0;
                        foreach (var item in enumerable) {
                            var itemKey = $"{key}[{counter++}]";
                            var itemType = item.GetType();
                            if (itemType.IsValueTypeOrString()) {
                                dictionary.Add(itemKey, item.ToStringValueType());
                            }
                            else {
                                ExecuteInternal(item, dictionary, itemKey);
                            }
                        }
                    }
                    else {
                        ExecuteInternal(value, dictionary, key);
                    }
                }
            }

            return dictionary;
        }

        private static Dictionary<PropertyInfo, Func<object, object>> GetProperties(Type type) {
            if (CachedProperties.TryGetValue(type, out var properties)) {
                return properties;
            }

            CacheProperties(type);
            return CachedProperties[type];
        }

        private static void CacheProperties(Type type) {
            if (CachedProperties.ContainsKey(type)) {
                return;
            }

            CachedProperties[type] = new Dictionary<PropertyInfo, Func<object, object>>();
            var properties = type.GetProperties().Where(x => x.CanRead);
            foreach (var propertyInfo in properties) {
                var getter = CompilePropertyGetter(propertyInfo);
                CachedProperties[type].Add(propertyInfo, getter);
                if (!propertyInfo.PropertyType.IsValueTypeOrString()) {
                    if (propertyInfo.PropertyType.IsIEnumerable()) {
                        var types = propertyInfo.PropertyType.GetGenericArguments();
                        foreach (var genericType in types) {
                            if (!genericType.IsValueTypeOrString()) {
                                CacheProperties(genericType);
                            }
                        }
                    }
                    else {
                        CacheProperties(propertyInfo.PropertyType);
                    }
                }
            }
        }

        // Inspired by Zanid Haytam
        // https://blog.zhaytam.com/2020/11/17/expression-trees-property-getter/
        private static Func<object, object> CompilePropertyGetter(PropertyInfo property) {
            var objectType = typeof(object);
            var objectParameter = Expression.Parameter(objectType);
            var castExpression = Expression.TypeAs(objectParameter, property.DeclaringType);
            var convertExpression = Expression.Convert(
                Expression.Property(castExpression, property),
                objectType);
            return Expression.Lambda<Func<object, object>>(
                convertExpression,
                objectParameter).Compile();
        }
    }
}


/*
 * Samples

Attributes:
      - Name: colour
        Value: 3
      - Name: colour
        Value: 1
      - Name: rhythmOfLight
        id: 2
      - Name: lightCharacteristic
        parent: 2
        Value: 4
      - Name: signalGroup
        parent: 2
        Value: (2)
      - Name: signalPeriod
        parent: 2
        Value: 4
    Geometry: P110125
 



*/