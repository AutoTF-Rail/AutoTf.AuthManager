using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoTf.AuthentikDashboard.Models.Authentik;

/// <summary>
/// I honestly don't know why this is called a user setting, but it's requested under the endpoint /stages/all/user_settings.
/// And the password stage is magically not shown.
/// </summary>
public class UserSetting
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("component")]
    public string Component { get; set; }
    
    [JsonPropertyName("object_uid")]
    public string ObjectUid { get; set; }
    
    [JsonPropertyName("configure_url")]
    public string ConfigureUrl { get; set; }
    
    public static UserSetting Serialize(JsonElement item)
    {
        return new UserSetting()
        {
            Title = item.GetProperty("title").GetString() ?? "Unknown",
            Component = item.GetProperty("component").GetString() ?? "Unknown",
            ObjectUid = item.GetProperty("object_uid").GetString() ?? "Unknown",
            ConfigureUrl = item.GetProperty("configure_url").GetString() ?? "Unknown",
        };
    }
}