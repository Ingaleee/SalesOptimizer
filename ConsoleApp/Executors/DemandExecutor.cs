using OzonSales.Business.Abstractions;
using OzonSales.Business.Types;
using OzonSales.ConsoleApp.Abstractions.Executors;

namespace OzonSales.ConsoleApp.Executors;

public class DemandExecutor : IDemandExecutor
{
    private readonly ISalesService _sales;
    public DemandExecutor(ISalesService sales)
    {
        _sales = sales;
    }
    public async Task<decimal> ExecuteAsync(Command command)
    {
        return await _sales.GetDemandAsync();
    }
}