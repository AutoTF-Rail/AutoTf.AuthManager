using System.Text.Json.Serialization;

namespace AutoTf.AuthManager.Models.Authentik;

public class Device
{
    [JsonPropertyName("email")]
    public int Email { get; set; }
    
    [JsonPropertyName("pk")]
    public int Pk { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("user")]
    public User User { get; set; }
}