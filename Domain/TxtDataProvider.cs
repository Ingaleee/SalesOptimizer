using OzonSales.Domain.Abstractions;

namespace OzonSales.Domain;

public class DataProvider<TEntity> : IDataProvider<TEntity>
{
    public Task GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ulong> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(ulong id)
    {
        throw new NotImplementedException();
    }
}