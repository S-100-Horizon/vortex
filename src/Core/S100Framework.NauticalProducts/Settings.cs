using ArcGIS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Horizon.Settings
{
    public record Connection(string ProductSpecification, Uri ConnectionFile);
    public class NauticalProducts
    {
        public Connection[] Connections { get; set; } = [];
    }
}

namespace S100Framework.NauticalProducts
{
    public enum ExportTypes : int
    {
        NewDataset = 1,
        NewEdition = 2,
        Update = 4,
        Reissue = 8,
        Cancellation = 16,
    }

    public class ElectronicProduct
    {
        public required string DatasetName { get; set; } = string.Empty;
        public required DateTime TimestampUTC { get; set; } = DateTime.UtcNow;

        public required int Edition { get; set; }
        public required int Update { get; set; }

        public required ExportTypes ExportTypes { get; set; }
    }
}