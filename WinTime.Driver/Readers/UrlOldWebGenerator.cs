using WinTime.Driver.Attributes;
using WinTime.Driver.Interfaces;

namespace WinTime.Driver.Readers;

public class UrlOldWebGenerator : IUrlGenerator
{
    private readonly string _application = UrlFactory.MakeUrl(
        UrlApplication.Old,
        UrlApplicationVersion.Version1,
        string.Empty
    );
    
    public string GetFacultiesString()
    {
        return _application + "faculties";
    }

    public string GetBuildingsString()
    {
        throw new NotImplementedException();
    }
    
    public string GetProfessorsString()
    {
        return _application + "professors";
    }

    public string GetGroupsByFacultyIdString(string key)
    {
        return _application + $"faculties/{key}/groups";
    }
    [UnderConstruction]
    public string GetScheduleByGroupIdString(string key)
    {
        (string from, string to) dates = WeekRangeFromCurrentDate();
        return _application + $"schedule/group?id={key}&dateFrom={dates.from}&dateTo={dates.to}";
    }
    [UnderConstruction]
    private (string, string) WeekRangeFromCurrentDate()
    {
        DateTime date = DateTime.Now;
        date = date.Date;
        int dayOfWeek = (int)date.DayOfWeek - 1;
        if (dayOfWeek < 0)
            dayOfWeek = 6;
        
        DateTime begin = date.AddDays(-dayOfWeek);
        DateTime end = begin.AddDays(6);
        
        string startWeek = begin.ToString("yyyy-MM-dd");
        string endWeek = end.ToString("yyyy-MM-dd");
        return (startWeek, endWeek);
    }
    
    [UnderConstruction]
    public string GetScheduleByProfessorIdString(string key)
    {
        (string from, string to) = WeekRangeFromCurrentDate();
        return _application + $"professor&id={key},dateFrom={from}&dateTo={to}";
    }

    public string GetAudiencesByBuildingIdString(string key)
    {
        return _application + $"buildings/{key}/audiences";
    }
    [UnderConstruction]
    public string GetScheduleByAudienceIdString(string key)
    {
        (string from, string to) = WeekRangeFromCurrentDate();
        return $"audience?id={key}&dateFrom={from}&dateTo={to}";
    }
}