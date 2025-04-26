using AutoTf.AuthManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Authenticators;

[ApiController]
[Route("/authenticators/endpoint")]
public class EndpointController : AuthentikController
{
    public EndpointController(UserManager userManager) : base(userManager) { }

    [HttpGet]
    public async Task<ActionResult<string>> Get([FromQuery] string name, [FromQuery] string ordering, [FromQuery] int page, [FromQuery(Name = "page_size")] int pageSize, [FromQuery] string search)
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/endpoint/?name={name}&ordering={ordering}&page={page}&page_size={pageSize}&search={search}");
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<string>> Get(int id)
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/email/{id}/");
    }
    
    [HttpGet("{uuid}")]
    public async Task<ActionResult<string>> Get(string uuid)
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/endpoint/{uuid}/", false);
    }
}