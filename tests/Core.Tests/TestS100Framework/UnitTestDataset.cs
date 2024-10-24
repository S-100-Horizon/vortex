using S100Framework.Model.S128.ComplexAttributes;
using S100Framework.Model.S128.FeatureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using IO = System.IO;

namespace TestS100Framework
{
    public class UnitTestDataset
    {
        [Fact]
        public void Test_XmlValidation() {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add("http://www.iho.int/S128/2.0", @".\Artifacts\S128.xsd");
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += SettingsValidationEventHandler;

            XmlReader xmlReader = XmlReader.Create(@".\Artifacts\S-128_FC_Ed2.0.0.xml", settings);

            while (xmlReader.Read()) { }
        }

        static void SettingsValidationEventHandler(object sender, ValidationEventArgs e) {
            if (e.Severity == XmlSeverityType.Warning) {
            }
            else if (e.Severity == XmlSeverityType.Error) {
            }
        }

        [Fact]
        public void Test_ElectronicProduct() {
            var productSpecification = XDocument.Load(@".\Artifacts\S-128_FC_Ed2.0.0.xml");

            var product = new ElectronicProduct {
                catalogueElementClassification = new List<S100Framework.Model.S128.catalogueElementClassification> { S100Framework.Model.S128.catalogueElementClassification.Enc },
                productSpecification = new S100Framework.Model.S128.ComplexAttributes.productSpecification {
                    date = DateTime.Now,
                },
                timeIntervalOfProduct = new S100Framework.Model.S128.ComplexAttributes.timeIntervalOfProduct {
                    issuanceCycle = new S100Framework.Model.S128.ComplexAttributes.issuanceCycle {
                        timeIntervalOfCycle = new S100Framework.Model.S128.ComplexAttributes.timeIntervalOfCycle {
                            typeOfTimeIntervalUnit = new List<S100Framework.Model.S128.typeOfTimeIntervalUnit> { S100Framework.Model.S128.typeOfTimeIntervalUnit.Month },
                            valueOfTime = 12,
                        }
                    },
                    issueDate = DateTime.Now,
                },
                editionNumber = 17,
                encodingFormat = S100Framework.Model.S128.encodingFormat.IsoIec8211,
                issueDate = DateTime.Now,
                notForNavigation = false,
                typeOfProductFormat = S100Framework.Model.S128.typeOfProductFormat.IsoIec8211,
            };

            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var ns = new XmlSerializerNamespaces();
            //ns.Add(string.Empty, "http://www.iho.int/S128/2.0");
            ns.Add("S128", "http://www.iho.int/S128/2.0");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("gml", "http://www.opengis.net/gml/3.2");
            ns.Add("S100", "http://www.iho.int/s100gml/5.0");
            ns.Add("s100_profile", "http://www.iho.int/S-100/profile/s100_gmlProfile");
            ns.Add("xlink", "http://www.w3.org/1999/xlink");

            var xmlSerializer = new XmlSerializer(typeof(ElectronicProduct));

            string xml;
            using (StringWriter textWriter = new StringWriter()) {
                xmlSerializer.Serialize(textWriter, product, ns);
                xml = textWriter.ToString();
            }

            IO.File.WriteAllText(@"c:\temp\s128_sample.gml", xml);
        }
    }
}


namespace TestS100Framework.Model
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S128/2.0", IsNullable = false)]
    public partial class Dataset
    {

        private DatasetIdentificationInformation datasetIdentificationInformationField;

        private DatasetMembers membersField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/s100gml/5.0")]
        public DatasetIdentificationInformation DatasetIdentificationInformation {
            get {
                return this.datasetIdentificationInformationField;
            }
            set {
                this.datasetIdentificationInformationField = value;
            }
        }

        /// <remarks/>
        public DatasetMembers members {
            get {
                return this.membersField;
            }
            set {
                this.membersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/s100gml/5.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/s100gml/5.0", IsNullable = false)]
    public partial class DatasetIdentificationInformation
    {

        private string encodingSpecificationField;

        private decimal encodingSpecificationEditionField;

        private string productIdentifierField;

        private decimal productEditionField;

        private byte applicationProfileField;

        private string datasetFileIdentifierField;

        private string datasetTitleField;

        private System.DateTime datasetReferenceDateField;

        private string datasetLanguageField;

        private string datasetTopicCategoryField;

        private string datasetPurposeField;

        private byte updateNumberField;

        /// <remarks/>
        public string encodingSpecification {
            get {
                return this.encodingSpecificationField;
            }
            set {
                this.encodingSpecificationField = value;
            }
        }

        /// <remarks/>
        public decimal encodingSpecificationEdition {
            get {
                return this.encodingSpecificationEditionField;
            }
            set {
                this.encodingSpecificationEditionField = value;
            }
        }

        /// <remarks/>
        public string productIdentifier {
            get {
                return this.productIdentifierField;
            }
            set {
                this.productIdentifierField = value;
            }
        }

        /// <remarks/>
        public decimal productEdition {
            get {
                return this.productEditionField;
            }
            set {
                this.productEditionField = value;
            }
        }

        /// <remarks/>
        public byte applicationProfile {
            get {
                return this.applicationProfileField;
            }
            set {
                this.applicationProfileField = value;
            }
        }

        /// <remarks/>
        public string datasetFileIdentifier {
            get {
                return this.datasetFileIdentifierField;
            }
            set {
                this.datasetFileIdentifierField = value;
            }
        }

        /// <remarks/>
        public string datasetTitle {
            get {
                return this.datasetTitleField;
            }
            set {
                this.datasetTitleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime datasetReferenceDate {
            get {
                return this.datasetReferenceDateField;
            }
            set {
                this.datasetReferenceDateField = value;
            }
        }

        /// <remarks/>
        public string datasetLanguage {
            get {
                return this.datasetLanguageField;
            }
            set {
                this.datasetLanguageField = value;
            }
        }

        /// <remarks/>
        public string datasetTopicCategory {
            get {
                return this.datasetTopicCategoryField;
            }
            set {
                this.datasetTopicCategoryField = value;
            }
        }

        /// <remarks/>
        public string datasetPurpose {
            get {
                return this.datasetPurposeField;
            }
            set {
                this.datasetPurposeField = value;
            }
        }

        /// <remarks/>
        public byte updateNumber {
            get {
                return this.updateNumberField;
            }
            set {
                this.updateNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembers
    {

        private DatasetMembersElectronicProduct[] electronicProductField;

        private DatasetMembersPhysicalProduct[] physicalProductField;

        private DatasetMembersS100Service s100ServiceField;

        private DatasetMembersDistributorInformation distributorInformationField;

        private DatasetMembersCatalogueSectionHeader catalogueSectionHeaderField;

        private DatasetMembersContactDetails contactDetailsField;

        private DatasetMembersProducerInformation producerInformationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ElectronicProduct")]
        public DatasetMembersElectronicProduct[] ElectronicProduct {
            get {
                return this.electronicProductField;
            }
            set {
                this.electronicProductField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PhysicalProduct")]
        public DatasetMembersPhysicalProduct[] PhysicalProduct {
            get {
                return this.physicalProductField;
            }
            set {
                this.physicalProductField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersS100Service S100Service {
            get {
                return this.s100ServiceField;
            }
            set {
                this.s100ServiceField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersDistributorInformation DistributorInformation {
            get {
                return this.distributorInformationField;
            }
            set {
                this.distributorInformationField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersCatalogueSectionHeader CatalogueSectionHeader {
            get {
                return this.catalogueSectionHeaderField;
            }
            set {
                this.catalogueSectionHeaderField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersContactDetails ContactDetails {
            get {
                return this.contactDetailsField;
            }
            set {
                this.contactDetailsField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersProducerInformation ProducerInformation {
            get {
                return this.producerInformationField;
            }
            set {
                this.producerInformationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProduct
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("catalogueElementClassification", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("compressionFlag", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("datasetName", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("editionNumber", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("elementContainer", typeof(DatasetMembersElectronicProductElementContainer))]
        [System.Xml.Serialization.XmlElementAttribute("encodingFormat", typeof(DatasetMembersElectronicProductEncodingFormat))]
        [System.Xml.Serialization.XmlElementAttribute("geometry", typeof(DatasetMembersElectronicProductGeometry))]
        [System.Xml.Serialization.XmlElementAttribute("issueDate", typeof(System.DateTime), DataType = "date")]
        [System.Xml.Serialization.XmlElementAttribute("navigationPurpose", typeof(DatasetMembersElectronicProductNavigationPurpose))]
        [System.Xml.Serialization.XmlElementAttribute("notForNavigation", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("productNumber", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("productSpecification", typeof(DatasetMembersElectronicProductProductSpecification))]
        [System.Xml.Serialization.XmlElementAttribute("specificUsage", typeof(DatasetMembersElectronicProductSpecificUsage))]
        [System.Xml.Serialization.XmlElementAttribute("timeIntervalOfProduct", typeof(DatasetMembersElectronicProductTimeIntervalOfProduct))]
        [System.Xml.Serialization.XmlElementAttribute("typeOfProductFormat", typeof(DatasetMembersElectronicProductTypeOfProductFormat))]
        [System.Xml.Serialization.XmlElementAttribute("updateDate", typeof(System.DateTime), DataType = "date")]
        [System.Xml.Serialization.XmlElementAttribute("updateNumber", typeof(byte))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName {
            get {
                return this.itemsElementNameField;
            }
            set {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductElementContainer
    {

        private string hrefField;

        private string arcroleField;

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
    public partial class DatasetMembersElectronicProductEncodingFormat
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductGeometry
    {

        private surfaceProperty surfacePropertyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/s100gml/5.0")]
        public surfaceProperty surfaceProperty {
            get {
                return this.surfacePropertyField;
            }
            set {
                this.surfacePropertyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/s100gml/5.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/s100gml/5.0", IsNullable = false)]
    public partial class surfaceProperty
    {

        private surfacePropertySurface surfaceField;

        /// <remarks/>
        public surfacePropertySurface Surface {
            get {
                return this.surfaceField;
            }
            set {
                this.surfaceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/s100gml/5.0")]
    public partial class surfacePropertySurface
    {

        private patches patchesField;

        private string idField;

        private string srsNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opengis.net/gml/3.2")]
        public patches patches {
            get {
                return this.patchesField;
            }
            set {
                this.patchesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string srsName {
            get {
                return this.srsNameField;
            }
            set {
                this.srsNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.opengis.net/gml/3.2", IsNullable = false)]
    public partial class patches
    {

        private patchesPolygonPatch polygonPatchField;

        /// <remarks/>
        public patchesPolygonPatch PolygonPatch {
            get {
                return this.polygonPatchField;
            }
            set {
                this.polygonPatchField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    public partial class patchesPolygonPatch
    {

        private patchesPolygonPatchExterior exteriorField;

        /// <remarks/>
        public patchesPolygonPatchExterior exterior {
            get {
                return this.exteriorField;
            }
            set {
                this.exteriorField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    public partial class patchesPolygonPatchExterior
    {

        private patchesPolygonPatchExteriorLinearRing linearRingField;

        /// <remarks/>
        public patchesPolygonPatchExteriorLinearRing LinearRing {
            get {
                return this.linearRingField;
            }
            set {
                this.linearRingField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opengis.net/gml/3.2")]
    public partial class patchesPolygonPatchExteriorLinearRing
    {

        private string posListField;

        /// <remarks/>
        public string posList {
            get {
                return this.posListField;
            }
            set {
                this.posListField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductNavigationPurpose
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductProductSpecification
    {

        private System.DateTime dateField;

        private string nameField;

        private decimal versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }

        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public decimal version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductSpecificUsage
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductTimeIntervalOfProduct
    {

        private System.DateTime issueDateField;

        private DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycle issuanceCycleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime issueDate {
            get {
                return this.issueDateField;
            }
            set {
                this.issueDateField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycle issuanceCycle {
            get {
                return this.issuanceCycleField;
            }
            set {
                this.issuanceCycleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycle
    {

        private DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycleTimeIntervalOfCycle timeIntervalOfCycleField;

        /// <remarks/>
        public DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycleTimeIntervalOfCycle timeIntervalOfCycle {
            get {
                return this.timeIntervalOfCycleField;
            }
            set {
                this.timeIntervalOfCycleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycleTimeIntervalOfCycle
    {

        private DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycleTimeIntervalOfCycleTypeOfTimeIntervalUnit typeOfTimeIntervalUnitField;

        private byte valueOfTimeField;

        /// <remarks/>
        public DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycleTimeIntervalOfCycleTypeOfTimeIntervalUnit typeOfTimeIntervalUnit {
            get {
                return this.typeOfTimeIntervalUnitField;
            }
            set {
                this.typeOfTimeIntervalUnitField = value;
            }
        }

        /// <remarks/>
        public byte valueOfTime {
            get {
                return this.valueOfTimeField;
            }
            set {
                this.valueOfTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductTimeIntervalOfProductIssuanceCycleTimeIntervalOfCycleTypeOfTimeIntervalUnit
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersElectronicProductTypeOfProductFormat
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.iho.int/S128/2.0", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        catalogueElementClassification,

        /// <remarks/>
        compressionFlag,

        /// <remarks/>
        datasetName,

        /// <remarks/>
        editionNumber,

        /// <remarks/>
        elementContainer,

        /// <remarks/>
        encodingFormat,

        /// <remarks/>
        geometry,

        /// <remarks/>
        issueDate,

        /// <remarks/>
        navigationPurpose,

        /// <remarks/>
        notForNavigation,

        /// <remarks/>
        productNumber,

        /// <remarks/>
        productSpecification,

        /// <remarks/>
        specificUsage,

        /// <remarks/>
        timeIntervalOfProduct,

        /// <remarks/>
        typeOfProductFormat,

        /// <remarks/>
        updateDate,

        /// <remarks/>
        updateNumber,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersPhysicalProduct
    {

        private object[] itemsField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("catalogueElementClassification", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("editionDate", typeof(System.DateTime), DataType = "date")]
        [System.Xml.Serialization.XmlElementAttribute("editionNumber", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("elementContainer", typeof(DatasetMembersPhysicalProductElementContainer))]
        [System.Xml.Serialization.XmlElementAttribute("featureName", typeof(DatasetMembersPhysicalProductFeatureName))]
        [System.Xml.Serialization.XmlElementAttribute("geometry", typeof(DatasetMembersPhysicalProductGeometry))]
        [System.Xml.Serialization.XmlElementAttribute("notForNavigation", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("onlineResource", typeof(DatasetMembersPhysicalProductOnlineResource))]
        [System.Xml.Serialization.XmlElementAttribute("printInformation", typeof(DatasetMembersPhysicalProductPrintInformation))]
        [System.Xml.Serialization.XmlElementAttribute("specificUsage", typeof(DatasetMembersPhysicalProductSpecificUsage))]
        [System.Xml.Serialization.XmlElementAttribute("theReference", typeof(DatasetMembersPhysicalProductTheReference))]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersPhysicalProductElementContainer
    {

        private string hrefField;

        private string arcroleField;

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
    public partial class DatasetMembersPhysicalProductFeatureName
    {

        private bool displayNameField;

        private bool displayNameFieldSpecified;

        private string languageField;

        private string nameField;

        /// <remarks/>
        public bool displayName {
            get {
                return this.displayNameField;
            }
            set {
                this.displayNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool displayNameSpecified {
            get {
                return this.displayNameFieldSpecified;
            }
            set {
                this.displayNameFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string language {
            get {
                return this.languageField;
            }
            set {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersPhysicalProductGeometry
    {

        private surfaceProperty surfacePropertyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/s100gml/5.0")]
        public surfaceProperty surfaceProperty {
            get {
                return this.surfacePropertyField;
            }
            set {
                this.surfacePropertyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersPhysicalProductOnlineResource
    {

        private string applicationProfileField;

        private string linkageField;

        /// <remarks/>
        public string applicationProfile {
            get {
                return this.applicationProfileField;
            }
            set {
                this.applicationProfileField = value;
            }
        }

        /// <remarks/>
        public string linkage {
            get {
                return this.linkageField;
            }
            set {
                this.linkageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersPhysicalProductPrintInformation
    {

        private string printNationField;

        private string printAgencyField;

        private System.DateTime printYearField;

        private DatasetMembersPhysicalProductPrintInformationPrintSize printSizeField;

        /// <remarks/>
        public string printNation {
            get {
                return this.printNationField;
            }
            set {
                this.printNationField = value;
            }
        }

        /// <remarks/>
        public string printAgency {
            get {
                return this.printAgencyField;
            }
            set {
                this.printAgencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime printYear {
            get {
                return this.printYearField;
            }
            set {
                this.printYearField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersPhysicalProductPrintInformationPrintSize printSize {
            get {
                return this.printSizeField;
            }
            set {
                this.printSizeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersPhysicalProductPrintInformationPrintSize
    {

        private string iSO216Field;

        /// <remarks/>
        public string ISO216 {
            get {
                return this.iSO216Field;
            }
            set {
                this.iSO216Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersPhysicalProductSpecificUsage
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersPhysicalProductTheReference
    {

        private DatasetMembersPhysicalProductTheReferenceProductMapping productMappingField;

        private string hrefField;

        private string arcroleField;

        /// <remarks/>
        public DatasetMembersPhysicalProductTheReferenceProductMapping ProductMapping {
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
    public partial class DatasetMembersPhysicalProductTheReferenceProductMapping
    {

        private string categoryOfProductMappingField;

        /// <remarks/>
        public string categoryOfProductMapping {
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
    public partial class DatasetMembersS100Service
    {

        private DatasetMembersS100ServiceCatalogueElementClassification catalogueElementClassificationField;

        private bool notForNavigationField;

        private string purposeField;

        private DatasetMembersS100ServiceFeatureName featureNameField;

        private bool compressionFlagField;

        private DatasetMembersS100ServiceEncodingFormat encodingFormatField;

        private string serviceStatusField;

        private DatasetMembersS100ServiceTypeOfProductFormat typeOfProductFormatField;

        private DatasetMembersS100ServiceProductSpecification productSpecificationField;

        private DatasetMembersS100ServiceElementContainer elementContainerField;

        private DatasetMembersS100ServiceGeometry geometryField;

        private string idField;

        /// <remarks/>
        public DatasetMembersS100ServiceCatalogueElementClassification catalogueElementClassification {
            get {
                return this.catalogueElementClassificationField;
            }
            set {
                this.catalogueElementClassificationField = value;
            }
        }

        /// <remarks/>
        public bool notForNavigation {
            get {
                return this.notForNavigationField;
            }
            set {
                this.notForNavigationField = value;
            }
        }

        /// <remarks/>
        public string purpose {
            get {
                return this.purposeField;
            }
            set {
                this.purposeField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersS100ServiceFeatureName featureName {
            get {
                return this.featureNameField;
            }
            set {
                this.featureNameField = value;
            }
        }

        /// <remarks/>
        public bool compressionFlag {
            get {
                return this.compressionFlagField;
            }
            set {
                this.compressionFlagField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersS100ServiceEncodingFormat encodingFormat {
            get {
                return this.encodingFormatField;
            }
            set {
                this.encodingFormatField = value;
            }
        }

        /// <remarks/>
        public string serviceStatus {
            get {
                return this.serviceStatusField;
            }
            set {
                this.serviceStatusField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersS100ServiceTypeOfProductFormat typeOfProductFormat {
            get {
                return this.typeOfProductFormatField;
            }
            set {
                this.typeOfProductFormatField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersS100ServiceProductSpecification productSpecification {
            get {
                return this.productSpecificationField;
            }
            set {
                this.productSpecificationField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersS100ServiceElementContainer elementContainer {
            get {
                return this.elementContainerField;
            }
            set {
                this.elementContainerField = value;
            }
        }

        /// <remarks/>
        public DatasetMembersS100ServiceGeometry geometry {
            get {
                return this.geometryField;
            }
            set {
                this.geometryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersS100ServiceCatalogueElementClassification
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersS100ServiceFeatureName
    {

        private string nameField;

        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersS100ServiceEncodingFormat
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersS100ServiceTypeOfProductFormat
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersS100ServiceProductSpecification
    {

        private System.DateTime dateField;

        private string nameField;

        private string versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }

        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersS100ServiceElementContainer
    {

        private string hrefField;

        private string arcroleField;

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
    public partial class DatasetMembersS100ServiceGeometry
    {

        private surfaceProperty surfacePropertyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/s100gml/5.0")]
        public surfaceProperty surfaceProperty {
            get {
                return this.surfacePropertyField;
            }
            set {
                this.surfacePropertyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersDistributorInformation
    {

        private string distributorNameField;

        private string idField;

        /// <remarks/>
        public string distributorName {
            get {
                return this.distributorNameField;
            }
            set {
                this.distributorNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersCatalogueSectionHeader
    {

        private ushort catalogueSectionNumberField;

        private string idField;

        /// <remarks/>
        public ushort catalogueSectionNumber {
            get {
                return this.catalogueSectionNumberField;
            }
            set {
                this.catalogueSectionNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersContactDetails
    {

        private string contactInstructionsField;

        private string idField;

        /// <remarks/>
        public string contactInstructions {
            get {
                return this.contactInstructionsField;
            }
            set {
                this.contactInstructionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S128/2.0")]
    public partial class DatasetMembersProducerInformation
    {

        private string agencyResponsibleForProductionField;

        private string idField;

        /// <remarks/>
        public string agencyResponsibleForProduction {
            get {
                return this.agencyResponsibleForProductionField;
            }
            set {
                this.agencyResponsibleForProductionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.opengis.net/gml/3.2")]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }


}