namespace product.inventory.dto
{
    public class ProductInventoryDto : BaseDto
    {
        public int ProductId { get; set; }
        public int CurrentStock { get; set; }
    }
}