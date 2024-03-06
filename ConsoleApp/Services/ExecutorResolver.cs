using ConsoleApp.Abstractions;
using ConsoleApp.Types;

namespace ConsoleApp;

public class ExecutorResolver : IExecutorResolver
{
    // private readonly IServiceProvider _services; 
    public ExecutorResolver()
    {
        
    }

    public IExecutor GetExecutor(Command command)
    {
        throw new NotImplementedException();
    }
}