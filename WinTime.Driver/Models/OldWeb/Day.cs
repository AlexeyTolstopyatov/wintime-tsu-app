using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public class Day
{
    /// <summary>
    /// Data of day in timetable
    /// </summary>
    [JsonPropertyName("date")] 
    public string Date { get; init; } = string.Empty;
    
    /// <summary>
    /// Represents always initialized array segment
    /// of Lessons
    /// </summary>
    [JsonPropertyName("lessons")]
    public Lesson[] Lessons { get; init; } = Array.Empty<Lesson>();
}