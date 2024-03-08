using Microsoft.Extensions.DependencyInjection;
using OzonSales.ConsoleApp.Abstractions;
using OzonSales.ConsoleApp.Abstractions.Executors;
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
        CommandType.Ads => _services.GetService<IAdsExecutor>(),
        CommandType.Prediction => _services.GetService<IPredictionExecutor>(),
        CommandType.Demand => _services.GetService<IDemandExecutor>(),
        _ => null
    };
}