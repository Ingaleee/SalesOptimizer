using OzonSales.Business.Abstractions;
using OzonSales.Types.Commands;

namespace OzonSales.Business;

public class SalesService : ISalesService
{
    public Task<decimal> GetADSAsync(Command command)
    {
        throw new NotImplementedException();
    }

    public Task<uint> GetPredictionAsync(Command command)
    {
        throw new NotImplementedException();
    }

    public Task<uint> GetDemandAsync(Command command)
    {
        throw new NotImplementedException();
    }
}