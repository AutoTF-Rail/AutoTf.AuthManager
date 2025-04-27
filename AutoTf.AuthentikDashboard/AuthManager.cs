using AutoTf.AuthentikDashboard.Models;
using AutoTf.AuthentikDashboard.Models.Authentik;
using Microsoft.Extensions.Options;
using Timer = System.Timers.Timer;

namespace AutoTf.AuthentikDashboard;

public class AuthManager : IHostedService
{
    private readonly UserManager _userManager;
    private readonly Credentials _credentials;
    private Timer? _currentTimer;

    public AuthManager(UserManager userManager, IOptions<Credentials> credentials)
    {
        _userManager = userManager;
        _credentials = credentials.Value;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await GrabNewToken();
        StartTimer(300);
        // We don't need to check if we have a valid token here, because the app will exit if we don't.
        await _userManager.IsReady();
    }

    private async Task GrabNewToken()
    {
        Console.WriteLine("Trying to grab a new API token.");
        
        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
        
        headers.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
        // Provider client ID
        headers.Add(new KeyValuePair<string, string>("client_id", _credentials.ClientId));
        // Service account username
        headers.Add(new KeyValuePair<string, string>("username", _credentials.Username));
        // Service account password
        headers.Add(new KeyValuePair<string, string>("password", _credentials.Password));
        // Scope, needs to be added under Advanced procotol settings in the provider.
        headers.Add(new KeyValuePair<string, string>("scope", "goauthentik.io/api"));
        
        HttpContent content = new FormUrlEncodedContent(headers);

        TokenRequestModel response = await HttpHelper.SendPost<TokenRequestModel>("/application/o/token/", content, false) ?? new TokenRequestModel();
        
        if (response.ExpiresIn == 0)
        {
            Console.WriteLine("Cannot get token from authentik instance.");
            Environment.Exit(1);
            return;
        }

        Statics.Token = response.AccessToken;
        
        Console.WriteLine("Successfully retrieved API token from authentik instance.");
    }

    private void StartTimer(int responseExpiresIn)
    {
        // Requests a new token 10 seconds before the current one expires.
        _currentTimer = new Timer(TimeSpan.FromSeconds(responseExpiresIn) - TimeSpan.FromSeconds(10));
        _currentTimer.Elapsed += async (_, _) => await GrabNewToken();
        _currentTimer.Start();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _currentTimer?.Dispose();
        return Task.CompletedTask;
    }
}