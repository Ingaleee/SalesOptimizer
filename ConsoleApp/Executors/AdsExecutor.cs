using OzonSales.Business.Abstractions;
using OzonSales.ConsoleApp.Abstractions.Executors;
using OzonSales.Types.Commands;

namespace OzonSales.ConsoleApp.Executors;

public class AdsCommandExecutor : IAdsExecutor
{
    private readonly ISalesService _sales;
    public AdsCommandExecutor(ISalesService sales)
    {
        _sales = sales;
    }
    public async Task<decimal?> ExecuteAsync(Command command)
    {
        return await _sales.GetADSAsync(command);
    }
}