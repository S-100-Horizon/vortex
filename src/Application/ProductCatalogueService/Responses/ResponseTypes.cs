namespace ProductCatalogueService
{
    public static class ResponseTypes {
        public class ApiResponse<T>
        {
            public T? Data { get; set; }
            public bool Success { get; set; } = true;
            public string? Message { get; set; }
            public int? TotalHits { get; set; }
            public double? DurationMs { get; set; }
            public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        }
    }
}