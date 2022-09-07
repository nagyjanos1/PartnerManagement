using Management.Partners.Domain.Base;

namespace Management.Partners.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;

        Task<bool> SaveAsync();
    }
}
