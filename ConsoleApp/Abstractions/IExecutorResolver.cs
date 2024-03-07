using OzonSales.Business.Types;

namespace OzonSales.ConsoleApp.Abstractions;

public interface IExecutorResolver
{
    IExecutor GetExecutor(Command command);
}