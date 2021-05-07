using System.Linq;
using System.Threading.Tasks;

namespace product.inventory.data.repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);

        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> Delete(TEntity entity);

        void Update(TEntity obj);

        int SaveChanges();
    }
}