using OzonSales.Business.Types;

namespace OzonSales.ConsoleApp.Abstractions;

public interface ICommandParser
{
    Command ToCommand(string input);
}