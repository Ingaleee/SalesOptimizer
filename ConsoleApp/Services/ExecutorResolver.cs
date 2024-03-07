using Microsoft.Extensions.DependencyInjection;
using OzonSales.ConsoleApp.Abstractions;
using OzonSales.ConsoleApp.Executors;
using OzonSales.Types.Commands;
using OzonSales.Types.Primitives;

namespace OzonSales.ConsoleApp.Services;

public class ExecutorResolver : IExecutorResolver
{
    private readonly IServiceProvider _services; 
    public ExecutorResolver(IServiceProvider services)
    {
        _services = services;
    }

    public IExecutor? GetExecutor(Command command) => command.Type switch
    {
        CommandType.Ads => _services.GetService<AdsCommandExecutor>(),
        CommandType.Prediction => _services.GetService<PredictionExecutor>(),
        CommandType.Demand => _services.GetService<DemandExecutor>(),
        _ => null
    };
}