using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using S100Framework.DomainModel.S100;
using S100Framework.DomainModel.S128;
using S100Framework.DomainModel.S128.ComplexAttributes;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestS100Framework
{
    public class UnitTestS128
    {
        private readonly ITestOutputHelper output;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new() {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
        };

        public UnitTestS128(ITestOutputHelper output) {
            this.output = output;

            ArcGIS.Core.Hosting.Host.Initialize();
        }

        [Fact]
        public void Test_Mockup() {
            var connectionfile = Environment.GetEnvironmentVariable("S100-Horizon-S57-Database");

            Func<Geodatabase> createGeodatabase = () => { throw new NotImplementedException(); };

            if (IO.File.Exists(connectionfile) && ".sde".Equals(IO.Path.GetExtension(connectionfile), StringComparison.InvariantCultureIgnoreCase)) {
                createGeodatabase = () => { return new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(connectionfile)))); };
            }
            else if (IO.Directory.Exists(connectionfile) && ".gdb".Equals(IO.Path.GetExtension(connectionfile), StringComparison.InvariantCultureIgnoreCase)) {
                createGeodatabase = () => { return new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(connectionfile)))); };
            }
            else
                throw new System.ArgumentOutOfRangeException(nameof(connectionfile));

            using var geodatabase = createGeodatabase();

            var nameProductDefinitions = geodatabase.GetDefinitions<TableDefinition>().Single(e => e.GetName().EndsWith("ProductDefinitions", StringComparison.InvariantCultureIgnoreCase));

            var productCoverages = new List<NetTopologySuite.Geometries.Polygon>();

            var wktReader = new WKTReader();

            using (var tableProductDefinitions = geodatabase.OpenDataset<Table>(nameProductDefinitions.GetName())) {
                using var cursor = tableProductDefinitions.Search(new QueryFilter {
                    WhereClause = "upper(ExportType) <> 'CANCEL' AND (CSCL >= 20000 AND CSCL < 90000)",
                }, true);

                while (cursor.MoveNext()) {
                    var c = cursor.Current;

                    var compilationScale = Convert.ToInt32(c["CSCL"]);

                    using (var tableProductCoverage = geodatabase.OpenDataset<Table>("NIS.ProductCoverage")) {
                        using var coverage = tableProductCoverage.Search(new QueryFilter {
                            WhereClause = $"DSNM = '{Convert.ToString(c["DSNM"])}'", //  coverage available
                        }, true);

                        var polygons = new List<ArcGIS.Core.Geometry.Polygon>();
                        while (coverage.MoveNext()) {
                            var current = (Feature)coverage.Current;
                            var polygon = (ArcGIS.Core.Geometry.Polygon)current.GetShape();

                            polygons.Add(polygon);
                        }

                        var cover = (ArcGIS.Core.Geometry.Polygon)GeometryEngine.Instance.Union(polygons);

                        var wkt = GeometryEngine.Instance.ExportToWKT(WktExportFlags.WktExportPolygon, cover.Extent);

                        var shape = (NetTopologySuite.Geometries.Polygon)wktReader.Read(wkt);

                        productCoverages.Add(shape);
                    }
                }
            }

            var random = new Random(DateTime.Now.Microsecond);

            XmlQualifiedName xmlQualifiedName = new XmlQualifiedName("S128", "http://www.iho.int/S128/2.0");

            var electronicProducts = new List<S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct>();

            var geometries = new Dictionary<string, XElement>();

            var queue = new Queue(productCoverages.OrderBy(e => random.NextDouble()).ToList());

            var geometryId = 1;

            var now = DateTime.Now;

            for (int i = 0; i < random.Next(10, 49); i++) {

                var usageBand = random.Next(1, 5);

                var timestamp = DateTime.Now.AddDays(random.Next(0, 365) * -1);

                var datasetName = $"101DK00{usageBand}_{namesOceans.Distinct().ToArray()[i]}";

                var p = new S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct {
                    gmlId = datasetName.Substring(9), //$"ID{featureId++:0000}",
                    datasetName = datasetName,
                    compilationScale = [compilationScales[random.Next(0, compilationScales.Length - 1)]],
                    compressionFlag = false,
                    distributionStatus = S100Framework.DomainModel.S128.distributionStatus.Production,
                    editionNumber = random.Next(1, 99),
                    updateNumber = random.Next(0, 30),
                    issueDate = DateOnly.FromDateTime(timestamp),
                    typeOfProductFormat = S100Framework.DomainModel.S128.typeOfProductFormat.IsoIec8211,
                    notForNavigation = true,
                    catalogueElementClassification = [catalogueElementClassification.Enc],
                    agencyResponsibleForProduction = "The Phantom Geodata Agency",
                    timeIntervalOfProduct = new S100Framework.DomainModel.S128.ComplexAttributes.timeIntervalOfProduct {
                        issueDate = DateOnly.FromDateTime(timestamp),
                    },
                    approximateGridResolution = Enumerable.Range(0, random.Next(1, 10)).Select(e => random.NextDouble()).ToList(),
                    catalogueElementClassificationElement = [catalogueElementClassification.Enc],
                    classification = "Testing purpose only",
                    distributionStatusElement = distributionStatus.Production,
                    horizontalDatumEPSGCode = CodeList.horizontalDatumEPSGCodes.Single(e => e.code == 4326),
                    iMOMaritimeService = [iMOMaritimeService.NauticalChartService],
                    iMOMaritimeServiceElement = [iMOMaritimeService.MaritimeAssistanceService],
                    information = [new information {
                        language = "eng",
                        text = ["Just testing"],
                    }],
                    //issueDateField = 
                    issueTime = new Time(now.Hour, now.Minute),
                    onlineResource = new onlineResource {
                        linkage = "iho.int/en/s-100-universal-hydrographic-data-model",
                        protocol = "https",
                        nameOfResource = "S-100 Universal Hydrographic Data Model",
                        protocolRequest = "GET",
                    },
                    producerNation = "Denmark",
                    productSpecification = new productSpecification {
                        name = Summary.Name,
                        version = Summary.Version.ToString(),
                        editionDate = Summary.VersionDate,
                    },
                    sourceIndication = new sourceIndication {
                        categoryOfAuthority = categoryOfAuthority.HydrographicOffice,
                        countryName = "Qostrana",
                        reportedDate = DateOnly.FromDateTime(now),
                        source = "AI",
                        sourceType = sourceType.Maritime,
                    },
                    typeOfProductFormatElement = typeOfProductFormat.IsoIec8211,
                };
                p.catalogueElementIdentifier = $"urn:mrn:iho:dk00:S128:{datasetName}";

                p.featureName.Add(new S100Framework.DomainModel.S128.ComplexAttributes.featureName {
                    language = "eng",
                    nameUsage = nameUsage.DefaultNameDisplay,
                    name = p.datasetName,
                });
                p.optimumDisplayScale = p.compilationScale[0];
                p.maximumDisplayScale = (int)(p.compilationScale[0] / 2);
                p.minimumDisplayScale = (int)(p.compilationScale[0] * 2);

                p.verticalDatum = random.Next(0, 99) switch {
                    < 30 => verticalDatum.BalticSeaChartDatum2000,
                    < 60 => verticalDatum.MeanSeaLevel,
                    _ => verticalDatum.LowestAstronomicalTide,
                };

                p.specificUsage = usageBand switch {
                    '5' => specificUsage.NavigationalPurposeHarbour,
                    '4' => specificUsage.NavigationalPurposeApproach,
                    '3' => specificUsage.NavigationalPurposeCoastal,
                    '2' => specificUsage.NavigationalPurposeGeneral,
                    _ or '1' => specificUsage.NavigationalPurposeOverview,
                };

                p.navigationPurpose = usageBand switch {
                    '5' => [navigationPurpose.Port],
                    '4' => [navigationPurpose.Transit],
                    '3' => [navigationPurpose.Transit],
                    _ => [navigationPurpose.Overview],
                };

                electronicProducts.Add(p);

                var shape = (NetTopologySuite.Geometries.Polygon)queue.Dequeue()!;

                var elementGeometry = shape.ToGMLFeatureS100($"Geometry.CNP{geometryId++:00000}", xmlQualifiedName)!;

                XmlElement xmlElement = (XmlElement)new XmlDocument().ReadNode(elementGeometry.CreateReader())!;
                xmlElement.RemoveAllAttributes();

                geometries.Add(p.gmlId, elementGeometry);
            }


            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(xmlQualifiedName.Name, xmlQualifiedName.Namespace);
            ns.Add("S128", "http://www.iho.int/S128/2.0");
            ns.Add("xlink", "http://www.w3.org/1999/xlink");

            var id = $"DK00_{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}";

            var fileName = $"128{id}.gml";

            var dataset = new S100Framework.DomainModel.S128.Dataset {
                gmlId = id,
                DatasetIdentificationInformation = new DataSetIdentification {
                    productIdentifier = "S-128",
                    productEdition = "2.0",
                    applicationProfile = "1",
                    datasetFileIdentifier = id,
                    datasetTitle = $"The Phantom Geodata Agency release {now.ToLongDateString()}.",
                    datasetReferenceDate = now,
                    datasetLanguage = "eng",
                    datasetTopicCategory = [MD_TopicCategoryCode.Oceans],
                    datasetPurpose = datasetPurposeType.Base,
                    updateNumber = "1",
                },
            };

            var catalogueSectionHeader = new S100Framework.DomainModel.S128.InformationTypes.CatalogueSectionHeader {
                catalogueSectionNumber = 1,
                catalogueSectionTitle = "Demo package!",
                gmlId = "CNP0001",
            };


            var elementContainer = new elementContainer {
                href = $"#{catalogueSectionHeader.gmlId}",
                arcrole = "http://www.iho.int/S128/gml/1.2/roles/elementContainer",
            };

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


            dataset.members = new Members();

            dataset.members = new S100Framework.DomainModel.S128.Members {
                elements = [catalogueSectionHeader, .. electronicProducts]
            };

            var serializer = new XmlSerializer(typeof(S100Framework.DomainModel.S128.Dataset));

            XDocument xDataset;
            using (var ms = new MemoryStream()) {
                serializer.Serialize(ms, dataset, ns);
                ms.Position = 0;
                xDataset = XDocument.Load(ms);
            }

            foreach (var e in xDataset.Descendants(XName.Get("ElectronicProduct", "http://www.iho.int/S128/2.0"))) {
                var gmlId = e.Attribute(XName.Get("id", "http://www.opengis.net/gml/3.2"))!.Value;

                var geometry = geometries[gmlId];


                e.Element(XName.Get("timeIntervalOfProduct", "http://www.iho.int/S128/2.0"))!.AddAfterSelf(xElementContainer.Root);
                e.Add(geometry);
            }


            using (var writer = new StreamWriter(IO.Path.Combine(@"c:\temp", $"{fileName}"))) {
                xDataset.Save(writer);
            }

            System.Diagnostics.Debugger.Break();

        }

        private static int[] compilationScales = new int[] {
            2000,4000,12000,22000,45000,90000,180000,350000,700000
        };

        private static string[] namesOceans = new string[] {
            "TheDeepofGilworth",
            "RossoneeSea",
            "TheDepthsofLeiley",
            "TheGulfofGrandto",
            "TheAbyssofIroborough",
            "TillvistaDomain",
            "TheShoalingDeep",
            "TheDomainofBeaunoque",
            "TillvistaDomain",
            "PenboiaDepths",
            "RockfilAbyss",
            "RossmouthExpanse",
            "TheClimbingAbyss",
            "TheCircumfluentAbyss",
            "TheTintedWaters",
            "MiddlescroftDepths",
            "ThePerfumedWaves",
            "TheWavesofBarrcarres",
            "TheCheerlessDomain",
            "TheIsolatedAbyss",
            "KindertryExpanse",
            "LatchpoolTides",
            "CaleholmTides",
            "TheSavageDepths",
            "TheUnstableGulf",
            "TheCheerlessDomain",
            "TheTidelessOcean",
            "TheTossingDomain",
            "ThePrimevalDeep",
            "TheGulfofLockeby",
            "TheTidesofBrentson",
            "TorringbronDepths",
            "ChamlingDomain",
            "TheDeepofWindiac",
            "TheDeepofSedgelam",
            "TheGulfofMulpar",
            "TheEverReachingBay",
            "LatchpoolTides",
            "TheDeepofWareset",
            "MiddlescroftDepths",
            "TheWatersofMatagus",
            "TheMoltenOcean",
            "TheDeepofWarbalt",
            "TheRollingGulf",
            "TheDancingExpanse",
            "TheTriumphantExpanse",
            "TheSternWaves",
            "TheSavageGulf",
            "TheWavesofBainnigan",
            "TheTidelessOcean"
        };

        [XmlRoot(Namespace = "http://www.iho.int/S128/2.0")]
        public class elementContainer
        {
            [XmlAttribute("href", Namespace = "http://www.w3.org/1999/xlink")]
            public string? href { get; set; } = default;

            [XmlAttribute("arcrole", Namespace = "http://www.w3.org/1999/xlink")]
            public string? arcrole { get; set; } = default;
        }
    }
}
