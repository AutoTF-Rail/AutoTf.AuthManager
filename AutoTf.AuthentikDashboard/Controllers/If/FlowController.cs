using AutoTf.AuthentikDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthentikDashboard.Controllers.If;

[ApiController]
[Route("/if/flow")]
public class FlowController : AuthentikController
{
    public FlowController(UserManager userManager) : base(userManager) { }

    [HttpGet("{slug}")]
    public IActionResult RedirectToFlow(string slug, [FromQuery] string next = "")
    {
        return RedirectPermanent(Statics.AuthUrl + $"/if/flow/{slug}/?next={next}/");
    }
}