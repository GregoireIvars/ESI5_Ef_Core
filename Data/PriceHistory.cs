using MyWebApi.Data;

public class PriceHistory
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public required Product Product { get; set; }

    public decimal OldPrice { get; set; }

    public decimal NewPrice { get; set; }

    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
}
