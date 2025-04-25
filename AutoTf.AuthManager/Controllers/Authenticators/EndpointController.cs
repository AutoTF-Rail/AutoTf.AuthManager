using AutoTf.AuthManager.Models;
using AutoTf.AuthManager.Models.Authentik;
using AutoTf.AuthManager.Models.Authentik.Requests.Authenticators;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Authenticators;

[ApiController]
[Route("/authenticators/endpoint")]
public class EndpointController : AuthentikController
{
    public EndpointController(UserManager userManager) : base(userManager) { }

    [HttpGet]
    public async Task<ActionResult<AuthenticatorResult>> Get([FromQuery] string name, [FromQuery] string ordering, [FromQuery] int page, [FromQuery(Name = "page_size")] int pageSize, [FromQuery] string search)
    {
        return await HttpHelper.SendGet<AuthenticatorResult>($"/api/v3/authenticators/endpoint/?name={name}&ordering={ordering}&page={page}&page_size={pageSize}&search={search}") ?? new AuthenticatorResult();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Device>> Get(int id)
    {
        return await HttpHelper.SendGet<Device>($"/api/v3/authenticators/email/{id}/") ?? new Device();
    }
    
    [HttpGet("{uuid}")]
    public async Task<ActionResult<Device>> Get(string uuid)
    {
        return await HttpHelper.SendGet<Device>($"/api/v3/authenticators/endpoint/{uuid}/", false) ?? new Device();
    }
}