using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace WinTime.Model;

public sealed class GroupsCollection : ObservableCollection<InTimeObject>
{
    [JsonPropertyName("isSubgroup")]
    public bool IsSubgroup { get; set; }
}