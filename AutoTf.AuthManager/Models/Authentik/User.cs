using System.Text.Json.Serialization;

namespace AutoTf.AuthManager.Models.Authentik;

public class User
{
    [JsonPropertyName("pk")]
    public int Pk { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    [JsonPropertyName("last_login")]
    public object LastLogin { get; set; }

    [JsonPropertyName("is_superuser")]
    public bool IsSuperuser { get; set; }

    [JsonPropertyName("groups")]
    public List<string> Groups { get; set; }

    [JsonPropertyName("groups_obj")]
    public List<GroupObj> GroupsObj { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("avatar")]
    public string Avatar { get; set; }

    [JsonPropertyName("attributes")]
    public Dictionary<string, object> Attributes { get; set; }

    [JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    [JsonPropertyName("password_change_date")]
    public DateTime PasswordChangeDate { get; set; }
}