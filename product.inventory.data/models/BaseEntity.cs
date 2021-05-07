using System;

namespace product.inventory.data.models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}