namespace ConsoleApp.Abstractions;

public interface IExecutor
{
    Task<decimal> ExecuteAsync();
}