using ConsoleApp.Abstractions;

namespace ConsoleApp;

public class InputHandler : IHandler
{
    private readonly ICommandParser _parser;
    private readonly IExecutorResolver _resolver;

    public InputHandler(ICommandParser parser)
    {
        _parser = parser;
    }

    public async Task HandleAsync()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var command = _parser.ToCommand(input);
            var executor = _resolver.GetExecutor(command);
        }
    }
}

