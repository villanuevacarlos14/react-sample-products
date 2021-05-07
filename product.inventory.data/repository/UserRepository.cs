using product.inventory.data.models;

namespace product.inventory.data.repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProductInventoryContext context) : base(context)
        {
        }
    }
}