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