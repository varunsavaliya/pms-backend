using System.Linq.Expressions;

namespace PMS.Repository.Interface
{
    public interface IGenericRepository<T>
        where T : class
    {
        #region Methods
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetAsync(Expression<Func<T, bool>> @where);

        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where);

        Task<T> InsertAsync(T entity);

        Task<IEnumerable<T>> InsertManyAsync(IEnumerable<T> entity);

        Task UpdateAsync(T entity);

        Task UpdateManyAsync(IEnumerable<T> entity);

        Task DeleteAsync(T entity);

        Task DeleteManyAsync(Expression<Func<T, bool>> @where);

        #endregion
    }
}
