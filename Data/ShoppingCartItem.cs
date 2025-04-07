namespace MyWebApi.Data;
public class ShoppingCartItem
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public required Product Product { get; set; }

    public int CustomerId { get; set; }
    public required Customer Customer { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
