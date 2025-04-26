using System.Runtime.InteropServices.JavaScript;

namespace AutoTf.AuthManager.Avalonia;

public static partial class UrlHelper
{
    [JSImport("window.getApiUrl")]
    public static extern string GetApiUrlFromJs();
    
}