namespace MyWebApi.Data;

public class NewBaseType
{
    public required ICollection<ProductReview> Reviews { get; set; }
}

public class Product : NewBaseType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Stock { get; set; }
    public string SKU { get; set; } = string.Empty;

    // Relation avec Category
    public int CategorieId { get; set; }
    public required Categorie Categorie { get; set; }

    public required ICollection<OrderItem> OrderItems { get; set; }
    public required ICollection<StockMovement> StockMovements { get; set; }
    public required ICollection<PriceHistory> PriceHistories { get; set; }


}
