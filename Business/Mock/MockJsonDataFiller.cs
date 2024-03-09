using System.Text.Json;
using OzonSales.Types;

namespace OzonSales.Business.Mock;

public class MockJsonDataFiller
{
    public async Task PrepareJsonDomain()
    {
        
        const string salesPath = "sales.json";
        if (!File.Exists(salesPath))
        {
            var sales = new List<Sale>();
            FillSalesCollection(sales);
            var salesJson = JsonSerializer.Serialize(sales);
            await File.WriteAllTextAsync(salesPath, salesJson);
        }


        const string coefPath = "coef.json";
        if (!File.Exists(coefPath))
        {
            var seasonCoefs = new List<SeasonCoef>();
            FillCoefCollection(seasonCoefs);
            var coefsJson = JsonSerializer.Serialize(seasonCoefs);
            await File.WriteAllTextAsync(coefPath, coefsJson);
        }
    }

    private static async Task FillSalesCollection(ICollection<Sale> sales)
    {
        for (ulong i = 1; i <= 10; i++)
        {
            for (ulong day = 1; day <= 30; day++)
            {
                sales.Add(new Sale
                {
                    Id = i,
                    Date = new DateTime(2023, 09, (int)day),
                    Sales = (uint)new Random().Next(1, 20),
                    Stock = (uint)new Random().Next(10, 100)
                });
            }
        }
    }
    
    private static async Task FillCoefCollection(List<SeasonCoef> coefs)
    {
        for (uint i = 1; i <= 10; i++)
        {
            for (uint month = 1; month <= 12; month++)
            {
                coefs.Add(new SeasonCoef
                {
                    Id = i,
                    Month = month,
                    Coef =  Math.Round((decimal)(new Random().NextDouble() * 2.5), 2)
                });
            }
        }
    }
}