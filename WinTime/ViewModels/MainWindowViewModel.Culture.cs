using System.Threading.Tasks;
using WinTime.Driver.Attributes;

namespace WinTime.ViewModels;

public partial class MainWindowViewModel
{
    private readonly string _facultyHintText;
    private readonly string _groupsHintText;
    private readonly string _startCardMessageText;
    private readonly string _windowTitleText;

    [UnderConstruction]
    private Task InitializeCulture()
    {
        // Call WinTime.Culture assembly.
        // XamlDriver
        //      .GetFacultyHintText(ref ...)
        //      .GetGroupsHintText(ref ...)
        //      .GetWindowTitleText(ref ...)
        //      .[next functional]
        
        return Task.CompletedTask;
    }
    
    #region CultureProperties

    public string FacultyHintText
    {
        get => _facultyHintText;
        init => SetField(ref _facultyHintText, value);
    }

    public string GroupHintText
    {
        get => _groupsHintText;
        init => SetField(ref _groupsHintText, value);
    }

    public string StartCardMessageText
    {
        get => _startCardMessageText;
        init => SetField(ref _startCardMessageText, value);
    }

    public string WindowTitleText
    {
        get => _windowTitleText;
        init => SetField(ref _windowTitleText, value);
    }
    
    #endregion
}