using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public class Audience
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
}