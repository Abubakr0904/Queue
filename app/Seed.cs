using app.Data;
using app.Entities;
using Microsoft.AspNetCore.Identity;

public class Seed : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Seed> _logger;

    public Seed(IServiceProvider serviceProvider, ILogger<Seed> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>(); 
        var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<User>>();

        var user = new User()
        {
            Email = "superadmin@abubakr.uz"
        };
        if(!context.Users.Any())
        {
            await signInManager.PasswordSignInAsync(user, "123456", false, false);
        }
    }
}