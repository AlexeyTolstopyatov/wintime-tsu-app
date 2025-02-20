using System;
using System.Linq;
using WinTime.Driver.Models.OldWeb;

namespace WinTime.Models;

public class ScheduleModel
{
    public ScheduleModel(string date, Lesson[] lessons)
    {
        Date = DateOnly.Parse(date)
            .DayOfWeek
            .ToString();
        
        var iterates = 
            from i in lessons
            where i.Type != "EMPTY"
            select new LessonModel(i);
        
        Lessons = iterates.ToArray();
    }
    
    public string? Date { get; set; }
    public LessonModel[]? Lessons { get; set; }
}