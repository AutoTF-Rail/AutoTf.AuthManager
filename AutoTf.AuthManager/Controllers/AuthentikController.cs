using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoTf.AuthManager.Controllers;

public class AuthentikController : ControllerBase, IActionFilter
{
    protected readonly UserManager UserManager;
    protected string Username { get; private set; } = null!;
    protected int UserId { get; private set; }

    public AuthentikController(UserManager userManager)
    {
        UserManager = userManager;
    }
	
    public void OnActionExecuting(ActionExecutingContext context)
    {
        IHeaderDictionary? headers = context.HttpContext.Request.Headers;

        if (!IsAllowedDevice(headers, out string? deviceName))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Result = new UnauthorizedResult();
        }
        else
        {
            Username = deviceName!;
            ExchangeUsernameForId(context);
        }
    }

    private void ExchangeUsernameForId(ActionExecutingContext context)
    {
        UserId = UserManager.GetUserId(Username);

        if (UserId != -1) 
            return;
        
        context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Result = new UnauthorizedResult();
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
	
    private static bool IsAllowedDevice(IHeaderDictionary headers, out string? deviceName)
    {
        deviceName = "debugPlaceholder";
            
        try
        {
            deviceName = headers["X-Authentik-Username"].ToString();
                
            // We don't need to further validate this, because all incoming traffic is being routed through authentik anyways, so this is secure enough.
            return !string.IsNullOrEmpty(deviceName);
        }
        catch
        {
            return false;
        }
    }
}