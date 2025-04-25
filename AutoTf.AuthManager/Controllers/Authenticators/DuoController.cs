using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoTf.AuthManager.Models;
using AutoTf.AuthManager.Models.Authentik;
using AutoTf.AuthManager.Models.Authentik.Requests.Authenticators;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Authenticators;

[ApiController]
[Route("/authenticators/duo")]
public class DuoController : AuthentikController
{
    public DuoController(UserManager userManager) : base(userManager) { }

    [HttpGet]
    public async Task<ActionResult<AuthenticatorResult>> Get()
    {
        return await HttpHelper.SendGet<AuthenticatorResult>("/api/v3/authenticators/duo/") ?? new AuthenticatorResult();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Device>> Get(int id)
    {
        return await HttpHelper.SendGet<Device>($"/api/v3/authenticators/duo/{id}/") ?? new Device();
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Device>> Put(int id, [FromBody, Required] string name)
    {
        HttpContent content = new StringContent(name, Encoding.UTF8, "application/json");

        return await HttpHelper.SendPut<Device>($"/api/v3/authenticators/duo/{id}/", content, false) ?? new Device();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return await HttpHelper.SendDelete($"/api/v3/authenticators/duo/{id}/", false);
    }
    
    [HttpPatch("{id:int}")]
    public async Task<ActionResult<Device>> Patch(int id, [FromBody, Required] string name)
    {
        HttpContent content = new StringContent(name, Encoding.UTF8, "application/json");
        
        return await HttpHelper.SendPatch<Device>($"/api/v3/authenticators/duo/{id}/", content, false) ?? new Device();
    }
    
    [HttpGet("{id:int}/used_by")]
    public async Task<ActionResult<List<UsedBy>>> UsedBy(int id)
    {
        return await HttpHelper.SendGet<List<UsedBy>>($"/api/v3/authenticators/duo/{id}/", false) ?? [];
    }
}