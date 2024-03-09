using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OzonSales.Business;
using OzonSales.Business.Abstractions;
using OzonSales.Domain.Extensions;
using OzonSales.Types;

namespace OzonSales.WebAPI;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ISalesService, SalesService>();
        services.WithJsonDomain<Sale>("sales.json");
        services.WithJsonDomain<SeasonCoef>("coef.json");
        services.AddSwaggerDocument();
        services.AddControllers();
        services.AddMvc();
    }
    
    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles();

        app.UseRouting();
        app.UseEndpoints(b => b.MapControllers());

        app.UseOpenApi();
        app.UseSwaggerUi3();
    }
}