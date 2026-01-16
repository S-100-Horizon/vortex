namespace S100Horizon.Settings
{
    public record Connection(string ProductSpecification, Uri? ConnectionFile = default);
    public class ProductCatalogue
    {
        public Connection[] Connections { get; set; } = [];

        public string OutputFolder { get; set; } = @".\";
    }
}

namespace S100FC.ProductCatalogue
{
    public enum ProductFormat : int
    {
        GML = 1,
        HDF5 = 5,
        ISO8211 = 8211
    }

    public enum ExportTypes : int
    {
        NewDataset = 1,
        NewEdition = 2,
        Update = 4,
        Reissue = 8,
        Cancellation = 16,
    }

    public class Dataset
    {
        public required string DatasetName { get; set; } = string.Empty;
        public required DateTime TimestampUTC { get; set; } = DateTime.UtcNow;

        public required int Edition { get; set; }
        public required int Update { get; set; }

        public required ExportTypes ExportTypes { get; set; }
    }
}