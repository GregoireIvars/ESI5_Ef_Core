
namespace MyWebApi.Data;
public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public required Customer Customer { get; set; }

    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;

    public string TrackingNumber { get; set; } = string.Empty;
    public string ShippingMethod { get; set; } = string.Empty;
    public string ShippingStatus { get; set; } = string.Empty;

    // Adresses complexes
    public required Address ShippingAddress { get; set; }
    public required Address BillingAddress { get; set; }

    public string PaymentMethod { get; set; } = string.Empty;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
