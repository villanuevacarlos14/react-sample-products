namespace product.inventory.dto
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }
}