
namespace MyWebApi.Data;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    // Adresse complexe
    public required Address Address { get; set; }

    public required ICollection<Order> Orders { get; set; }
}
