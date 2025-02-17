using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public class Day
{
    public Day(string date, Lesson[] lessons)
    {
        this.Date = date;
        this.Lessons = lessons;
    }
    
    [JsonPropertyName("date")]
    public string Date { get; set; }
    [JsonPropertyName("lessons")]
    public Lesson[] Lessons { get; set; }
}