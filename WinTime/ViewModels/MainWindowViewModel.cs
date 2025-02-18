using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using WinTime.Driver.Interfaces;
using WinTime.Driver.Models.OldWeb;
using WinTime.Driver.Providers;
using WinTime.Driver.Readers;
using WinTime.Models;
using Wpf.Ui.Controls;
using Wpf.Ui.Input;

namespace WinTime.ViewModels;

public partial class MainWindowViewModel : NotifyPropertyChanged
{
    private ICommand _facultySelectionCommand;
    private ICommand _groupSelectionCommand;
    private Faculty[] _faculties;
    private Group[] _groups;
    private Faculty _selectedFacultyString;
    private string _selectedGroupString;
    private bool _allowGroupBox;
    private Day[] _scheduleByGroup;
    private Group _selectedGroup;
    private ICommand _testScheduleCommand;
    
    public MainWindowViewModel()
    {
        _allowGroupBox = false;
        _facultySelectionCommand = new RelayCommand<string>(FacultySelected!);
        _groupSelectionCommand = new RelayCommand<string>(GroupSelected!);
        _testScheduleCommand = new RelayCommand<object>(TestSchedule!);
        _ = InitializeCulture();
        //_ = InitializeModel();
    }

    /// <summary>
    /// Creates basics of MainWindowViewModel
    /// </summary>
    /// <returns></returns>
    private Task InitializeModel()
    {
        Console.Write("InitializeModel: ");
        NotAuthorizedProvider provider = new(UrlApplication.Old, UrlApplicationVersion.Version1);
        List<Faculty> faculties = new();
        
        provider.FillFaculties(ref faculties);
        Faculties = faculties.ToArray();
        
        Console.WriteLine($"faculties={faculties.Count}");
        return Task.CompletedTask;
    }
    
    #region ViewModelCommands
    /// <summary>
    /// Fills groups by Faculty ID
    /// Or gets Provider instance and calls it for fill groups.
    /// </summary>
    /// <param name="name"></param>
    private void FacultySelected(string name)
    {
        string id = Faculties
            .Where(x => x.Name == name)
            .Select(x =>
            {
                _selectedFacultyString = x;
                return x.Id;
            })
            .First();
        
        // name takes from View ware.
        List<Group> groups = new();
        IMessageWriter provider = 
            new NotAuthorizedProvider(UrlApplication.Old, UrlApplicationVersion.Version1)
            .FillGroupsByFId(ref groups, id);
        Groups = groups.ToArray();

        if (groups.Count > 0)
            AllowGroupBox = true;
    }

    /// <summary>
    /// Makes timetable
    /// </summary>
    /// <param name="number"></param>
    private void GroupSelected(string number)
    {
        SelectedGroup = number;
        Console.Write("GroupSelected: ");
        
        string id = Groups
            .Where(x => x.Name == number)
            .Select(x =>
            {
                _selectedGroup = x;
                return x.Id;
            })
            .First();
        
        List<Day> days = new();
        IMessageWriter provider = 
            new NotAuthorizedProvider(UrlApplication.Old, UrlApplicationVersion.Version1)
                .FillScheduleByGId(ref days, id);
        
        ScheduleByGroup = days.ToArray();

        if (days.Count > 0)
            AllowGroupBox = true;
        
        Console.WriteLine($"days={days.Count}");
        foreach (Day day in ScheduleByGroup)
        foreach (Lesson lesson in day.Lessons)
        {
            Console.WriteLine($"{day.Date}\t({lesson.LessonType}){lesson.Title}");
        }
    }

    /// <summary>
    /// Test #18
    /// Deserialization & Viewing given not-null schedule JSON 
    /// </summary>
    private void TestSchedule(object unused)
    {
        // C:\schedule.json
        string filePath = @"C:\Users\MagicBook\Desktop\schedule.json";

        string json = File.ReadAllText(filePath);
        
        List<Day>? daysList = new();
        daysList = JsonSerializer.Deserialize<List<Day>>(json);

        ScheduleByGroup = daysList!.ToArray();
    }
    
    #endregion
    
    #region ViewModelProperties

    public ICommand TestScheduleCommand
    {
        get => _testScheduleCommand;
        set => SetField(ref _testScheduleCommand, value);
    }
    
    public bool AllowGroupBox
    {
        get => _allowGroupBox;
        set => SetField(ref _allowGroupBox, value);
    }

    public Day[] ScheduleByGroup
    {
        get => _scheduleByGroup;
        set => SetField(ref _scheduleByGroup, value);
    }
    public string SelectedGroup
    {
        get => _selectedGroupString;
        set => SetField(ref _selectedGroupString, value);
    }
    public ICommand FacultySelectionCommand
    {
        get => _facultySelectionCommand;
        set => SetField(ref _facultySelectionCommand, value);
    }

    public ICommand GroupSelectionCommand
    {
        get => _groupSelectionCommand;
        set => SetField(ref _groupSelectionCommand, value);
    }

    public Faculty[] Faculties
    {
        get => _faculties;
        set => SetField(ref _faculties, value);
    }

    public Group[] Groups
    {
        get => _groups;
        set => SetField(ref _groups, value);
    }

    #endregion
}