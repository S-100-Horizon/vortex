using S100Framework.DomainModel.S128;
using S100Framework.DomainModel.S128.ComplexAttributes;
using S100Framework.DomainModel.S128.FeatureTypes;
using System.Text.Json.Serialization;

namespace ProductCatalogueService
{
    public static class ResponseTypes
    {
        public class ApiResponse
        {
            public bool Success { get; set; } = true;
            public string? Message { get; set; }
            public int? TotalHits { get; set; }
            public double? DurationMs { get; set; }
            public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
        }

        public class ApiResponse<T> : ApiResponse
        {
            public T? Data { get; set; }
        }


        public class ElectronicProductResponse {
            public Boolean? CompressionFlag { get; set; } = default;
            public String? DatasetName { get; set; } = default;
            public DateOnly IssueDate { get; set; } = default;
            public S100Framework.DomainModel.S100.Time? IssueTime { get; set; } = default;
            public typeOfProductFormat TypeOfProductFormat { get; set; }
            public productSpecification? ProductSpecification { get; set; } = default;
            public string Code => nameof(ElectronicProduct);
        }
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public static class RequestTypes
    {
        public enum ExportType : int
        {
            NewEdition = 1,
            Update = 2,
            Reissue = 3
        };
    }
}