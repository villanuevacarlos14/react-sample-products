using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product.inventory.data.models;

namespace product.inventory.data.mapping
{
    public class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdateDate);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.CurrentStock);

            builder
                .HasOne<Product>(x => x.Product)
                .WithOne(x => x.ProductInventory);
        }
    }
}