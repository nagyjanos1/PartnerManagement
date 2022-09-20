using AutoMapper;
using Management.Partners.Domain.Base;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Infrastructure.Entities;
using Management.Partners.Infrastructure.Repositories;

namespace Management.Partners.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, Type> _repositoryTypes = new()
        {
            { typeof(Domain.Partners.Partner), typeof(GenericRepository<Domain.Partners.Partner, Partner>) },
            { typeof(Domain.Partners.Address), typeof(GenericRepository<Domain.Partners.Address, Address>) },
        };

        private readonly PartnerDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnitOfWork(PartnerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseModel
        {
            if (_repositoryTypes.TryGetValue(typeof(T), out var repositoryType))
            {
                var instance = Activator.CreateInstance(repositoryType, _dbContext, _mapper);
                return instance as IGenericRepository<T>;
            }

            throw new Exception();
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
