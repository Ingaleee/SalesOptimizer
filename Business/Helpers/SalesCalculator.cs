using OzonSales.Types;
using OzonSales.Types.Commands;

namespace OzonSales.Business.Helpers;

public static class SalesCalculator
{
    public static decimal? CalculatePrediction(ICollection<SeasonCoef> coefs, Command command, decimal ads)
    {
        if (!coefs.Any())
        {
            return null;
        }
        
        var currentMonthItemCoef = coefs
            .Where(i => i.Id == command.Id)
            .FirstOrDefault(i => i.Month == DateTime.UtcNow.Month);
        
        if (currentMonthItemCoef == null)
        {
            return null;
        }
        
        return ads * currentMonthItemCoef.Coef * command.Days;
    }
    
    public static decimal? CalculateAds(IEnumerable<Sale> sales)
    {
        if (!sales.Any())
        {
            return null;
        }
        
        var salesSum = sales.Sum(x => x.Sales);
        var salesDays = sales.GroupBy(i => i.Date);
        return salesSum / salesDays.Count();
    }

    public static decimal? CalculateDemand(IEnumerable<Sale> sales, decimal prediction)
    {
        if (!sales.Any())
        {
            return null;
        }
        
        var salesSum = sales.Sum(i => i.Sales);
        var stockSum = sales.Sum(i => i.Stock);

        var itemsLeft = stockSum - salesSum;

        var demand = prediction - itemsLeft;
        if (demand < 0)
        {
            return 0;
        }

        return demand;
    }
}