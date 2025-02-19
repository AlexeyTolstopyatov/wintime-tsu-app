using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WinTime.Driver.Interfaces;
using WinTime.Driver.Models.OldWeb;
using WinTime.Driver.Providers;
using WinTime.Driver.Readers;
using WinTime.Models;
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
    private bool _allowFaculties;
    private ScheduleModel[] _scheduleByGroup;
    private Group _selectedGroup;
    
    public MainWindowViewModel()
    {
        _allowGroupBox = false;
        _allowFaculties = false;
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
        try
        {
            NotAuthorizedProvider provider = 
                new(UrlApplication.Old, UrlApplicationVersion.Version1);
            List<Faculty> faculties = new();

            provider.FillFaculties(ref faculties);
            Faculties = faculties.ToArray();
            AllowFaculties = true;
        }
        catch (Exception e)
        {
            SelectedGroup = "Нет соединения";
        }

        return Task.CompletedTask;
    }
    
    #region ViewModelCommands
    
    /// <summary>
    /// Calls Task instance for TSU faculties
    /// in another thread.
    /// </summary>
    /// <param name="name"></param>
    private void FacultySelected(string name)
    {
        Task.Run(() => FillFacultiesAsync(name));
    }

    /// <summary>
    /// Calls Task instance for groups faculties
    /// in another thread.
    /// </summary>
    /// <param name="number"></param>
    private void GroupSelected(string number)
    {
        Task.Run(() => FillGroupsAsync(number));
    }
    #endregion
    
    #region ViewModelProperties
    public bool AllowGroupBox
    {
        get => _allowGroupBox;
        set => SetField(ref _allowGroupBox, value);
    }
    public bool AllowFaculties
    {
        get => _allowFaculties;
        set => SetField(ref _allowFaculties, value);
    }
    public ScheduleModel[] ScheduleByGroup
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

    #region AsyncActions
    /// <summary>
    /// Fills Faculties structures array
    /// Or gets Provider instance and calls it for fill faculties.
    /// </summary>
    /// <param name="name"></param>
    private Task FillFacultiesAsync(string name)
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
        return Task.CompletedTask;
    }
    /// <summary>
    /// Fills groups by Faculty ID
    /// Or gets Provider instance and calls it for fill groups.
    /// </summary>
    /// <param name="number"></param>
    private Task FillGroupsAsync(string number)
    {
        SelectedGroup = number;
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

        var normalized =
            from i in days.ToArray()
            select new ScheduleModel(i.Date, i.Lessons);

        // sort not-empty cards
        ScheduleByGroup = normalized.ToArray();
        
        if (days?.Count > 0) AllowGroupBox = true;
        
        return Task.CompletedTask;
    }
    #endregion
}