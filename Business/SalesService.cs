using Microsoft.Extensions.DependencyInjection;
using OzonSales.Business.Abstractions;
using OzonSales.Business.Helpers;
using OzonSales.Domain.Abstractions;
using OzonSales.Types;
using OzonSales.Types.Commands;

namespace OzonSales.Business;

public class SalesService : ISalesService
{
    private readonly IServiceProvider _services;

    public SalesService(IServiceProvider services)
    {
        _services = services;
    }
    public async Task<decimal?> GetADSAsync(Command command)
    {
        var salesProvider = _services.GetService<IDataProvider<Sale>>();
        var sales = await salesProvider.GetAsync();
        if (sales is null)
        {
            return null;
        }

        return SalesCalculator.CalculateAds(sales, command);
    }

    public async Task<decimal?> GetPredictionAsync(Command command)
    {
        if (command.Days <= 0)
        {
            return null;
        }

        var coefsProvider = _services.GetService<IDataProvider<SeasonCoef>>();
        var coefs = await coefsProvider?.GetAsync();
        if (coefs == null)
        {
            return null;
        }
        
        var salesProvider = _services.GetService<IDataProvider<Sale>>();
        var sales = await salesProvider.GetAsync();
        if (sales is null)
        {
            return null;
        }

        var ads = SalesCalculator.CalculateAds(sales, command);
        if (!ads.HasValue)
        {
            return null;
        }
        return SalesCalculator.CalculatePrediction(coefs, command, ads.Value);
    }

    public async Task<decimal?> GetDemandAsync(Command command)
    {
        var coefsProvider = _services.GetService<IDataProvider<SeasonCoef>>();
        var coefs = await coefsProvider?.GetAsync();
        if (coefs == null)
        {
            return null;
        }
        
        var salesProvider = _services.GetService<IDataProvider<Sale>>();
        var sales = await salesProvider.GetAsync();
        if (sales is null)
        {
            return null;
        }

        var ads = SalesCalculator.CalculateAds(sales, command);
        if (!ads.HasValue)
        {
            return null;
        }
        
        var prediction = SalesCalculator.CalculatePrediction(coefs, command, ads.Value);
        if (!prediction.HasValue)
        {
            return null;
        }

        var requiredItemsSales = sales.Where(i => i.Id == command.Id);
        var salesSum = requiredItemsSales.Sum(i => i.Sales);
        var stockSum = requiredItemsSales.Sum(i => i.Stock);

        var itemsLeft = stockSum - salesSum;

        return prediction - itemsLeft;
    }
}