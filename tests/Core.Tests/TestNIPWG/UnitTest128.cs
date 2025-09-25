using ArcGIS.Core.Data;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using S100Framework.DomainModel.S100;
using S100Framework.DomainModel.S128;
using S100Framework.DomainModel.S128.FeatureTypes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestNIPWG
{
    public class UnitTest128
    {
        [XmlRoot(Namespace = "http://www.iho.int/S128/2.0")]
        public class elementContainer
        {
            [XmlAttribute("href", Namespace = "http://www.w3.org/1999/xlink")]
            public string? href { get; set; } = default;

            [XmlAttribute("arcrole", Namespace = "http://www.w3.org/1999/xlink")]
            public string? arcrole { get; set; } = default;
        }

        private readonly ITestOutputHelper _output;

        public UnitTest128(ITestOutputHelper output) {
            this._output = output;

            ArcGIS.Core.Hosting.Host.Initialize();
        }

        [Fact]
        public void Test_S101PT74() {
            var wkt = "POLYGON ((10.000000000000057 57.000000000000057, 11.000000000000057 57.000000000000057, 11.000000000000057 58.000000000000057, 10.000000000000057 58.000000000000057, 10.000000000000057 57.000000000000057))";

            //  Dataset titles – Paper 7.4

            var datasetName = "101DK0031341D";

            var catalogueSectionHeader = new S100Framework.DomainModel.S128.InformationTypes.CatalogueSectionHeader {
                catalogueSectionNumber = 1,
                
                catalogueSectionTitle = "Skagerrak-Kattegat",
                gmlId = "CNP0001",
            };

            var issueDate = new DateOnly(2025, 4, 9);

            var product = new S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct {
                gmlId = datasetName.Substring(3), //$"ID{featureId++:0000}",
                datasetName = datasetName,
                compilationScale = [90000],
                compressionFlag = false,
                distributionStatus = S100Framework.DomainModel.S128.distributionStatus.Production,
                editionNumber = 2,
                updateNumber = 3,
                issueDate = issueDate,
                typeOfProductFormat = S100Framework.DomainModel.S128.typeOfProductFormat.IsoIec8211,
                notForNavigation = true,
                catalogueElementClassification = [catalogueElementClassification.Enc],
                agencyResponsibleForProduction = "Danish Geodata Agency",
                timeIntervalOfProduct = new S100Framework.DomainModel.S128.ComplexAttributes.timeIntervalOfProduct {
                    issueDate = issueDate,
                },
                catalogueElementClassificationElement = [catalogueElementClassification.Enc],
                specificUsage = specificUsage.NavigationalPurposeCoastal,
            };


            var elementContainer = new elementContainer {
                href = $"#{catalogueSectionHeader.gmlId}",
                arcrole = "http://www.iho.int/S128/gml/1.2/roles/elementContainer",
            };

            XmlQualifiedName xmlQualifiedName = new XmlQualifiedName("S128", "http://www.iho.int/S128/2.0");

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(xmlQualifiedName.Name, xmlQualifiedName.Namespace);
            ns.Add("S128", "http://www.iho.int/S128/2.0");
            ns.Add("xlink", "http://www.w3.org/1999/xlink");

            XDocument xElementContainer;
            {
                var serializerContainer = new XmlSerializer(typeof(elementContainer));

                using (var ms = new MemoryStream()) {
                    serializerContainer.Serialize(ms, elementContainer, ns);
                    ms.Position = 0;
                    xElementContainer = XDocument.Load(ms);
                }
            }

            ns.Add("gml", "http://www.opengis.net/gml/3.2");
            ns.Add("S100", "http://www.iho.int/s100gml/5.0");
            ns.Add("S100_profile", "http://www.iho.int/S-100/profile/s100_gmlProfile");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            var id = $"{datasetName}";

            var dataset = new S100Framework.DomainModel.S128.Dataset {
                gmlId = "Package.DK000-0001",
                DatasetIdentificationInformation = new DataSetIdentification {
                    productIdentifier = "S-128",
                    productEdition = "2.0",
                    applicationProfile = "1",
                    datasetFileIdentifier = id,
                    datasetTitle = $"Danish Geodata Agency Test Package",
                    datasetReferenceDate = DateTime.Now,
                    datasetLanguage = "eng",
                    datasetTopicCategory = [MD_TopicCategoryCode.Oceans],
                    datasetPurpose = datasetPurposeType.Base,
                    updateNumber = "1",
                },
            };

            dataset.members = new Members();

            dataset.members = new S100Framework.DomainModel.S128.Members {
                elements = [catalogueSectionHeader, product]
            };

            var serializer = new XmlSerializer(typeof(S100Framework.DomainModel.S128.Dataset));

            XDocument xDataset;
            using (var ms = new MemoryStream()) {
                serializer.Serialize(ms, dataset, ns);
                ms.Position = 0;
                xDataset = XDocument.Load(ms);
            }

            var wktReader = new WKTReader();

            var geometryId = 1;

            foreach (var e in xDataset.Descendants(XName.Get("ElectronicProduct", "http://www.iho.int/S128/2.0"))) {
                var gmlId = e.Attribute(XName.Get("id", "http://www.opengis.net/gml/3.2"))!.Value;

                var shape = (NetTopologySuite.Geometries.Polygon)wktReader.Read(wkt);

                var elementGeometry = shape.ToGMLFeatureS100($"Geometry.CNP{geometryId++:00000}", xmlQualifiedName, "https://www.opengis.net/def/crs/EPSG/0/4326")!;

                e.Element(XName.Get("timeIntervalOfProduct", "http://www.iho.int/S128/2.0"))!.AddAfterSelf(xElementContainer.Root);
                e.Add(elementGeometry);
            }

            var fileName = IO.Path.GetTempFileName();

            using (var writer = new StreamWriter(IO.Path.Combine(@"c:\temp", $"{fileName}"))) {
                xDataset.Save(writer);
            }

            _output.WriteLine(IO.Path.GetFullPath(fileName));
        }
    }
}