using System.Text.Json.Serialization;

namespace WinTime.Config;

public class WinTimeConfig
{
    [JsonPropertyName("api_usage")] public string? ApiUsage { get; set; }

    [JsonPropertyName("faculty")] public string? Faculty { get; set; }

    [JsonPropertyName("group")] public string? Group { get; set; }
}