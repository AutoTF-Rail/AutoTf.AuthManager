using System.Text.Json.Serialization;

namespace AutoTf.AuthentikDashboard.Models.Authentik;

public class Pagination
{
    [JsonPropertyName("next")]
    public int Next { get; set; }

    [JsonPropertyName("previous")]
    public int Previous { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("current")]
    public int Current { get; set; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("start_index")]
    public int StartIndex { get; set; }

    [JsonPropertyName("end_index")]
    public int EndIndex { get; set; }
}