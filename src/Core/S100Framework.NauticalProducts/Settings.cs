using ArcGIS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.DomainModel.S128.Horizon
{
    namespace Settings
    {
        public record Connection(string ProductSpecification, Uri ConnectionFile);
        public class NauticalProducts
        {
            public Connection[] Connections { get; set; } = [];
        }
    }

    public enum ExportTypes : int {
        NewDataset = 1,
        NewEdition = 2,
        Update = 4,
        Reissue = 8,
        Cancellation = 16,
    }

    public record ElectronicProduct(string DatasetName, DateTime TimestampUTC, int Edition, int Update, ExportTypes ExportTypes);
}