using System.Net.Http.Json;
using WinTime.Driver.Attributes;
using WinTime.Driver.Interfaces;
using WinTime.Driver.Readers;

namespace WinTime.Driver.Providers;

/// <summary>
/// Represents API without TSU Account
/// integration features. (Not allowed to see Marks and other personal data)
///
/// Long time will be as default, just because TSU InTime has cascade authentication
/// and I can't catch needed token for get personal information.
/// </summary>
public class NotAuthorizedProvider : IMessageWriter
{
    private readonly IUrlGenerator _generator;
    
    [UnderConstruction]
    public NotAuthorizedProvider(UrlApplication app, UrlApplicationVersion ver)
    {
        _generator = app switch
        {
            UrlApplication.New => new UrlWebGenerator(),
            UrlApplication.Mobile => new UrlWebGenerator(),
            _ => new UrlOldWebGenerator()
        };
    }

    /// <summary>
    /// Creates Http GET request and
    /// deserializes JSON response message.
    /// </summary>
    /// <param name="faculties">Expected result NOT <see cref="Nullable{T}"/></param>
    /// <returns>Filled collection by pointer</returns>
    /// <exception cref="Exception">
    /// Throws exceptions if something went wrong.
    /// HANDLE it IN CLIENT part.
    /// </exception>
    public IMessageWriter FillFaculties<TStruct>(ref TStruct faculties)
    {
        string endpoint = _generator.GetFacultiesString();
        
        HttpClient client = new();
        var request = 
            client.GetAsync(endpoint);
            
        request.Result.EnsureSuccessStatusCode();

        var response = 
            request.Result.Content.ReadFromJsonAsync<TStruct>();
            
        faculties = response.Result!;
        
        return this;
    }
    /// <summary>
    /// Fills Building structure by pointer.
    /// </summary>
    /// <param name="buildings"></param>
    /// <typeparam name="TStruct"></typeparam>
    /// <returns></returns>
    public IMessageWriter FillBuildings<TStruct>(ref TStruct buildings)
    {
        string endpoint = _generator.GetBuildingsString();
        HttpClient client = new();
        var request = 
            client.GetAsync(endpoint);
            
        request.Result.EnsureSuccessStatusCode();

        var response = 
            request.Result.Content.ReadFromJsonAsync<TStruct>();
            
        buildings = response.Result!;
        
        return this;
    }
    /// <summary>
    /// Fills structure by pointer
    /// </summary>
    /// <param name="professors"></param>
    /// <typeparam name="TStruct"></typeparam>
    /// <returns></returns>
    public IMessageWriter FillProfessors<TStruct>(ref TStruct professors)
    {
        string endpoint = _generator.GetProfessorsString();
        HttpClient client = new();
        var request = 
            client.GetAsync(endpoint);
            
        request.Result.EnsureSuccessStatusCode();

        var response = 
            request.Result.Content.ReadFromJsonAsync<TStruct>();
            
        if (response.Result is not null)
            professors = response.Result;
        
        return this;
    }
    /// <summary>
    /// Fills groups array by pointer
    /// </summary>
    /// <param name="groups"></param>
    /// <param name="id"></param>
    /// <typeparam name="TStruct"></typeparam>
    /// <returns></returns>
    public IMessageWriter FillGroupsByFId<TStruct>(ref TStruct groups, string id)
    {
        string endpoint = _generator.GetGroupsByFacultyIdString(id);
        HttpClient client = new();
        var request = 
            client.GetAsync(endpoint);
            
        request.Result.EnsureSuccessStatusCode();

        var response = 
            request.Result.Content.ReadFromJsonAsync<TStruct>();
        
        // groups already not null. Referenced types are not null here.
        groups = response.Result!;
        
        return this;
    }
    /// <summary>
    /// Fills timetable by pointer
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [UnderConstruction]
    public IMessageWriter FillScheduleByGId<TSchedule>(ref TSchedule schedule, string id)
    {
        string endpoint = _generator.GetScheduleByGroupIdString(id);
        HttpClient client = new();
        var request = 
            client.GetAsync(endpoint);
            
        request.Result.EnsureSuccessStatusCode();

        var response = 
            request.Result.Content.ReadFromJsonAsync<TSchedule>();
        
        schedule = response.Result!;
        
        return this;
    }
}