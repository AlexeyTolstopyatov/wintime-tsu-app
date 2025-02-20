using System.DirectoryServices;
using WinTime.Config;
using WinTime.Driver.Readers;

namespace WinTime.Models;

public class WinTimeConfigModel
{
    public WinTimeConfigModel()
    {
        WinTimeConfig? instance = new WinTimeConfigManager().Config;
        switch (instance?.ApiUsage)
        {
            case "old":
                Application = UrlApplication.Old;
                Version = UrlApplicationVersion.Version1;
                break;
            case "web":
                Application = UrlApplication.New;
                Version = UrlApplicationVersion.Version1;
                break;
            case "mobile":
                Application = UrlApplication.Mobile;
                Version = UrlApplicationVersion.Version3;
                break;
            default:
                Application = UrlApplication.Old;
                Version = UrlApplicationVersion.Version1;
                break;
        }
    }

    public UrlApplication Application { get; set; }
    public UrlApplicationVersion Version { get; set; }
    public string? FacultyName { get; set; }
    public string? GroupName { get; set; }
}