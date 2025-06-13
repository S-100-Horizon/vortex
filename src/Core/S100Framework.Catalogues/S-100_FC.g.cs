using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace S100Framework.Catalogues
{
    public class S100_TruncatedDate
    {
        public string Value { get; set; }
    }
}

namespace S100Framework.DomainModel.S100
{
    #region SimpleTypes

    [Serializable]
    [XmlType(Namespace = "http://www.iho.int/s100gml/5.0")]
    public enum MD_TopicCategoryCode
    {
        [XmlEnum("farming")]
        Farming,
        [XmlEnum("biota")]
        Biota,
        [XmlEnum("boundaries")]
        Boundaries,
        [XmlEnum("climatologyMeteorologyAtmosphere")]
        ClimatologyMeteorologyAtmosphere,
        [XmlEnum("economy")]
        Economy,
        [XmlEnum("elevation")]
        Elevation,
        [XmlEnum("environment")]
        Environment,
        [XmlEnum("geoscientificInformation")]
        GeoscientificInformation,
        [XmlEnum("health")]
        Health,
        [XmlEnum("imageryBaseMapsEarthCover")]
        ImageryBaseMapsEarthCover,
        [XmlEnum("intelligenceMilitary")]
        IntelligenceMilitary,
        [XmlEnum("inlandWaters")]
        InlandWaters,
        [XmlEnum("location")]
        Location,
        [XmlEnum("oceans")]
        Oceans,
        [XmlEnum("planningCadastre")]
        PlanningCadastre,
        [XmlEnum("society")]
        Society,
        [XmlEnum("structure")]
        Structure,
        [XmlEnum("transportation")]
        Transportation,
        [XmlEnum("utilitiesCommunication")]
        UtilitiesCommunication,
    }

    [Serializable]
    [XmlType(Namespace = "http://www.iho.int/s100gml/5.0")]
    public enum datasetPurposeType
    {
        [XmlEnum("base")]
        Base,
        [XmlEnum("update")]
        Update,
    }

    #endregion


    #region ComplexTypes

    #endregion

    [System.Serializable()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
    [XmlType(Namespace = "http://www.iho.int/s100gml/5.0")]
    public partial class DataSetIdentification
    {
        [XmlElement(Order = 0)]
        public string encodingSpecification { get; init; } = "S-100 Part 10b";

        [XmlElement(Order = 1)]
        public string encodingSpecificationEdition { get; init; } = "1.0";

        [XmlElement(Order = 2)]
        public string productIdentifier { get; set; }

        [XmlElement(Order = 3)]
        public string productEdition { get; set; }

        [XmlElement(Order = 4)]
        public string applicationProfile { get; set; }

        [XmlElement(Order = 5)]
        public string datasetFileIdentifier { get; set; }

        [XmlElement(Order = 6)]
        public string datasetTitle { get; set; }

        [XmlElement(DataType = "date", Order = 7)]
        public DateTime datasetReferenceDate { get; set; }

        [XmlElement(Order = 8)]
        [DefaultValue("eng")]
        public string datasetLanguage { get; set; } = "eng";

        [XmlElement(Order = 9)]
        public string datasetAbstract { get; set; }

        [XmlElement("datasetTopicCategory", Order = 10)]
        public List<MD_TopicCategoryCode> datasetTopicCategory { get; set; } = new List<MD_TopicCategoryCode>();

        [XmlElement(Order = 11)]
        public datasetPurposeType datasetPurpose { get; set; }

        [XmlElement(DataType = "nonNegativeInteger", Order = 12)]
        public string updateNumber { get; set; }
    }


    [Serializable]
    public abstract class DatasetBase
    {
        [XmlElement(Order = 0)]
        public DataSetIdentification DatasetIdentificationInformation { get; set; }
    }

    [Serializable]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "<Pending>")]
    public abstract class MembersBase
    {
        public abstract List<object> elements { get; set; }
    }
}
