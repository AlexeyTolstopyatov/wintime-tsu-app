namespace WinTime.Driver.Interfaces;

/// <summary>
/// Provides Common API for every application's type.
/// Not includes Authorized features (when TSU.Account authorization exists)
/// </summary>
public interface IUrlGenerator
{
    /// <summary>
    /// Returns Faculties endpoint
    /// </summary>
    /// <returns></returns>
    string GetFacultiesString();
    /// <summary>
    /// Returns Buildings string
    /// </summary>
    /// <returns></returns>
    string GetBuildingsString();
    /// <summary>
    /// Returns Professors endpoint
    /// </summary>
    /// <returns></returns>
    string GetProfessorsString();
    /// <summary>
    /// Returns Groups endpoint, using known Faculty ID
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string GetGroupsByFacultyIdString(string key);
    /// <summary>
    /// Returns Schedule endpoint, using known Group ID
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string GetScheduleByGroupIdString(string key);
    /// <summary>
    /// Returns Schedule endpoint, using known Professor ID 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string GetScheduleByProfessorIdString(string key);
    /// <summary>
    /// Returns Audiences endpoint, using known Building's ID
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    string GetAudiencesByBuildingIdString(string key);
}