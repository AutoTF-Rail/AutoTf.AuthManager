using System.Text.Json.Serialization;

namespace AutoTf.AuthManager.Models.Authentik;

public class TotpDevice
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
    public DateTime Created { get; set; }

    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonPropertyName("last_used")]
    public DateTime LastUsed { get; set; }

    [JsonPropertyName("extra_description")]
    public string ExtraDescription { get; set; }
}