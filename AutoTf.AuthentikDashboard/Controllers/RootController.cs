using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthentikDashboard.Controllers;

[ApiController]
[Route("/")]
public class RootController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}