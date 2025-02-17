using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public struct Audience
{
    [JsonPropertyName("id")]   public string Id;
    [JsonPropertyName("name")] public string Name;
}