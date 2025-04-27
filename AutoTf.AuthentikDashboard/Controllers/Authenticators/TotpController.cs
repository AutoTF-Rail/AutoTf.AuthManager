using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoTf.AuthentikDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthentikDashboard.Controllers.Authenticators;

[ApiController]
[Route("/authenticators/totp")]
public class TotpController : AuthentikController
{
    public TotpController(UserManager userManager) : base(userManager) { }

    [HttpGet]
    public async Task<ActionResult<string>> Get([FromQuery] string name, [FromQuery] string ordering, [FromQuery] int page, [FromQuery(Name = "page_size")] int pageSize, [FromQuery] string search)
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/totp/?name={name}&ordering={ordering}&page={page}&page_size={pageSize}&search={search}");
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<string>> Get(int id)
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/totp/{id}/");
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<string>> Put(int id, [FromBody, Required] string name)
    {
        HttpContent content = new StringContent(name, Encoding.UTF8, "application/json");
        
        return await HttpHelper.SendPut($"/api/v3/authenticators/totp/{id}/", content, false);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return await HttpHelper.SendDelete($"/api/v3/authenticators/totp/{id}/", false);
    }
    
    [HttpPatch("{id:int}")]
    public async Task<ActionResult<string>> Patch(int id, [FromBody, Required] string name)
    {
        HttpContent content = new StringContent(name, Encoding.UTF8, "application/json");
        
        return await HttpHelper.SendPatch($"/api/v3/authenticators/totp/{id}/", content, false);
    }
    
    [HttpGet("{id:int}/used_by")]
    public async Task<ActionResult<string>> UsedBy(int id)
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/totp/{id}/", false);
    }
}