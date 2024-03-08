using OzonSales.Types;
using OzonSales.Types.Commands;

namespace OzonSales.Business.Helpers;

public static class SalesCalculator
{
    public static uint? CalculatePrediction(ICollection<SeasonCoef> coefs, Command command, decimal ads)
    {
        var currentMonthItemCoef = coefs?
            .Where(i => i.Id == command.Id)
            .FirstOrDefault(i => i.Month == DateTime.UtcNow.Month);
        
        if (currentMonthItemCoef == null)
        {
            return null;
        }
        
        return (uint?)(ads * currentMonthItemCoef.Coef * command.Days);
    }
    
    public static decimal? CalculateAds(ICollection<Sale> sales, Command command)
    {
        var requiredItemSales = sales.Where(i => i.Id == command.Id);
        if (!requiredItemSales.Any())
        {
            return null;
        }
        
        var salesSum = requiredItemSales.Sum(x => x.Sales);
        var salesDays = requiredItemSales.GroupBy(i => i.Date);
        return salesSum / salesDays.Count();
    }
}