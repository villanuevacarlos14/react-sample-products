namespace product.inventory.dto
{
    public class ProductInventoryLogDto : BaseDto
    {
        public int ProductInventoryId { get; set; }
        public int Quantity { get; set; }
        public ProductInventoryMovementType Type { get; set; }

    }
}