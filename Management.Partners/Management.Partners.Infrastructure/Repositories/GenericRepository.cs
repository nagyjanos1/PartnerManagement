using System.Linq.Expressions;
using AutoMapper;
using Management.Partners.Domain.Base;
using Management.Partners.Domain.Interfaces;
using Management.Partners.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Management.Partners.Infrastructure.Repositories
{
    internal class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity> 
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        private readonly DbSet<TModel> _dbSet;
        private readonly IMapper _mapper;

        public GenericRepository(DbContext context, IMapper mapper)
        {
            _dbSet = context.Set<TModel>();
            _mapper = mapper;
        }

        public async Task AddAsync(TEntity entity)
        {
            var dbModel = _mapper.Map<TModel>(entity);

            await _dbSet.AddAsync(dbModel);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
           var models = entities.Select(_mapper.Map<TModel>).ToList();

            await _dbSet.AddRangeAsync(models);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var dbModels = await _dbSet.ToListAsync();

            return dbModels.Select(_mapper.Map<TEntity>).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            var modelFilter = _mapper.Map<Expression<Func<TModel, bool>>>(filter);

            var dbModels =  await _dbSet.Where(modelFilter).ToListAsync();

            return dbModels.Select(_mapper.Map<TEntity>).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<P>(params Expression<Func<TEntity, P>>[] includes) where P : BaseEntity
        {
            var dbModels = await QueryWithIncludes(includes).ToListAsync();

            return dbModels.Select(_mapper.Map<TEntity>).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<P>(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, P>>[] includes) where P : BaseEntity
        {
            var dbFilter = _mapper.Map<Expression<Func<TModel, bool>>>(filter);

            var dbModels = await QueryWithIncludes(includes).Where(dbFilter).ToListAsync();

            return dbModels.Select(_mapper.Map<TEntity>).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<P>(params Expression<Func<TEntity, ICollection<P>>>[] includes) where P : BaseEntity
        {
            var dbModels = await QueryWithIncludes(includes).ToListAsync();

            return dbModels.Select(_mapper.Map<TEntity>).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<P>(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, ICollection<P>>>[] includes) where P : BaseEntity
        {
            var dbFilter = _mapper.Map<Expression<Func<TModel, bool>>>(filter);

            var dbModels = await QueryWithIncludes(includes).Where(dbFilter).ToListAsync();

            return dbModels.Select(_mapper.Map<TEntity>).ToList();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            var dbModel = await _dbSet.FindAsync(id);
            if (dbModel == null)
            {
                return null;
            }

            return _mapper.Map<TEntity>(dbModel);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var dbFilter = _mapper.Map<Expression<Func<TModel, bool>>>(filter);

            var dbModel = await _dbSet.FirstOrDefaultAsync(dbFilter);
            if (dbModel == null)
            {
                return null;
            }

            return _mapper.Map<TEntity>(dbModel);
        }

        public async Task<TEntity> GetAsync<P>(Guid id, params Expression<Func<TEntity, P>>[] includes) where P : BaseEntity
        {
            var dbModel = await QueryWithIncludes(includes).FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TEntity>(dbModel);
        }

        public async Task<TEntity> GetAsync<P>(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, P>>[] includes) where P : BaseEntity
        {
            var dbFilter = _mapper.Map<Expression<Func<TModel, bool>>>(filter);

            var dbModel = await QueryWithIncludes(includes).FirstOrDefaultAsync(dbFilter);

            return _mapper.Map<TEntity>(dbModel);
        }

        public async Task<TEntity> GetAsync<P>(Guid id, params Expression<Func<TEntity, ICollection<P>>>[] includes) where P : BaseEntity
        {
            var dbModel = await QueryWithIncludes(includes).FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TEntity>(dbModel);
        }

        public async Task<TEntity> GetAsync<P>(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, ICollection<P>>>[] includes) where P : BaseEntity
        {
            var dbFilter = _mapper.Map<Expression<Func<TModel, bool>>>(filter);

            var dbModel = await QueryWithIncludes(includes).FirstOrDefaultAsync(dbFilter);
    
            return _mapper.Map<TEntity>(dbModel);
        }

        public TEntity Update(TEntity entity)
        {
            var dbModel = _mapper.Map<TModel>(entity);

            var entry = _dbSet.Update(dbModel);

            return _mapper.Map<TEntity>(entry);
        }

        public void Remove(TEntity entity)
        {
            var dbModel = _mapper.Map<TModel>(entity);

            _dbSet.Remove(dbModel);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            var dbModels = entities.Select(_mapper.Map<TModel>).ToList();

            _dbSet.RemoveRange(dbModels);
        }

        private IQueryable<TModel> QueryWithIncludes<P>(params Expression<Func<TEntity, P>>[] includes) where P : BaseEntity
        {
            var query = _dbSet.AsQueryable<TModel>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    var includeExpr = _mapper.Map<Expression<Func<TModel, ICollection<P>>>>(include);
                    query = query.Include(includeExpr);
                }
            }

            return query;
        }

        private IQueryable<TModel> QueryWithIncludes<P>(params Expression<Func<TEntity, ICollection<P>>>[] includes) where P : BaseEntity
        {
            var query = _dbSet.AsQueryable<TModel>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    var includeExpr = _mapper.Map<Expression<Func<TModel, ICollection<P>>>>(include);
                    query = query.Include(includeExpr);
                }
            }

            return query;
        }
    }
}

