using System;
using System.Linq;
using WinTime.Driver.Models.OldWeb;

namespace WinTime.Models;

/// <summary>
/// Normalized readonly Lesson model
/// for LessonCard
/// </summary>
public class LessonModel
{
    public LessonModel(Lesson deserialized)
    {
        Title = deserialized.Title;
        LessonType = deserialized.Type == "EMPTY" 
            ? "Пусто" 
            : deserialized.LessonType switch
        {
            "LECTURE" => "Лекция",
            "PRACTICE" => "Практическая работа",
            "EXAM" => "Экзамен",
            "CONSULTATION" => "Консультация",
            "INDIVIDUAL" => "Индивидуальная работа",
            "SEMINAR" => "Семинар",
            "LABORATORY" => "Лабораторная работа",
            "CREDIT" => "Зачёт",
            _ => deserialized.LessonType
        };
        LessonNumber = deserialized
            .LessonNumber
            .ToString();
        Starts = new DateTime()
            .AddHours(7)
            .AddSeconds(deserialized.Starts)
            .ToShortTimeString();
        Ends = new DateTime()
            .AddHours(7)
            .AddSeconds(deserialized.Ends)
            .ToShortTimeString();
        Professor = deserialized.Professor?.FullName;
        Audience = deserialized.Audience?.Name;
        Groups = deserialized.Groups?
            .Select(x => x.Name)
            .Distinct()
            .ToArray();
    }
    
    /// <summary>
    /// Full lesson's name
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// LessonType of LESSON if JSON-Lesson message not empty.
    /// LECTURE, EXAM, CONSULTATION, SEMINAR, LABORATORY, PRACTICE and others...
    /// </summary>
    public string? LessonType { get; set; }

    /// <summary>
    /// Number in timetable.
    /// </summary>
    public string? LessonNumber { get; set; }

    /// <summary>
    /// Array of groups, included to lesson.
    /// </summary>
    public string[]? Groups { get; set; }

    /// <summary>
    /// Professor's Full Name
    /// </summary>
    public string? Professor { get; set; }

    /// <summary>
    /// Audience name. Not contains Building name or number.
    /// </summary>
    public string? Audience { get; set; }

    /// <summary>
    /// Int32 InTime value of lesson's start. It needs to translate into DateTime object
    /// </summary>
    public string? Starts { get; set; }

    /// <summary>
    /// Int32 InTime value of the lesson's end. Also needs to translate into DateTime object
    /// </summary>
    public string? Ends { get; set; }
}