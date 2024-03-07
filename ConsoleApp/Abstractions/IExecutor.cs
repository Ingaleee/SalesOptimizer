using OzonSales.Business.Types;

namespace OzonSales.ConsoleApp.Abstractions;

public interface IExecutor
{
    Task<decimal> ExecuteAsync(Command command);
}