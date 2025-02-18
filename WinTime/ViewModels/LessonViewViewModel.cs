using System;
using System.Linq;
using WinTime.Driver.Models.OldWeb;

namespace WinTime.ViewModels;

public class LessonViewViewModel : NotifyPropertyChanged
{
    private string _title;
    private string _type;
    private string _starts;
    private string _ends;
    private string _professor;
    private string _audience;
    private string[] _groups;
    private string _number;

    public LessonViewViewModel()
    {
        
    }

    public LessonViewViewModel(Lesson lesson)
    {
        _title = "Нет пары";
        _ends = new DateTime().AddSeconds(lesson.Ends).ToShortTimeString();
        _starts = new DateTime().AddSeconds(lesson.Starts).ToShortTimeString();
        _number = lesson.LessonNumber.ToString();

        if (lesson.Type == "EMPTY") return; // force exit when no lesson.
        
        _audience = lesson.Audience.Name;
        _professor = lesson.Professor.FullName;
        _groups = lesson.Groups.Select(x => x.Name).ToArray();
        _title = lesson.Title;
        _type = lesson.LessonType;
    }
    
    #region ViewModel Properties
    public string Title
    {
        get => _title;
        set => SetField(ref _title, value);
    }

    public string Type
    {
        get => _type;
        set => SetField(ref _type, value);
    }

    public string Starts
    {
        get => _starts;
        set => SetField(ref _starts, value);
    }

    public string Ends
    {
        get => _ends;
        set => SetField(ref _ends, value);
    }

    public string Professor
    {
        get => _professor;
        set => SetField(ref _professor, value);
    }

    public string Audience
    {
        get => _audience;
        set => SetField(ref _audience, value);
    }

    public string[] Groups
    {
        get => _groups;
        set => SetField(ref _groups, value);
    }

    public string Number
    {
        get => _number;
        set => SetField(ref _number, value);
    }
    #endregion
}