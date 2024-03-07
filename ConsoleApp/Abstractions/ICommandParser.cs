using OzonSales.Types.Commands;

namespace OzonSales.ConsoleApp.Abstractions;

public interface ICommandParser
{
    Command ToCommand(string input);
}