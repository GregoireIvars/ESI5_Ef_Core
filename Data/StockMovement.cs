using System.ComponentModel.DataAnnotations;
using MyWebApi.Data;

public class StockMovement
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public required Product Product { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int QuantityChanged { get; set; }

    [MaxLength(250)]
    public string Reason { get; set; } = string.Empty;
}
