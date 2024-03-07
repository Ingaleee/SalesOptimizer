using OzonSales.Business.Abstractions;
using OzonSales.Business.Types;
using OzonSales.ConsoleApp.Abstractions;

namespace OzonSales.ConsoleApp.Executors;

public class DemandExecutor : IExecutor
{
    private readonly ISalesService _sales;
    public DemandExecutor(ISalesService sales)
    {
        _sales = sales;
    }
    public async Task<decimal> ExecuteAsync(Command command)
    {
        throw new NotImplementedException();
    }
}