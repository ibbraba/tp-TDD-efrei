using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TP_Poker_console;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Register services here
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGameService, GameService>();
    })
    .Build();

var gameService = host.Services.GetRequiredService<IGameService>();
gameService.RunGame();