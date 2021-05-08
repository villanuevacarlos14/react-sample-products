using System.Collections.Generic;

namespace product.inventory.data.models
{
    public class ProductInventory : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CurrentStock { get; set; }
        public virtual IEnumerable<ProductInventoryLog> ProductInventoryLogs { get; set; }
    }
}