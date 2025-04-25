using AutoTf.AuthManager.Models;
using AutoTf.AuthManager.Models.Authentik;
using AutoTf.AuthManager.Models.Authentik.Requests.Core;
using Timer = System.Timers.Timer;

namespace AutoTf.AuthManager;

public class UserManager : IHostedService
{
    private Timer _timer = new Timer(TimeSpan.FromMinutes(5));
    
    public List<User> Users = new List<User>();
    
    // This is seperate from StartAsync, because we have to wait for the Token to be available first.
    public async Task IsReady()
    {
        await UpdateUserCache();
        StartTimer();
    }

    public int GetUserId(string username)
    {
        User? user = Users.FirstOrDefault(x => x.Username == username);
        
        if (user == null)
            return -1;
        
        return user.Pk;
    }

    private void StartTimer()
    {
        _timer.AutoReset = true;
        _timer.Elapsed += async (_, _) => await UpdateUserCache();
        _timer.Start();
    }

    private async Task UpdateUserCache()
    {
        Console.WriteLine("Updating user cache.");

        Users? result = await HttpHelper.SendGet<Users>("/api/v3/core/users/", false);

        if (result == null)
        {
            Console.WriteLine("Could not update users cache.");
            return;
        }

        Users = result.Results;
        Console.WriteLine("Updated users cache.");
    }

    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer.Dispose();
        return Task.CompletedTask;
    }
}