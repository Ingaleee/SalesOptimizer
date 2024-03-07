using OzonSales.Types.Commands;

namespace OzonSales.ConsoleApp.Abstractions;

public interface IExecutor
{
    Task<decimal> ExecuteAsync(Command command);
}