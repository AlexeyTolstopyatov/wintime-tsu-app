using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public struct Professor
{
    [JsonPropertyName("id")] public string Id;
    [JsonPropertyName("fullName")] public string FullName;
}