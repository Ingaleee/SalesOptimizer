using ConsoleApp.Abstractions;

namespace ConsoleApp.Commands;

public class PredictionCommand : BaseCommand
{
    public override Task ExecuteAsync()
    {
        throw new NotImplementedException();
    }

    public PredictionCommand(ulong id, uint days) : base(id, days)
    {
    }
}