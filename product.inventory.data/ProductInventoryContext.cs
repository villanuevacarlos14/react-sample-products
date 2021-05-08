using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using product.inventory.data.mapping;
using product.inventory.data.models;

namespace product.inventory.data
{
    public class ProductInventoryContext : DbContext
    {
        public ProductInventoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { internal get; set; }
        public DbSet<ProductInventory> ProductInventories { internal get; set; }
        public DbSet<ProductInventoryLog> ProductInventoryLogs { internal get; set; }
        public DbSet<User> Users { internal get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductInventoryConfiguration());
            builder.ApplyConfiguration(new ProductInventoryLogConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            const string defaultPassword = "123456";
            var hashedPassword = new PasswordHasher<object>().HashPassword(null, defaultPassword);

            //seed database
            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "admin",
                Password = hashedPassword,
                CreatedDate = DateTime.Now
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Galaxy Tab 9",
                Brand = "Samsung",
                Price = 35000,
                CreatedDate = DateTime.Now
            });

            builder.Entity<ProductInventory>().HasData(new ProductInventory
            {
                Id = 1,
                ProductId = 1,
                CurrentStock = 30,
                CreatedDate = DateTime.Now
            });

            builder.Entity<ProductInventoryLog>().HasData(new ProductInventoryLog
            {
                Id = 1,
                ProductInventoryId = 1,
                Quantity = 30,
                Type = dto.ProductInventoryMovementType.Stockin,
                CreatedDate = DateTime.Now
            });


        }
    }
}