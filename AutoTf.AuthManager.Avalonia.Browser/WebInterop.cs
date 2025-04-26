using System.Runtime.InteropServices.JavaScript;

namespace AutoTf.AuthManager.Avalonia.Browser;

public static partial class WebInterop
{
    // This shows an error, but it doesn't actually stop the build, and it works.
    [JSImport("getApiUrl", "main.js")]
    internal static partial string GetApiUrlFromJs();
    
    [JSImport("openNewTab", "main.js")]
    internal static partial string OpenUrl(string url);
}