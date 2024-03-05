using ConsoleApp.Abstractions;

namespace ConsoleApp;

public class CommandHandler : ICommandHandler
{
    public async Task HandleAsync(BaseCommand command)
    {
        await command.ExecuteAsync();
    }
}

