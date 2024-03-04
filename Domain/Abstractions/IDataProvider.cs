namespace OzonSales.Domain.Abstractions;

public interface IUnitOfWork<TEntity>
{
    Task GetAsync();
    Task UpdateAsync();
    Task<ulong> CreateAsync();
    Task RemoveAsync(ulong id);
}