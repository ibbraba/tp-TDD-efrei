using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TP_Poker_console;

Console.WriteLine("Hello, World!");

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Register services here
        services.AddTransient<IUserService, UserService>();
    })
    .Build();

void RunPokerGame()
{
}