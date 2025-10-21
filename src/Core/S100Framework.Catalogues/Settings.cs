using S100Framework.DomainModel.S100;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace S100Horizon.Settings
{
    public class SupportFile
    {
        public string FileName { get; set; } = string.Empty;
        public S100_SupportFileFormat? s100_SupportFileFormat { get; set; }

        public string? version { get; set; } = default;

        public DateOnly? date { get; set; } = default;


        [JsonIgnore]
        [XmlIgnore]
        public string Code => nameof(SupportFile);

    }
}
