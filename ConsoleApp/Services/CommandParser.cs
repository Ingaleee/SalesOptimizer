using OzonSales.Business.Primitives;
using OzonSales.Business.Types;
using OzonSales.ConsoleApp.Abstractions;

namespace OzonSales.ConsoleApp.Services;

public class CommandParser : ICommandParser
{
    public Command? ToCommand(string input)
    {
        var parts = input.Split(' ');
        if (parts.Length < 2)
        {
            return null;
        }

        if (!ulong.TryParse(parts[1], out var id))
        {
            return null;
        }

        uint days = 0;
        if (parts.Length >= 3)
        {
            uint.TryParse(parts[2], out days);
        }
        
        var type = parts[0].ToLower() switch
        {
            "ads" => CommandType.Ads,
            "prediction" => CommandType.Prediction,
            "demand" => CommandType.Demand,
            _ => CommandType.Undefined,
        };

        return new Command { Id = id, Type = type, Days = days };
    }
}