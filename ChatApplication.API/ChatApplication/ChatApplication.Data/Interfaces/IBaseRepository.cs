using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ChatApplication.Data.Entities;

namespace ChatApplication.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        
        Task<TEntity> UpdateAsync(TEntity entity);
        
        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        
        Task<TEntity> FindByIdAsync(Guid id);

        Task DeleteByIdAsync(Guid id);
    }
}