namespace WinTime.Driver;

public enum InTimeMessageType
{
    /// <summary>
    /// I apologise, ShowNotification needs to determine
    /// banners signal handling
    /// </summary>
    ShowNotification,
    
    /// <summary>
    /// Open TSU another resources from page
    /// </summary>
    OpenUri,
    
    /// <summary>
    /// ??? I dont know why. May be it calls handler insight server
    /// for preparing image or some previews for link sharing.
    /// </summary>
    Share
}