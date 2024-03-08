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
        var serializer = services.GetService<IJsonParser>();
        
        const string salesPath = "sales.json";
        if (!File.Exists(salesPath))
        {
            var sales = new List<Sale>();
            FillSalesCollection(sales);
            var salesJson = serializer.Serialize(sales);
            await File.WriteAllTextAsync(salesPath, salesJson);
        }


        const string coefPath = "sales.json";
        if (!File.Exists(coefPath))
        {
            var seasonCoefs = new List<SeasonCoef>();
            FillCoefCollection(seasonCoefs);
            var coefsJson = serializer.Serialize(seasonCoefs);
            await File.WriteAllTextAsync(coefPath, coefsJson);
        }
    }

    private static async Task FillSalesCollection(ICollection<Sale> sales)
    {
        for (ulong i = 1; i <= 10; i++)
        {
            for (ulong day = 1; day <= 30; day++)
            {
                sales.Add(new Sale
                {
                    Id = i,
                    Date = new DateTime(2023, 09, (int)day),
                    Sales = (uint)new Random().Next(1, 20),
                    Stock = (uint)new Random().Next(10, 100)
                });
            }
        }
    }
    
    private static async Task FillCoefCollection(List<SeasonCoef> coefs)
    {
        for (uint i = 1; i <= 10; i++)
        {
            for (uint month = 1; month <= 12; month++)
            {
                coefs.Add(new SeasonCoef
                {
                    Id = i,
                    Month = month,
                    Coef =  Math.Round((decimal)(new Random().NextDouble() * 2.5), 2)
                });
            }
        }
    }
}