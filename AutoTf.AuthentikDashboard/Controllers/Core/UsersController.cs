using AutoTf.AuthentikDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthentikDashboard.Controllers.Core;

[ApiController]
[Route("/core/users")]
public class UsersController : AuthentikController
{
    public UsersController(UserManager userManager) : base(userManager) { }
    
    [HttpGet("me")]
    public async Task<ActionResult<string>> Me()
    {
        return await HttpHelper.SendGetString("/api/v3/core/users/me/");
    }
}