using System.Text.Json.Serialization;

namespace AutoTf.AuthentikDashboard.Models.Authentik;

public class GroupObj
{
    [JsonPropertyName("pk")]
    public string Pk { get; set; }

    [JsonPropertyName("num_pk")]
    public int NumPk { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("is_superuser")]
    public bool IsSuperuser { get; set; }

    [JsonPropertyName("parent")]
    public object Parent { get; set; }

    [JsonPropertyName("parent_name")]
    public object ParentName { get; set; }

    [JsonPropertyName("attributes")]
    public Dictionary<string, object> Attributes { get; set; }
}