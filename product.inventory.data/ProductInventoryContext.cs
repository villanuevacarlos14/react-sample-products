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
        }
    }
}