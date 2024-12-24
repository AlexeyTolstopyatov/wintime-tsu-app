using System.IO;

namespace WinTime.Driver;

public enum InTimeNotificationType : byte
{
    Success,
    Warning,
    Error,
    Info,
}