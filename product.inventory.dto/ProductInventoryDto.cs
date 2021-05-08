using System.Collections.Generic;

namespace product.inventory.dto
{
    public class ProductInventoryDto : BaseDto
    {
        public int ProductId { get; set; }
        public int CurrentStock { get; set; }
        public IEnumerable<ProductInventoryLogDto> ProductInventoryLogs { get; set; }
    }
}