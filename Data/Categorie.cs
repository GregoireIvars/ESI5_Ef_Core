namespace MyWebApi.Data
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
        public string CategoryType { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
        public Categorie? ParentCategory { get; set; }
        public ICollection<Categorie> SubCategories { get; set; } = new List<Categorie>();
    }
}