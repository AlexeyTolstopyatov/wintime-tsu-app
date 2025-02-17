using WinTime.Driver.Attributes;

namespace WinTime.Driver.Interfaces;

/// <summary>
/// Represent common API for InTime Message-writers
/// Message writer is an entity which deserializes
/// JSON messages from InTime Server. 
/// </summary>
[UnderConstruction]
public interface IMessageWriter
{
    /// <summary>
    /// Fills Faculties-information array
    /// </summary>
    /// <returns></returns>
    IMessageWriter FillFaculties<TStruct>(ref TStruct faculties);
    /// <summary>
    /// Fills Buildings-information array
    /// </summary>
    /// <returns></returns>
    IMessageWriter FillBuildings<TStruct>(ref TStruct buildings);
    /// <summary>
    /// Fills Professors array
    /// </summary>
    /// <returns></returns>
    IMessageWriter FillProfessors<TStruct>(ref TStruct professors);
    /// <summary>
    /// Fills Groups array by Faculty's ID
    /// </summary>
    /// <returns></returns>
    IMessageWriter FillGroupsByFId<TStruct>(ref TStruct groups, string id);
    /// <summary>
    /// Fills Schedule table by registered group's ID
    /// </summary>
    /// <returns></returns>
    IMessageWriter FillScheduleByGId<TSchedule>(ref TSchedule schedule, string id);
}