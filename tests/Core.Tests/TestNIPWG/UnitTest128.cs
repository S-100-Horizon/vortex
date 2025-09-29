using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using S100Framework.DomainModel.S100;
using S100Framework.DomainModel.S128;
using S100Framework.DomainModel.S128.ComplexAttributes;
using S100Framework.DomainModel.S128.FeatureTypes;
using S100Framework.DomainModel.S128.InformationTypes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Test;
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
       
        [XmlRoot(Namespace = "http://www.iho.int/S128/2.0")]
        public class theReference
        {
            [XmlAttribute("href", Namespace = "http://www.w3.org/1999/xlink")]
            public string? href { get; set; } = default;

            private theReferenceProductMapping productMappingField;

            public theReferenceProductMapping ProductMapping {
                get {
                    return this.productMappingField;
                }
                set {
                    this.productMappingField = value;
                }
            }

            [XmlAttribute("arcrole", Namespace = "http://www.w3.org/1999/xlink")]
            public string? arcrole { get; set; } = default;
        }

        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        public partial class theReferenceProductMapping
        {
            private theReferenceProductMappingCategoryOfProductMapping categoryOfProductMappingField;

            /// <remarks/>
            public theReferenceProductMappingCategoryOfProductMapping categoryOfProductMapping {
                get {
                    return this.categoryOfProductMappingField;
                }
                set {
                    this.categoryOfProductMappingField = value;
                }
            }
        }

        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
        public partial class theReferenceProductMappingCategoryOfProductMapping
        {

            private byte codeField;

            private string valueField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte code {
                get {
                    return this.codeField;
                }
                set {
                    this.codeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value {
                get {
                    return this.valueField;
                }
                set {
                    this.valueField = value;
                }
            }
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

        [Fact]
        public void Test_Sample() {
            var uri = Environment.GetEnvironmentVariable("S100-Horizon-S57-Database");

            using var sourcedb = IO.Path.GetExtension(uri) switch {
                ".sde" or ".SDE" => new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(uri)))),
                ".gdb" or ".GDB" => new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(uri)))),
                _ => throw new System.ArgumentNullException(),
            };

            var wktReader = new WKTReader();

            XmlQualifiedName xmlQualifiedName = new XmlQualifiedName("S128", "http://www.iho.int/S128/2.0");

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(xmlQualifiedName.Name, xmlQualifiedName.Namespace);
            ns.Add("S128", "http://www.iho.int/S128/2.0");
            ns.Add("xlink", "http://www.w3.org/1999/xlink");

            var electronicProducts = new List<S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct>();

            var theReferences = new Dictionary<string, XDocument>();

            var geometries = new Dictionary<string, XElement>();

            var productMappings = new List<(S100Framework.DomainModel.S128.FeatureAssociations.ProductMapping pProductMapping, string From, string To)>();

            using (var tableProductDefinitions = sourcedb.OpenDataset<Table>("NIS.ProductDefinitions")) {
                using var cursor = tableProductDefinitions.Search(new QueryFilter {
                    WhereClause = "upper(ExportType) <> 'CANCEL' AND CSCL = 22000",
                }, true);

                var geometryId = 1;

                while (cursor.MoveNext()) {
                    var c = cursor.Current;


                    var datasetName = "101DK00" + Convert.ToString(c["DSNM"])!.Substring(2);

                    var s101 = CreateProduct(c, datasetName);
                    electronicProducts.Add(s101);

                    var s57 = CreateProduct(c, Convert.ToString(c["DSNM"])!);
                    electronicProducts.Add(s57);


                    var productMappingS57 = new S100Framework.DomainModel.S128.FeatureAssociations.ProductMapping {
                        categoryOfProductMapping = categoryOfProductMapping.LowerPriorityAlternative,                        
                    };
                    productMappings.Add(new (productMappingS57, s101.gmlId!, s57.gmlId!));

                    var productMappingS101 = new S100Framework.DomainModel.S128.FeatureAssociations.ProductMapping {
                        categoryOfProductMapping = categoryOfProductMapping.HigherPriorityAlternative,
                    };
                    productMappings.Add(new(productMappingS101, s57.gmlId!, s101.gmlId!));


                    {
                        var theReference = new theReference {
                            href = $"#{s57.gmlId}",
                            ProductMapping = new theReferenceProductMapping {                                
                                categoryOfProductMapping = new theReferenceProductMappingCategoryOfProductMapping {
                                    code = (int)categoryOfProductMapping.LowerPriorityAlternative,
                                    Value = "Lower Priority Alternative",
                                }
                            },
                            arcrole = "http://www.iho.int/S128/gml/1.2/roles/theReference",
                        };

                        var serializerContainer = new XmlSerializer(typeof(theReference));

                        using (var ms = new MemoryStream()) {
                            serializerContainer.Serialize(ms, theReference, ns);
                            ms.Position = 0;
                            theReferences.Add(s101.gmlId!, XDocument.Load(ms));
                        }
                    }

                    {
                        var theReference = new theReference {
                            href = $"#{s101.gmlId}",
                            ProductMapping = new theReferenceProductMapping {
                                categoryOfProductMapping = new theReferenceProductMappingCategoryOfProductMapping {
                                    code = (int)categoryOfProductMapping.HigherPriorityAlternative,
                                    Value = "Higher Priority Alternative",
                                }
                            },
                            arcrole = "http://www.iho.int/S128/gml/1.2/roles/theReference",
                        };

                        var serializerContainer = new XmlSerializer(typeof(theReference));

                        using (var ms = new MemoryStream()) {
                            serializerContainer.Serialize(ms, theReference, ns);
                            ms.Position = 0;
                            theReferences.Add(s57.gmlId!, XDocument.Load(ms));
                        }
                    }

                    using (var tableProductCoverage = sourcedb.OpenDataset<Table>("NIS.ProductCoverage")) {
                        using var coverage = tableProductCoverage.Search(new QueryFilter {
                            WhereClause = $"DSNM = '{Convert.ToString(c["DSNM"])}'", //  coverage available
                        }, true);

                        var polygons = new List<ArcGIS.Core.Geometry.Polygon>();
                        while (coverage.MoveNext()) {
                            var current = (Feature)coverage.Current;
                            var polygon = (ArcGIS.Core.Geometry.Polygon)current.GetShape();

                            polygons.Add(polygon);
                            continue;
                        }

                        var cover = (ArcGIS.Core.Geometry.Polygon)GeometryEngine.Instance.Union(polygons);

                        var wkt = GeometryEngine.Instance.ExportToWKT(WktExportFlags.WktExportPolygon, cover.Extent);

                        var shape = (NetTopologySuite.Geometries.Polygon)wktReader.Read(wkt);

                        {
                            var elementGeometry = shape.ToGMLFeatureS100($"SHAPE.CNP{geometryId++:00000}", xmlQualifiedName)!;

                            XmlElement xmlElement = (XmlElement)new XmlDocument().ReadNode(elementGeometry.CreateReader())!;
                            xmlElement.RemoveAllAttributes();

                            geometries.Add(s101.gmlId!, elementGeometry);
                        }

                        {
                            var elementGeometry = shape.ToGMLFeatureS100($"SHAPE.CNP{geometryId++:00000}", xmlQualifiedName)!;

                            XmlElement xmlElement = (XmlElement)new XmlDocument().ReadNode(elementGeometry.CreateReader())!;
                            xmlElement.RemoveAllAttributes();

                            geometries.Add(s57.gmlId!, elementGeometry);
                        }
                    }
                }
            }

            var catalogueSectionHeader = new S100Framework.DomainModel.S128.InformationTypes.CatalogueSectionHeader {
                catalogueSectionNumber = 1,

                catalogueSectionTitle = "Internal Danish waters",
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

            var id = $"101DK00_SAMPLE_PACKAGE";

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

                e.Element(XName.Get("timeIntervalOfProduct", "http://www.iho.int/S128/2.0"))!.AddAfterSelf(theReferences[gmlId].Root);
                e.Element(XName.Get("timeIntervalOfProduct", "http://www.iho.int/S128/2.0"))!.AddAfterSelf(xElementContainer.Root);
                e.Add(geometry);
            }

            using (var writer = new StreamWriter(IO.Path.Combine(@"c:\temp", $"{id}.gml"))) {
                xDataset.Save(writer);
            }
        }

        protected S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct CreateProduct(Row c, string datasetName) {
            var series = Convert.ToString(c["series"])!.ToString();

            var issueDate = DateOnly.FromDateTime(Convert.ToDateTime(c["ISDT"]));

            var p = new S100Framework.DomainModel.S128.FeatureTypes.ElectronicProduct {
                gmlId = datasetName.Replace("101", string.Empty),
                datasetName = datasetName,
                compilationScale = [Convert.ToInt32(c["CSCL"])],
                compressionFlag = false,
                distributionStatus = S100Framework.DomainModel.S128.distributionStatus.Production,
                editionNumber = Convert.ToInt32(c["EDTN"]),
                updateNumber = Convert.ToInt32(c["UPDN"]),
                issueDate = issueDate,
                typeOfProductFormat = S100Framework.DomainModel.S128.typeOfProductFormat.IsoIec8211,
                notForNavigation = true,
                catalogueElementClassification = [catalogueElementClassification.Enc],
                agencyResponsibleForProduction = "Danish Geodata Agency",
                timeIntervalOfProduct = new S100Framework.DomainModel.S128.ComplexAttributes.timeIntervalOfProduct {
                    issueDate = issueDate,
                    expirationDate = issueDate.AddMonths(3),
                    issuanceCycle = new issuanceCycle {
                        //periodicDateRange = new periodicDateRange {

                        //},
                        timeIntervalOfCycle = new timeIntervalOfCycle {
                            typeOfTimeIntervalUnit = [typeOfTimeIntervalUnit.Month],
                            valueOfTime = 3,
                            typeOfTimeIntervalUnitElement = [typeOfTimeIntervalUnit.Month],
                        }
                    },
                },
                catalogueElementClassificationElement = [catalogueElementClassification.Enc],

            };
            p.featureName.Add(new S100Framework.DomainModel.S128.ComplexAttributes.featureName {
                language = "eng",
                nameUsage = nameUsage.DefaultNameDisplay,
                name = p.datasetName,
            });
            p.optimumDisplayScale = Convert.ToInt32(c["CSCL"]);
            p.ApplyScamin(p.compilationScale[0]);
            var vdat = Convert.ToInt32(c["VDAT"]);

            p.verticalDatum = vdat switch {
                3 => series.StartsWith("DK") ? verticalDatum.BalticSeaChartDatum2000 : verticalDatum.MeanSeaLevel,
                23 => verticalDatum.LowestAstronomicalTide,
                _ => throw new InvalidDataException(),
            };

            var index = p.datasetName.StartsWith("101") ? 7 : 2;

            p.specificUsage = p.datasetName[index] switch {
                '5' => specificUsage.NavigationalPurposeHarbour,
                '4' => specificUsage.NavigationalPurposeApproach,
                '3' => specificUsage.NavigationalPurposeCoastal,
                '2' => specificUsage.NavigationalPurposeGeneral,
                '1' => specificUsage.NavigationalPurposeOverview,
                _ => throw new InvalidDataException(),
            };
            return p;
        }
    }
}

namespace Test
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
    public partial class theReference
    {

        private theReferenceProductMapping productMappingField;

        private string hrefField;

        private string arcroleField;

        /// <remarks/>
        public theReferenceProductMapping ProductMapping {
            get {
                return this.productMappingField;
            }
            set {
                this.productMappingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public string href {
            get {
                return this.hrefField;
            }
            set {
                this.hrefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
        public string arcrole {
            get {
                return this.arcroleField;
            }
            set {
                this.arcroleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class theReferenceProductMapping
    {

        private theReferenceProductMappingCategoryOfProductMapping categoryOfProductMappingField;

        /// <remarks/>
        public theReferenceProductMappingCategoryOfProductMapping categoryOfProductMapping {
            get {
                return this.categoryOfProductMappingField;
            }
            set {
                this.categoryOfProductMappingField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class theReferenceProductMappingCategoryOfProductMapping
    {

        private byte codeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }


}