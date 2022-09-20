using System.Linq.Expressions;
using AutoMapper;
using Management.Partners.Domain.Base;
using Management.Partners.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Management.Partners.Infrastructure.Repositories
{
    internal class GenericRepository<TModel, TEntity> : IGenericRepository<TModel> 
        where TModel : BaseModel
        where TEntity : Base.BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        public GenericRepository(DbContext context, IMapper mapper)
        {
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task AddAsync(TModel entity)
        {
            var dbModel = _mapper.Map<TEntity>(entity);

            await _dbSet.AddAsync(dbModel);
        }

        public async Task AddRangeAsync(IEnumerable<TModel> entities)
        {
           var models = entities.Select(_mapper.Map<TEntity>).ToList();

            await _dbSet.AddRangeAsync(models);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var dbModels = await _dbSet.ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> filter)
        {
            var modelFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModels =  await _dbSet.Where(modelFilter).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> filter, int skip = 0, int take = 15)
        {
            var modelFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModels = await _dbSet.Where(modelFilter).Skip(skip).Take(take).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> filter, Expression<Func<TModel, object>> orderBy, bool isDesc, int skip = 0, int take = 15)
        {
            var modelFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbOrderBy = _mapper.Map<Expression<Func<TEntity, object>>>(orderBy);

            var query = isDesc ? _dbSet.OrderByDescending(dbOrderBy) : _dbSet.OrderBy(dbOrderBy);

            var dbModels = await query.Skip(skip).Take(take).Where(modelFilter).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<P>(params Expression<Func<TModel, P>>[] includes) where P : BaseModel
        {
            var dbModels = await QueryWithIncludes(includes).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<P>(int skip = 0, int take = 15, params Expression<Func<TModel, P>>[] includes) where P : BaseModel
        {
            var dbModels = await QueryWithIncludes(includes).Skip(skip).Take(take).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<P>(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, P>>[] includes) where P : BaseModel
        {
            var dbFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModels = await QueryWithIncludes(includes).Where(dbFilter).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }
        
        public async Task<IEnumerable<TModel>> GetAllAsync<P>(Expression<Func<TModel, bool>> filter, int skip = 0, int take = 15, params Expression<Func<TModel, P>>[] includes) where P : BaseModel
        {
            var dbFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModels = await QueryWithIncludes(includes).Where(dbFilter).Skip(skip).Take(take).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<P>(Expression<Func<TModel, P>> orderBy, bool isDesc, int skip = 0, int take = 15)
        {
            var dbOrderBy = _mapper.Map<Expression<Func<TEntity, P>>>(orderBy);

            var query = isDesc ? _dbSet.OrderByDescending(dbOrderBy) : _dbSet.OrderBy(dbOrderBy);

            var dbModels = await query.Skip(skip).Take(take).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<P>(params Expression<Func<TModel, ICollection<P>>>[] includes) where P : BaseModel
        {
            var dbModels = await QueryWithIncludesAsync(includes).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<P>(Expression<Func<TModel, object>> orderBy, bool isDesc, int skip = 0, int take = 15, params Expression<Func<TModel, ICollection<P>>>[] includes) where P : BaseModel
        {
            var query = QueryWithIncludesAsync(includes);

            var dbOrderBy = _mapper.Map<Expression<Func<TEntity, object>>>(orderBy);

            query = !isDesc ? query.OrderBy(dbOrderBy).Skip(skip).Take(take) : query.OrderByDescending(dbOrderBy).Skip(skip).Take(take);

            var dbModels = await query.Skip(skip).Take(take).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<P>(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, ICollection<P>>>[] includes) where P : BaseModel
        {
            var dbFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModels = await QueryWithIncludesAsync(includes).Where(dbFilter).ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<P>(Expression<Func<TModel, bool>> filter = null, int skip = 0, int take = 15, params Expression<Func<TModel, ICollection<P>>>[] includes) where P : BaseModel
        {
            var dbFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModels = await QueryWithIncludesAsync(includes)
                .Where(dbFilter)
                .Skip(skip).Take(take)
                .ToListAsync();

            return dbModels.Select(_mapper.Map<TModel>).ToList();
        }

        public async Task<TModel> GetAsync(Guid id)
        {
            var dbModel = await _dbSet.FindAsync(id);
            if (dbModel == null)
            {
                return null;
            }

            return _mapper.Map<TModel>(dbModel);
        }

        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter)
        {
            var dbFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModel = await _dbSet.FirstOrDefaultAsync(dbFilter);
            if (dbModel == null)
            {
                return null;
            }

            return _mapper.Map<TModel>(dbModel);
        }

        public async Task<TModel> GetAsync<P>(Guid id, params Expression<Func<TModel, P>>[] includes) where P : BaseModel
        {
            var dbModel = await QueryWithIncludes(includes).FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TModel>(dbModel);
        }

        public async Task<TModel> GetAsync<P>(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, P>>[] includes) where P : BaseModel
        {
            var dbFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModel = await QueryWithIncludes(includes).FirstOrDefaultAsync(dbFilter);

            return _mapper.Map<TModel>(dbModel);
        }

        public async Task<TModel> GetAsync<P>(Guid id, params Expression<Func<TModel, ICollection<P>>>[] includes) where P : BaseModel
        {
            var dbModel = await QueryWithIncludesAsync(includes).FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TModel>(dbModel);
        }

        public async Task<TModel> GetAsync<P>(Expression<Func<TModel, bool>> filter, params Expression<Func<TModel, ICollection<P>>>[] includes) where P : BaseModel
        {
            var dbFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);

            var dbModel = await QueryWithIncludesAsync(includes).FirstOrDefaultAsync(dbFilter);
    
            return _mapper.Map<TModel>(dbModel);
        }

        public TModel Update(TModel entity)
        {
            var dbModel = _mapper.Map<TEntity>(entity);

            var entry = _dbSet.Update(dbModel);

            return _mapper.Map<TModel>(entry);
        }

        public void Remove(TModel entity)
        {
            var dbModel = _mapper.Map<TEntity>(entity);

            _dbSet.Remove(dbModel);
        }

        public void RemoveRange(IEnumerable<TModel> entities)
        {
            var dbModels = entities.Select(_mapper.Map<TEntity>).ToList();

            _dbSet.RemoveRange(dbModels);
        }

        private IQueryable<TEntity> QueryWithIncludes<P>(params Expression<Func<TModel, P>>[] includes) where P : BaseModel
        {
            var query = _dbSet.AsQueryable<TEntity>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    var includeExpr = _mapper.Map<Expression<Func<TEntity, ICollection<P>>>>(include);
                    query = query.Include(includeExpr);
                }
            }

            return query;
        }

        private IQueryable<TEntity> QueryWithIncludesAsync<P>(params Expression<Func<TModel, ICollection<P>>>[] includes) where P : BaseModel
        {
            var query = _dbSet.AsQueryable<TEntity>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    var includeExpr = _mapper.Map<Expression<Func<TEntity, ICollection<P>>>>(include) as Expression<Func<TEntity, ICollection<P>>>;
                    query = query.Include(includeExpr);
                }
            }

            return query;
        }
    }
}

