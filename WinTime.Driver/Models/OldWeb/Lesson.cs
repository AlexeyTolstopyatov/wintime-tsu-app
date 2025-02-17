using System.Text.Json.Serialization;

namespace WinTime.Driver.Models.OldWeb;

public struct Lesson
{
    /// <summary>
    /// Temporary Authentication hash.
    /// (i suggest it creates on Server-side).
    /// </summary>
    [JsonPropertyName("id")] public string Id;
    /// <summary>
    /// Full lesson's name
    /// </summary>
    [JsonPropertyName("title")] public string Title;
    /// <summary>
    /// Type of Lesson-JSON message. may be LESSON or EMPTY
    /// for delimiter creation in schedule
    /// </summary>
    [JsonPropertyName("type")] public string MessageType;
    /// <summary>
    /// Type of LESSON if JSON-Lesson message not empty.
    /// LECTURE, EXAM, CONSULTATION, SEMINAR, LABORATORY, PRACTICE and others...
    /// </summary>
    [JsonPropertyName("lessonType")] public string Type;
    /// <summary>
    /// Number in timetable.
    /// </summary>
    [JsonPropertyName("lessonNumber")] public int Number;
    /// <summary>
    /// Array of groups, included to lesson.
    /// </summary>
    [JsonPropertyName("groups")] public Group[] Groups;
    /// <summary>
    /// Professor structure
    /// </summary>
    [JsonPropertyName("professor")] public Professor Professor;
    /// <summary>
    /// Audience structure. Not contains Building name or number.
    /// </summary>
    [JsonPropertyName("audience")] public Audience Audience;
    /// <summary>
    /// Int32 InTime value of lesson's start. It needs to translate into DateTime object
    /// </summary>
    [JsonPropertyName("starts")] public int Starts;
    /// <summary>
    /// Int32 InTime value of the lesson's end. Also needs to translate into DateTime object
    /// </summary>
    [JsonPropertyName("ends")] public int Ends;
}