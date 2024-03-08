using Microsoft.Extensions.DependencyInjection;
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
        
        services.AddTransient<IAdsExecutor, AdsCommandExecutor>();
        services.AddTransient<IDemandExecutor, DemandExecutor>();
        services.AddTransient<IPredictionExecutor, PredictionExecutor>();
        
        services.AddTransient<ICommandParser, CommandParser>();
        services.AddTransient<IInputHandler, InputHandler>();
        
        services.AddTransient<IInputHandler, InputHandler>();

        services.AddTransient<IJsonParser, NetJsonParser>();

        services.WithJsonDomain<Sale>("sales.json");
        services.WithJsonDomain<SeasonCoef>("coef.json");

        return services.BuildServiceProvider();
    }

    // TODO: need to refactoring
    public static async Task PrepareJsonDomain(IServiceProvider services)
    {
        const string salesPath = "sales.json";
        var serializer = services.GetService<IJsonParser>();
        var sales = new List<Sale>
        {
            new() { Id = 123, Date = new DateTime(2023, 09, 01), Sales = 10, Stock = 50 },
            new() { Id = 567, Date = new DateTime(2023, 09, 01), Sales = 0, Stock = 100 },
            new() { Id = 678, Date = new DateTime(2023, 09, 01), Sales = 0, Stock = 50 },
        };

        var salesJson = serializer.Serialize(sales);
        await File.WriteAllTextAsync(salesPath, salesJson);

        
        const string coefPath = "sales.json";
        var coefs = new List<SeasonCoef>
        {
            new() { Id = 123, Month = 1, Coef = 0.5m },
            new() { Id = 657, Month = 12, Coef = 3m },
        };
        
        var coefsJson = serializer.Serialize(coefs);
        await File.WriteAllTextAsync(salesPath, coefsJson);
    }
}