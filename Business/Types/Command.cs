using OzonSales.Business.Primitives;

namespace OzonSales.Business.Types;

public class Command
{
    public ulong Id { get; set; }
    public CommandType Type { get; set; }
    public uint Days { get; set; }
}