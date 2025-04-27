using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoTf.AuthentikDashboard.Models.Authentik;

public class MfaDevice
{
    [JsonPropertyName("verbose_name")]
    public string VerboseName { get; set; }

    [JsonPropertyName("verbose_name_plural")]
    public string VerboseNamePlural { get; set; }

    [JsonPropertyName("meta_model_name")]
    public string MetaModelName { get; set; }

    [JsonPropertyName("pk")]
    public string Pk { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("confirmed")]
    public bool Confirmed { get; set; }

    [JsonPropertyName("created")]
    public string? Created { get; set; }

    [JsonPropertyName("last_updated")]
    public string? LastUpdated { get; set; }

    [JsonPropertyName("last_used")]
    public string? LastUsed { get; set; }

    [JsonPropertyName("extra_description")]
    public string ExtraDescription { get; set; }

    public static MfaDevice Serialize(JsonElement item)
    {
        return new MfaDevice()
        {
            VerboseName = item.GetProperty("verbose_name").GetString() ?? "Unknown",
            VerboseNamePlural = item.GetProperty("verbose_name_plural").GetString() ?? "Unknown",
            MetaModelName = item.GetProperty("meta_model_name").GetString() ?? "Unknown",
            Pk = item.GetProperty("pk").GetString() ?? "Unknown",
            Name = item.GetProperty("name").GetString() ?? "Unknown",
            // Maybe remove this and do that via a converted?
            Type = item.GetProperty("type").GetString()?.Split('.')[1] ?? "Unknown",
            Confirmed = item.GetProperty("confirmed").GetBoolean(),
            Created = item.GetProperty("created").GetString() ?? "Unknown",
            LastUpdated = item.GetProperty("last_updated").GetString() ?? "Unknown",
            LastUsed = item.GetProperty("last_used").GetString() ?? "Unknown",
            ExtraDescription = item.GetProperty("extra_description").GetString() ?? "Unknown"
        };
    }
    
    /// <summary>
    /// Only for the UI
    /// </summary>
    public bool IsChecked { get; set; }
}