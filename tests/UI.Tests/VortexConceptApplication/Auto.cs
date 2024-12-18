namespace VortexConceptApplication
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IsNullable = false)]
    public partial class S100_FC_FeatureCatalogue
    {

        private string nameField;

        private string scopeField;

        private string fieldOfApplicationField;

        private string versionNumberField;

        private System.DateTime versionDateField;

        private string productIdField;

        private S100_FC_FeatureCatalogueProducer producerField;

        private S100_FC_FeatureCatalogueS100_FC_DefinitionSources s100_FC_DefinitionSourcesField;

        private S100_FC_FeatureCatalogueS100_FC_SimpleAttribute[] s100_FC_SimpleAttributesField;

        private S100_FC_FeatureCatalogueS100_FC_ComplexAttribute[] s100_FC_ComplexAttributesField;

        private S100_FC_FeatureCatalogueS100_FC_Role[] s100_FC_RolesField;

        private S100_FC_FeatureCatalogueS100_FC_InformationAssociation[] s100_FC_InformationAssociationsField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureAssociation[] s100_FC_FeatureAssociationsField;

        private S100_FC_FeatureCatalogueS100_FC_InformationType[] s100_FC_InformationTypesField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureType[] s100_FC_FeatureTypesField;

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
        public string scope {
            get {
                return this.scopeField;
            }
            set {
                this.scopeField = value;
            }
        }

        /// <remarks/>
        public string fieldOfApplication {
            get {
                return this.fieldOfApplicationField;
            }
            set {
                this.fieldOfApplicationField = value;
            }
        }

        /// <remarks/>
        public string versionNumber {
            get {
                return this.versionNumberField;
            }
            set {
                this.versionNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime versionDate {
            get {
                return this.versionDateField;
            }
            set {
                this.versionDateField = value;
            }
        }

        /// <remarks/>
        public string productId {
            get {
                return this.productIdField;
            }
            set {
                this.productIdField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueProducer producer {
            get {
                return this.producerField;
            }
            set {
                this.producerField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_DefinitionSources S100_FC_DefinitionSources {
            get {
                return this.s100_FC_DefinitionSourcesField;
            }
            set {
                this.s100_FC_DefinitionSourcesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("S100_FC_SimpleAttribute", IsNullable = false)]
        public S100_FC_FeatureCatalogueS100_FC_SimpleAttribute[] S100_FC_SimpleAttributes {
            get {
                return this.s100_FC_SimpleAttributesField;
            }
            set {
                this.s100_FC_SimpleAttributesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("S100_FC_ComplexAttribute", IsNullable = false)]
        public S100_FC_FeatureCatalogueS100_FC_ComplexAttribute[] S100_FC_ComplexAttributes {
            get {
                return this.s100_FC_ComplexAttributesField;
            }
            set {
                this.s100_FC_ComplexAttributesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("S100_FC_Role", IsNullable = false)]
        public S100_FC_FeatureCatalogueS100_FC_Role[] S100_FC_Roles {
            get {
                return this.s100_FC_RolesField;
            }
            set {
                this.s100_FC_RolesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("S100_FC_InformationAssociation", IsNullable = false)]
        public S100_FC_FeatureCatalogueS100_FC_InformationAssociation[] S100_FC_InformationAssociations {
            get {
                return this.s100_FC_InformationAssociationsField;
            }
            set {
                this.s100_FC_InformationAssociationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("S100_FC_FeatureAssociation", IsNullable = false)]
        public S100_FC_FeatureCatalogueS100_FC_FeatureAssociation[] S100_FC_FeatureAssociations {
            get {
                return this.s100_FC_FeatureAssociationsField;
            }
            set {
                this.s100_FC_FeatureAssociationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("S100_FC_InformationType", IsNullable = false)]
        public S100_FC_FeatureCatalogueS100_FC_InformationType[] S100_FC_InformationTypes {
            get {
                return this.s100_FC_InformationTypesField;
            }
            set {
                this.s100_FC_InformationTypesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("S100_FC_FeatureType", IsNullable = false)]
        public S100_FC_FeatureCatalogueS100_FC_FeatureType[] S100_FC_FeatureTypes {
            get {
                return this.s100_FC_FeatureTypesField;
            }
            set {
                this.s100_FC_FeatureTypesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueProducer
    {

        private string roleField;

        private party partyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100CI/5.0")]
        public string role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100CI/5.0")]
        public party party {
            get {
                return this.partyField;
            }
            set {
                this.partyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100CI/5.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100CI/5.0", IsNullable = false)]
    public partial class party
    {

        private partyCI_Organisation cI_OrganisationField;

        /// <remarks/>
        public partyCI_Organisation CI_Organisation {
            get {
                return this.cI_OrganisationField;
            }
            set {
                this.cI_OrganisationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100CI/5.0")]
    public partial class partyCI_Organisation
    {

        private string nameField;

        private partyCI_OrganisationContactInfo contactInfoField;

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
        public partyCI_OrganisationContactInfo contactInfo {
            get {
                return this.contactInfoField;
            }
            set {
                this.contactInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100CI/5.0")]
    public partial class partyCI_OrganisationContactInfo
    {

        private partyCI_OrganisationContactInfoAddress addressField;

        private partyCI_OrganisationContactInfoOnlineResource onlineResourceField;

        /// <remarks/>
        public partyCI_OrganisationContactInfoAddress address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public partyCI_OrganisationContactInfoOnlineResource onlineResource {
            get {
                return this.onlineResourceField;
            }
            set {
                this.onlineResourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100CI/5.0")]
    public partial class partyCI_OrganisationContactInfoAddress
    {

        private string administrativeAreaField;

        private string countryField;

        private string electronicMailAddressField;

        /// <remarks/>
        public string administrativeArea {
            get {
                return this.administrativeAreaField;
            }
            set {
                this.administrativeAreaField = value;
            }
        }

        /// <remarks/>
        public string country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public string electronicMailAddress {
            get {
                return this.electronicMailAddressField;
            }
            set {
                this.electronicMailAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100CI/5.0")]
    public partial class partyCI_OrganisationContactInfoOnlineResource
    {

        private string linkageField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_DefinitionSources
    {

        private S100_FC_FeatureCatalogueS100_FC_DefinitionSourcesFC_DefinitionSource fC_DefinitionSourceField;

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_DefinitionSourcesFC_DefinitionSource FC_DefinitionSource {
            get {
                return this.fC_DefinitionSourceField;
            }
            set {
                this.fC_DefinitionSourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_DefinitionSourcesFC_DefinitionSource
    {

        private S100_FC_FeatureCatalogueS100_FC_DefinitionSourcesFC_DefinitionSourceSource sourceField;

        private string idField;

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_DefinitionSourcesFC_DefinitionSourceSource source {
            get {
                return this.sourceField;
            }
            set {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_DefinitionSourcesFC_DefinitionSourceSource
    {

        private string titleField;

        private onlineResource onlineResourceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100CI/5.0")]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100CI/5.0")]
        public onlineResource onlineResource {
            get {
                return this.onlineResourceField;
            }
            set {
                this.onlineResourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100CI/5.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100CI/5.0", IsNullable = false)]
    public partial class onlineResource
    {

        private string linkageField;

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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttribute
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("alias", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("code", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("constraints", typeof(S100_FC_FeatureCatalogueS100_FC_SimpleAttributeConstraints))]
        [System.Xml.Serialization.XmlElementAttribute("definition", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("definitionReference", typeof(S100_FC_FeatureCatalogueS100_FC_SimpleAttributeDefinitionReference))]
        [System.Xml.Serialization.XmlElementAttribute("listedValues", typeof(S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValues))]
        [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("quantitySpecification", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("uom", typeof(S100_FC_FeatureCatalogueS100_FC_SimpleAttributeUom))]
        [System.Xml.Serialization.XmlElementAttribute("valueType", typeof(string))]
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttributeConstraints
    {

        private range rangeField;

        private ushort stringLengthField;

        private bool stringLengthFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100CD/5.0")]
        public range range {
            get {
                return this.rangeField;
            }
            set {
                this.rangeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100CD/5.0")]
        public ushort stringLength {
            get {
                return this.stringLengthField;
            }
            set {
                this.stringLengthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool stringLengthSpecified {
            get {
                return this.stringLengthFieldSpecified;
            }
            set {
                this.stringLengthFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100CD/5.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100CD/5.0", IsNullable = false)]
    public partial class range
    {

        private decimal lowerBoundField;

        private decimal upperBoundField;

        private bool upperBoundFieldSpecified;

        private string closureField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public decimal lowerBound {
            get {
                return this.lowerBoundField;
            }
            set {
                this.lowerBoundField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public decimal upperBound {
            get {
                return this.upperBoundField;
            }
            set {
                this.upperBoundField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool upperBoundSpecified {
            get {
                return this.upperBoundFieldSpecified;
            }
            set {
                this.upperBoundFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public string closure {
            get {
                return this.closureField;
            }
            set {
                this.closureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttributeDefinitionReference
    {

        private ushort sourceIdentifierField;

        private S100_FC_FeatureCatalogueS100_FC_SimpleAttributeDefinitionReferenceDefinitionSource definitionSourceField;

        /// <remarks/>
        public ushort sourceIdentifier {
            get {
                return this.sourceIdentifierField;
            }
            set {
                this.sourceIdentifierField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_SimpleAttributeDefinitionReferenceDefinitionSource definitionSource {
            get {
                return this.definitionSourceField;
            }
            set {
                this.definitionSourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttributeDefinitionReferenceDefinitionSource
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValues
    {

        private S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValue[] listedValueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("listedValue")]
        public S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValue[] listedValue {
            get {
                return this.listedValueField;
            }
            set {
                this.listedValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValue
    {

        private string labelField;

        private string definitionField;

        private byte codeField;

        private S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValueDefinitionReference definitionReferenceField;

        /// <remarks/>
        public string label {
            get {
                return this.labelField;
            }
            set {
                this.labelField = value;
            }
        }

        /// <remarks/>
        public string definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }

        /// <remarks/>
        public byte code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValueDefinitionReference definitionReference {
            get {
                return this.definitionReferenceField;
            }
            set {
                this.definitionReferenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValueDefinitionReference
    {

        private ushort sourceIdentifierField;

        private S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValueDefinitionReferenceDefinitionSource definitionSourceField;

        /// <remarks/>
        public ushort sourceIdentifier {
            get {
                return this.sourceIdentifierField;
            }
            set {
                this.sourceIdentifierField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValueDefinitionReferenceDefinitionSource definitionSource {
            get {
                return this.definitionSourceField;
            }
            set {
                this.definitionSourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttributeListedValuesListedValueDefinitionReferenceDefinitionSource
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_SimpleAttributeUom
    {

        private string nameField;

        private string symbolField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public string symbol {
            get {
                return this.symbolField;
            }
            set {
                this.symbolField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.iho.int/S100FC/5.2", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        alias,

        /// <remarks/>
        code,

        /// <remarks/>
        constraints,

        /// <remarks/>
        definition,

        /// <remarks/>
        definitionReference,

        /// <remarks/>
        listedValues,

        /// <remarks/>
        name,

        /// <remarks/>
        quantitySpecification,

        /// <remarks/>
        uom,

        /// <remarks/>
        valueType,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_ComplexAttribute
    {

        private string nameField;

        private string definitionField;

        private string codeField;

        private string[] aliasField;

        private S100_FC_FeatureCatalogueS100_FC_ComplexAttributeDefinitionReference definitionReferenceField;

        private S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBinding[] subAttributeBindingField;

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
        public string definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }

        /// <remarks/>
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("alias")]
        public string[] alias {
            get {
                return this.aliasField;
            }
            set {
                this.aliasField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_ComplexAttributeDefinitionReference definitionReference {
            get {
                return this.definitionReferenceField;
            }
            set {
                this.definitionReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("subAttributeBinding")]
        public S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBinding[] subAttributeBinding {
            get {
                return this.subAttributeBindingField;
            }
            set {
                this.subAttributeBindingField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_ComplexAttributeDefinitionReference
    {

        private ushort sourceIdentifierField;

        private S100_FC_FeatureCatalogueS100_FC_ComplexAttributeDefinitionReferenceDefinitionSource definitionSourceField;

        /// <remarks/>
        public ushort sourceIdentifier {
            get {
                return this.sourceIdentifierField;
            }
            set {
                this.sourceIdentifierField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_ComplexAttributeDefinitionReferenceDefinitionSource definitionSource {
            get {
                return this.definitionSourceField;
            }
            set {
                this.definitionSourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_ComplexAttributeDefinitionReferenceDefinitionSource
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBinding
    {

        private S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBindingMultiplicity multiplicityField;

        private byte[] permittedValuesField;

        private string attributeVisibilityField;

        private S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBindingAttribute attributeField;

        private bool sequentialField;

        private bool sequentialFieldSpecified;

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBindingMultiplicity multiplicity {
            get {
                return this.multiplicityField;
            }
            set {
                this.multiplicityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public byte[] permittedValues {
            get {
                return this.permittedValuesField;
            }
            set {
                this.permittedValuesField = value;
            }
        }

        /// <remarks/>
        public string attributeVisibility {
            get {
                return this.attributeVisibilityField;
            }
            set {
                this.attributeVisibilityField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBindingAttribute attribute {
            get {
                return this.attributeField;
            }
            set {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool sequential {
            get {
                return this.sequentialField;
            }
            set {
                this.sequentialField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sequentialSpecified {
            get {
                return this.sequentialFieldSpecified;
            }
            set {
                this.sequentialFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBindingMultiplicity
    {

        private byte lowerField;

        private upper upperField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public byte lower {
            get {
                return this.lowerField;
            }
            set {
                this.lowerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0", IsNullable = true)]
        public upper upper {
            get {
                return this.upperField;
            }
            set {
                this.upperField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100Base/5.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.iho.int/S100Base/5.0", IsNullable = true)]
    public partial class upper
    {

        private bool infiniteField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool infinite {
            get {
                return this.infiniteField;
            }
            set {
                this.infiniteField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_ComplexAttributeSubAttributeBindingAttribute
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_Role
    {

        private string nameField;

        private string definitionField;

        private string codeField;

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
        public string definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }

        /// <remarks/>
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationAssociation
    {

        private string nameField;

        private string definitionField;

        private string codeField;

        private S100_FC_FeatureCatalogueS100_FC_InformationAssociationDefinitionReference definitionReferenceField;

        private S100_FC_FeatureCatalogueS100_FC_InformationAssociationRole roleField;

        private bool isAbstractField;

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
        public string definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }

        /// <remarks/>
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_InformationAssociationDefinitionReference definitionReference {
            get {
                return this.definitionReferenceField;
            }
            set {
                this.definitionReferenceField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_InformationAssociationRole role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool isAbstract {
            get {
                return this.isAbstractField;
            }
            set {
                this.isAbstractField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationAssociationDefinitionReference
    {

        private uint sourceIdentifierField;

        private S100_FC_FeatureCatalogueS100_FC_InformationAssociationDefinitionReferenceDefinitionSource definitionSourceField;

        /// <remarks/>
        public uint sourceIdentifier {
            get {
                return this.sourceIdentifierField;
            }
            set {
                this.sourceIdentifierField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_InformationAssociationDefinitionReferenceDefinitionSource definitionSource {
            get {
                return this.definitionSourceField;
            }
            set {
                this.definitionSourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationAssociationDefinitionReferenceDefinitionSource
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationAssociationRole
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureAssociation
    {

        private string nameField;

        private string definitionField;

        private string codeField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureAssociationDefinitionReference definitionReferenceField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureAssociationRole[] roleField;

        private bool isAbstractField;

        private bool isAbstractFieldSpecified;

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
        public string definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }

        /// <remarks/>
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureAssociationDefinitionReference definitionReference {
            get {
                return this.definitionReferenceField;
            }
            set {
                this.definitionReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("role")]
        public S100_FC_FeatureCatalogueS100_FC_FeatureAssociationRole[] role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool isAbstract {
            get {
                return this.isAbstractField;
            }
            set {
                this.isAbstractField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool isAbstractSpecified {
            get {
                return this.isAbstractFieldSpecified;
            }
            set {
                this.isAbstractFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureAssociationDefinitionReference
    {

        private uint sourceIdentifierField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureAssociationDefinitionReferenceDefinitionSource definitionSourceField;

        /// <remarks/>
        public uint sourceIdentifier {
            get {
                return this.sourceIdentifierField;
            }
            set {
                this.sourceIdentifierField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureAssociationDefinitionReferenceDefinitionSource definitionSource {
            get {
                return this.definitionSourceField;
            }
            set {
                this.definitionSourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureAssociationDefinitionReferenceDefinitionSource
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureAssociationRole
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationType
    {

        private string nameField;

        private string definitionField;

        private string codeField;

        private S100_FC_FeatureCatalogueS100_FC_InformationTypeDefinitionReference definitionReferenceField;

        private S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBinding[] attributeBindingField;

        private bool isAbstractField;

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
        public string definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }

        /// <remarks/>
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_InformationTypeDefinitionReference definitionReference {
            get {
                return this.definitionReferenceField;
            }
            set {
                this.definitionReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("attributeBinding")]
        public S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBinding[] attributeBinding {
            get {
                return this.attributeBindingField;
            }
            set {
                this.attributeBindingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool isAbstract {
            get {
                return this.isAbstractField;
            }
            set {
                this.isAbstractField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationTypeDefinitionReference
    {

        private byte sourceIdentifierField;

        private S100_FC_FeatureCatalogueS100_FC_InformationTypeDefinitionReferenceDefinitionSource definitionSourceField;

        /// <remarks/>
        public byte sourceIdentifier {
            get {
                return this.sourceIdentifierField;
            }
            set {
                this.sourceIdentifierField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_InformationTypeDefinitionReferenceDefinitionSource definitionSource {
            get {
                return this.definitionSourceField;
            }
            set {
                this.definitionSourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationTypeDefinitionReferenceDefinitionSource
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBinding
    {

        private S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingMultiplicity multiplicityField;

        private S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingPermittedValues permittedValuesField;

        private S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingAttribute attributeField;

        private bool sequentialField;

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingMultiplicity multiplicity {
            get {
                return this.multiplicityField;
            }
            set {
                this.multiplicityField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingPermittedValues permittedValues {
            get {
                return this.permittedValuesField;
            }
            set {
                this.permittedValuesField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingAttribute attribute {
            get {
                return this.attributeField;
            }
            set {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool sequential {
            get {
                return this.sequentialField;
            }
            set {
                this.sequentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingMultiplicity
    {

        private byte lowerField;

        private upper upperField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public byte lower {
            get {
                return this.lowerField;
            }
            set {
                this.lowerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0", IsNullable = true)]
        public upper upper {
            get {
                return this.upperField;
            }
            set {
                this.upperField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingPermittedValues
    {

        private byte valueField;

        /// <remarks/>
        public byte value {
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_InformationTypeAttributeBindingAttribute
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureType
    {

        private string nameField;

        private string definitionField;

        private string codeField;

        private string[] aliasField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeDefinitionReference definitionReferenceField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBinding[] attributeBindingField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBinding informationBindingField;

        private string featureUseTypeField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBinding[] featureBindingField;

        private string[] permittedPrimitivesField;

        private bool isAbstractField;

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
        public string definition {
            get {
                return this.definitionField;
            }
            set {
                this.definitionField = value;
            }
        }

        /// <remarks/>
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("alias")]
        public string[] alias {
            get {
                return this.aliasField;
            }
            set {
                this.aliasField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeDefinitionReference definitionReference {
            get {
                return this.definitionReferenceField;
            }
            set {
                this.definitionReferenceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("attributeBinding")]
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBinding[] attributeBinding {
            get {
                return this.attributeBindingField;
            }
            set {
                this.attributeBindingField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBinding informationBinding {
            get {
                return this.informationBindingField;
            }
            set {
                this.informationBindingField = value;
            }
        }

        /// <remarks/>
        public string featureUseType {
            get {
                return this.featureUseTypeField;
            }
            set {
                this.featureUseTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("featureBinding")]
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBinding[] featureBinding {
            get {
                return this.featureBindingField;
            }
            set {
                this.featureBindingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("permittedPrimitives")]
        public string[] permittedPrimitives {
            get {
                return this.permittedPrimitivesField;
            }
            set {
                this.permittedPrimitivesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool isAbstract {
            get {
                return this.isAbstractField;
            }
            set {
                this.isAbstractField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeDefinitionReference
    {

        private ushort sourceIdentifierField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeDefinitionReferenceDefinitionSource definitionSourceField;

        /// <remarks/>
        public ushort sourceIdentifier {
            get {
                return this.sourceIdentifierField;
            }
            set {
                this.sourceIdentifierField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeDefinitionReferenceDefinitionSource definitionSource {
            get {
                return this.definitionSourceField;
            }
            set {
                this.definitionSourceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeDefinitionReferenceDefinitionSource
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBinding
    {

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBindingMultiplicity multiplicityField;

        private string attributeVisibilityField;

        private byte[] permittedValuesField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBindingAttribute attributeField;

        private bool sequentialField;

        private bool sequentialFieldSpecified;

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBindingMultiplicity multiplicity {
            get {
                return this.multiplicityField;
            }
            set {
                this.multiplicityField = value;
            }
        }

        /// <remarks/>
        public string attributeVisibility {
            get {
                return this.attributeVisibilityField;
            }
            set {
                this.attributeVisibilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public byte[] permittedValues {
            get {
                return this.permittedValuesField;
            }
            set {
                this.permittedValuesField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBindingAttribute attribute {
            get {
                return this.attributeField;
            }
            set {
                this.attributeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool sequential {
            get {
                return this.sequentialField;
            }
            set {
                this.sequentialField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sequentialSpecified {
            get {
                return this.sequentialFieldSpecified;
            }
            set {
                this.sequentialFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBindingMultiplicity
    {

        private byte lowerField;

        private upper upperField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public byte lower {
            get {
                return this.lowerField;
            }
            set {
                this.lowerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0", IsNullable = true)]
        public upper upper {
            get {
                return this.upperField;
            }
            set {
                this.upperField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeAttributeBindingAttribute
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBinding
    {

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingMultiplicity multiplicityField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingAssociation associationField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingRole roleField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingInformationType[] informationTypeField;

        private string roleTypeField;

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingMultiplicity multiplicity {
            get {
                return this.multiplicityField;
            }
            set {
                this.multiplicityField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingAssociation association {
            get {
                return this.associationField;
            }
            set {
                this.associationField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingRole role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("informationType")]
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingInformationType[] informationType {
            get {
                return this.informationTypeField;
            }
            set {
                this.informationTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string roleType {
            get {
                return this.roleTypeField;
            }
            set {
                this.roleTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingMultiplicity
    {

        private byte lowerField;

        private upper upperField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public byte lower {
            get {
                return this.lowerField;
            }
            set {
                this.lowerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0", IsNullable = true)]
        public upper upper {
            get {
                return this.upperField;
            }
            set {
                this.upperField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingAssociation
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingRole
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeInformationBindingInformationType
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBinding
    {

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingMultiplicity multiplicityField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingAssociation associationField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingRole roleField;

        private S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingFeatureType[] featureTypeField;

        private string roleTypeField;

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingMultiplicity multiplicity {
            get {
                return this.multiplicityField;
            }
            set {
                this.multiplicityField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingAssociation association {
            get {
                return this.associationField;
            }
            set {
                this.associationField = value;
            }
        }

        /// <remarks/>
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingRole role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("featureType")]
        public S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingFeatureType[] featureType {
            get {
                return this.featureTypeField;
            }
            set {
                this.featureTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string roleType {
            get {
                return this.roleTypeField;
            }
            set {
                this.roleTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingMultiplicity
    {

        private byte lowerField;

        private upper upperField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0")]
        public byte lower {
            get {
                return this.lowerField;
            }
            set {
                this.lowerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.iho.int/S100Base/5.0", IsNullable = true)]
        public upper upper {
            get {
                return this.upperField;
            }
            set {
                this.upperField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingAssociation
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingRole
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.iho.int/S100FC/5.2")]
    public partial class S100_FC_FeatureCatalogueS100_FC_FeatureTypeFeatureBindingFeatureType
    {

        private string refField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }


}
