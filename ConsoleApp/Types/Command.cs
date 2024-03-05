namespace ConsoleApp.Types;

public class Command
{
    public ulong Id { get; set; }
    public CommandType Type { get; set; }
    public uint Days { get; set; }
}