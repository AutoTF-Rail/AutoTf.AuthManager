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
	
    [HttpGet("/token")]
    public IActionResult Token()
    {
        return File("~/token.html", "text/html");
    }
	
    [HttpGet("/tokenStep")]
    public IActionResult TokenStep()
    {
        string? csrfToken = Request.Query["csrf_token"];

        KeyValuePair<string, string> proxyToken = Request.Cookies.FirstOrDefault(c => c.Key.StartsWith("authentik_proxy"));

        if (!string.IsNullOrEmpty(csrfToken) && !string.IsNullOrEmpty(proxyToken.Key))
        {
            string redirectUrl = $"http://localhost:5000/token?csrf_token={csrfToken}&proxy_name={proxyToken.Key}&proxy_token={proxyToken}";
            return Redirect(redirectUrl);
        }

        return Content("Tokens not found.");
    }
}