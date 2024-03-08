using Microsoft.Extensions.DependencyInjection;
using OzonSales.Domain.Abstractions;
using OzonSales.Domain.Configurations;

namespace OzonSales.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static void WithJsonDomain<TEntity>(this IServiceCollection services, string path)
    {
        services.AddTransient<IDataProvider<TEntity>, JsonDataProvider<TEntity>>();
        services.AddSingleton(new JsonDomainOptions<TEntity> { Path = path });
    }
}