using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "Description", "ImageUrl", "Name", "ParentCategoryId" },
                values: new object[] { 1, "Standard", "Appareils et gadgets électroniques", "https://example.com/electronique.jpg", "Électronique", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "Address_City", "Address_Country", "Address_State", "Address_Street", "Address_ZipCode" },
                values: new object[] { 1, "jean.dupont@example.com", "Jean Dupont", "0601020304", "Paris", "France", "Île-de-France", "123 rue de Paris", "75001" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "PaymentMethod", "ShippingMethod", "ShippingStatus", "Status", "TotalAmount", "TrackingNumber", "BillingAddress_City", "BillingAddress_Country", "BillingAddress_State", "BillingAddress_Street", "BillingAddress_ZipCode", "ShippingAddress_City", "ShippingAddress_Country", "ShippingAddress_State", "ShippingAddress_Street", "ShippingAddress_ZipCode" },
                values: new object[] { 1, 1, new DateTime(2025, 4, 7, 14, 24, 52, 51, DateTimeKind.Utc).AddTicks(3660), "Carte bancaire", "Colissimo", "Préparation", "En cours", 699.99m, "TRACK123", "Paris", "France", "Île-de-France", "123 rue de Paris", "75001", "Lyon", "France", "Rhône", "456 avenue de Lyon", "69000" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategorieId", "Description", "ImageUrl", "Name", "Price", "SKU", "Stock" },
                values: new object[] { 1, 1, "Dernier modèle avec fonctionnalités avancées", "https://example.com/smartphone.jpg", "Smartphone X", 699.99m, "SMARTX001", 100 });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 699.99m, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
