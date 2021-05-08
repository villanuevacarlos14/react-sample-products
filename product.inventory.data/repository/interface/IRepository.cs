using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace product.inventory.data.repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(int id, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> Delete(TEntity entity);

        void Update(TEntity obj);

        int SaveChanges();
    }
}