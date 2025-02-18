using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public class Professor
{
    [JsonPropertyName("id")] 
    public string Id { get; set; }
    [JsonPropertyName("fullName")] 
    public string FullName { get; set; }
}