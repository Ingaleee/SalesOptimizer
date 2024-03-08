namespace OzonSales.Domain.Abstractions;

public interface IDataProvider<TEntity>
{
    Task<ICollection<TEntity>?> GetAsync();
}