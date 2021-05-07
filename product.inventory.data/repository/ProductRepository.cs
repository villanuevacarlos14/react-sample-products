using product.inventory.data.models;

namespace product.inventory.data.repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductInventoryContext context) : base(context)
        {
        }
    }
}