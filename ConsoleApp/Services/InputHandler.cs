using OzonSales.ConsoleApp.Abstractions;

namespace OzonSales.ConsoleApp.Services;

public class InputHandler : IInputHandler
{
    private readonly ICommandParser _parser;
    private readonly IExecutorResolver _resolver;

    public InputHandler(ICommandParser parser, IExecutorResolver resolver)
    {
        _parser = parser;
        _resolver = resolver;
    }

    public async Task HandleAsync()
    {
        Console.WriteLine("Allowed commands: <ads|prediction|demand> [id] [days]");
        while (true)
        {
            Console.WriteLine("Input command:");
            var input = Console.ReadLine();
            if (input?.ToLower() == "q")
            {
                break;
            }
            
            var command = _parser.ToCommand(input);
            var executor = _resolver.GetExecutor(command);
            if (executor is null)
            {
                Console.WriteLine("Invalid command");
            }
            
            var result = await executor.ExecuteAsync(command);
            if (result is null)
            {
                Console.WriteLine("Invalid command");
            }
            
            Console.WriteLine($"Response: {result}");
            Console.ReadKey();
        }
    }
}

