using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoTf.AuthManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Authenticators;

[ApiController]
[Route("/authenticators/duo")]
public class DuoController : AuthentikController
{
    public DuoController(UserManager userManager) : base(userManager) { }

    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
        return await HttpHelper.SendGetString("/api/v3/authenticators/duo/");
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<string>> Get(int id)
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/duo/{id}/");
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<string>> Put(int id, [FromBody, Required] string name)
    {
        HttpContent content = new StringContent(name, Encoding.UTF8, "application/json");

        return await HttpHelper.SendPut($"/api/v3/authenticators/duo/{id}/", content, false);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return await HttpHelper.SendDelete($"/api/v3/authenticators/duo/{id}/", false);
    }
    
    [HttpPatch("{id:int}")]
    public async Task<ActionResult<string>> Patch(int id, [FromBody, Required] string name)
    {
        HttpContent content = new StringContent(name, Encoding.UTF8, "application/json");
        
        return await HttpHelper.SendPatch($"/api/v3/authenticators/duo/{id}/", content, false);
    }
    
    [HttpGet("{id:int}/used_by")]
    public async Task<ActionResult<string>> UsedBy(int id)
    {
        return await HttpHelper.SendGetString($"/api/v3/authenticators/duo/{id}/", false);
    }
}