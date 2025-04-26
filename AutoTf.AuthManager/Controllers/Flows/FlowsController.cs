using AutoTf.AuthManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Flows;

[ApiController]
[Route("/flows")]
public class FlowsController : AuthentikController
{
    public FlowsController(UserManager userManager) : base(userManager) { }

    [HttpGet("-/configure/{flowId}")]
    public ActionResult RedirectToFlow(string flowId)
    {
        return RedirectPermanent(Statics.AuthUrl + $"/flows/-/configure/{flowId}/");
    }
}