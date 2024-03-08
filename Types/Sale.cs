namespace OzonSales.Types;

public class Sale
{
    public ulong Id { get; set; }
    public DateTime Date { get; set; }
    public uint Sales { get; set; }
    public uint Stock { get; set; }
}