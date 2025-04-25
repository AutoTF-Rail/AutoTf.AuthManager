using AutoTf.AuthManager.Models;
using AutoTf.AuthManager.Models.Authentik;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Authenticators;

[ApiController]
[Route("/authenticators")]
public class AuthenticatorsController : AuthentikController
{
    public AuthenticatorsController(UserManager userManager) : base(userManager) { }

    [HttpGet("all")]
    public async Task<ActionResult<List<TotpDevice>>> All()
    {
        return await HttpHelper.SendGet<List<TotpDevice>>($"/api/v3/authenticators/admin/all/?user={UserId}") ?? [];
    }
}