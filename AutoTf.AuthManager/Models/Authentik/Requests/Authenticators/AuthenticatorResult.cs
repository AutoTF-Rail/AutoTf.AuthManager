using System.Text.Json.Serialization;

namespace AutoTf.AuthManager.Models.Authentik.Requests.Authenticators;

public class AuthenticatorResult
{
    [JsonPropertyName("pagination")]
    public Pagination Pagination { get; set; }

    [JsonPropertyName("results")]
    public List<Device> Results { get; set; }
}