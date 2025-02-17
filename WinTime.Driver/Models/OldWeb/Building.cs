using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public struct Building
{
    [JsonPropertyName("id")] public string Id;
    [JsonPropertyName("name")] public string Name;
}