namespace OzonSales.Domain.Abstractions;

public interface IDataProvider<TEntity>
{
    Task GetAsync();
    Task UpdateAsync();
    Task<ulong> CreateAsync();
    Task RemoveAsync(ulong id);
}