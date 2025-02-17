using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public class Faculty
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
}