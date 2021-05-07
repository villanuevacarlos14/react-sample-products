using product.inventory.data.models;

namespace product.inventory.data.repository
{
    public class ProductInventoryRepository : Repository<ProductInventory>, IProductInventoryRepository
    {
        public ProductInventoryRepository(ProductInventoryContext context) : base(context)
        {
        }
    }
}