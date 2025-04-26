using System.ComponentModel.DataAnnotations;
using AutoTf.AuthManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoTf.AuthManager.Controllers.Stages;

[ApiController]
[Route("/stages/all")]
public class AllController : AuthentikController
{
    public AllController(UserManager userManager) : base(userManager) { }

    [HttpGet]
    public async Task<ActionResult<string>> Get([FromQuery] string name, [FromQuery] string ordering, [FromQuery] string page,
        [FromQuery(Name = "page_size")] string pageSize, [FromQuery] string search)
    {
        return await HttpHelper.SendGetString($"/api/v3/stages/all/?name={name}&ordering={ordering}&page={page}&page_size={pageSize}&search={search}");
    }

    [HttpGet("{stage_uuid}")]
    public async Task<ActionResult<string>> Get([FromRoute(Name = "stage_uuid")] string stageUuid)
    {
        return await HttpHelper.SendGetString($"/api/v3/stages/all/{stageUuid}/");
    }
    
    [HttpDelete("{stage_uuid}")]
    public async Task<ActionResult<bool>> Delete([FromRoute(Name = "stage_uuid")] string stageUuid)
    {
        return await HttpHelper.SendDelete($"/api/v3/stages/all/{stageUuid}/");
    }
    
    [HttpGet("{stage_uuid}/used_by")]
    public async Task<ActionResult<string>> UsedBy([FromRoute(Name = "stage_uuid")] string stageUuid)
    {
        return await HttpHelper.SendGetString($"/api/v3/stages/all/{stageUuid}/used_by/");
    }
    
    [HttpGet("types")]
    public async Task<ActionResult<string>> Types()
    {
        return await HttpHelper.SendGetString($"/api/v3/stages/all/types/");
    }
    
    [HttpGet("user_settings")]
    public async Task<ActionResult<string>> UserSettings()
    {
        return await HttpHelper.SendGetString($"/api/v3/stages/all/user_settings/");
    }
}