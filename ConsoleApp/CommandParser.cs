using ConsoleApp.Abstractions;
using ConsoleApp.Commands;
using ConsoleApp.Types;

namespace ConsoleApp;

public class CommandParser : ICommandParser
{
    public BaseCommand? ToCommand(string input)
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
        
        return parts[0] switch
        {
            "ads" => new AdsCommand(id, days),
            "prediction" => new PredictionCommand(id, days),
            "demand" => new DemandCommand(id, days),
            _ => null,
        };
    }
}