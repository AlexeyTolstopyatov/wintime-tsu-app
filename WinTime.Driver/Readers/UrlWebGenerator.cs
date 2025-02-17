using WinTime.Driver.Attributes;
using WinTime.Driver.Interfaces;

namespace WinTime.Driver.Readers;

[UnderConstruction]
public class UrlWebGenerator : IUrlGenerator
{
    public string GetFacultiesString()
    {
        throw new NotImplementedException();
    }

    public string GetBuildingsString()
    {
        throw new NotImplementedException();
    }

    public string GetProfessorsString()
    {
        throw new NotImplementedException();
    }

    public string GetGroupsByFacultyIdString(string key)
    {
        throw new NotImplementedException();
    }

    public string GetScheduleByGroupIdString(string key)
    {
        throw new NotImplementedException();
    }

    public string GetScheduleByProfessorIdString(string key)
    {
        throw new NotImplementedException();
    }

    public string GetAudiencesByBuildingIdString(string key)
    {
        throw new NotImplementedException();
    }
}