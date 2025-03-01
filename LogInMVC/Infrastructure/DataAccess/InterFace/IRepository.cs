using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.InterFace
{
    public interface IRepository<TEntity,TId>
        where TEntity : BaseEntity<TId>
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] navProp);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] navProp);

        Task<TEntity> GetByIdAsync(TId id, params string[] navProp);

        Task<TEntity> InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TId id);
    }
}
