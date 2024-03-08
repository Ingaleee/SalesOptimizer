using OzonSales.Types.Commands;

namespace OzonSales.Business.Abstractions;

public interface ISalesService
{
    // TODO: create divided class for ADS calculation result
    Task<decimal?> GetADSAsync(Command command);
    Task<decimal?> GetPredictionAsync(Command command);
    Task<decimal?> GetDemandAsync(Command command);
}