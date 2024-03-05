namespace ConsoleApp.Abstractions;

public interface ICommandHandler
{
    Task HandleAsync(BaseCommand command);
}