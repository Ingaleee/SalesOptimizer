using ConsoleApp.Abstractions;

namespace ConsoleApp.Commands;

public class AdsCommand : BaseCommand
{
    public AdsCommand(ulong id, uint days) : base(id, days)
    {
    }

    public override Task ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}