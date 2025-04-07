using System.ComponentModel.DataAnnotations;
using MyWebApi.Data;

public class ProductReview
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public required Product Product { get; set; }

    public int CustomerId { get; set; }
    public required Customer Customer { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(1000)]
    public string Comment { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
