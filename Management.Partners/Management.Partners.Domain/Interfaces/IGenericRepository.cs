using System.Linq.Expressions;
using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync<P>(Guid id, params Expression<Func<T, P>>[] includes) where P : BaseEntity;
        Task<T> GetAsync<P>(Guid id, params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity;
        Task<T> GetAsync<P>(Expression<Func<T, bool>> filter, params Expression<Func<T, P>>[] includes) where P : BaseEntity;
        Task<T> GetAsync<P>(Expression<Func<T, bool>> filter, params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity;
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync<P>(params Expression<Func<T, P>>[] includes) where P : BaseEntity;
        Task<IEnumerable<T>> GetAllAsync<P>(params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity;
        Task<IEnumerable<T>> GetAllAsync<P>(Expression<Func<T, bool>> filter, params Expression<Func<T, P>>[] includes) where P : BaseEntity;
        Task<IEnumerable<T>> GetAllAsync<P>(Expression<Func<T, bool>> filter, params Expression<Func<T, ICollection<P>>>[] includes) where P : BaseEntity;
        Task AddAsync(T model);
        Task AddRangeAsync(IEnumerable<T> models);
        T Update(T model);
        void Remove(T model);
        void RemoveRange(IEnumerable<T> models);
    }
}