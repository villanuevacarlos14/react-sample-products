using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product.inventory.data.models;

namespace product.inventory.data.mapping
{
    public class ProductInventoryLogConfiguration : IEntityTypeConfiguration<ProductInventoryLog>
    {
        public void Configure(EntityTypeBuilder<ProductInventoryLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdateDate);
            builder.Property(x => x.ProductInventoryId).IsRequired();
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Type).IsRequired();

            builder
                .HasOne<ProductInventory>(x => x.ProductInventory)
                .WithMany(x => x.ProductInventoryLogs)
                .HasForeignKey(x => x.ProductInventoryId);
        }
    }
}