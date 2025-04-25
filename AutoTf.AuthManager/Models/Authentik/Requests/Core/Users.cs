using System.Text.Json.Serialization;

namespace AutoTf.AuthManager.Models.Authentik.Requests.Core;

public class Users
{
    [JsonPropertyName("pagination")]
    public Pagination Pagination { get; set; }

    [JsonPropertyName("results")]
    public List<User> Results { get; set; }
}