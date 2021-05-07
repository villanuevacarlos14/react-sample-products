using System;
using System.Linq;
using System.Threading.Tasks;

namespace product.inventory.data.repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProductInventoryContext _context;

        public Repository(ProductInventoryContext context)
        {
            _context = context;
        }
        public async Task<TEntity> GetAsync(int id)
        {
            try
            {
                return await _context.FindAsync<TEntity>(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(string.Format("{0} entity must not be null", nameof(AddAsync)));
            }

            try
            {
                await _context.AddAsync(entity).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(string.Format("{0} entity must not be null", nameof(AddAsync)));
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public virtual void Update(TEntity obj)
        {
            _context.Update(obj);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}