using PMS.Repository.Interface;
using PMS.Service.Interface;
using System.Linq.Expressions;

namespace PMS.Service.Implementation
{
    public abstract class BaseService<T>(IGenericRepository<T> repository) : IBaseService<T>
        where T : class
    {
        #region Properties and fields
        protected readonly IGenericRepository<T> _repository = repository;

        #endregion

        #region Public Methods
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> @where) => await _repository.GetAsync(where);

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where) => await _repository.GetManyAsync(where);

        public virtual async Task<T> InsertAsync(T entity) => await _repository.InsertAsync(entity);

        public virtual async Task<IEnumerable<T>> InsertManyAsync(IEnumerable<T> entities) => await _repository.InsertManyAsync(entities);

        public virtual async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);

        public virtual async Task UpdateManyAsync(IEnumerable<T> entities) => await _repository.UpdateManyAsync(entities);

        public virtual async Task DeleteAsync(T entity) => await _repository.DeleteAsync(entity);

        public virtual async Task DeleteManyAsync(Expression<Func<T, bool>> @where) => await _repository.DeleteManyAsync(@where);

        #endregion
    }
}
