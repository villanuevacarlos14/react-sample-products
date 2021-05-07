using System.Collections.Generic;

namespace product.inventory.data.models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int ProductInventoryId { get; set; }
        public ProductInventory ProductInventory { get; set; }
    }
}