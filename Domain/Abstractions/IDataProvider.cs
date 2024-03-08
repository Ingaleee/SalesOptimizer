namespace OzonSales.Domain.Abstractions;

public interface IDataProvider<TEntity>
{
    Task GetAsync();
}