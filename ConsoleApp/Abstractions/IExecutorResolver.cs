using ConsoleApp.Types;

namespace ConsoleApp.Abstractions;

public interface IExecutorResolver
{
    IExecutor GetExecutor(Command command);
}