using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public class Lesson
{
    /// <summary>
    /// Temporary Authentication hash.
    /// (i suggest it creates on Server-side).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Full lesson's name
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// LessonType of Lesson-JSON message. may be LESSON or EMPTY
    /// for delimiter creation in schedule
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// LessonType of LESSON if JSON-Lesson message not empty.
    /// LECTURE, EXAM, CONSULTATION, SEMINAR, LABORATORY, PRACTICE and others...
    /// </summary>
    [JsonPropertyName("lessonType")]
    public string? LessonType { get; set; }

    /// <summary>
    /// Number in timetable.
    /// </summary>
    [JsonPropertyName("lessonNumber")]
    public int LessonNumber { get; set; }

    /// <summary>
    /// Array of groups, included to lesson.
    /// </summary>
    [JsonPropertyName("groups")]
    public Group[]? Groups { get; set; }

    /// <summary>
    /// Professor structure
    /// </summary>
    [JsonPropertyName("professor")]
    public Professor? Professor { get; set; }

    /// <summary>
    /// Audience structure. Not contains Building name or number.
    /// </summary>
    [JsonPropertyName("audience")]
    public Audience? Audience { get; set; }

    /// <summary>
    /// Int32 InTime value of lesson's start. It needs to translate into DateTime object
    /// </summary>
    [JsonPropertyName("starts")]
    public int Starts { get; set; }

    /// <summary>
    /// Int32 InTime value of the lesson's end. Also needs to translate into DateTime object
    /// </summary>
    [JsonPropertyName("ends")]
    public int Ends { get; set; }
}