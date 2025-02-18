using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public class Group
{
    [JsonPropertyName("id")] 
    public string Id { get; set; }
    [JsonPropertyName("name")] 
    public string Name { get; set; }
    [JsonPropertyName("isSubgroup")] 
    public bool IsSubgroup { get; set; }
}