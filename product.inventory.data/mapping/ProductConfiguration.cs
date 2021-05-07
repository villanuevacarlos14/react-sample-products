using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product.inventory.data.models;

namespace product.inventory.data.mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdateDate);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Brand);
            builder.Property(x => x.Price).IsRequired();
        }
    }
}