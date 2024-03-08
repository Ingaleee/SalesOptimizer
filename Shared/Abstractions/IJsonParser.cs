namespace Shared.Abstractions;

public interface IJsonParser
{
    string Serialize<T>(T target);
    T Deserialize<T>(string content);
}