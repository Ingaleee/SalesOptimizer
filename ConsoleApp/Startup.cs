using Microsoft.Extensions.DependencyInjection;
using OzonSales.Business;
using OzonSales.Business.Abstractions;
using OzonSales.ConsoleApp.Abstractions;
using OzonSales.ConsoleApp.Abstractions.Executors;
using OzonSales.ConsoleApp.Executors;
using OzonSales.ConsoleApp.Services;
using OzonSales.Domain.Extensions;
using OzonSales.Types;
using Shared.Abstractions;
using Shared.Services;

namespace OzonSales.ConsoleApp;

public static class Startup
{
    public static IServiceProvider BuildConsoleProvider(this IServiceCollection services)
    {
        services.AddTransient<ICommandParser, CommandParser>();

        services.AddTransient<IExecutorResolver, ExecutorResolver>();
        
        services.AddTransient<IAdsExecutor, AdsExecutor>();
        services.AddTransient<IDemandExecutor, DemandExecutor>();
        services.AddTransient<IPredictionExecutor, PredictionExecutor>();
        
        services.AddTransient<ICommandParser, CommandParser>();
        services.AddTransient<IInputHandler, InputHandler>();
        
        services.AddTransient<IInputHandler, InputHandler>();

        services.AddTransient<IJsonParser, NetJsonParser>();

        services.AddTransient<ISalesService, SalesService>();

        services.WithJsonDomain<Sale>("sales.json");
        services.WithJsonDomain<SeasonCoef>("coef.json");

        return services.BuildServiceProvider();
    }
}