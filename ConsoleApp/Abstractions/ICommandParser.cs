using ConsoleApp.Types;

namespace ConsoleApp.Abstractions;

public interface ICommandParser
{
    Command ToCommand(string input);
}