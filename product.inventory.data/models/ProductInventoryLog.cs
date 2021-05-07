using product.inventory.dto;

namespace product.inventory.data.models
{
    public class ProductInventoryLog : BaseEntity
    {
        public int ProductInventoryId { get; set; }
        public ProductInventory ProductInventory { get; set; }
        public int Quantity { get; set; }
        public ProductInventoryMovementType Type { get; set; }
    }
}