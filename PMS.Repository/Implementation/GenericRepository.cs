using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Repository.Interface;
using System.Data;
using System.Linq.Expressions;

namespace PMS.Repository.Implementation
{
    public abstract class GenericRepository<T>(PMSDbContext dbContext) : IGenericRepository<T>
         where T : class
    {
        #region Properties and fields
        protected readonly PMSDbContext _dbContext = dbContext;

        protected DbSet<T> Dbset
        {
            get { return _dbContext.Set<T>(); }
        }

        #endregion

        #region Public Methods
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await Dbset.AsNoTracking().ToListAsync();

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> @where) => await Dbset.Where(where).AsNoTracking().FirstOrDefaultAsync();

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where) => await Dbset.Where(where).AsNoTracking().ToListAsync();

        public virtual async Task<T> InsertAsync(T entity)
        {
            Dbset.Add(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> InsertManyAsync(IEnumerable<T> entities)
        {
            Dbset.AddRange(entities);
            await SaveChangesAsync();
            return entities;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public virtual async Task UpdateManyAsync(IEnumerable<T> entities)
        {
            entities.ToList().ForEach(entity => _dbContext.Entry(entity).State = EntityState.Modified);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            Dbset.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteManyAsync(Expression<Func<T, bool>> @where) => await Dbset.Where(where).ExecuteDeleteAsync();

        #endregion

        #region Private Methods
        private async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        #endregion
    }
}
