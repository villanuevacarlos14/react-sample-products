using product.inventory.data.models;

namespace product.inventory.data.repository
{
    public class ProductInventoryLogRepository : Repository<ProductInventoryLog>, IProductInventoryLogRepository
    {
        public ProductInventoryLogRepository(ProductInventoryContext context) : base(context)
        {
        }
    }
}