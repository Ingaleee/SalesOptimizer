namespace ConsoleApp.Abstractions;

public abstract class BaseCommand
{
    protected ulong Id;
    protected uint Days;
    
    public BaseCommand(ulong id, uint days)
    {
        Id = id;
        Days = days;
    }
    public abstract Task ExecuteAsync();
}