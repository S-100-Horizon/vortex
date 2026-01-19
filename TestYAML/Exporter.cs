using S100FC.S101.FeatureTypes;
using S100FC.YAML;
using S100FC.S101.ComplexAttributes;

namespace TestYAML
{
    public class Exporter
    {
        [Fact]
        public void Test_SerializeFeature() {
            var dataset = new Dataset() {
                CellName = "101DK0040349E.000",
                Comment = "Not for navigation!",
                verticalDatum = "Baltic Sea Chart Datum 2000,44",
                ENCVer = "INT.IHO.S-101.2.0",
                Edition = 1,
                FCVer = "2.0",
            };

            var lightFogDetector = new LightFogDetector {
                fixedDateRange = new fixedDateRange {
                    dateStart = "1944",
                },
                rhythmOfLight = new rhythmOfLight {
                    lightCharacteristic = 5555,
                    signalSequence = [
                        new signalSequence {
                            signalDuration = 1111,

                        },
                        new signalSequence {
                            signalDuration = 9999,
                        },]
                },
            };


            var feature = new S100FC.YAML.Feature {
                Name = "LightFogDetector",
                Foid = "110:85:1",
                Prim = Primitive.Point,
                Geometry = "P5343543",
                Attributes = lightFogDetector
            };

            dataset.AddFeature(feature);

            var serialized = S100FC.YAML.Converter.Serialize(feature);

            System.Diagnostics.Debugger.Break();
        }
    }
}