namespace OzonSales.Business.Abstractions;

public interface ISalesService
{
    // TODO: create divided class for ADS calculation result
    Task<decimal> GetADSAsync();
    Task<uint> GetPredictionAsync();
    Task<uint> GetDemandAsync();
}