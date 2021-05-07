namespace product.inventory.data.models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}