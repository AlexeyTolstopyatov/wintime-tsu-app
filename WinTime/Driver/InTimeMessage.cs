namespace WinTime.Driver;

/// <summary>
/// Represents Structure of JSON message from InTime server
/// <see href="https://www.npmjs.com/package/@tsu.intime/tsu-intime-bridge"/>
/// </summary>
public class InTimeMessage
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public InTimeMessageType? Type { get; set; }
}

public class InTimeOpenUriMessage
{
    public string? Uri { get; set; }
}

public class InTimeShareMessage
{
    public string? Text { get; set; }
    
    // Fixme: Unknown type of Attachments inside InTime JS library
    public object? Attachments { get; set; }
}