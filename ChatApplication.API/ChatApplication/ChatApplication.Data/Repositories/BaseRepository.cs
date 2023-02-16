using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ChatApplication.Data.Entities;
using ChatApplication.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly Context _db;
        
        protected abstract IQueryable<TEntity> CollectionWithIncludes { get; set; }

        private DbSet<TEntity> DbSet { get; }
        
        protected BaseRepository(Context context)
        {
            _db = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);

            var savedAmount = await _db.SaveChangesAsync();

            if (savedAmount > 0)
            {
                return entity;
            }

            return null;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntityEntry = DbSet.Update(entity);

            await _db.SaveChangesAsync();

            var updatedEntity = await FindByIdAsync(updatedEntityEntry.Entity.Id);

            return updatedEntity;
        }

        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return await CollectionWithIncludes.ToListAsync();
            }

            return await CollectionWithIncludes.Where(filter).ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await CollectionWithIncludes.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var deletingEntity = await CollectionWithIncludes.FirstOrDefaultAsync(x => x.Id == id);

            DbSet.Remove(deletingEntity);

            await _db.SaveChangesAsync();
        }
    }
}