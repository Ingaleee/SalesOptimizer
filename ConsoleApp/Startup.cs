using Microsoft.Extensions.DependencyInjection;
using OzonSales.ConsoleApp.Abstractions;
using OzonSales.ConsoleApp.Abstractions.Executors;
using OzonSales.ConsoleApp.Executors;
using OzonSales.ConsoleApp.Services;

namespace OzonSales.ConsoleApp;

public static class Startup
{
    public static IServiceProvider BuildConsoleProvider(this IServiceCollection services)
    {
        services.AddTransient<ICommandParser, CommandParser>();
        
        services.AddTransient<IAdsExecutor, AdsCommandExecutor>();
        services.AddTransient<IDemandExecutor, DemandExecutor>();
        services.AddTransient<IPredictionExecutor, PredictionExecutor>();
        
        services.AddTransient<ICommandParser, CommandParser>();
        services.AddTransient<IInputHandler, InputHandler>();

        return services.BuildServiceProvider();
    }
}