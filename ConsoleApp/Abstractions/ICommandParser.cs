namespace ConsoleApp.Abstractions;

public interface ICommandParser
{
    BaseCommand ToCommand(string input);
}