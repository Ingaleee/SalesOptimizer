using ConsoleApp.Abstractions;

namespace ConsoleApp.Commands;

public class DemandCommand : BaseCommand
{
    public DemandCommand(ulong id, uint days) : base(id, days)
    {
    }

    public override Task ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}