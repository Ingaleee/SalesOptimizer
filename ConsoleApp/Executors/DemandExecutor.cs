using OzonSales.Business.Abstractions;
using OzonSales.ConsoleApp.Abstractions.Executors;
using OzonSales.Types.Commands;

namespace OzonSales.ConsoleApp.Executors;

public class DemandExecutor : IDemandExecutor
{
    private readonly ISalesService _sales;
    public DemandExecutor(ISalesService sales)
    {
        _sales = sales;
    }
    public async Task<decimal?> ExecuteAsync(Command command)
    {
        return await _sales.GetDemandAsync(command);
    }
}