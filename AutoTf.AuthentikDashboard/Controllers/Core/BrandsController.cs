using AutoTf.AuthentikDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthentikDashboard.Controllers.Core;

[ApiController]
[Route("/core/brands")]
public class BrandsController : AuthentikController
{
    public BrandsController(UserManager userManager) : base(userManager) { }

    [HttpGet("current")]
    public async Task<ActionResult<string>> Current()
    {
        return await HttpHelper.SendGetString("/core/brands/current/");
    }
}