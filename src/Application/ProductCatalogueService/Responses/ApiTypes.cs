using System.Text.Json;

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
    }

    public static class RequestTypes
    {
        public enum ExportType : int
        {
            NewEdition = 1,
            Update = 2,
            Reissue = 3
        };

        public enum SpecificUsage : int
        {
            NavigationalPurposeOverview = 1,
            NavigationalPurposeGeneral = 2,
            NavigationalPurposeCoastal = 3,
            NavigationalPurposeApproach = 4,
            NavigationalPurposeHarbour = 5,
            NavigationalPurposeBerthing = 6,
        };

        public class CreateProductRequest
        {
            public JsonElement Aoi { get; set; }
            public SpecificUsage UsageBand { get; set; }
        }
    }
}