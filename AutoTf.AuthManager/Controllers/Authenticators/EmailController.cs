using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoTf.AuthManager.Models;
using AutoTf.AuthManager.Models.Authentik;
using AutoTf.AuthManager.Models.Authentik.Requests.Authenticators;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Authenticators;

[ApiController]
[Route("/authenticators/email")]
public class EmailController : AuthentikController
{
    public EmailController(UserManager userManager) : base(userManager) { }

    [HttpGet]
    public async Task<ActionResult<AuthenticatorResult>> Get([FromQuery] string name, [FromQuery] string ordering, [FromQuery] int page, [FromQuery(Name = "page_size")] int pageSize, [FromQuery] string search)
    {
        return await HttpHelper.SendGet<AuthenticatorResult>($"/api/v3/authenticators/email/?name={name}&ordering={ordering}&page={page}&page_size={pageSize}&search={search}") ?? new AuthenticatorResult();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Device>> Get(int id)
    {
        return await HttpHelper.SendGet<Device>($"/api/v3/authenticators/email/{id}/") ?? new Device();
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Device>> Put(int id, [FromBody, Required] string name)
    {
        HttpContent content = new StringContent(name, Encoding.UTF8, "application/json");
        
        return await HttpHelper.SendPut<Device>($"/api/v3/authenticators/email/{id}/", content, false) ?? new Device();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return await HttpHelper.SendDelete($"/api/v3/authenticators/email/{id}/", false);
    }
    
    [HttpPatch("{id:int}")]
    public async Task<ActionResult<Device>> Patch(int id, [FromBody, Required] string name)
    {
        HttpContent content = new StringContent(name, Encoding.UTF8, "application/json");
        
        return await HttpHelper.SendPatch<Device>($"/api/v3/authenticators/email/{id}/", content, false) ?? new Device();
    }
    
    [HttpGet("{id:int}/used_by")]
    public async Task<ActionResult<List<UsedBy>>> UsedBy(int id)
    {
        return await HttpHelper.SendGet<List<UsedBy>>($"/api/v3/authenticators/email/{id}/", false) ?? [];
    }
}