using Action = AutoTf.AuthManager.Models.Authentik.Enums.Action;

namespace AutoTf.AuthManager.Models.Authentik;

public class UsedBy
{
    public string App { get; set; }
    public string ModelName { get; set; }
    public string Pk { get; set; }
    public string Name { get; set; }
    public Action Action { get; set; }
}