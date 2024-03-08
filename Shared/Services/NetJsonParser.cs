using System.Text.Json;
using Shared.Abstractions;

namespace Shared.Services;

public class NetJsonParser: IJsonParser
{
    public string Serialize<T>(T target)
    {
        return JsonSerializer.Serialize(target);
    }

    public T Deserialize<T>(string target)
    {
        return JsonSerializer.Deserialize<T>(target);
    }
}