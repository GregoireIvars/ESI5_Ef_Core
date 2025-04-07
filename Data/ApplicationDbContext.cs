using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<StockMovement> StockMovements { get; set; }

        public DbSet<PriceHistory> PriceHistories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Seed de la catégorie
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie
                {
                    Id = 1,
                    Name = "Électronique",
                    Description = "Appareils et gadgets électroniques",
                    ImageUrl = "https://example.com/electronique.jpg",
                    CategoryType = "Standard"
                });

            // Seed du customer
            modelBuilder.Entity<Customer>().HasData(
                new
                {
                    Id = 1,
                    Name = "Jean Dupont",
                    Email = "jean.dupont@example.com",
                    PhoneNumber = "0601020304"
                });

            // Seed de l'adresse associée au Customer
            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address).HasData(
                new
                {
                    CustomerId = 1,
                    Street = "123 rue de Paris",
                    City = "Paris",
                    State = "Île-de-France",
                    ZipCode = "75001",
                    Country = "France"
                });

            // Seed d'un produit
            modelBuilder.Entity<Product>().HasData(
                new
                {
                    Id = 1,
                    Name = "Smartphone X",
                    Description = "Dernier modèle avec fonctionnalités avancées",
                    ImageUrl = "https://example.com/smartphone.jpg",
                    Price = 699.99m,
                    Stock = 100,
                    SKU = "SMARTX001",
                    CategorieId = 1
                });

            // Seed d'une commande
            modelBuilder.Entity<Order>().HasData(
                new
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = 699.99m,
                    Status = "En cours",
                    TrackingNumber = "TRACK123",
                    ShippingMethod = "Colissimo",
                    ShippingStatus = "Préparation",
                    PaymentMethod = "Carte bancaire"
                });

            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress).HasData(
                new
                {
                    OrderId = 1,
                    Street = "456 avenue de Lyon",
                    City = "Lyon",
                    State = "Rhône",
                    ZipCode = "69000",
                    Country = "France"
                });

            modelBuilder.Entity<Order>().OwnsOne(o => o.BillingAddress).HasData(
                new
                {
                    OrderId = 1,
                    Street = "123 rue de Paris",
                    City = "Paris",
                    State = "Île-de-France",
                    ZipCode = "75001",
                    Country = "France"
                });

            // Seed d'un OrderItem
            modelBuilder.Entity<OrderItem>().HasData(
                new
                {
                    Id = 1,
                    ProductId = 1,
                    OrderId = 1,
                    Quantity = 1,
                    Price = 699.99m
                });
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();


            modelBuilder.Entity<Product>()
                .HasIndex(p => p.SKU)
                .IsUnique();
            modelBuilder.Entity<PriceHistory>()
                .HasOne(ph => ph.Product)
                .WithMany(p => p.PriceHistories)
                .HasForeignKey(ph => ph.ProductId);
            modelBuilder.Entity<StockMovement>()
                .HasOne(sm => sm.Product)
                .WithMany(p => p.StockMovements)
                .HasForeignKey(sm => sm.ProductId);
            modelBuilder.Entity<ProductReview>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<ProductReview>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Categorie)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategorieId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Categorie>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.Product)
                .WithMany()
                .HasForeignKey(sci => sci.ProductId);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.Customer)
                .WithMany()
                .HasForeignKey(sci => sci.CustomerId);

            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress);
            modelBuilder.Entity<Order>().OwnsOne(o => o.BillingAddress);


            modelBuilder.Entity<ShoppingCartItem>()
                .HasIndex(s => new { s.CustomerId, s.ProductId })
                .IsUnique();
        }


    }
}
