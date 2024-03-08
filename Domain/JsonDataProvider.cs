using System.Text.Json;
using OzonSales.Domain.Abstractions;
using OzonSales.Domain.Configurations;

namespace OzonSales.Domain;

public class JsonDataProvider<TEntity> : IDataProvider<TEntity>
{
    private readonly JsonDomainOptions<TEntity> _options;

    public JsonDataProvider(JsonDomainOptions<TEntity> options)
    {
        _options = options;
    }

    public async Task<ICollection<TEntity>?> GetAsync()
    {
        var path = _options.Path;
        var content = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<ICollection<TEntity>>(content);
    }
}