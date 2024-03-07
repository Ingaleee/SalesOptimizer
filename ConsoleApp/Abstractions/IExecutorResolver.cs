using OzonSales.Types.Commands;

namespace OzonSales.ConsoleApp.Abstractions;

public interface IExecutorResolver
{
    IExecutor GetExecutor(Command command);
}