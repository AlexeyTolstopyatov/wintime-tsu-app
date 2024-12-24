using MicaWPF.Core.Interop;

namespace WinTime.Driver;

/// <summary>
/// Represents API for InTime server
/// I try to implement InTime API here.
/// <seealso href="https://miniapps.intime.tsu.ru/docs/docs/libraries/tsu-intime-bridge/"/>>
/// </summary>
public class InTimeDriver
{
    private InTimeDriver? DriverInstance { get; set; }

    /// <summary>
    /// Singleton pattern usage, just because
    /// Only one instance of TSU API driver needed
    /// </summary>
    /// <returns></returns>
    public InTimeDriver Call()
    {
        return DriverInstance ??= new InTimeDriver();
    }
    
    
}