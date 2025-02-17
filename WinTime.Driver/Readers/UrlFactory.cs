namespace WinTime.Driver.Readers;
/// <summary>
/// Uses by Factory methods for simplify
/// generation InTime server strings 
/// </summary>
public enum UrlApplication
{
    /// <summary>
    /// Old TSU InTime application uses with version 1
    /// and at the moment of 2024-25 years default website uses old API
    /// </summary>
    Old,
    /// <summary>
    /// New TSU InTime application uses with different versions like "Mobile".
    /// At the moment of 2024-2025 years Tomsk State University has second
    /// website with global schedule and other features, became available
    /// at Feb 2025. (as i've seen)...
    /// </summary>
    New,
    /// <summary>
    /// Tomsk State University has mobile application with shorten data
    /// about student's statistic. "Mobile" application's API represented
    /// for Android/iOS platforms (.apk/.ipa packages, not website)
    /// </summary>
    Mobile
}
/// <summary>
/// Uses by Factory methods for simplify generation
/// InTime server strings
/// </summary>
public enum UrlApplicationVersion
{
    Version1,
    Version2,
    Version3
}

/// <summary>
/// Represents Application's endpoints maker for
/// every goal.
/// </summary>
public sealed class UrlFactory
{
    /// <summary>
    /// Makes url till needed function on InTime server
    /// </summary>
    /// <param name="api"></param>
    /// <param name="ver"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string MakeUrl(UrlApplication api, UrlApplicationVersion ver, string path)
    {
        string url = "https://intime.tsu.ru/api/";

        url += api switch
        {
            UrlApplication.Old => "old-web/",
            UrlApplication.New => "web/",
            UrlApplication.Mobile => "mobile/",
            _ => "old-web/"
        };

        url += ver switch
        {
            UrlApplicationVersion.Version1 => "v1/",
            UrlApplicationVersion.Version2 => "v2/",
            UrlApplicationVersion.Version3 => "v3/",
            _ => "v1/"
        };

        url += path;
        return url;
    }
}