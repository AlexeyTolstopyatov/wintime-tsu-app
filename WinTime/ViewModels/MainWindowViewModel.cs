using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Input;
using Accessibility;
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
    
    public MainWindowViewModel()
    {
        _allowGroupBox = false;
        _facultySelectionCommand = new RelayCommand<string>(FacultySelected!);
        _groupSelectionCommand = new RelayCommand<string>(GroupSelected!);
        _ = InitializeCulture();
        _ = InitializeModel();
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
        Console.Write("FacultySelected: ");
        // get by key [name]
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
        
        Console.WriteLine($"groups={groups.Count}");
    }

    /// <summary>
    /// Makes timetable
    /// </summary>
    /// <param name="number"></param>
    private void GroupSelected(string number)
    {
        // remember: number takes from XAML bindings
        // (QuerySubmitted.QueryText{ get; set; })
        SelectedGroup = number;
        Console.Write("GroupSelected: ");
        
        // get by key [name]
        string id = Groups
            .Where(x => x.Name == number)
            .Select(x =>
            {
                _selectedGroup = x;
                return x.Id;
            })
            .First();
        
        // name takes from View ware.
        List<Day> days = new();
        IMessageWriter provider = 
            new NotAuthorizedProvider(UrlApplication.Old, UrlApplicationVersion.Version1)
                .FillScheduleByGId(ref days, id);
        
        ScheduleByGroup = days.ToArray();

        if (days.Count > 0)
            AllowGroupBox = true;
        
        Console.WriteLine($"days={days.Count}");
        foreach (var day in ScheduleByGroup)
        foreach (var lesson in day.Lessons)
        {
            Console.WriteLine($"{day.Date}\t({lesson.Type}){lesson.Title}");
        }
    }
    #endregion
    
    #region ViewModelProperties
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