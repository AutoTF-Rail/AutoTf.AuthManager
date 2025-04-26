using System.Text.Json;
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
    public DateTime? Created { get; set; }

    [JsonPropertyName("last_updated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("last_used")]
    public DateTime? LastUsed { get; set; }

    [JsonPropertyName("extra_description")]
    public string ExtraDescription { get; set; }

    public static TotpDevice Serialize(JsonElement item)
    {
        DateTime? finalCreated = null;
        if (item.GetProperty("created").TryGetDateTime(out DateTime created))
            finalCreated = created;
        
        DateTime? finalLastUpdate = null;
        if (item.GetProperty("last_updated").TryGetDateTime(out DateTime lastUpdate))
            finalLastUpdate = lastUpdate;
        
        DateTime? finalLastUsed = null;
        if (item.GetProperty("last_used").TryGetDateTime(out DateTime lastUsed))
            finalLastUsed = lastUsed;
            
        return new TotpDevice()
        {
            VerboseName = item.GetProperty("verbose_name").GetString() ?? "Unknown",
            VerboseNamePlural = item.GetProperty("verbose_name_plural").GetString() ?? "Unknown",
            MetaModelName = item.GetProperty("meta_model_name").GetString() ?? "Unknown",
            Pk = item.GetProperty("pk").GetString() ?? "Unknown",
            Name = item.GetProperty("name").GetString() ?? "Unknown",
            Type = item.GetProperty("type").GetString() ?? "Unknown",
            Confirmed = item.GetProperty("confirmed").GetBoolean(),
            Created = finalCreated,
            LastUpdated = finalLastUpdate,
            LastUsed = finalLastUsed,
            ExtraDescription = item.GetProperty("extra_description").GetString() ?? "Unknown"
        };
    }
}