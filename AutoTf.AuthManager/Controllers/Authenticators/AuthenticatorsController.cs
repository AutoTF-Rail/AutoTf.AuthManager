using AutoTf.AuthManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Authenticators;

[ApiController]
[Route("/authenticators")]
public class AuthenticatorsController : AuthentikController
{
    public AuthenticatorsController(UserManager userManager) : base(userManager) { }

    [HttpGet("all")]
    public async Task<ActionResult<string>> All()
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/admin/all/?user={UserId}");
    }
}