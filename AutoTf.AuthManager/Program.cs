using AutoTf.AuthManager.Avalonia;
using AutoTf.AuthManager.Controllers;
using AutoTf.AuthManager.Extensions;
using AutoTf.AuthManager.Models;

namespace AutoTf.AuthManager;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<AuthentikController>();
        });
        
        builder.Services.AddControllers();
        
        // stored in appsettings.Development.json or set manually in .env
        builder.Services.Configure<Credentials>(options =>
        {
            options.ClientId = builder.Configuration["ClientId"] ?? "key";
            options.Username = builder.Configuration["Username"] ?? "key";
            options.Password = builder.Configuration["Password"] ?? "key";
        });
        
        Statics.AuthUrl = builder.Configuration["AuthUrl"] ?? "https://autotf.de";
        Console.WriteLine($"Set auth url to: {Statics.AuthUrl}.");
        
        builder.Services.AddHostedSingleton<UserManager>();
        
        builder.Services.AddHostedService<AuthManager>();
        
        WebApplication app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseDefaultFiles();
        
        app.UseStaticFiles(new StaticFileOptions
        {
            ServeUnknownFileTypes = true,
            DefaultContentType = "application/octet-stream"
        });
        
        app.MapControllers();

        app.Run("http://0.0.0.0:80");
    }
}