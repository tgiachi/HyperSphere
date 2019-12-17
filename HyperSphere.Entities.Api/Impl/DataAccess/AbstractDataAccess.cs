using HyperSphere.Api.Core.Data.Entities;
using HyperSphere.Api.Core.Interfaces.DataAccess;
using HyperSphere.Api.Core.Interfaces.Entities;
using HyperSphere.Entities.Api.Impl.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace HyperSphere.Entities.Api.Impl.DataAccess
{
    public class AbstractDataAccess<TEntity> : IDataAccess<TEntity> where TEntity : class, IEntity
    {

        private readonly ILogger<IDataAccess<TEntity>> _logger;
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public AbstractDataAccess(DbContext dbContext, ILogger<IDataAccess<TEntity>> logger)
        {

            _logger = logger;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public long Count()
        {
            var count = _dbSet.Count();
            _logger.LogDebug($"Entities count: {count}");

            return count;
        }

        public async Task<long> CountAsync()
        {
            var count = await _dbSet.CountAsync();
            _logger.LogDebug($"Entities count: {count}");
            return count;
        }

        public bool Delete(Func<TEntity, bool> query)
        {
            var itemsToDelete = _dbSet.Where(query);
            _dbSet.RemoveRange(itemsToDelete);

            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.RemoveRange(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public List<TEntity> FindAll()
        {
            var items = _dbSet.ToList();

            return items;
        }



        public async Task<List<TEntity>> FindAllAsync()
        {
            var items = await _dbSet.ToListAsync();
            return items;
        }

        public TEntity FindById(Guid id)
        {
            var item = _dbSet.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public TEntity Insert(TEntity entity)
        {
            var entityState = _dbContext.Add(entity);

            
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entityState = await _dbContext.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public PagedEntityResult<TEntity> PagedQuery(int pageSize, int pageNum, IQueryable<TEntity> query)
        {
            var pagedResult = new PagedEntityResult<TEntity>()
            {
                PageSize = pageSize,
                Count = query.Count()
            };

            var pageCount = (double)pagedResult.Count / pageSize;
            pagedResult.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (pageNum - 1) * pageSize;
            pagedResult.Result = query.Skip(skip).Take(pageSize).ToList();

            return pagedResult;
        }

        public List<TEntity> Query(Func<TEntity, bool> query)
        {
            var queryable = _dbSet.FromCache().Where(query);

            return queryable.ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
