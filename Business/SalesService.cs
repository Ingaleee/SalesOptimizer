using OzonSales.Business.Abstractions;

namespace OzonSales.Business;

public class SalesService : ISalesService
{
    public Task<decimal> GetADSAsync()
    {
        throw new NotImplementedException();
    }

    public Task<uint> GetPredictionAsync()
    {
        throw new NotImplementedException();
    }

    public Task<uint> GetDemandAsync()
    {
        throw new NotImplementedException();
    }
}